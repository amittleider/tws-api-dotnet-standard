using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBApi;

namespace Samples
{
    public class OrderSamples
    {
        public static Order LimitOrder()
        {
            Order order = new Order();
            order.Action = "BUY";
            order.OrderType = "LMT";
            order.TotalQuantity = 100;
            order.Account = "DU74649";
            order.LmtPrice = 33.884;
            return order;
        }
    }
}
