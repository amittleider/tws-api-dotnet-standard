using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace TWSLib
{
    [ComVisible(true)]
    public class ComSoftDollarTier
    {
        private IBApi.Order order;

        public ComSoftDollarTier(IBApi.Order order)
        {
            this.order = order;
        }

        public string Name { get { return order.Tier.Name; } set { order.Tier = new IBApi.SoftDollarTier(value, order.Tier.Value, order.Tier.DisplayName); } }
        public string Value { get { return order.Tier.Value; } set { order.Tier = new IBApi.SoftDollarTier(order.Tier.Name, value, order.Tier.DisplayName); } }
    }
}
