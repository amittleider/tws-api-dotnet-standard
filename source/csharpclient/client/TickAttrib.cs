/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBApi
{
	/**
     * @class TickAttrib
     * @brief Tick attributes that describes additional information for price ticks
     * @sa EWrapper::tickPrice
     */
    public class TickAttrib
    {
		/**
         * @brief Specifies whether the price tick is available for automatic execution (1) or not (0)
         */
        public bool CanAutoExecute { get; set; }

		/**
         * @brief Indicates whether the bid price is lower than the day's lowest value or the ask price is higher than the highest ask 
         */
        public bool PastLimit { get; set; }

		/**
         * @brief Indicates whether the bid/ask price tick is from pre-open session
         */
        public bool PreOpen { get; set; }

        public bool Unreported { get; set; }

        public bool BidPastLow { get; set; }

        public bool AskPastHigh { get; set; }
    }
}
