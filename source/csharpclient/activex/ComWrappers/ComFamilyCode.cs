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
     * @class FamilyCode
     * @brief Class describing family code
     * @sa EClient::reqFamilyCodes, EWrapper::familyCodes
     */
    [ComVisible(true)]
    public class ComFamilyCode : ComWrapper<FamilyCode>, IFamilyCode
    {
        /**
         * @brief The API account Id
         */
        public string AccountID
        {
            get { return data != null ? data.AccountID : default(string); }
            set { if (data != null) data.AccountID = value; }
        }

        /**
         * @brief The API family code
         */
        public string FamilyCodeStr
        {
            get { return data != null ? data.FamilyCodeStr : default(string); }
            set { if (data != null) data.FamilyCodeStr = value; }
        }

        public ComFamilyCode()
        {
        }

        string TWSLib.IFamilyCode.accountID
        {
            get { return AccountID; }
        }

        string TWSLib.IFamilyCode.familyCodeStr
        {
            get { return FamilyCodeStr; }
        }

        public static explicit operator FamilyCode(ComFamilyCode cfc)
        {
            return cfc.ConvertTo();
        }

        public static explicit operator ComFamilyCode(FamilyCode fc)
        {
            return new ComFamilyCode().ConvertFrom(fc) as ComFamilyCode;
        }
    }
}
