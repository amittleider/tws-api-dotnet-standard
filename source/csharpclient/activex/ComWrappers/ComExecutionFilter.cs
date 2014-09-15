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
    public class ComExecutionFilter : ComWrapper<ExecutionFilter>, IExecutionFilter
    {
        /**
         * @brief The API client which placed the order
         */
        public int ClientId
        {
            get { return data != null ? data.ClientId : default(int); }
            set { if (data != null) data.ClientId = value; }
        }

        /**
        * @brief The account to which the order was allocated to
        */
        public string AcctCode
        {
            get { return data != null ? data.AcctCode : default(string); }
            set { if (data != null) data.AcctCode = value; }
        }

        /**
         * @brief Time from which the executions will be brough yyyymmdd hh:mm:ss
         * Only those executions reported after the specified time will be returned.
         */
        public string Time
        {
            get { return data != null ? data.Time : default(string); }
            set { if (data != null) data.Time = value; }
        }

        /**
        * @brief The instrument's symbol
        */
        public string Symbol
        {
            get { return data != null ? data.Symbol : default(string); }
            set { if (data != null) data.Symbol = value; }
        }

        /**
         * @brief The Contract's security's type (i.e. STK, OPT...)
         */
        public string SecType
        {
            get { return data != null ? data.SecType : default(string); }
            set { if (data != null) data.SecType = value; }
        }

        /**
         * @brief The exchange at which the execution was produced
         */
        public string Exchange
        {
            get { return data != null ? data.Exchange : default(string); }
            set { if (data != null) data.Exchange = value; }
        }

        /**
        * @brief The Contract's side (Put or Call).
        */
        public string Side
        {
            get { return data != null ? data.Side : default(string); }
            set { if (data != null) data.Side = value; }
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
            return new ComExecutionFilter().ConvertFrom(ef) as ComExecutionFilter;
        }

        public static explicit operator ExecutionFilter(ComExecutionFilter cef)
        {
            return cef.ConvertTo();
        }
    }
}
