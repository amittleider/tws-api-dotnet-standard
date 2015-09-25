/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using IBApi;
using System.Threading;
using IBSamples;
using System.Collections.Generic;

namespace Samples
{
    public class Sample
    {
        /* IMPORTANT: always use your paper trading account. The code below will submit orders as part of the demonstration. */
        /* IB will not be responsible for accidental executions on your live account. */
        /* Any stock or option symbols displayed are for illustrative purposes only and are not intended to portray a recommendation. */
        /* Before contacting our API support team please refer to the available documentation. */
        public static int Main(string[] args)
        {
            EWrapperImpl testImpl = new EWrapperImpl();
            testImpl.ClientSocket.eConnect("127.0.0.1", 7496, 0, false);
            //Create a reader to consume messages from the TWS. The EReader will consume the incoming messages and put them in a queue
            var reader = new EReader(testImpl.ClientSocket, testImpl.Signal);
            reader.Start();
            //Once the messages are in the queue, an additional thread need to fetch them
            new Thread(() => { while (testImpl.ClientSocket.IsConnected()) { testImpl.Signal.waitForSignal(); reader.processMsgs(); } }) { IsBackground = true }.Start();

            /*************************************************************************************************************************************************/
            /* One (although primitive) way of knowing if we can proceed is by monitoring the order's nextValidId reception which comes down automatically after connecting. */
            /*************************************************************************************************************************************************/
            while (testImpl.NextOrderId <= 0) { }            
            testIBMethods(testImpl.ClientSocket, testImpl.NextOrderId);            
            Console.WriteLine("Disconnecting...");
            testImpl.ClientSocket.eDisconnect();
            return 0;
        }

        /*****************************************************************/
        /* Below are few quick-to-test examples on the IB API functions grouped by functionality. Uncomment the relevant methods. */
        /*****************************************************************/
        private static void testIBMethods(EClientSocket client, int nextValidId)
        {
            /***************************************************/
            /*** Real time market data operations  - Tickers ***/
            /***************************************************/
            //tickDataOperations(client);

            /********************************************************/
            /*** Real time market data operations  - Market Depth ***/
            /********************************************************/
            //marketDepthOperations(client);

            /**********************************************************/
            /*** Real time market data operations  - Real Time Bars ***/
            /**********************************************************/
            //realTimeBars(client);

            /**************************************************************/
            /*** Real time market data operations  - Streamed or Frozen ***/
            /**************************************************************/
            //marketDataType(client);

            /**********************************/
            /*** Historical Data operations ***/
            /**********************************/
            //historicalDataRequests(client);

            /*************************/
            /*** Options Specifics ***/
            /*************************/
            //optionsOperations(client);

            /****************************/
            /*** Contract information ***/
            /****************************/
            //contractOperations(client);

            /***********************/
            /*** Market Scanners ***/
            /***********************/
            //marketScanners(client);

            /*****************************/
            /*** Reuter's Fundamentals ***/
            /*****************************/
            //reutersFundamentals(client);

            /***********************/
            /*** IB's Bulletins ***/
            /***********************/
            //bulletins(client);

            /**************************/
            /*** Account Management ***/
            /**************************/
            //accountOperations(client);

            /**********************/
            /*** Order handling ***/
            /**********************/
            //orderOperations(client, nextValidId);

            /************************************/
            /*** Financial Advisor Exclusive Operations ***/
            /************************************/
            //financialAdvisorOperations(client);

            /********************/
            /*** Miscelaneous ***/
            /********************/
            //miscelaneous(client);

            /********************/
            /*** Linking ***/
            /********************/
            //linkingOperations(client);

            Thread.Sleep(3000);
            Console.WriteLine("Done");
            Thread.Sleep(500000);
        }

        private static void tickDataOperations(EClientSocket client)
        {
            /*** Requesting real time market data ***/
            //Thread.Sleep(1000);
            client.reqMktData(1001, ContractSamples.StockComboContract(), string.Empty, false, null);
            client.reqMktData(1002, ContractSamples.FuturesOnOptions(), string.Empty, false, null);
            client.reqMktData(1003, ContractSamples.FutureComboContract(), string.Empty, false, null);
            Thread.Sleep(10000);
            /*** Canceling the market data subscription ***/
            client.cancelMktData(1001);
            client.cancelMktData(1002);
            client.cancelMktData(1003);
        }

        private static void marketDepthOperations(EClientSocket client)
        {
            /*** Requesting the Deep Book ***/
            client.reqMarketDepth(2001, ContractSamples.EurGbpFx(), 5, null);
            Thread.Sleep(2000);
            /*** Canceling the Deep Book request ***/
            client.cancelMktDepth(2001);
        }

