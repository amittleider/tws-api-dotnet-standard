/* Copyright (C) 2015 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBApi
{
    /**
     * @class DepthMktDataDescription
     * @brief A class for storing depth market data desctiption
     */
    public class DepthMktDataDescription
    {
        private String exchange;
        private String secType;
        private bool isL2;

        /**
         * @brief The exchange name
         */
        public string Exchange
        {
            get { return exchange; }
            set { exchange = value; }
        }

        /**
         * @brief The security type
         */
        public string SecType
        {
            get { return secType; }
            set { secType = value; }
        }

        /**
         * @brief The L2 flag
         */
        public bool IsL2
        {
            get { return isL2; }
            set { isL2 = value; }
        }

        public DepthMktDataDescription()
        {
        }

        public DepthMktDataDescription(string exchange, string secType, bool isL2)
        {
            this.Exchange = exchange;
            this.SecType = secType;
            this.IsL2 = isL2;
        }
    }
}
