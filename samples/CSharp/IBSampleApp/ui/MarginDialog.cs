/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IBSampleApp.messages;
using IBApi;

namespace IBSampleApp.ui
{
    public partial class MarginDialog : Form
    {
        delegate void UpdateMarginInformationDelegate(OrderState state);

        public MarginDialog()
        {
            InitializeComponent();
        }

        public void FillAndDisplay(OrderState state)
        {
            this.equityWithLoanResult.Text = state.EquityWithLoan.ToString();
            this.initialMarginResult.Text = state.InitMargin.ToString();
            this.maintenanceMarginResult.Text = state.MaintMargin.ToString();
        }

        public void UpdateMarginInformation(OrderState state)
        {
            FillAndDisplay(state);
            this.ShowDialog();  
        }

        private void acceptMarginButton_Click(object sender, EventArgs e)
        {
            this.equityWithLoanResult.Text = "";
            this.initialMarginResult.Text = "";
            this.maintenanceMarginResult.Text = "";
            this.Visible = false;
        }
    }
}
