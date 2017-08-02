/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace IBApi
{
    /**
     * @class ContractDetails
     * @brief extended contract details.
     * @sa Contract
     */
    public class ContractDetails
    {
        private Contract summary;
        private string marketName;
        private double minTick;
        private int priceMagnifier;
        private string orderTypes;
        private string validExchanges;
        private int underConId;
        private string longName;
        private string contractMonth;
        private string industry;
        private string category;
        private string subcategory;
        private string timeZoneId;
        private string tradingHours;
        private string liquidHours;
        private string evRule;
        private double evMultiplier;
        private int mdSizeMultiplier;
        private int aggGroup;
        private List<TagValue> secIdList;
        private string underSymbol;
        private string underSecType;
        private string marketRuleIds;
        private string realExpirationDate;
       
        // BOND values
        private string cusip;
        private string ratings;
        private string descAppend;
        private string bondType;
        private string couponType;
        private bool callable = false;
        private bool putable = false;
        private double coupon = 0;
        private bool convertible = false;
        private string maturity;
        private string issueDate;
        private string nextOptionDate;
        private string nextOptionType;
        private bool nextOptionPartial = false;
        private string notes;

        /**
         * @brief A fully-defined Contract object.
         */
        public Contract Summary
        { 
			//! @cond
            get { return summary; }
            set { summary = value; }
			//! @endcond
        }

        /**
        * @brief The market name for this product.
        */
        public string MarketName
        {
			//! @cond
            get { return marketName; }
            set { marketName = value; }
			//! @endcond
        }

        /**
        * @brief The minimum allowed price variation.
         * Note that many securities vary their minimum tick size according to their price. This value will only show the smallest of the different minimum tick sizes regardless of the product's price. Full information about the minimum increment price structure can be obtained with the reqMarketRule function or the IB Contract and Security Search site. 
        */
        public double MinTick
        { 
            //! @cond
			get { return minTick; }
            set { minTick = value; }
			//! @endcond
        }

        /**
        * @brief Allows execution and strike prices to be reported consistently with market data, historical data and the order price, i.e. Z on LIFFE is reported in Index points and not GBP.
        */
        public int PriceMagnifier
        {
			//! @cond
            get { return priceMagnifier; }
            set { priceMagnifier = value; }
			//! @endcond
        }

        /**
        * @brief Supported order types for this product.
        */
        public string OrderTypes
        {
			//! @cond
            get { return orderTypes; }
            set { orderTypes = value; }
			//! @endcond
        }

        /**
        * @brief Valid exchange fields when placing an order for this contract.\n
		* The list of exchanges will is provided in the same order as the corresponding MarketRuleIds list.
        */
        public string ValidExchanges
        {
			//! @cond
            get { return validExchanges; }
            set { validExchanges = value; }
			//! @endcond
        }

        /**
        * @brief For derivatives, the contract ID (conID) of the underlying instrument
        */
        public int UnderConId
        {
			//! @cond
            get { return underConId; }
            set { underConId = value; }
			//! @endcond
        }

        /**
        * @brief Descriptive name of the product.
        */
        public string LongName
        {
			//! @cond
            get { return longName; }
            set { longName = value; }
			//! @endcond
        }

        /**
        * @brief Typically the contract month of the underlying for a Future contract.
        */
        public string ContractMonth
        {
			//! @cond
            get { return contractMonth; }
            set { contractMonth = value; }
			//! @endcond
        }

        /**
        * @brief The industry classification of the underlying/product. For example, Financial.
        */
        public string Industry
        {
			//! @cond
            get { return industry; }
            set { industry = value; }
			//! @endcond
        }

        /**
        * @brief The industry category of the underlying. For example, InvestmentSvc.
        */
        public string Category
        {
			//! @cond
            get { return category; }
            set { category = value; }
			//! @endcond
        }

        /**
        * @brief The industry subcategory of the underlying. For example, Brokerage.
        */
        public string Subcategory
        {
			//! @cond
            get { return subcategory; }
            set { subcategory = value; }
			//! @endcond
        }

        /**
        * @brief The time zone for the trading hours of the product. For example, EST.
        */
        public string TimeZoneId
        {
			//! @cond
            get { return timeZoneId; }
            set { timeZoneId = value; }
			//! @endcond
        }

        /**
        * @brief The trading hours of the product.
         * This value will contain the trading hours of the current day as well as the next's. For example, 20090507:0700-1830,1830-2330;20090508:CLOSED.
		 * In TWS versions 965+ there is an option in the Global Configuration API settings to return 1 month of trading hours. 
		 * The trading hours will correspond to the hours for the product on the associated exchange. The same instrument can have different hours on different exchanges.
        */
        public string TradingHours
        {
			//! @cond
            get { return tradingHours; }
            set { tradingHours = value; }
			//! @endcond
        }

        /**
        * @brief The liquid hours of the product.
        * This value will contain the liquid hours (regular trading hours) of the contract on the specified exchange. For example, 20090507:0700-1830,1830-2330;20090508:CLOSED.
        * In TWS versions 965+ there is an option in the Global Configuration API settings to return 1 month of trading hours. 
		*/
        public string LiquidHours
        {
			//! @cond
            get { return liquidHours; }
            set { liquidHours = value; }
			//! @endcond
        }

        /**
        * @brief Contains the Economic Value Rule name and the respective optional argument.
         * The two values should be separated by a colon. For example, aussieBond:YearsToExpiration=3. When the optional argument is not present, the first value will be followed by a colon.
        */
        public string EvRule
        {
			//! @cond
            get { return evRule; }
            set { evRule = value; }
			//! @endcond
        }

        /**
        * @brief Tells you approximately how much the market value of a contract would change if the price were to change by 1. 
         * It cannot be used to get market value by multiplying the price by the approximate multiplier.
        */
        public double EvMultiplier
        {
			//! @cond
            get { return evMultiplier; }
            set { evMultiplier = value; }
			//! @endcond
        }

        /**
        * @brief MD Size Multiplier. Returns the size multiplier for values returned to tickSize from a market data request. Generally 100 for US stocks and 1 for other instruments. 
        */
        public int MdSizeMultiplier
        {
			//! @cond
            get { return mdSizeMultiplier; }
            set { mdSizeMultiplier = value; }
			//! @endcond
        }

        /**
        * @brief Aggregated group
		* Indicates the smart-routing group to which a contract belongs.
		* contracts which cannot be smart-routed have aggGroup = -1
        */
        public int AggGroup
        {
			//! @cond
            get { return aggGroup; }
            set { aggGroup = value; }
			//! @endcond
        }

        /**
        * @brief A list of contract identifiers that the customer is allowed to view.
        * CUSIP/ISIN/etc. For US stocks, receiving the ISIN requires the CUSIP market data subscription.
		* For Bonds, the CUSIP or ISIN is input directly into the symbol field of the Contract class.  
        */
        public List<TagValue> SecIdList
        {
			//! @cond
            get { return secIdList; }
            set { secIdList = value; }
			//! @endcond
        }

        /**
        * @brief For derivatives, the symbol of the underlying contract. 
        */
        public string UnderSymbol
        {
			//! @cond
            get { return underSymbol; }
            set { underSymbol = value; }
			//! @endcond
		}

        /**
        * @brief For derivatives, returns the underlying security type. 
        */
        public string UnderSecType
        {
			//! @cond
            get { return underSecType; }
            set { underSecType = value; }
			//! @endcond
		}

        /**
        * @brief The list of market rule IDs separated by comma
		* Market rule IDs can be used to determine the minimum price increment at a given price. 
        */
        public string MarketRuleIds
        {
			//! @cond
            get { return marketRuleIds; }
            set { marketRuleIds = value; }
			//! @endcond
        }

        /**
        * @brief Real expiration date
        */
        public string RealExpirationDate
        {
            //! @cond
            get { return realExpirationDate; }
            set { realExpirationDate = value; }
            //! @endcond
        }

        /**
        * @brief The nine-character bond CUSIP.
         * For Bonds only. Receiving CUSIPs requires a CUSIP market data subscription.
        */
        public string Cusip
        {
			//! @cond
            get { return cusip; }
            set { cusip = value; }
			//! @endcond
        }

        /**
        * @brief Identifies the credit rating of the issuer.
		* This field is not currently available from the TWS API. 
        * For Bonds only. A higher credit rating generally indicates a less risky investment. Bond ratings are from Moody's and S&P respectively. Not currently implemented due to bond market data restrictions.
        */
        public string Ratings
        {
			//! @cond
            get { return ratings; }
            set { ratings = value; }
			//! @endcond
        }

        /**
        * @brief A description string containing further descriptive information about the bond.
         * For Bonds only.
        */
        public string DescAppend
        {
			//! @cond
            get { return descAppend; }
            set { descAppend = value; }
			//! @endcond
        }

        /**
        * @brief The type of bond, such as "CORP."
        */
        public string BondType
        {
			//! @cond
            get { return bondType; }
            set { bondType = value; }
			//! @endcond
        }

        /**
        * @brief The type of bond coupon.
		* This field is currently not available from the TWS API. 
        * For Bonds only.
        */
        public string CouponType
        {
			//! @cond
            get { return couponType; }
            set { couponType = value; }
			//! @endcond
        }

        /**
        * @brief If true, the bond can be called by the issuer under certain conditions.
		* This field is currently not available from the TWS API.
        * For Bonds only.
        */
        public bool Callable
        {
			//! @cond
            get { return callable; }
            set { callable = value; }
			//! @endcond
        }

        /**
        * @brief Values are True or False. If true, the bond can be sold back to the issuer under certain conditions.
		* This field is currently not available from the TWS API. 
        * For Bonds only.
        */
        public bool Putable
        {
			//! @cond
            get { return putable; }
            set { putable = value; }
			//! @endcond
        }

        /**
        * @brief The interest rate used to calculate the amount you will receive in interest payments over the course of the year.
        * This field is currently not available from the TWS API. 
		* For Bonds only.
        */
        public double Coupon
        {
			//! @cond
            get { return coupon; }
            set { coupon = value; }
			//! @endcond
        }

        /**
        * @brief Values are True or False. If true, the bond can be converted to stock under certain conditions.
        * This field is currently not available from the TWS API. 
		* For Bonds only.
        */
        public bool Convertible
        {
			//! @cond
            get { return convertible; }
            set { convertible = value; }
			//! @endcond
        }

        /**
        * @brief he date on which the issuer must repay the face value of the bond.
        * This field is currently not available from the TWS API. 
		* For Bonds only. Not currently implemented due to bond market data restrictions.
        */
        public string Maturity
        {
			//! @cond
            get { return maturity; }
            set { maturity = value; }
			//! @endcond
        }

        /** 
        * @brief The date the bond was issued. 
        * This field is currently not available from the TWS API. 
		* For Bonds only. Not currently implemented due to bond market data restrictions.
        */
        public string IssueDate
        {
			//! @cond
            get { return issueDate; }
            set { issueDate = value; }
			//! @endcond
        }

        /**
        * @brief Only if bond has embedded options. 
		* This field is currently not available from the TWS API. 
        * Refers to callable bonds and puttable bonds. Available in TWS description window for bonds.
        */
        public string NextOptionDate
        {
			//! @cond
            get { return nextOptionDate; }
            set { nextOptionDate = value; }
			//! @endcond
        }

        /**
        * @brief Type of embedded option.
		* This field is currently not available from the TWS API. 
        * Only if bond has embedded options.
        */
        public string NextOptionType
        {
			//! @cond
            get { return nextOptionType; }
            set { nextOptionType = value; }
			//! @endcond
        }

        /**
       * @brief Only if bond has embedded options.
	   * This field is currently not available from the TWS API. 
       * For Bonds only.
       */
        public bool NextOptionPartial
        {
			//! @cond
            get { return nextOptionPartial; }
            set { nextOptionPartial = value; }
			//! @endcond
        }

        /**
        * @brief If populated for the bond in IB's database.
         * For Bonds only.
        */
        public string Notes
        {
			//! @cond
            get { return notes; }
            set { notes = value; }
			//! @endcond
        }

        public ContractDetails()
        {
            summary = new Contract();
            minTick = 0;
            underConId = 0;
            evMultiplier = 0;
        }

        public ContractDetails(Contract summary, String marketName,
                double minTick, String orderTypes, String validExchanges, int underConId, String longName,
                String contractMonth, String industry, String category, String subcategory,
                String timeZoneId, String tradingHours, String liquidHours,
                String evRule, double evMultiplier, int aggGroup)
        {
            Summary = summary;
            MarketName = marketName;
            MinTick = minTick;
            OrderTypes = orderTypes;
            ValidExchanges = validExchanges;
            UnderConId = underConId;
            LongName = longName;
            ContractMonth = contractMonth;
            Industry = industry;
            Category = category;
            Subcategory = subcategory;
            TimeZoneId = timeZoneId;
            TradingHours = tradingHours;
            LiquidHours = liquidHours;
            EvRule = evRule;
            EvMultiplier = evMultiplier;
            AggGroup = aggGroup;
        }
    }
}
