/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBApi;

namespace Samples
{
    /*
     * Contracts can be defined in multiple ways. The TWS/IB Gateway will always perform a query on the available contracts
     * and find which one is the best candidate:
     *  - More than a single candidate will yield an ambiguity error message.
     *  - No suitable candidates will produce a "contract not found" message.
     *  How do I find my contract though?
     *  - Often the quickest way is by looking for it in the TWS and looking at its description there (double click).
     *  - The TWS' symbol corresponds to the API's localSymbol. Keep this in mind when defining Futures or Options.
     *  - The TWS' underlying's symbol can usually be mapped to the API's symbol.
     *  
     * Any stock or option symbols displayed are for illustrative purposes only and are not intended to portray a recommendation.
     */
    public class ContractSamples
    {
        /*
         * Usually, the easiest way to define a Stock/CASH contract is through these four attributes.
         */
        public static Contract EurGbpFx()
        {
            //! [cashcontract]
            Contract contract = new Contract();
            contract.Symbol = "EUR";
            contract.SecType = "CASH";
            contract.Currency = "GBP";
            contract.Exchange = "IDEALPRO";
            //! [cashcontract]
            return contract;
        }

        public static Contract Index()
        {
            //! [indcontract]
            Contract contract = new Contract();
            contract.Symbol = "DAX";
            contract.SecType = "IND";
            contract.Currency = "EUR";
            contract.Exchange = "DTB";
            //! [indcontract]
            return contract;
        }

        public static Contract CFD()
        {
            //! [cfdcontract]
            Contract contract = new Contract();
            contract.Symbol = "IBDE30";
            contract.SecType = "CFD";
            contract.Currency = "EUR";
            contract.Exchange = "SMART";
            //! [cfdcontract]
            return contract;
        }

        public static Contract EuropeanStock()
        {
            Contract contract = new Contract();
            contract.Symbol = "SIE";
            contract.SecType = "STK";
            contract.Currency = "EUR";
            contract.Exchange = "SMART";
            return contract;
        }

        public static Contract OptionAtIse()
        {
            Contract contract = new Contract();
            contract.Symbol = "BPX";
            contract.SecType = "OPT";
            contract.Currency = "USD";
            contract.Exchange = "ISE";
            contract.LastTradeDateOrContractMonth = "20160916";
            contract.Right = "C";
            contract.Strike = 65;
            contract.Multiplier = "100";
            return contract;
        }

		public static Contract BondWithCusip() {
			//! [bondwithcusip]
			Contract contract = new Contract();
			// enter CUSIP as symbol
			contract.Symbol= "912828C57";
			contract.SecType = "BOND";
			contract.Exchange = "SMART";
			contract.Currency = "USD";
			//! [bondwithcusip]
			return contract;
		}
	
		public static Contract Bond() {
			//! [bond]
			Contract contract = new Contract();
			contract.ConId = 147554578;
			contract.Exchange = "SMART";
			//! [bond]
			return contract;
		}
	
		public static Contract MutualFund() {
			//! [fundcontract]
			Contract contract = new Contract();
			contract.Symbol = "VINIX";
			contract.SecType = "FUND";
			contract.Exchange = "FUNDSERV";
			contract.Currency = "USD";
			//! [fundcontract]
			return contract;
		}
	
		public static Contract Commodity() {
			//! [commoditycontract]
			Contract contract = new Contract();
			contract.Symbol = "XAUUSD";
			contract.SecType = "CMDTY";
			contract.Exchange = "SMART";
			contract.Currency = "USD";
			//! [commoditycontract]
			return contract;
		}
		
        public static Contract USStock()
        {
            //! [stkcontract]
            Contract contract = new Contract();
            contract.Symbol = "IBKR";
            contract.SecType = "STK";
            contract.Currency = "USD";
            //In the API side, NASDAQ is always defined as ISLAND in the exchange field
            contract.Exchange = "ISLAND";
            //! [stkcontract]
            return contract;
        }

