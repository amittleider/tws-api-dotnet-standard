/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using IBApi;
using System.Collections;

namespace TWSLib
{
    /**
     * @class Order
     * @brief The order's description.
     * @sa Contract, OrderComboLeg, OrderState
     */
    [ComVisible(true)]
    public class ComOrder : ComWrapper<Order>, TWSLib.IOrder
    {        
        /**
         * @brief model code
         */
        public string ModelCode
        {
            get { return data != null ? data.ModelCode : default(string); }
            set { if (data != null) data.ModelCode = value; }
        }

        public override bool Equals(Object p_other)
        {
            if (!(p_other is ComOrder))
                return false;

            return data.Equals((p_other as ComOrder).data);
        }


        int TWSLib.IOrder.orderId { get { return data.OrderId; } set { data.OrderId = value; } }

        int TWSLib.IOrder.clientId { get { return data.ClientId; } set { data.ClientId = value; } }

        int TWSLib.IOrder.permId { get { return data.PermId; } set { data.PermId = value; } }

        string TWSLib.IOrder.action { get { return data.Action; } set { data.Action = value; } }

        double TWSLib.IOrder.totalQuantity { get { return data.TotalQuantity; } set { data.TotalQuantity = value; } }

        string TWSLib.IOrder.orderType { get { return data.OrderType; } set { data.OrderType = value; } }

        double TWSLib.IOrder.lmtPrice { get { return data.LmtPrice; } set { data.LmtPrice = value; } }

        double TWSLib.IOrder.auxPrice { get { return data.AuxPrice; } set { data.AuxPrice = value; } }

        string TWSLib.IOrder.timeInForce { get { return data.Tif; } set { data.Tif = value; } }

        string TWSLib.IOrder.ocaGroup { get { return data.OcaGroup; } set { data.OcaGroup = value; } }

        int TWSLib.IOrder.ocaType { get { return data.OcaType; } set { data.OcaType = value; } }

        string TWSLib.IOrder.orderRef { get { return data.OrderRef; } set { data.OrderRef = value; } }

        bool TWSLib.IOrder.transmit { get { return data.Transmit; } set { data.Transmit = value; } }

        int TWSLib.IOrder.parentId { get { return data.ParentId; } set { data.ParentId = value; } }

        bool TWSLib.IOrder.blockOrder { get { return data.BlockOrder; } set { data.BlockOrder = value; } }

        bool TWSLib.IOrder.sweepToFill { get { return data.SweepToFill; } set { data.SweepToFill = value; } }

        int TWSLib.IOrder.displaySize { get { return data.DisplaySize; } set { data.DisplaySize = value; } }

        int TWSLib.IOrder.triggerMethod { get { return data.TriggerMethod; } set { data.TriggerMethod = value; } }

        bool TWSLib.IOrder.outsideRth { get { return data.OutsideRth; } set { data.OutsideRth = value; } }

        bool TWSLib.IOrder.hidden { get { return data.Hidden; } set { data.Hidden = value; } }

        string TWSLib.IOrder.goodAfterTime { get { return data.GoodAfterTime; } set { data.GoodAfterTime = value; } }

        string TWSLib.IOrder.goodTillDate { get { return data.GoodTillDate; } set { data.GoodTillDate = value; } }

        bool TWSLib.IOrder.overridePercentageConstraints { get { return data.OverridePercentageConstraints; } set { data.OverridePercentageConstraints = value; } }

        string TWSLib.IOrder.rule80A { get { return data.Rule80A; } set { data.Rule80A = value; } }

        bool TWSLib.IOrder.allOrNone { get { return data.AllOrNone; } set { data.AllOrNone = value; } }

        int TWSLib.IOrder.minQty { get { return data.MinQty; } set { data.MinQty = value; } }

        double TWSLib.IOrder.percentOffset { get { return data.PercentOffset; } set { data.PercentOffset = value; } }

        double TWSLib.IOrder.trailStopPrice { get { return data.TrailStopPrice; } set { data.TrailStopPrice = value; } }

        double TWSLib.IOrder.trailingPercent { get { return data.TrailingPercent; } set { data.TrailingPercent = value; } }

        bool TWSLib.IOrder.whatIf { get { return data.WhatIf; } set { data.WhatIf = value; } }

        string TWSLib.IOrder.algoId { get { return data.AlgoId; } set { data.AlgoId = value; } }

