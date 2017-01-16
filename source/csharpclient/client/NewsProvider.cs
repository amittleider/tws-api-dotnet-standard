/* Copyright (C) 2017 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace IBApi
{
    /**
     * @class NewsProvider
     * @brief Class describing news provider
     * @sa EClient::reqNewsProviders, EWrapper::newsProviders
     */
    public class NewsProvider
    {
        private String providerCode;
        private String providerName;

        /**
         * @brief The API news provider code
         */
        public string ProviderCode
        {
            get { return providerCode; }
            set { providerCode = value; }
        }

        /**
         * @brief The API news provider name
         */
        public string ProviderName
        {
            get { return providerName; }
            set { providerName = value; }
        }

        public NewsProvider()
        {

        }

        public NewsProvider(String providerCode, String providerName)
        {
            ProviderCode = providerCode;
            ProviderName = providerName;
        }
    }
}