		public static Contract USStockWithPrimaryExch() {
			//! [stkcontractwithprimary]
			Contract contract = new Contract();
			contract.Symbol = "MSFT";
			contract.SecType = "STK";
			contract.Currency = "USD";
			contract.Exchange = "SMART";
			//Specify the Primary Exchange attribute to avoid contract ambiguity
            contract.PrimaryExch = "ISLAND";
			//! [stkcontractwithprimary]
			return contract;
		}
		
		
        public static Contract USStockAtSmart()
        {
            Contract contract = new Contract();
            contract.Symbol = "IBKR";
            contract.SecType = "STK";
            contract.Currency = "USD";
            contract.Exchange = "SMART";
            return contract;
        }

        public static Contract USOptionContract()
        {
            //! [optcontract_us]
            Contract contract = new Contract();
            contract.Symbol = "GOOG";
            contract.SecType = "OPT";
            contract.Exchange = "SMART";
            contract.Currency = "USD";
            contract.LastTradeDateOrContractMonth = "20170120";
            contract.Strike = 615;
            contract.Right = "C";
            contract.Multiplier = "100";
            //! [optcontract_us]
            return contract;
        }

        public static Contract OptionAtBOX()
        {
            //! [optcontract]
            Contract contract = new Contract();
            contract.Symbol = "GOOG";
            contract.SecType = "OPT";
            contract.Exchange = "BOX";
            contract.Currency = "USD";
            contract.LastTradeDateOrContractMonth = "20170120";
            contract.Strike = 615;
            contract.Right = "C";
            contract.Multiplier = "100";
            //! [optcontract]
            return contract;
        }

        /*
         * Option contracts require far more information since there are many contracts having the exact same
         * attributes such as symbol, currency, strike, etc. This can be overcome by adding more details such as the trading class
         */
        public static Contract OptionWithTradingClass()
        {
            //! [optcontract_tradingclass]
            Contract contract = new Contract();
            contract.Symbol = "SANT";
            contract.SecType = "OPT";
            contract.Exchange = "MEFFRV";
            contract.Currency = "EUR";
            contract.LastTradeDateOrContractMonth = "20190621";
            contract.Strike = 7.5;
            contract.Right = "C";
            contract.Multiplier = "100";
            contract.TradingClass = "SANEU";
            //! [optcontract_tradingclass]
            return contract;
        }

        /*
         * Using the contract's own symbol (localSymbol) can greatly simplify a contract description
         */
        public static Contract OptionWithLocalSymbol()
        {
            //! [optcontract_localsymbol]
            Contract contract = new Contract();
            //Watch out for the spaces within the local symbol!
            contract.LocalSymbol = "C DBK  DEC 20  1600";
            contract.SecType = "OPT";
            contract.Exchange = "DTB";
            contract.Currency = "EUR";
            //! [optcontract_localsymbol]
            return contract;
        }

        /*
         * Future contracts also require an expiration date but are less complicated than options.
         */
        public static Contract SimpleFuture()
        {
            //! [futcontract]
            Contract contract = new Contract();
            contract.Symbol = "ES";
            contract.SecType = "FUT";
            contract.Exchange = "GLOBEX";
            contract.Currency = "USD";
            contract.LastTradeDateOrContractMonth = "201612";
            //! [futcontract]
            return contract;
        }

        /*
         * Rather than giving expiration dates we can also provide the local symbol
         * attributes such as symbol, currency, strike, etc. 
         */
        public static Contract FutureWithLocalSymbol()
        {
            //! [futcontract_local_symbol]
            Contract contract = new Contract();
            contract.SecType = "FUT";
            contract.Exchange = "GLOBEX";
            contract.Currency = "USD";
            contract.LocalSymbol = "ESU6";
            //! [futcontract_local_symbol]
            return contract;
        }

        public static Contract FutureWithMultiplier()
        {
            //! [futcontract_multiplier]
            Contract contract = new Contract();
            contract.Symbol = "DAX";
            contract.SecType = "FUT";
            contract.Exchange = "DTB";
            contract.Currency = "EUR";
            contract.LastTradeDateOrContractMonth = "201609";
            contract.Multiplier = "5";
            //! [futcontract_multiplier]
            return contract;
        }

