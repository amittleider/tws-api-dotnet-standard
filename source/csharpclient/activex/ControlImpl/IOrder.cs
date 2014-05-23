/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace TWSLib
{
    [ComVisible(true), Guid("25D97F3D-2C4D-4080-9250-D2FB8071BE58")]
    public interface IOrder
    {
        [DispId(1)]
        int orderId { get; set; }
        [DispId(2)]
        int clientId { get; set; }
        [DispId(3)]
        int permId { get; set; }
        [DispId(4)]
        string action { get; set; }
        [DispId(5)]
        int totalQuantity { get; set; }
        [DispId(6)]
        string orderType { get; set; }
        [DispId(7)]
        double lmtPrice { get; set; }
        [DispId(8)]
        double auxPrice { get; set; }

        // extended order fields
        [DispId(20)]
        string timeInForce { get; set; }
        [DispId(140)]//!!!
        string activeStartTime { get; set; }
        [DispId(141)]//!!!
        string activeStopTime { get; set; }
        [DispId(21)]
        string ocaGroup { get; set; }
        [DispId(22)]
        int ocaType { get; set; }
        [DispId(23)]
        string orderRef { get; set; }
        [DispId(24)]
        bool transmit { [return: MarshalAs(UnmanagedType.Bool)] get; [param: MarshalAs(UnmanagedType.Bool)] set; }
        [DispId(25)]
        int parentId { get; set; }
        [DispId(26)]
        bool blockOrder { [return: MarshalAs(UnmanagedType.Bool)] get; [param: MarshalAs(UnmanagedType.Bool)] set; }
        [DispId(27)]
        bool sweepToFill { [return: MarshalAs(UnmanagedType.Bool)] get; [param: MarshalAs(UnmanagedType.Bool)] set; }
        [DispId(28)]
        int displaySize { get; set; }
        [DispId(29)]
        int triggerMethod { get; set; }
        [DispId(30)]
        bool outsideRth { [return: MarshalAs(UnmanagedType.Bool)] get; [param: MarshalAs(UnmanagedType.Bool)] set; }
        [DispId(31)]
        bool hidden { [return: MarshalAs(UnmanagedType.Bool)] get; [param: MarshalAs(UnmanagedType.Bool)] set; }
        [DispId(32)]
        string goodAfterTime { get; set; }
        [DispId(33)]
        string goodTillDate { get; set; }
        [DispId(35)]
        bool overridePercentageConstraints { [return: MarshalAs(UnmanagedType.Bool)] get; [param: MarshalAs(UnmanagedType.Bool)] set; }
        [DispId(36)]
        string rule80A { get; set; }
        [DispId(37)]
        bool allOrNone { [return: MarshalAs(UnmanagedType.Bool)] get; [param: MarshalAs(UnmanagedType.Bool)] set; }
        [DispId(38)]
        int minQty { get; set; }
        [DispId(39)]
        double percentOffset { get; set; }
        [DispId(40)]
        double trailStopPrice { get; set; }
        [DispId(44)]
        double trailingPercent { get; set; }
        [DispId(41)]
        bool whatIf { [return: MarshalAs(UnmanagedType.Bool)] get; [param: MarshalAs(UnmanagedType.Bool)] set; }
        [DispId(42)]
        bool notHeld { [return: MarshalAs(UnmanagedType.Bool)] get; [param: MarshalAs(UnmanagedType.Bool)] set; }

        // Financial advisors only
        [DispId(60)]
        string faGroup { get; set; }
        [DispId(61)]
        string faProfile { get; set; }
        [DispId(62)]
        string faMethod { get; set; }
        [DispId(63)]
        string faPercentage { get; set; }

        // Institutional orders only
        [DispId(72)]
        string openClose { get; set; }
        [DispId(73)]
        int origin { get; set; }
        [DispId(74)]
        int shortSaleSlot { get; set; }
        [DispId(75)]
        string designatedLocation { get; set; }
        [DispId(76)]
        int exemptCode { get; set; }

        // SMART routing only
        [DispId(80)]
        double discretionaryAmt { get; set; }
        [DispId(81)]
        bool eTradeOnly { [return: MarshalAs(UnmanagedType.Bool)] get; [param: MarshalAs(UnmanagedType.Bool)] set; }
        [DispId(82)]
        bool firmQuoteOnly { [return: MarshalAs(UnmanagedType.Bool)] get; [param: MarshalAs(UnmanagedType.Bool)] set; }
        [DispId(83)]
        double nbboPriceCap { get; set; }
        [DispId(84)]
        bool optOutSmartRouting { [return: MarshalAs(UnmanagedType.Bool)] get; [param: MarshalAs(UnmanagedType.Bool)] set; }

        // BOX or VOL orders only
        [DispId(90)]
        int auctionStrategy { get; set; }

        // BOX order only
        [DispId(91)]
        double startingPrice { get; set; }
        [DispId(92)]
        double stockRefPrice { get; set; }
        [DispId(93)]
        double delta { get; set; }

        // pegged to stock or VOL orders
        [DispId(94)]
        double stockRangeLower { get; set; }
        [DispId(95)]
        double stockRangeUpper { get; set; }

        // VOLATILITY orders only
        [DispId(96)]
        double volatility { get; set; }
        [DispId(97)]
        int volatilityType { get; set; }
        [DispId(98)]
        bool continuousUpdate { [return: MarshalAs(UnmanagedType.Bool)] get; [param: MarshalAs(UnmanagedType.Bool)] set; }
        [DispId(99)]
        int referencePriceType { get; set; }
        [DispId(100)]
        string deltaNeutralOrderType { get; set; }
        [DispId(101)]
        double deltaNeutralAuxPrice { get; set; }
        [DispId(123)]
        int deltaNeutralConId { get; set; }
        [DispId(124)]
        string deltaNeutralSettlingFirm { get; set; }
        [DispId(125)]
        string deltaNeutralClearingAccount { get; set; }
        [DispId(126)]
        string deltaNeutralClearingIntent { get; set; }
        [DispId(135)]
        string deltaNeutralOpenClose { get; set; }
        [DispId(136)]
        bool deltaNeutralShortSale { [return: MarshalAs(UnmanagedType.Bool)] get; [param: MarshalAs(UnmanagedType.Bool)] set; }
        [DispId(137)]
        int deltaNeutralShortSaleSlot { get; set; }
        [DispId(138)]
        string deltaNeutralDesignatedLocation { get; set; }

        // COMBO orders only
        [DispId(102)]
        double basisPoints { get; set; }
        [DispId(103)]
        int basisPointsType { get; set; }

        // SCALE orders only
        [DispId(104)]
        int scaleInitLevelSize { get; set; }
        [DispId(105)]
        int scaleSubsLevelSize { get; set; }
        [DispId(106)]
        double scalePriceIncrement { get; set; }
        [DispId(127)]
        double scalePriceAdjustValue { get; set; }
        [DispId(128)]
        int scalePriceAdjustInterval { get; set; }
        [DispId(129)]
        double scaleProfitOffset { get; set; }
        [DispId(130)]
        bool scaleAutoReset { [return: MarshalAs(UnmanagedType.Bool)] get; [param: MarshalAs(UnmanagedType.Bool)] set; }
        [DispId(131)]
        int scaleInitPosition { get; set; }
        [DispId(132)]
        int scaleInitFillQty { get; set; }
        [DispId(133)]
        bool scaleRandomPercent { [return: MarshalAs(UnmanagedType.Bool)] get; [param: MarshalAs(UnmanagedType.Bool)] set; }
        [DispId(139)]//!!
        string scaleTable { get; set; }

        // HEDGE orders only
        [DispId(107)]
        string hedgeType { get; set; }
        [DispId(108)]
        string hedgeParam { get; set; }

        // Clearing info
        [DispId(110)]
        string account { get; set; }
        [DispId(111)]
        string settlingFirm { get; set; }
        [DispId(112)]
        string clearingAccount { get; set; }
        [DispId(113)]
        string clearingIntent { get; set; }

        // ALGO orders only
        [DispId(120)]
        string algoStrategy { get; set; }
        [DispId(121)]
        object algoParams { [return: MarshalAs(UnmanagedType.IDispatch)] get; [param: MarshalAs(UnmanagedType.IDispatch)] set; }

        // Smart combo routing params
        [DispId(122)]
        object smartComboRoutingParams { [return: MarshalAs(UnmanagedType.IDispatch)] get; [param: MarshalAs(UnmanagedType.IDispatch)] set; }

        // order combo legs
        [DispId(134)]
        object orderComboLegs { [return: MarshalAs(UnmanagedType.IDispatch)] get; [param: MarshalAs(UnmanagedType.IDispatch)] set; }

        [DispId(142)]
        object orderMiscOptions { [return: MarshalAs(UnmanagedType.IDispatch)] get; [param: MarshalAs(UnmanagedType.IDispatch)] set; }
        [DispId(143)]
        string algoId { get; set; }
    }
}
