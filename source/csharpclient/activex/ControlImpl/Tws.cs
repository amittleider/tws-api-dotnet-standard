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
using System.Linq;
using System.Threading;
using System.Collections;

namespace TWSLib
{
    [ProgId("Tws.TwsCtrl")]
    [Guid("0A77CCF8-052C-11D6-B0EC-00B0D074179C")]
    [ComVisible(true), ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(ITwsEvents))]
    public class Tws: UserControl, EWrapper, ITws, IDisposable
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
        EReaderSignal eReaderSignal = new EReaderMonitorSignal();

        public Tws()
        {
            socket = new EClientSocket(this, eReaderSignal);

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
        public string TwsConnectionTime { get { return socket.ServerTime; } }
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
        public void placeOrder(int id, string action, double quantity, string localSymbol, string secType,
                   string lastTradeDateOrContractMonth, double strike, string right, string multiplier,
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
                ComboLegs = this.comboLegs,
                LastTradeDateOrContractMonth = lastTradeDateOrContractMonth,
                Strike = strike,
                Right = right,
                Multiplier = multiplier
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

            if (socket.ServerVersion == 0)
                return;

            var reader = new EReader(socket, eReaderSignal);

            reader.Start();

            new Thread(() =>
            {
                while (socket.IsConnected())
                {
                    eReaderSignal.waitForSignal();
                    reader.processMsgs();
                }
            }) { IsBackground = true }.Start();
        }

        [DispId(60)]
        public void reqMktData(int id, string symbol, string secType, string lastTradeDateOrContractMonth, double strike,
                   string right, string multiplier, string exchange, string primaryExchange,
                   string currency, string genericTicks, bool snapshot, ITagValueList options)
        {
            // set contract fields
            Contract contract = new Contract();

            contract.Symbol = symbol;
            contract.SecType = secType;
            contract.LastTradeDateOrContractMonth = lastTradeDateOrContractMonth;
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
        public void placeOrder2(int id, string action, double quantity, string localSymbol,
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
        public void reqContractDetails(string symbol, string secType, string lastTradeDateOrContractMonth, double strike,
                   string right, string multiplier, string exchange, string curency, int includeExpired)
        {
            // set contract fields
            Contract contract = new Contract();

            contract.Symbol = symbol;
            contract.SecType = secType;
            contract.LastTradeDateOrContractMonth = lastTradeDateOrContractMonth;
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
        public void reqMktDepth(int id, string symbol, string secType, string lastTradeDateOrContractMonth, double strike,
                   string right, string multiplier, string exchange, string curency, int numRows, ITagValueList options)
        {
            // set contract fields
            Contract contract = new Contract();

            contract.Symbol = symbol;
            contract.SecType = secType;
            contract.LastTradeDateOrContractMonth = lastTradeDateOrContractMonth;
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
        public void reqHistoricalData(int id, string symbol, string secType, string lastTradeDateOrContractMonth, double strike,
                   string right, string multiplier, string exchange, string curency, int isExpired,
                   string endDateTime, string durationStr, string barSizeSetting, string whatToShow,
                   int useRTH, int formatDate, ITagValueList options)
        {
            Contract contract = new Contract();

            contract.Symbol = symbol;
            contract.SecType = secType;
            contract.LastTradeDateOrContractMonth = lastTradeDateOrContractMonth;
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
        public void exerciseOptions(int id, string symbol, string secType, string lastTradeDateOrContractMonth, double strike,
                   string right, string multiplier, string exchange, string curency,
                   int exerciseAction, int exerciseQuantity, int @override)
        {
            Contract contract = new Contract();

            contract.Symbol = symbol;
            contract.SecType = secType;
            contract.LastTradeDateOrContractMonth = lastTradeDateOrContractMonth;
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
            deltaNeutralOrderType = "";
            trailStopPrice = double.MaxValue;
            scaleInitLevelSize = int.MaxValue;
            scaleSubsLevelSize = int.MaxValue;
            scalePriceIncrement = double.MaxValue;
        }

        [DispId(89)]
        public void reqRealTimeBars(int tickerId, string symbol, string secType, string lastTradeDateOrContractMonth, double strike,
            string right, string multiplier, string exchange, string primaryExchange, string currency,
            int isExpired, int barSize, string whatToShow, int useRTH, ITagValueList options)
        {
            Contract contract = new Contract();

            contract.Symbol = symbol;
            contract.SecType = secType;
            contract.LastTradeDateOrContractMonth = lastTradeDateOrContractMonth;
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
            if (!(contract is ComContract))
                throw new ArgumentException("Invalid argument type", "contract");
            //X - CHANGED
            this.socket.reqFundamentalData(reqId, (Contract)(contract as ComContract), reportType, null);
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
            this.socket.calculateImpliedVolatility(reqId, (Contract)(contract as ComContract), optionPrice, underPrice, null);
        }

        [DispId(95)]
        public void calculateOptionPrice(int reqId, IContract contract, double volatility, double underPrice)
        {
            //X - CHANGED
            this.socket.calculateOptionPrice(reqId, (Contract)(contract as ComContract), volatility, underPrice, null);
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
            this.socket.reqContractDetails(reqId, (Contract)(contract as ComContract));
        }

        [DispId(101)]
        public void reqMktDataEx(int tickerId, IContract contract, string genericTicks, bool snapshot, ITagValueList options)
        {
            this.socket.reqMktData(tickerId, (Contract)(contract as ComContract), genericTicks, snapshot, ITagValueListToListTagValue(options));
        }

        private static List<TagValue> ITagValueListToListTagValue(ITagValueList v)
        {
            if (v == null)
                return null;

            return (v as ComTagValueList).Tvl.Select(x => (TagValue)x).ToList();
        }

        [DispId(102)]
        public void reqMktDepthEx(int tickerId, IContract contract, int numRows, ITagValueList options)
        {
            this.socket.reqMarketDepth(tickerId, (Contract)(contract as ComContract), numRows, ITagValueListToListTagValue(options));
        }

        [DispId(103)]
        public void placeOrderEx(int orderId, IContract contract, IOrder order)
        {
            this.socket.placeOrder(orderId, (Contract)(contract as ComContract), (Order)(order as ComOrder));
        }

        [DispId(104)]
        public void reqExecutionsEx(int reqId, IExecutionFilter filter)
        {
            this.socket.reqExecutions(reqId, (ExecutionFilter)(filter as ComExecutionFilter));
        }

        [DispId(105)]
        public void exerciseOptionsEx(int tickerId, IContract contract, int exerciseAction,
            int exerciseQuantity, string account, int @override)
        {
            this.socket.exerciseOptions(tickerId, (Contract)(contract as ComContract), exerciseAction, exerciseQuantity, account, @override);
        }

        [DispId(106)]
        public void reqHistoricalDataEx(int tickerId, IContract contract, string endDateTime,
            string duration, string barSize, string whatToShow, bool useRTH, int formatDate, ITagValueList options)
        {
            this.socket.reqHistoricalData(tickerId, (Contract)(contract as ComContract), endDateTime, duration, barSize, whatToShow, useRTH ? 1 : 0, formatDate, ITagValueListToListTagValue(options));
        }

        [DispId(107)]
        public void reqRealTimeBarsEx(int tickerId, IContract contract, int barSize, string whatToShow, bool useRTH, ITagValueList options)
        {
            this.socket.reqRealTimeBars(tickerId, (Contract)(contract as ComContract), barSize, whatToShow, useRTH, ITagValueListToListTagValue(options));
        }

        [DispId(108)]
        public void reqScannerSubscriptionEx(int tickerId, IScannerSubscription subscription, ITagValueList options)
        {
            this.socket.reqScannerSubscription(tickerId, (ScannerSubscription)(subscription as ComScannerSubscription), ITagValueListToListTagValue(options));
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
        [DispId(123)]
        public void reqPositionsMulti(int requestId, string account, string modelCode)
        {
            this.socket.reqPositionsMulti(requestId, account, modelCode);
        }
        [DispId(124)]
        public void cancelPositionsMulti(int requestId)
        {
            this.socket.cancelPositionsMulti(requestId);
        }
        [DispId(125)]
        public void reqAccountUpdatesMulti(int requestId, string account, string modelCode, bool ledgerAndNLV)
        {
            this.socket.reqAccountUpdatesMulti(requestId, account, modelCode, ledgerAndNLV);
        }
        [DispId(126)]
        public void cancelAccountUpdatesMulti(int requestId)
        {
            this.socket.cancelAccountUpdatesMulti(requestId);
        }

        [DispId(200)]
        public IContract createContract() { return new ComContract(); }
        [DispId(201)]
        public IComboLegList createComboLegList() { return new ComComboLegList(); }
        [DispId(202)]
        public IOrder createOrder() { return new ComOrder(); }
        [DispId(203)]
        public IExecutionFilter createExecutionFilter() { return new ComExecutionFilter(); }
        [DispId(204)]
        public IScannerSubscription createScannerSubscription() { return new ComScannerSubscription(); }
        [DispId(205)]
        public IUnderComp createUnderComp() { return new ComUnderComp(); }
        [DispId(206)]
        public ITagValueList createTagValueList() { return new ComTagValueList(); }
        [DispId(207)]
        public IOrderComboLegList createOrderComboLegList() { return new ComOrderComboLegList(); }
        #endregion

        #region events

        public delegate void tickPriceDelegate(int id, int tickType, double price, int canAutoExecute);
        public event tickPriceDelegate tickPrice;
        void EWrapper.tickPrice(int tickerId, int field, double price, int canAutoExecute)
        {
            var t_tickPrice = this.tickPrice;
            if (t_tickPrice != null)
                InvokeIfRequired(t_tickPrice, tickerId, field, price, canAutoExecute);
        }

        public delegate void tickSizeDelegate(int id, int tickType, int size);
        public event tickSizeDelegate tickSize;
        void EWrapper.tickSize(int tickerId, int field, int size)
        {
            var t_tickSize = this.tickSize;
            if (t_tickSize != null)
                InvokeIfRequired(t_tickSize, tickerId, field, size);
        }

        public delegate void connectionClosedDelegate();
        public event connectionClosedDelegate connectionClosed;
        void EWrapper.connectionClosed()
        {
            this.serverVersion = socket.ServerVersion;

            var t_connectionClosed = this.connectionClosed;
            if (t_connectionClosed != null)
                InvokeIfRequired(t_connectionClosed);
        }


        public delegate void openOrder1Delegate(int id, string symbol, string secType, string lastTradeDate, double strike, string right, string exchange, string curency, string localSymbol);
        public event openOrder1Delegate openOrder1;

        public delegate void openOrder2Delegate(int id, string action, double quantity, string orderType, double lmtPrice, double auxPrice, string tif, string ocaGroup, string account, string openClose, int origin, string orderRef, int clientId);
        public event openOrder2Delegate openOrder2;

        public delegate void openOrder3Delegate(int id, string symbol, string secType, string lastTradeDate, double strike, string right, string exchange, string curency, string localSymbol, string action, double quantity, string orderType, double lmtPrice, double auxPrice, string tif, string ocaGroup, string account, string openClose, int origin, string orderRef, int clientId, int permId, string sharesAllocation, string faGroup, string faMethod, string faPercentage, string faProfile, string goodAfterTime, string goodTillDate);
        public event openOrder3Delegate openOrder3;
    
        public delegate void openOrder4Delegate(int id, string symbol, string secType, string lastTradeDate, double strike, string right, string exchange, string curency, string localSymbol, string action, double quantity, string orderType, double lmtPrice, double auxPrice, string tif, string ocaGroup, string account, string openClose, int origin, string orderRef, int clientId, int permId, string sharesAllocation, string faGroup, string faMethod, string faPercentage, string faProfile, string goodAfterTime, string goodTillDate, int ocaType, string rule80A, string settlingFirm, int allOrNone, int minQty, double percentOffset, int eTradeOnly, int firmQuoteOnly, double nbboPriceCap, int auctionStrategy, double startingPrice, double stockRefPrice, double delta, double stockRangeLower, double stockRangeUpper, int blockOrder, int sweepToFill, int ignoreRth, int hidden, double discretionaryAmt, int displaySize, int parentId, int triggerMethod, int shortSaleSlot, string designatedLocation, double volatility, int volatilityType, string deltaNeutralOrderType, double deltaNeutralAuxPrice, int continuousUpdate, int referencePriceType, double trailStopPrice, double basisPoints, int basisPointsType, string legsStr, int scaleInitLevelSize, int scaleSubsLevelSize, double scalePriceIncrement);
        public event openOrder4Delegate openOrder4;

        public delegate void openOrderExDelegate(int orderId, IContract contract, IOrder order, IOrderState orderState);
        public event openOrderExDelegate openOrderEx;
        void EWrapper.openOrder(int orderId, Contract contract, Order order, OrderState orderState)
        {
            var t_openOrder1 = this.openOrder1;
            if (t_openOrder1 != null)
                InvokeIfRequired(t_openOrder1,
                    orderId,
                    contract.Symbol,
                    contract.SecType,
                    contract.LastTradeDateOrContractMonth,
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
                                contract.LastTradeDateOrContractMonth,
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
                                contract.LastTradeDateOrContractMonth,
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
                InvokeIfRequired(t_openOrderEx, orderId, (ComContract)contract, (ComOrder)order, (ComOrderState)orderState);
        }

        public delegate void updateAccountTimeDelegate(string timeStamp);
        public event updateAccountTimeDelegate updateAccountTime;
        void EWrapper.updateAccountTime(string timestamp)
        {
            var t_updateAccountTime = this.updateAccountTime;
            if (t_updateAccountTime != null)
                InvokeIfRequired(t_updateAccountTime, timestamp);
        }

        public delegate void updateAccountValueDelegate(string key, string value, string curency, string accountName);
        public event updateAccountValueDelegate updateAccountValue;
        void EWrapper.updateAccountValue(string key, string value, string currency, string accountName)
        {
            var t_updateAccountValue = this.updateAccountValue;
            if (t_updateAccountValue != null)
                InvokeIfRequired(t_updateAccountValue, key, value, currency, accountName);
        }

        public delegate void nextValidIdDelegate(int id);
        public event nextValidIdDelegate nextValidId;
        void EWrapper.nextValidId(int orderId)
        {
            var t_nextValidId = this.nextValidId;
            if (t_nextValidId != null)
                InvokeIfRequired(t_nextValidId, orderId);
        }

        public delegate void permIdDelegate(int id, int permId);
        public event permIdDelegate permId;

        public delegate void errMsgDelegate(int id, int errorCode, string errorMsg);
        public event errMsgDelegate errMsg;
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


        public delegate void updatePortfolioDelegate(string symbol, string secType, string lastTradeDate, double strike, string right, string curency, string localSymbol, double position, double marketPrice, double marketValue, double averageCost, double unrealizedPNL, double realizedPNL, string accountName);
        public event updatePortfolioDelegate updatePortfolio;

        public delegate void updatePortfolioExDelegate(IContract contract, double position, double marketPrice,
            double marketValue, double averageCost, double unrealizedPNL, double realizedPNL, string accountName);
        public event updatePortfolioExDelegate updatePortfolioEx;
        void EWrapper.updatePortfolio(Contract contract, double position, double marketPrice, double marketValue, double averageCost, double unrealisedPNL, double realisedPNL, string accountName)
        {
            var t_updatePortfolio = this.updatePortfolio;
            if (t_updatePortfolio != null)
                InvokeIfRequired(t_updatePortfolio,
                                contract.Symbol,
                                contract.SecType,
                                contract.LastTradeDateOrContractMonth,
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
                InvokeIfRequired(t_updatePortfolioEx, (ComContract)contract, position, marketPrice, marketValue, averageCost, unrealisedPNL, realisedPNL, accountName);
        }

        public delegate void orderStatusDelegate(int id, string status, double filled, double remaining, double avgFillPrice, int permId, int parentId, double lastFillPrice, int clientId, string whyHeld);
        public event orderStatusDelegate orderStatus;
        void EWrapper.orderStatus(int orderId, string status, double filled, double remaining, double avgFillPrice, int permId, int parentId, double lastFillPrice, int clientId, string whyHeld)
        {
            var t_orderStatus = this.orderStatus;
            if (t_orderStatus != null)
                InvokeIfRequired(t_orderStatus, orderId, status, filled, remaining, avgFillPrice, permId, parentId, lastFillPrice, clientId, whyHeld);
        }

        public delegate void contractDetailsDelegate(string symbol, string secType, string lastTradeDate, double strike, string right, string exchange, string curency, string localSymbol, string marketName, string tradingClass, int conId, double minTick, int priceMagnifier, string multiplier, string orderTypes, string validExchanges);
        public event contractDetailsDelegate contractDetails;

        public delegate void contractDetailsExDelegate(int reqId, IContractDetails contractDetails);
        public event contractDetailsExDelegate contractDetailsEx;
        void EWrapper.contractDetails(int reqId, ContractDetails contractDetails)
        {
            var t_contractDetails = this.contractDetails;
            if (t_contractDetails != null)
                InvokeIfRequired(t_contractDetails,
                                contractDetails.Summary.Symbol,
                                contractDetails.Summary.SecIdType,
                                contractDetails.Summary.LastTradeDateOrContractMonth,
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
                InvokeIfRequired(t_contractDetailsEx, reqId, (ComContractDetails)contractDetails);
        }

        public delegate void execDetailsDelegate(int id, string symbol, string secType, string lastTradeDate, double strike, string right, string cExchange, string curency, string localSymbol, string execId, string time, string acctNumber, string eExchange, string side, double shares, double price, int permId, int clientId, int isLiquidation);
        public event execDetailsDelegate execDetails;

        public delegate void execDetailsExDelegate(int reqId, IContract contract, IExecution execution);
        public event execDetailsExDelegate execDetailsEx;
        void EWrapper.execDetails(int reqId, Contract contract, Execution execution)
        {
            var t_execDetails = this.execDetails;
            if (t_execDetails != null)
                InvokeIfRequired(t_execDetails,
                                reqId,
                                contract.Symbol,
                                contract.SecType,
                                contract.LastTradeDateOrContractMonth,
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
                InvokeIfRequired(t_execDetailsEx, reqId, (ComContract)contract, (ComExecution)execution);
        }

        public delegate void updateMktDepthDelegate(int id, int position, int operation, int side, double price, int size);
        public event updateMktDepthDelegate updateMktDepth;
        void EWrapper.updateMktDepth(int tickerId, int position, int operation, int side, double price, int size)
        {
            var t_updateMktDepth = this.updateMktDepth;
            if (t_updateMktDepth != null)
                InvokeIfRequired(t_updateMktDepth, tickerId, position, operation, side, price, size);
        }

        public delegate void updateMktDepthL2Delegate(int id, int position, string marketMaker, int operation, int side, double price, int size);
        public event updateMktDepthL2Delegate updateMktDepthL2;
        void EWrapper.updateMktDepthL2(int tickerId, int position, string marketMaker, int operation, int side, double price, int size)
        {
            var t_updateMktDepthL2 = this.updateMktDepthL2;
            if (t_updateMktDepthL2 != null)
                InvokeIfRequired(t_updateMktDepthL2, tickerId, position, marketMaker, operation, side, price, size);
        }

        public delegate void updateNewsBulletinDelegate(short msgId, short msgType, string message, string origExchange);
        public event updateNewsBulletinDelegate updateNewsBulletin;
        void EWrapper.updateNewsBulletin(int msgId, int msgType, string message, string origExchange)
        {
            var t_updateNewsBulletin = this.updateNewsBulletin;
            if (t_updateNewsBulletin != null)
                InvokeIfRequired(t_updateNewsBulletin, (short)msgId, (short)msgType, message, origExchange);
        }

        public delegate void managedAccountsDelegate(string accountsList);
        public event managedAccountsDelegate managedAccounts;
        void EWrapper.managedAccounts(string accountsList)
        {
            var t_managedAccounts = this.managedAccounts;
            if (t_managedAccounts != null)
                InvokeIfRequired(t_managedAccounts, accountsList);
        }

        public delegate void receiveFADelegate(int faDataType, string cxml);
        public event receiveFADelegate receiveFA;
        void EWrapper.receiveFA(int faDataType, string faXmlData)
        {
            var t_receiveFA = this.receiveFA;
            if (t_receiveFA != null)
                InvokeIfRequired(t_receiveFA, faDataType, faXmlData);
        }

        public delegate void historicalDataDelegate(int reqId, string date, double open, double high, double low, double close, int volume, int barCount, double WAP, int hasGaps);
        public event historicalDataDelegate historicalData;
        void EWrapper.historicalData(int reqId, string date, double open, double high, double low, double close, int volume, int count, double WAP, bool hasGaps)
        {
            var t_historicalData = this.historicalData;
            if (t_historicalData != null)
                InvokeIfRequired(t_historicalData, reqId, date, open, high, low, close, volume, count, WAP, hasGaps ? 1 : 0);
        }

        public delegate void historicalDataEndDelegate(int reqId, string startDate, string endDate);
        public event historicalDataEndDelegate historicalDataEnd;
        void EWrapper.historicalDataEnd(int reqId, string start, string end)
        {
            var t_historicalDataEnd = this.historicalDataEnd;
            if (t_historicalDataEnd != null)
                InvokeIfRequired(t_historicalDataEnd, reqId, start, end);
        }

        public delegate void bondContractDetailsDelegate(string symbol, string secType, string cusip, double coupon, string maturity, string issueDate, string ratings, string bondType, string couponType, bool convertible, bool callable, bool putable, string descAppend, string exchange, string curency, string marketName, string tradingClass, int conId, double minTick, string orderTypes, string validExchanges, string nextOptionDate, string nextOptionType, bool nextOptionPartial, string notes);
        public event bondContractDetailsDelegate bondContractDetails;

        public delegate void bondContractDetailsExDelegate(int reqId, IContractDetails contractDetails);
        public event bondContractDetailsExDelegate bondContractDetailsEx;
        void EWrapper.bondContractDetails(int reqId, ContractDetails contractDetails)
        {
            var t_bondContractDetailsEx = this.bondContractDetailsEx;
            if (t_bondContractDetailsEx != null)
                InvokeIfRequired(t_bondContractDetailsEx, reqId, (ComContractDetails)contractDetails);

            var t_bondContractDetails = this.bondContractDetails;

            if (t_bondContractDetails != null)
                InvokeIfRequired(t_bondContractDetails, contractDetails.Summary.Symbol,
                                      contractDetails.Summary.SecType,
                                      contractDetails.Cusip,
                                      contractDetails.Coupon,
                                      contractDetails.Maturity,
                                      contractDetails.IssueDate,
                                      contractDetails.Ratings,
                                      contractDetails.BondType,
                                      contractDetails.CouponType,
                                      contractDetails.Convertible,
                                      contractDetails.Callable,
                                      contractDetails.Putable,
                                      contractDetails.DescAppend,
                                      contractDetails.Summary.Exchange,
                                      contractDetails.Summary.Currency,
                                      contractDetails.MarketName,
                                      contractDetails.Summary.TradingClass,
                                      contractDetails.Summary.ConId,
                                      contractDetails.MinTick,
                                      contractDetails.OrderTypes,
                                      contractDetails.ValidExchanges,
                                      contractDetails.NextOptionDate,
                                      contractDetails.NextOptionType,
                                      contractDetails.NextOptionPartial,
                                      contractDetails.Notes);
        }

        public delegate void scannerParametersDelegate(string xml);
        public event scannerParametersDelegate scannerParameters;

        public delegate void scannerDataDelegate(int reqId, int rank, string symbol, string secType, string lastTradeDate, double strike, string right, string exchange, string curency, string localSymbol, string marketName, string tradingClass, string distance, string benchmark, string projection, string legsStr);
        public event scannerDataDelegate scannerData;

        public delegate void tickOptionComputationDelegate(int id, int tickType, double impliedVol, double delta, double optPrice, double pvDividend, double gamma, double vega, double theta, double undPrice);
        public event tickOptionComputationDelegate tickOptionComputation;

        public delegate void tickGenericDelegate(int id, int tickType, double value);
        public event tickGenericDelegate tickGeneric;
        void EWrapper.tickGeneric(int tickerId, int field, double value)
        {
            var t_tickGeneric = this.tickGeneric;
            if (t_tickGeneric != null)
                InvokeIfRequired(t_tickGeneric, tickerId, field, value);
        }

        public delegate void tickStringDelegate(int id, int tickType, string value);
        public event tickStringDelegate tickString;
        void EWrapper.tickString(int tickerId, int field, string value)
        {
            var t_tickString = this.tickString;
            if (t_tickString != null)
                InvokeIfRequired(t_tickString, tickerId, field, value);
        }

        public delegate void tickEFPDelegate(int tickerId, int field, double basisPoints, string formattedBasisPoints,
                     double totalDividends, int holdDays, string futureLastTradeDate, double dividendImpact,
                     double dividendsToLastTradeDate);
        public event tickEFPDelegate tickEFP;
        void EWrapper.tickEFP(int tickerId, int tickType, double basisPoints, string formattedBasisPoints, double impliedFuture, int holdDays, string futureLastTradeDate, double dividendImpact, double dividendsToLastTradeDate)
        {
            var t_tickEFP = this.tickEFP;
            if (t_tickEFP != null)
                InvokeIfRequired(t_tickEFP, tickerId, tickType, basisPoints, formattedBasisPoints, impliedFuture, holdDays, futureLastTradeDate, dividendImpact, dividendsToLastTradeDate);
        }

        public delegate void realtimeBarDelegate(int tickerId, int time, double open, double high, double low, double close,
                         int volume, double WAP, int count);
        public event realtimeBarDelegate realtimeBar;

        public delegate void currentTimeDelegate(int time);
        public event currentTimeDelegate currentTime;
        void EWrapper.currentTime(long time)
        {
            var t_currentTime = this.currentTime;
            if (t_currentTime != null)
                InvokeIfRequired(t_currentTime, (int)time);
        }

        public delegate void scannerDataEndDelegate(int reqId);
        public event scannerDataEndDelegate scannerDataEnd;
        void EWrapper.scannerDataEnd(int reqId)
        {
            var t_scannerDataEnd = this.scannerDataEnd;
            if (t_scannerDataEnd != null)
                InvokeIfRequired(t_scannerDataEnd, reqId);
        }

        public delegate void fundamentalDataDelegate(int reqId, string data);
        public event fundamentalDataDelegate fundamentalData;
        void EWrapper.fundamentalData(int reqId, string data)
        {
            var t_fundamentalData = this.fundamentalData;
            if (t_fundamentalData != null)
                InvokeIfRequired(t_fundamentalData, reqId, data);
        }

        public delegate void contractDetailsEndDelegate(int reqId);
        public event contractDetailsEndDelegate contractDetailsEnd;
        void EWrapper.contractDetailsEnd(int reqId)
        {
            var t_contractDetailsEnd = this.contractDetailsEnd;
            if (t_contractDetailsEnd != null)
                InvokeIfRequired(t_contractDetailsEnd, reqId);
        }

        public delegate void openOrderEndDelegate();
        public event openOrderEndDelegate openOrderEnd;
        void EWrapper.openOrderEnd()
        {
            var t_openOrderEnd = this.openOrderEnd;
            if (t_openOrderEnd != null)
                InvokeIfRequired(t_openOrderEnd);
        }

        public delegate void accountDownloadEndDelegate(string accountName);
        public event accountDownloadEndDelegate accountDownloadEnd;
        void EWrapper.accountDownloadEnd(string account)
        {
            var t_accountDownloadEnd = this.accountDownloadEnd;
            if (t_accountDownloadEnd != null)
                InvokeIfRequired(t_accountDownloadEnd, account);
        }

        public delegate void execDetailsEndDelegate(int reqId);
        public event execDetailsEndDelegate execDetailsEnd;
        void EWrapper.execDetailsEnd(int reqId)
        {
            var t_execDetailsEnd = this.execDetailsEnd;
            if (t_execDetailsEnd != null)
                InvokeIfRequired(t_execDetailsEnd, reqId);
        }

        public delegate void deltaNeutralValidationDelegate(int reqId, IUnderComp underComp);
        public event deltaNeutralValidationDelegate deltaNeutralValidation;
        void EWrapper.deltaNeutralValidation(int reqId, UnderComp underComp)
        {
            var t_deltaNeutralValidation = this.deltaNeutralValidation;
            if (t_deltaNeutralValidation != null)
                InvokeIfRequired(t_deltaNeutralValidation, reqId, (ComUnderComp)underComp);
        }

        public delegate void tickSnapshotEndDelegate(int reqId);
        public event tickSnapshotEndDelegate tickSnapshotEnd;
        void EWrapper.tickSnapshotEnd(int tickerId)
        {
            var t_tickSnapshotEnd = this.tickSnapshotEnd;
            if (t_tickSnapshotEnd != null)
                InvokeIfRequired(t_tickSnapshotEnd, tickerId);
        }

        public delegate void marketDataTypeDelegate(int reqId, int marketDataType);
        public event marketDataTypeDelegate marketDataType;
        void EWrapper.marketDataType(int reqId, int marketDataType)
        {
            var t_marketDataType = this.marketDataType;
            if (t_marketDataType != null)
                InvokeIfRequired(t_marketDataType, reqId, marketDataType);
        }

        public delegate void scannerDataExDelegate(int reqId, int rank, IContractDetails contractDetails, string distance, string benchmark, string projection, string legsStr);
        public event scannerDataExDelegate scannerDataEx;
        void EWrapper.scannerData(int reqId, int rank, ContractDetails contractDetails, string distance, string benchmark, string projection, string legsStr)
        {
            var t_scannerData = this.scannerData;
            if (t_scannerData != null)
                InvokeIfRequired(t_scannerData,
                                reqId,
                                rank,
                                contractDetails.Summary.Symbol,
                                distance,
                                contractDetails.Summary.LastTradeDateOrContractMonth,
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
                InvokeIfRequired(t_scannerDataEx, reqId, rank, (ComContractDetails)contractDetails, distance, benchmark, projection, legsStr);
        }

        public delegate void commissionReportDelegate(ICommissionReport commissionReport);
        public event commissionReportDelegate commissionReport;
        void EWrapper.commissionReport(CommissionReport commissionReport)
        {
            var t_commissionReport = this.commissionReport;
            if (t_commissionReport != null)
                InvokeIfRequired(t_commissionReport, (ComCommissionReport)commissionReport);
        }

        public delegate void positionDelegate(string account, IContract contract, double position, double avgCost);
        public event positionDelegate position;
        void EWrapper.position(string account, Contract contract, double pos, double avgCost)
        {
            var t_position = this.position;
            if (t_position != null)
                InvokeIfRequired(t_position, account, (ComContract)contract, pos, avgCost);
        }

        public delegate void positionEndDelegate();
        public event positionEndDelegate positionEnd;
        void EWrapper.positionEnd()
        {
            var t_positionEnd = this.positionEnd;
            if (t_positionEnd != null)
                InvokeIfRequired(t_positionEnd);
        }

        public delegate void accountSummaryDelegate(int reqId, string account, string tag, string value, string curency);
        public event accountSummaryDelegate accountSummary;
        void EWrapper.accountSummary(int reqId, string account, string tag, string value, string currency)
        {
            var t_accountSummary = this.accountSummary;
            if (t_accountSummary != null)
                InvokeIfRequired(t_accountSummary, reqId, account, tag, value, currency);
        }

        public delegate void accountSummaryEndDelegate(int reqId);
        public event accountSummaryEndDelegate accountSummaryEnd;
        void EWrapper.accountSummaryEnd(int reqId)
        {
            var t_accountSummaryEnd = this.accountSummaryEnd;
            if (t_accountSummaryEnd != null)
                InvokeIfRequired(t_accountSummaryEnd, reqId);
        }

        public delegate void verifyMessageAPIDelegate(string apiData);
        public event verifyMessageAPIDelegate verifyMessageAPI;
        void EWrapper.verifyMessageAPI(string apiData)
        {
            var t_verifyMessageAPI = this.verifyMessageAPI;
            if (t_verifyMessageAPI != null)
                InvokeIfRequired(t_verifyMessageAPI, apiData);
        }

        public delegate void verifyCompletedDelegate(bool isSuccessful, string errorText);
        public event verifyCompletedDelegate verifyCompleted;
        void EWrapper.verifyCompleted(bool isSuccessful, string errorText)
        {
            var t_verifyCompleted = this.verifyCompleted;
            if (t_verifyCompleted != null)
                InvokeIfRequired(t_verifyCompleted, isSuccessful, errorText);
        }

        public delegate void verifyAndAuthMessageAPIDelegate(string apiData, string xyzChallenge);
        public event verifyAndAuthMessageAPIDelegate verifyAndAuthMessageAPI;
        void EWrapper.verifyAndAuthMessageAPI(string apiData, string xyzChallenge)
        {
            var t_verifyAndAuthMessageAPI = this.verifyAndAuthMessageAPI;
            if (t_verifyAndAuthMessageAPI != null)
                InvokeIfRequired(t_verifyAndAuthMessageAPI, apiData, xyzChallenge);
        }

        public delegate void verifyAndAuthCompletedDelegate(bool isSuccessful, string errorText);
        public event verifyAndAuthCompletedDelegate verifyAndAuthCompleted;
        void EWrapper.verifyAndAuthCompleted(bool isSuccessful, string errorText)
        {
            var t_verifyAndAuthCompleted = this.verifyAndAuthCompleted;
            if (t_verifyAndAuthCompleted != null)
                InvokeIfRequired(t_verifyAndAuthCompleted, isSuccessful, errorText);
        }

        public delegate void displayGroupListDelegate(int reqId, string groups);
        public event displayGroupListDelegate displayGroupList;
        void EWrapper.displayGroupList(int reqId, string groups)
        {
            var t_displayGroupList = this.displayGroupList;
            if (t_displayGroupList != null)
                InvokeIfRequired(t_displayGroupList, reqId, groups);
        }

        public delegate void displayGroupUpdatedDelegate(int reqId, string contractInfo);
        public event displayGroupUpdatedDelegate displayGroupUpdated;
        void EWrapper.displayGroupUpdated(int reqId, string contractInfo)
        {
            var t_displayGroupUpdated = this.displayGroupUpdated;
            if (t_displayGroupUpdated != null)
                InvokeIfRequired(t_displayGroupUpdated, reqId, contractInfo);
        }

        public delegate void connectAckDelegate();
        public event connectAckDelegate connectAck;
        void EWrapper.connectAck()
        {
            var t_connectAck = this.connectAck;
            if (t_connectAck != null)
                InvokeIfRequired(t_connectAck);
        }

        public delegate void positionMultiDelegate(int requestId, string account, string modelCode, IContract contract, double position, double avgCost);
        public event positionMultiDelegate positionMulti;
        void EWrapper.positionMulti(int requestId, string account, string modelCode, Contract contract, double pos, double avgCost)
        {
            var t_positionMulti = this.positionMulti;
            if (t_positionMulti != null)
                InvokeIfRequired(t_positionMulti, requestId, account, modelCode, (ComContract)contract, pos, avgCost);
        }

        public delegate void positionMultiEndDelegate(int requestId);
        public event positionMultiEndDelegate positionMultiEnd;
        void EWrapper.positionMultiEnd(int requestId)
        {
            var t_positionMultiEnd = this.positionMultiEnd;
            if (t_positionMultiEnd != null)
                InvokeIfRequired(t_positionMultiEnd, requestId);
        }

        public delegate void accountUpdateMultiDelegate(int requestId, string account, string modelCode, string key, string value, string currency);
        public event accountUpdateMultiDelegate accountUpdateMulti;
        void EWrapper.accountUpdateMulti(int requestId, string account, string modelCode, string key, string value, string currency)
        {
            var t_accountUpdateMulti = this.accountUpdateMulti;
            if (t_accountUpdateMulti != null)
                InvokeIfRequired(t_accountUpdateMulti, requestId, account, modelCode, key, value, currency);
        }

        public delegate void accountUpdateMultiEndDelegate(int requestId);
        public event accountUpdateMultiEndDelegate accountUpdateMultiEnd;
        void EWrapper.accountUpdateMultiEnd(int requestId)
        {
            var t_accountUpdateMultiEnd = this.accountUpdateMultiEnd;
            if (t_accountUpdateMultiEnd != null)
                InvokeIfRequired(t_accountUpdateMultiEnd, requestId);
        }

        public delegate void securityDefinitionOptionParameterDelegate(int reqId, string exchange, int underlyingConId, string tradingClass, string multiplier, ArrayList expirations, ArrayList strikes);
        public event securityDefinitionOptionParameterDelegate securityDefinitionOptionParameter;
        void EWrapper.securityDefinitionOptionParameter(int reqId, string exchange, int underlyingConId, string tradingClass, string multiplier, HashSet<string> expirations, HashSet<double> strikes)
        {
            var t_securityDefinitionOptionParameter = this.securityDefinitionOptionParameter;
            if (t_securityDefinitionOptionParameter != null)
                InvokeIfRequired(t_securityDefinitionOptionParameter, reqId, exchange, underlyingConId, tradingClass, multiplier, new ArrayList(expirations.ToArray()), new ArrayList(strikes.ToArray()));
        }

        public delegate void securityDefinitionOptionParameterEndDelegate(int reqId);
        public event securityDefinitionOptionParameterEndDelegate securityDefinitionOptionParameterEnd;
        void EWrapper.securityDefinitionOptionParameterEnd(int reqId)
        {
            var t_securityDefinitionOptionParameterEnd = this.securityDefinitionOptionParameterEnd;
            if (t_securityDefinitionOptionParameterEnd != null)
                InvokeIfRequired(t_securityDefinitionOptionParameterEnd, reqId);
        }

        public delegate void softDollarTiersDelegate(int reqId, SoftDollarTier[] tiers);
        public event softDollarTiersDelegate softDollarTiers;
        void EWrapper.softDollarTiers(int reqId, SoftDollarTier[] tiers)
        {
            var t_softdollarTiers = this.softDollarTiers;

            if (t_softdollarTiers != null)
                InvokeIfRequired(t_softdollarTiers, reqId, tiers);
        }

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
 
        void EWrapper.tickOptionComputation(int tickerId, int field, double impliedVolatility, double delta, double optPrice, double pvDividend, double gamma, double vega, double theta, double undPrice)
        {
            var t_tickOptionComputation = this.tickOptionComputation;
            if (t_tickOptionComputation != null)
                InvokeIfRequired(t_tickOptionComputation, tickerId, field, impliedVolatility, delta, optPrice, pvDividend, gamma, vega, theta, undPrice);
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

        public void verifyAndAuthRequest(string apiName, string apiVersion, string opaqueIsvKey)
        {
            socket.verifyAndAuthRequest(apiName, apiVersion, opaqueIsvKey);
        }

        public void verifyAndAuthMessage(string apiData, string xyzResponse)
        {
            socket.verifyAndAuthMessage(apiData, xyzResponse);
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

        public void setConnectOptions(string connectOptions)
        {
            socket.SetConnectOptions(connectOptions);
        }

        public void disableUseV100Plus()
        {
            socket.DisableUseV100Plus();
        }

        public void startApi()
        {
            socket.startApi();
        }

        public void reqSecDefOptParams(int reqId, string underlyingSymbol, string futFopExchange, string underlyingSecType, int underlyingConId)
        {
            socket.reqSecDefOptParams(reqId, underlyingSymbol, futFopExchange, underlyingSecType, underlyingConId);
        }

        public void reqSoftDollarTiers(int reqId)
        {
            socket.reqSoftDollarTiers(reqId);
        }

        public ArrayList ParseConditions(string str)
        {
            var strConditions = str.Split(new[] { " or", " and" }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim());
            var conditions = strConditions.Select(c => OrderCondition.Parse(c)).ToArray();

            return new ArrayList(conditions);
        }

        public string ConditionsToString(object oConditions)
        {
            var conditions = (oConditions as ArrayList);
            var rval = "";

            if (conditions.Count > 0)
                rval = string.Join(" ", conditions.OfType<OrderCondition>().Take(conditions.Count - 1).Select(o => o + (o.IsConjunctionConnection ? " and" : " or")));

            if (conditions.Count > 1)
                rval += " " + conditions.OfType<OrderCondition>().Last();

            return rval;
        }
    }
}
