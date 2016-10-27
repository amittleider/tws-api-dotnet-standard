/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBApi;

namespace IBSamples
{
    public class ScannerSubscriptionSamples
    {
        public static ScannerSubscription HotUSStkByVolume()
        {
            //! [hotusvolume]
            //Hot US stocks by volume
            ScannerSubscription scanSub = new ScannerSubscription();
            scanSub.Instrument = "STK";
            scanSub.LocationCode = "STK.US.MAJOR";
            scanSub.ScanCode = "HOT_BY_VOLUME";
            //! [hotusvolume]
            return scanSub;
        }

        public static ScannerSubscription TopPercentGainersIbis()
        {
            //! [toppercentgaineribis]
            //Top % gainers at IBIS
            ScannerSubscription scanSub = new ScannerSubscription();
            scanSub.Instrument = "STOCK.EU";
            scanSub.LocationCode = "STK.EU.IBIS";
            scanSub.ScanCode = "TOP_PERC_GAIN";
            //! [toppercentgaineribis]
            return scanSub;
        }

        public static ScannerSubscription MostActiveFutSoffex()
        {
            //! [mostactivefutsoffex]
            //Most active futures at SOFFEX
            ScannerSubscription scanSub = new ScannerSubscription();
            scanSub.Instrument = "FUT.EU";
            scanSub.LocationCode = "FUT.EU.SOFFEX";
            scanSub.ScanCode = "MOST_ACTIVE";
            //! [mostactivefutsoffex]
            return scanSub;
        }

        public static ScannerSubscription HighOptVolumePCRatioUSIndexes()
        {
            //! [highoptvolume]
            //High option volume P/C ratio US indexes
            ScannerSubscription scanSub = new ScannerSubscription();
            scanSub.Instrument = "IND.US";
            scanSub.LocationCode = "IND.US";
            scanSub.ScanCode = "HIGH_OPT_VOLUME_PUT_CALL_RATIO";
            //! [highoptvolume]
            return scanSub;
        }
    }
}
