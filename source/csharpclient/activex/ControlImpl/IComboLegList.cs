/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace TWSLib
{
    [ComVisible(true), Guid("BE3E5CD3-6F13-4D39-981C-4F75C063C2BA")]
    public interface IComboLegList
    {
        [DispId(-4)]
        object _NewEnum { [return:MarshalAs(UnmanagedType.IUnknown)] get; }
        [DispId(0)]
        object this[int index] { [return:MarshalAs(UnmanagedType.IDispatch)] get; }
        [DispId(1)]
        int Count { get; }
        [DispId(2)]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        object Add();
    }

    [ComVisible(true)]
    public class ComComboLegList : IComboLegList
    {
        public ComList<ComComboLeg, IBApi.ComboLeg> Ocl { get; private set; }

        public ComComboLegList() : this(null) { }

        public ComComboLegList(ComList<ComComboLeg, IBApi.ComboLeg> cbl) 
        {
            this.Ocl = cbl == null ? new ComList<ComComboLeg, IBApi.ComboLeg>(new List<IBApi.ComboLeg>()) : cbl;
        }

        public object _NewEnum
        {
            get { return Ocl.GetEnumerator(); }
        }

        public object this[int index]
        {
            get { return Ocl[index]; }
        }

        public int Count
        {
            get { return Ocl.Count; }
        }

        public object Add()
        {
            var rval = new ComComboLeg();

            Ocl.Add(rval);

            return rval;
        }
    }

}
