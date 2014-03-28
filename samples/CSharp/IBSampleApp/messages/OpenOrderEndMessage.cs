/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBSampleApp.messages
{
    public class OpenOrderEndMessage : OrderMessage
    {
        public OpenOrderEndMessage()
        {
            Type = MessageType.OpenOrderEnd;
        }
    }
}