        bool TWSLib.IOrder.notHeld { get { return data.NotHeld; } set { data.NotHeld = value; } }

        string TWSLib.IOrder.faGroup { get { return data.FaGroup; } set { data.FaGroup = value; } }

        string TWSLib.IOrder.faProfile { get { return data.FaProfile; } set { data.FaProfile = value; } }

        string TWSLib.IOrder.faMethod { get { return data.FaMethod; } set { data.FaMethod = value; } }

        string TWSLib.IOrder.faPercentage { get { return data.FaPercentage; } set { data.FaPercentage = value; } }

        string TWSLib.IOrder.openClose { get { return data.OpenClose; } set { data.OpenClose = value; } }

        int TWSLib.IOrder.origin { get { return data.Origin; } set { data.Origin = value; } }

        int TWSLib.IOrder.shortSaleSlot { get { return data.ShortSaleSlot; } set { data.ShortSaleSlot = value; } }

        string TWSLib.IOrder.designatedLocation { get { return data.DesignatedLocation; } set { data.DesignatedLocation = value; } }

        int TWSLib.IOrder.exemptCode { get { return data.ExemptCode; } set { data.ExemptCode = value; } }

        double TWSLib.IOrder.discretionaryAmt { get { return data.DiscretionaryAmt; } set { data.DiscretionaryAmt = value; } }

        bool TWSLib.IOrder.eTradeOnly { get { return data.ETradeOnly; } set { data.ETradeOnly = value; } }

        bool TWSLib.IOrder.firmQuoteOnly { get { return data.FirmQuoteOnly; } set { data.FirmQuoteOnly = value; } }

        double TWSLib.IOrder.nbboPriceCap { get { return data.NbboPriceCap; } set { data.NbboPriceCap = value; } }

        bool TWSLib.IOrder.optOutSmartRouting { get { return data.OptOutSmartRouting; } set { data.OptOutSmartRouting = value; } }

        int TWSLib.IOrder.auctionStrategy { get { return data.AuctionStrategy; } set { data.AuctionStrategy = value; } }

        double TWSLib.IOrder.startingPrice { get { return data.StartingPrice; } set { data.StartingPrice = value; } }

        double TWSLib.IOrder.stockRefPrice { get { return data.StockRefPrice; } set { data.StockRefPrice = value; } }

        double TWSLib.IOrder.delta { get { return data.Delta; } set { data.Delta = value; } }

        double TWSLib.IOrder.stockRangeLower { get { return data.StockRangeLower; } set { data.StockRangeLower = value; } }

        double TWSLib.IOrder.stockRangeUpper { get { return data.StockRangeUpper; } set { data.StockRangeUpper = value; } }

        double TWSLib.IOrder.volatility { get { return data.Volatility; } set { data.Volatility = value; } }

        int TWSLib.IOrder.volatilityType { get { return data.VolatilityType; } set { data.VolatilityType = value; } }

        bool TWSLib.IOrder.continuousUpdate { get { return data.ContinuousUpdate != 0; } set { data.ContinuousUpdate = value ? 1 : 0; } }

        int TWSLib.IOrder.referencePriceType { get { return data.ReferencePriceType; } set { data.ReferencePriceType = value; } }

        string TWSLib.IOrder.deltaNeutralOrderType { get { return data.DeltaNeutralOrderType; } set { data.DeltaNeutralOrderType = value; } }

        double TWSLib.IOrder.deltaNeutralAuxPrice { get { return data.DeltaNeutralAuxPrice; } set { data.DeltaNeutralAuxPrice = value; } }

        int TWSLib.IOrder.deltaNeutralConId { get { return data.DeltaNeutralConId; } set { data.DeltaNeutralConId = value; } }

        string TWSLib.IOrder.deltaNeutralSettlingFirm { get { return data.DeltaNeutralSettlingFirm; } set { data.DeltaNeutralSettlingFirm = value; } }

        string TWSLib.IOrder.deltaNeutralClearingAccount { get { return data.DeltaNeutralClearingAccount; } set { data.DeltaNeutralClearingAccount = value; } }

        string TWSLib.IOrder.deltaNeutralClearingIntent { get { return data.DeltaNeutralClearingIntent; } set { data.DeltaNeutralClearingIntent = value; } }

        string TWSLib.IOrder.deltaNeutralOpenClose { get { return data.DeltaNeutralOpenClose; } set { data.DeltaNeutralOpenClose = value; } }

