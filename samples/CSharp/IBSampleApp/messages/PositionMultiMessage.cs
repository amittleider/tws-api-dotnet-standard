/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBApi;

namespace IBSampleApp.messages
{
    public class PositionMultiMessage : IBMessage 
    {
        private int reqId;
        private string account;
        private string modelCode;
        private Contract contract;
        private double position;
        private double averageCost;
        
        public PositionMultiMessage(int reqId, string account, string modelCode, Contract contract, double pos, double avgCost)
        {
            Type = MessageType.PositionMulti;
            ReqId = reqId;
            Account = account;
            ModelCode = modelCode;
            Contract = contract;
            Position = pos;
            AverageCost = avgCost;
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

        public Contract Contract
        {
            get { return contract; }
            set { contract = value; }
        }

        public double Position
        {
            get { return position; }
            set { position = value; }
        }
        
        public double AverageCost
        {
            get { return averageCost; }
            set { averageCost = value; }
        }
    }
}
