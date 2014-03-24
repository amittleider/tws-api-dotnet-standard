/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace TWSLib
{
    [ComVisible(true), Guid("3553EA07-F281-433D-B2A4-4CB722A9859B")]
    public interface IExecutionFilter
    {
        [DispId(1)]
        int clientId { get; set; }
        [DispId(2)]
        string acctCode { get; set; }
        [DispId(3)]
        string time { get; set; }
        [DispId(4)]
        string symbol { get; set; }
        [DispId(5)]
        string secType { get; set; }
        [DispId(6)]
        string exchange { get; set; }
        [DispId(7)]
        string side { get; set; }
    }
}
