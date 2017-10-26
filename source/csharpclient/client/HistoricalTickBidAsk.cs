using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace IBApi
{
	/**
     * @class HistoricalTickBidAsk
     * @brief The historical tick's description. Used when requesting historical tick data with whatToShow = BID_ASK
     * @sa EClient, EWrapper
     */
    [ComVisible(true)]
    public class HistoricalTickBidAsk
    {
        /**
         * @brief The UNIX timestamp of the historical tick 
         */
        public long Time 
        {
            [return:MarshalAs(UnmanagedType.I8)]
            get;
            [param:MarshalAs(UnmanagedType.I8)]
            private set; 
        }
		
		/**
         * @brief Mask
         */
        public int Mask { get; private set; }
		
		/**
         * @brief The bid price of the historical tick
         */
        public double PriceBid { get; private set; }
		
		/**
         * @brief The ask price of the historical tick 
         */
        public double PriceAsk { get; private set; }
		
		/**
         * @brief The bid size of the historical tick 
         */
        public long SizeBid
        {
            [return: MarshalAs(UnmanagedType.I8)]
            get;
            [param: MarshalAs(UnmanagedType.I8)]
            private set;
        }
		
		/**
         * @brief The ask size of the historical tick 
         */
        public long SizeAsk
        {
            [return: MarshalAs(UnmanagedType.I8)]
            get;
            [param: MarshalAs(UnmanagedType.I8)]
            private set;
        }

        public HistoricalTickBidAsk(long time, int mask, double priceBid, double priceAsk, long sizeBid, long sizeAsk)
        {
            Time = time;
            Mask = mask;
            PriceBid = priceBid;
            PriceAsk = priceAsk;
            SizeBid = sizeBid;
            SizeAsk = sizeAsk;
        }
    }
}
