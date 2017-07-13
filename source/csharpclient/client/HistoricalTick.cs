using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace IBApi
{
    [ComVisible(true)]
    public class HistoricalTick
    {
        public HistoricalTick(long time, double price, long size)
        {
            Time = time;
            Price = price;
            Size = size;
        }

        public long Time
        {
            [return: MarshalAs(UnmanagedType.I8)]
            get;
            [param: MarshalAs(UnmanagedType.I8)]
            private set;
        }
        public double Price { get; private set; }
        public long Size
        {
            [return: MarshalAs(UnmanagedType.I8)]
            get;
            [param: MarshalAs(UnmanagedType.I8)]
            private set;
        }
    }
}