        /*
         * Note the space in the symbol!
         */
        public static Contract WrongContract()
        {
            Contract contract = new Contract();
            contract.Symbol = " IJR ";
            contract.ConId = 9579976;
            contract.SecType = "STK";
            contract.Exchange = "SMART";
            contract.Currency = "USD";
            return contract;
        }

        public static Contract FuturesOnOptions()
        {
            //! [fopcontract]
            Contract contract = new Contract();
            contract.Symbol = "ES";
            contract.SecType = "FOP";
            contract.Exchange = "GLOBEX";
            contract.Currency = "USD";
            contract.LastTradeDateOrContractMonth = "20160617";
            contract.Strike = 1810;
            contract.Right = "C";
            contract.Multiplier = "50";
            //! [fopcontract]
            return contract;
        }

        /*
         * It is also possible to define contracts based on their ISIN (IBKR STK sample).
         * 
         */
        public static Contract ByISIN()
        {
            Contract contract = new Contract();
            contract.SecIdType = "ISIN";
            contract.SecId = "US45841N1072";
            contract.Exchange = "SMART";
            contract.Currency = "USD";
            contract.SecType = "STK";
            return contract;
        }

        /*
         * Or their conId (EUR.USD sample).
         * Note: passing a contract containing the conId can cause problems if one of the other provided
         * attributes does not match 100% with what is in IB's database. This is particularly important
         * for contracts such as Bonds which may change their description from one day to another.
         * If the conId is provided, it is best not to give too much information as in the example below.
         */
        public static Contract ByConId()
        {
            Contract contract = new Contract();
            contract.SecType = "CASH";
            contract.ConId = 12087792;
            contract.Exchange = "IDEALPRO";
            return contract;
        }

        /*
         * Ambiguous contracts are great to use with reqContractDetails. This way you can
         * query the whole option chain for an underlying. Bear in mind that there are
         * pacing mechanisms in place which will delay any further responses from the TWS
         * to prevent abuse.
         */
        public static Contract OptionForQuery()
        {
            //! [optionforquery]
            Contract contract = new Contract();
            contract.Symbol = "FISV";
            contract.SecType = "OPT";
            contract.Exchange = "SMART";
            contract.Currency = "USD";
            //! [optionforquery]
            return contract;
        }

        public static Contract OptionComboContract()
        {
            //! [bagoptcontract]
            Contract contract = new Contract();
            contract.Symbol = "DBK";
            contract.SecType = "BAG";
            contract.Currency = "EUR";
            contract.Exchange = "DTB";

            ComboLeg leg1 = new ComboLeg();
            leg1.ConId = 197397509;//DBK JUN 15 '18 C
            leg1.Ratio = 1;
            leg1.Action = "BUY";
            leg1.Exchange = "DTB";

            ComboLeg leg2 = new ComboLeg();
            leg2.ConId = 197397584;//DBK JUN 15 '18 P
            leg2.Ratio = 1;
            leg2.Action = "SELL";
            leg2.Exchange = "DTB";

            contract.ComboLegs = new List<ComboLeg>();
            contract.ComboLegs.Add(leg1);
            contract.ComboLegs.Add(leg2);
            //! [bagoptcontract]
            return contract;
        }

        /*
         * STK Combo contract
         * Leg 1: 43645865 - IBKR's STK
         * Leg 2: 9408 - McDonald's STK
         */
        public static Contract StockComboContract()
        {
            //! [bagstkcontract]
            Contract contract = new Contract();
            contract.Symbol = "IBKR,MCD";
            contract.SecType = "BAG";
            contract.Currency = "USD";
            contract.Exchange = "SMART";

            ComboLeg leg1 = new ComboLeg();
            leg1.ConId = 43645865;//IBKR STK
            leg1.Ratio = 1;
            leg1.Action = "BUY";
            leg1.Exchange = "SMART";

            ComboLeg leg2 = new ComboLeg();
            leg2.ConId = 9408;//MCD STK
            leg2.Ratio = 1;
            leg2.Action = "SELL";
            leg2.Exchange = "SMART";

            contract.ComboLegs = new List<ComboLeg>();
            contract.ComboLegs.Add(leg1);
            contract.ComboLegs.Add(leg2);
            //! [bagstkcontract]
            return contract;
        }

