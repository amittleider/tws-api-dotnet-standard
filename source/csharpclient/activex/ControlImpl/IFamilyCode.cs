/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace TWSLib
{
    [ComVisible(true), Guid("2769488A-CEEC-4521-B4C5-55F361603640")]

    public interface IFamilyCode
    {
        [DispId(1)]
        string accountID { get; }
        [DispId(2)]
        string familyCodeStr { get; }
    }
}
