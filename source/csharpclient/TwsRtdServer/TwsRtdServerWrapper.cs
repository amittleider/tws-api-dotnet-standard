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
        private int nextOrderId;

        // constructor
        public TwsRtdServerWrapper() {}

        public TwsRtdServerWrapper(TwsRtdServer server, TwsRtdServerConnection connection)
        {
            m_server = server;
            m_connection = connection;
        }

        public int NextOrderId
        {
            get { return nextOrderId; }
            set { nextOrderId = value; }
        }

        void SetTopicValue(int tickerId, int field, object value)
        {
            TwsRtdServerMktDataRequest mktDataRequest = m_connection.GetMktDataRequest(tickerId);
            string tickTypeStr = TwsRtdServerData.GetTickTypeStrByTickId(field);

            if (mktDataRequest != null && tickTypeStr != null)
            {
                GetTopicAndAddUpdate(tickTypeStr, mktDataRequest, value);
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

        void SetAllLiveTopicsValues(int tickerId, string value)
        {
            TwsRtdServerMktDataRequest mktDataRequest = m_connection.GetMktDataRequest(tickerId);
            if (mktDataRequest != null)
            {
                m_server.AddUpdatedTopicIds(mktDataRequest.SetAllLiveTopicsValues(value));
            }
        }

        void SetOptionComputationTopicsValues(int tickerId, int field, TwsRtdServerData.OptionComputationData value)
        {
            TwsRtdServerMktDataRequest mktDataRequest = m_connection.GetMktDataRequest(tickerId);
            string tickTypeStr = TwsRtdServerData.GetTickTypeStrByTickId(field);

            if (mktDataRequest != null && tickTypeStr != null)
            {
                switch (tickTypeStr)
                {
                        // assigning implied vol, delta, opt price, pv dividend, gamma, vega, theta and und price
                    case TwsRtdServerData.BID_OPTION_COMPUTATION:
                        GetTopicAndAddUpdate(TwsRtdServerData.BID_IMPLIED_VOL, mktDataRequest, value.getImpliedVolatility());
                        GetTopicAndAddUpdate(TwsRtdServerData.BID_DELTA, mktDataRequest, value.getDelta());
                        GetTopicAndAddUpdate(TwsRtdServerData.BID_OPT_PRICE, mktDataRequest, value.getOptPrice());
                        GetTopicAndAddUpdate(TwsRtdServerData.BID_PV_DIVIDEND, mktDataRequest, value.getPvDividend());
                        GetTopicAndAddUpdate(TwsRtdServerData.BID_GAMMA, mktDataRequest, value.getGamma());
                        GetTopicAndAddUpdate(TwsRtdServerData.BID_VEGA, mktDataRequest, value.getVega());
                        GetTopicAndAddUpdate(TwsRtdServerData.BID_THETA, mktDataRequest, value.getTheta());
                        GetTopicAndAddUpdate(TwsRtdServerData.BID_UND_PRICE, mktDataRequest, value.getUndPrice());
                        break;
                    case TwsRtdServerData.ASK_OPTION_COMPUTATION:
                        GetTopicAndAddUpdate(TwsRtdServerData.ASK_IMPLIED_VOL, mktDataRequest, value.getImpliedVolatility());
                        GetTopicAndAddUpdate(TwsRtdServerData.ASK_DELTA, mktDataRequest, value.getDelta());
                        GetTopicAndAddUpdate(TwsRtdServerData.ASK_OPT_PRICE, mktDataRequest, value.getOptPrice());
                        GetTopicAndAddUpdate(TwsRtdServerData.ASK_PV_DIVIDEND, mktDataRequest, value.getPvDividend());
                        GetTopicAndAddUpdate(TwsRtdServerData.ASK_GAMMA, mktDataRequest, value.getGamma());
                        GetTopicAndAddUpdate(TwsRtdServerData.ASK_VEGA, mktDataRequest, value.getVega());
                        GetTopicAndAddUpdate(TwsRtdServerData.ASK_THETA, mktDataRequest, value.getTheta());
                        GetTopicAndAddUpdate(TwsRtdServerData.ASK_UND_PRICE, mktDataRequest, value.getUndPrice());
                        break;
                    case TwsRtdServerData.LAST_OPTION_COMPUTATION:
                        GetTopicAndAddUpdate(TwsRtdServerData.LAST_IMPLIED_VOL, mktDataRequest, value.getImpliedVolatility());
                        GetTopicAndAddUpdate(TwsRtdServerData.LAST_DELTA, mktDataRequest, value.getDelta());
                        GetTopicAndAddUpdate(TwsRtdServerData.LAST_OPT_PRICE, mktDataRequest, value.getOptPrice());
                        GetTopicAndAddUpdate(TwsRtdServerData.LAST_PV_DIVIDEND, mktDataRequest, value.getPvDividend());
                        GetTopicAndAddUpdate(TwsRtdServerData.LAST_GAMMA, mktDataRequest, value.getGamma());
                        GetTopicAndAddUpdate(TwsRtdServerData.LAST_VEGA, mktDataRequest, value.getVega());
                        GetTopicAndAddUpdate(TwsRtdServerData.LAST_THETA, mktDataRequest, value.getTheta());
                        GetTopicAndAddUpdate(TwsRtdServerData.LAST_UND_PRICE, mktDataRequest, value.getUndPrice());
                        break;
                    case TwsRtdServerData.MODEL_OPTION_COMPUTATION:
                        GetTopicAndAddUpdate(TwsRtdServerData.MODEL_IMPLIED_VOL, mktDataRequest, value.getImpliedVolatility());
                        GetTopicAndAddUpdate(TwsRtdServerData.MODEL_DELTA, mktDataRequest, value.getDelta());
                        GetTopicAndAddUpdate(TwsRtdServerData.MODEL_OPT_PRICE, mktDataRequest, value.getOptPrice());
                        GetTopicAndAddUpdate(TwsRtdServerData.MODEL_PV_DIVIDEND, mktDataRequest, value.getPvDividend());
                        GetTopicAndAddUpdate(TwsRtdServerData.MODEL_GAMMA, mktDataRequest, value.getGamma());
                        GetTopicAndAddUpdate(TwsRtdServerData.MODEL_VEGA, mktDataRequest, value.getVega());
                        GetTopicAndAddUpdate(TwsRtdServerData.MODEL_THETA, mktDataRequest, value.getTheta());
                        GetTopicAndAddUpdate(TwsRtdServerData.MODEL_UND_PRICE, mktDataRequest, value.getUndPrice());
                        break;
                }
            }
        }

        void GetTopicAndAddUpdate(string topicStr, TwsRtdServerMktDataRequest mktDataRequest, object value)
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

        public void error(Exception e) { }
        public void error(string str) { }
        public void error(int id, int errorCode, string errorMsg) 
        {
            if (id == -1 && Array.IndexOf(TwsRtdServerErrors.TwsServerErrors(), errorCode) >= 0) 
            {
                m_connection.SetError(TwsRtdServerErrors.CANNOT_CONNECT_TO_TWS, errorMsg);
            }

            if (id != -1 && Array.IndexOf(TwsRtdServerErrors.TwsTickerErrors(), errorCode) >= 0)
            {
                TwsRtdServerMktDataRequest mktDataRequest = m_connection.GetMktDataRequest(id);
                if (mktDataRequest != null)
                {
                    mktDataRequest.SetError(errorCode, errorMsg);
                }

                switch (errorCode)
                {
                    case 10167:
                        {
                            SetAllLiveTopicsValues(id, "TwsRtdServer error: " + errorMsg);
                            break;
                        }
                    default:
                        {
                            SetAllTopicsValues(id, "TwsRtdServer error: " + errorMsg);
                            break;
                        }
                }
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
            TwsRtdServerData.OptionComputationData value = new TwsRtdServerData.OptionComputationData(impliedVolatility,
                delta, optPrice, pvDividend, gamma, vega, theta, undPrice);
            SetOptionComputationTopicsValues(tickerId, field, value);
        }

        public void tickSnapshotEnd(int tickerId) { }
        public void nextValidId(int orderId) {
            NextOrderId = orderId;
        }
        public void managedAccounts(string accountsList) { }
        public void connectionClosed() { }
        public void accountSummary(int reqId, string account, string tag, string value, string currency) { }
        public void accountSummaryEnd(int reqId) { }
        public void bondContractDetails(int reqId, ContractDetails contract) { }
        public void updateAccountValue(string key, string value, string currency, string accountName) { }
        public void updatePortfolio(Contract contract, double position, double marketPrice, double marketValue,
            double averageCost, double unrealizedPNL, double realizedPNL, string accountName) { }
        public void updateAccountTime(string timestamp) { }
        public void accountDownloadEnd(string account) { }
        public void orderStatus(int orderId, string status, double filled, double remaining, double avgFillPrice,
            int permId, int parentId, double lastFillPrice, int clientId, string whyHeld, double mktCapPrice) { }
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
        public void marketRule(int marketRuleId, PriceIncrement[] priceIncrements) { }
        public void pnl(int reqId, double dailyPnL, double unrealizedPnL, double realizedPnL) { }
        public void pnlSingle(int reqId, int pos, double dailyPnL, double unrealizedPnL, double realizedPnL, double value) { }
        public void historicalTicks(int reqId, HistoricalTick[] ticks, bool done) { }
        public void historicalTicksBidAsk(int reqId, HistoricalTickBidAsk[] ticks, bool done) { }
        public void historicalTicksLast(int reqId, HistoricalTickLast[] ticks, bool done) { }
    }
}