        private static void realTimeBars(EClientSocket client)
        {
            /*** Requesting real time bars ***/
            client.reqRealTimeBars(3001, ContractSamples.EurGbpFx(), 5, "MIDPOINT", true, null);
            Thread.Sleep(2000);
            /*** Canceling real time bars ***/
            client.cancelRealTimeBars(3001);
        }

        private static void marketDataType(EClientSocket client)
        {
            /*** Switch to frozen (2) or streaming (1)***/
            client.reqMarketDataType(1);
        }

        private static void historicalDataRequests(EClientSocket client)
        {
            /*** Requesting historical data ***/
            String queryTime = DateTime.Now.AddMonths(-6).ToString("yyyyMMdd HH:mm:ss");
            client.reqHistoricalData(4001, ContractSamples.EurGbpFx(), queryTime, "1 M", "1 day", "MIDPOINT", 1, 1, null);
            client.reqHistoricalData(4002, ContractSamples.EuropeanStock(), queryTime, "10 D", "1 min", "TRADES", 1, 1, null);
            Thread.Sleep(2000);
            /*** Canceling historical data requests ***/
            client.cancelHistoricalData(4001);
            client.cancelHistoricalData(4002);
        }

        private static void optionsOperations(EClientSocket client)
        {
            /*** Calculating implied volatility ***/
            client.calculateImpliedVolatility(5001, ContractSamples.NormalOption(), 5, 85, null);
            /*** Canceling implied volatility ***/
            client.cancelCalculateImpliedVolatility(5001);
            /*** Calculating option's price ***/
            client.calculateOptionPrice(5002, ContractSamples.NormalOption(), 0.22, 85, null);
            /*** Canceling option's price calculation ***/
            client.cancelCalculateOptionPrice(5002);
            /*** Exercising options ***/
            client.exerciseOptions(5003, ContractSamples.OptionWithTradingClass(), 1, 1, null, 1);
        }

        private static void contractOperations(EClientSocket client)
        {
            client.reqContractDetails(209, ContractSamples.EurGbpFx());
            Thread.Sleep(2000);
            client.reqContractDetails(210, ContractSamples.OptionForQuery());
        }

        private static void marketScanners(EClientSocket client)
        {
            /*** Requesting all available parameters which can be used to build a scanner request ***/
            client.reqScannerParameters();
            /*** Triggering a scanner subscription ***/
            client.reqScannerSubscription(7001, ScannerSubscriptionSamples.GetScannerSubscription(), null);
            Thread.Sleep(2000);
            /*** Canceling the scanner subscription ***/
            client.cancelScannerSubscription(7001);
        }

        private static void reutersFundamentals(EClientSocket client)
        {
            /*** Requesting Fundamentals ***/
            client.reqFundamentalData(8001, ContractSamples.USStock(), "ReportsFinSummary", null);
            Thread.Sleep(2000);
            /*** Canceling fundamentals request ***/
            client.cancelFundamentalData(8001);
        }

        private static void bulletins(EClientSocket client)
        {
            /*** Requesting Interactive Broker's news bulletins */
            client.reqNewsBulletins(true);
            Thread.Sleep(2000);
            /*** Canceling IB's news bulletins ***/
            client.cancelNewsBulletin();
        }

        private static void accountOperations(EClientSocket client)
        {
            /*** Requesting managed accounts***/
            client.reqManagedAccts();
            /*** Requesting accounts' summary ***/
            Thread.Sleep(2000);
            client.reqAccountSummary(9001, "All", AccountSummaryTags.GetAllTags());
            /*** Subscribing to an account's information. Only one at a time! ***/
            Thread.Sleep(2000);
            client.reqAccountUpdates(true, "U150462");
            Thread.Sleep(2000);
            /*** Requesting all accounts' positions. ***/
            client.reqPositions();
        }

