/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

#include "ConnectionVerifyTest.h"
#include "EPosixClientSocket.h"
#include "EPosixClientSocketPlatform.h"

#include <assert.h>

const int PING_DEADLINE = 2; // seconds
const int SLEEP_BETWEEN_PINGS = 30; // seconds

///////////////////////////////////////////////////////////
// member funcs
ConnectionVerifyTest::ConnectionVerifyTest(const char * apiName, const char * apiVersion)
	: m_pClient(new EPosixClientSocket(this))
	, m_state(ST_CONNECT)
	, m_sleepDeadline(0)
	, m_apiData("")
	, m_apiName(apiName)
	, m_apiVersion(apiVersion)
	, m_rsa(NULL)
{
}

ConnectionVerifyTest::~ConnectionVerifyTest()
{
	if (m_rsa)
		RSA_free(m_rsa);
}

bool ConnectionVerifyTest::connect(const char *host, unsigned int port, int clientId)
{
	assert (m_state == ST_CONNECT);

	// trying to connect
	printf( "Connecting to %s:%d clientId:%d\n", !( host && *host) ? "127.0.0.1" : host, port, clientId);

	bool bRes = m_pClient->eConnect( host, port, clientId, /* extraAuth */ true);

	if (bRes) {
		printf( "Connected to %s:%d clientId:%d\n", !( host && *host) ? "127.0.0.1" : host, port, clientId);
		m_state = ST_VERIFYREQUEST;
	}
	else
		printf( "Cannot connect to %s:%d clientId:%d\n", !( host && *host) ? "127.0.0.1" : host, port, clientId);

	return bRes;
}

void ConnectionVerifyTest::disconnect()
{
	m_pClient->eDisconnect();
	m_state = ST_CONNECT;
	m_sleepDeadline = 0;
	m_apiData = "";

	printf ( "Disconnected\n");
}

bool ConnectionVerifyTest::isConnected() const
{
	return m_pClient->isConnected();
}

void ConnectionVerifyTest::processMessages()
{
	fd_set readSet, writeSet, errorSet;

	struct timeval tval;
	tval.tv_usec = 0;
	tval.tv_sec = 0;

	time_t now = time(NULL);

	switch (m_state) {
		case ST_VERIFYREQUEST:
			verifyRequest();
			break;
		case ST_VERIFYREQUEST_ACK:
			break;
		case ST_VERIFYMESSAGE:
			verifyMessage();
			break;
		case ST_VERIFYMESSAGE_ACK:
			break;
		case ST_PING:
			reqCurrentTime();
			break;
		case ST_PING_ACK:
			if( m_sleepDeadline < now) {
				disconnect();
				return;
			}
			break;
		case ST_IDLE:
			if( m_sleepDeadline < now) {
				m_state = ST_PING;
				return;
			}
			break;
	}

	if( m_sleepDeadline > 0) {
		// initialize timeout with m_sleepDeadline - now
		tval.tv_sec = m_sleepDeadline - now;
	}

	if( m_pClient->fd() >= 0 ) {

		FD_ZERO( &readSet);
		errorSet = writeSet = readSet;

		FD_SET( m_pClient->fd(), &readSet);

		if( !m_pClient->isOutBufferEmpty())
			FD_SET( m_pClient->fd(), &writeSet);

		FD_SET( m_pClient->fd(), &errorSet);

		int ret = select( m_pClient->fd() + 1, &readSet, &writeSet, &errorSet, &tval);

		if( ret == 0) { // timeout
			return;
		}

		if( ret < 0) {	// error
			disconnect();
			return;
		}

		if( m_pClient->fd() < 0)
			return;

		if( FD_ISSET( m_pClient->fd(), &errorSet)) {
			// error on socket
			m_pClient->onError();
		}

		if( m_pClient->fd() < 0)
			return;

		if( FD_ISSET( m_pClient->fd(), &writeSet)) {
			// socket is ready for writing
			m_pClient->onSend();
		}

		if( m_pClient->fd() < 0)
			return;

		if( FD_ISSET( m_pClient->fd(), &readSet)) {
			// socket is ready for reading
			m_pClient->onReceive();
		}
	}
}

//////////////////////////////////////////////////////////////////
// methods
void ConnectionVerifyTest::reqCurrentTime()
{
	printf( "Requesting Current Time\n");

	// set ping deadline to "now + n seconds"
	m_sleepDeadline = time( NULL) + PING_DEADLINE;

	m_state = ST_PING_ACK;

	m_pClient->reqCurrentTime();
}

void ConnectionVerifyTest::verifyRequest()
{

	printf( "verifyRequest sent: apiName=%s apiVersion=%s\n", m_apiName, m_apiVersion);

	m_state = ST_VERIFYREQUEST_ACK;

	m_pClient->verifyRequest( m_apiName, m_apiVersion);
}

