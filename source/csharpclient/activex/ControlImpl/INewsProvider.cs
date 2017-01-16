/* Copyright (C) 2017 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace TWSLib
{
    [ComVisible(true), Guid("52CEE988-24FA-44A2-86E6-44EFA8327EFF")]

    public interface INewsProvider
    {
        [DispId(1)]
        string providerCode { get; }
        [DispId(2)]
        string providerName { get; }
    }
}
