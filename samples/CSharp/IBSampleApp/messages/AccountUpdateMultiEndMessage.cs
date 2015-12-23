/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBApi;

namespace IBSampleApp.messages
{
    public class AccountUpdateMultiEndMessage : IBMessage 
    {
        private int reqId;
        
        public AccountUpdateMultiEndMessage(int reqId)
        {
            Type = MessageType.AccountUpdateMultiEnd;
            ReqId = ReqId;
        }

        public int ReqId
        {
            get { return reqId; }
            set { reqId = value; }
        }

    }
}
