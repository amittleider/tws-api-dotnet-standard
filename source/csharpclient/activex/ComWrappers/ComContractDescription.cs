/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using IBApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections;

namespace TWSLib
{
    /**
     * @class ContractDescription
     * @brief contract data and list of derivative security types
     * @sa Contract
     */
    [ComVisible(true)]
    public class ComContractDescription : ComWrapper<ContractDescription>, IContractDescription
    {
        /**
         * @brief A contract data
         */
        ComContract Contract
        {
            get { return (ComContract)data.Contract; }
            set { if (data != null) data.Contract = (Contract)value; }
        }

        /**
         * @brief A list of derivative security types
         */
        ArrayList TWSLib.IContractDescription.DerivativeSecTypes { get { return new ArrayList(data.DerivativeSecTypes); } set { data.DerivativeSecTypes = value.OfType<string>().ToArray(); } }

        public ComContractDescription()
        {
            this.Contract = new ComContract();
        }

        public ComContractDescription(ComContract contract, string[] derivativeSecTypes)
        {
            this.Contract = contract;
            this.data.DerivativeSecTypes = derivativeSecTypes.OfType<string>().ToArray();
        }

        public static explicit operator ComContractDescription(ContractDescription cd)
        {
            return new ComContractDescription().ConvertFrom(cd) as ComContractDescription;
        }

        public static explicit operator ContractDescription(ComContractDescription ccd)
        {
            return ccd.ConvertTo();
        }

        object TWSLib.IContractDescription.contract
        {
            get { return Contract; }
        }
    }
}
