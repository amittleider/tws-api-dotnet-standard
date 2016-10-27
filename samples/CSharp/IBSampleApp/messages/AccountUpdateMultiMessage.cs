/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBApi;

namespace IBSampleApp.messages
{
    public class AccountUpdateMultiMessage : IBMessage 
    {
        private int reqId;
        private string account;
        private string modelCode;
        private string key;
        private string value;
        private string currency;
        
        public AccountUpdateMultiMessage(int reqId, string account, string modelCode, string key, string value, string currency)
        {
            Type = MessageType.AccountUpdateMulti;
            Account = account;
            ModelCode = modelCode;
            Key = key;
            Value = value;
            Currency = currency;
        }

        public int ReqId
        {
            get { return reqId; }
            set { reqId = value; }
        }

        public string Account
        {
            get { return account; }
            set { account = value; }
        }

        public string ModelCode
        {
            get { return modelCode; }
            set { modelCode = value; }
        }

        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public string Currency
        {
            get { return currency; }
            set { currency = value; }
        }

    }
}
