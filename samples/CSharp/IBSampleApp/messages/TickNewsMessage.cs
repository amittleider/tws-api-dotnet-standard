/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBApi;

namespace IBSampleApp.messages
{
    class TickNewsMessage
    {
        public int TickerId { get; private set; }
        public long TimeStamp { get; private set; }
        public string ProviderCode { get; private set; }
        public string ArticleId { get; private set; }
        public string Headline { get; private set; }
        public string ExtraData { get; private set; }

        public TickNewsMessage(int tickerId, long timeStamp, string providerCode, string articleId, string headline, string extraData)
        {
            this.TickerId = tickerId;
            this.TimeStamp = timeStamp;
            this.ProviderCode = providerCode;
            this.ArticleId = articleId;
            this.Headline = headline;
            this.ExtraData = extraData;
        }
    }
}
