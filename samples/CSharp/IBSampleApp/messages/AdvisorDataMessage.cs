/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBSampleApp.messages
{
    public class AdvisorDataMessage : IBMessage 
    {
        private int faDataType;
        private string data;
        
        public AdvisorDataMessage(int faDataType, string data)
        {
            Type = MessageType.ReceiveFA;
            FaDataType = faDataType;
            Data = data;
        }

        public int FaDataType
        {
            get { return faDataType; }
            set { faDataType = value; }
        }

        public string Data
        {
            get { return data; }
            set { data = value; }
        }
    }
}
