/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
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
     * @brief Delta-Neutral Underlying Component.
     */
    [ComVisible(true)]
    public class ComUnderComp : IUnderComp
    {
        UnderComp data = new UnderComp();

        /**
         * @brief
         */
        public int ConId
        {
            get { return data.ConId; }
            set { data.ConId = value; }
        }

        /**
        * @brief
        */
        public double Delta
        {
            get { return data.Delta; }
            set { data.Delta = value; }
        }

        /**
        * @brief
        */
        public double Price
        {
            get { return data.Price; }
            set { data.Price = value; }
        }

        int TWSLib.IUnderComp.conId
        {
            get
            {
                return ConId;
            }
            set
            {
                ConId = value;
            }
        }

        double TWSLib.IUnderComp.delta
        {
            get
            {
                return Delta;
            }
            set
            {
                Delta = value;
            }
        }

        double TWSLib.IUnderComp.price
        {
            get
            {
                return Price;
            }
            set
            {
                Price = value;
            }
        }

        public static explicit operator ComUnderComp(UnderComp uc)
        {
            return new ComUnderComp() { data = uc };
        }

        public static explicit operator UnderComp(ComUnderComp cuc)
        {
            return cuc.data;
        }
    }
}
