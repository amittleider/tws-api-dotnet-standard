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
    public class ComScannerSubscription : IScannerSubscription
    {
        ScannerSubscription data = new ScannerSubscription();

        public int NumberOfRows
        {
            get { return data.NumberOfRows; }
            set { data.NumberOfRows = value; }
        }
       
        public string Instrument
        {
            get { return data.Instrument; }
            set { data.Instrument = value; }
        }

        public string LocationCode
        {
            get { return data.LocationCode; }
            set { data.LocationCode = value; }
        }

        public string ScanCode
        {
            get { return data.ScanCode; }
            set { data.ScanCode = value; }
        }

        public double AbovePrice
        {
            get { return data.AbovePrice; }
            set { data.AbovePrice = value; }
        }

        public double BelowPrice
        {
            get { return data.BelowPrice; }
            set { data.BelowPrice = value; }
        }

        public int AboveVolume
        {
            get { return data.AboveVolume; }
            set { data.AboveVolume = value; }
        }

        public int AverageOptionVolumeAbove
        {
            get { return data.AverageOptionVolumeAbove; }
            set { data.AverageOptionVolumeAbove = value; }
        }

        public double MarketCapAbove
        {
            get { return data.MarketCapAbove; }
            set { data.MarketCapAbove = value; }
        }

        public double MarketCapBelow
        {
            get { return data.MarketCapBelow; }
            set { data.MarketCapBelow = value; }
        }

        public string MoodyRatingAbove
        {
            get { return data.MoodyRatingAbove; }
            set { data.MoodyRatingAbove = value; }
        }

        public string MoodyRatingBelow
        {
            get { return data.MoodyRatingBelow; }
            set { data.MoodyRatingBelow = value; }
        }

        public string SpRatingAbove
        {
            get { return data.SpRatingAbove; }
            set { data.SpRatingAbove = value; }
        }

        public string SpRatingBelow
        {
            get { return data.SpRatingBelow; }
            set { data.SpRatingBelow = value; }
        }

        public string MaturityDateAbove
        {
            get { return data.MaturityDateAbove; }
            set { data.MaturityDateAbove = value; }
        }

        public string MaturityDateBelow
        {
            get { return data.MaturityDateBelow; }
            set { data.MaturityDateBelow = value; }
        }

        public double CouponRateAbove
        {
            get { return data.CouponRateAbove; }
            set { data.CouponRateAbove = value; }
        }

        public double CouponRateBelow
        {
            get { return data.CouponRateBelow; }
            set { data.CouponRateBelow = value; }
        }

        public string ExcludeConvertible
        {
            get { return data.ExcludeConvertible; }
            set { data.ExcludeConvertible = value; }
        }

        public string ScannerSettingPairs
        {
            get { return data.ScannerSettingPairs; }
            set { data.ScannerSettingPairs = value; }
        }

        public string StockTypeFilter
        {
            get { return data.StockTypeFilter; }
            set { data.StockTypeFilter = value; }
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
            return new ComScannerSubscription() { data = ss };
        }

        public static explicit operator ScannerSubscription(ComScannerSubscription css)
        {
            return css.data;
        }
    }
}
