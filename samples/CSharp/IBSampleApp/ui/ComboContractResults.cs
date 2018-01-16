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

namespace IBSampleApp.ui
{
    partial class ComboContractResults : Form
    {
        public ComboContractResults()
        {
            InitializeComponent();
        }

        public void UpdateUI(ContractDetailsMessage message)
        {
            contractResults.Rows.Add(1);
            contractResults[0, contractResults.Rows.Count - 1].Value = message.ContractDetails.Contract.Symbol;
            contractResults[1, contractResults.Rows.Count - 1].Value = message.ContractDetails.Contract.Currency;
            contractResults[2, contractResults.Rows.Count - 1].Value = message.ContractDetails.Contract.Multiplier;
            contractResults[3, contractResults.Rows.Count - 1].Value = message.ContractDetails.Contract.Strike;
            contractResults[4, contractResults.Rows.Count - 1].Value = message.ContractDetails.Contract.Right;
            contractResults[5, contractResults.Rows.Count - 1].Value = message.ContractDetails.Contract.LastTradeDateOrContractMonth;
            contractResults[6, contractResults.Rows.Count - 1].Value = message.ContractDetails.Contract.ConId;
        }

        private void contractResultsClose_Click(object sender, EventArgs e)
        {
            contractResults.Rows.Clear();
            this.Visible = false;
        }

        private void addComboLeg_Click(object sender, EventArgs e)
        {
            int conId = (int)contractResults.SelectedRows[0].Cells[6].Value;
            this.Visible = false;
        }
    }
}
