/* Copyright (C) 2017 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBApi;

namespace IBSampleApp.messages
{
    class NewsArticleMessage
    {
        public int RequestId { get; private set; }
        public int ArticleType { get; private set; }
        public string ArticleText { get; private set; }

        public NewsArticleMessage(int requestId, int articleType, string articleText)
        {
            this.RequestId = requestId;
            this.ArticleType = articleType;
            this.ArticleText = articleText;
        }
    }
}
