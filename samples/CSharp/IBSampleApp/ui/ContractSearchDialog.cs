using IBApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IBSampleApp.ui
{
    public partial class ContractSearchDialog : Form
    {
        IBClient ibClient;
        List<Contract> contracts = new List<Contract>();

        public ContractSearchDialog(Contract c, IBClient ibClient)
        {
            InitializeComponent();

            this.ibClient = ibClient;
            Contract = c;

            if (c != null)
            {
                tbSymbol.Text = c.Symbol;
                tbExchange.Text = c.Exchange;
                tbCurrency.Text = c.Currency;
                cbSecType.Text = c.SecType;
            }
        }

        private async void btSearch_Click(object sender, EventArgs e)
        {
            btSearch.Enabled = false;

            contracts.Clear();
            contracts.AddRange(await ibClient.ResolveContractAsync(cbSecType.Text, tbSymbol.Text, tbCurrency.Text, tbExchange.Text));
            UpdateContractList();
        }

        private void UpdateContractList()
        {
            listBox.Items.Clear();
            listBox.Items.AddRange(contracts.Select(c => (object)c.ToString()).ToArray());

            btSearch.Enabled = true;
        }

        private void listBox_DoubleClick(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
                return;

            Contract = contracts[listBox.SelectedIndex];
            this.DialogResult = DialogResult.OK;

            Close();
        }

        public override string ToString()
        {
            if (listBox.SelectedIndex == -1 || Contract == null)
                return base.ToString();

            return Contract.ToString();
        }

        public Contract Contract { get; private set; }
    }
}
