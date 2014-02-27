/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace TWSLib
{
    [ComVisible(true), Guid("AE6A66F3-8FA9-4076-9C1F-3728B10A4CC7")]
    public interface IContract
    {
        [DispId(1)]
        int conId { get; set; }
        [DispId(2)]
        string symbol { get; set; }
        [DispId(3)]
        string secType { get; set; }
        [DispId(4)]
        string expiry { get; set; }
        [DispId(5)]
        double strike { get; set; }
        [DispId(6)]
        string right { get; set; }
        [DispId(7)]
        string multiplier { get; set; }
        [DispId(8)]
        string exchange { get; set; }
        [DispId(9)]
        string primaryExchange { get; set; }
        [DispId(10)]
        string currency { get; set; }
        [DispId(11)]
        string localSymbol { get; set; }
        [DispId(12)]
        string tradingClass { get; set; }
        [DispId(13)]
        bool includeExpired { [return: MarshalAs(UnmanagedType.Bool)] get; [param: MarshalAs(UnmanagedType.Bool)] set; }

        [DispId(14)]
        object comboLegs { [return: MarshalAs(UnmanagedType.IDispatch)] get; [param: MarshalAs(UnmanagedType.IDispatch)] set; }

        [DispId(15)]
        object underComp { [return: MarshalAs(UnmanagedType.IDispatch)] get; [param: MarshalAs(UnmanagedType.IDispatch)] set; }

        [DispId(16)]
        string comboLegsDescrip { get; }

        [DispId(17)]
        string secIdType { get; set; }
        [DispId(18)]
        string secId { get; set; }
    }
}
