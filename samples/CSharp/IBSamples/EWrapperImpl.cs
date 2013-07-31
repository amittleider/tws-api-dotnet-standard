using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBApi;

namespace Samples
{
    public class EWrapperImpl : EWrapper 
    {
        EClientSocket clientSocket;
        private int nextOrderId;
        
        public EWrapperImpl()
        {
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

        public void error(Exception e)
        {
            Console.WriteLine("Error: "+e);
            throw e;//remove after testing!
        }
        
        public void error(string str)
        {
            Console.WriteLine("Error: "+str+"\n");
        }
        
        public void error(int id, int errorCode, string errorMsg)
        {
            Console.WriteLine("Error. Id: " + id + ", Code: " + errorCode + ", Msg: " + errorMsg + "\n");
        }
        
        public void connectionClosed()
        {
            Console.WriteLine("Connection closed.\n");
        }
        
        public void currentTime(long time) 
        {
            Console.WriteLine("Current Time: "+time+"\n");
        }

        public void tickPrice(int tickerId, int field, double price, int canAutoExecute) 
        {
            Console.WriteLine("Tick Price. Ticker Id:"+tickerId+", Field: "+field+", Price: "+price+", CanAutoExecute: "+canAutoExecute+"\n");
        }
        
        public void tickSize(int tickerId, int field, int size)
        {
            Console.WriteLine("Tick Size. Ticker Id:" + tickerId + ", Field: " + field + ", Size: " + size+"\n");
        }
        
        public void tickString(int tickerId, int tickType, string value)
        {
            Console.WriteLine("Tick string. Ticker Id:" + tickerId + ", Type: " + tickType + ", Value: " + value+"\n");
        }

        public void tickGeneric(int tickerId, int field, double value)
        {
            Console.WriteLine("Tick Generic. Ticker Id:" + tickerId + ", Field: " + field + ", Value: " + value+"\n");
        }

        public void tickEFP(int tickerId, int tickType, double basisPoints, string formattedBasisPoints, double impliedFuture, int holdDays, string futureExpiry, double dividendImpact, double dividendsToExpiry)
        {
            Console.WriteLine("TickEFP. "+tickerId+", Type: "+tickType+", BasisPoints: "+basisPoints+", FormattedBasisPoints: "+formattedBasisPoints+", ImpliedFuture: "+impliedFuture+", HoldDays: "+holdDays+", FutureExpiry: "+futureExpiry+", DividendImpact: "+dividendImpact+", DividendsToExpiry: "+dividendsToExpiry+"\n");
        }

        public void tickSnapshotEnd(int tickerId)
        {
            Console.WriteLine("TickSnapshotEnd: "+tickerId+"\n");
        }

        public void nextValidId(int orderId) 
        {
            Console.WriteLine("Next Valid Id: "+orderId+"\n");
            NextOrderId = orderId;
        }

        public void deltaNeutralValidation(int reqId, UnderComp underComp)
        {
            Console.WriteLine("DeltaNeutralValidation. "+reqId+", ConId: "+underComp.ConId+", Delta: "+underComp.Delta+", Price: "+underComp.Price+"\n");
        }

        public void managedAccounts(string accountsList) 
        {
            Console.WriteLine("Account list: "+accountsList+"\n");
        }

        public void tickOptionComputation(int tickerId, int field, double impliedVolatility, double delta, double optPrice, double pvDividend, double gamma, double vega, double theta, double undPrice)
        {
            Console.WriteLine("TickOptionComputation. TickerId: "+tickerId+", field: "+field+", ImpliedVolatility: "+impliedVolatility+", Delta: "+delta
                +", OptionPrice: "+optPrice+", pvDividend: "+pvDividend+", Gamma: "+gamma+", Vega: "+vega+", Theta: "+theta+", UnderlyingPrice: "+undPrice+"\n");
        }

        public void accountSummary(int reqId, string account, string tag, string value, string currency)
        {
            Console.WriteLine("Acct Summary. ReqId: " + reqId + ", Acct: " + account + ", Tag: " + tag + ", Value: " + value + ", Currency: " + currency+"\n");
        }

        public void accountSummaryEnd(int reqId)
        {
            Console.WriteLine("AccountSummaryEnd. Req Id: "+reqId+"\n");
        }

        public void updateAccountValue(string key, string value, string currency, string accountName)
        {
            Console.WriteLine("UpdateAccountValue. Key: " + key + ", Value: " + value + ", Currency: " + currency + ", AccountName: " + accountName+"\n");
        }

        public void updatePortfolio(Contract contract, int position, double marketPrice, double marketValue, double averageCost, double unrealisedPNL, double realisedPNL, string accountName)
        {
            Console.WriteLine("UpdatePortfolio. "+contract.Symbol+", "+contract.SecType+" @ "+contract.Exchange
                +": Position: "+position+", MarketPrice: "+marketPrice+", MarketValue: "+marketValue+", AverageCost: "+averageCost
                +", UnrealisedPNL: "+unrealisedPNL+", RealisedPNL: "+realisedPNL+", AccountName: "+accountName+"\n");
        }

        public void updateAccountTime(string timestamp)
        {
            Console.WriteLine("UpdateAccountTime. Time: " + timestamp+"\n");
        }

        public void accountDownloadEnd(string account)
        {
            Console.WriteLine("Account download finished: "+account+"\n");
        }

        public void orderStatus(int orderId, string status, int filled, int remaining, double avgFillPrice, int permId, int parentId, double lastFillPrice, int clientId, string whyHeld)
        {
            Console.WriteLine("OrderStatus. Id: "+orderId+", Status: "+status+", Filled"+filled+", Remaining: "+remaining
                +", AvgFillPrice: "+avgFillPrice+", PermId: "+permId+", ParentId: "+parentId+", LastFillPrice: "+lastFillPrice+", ClientId: "+clientId+", WhyHeld: "+whyHeld+"\n");
        }

        public void openOrder(int orderId, Contract contract, Order order, OrderState orderState)
        {
            Console.WriteLine("OpenOrder. ID: "+orderId+", "+contract.Symbol+", "+contract.SecType+" @ "+contract.Exchange+": "+order.Action+", "+order.OrderType+" "+order.TotalQuantity+", "+orderState.Status+"\n");
        }

        public void openOrderEnd()
        {
            Console.WriteLine("OpenOrderEnd");
        }

        public void contractDetails(int reqId, ContractDetails contractDetails)
        {
            Console.WriteLine("ContractDetails. ReqId: "+reqId+" - "+contractDetails.Summary.Symbol+", "+contractDetails.Summary.SecType+", ConId: "+contractDetails.Summary.ConId+" @ "+contractDetails.Summary.Exchange+"\n");
        }

        public void contractDetailsEnd(int reqId)
        {
            Console.WriteLine("ContractDetailsEnd. "+reqId+"\n");
        }

        public void execDetails(int reqId, Contract contract, Execution execution)
        {
            Console.WriteLine("ExecDetails. "+reqId+" - "+contract.Symbol+", "+contract.SecType+", "+contract.Currency+" - "+execution.ExecId+", "+execution.OrderId+", "+execution.Shares+"\n");
        }

        public void execDetailsEnd(int reqId)
        {
            Console.WriteLine("ExecDetailsEnd. "+reqId+"\n");
        }

        public void commissionReport(CommissionReport commissionReport)
        {
            Console.WriteLine("CommissionReport. "+commissionReport.ExecId+" - "+commissionReport.Commission+" "+commissionReport.Currency+" RPNL "+commissionReport.RealizedPNL+"\n");
        }

        public void fundamentalData(int reqId, string data)
        {
            Console.WriteLine("FundamentalData. " + reqId + "" + data+"\n");
        }

        public void historicalData(int reqId, string date, double open, double high, double low, double close, int volume, int count, double WAP, bool hasGaps)
        {
            Console.WriteLine("HistoricalData. "+reqId+" - Date: "+date+", Open: "+open+", High: "+high+", Low: "+low+", Close: "+close+", Volume: "+volume+", Count: "+count+", WAP: "+WAP+", HasGaps: "+hasGaps+"\n");
        }

        public void marketDataType(int reqId, int marketDataType)
        {
            //WARN: when we request this, we never send a requestId
            //This is also not returning anything when invoked
            Console.WriteLine("MarketDataType. "+reqId+", Type: "+marketDataType+"\n");
        }

        public void updateMktDepth(int tickerId, int position, int operation, int side, double price, int size)
        {
            Console.WriteLine("UpdateMarketDepth. " + tickerId + " - Position: " + position + ", Operation: " + operation + ", Side: " + side + ", Price: " + price + ", Size" + size+"\n");
        }

        //WARN: Could not test!
        public void updateMktDepthL2(int tickerId, int position, string marketMaker, int operation, int side, double price, int size)
        {
            Console.WriteLine("UpdateMarketDepthL2. " + tickerId + " - Position: " + position + ", Operation: " + operation + ", Side: " + side + ", Price: " + price + ", Size" + size+"\n");
        }

        //WARN: Could not test!
        public void updateNewsBulletin(int msgId, int msgType, String message, String origExchange)
        {
            Console.WriteLine("News Bulletins. "+msgId+" - Type: "+msgType+", Message: "+message+", Exchange of Origin: "+origExchange+"\n");
        }

        public void position(string account, Contract contract, int pos)
        {
            Console.WriteLine("Position. "+account+" - Symbol: "+contract.Symbol+", SecType: "+contract.SecType+", Currency: "+contract.Currency+", Position: "+pos+"\n");
        }

        public void positionEnd()
        {
            Console.WriteLine("PositionEnd \n");
        }

        public void realtimeBar(int reqId, long time, double open, double high, double low, double close, long volume, double WAP, int count)
        {
            Console.WriteLine("RealTimeBars. " + reqId + " - Time: " + time + ", Open: " + open + ", High: " + high + ", Low: " + low + ", Close: " + close + ", Volume: " + volume + ", Count: " + count + ", WAP: " + WAP+"\n");
        }

        public void scannerParameters(string xml)
        {
            Console.WriteLine("ScannerParameters. "+xml+"\n");
        }

        public void scannerData(int reqId, int rank, ContractDetails contractDetails, string distance, string benchmark, string projection, string legsStr)
        {
            Console.WriteLine("ScannerData. "+reqId+" - Rank: "+rank+", Symbol: "+contractDetails.Summary.Symbol+", SecType: "+contractDetails.Summary.SecType+", Currency: "+contractDetails.Summary.Currency
                +", Distance: "+distance+", Benchmark: "+benchmark+", Projection: "+projection+", Legs String: "+legsStr+"\n");
        }

        public void scannerDataEnd(int reqId)
        {
            Console.WriteLine("ScannerDataEnd. "+reqId+"\n");
        }

        public void receiveFA(int faDataType, string faXmlData)
        {
            Console.WriteLine("Receing FA: "+faDataType+" - "+faXmlData+"\n");
        }
    }
}
