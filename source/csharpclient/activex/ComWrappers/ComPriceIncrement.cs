/* Copyright (C) 2017 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using IBApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace TWSLib
{
    /**
     * @class PriceIncrement
     * @brief Class describing price increment
     * @sa EClient::reqMarketRule, EWrapper::marketRule
     */
    [ComVisible(true)]
    public class ComPriceIncrement : ComWrapper<PriceIncrement>, IPriceIncrement
    {
        /**
         * @brief The low edge
         */
        double LowEdge
        {
            get { return data != null ? data.LowEdge : default(double); }
            set { if (data != null) data.LowEdge = value; }
        }

        /**
         * @brief The increment
         */
        double Increment
        {
            get { return data != null ? data.Increment : default(double); }
            set { if (data != null) data.Increment = value; }
        }

        public ComPriceIncrement()
        {
        }

        double TWSLib.IPriceIncrement.lowEdge
        {
            get { return LowEdge; }
        }

        double TWSLib.IPriceIncrement.increment
        {
            get { return Increment; }
        }

        public static explicit operator PriceIncrement(ComPriceIncrement cpi)
        {
            return cpi.ConvertTo();
        }

        public static explicit operator ComPriceIncrement(PriceIncrement pi)
        {
            return new ComPriceIncrement().ConvertFrom(pi) as ComPriceIncrement;
        }
    }
}
