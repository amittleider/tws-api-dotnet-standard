/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBSampleApp.messages
{
    public class MarketDataTypeMessage
    {
        protected int requestId;
        protected int marketDataType;

        public MarketDataTypeMessage(int requestId, int marketDataType)
        {
            RequestId = requestId;
            MarketDataType = marketDataType;
        }

        public int RequestId
        {
            get { return requestId; }
            set { requestId = value; }
        }

        public int MarketDataType
        {
            get { return marketDataType; }
            set { marketDataType = value; }
        }
    }
}
