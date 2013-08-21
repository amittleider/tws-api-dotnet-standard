using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBApi;
using System.Windows.Forms;
using IBSampleApp.messages;

namespace IBSampleApp
{
    public class IBClient : EWrapper
    {
        EClientSocket clientSocket;
        int nextOrderId;
        private IBSampleApp parentUI;

        public IBClient(IBSampleApp parent)
        {
            parentUI = parent;
            clientSocket = new EClientSocket(this);
        }

        public EClientSocket ClientSocket
        {
            get { return clientSocket; }
            set { clientSocket = value; }
        }

        public int NextOrderId
        {
            get { return nextOrderId; }
            set { nextOrderId = value; }
        }

        public virtual void error(Exception e)
        {
            addTextToBox("Error: " + e);
            throw e;//remove after testing!
        }

        public virtual void error(string str)
        {
            addTextToBox("Error: " + str + "\n");
        }

        public virtual void error(int id, int errorCode, string errorMsg)
        {
            //addTextToBox("Error. Id: " + id + ", Code: " + errorCode + ", Msg: " + errorMsg + "\n");
           parentUI.PostMessage(new ErrorMessage(id, errorCode, errorMsg));
        }

        public virtual void connectionClosed()
        {
            parentUI.IsConnected = false;
            parentUI.NotifyConnection();
        }

        public virtual void currentTime(long time)
        {
            addTextToBox("Current Time: " + time + "\n");
        }

        public virtual void tickPrice(int tickerId, int field, double price, int canAutoExecute)
        {
            //addTextToBox("Tick Price. Ticker Id:" + tickerId + ", Field: " + field + ", Price: " + price + ", CanAutoExecute: " + canAutoExecute + "\n");
            parentUI.PostMessage(new TickPriceMessage(tickerId, field, price, canAutoExecute));
        }

        public virtual void tickSize(int tickerId, int field, int size)
        {
            //addTextToBox("Tick Size. Ticker Id:" + tickerId + ", Field: " + field + ", Size: " + size + "\n");
            parentUI.PostMessage(new TickSizeMessage(tickerId, field, size));
        }

        public virtual void tickString(int tickerId, int tickType, string value)
        {
            addTextToBox("Tick string. Ticker Id:" + tickerId + ", Type: " + tickType + ", Value: " + value + "\n");
        }

        public virtual void tickGeneric(int tickerId, int field, double value)
        {
            addTextToBox("Tick Generic. Ticker Id:" + tickerId + ", Field: " + field + ", Value: " + value + "\n");
        }

        public virtual void tickEFP(int tickerId, int tickType, double basisPoints, string formattedBasisPoints, double impliedFuture, int holdDays, string futureExpiry, double dividendImpact, double dividendsToExpiry)
        {
            addTextToBox("TickEFP. " + tickerId + ", Type: " + tickType + ", BasisPoints: " + basisPoints + ", FormattedBasisPoints: " + formattedBasisPoints + ", ImpliedFuture: " + impliedFuture + ", HoldDays: " + holdDays + ", FutureExpiry: " + futureExpiry + ", DividendImpact: " + dividendImpact + ", DividendsToExpiry: " + dividendsToExpiry + "\n");
        }

        public virtual void tickSnapshotEnd(int tickerId)
        {
            addTextToBox("TickSnapshotEnd: " + tickerId + "\n");
        }

        public virtual void nextValidId(int orderId)
        {
            parentUI.IsConnected = true;
            NextOrderId = orderId;
            parentUI.NotifyConnection();
        }

        public virtual void deltaNeutralValidation(int reqId, UnderComp underComp)
        {
            addTextToBox("DeltaNeutralValidation. " + reqId + ", ConId: " + underComp.ConId + ", Delta: " + underComp.Delta + ", Price: " + underComp.Price + "\n");
        }

        public virtual void managedAccounts(string accountsList)
        {
            addTextToBox("Account list: " + accountsList + "\n");
        }

        public virtual void tickOptionComputation(int tickerId, int field, double impliedVolatility, double delta, double optPrice, double pvDividend, double gamma, double vega, double theta, double undPrice)
        {
            addTextToBox("TickOptionComputation. TickerId: " + tickerId + ", field: " + field + ", ImpliedVolatility: " + impliedVolatility + ", Delta: " + delta
                + ", OptionPrice: " + optPrice + ", pvDividend: " + pvDividend + ", Gamma: " + gamma + ", Vega: " + vega + ", Theta: " + theta + ", UnderlyingPrice: " + undPrice + "\n");
        }