        private static void orderOperations(EClientSocket client, int nextOrderId)
        {
            /*** Requesting the next valid id ***/
            client.reqIds(-1);
            Thread.Sleep(1000);
            /*** Requesting all open orders ***/
            client.reqAllOpenOrders();
            Thread.Sleep(1000);
            /*** Taking over orders to be submitted via TWS ***/
            client.reqAutoOpenOrders(true);
            Thread.Sleep(1000);
            /*** Requesting this API client's orders ***/
            client.reqOpenOrders();
            Thread.Sleep(1000);

            /*** Placing/modifying an order - remember to ALWAYS increment the nextValidId after placing an order so it can be used for the next one! ***/
            //client.placeOrder(nextOrderId++, ContractSamples.OptionAtBOX(), OrderSamples.Block("BUY", 50, 20));
            //client.placeOrder(nextOrderId++, ContractSamples.OptionAtBOX(), OrderSamples.BoxTop("SELL", 10));
            //client.placeOrder(nextOrderId++, ContractSamples.FutureComboContract(), OrderSamples.ComboLimitOrder("SELL", 1, 1, false));
            //client.placeOrder(nextOrderId++, ContractSamples.StockComboContract(), OrderSamples.ComboMarketOrder("BUY", 1, true));
            //client.placeOrder(nextOrderId++, ContractSamples.StockComboContract(), OrderSamples.LimitOrderForComboWithLegPrices("BUY", 1, new double[]{10, 5}, true));
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.Discretionary("SELL", 1, 45, 0.5));
            //client.placeOrder(nextOrderId++, ContractSamples.OptionAtBOX(), OrderSamples.LimitIfTouched("BUY", 1, 30, 34));
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.LimitOnClose("SELL", 1, 34));
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.LimitOnOpen("BUY", 1, 35));
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.LimitOrder("SELL", 1, 50));
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.MarketIfTouched("BUY", 1, 30));
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.MarketOnClose("SELL", 1));
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.MarketOnOpen("BUY", 1));
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.MarketOrder("SELL", 1));
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.MarketToLimit("BUY", 1));
            //client.placeOrder(nextOrderId++, ContractSamples.OptionAtIse(), OrderSamples.MidpointMatch("BUY", 1));
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.MarketToLimit("BUY", 1));
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.Stop("SELL", 1, 34));
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.StopLimit("BUY", 1, 35, 33));
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.StopWithProtection("SELL", 1, 45));
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.SweepToFill("BUY", 1, 35));
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.TrailingStop("SELL", 1, 0.5, 30));
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.TrailingStopLimit("BUY", 1, 50, 5, 30));
            //client.placeOrder(nextOrderId++, ContractSamples.NormalOption(), OrderSamples.Volatility("SELL", 1, 5, 2));

            //BRACKET ORDER
            //List<Order> bracket = OrderSamples.BracketOrder(nextOrderId++, "BUY", 100, 30, 40, 20);
            //foreach (Order o in bracket)
            //    client.placeOrder(o.OrderId, ContractSamples.EuropeanStock(), o);

            //OCA ORDER
            //List<Order> ocaOrders = new List<Order>();
            //ocaOrders.Add(OrderSamples.LimitOrder("BUY", 1, 10));
            //ocaOrders.Add(OrderSamples.LimitOrder("BUY", 1, 11));
            //ocaOrders.Add(OrderSamples.LimitOrder("BUY", 1, 12));
            //ocaOrders = OrderSamples.OneCancelsAll("TestOCA_" + nextOrderId, ocaOrders, 2);
            //foreach (Order o in ocaOrders)
            //    client.placeOrder(nextOrderId++, ContractSamples.USStock(), o);
            
            //NOTE: the following orders are not supported for Paper Trading
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.AtAuction("BUY", 100, 30.0));
            //client.placeOrder(nextOrderId++, ContractSamples.OptionAtBOX(), OrderSamples.AuctionLimit("SELL", 10, 30.0, 2));
            //client.placeOrder(nextOrderId++, ContractSamples.OptionAtBOX(), OrderSamples.AuctionPeggedToStock("BUY", 10, 30, 0.5));
            //client.placeOrder(nextOrderId++, ContractSamples.OptionAtBOX(), OrderSamples.AuctionRelative("SELL", 10, 0.6));
            //client.placeOrder(nextOrderId++, ContractSamples.SimpleFuture(), OrderSamples.MarketWithProtection("BUY", 1));
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.PassiveRelative("BUY", 1, 0.5));
            //client.placeOrder(nextOrderId++, ContractSamples.NormalOption(), OrderSamples.Volatility("BUY", 1, 4, 2));            

            Thread.Sleep(3000);
            /*** Cancel all orders for all accounts ***/
            client.reqGlobalCancel();
            /*** Request the day's executions ***/
            client.reqExecutions(10001, new ExecutionFilter());
        }

        private static void financialAdvisorOperations(EClientSocket client)
        {
            /*** Requesting FA information ***/
            client.requestFA(Constants.FaAliases);
            client.requestFA(Constants.FaGroups);
            client.requestFA(Constants.FaProfiles);
            /*** Replacing FA information - Fill in with the appropriate XML string. ***/
            client.replaceFA(Constants.FaGroups, string.Empty);
        }

        private static void miscelaneous(EClientSocket client)
        {
            /*** Request TWS' current time ***/
            client.reqCurrentTime();
            /*** Setting TWS logging level  ***/
            client.setServerLogLevel(1);
        }

        private static void linkingOperations(EClientSocket client)
        {
            client.verifyRequest("a name", "9.71");
            client.verifyMessage("apiData");
            client.queryDisplayGroups(123);
            client.subscribeToGroupEvents(124, 1);
            client.updateDisplayGroup(125, "contract info");
            client.unsubscribeFromGroupEvents(124);
        }
        
    }
}