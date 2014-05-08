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
     * @class ExecutionFilter
     * @brief when requesting executions, a filter can be specified to receive only a subset of them
     * @sa Contract, Execution, CommissionReport
     */
    [ComVisible(true)]
    public class ComExecutionFilter : IExecutionFilter
    {
        ExecutionFilter data = new ExecutionFilter();

        /**
         * @brief The API client which placed the order
         */
        public int ClientId
        {
            get { return data.ClientId; }
            set { data.ClientId = value; }
        }

        /**
        * @brief The account to which the order was allocated to
        */
        public string AcctCode
        {
            get { return data.AcctCode; }
            set { data.AcctCode = value; }
        }

        /**
         * @brief Time from which the executions will be brough yyyymmdd hh:mm:ss
         * Only those executions reported after the specified time will be returned.
         */
        public string Time
        {
            get { return data.Time; }
            set { data.Time = value; }
        }

        /**
        * @brief The instrument's symbol
        */
        public string Symbol
        {
            get { return data.Symbol; }
            set { data.Symbol = value; }
        }

        /**
         * @brief The Contract's security's type (i.e. STK, OPT...)
         */
        public string SecType
        {
            get { return data.SecType; }
            set { data.SecType = value; }
        }

        /**
         * @brief The exchange at which the execution was produced
         */
        public string Exchange
        {
            get { return data.Exchange; }
            set { data.Exchange = value; }
        }

        /**
        * @brief The Contract's side (Put or Call).
        */
        public string Side
        {
            get { return data.Side; }
            set { data.Side = value; }
        }

        public override bool Equals(Object other)
        {
            bool l_bRetVal = false;

            if (other == null)
            {
                l_bRetVal = false;
            }
            else if (this == other)
            {
                l_bRetVal = true;
            }
            else
            {
                ComExecutionFilter l_theOther = (ComExecutionFilter)other;
                l_bRetVal = (ClientId == l_theOther.ClientId &&
                    String.Compare(AcctCode, l_theOther.AcctCode, true) == 0 &&
                    String.Compare(Time, l_theOther.Time, true) == 0 &&
                    String.Compare(Symbol, l_theOther.Symbol, true) == 0 &&
                    String.Compare(SecType, l_theOther.SecType, true) == 0 &&
                    String.Compare(Exchange, l_theOther.Exchange, true) == 0 &&
                    String.Compare(Side, l_theOther.Side, true) == 0);
            }
            return l_bRetVal;
        }

        int TWSLib.IExecutionFilter.clientId { get { return ClientId; } set { ClientId = value; } }

        string TWSLib.IExecutionFilter.acctCode { get { return AcctCode; } set { AcctCode = value; } }

        string TWSLib.IExecutionFilter.time { get { return Time; } set { Time = value; } }

        string TWSLib.IExecutionFilter.symbol { get { return Symbol; } set { Symbol = value; } }

        string TWSLib.IExecutionFilter.secType { get { return SecType; } set { SecType = value; } }

        string TWSLib.IExecutionFilter.exchange { get { return Exchange; } set { Exchange = value; } }

        string TWSLib.IExecutionFilter.side { get { return Side; } set { Side = value; } }

        public static explicit operator ComExecutionFilter(ExecutionFilter ef)
        {
            return new ComExecutionFilter() { data = ef };
        }

        public static explicit operator ExecutionFilter(ComExecutionFilter cef)
        {
            return cef.data;
        }
    }
}
