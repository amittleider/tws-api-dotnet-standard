/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace TWSLib
{
    [ComVisible(true), Guid("64F03988-ED93-452E-830B-3420DF21BAF9")]
    public interface IContractDetails
    {
        [DispId(1)]
        string marketName { get; }
        [DispId(3)]
        double minTick { get; }
        [DispId(4)]
        int priceMagnifier { get; }
        [DispId(5)]
        string orderTypes { get; }
        [DispId(6)]
        string validExchanges { get; }
        [DispId(7)]
        int underConId { get; }
        [DispId(8)]
        string longName { get; }
        [DispId(9)]
        string contractMonth { get; }
        [DispId(10)]
        string industry { get; }
        [DispId(11)]
        string category { get; }
        [DispId(12)]
        string subcategory { get; }
        [DispId(13)]
        string timeZoneId { get; }
        [DispId(14)]
        string tradingHours { get; }
        [DispId(15)]
        string liquidHours { get; }

        [DispId(16)]
        object summary { [return:MarshalAs(UnmanagedType.IDispatch)] get; }

        // CUSIP/ISIN/etc.
        [DispId(17)]
        object secIdList { [return: MarshalAs(UnmanagedType.IDispatch)] get; }

        // BOND specific properties
        [DispId(20)]
        string cusip { get; }
        [DispId(21)]
        string ratings { get; }
        [DispId(22)]
        string descAppend { get; }
        [DispId(23)]
        string bondType { get; }
        [DispId(24)]
        string couponType { get; }
        [DispId(25)]
        bool callable { get; }
        [DispId(26)]
        bool putable { get; }
        [DispId(27)]
        double coupon { get; }
        [DispId(28)]
        bool convertible { get; }
        [DispId(29)]
        string maturity { get; }
        [DispId(30)]
        string issueDate { get; }
        [DispId(31)]
        string nextOptionDate { get; }
        [DispId(32)]
        string nextOptionType { get; }
        [DispId(33)]
        bool nextOptionPartial { get; }
        [DispId(34)]
        string notes { get; }
        [DispId(35)]
        string evRule { get; }
        [DispId(36)]
        double evMultiplier { get; }
    }
}
