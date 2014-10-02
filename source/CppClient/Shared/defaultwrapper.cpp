#include "StdAfx.h"
#include "DefaultWrapper.h"

void DefaultWrapper::tickPrice( TickerId tickerId, TickType field, double price, int canAutoExecute) { }
void DefaultWrapper::tickSize( TickerId tickerId, TickType field, int size) { }
void DefaultWrapper::tickOptionComputation( TickerId tickerId, TickType tickType, double impliedVol, double delta,
	   double optPrice, double pvDividend, double gamma, double vega, double theta, double undPrice) { }
void DefaultWrapper::tickGeneric(TickerId tickerId, TickType tickType, double value) { }
void DefaultWrapper::tickString(TickerId tickerId, TickType tickType, const std::string& value) { }
void DefaultWrapper::tickEFP(TickerId tickerId, TickType tickType, double basisPoints, const std::string& formattedBasisPoints,
	   double totalDividends, int holdDays, const std::string& futureExpiry, double dividendImpact, double dividendsToExpiry) { }
void DefaultWrapper::orderStatus( OrderId orderId, const std::string& status, int filled,
	   int remaining, double avgFillPrice, int permId, int parentId,
	   double lastFillPrice, int clientId, const std::string& whyHeld) { }
void DefaultWrapper::openOrder( OrderId orderId, const Contract&, const Order&, const OrderState&) { }
void DefaultWrapper::openOrderEnd() { }
void DefaultWrapper::winError( const std::string& str, int lastError) { }
void DefaultWrapper::connectionClosed() { }
void DefaultWrapper::updateAccountValue(const std::string& key, const std::string& val,
   const std::string& currency, const std::string& accountName) { }
void DefaultWrapper::updatePortfolio( const Contract& contract, int position,
      double marketPrice, double marketValue, double averageCost,
      double unrealizedPNL, double realizedPNL, const std::string& accountName) { }
void DefaultWrapper::updateAccountTime(const std::string& timeStamp) { }
void DefaultWrapper::accountDownloadEnd(const std::string& accountName) { }
void DefaultWrapper::nextValidId( OrderId orderId) { }
void DefaultWrapper::contractDetails( int reqId, const ContractDetails& contractDetails) { }
void DefaultWrapper::bondContractDetails( int reqId, const ContractDetails& contractDetails) { }
void DefaultWrapper::contractDetailsEnd( int reqId) { }
void DefaultWrapper::execDetails( int reqId, const Contract& contract, const Execution& execution) { }
void DefaultWrapper::execDetailsEnd( int reqId) { }
void DefaultWrapper::error(const int id, const int errorCode, const std::string errorString) { }
void DefaultWrapper::updateMktDepth(TickerId id, int position, int operation, int side,
      double price, int size) { }
void DefaultWrapper::updateMktDepthL2(TickerId id, int position, std::string marketMaker, int operation,
      int side, double price, int size) { }
void DefaultWrapper::updateNewsBulletin(int msgId, int msgType, const std::string& newsMessage, const std::string& originExch) { }
void DefaultWrapper::managedAccounts( const std::string& accountsList) { }
void DefaultWrapper::receiveFA(faDataType pFaDataType, const std::string& cxml) { }
void DefaultWrapper::historicalData(TickerId reqId, const std::string& date, double open, double high, 
	   double low, double close, int volume, int barCount, double WAP, int hasGaps) { }
void DefaultWrapper::scannerParameters(const std::string& xml) { }
void DefaultWrapper::scannerData(int reqId, int rank, const ContractDetails& contractDetails,
	   const std::string& distance, const std::string& benchmark, const std::string& projection,
	   const std::string& legsStr) { }
void DefaultWrapper::scannerDataEnd(int reqId) { }
void DefaultWrapper::realtimeBar(TickerId reqId, long time, double open, double high, double low, double close,
	   long volume, double wap, int count) { }
void DefaultWrapper::currentTime(long time) { }
void DefaultWrapper::fundamentalData(TickerId reqId, const std::string& data) { }
void DefaultWrapper::deltaNeutralValidation(int reqId, const UnderComp& underComp) { }
void DefaultWrapper::tickSnapshotEnd( int reqId) { }
void DefaultWrapper::marketDataType( TickerId reqId, int marketDataType) { }
void DefaultWrapper::commissionReport( const CommissionReport& commissionReport) { }
void DefaultWrapper::position( const std::string& account, const Contract& contract, int position, double avgCost) { }
void DefaultWrapper::positionEnd() { }
void DefaultWrapper::accountSummary( int reqId, const std::string& account, const std::string& tag, const std::string& value, const std::string& curency) { }
void DefaultWrapper::accountSummaryEnd( int reqId) { }
void DefaultWrapper::verifyMessageAPI( const std::string& apiData) { }
void DefaultWrapper::verifyCompleted( bool isSuccessful, const std::string& errorText) { }
void DefaultWrapper::displayGroupList( int reqId, const std::string& groups) { }
void DefaultWrapper::displayGroupUpdated( int reqId, const std::string& contractInfo) { }
void DefaultWrapper::verifyAndAuthMessageAPI( const std::string& apiData, const std::string& xyzChallange) { }
void DefaultWrapper::verifyAndAuthCompleted( bool isSuccessful, const std::string& errorText) { }