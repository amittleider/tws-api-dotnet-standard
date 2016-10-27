/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using IBApi;
using System.Collections;

namespace TWSLib
{
    [ComVisible(true), Guid("AEF9EE1F-CAA3-4D5D-9771-F606C0EFC886")]
    public interface IContractDescriptionList
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
        object Add(ComContract c, string[] derivativeSecTypes);
    }

    [ComVisible(true)]
    public class ComContractDescriptionList : IContractDescriptionList
    {
        public ComList<ComContractDescription, IBApi.ContractDescription> Cdl { get; private set; }

        public ComContractDescriptionList() : this(null) { }

        public ComContractDescriptionList(ContractDescription[] cds)
        {
            this.Cdl = (cds.Length > 0) ? new ComList<ComContractDescription, IBApi.ContractDescription>(new List<IBApi.ContractDescription>(cds)) : null;
        }

        public object _NewEnum
        {
            get { return Cdl.GetEnumerator(); }
        }

        public object this[int index]
        {
            get { return Cdl[index]; }
        }

        public int Count
        {
            get { return Cdl.Count; }
        }

        public object AddEmpty()
        {
            var rval = new ComContractDescription();

            Cdl.Add(rval);

            return rval;
        }

        public object Add(ComContract c, string[] derivativeSecTypes)
        {
            var rval = new ComContractDescription(c, derivativeSecTypes);

            Cdl.Add(rval);

            return rval;
        }
    }
}
