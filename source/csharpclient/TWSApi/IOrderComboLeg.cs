/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace IBApi.TWSApi
{
    [Guid("639C4479-D0B6-49a3-B524-AEA6A9574945"), ComVisible(true)]
    public interface IOrderComboLeg
    {
        [DispId(1)]
        double price { get; set; }
    }
}
