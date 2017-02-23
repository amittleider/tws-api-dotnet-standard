/* Copyright (C) 2017 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace TWSLib
{
    [ComVisible(true), Guid("CC86C8BE-83DA-453C-9B34-5E2EDFC00CAF")]

    public interface IDepthMktDataDescription
    {
        [DispId(1)]
        string exchange { get; }
        [DispId(2)]
        string secType { get; }
        [DispId(3)]
        string listingExch { get; }
        [DispId(4)]
        string serviceDataType { get; }
        [DispId(5)]
        int aggGroup { get; }
    }
}
