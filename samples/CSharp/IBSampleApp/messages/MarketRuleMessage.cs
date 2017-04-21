/* Copyright (C) 2017 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBApi;

namespace IBSampleApp.messages
{
    public class MarketRuleMessage
    {
        public int MarketruleId { get; private set; }
        public PriceIncrement[] PriceIncrements { get; private set; }

        public MarketRuleMessage(int marketRuleId, PriceIncrement[] priceIncrements)
        {
            this.MarketruleId = marketRuleId;
            this.PriceIncrements = priceIncrements;
        }
    }
}
