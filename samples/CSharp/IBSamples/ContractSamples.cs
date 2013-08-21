using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBApi;

namespace Samples
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

        public static Contract getOptionForQuery()
        {
            Contract contract = new Contract();
            contract.Symbol = "IBM";
            contract.SecType = "OPT";
            contract.Exchange = "SMART";
            contract.Currency = "USD";
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

        public static Contract getComboContract()
        {
            Contract contract = new Contract();
            contract.Symbol = "MCD";
            contract.SecType = "BAG";
            contract.Currency = "USD";
            contract.Exchange = "SMART";

            ComboLeg leg1 = new ComboLeg();
            leg1.ConId = 128440094;
            leg1.Ratio = 1;
            leg1.Action = "BUY";
            leg1.Exchange = "SMART";

            ComboLeg leg2 = new ComboLeg();
            leg2.ConId = 126317126;
            leg2.Ratio = 1;
            leg2.Action = "SELL";
            leg2.Exchange = "SMART";

            contract.ComboLegs = new List<ComboLeg>();
            contract.ComboLegs.Add(leg1);
            contract.ComboLegs.Add(leg2);

            return contract;
        }
    }
}
