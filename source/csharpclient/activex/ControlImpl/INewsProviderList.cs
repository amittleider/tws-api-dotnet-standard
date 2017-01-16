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
    [ComVisible(true), Guid("66AF0F11-442F-42A2-AF44-016066AD1315")]

    public interface INewsProviderList
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
        object Add(ComNewsProvider cnp);
    }

    [ComVisible(true)]
    public class ComNewsProviderList : INewsProviderList
    {
        public ComList<ComNewsProvider, IBApi.NewsProvider> Npl { get; private set; }

        public ComNewsProviderList() : this(null) { }

        public ComNewsProviderList(NewsProvider[] nps)
        {
            this.Npl = (nps.Length > 0) ? new ComList<ComNewsProvider, IBApi.NewsProvider>(new List<IBApi.NewsProvider>(nps)) : null;
        }

        public object _NewEnum
        {
            get { return Npl.GetEnumerator(); }
        }

        public object this[int index]
        {
            get { return Npl[index]; }
        }

        public int Count
        {
            get { return Npl.Count; }
        }

        public object AddEmpty()
        {
            var rval = new ComNewsProvider();

            Npl.Add(rval);

            return rval;
        }

        public object Add(ComNewsProvider cnp)
        {
            var rval = cnp;

            Npl.Add(rval);

            return rval;
        }
    }
}
