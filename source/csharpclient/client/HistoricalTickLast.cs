using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace IBApi
{
    [ComVisible(true)]
    public class HistoricalTickLast
    {
        public HistoricalTickLast(long time, int mask, double price, long size, string exchange, string specialConditions)
        {
            Time = time;
            Mask = mask;
            Price = price;
            Size = size;
            Exchange = exchange;
            SpecialConditions = specialConditions;
        }

        public long Time
        {
            [return: MarshalAs(UnmanagedType.I8)]
            get;
            [param: MarshalAs(UnmanagedType.I8)]
            private set;
        }

        public int Mask { get; private set; }

        public double Price { get; private set; }

        public long Size
        {
            [return: MarshalAs(UnmanagedType.I8)]
            get;
            [param: MarshalAs(UnmanagedType.I8)]
            private set;
        }

        public string Exchange { get; private set; }

        public string SpecialConditions { get; private set; }
    }
}
