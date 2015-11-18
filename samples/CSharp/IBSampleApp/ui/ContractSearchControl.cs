using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IBApi;

namespace IBSampleApp.ui
{
    public partial class ContractSearchControl : Control
    {
        private ContractSearchDialog contractSearchDlg;

        public ContractSearchControl()
        {
            InitializeComponent();
        }

        private void clear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Contract = null;
        }

        private void searchContractLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (IBClient == null)
                throw new ArgumentNullException("IBClient");

            if (contractSearchDlg == null)
                contractSearchDlg = new ContractSearchDialog(null, IBClient);

            if (contractSearchDlg.ShowDialog() == DialogResult.OK)
                searchContractLink.Text = contractSearchDlg.ToString();
        }

        [Browsable(false)]
        public Contract Contract
        {
            get
            {
                return contractSearchDlg != null ? contractSearchDlg.Contract : null;
            }

            set
            {
                if (IBClient != null)
                {
                    if (value != null)
                    {
                        var task = IBClient.ResolveContractAsync(value.ConId, value.Exchange);

                        task.ContinueWith(t =>
                        {
                            value = t.Result;
                            contractSearchDlg = new ContractSearchDialog(value, IBClient);
                            searchContractLink.Text = value != null ? value.ToString() : "search...";
                        },
                        TaskScheduler.FromCurrentSynchronizationContext());
                    }
                    else
                    {
                        contractSearchDlg = null;
                        searchContractLink.Text = "search...";
                    }
                }
            }
        }

        [Browsable(false)]
        public IBClient IBClient { get; set; }
    }
}
