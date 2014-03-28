/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBApi;

namespace IBSampleApp.messages
{
    public class OpenOrderMessage : OrderMessage
    {
        private Contract contract;
        private Order order;
        private OrderState orderState;

        public OpenOrderMessage(int orderId, Contract contract, Order order, OrderState orderState)
        {
            Type = MessageType.OpenOrder;
            OrderId = orderId;
            Contract = contract;
            Order = order;
            OrderState = orderState;
        }
        
        public Contract Contract
        {
            get { return contract; }
            set { contract = value; }
        }
        
        public Order Order
        {
            get { return order; }
            set { order = value; }
        }
        
        public OrderState OrderState
        {
            get { return orderState; }
            set { orderState = value; }
        }
        
    }
}
