/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace TWSLib
{
    [ComVisible(true), Guid("6BBE7E50-795D-4C45-A69E-E1EEB7918DD2")]
    public interface IScannerSubscription
    {
        [DispId(1)]
        string instrument { get; set; }
        [DispId(2)]
        string locations { get; set; }
        [DispId(3)]
        string scanCode { get; set; }
        [DispId(4)]
        int numberOfRows { get; set; }
        [DispId(100)]
        double priceAbove { get; set; }
        [DispId(101)]
        double priceBelow { get; set; }
        [DispId(102)]
        int volumeAbove { get; set; }
        [DispId(103)]
        int averageOptionVolumeAbove { get; set; }
        [DispId(104)]
        double marketCapAbove { get; set; }
        [DispId(105)]
        double marketCapBelow { get; set; }
        [DispId(106)]
        string moodyRatingAbove { get; set; }
        [DispId(107)]
        string moodyRatingBelow { get; set; }
        [DispId(108)]
        string spRatingAbove { get; set; }
        [DispId(109)]
        string spRatingBelow { get; set; }
        [DispId(110)]
        string maturityDateAbove { get; set; }
        [DispId(111)]
        string maturityDateBelow { get; set; }
        [DispId(112)]
        double couponRateAbove { get; set; }
        [DispId(113)]
        double couponRateBelow { get; set; }
        [DispId(114)]
        int excludeConvertible { get; set; }
        [DispId(115)]
        string scannerSettingPairs { get; set; }
        [DispId(116)]
        string stockTypeFilter { get; set; }
    }
}
