/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace TWSLib
{
    [ComVisible(true), Guid("39F18DDF-687D-421d-8BB9-4F389D69E428")]
    public interface IOrderComboLegList
    {
        [DispId(-4)]
        object _NewEnum { [return: MarshalAs(UnmanagedType.IUnknown)] get; }
        [DispId(0)]
        object this[int index] { [return: MarshalAs(UnmanagedType.IDispatch)] get; }
        [DispId(1)]
        int Count { get; }
        [DispId(2)]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        object Add();
    }

    [ComVisible(true)]
    public class OrderComboLegList : IOrderComboLegList
    {
        public List<IBApi.OrderComboLeg> Ocl { get; private set; }

        public OrderComboLegList() : this(new List<IBApi.OrderComboLeg>()) { Ocl = new List<IBApi.OrderComboLeg>(); }

        public OrderComboLegList(List<IBApi.OrderComboLeg> ocl)
        {
            this.Ocl = ocl == null ? new List<IBApi.OrderComboLeg>() : ocl;
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
            var rval = new IBApi.OrderComboLeg();

            Ocl.Add(rval);

            return rval;
        }
    }
}
