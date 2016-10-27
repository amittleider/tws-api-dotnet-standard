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
    [ComVisible(true), Guid("EE7BC342-8D86-4900-808A-B435A2C16F6C")]

    public interface IFamilyCodeList
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
        object Add(ComFamilyCode cfc);
    }

    [ComVisible(true)]
    public class ComFamilyCodeList : IFamilyCodeList
    {
        public ComList<ComFamilyCode, IBApi.FamilyCode> Fcl { get; private set; }

        public ComFamilyCodeList() : this(null) { }

        public ComFamilyCodeList(FamilyCode[] fcs)
        {
            this.Fcl = (fcs.Length > 0) ? new ComList<ComFamilyCode, IBApi.FamilyCode>(new List<IBApi.FamilyCode>(fcs)) : null;
        }

        public object _NewEnum
        {
            get { return Fcl.GetEnumerator(); }
        }

        public object this[int index]
        {
            get { return Fcl[index]; }
        }

        public int Count
        {
            get { return Fcl.Count; }
        }

        public object AddEmpty()
        {
            var rval = new ComFamilyCode();

            Fcl.Add(rval);

            return rval;
        }

        public object Add(ComFamilyCode cfc)
        {
            var rval = cfc;

            Fcl.Add(rval);

            return rval;
        }
    }
}
