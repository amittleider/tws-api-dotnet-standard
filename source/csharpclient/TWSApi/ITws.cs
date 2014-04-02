/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace TWSLib
{
    [ComVisible(true)]
    [Guid("0A77CCF6-052C-11D6-B0EC-00B0D074179C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface ITws
    {
        #region properties
        [DispId(1)]
        string account { get; set; }
        [DispId(2)]
        string tif { get; set; }
        [DispId(3)]
        string oca { get; set; }
        [DispId(4)]
        string orderRef { get; set; }
        [DispId(5)]
        int origin { get; set; }
        [DispId(6)]
        bool transmit { get; set; }
        [DispId(7)]
        string openClose { get; set; }
        [DispId(8)]
        int parentId { get; set; }
        [DispId(9)]
        bool blockOrder { get; set; }
        [DispId(10)]
        bool sweepToFill { get; set; }
        [DispId(11)]
        int displaySize { get; set; }
        [DispId(12)]
        int triggerMethod { get; set; }
        [DispId(13)]
        bool outsideRth { get; set; }
        [DispId(14)]
        bool hidden { get; set; }
        [DispId(16)]
        int clientIdFilter { get; set; }
        [DispId(17)]
        string acctCodeFilter { get; set; }
        [DispId(18)]
        string timeFilter { get; set; }
        [DispId(19)]
        string symbolFilter { get; set; }
        [DispId(20)]
        string secTypeFilter { get; set; }
        [DispId(21)]
        string exchangeFilter { get; set; }
        [DispId(22)]
        string sideFilter { get; set; }
        [DispId(23)]
        double discretionaryAmt { get; set; }
        [DispId(24)]
        int shortSaleSlot { get; set; }
        [DispId(25)]
        string designatedLocation { get; set; }
        [DispId(26)]
        int ocaType { get; set; }
        [DispId(27)]
        int exemptCode { get; set; }
        [DispId(28)]
        string rule80A { get; set; }
        [DispId(29)]
        string settlingFirm { get; set; }
        [DispId(30)]
        bool allOrNone { get; set; }
        [DispId(31)]
        int minQty { get; set; }
        [DispId(32)]
        double percentOffset { get; set; }
        [DispId(33)]
        bool eTradeOnly { get; set; }
        [DispId(34)]
        bool firmQuoteOnly { get; set; }
        [DispId(35)]
        double nbboPriceCap { get; set; }
        [DispId(36)]
        int auctionStrategy { get; set; }
        [DispId(37)]
        double startingPrice { get; set; }
        [DispId(38)]
        double stockRefPrice { get; set; }
        [DispId(39)]
        double delta { get; set; }
        [DispId(40)]
        double stockRangeLower { get; set; }
        [DispId(41)]
        double stockRangeUpper { get; set; }
        [DispId(42)]
        string TwsConnectionTime { get; set; }
        [DispId(43)]
        int serverVersion { get; set; }
        [DispId(44)]
        bool overridePercentageConstraints { get; set; }
        [DispId(45)]
        double volatility { get; set; }
        [DispId(46)]
        int volatilityType { get; set; }
        [DispId(47)]
        string deltaNeutralOrderType { get; set; }
        [DispId(48)]
        double deltaNeutralAuxPrice { get; set; }
        [DispId(49)]
        int continuousUpdate { get; set; }
        [DispId(50)]
        int referencePriceType { get; set; }
        [DispId(51)]
        double trailStopPrice { get; set; }
        [DispId(52)]
        int scaleInitLevelSize { get; set; }
        [DispId(53)]
        int scaleSubsLevelSize { get; set; }
        [DispId(54)]
        double scalePriceIncrement { get; set; }
        #endregion

        #region methods
        [DispId(55)]
        void cancelMktData(int id);

        [DispId(56)]
        void cancelOrder(int id);

        [DispId(57)]
        void placeOrder(int id, string action, int quantity, string symbol, string secType,
                  string expiry, double strike, string right, string multiplier,
                  string exchange, string primaryExchange, string curency, string orderType,
                  double price, double auxPrice, string goodAfterTime, string group,
                  string faMethod, string faPercentage, string faProfile, string goodTillDate);

        [DispId(58)]
        void disconnect();

        [DispId(59)]
        void connect(string host, int port, int clientId, bool extraAuth);

        [DispId(60)]
        void reqMktData(int id, string symbol, string secType, string expiry, double strike,
                  string right, string multiplier, string exchange, string primaryExchange,
                  string currency, string genericTicks, bool snapshot, ITagValueList options);

        [DispId(61)]
        void reqOpenOrders();

        [DispId(62)]
        void reqAccountUpdates(bool subscribe, string acctCode);

        [DispId(63)]
        void reqExecutions();

        [DispId(64)]
        void reqIds(int numIds);

        [DispId(65)]
        void reqMktData2(int id, string localSymbol, string secType, string exchange,
                  string primaryExchange, string currency, string genericTicks,
                  bool snapshot, ITagValueList options);

        [DispId(66)]
        void placeOrder2(int id, string action, int quantity, string localSymbol,
                  string secType, string exchange, string primaryExchange, string curency,
                  string orderType, double lmtPrice, double auxPrice,
                  string goodAfterTime, string group,
                  string faMethod, string faPercentage, string faProfile, string goodTillDate);
        [DispId(67)]
        void reqContractDetails(string symbol, string secType, string expiry, double strike,
                  string right, string multiplier, string exchange, string curency, int includeExpired);
        [DispId(68)]
        void reqContractDetails2(string localSymbol, string secType, string exchange, string curency, int includeExpired);
        [DispId(69)]
        void reqMktDepth(int id, string symbol, string secType, string expiry, double strike,
                  string right, string multiplier, string exchange, string curency, int numRows, ITagValueList options);
        [DispId(70)]
        void reqMktDepth2(int id, string localSymbol, string secType, string exchange, string curency, int numRows, ITagValueList options);
        [DispId(71)]
        void cancelMktDepth(int id);
        [DispId(72)]
        void addComboLeg(int conid, string action, int ratio, string exchange, int openClose, int shortSaleSlot, string designatedLocation, int exemptCode);
        [DispId(73)]
        void clearComboLegs();
        [DispId(74)]
        void cancelNewsBulletins();
        [DispId(75)]
        void reqNewsBulletins(bool allDaysMsgs);
        [DispId(76)]
        void setServerLogLevel(int logLevel);
        [DispId(77)]
        void reqAutoOpenOrders(bool bAutoBind);
        [DispId(78)]
        void reqAllOpenOrders();
        [DispId(79)]
        void reqManagedAccts();
        [DispId(80)]
        void requestFA(int faDataType);
        [DispId(81)]
        void replaceFA(int faDataType, string cxml);
        [DispId(82)]
        void reqHistoricalData(int id, string symbol, string secType, string expiry, double strike,
                  string right, string multiplier, string exchange, string curency, int isExpired,
                  string endDateTime, string durationStr, string barSizeSetting, string whatToShow,
                  int useRTH, int formatDate, ITagValueList options);
        [DispId(83)]
        void exerciseOptions(int id, string symbol, string secType, string expiry, double strike,
                  string right, string multiplier, string exchange, string curency,
                  int exerciseAction, int exerciseQuantity, int @override);
        [DispId(84)]
        void reqScannerParameters();
        [DispId(85)]
        void reqScannerSubscription(int tickerId, int numberOfRows, string instrument,
           string locationCode, string scanCode, double abovePrice, double belowPrice,
           int aboveVolume, double marketCapAbove, double marketCapBelow, string moodyRatingAbove,
           string moodyRatingBelow, string spRatingAbove, string spRatingBelow,
           string maturityDateAbove, string maturityDateBelow, double couponRateAbove,
           double couponRateBelow, int excludeConvertible, int averageOptionVolumeAbove,
           string scannerSettingPairs, string stockTypeFilter, ITagValueList options);
        [DispId(86)]
        void cancelHistoricalData(int tickerId);
        [DispId(87)]
        void cancelScannerSubscription(int tickerId);
        [DispId(88)]
        void resetAllProperties();
        [DispId(89)]
        void reqRealTimeBars(int tickerId, string symbol, string secType, string expiry, double strike,
           string right, string multiplier, string exchange, string primaryExchange, string currency,
           int isExpired, int barSize, string whatToShow, int useRTH, ITagValueList options);
        [DispId(90)]
        void cancelRealTimeBars(int tickerId);
        [DispId(91)]
        void reqCurrentTime();
        [DispId(92)]
        void reqFundamentalData(int reqId, IContract contract, string reportType);
        [DispId(93)]
        void cancelFundamentalData(int reqId);
        [DispId(94)]
        void calculateImpliedVolatility(int reqId, IContract contract, double optionPrice, double underPrice);
        [DispId(95)]
        void calculateOptionPrice(int reqId, IContract contract, double volatility, double underPrice);
        [DispId(96)]
        void cancelCalculateImpliedVolatility(int reqId);
        [DispId(97)]
        void cancelCalculateOptionPrice(int reqId);
        [DispId(98)]
        void reqGlobalCancel();
        [DispId(99)]
        void reqMarketDataType(int marketDataType);

        [DispId(100)]
        void reqContractDetailsEx(int reqId, IContract contract);
        [DispId(101)]
        void reqMktDataEx(int tickerId, IContract contract, string genericTicks, bool snapshot, ITagValueList options);
        [DispId(102)]
        void reqMktDepthEx(int tickerId, IContract contract, int numRows, ITagValueList options);
        [DispId(103)]
        void placeOrderEx(int orderId, IContract contract, IOrder order);
        [DispId(104)]
        void reqExecutionsEx(int reqId, IExecutionFilter filter);
        [DispId(105)]
        void exerciseOptionsEx(int tickerId, IContract contract, int exerciseAction,
           int exerciseQuantity, string account, int @override);
        [DispId(106)]
        void reqHistoricalDataEx(int tickerId, IContract contract, string endDateTime,
           string duration, string barSize, string whatToShow, bool useRTH, int formatDate, ITagValueList options);
        [DispId(107)]
        void reqRealTimeBarsEx(int tickerId, IContract contract, int barSize, string whatToShow, bool useRTH, ITagValueList options);
        [DispId(108)]
        void reqScannerSubscriptionEx(int tickerId, IScannerSubscription subscription, ITagValueList options);
        [DispId(109)]
        void addOrderComboLeg(double price);
        [DispId(110)]
        void clearOrderComboLegs();
        [DispId(111)]
        void reqPositions();
        [DispId(112)]
        void cancelPositions();
        [DispId(113)]
        void reqAccountSummary(int reqId, string groupName, string tags);
        [DispId(114)]
        void cancelAccountSummary(int reqId);
        [DispId(115)]
        void verifyRequest(string apiName, string apiVersion);
        [DispId(116)]
        void verifyMessage(string apiData);
        [DispId(117)]
        void queryDisplayGroups(int reqId);
        [DispId(118)]
        void subscribeToGroupEvents(int reqId, int groupId);
        [DispId(119)]
        void updateDisplayGroup(int reqId, string contractInfo);
        [DispId(120)]
        void unsubscribeFromGroupEvents(int reqId);
        [DispId(200)]
        IContract createContract();
        [DispId(201)]
        IComboLegList createComboLegList();
        [DispId(202)]
        IOrder createOrder();
        [DispId(203)]
        IExecutionFilter createExecutionFilter();
        [DispId(204)]
        IScannerSubscription createScannerSubscription();
        [DispId(205)]
        IUnderComp createUnderComp();
        [DispId(206)]
        ITagValueList createTagValueList();
        [DispId(207)]
        IOrderComboLegList createOrderComboLegList();
        #endregion
    }
}
