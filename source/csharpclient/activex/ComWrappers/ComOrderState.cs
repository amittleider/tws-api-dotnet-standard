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
     * @class OrderState
     * @brief Provides an active order's current state
     * @sa Order
     */
    [ComVisible(true)]
    public class ComOrderState : ComWrapper<OrderState>, IOrderState
    {
        /**
         * @brief The order's current status
         */
        public string Status
        {
            get { return data !=null ? data.Status : default(string); }
            set { if (data != null) data.Status = value; }
        }

        /**
         * @brief The order's impact on the account's initial margin.
         */
        public string InitMargin
        {
            get { return data !=null ? data.InitMargin : default(string); }
            set { if (data != null) data.InitMargin = value; }
        }

        /**
        * @brief The order's impact on the account's maintenance margin
        */
        public string MaintMargin
        {
            get { return data !=null ? data.MaintMargin : default(string); }
            set { if (data != null) data.MaintMargin = value; }
        }

        /**
        * @brief Shows the impact the order would have on the account's equity with loan
        */
        public string EquityWithLoan
        {
            get { return data !=null ? data.EquityWithLoan : default(string); }
            set { if (data != null) data.EquityWithLoan = value; }
        }

        /**
          * @brief The order's generated commission.
          */
        public double Commission
        {
            get { return data !=null ? data.Commission : default(double); }
            set { if (data != null) data.Commission = value; }
        }

        /**
        * @brief The execution's minimum commission.
        */
        public double MinCommission
        {
            get { return data !=null ? data.MinCommission : default(double); }
            set { if (data != null) data.MinCommission = value; }
        }

        /**
        * @brief The executions maximum commission.
        */
        public double MaxCommission
        {
            get { return data !=null ? data.MaxCommission : default(double); }
            set { if (data != null) data.MaxCommission = value; }
        }

        /**
         * @brief The generated commission currency
         * @sa CommissionReport
         */
        public string CommissionCurrency
        {
            get { return data !=null ? data.CommissionCurrency : default(string); }
            set { if (data != null) data.CommissionCurrency = value; }
        }

        /**
         * @brief If the order is warranted, a descriptive message will be provided.
         */
        public string WarningText
        {
            get { return data !=null ? data.WarningText : default(string); }
            set { if (data != null) data.WarningText = value; }
        }

        public override bool Equals(Object other)
        {

            if (this == other)
                return true;

            if (other == null)
                return false;

            OrderState state = (OrderState)other;

            if (Commission != state.Commission ||
                MinCommission != state.MinCommission ||
                MaxCommission != state.MaxCommission)
            {
                return false;
            }

            if (Util.StringCompare(Status, state.Status) != 0 ||
                Util.StringCompare(InitMargin, state.InitMargin) != 0 ||
                Util.StringCompare(MaintMargin, state.MaintMargin) != 0 ||
                Util.StringCompare(EquityWithLoan, state.EquityWithLoan) != 0 ||
                Util.StringCompare(CommissionCurrency, state.CommissionCurrency) != 0)
            {
                return false;
            }

            return true;
        }

        string TWSLib.IOrderState.status
        {
            get { return Status; }
        }

        string TWSLib.IOrderState.initMargin
        {
            get { return InitMargin; }
        }

        string TWSLib.IOrderState.maintMargin
        {
            get { return MaintMargin; }
        }

        string TWSLib.IOrderState.equityWithLoan
        {
            get { return EquityWithLoan; }
        }

        double TWSLib.IOrderState.commission
        {
            get { return Commission; }
        }

        double TWSLib.IOrderState.minCommission
        {
            get { return MinCommission; }
        }

        double TWSLib.IOrderState.maxCommission
        {
            get { return MaxCommission; }
        }

        string TWSLib.IOrderState.commissionCurrency
        {
            get { return CommissionCurrency; }
        }

        string TWSLib.IOrderState.warningText
        {
            get { return WarningText; }
        }

        public static explicit operator OrderState(ComOrderState cos)
        {
            return cos.ConvertTo();
        }

        public static explicit operator ComOrderState(OrderState os)
        {
            return new ComOrderState().ConvertFrom(os) as ComOrderState;
        }
    }
}
