/* Copyright (C) 2017 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using IBApi;
using System.Collections;

namespace TWSLib
{
    [ComVisible(true), Guid("D85B33C9-7347-4C2A-AA85-DA9E34F27D10")]

    public interface IPriceIncrementList
    {
        [DispId(-4)]
        object _NewEnum { [return: MarshalAs(UnmanagedType.IUnknown)] get; }
        [DispId(0)]
        object this[int index] { [return: MarshalAs(UnmanagedType.IDispatch)] get; }
        [DispId(1)]
        int Count { get; }
        [DispId(2)]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        object AddEmpty();
        [DispId(3)]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        object Add(ComPriceIncrement cpi);
    }

    [ComVisible(true)]
    public class ComPriceIncrementList : IPriceIncrementList
    {
        public ComList<ComPriceIncrement, IBApi.PriceIncrement> PriceIncrementList { get; private set; }

        public ComPriceIncrementList() : this(null) { }

        public ComPriceIncrementList(PriceIncrement[] priceIncrements)
        {
            this.PriceIncrementList = (priceIncrements.Length > 0) ? new ComList<ComPriceIncrement, IBApi.PriceIncrement>(new List<IBApi.PriceIncrement>(priceIncrements)) : null;
        }

        public object _NewEnum
        {
            get { return PriceIncrementList.GetEnumerator(); }
        }

        public object this[int index]
        {
            get { return PriceIncrementList[index]; }
        }

        public int Count
        {
            get { return PriceIncrementList.Count; }
        }

        public object AddEmpty()
        {
            var rval = new ComPriceIncrement();

            PriceIncrementList.Add(rval);

            return rval;
        }

        public object Add(ComPriceIncrement comPriceIncrement)
        {
            var rval = comPriceIncrement;

            PriceIncrementList.Add(rval);

            return rval;
        }
    }
}
