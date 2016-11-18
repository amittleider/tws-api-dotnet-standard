/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace IBApi
{
    /**
     * @class ContractDescription
     * @brief contract data and list of derivative security types
     * @sa Contract, EClient::reqMatchingSymbols, EWrapper::symbolSamples
     */
    public class ContractDescription
    {
        private Contract contract;
        private string[] derivativeSecTypes;

         /**
         * @brief A contract data
         */
        public Contract Contract
        {
            get { return contract; }
            set { contract = value; }
        }

        /**
         * @brief A list of derivative security types
         */
        public string[] DerivativeSecTypes
        {
            get { return derivativeSecTypes; }
            set { derivativeSecTypes = value; }
        }

        public ContractDescription()
        {
            Contract = new Contract();
        }

        public ContractDescription(Contract contract, string[] derivativeSecTypes)
        {
            Contract = contract;
            DerivativeSecTypes = derivativeSecTypes;
        }

        public override string ToString()
        {
            return Contract.ToString() + " derivativeSecTypes [" + String.Join(", ", DerivativeSecTypes) + "]";
        }
    }
}
