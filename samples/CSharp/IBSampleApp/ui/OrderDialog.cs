using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IBApi;

namespace IBSampleApp
{
    public partial class OrderDialog : Form
    {
        private IBClient ibClient;

        public OrderDialog(IBClient ibClient)
        {
            this.ibClient = ibClient;
            InitializeComponent();
        }

        private void sendOrderButton_Click(object sender, EventArgs e)
        {
            /*
            Contract contract = GetOrderContract();
            Order order = GetOrder();
            ibClient.ClientSocket.placeOrder(ibClient.NextOrderId, contract, order);
            ibClient.NextOrderId++;
             * */
            this.Visible = false;
        }

        private Contract GetOrderContract()
        {
            Contract contract = new Contract();
            contract.Symbol = "EUR";//orderSymbol.Text;
            contract.SecType = "CASH";
            contract.Currency = "USD";
            contract.Exchange = "IDEALPRO";
            return contract;
        }

        private Order GetOrder()
        {
            Order order = new Order();
            order.Action = "BUY";
            order.OrderType = "LMT";
            order.LmtPrice = 0.80;
            order.TotalQuantity = 20000;
            return order;
        }


    }
}