        bool TWSLib.IOrder.deltaNeutralShortSale { get { return data.DeltaNeutralShortSale; } set { data.DeltaNeutralShortSale = value; } }

        int TWSLib.IOrder.deltaNeutralShortSaleSlot { get { return data.DeltaNeutralShortSaleSlot; } set { data.DeltaNeutralShortSaleSlot = value; } }

        string TWSLib.IOrder.deltaNeutralDesignatedLocation { get { return data.DeltaNeutralDesignatedLocation; } set { data.DeltaNeutralDesignatedLocation = value; } }

        double TWSLib.IOrder.basisPoints { get { return data.BasisPoints; } set { data.BasisPoints = value; } }

        int TWSLib.IOrder.basisPointsType { get { return data.BasisPointsType; } set { data.BasisPointsType = value; } }

        int TWSLib.IOrder.scaleInitLevelSize { get { return data.ScaleInitLevelSize; } set { data.ScaleInitLevelSize = value; } }

        int TWSLib.IOrder.scaleSubsLevelSize { get { return data.ScaleSubsLevelSize; } set { data.ScaleSubsLevelSize = value; } }

        double TWSLib.IOrder.scalePriceIncrement { get { return data.ScalePriceIncrement; } set { data.ScalePriceIncrement = value; } }

        double TWSLib.IOrder.scalePriceAdjustValue { get { return data.ScalePriceAdjustValue; } set { data.ScalePriceAdjustValue = value; } }

        int TWSLib.IOrder.scalePriceAdjustInterval { get { return data.ScalePriceAdjustInterval; } set { data.ScalePriceAdjustInterval = value; } }

        double TWSLib.IOrder.scaleProfitOffset { get { return data.ScaleProfitOffset; } set { data.ScaleProfitOffset = value; } }

        bool TWSLib.IOrder.scaleAutoReset { get { return data.ScaleAutoReset; } set { data.ScaleAutoReset = value; } }

        int TWSLib.IOrder.scaleInitPosition { get { return data.ScaleInitPosition; } set { data.ScaleInitPosition = value; } }

        int TWSLib.IOrder.scaleInitFillQty { get { return data.ScaleInitFillQty; } set { data.ScaleInitFillQty = value; } }

        bool TWSLib.IOrder.scaleRandomPercent { get { return data.ScaleRandomPercent; } set { data.ScaleRandomPercent = value; } }

        string TWSLib.IOrder.hedgeType { get { return data.HedgeType; } set { data.HedgeType = value; } }

        string TWSLib.IOrder.hedgeParam { get { return data.HedgeParam; } set { data.HedgeParam = value; } }

        string TWSLib.IOrder.account { get { return data.Account; } set { data.Account = value; } }

        string TWSLib.IOrder.settlingFirm { get { return data.SettlingFirm; } set { data.SettlingFirm = value; } }

        string TWSLib.IOrder.clearingAccount { get { return data.ClearingAccount; } set { data.ClearingAccount = value; } }

        string TWSLib.IOrder.clearingIntent { get { return data.ClearingIntent; } set { data.ClearingIntent = value; } }

        string TWSLib.IOrder.algoStrategy { get { return data.AlgoStrategy; } set { data.AlgoStrategy = value; } }

        object TWSLib.IOrder.algoParams
        {
            get
            {
                return new TWSLib.ComTagValueList(new ComList<ComTagValue, TagValue>(data.AlgoParams));
            }

            set
            {
                data.AlgoParams = value != null ? (value as ComTagValueList).Tvl.ConvertTo() : new List<TagValue>();
            }
        }

        object TWSLib.IOrder.smartComboRoutingParams
        {
            get
            {
                return data.SmartComboRoutingParams != null ? new TWSLib.ComTagValueList(new ComList<ComTagValue, TagValue>(data.SmartComboRoutingParams)) : null;
            }

            set
            {
                data.SmartComboRoutingParams = value != null ? (value as ComTagValueList).Tvl.ConvertTo() : new List<TagValue>();
            }
        }

        object TWSLib.IOrder.orderComboLegs
        {
            get
            {
                return data.OrderComboLegs != null ? new TWSLib.ComOrderComboLegList(new ComList<ComOrderComboLeg,OrderComboLeg>(data.OrderComboLegs)) : null;
            }

            set
            {
                data.OrderComboLegs = value != null ? (value as TWSLib.ComOrderComboLegList).Ocl.ConvertTo() : null;
            }
        }

