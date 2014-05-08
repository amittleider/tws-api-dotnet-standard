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
    public class ComContractDetails : IContractDetails
    {
        ContractDetails data = new ContractDetails();

        /**
         * @brief A Contract object summarising this product.
         */
        public Contract Summary
        {
            get { return data.Summary; }
            set { data.Summary = value; }
        }

        /**
        * @brief The market name for this product.
        */
        public string MarketName
        {
            get { return data.MarketName; }
            set { data.MarketName = value; }
        }

        /**
        * @brief The minimum allowed price variation.
         * Note that many securities vary their minimum tick size according to their price. This value will only show the smallest of the different minimum tick sizes regardless of the product's price.
        */
        public double MinTick
        {
            get { return data.MinTick; }
            set { data.MinTick = value; }
        }

        /**
        * @brief Allows execution and strike prices to be reported consistently with market data, historical data and the order price, i.e. Z on LIFFE is reported in Index points and not GBP.
        */
        public int PriceMagnifier
        {
            get { return data.PriceMagnifier; }
            set { data.PriceMagnifier = value; }
        }

        /**
        * @brief Supported order types for this product.
        */
        public string OrderTypes
        {
            get { return data.OrderTypes; }
            set { data.OrderTypes = value; }
        }

        /**
        * @brief Exchanges on which this product is traded.
        */
        public string ValidExchanges
        {
            get { return data.ValidExchanges; }
            set { data.ValidExchanges = value; }
        }

        /**
        * @brief Underlying's contract Id
        */
        public int UnderConId
        {
            get { return data.UnderConId; }
            set { data.UnderConId = value; }
        }

        /**
        * @brief Descriptive name of the product.
        */
        public string LongName
        {
            get { return data.LongName; }
            set { data.LongName = value; }
        }

        /**
        * @brief Typically the contract month of the underlying for a Future contract.
        */
        public string ContractMonth
        {
            get { return data.ContractMonth; }
            set { data.ContractMonth = value; }
        }

        /**
        * @brief The industry classification of the underlying/product. For example, Financial.
        */
        public string Industry
        {
            get { return data.Industry; }
            set { data.Industry = value; }
        }

        /**
        * @brief The industry category of the underlying. For example, InvestmentSvc.
        */
        public string Category
        {
            get { return data.Category; }
            set { data.Category = value; }
        }

        /**
        * @brief The industry subcategory of the underlying. For example, Brokerage.
        */
        public string Subcategory
        {
            get { return data.Subcategory; }
            set { data.Subcategory = value; }
        }

        /**
        * @brief The ID of the time zone for the trading hours of the product. For example, EST.
        */
        public string TimeZoneId
        {
            get { return data.TimeZoneId; }
            set { data.TimeZoneId = value; }
        }

        /**
        * @brief The trading hours of the product.
         * This value will contain the trading hours of the current day as well as the next's. For example, 20090507:0700-1830,1830-2330;20090508:CLOSED.
        */
        public string TradingHours
        {
            get { return data.TradingHours; }
            set { data.TradingHours = value; }
        }

        /**
        * @brief The liquid hours of the product.
         * This value will contain the liquid hours of the current day as well as the next's. For example, 20090507:0700-1830,1830-2330;20090508:CLOSED.
        */
        public string LiquidHours
        {
            get { return data.LiquidHours; }
            set { data.LiquidHours = value; }
        }

        /**
        * @brief Contains the Economic Value Rule name and the respective optional argument.
         * The two values should be separated by a colon. For example, aussieBond:YearsToExpiration=3. When the optional argument is not present, the first value will be followed by a colon.
        */
        public string EvRule
        {
            get { return data.EvRule; }
            set { data.EvRule = value; }
        }

        /**
        * @brief Tells you approximately how much the market value of a contract would change if the price were to change by 1. 
         * It cannot be used to get market value by multiplying the price by the approximate multiplier.
        */
        public double EvMultiplier
        {
            get { return data.EvMultiplier; }
            set { data.EvMultiplier = value; }
        }

        /**
        * @brief A list of contract identifiers that the customer is allowed to view.
         * CUSIP/ISIN/etc.
        */
        public List<TagValue> SecIdList
        {
            get { return data.SecIdList; }
            set { data.SecIdList = value; }
        }

        /**
        * @brief The nine-character bond CUSIP or the 12-character SEDOL.
         * For Bonds only.
        */
        public string Cusip
        {
            get { return data.Cusip; }
            set { data.Cusip = value; }
        }

        /**
        * @brief Identifies the credit rating of the issuer.
         * For Bonds only. A higher credit rating generally indicates a less risky investment. Bond ratings are from Moody's and S&P respectively.
        */
        public string Ratings
        {
            get { return data.Ratings; }
            set { data.Ratings = value; }
        }

        /**
        * @brief A description string containing further descriptive information about the bond.
         * For Bonds only.
        */
        public string DescAppend
        {
            get { return data.DescAppend; }
            set { data.DescAppend = value; }
        }

        /**
        * @brief The type of bond, such as "CORP."
        */
        public string BondType
        {
            get { return data.BondType; }
            set { data.BondType = value; }
        }

        /**
        * @brief The type of bond coupon.
         * For Bonds only.
        */
        public string CouponType
        {
            get { return data.CouponType; }
            set { data.CouponType = value; }
        }

        /**
        * @brief If true, the bond can be called by the issuer under certain conditions.
         * For Bonds only.
        */
        public bool Callable
        {
            get { return data.Callable; }
            set { data.Callable = value; }
        }

        /**
        * @brief Values are True or False. If true, the bond can be sold back to the issuer under certain conditions.
         * For Bonds only.
        */
        public bool Putable
        {
            get { return data.Putable; }
            set { data.Putable = value; }
        }

        /**
        * @brief The interest rate used to calculate the amount you will receive in interest payments over the course of the year.
         * For Bonds only.
        */
        public double Coupon
        {
            get { return data.Coupon; }
            set { data.Coupon = value; }
        }

        /**
        * @brief Values are True or False. If true, the bond can be converted to stock under certain conditions.
         * For Bonds only.
        */
        public bool Convertible
        {
            get { return data.Convertible; }
            set { data.Convertible = value; }
        }

        /**
        * @brief he date on which the issuer must repay the face value of the bond.
         * For Bonds only.
        */
        public string Maturity
        {
            get { return data.Maturity; }
            set { data.Maturity = value; }
        }

        /** 
        * @brief The date the bond was issued. 
         * For Bonds only.
        */
        public string IssueDate
        {
            get { return data.IssueDate; }
            set { data.IssueDate = value; }
        }

        /**
        * @brief Only if bond has embedded options. 
         * Refers to callable bonds and puttable bonds. Available in TWS description window for bonds.
        */
        public string NextOptionDate
        {
            get { return data.NextOptionDate; }
            set { data.NextOptionDate = value; }
        }

        /**
        * @brief Type of embedded option.
        * Only if bond has embedded options.
        */
        public string NextOptionType
        {
            get { return data.NextOptionType; }
            set { data.NextOptionType = value; }
        }

        /**
       * @brief Only if bond has embedded options.
        * For Bonds only.
       */
        public bool NextOptionPartial
        {
            get { return data.NextOptionPartial; }
            set { data.NextOptionPartial = value; }
        }

        /**
        * @brief If populated for the bond in IB's database.
         * For Bonds only.
        */
        public string Notes
        {
            get { return data.Notes; }
            set { data.Notes = value; }
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

        public static explicit operator ComContractDetails(ContractDetails cd)
        {
            return new ComContractDetails() { data = cd };
        }

        public static explicit operator ContractDetails(ComContractDetails ccd)
        {
            return ccd.data;
        }
    }
}
