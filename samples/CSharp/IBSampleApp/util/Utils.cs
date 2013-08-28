using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBApi;

namespace IBSampleApp.util
{
    public class Utils
    {
        public static string ContractToString(Contract contract)
        {
            return contract.Symbol + contract.SecType;
        }
    }
}
