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

        public static int Main(string[] args)
        {
            EWrapperImpl testImpl = new EWrapperImpl();
            testImpl.ClientSocket.eConnect("127.0.0.1", 7496, 0, false);
            /*************************************************************************************************************************************************/
            /* One good way of knowing if we can proceed is by monitoring the order's nextValidId reception which comes down automatically after connecting. */
            /*************************************************************************************************************************************************/
            while (testImpl.NextOrderId <= 0) { }            
            testIBMethods(testImpl);            
            Console.WriteLine("Disconnecting...");
            testImpl.ClientSocket.eDisconnect();
            return 0;
        }

        /*****************************************************************/
        /* Below are few quick-to-test examples on the IB API functions. */
        /*****************************************************************/
        private static void testIBMethods(EWrapperImpl wrapper)
        {            
            /***************************************************/
            /*** Real time market data operations  - Tickers ***/
            /***************************************************/
            /*** Requesting real time market data ***/
            //wrapper.ClientSocket.reqMarketDataType(2);
            //wrapper.ClientSocket.reqMktData(1001, ContractSamples.getEurUsdForex(), "", false, GetFakeParameters(3));
            //wrapper.ClientSocket.reqMktData(1002, ContractSamples.getOption(), "", false, GetFakeParameters(3));
            //wrapper.ClientSocket.reqMktData(1003, ContractSamples.getEuropeanStock(), "", false);
            //Thread.Sleep(2000);
            /*** Canceling the market data subscription ***/
            //wrapper.ClientSocket.cancelMktData(1001);            
            //wrapper.ClientSocket.cancelMktData(1002);            
            //wrapper.ClientSocket.cancelMktData(1003);

            /********************************************************/
            /*** Real time market data operations  - Market Depth ***/
            /********************************************************/
            /*** Requesting the Deep Book ***/
            //wrapper.ClientSocket.reqMarketDepth(2001, ContractSamples.getEurGbpForex(), 5, GetFakeParameters(2));
            //Thread.Sleep(2000);
            /*** Canceling the Deep Book request ***/
            //wrapper.ClientSocket.cancelMktDepth(2001);

            /**********************************************************/
            /*** Real time market data operations  - Real Time Bars ***/
            /**********************************************************/
            /*** Requesting real time bars ***/
            //wrapper.ClientSocket.reqRealTimeBars(3001, ContractSamples.getEurGbpForex(), -1, "MIDPOINT", true, GetFakeParameters(4));
            //Thread.Sleep(2000);
            /*** Canceling real time bars ***/
            //wrapper.ClientSocket.cancelRealTimeBars(3001);

            /**************************************************************/
            /*** Real time market data operations  - Streamed or Frozen ***/
            /**************************************************************/
            /*** Switch to frozen or streaming***/
            //wrapper.ClientSocket.reqMarketDataType(1);

            /**********************************/
            /*** Historical Data operations ***/
            /**********************************/
            /*** Requesting historical data ***/
            //wrapper.ClientSocket.reqHistoricalData(4001, ContractSamples.getEurGbpForex(), "20130722 23:59:59", "1 D", "1 min", "MIDPOINT", 1, 1, GetFakeParameters(4));
            //wrapper.ClientSocket.reqHistoricalData(4002, ContractSamples.getEuropeanStock(), "20131009 23:59:59", "10 D", "1 min", "TRADES", 1, 1);
            /*** Canceling historical data requests ***/
            //wrapper.ClientSocket.cancelHistoricalData(4001);
            //wrapper.ClientSocket.cancelHistoricalData(4002);

            /*************************/
            /*** Options Specifics ***/
            /*************************/
            /*** Calculating implied volatility ***/
            //wrapper.ClientSocket.calculateImpliedVolatility(5001, ContractSamples.getOption(), 5, 85, GetFakeParameters(6));
            /*** Canceling implied volatility ***/
            //wrapper.ClientSocket.cancelCalculateImpliedVolatility(5001);
            /*** Calculating option's price ***/
            //wrapper.ClientSocket.calculateOptionPrice(5002, ContractSamples.getOption(), 0.22, 85, GetFakeParameters(1));
            /*** Canceling option's price calculation ***/
            //wrapper.ClientSocket.cancelCalculateOptionPrice(5002);
            /*** Exercising options ***/
            //wrapper.ClientSocket.exerciseOptions(5003, ContractSamples.GetSANTOption(), 1, 1, null, 1);

            /****************************/
            /*** Contract information ***/
            /****************************/
            //wrapper.ClientSocket.reqContractDetails(6001, ContractSamples.GetbyIsin());
            //wrapper.ClientSocket.reqContractDetails(210, ContractSamples.getOptionForQuery());
            //wrapper.ClientSocket.reqContractDetails(211, ContractSamples.GetBondForQuery());

            /***********************/
            /*** Market Scanners ***/
            /***********************/
            /*** Requesting all available parameters which can be used to build a scanner request ***/
            //wrapper.ClientSocket.reqScannerParameters();
            /*** Triggering a scanner subscription ***/
            //wrapper.ClientSocket.reqScannerSubscription(7001, ScannerSubscriptionSamples.GetScannerSubscription(), GetFakeParameters(5));
            /*** Canceling the scanner subscription ***/
            //wrapper.ClientSocket.cancelScannerSubscription(7001);

            /*****************************/
            /*** Reuter's Fundamentals ***/
            /*****************************/
            /*** Requesting Fundamentals ***/
            //wrapper.ClientSocket.reqFundamentalData(8001, ContractSamples.GetUSStock(), "snapshot", GetFakeParameters(4));
            /*** Camceling fundamentals request ***/
            //wrapper.ClientSocket.cancelFundamentalData(8001);

            /***********************/
            /*** IB's Bulletins ***/
            /***********************/
            /*** Requesting Interactive Broker's news bulletins */
            //wrapper.ClientSocket.reqNewsBulletins(true);
            /*** Canceling IB's news bulletins ***/
            //wrapper.ClientSocket.cancelNewsBulletin();

            /**************************/
            /*** Account Management ***/
            /**************************/
            /*** Requesting managed accounts***/
            //wrapper.ClientSocket.reqManagedAccts();
            /*** Requesting accounts' summary ***/
            //wrapper.ClientSocket.reqAccountSummary(9001, "All", AccountSummaryTags.GetAllTags());
            /*** Subscribing to an account's information. Only one at a time! ***/
            //wrapper.ClientSocket.reqAccountUpdates(true, "U150462");
            /*** Requesting all accounts' positions. ***/
            //wrapper.ClientSocket.reqPositions();

            /**********************/
            /*** Order handling ***/
            /**********************/
            /*** Requesting the next valid id ***/
            //wrapper.ClientSocket.reqIds(-1);
            /*** Requesting all open orders ***/
            //wrapper.ClientSocket.reqAllOpenOrders();
            /*** Taking over orders to be submitted via TWS ***/
            //wrapper.ClientSocket.reqAutoOpenOrders(true);
            /*** Requesting this API client's orders ***/
            //wrapper.ClientSocket.reqOpenOrders();
            /*** Placing/modifying an order - remember to ALWAYS increment the nextValidId after placing an order so it can be used for the next one! ***/
            //Order order = OrderSamples.LimitOrder();
            //order.OrderMiscOptions = GetFakeParameters(3);
            //wrapper.ClientSocket.placeOrder(wrapper.NextOrderId++, ContractSamples.getComboContract(), order);
            //wrapper.ClientSocket.placeOrder(wrapper.NextOrderId++, ContractSamples.getComboContract(), OrderSamples.LimitOrderForComboWithLegPrice());
            //wrapper.ClientSocket.placeOrder(wrapper.NextOrderId++, ContractSamples.getVixComboContract(), OrderSamples.LimitOrder());
            /*** Cancel all orders for all accounts ***/
            //wrapper.ClientSocket.reqGlobalCancel();
            /*** Request the day's executions ***/
            //wrapper.ClientSocket.reqExecutions(10001, new ExecutionFilter());

            /************************************/
            /*** Financial Advisor Exclusive Operations ***/
            /************************************/
            /*** Requesting FA information ***/
            //wrapper.ClientSocket.requestFA(Constants.FaAliases);
            //wrapper.ClientSocket.requestFA(Constants.FaGroups);
            //wrapper.ClientSocket.requestFA(Constants.FaProfiles);
            /*** Replacing FA information - Fill in with the appropriate XML string. ***/
            //wrapper.ClientSocket.replaceFA(Constants.FaGroups, "");


            /********************/
            /*** Miscelaneous ***/
            /********************/
            /*** Request TWS' current time ***/
            //wrapper.ClientSocket.reqCurrentTime();
            /*** Setting TWS logging level  ***/
            //wrapper.ClientSocket.setServerLogLevel(1);

            /********************/
            /*** Linking ***/
            /********************/
            //wrapper.ClientSocket.verifyRequest("a name", "9.71");
            //wrapper.ClientSocket.verifyMessage("apiData");
            //wrapper.ClientSocket.queryDisplayGroups(123);
            //wrapper.ClientSocket.subscribeToGroupEvents(124, 1);
            //wrapper.ClientSocket.updateDisplayGroup(125, "contract info");
            //wrapper.ClientSocket.unsubscribeFromGroupEvents(124);

            //Thread.Sleep(3000);
            Console.WriteLine("Done");
            Thread.Sleep(500000);
        }

        private static List<TagValue> GetFakeParameters(int numParams)
        {
            List<TagValue> fakeParams = new List<TagValue>();
            for (int i = 0; i < numParams; i++)
                fakeParams.Add(new TagValue("tag" + i, i.ToString()));
            return fakeParams;
        }
        
    }
}