/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBApi;

namespace IBSampleApp.messages
{
    class UpdatePortfolioMessage
    {
        private Contract contract;
        private double position;
        private double marketPrice;
        private double marketValue;
        private double averageCost;
        private double unrealizedPNL;
        private double realizedPNL;
        private string accountName;

        public UpdatePortfolioMessage(Contract contract, double position, double marketPrice, double marketValue, double averageCost, double unrealizedPNL, double realizedPNL, string accountName)
        {
            Contract = contract;
            Position = position;
            MarketPrice = marketPrice;
            MarketValue = marketValue;
            AverageCost = averageCost;
            UnrealizedPNL = unrealizedPNL;
            RealizedPNL = realizedPNL;
            AccountName = accountName;
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
        
        public double MarketPrice
        {
            get { return marketPrice; }
            set { marketPrice = value; }
        }
        
        public double MarketValue
        {
            get { return marketValue; }
            set { marketValue = value; }
        }
        
        public double AverageCost
        {
            get { return averageCost; }
            set { averageCost = value; }
        }
        
        public double UnrealizedPNL
        {
            get { return unrealizedPNL; }
            set { unrealizedPNL = value; }
        }
        
        public double RealizedPNL
        {
            get { return realizedPNL; }
            set { realizedPNL = value; }
        }
        
        public string AccountName
        {
            get { return accountName; }
            set { accountName = value; }
        }

    }
}
