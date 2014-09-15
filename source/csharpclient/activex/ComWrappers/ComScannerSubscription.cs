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
     * @class ScannerSubscription
     * @brief Defines a market scanner request
     */
    [ComVisible(true)]
    public class ComScannerSubscription : ComWrapper<ScannerSubscription>, IScannerSubscription
    {
        public int NumberOfRows
        {
            get { return data != null ? data.NumberOfRows : default(int); }
            set { if (data != null) data.NumberOfRows = value; }
        }
       
        public string Instrument
        {
            get { return data != null ? data.Instrument : default(string); }
            set { if (data != null) data.Instrument = value; }
        }

        public string LocationCode
        {
            get { return data != null ? data.LocationCode : default(string); }
            set { if (data != null) data.LocationCode = value; }
        }

        public string ScanCode
        {
            get { return data != null ? data.ScanCode : default(string); }
            set { if (data != null) data.ScanCode = value; }
        }

        public double AbovePrice
        {
            get { return data != null ? data.AbovePrice : default(double); }
            set { if (data != null) data.AbovePrice = value; }
        }

        public double BelowPrice
        {
            get { return data != null ? data.BelowPrice : default(double); }
            set { if (data != null) data.BelowPrice = value; }
        }

        public int AboveVolume
        {
            get { return data != null ? data.AboveVolume : default(int); }
            set { if (data != null) data.AboveVolume = value; }
        }

        public int AverageOptionVolumeAbove
        {
            get { return data != null ? data.AverageOptionVolumeAbove : default(int); }
            set { if (data != null) data.AverageOptionVolumeAbove = value; }
        }

        public double MarketCapAbove
        {
            get { return data != null ? data.MarketCapAbove : default(double); }
            set { if (data != null) data.MarketCapAbove = value; }
        }

        public double MarketCapBelow
        {
            get { return data != null ? data.MarketCapBelow : default(double); }
            set { if (data != null) data.MarketCapBelow = value; }
        }

        public string MoodyRatingAbove
        {
            get { return data != null ? data.MoodyRatingAbove : default(string); }
            set { if (data != null) data.MoodyRatingAbove = value; }
        }

        public string MoodyRatingBelow
        {
            get { return data != null ? data.MoodyRatingBelow : default(string); }
            set { if (data != null) data.MoodyRatingBelow = value; }
        }

        public string SpRatingAbove
        {
            get { return data != null ? data.SpRatingAbove : default(string); }
            set { if (data != null) data.SpRatingAbove = value; }
        }

        public string SpRatingBelow
        {
            get { return data != null ? data.SpRatingBelow : default(string); }
            set { if (data != null) data.SpRatingBelow = value; }
        }

        public string MaturityDateAbove
        {
            get { return data != null ? data.MaturityDateAbove : default(string); }
            set { if (data != null) data.MaturityDateAbove = value; }
        }

        public string MaturityDateBelow
        {
            get { return data != null ? data.MaturityDateBelow : default(string); }
            set { if (data != null) data.MaturityDateBelow = value; }
        }

        public double CouponRateAbove
        {
            get { return data != null ? data.CouponRateAbove : default(double); }
            set { if (data != null) data.CouponRateAbove = value; }
        }

        public double CouponRateBelow
        {
            get { return data != null ? data.CouponRateBelow : default(double); }
            set { if (data != null) data.CouponRateBelow = value; }
        }

        public string ExcludeConvertible
        {
            get { return data != null ? data.ExcludeConvertible : default(string); }
            set { if (data != null) data.ExcludeConvertible = value; }
        }

        public string ScannerSettingPairs
        {
            get { return data != null ? data.ScannerSettingPairs : default(string); }
            set { if (data != null) data.ScannerSettingPairs = value; }
        }

        public string StockTypeFilter
        {
            get { return data != null ? data.StockTypeFilter : default(string); }
            set { if (data != null) data.StockTypeFilter = value; }
        }

        string TWSLib.IScannerSubscription.instrument { get { return Instrument; } set { Instrument = value; } }

        string TWSLib.IScannerSubscription.locations { get { return LocationCode; } set { LocationCode = value; } }

        string TWSLib.IScannerSubscription.scanCode { get { return ScanCode; } set { ScanCode = value; } }

        int TWSLib.IScannerSubscription.numberOfRows { get { return NumberOfRows; } set { NumberOfRows = value; } }

        double TWSLib.IScannerSubscription.priceAbove { get { return AbovePrice; } set { AbovePrice = value; } }

        double TWSLib.IScannerSubscription.priceBelow { get { return BelowPrice; } set { BelowPrice = value; } }

        int TWSLib.IScannerSubscription.volumeAbove { get { return AboveVolume; } set { AboveVolume = value; } }

        int TWSLib.IScannerSubscription.averageOptionVolumeAbove { get { return AverageOptionVolumeAbove; } set { AverageOptionVolumeAbove = value; } }

        double TWSLib.IScannerSubscription.marketCapAbove { get { return MarketCapAbove; } set { MarketCapAbove = value; } }

        double TWSLib.IScannerSubscription.marketCapBelow { get { return MarketCapBelow; } set { MarketCapBelow = value; } }

        string TWSLib.IScannerSubscription.moodyRatingAbove { get { return MoodyRatingAbove; } set { MoodyRatingAbove = value; } }

        string TWSLib.IScannerSubscription.moodyRatingBelow { get { return MoodyRatingBelow; } set { MoodyRatingBelow = value; } }

        string TWSLib.IScannerSubscription.spRatingAbove { get { return SpRatingAbove; } set { SpRatingAbove = value; } }

        string TWSLib.IScannerSubscription.spRatingBelow { get { return SpRatingBelow; } set { SpRatingBelow = value; } }

        string TWSLib.IScannerSubscription.maturityDateAbove { get { return MaturityDateAbove; } set { MaturityDateAbove = value; } }

        string TWSLib.IScannerSubscription.maturityDateBelow { get { return MaturityDateBelow; } set { MaturityDateBelow = value; } }

        double TWSLib.IScannerSubscription.couponRateAbove { get { return CouponRateAbove; } set { CouponRateAbove = value; } }

        double TWSLib.IScannerSubscription.couponRateBelow { get { return CouponRateBelow; } set { CouponRateBelow = value; } }

        int TWSLib.IScannerSubscription.excludeConvertible
        {
            get { return string.IsNullOrEmpty(ExcludeConvertible) ? 0 : int.Parse(ExcludeConvertible); }
            set { ExcludeConvertible = value.ToString(); }
        }

        string TWSLib.IScannerSubscription.scannerSettingPairs { get { return ScannerSettingPairs; } set { ScannerSettingPairs = value; } }

        string TWSLib.IScannerSubscription.stockTypeFilter { get { return StockTypeFilter; } set { StockTypeFilter = value; } }

        public static explicit operator ComScannerSubscription(ScannerSubscription ss)
        {
            return new ComScannerSubscription().ConvertFrom(ss) as ComScannerSubscription;
        }

        public static explicit operator ScannerSubscription(ComScannerSubscription css)
        {
            return css.ConvertTo();
        }
    }
}
