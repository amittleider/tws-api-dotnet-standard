/* Copyright (C) 2017 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using IBApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace TWSLib
{
    /**
     * @class NewsProvider
     * @brief Class describing news provider
     * @sa EClient::reqNewsProviders, EWrapper::newsProviders
     */
    [ComVisible(true)]
    public class ComNewsProvider : ComWrapper<NewsProvider>, INewsProvider
    {
        /**
         * @brief The API news provider code
         */
        public string ProviderCode
        {
            get { return data != null ? data.ProviderCode : default(string); }
            set { if (data != null) data.ProviderCode = value; }
        }

        /**
         * @brief The API news provider name
         */
        public string ProviderName
        {
            get { return data != null ? data.ProviderName : default(string); }
            set { if (data != null) data.ProviderName = value; }
        }

        public ComNewsProvider()
        {
        }

        string TWSLib.INewsProvider.providerCode
        {
            get { return ProviderCode; }
        }

        string TWSLib.INewsProvider.providerName
        {
            get { return ProviderName; }
        }

        public static explicit operator NewsProvider(ComNewsProvider cnp)
        {
            return cnp.ConvertTo();
        }

        public static explicit operator ComNewsProvider(NewsProvider np)
        {
            return new ComNewsProvider().ConvertFrom(np) as ComNewsProvider;
        }
    }
}
