/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace IBApi.TWSApi
{
    [ComVisible(true)]
    [Guid("06FF1D3F-F12F-47D1-9443-A74D3CD58723")]
    public interface ITagValue
    {
        [DispId(1)]
        string tag { get; set; }
        [DispId(2)]
        string value { get; set; }
    }
}
