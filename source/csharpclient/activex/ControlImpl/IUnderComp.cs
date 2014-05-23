/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace TWSLib
{
    [ComVisible(true), Guid("E5EE73C4-7D45-428E-A347-821CBF918AA6")]
    public interface IUnderComp
    {
        [DispId(1)]
        int conId { get; set; }
        [DispId(2)]
        double delta { get; set; }
        [DispId(3)]
        double price { get; set; }
    }
}
