/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace TWSLib
{
    [ComVisible(true), Guid("4428B613-9987-4B23-A7DC-DD6584EFF82A")]
    public interface IContractDescription
    {
        [DispId(1)]
        object contract { [return: MarshalAs(UnmanagedType.IDispatch)] get; }
        [DispId(2)]
        ArrayList DerivativeSecTypes { get; set; }
    }
}
