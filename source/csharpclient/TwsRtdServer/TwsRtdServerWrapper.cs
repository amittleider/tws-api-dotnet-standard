using System;
using System.Collections.Generic;
using System.Collections;
using Microsoft.Office.Interop.Excel;
using IBApi;

namespace TwsRtdServer
{
    public class TwsRtdServerWrapper : EWrapper
    {
        private TwsRtdServer m_server;
        private TwsRtdServerConnection m_connection;

        // constructor
        public TwsRtdServerWrapper() {}

        public TwsRtdServerWrapper(TwsRtdServer server, TwsRtdServerConnection connection)
        {
            m_server = server;
            m_connection = connection;
        }

        void SetTopicValue(int tickerId, int field, object value)
        {
            TwsRtdServerMktDataRequest mktDataRequest = m_connection.GetMktDataRequest(tickerId);
            string topicStr = TwsRtdServerData.GetTopicStrByTickType(field);

            if (mktDataRequest != null && topicStr != null)
            {
	            TwsRtdServerTopic topic = mktDataRequest.GetTopic(topicStr);

    	        if (topic != null)
        	    {
            	    // set topic's new value
                	topic.TopicValue(value);

	                m_server.AddUpdatedTopicId(topic.TopicId());  // add topic to updatedTopicIds array
    	        }

                // save latest value
                mktDataRequest.SetMktDataTickValue(topicStr, value);
            }
        }

        void SetAllTopicsValues(int tickerId, string value)
        {
            TwsRtdServerMktDataRequest mktDataRequest = m_connection.GetMktDataRequest(tickerId);
            if (mktDataRequest != null)
            {
                m_server.AddUpdatedTopicIds(mktDataRequest.SetAllTopicsValues(value));
            }
        }

        public void error(Exception e) { }
        public void error(string str) { }
        public void error(int id, int errorCode, string errorMsg) 
        {
            // errors
            // 502 - Couldn't connect to TWS
            if (id == -1 && errorCode == 502) 
            {
                m_connection.SetError(TwsRtdServerErrors.CANNOT_CONNECT_TO_TWS, errorMsg);
            }
            // mktDataRequest error
            // 429 - delta neutral combo only
            // 313 - invalid combo legs
            // 321 - validate req error
            // 200 - no secdef found
            // 10154 - leg not supported
            // 322 - process req error
            // 10089 - API data requires subscription
            // 354 - market data not subscribed
            if (id != -1 && 
                (   errorCode == 429 || 
                    errorCode == 313 || 
                    errorCode == 321 ||
                    errorCode == 200 ||
                    errorCode == 10154 ||
                    errorCode == 322 ||
                    errorCode == 10089 ||
                    errorCode == 354
                 ))
            {
                TwsRtdServerMktDataRequest mktDataRequest = m_connection.GetMktDataRequest(id);
                if (mktDataRequest != null)
                {
                    mktDataRequest.SetError(TwsRtdServerErrors.REQUEST_MKT_DATA_ERROR, errorMsg);
                }
                SetAllTopicsValues(id, "TwsRtdServer error: " + errorMsg);
            }
        }

        public void currentTime(long time) { }
        public void tickPrice(int tickerId, int field, double price, /*unused*/ TickAttrib attribs) 
        {
            SetTopicValue(tickerId, field, price);
        }

        public void tickSize(int tickerId, int field, int size) 
        { 
            SetTopicValue(tickerId, field, size);
        }
        
        public void tickString(int tickerId, int field, string value) 
        { 
            SetTopicValue(tickerId, field, value);
        }

        public void tickGeneric(int tickerId, int field, double value) 
        {
            SetTopicValue(tickerId, field, value);
        }

        public void tickEFP(int tickerId, int tickType, double basisPoints, string formattedBasisPoints, double impliedFuture, int holdDays, string futureLastTradeDate, double dividendImpact, double dividendsToLastTradeDate) 
        { 
            // TODO: add support for tickEFP
        }

        public void deltaNeutralValidation(int reqId, UnderComp underComp) { }
        public void tickOptionComputation(int tickerId, int field, double impliedVolatility, double delta, double optPrice, double pvDividend, double gamma, double vega, double theta, double undPrice) 
        { 
            // TODO: add support for tickOptionComputation
        }

