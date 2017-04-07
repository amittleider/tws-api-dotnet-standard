/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBApi;

namespace IBSampleApp.messages
{
    class SymbolSamplesMessage
    {
        public int ReqId { get; private set; }
        public ContractDescription[] ContractDescriptions { get; private set; }

        public SymbolSamplesMessage(int reqId, ContractDescription[] contractDescriptions)
        {
            this.ReqId = reqId;
            this.ContractDescriptions = contractDescriptions;
        }
    }
}
