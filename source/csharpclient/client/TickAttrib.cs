/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBApi
{
    public class TickAttrib
    {
        public bool CanAutoExecute { get; set; }

        public bool PastLimit { get; set; }

        public bool PreOpen { get; set; }

        public bool Unreported { get; set; }

        public bool BidPastLow { get; set; }

        public bool AskPastHigh { get; set; }
    }
}