        public virtual void accountSummary(int reqId, string account, string tag, string value, string currency)
        {
            addTextToBox("Acct Summary. ReqId: " + reqId + ", Acct: " + account + ", Tag: " + tag + ", Value: " + value + ", Currency: " + currency + "\n");
        }

        public virtual void accountSummaryEnd(int reqId)
        {
            addTextToBox("AccountSummaryEnd. Req Id: " + reqId + "\n");
        }

        public virtual void updateAccountValue(string key, string value, string currency, string accountName)
        {
            addTextToBox("UpdateAccountValue. Key: " + key + ", Value: " + value + ", Currency: " + currency + ", AccountName: " + accountName + "\n");
        }

        public virtual void updatePortfolio(Contract contract, int position, double marketPrice, double marketValue, double averageCost, double unrealisedPNL, double realisedPNL, string accountName)
        {
            addTextToBox("UpdatePortfolio. " + contract.Symbol + ", " + contract.SecType + " @ " + contract.Exchange
                + ": Position: " + position + ", MarketPrice: " + marketPrice + ", MarketValue: " + marketValue + ", AverageCost: " + averageCost
                + ", UnrealisedPNL: " + unrealisedPNL + ", RealisedPNL: " + realisedPNL + ", AccountName: " + accountName + "\n");
        }

        public virtual void updateAccountTime(string timestamp)
        {
            addTextToBox("UpdateAccountTime. Time: " + timestamp + "\n");
        }

        public virtual void accountDownloadEnd(string account)
        {
            addTextToBox("Account download finished: " + account + "\n");
        }

        public virtual void orderStatus(int orderId, string status, int filled, int remaining, double avgFillPrice, int permId, int parentId, double lastFillPrice, int clientId, string whyHeld)
        {
            addTextToBox("OrderStatus. Id: " + orderId + ", Status: " + status + ", Filled" + filled + ", Remaining: " + remaining
                + ", AvgFillPrice: " + avgFillPrice + ", PermId: " + permId + ", ParentId: " + parentId + ", LastFillPrice: " + lastFillPrice + ", ClientId: " + clientId + ", WhyHeld: " + whyHeld + "\n");
        }

        public virtual void openOrder(int orderId, Contract contract, Order order, OrderState orderState)
        {
            addTextToBox("OpenOrder. ID: " + orderId + ", " + contract.Symbol + ", " + contract.SecType + " @ " + contract.Exchange + ": " + order.Action + ", " + order.OrderType + " " + order.TotalQuantity + ", " + orderState.Status + "\n");
        }

        public virtual void openOrderEnd()
        {
            addTextToBox("OpenOrderEnd");
        }

        public virtual void contractDetails(int reqId, ContractDetails contractDetails)
        {
            addTextToBox("ContractDetails. ReqId: " + reqId + " - " + contractDetails.Summary.Symbol + ", " + contractDetails.Summary.SecType + ", ConId: " + contractDetails.Summary.ConId + " @ " + contractDetails.Summary.Exchange + "\n");
        }

        public virtual void contractDetailsEnd(int reqId)
        {
            addTextToBox("ContractDetailsEnd. " + reqId + "\n");
        }

        public virtual void execDetails(int reqId, Contract contract, Execution execution)
        {
            addTextToBox("ExecDetails. " + reqId + " - " + contract.Symbol + ", " + contract.SecType + ", " + contract.Currency + " - " + execution.ExecId + ", " + execution.OrderId + ", " + execution.Shares + "\n");
        }

        public virtual void execDetailsEnd(int reqId)
        {
            addTextToBox("ExecDetailsEnd. " + reqId + "\n");
        }

        public virtual void commissionReport(CommissionReport commissionReport)
        {
            addTextToBox("CommissionReport. " + commissionReport.ExecId + " - " + commissionReport.Commission + " " + commissionReport.Currency + " RPNL " + commissionReport.RealizedPNL + "\n");
        }

        public virtual void fundamentalData(int reqId, string data)
        {
            addTextToBox("FundamentalData. " + reqId + "" + data + "\n");
        }

