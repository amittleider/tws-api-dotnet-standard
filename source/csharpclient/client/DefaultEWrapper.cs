using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBApi
{
    public class DefaultEWrapper : EWrapper
    {
        public void error(Exception e)
        {
        }

        public void error(string str)
        {
        }

        public void error(int id, int errorCode, string errorMsg)
        {
        }

        public void currentTime(long time)
        {
        }

        public void tickPrice(int tickerId, int field, double price, int canAutoExecute)
        {
        }

        public void tickSize(int tickerId, int field, int size)
        {
        }

        public void tickString(int tickerId, int field, string value)
        {
        }

        public void tickGeneric(int tickerId, int field, double value)
        {
        }

        public void tickEFP(int tickerId, int tickType, double basisPoints, string formattedBasisPoints, double impliedFuture, int holdDays, string futureExpiry, double dividendImpact, double dividendsToExpiry)
        {
        }

        public void deltaNeutralValidation(int reqId, UnderComp underComp)
        {
        }

        public void tickOptionComputation(int tickerId, int field, double impliedVolatility, double delta, double optPrice, double pvDividend, double gamma, double vega, double theta, double undPrice)
        {
        }

        public void tickSnapshotEnd(int tickerId)
        {
        }

        public void nextValidId(int orderId)
        {
        }

        public void managedAccounts(string accountsList)
        {
        }

        public void connectionClosed()
        {
        }

        public void accountSummary(int reqId, string account, string tag, string value, string currency)
        {
        }

        public void accountSummaryEnd(int reqId)
        {
        }

        public void bondContractDetails(int reqId, ContractDetails contract)
        {
        }

        public void updateAccountValue(string key, string value, string currency, string accountName)
        {
        }

        public void updatePortfolio(Contract contract, int position, double marketPrice, double marketValue, double averageCost, double unrealisedPNL, double realisedPNL, string accountName)
        {
        }

        public void updateAccountTime(string timestamp)
        {
        }

        public void accountDownloadEnd(string account)
        {
        }

        public void orderStatus(int orderId, string status, int filled, int remaining, double avgFillPrice, int permId, int parentId, double lastFillPrice, int clientId, string whyHeld)
        {
        }

        public void openOrder(int orderId, Contract contract, Order order, OrderState orderState)
        {
        }

        public void openOrderEnd()
        {
        }

        public void contractDetails(int reqId, ContractDetails contractDetails)
        {
        }

        public void contractDetailsEnd(int reqId)
        {
        }

        public void execDetails(int reqId, Contract contract, Execution execution)
        {
        }

        public void execDetailsEnd(int reqId)
        {
        }

        public void commissionReport(CommissionReport commissionReport)
        {
        }

        public void fundamentalData(int reqId, string data)
        {
        }

        public void historicalData(int reqId, string date, double open, double high, double low, double close, int volume, int count, double WAP, bool hasGaps)
        {
        }

        public void historicalDataEnd(int reqId, string start, string end)
        {
        }

        public void marketDataType(int reqId, int marketDataType)
        {
        }

        public void updateMktDepth(int tickerId, int position, int operation, int side, double price, int size)
        {
        }

        public void updateMktDepthL2(int tickerId, int position, string marketMaker, int operation, int side, double price, int size)
        {
        }

        public void updateNewsBulletin(int msgId, int msgType, string message, string origExchange)
        {
        }

        public void position(string account, Contract contract, int pos, double avgCost)
        {
        }

        public void positionEnd()
        {
        }

        public void realtimeBar(int reqId, long time, double open, double high, double low, double close, long volume, double WAP, int count)
        {
        }

        public void scannerParameters(string xml)
        {
        }

        public void scannerData(int reqId, int rank, ContractDetails contractDetails, string distance, string benchmark, string projection, string legsStr)
        {
        }

        public void scannerDataEnd(int reqId)
        {
        }

        public void receiveFA(int faDataType, string faXmlData)
        {
        }

        public void verifyMessageAPI(string apiData)
        {
        }

        public void verifyCompleted(bool isSuccessful, string errorText)
        {
        }

        public void verifyAndAuthMessageAPI(string apiData, string xyzChallenge)
        {
        }

        public void verifyAndAuthCompleted(bool isSuccessful, string errorText)
        {
        }

        public void displayGroupList(int reqId, string groups)
        {
        }

        public void displayGroupUpdated(int reqId, string contractInfo)
        {
        }
    }
}
