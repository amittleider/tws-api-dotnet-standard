using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace IBApi
{
    public class PercentChangeCondition : ContractCondition
    {
        protected override string Value
        {
            get
            {
                return ChangePercent.ToString();
            }
            set
            {
                ChangePercent = double.Parse(value, NumberFormatInfo.InvariantInfo);
            }           
        }

        public double ChangePercent { get; set; }
    }
}
