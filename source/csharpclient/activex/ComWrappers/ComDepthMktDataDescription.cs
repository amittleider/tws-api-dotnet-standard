/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
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
        * @brief is L2
        */
        public bool IsL2
        {
            get { return data != null ? data.IsL2 : default(bool); }
            set { if (data != null) data.IsL2 = value; }
        }

        
        string TWSLib.IDepthMktDataDescription.exchange
        {
            get { return Exchange; }
        }

        string TWSLib.IDepthMktDataDescription.secType
        {
            get { return SecType; }
        }

        bool TWSLib.IDepthMktDataDescription.isL2
        {
            get { return IsL2; }
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
