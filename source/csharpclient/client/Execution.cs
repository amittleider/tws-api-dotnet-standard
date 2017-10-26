/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace IBApi
{

	/**
     * @class Liquidity
     * @brief Class describing the liquidity type of an execution.
     * @sa Execution
     */
    public class Liquidity
    {
		/**
         * @brief The enum of available liquidity flag types. 
		 * 0 = Unknown, 1 = Added liquidity, 2 = Removed liquidity, 3 = Liquidity routed out
         */
        public enum Values
        {
            None = 0,
            [Description("Added Liquidity")]
            Added = 1,
            [Description("Removed Liquidity")]
            Removed = 2,
            [Description("Liquidity Routed Out")]
            RoudedOut = 3
        }

        public Liquidity(int p)
        {
            Value = (Values)p;
        }
		
		/**
         * @brief The value of the liquidity type.
         */
        public Values Value { get; set; }

        public override string ToString()
        {
            return (Value.GetType().GetMember(Value + "")[0].GetCustomAttributes(typeof(DescriptionAttribute), true)[0] as DescriptionAttribute).Description;
        }
    }

    /**
     * @class Execution
     * @brief Class describing an order's execution.
     * @sa ExecutionFilter, CommissionReport
     */
    public class Execution
    {
        /**
         * @brief The API client's order Id. May not be unique to an account.
         */
        public int OrderId { get; set; }

        /**
         * @brief The API client identifier which placed the order which originated this execution.
         */
        public int ClientId { get; set; }

        /**
         * @brief The execution's unique identifier. Each partial fill has a separate ExecId. 
         */
        public string ExecId { get; set; }

        /**
         * @brief The execution's server time.
         */
        public string Time { get; set; }

        /**
         * @brief The account to which the order was allocated.
         */
        public string AcctNumber { get; set; }

        /**
         * @brief The exchange where the execution took place.
         */
        public string Exchange { get; set; }

        /**
         * @brief Specifies if the transaction was buy or sale
         * BOT for bought, SLD for sold
         */
        public string Side { get; set; }

        /**
         * @brief The number of shares filled.
         */
        public double Shares { get; set; }

        /**
         * @brief The order's execution price excluding commissions.
         */
        public double Price { get; set; }

        /**
         * @brief The TWS order identifier. The PermId can be 0 for trades originating outside IB. 
         */
        public int PermId { get; set; }

        /**
         * @brief Identifies whether an execution occurred because of an IB-initiated liquidation. 
         */
        public int Liquidation { get; set; }

        /**
         * @brief Cumulative quantity. 
         * Used in regular trades, combo trades and legs of the combo.
         */
        public double CumQty { get; set; }

        /**
         * @brief Average price. 
         * Used in regular trades, combo trades and legs of the combo. Does not include commissions.
         */
        public double AvgPrice { get; set; }

        /**
         * @brief The OrderRef is a user-customizable string that can be set from the API or TWS and will be associated with an order for its lifetime.
         */
        public string OrderRef { get; set; }

        /**
         * @brief The Economic Value Rule name and the respective optional argument.
         * The two values should be separated by a colon. For example, aussieBond:YearsToExpiration=3. When the optional argument is not present, the first value will be followed by a colon.
         */
        public string EvRule { get; set; }

        /**
         * @brief Tells you approximately how much the market value of a contract would change if the price were to change by 1.
         * It cannot be used to get market value by multiplying the price by the approximate multiplier.
         */
        public double EvMultiplier { get; set; }

        /**
         * @brief model code
         */
        public string ModelCode { get; set; }
		
		/**
         * @brief The liquidity type of the execution. Requires TWS 968+ and API v973.05+. Python API specifically requires API v973.06+.
         */
        public Liquidity LastLiquidity { get; set; }

        public Execution()
        {
            OrderId = 0;
            ClientId = 0;
            Shares = 0;
            Price = 0;
            PermId = 0;
            Liquidation = 0;
            CumQty = 0;
            AvgPrice = 0;
            EvMultiplier = 0;
        }

        public Execution(int orderId, int clientId, String execId, String time,
                          String acctNumber, String exchange, String side, double shares,
                          double price, int permId, int liquidation, double cumQty,
                          double avgPrice, String orderRef, String evRule, double evMultiplier,
                          String modelCode, Liquidity lastLiquidity)
        {
            OrderId = orderId;
            ClientId = clientId;
            ExecId = execId;
            Time = time;
            AcctNumber = acctNumber;
            Exchange = exchange;
            Side = side;
            Shares = shares;
            Price = price;
            PermId = permId;
            Liquidation = liquidation;
            CumQty = cumQty;
            AvgPrice = avgPrice;
            OrderRef = orderRef;
            EvRule = evRule;
            EvMultiplier = evMultiplier;
            ModelCode = modelCode;
            LastLiquidity = lastLiquidity;
        }

        public override bool Equals(Object p_other)
        {
            bool l_bRetVal = false;

            if (p_other == null)
            {
                l_bRetVal = false;
            }
            else if (this == p_other)
            {
                l_bRetVal = true;
            }
            else
            {
                Execution l_theOther = (Execution)p_other;
                l_bRetVal = String.Compare(ExecId, l_theOther.ExecId, true) == 0;
            }
            return l_bRetVal;
        }
    }
}
