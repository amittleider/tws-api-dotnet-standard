/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBSampleApp.messages
{
    public abstract class MarketDataMessage : IBMessage
    {
        protected int requestId;
        protected int field;

        public MarketDataMessage(MessageType type, int requestId, int field)
        {
            Type = type;
            RequestId = requestId;
            Field = field;
        }

        public int RequestId
        {
            get { return requestId; }
            set { requestId = value; }
        }

        public int Field
        {
            get { return field; }
            set { field = value; }
        }
    }
}
