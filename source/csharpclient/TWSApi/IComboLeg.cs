/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace IBApi.TWSApi
{
    [Guid("573E95CF-F67C-4367-A95B-CB7599BD0673"), ComVisible(true)]
    public interface IComboLeg
    {
        [DispId(1)]
        int conId { get; set; }
        [DispId(2)]
        int ratio { get; set; }
        [DispId(3)]
        string action { get; set; }
        [DispId(4)]
        string exchange { get; set; }
        [DispId(5)]
        int openClose { get; set; }
        [DispId(6)]
        int shortSaleSlot { get; set; }
        [DispId(7)]
        string designatedLocation { get; set; }
        [DispId(8)]
        int exemptCode { get; set; }
    };
}
