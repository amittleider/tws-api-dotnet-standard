using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace IBApi
{
	/**
     * @class HistoricalTickLast
     * @brief The historical tick's description. Used when requesting historical tick data with whatToShow = TRADES
     * @sa EClient, EWrapper
     */
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

		/**
         * @brief The UNIX timestamp of the historical tick 
         */
        public long Time
        {
            [return: MarshalAs(UnmanagedType.I8)]
            get;
            [param: MarshalAs(UnmanagedType.I8)]
            private set;
        }
		
		/**
         * @brief Mask
         */
        public int Mask { get; private set; }

		/**
         * @brief The last price of the historical tick 
         */
        public double Price { get; private set; }

		/**
         * @brief The last size of the historical tick 
         */
        public long Size
        {
            [return: MarshalAs(UnmanagedType.I8)]
            get;
            [param: MarshalAs(UnmanagedType.I8)]
            private set;
        }

		/**
         * @brief The source exchange of the historical tick 
         */
        public string Exchange { get; private set; }

		/**
         * @brief The conditions of the historical tick. Refer to Trade Conditions page for more details: https://www.interactivebrokers.com/en/index.php?f=7235
         */
        public string SpecialConditions { get; private set; }
    }
}
