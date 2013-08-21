using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using IBApi;
using System.Threading;

namespace Samples
{
    public class Sample
    {

        public static int Main(string[] args)
        {
            EWrapperImpl testImpl = new EWrapperImpl();
            testImpl.ClientSocket.eConnect("127.0.0.1", 7496, 222);
            while (testImpl.NextOrderId <= 0) { }
            //for (int i = 0; i < 2; i++)
            {
                testConnectDisconnect(testImpl);
            }
            Console.WriteLine("Disconnecting...");
            testImpl.ClientSocket.eDisconnect();
            return 0;
        }

        private static void testConnectDisconnect(EWrapperImpl wrapper)
        {

            //Order order = OrderSamples.LimitOrder();
            //Contract contract = ContractSamples.getOption();

            //wrapper.ClientSocket.reqMktData(1, ContractSamples.getOption(), "", false);
            //wrapper.ClientSocket.reqMktData(3, ContractSamples.getEuropeanStock(), "", false);
            //wrapper.ClientSocket.reqGlobalCancel();
            //wrapper.ClientSocket.reqCurrentTime();
            //wrapper.ClientSocket.reqMktData(1, ContractSamples.getForex(), "", false);
            //wrapper.ClientSocket.calculateImpliedVolatility(2, ContractSamples.getOption(), 10, 345);
            //wrapper.ClientSocket.calculateOptionPrice(3, ContractSamples.getOption(), 4.69, 345);
            //wrapper.ClientSocket.reqAccountSummary(1, "All", AccountSummaryTags.GetAllTags());
            //wrapper.ClientSocket.reqAccountUpdates(true, "DU150462");
            //wrapper.ClientSocket.reqAllOpenOrders();
            //wrapper.ClientSocket.reqAutoOpenOrders(true);
            //wrapper.ClientSocket.reqOpenOrders();
            //wrapper.ClientSocket.placeOrder(wrapper.NextOrderId, ContractSamples.getForex(), order);

            wrapper.ClientSocket.placeOrder(wrapper.NextOrderId, ContractSamples.getComboContract(), OrderSamples.LimitOrderForComboWithLegPrice());

            //wrapper.ClientSocket.reqContractDetails(1, ContractSamples.getForex());
            //wrapper.ClientSocket.reqExecutions(1, new ExecutionFilter());
            //wrapper.ClientSocket.reqMktData(2, ContractSamples.getForex(), "", false);
            //wrapper.ClientSocket.reqFundamentalData(1, ContractSamples.getEuropeanStock(), "snapshot");
            //wrapper.ClientSocket.reqHistoricalData(1, ContractSamples.getEurUsdForex(), "20130722 23:59:59", "1 D", "1 hour", "MIDPOINT", 1, 1);
            //wrapper.ClientSocket.cancelHistoricalData(1);
            //wrapper.ClientSocket.reqFundamentalData(2, ContractSamples.getEuropeanStock(), "snapshot");
            //wrapper.ClientSocket.reqIds(-1);
            //wrapper.ClientSocket.reqManagedAccts();
            //wrapper.ClientSocket.reqMarketDataType(1);
            //wrapper.ClientSocket.reqMarketDepth(1, ContractSamples.getForex(), 5);
            //wrapper.ClientSocket.reqNewsBulletins(true);
            //wrapper.ClientSocket.reqPositions();
            //wrapper.ClientSocket.reqRealTimeBars(1, ContractSamples.getForex(), -1, "MIDPOINT", true);
            //wrapper.ClientSocket.reqScannerParameters();
            //wrapper.ClientSocket.exerciseOptions(1, ContractSamples.getOption(), 1, 20, null, 1);
            //wrapper.ClientSocket.reqScannerSubscription(1, GetScannerSubscription());
            //wrapper.ClientSocket.requestFA(Constants.FaProfiles);            

            //NOT WORKING (ALSO CHECKED WITH JAVA 969)
            wrapper.ClientSocket.setServerLogLevel(1);
            Thread.Sleep(500000);
        }

        private static ScannerSubscription GetScannerSubscription()
        {
            ScannerSubscription scanSub = new ScannerSubscription();
            scanSub.Instrument = "STOCK.EU";
            scanSub.LocationCode = "STK.EU.IBIS";
            scanSub.ScanCode = "HOT_BY_VOLUME";
            return scanSub;
        }
    }
}