        object TWSLib.IOrder.orderMiscOptions
        {
            get
            {
                return data.OrderMiscOptions != null ? new TWSLib.ComTagValueList(new ComList<ComTagValue, TagValue>(data.OrderMiscOptions)) : null;
            }

            set
            {
                data.OrderMiscOptions = value != null ? (value as ComTagValueList).Tvl.ConvertTo() : new List<TagValue>();
            }
        }


        string TWSLib.IOrder.activeStartTime
        {
            get
            {
                return data.ActiveStartTime;
            }
            set
            {
                data.ActiveStartTime = value;
            }
        }

        string TWSLib.IOrder.activeStopTime
        {
            get
            {
                return data.ActiveStopTime;
            }
            set
            {
                data.ActiveStopTime = value;
            }
        }

        string TWSLib.IOrder.scaleTable
        {
            get
            {
                return data.ScaleTable;
            }
            set
            {
                data.ScaleTable = value;
            }
        }

        bool TWSLib.IOrder.solicited
        {
            get
            {
                return data.Solicited;
            }

            set
            {
                data.Solicited = value;
            }
        }

        bool TWSLib.IOrder.randomizeSize { get { return data.RandomizeSize; } set { data.RandomizeSize = value; } }
        bool TWSLib.IOrder.randomizePrice { get { return data.RandomizePrice; } set { data.RandomizePrice = value; } }

        int TWSLib.IOrder.ReferenceContractId { get { return data.ReferenceContractId; } set { data.ReferenceContractId = value; } }
        bool TWSLib.IOrder.IsPeggedChangeAmountDecrease { get { return data.IsPeggedChangeAmountDecrease; } set { data.IsPeggedChangeAmountDecrease = value; } }
        double TWSLib.IOrder.PeggedChangeAmount { get { return data.PeggedChangeAmount; } set { data.PeggedChangeAmount = value; } }
        double TWSLib.IOrder.ReferenceChangeAmount { get { return data.ReferenceChangeAmount; } set { data.ReferenceChangeAmount = value; } }
        string TWSLib.IOrder.ReferenceExchange { get { return data.ReferenceExchange; } set { data.ReferenceExchange = value; } }
        ArrayList TWSLib.IOrder.Conditions { get { return new ArrayList(data.Conditions); } set { data.Conditions = value.OfType<OrderCondition>().ToList(); } }

        string TWSLib.IOrder.adjustedOrderType { get { return data.AdjustedOrderType; } set { data.AdjustedOrderType = value; } }

        double TWSLib.IOrder.triggerPrice { get { return data.TriggerPrice; } set { data.TriggerPrice = value; } }

        double TWSLib.IOrder.lmtPriceOffset { get { return data.LmtPriceOffset; } set { data.LmtPriceOffset = value; } }

        double TWSLib.IOrder.adjustedStopPrice { get { return data.AdjustedStopPrice; } set { data.AdjustedStopPrice = value; } }

        double TWSLib.IOrder.adjustedStopLimitPrice { get { return data.AdjustedStopLimitPrice; } set { data.AdjustedStopLimitPrice = value; } }

        double TWSLib.IOrder.adjustedTrailingAmount { get { return data.AdjustedTrailingAmount; } set { data.AdjustedTrailingAmount = value; } }

        int TWSLib.IOrder.adjustableTrailingUnit { get { return data.AdjustableTrailingUnit; } set { data.AdjustableTrailingUnit = value; } }

        bool TWSLib.IOrder.conditionsIgnoreRth { get { return data.ConditionsIgnoreRth; } set { data.ConditionsIgnoreRth = value; } }

        bool TWSLib.IOrder.conditionsCancelOrder { get { return data.ConditionsCancelOrder; } set { data.ConditionsCancelOrder = value; } }
        
        public static explicit operator ComOrder(IBApi.Order o)
        {
            return new ComOrder().ConvertFrom(o) as ComOrder;
        }

        public static explicit operator IBApi.Order(ComOrder co)
        {
            return co.ConvertTo();
        }

        string TWSLib.IOrder.modelCode { get { return ModelCode; } set { ModelCode = value; } }
        string TWSLib.IOrder.extOperator { get { return data.ExtOperator; } set { data.ExtOperator = value; } }
        TWSLib.ComSoftDollarTier IOrder.tier { get { return new TWSLib.ComSoftDollarTier(data); } }
    }
}