void ConnectionVerifyTest::verifyMessage()
{
	printf( "verifyMessage sent: apiData=%s\n", m_apiData.c_str());

	m_state = ST_VERIFYMESSAGE_ACK;

	m_pClient->verifyMessage( m_apiData);
}

///////////////////////////////////////////////////////////////////
// events

void ConnectionVerifyTest::verifyMessageAPI( const std::string& apiData)
{
	m_apiData = apiData;

	printf( "verifyMessageAPI is received: apiData=%s\n", m_apiData.c_str());

	// 1. base64-decode data (m_apiData)
	printf( "Started base64 decoding of API data: %s\n", m_apiData.c_str());

	m_apiData = base64_decode(m_apiData);

	if (m_apiData.empty()){
		// error during base64 decoding - disconnecting
		disconnect();
		return;
	}

	printf( "API data is base64 decoded: %s\n", m_apiData.c_str());

	// 2. calculate SHA1 signature of data (m_apiData) using OpenSSL
	printf( "Started to calculate SHA1 signature of API data: %s\n", m_apiData.c_str());

	m_apiData = calculateSHA1Signature(m_apiData);

	if (m_apiData.empty()){
		// error during sha1 calculation - disconnecting
		disconnect();
		return;
	}

	// 3. sign data using the private key by using RSA_sign function of Open SSL on SHA1 signature of the data
	printf( "Signing API data using RSA_sign function ...\n");

	m_apiData = signDataWithPrivateKey(m_apiData);

	if (m_apiData.empty()){
		// error during RSA signing - disconnecting
		disconnect();
		return;
	}

	printf( "API data was signed.\n");

	// 4. base64-encode the resulting byte stream
	printf( "Started base64 encoding of signed API data ...\n");

	m_apiData = base64_encode(m_apiData);

	if (m_apiData.empty()){
		// error during base64 encoding - disconnecting
		disconnect();
		return;
	}

	printf( "API data is base64 encoded.\n");

	if( m_state == ST_VERIFYREQUEST_ACK)
		m_state = ST_VERIFYMESSAGE;
}

void ConnectionVerifyTest::verifyCompleted( bool isSuccessful, const std::string& errorText)
{
	printf( "verifyCompleted is received: isSuccessful=%s errorText=%s\n", isSuccessful ? "true" : "false", errorText.c_str());

	if( m_state == ST_VERIFYMESSAGE_ACK)
		m_state = ST_PING;

}

void ConnectionVerifyTest::currentTime( long time)
{
	if ( m_state == ST_PING_ACK) {
		time_t t = ( time_t)time;
		struct tm * timeinfo = localtime ( &t);
		printf( "The current date/time is: %s", asctime( timeinfo));

		time_t now = ::time(NULL);
		m_sleepDeadline = now + SLEEP_BETWEEN_PINGS;

		m_state = ST_IDLE;
	}
}

void ConnectionVerifyTest::error(const int id, const int errorCode, const std::string errorString)
{
	printf( "Error id=%d, errorCode=%d, msg=%s\n", id, errorCode, errorString.c_str());

	if( id == -1 && errorCode == 1100) // if "Connectivity between IB and TWS has been lost"
		disconnect();
}

void ConnectionVerifyTest::nextValidId( OrderId orderId) {}
void ConnectionVerifyTest::tickPrice( TickerId tickerId, TickType field, double price, int canAutoExecute) {}
void ConnectionVerifyTest::tickSize( TickerId tickerId, TickType field, int size) {}
void ConnectionVerifyTest::tickOptionComputation( TickerId tickerId, TickType tickType, double impliedVol, double delta,
											 double optPrice, double pvDividend,
											 double gamma, double vega, double theta, double undPrice) {}
void ConnectionVerifyTest::tickGeneric(TickerId tickerId, TickType tickType, double value) {}
void ConnectionVerifyTest::tickString(TickerId tickerId, TickType tickType, const std::string& value) {}
void ConnectionVerifyTest::tickEFP(TickerId tickerId, TickType tickType, double basisPoints, const std::string& formattedBasisPoints,
							   double totalDividends, int holdDays, const std::string& futureExpiry, double dividendImpact, double dividendsToExpiry) {}
void ConnectionVerifyTest::orderStatus( OrderId orderId, const std::string &status, int filled,
	   int remaining, double avgFillPrice, int permId, int parentId,
	   double lastFillPrice, int clientId, const std::string& whyHeld) {}