        public void tickSnapshotEnd(int tickerId) { }
        public void nextValidId(int orderId) { }
        public void managedAccounts(string accountsList) { }
        public void connectionClosed() { }
        public void accountSummary(int reqId, string account, string tag, string value, string currency) { }
        public void accountSummaryEnd(int reqId) { }
        public void bondContractDetails(int reqId, ContractDetails contract) { }
        public void updateAccountValue(string key, string value, string currency, string accountName) { }
        public void updatePortfolio(Contract contract, double position, double marketPrice, double marketValue,
            double averageCost, double unrealisedPNL, double realisedPNL, string accountName) { }
        public void updateAccountTime(string timestamp) { }
        public void accountDownloadEnd(string account) { }
        public void orderStatus(int orderId, string status, double filled, double remaining, double avgFillPrice,
            int permId, int parentId, double lastFillPrice, int clientId, string whyHeld) { }
        public void openOrder(int orderId, Contract contract, Order order, OrderState orderState) { }
        public void openOrderEnd() { }
        public void contractDetails(int reqId, ContractDetails contractDetails) { }
        public void contractDetailsEnd(int reqId) { }
        public void execDetails(int reqId, Contract contract, Execution execution) { }
        public void execDetailsEnd(int reqId) { }
        public void commissionReport(CommissionReport commissionReport) { }
        public void fundamentalData(int reqId, string data) { }
        public void historicalData(int reqId, Bar bar) { }
        public void historicalDataUpdate(int reqId, Bar bar) { }
        public void historicalDataEnd(int reqId, string start, string end) { }
        public void marketDataType(int reqId, int marketDataType) { }
        public void updateMktDepth(int tickerId, int position, int operation, int side, double price, int size) { }
        public void updateMktDepthL2(int tickerId, int position, string marketMaker, int operation, int side, double price, int size) { }
        public void updateNewsBulletin(int msgId, int msgType, String message, String origExchange) { }
        public void position(string account, Contract contract, double pos, double avgCost) { }
        public void positionEnd() { }
        public void realtimeBar(int reqId, long time, double open, double high, double low, double close, long volume, double WAP, int count) { }
        public void scannerParameters(string xml) { }
        public void scannerData(int reqId, int rank, ContractDetails contractDetails, string distance, string benchmark, string projection, string legsStr) { }
        public void scannerDataEnd(int reqId) { }
        public void receiveFA(int faDataType, string faXmlData) { }
        public void verifyMessageAPI(string apiData) { }
        public void verifyCompleted(bool isSuccessful, string errorText) { }
        public void verifyAndAuthMessageAPI(string apiData, string xyzChallenge) { }
        public void verifyAndAuthCompleted(bool isSuccessful, string errorText) { }
        public void displayGroupList(int reqId, string groups) { }
        public void displayGroupUpdated(int reqId, string contractInfo) { }
        public void connectAck() { }
        public void positionMulti(int requestId, string account, string modelCode, Contract contract, double pos, double avgCost) { }
        public void positionMultiEnd(int requestId) { }
        public void accountUpdateMulti(int requestId, string account, string modelCode, string key, string value, string currency) { }
        public void accountUpdateMultiEnd(int requestId) { }
        public void securityDefinitionOptionParameter(int reqId, string exchange, int underlyingConId, string tradingClass, string multiplier, HashSet<string> expirations, HashSet<double> strikes) { }
        public void securityDefinitionOptionParameterEnd(int reqId) { }
        public void softDollarTiers(int reqId, SoftDollarTier[] tiers) { }
        public void familyCodes(FamilyCode[] familyCodes) { }
        public void symbolSamples(int reqId, ContractDescription[] contractDescriptions) { }
        public void mktDepthExchanges(DepthMktDataDescription[] depthMktDataDescriptions) { }
        public void tickNews(int tickerId, long timeStamp, string providerCode, string articleId, string headline, string extraData) { }
        public void smartComponents(int reqId, Dictionary<int, KeyValuePair<string, char>> theMap) { }
        public void tickReqParams(int tickerId, double minTick, string bboExchange, int snapshotPermissions) { }
        public void newsProviders(NewsProvider[] newsProviders) { }
        public void newsArticle(int requestId, int articleType, string articleText) { }
        public void historicalNews(int requestId, string time, string providerCode, string articleId, string headline) { }
        public void historicalNewsEnd(int requestId, bool hasMore) { }
        public void headTimestamp(int reqId, string headTimestamp) { }
        public void histogramData(int reqId, HistogramEntry[] data) { }

        public void rerouteMktDataReq(int reqId, int conId, string exchange)
        {
            TwsRtdServerMktDataRequest mktDataRequest = m_connection.GetMktDataRequest(reqId);
            String errorMsg = "Re-route market data request to conId:" + conId + " exchange:" + exchange;
            if (mktDataRequest != null)
            {
                mktDataRequest.SetError(TwsRtdServerErrors.REQUEST_MKT_DATA_ERROR, errorMsg);
            }
            SetAllTopicsValues(reqId, "TwsRtdServer error: " + errorMsg);
        }

        public void rerouteMktDepthReq(int reqId, int conId, string exchange) { }
    }
}
