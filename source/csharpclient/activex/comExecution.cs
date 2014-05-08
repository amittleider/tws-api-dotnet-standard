/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using IBApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace TWSLib
{
    /**
     * @class Execution
     * @brief Class describing an order's execution.
     * @sa ExecutionFilter, CommissionReport
     */
    [ComVisible(true)]
    public class ComExecution : IExecution
    {
        Execution data = new Execution();

        /**
         * @brief The API client's order Id.
         */
        public int OrderId
        {
            get { return data.OrderId; }
            set { data.OrderId = value; }
        }

        /**
         * @brief The API client identifier which placed the order which originated this execution.
         */
        public int ClientId
        {
            get { return data.ClientId; }
            set { data.ClientId = value; }
        }

        /**
         * @brief The execution's identifier.
         */
        public string ExecId
        {
            get { return data.ExecId; }
            set { data.ExecId = value; }
        }

        /**
         * @brief The execution's server time.
         */
        public string Time
        {
            get { return data.Time; }
            set { data.Time = value; }
        }

        /**
         * @brief The account to which the order was allocated.
         */
        public string AcctNumber
        {
            get { return data.AcctNumber; }
            set { data.AcctNumber = value; }
        }

        /**
         * @brief The exchange where the execution took place.
         */
        public string Exchange
        {
            get { return data.Exchange; }
            set { data.Exchange = value; }
        }

        /**
         * @brief Specifies if the transaction was buy or sale
         * BOT for bought, SLD for sold
         */
        public string Side
        {
            get { return data.Side; }
            set { data.Side = value; }
        }

        /**
         * @brief The number of shares filled.
         */
        public int Shares
        {
            get { return data.Shares; }
            set { data.Shares = value; }
        }

        /**
         * @brief The order's execution price excluding commissions.
         */
        public double Price
        {
            get { return data.Price; }
            set { data.Price = value; }
        }

        /**
         * @brief The TWS order identifier.
         */
        public int PermId
        {
            get { return data.PermId; }
            set { data.PermId = value; }
        }

        /**
         * @brief Identifies the position as one to be liquidated last should the need arise.
         */
        public int Liquidation
        {
            get { return data.Liquidation; }
            set { data.Liquidation = value; }
        }

        /**
         * @brief Cumulative quantity. 
         * Used in regular trades, combo trades and legs of the combo.
         */
        public int CumQty
        {
            get { return data.CumQty; }
            set { data.CumQty = value; }
        }

        /**
         * @brief Average price. 
         * Used in regular trades, combo trades and legs of the combo. Includes commissions.
         */
        public double AvgPrice
        {
            get { return data.AvgPrice; }
            set { data.AvgPrice = value; }
        }

        /**
         * @brief Allows API client to add a reference to an order.
         */
        public string OrderRef
        {
            get { return data.OrderRef; }
            set { data.OrderRef = value; }
        }

        /**
         * @brief The Economic Value Rule name and the respective optional argument.
         * The two values should be separated by a colon. For example, aussieBond:YearsToExpiration=3. When the optional argument is not present, the first value will be followed by a colon.
         */
        public string EvRule
        {
            get { return data.EvRule; }
            set { data.EvRule = value; }
        }

        /**
         * @brief Tells you approximately how much the market value of a contract would change if the price were to change by 1.
         * It cannot be used to get market value by multiplying the price by the approximate multiplier.
         */
        public double EvMultiplier
        {
            get { return data.EvMultiplier; }
            set { data.EvMultiplier = value; }
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

        string TWSLib.IExecution.execId
        {
            get { return ExecId; }
        }

        int TWSLib.IExecution.orderId
        {
            get { return OrderId; }
        }

        int TWSLib.IExecution.clientId
        {
            get { return ClientId; }
        }

        int TWSLib.IExecution.permId
        {
            get { return PermId; }
        }

        string TWSLib.IExecution.time
        {
            get { return Time; }
        }

        string TWSLib.IExecution.acctNumber
        {
            get { return AcctNumber; }
        }

        string TWSLib.IExecution.exchange
        {
            get { return Exchange; }
        }

        string TWSLib.IExecution.side
        {
            get { return Side; }
        }

        int TWSLib.IExecution.shares
        {
            get { return Shares; }
        }

        double TWSLib.IExecution.price
        {
            get { return Price; }
        }

        int TWSLib.IExecution.liquidation
        {
            get { return Liquidation; }
        }

        int TWSLib.IExecution.cumQty
        {
            get { return CumQty; }
        }

        double TWSLib.IExecution.avgPrice
        {
            get { return AvgPrice; }
        }

        string TWSLib.IExecution.orderRef
        {
            get { return OrderRef; }
        }

        string TWSLib.IExecution.evRule
        {
            get { return EvRule; }
        }

        double TWSLib.IExecution.evMultiplier
        {
            get { return EvMultiplier; }
        }

        public static explicit operator Execution(ComExecution ce)
        {
            return ce.data;
        }

        public static explicit operator ComExecution(Execution e)
        {
            return new ComExecution() { data = e };
        }
    }
}
