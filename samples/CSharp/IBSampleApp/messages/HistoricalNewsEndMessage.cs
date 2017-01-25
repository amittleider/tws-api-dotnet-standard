/* Copyright (C) 2017 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBApi;

namespace IBSampleApp.messages
{
    public class HistoricalNewsEndMessage
    {
        public int RequestId { get; private set; }
        public bool HasMore { get; private set; }

        public HistoricalNewsEndMessage(int requestId, bool hasMore)
        {
            this.RequestId = requestId;
            this.HasMore = hasMore;
        }
    }
}
