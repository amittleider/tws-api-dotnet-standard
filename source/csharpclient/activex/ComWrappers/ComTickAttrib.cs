/* Copyright (C) 2017 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using IBApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace TWSLib
{
    /**
     * @class TickAttrib
     * @brief Class describing tick attrib
     */
    [ComVisible(true)]
    public class ComTickAttrib : ComWrapper<TickAttrib>, ITickAttrib
    {
        /**
         * @brief canAutoExecute
         */
        bool CanAutoExecute
        {
            get { return data != null ? data.CanAutoExecute : default(bool); }
            set { if (data != null) data.CanAutoExecute = value; }
        }

        /**
         * @brief pastLimit
         */
        bool PastLimit
        {
            get { return data != null ? data.PastLimit : default(bool); }
            set { if (data != null) data.PastLimit = value; }
        }

        /**
         * @brief preOpen
         */
        bool PreOpen
        {
            get { return data != null ? data.PreOpen : default(bool); }
            set { if (data != null) data.PreOpen = value; }
        }

        /**
         * @brief unreported
         */
        bool Unreported
        {
            get { return data != null ? data.Unreported : default(bool); }
            set { if (data != null) data.Unreported = value; }
        }

        /**
         * @brief bidPastlow
         */
        bool BidPastLow
        {
            get { return data != null ? data.BidPastLow : default(bool); }
            set { if (data != null) data.BidPastLow = value; }
        }

        /**
         * @brief askPastHigh
         */
        bool AskPastHigh
        {
            get { return data != null ? data.AskPastHigh : default(bool); }
            set { if (data != null) data.AskPastHigh = value; }
        }

        public ComTickAttrib()
        {
        }

        public static explicit operator TickAttrib(ComTickAttrib cta)
        {
            return cta.ConvertTo();
        }

        public static explicit operator ComTickAttrib(TickAttrib ta)
        {
            return new ComTickAttrib().ConvertFrom(ta) as ComTickAttrib;
        }

        bool TWSLib.ITickAttrib.canAutoExecute { get { return CanAutoExecute; } set { CanAutoExecute = value; } }
        bool TWSLib.ITickAttrib.pastLimit { get { return PastLimit; } set { PastLimit = value; } }
        bool TWSLib.ITickAttrib.preOpen { get { return PreOpen; } set { PreOpen = value; } }
        bool TWSLib.ITickAttrib.unreported { get { return Unreported; } set { Unreported = value; } }
        bool TWSLib.ITickAttrib.bidPastLow { get { return BidPastLow; } set { BidPastLow = value; } }
        bool TWSLib.ITickAttrib.askPastHigh { get { return AskPastHigh; } set { AskPastHigh = value; } }

    }
}
