/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBApi;

namespace IBSampleApp.messages
{
    class ContractDetailsMessage
    {
        private int requestId;
        private ContractDetails contractDetails;
        
        public ContractDetailsMessage(int requestId, ContractDetails contractDetails)
        {
            RequestId = requestId;
            ContractDetails = contractDetails;
        }

        public ContractDetails ContractDetails
        {
            get { return contractDetails; }
            set { contractDetails = value; }
        }

        public int RequestId
        {
            get { return requestId; }
            set { requestId = value; }
        }
    }
}
