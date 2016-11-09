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
     * @class FamilyCode
     * @brief Class describing family code
     * @sa EClient::reqFamilyCodes, EWrapper::familyCodes
     */
    public class FamilyCode
    {
        private String accountID;
        private String familyCodeStr;

        /**
         * @brief The API account id
         */
        public string AccountID
        {
            get { return accountID; }
            set { accountID = value; }
        }

        /**
         * @brief The API family code
         */
        public string FamilyCodeStr
        {
            get { return familyCodeStr; }
            set { familyCodeStr = value; }
        }

        public FamilyCode()
        {

        }

        public FamilyCode(String accountID, String familyCodeStr)
        {
            AccountID = accountID;
            FamilyCodeStr = familyCodeStr;
        }
    }
}
