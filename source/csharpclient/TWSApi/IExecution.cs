/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace TWSLib
{
    [ComVisible(true), Guid("58BDEC36-791C-4E2E-88A4-6E4339392B5B")]
    public interface IExecution
    {
        [DispId(1)]
        string execId { get; }
        [DispId(2)]
        int orderId { get; }
        [DispId(3)]
        int clientId { get; }
        [DispId(4)]
        int permId { get; }
        [DispId(5)]
        string time { get; }
        [DispId(6)]
        string acctNumber { get; }
        [DispId(7)]
        string exchange { get; }
        [DispId(8)]
        string side { get; }
        [DispId(9)]
        int shares { get; }
        [DispId(10)]
        double price { get; }
        [DispId(11)]
        int liquidation { get; }
        [DispId(12)]
        int cumQty { get; }
        [DispId(13)]
        double avgPrice { get; }
        [DispId(14)]
        string orderRef { get; }
        [DispId(15)]
        string evRule { get; }
        [DispId(16)]
        double evMultiplier { get; }
    }
}
