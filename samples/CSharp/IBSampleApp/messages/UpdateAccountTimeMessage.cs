/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBSampleApp.messages
{
    public class UpdateAccountTimeMessage : IBMessage
    {
        private string timestamp;
        
        public UpdateAccountTimeMessage(string timestamp)
        {
            Type = MessageType.AccountUpdateTime;
            Timestamp = timestamp;
        }

        public string Timestamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }
    }
}
