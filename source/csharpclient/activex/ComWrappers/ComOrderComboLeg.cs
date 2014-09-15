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
     * @class OrderComboLeg
     * @brief Allows to specify a price on an order's leg
     * @sa Order, ComboLeg
     */
    [ComVisible(true)]
    public class ComOrderComboLeg : ComWrapper<OrderComboLeg>, IOrderComboLeg
    {
        /**
         * @brief The order's leg's price
         */
        public double Price
        {
            get { return data != null ? data.Price : default(double); }
            set { if (data != null) data.Price = value; }
        }

        public override bool Equals(Object other)
        {
            if (this == other)
            {
                return true;
            }
            else if (other == null)
            {
                return false;
            }

            OrderComboLeg theOther = (OrderComboLeg)other;

            if (Price != theOther.Price)
            {
                return false;
            }

            return true;
        }

        double IOrderComboLeg.price { get { return this.Price; } set { this.Price = value; } }

        public static explicit operator OrderComboLeg(ComOrderComboLeg coc)
        {
            return coc.ConvertTo();
        }

        public static explicit operator ComOrderComboLeg(OrderComboLeg ocl)
        {
            return new ComOrderComboLeg().ConvertFrom(ocl) as ComOrderComboLeg;
        }
    }
}
