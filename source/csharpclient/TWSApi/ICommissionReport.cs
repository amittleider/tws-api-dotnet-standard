/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace TWSLib
{
    [ComVisible(true), Guid("51AE469F-D859-4537-A0BA-A93992F395BB")]
    public interface ICommissionReport
    {
        [DispId(1)]
        string execId { get; }
        [DispId(2)]
        double commission { get; }
        [DispId(3)]
        string currency { get; }
        [DispId(4)]
        double realizedPNL { get; }
        [DispId(5)]
        double yield { get; }
        [DispId(6)]
        int yieldRedemptionDate { get; }
    }
}
