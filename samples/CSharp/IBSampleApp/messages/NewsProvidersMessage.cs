/* Copyright (C) 2017 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBApi;

namespace IBSampleApp.messages
{
    public class NewsProvidersMessage
    {
        public NewsProvider[] NewsProviders { get; private set; }

        public NewsProvidersMessage(NewsProvider[] newsProviders)
        {
            this.NewsProviders = newsProviders;
        }
    }
}
