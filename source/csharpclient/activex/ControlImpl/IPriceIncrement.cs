/* Copyright (C) 2017 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace TWSLib
{
    [ComVisible(true), Guid("EE277FB9-B9B9-4A15-88BA-262687C9AD77")]

    public interface IPriceIncrement
    {
        [DispId(1)]
        double lowEdge { get; }
        [DispId(2)]
        double increment { get; }
    }
}