        /*
         * CBOE Volatility Index Future combo contract
         * Leg 1: 195538625 - FUT expiring 2016/02/17
         * Leg 2: 197436571 - FUT expiring 2016/03/16
         */
        public static Contract FutureComboContract()
        {
            //! [bagfutcontract]
            Contract contract = new Contract();
            contract.Symbol = "VIX";
            contract.SecType = "BAG";
            contract.Currency = "USD";
            contract.Exchange = "CFE";

            ComboLeg leg1 = new ComboLeg();
            leg1.ConId = 195538625;//VIX FUT 20160217
            leg1.Ratio = 1;
            leg1.Action = "BUY";
            leg1.Exchange = "CFE";

            ComboLeg leg2 = new ComboLeg();
            leg2.ConId = 197436571;//VIX FUT 20160316
            leg2.Ratio = 1;
            leg2.Action = "SELL";
            leg2.Exchange = "CFE";

            contract.ComboLegs = new List<ComboLeg>();
            contract.ComboLegs.Add(leg1);
            contract.ComboLegs.Add(leg2);
            //! [bagfutcontract]
            return contract;
        }

        public static Contract InterCmdtyFuturesContract()
        {
            //! [intcmdfutcontract]
            Contract contract = new Contract();
            contract.Symbol = "CL.BZ";
            contract.SecType = "BAG";
            contract.Currency = "USD";
            contract.Exchange = "NYMEX";

            ComboLeg leg1 = new ComboLeg();
            leg1.ConId = 47207310; //CL Dec'16 @NYMEX
            leg1.Ratio = 1;
            leg1.Action = "BUY";
            leg1.Exchange = "NYMEX";

            ComboLeg leg2 = new ComboLeg();
            leg2.ConId = 47195961; //BZ Dec'16 @NYMEX
            leg2.Ratio = 1;
            leg2.Action = "SELL";
            leg2.Exchange = "NYMEX";

            contract.ComboLegs = new List<ComboLeg>();
            contract.ComboLegs.Add(leg1);
            contract.ComboLegs.Add(leg2);
            //! [intcmdfutcontract]
            return contract;
        }

        public static Contract NewsFeedForQuery()
        {
            //! [newsfeedforquery]
            Contract contract = new Contract();
            contract.SecType = "NEWS";
            contract.Exchange = "BT"; //Briefing Trader
            //! [newsfeedforquery]
            return contract;
        }

        public static Contract BTbroadtapeNewsFeed()
        {
            //! [newscontractbt]
            Contract contract = new Contract();
            contract.Symbol  = "BT:BT_ALL"; //BroadTape All News
            contract.SecType = "NEWS";
            contract.Exchange = "BT"; //Briefing Trader
            //! [newscontractbt]
            return contract;
        }

        public static Contract BZbroadtapeNewsFeed()
        {
            //! [newscontractbz]
            Contract contract = new Contract();
            contract.Symbol = "BZ:BZ_ALL"; //BroadTape All News
            contract.SecType = "NEWS";
            contract.Exchange = "BZ"; //Benzinga Pro
            //! [newscontractbz]
            return contract;
        }

        public static Contract FLYbroadtapeNewsFeed()
        {
            //! [newscontractfly]
            Contract contract = new Contract();
            contract.Symbol  = "FLY:FLY_ALL"; //BroadTape All News
            contract.SecType = "NEWS";
            contract.Exchange = "FLY"; //Fly on the Wall
           //! [newscontractfly]
            return contract;
        }

        public static Contract MTbroadtapeNewsFeed()
        {
            //! [newscontractmt]
            Contract contract = new Contract();
            contract.Symbol = "MT:MT_ALL"; //BroadTape All News
            contract.SecType = "NEWS";
            contract.Exchange = "MT"; //Midnight Trader
            //! [newscontractmt]
            return contract;
        }

    }
}