        public virtual void historicalData(int reqId, string date, double open, double high, double low, double close, int volume, int count, double WAP, bool hasGaps)
        {
            //addTextToBox("HistoricalData. " + reqId + " - Date: " + date + ", Open: " + open + ", High: " + high + ", Low: " + low + ", Close: " + close + ", Volume: " + volume + ", Count: " + count + ", WAP: " + WAP + ", HasGaps: " + hasGaps + "\n");
            parentUI.PostMessage(new HistoricalDataMessage(reqId, date, open, high, low, close, volume, count, WAP, hasGaps));
        }

        public virtual void historicalDataEnd(int reqId, string startDate, string endDate)
        {
            parentUI.PostMessage(new HistoricalDataEndMessage(reqId, startDate, endDate));
        }

        public virtual void marketDataType(int reqId, int marketDataType)
        {
            //WARN: when we request this, we never send a requestId
            //This is also not returning anything when invoked
            addTextToBox("MarketDataType. " + reqId + ", Type: " + marketDataType + "\n");
        }

        public virtual void updateMktDepth(int tickerId, int position, int operation, int side, double price, int size)
        {
            parentUI.PostMessage(new DeepBookMessage(tickerId, position, operation, side, price, size, ""));
            //addTextToBox("UpdateMarketDepth. " + tickerId + " - Position: " + position + ", Operation: " + operation + ", Side: " + side + ", Price: " + price + ", Size" + size + "\n");
        }

        //WARN: Could not test!
        public virtual void updateMktDepthL2(int tickerId, int position, string marketMaker, int operation, int side, double price, int size)
        {
            //addTextToBox("UpdateMarketDepthL2. " + tickerId + " - Position: " + position + ", Operation: " + operation + ", Side: " + side + ", Price: " + price + ", Size" + size + "\n");
            parentUI.PostMessage(new DeepBookMessage(tickerId, position, operation, side, price, size, marketMaker));
        }

        //WARN: Could not test!
        public virtual void updateNewsBulletin(int msgId, int msgType, String message, String origExchange)
        {
            addTextToBox("News Bulletins. " + msgId + " - Type: " + msgType + ", Message: " + message + ", Exchange of Origin: " + origExchange + "\n");
        }

        public virtual void position(string account, Contract contract, int pos)
        {
            addTextToBox("Position. " + account + " - Symbol: " + contract.Symbol + ", SecType: " + contract.SecType + ", Currency: " + contract.Currency + ", Position: " + pos + "\n");
        }

        public virtual void positionEnd()
        {
            addTextToBox("PositionEnd \n");
        }

        public virtual void realtimeBar(int reqId, long time, double open, double high, double low, double close, long volume, double WAP, int count)
        {
            //addTextToBox("RealTimeBars. " + reqId + " - Time: " + time + ", Open: " + open + ", High: " + high + ", Low: " + low + ", Close: " + close + ", Volume: " + volume + ", Count: " + count + ", WAP: " + WAP + "\n");
            parentUI.PostMessage(new RealTimeBarMessage(reqId, time, open, high, low, close, volume, WAP, count));
        }

        public virtual void scannerParameters(string xml)
        {
            addTextToBox("ScannerParameters. " + xml + "\n");
        }

        public virtual void scannerData(int reqId, int rank, ContractDetails contractDetails, string distance, string benchmark, string projection, string legsStr)
        {
            parentUI.PostMessage(new ScannerMessage(reqId, rank, contractDetails, distance, benchmark, projection, legsStr));
            //addTextToBox("ScannerData. " + reqId + " - Rank: " + rank + ", Symbol: " + contractDetails.Summary.Symbol + ", SecType: " + contractDetails.Summary.SecType + ", Currency: " + contractDetails.Summary.Currency
            //    + ", Distance: " + distance + ", Benchmark: " + benchmark + ", Projection: " + projection + ", Legs String: " + legsStr + "\n");
        }

        public virtual void scannerDataEnd(int reqId)
        {
            addTextToBox("ScannerDataEnd. " + reqId + "\r\n");
        }

        public virtual void receiveFA(int faDataType, string faXmlData)
        {
            addTextToBox("Receing FA: " + faDataType + " - " + faXmlData + "\n");
        }

        private void addTextToBox(string text)
        {
            //parent.AddMessage(text);
        }

    }
}