void ConnectionVerifyTest::openOrder( OrderId orderId, const Contract&, const Order&, const OrderState& ostate) {}
void ConnectionVerifyTest::openOrderEnd() {}
void ConnectionVerifyTest::winError( const std::string &str, int lastError) {}
void ConnectionVerifyTest::connectionClosed() {}
void ConnectionVerifyTest::updateAccountValue(const std::string& key, const std::string& val,
										  const std::string& currency, const std::string& accountName) {}
void ConnectionVerifyTest::updatePortfolio(const Contract& contract, int position,
		double marketPrice, double marketValue, double averageCost,
		double unrealizedPNL, double realizedPNL, const std::string& accountName){}
void ConnectionVerifyTest::updateAccountTime(const std::string& timeStamp) {}
void ConnectionVerifyTest::accountDownloadEnd(const std::string& accountName) {}
void ConnectionVerifyTest::contractDetails( int reqId, const ContractDetails& contractDetails) {}
void ConnectionVerifyTest::bondContractDetails( int reqId, const ContractDetails& contractDetails) {}
void ConnectionVerifyTest::contractDetailsEnd( int reqId) {}
void ConnectionVerifyTest::execDetails( int reqId, const Contract& contract, const Execution& execution) {}
void ConnectionVerifyTest::execDetailsEnd( int reqId) {}

void ConnectionVerifyTest::updateMktDepth(TickerId id, int position, int operation, int side,
									  double price, int size) {}
void ConnectionVerifyTest::updateMktDepthL2(TickerId id, int position, std::string marketMaker, int operation,
										int side, double price, int size) {}
void ConnectionVerifyTest::updateNewsBulletin(int msgId, int msgType, const std::string& newsMessage, const std::string& originExch) {}
void ConnectionVerifyTest::managedAccounts( const std::string& accountsList) {}
void ConnectionVerifyTest::receiveFA(faDataType pFaDataType, const std::string& cxml) {}
void ConnectionVerifyTest::historicalData(TickerId reqId, const std::string& date, double open, double high,
									  double low, double close, int volume, int barCount, double WAP, int hasGaps) {}
void ConnectionVerifyTest::scannerParameters(const std::string &xml) {}
void ConnectionVerifyTest::scannerData(int reqId, int rank, const ContractDetails &contractDetails,
	   const std::string &distance, const std::string &benchmark, const std::string &projection,
	   const std::string &legsStr) {}
void ConnectionVerifyTest::scannerDataEnd(int reqId) {}
void ConnectionVerifyTest::realtimeBar(TickerId reqId, long time, double open, double high, double low, double close,
								   long volume, double wap, int count) {}
void ConnectionVerifyTest::fundamentalData(TickerId reqId, const std::string& data) {}
void ConnectionVerifyTest::deltaNeutralValidation(int reqId, const UnderComp& underComp) {}
void ConnectionVerifyTest::tickSnapshotEnd(int reqId) {}
void ConnectionVerifyTest::marketDataType(TickerId reqId, int marketDataType) {}
void ConnectionVerifyTest::commissionReport( const CommissionReport& commissionReport) {}
void ConnectionVerifyTest::position( const std::string& account, const Contract& contract, int position, double avgCost) {}
void ConnectionVerifyTest::positionEnd() {}
void ConnectionVerifyTest::accountSummary( int reqId, const std::string& account, const std::string& tag, const std::string& value, const std::string& curency) {}
void ConnectionVerifyTest::accountSummaryEnd( int reqId) {}
void ConnectionVerifyTest::displayGroupList( int reqId, const std::string& groups) {}
void ConnectionVerifyTest::displayGroupUpdated( int reqId, const std::string& contractInfo) {}


//////////////////////////////////////////////////////////////////////////
//
//  calculate SHA1 signature of data string using OpenSSL
//
//////////////////////////////////////////////////////////////////////////
std::string ConnectionVerifyTest::calculateSHA1Signature(const std::string& dataString)
{
	unsigned char digest[SHA_DIGEST_LENGTH];

	SHA_CTX ctx;
	
	// init SHA1 digest calculator
	if (SHA1_Init(&ctx) <= 0){
		print_ssl_error("Error during SHA1_Init() call.\n");
		return std::string();
	}

	// update SHA1 digest value
	if (SHA1_Update(&ctx, dataString.data(), dataString.size()) <= 0){
		print_ssl_error("Error during SHA1_Update() call.\n");
		return std::string();
	}

	// destroy SHA1 digest calculator
	if (SHA1_Final(digest, &ctx) <= 0){
		print_ssl_error("Error during SHA1_Final() call.\n");
		return std::string();
	}

	return std::string((const char*)digest, SHA_DIGEST_LENGTH);
}

