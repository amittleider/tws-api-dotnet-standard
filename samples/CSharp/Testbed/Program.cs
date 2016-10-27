/* Copyright (C) 2015 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */
using System;
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
            EClientSocket clientSocket = testImpl.ClientSocket;
            EReaderSignal readerSignal = testImpl.Signal;
            //! [connect]
            clientSocket.eConnect("127.0.0.1", 7496, 0);
            //! [connect]
            //! [ereader]
            //Create a reader to consume messages from the TWS. The EReader will consume the incoming messages and put them in a queue
            var reader = new EReader(clientSocket, readerSignal);
            reader.Start();
            //Once the messages are in the queue, an additional thread need to fetch them
            new Thread(() => { while (clientSocket.IsConnected()) { readerSignal.waitForSignal(); reader.processMsgs(); } }) { IsBackground = true }.Start();
            //! [ereader]
            /*************************************************************************************************************************************************/
            /* One (although primitive) way of knowing if we can proceed is by monitoring the order's nextValidId reception which comes down automatically after connecting. */
            /*************************************************************************************************************************************************/
            while (testImpl.NextOrderId <= 0) { }            
            testIBMethods(clientSocket, testImpl.NextOrderId);            
            Console.WriteLine("Disconnecting...");
            clientSocket.eDisconnect();
            return 0;
        }

        /*****************************************************************/
        /* Below are few quick-to-test examples on the IB API functions grouped by functionality. Uncomment the relevant methods. */
        /*****************************************************************/
        private static void testIBMethods(EClientSocket client, int nextValidId)
        {
            /**************************************************************/
            /*** Real time market data operations  - Streamed or Frozen ***/
            /**************************************************************/
            //marketDataType(client);

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

            /**************************************************************************************/
            /*** Real time market data operations  - Streamed, Frozen, Delayed or Delayed-Frozen***/
            /**************************************************************************************/
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
            //! [reqmktdata]
            client.reqMktData(1001, ContractSamples.StockComboContract(), string.Empty, false, null);
            //! [reqmktdata]
            //! [reqmktdata_snapshot]
            client.reqMktData(1003, ContractSamples.FutureComboContract(), string.Empty, true, null);
            //! [reqmktdata_snapshot]

            //! [reqmktdata_genticks]
            //Requesting RTVolume (Time & Sales), shortable and Fundamental Ratios generic ticks
            client.reqMktData(1004, ContractSamples.USStock(), "233,236,258", false, null);
            //! [reqmktdata_genticks]

            //! [reqmktdata_contractnews]
            client.reqMktData(1005, ContractSamples.USStock(), "mdoff,292:BZ", false, null);
            client.reqMktData(1006, ContractSamples.USStock(), "mdoff,292:BT", false, null);
            client.reqMktData(1007, ContractSamples.USStock(), "mdoff,292:FLY", false, null);
            client.reqMktData(1008, ContractSamples.USStock(), "mdoff,292:MT", false, null);
            //! [reqmktdata_contractnews]
            //! [reqmktdata_broadtapenews]
            client.reqMktData(1009, ContractSamples.BTbroadtapeNewsFeed(), "mdoff,292", false, null);
            client.reqMktData(1010, ContractSamples.BZbroadtapeNewsFeed(), "mdoff,292", false, null);
            client.reqMktData(1011, ContractSamples.FLYbroadtapeNewsFeed(), "mdoff,292", false, null);
            client.reqMktData(1012, ContractSamples.MTbroadtapeNewsFeed(), "mdoff,292", false, null);
            //! [reqmktdata_broadtapenews]

            //! [reqoptiondatagenticks]
            //Requesting data for an option contract will return the greek values
            client.reqMktData(1002, ContractSamples.OptionWithLocalSymbol(), string.Empty, false, null);
            //! [reqoptiondatagenticks]

            Thread.Sleep(10000);
            /*** Canceling the market data subscription ***/
            //! [cancelmktdata]
            client.cancelMktData(1001);
            client.cancelMktData(1002);
            client.cancelMktData(1003);
            //! [cancelmktdata]
        }

        private static void marketDepthOperations(EClientSocket client)
        {
            /*** Requesting the Deep Book ***/
            //! [reqmarketdepth]
            client.reqMarketDepth(2001, ContractSamples.EurGbpFx(), 5, null);
            //! [reqmarketdepth]
            Thread.Sleep(2000);
            /*** Canceling the Deep Book request ***/
            //! [cancelmktdepth]
            client.cancelMktDepth(2001);
            //! [cancelmktdepth]
        }

        private static void realTimeBars(EClientSocket client)
        {
            /*** Requesting real time bars ***/
            //! [reqrealtimebars]
            client.reqRealTimeBars(3001, ContractSamples.EurGbpFx(), 5, "MIDPOINT", true, null);
            //! [reqrealtimebars]
            Thread.Sleep(2000);
            /*** Canceling real time bars ***/
            //! [cancelrealtimebars]
            client.cancelRealTimeBars(3001);
            //! [cancelrealtimebars]
        }

        private static void marketDataType(EClientSocket client)
        {
            //! [reqmarketdatatype]
            /*** Switch to live (1) frozen (2) delayed (3) or delayed frozen (4)***/
            client.reqMarketDataType(2);
            //! [reqmarketdatatype]
        }

        private static void historicalDataRequests(EClientSocket client)
        {
            /*** Requesting historical data ***/
            //! [reqhistoricaldata]
            String queryTime = DateTime.Now.AddMonths(-6).ToString("yyyyMMdd HH:mm:ss");
            client.reqHistoricalData(4001, ContractSamples.EurGbpFx(), queryTime, "1 M", "1 day", "MIDPOINT", 1, 1, null);
            client.reqHistoricalData(4002, ContractSamples.EuropeanStock(), queryTime, "10 D", "1 min", "TRADES", 1, 1, null);
            //! [reqhistoricaldata]
            Thread.Sleep(2000);
            /*** Canceling historical data requests ***/
            client.cancelHistoricalData(4001);
            client.cancelHistoricalData(4002);
        }

        private static void optionsOperations(EClientSocket client)
        {
            //! [reqsecdefoptparams]
            client.reqSecDefOptParams(0, "IBM", "", "STK", 8314);
            //! [reqsecdefoptparams]

            /*** Calculating implied volatility ***/
            //! [calculateimpliedvolatility]
            client.calculateImpliedVolatility(5001, ContractSamples.OptionAtBOX(), 5, 85, null);
            //! [calculateimpliedvolatility]
            /*** Canceling implied volatility ***/
            client.cancelCalculateImpliedVolatility(5001);
            /*** Calculating option's price ***/
            //! [calculateoptionprice]
            client.calculateOptionPrice(5002, ContractSamples.OptionAtBOX(), 0.22, 85, null);
            //! [calculateoptionprice]
            /*** Canceling option's price calculation ***/
            client.cancelCalculateOptionPrice(5002);
            /*** Exercising options ***/
            //! [exercise_options]
            client.exerciseOptions(5003, ContractSamples.OptionWithTradingClass(), 1, 1, null, 1);
            //! [exercise_options]
        }

        private static void contractOperations(EClientSocket client)
        {
            client.reqContractDetails(209, ContractSamples.EurGbpFx());
            Thread.Sleep(2000);
            //! [reqcontractdetails]
            client.reqContractDetails(210, ContractSamples.OptionForQuery());
            //! [reqcontractdetails]
        }

        private static void contractNewsFeed(EClientSocket client)
        {
            //! [reqcontractdetailsnews]
            client.reqContractDetails(211, ContractSamples.NewsFeedForQuery());
            //! [reqcontractdetailsnews]
        }

        private static void marketScanners(EClientSocket client)
        {
            /*** Requesting all available parameters which can be used to build a scanner request ***/
            //! [reqscannerparameters]
            client.reqScannerParameters();
            //! [reqscannerparameters]
            Thread.Sleep(2000);

            /*** Triggering a scanner subscription ***/
            //! [reqscannersubscription]
            client.reqScannerSubscription(7001, ScannerSubscriptionSamples.HighOptVolumePCRatioUSIndexes(), null);
            //! [reqscannersubscription]

            Thread.Sleep(2000);
            /*** Canceling the scanner subscription ***/
            //! [cancelscannersubscription]
            client.cancelScannerSubscription(7001);
            //! [cancelscannersubscription]
        }

        private static void reutersFundamentals(EClientSocket client)
        {
            /*** Requesting Fundamentals ***/
            //! [reqfundamentaldata]
            client.reqFundamentalData(8001, ContractSamples.USStock(), "ReportsFinSummary", null);
            //! [reqfundamentaldata]
            Thread.Sleep(2000);
            /*** Canceling fundamentals request ***/
            //! [cancelfundamentaldata]
            client.cancelFundamentalData(8001);
            //! [cancelfundamentaldata]
        }

        private static void bulletins(EClientSocket client)
        {
            /*** Requesting Interactive Broker's news bulletins */
            //! [reqnewsbulletins]
            client.reqNewsBulletins(true);
            //! [reqnewsbulletins]
            Thread.Sleep(2000);
            /*** Canceling IB's news bulletins ***/
            //! [cancelnewsbulletins]
            client.cancelNewsBulletin();
            //! [cancelnewsbulletins]
        }

        private static void accountOperations(EClientSocket client)
        {
            /*** Requesting managed accounts***/
            //! [reqmanagedaccts]
            client.reqManagedAccts();
            //! [reqmanagedaccts]
            /*** Requesting accounts' summary ***/
            Thread.Sleep(2000);
            //! [reqaaccountsummary]
            client.reqAccountSummary(9001, "All", AccountSummaryTags.GetAllTags());
            //! [reqaaccountsummary]

            //! [reqaaccountsummaryledger]
            client.reqAccountSummary(9002, "All", "$LEDGER");
            //! [reqaaccountsummaryledger]
            Thread.Sleep(2000);
            //! [reqaaccountsummaryledgercurrency]
            client.reqAccountSummary(9003, "All", "$LEDGER:EUR");
            //! [reqaaccountsummaryledgercurrency]
            Thread.Sleep(2000);
            //! [reqaaccountsummaryledgerall]
            client.reqAccountSummary(9004, "All", "$LEDGER:ALL");
            //! [reqaaccountsummaryledgerall]

            //! [cancelaaccountsummary]
            client.cancelAccountSummary(9001);
            client.cancelAccountSummary(9002);
            client.cancelAccountSummary(9003);
            client.cancelAccountSummary(9004);
            //! [cancelaaccountsummary]

            /*** Subscribing to an account's information. Only one at a time! ***/
            Thread.Sleep(2000);
            //! [reqaaccountupdates]
            client.reqAccountUpdates(true, "U150462");
            //! [reqaaccountupdates]
            Thread.Sleep(2000);
            //! [cancelaaccountupdates]
            client.reqAccountUpdates(false, "U150462");
            //! [cancelaaccountupdates]

            //! [reqaaccountupdatesmulti]
            client.reqAccountUpdatesMulti(9002, "U150462", "EUstocks", true);
            //! [reqaaccountupdatesmulti]

            Thread.Sleep(2000);
            /*** Requesting all accounts' positions. ***/
            //! [reqpositions]
            client.reqPositions();
            //! [reqpositions]
            Thread.Sleep(2000);
            //! [cancelpositions]
            client.cancelPositions();
            //! [cancelpositions]

            //! [reqpositionsmulti]
            client.reqPositionsMulti(9003, "DU74649", "EUstocks");
            //! [reqpositionsmulti]
        }

        private static void orderOperations(EClientSocket client, int nextOrderId)
        {
            /*** Requesting the next valid id ***/
            //! [reqids]
            //The parameter is always ignored.
            client.reqIds(-1);
            //! [reqids]
            //Thread.Sleep(1000);
            /*** Requesting all open orders ***/
            //! [reqallopenorders]
            client.reqAllOpenOrders();
            //! [reqallopenorders]
            //Thread.Sleep(1000);
            /*** Taking over orders to be submitted via TWS ***/
            //! [reqautoopenorders]
            client.reqAutoOpenOrders(true);
            //! [reqautoopenorders]
            //Thread.Sleep(1000);
            /*** Requesting this API client's orders ***/
            //! [reqopenorders]
            client.reqOpenOrders();
            //! [reqopenorders]
            //Thread.Sleep(1000);
            //BracketSample(client, nextOrderId);

            /*** Placing/modifying an order - remember to ALWAYS increment the nextValidId after placing an order so it can be used for the next one! 
			Note if there are multiple clients connected to an account, the order ID must also be greater than all order IDs returned for orders to orderStatus and openOrder to this client.
			***/
            //! [order_submission]
            client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.LimitOrder("SELL", 1, 50));
            //! [order_submission]

            //! [faorderoneaccount]
            Order faOrderOneAccount = OrderSamples.MarketOrder("BUY", 100);
            // Specify the Account Number directly
            faOrderOneAccount.Account = "DU119915";
            client.placeOrder(nextOrderId++, ContractSamples.USStock(), faOrderOneAccount);
            //! [faorderoneaccount]

            //! [faordergroupequalquantity]
            Order faOrderGroupEQ = OrderSamples.LimitOrder("SELL", 200, 2000);
            faOrderGroupEQ.FaGroup = "Group_Equal_Quantity";
            faOrderGroupEQ.FaMethod = "EqualQuantity";
            client.placeOrder(nextOrderId++, ContractSamples.SimpleFuture(), faOrderGroupEQ);
            //! [faordergroupequalquantity]

            //! [faordergrouppctchange]
            Order faOrderGroupPC = OrderSamples.MarketOrder("BUY", 0); ;
            // You should not specify any order quantity for PctChange allocation method
            faOrderGroupPC.FaGroup = "Pct_Change";
            faOrderGroupPC.FaMethod = "PctChange";
            faOrderGroupPC.FaPercentage = "100";
            client.placeOrder(nextOrderId++, ContractSamples.EurGbpFx(), faOrderGroupPC);
            //! [faordergrouppctchange]

            //! [faorderprofile]
            Order faOrderProfile = OrderSamples.LimitOrder("BUY", 200, 100);
            faOrderProfile.FaProfile = "Percent_60_40";
            client.placeOrder(nextOrderId++, ContractSamples.EuropeanStock(), faOrderProfile);
            //! [faorderprofile]

            //client.placeOrder(nextOrderId++, ContractSamples.OptionAtBOX(), OrderSamples.Block("BUY", 50, 20));
            //client.placeOrder(nextOrderId++, ContractSamples.OptionAtBOX(), OrderSamples.BoxTop("SELL", 10));
            //client.placeOrder(nextOrderId++, ContractSamples.FutureComboContract(), OrderSamples.ComboLimitOrder("SELL", 1, 1, false));
            //client.placeOrder(nextOrderId++, ContractSamples.StockComboContract(), OrderSamples.ComboMarketOrder("BUY", 1, true));
            //client.placeOrder(nextOrderId++, ContractSamples.OptionComboContract(), OrderSamples.ComboMarketOrder("BUY", 1, false));
            //client.placeOrder(nextOrderId++, ContractSamples.StockComboContract(), OrderSamples.LimitOrderForComboWithLegPrices("BUY", 1, new double[]{10, 5}, true));
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.Discretionary("SELL", 1, 45, 0.5));
            //client.placeOrder(nextOrderId++, ContractSamples.OptionAtBOX(), OrderSamples.LimitIfTouched("BUY", 1, 30, 34));
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.LimitOnClose("SELL", 1, 34));
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.LimitOnOpen("BUY", 1, 35));
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.MarketIfTouched("BUY", 1, 30));
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.MarketOnClose("SELL", 1));
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.MarketOnOpen("BUY", 1));
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.MarketOrder("SELL", 1));
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.MarketToLimit("BUY", 1));
            //client.placeOrder(nextOrderId++, ContractSamples.OptionAtIse(), OrderSamples.MidpointMatch("BUY", 1));
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.MarketToLimit("BUY", 1));
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.Stop("SELL", 1, 34.4));
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.StopLimit("BUY", 1, 35, 33));
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.StopWithProtection("SELL", 1, 45));
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.SweepToFill("BUY", 1, 35));
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.TrailingStop("SELL", 1, 0.5, 30));
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.TrailingStopLimit("BUY", 1, 50, 5, 30));
            //client.placeOrder(nextOrderId++, ContractSamples.NormalOption(), OrderSamples.Volatility("SELL", 1, 5, 2));

            

            //NOTE: the following orders are not supported for Paper Trading
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.AtAuction("BUY", 100, 30.0));
            //client.placeOrder(nextOrderId++, ContractSamples.OptionAtBOX(), OrderSamples.AuctionLimit("SELL", 10, 30.0, 2));
            //client.placeOrder(nextOrderId++, ContractSamples.OptionAtBOX(), OrderSamples.AuctionPeggedToStock("BUY", 10, 30, 0.5));
            //client.placeOrder(nextOrderId++, ContractSamples.OptionAtBOX(), OrderSamples.AuctionRelative("SELL", 10, 0.6));
            //client.placeOrder(nextOrderId++, ContractSamples.SimpleFuture(), OrderSamples.MarketWithProtection("BUY", 1));
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(), OrderSamples.PassiveRelative("BUY", 1, 0.5));

            //208813720 (GOOG)
            //client.placeOrder(nextOrderId++, ContractSamples.USStock(),
            //    OrderSamples.PeggedToBenchmark("SELL", 100, 33, true, 0.1, 1, 208813720, "ISLAND", 750, 650, 800));

            //STOP ADJUSTABLE ORDERS
            //Order stpParent = OrderSamples.Stop("SELL", 100, 30);
            //stpParent.OrderId = nextOrderId++;
            //client.placeOrder(stpParent.OrderId, ContractSamples.EuropeanStock(), stpParent);
            //client.placeOrder(nextOrderId++, ContractSamples.EuropeanStock(), OrderSamples.AttachAdjustableToStop(stpParent, 35, 32, 33));
            //client.placeOrder(nextOrderId++, ContractSamples.EuropeanStock(), OrderSamples.AttachAdjustableToStopLimit(stpParent, 35, 33, 32, 33));
            //client.placeOrder(nextOrderId++, ContractSamples.EuropeanStock(), OrderSamples.AttachAdjustableToTrail(stpParent, 35, 32, 32, 1, 0));

            //Order lmtParent = OrderSamples.LimitOrder("BUY", 100, 30);
            //lmtParent.OrderId = nextOrderId++;
            //client.placeOrder(lmtParent.OrderId, ContractSamples.EuropeanStock(), lmtParent);
            //Attached TRAIL adjusted can only be attached to LMT parent orders.
            //client.placeOrder(nextOrderId++, ContractSamples.EuropeanStock(), OrderSamples.AttachAdjustableToTrailAmount(lmtParent, 34, 32, 33, 0.008));
            TestAlgoSamples(client, nextOrderId);
            Thread.Sleep(30000);
            /*** Cancel all orders for all accounts ***/
            //client.reqGlobalCancel();
            /*** Request the day's executions ***/
            //! [reqexecutions]
            client.reqExecutions(10001, new ExecutionFilter());
            //! [reqexecutions]
        }

        private static void OcaSample(EClientSocket client, int nextOrderId)
        {
            //OCA ORDER
            //! [ocasubmit]
            List<Order> ocaOrders = new List<Order>();
            ocaOrders.Add(OrderSamples.LimitOrder("BUY", 1, 10));
            ocaOrders.Add(OrderSamples.LimitOrder("BUY", 1, 11));
            ocaOrders.Add(OrderSamples.LimitOrder("BUY", 1, 12));
            OrderSamples.OneCancelsAll("TestOCA_" + nextOrderId, ocaOrders, 2);
            foreach (Order o in ocaOrders)
                client.placeOrder(nextOrderId++, ContractSamples.USStock(), o);
            //! [ocasubmit]
        }

        private static void ConditionSamples(EClientSocket client, int nextOrderId)
        {
            //! [order_conditioning_activate]
            Order mkt = OrderSamples.MarketOrder("BUY", 100);
            //Order will become active if conditioning criteria is met
            mkt.ConditionsCancelOrder = true;
            mkt.Conditions.Add(OrderSamples.PriceCondition(208813720, "SMART", 600, false, false));
            mkt.Conditions.Add(OrderSamples.ExecutionCondition("EUR.USD", "CASH", "IDEALPRO", true));
            mkt.Conditions.Add(OrderSamples.MarginCondition(30, true, false));
            mkt.Conditions.Add(OrderSamples.PercentageChangeCondition(15.0, 208813720, "SMART", true, true));
            mkt.Conditions.Add(OrderSamples.TimeCondition("20160118 23:59:59", true, false));
            mkt.Conditions.Add(OrderSamples.VolumeCondition(208813720, "SMART", false, 100, true));
            client.placeOrder(nextOrderId++, ContractSamples.EuropeanStock(), mkt);
            //! [order_conditioning_activate]

            //Conditions can make the order active or cancel it. Only LMT orders can be conditionally canceled.
            //! [order_conditioning_cancel]
            Order lmt = OrderSamples.LimitOrder("BUY", 100, 20);
            //The active order will be cancelled if conditioning criteria is met
            lmt.ConditionsCancelOrder = true;
            lmt.Conditions.Add(OrderSamples.PriceCondition(208813720, "SMART", 600, false, false));
            client.placeOrder(nextOrderId++, ContractSamples.EuropeanStock(), lmt);
            //! [order_conditioning_cancel]
        }

        private static void BracketSample(EClientSocket client, int nextOrderId)
        {
            //BRACKET ORDER
            //! [bracketsubmit]
            List<Order> bracket = OrderSamples.BracketOrder(nextOrderId++, "BUY", 100, 30, 40, 20);
            foreach (Order o in bracket)
                client.placeOrder(o.OrderId, ContractSamples.EuropeanStock(), o);
            //! [bracketsubmit]
        }

        private static void HedgeSample(EClientSocket client, int nextOrderId)
        {
            //F Hedge order
            //! [hedgesubmit]
            //Parent order on a contract which currency differs from your base currency
            Order parent = OrderSamples.LimitOrder("BUY", 100, 10);
            parent.OrderId = nextOrderId++;
            //Hedge on the currency conversion
            Order hedge = OrderSamples.MarketFHedge(parent.OrderId, "BUY");
            //Place the parent first...
            client.placeOrder(parent.OrderId, ContractSamples.EuropeanStock(), parent);
            //Then the hedge order
            client.placeOrder(nextOrderId++, ContractSamples.EurGbpFx(), hedge);
            //! [hedgesubmit]
        }

        private static void TestAlgoSamples(EClientSocket client, int nextOrderId)
        {
            //! [algo_base_order]
            Order baseOrder = OrderSamples.LimitOrder("BUY", 1000, 1);
            //! [algo_base_order]

            //! [arrivalpx]
            AvailableAlgoParams.FillArrivalPriceParams(baseOrder, 0.1, "Aggressive", "09:00:00 CET", "16:00:00 CET", true, true);
            client.placeOrder(nextOrderId++, ContractSamples.USStockAtSmart(), baseOrder);
            //! [arrivalpx]

            Thread.Sleep(500);

            //! [darkice]
            AvailableAlgoParams.FillDarkIceParams(baseOrder, 10, "09:00:00 CET", "16:00:00 CET", true);
            client.placeOrder(nextOrderId++, ContractSamples.USStockAtSmart(), baseOrder);
            //! [darkice]

            Thread.Sleep(500);

            //! [ad]
            AvailableAlgoParams.FillAccumulateDistributeParams(baseOrder, 10, 60, true, true, 1, true, true, "09:00:00 CET", "16:00:00 CET");
            client.placeOrder(nextOrderId++, ContractSamples.USStockAtSmart(), baseOrder);
            //! [ad]

            Thread.Sleep(500);

            //! [twap]
            AvailableAlgoParams.FillTwapParams(baseOrder, "Marketable", "09:00:00 CET", "16:00:00 CET", true);
            client.placeOrder(nextOrderId++, ContractSamples.USStockAtSmart(), baseOrder);
            //! [twap]

            Thread.Sleep(500);

            //! [vwap]
            AvailableAlgoParams.FillVwapParams(baseOrder, 0.2, "09:00:00 CET", "16:00:00 CET", true, true);
            client.placeOrder(nextOrderId++, ContractSamples.USStockAtSmart(), baseOrder);
            //! [vwap]

            Thread.Sleep(500);

            //! [balanceimpactrisk]
            AvailableAlgoParams.FillBalanceImpactRiskParams(baseOrder, 0.1, "Aggressive", true);
            client.placeOrder(nextOrderId++, ContractSamples.USOptionContract(), baseOrder);
            //! [balanceimpactrisk]

            Thread.Sleep(500);

            //! [minimpact]
            AvailableAlgoParams.FillMinImpactParams(baseOrder, 0.3);
            client.placeOrder(nextOrderId++, ContractSamples.USOptionContract(), baseOrder);
            //! [minimpact]

            //! [adaptive]
            AvailableAlgoParams.FillAdaptiveParams(baseOrder, "Normal");
            client.placeOrder(nextOrderId++, ContractSamples.USStockAtSmart(), baseOrder);
            //! [adaptive]
        }

        private static void financialAdvisorOperations(EClientSocket client)
        {
            /*** Requesting FA information ***/
            //! [requestfaaliases]
            client.requestFA(Constants.FaAliases);
            //! [requestfaaliases]

            //! [requestfagroups]
            client.requestFA(Constants.FaGroups);
            //! [requestfagroups]

            //! [requestfaprofiles]
            client.requestFA(Constants.FaProfiles);
            //! [requestfaprofiles]

            /*** Replacing FA information - Fill in with the appropriate XML string. ***/
            //! [replacefaonegroup]
            client.replaceFA(Constants.FaGroups, FaAllocationSamples.FaOneGroup);
            //! [replacefaonegroup]

            //! [replacefatwogroups]
            client.replaceFA(Constants.FaGroups, FaAllocationSamples.FaTwoGroups);
            //! [replacefatwogroups]

            //! [replacefaoneprofile]
            client.replaceFA(Constants.FaProfiles, FaAllocationSamples.FaOneProfile);
            //! [replacefaoneprofile]

            //! [replacefatwoprofiles]
            client.replaceFA(Constants.FaProfiles, FaAllocationSamples.FaTwoProfiles);
            //! [replacefatwoprofiles]
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

            //! [querydisplaygroups]
            client.queryDisplayGroups(9001);
            //! [querydisplaygroups]

            //! [subscribetogroupevents]
            client.subscribeToGroupEvents(9002, 1);
            //! [subscribetogroupevents]

            //! [updatedisplaygroup]
            client.updateDisplayGroup(9002, "8314@SMART");
            //! [updatedisplaygroup]

            //! [subscribefromgroupevents]
            client.unsubscribeFromGroupEvents(9002);
            //! [subscribefromgroupevents]
        }

    }
}