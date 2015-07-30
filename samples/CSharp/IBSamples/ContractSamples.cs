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
     */
    public class ContractSamples
    {
        /*
         * Usually, the easiest way to define a Stock/CASH contract is through these four attributes.
         */
        public static Contract EurGbpFx()
        {
            Contract contract = new Contract();
            contract.Symbol = "EUR";
            contract.SecType = "CASH";
            contract.Currency = "GBP";
            contract.Exchange = "IDEALPRO";
            return contract;
        }

        public static Contract EuropeanStock()
        {
            Contract contract = new Contract();
            contract.Symbol = "SMTPC";
            contract.SecType = "STK";
            contract.Currency = "EUR";
            contract.Exchange = "BATEEN";
            return contract;
        }

        public static Contract USStock()
        {
            Contract contract = new Contract();
            contract.Symbol = "IBKR";
            contract.SecType = "STK";
            contract.Currency = "USD";
            contract.Exchange = "SMART";
            return contract;
        }

        /*
         * Option contracts require far more information since there are many contracts having the exact same
         * attributes such as symbol, currency, strike, etc. 
         */
        public static Contract NormalOption()
        {
            Contract contract = new Contract();
            contract.Symbol = "BAYN";
            contract.SecType = "OPT";
            contract.Exchange = "DTB";
            contract.Currency = "EUR";
            contract.LastTradeDateOrContractMonth = "201612";
            contract.Strike = 100;
            contract.Right = "C";
            contract.Multiplier = "100";
            return contract;
        }

        /*
         * This contract for example requires the trading class too in order to prevent any ambiguity.
         */
        public static Contract OptionWithTradingClass()
        {
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
            return contract;
        }

        /*
         * Future contracts also require an expiration date but are less complicated than options.
         */
        public static Contract SimpleFuture()
        {
            Contract contract = new Contract();
            contract.Symbol = "ES";
            contract.SecType = "FUT";
            contract.Exchange = "GLOBEX";
            contract.Currency = "USD";
            contract.LastTradeDateOrContractMonth = "201609";
            return contract;
        }

        /*
         * Rather than giving expiration dates we can also provide the local symbol
         * attributes such as symbol, currency, strike, etc. 
         */
        public static Contract FutureWithLocalSymbol()
        {
            Contract contract = new Contract();
            contract.SecType = "FUT";
            contract.Exchange = "GLOBEX";
            contract.Currency = "USD";
            contract.LocalSymbol = "ESU6"; ;
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
            Contract contract = new Contract();
            contract.Symbol = "ES";
            contract.SecType = "FOP";
            contract.Exchange = "GLOBEX";
            contract.Currency = "USD";
            contract.LastTradeDateOrContractMonth = "20160617";
            contract.Strike = 1810;
            contract.Right = "C";
            contract.Multiplier = "50";
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
            Contract contract = new Contract();
            contract.Symbol = "FISV";
            contract.SecType = "OPT";
            contract.Exchange = "SMART";
            contract.Currency = "USD";
            return contract;
        }

        /*
         * STK Combo contract
         * Leg 1: 43645865 - IBKR's STK
         * Leg 2: 9408 - McDonald's STK
         */
        public static Contract StockComboContract()
        {
            Contract contract = new Contract();
            contract.Symbol = "MCD";
            contract.SecType = "BAG";
            contract.Currency = "USD";
            contract.Exchange = "SMART";

            ComboLeg leg1 = new ComboLeg();
            leg1.ConId = 43645865;
            leg1.Ratio = 1;
            leg1.Action = "BUY";
            leg1.Exchange = "SMART";

            ComboLeg leg2 = new ComboLeg();
            leg2.ConId = 9408;
            leg2.Ratio = 1;
            leg2.Action = "SELL";
            leg2.Exchange = "SMART";

            contract.ComboLegs = new List<ComboLeg>();
            contract.ComboLegs.Add(leg1);
            contract.ComboLegs.Add(leg2);

            return contract;
        }

        /*
         * CBOE Volatility Index Future combo contract
         * Leg 1: 195538625 - FUT expiring 2016/02/17
         * Leg 2: 197436571 - FUT expiring 2016/03/16
         */
        public static Contract FutureComboContract()
        {
            Contract contract = new Contract();
            contract.Symbol = "RB";
            contract.SecType = "BAG";
            contract.Currency = "USD";
            contract.Exchange = "NYMEX";

            ComboLeg leg1 = new ComboLeg();
            leg1.ConId = 114833269;
            leg1.Ratio = 1;
            leg1.Action = "BUY";
            leg1.Exchange = "NYMEX";

            ComboLeg leg2 = new ComboLeg();
            leg2.ConId = 113088887;
            leg2.Ratio = 1;
            leg2.Action = "SELL";
            leg2.Exchange = "NYMEX";

            contract.ComboLegs = new List<ComboLeg>();
            contract.ComboLegs.Add(leg1);
            contract.ComboLegs.Add(leg2);
            
            return contract;
        }
    }
}