//////////////////////////////////////////////////////////////////////////
//
//  base64 encode of data string using OpenSSL
//
//////////////////////////////////////////////////////////////////////////
std::string ConnectionVerifyTest::base64_encode(std::string& input_string)
{
	const char * input = input_string.c_str();
	int length = input_string.size();

	BIO * bmem = NULL;
	BIO * b64 = NULL;
	BUF_MEM * bptr = NULL;

	// create new BIO object
	b64 = BIO_new( BIO_f_base64());

	if (b64 == NULL){
		print_ssl_error("Error during BIO_new() call.\n");
		return std::string();
	}

	// create new BIO object
	bmem = BIO_new( BIO_s_mem());

	if (bmem == NULL){
		print_ssl_error("Error during BIO_new() call.\n");
		BIO_free_all( b64);
		return std::string();
	}

	// set flag to encode all data in single line
	BIO_set_flags( b64, BIO_FLAGS_BASE64_NO_NL);

	// append bmem to b64
	b64 = BIO_push( b64, bmem);

	if (b64 == NULL){
		print_ssl_error("Error during BIO_push() call.\n");
		BIO_free_all( bmem);
		return std::string();
	}

	// write 'length' bytes of data from input to b64
	if (BIO_write( b64, input, length) <= 0){
		print_ssl_error("Error during BIO_write() call.\n");
		BIO_free_all( b64);
		return std::string();
	}

	if (BIO_flush( b64) <= 0){
		print_ssl_error("Error during BIO_flush() call.\n");
		BIO_free_all( b64);
		return std::string();
	}

	BIO_get_mem_ptr( b64, &bptr);

	if (bptr == NULL){
		print_ssl_error("Error during BIO_get_mem_ptr() call.\n");
		BIO_free_all( b64);
		return std::string();
	}

	std::string output_string(bptr->data, bptr->length);

	BIO_free_all( b64);

	return output_string;
}

//////////////////////////////////////////////////////////////////////////
//
//  base64 decode of data string using OpenSSL
//
//////////////////////////////////////////////////////////////////////////
std::string ConnectionVerifyTest::base64_decode(std::string& input_string)
{
	const char * input = input_string.c_str();
	int length = input_string.size();
	BIO *bmem;
	BIO *b64;

	std::string output_string;
	output_string.resize(length);

	b64 = BIO_new( BIO_f_base64());

	if (b64 == NULL){
		print_ssl_error("Error during BIO_push() call.\n");
		return std::string();
	}

	BIO_set_flags( b64, BIO_FLAGS_BASE64_NO_NL);

	bmem = BIO_new_mem_buf( (void *)input, length);

	if (bmem == NULL){
		print_ssl_error("Error during BIO_new_mem_buf() call.\n");
		BIO_free_all( b64);
		return std::string();
	}

	bmem = BIO_push( b64, bmem);

	if (bmem == NULL){
		print_ssl_error("Error during BIO_push() call.\n");
		BIO_free_all( bmem);
		return std::string();
	}

	length = BIO_read( bmem, &output_string[0], length);

	BIO_free_all( bmem);

	if (length <= 0){
		print_ssl_error("Error during BIO_read() call.\n");
		return std::string();
	}

	output_string.resize(length);
	return output_string;
}

//////////////////////////////////////////////////////////////////////////
//
//  signing data string with private key using OpenSSL and SHA1 algorithm
//
//////////////////////////////////////////////////////////////////////////
std::string ConnectionVerifyTest::signDataWithPrivateKey(const std::string& apiData) 
{

	std::string sig;
	sig.resize(RSA_size(m_rsa));

	unsigned sig_len = 0;

	if (!RSA_sign(NID_sha1, (const unsigned char*)apiData.data(), apiData.size(), (unsigned char*)&sig[0], &sig_len, m_rsa)){
		print_ssl_error("Unable to sign data using RSA_sign method.\n");
		return std::string();
	}

	if (sig_len != sig.size())
		sig.resize(sig_len);

	return sig;
}

//////////////////////////////////////////////////////////////////////////
//
//  initializing private key
//
//////////////////////////////////////////////////////////////////////////
bool ConnectionVerifyTest::initPrivateKey(const char * fileName) 
{
	assert (!m_rsa);

	FILE* fp = fopen(fileName, "r");

	if (!fp){
		printf( "Error: can't open private key file: %s\n", fileName);
		return false;
	}

	if ((PEM_read_RSAPrivateKey(fp, &m_rsa, NULL, NULL)) == NULL){
		printf( "Error: can't load private key from file: %s\n", fileName);
		fclose(fp);
		return false;
	}

	printf( "Private key is initialized from %s\n", fileName);
	fclose(fp);
	fp = NULL;

	return true;
}

void ConnectionVerifyTest::print_ssl_error(const char * message)
{
	printf(message);
	printf("Error: %s\n", ERR_reason_error_string(ERR_get_error()));
	printf("Error: %s\n", ERR_error_string(ERR_get_error(), NULL));
}
