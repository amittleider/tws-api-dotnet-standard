/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

#ifndef connectionverifytest_h__INCLUDED
#define connectionverifytest_h__INCLUDED

#include "EWrapper.h"
#include <memory>
#include <openssl/pem.h>
#include <openssl/err.h>

class EPosixClientSocket;

enum State {
	ST_CONNECT,
	ST_VERIFYREQUEST,
	ST_VERIFYREQUEST_ACK,
	ST_VERIFYMESSAGE,
	ST_VERIFYMESSAGE_ACK,
	ST_PING,
	ST_PING_ACK,
	ST_IDLE
};

class ConnectionVerifyTest : public EWrapper
{
public:

	ConnectionVerifyTest(const char * apiName, const char * apiVersion);
	~ConnectionVerifyTest();

	void processMessages();
public:

	bool initPrivateKey(const char * fileName);
	bool connect(const char * host, unsigned int port, int clientId = 0);
	void disconnect();
	bool isConnected() const;

private:

	void verifyRequest();
	void verifyMessage();
	void reqCurrentTime();


	std::string base64_decode(std::string& encoded_string);
	std::string base64_encode(std::string& decoded_string);
	std::string calculateSHA1Signature(const std::string &str);
	std::string signDataWithPrivateKey(const std::string& apiData);
	void print_ssl_error(const char * message);

public:
	// events
	void tickPrice(TickerId tickerId, TickType field, double price, int canAutoExecute);
	void tickSize(TickerId tickerId, TickType field, int size);
	void tickOptionComputation( TickerId tickerId, TickType tickType, double impliedVol, double delta,
		double optPrice, double pvDividend, double gamma, double vega, double theta, double undPrice);
	void tickGeneric(TickerId tickerId, TickType tickType, double value);
	void tickString(TickerId tickerId, TickType tickType, const std::string& value);
	void tickEFP(TickerId tickerId, TickType tickType, double basisPoints, const std::string& formattedBasisPoints,
		double totalDividends, int holdDays, const std::string& futureExpiry, double dividendImpact, double dividendsToExpiry);
	void orderStatus(OrderId orderId, const std::string &status, int filled,
		int remaining, double avgFillPrice, int permId, int parentId,
		double lastFillPrice, int clientId, const std::string& whyHeld);
	void openOrder(OrderId orderId, const Contract&, const Order&, const OrderState&);
	void openOrderEnd();
	void winError(const std::string &str, int lastError);
	void connectionClosed();
	void updateAccountValue(const std::string& key, const std::string& val,
		const std::string& currency, const std::string& accountName);
	void updatePortfolio(const Contract& contract, int position,
		double marketPrice, double marketValue, double averageCost,
		double unrealizedPNL, double realizedPNL, const std::string& accountName);
	void updateAccountTime(const std::string& timeStamp);
	void accountDownloadEnd(const std::string& accountName);
	void nextValidId(OrderId orderId);
	void contractDetails(int reqId, const ContractDetails& contractDetails);
	void bondContractDetails(int reqId, const ContractDetails& contractDetails);
	void contractDetailsEnd(int reqId);
	void execDetails(int reqId, const Contract& contract, const Execution& execution);
	void execDetailsEnd(int reqId);
	void error(const int id, const int errorCode, const std::string errorString);
	void updateMktDepth(TickerId id, int position, int operation, int side,
		double price, int size);
	void updateMktDepthL2(TickerId id, int position, std::string marketMaker, int operation,
		int side, double price, int size);
	void updateNewsBulletin(int msgId, int msgType, const std::string& newsMessage, const std::string& originExch);
	void managedAccounts(const std::string& accountsList);
	void receiveFA(faDataType pFaDataType, const std::string& cxml);
	void historicalData(TickerId reqId, const std::string& date, double open, double high,
		double low, double close, int volume, int barCount, double WAP, int hasGaps);
	void scannerParameters(const std::string &xml);
	void scannerData(int reqId, int rank, const ContractDetails &contractDetails,
		const std::string &distance, const std::string &benchmark, const std::string &projection,
		const std::string &legsStr);
	void scannerDataEnd(int reqId);
	void realtimeBar(TickerId reqId, long time, double open, double high, double low, double close,
		long volume, double wap, int count);
	void currentTime(long time);
	void fundamentalData(TickerId reqId, const std::string& data);
	void deltaNeutralValidation(int reqId, const UnderComp& underComp);
	void tickSnapshotEnd(int reqId);
	void marketDataType(TickerId reqId, int marketDataType);
	void commissionReport( const CommissionReport& commissionReport);
	void position( const std::string& account, const Contract& contract, int position, double avgCost);
	void positionEnd();
	void accountSummary( int reqId, const std::string& account, const std::string& tag, const std::string& value, const std::string& curency);
	void accountSummaryEnd( int reqId);
	void verifyMessageAPI( const std::string& apiData);
	void verifyCompleted( bool isSuccessful, const std::string& errorText);
	void displayGroupList( int reqId, const std::string& groups);
	void displayGroupUpdated( int reqId, const std::string& contractInfo);

private:

	std::auto_ptr<EPosixClientSocket> m_pClient;
	State m_state;
	time_t m_sleepDeadline;
	std::string m_apiData;
	const char * m_apiName;
	const char * m_apiVersion;
	RSA * m_rsa;
};

#endif

