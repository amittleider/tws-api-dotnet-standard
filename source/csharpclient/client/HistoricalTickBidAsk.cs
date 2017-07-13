using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace IBApi
{
    [ComVisible(true)]
    public class HistoricalTickBidAsk
    {
        
        public long Time 
        {
            [return:MarshalAs(UnmanagedType.I8)]
            get;
            [param:MarshalAs(UnmanagedType.I8)]
            private set; 
        }
        public int Mask { get; private set; }
        public double PriceBid { get; private set; }
        public double PriceAsk { get; private set; }
        public long SizeBid
        {
            [return: MarshalAs(UnmanagedType.I8)]
            get;
            [param: MarshalAs(UnmanagedType.I8)]
            private set;
        }
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
