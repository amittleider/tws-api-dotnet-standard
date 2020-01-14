﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace IBApi
{
    /**
    * @brief Used with conditional orders to place or submit an order based on a percentage change of an instrument to the last close price.
    */
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
