/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using IBApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace TWSLib
{
    /**
     * @class ContractDetails
     * @brief extended contract details.
     * @sa Contract
     */
    [ComVisible(true)]
    public class ComContractDetails : ComWrapper<ContractDetails>, IContractDetails
    {
        /**
         * @brief A Contract object summarising this product.
         */
        ComContract Summary
        {
            get { return (ComContract)data.Summary; }
            set { if (data != null) data.Summary = (Contract)value; }
        }

        /**
        * @brief The market name for this product.
        */
        string MarketName
        {
            get { return data != null ? data.MarketName : default(string); }
            set { if (data != null) data.MarketName = value; }
        }

        /**
        * @brief The minimum allowed price variation.
         * Note that many securities vary their minimum tick size according to their price. This value will only show the smallest of the different minimum tick sizes regardless of the product's price.
        */
        double MinTick
        {
            get { return data != null ? data.MinTick : default(double); }
            set { if (data != null) data.MinTick = value; }
        }

        /**
        * @brief Allows execution and strike prices to be reported consistently with market data, historical data and the order price, i.e. Z on LIFFE is reported in Index points and not GBP.
        */
        int PriceMagnifier
        {
            get { return data != null ? data.PriceMagnifier : default(int); }
            set { if (data != null) data.PriceMagnifier = value; }
        }

        /**
        * @brief Supported order types for this product.
        */
        string OrderTypes
        {
            get { return data != null ? data.OrderTypes : default(string); }
            set { if (data != null) data.OrderTypes = value; }
        }

        /**
        * @brief Exchanges on which this product is traded.
        */
        string ValidExchanges
        {
            get { return data != null ? data.ValidExchanges : default(string); }
            set { if (data != null) data.ValidExchanges = value; }
        }

        /**
        * @brief Underlying's contract Id
        */
        int UnderConId
        {
            get { return data != null ? data.UnderConId : default(int); }
            set { if (data != null) data.UnderConId = value; }
        }

        /**
        * @brief Descriptive name of the product.
        */
        string LongName
        {
            get { return data != null ? data.LongName : default(string); }
            set { if (data != null) data.LongName = value; }
        }

        /**
        * @brief Typically the contract month of the underlying for a Future contract.
        */
        string ContractMonth
        {
            get { return data != null ? data.ContractMonth : default(string); }
            set { if (data != null) data.ContractMonth = value; }
        }

        /**
        * @brief The industry classification of the underlying/product. For example, Financial.
        */
        string Industry
        {
            get { return data != null ? data.Industry : default(string); }
            set { if (data != null) data.Industry = value; }
        }

        /**
        * @brief The industry category of the underlying. For example, InvestmentSvc.
        */
        string Category
        {
            get { return data != null ? data.Category : default(string); }
            set { if (data != null) data.Category = value; }
        }

        /**
        * @brief The industry subcategory of the underlying. For example, Brokerage.
        */
        string Subcategory
        {
            get { return data != null ? data.Subcategory : default(string); }
            set { if (data != null) data.Subcategory = value; }
        }

        /**
        * @brief The ID of the time zone for the trading hours of the product. For example, EST.
        */
        string TimeZoneId
        {
            get { return data != null ? data.TimeZoneId : default(string); }
            set { if (data != null) data.TimeZoneId = value; }
        }

        /**
        * @brief The trading hours of the product.
         * This value will contain the trading hours of the current day as well as the next's. For example, 20090507:0700-1830,1830-2330;20090508:CLOSED.
        */
        string TradingHours
        {
            get { return data != null ? data.TradingHours : default(string); }
            set { if (data != null) data.TradingHours = value; }
        }

        /**
        * @brief The liquid hours of the product.
         * This value will contain the liquid hours of the current day as well as the next's. For example, 20090507:0700-1830,1830-2330;20090508:CLOSED.
        */
        string LiquidHours
        {
            get { return data != null ? data.LiquidHours : default(string); }
            set { if (data != null) data.LiquidHours = value; }
        }

        /**
        * @brief Contains the Economic Value Rule name and the respective optional argument.
         * The two values should be separated by a colon. For example, aussieBond:YearsToExpiration=3. When the optional argument is not present, the first value will be followed by a colon.
        */
        string EvRule
        {
            get { return data != null ? data.EvRule : default(string); }
            set { if (data != null) data.EvRule = value; }
        }

        /**
        * @brief Tells you approximately how much the market value of a contract would change if the price were to change by 1. 
         * It cannot be used to get market value by multiplying the price by the approximate multiplier.
        */
        double EvMultiplier
        {
            get { return data != null ? data.EvMultiplier : default(double); }
            set { if (data != null) data.EvMultiplier = value; }
        }

        /**
        * @brief MD Size Multiplier
        */
        int MdSizeMultiplier
        {
            get { return data != null ? data.MdSizeMultiplier : default(int); }
            set { if (data != null) data.MdSizeMultiplier = value; }
        }

        /**
        * @brief Aggregated group
        */
        int AggGroup
        {
            get { return data != null ? data.AggGroup : default(int); }
            set { if (data != null) data.AggGroup = value; }
        }

        /**
        * @brief Underlying symbol
        */
        string UnderSymbol
        {
            get { return data != null ? data.UnderSymbol : default(string); }
            set { if (data != null) data.UnderSymbol = value; }
        }

        /**
        * @brief Underlying sec type
        */
        string UnderSecType
        {
            get { return data != null ? data.UnderSecType : default(string); }
            set { if (data != null) data.UnderSecType = value; }
        }

        /**
        * @brief A list of contract identifiers that the customer is allowed to view.
         * CUSIP/ISIN/etc.
        */
        ComList<ComTagValue, TagValue> SecIdList
        {
            get { return data != null ? data.SecIdList != null ? new ComList<ComTagValue, TagValue>(data.SecIdList) : null : null; }
            set { if (data != null) data.SecIdList = value != null ? value.ConvertTo() : null; }
        }

        /**
        * @brief The nine-character bond CUSIP or the 12-character SEDOL.
         * For Bonds only.
        */
        string Cusip
        {
            get { return data != null ? data.Cusip : default(string); }
            set { if (data != null) data.Cusip = value; }
        }

        /**
        * @brief Identifies the credit rating of the issuer.
         * For Bonds only. A higher credit rating generally indicates a less risky investment. Bond ratings are from Moody's and S&P respectively.
        */
        string Ratings
        {
            get { return data != null ? data.Ratings : default(string); }
            set { if (data != null) data.Ratings = value; }
        }

        /**
        * @brief A description string containing further descriptive information about the bond.
         * For Bonds only.
        */
        string DescAppend
        {
            get { return data != null ? data.DescAppend : default(string); }
            set { if (data != null) data.DescAppend = value; }
        }

        /**
        * @brief The type of bond, such as "CORP."
        */
        string BondType
        {
            get { return data != null ? data.BondType : default(string); }
            set { if (data != null) data.BondType = value; }
        }

        /**
        * @brief The type of bond coupon.
         * For Bonds only.
        */
        string CouponType
        {
            get { return data != null ? data.CouponType : default(string); }
            set { if (data != null) data.CouponType = value; }
        }

        /**
        * @brief If true, the bond can be called by the issuer under certain conditions.
         * For Bonds only.
        */
        bool Callable
        {
            get { return data != null ? data.Callable : default(bool); }
            set { if (data != null) data.Callable = value; }
        }

        /**
        * @brief Values are True or False. If true, the bond can be sold back to the issuer under certain conditions.
         * For Bonds only.
        */
        bool Putable
        {
            get { return data != null ? data.Putable : default(bool); }
            set { if (data != null) data.Putable = value; }
        }

        /**
        * @brief The interest rate used to calculate the amount you will receive in interest payments over the course of the year.
         * For Bonds only.
        */
        double Coupon
        {
            get { return data != null ? data.Coupon : default(double); }
            set { if (data != null) data.Coupon = value; }
        }

        /**
        * @brief Values are True or False. If true, the bond can be converted to stock under certain conditions.
         * For Bonds only.
        */
        bool Convertible
        {
            get { return data != null ? data.Convertible : default(bool); }
            set { if (data != null) data.Convertible = value; }
        }

        /**
        * @brief he date on which the issuer must repay the face value of the bond.
         * For Bonds only.
        */
        string Maturity
        {
            get { return data != null ? data.Maturity : default(string); }
            set { if (data != null) data.Maturity = value; }
        }

        /** 
        * @brief The date the bond was issued. 
         * For Bonds only.
        */
        string IssueDate
        {
            get { return data != null ? data.IssueDate : default(string); }
            set { if (data != null) data.IssueDate = value; }
        }

        /**
        * @brief Only if bond has embedded options. 
         * Refers to callable bonds and puttable bonds. Available in TWS description window for bonds.
        */
        string NextOptionDate
        {
            get { return data != null ? data.NextOptionDate : default(string); }
            set { if (data != null) data.NextOptionDate = value; }
        }

        /**
        * @brief Type of embedded option.
        * Only if bond has embedded options.
        */
        string NextOptionType
        {
            get { return data != null ? data.NextOptionType : default(string); }
            set { if (data != null) data.NextOptionType = value; }
        }

        /**
       * @brief Only if bond has embedded options.
        * For Bonds only.
       */
        bool NextOptionPartial
        {
            get { return data != null ? data.NextOptionPartial : default(bool); }
            set { if (data != null) data.NextOptionPartial = value; }
        }

        /**
        * @brief If populated for the bond in IB's database.
         * For Bonds only.
        */
        string Notes
        {
            get { return data != null ? data.Notes : default(string); }
            set { if (data != null) data.Notes = value; }
        }
        
        string TWSLib.IContractDetails.marketName
        {
            get { return MarketName; }
        }

        double TWSLib.IContractDetails.minTick
        {
            get { return MinTick; }
        }

        int TWSLib.IContractDetails.priceMagnifier
        {
            get { return PriceMagnifier; }
        }

        string TWSLib.IContractDetails.orderTypes
        {
            get { return OrderTypes; }
        }

        string TWSLib.IContractDetails.validExchanges
        {
            get { return ValidExchanges; }
        }

        int TWSLib.IContractDetails.underConId
        {
            get { return UnderConId; }
        }

        string TWSLib.IContractDetails.longName
        {
            get { return LongName; }
        }

        string TWSLib.IContractDetails.contractMonth
        {
            get { return ContractMonth; }
        }

        string TWSLib.IContractDetails.industry
        {
            get { return Industry; }
        }

        string TWSLib.IContractDetails.category
        {
            get { return Category; }
        }

        string TWSLib.IContractDetails.subcategory
        {
            get { return Subcategory; }
        }

        string TWSLib.IContractDetails.timeZoneId
        {
            get { return TimeZoneId; }
        }

        string TWSLib.IContractDetails.tradingHours
        {
            get { return TradingHours; }
        }

        string TWSLib.IContractDetails.liquidHours
        {
            get { return LiquidHours; }
        }

        object TWSLib.IContractDetails.summary
        {
            get { return Summary; }
        }

        object TWSLib.IContractDetails.secIdList
        {
            get { return SecIdList; }
        }

        string TWSLib.IContractDetails.cusip
        {
            get { return Cusip; }
        }

        string TWSLib.IContractDetails.ratings
        {
            get { return Ratings; }
        }

        string TWSLib.IContractDetails.descAppend
        {
            get { return DescAppend; }
        }

        string TWSLib.IContractDetails.bondType
        {
            get { return BondType; }
        }

        string TWSLib.IContractDetails.couponType
        {
            get { return CouponType; }
        }

        bool TWSLib.IContractDetails.callable
        {
            get { return Callable; }
        }

        bool TWSLib.IContractDetails.putable
        {
            get { return Putable; }
        }

        double TWSLib.IContractDetails.coupon
        {
            get { return Coupon; }
        }

        bool TWSLib.IContractDetails.convertible
        {
            get { return Convertible; }
        }

        string TWSLib.IContractDetails.maturity
        {
            get { return Maturity; }
        }

        string TWSLib.IContractDetails.issueDate
        {
            get { return IssueDate; }
        }

        string TWSLib.IContractDetails.nextOptionDate
        {
            get { return NextOptionDate; }
        }

        string TWSLib.IContractDetails.nextOptionType
        {
            get { return NextOptionType; }
        }

        bool TWSLib.IContractDetails.nextOptionPartial
        {
            get { return NextOptionPartial; }
        }

        string TWSLib.IContractDetails.notes
        {
            get { return Notes; }
        }

        string TWSLib.IContractDetails.evRule
        {
            get { return EvRule; }
        }

        double TWSLib.IContractDetails.evMultiplier
        {
            get { return EvMultiplier; }
        }

        int TWSLib.IContractDetails.mdSizeMultiplier
        {
            get { return MdSizeMultiplier; }
        }

        int TWSLib.IContractDetails.aggGroup
        {
            get { return AggGroup; }
        }

        string TWSLib.IContractDetails.underSymbol
        {
            get { return UnderSymbol; }
        }

        string TWSLib.IContractDetails.underSecType
        {
            get { return UnderSecType; }
        }

        public static explicit operator ComContractDetails(ContractDetails cd)
        {
            return new ComContractDetails().ConvertFrom(cd) as ComContractDetails;
        }

        public static explicit operator ContractDetails(ComContractDetails ccd)
        {
            return ccd.ConvertTo();
        }
    }
}
