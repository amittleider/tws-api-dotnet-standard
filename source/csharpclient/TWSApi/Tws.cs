/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using IBApi;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace TWSLib
{
    [ProgId("Tws.TwsCtrl")]
    [Guid("0A77CCF8-052C-11D6-B0EC-00B0D074179C")]
    [ComVisible(true), ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(ITwsEvents))]
    public class Tws : UserControl, EWrapper, ITws, IDisposable
    {
        static T GetCustomAtribute<T>(ICustomAttributeProvider t) where T : Attribute
        {
            var cas = t.GetCustomAttributes(typeof(T), false);

            if (cas.Length < 0)
                throw new KeyNotFoundException();

            return cas[0] as T;
        }

        [ComRegisterFunction]
        public static void Register(Type t)
        {
            var clsidSubKey = Registry.ClassesRoot.OpenSubKey("CLSID", true).CreateSubKey("{" + GetCustomAtribute<GuidAttribute>(new StackFrame().GetMethod().DeclaringType).Value + "}");
            var typelibguid = "{" + GetCustomAtribute<GuidAttribute>(Assembly.GetExecutingAssembly()).Value + "}";

            clsidSubKey.CreateSubKey("Control");
            clsidSubKey.CreateSubKey("TypeLib").SetValue("", typelibguid);
            clsidSubKey.CreateSubKey("Version").SetValue("", "1.0");
        }

        EClientSocket socket;

        public Tws()
        {
            socket = new EClientSocket(this);

            resetAllProperties();
        }

        #region properties
        [DispId(1)]
        public string account { get; set; }
        [DispId(2)]
        public string tif { get; set; }
        [DispId(3)]
        public string oca { get; set; }
        [DispId(4)]
        public string orderRef { get; set; }
        [DispId(5)]
        public int origin { get; set; }
        [DispId(6)]
        public bool transmit { get; set; }
        [DispId(7)]
        public string openClose { get; set; }
        [DispId(8)]
        public int parentId { get; set; }
        [DispId(9)]
        public bool blockOrder { get; set; }
        [DispId(10)]
        public bool sweepToFill { get; set; }
        [DispId(11)]
        public int displaySize { get; set; }
        [DispId(12)]
        public int triggerMethod { get; set; }
        [DispId(13)]
        public bool outsideRth { get; set; }
        [DispId(14)]
        public bool hidden { get; set; }
        [DispId(16)]
        public int clientIdFilter { get; set; }
        [DispId(17)]
        public string acctCodeFilter { get; set; }
        [DispId(18)]
        public string timeFilter { get; set; }
        [DispId(19)]
        public string symbolFilter { get; set; }
        [DispId(20)]
        public string secTypeFilter { get; set; }
        [DispId(21)]
        public string exchangeFilter { get; set; }
        [DispId(22)]
        public string sideFilter { get; set; }
        [DispId(23)]
        public double discretionaryAmt { get; set; }
        [DispId(24)]
        public int shortSaleSlot { get; set; }
        [DispId(25)]
        public string designatedLocation { get; set; }
        [DispId(26)]
        public int ocaType { get; set; }
        [DispId(27)]
        public int exemptCode { get; set; }
        [DispId(28)]
        public string rule80A { get; set; }
        [DispId(29)]
        public string settlingFirm { get; set; }
        [DispId(30)]
        public bool allOrNone { get; set; }
        [DispId(31)]
        public int minQty { get; set; }
        [DispId(32)]
        public double percentOffset { get; set; }
        [DispId(33)]
        public bool eTradeOnly { get; set; }
        [DispId(34)]
        public bool firmQuoteOnly { get; set; }
        [DispId(35)]
        public double nbboPriceCap { get; set; }
        [DispId(36)]
        public int auctionStrategy { get; set; }
        [DispId(37)]
        public double startingPrice { get; set; }
        [DispId(38)]
        public double stockRefPrice { get; set; }
        [DispId(39)]
        public double delta { get; set; }
        [DispId(40)]
        public double stockRangeLower { get; set; }
        [DispId(41)]
        public double stockRangeUpper { get; set; }
        [DispId(42)]
        public string TwsConnectionTime { get; set; }
        [DispId(43)]
        public int serverVersion { get; set; }
        [DispId(44)]
        public bool overridePercentageConstraints { get; set; }
        [DispId(45)]
        public double volatility { get; set; }
        [DispId(46)]
        public int volatilityType { get; set; }
        [DispId(47)]
        public string deltaNeutralOrderType { get; set; }
        [DispId(48)]
        public double deltaNeutralAuxPrice { get; set; }
        [DispId(49)]
        public int continuousUpdate { get; set; }
        [DispId(50)]
        public int referencePriceType { get; set; }
        [DispId(51)]
        public double trailStopPrice { get; set; }
        [DispId(52)]
        public int scaleInitLevelSize { get; set; }
        [DispId(53)]
        public int scaleSubsLevelSize { get; set; }
        [DispId(54)]
        public double scalePriceIncrement { get; set; }
        #endregion

        #region methods
        [DispId(55)]
        public void cancelMktData(int id)
        {
            socket.cancelMktData(id);
        }

        [DispId(56)]
        public void cancelOrder(int id)
        {
            socket.cancelOrder(id);
        }

        [DispId(57)]
        public void placeOrder(int id, string action, int quantity, string localSymbol, string secType,
                   string expiry, double strike, string right, string multiplier,
                   string exchange, string primaryExchange, string curency, string orderType,
                   double lmtPrice, double auxPrice, string goodAfterTime, string faGroup,
                   string faMethod, string faPercentage, string faProfile, string goodTillDate)
        {
            var order = new Order()
            {
                Action = action,
                TotalQuantity = quantity,
                OrderType = orderType,
                LmtPrice = lmtPrice,
                AuxPrice = auxPrice,
                FaGroup = faGroup,
                FaProfile = faProfile,
                FaMethod = faMethod,
                FaPercentage = faPercentage,
                GoodAfterTime = goodAfterTime,
                GoodTillDate = goodTillDate
            };

            socket.placeOrder(id, new Contract()
            {
                LocalSymbol = localSymbol,
                SecType = secType,
                Exchange = exchange,
                PrimaryExch = primaryExchange,
                Currency = curency,
                ComboLegs = this.comboLegs
            }, order);


            setExtendedOrderAttributes(order);
        }

        void setExtendedOrderAttributes(Order order)
        {
            order.Tif = this.tif;
            order.OcaGroup = this.oca;
            order.Account = this.account;
            order.OpenClose = this.openClose;
            order.Origin = this.origin;
            order.OrderRef = this.orderRef;
            order.Transmit = this.transmit;
            order.ParentId = this.parentId;
            order.BlockOrder = this.blockOrder;
            order.SweepToFill = this.sweepToFill;
            order.DisplaySize = this.displaySize;
            order.TriggerMethod = this.triggerMethod;
            order.OutsideRth = this.outsideRth;
            order.Hidden = this.hidden;
            order.DiscretionaryAmt = this.discretionaryAmt;
            order.ShortSaleSlot = this.shortSaleSlot;
            order.DesignatedLocation = this.designatedLocation;
            order.ExemptCode = this.exemptCode;
            order.OcaType = this.ocaType;
            order.Rule80A = this.rule80A;
            order.SettlingFirm = this.settlingFirm;
            order.AllOrNone = this.allOrNone;
            order.MinQty = this.minQty;
            order.PercentOffset = this.percentOffset;
            order.ETradeOnly = this.eTradeOnly;
            order.FirmQuoteOnly = this.firmQuoteOnly;
            order.NbboPriceCap = this.nbboPriceCap;
            order.AuctionStrategy = this.auctionStrategy;
            order.StartingPrice = this.startingPrice;
            order.StockRefPrice = this.stockRefPrice;
            order.Delta = this.delta;
            order.StockRangeLower = this.stockRangeLower;
            order.StockRangeUpper = this.stockRangeUpper;
            order.OverridePercentageConstraints = this.overridePercentageConstraints;
            // VOLATILITY ORDERS ONLY
            order.Volatility = this.volatility;
            order.VolatilityType = this.volatilityType;     // 1=daily, 2=annual
            order.DeltaNeutralOrderType = this.deltaNeutralOrderType;
            order.DeltaNeutralAuxPrice = this.deltaNeutralAuxPrice;
            order.ContinuousUpdate = this.continuousUpdate;
            order.ReferencePriceType = this.referencePriceType; // 1=Average, 2 = BidOrAsk
            order.TrailStopPrice = this.trailStopPrice;
            order.ScaleInitLevelSize = this.scaleInitLevelSize;
            order.ScaleSubsLevelSize = this.scaleSubsLevelSize;
            order.ScalePriceIncrement = this.scalePriceIncrement;
        }

        [DispId(58)]
        public void disconnect()
        {
            this.socket.eDisconnect();
        }

        [DispId(59)]
        public void connect(string host, int port, int clientId, bool extraAuth)
        {
            this.socket.eConnect(host, port, clientId, extraAuth);
        }

        [DispId(60)]
        public void reqMktData(int id, string symbol, string secType, string expiry, double strike,
                   string right, string multiplier, string exchange, string primaryExchange,
                   string currency, string genericTicks, bool snapshot, ITagValueList options)
        {
            // set contract fields
            Contract contract = new Contract();

            contract.Symbol = symbol;
            contract.SecType = secType;
            contract.Expiry = expiry;
            contract.Strike = strike;
            contract.Right = right;
            contract.Multiplier = multiplier;
            contract.Exchange = exchange;
            contract.PrimaryExch = primaryExchange;
            contract.Currency = currency;

            // add the combo order legs, if any
            contract.ComboLegs = this.comboLegs;

            // request market data
            this.socket.reqMktData(id, contract, genericTicks, snapshot, ITagValueListToListTagValue(options));
        }

        [DispId(61)]
        public void reqOpenOrders()
        {
            this.socket.reqOpenOrders();
        }

        [DispId(62)]
        public void reqAccountUpdates(bool subscribe, string acctCode)
        {
            this.socket.reqAccountUpdates(subscribe, acctCode);
        }

        [DispId(63)]
        public void reqExecutions()
        {
            ExecutionFilter filter = new ExecutionFilter();

            filter.ClientId = this.clientIdFilter;
            filter.AcctCode = this.acctCodeFilter;
            filter.Time = this.timeFilter;
            filter.Symbol = this.symbolFilter;
            filter.SecType = this.secTypeFilter;
            filter.Exchange = this.exchangeFilter;
            filter.Side = this.sideFilter;

            this.socket.reqExecutions(-1, filter);
        }

        [DispId(64)]
        public void reqIds(int numIds)
        {
            this.socket.reqIds(numIds);
        }

        [DispId(65)]
        public void reqMktData2(int id, string localSymbol, string secType, string exchange,
                   string primaryExchange, string currency, string genericTicks,
                   bool snapshot, ITagValueList options)
        {
            // set contract fields
            Contract contract = new Contract();

            contract.LocalSymbol = localSymbol;
            contract.SecType = secType;
            contract.Exchange = exchange;
            contract.PrimaryExch = primaryExchange;
            contract.Currency = currency;

            // add the combo order legs, if any
            contract.ComboLegs = this.comboLegs;

            // request market data
            this.socket.reqMktData(id, contract, genericTicks, snapshot, ITagValueListToListTagValue(options));
        }

        [DispId(66)]
        public void placeOrder2(int id, string action, int quantity, string localSymbol,
                   string secType, string exchange, string primaryExchange, string curency,
                   string orderType, double lmtPrice, double auxPrice,
                   string goodAfterTime, string faGroup,
                   string faMethod, string faPercentage, string faProfile, string goodTillDate)
        {
            // set contract fields
            Contract contract = new Contract();

            contract.LocalSymbol = localSymbol;
            contract.SecType = secType;
            contract.Exchange = exchange;
            contract.PrimaryExch = primaryExchange;
            contract.Currency = curency;

            // add the combo order legs, if any
            contract.ComboLegs = this.comboLegs;

            // set parameterized order fields
            Order order = new Order();

            order.Action = action;
            order.TotalQuantity = quantity;
            order.OrderType = orderType;
            order.LmtPrice = lmtPrice;
            order.AuxPrice = auxPrice;
            order.FaGroup = faGroup;
            order.FaProfile = faProfile;
            order.FaMethod = faMethod;
            order.FaPercentage = faPercentage;
            order.GoodAfterTime = goodAfterTime;
            order.GoodTillDate = goodTillDate;

            // set extended order fields from properties
            setExtendedOrderAttributes(order);

            // place or modify order
            this.socket.placeOrder(id, contract, order);
        }

        [DispId(67)]
        public void reqContractDetails(string symbol, string secType, string expiry, double strike,
                   string right, string multiplier, string exchange, string curency, int includeExpired)
        {
            // set contract fields
            Contract contract = new Contract();

            contract.Symbol = symbol;
            contract.SecType = secType;
            contract.Expiry = expiry;
            contract.Strike = strike;
            contract.Right = right;
            contract.Multiplier = multiplier;
            contract.Exchange = exchange;
            contract.Currency = curency;
            contract.IncludeExpired = includeExpired != 0;

            // request contract details
            this.socket.reqContractDetails(-1, contract);
        }

        [DispId(68)]
        public void reqContractDetails2(string localSymbol, string secType, string exchange, string curency, int includeExpired)
        {
            // set contract fields
            Contract contract = new Contract();

            contract.LocalSymbol = localSymbol;
            contract.SecType = secType;
            contract.Exchange = exchange;
            contract.Currency = curency;
            contract.IncludeExpired = includeExpired != 0;

            // request contract details
            this.socket.reqContractDetails(-1, contract);
        }

        [DispId(69)]
        public void reqMktDepth(int id, string symbol, string secType, string expiry, double strike,
                   string right, string multiplier, string exchange, string curency, int numRows, ITagValueList options)
        {
            // set contract fields
            Contract contract = new Contract();

            contract.Symbol = symbol;
            contract.SecType = secType;
            contract.Expiry = expiry;
            contract.Strike = strike;
            contract.Right = right;
            contract.Multiplier = multiplier;
            contract.Exchange = exchange;
            contract.Currency = curency;

            // request market depth
            this.socket.reqMarketDepth(id, contract, numRows, ITagValueListToListTagValue(options));
        }

        [DispId(70)]
        public void reqMktDepth2(int id, string localSymbol, string secType, string exchange, string curency, int numRows, ITagValueList options)
        {

            Contract contract = new Contract();

            contract.LocalSymbol = localSymbol;
            contract.SecType = secType;
            contract.Exchange = exchange;
            contract.Currency = curency;

            // request market depth
            this.socket.reqMarketDepth(id, contract, numRows, ITagValueListToListTagValue(options));
        }

        [DispId(71)]
        public void cancelMktDepth(int id)
        {
            this.socket.cancelMktDepth(id);
        }

        [DispId(72)]
        public void addComboLeg(int conid, string action, int ratio, string exchange, int openClose, int shortSaleSlot, string designatedLocation, int exemptCode)
        {
            ComboLeg comboLeg = new ComboLeg();

            comboLeg.ConId = conid;
            comboLeg.Ratio = ratio;
            comboLeg.Action = action;
            comboLeg.Exchange = exchange;
            comboLeg.OpenClose = openClose;
            comboLeg.ShortSaleSlot = shortSaleSlot;
            comboLeg.DesignatedLocation = designatedLocation;
            comboLeg.ExemptCode = exemptCode;

            this.comboLegs.Add(comboLeg);
        }

        [DispId(73)]
        public void clearComboLegs()
        {
            this.comboLegs.Clear();
        }

        [DispId(74)]
        public void cancelNewsBulletins()
        {
            this.socket.cancelNewsBulletin();
        }

        [DispId(75)]
        public void reqNewsBulletins(bool allDaysMsgs)
        {
            this.socket.reqNewsBulletins(allDaysMsgs);
        }

        [DispId(76)]
        public void setServerLogLevel(int logLevel)
        {
            this.socket.setServerLogLevel(logLevel);
        }

        [DispId(77)]
        public void reqAutoOpenOrders(bool bAutoBind)
        {
            this.socket.reqAutoOpenOrders(bAutoBind);
        }

        [DispId(78)]
        public void reqAllOpenOrders()
        {
            this.socket.reqAllOpenOrders();
        }

        [DispId(79)]
        public void reqManagedAccts()
        {
            this.socket.reqManagedAccts();
        }

        [DispId(80)]
        public void requestFA(int faDataType)
        {
            this.socket.requestFA(faDataType);
        }

        [DispId(81)]
        public void replaceFA(int faDataType, string cxml)
        {
            this.socket.replaceFA(faDataType, cxml);
        }

        [DispId(82)]
        public void reqHistoricalData(int id, string symbol, string secType, string expiry, double strike,
                   string right, string multiplier, string exchange, string curency, int isExpired,
                   string endDateTime, string durationStr, string barSizeSetting, string whatToShow,
                   int useRTH, int formatDate, ITagValueList options)
        {
            Contract contract = new Contract();

            contract.Symbol = symbol;
            contract.SecType = secType;
            contract.Expiry = expiry;
            contract.Strike = strike;
            contract.Right = right;
            contract.Multiplier = multiplier;
            contract.Exchange = exchange;
            contract.Currency = curency;
            contract.IncludeExpired = isExpired != 0;

            // add the combo order legs, if any
            contract.ComboLegs = this.comboLegs;

            // request historical data
            this.socket.reqHistoricalData(id, contract, endDateTime, durationStr, barSizeSetting, whatToShow, useRTH, formatDate, ITagValueListToListTagValue(options));
        }

        [DispId(83)]
        public void exerciseOptions(int id, string symbol, string secType, string expiry, double strike,
                   string right, string multiplier, string exchange, string curency,
                   int exerciseAction, int exerciseQuantity, int @override)
        {
            Contract contract = new Contract();

            contract.Symbol = symbol;
            contract.SecType = secType;
            contract.Expiry = expiry;
            contract.Strike = strike;
            contract.Right = right;
            contract.Multiplier = multiplier;
            contract.Exchange = exchange;
            contract.Currency = curency;

            this.socket.exerciseOptions(id, contract, exerciseAction, exerciseQuantity, this.account, @override);
        }

        [DispId(84)]
        public void reqScannerParameters()
        {
            this.socket.reqScannerParameters();
        }

        [DispId(85)]
        public void reqScannerSubscription(int tickerId, int numberOfRows, string instrument,
            string locationCode, string scanCode, double abovePrice, double belowPrice,
            int aboveVolume, double marketCapAbove, double marketCapBelow, string moodyRatingAbove,
            string moodyRatingBelow, string spRatingAbove, string spRatingBelow,
            string maturityDateAbove, string maturityDateBelow, double couponRateAbove,
            double couponRateBelow, int excludeConvertible, int averageOptionVolumeAbove,
            string scannerSettingPairs, string stockTypeFilter, ITagValueList options)
        {
            ScannerSubscription subscription = new ScannerSubscription();

            subscription.NumberOfRows = numberOfRows;
            subscription.Instrument = instrument;
            subscription.LocationCode = locationCode;
            subscription.ScanCode = scanCode;
            subscription.AbovePrice = abovePrice;
            subscription.BelowPrice = belowPrice;
            subscription.AboveVolume = aboveVolume;
            subscription.MarketCapAbove = marketCapAbove;
            subscription.MarketCapBelow = marketCapBelow;
            subscription.MoodyRatingAbove = moodyRatingAbove;
            subscription.MoodyRatingBelow = moodyRatingBelow;
            subscription.SpRatingAbove = spRatingAbove;
            subscription.SpRatingBelow = spRatingBelow;
            subscription.MaturityDateAbove = maturityDateAbove;
            subscription.MaturityDateBelow = maturityDateBelow;
            subscription.CouponRateAbove = couponRateAbove;
            subscription.CouponRateBelow = couponRateBelow;
            subscription.ExcludeConvertible = excludeConvertible.ToString();
            subscription.AverageOptionVolumeAbove = averageOptionVolumeAbove;
            subscription.ScannerSettingPairs = scannerSettingPairs;
            subscription.StockTypeFilter = stockTypeFilter;

            this.socket.reqScannerSubscription(tickerId, subscription, ITagValueListToListTagValue(options));
        }

        [DispId(86)]
        public void cancelHistoricalData(int tickerId)
        {
            this.socket.cancelHistoricalData(tickerId);
        }

        [DispId(87)]
        public void cancelScannerSubscription(int tickerId)
        {
            this.socket.cancelScannerSubscription(tickerId);
        }

        [DispId(88)]
        public void resetAllProperties()
        {
            openClose = "O";
            origin = 0;
            transmit = true;
            parentId = 0;
            blockOrder = false;
            sweepToFill = false;
            displaySize = 0;
            triggerMethod = 0;
            outsideRth = false;
            hidden = false;
            shortSaleSlot = 0;
            exemptCode = -1;
            clientIdFilter = 0;
            discretionaryAmt = 0;
            ocaType = 0;
            allOrNone = false;
            minQty = int.MaxValue;
            percentOffset = double.MaxValue;
            eTradeOnly = false;
            firmQuoteOnly = false;
            nbboPriceCap = double.MaxValue;
            auctionStrategy = 0;
            startingPrice = double.MaxValue;
            stockRefPrice = double.MaxValue;
            delta = double.MaxValue;
            stockRangeLower = double.MaxValue;
            stockRangeUpper = double.MaxValue;
            serverVersion = 0;
            overridePercentageConstraints = false;
            volatility = double.MaxValue;
            volatilityType = int.MaxValue;
            deltaNeutralAuxPrice = double.MaxValue;
            continuousUpdate = 0;
            referencePriceType = int.MaxValue;
            account = "";
            tif = "";
            oca = "";
            orderRef = "";
            openClose = "";
            acctCodeFilter = "";
            timeFilter = "";
            symbolFilter = "";
            secTypeFilter = "";
            exchangeFilter = "";
            sideFilter = "";
            designatedLocation = "";
            rule80A = "";
            settlingFirm = "";
            TwsConnectionTime = "";
            deltaNeutralOrderType = "";
            trailStopPrice = double.MaxValue;
            scaleInitLevelSize = int.MaxValue;
            scaleSubsLevelSize = int.MaxValue;
            scalePriceIncrement = double.MaxValue;
        }

        [DispId(89)]
        public void reqRealTimeBars(int tickerId, string symbol, string secType, string expiry, double strike,
            string right, string multiplier, string exchange, string primaryExchange, string currency,
            int isExpired, int barSize, string whatToShow, int useRTH, ITagValueList options)
        {
            Contract contract = new Contract();

            contract.Symbol = symbol;
            contract.SecType = secType;
            contract.Expiry = expiry;
            contract.Strike = strike;
            contract.Right = right;
            contract.Multiplier = multiplier;
            contract.Exchange = exchange;
            contract.PrimaryExch = primaryExchange;
            contract.Currency = currency;
            contract.IncludeExpired = (isExpired != 0);

            // request real time bars
            this.socket.reqRealTimeBars(tickerId, contract, barSize, whatToShow, useRTH != 0, ITagValueListToListTagValue(options));
        }

        [DispId(90)]
        public void cancelRealTimeBars(int tickerId)
        {
            this.socket.cancelRealTimeBars(tickerId);
        }

        [DispId(91)]
        public void reqCurrentTime()
        {
            this.socket.reqCurrentTime();
        }

        [DispId(92)]
        public void reqFundamentalData(int reqId, IContract contract, string reportType)
        {
            if (!(contract is Contract))
                throw new ArgumentException("Invalid argument type", "contract");
            //X - CHANGED
            this.socket.reqFundamentalData(reqId, contract as Contract, reportType, null);
        }

        [DispId(93)]
        public void cancelFundamentalData(int reqId)
        {
            this.socket.cancelFundamentalData(reqId);
        }

        [DispId(94)]
        public void calculateImpliedVolatility(int reqId, IContract contract, double optionPrice, double underPrice)
        {
            //X - CHANGED
            this.socket.calculateImpliedVolatility(reqId, (Contract)contract, optionPrice, underPrice, null);
        }

        [DispId(95)]
        public void calculateOptionPrice(int reqId, IContract contract, double volatility, double underPrice)
        {
            //X - CHANGED
            this.socket.calculateOptionPrice(reqId, (Contract)contract, volatility, underPrice, null);
        }

        [DispId(96)]
        public void cancelCalculateImpliedVolatility(int reqId)
        {
            this.socket.cancelCalculateImpliedVolatility(reqId);
        }

        [DispId(97)]
        public void cancelCalculateOptionPrice(int reqId)
        {
            this.socket.cancelCalculateOptionPrice(reqId);
        }

        [DispId(98)]
        public void reqGlobalCancel()
        {
            this.socket.reqGlobalCancel();
        }

        [DispId(99)]
        public void reqMarketDataType(int marketDataType)
        {
            this.socket.reqMarketDataType(marketDataType);
        }

        [DispId(100)]
        public void reqContractDetailsEx(int reqId, IContract contract)
        {
            this.socket.reqContractDetails(reqId, (Contract)contract);
        }

        [DispId(101)]
        public void reqMktDataEx(int tickerId, IContract contract, string genericTicks, bool snapshot, ITagValueList options)
        {
            this.socket.reqMktData(tickerId, (Contract)contract, genericTicks, snapshot, ITagValueListToListTagValue(options));
        }

        private static List<TagValue> ITagValueListToListTagValue(ITagValueList v)
        {
            if (v == null)
                return null;

            return (v as TagValueList).Tvl;
        }

        [DispId(102)]
        public void reqMktDepthEx(int tickerId, IContract contract, int numRows, ITagValueList options)
        {
            this.socket.reqMarketDepth(tickerId, (Contract)contract, numRows, ITagValueListToListTagValue(options));
        }

        [DispId(103)]
        public void placeOrderEx(int orderId, IContract contract, IOrder order)
        {
            this.socket.placeOrder(orderId, (Contract)contract, (Order)order);
        }

        [DispId(104)]
        public void reqExecutionsEx(int reqId, IExecutionFilter filter)
        {
            this.socket.reqExecutions(reqId, (ExecutionFilter)filter);
        }

        [DispId(105)]
        public void exerciseOptionsEx(int tickerId, IContract contract, int exerciseAction,
            int exerciseQuantity, string account, int @override)
        {
            this.socket.exerciseOptions(tickerId, (Contract)contract, exerciseAction, exerciseQuantity, account, @override);
        }

        [DispId(106)]
        public void reqHistoricalDataEx(int tickerId, IContract contract, string endDateTime,
            string duration, string barSize, string whatToShow, bool useRTH, int formatDate, ITagValueList options)
        {
            this.socket.reqHistoricalData(tickerId, (Contract)contract, endDateTime, duration, barSize, whatToShow, useRTH ? 1 : 0, formatDate, ITagValueListToListTagValue(options));
        }

        [DispId(107)]
        public void reqRealTimeBarsEx(int tickerId, IContract contract, int barSize, string whatToShow, bool useRTH, ITagValueList options)
        {
            this.socket.reqRealTimeBars(tickerId, (Contract)contract, barSize, whatToShow, useRTH, ITagValueListToListTagValue(options));
        }

        [DispId(108)]
        public void reqScannerSubscriptionEx(int tickerId, IScannerSubscription subscription, ITagValueList options)
        {
            this.socket.reqScannerSubscription(tickerId, (ScannerSubscription)subscription, ITagValueListToListTagValue(options));
        }

        [DispId(109)]
        public void addOrderComboLeg(double price)
        {
            this.orderComboLegs.Add(new OrderComboLeg() { Price = price });
        }

        [DispId(110)]
        public void clearOrderComboLegs()
        {
            this.orderComboLegs.Clear();
        }

        [DispId(111)]
        public void reqPositions()
        {
            this.socket.reqPositions();
        }

        [DispId(112)]
        public void cancelPositions()
        {
            this.socket.cancelPositions();
        }

        [DispId(113)]
        public void reqAccountSummary(int reqId, string groupName, string tags)
        {
            this.socket.reqAccountSummary(reqId, groupName, tags);
        }

        [DispId(114)]
        public void cancelAccountSummary(int reqId)
        {
            this.socket.cancelAccountSummary(reqId);
        }

        [DispId(200)]
        public IContract createContract() { return new Contract(); }
        [DispId(201)]
        public IComboLegList createComboLegList() { return new ComboLegList(); }
        [DispId(202)]
        public IOrder createOrder() { return new Order(); }
        [DispId(203)]
        public IExecutionFilter createExecutionFilter() { return new ExecutionFilter(); }
        [DispId(204)]
        public IScannerSubscription createScannerSubscription() { return new ScannerSubscription(); }
        [DispId(205)]
        public IUnderComp createUnderComp() { return new UnderComp(); }
        [DispId(206)]
        public ITagValueList createTagValueList() { return new TagValueList(); }
        [DispId(207)]
        public IOrderComboLegList createOrderComboLegList() { return new OrderComboLegList(); }
        #endregion

        #region events

        public delegate void tickPriceDelegate(int id, int tickType, double price, int canAutoExecute);

        public delegate void tickSizeDelegate(int id, int tickType, int size);

        public delegate void connectionClosedDelegate();

        public delegate void openOrder1Delegate(int id, string symbol, string secType, string expiry, double strike, string right, string exchange, string curency, string localSymbol);

        public delegate void openOrder2Delegate(int id, string action, int quantity, string orderType, double lmtPrice, double auxPrice, string tif, string ocaGroup, string account, string openClose, int origin, string orderRef, int clientId);

        public delegate void updateAccountTimeDelegate(string timeStamp);

        public delegate void updateAccountValueDelegate(string key, string value, string curency, string accountName);

        public delegate void nextValidIdDelegate(int id);

        public delegate void permIdDelegate(int id, int permId);

        public delegate void errMsgDelegate(int id, int errorCode, string errorMsg);

        public delegate void updatePortfolioDelegate(string symbol, string secType, string expiry, double strike, string right, string curency, string localSymbol, int position, double marketPrice, double marketValue, double averageCost, double unrealizedPNL, double realizedPNL, string accountName);

        public delegate void orderStatusDelegate(int id, string status, int filled, int remaining, double avgFillPrice, int permId, int parentId, double lastFillPrice, int clientId, string whyHeld);

        public delegate void contractDetailsDelegate(string symbol, string secType, string expiry, double strike, string right, string exchange, string curency, string localSymbol, string marketName, string tradingClass, int conId, double minTick, int priceMagnifier, string multiplier, string orderTypes, string validExchanges);

        public delegate void execDetailsDelegate(int id, string symbol, string secType, string expiry, double strike, string right, string cExchange, string curency, string localSymbol, string execId, string time, string acctNumber, string eExchange, string side, int shares, double price, int permId, int clientId, int isLiquidation);

        public delegate void updateMktDepthDelegate(int id, int position, int operation, int side, double price, int size);

        public delegate void updateMktDepthL2Delegate(int id, int position, string marketMaker, int operation, int side, double price, int size);

        public delegate void updateNewsBulletinDelegate(short msgId, short msgType, string message, string origExchange);

        public delegate void managedAccountsDelegate(string accountsList);

        public delegate void openOrder3Delegate(int id, string symbol, string secType, string expiry, double strike, string right, string exchange, string curency, string localSymbol, string action, int quantity, string orderType, double lmtPrice, double auxPrice, string tif, string ocaGroup, string account, string openClose, int origin, string orderRef, int clientId, int permId, string sharesAllocation, string faGroup, string faMethod, string faPercentage, string faProfile, string goodAfterTime, string goodTillDate);

        public delegate void receiveFADelegate(int faDataType, string cxml);

        public delegate void historicalDataDelegate(int reqId, string date, double open, double high, double low, double close, int volume, int barCount, double WAP, int hasGaps);

        public delegate void openOrder4Delegate(int id, string symbol, string secType, string expiry, double strike, string right, string exchange, string curency, string localSymbol, string action, int quantity, string orderType, double lmtPrice, double auxPrice, string tif, string ocaGroup, string account, string openClose, int origin, string orderRef, int clientId, int permId, string sharesAllocation, string faGroup, string faMethod, string faPercentage, string faProfile, string goodAfterTime, string goodTillDate, int ocaType, string rule80A, string settlingFirm, int allOrNone, int minQty, double percentOffset, int eTradeOnly, int firmQuoteOnly, double nbboPriceCap, int auctionStrategy, double startingPrice, double stockRefPrice, double delta, double stockRangeLower, double stockRangeUpper, int blockOrder, int sweepToFill, int ignoreRth, int hidden, double discretionaryAmt, int displaySize, int parentId, int triggerMethod, int shortSaleSlot, string designatedLocation, double volatility, int volatilityType, string deltaNeutralOrderType, double deltaNeutralAuxPrice, int continuousUpdate, int referencePriceType, double trailStopPrice, double basisPoints, int basisPointsType, string legsStr, int scaleInitLevelSize, int scaleSubsLevelSize, double scalePriceIncrement);

        public delegate void bondContractDetailsDelegate(string symbol, string secType, string cusip, double coupon, string maturity, string issueDate, string ratings, string bondType, string couponType, int convertible, int callable, int putable, string descAppend, string exchange, string curency, string marketName, string tradingClass, int conId, double minTick, string orderTypes, string validExchanges, string nextOptionDate, string nextOptionType, int nextOptionPartial, string notes);

        public delegate void scannerParametersDelegate(string xml);

        public delegate void scannerDataDelegate(int reqId, int rank, string symbol, string secType, string expiry, double strike, string right, string exchange, string curency, string localSymbol, string marketName, string tradingClass, string distance, string benchmark, string projection, string legsStr);

        public delegate void tickOptionComputationDelegate(int id, int tickType, double impliedVol, double delta, double optPrice, double pvDividend, double gamma, double vega, double theta, double undPrice);

        public delegate void tickGenericDelegate(int id, int tickType, double value);

        public delegate void tickStringDelegate(int id, int tickType, string value);

        public delegate void tickEFPDelegate(int tickerId, int field, double basisPoints, string formattedBasisPoints,
                     double totalDividends, int holdDays, string futureExpiry, double dividendImpact,
                     double dividendsToExpiry);

        public delegate void realtimeBarDelegate(int tickerId, int time, double open, double high, double low, double close,
                         int volume, double WAP, int count);

        public delegate void currentTimeDelegate(int time);

        public delegate void scannerDataEndDelegate(int reqId);

        public delegate void fundamentalDataDelegate(int reqId, string data);

        public delegate void contractDetailsEndDelegate(int reqId);

        public delegate void openOrderEndDelegate();

        public delegate void accountDownloadEndDelegate(string accountName);

        public delegate void execDetailsEndDelegate(int reqId);

        public delegate void deltaNeutralValidationDelegate(int reqId, IUnderComp underComp);

        public delegate void tickSnapshotEndDelegate(int reqId);

        public delegate void marketDataTypeDelegate(int reqId, int marketDataType);

        public delegate void contractDetailsExDelegate(int reqId, IContractDetails contractDetails);

		//X - ADDED
        public delegate void bondContractDetailsExDelegate(int reqId, IContractDetails contractDetails);

        public delegate void openOrderExDelegate(int orderId, IContract contract, IOrder order, IOrderState orderState);

        public delegate void execDetailsExDelegate(int reqId, IContract contract, IExecution execution);

        public delegate void updatePortfolioExDelegate(IContract contract, int position, double marketPrice,
            double marketValue, double averageCost, double unrealizedPNL, double realizedPNL, string accountName);

        public delegate void scannerDataExDelegate(int reqId, int rank, IContractDetails contractDetails, string distance, string benchmark, string projection, string legsStr);

        public delegate void commissionReportDelegate(ICommissionReport commissionReport);

        public delegate void positionDelegate(string account, IContract contract, int position, double avgCost);

        public delegate void positionEndDelegate();

        public delegate void accountSummaryDelegate(int reqId, string account, string tag, string value, string curency);

        public delegate void accountSummaryEndDelegate(int reqId);

        public delegate void verifyMessageAPIDelegate(string apiData);

        public delegate void verifyCompletedDelegate(bool isSuccessful, string errorText);

        public delegate void displayGroupListDelegate(int reqId, string groups);

        public delegate void displayGroupUpdatedDelegate(int reqId, string contractInfo);

        public event tickPriceDelegate tickPrice;

        public event tickSizeDelegate tickSize;

        public event connectionClosedDelegate connectionClosed;

        public event openOrder1Delegate openOrder1;

        public event openOrder2Delegate openOrder2;

        public event updateAccountTimeDelegate updateAccountTime;

        public event updateAccountValueDelegate updateAccountValue;

        public event nextValidIdDelegate nextValidId;

        public event permIdDelegate permId;

        public event errMsgDelegate errMsg;

        public event updatePortfolioDelegate updatePortfolio;

        public event orderStatusDelegate orderStatus;

        public event contractDetailsDelegate contractDetails;

        public event execDetailsDelegate execDetails;

        public event updateMktDepthDelegate updateMktDepth;

        public event updateMktDepthL2Delegate updateMktDepthL2;

        public event updateNewsBulletinDelegate updateNewsBulletin;

        public event managedAccountsDelegate managedAccounts;

        public event openOrder3Delegate openOrder3;

        public event receiveFADelegate receiveFA;

        public event historicalDataDelegate historicalData;

        public event openOrder4Delegate openOrder4;

        public event bondContractDetailsDelegate bondContractDetails;

        public event scannerParametersDelegate scannerParameters;

        public event scannerDataDelegate scannerData;

        public event tickOptionComputationDelegate tickOptionComputation;

        public event tickGenericDelegate tickGeneric;

        public event tickStringDelegate tickString;

        public event tickEFPDelegate tickEFP;

        public event realtimeBarDelegate realtimeBar;

        public event currentTimeDelegate currentTime;

        event scannerDataEndDelegate scannerDataEnd;

        public event fundamentalDataDelegate fundamentalData;

        public event contractDetailsEndDelegate contractDetailsEnd;

        public event openOrderEndDelegate openOrderEnd;

        public event accountDownloadEndDelegate accountDownloadEnd;

        public event execDetailsEndDelegate execDetailsEnd;

        public event deltaNeutralValidationDelegate deltaNeutralValidation;

        public event tickSnapshotEndDelegate tickSnapshotEnd;

        public event marketDataTypeDelegate marketDataType;

        public event contractDetailsExDelegate contractDetailsEx;

		//X - ADDED
        public event bondContractDetailsExDelegate bondContractDetailsEx;

        public event openOrderExDelegate openOrderEx;

        public event execDetailsExDelegate execDetailsEx;

        public event updatePortfolioExDelegate updatePortfolioEx;

        public event scannerDataExDelegate scannerDataEx;

        public event commissionReportDelegate commissionReport;

        public event positionDelegate position;

        public event positionEndDelegate positionEnd;

        public event accountSummaryDelegate accountSummary;

        public event accountSummaryEndDelegate accountSummaryEnd;

        public event verifyMessageAPIDelegate verifyMessageAPI;

        public event verifyCompletedDelegate verifyCompleted;

        public event displayGroupListDelegate displayGroupList;

        public event displayGroupUpdatedDelegate displayGroupUpdated;

        #endregion

        List<ComboLeg> comboLegs = new List<ComboLeg>();
        List<OrderComboLeg> orderComboLegs = new List<OrderComboLeg>();

        void InvokeIfRequired(Delegate method, params object[] args)
        {
            if (InvokeRequired)
                Invoke(method, args);
            else
                method.DynamicInvoke(args);
        }

        void InvokeIfRequired(Delegate method)
        {
            InvokeIfRequired(method, new object[0]);
        }

        void EWrapper.error(Exception e)
        {
            var t_errMsg = this.errMsg;
            if (t_errMsg != null)
                InvokeIfRequired(t_errMsg, -1, -1, e.Message);
        }

        void EWrapper.error(string str)
        {
            var t_errMsg = this.errMsg;
            if (t_errMsg != null)
                InvokeIfRequired(t_errMsg, -1, -1, str);
        }

        void EWrapper.error(int id, int errorCode, string errorMsg)
        {
            var t_errMsg = this.errMsg;
            if (t_errMsg != null)
                InvokeIfRequired(t_errMsg, id, errorCode, errorMsg);
        }

        void EWrapper.currentTime(long time)
        {
            var t_currentTime = this.currentTime;
            if (t_currentTime != null)
                InvokeIfRequired(t_currentTime, (int)time);
        }

        void EWrapper.tickPrice(int tickerId, int field, double price, int canAutoExecute)
        {
            var t_tickPrice = this.tickPrice;
            if (t_tickPrice != null)
                InvokeIfRequired(t_tickPrice, tickerId, field, price, canAutoExecute);
        }

        void EWrapper.tickSize(int tickerId, int field, int size)
        {
            var t_tickSize = this.tickSize;
            if (t_tickSize != null)
                InvokeIfRequired(t_tickSize, tickerId, field, size);
        }

        void EWrapper.tickString(int tickerId, int field, string value)
        {
            var t_tickString = this.tickString;
            if (t_tickString != null)
                InvokeIfRequired(t_tickString, tickerId, field, value);
        }

        void EWrapper.tickGeneric(int tickerId, int field, double value)
        {
            var t_tickGeneric = this.tickGeneric;
            if (t_tickGeneric != null)
                InvokeIfRequired(t_tickGeneric, tickerId, field, value);
        }

        void EWrapper.tickEFP(int tickerId, int tickType, double basisPoints, string formattedBasisPoints, double impliedFuture, int holdDays, string futureExpiry, double dividendImpact, double dividendsToExpiry)
        {
            var t_tickEFP = this.tickEFP;
            if (t_tickEFP != null)
                InvokeIfRequired(t_tickEFP, tickerId, tickType, basisPoints, formattedBasisPoints, impliedFuture, holdDays, futureExpiry, dividendImpact, dividendsToExpiry);
        }

        void EWrapper.deltaNeutralValidation(int reqId, UnderComp underComp)
        {
            var t_deltaNeutralValidation = this.deltaNeutralValidation;
            if (t_deltaNeutralValidation != null)
                InvokeIfRequired(t_deltaNeutralValidation, reqId, underComp);
        }

        void EWrapper.tickOptionComputation(int tickerId, int field, double impliedVolatility, double delta, double optPrice, double pvDividend, double gamma, double vega, double theta, double undPrice)
        {
            var t_tickOptionComputation = this.tickOptionComputation;
            if (t_tickOptionComputation != null)
                InvokeIfRequired(t_tickOptionComputation, tickerId, field, impliedVolatility, delta, optPrice, pvDividend, gamma, vega, theta, undPrice);
        }

        void EWrapper.tickSnapshotEnd(int tickerId)
        {
            var t_tickSnapshotEnd = this.tickSnapshotEnd;
            if (t_tickSnapshotEnd != null)
                InvokeIfRequired(t_tickSnapshotEnd, tickerId);
        }

        void EWrapper.nextValidId(int orderId)
        {
            var t_nextValidId = this.nextValidId;
            if (t_nextValidId != null)
                InvokeIfRequired(t_nextValidId, orderId);
        }

        void EWrapper.managedAccounts(string accountsList)
        {
            var t_managedAccounts = this.managedAccounts;
            if (t_managedAccounts != null)
                InvokeIfRequired(t_managedAccounts, accountsList);
        }

        void EWrapper.connectionClosed()
        {
#warning            var t_TwsConnectionTime = this.TwsConnectionTime;

            this.serverVersion = socket.ServerVersion;

            var t_connectionClosed = this.connectionClosed;
            if (t_connectionClosed != null)
                InvokeIfRequired(t_connectionClosed);
        }

        void EWrapper.accountSummary(int reqId, string account, string tag, string value, string currency)
        {
            var t_accountSummary = this.accountSummary;
            if (t_accountSummary != null)
                InvokeIfRequired(t_accountSummary, reqId, account, tag, value, currency);
        }

        void EWrapper.accountSummaryEnd(int reqId)
        {
            var t_accountSummaryEnd = this.accountSummaryEnd;
            if (t_accountSummaryEnd != null)
                InvokeIfRequired(t_accountSummaryEnd, reqId);
        }

        void EWrapper.updateAccountValue(string key, string value, string currency, string accountName)
        {
            var t_updateAccountValue = this.updateAccountValue;
            if (t_updateAccountValue != null)
                InvokeIfRequired(t_updateAccountValue, key, value, currency, accountName);
        }

        void EWrapper.updatePortfolio(Contract contract, int position, double marketPrice, double marketValue, double averageCost, double unrealisedPNL, double realisedPNL, string accountName)
        {
            var t_updatePortfolio = this.updatePortfolio;
            if (t_updatePortfolio != null)
                InvokeIfRequired(t_updatePortfolio,
                                contract.Symbol,
                                contract.SecType,
                                contract.Expiry,
                                contract.Strike,
                                contract.Right,
                                contract.Currency,
                                contract.LocalSymbol,
                                position,
                                marketPrice,
                                marketValue,
                                averageCost,
                                unrealisedPNL,
                                realisedPNL,
                                accountName);

            var t_updatePortfolioEx = this.updatePortfolioEx;
            if (t_updatePortfolioEx != null)
                InvokeIfRequired(t_updatePortfolioEx, contract, position, marketPrice, marketValue, averageCost, unrealisedPNL, realisedPNL, accountName);
        }

        void EWrapper.updateAccountTime(string timestamp)
        {
            var t_updateAccountTime = this.updateAccountTime;
            if (t_updateAccountTime != null)
                InvokeIfRequired(t_updateAccountTime, timestamp);
        }

        void EWrapper.accountDownloadEnd(string account)
        {
            var t_accountDownloadEnd = this.accountDownloadEnd;
            if (t_accountDownloadEnd != null)
                InvokeIfRequired(t_accountDownloadEnd, account);
        }

        void EWrapper.orderStatus(int orderId, string status, int filled, int remaining, double avgFillPrice, int permId, int parentId, double lastFillPrice, int clientId, string whyHeld)
        {
            var t_orderStatus = this.orderStatus;
            if (t_orderStatus != null)
                InvokeIfRequired(t_orderStatus, orderId, status, filled, remaining, avgFillPrice, permId, parentId, lastFillPrice, clientId, whyHeld);
        }

        void EWrapper.openOrder(int orderId, Contract contract, Order order, OrderState orderState)
        {
            var t_openOrder1 = this.openOrder1;
            if (t_openOrder1 != null)
                InvokeIfRequired(t_openOrder1,
                    orderId,
                    contract.Symbol,
                    contract.SecType,
                    contract.Expiry,
                    contract.Strike,
                    contract.Right,
                    contract.Exchange,
                    contract.Currency,
                    contract.LocalSymbol);

            // send order fields
            var t_openOrder2 = this.openOrder2;
            if (t_openOrder2 != null)
                InvokeIfRequired(t_openOrder2,
                                orderId,
                                order.Action,
                                order.TotalQuantity,
                                order.OrderType,
                                order.LmtPrice,
                                order.AuxPrice,
                                order.Tif,
                                order.OcaGroup,
                                order.Account,
                                order.OpenClose,
                                order.Origin,
                                order.OrderRef,
                                order.ClientId);

            // send order and contract fields
            var t_openOrder3 = this.openOrder3;
            if (t_openOrder3 != null)
                InvokeIfRequired(t_openOrder3,
                                orderId,
                                contract.Symbol,
                                contract.SecType,
                                contract.Expiry,
                                contract.Strike,
                                contract.Right,
                                contract.Exchange,
                                contract.Currency,
                                contract.LocalSymbol,
                                order.Action,
                                order.TotalQuantity,
                                order.OrderType,
                                order.LmtPrice,
                                order.AuxPrice,
                                order.Tif,
                                order.OcaGroup,
                                order.Account,
                                order.OpenClose,
                                order.Origin,
                                order.OrderRef,
                                order.ClientId,
                                order.PermId,
                                "", // deprecated sharesAllocation
                                order.FaGroup,
                                order.FaMethod,
                                order.FaPercentage,
                                order.FaProfile,
                                order.GoodAfterTime,
                                order.GoodTillDate);

            // send order and contract fields, and etended order attributes
            var t_openOrder4 = this.openOrder4;
            if (t_openOrder4 != null)
                InvokeIfRequired(t_openOrder4,
                                orderId,
                                contract.Symbol,
                                contract.SecType,
                                contract.Expiry,
                                contract.Strike,
                                contract.Right,
                                contract.Exchange,
                                contract.Currency,
                                contract.LocalSymbol,
                                order.Action,
                                order.TotalQuantity,
                                order.OrderType,
                                order.LmtPrice,
                                order.AuxPrice,
                                order.Tif,
                                order.OcaGroup,
                                order.Account,
                                order.OpenClose,
                                order.Origin,
                                order.OrderRef,
                                order.ClientId,
                                order.PermId,
                                "", // deprecated sharesAllocation
                                order.FaGroup,
                                order.FaMethod,
                                order.FaPercentage,
                                order.FaProfile,
                                order.GoodAfterTime,
                                order.GoodTillDate,
                                order.OcaType,
                                order.Rule80A,
                                order.SettlingFirm,
                                order.AllOrNone ? 1 : 0,
                                order.MinQty,
                                order.PercentOffset,
                                order.ETradeOnly ? 1 : 0,
                                order.FirmQuoteOnly ? 1 : 0,
                                order.NbboPriceCap,
                                order.AuctionStrategy,
                                order.StartingPrice,
                                order.StockRefPrice,
                                order.Delta,
                                order.StockRangeLower,
                                order.StockRangeUpper,
                                order.BlockOrder ? 1 : 0,
                                order.SweepToFill ? 1 : 0,
                                order.OutsideRth ? 1 : 0,
                                order.Hidden ? 1 : 0,
                                order.DiscretionaryAmt,
                                order.DisplaySize,
                                order.ParentId,
                                order.TriggerMethod,
                                order.ShortSaleSlot,
                                order.DesignatedLocation,
                                order.Volatility,
                                order.VolatilityType,
                                order.DeltaNeutralOrderType,
                                order.DeltaNeutralAuxPrice,
                                order.ContinuousUpdate,
                                order.ReferencePriceType,
                                order.TrailStopPrice,
                                order.BasisPoints,
                                order.BasisPointsType,
                                contract.ComboLegsDescription,
                                order.ScaleInitLevelSize,
                                order.ScaleSubsLevelSize,
                                order.ScalePriceIncrement);

            /*
             * Note: all of the above events are deprecated
             *       let's fire a real one
             */


            var t_openOrderEx = this.openOrderEx;
            if (t_openOrderEx != null)
                InvokeIfRequired(t_openOrderEx, orderId, contract, order, orderState);
        }

        void EWrapper.openOrderEnd()
        {
            var t_openOrderEnd = this.openOrderEnd;
            if (t_openOrderEnd != null)
                InvokeIfRequired(t_openOrderEnd);
        }

        void EWrapper.contractDetails(int reqId, ContractDetails contractDetails)
        {
            var t_contractDetails = this.contractDetails;
            if (t_contractDetails != null)
                InvokeIfRequired(t_contractDetails,
                                contractDetails.Summary.Symbol,
                                contractDetails.Summary.SecIdType,
                                contractDetails.Summary.Expiry,
                                contractDetails.Summary.Strike,
                                contractDetails.Summary.Right,
                                contractDetails.Summary.Exchange,
                                contractDetails.Summary.Currency,
                                contractDetails.Summary.LocalSymbol,
                                contractDetails.MarketName,
                                contractDetails.Summary.TradingClass,
                                contractDetails.Summary.ConId,
                                contractDetails.MinTick,
                                contractDetails.PriceMagnifier,
                                contractDetails.Summary.Multiplier,
                                contractDetails.OrderTypes,
                                contractDetails.ValidExchanges);

            var t_contractDetailsEx = this.contractDetailsEx;
            if (t_contractDetailsEx != null)
                InvokeIfRequired(t_contractDetailsEx, reqId, contractDetails);
        }

		//X - ADDED
        void EWrapper.bondContractDetails(int reqId, ContractDetails contractDetails)
        {
            var t_bondContractDetailsEx = this.bondContractDetailsEx;
            if (t_bondContractDetailsEx != null)
                Invoke(t_bondContractDetailsEx, reqId, contractDetails);
        }

        void EWrapper.contractDetailsEnd(int reqId)
        {
            var t_contractDetailsEnd = this.contractDetailsEnd;
            if (t_contractDetailsEnd != null)
                InvokeIfRequired(t_contractDetailsEnd, reqId);
        }

        void EWrapper.execDetails(int reqId, Contract contract, Execution execution)
        {
            var t_execDetails = this.execDetails;
            if (t_execDetails != null)
                InvokeIfRequired(t_execDetails,
                                reqId,
                                contract.Symbol,
                                contract.SecType,
                                contract.Expiry,
                                contract.Strike,
                                contract.Right,
                                contract.Exchange,
                                contract.Currency,
                                contract.LocalSymbol,
                                execution.ExecId,
                                execution.Time,
                                execution.AcctNumber,
                                execution.Exchange,
                                execution.Side,
                                execution.Shares,
                                execution.Price,
                                execution.PermId,
                                execution.ClientId,
                                execution.Liquidation);

            var t_execDetailsEx = this.execDetailsEx;
            if (t_execDetailsEx != null)
                InvokeIfRequired(t_execDetailsEx, reqId, contract, execution);
        }

        void EWrapper.execDetailsEnd(int reqId)
        {
            var t_execDetailsEnd = this.execDetailsEnd;
            if (t_execDetailsEnd != null)
                InvokeIfRequired(t_execDetailsEnd, reqId);
        }

        void EWrapper.commissionReport(CommissionReport commissionReport)
        {
            var t_commissionReport = this.commissionReport;
            if (t_commissionReport != null)
                InvokeIfRequired(t_commissionReport, commissionReport);
        }

        void EWrapper.fundamentalData(int reqId, string data)
        {
            var t_fundamentalData = this.fundamentalData;
            if (t_fundamentalData != null)
                InvokeIfRequired(t_fundamentalData, reqId, data);
        }

        void EWrapper.historicalData(int reqId, string date, double open, double high, double low, double close, int volume, int count, double WAP, bool hasGaps)
        {
            var t_historicalData = this.historicalData;
            if (t_historicalData != null)
                InvokeIfRequired(t_historicalData, reqId, date, open, high, low, close, volume, count, WAP, hasGaps ? 1 : 0);
        }

        public void historicalDataEnd(int reqId, string start, string end)
        {

        }

        void EWrapper.marketDataType(int reqId, int marketDataType)
        {
            var t_marketDataType = this.marketDataType;
            if (t_marketDataType != null)
                InvokeIfRequired(t_marketDataType, reqId, marketDataType);
        }

        void EWrapper.updateMktDepth(int tickerId, int position, int operation, int side, double price, int size)
        {
            var t_updateMktDepth = this.updateMktDepth;
            if (t_updateMktDepth != null)
                InvokeIfRequired(t_updateMktDepth, tickerId, position, operation, side, price, size);
        }

        void EWrapper.updateMktDepthL2(int tickerId, int position, string marketMaker, int operation, int side, double price, int size)
        {
            var t_updateMktDepthL2 = this.updateMktDepthL2;
            if (t_updateMktDepthL2 != null)
                InvokeIfRequired(t_updateMktDepthL2, tickerId, position, marketMaker, operation, side, price, size);
        }

        void EWrapper.updateNewsBulletin(int msgId, int msgType, string message, string origExchange)
        {
            var t_updateNewsBulletin = this.updateNewsBulletin;
            if (t_updateNewsBulletin != null)
                InvokeIfRequired(t_updateNewsBulletin, (short)msgId, (short)msgType, message, origExchange);
        }

        void EWrapper.position(string account, Contract contract, int pos, double avgCost)
        {
            var t_position = this.position;
            if (t_position != null)
                InvokeIfRequired(t_position, account, contract, pos, avgCost);
        }

        void EWrapper.positionEnd()
        {
            var t_positionEnd = this.positionEnd;
            if (t_positionEnd != null)
                InvokeIfRequired(t_positionEnd);
        }

        void EWrapper.realtimeBar(int reqId, long time, double open, double high, double low, double close, long volume, double WAP, int count)
        {
            var t_realtimeBar = this.realtimeBar;
            if (t_realtimeBar != null)
                InvokeIfRequired(t_realtimeBar, reqId, (int)time, open, high, low, close, (int)volume, WAP, count);
        }

        void EWrapper.scannerParameters(string xml)
        {
            var t_scannerParameters = this.scannerParameters;
            if (t_scannerParameters != null)
                InvokeIfRequired(t_scannerParameters, xml);
        }

        void EWrapper.scannerData(int reqId, int rank, ContractDetails contractDetails, string distance, string benchmark, string projection, string legsStr)
        {
            var t_scannerData = this.scannerData;
            if (t_scannerData != null)
                InvokeIfRequired(t_scannerData,
                                reqId,
                                rank,
                                contractDetails.Summary.Symbol,
                                distance,
                                contractDetails.Summary.Expiry,
                                contractDetails.Summary.Strike,
                                contractDetails.Summary.Right,
                                contractDetails.Summary.Exchange,
                                contractDetails.Summary.Currency,
                                contractDetails.Summary.LocalSymbol,
                                contractDetails.MarketName,
                                contractDetails.Summary.TradingClass,
                                distance,
                                benchmark,
                                projection,
                                legsStr);

            var t_scannerDataEx = this.scannerDataEx;
            if (t_scannerDataEx != null)
                InvokeIfRequired(t_scannerDataEx, reqId, rank, contractDetails, distance, benchmark, projection, legsStr);
        }

        void EWrapper.scannerDataEnd(int reqId)
        {
            var t_scannerDataEnd = this.scannerDataEnd;
            if (t_scannerDataEnd != null)
                InvokeIfRequired(t_scannerDataEnd, reqId);
        }

        void EWrapper.receiveFA(int faDataType, string faXmlData)
        {
            var t_receiveFA = this.receiveFA;
            if (t_receiveFA != null)
                InvokeIfRequired(t_receiveFA, faDataType, faXmlData);
        }

        void EWrapper.verifyMessageAPI(string apiData)
        {
            var t_verifyMessageAPI = this.verifyMessageAPI;
            if (t_verifyMessageAPI != null)
                InvokeIfRequired(t_verifyMessageAPI, apiData);
        }

        void EWrapper.verifyCompleted(bool isSuccessful, string errorText)
        {
            var t_verifyCompleted = this.verifyCompleted;
            if (t_verifyCompleted != null)
                InvokeIfRequired(t_verifyCompleted, isSuccessful, errorText);
        }

        void EWrapper.displayGroupList(int reqId, string groups)
        {
            var t_displayGroupList = this.displayGroupList;
            if (t_displayGroupList != null)
                InvokeIfRequired(t_displayGroupList, reqId, groups);
        }

        void EWrapper.displayGroupUpdated(int reqId, string contractInfo)
        {
            var t_displayGroupUpdated = this.displayGroupUpdated;
            if (t_displayGroupUpdated != null)
                InvokeIfRequired(t_displayGroupUpdated, reqId, contractInfo);
        }

        void IDisposable.Dispose()
        {
            this.socket.Close();
        }


        public void verifyRequest(string apiName, string apiVersion)
        {
            socket.verifyRequest(apiName, apiVersion);
        }

        public void verifyMessage(string apiData)
        {
            socket.verifyMessage(apiData);
        }

        public void queryDisplayGroups(int reqId)
        {
            socket.queryDisplayGroups(reqId);
        }

        public void subscribeToGroupEvents(int reqId, int groupId)
        {
            socket.subscribeToGroupEvents(reqId, groupId);
        }

        public void updateDisplayGroup(int reqId, string contractInfo)
        {
            socket.updateDisplayGroup(reqId, contractInfo);
        }

        public void unsubscribeFromGroupEvents(int reqId)
        {
            socket.unsubscribeFromGroupEvents(reqId);
        }
    }
}
