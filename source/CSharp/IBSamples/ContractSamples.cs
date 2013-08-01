using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBApi
{
    public class ContractSamples
    {
        public static Contract getOption()
        {
            Contract contract = new Contract();
            contract.Symbol = "EOE";
            contract.SecType = "OPT";
            contract.Exchange = "FTA";
            contract.Currency = "EUR";
            contract.Expiry = "20130920";//Expiration time
            contract.Strike = 350;
            contract.Right = "CALL";
            contract.Multiplier = "100";
            return contract;
        }

        public static Contract getOptionToExercide()
        {
            Contract contract = new Contract();
            contract.Symbol = "AAPL";
            contract.SecType = "OPT";
            contract.Exchange = "CBOE2";//Boston Options Exchange
            contract.Currency = "USD";
            contract.Expiry = "20130816";//Expiration time
            contract.Strike = 430;
            contract.Right = "CALL";
            contract.Multiplier = "100";
            return contract;
        }

        public static Contract getEurUsdForex()
        {
            Contract contract = new Contract();
            contract.Symbol = "EUR";
            contract.SecType = "CASH";
            contract.Currency = "USD";
            contract.Exchange = "IDEALPRO";
            return contract;
        }

        public static Contract getEurGbpForex()
        {
            Contract contract = new Contract();
            contract.Symbol = "EUR";
            contract.SecType = "CASH";
            contract.Currency = "GBP";
            contract.Exchange = "IDEALPRO";
            return contract;
        }

        public static Contract getEuropeanStock()
        {
            Contract contract = new Contract();
            contract.Symbol = "SAB";
            contract.SecType = "STK";
            contract.Currency = "GBP";
            contract.Exchange = "LSE";
            return contract;
        }
    }
}
