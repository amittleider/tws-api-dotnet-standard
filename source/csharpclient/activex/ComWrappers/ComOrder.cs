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
         * @brief The API client's order id.
         */
        public int OrderId
        {
            get { return data != null ? data.OrderId : default(int); }
            set { if (data != null) data.OrderId = value; }
        }

        /**
         * @brief The API client id which placed the order.
         */
        public int ClientId
        {
            get { return data != null ? data.ClientId : default(int); }
            set { if (data != null) data.ClientId = value; }
        }

        /**
         * @brief The Host order identifier.
         */
        public int PermId
        {
            get { return data != null ? data.PermId : default(int); }
            set { if (data != null) data.PermId = value; }
        }

        /**
         * @brief Identifies the side.
         * Possible values are BUY, SELL, SSHORT
         */
        public string Action
        {
            get { return data != null ? data.Action : default(string); }
            set { if (data != null) data.Action = value; }
        }

        /**
         * @brief The number of positions being bought/sold.
         */
        public int TotalQuantity
        {
            get { return data != null ? data.TotalQuantity : default(int); }
            set { if (data != null) data.TotalQuantity = value; }
        }

        /**
         * @brief The order's type.
         * Available Orders are at https://www.interactivebrokers.com/en/software/api/apiguide/tables/supported_order_types.htm 
         */
        public string OrderType
        {
            get { return data != null ? data.OrderType : default(string); }
            set { if (data != null) data.OrderType = value; }
        }

        /**
         * @brief The LIMIT price.
         * Used for limit, stop-limit and relative orders. In all other cases specify zero. For relative orders with no limit price, also specify zero.
         */
        public double LmtPrice
        {
            get { return data != null ? data.LmtPrice : default(double); }
            set { if (data != null) data.LmtPrice = value; }
        }

        /**
         * @brief Generic field to contain the stop price for STP LMT orders, trailing amount, etc.
         */
        public double AuxPrice
        {
            get { return data != null ? data.AuxPrice : default(double); }
            set { if (data != null) data.AuxPrice = value; }
        }

        /**
          * @brief The time in force.
         * Valid values are: \n
         *      DAY - Valid for the day only.\n
         *      GTC - Good until canceled. The order will continue to work within the system and in the marketplace until it executes or is canceled. GTC orders will be automatically be cancelled under the following conditions:
         *          \t\t If a corporate action on a security results in a stock split (forward or reverse), exchange for shares, or distribution of shares.
         *          \t\t If you do not log into your IB account for 90 days.\n
         *          \t\t At the end of the calendar quarter following the current quarter. For example, an order placed during the third quarter of 2011 will be canceled at the end of the first quarter of 2012. If the last day is a non-trading day, the cancellation will occur at the close of the final trading day of that quarter. For example, if the last day of the quarter is Sunday, the orders will be cancelled on the preceding Friday.\n
         *          \t\t Orders that are modified will be assigned a new “Auto Expire” date consistent with the end of the calendar quarter following the current quarter.\n
         *          \t\t Orders submitted to IB that remain in force for more than one day will not be reduced for dividends. To allow adjustment to your order price on ex-dividend date, consider using a Good-Til-Date/Time (GTD) or Good-after-Time/Date (GAT) order type, or a combination of the two.\n
         *      IOC - Immediate or Cancel. Any portion that is not filled as soon as it becomes available in the market is canceled.\n
         *      GTD. - Good until Date. It will remain working within the system and in the marketplace until it executes or until the close of the market on the date specified\n
         *      OPG - Use OPG to send a market-on-open (MOO) or limit-on-open (LOO) order.\n
         *      FOK - If the entire Fill-or-Kill order does not execute as soon as it becomes available, the entire order is canceled.\n
         *      DTC - Day until Canceled \n
          */
        public string Tif
        {
            get { return data != null ? data.Tif : default(string); }
            set { if (data != null) data.Tif = value; }
        }


        /**
         * @brief One-Cancels-All group identifier.
         */
        public string OcaGroup
        {
            get { return data != null ? data.OcaGroup : default(string); }
            set { if (data != null) data.OcaGroup = value; }
        }

        /**
         * @brief Tells how to handle remaining orders in an OCA group when one order or part of an order executes.
         * Valid values are:\n
         *      \t\t 1 = Cancel all remaining orders with block.\n
         *      \t\t 2 = Remaining orders are proportionately reduced in size with block.\n
         *      \t\t 3 = Remaining orders are proportionately reduced in size with no block.\n
         * If you use a value "with block" gives your order has overfill protection. This means that only one order in the group will be routed at a time to remove the possibility of an overfill.
         */
        public int OcaType
        {
            get { return data != null ? data.OcaType : default(int); }
            set { if (data != null) data.OcaType = value; }
        }

        /**
         * @brief The order reference.
         * Intended for institutional customers only, although all customers may use it to identify the API client that sent the order when multiple API clients are running.
         */
        public string OrderRef
        {
            get { return data != null ? data.OrderRef : default(string); }
            set { if (data != null) data.OrderRef = value; }
        }

        /**
         * @brief Specifies whether the order will be transmitted by TWS. If set to false, the order will be created at TWS but will not be sent.
         */
        public bool Transmit
        {
            get { return data != null ? data.Transmit : default(bool); }
            set { if (data != null) data.Transmit = value; }
        }

        /**
         * @brief The order ID of the parent order, used for bracket and auto trailing stop orders.
         */
        public int ParentId
        {
            get { return data != null ? data.ParentId : default(int); }
            set { if (data != null) data.ParentId = value; }
        }

        /**
         * @brief If set to true, specifies that the order is an ISE Block order.
         */
        public bool BlockOrder
        {
            get { return data != null ? data.BlockOrder : default(bool); }
            set { if (data != null) data.BlockOrder = value; }
        }

        /**
         * @brief If set to true, specifies that the order is a Sweep-to-Fill order.
         */
        public bool SweepToFill
        {
            get { return data != null ? data.SweepToFill : default(bool); }
            set { if (data != null) data.SweepToFill = value; }
        }

        /**
         * @brief The publicly disclosed order size, used when placing Iceberg orders.
         */
        public int DisplaySize
        {
            get { return data != null ? data.DisplaySize : default(int); }
            set { if (data != null) data.DisplaySize = value; }
        }

        /**
         * @brief Specifies how Simulated Stop, Stop-Limit and Trailing Stop orders are triggered.
         * Valid values are:\n
         *  0 - The default value. The "double bid/ask" function will be used for orders for OTC stocks and US options. All other orders will used the "last" function.\n
         *  1 - use "double bid/ask" function, where stop orders are triggered based on two consecutive bid or ask prices.\n
         *  2 - "last" function, where stop orders are triggered based on the last price.\n
         *  3 double last function.\n
         *  4 bid/ask function.\n
         *  7 last or bid/ask function.\n
         *  8 mid-point function.\n
         */
        public int TriggerMethod
        {
            get { return data != null ? data.TriggerMethod : default(int); }
            set { if (data != null) data.TriggerMethod = value; }
        }

        /**
         * @brief If set to true, allows orders to also trigger or fill outside of regular trading hours.
         */
        public bool OutsideRth
        {
            get { return data != null ? data.OutsideRth : default(bool); }
            set { if (data != null) data.OutsideRth = value; }
        }

        /**
         * @brief If set to true, the order will not be visible when viewing the market depth. 
         * This option only applies to orders routed to the ISLAND exchange.
         */
        public bool Hidden
        {
            get { return data != null ? data.Hidden : default(bool); }
            set { if (data != null) data.Hidden = value; }
        }

        /**
         * @brief Specifies the date and time after which the order will be active.
         * Format: yyyymmdd hh:mm:ss {optional Timezone}
         */
        public string GoodAfterTime
        {
            get { return data != null ? data.GoodAfterTime : default(string); }
            set { if (data != null) data.GoodAfterTime = value; }
        }

        /**
         * @brief The date and time until the order will be active.
         * You must enter GTD as the time in force to use this string. The trade's "Good Till Date," format "YYYYMMDD hh:mm:ss (optional time zone)"
         */
        public string GoodTillDate
        {
            get { return data != null ? data.GoodTillDate : default(string); }
            set { if (data != null) data.GoodTillDate = value; }
        }

        /**
         * @brief Overrides TWS constraints.
         * Precautionary constraints are defined on the TWS Presets page, and help ensure tha tyour price and size order values are reasonable. Orders sent from the API are also validated against these safety constraints, and may be rejected if any constraint is violated. To override validation, set this parameter’s value to True.
         * 
         */
        public bool OverridePercentageConstraints
        {
            get { return data != null ? data.OverridePercentageConstraints : default(bool); }
            set { if (data != null) data.OverridePercentageConstraints = value; }
        }

        /**
         * @brief -
         * Individual = 'I'\n
         * Agency = 'A'\n
         * AgentOtherMember = 'W'\n
         * IndividualPTIA = 'J'\n
         * AgencyPTIA = 'U'\n
         * AgentOtherMemberPTIA = 'M'\n
         * IndividualPT = 'K'\n
         * AgencyPT = 'Y'\n
         * AgentOtherMemberPT = 'N'\n
         */
        public string Rule80A
        {
            get { return data != null ? data.Rule80A : default(string); }
            set { if (data != null) data.Rule80A = value; }
        }

        /**
         * @brief Indicates whether or not all the order has to be filled on a single execution.
         */
        public bool AllOrNone
        {
            get { return data != null ? data.AllOrNone : default(bool); }
            set { if (data != null) data.AllOrNone = value; }
        }

        /**
         * @brief Identifies a minimum quantity order type.
         */
        public int MinQty
        {
            get { return data != null ? data.MinQty : default(int); }
            set { if (data != null) data.MinQty = value; }
        }

        /**
         * @brief The percent offset amount for relative orders.
         */
        public double PercentOffset
        {
            get { return data != null ? data.PercentOffset : default(double); }
            set { if (data != null) data.PercentOffset = value; }
        }

        /**
         * @brief Trail stop price for TRAILIMIT orders.
         */
        public double TrailStopPrice
        {
            get { return data != null ? data.TrailStopPrice : default(double); }
            set { if (data != null) data.TrailStopPrice = value; }
        }

        /**
         * @brief Specifies the trailing amount of a trailing stop order as a percentage.
         * Observe the following guidelines when using the trailingPercent field:\n
         *    - This field is mutually exclusive with the existing trailing amount. That is, the API client can send one or the other but not both.\n
         *    - This field is read AFTER the stop price (barrier price) as follows: deltaNeutralAuxPrice stopPrice, trailingPercent, scale order attributes\n
         *    - The field will also be sent to the API in the openOrder message if the API client version is >= 56. It is sent after the stopPrice field as follows: stopPrice, trailingPct, basisPoint\n
         */
        public double TrailingPercent
        {
            get { return data != null ? data.TrailingPercent : default(double); }
            set { if (data != null) data.TrailingPercent = value; }
        }

        /**
         * @brief The Financial Advisor group the trade will be allocated to.
         * Use an empty string if not applicable.
         */
        public string FaGroup
        {
            get { return data != null ? data.FaGroup : default(string); }
            set { if (data != null) data.FaGroup = value; }
        }

        /**
         * @brief The Financial Advisor allocation profile the trade will be allocated to.
         * Use an empty string if not applicable.
         */
        public string FaProfile
        {
            get { return data != null ? data.FaProfile : default(string); }
            set { if (data != null) data.FaProfile = value; }
        }

        /**
         * @brief The Financial Advisor allocation method the trade will be allocated to.
         * Use an empty string if not applicable.
         */
        public string FaMethod
        {
            get { return data != null ? data.FaMethod : default(string); }
            set { if (data != null) data.FaMethod = value; }
        }

        /**
         * @brief The Financial Advisor percentage concerning the trade's allocation.
         * Use an empty string if not applicable.
         */
        public string FaPercentage
        {
            get { return data != null ? data.FaPercentage : default(string); }
            set { if (data != null) data.FaPercentage = value; }
        }


        /**
         * @brief For institutional customers only.
         * Available for institutional clients to determine if this order is to open or close a position. Valid values are O (open), C (close).
         */
        public string OpenClose
        {
            get { return data != null ? data.OpenClose : default(string); }
            set { if (data != null) data.OpenClose = value; }
        }


        /**
         * @brief The order's origin. 
         * Same as TWS "Origin" column. Identifies the type of customer from which the order originated. Valid values are 0 (customer), 1 (firm).
         */
        public int Origin
        {
            get { return data != null ? data.Origin : default(int); }
            set { if (data != null) data.Origin = value; }
        }

        /**
         * @brief -
         * For institutions only. Valid values are: 1 (broker holds shares) or 2 (shares come from elsewhere).
         */
        public int ShortSaleSlot
        {
            get { return data != null ? data.ShortSaleSlot : default(int); }
            set { if (data != null) data.ShortSaleSlot = value; }
        }

        /**
         * @brief Used only when shortSaleSlot is 2.
         * For institutions only. Indicates the location where the shares to short come from. Used only when short 
         * sale slot is set to 2 (which means that the shares to short are held elsewhere and not with IB).
         */
        public string DesignatedLocation
        {
            get { return data != null ? data.DesignatedLocation : default(string); }
            set { if (data != null) data.DesignatedLocation = value; }
        }

        /**
         * @brief -
         */
        public int ExemptCode
        {
            get { return data != null ? data.ExemptCode : default(int); }
            set { if (data != null) data.ExemptCode = value; }
        }

        /**
          * @brief The amount off the limit price allowed for discretionary orders.
          */
        public double DiscretionaryAmt
        {
            get { return data != null ? data.DiscretionaryAmt : default(double); }
            set { if (data != null) data.DiscretionaryAmt = value; }
        }

        /**
         * @brief Trade with electronic quotes.
         */
        public bool ETradeOnly
        {
            get { return data != null ? data.ETradeOnly : default(bool); }
            set { if (data != null) data.ETradeOnly = value; }
        }

        /**
         * @brief Trade with firm quotes.
         */
        public bool FirmQuoteOnly
        {
            get { return data != null ? data.FirmQuoteOnly : default(bool); }
            set { if (data != null) data.FirmQuoteOnly = value; }
        }

        /**
         * @brief Maximum smart order distance from the NBBO.
         */
        public double NbboPriceCap
        {
            get { return data != null ? data.NbboPriceCap : default(double); }
            set { if (data != null) data.NbboPriceCap = value; }
        }

        /**
         * @brief Use to opt out of default SmartRouting for orders routed directly to ASX.
         * This attribute defaults to false unless explicitly set to true. When set to false, orders routed directly to ASX will NOT use SmartRouting. When set to true, orders routed directly to ASX orders WILL use SmartRouting.
         */
        public bool OptOutSmartRouting
        {
            get { return data != null ? data.OptOutSmartRouting : default(bool); }
            set { if (data != null) data.OptOutSmartRouting = value; }
        }

        /**
         * @brief - 
         * For BOX orders only. Values include:
         *      1 - match \n
         *      2 - improvement \n
         *      3 - transparent \n
         */
        public int AuctionStrategy
        {
            get { return data != null ? data.AuctionStrategy : default(int); }
            set { if (data != null) data.AuctionStrategy = value; }
        }

        /**
         * @brief The auction's starting price.
         * For BOX orders only.
         */
        public double StartingPrice
        {
            get { return data != null ? data.StartingPrice : default(double); }
            set { if (data != null) data.StartingPrice = value; }
        }

        /**
         * @brief The stock's reference price.
         * The reference price is used for VOL orders to compute the limit price sent to an exchange (whether or not Continuous Update is selected), and for price range monitoring.
         */
        public double StockRefPrice
        {
            get { return data != null ? data.StockRefPrice : default(double); }
            set { if (data != null) data.StockRefPrice = value; }
        }

        /**
         * @brief The stock's Delta.
         * For orders on BOX only.
         */
        public double Delta
        {
            get { return data != null ? data.Delta : default(double); }
            set { if (data != null) data.Delta = value; }
        }

        /**
          * @brief The lower value for the acceptable underlying stock price range.
          * For price improvement option orders on BOX and VOL orders with dynamic management.
          */
        public double StockRangeLower
        {
            get { return data != null ? data.StockRangeLower : default(double); }
            set { if (data != null) data.StockRangeLower = value; }
        }

        /**
         * @brief The upper value for the acceptable underlying stock price range.
         * For price improvement option orders on BOX and VOL orders with dynamic management.
         */
        public double StockRangeUpper
        {
            get { return data != null ? data.StockRangeUpper : default(double); }
            set { if (data != null) data.StockRangeUpper = value; }
        }


        /**
         * @brief The option price in volatility, as calculated by TWS' Option Analytics.
         * This value is expressed as a percent and is used to calculate the limit price sent to the exchange.
         */
        public double Volatility
        {
            get { return data != null ? data.Volatility : default(double); }
            set { if (data != null) data.Volatility = value; }
        }

        /**
         * @brief
         * Values include:\n
         *      1 - Daily Volatility
         *      2 - Annual Volatility
         */
        public int VolatilityType
        {
            get { return data != null ? data.VolatilityType : default(int); }
            set { if (data != null) data.VolatilityType = value; }
        }

        /**
         * @brief Specifies whether TWS will automatically update the limit price of the order as the underlying price moves.
         * VOL orders only.
         */
        public int ContinuousUpdate
        {
            get { return data != null ? data.ContinuousUpdate : default(int); }
            set { if (data != null) data.ContinuousUpdate = value; }
        }

        /**
         * @brief Specifies how you want TWS to calculate the limit price for options, and for stock range price monitoring.
         * VOL orders only. Valid values include: \n
         *      1 - Average of NBBO \n
         *      2 - NBB or the NBO depending on the action and right. \n
         */
        public int ReferencePriceType
        {
            get { return data != null ? data.ReferencePriceType : default(int); }
            set { if (data != null) data.ReferencePriceType = value; }
        }

        /**
         * @brief Enter an order type to instruct TWS to submit a delta neutral trade on full or partial execution of the VOL order.
         * VOL orders only. For no hedge delta order to be sent, specify NONE.
         */
        public string DeltaNeutralOrderType
        {
            get { return data != null ? data.DeltaNeutralOrderType : default(string); }
            set { if (data != null) data.DeltaNeutralOrderType = value; }
        }

        /**
         * @brief Use this field to enter a value if the value in the deltaNeutralOrderType field is an order type that requires an Aux price, such as a REL order. 
         * VOL orders only.
         */
        public double DeltaNeutralAuxPrice
        {
            get { return data != null ? data.DeltaNeutralAuxPrice : default(double); }
            set { if (data != null) data.DeltaNeutralAuxPrice = value; }
        }

        /**
         * @brief - 
         */
        public int DeltaNeutralConId
        {
            get { return data != null ? data.DeltaNeutralConId : default(int); }
            set { if (data != null) data.DeltaNeutralConId = value; }
        }

        /**
         * @brief -
         */
        public string DeltaNeutralSettlingFirm
        {
            get { return data != null ? data.DeltaNeutralSettlingFirm : default(string); }
            set { if (data != null) data.DeltaNeutralSettlingFirm = value; }
        }

        /**
         * @brief -
         */
        public string DeltaNeutralClearingAccount
        {
            get { return data != null ? data.DeltaNeutralClearingAccount : default(string); }
            set { if (data != null) data.DeltaNeutralClearingAccount = value; }
        }

        /**
         * @brief -
         */
        public string DeltaNeutralClearingIntent
        {
            get { return data != null ? data.DeltaNeutralClearingIntent : default(string); }
            set { if (data != null) data.DeltaNeutralClearingIntent = value; }
        }

        /**
         * @brief Specifies whether the order is an Open or a Close order and is used when the hedge involves a CFD and and the order is clearing away.
         */
        public string DeltaNeutralOpenClose
        {
            get { return data != null ? data.DeltaNeutralOpenClose : default(string); }
            set { if (data != null) data.DeltaNeutralOpenClose = value; }
        }

        /**
         * @brief Used when the hedge involves a stock and indicates whether or not it is sold short.
         */
        public bool DeltaNeutralShortSale
        {
            get { return data != null ? data.DeltaNeutralShortSale : default(bool); }
            set { if (data != null) data.DeltaNeutralShortSale = value; }
        }

        /**
         * @brief -
         * Has a value of 1 (the clearing broker holds shares) or 2 (delivered from a third party). If you use 2, then you must specify a deltaNeutralDesignatedLocation.
         */
        public int DeltaNeutralShortSaleSlot
        {
            get { return data != null ? data.DeltaNeutralShortSaleSlot : default(int); }
            set { if (data != null) data.DeltaNeutralShortSaleSlot = value; }
        }

        /**
         * @brief -
         * Used only when deltaNeutralShortSaleSlot = 2.
         */
        public string DeltaNeutralDesignatedLocation
        {
            get { return data != null ? data.DeltaNeutralDesignatedLocation : default(string); }
            set { if (data != null) data.DeltaNeutralDesignatedLocation = value; }
        }

        /**
         * @brief -
         * For EFP orders only.
         */
        public double BasisPoints
        {
            get { return data != null ? data.BasisPoints : default(double); }
            set { if (data != null) data.BasisPoints = value; }
        }

        /**
         * @brief -
         * For EFP orders only.
         */
        public int BasisPointsType
        {
            get { return data != null ? data.BasisPointsType : default(int); }
            set { if (data != null) data.BasisPointsType = value; }
        }

        /**
         * @brief Defines the size of the first, or initial, order component.
         * For Scale orders only.
         */
        public int ScaleInitLevelSize
        {
            get { return data != null ? data.ScaleInitLevelSize : default(int); }
            set { if (data != null) data.ScaleInitLevelSize = value; }
        }

        /**
         * @brief Defines the order size of the subsequent scale order components.
         * For Scale orders only. Used in conjunction with scaleInitLevelSize().
         */
        public int ScaleSubsLevelSize
        {
            get { return data != null ? data.ScaleSubsLevelSize : default(int); }
            set { if (data != null) data.ScaleSubsLevelSize = value; }
        }

        /**
         * @brief Defines the price increment between scale components.
         * For Scale orders only. This value is compulsory.
         */
        public double ScalePriceIncrement
        {
            get { return data != null ? data.ScalePriceIncrement : default(double); }
            set { if (data != null) data.ScalePriceIncrement = value; }
        }

        /**
         * @brief -
         * For extended Scale orders.
         */
        public double ScalePriceAdjustValue
        {
            get { return data != null ? data.ScalePriceAdjustValue : default(double); }
            set { if (data != null) data.ScalePriceAdjustValue = value; }
        }

        /**
         * @brief -
         * For extended Scale orders.
         */
        public int ScalePriceAdjustInterval
        {
            get { return data != null ? data.ScalePriceAdjustInterval : default(int); }
            set { if (data != null) data.ScalePriceAdjustInterval = value; }
        }

        /**
         * @brief -
         * For extended scale orders.
         */
        public double ScaleProfitOffset
        {
            get { return data != null ? data.ScaleProfitOffset : default(double); }
            set { if (data != null) data.ScaleProfitOffset = value; }
        }

        /**
         * @brief -
         * For extended scale orders.
         */
        public bool ScaleAutoReset
        {
            get { return data != null ? data.ScaleAutoReset : default(bool); }
            set { if (data != null) data.ScaleAutoReset = value; }
        }

        /**
         * @brief -
         * For extended scale orders.
         */
        public int ScaleInitPosition
        {
            get { return data != null ? data.ScaleInitPosition : default(int); }
            set { if (data != null) data.ScaleInitPosition = value; }
        }

        /**
          * @brief -
          * For extended scale orders.
          */
        public int ScaleInitFillQty
        {
            get { return data != null ? data.ScaleInitFillQty : default(int); }
            set { if (data != null) data.ScaleInitFillQty = value; }
        }

        /**
         * @brief -
         * For extended scale orders.
         */
        public bool ScaleRandomPercent
        {
            get { return data != null ? data.ScaleRandomPercent : default(bool); }
            set { if (data != null) data.ScaleRandomPercent = value; }
        }

        /**
         * @brief For hedge orders.
         * Possible values include:\n
         *      D - delta \n
         *      B - beta \n
         *      F - FX \n
         *      P - Pair \n
         */
        public string HedgeType
        {
            get { return data != null ? data.HedgeType : default(string); }
            set { if (data != null) data.HedgeType = value; }
        }

        /**
         * @brief -
         * Beta = x for Beta hedge orders, ratio = y for Pair hedge order
         */
        public string HedgeParam
        {
            get { return data != null ? data.HedgeParam : default(string); }
            set { if (data != null) data.HedgeParam = value; }
        }

        /**
         * @brief The account the trade will be allocated to.
         */
        public string Account
        {
            get { return data != null ? data.Account : default(string); }
            set { if (data != null) data.Account = value; }
        }

        /**
         * @brief -
         * Institutions only. Indicates the firm which will settle the trade.
         */
        public string SettlingFirm
        {
            get { return data != null ? data.SettlingFirm : default(string); }
            set { if (data != null) data.SettlingFirm = value; }
        }

        /**
         * @brief Specifies the true beneficiary of the order.
         * For IBExecution customers. This value is required for FUT/FOP orders for reporting to the exchange.
         */
        public string ClearingAccount
        {
            get { return data != null ? data.ClearingAccount : default(string); }
            set { if (data != null) data.ClearingAccount = value; }
        }

        /**
        * @brief For exeuction-only clients to know where do they want their shares to be cleared at.
         * Valid values are: IB, Away, and PTA (post trade allocation).
        */
        public string ClearingIntent
        {
            get { return data != null ? data.ClearingIntent : default(string); }
            set { if (data != null) data.ClearingIntent = value; }
        }

        /**
         * @brief The algorithm strategy.
         * As of API verion 9.6, the following algorithms are supported:\n
         *      ArrivalPx - Arrival Price \n
         *      DarkIce - Dark Ice \n
         *      PctVol - Percentage of Volume \n
         *      Twap - TWAP (Time Weighted Average Price) \n
         *      Vwap - VWAP (Volume Weighted Average Price) \n
         * For more information about IB's API algorithms, refer to https://www.interactivebrokers.com/en/software/api/apiguide/tables/ibalgo_parameters.htm
        */
        public string AlgoStrategy
        {
            get { return data != null ? data.AlgoStrategy : default(string); }
            set { if (data != null) data.AlgoStrategy = value; }
        }

        /**
        * @brief The list of parameters for the IB algorithm.
         * For more information about IB's API algorithms, refer to https://www.interactivebrokers.com/en/software/api/apiguide/tables/ibalgo_parameters.htm
        */
        public ComList<ComTagValue, TagValue> AlgoParams
        {
            get { return data != null ? data.AlgoParams != null ? new ComList<ComTagValue, TagValue>(data.AlgoParams) : null : null; }
            set { if (data != null) data.AlgoParams = value != null ? value.ConvertTo() : null; }
        }

        /**
        * @brief Allows to retrieve the commissions and margin information.
         * When placing an order with this attribute set to true, the order will not be placed as such. Instead it will used to request the commissions and margin information that would result from this order.
        */
        public bool WhatIf
        {
            get { return data != null ? data.WhatIf : default(bool); }
            set { if (data != null) data.WhatIf = value; }
        }

        public string AlgoId { get { return data.AlgoId; } set { if (data != null) data.AlgoId = value; } }

        /**
        * @brief Orders routed to IBDARK are tagged as “post only” and are held in IB's order book, where incoming SmartRouted orders from other IB customers are eligible to trade against them.
         * For IBDARK orders only.
        */
        public bool NotHeld
        {
            get { return data != null ? data.NotHeld : default(bool); }
            set { if (data != null) data.NotHeld = value; }
        }

        /**
         * @brief Parameters for combo routing.
         * For more information, refer to https://www.interactivebrokers.com/en/software/api/apiguide/tables/smart_combo_routing.htm   
         */
        public ComList<ComTagValue, TagValue> SmartComboRoutingParams
        {
            get { return data != null ? data.SmartComboRoutingParams != null ? new ComList<ComTagValue, TagValue>(data.SmartComboRoutingParams) : null : null; }
            set { if (data != null) data.SmartComboRoutingParams = value != null ? value.ConvertTo() : null; }
        }

        /**
        * @brief The attributes for all legs within a combo order.
        */
        public ComList<ComOrderComboLeg, OrderComboLeg> OrderComboLegs
        {
            get { return data != null ? data.OrderComboLegs != null ? new ComList<ComOrderComboLeg, OrderComboLeg>(data.OrderComboLegs) : null : null; }
            set { if (data != null) data.OrderComboLegs = value != null ? value.ConvertTo() : null; }
        }

        public ComList<ComTagValue, TagValue> OrderMiscOptions
        {
            get { return data != null ? data.OrderMiscOptions != null ? new ComList<ComTagValue, TagValue>(data.OrderMiscOptions) : null : null; }
            set { if (data != null) data.OrderMiscOptions = value != null ? value.ConvertTo() : null; }
        }

        /*
         * @brief for GTC orders.
         */
        public string ActiveStartTime
        {
            get { return data != null ? data.ActiveStartTime : default(string); }
            set { if (data != null) data.ActiveStartTime = value; }
        }

        /*
        * @brief for GTC orders.
        */
        public string ActiveStopTime
        {
            get { return data != null ? data.ActiveStopTime : default(string); }
            set { if (data != null) data.ActiveStopTime = value; }
        }

        /*
         * @brief Used for scale orders.
         */
        public string ScaleTable
        {
            get { return data != null ? data.ScaleTable : default(string); }
            set { if (data != null) data.ScaleTable = value; }
        }

        public bool Solicited
        {
            get { return data.Solicited; }
            set { data.Solicited = value; }
        }

        public override bool Equals(Object p_other)
        {
            if (!(p_other is ComOrder))
                return false;

            return data.Equals((p_other as ComOrder).data);
        }


        int TWSLib.IOrder.orderId { get { return OrderId; } set { OrderId = value; } }

        int TWSLib.IOrder.clientId { get { return ClientId; } set { ClientId = value; } }

        int TWSLib.IOrder.permId { get { return PermId; } set { PermId = value; } }

        string TWSLib.IOrder.action { get { return Action; } set { Action = value; } }

        int TWSLib.IOrder.totalQuantity { get { return TotalQuantity; } set { TotalQuantity = value; } }

        string TWSLib.IOrder.orderType { get { return OrderType; } set { OrderType = value; } }

        double TWSLib.IOrder.lmtPrice { get { return LmtPrice; } set { LmtPrice = value; } }

        double TWSLib.IOrder.auxPrice { get { return AuxPrice; } set { AuxPrice = value; } }

        string TWSLib.IOrder.timeInForce { get { return Tif; } set { Tif = value; } }

        string TWSLib.IOrder.ocaGroup { get { return OcaGroup; } set { OcaGroup = value; } }

        int TWSLib.IOrder.ocaType { get { return OcaType; } set { OcaType = value; } }

        string TWSLib.IOrder.orderRef { get { return OrderRef; } set { OrderRef = value; } }

        bool TWSLib.IOrder.transmit { get { return Transmit; } set { Transmit = value; } }

        int TWSLib.IOrder.parentId { get { return ParentId; } set { ParentId = value; } }

        bool TWSLib.IOrder.blockOrder { get { return BlockOrder; } set { BlockOrder = value; } }

        bool TWSLib.IOrder.sweepToFill { get { return SweepToFill; } set { SweepToFill = value; } }

        int TWSLib.IOrder.displaySize { get { return DisplaySize; } set { DisplaySize = value; } }

        int TWSLib.IOrder.triggerMethod { get { return TriggerMethod; } set { TriggerMethod = value; } }

        bool TWSLib.IOrder.outsideRth { get { return OutsideRth; } set { OutsideRth = value; } }

        bool TWSLib.IOrder.hidden { get { return Hidden; } set { Hidden = value; } }

        string TWSLib.IOrder.goodAfterTime { get { return GoodAfterTime; } set { GoodAfterTime = value; } }

        string TWSLib.IOrder.goodTillDate { get { return GoodTillDate; } set { GoodTillDate = value; } }

        bool TWSLib.IOrder.overridePercentageConstraints { get { return OverridePercentageConstraints; } set { OverridePercentageConstraints = value; } }

        string TWSLib.IOrder.rule80A { get { return Rule80A; } set { Rule80A = value; } }

        bool TWSLib.IOrder.allOrNone { get { return AllOrNone; } set { AllOrNone = value; } }

        int TWSLib.IOrder.minQty { get { return MinQty; } set { MinQty = value; } }

        double TWSLib.IOrder.percentOffset { get { return PercentOffset; } set { PercentOffset = value; } }

        double TWSLib.IOrder.trailStopPrice { get { return TrailStopPrice; } set { TrailStopPrice = value; } }

        double TWSLib.IOrder.trailingPercent { get { return TrailingPercent; } set { TrailingPercent = value; } }

        bool TWSLib.IOrder.whatIf { get { return WhatIf; } set { WhatIf = value; } }

        string TWSLib.IOrder.algoId { get { return AlgoId; } set { AlgoId = value; } }

        bool TWSLib.IOrder.notHeld { get { return NotHeld; } set { NotHeld = value; } }

        string TWSLib.IOrder.faGroup { get { return FaGroup; } set { FaGroup = value; } }

        string TWSLib.IOrder.faProfile { get { return FaProfile; } set { FaProfile = value; } }

        string TWSLib.IOrder.faMethod { get { return FaMethod; } set { FaMethod = value; } }

        string TWSLib.IOrder.faPercentage { get { return FaPercentage; } set { FaPercentage = value; } }

        string TWSLib.IOrder.openClose { get { return OpenClose; } set { OpenClose = value; } }

        int TWSLib.IOrder.origin { get { return Origin; } set { Origin = value; } }

        int TWSLib.IOrder.shortSaleSlot { get { return ShortSaleSlot; } set { ShortSaleSlot = value; } }

        string TWSLib.IOrder.designatedLocation { get { return DesignatedLocation; } set { DesignatedLocation = value; } }

        int TWSLib.IOrder.exemptCode { get { return ExemptCode; } set { ExemptCode = value; } }

        double TWSLib.IOrder.discretionaryAmt { get { return DiscretionaryAmt; } set { DiscretionaryAmt = value; } }

        bool TWSLib.IOrder.eTradeOnly { get { return ETradeOnly; } set { ETradeOnly = value; } }

        bool TWSLib.IOrder.firmQuoteOnly { get { return FirmQuoteOnly; } set { FirmQuoteOnly = value; } }

        double TWSLib.IOrder.nbboPriceCap { get { return NbboPriceCap; } set { NbboPriceCap = value; } }

        bool TWSLib.IOrder.optOutSmartRouting { get { return OptOutSmartRouting; } set { OptOutSmartRouting = value; } }

        int TWSLib.IOrder.auctionStrategy { get { return AuctionStrategy; } set { AuctionStrategy = value; } }

        double TWSLib.IOrder.startingPrice { get { return StartingPrice; } set { StartingPrice = value; } }

        double TWSLib.IOrder.stockRefPrice { get { return StockRefPrice; } set { StockRefPrice = value; } }

        double TWSLib.IOrder.delta { get { return Delta; } set { Delta = value; } }

        double TWSLib.IOrder.stockRangeLower { get { return StockRangeLower; } set { StockRangeLower = value; } }

        double TWSLib.IOrder.stockRangeUpper { get { return StockRangeUpper; } set { StockRangeUpper = value; } }

        double TWSLib.IOrder.volatility { get { return Volatility; } set { Volatility = value; } }

        int TWSLib.IOrder.volatilityType { get { return VolatilityType; } set { VolatilityType = value; } }

        bool TWSLib.IOrder.continuousUpdate { get { return ContinuousUpdate != 0; } set { ContinuousUpdate = value ? 1 : 0; } }

        int TWSLib.IOrder.referencePriceType { get { return ReferencePriceType; } set { ReferencePriceType = value; } }

        string TWSLib.IOrder.deltaNeutralOrderType { get { return DeltaNeutralOrderType; } set { DeltaNeutralOrderType = value; } }

        double TWSLib.IOrder.deltaNeutralAuxPrice { get { return DeltaNeutralAuxPrice; } set { DeltaNeutralAuxPrice = value; } }

        int TWSLib.IOrder.deltaNeutralConId { get { return DeltaNeutralConId; } set { DeltaNeutralConId = value; } }

        string TWSLib.IOrder.deltaNeutralSettlingFirm { get { return DeltaNeutralSettlingFirm; } set { DeltaNeutralSettlingFirm = value; } }

        string TWSLib.IOrder.deltaNeutralClearingAccount { get { return DeltaNeutralClearingAccount; } set { DeltaNeutralClearingAccount = value; } }

        string TWSLib.IOrder.deltaNeutralClearingIntent { get { return DeltaNeutralClearingIntent; } set { DeltaNeutralClearingIntent = value; } }

        string TWSLib.IOrder.deltaNeutralOpenClose { get { return DeltaNeutralOpenClose; } set { DeltaNeutralOpenClose = value; } }

        bool TWSLib.IOrder.deltaNeutralShortSale { get { return DeltaNeutralShortSale; } set { DeltaNeutralShortSale = value; } }

        int TWSLib.IOrder.deltaNeutralShortSaleSlot { get { return DeltaNeutralShortSaleSlot; } set { DeltaNeutralShortSaleSlot = value; } }

        string TWSLib.IOrder.deltaNeutralDesignatedLocation { get { return DeltaNeutralDesignatedLocation; } set { DeltaNeutralDesignatedLocation = value; } }

        double TWSLib.IOrder.basisPoints { get { return BasisPoints; } set { BasisPoints = value; } }

        int TWSLib.IOrder.basisPointsType { get { return BasisPointsType; } set { BasisPointsType = value; } }

        int TWSLib.IOrder.scaleInitLevelSize { get { return ScaleInitLevelSize; } set { ScaleInitLevelSize = value; } }

        int TWSLib.IOrder.scaleSubsLevelSize { get { return ScaleSubsLevelSize; } set { ScaleSubsLevelSize = value; } }

        double TWSLib.IOrder.scalePriceIncrement { get { return ScalePriceIncrement; } set { ScalePriceIncrement = value; } }

        double TWSLib.IOrder.scalePriceAdjustValue { get { return ScalePriceAdjustValue; } set { ScalePriceAdjustValue = value; } }

        int TWSLib.IOrder.scalePriceAdjustInterval { get { return ScalePriceAdjustInterval; } set { ScalePriceAdjustInterval = value; } }

        double TWSLib.IOrder.scaleProfitOffset { get { return ScaleProfitOffset; } set { ScaleProfitOffset = value; } }

        bool TWSLib.IOrder.scaleAutoReset { get { return ScaleAutoReset; } set { ScaleAutoReset = value; } }

        int TWSLib.IOrder.scaleInitPosition { get { return ScaleInitPosition; } set { ScaleInitPosition = value; } }

        int TWSLib.IOrder.scaleInitFillQty { get { return ScaleInitFillQty; } set { ScaleInitFillQty = value; } }

        bool TWSLib.IOrder.scaleRandomPercent { get { return ScaleRandomPercent; } set { ScaleRandomPercent = value; } }

        string TWSLib.IOrder.hedgeType { get { return HedgeType; } set { HedgeType = value; } }

        string TWSLib.IOrder.hedgeParam { get { return HedgeParam; } set { HedgeParam = value; } }

        string TWSLib.IOrder.account { get { return Account; } set { Account = value; } }

        string TWSLib.IOrder.settlingFirm { get { return SettlingFirm; } set { SettlingFirm = value; } }

        string TWSLib.IOrder.clearingAccount { get { return ClearingAccount; } set { ClearingAccount = value; } }

        string TWSLib.IOrder.clearingIntent { get { return ClearingIntent; } set { ClearingIntent = value; } }

        string TWSLib.IOrder.algoStrategy { get { return AlgoStrategy; } set { AlgoStrategy = value; } }

        object TWSLib.IOrder.algoParams
        {
            get
            {
                return new TWSLib.ComTagValueList(AlgoParams);
            }

            set
            {
                AlgoParams = value != null ? (value as ComTagValueList).Tvl : new ComList<ComTagValue, TagValue>(new List<TagValue>());
            }
        }

        object TWSLib.IOrder.smartComboRoutingParams
        {
            get
            {
                return SmartComboRoutingParams != null ? new TWSLib.ComTagValueList(SmartComboRoutingParams) : null;
            }

            set
            {
                SmartComboRoutingParams = value != null ? (value as ComTagValueList).Tvl : new ComList<ComTagValue, TagValue>(new List<TagValue>());
            }
        }

        object TWSLib.IOrder.orderComboLegs
        {
            get
            {
                return OrderComboLegs != null ? new TWSLib.ComOrderComboLegList(OrderComboLegs) : null;
            }

            set
            {
                OrderComboLegs = value != null ? (value as TWSLib.ComOrderComboLegList).Ocl : null;
            }
        }

        object TWSLib.IOrder.orderMiscOptions
        {
            get
            {
                return OrderMiscOptions != null ? new TWSLib.ComTagValueList(OrderMiscOptions) : null;
            }

            set
            {
                OrderMiscOptions = value != null ? (value as ComTagValueList).Tvl : new ComList<ComTagValue, TagValue>(new List<TagValue>());
            }
        }


        string TWSLib.IOrder.activeStartTime
        {
            get
            {
                return ActiveStartTime;
            }
            set
            {
                ActiveStartTime = value;
            }
        }

        string TWSLib.IOrder.activeStopTime
        {
            get
            {
                return ActiveStopTime;
            }
            set
            {
                ActiveStopTime = value;
            }
        }

        string TWSLib.IOrder.scaleTable
        {
            get
            {
                return ScaleTable;
            }
            set
            {
                ScaleTable = value;
            }
        }

        bool TWSLib.IOrder.solicited
        {
            get
            {
                return Solicited;
            }

            set
            {
                Solicited = value;
            }
        }

        public static explicit operator ComOrder(IBApi.Order o)
        {
            return new ComOrder().ConvertFrom(o) as ComOrder;
        }

        public static explicit operator IBApi.Order(ComOrder co)
        {
            return co.ConvertTo();
        }
    }
}
