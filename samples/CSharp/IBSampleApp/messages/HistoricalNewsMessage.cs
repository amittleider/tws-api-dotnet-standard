/* Copyright (C) 2017 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBApi;

namespace IBSampleApp.messages
{
    public class HistoricalNewsMessage
    {
        public int RequestId { get; private set; }
        public string Time { get; private set; }
        public string ProviderCode { get; private set; }
        public string ArticleId { get; private set; }
        public string Headline { get; private set; }

        public HistoricalNewsMessage(int requestId, string time, string providerCode, string articleId, string headline)
        {
            this.RequestId = requestId;
            this.Time = time;
            this.ProviderCode = providerCode;
            this.ArticleId = articleId;
            this.Headline = headline;
        }
    }
}
