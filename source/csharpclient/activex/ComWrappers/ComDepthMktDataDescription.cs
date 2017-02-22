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
     * @class DepthMktDataDescription
     * @brief depth market data description
     */
    [ComVisible(true)]
    public class ComDepthMktDataDescription : ComWrapper<DepthMktDataDescription>, IDepthMktDataDescription
    {
        /**
        * @brief exchange
        */
        public string Exchange
        {
            get { return data != null ? data.Exchange : default(string); }
            set { if (data != null) data.Exchange = value; }
        }

        /**
        * @brief security type
        */
        public string SecType
        {
            get { return data != null ? data.SecType : default(string); }
            set { if (data != null) data.SecType = value; }
        }

        /**
        * @brief listing exchange
        */
        public string ListingExch
        {
            get { return data != null ? data.ListingExch : default(string); }
            set { if (data != null) data.ListingExch = value; }
        }

        /**
        * @brief service data type
        */
        public string ServiceDataType
        {
            get { return data != null ? data.ServiceDataType : default(string); }
            set { if (data != null) data.ServiceDataType = value; }
        }

        /**
        * @brief aggregated group
        */
        public int AggGroup
        {
            get { return data != null ? data.AggGroup : default(int); }
            set { if (data != null) data.AggGroup = value; }
        }

        string TWSLib.IDepthMktDataDescription.exchange
        {
            get { return Exchange; }
        }

        string TWSLib.IDepthMktDataDescription.secType
        {
            get { return SecType; }
        }

        string TWSLib.IDepthMktDataDescription.listingExch
        {
            get { return ListingExch; }
        }

        string TWSLib.IDepthMktDataDescription.serviceDataType
        {
            get { return ServiceDataType; }
        }

        int TWSLib.IDepthMktDataDescription.aggGroup
        {
            get { return AggGroup; }
        }

        public static explicit operator ComDepthMktDataDescription(DepthMktDataDescription depthMktDataDescription)
        {
            return new ComDepthMktDataDescription().ConvertFrom(depthMktDataDescription) as ComDepthMktDataDescription;
        }

        public static explicit operator DepthMktDataDescription(ComDepthMktDataDescription comDepthMktDataDescription)
        {
            return comDepthMktDataDescription.ConvertTo();
        }
    }
}
