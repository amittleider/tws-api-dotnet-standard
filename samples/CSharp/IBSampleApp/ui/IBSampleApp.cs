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
using IBSampleApp.ui;
using IBSampleApp.util;


namespace IBSampleApp
{
    public partial class IBSampleApp : Form
    {
        delegate void UpdateTextDelegate(string message, Control component);

        delegate void UpdateMessageBoxDelegate(string text);

        private MarketDataManager marketDataManager;
        private DeepBookManager deepBookManager;
        private HistoricalDataManager historicalDataManager;
        private RealTimeBarsManager realTimeBarManager;
        private ScannerManager scannerManager;
        private OrderDialog orderDialog;

        protected IBClient ibClient;

        private bool isConnected = false;

        public IBSampleApp()
        {
            InitializeComponent();
            ibClient = new IBClient(this);
            marketDataManager = new MarketDataManager(ibClient, marketDataGrid_MDT);
            deepBookManager = new DeepBookManager(ibClient, deepBookGrid);
            historicalDataManager = new HistoricalDataManager(ibClient, historicalChart, barsGrid);
            realTimeBarManager = new RealTimeBarsManager(ibClient, rtBarsChart, rtBarsGrid);
            scannerManager = new ScannerManager(ibClient, scannerGrid);
            orderDialog = new OrderDialog(ibClient);
        }

        private void connectLink_CT_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            
        }

        private void disconnectLink_CT_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ibClient.ClientSocket.eDisconnect();
        }

        public bool IsConnected
        {
            get { return isConnected; }
            set { isConnected = value; }
        }
        
        public void PostMessage(IBMessage message)
        {
            switch (message.Type)
            {
                case MessageType.Error:
                    {
                        AddMessage(message.ToString());
                        HandleErrorMessage((ErrorMessage)message);
                        break;
                    }
                case MessageType.TickPrice:
                case MessageType.TickSize:
                    {
                        marketDataManager.UpdateUI((MarketDataMessage)message);
                        break;
                    }
                case MessageType.MarketDepth:
                case MessageType.MarketDepthL2:
                    {
                        deepBookManager.UpdateUI(message);
                        break;
                    }
                case MessageType.HistoricalData:
                    {
                        historicalDataManager.UpdateUI(message);
                        break;
                    }
                case MessageType.RealTimeBars:
                    {
                        realTimeBarManager.UpdateUI(message);
                        break;
                    }
                case MessageType.ScannerData:
                    {
                        scannerManager.UpdateUI(message);
                        break;
                    }
                default:
                    {
                        AddMessage(message.ToString());
                        break;
                    }
            }
        }

        private void HandleErrorMessage(ErrorMessage message)
        {
            if (message.RequestId > MarketDataManager.TICK_ID_BASE && message.RequestId < DeepBookManager.TICK_ID_BASE)
                marketDataManager.NotifyError(message.RequestId);
            else if (message.RequestId > DeepBookManager.TICK_ID_BASE)
                deepBookManager.NotifyError(message.RequestId);
        }

        private void AddMessage(string text)
        {
            if (this.messageBox.InvokeRequired)
            {
                UpdateMessageBoxDelegate d = new UpdateMessageBoxDelegate(AddMessage);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.messageBox.Text += (text + "\r\n");
                messageBox.Select(messageBox.Text.Length, 0);
                messageBox.ScrollToCaret();
            }
        }

        
        public void NotifyConnection()
        {
            if (!isConnected)
            {
                NotifyUI("Disconnected...", status_CT);
                NotifyUI("Connect", connectButton);
            }
            else
            {
                NotifyUI("Connected!", status_CT);
                NotifyUI("Disconnect", connectButton);
            }
        }

        public void NotifyUI(string message, Control component)
        {
            if (component.InvokeRequired)
            {
                UpdateTextDelegate callback = new UpdateTextDelegate(NotifyUI);
                this.Invoke(callback, new object[] { message, component });
            }
            else
            {
                component.Text = message;
            }
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (!IsConnected)
            {
                int port, clientId;
                string host = this.host_CT.Text;

                if (host == null || host.Equals(""))
                    host = "127.0.0.1";
                try
                {
                    port = Int32.Parse(this.port_CT.Text);
                    clientId = Int32.Parse(this.clientid_CT.Text);
                    ibClient.ClientSocket.eConnect(host, port, clientId);
                }
                catch (Exception)
                {
                    AddMessage("Please check your connection attributes.");
                }
            }
            else
            {
                IsConnected = false;
                ibClient.ClientSocket.eDisconnect();
            }
        }

        private void marketData_Click(object sender, EventArgs e)
        {
            Contract contract = GetMDContract();
            marketDataManager.AddRequest(contract);
            ShowTab(marketData_MDT, topMarketDataTab_MDT);
        }

        private void closeMketDataTab_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            marketDataManager.StopActiveRequests();
            this.marketData_MDT.TabPages.Remove(topMarketDataTab_MDT);
        }

        private void deepBook_Click(object sender, EventArgs e)
        {
            Contract contract = GetMDContract();
            deepBookManager.AddRequest(contract);
            deepBookTab_MDT.Text = Utils.ContractToString(contract) + " (Book)";
            ShowTab(marketData_MDT, deepBookTab_MDT);
        }

        private void closeDeepBookLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            deepBookManager.StopActiveRequests();
            deepBookTab_MDT.Text = "";
            this.marketData_MDT.TabPages.Remove(deepBookTab_MDT);
        }

        private void histDataButton_Click(object sender, EventArgs e)
        {
            Contract contract = GetMDContract();
            string endTime = hdRequest_EndTime.Text.Trim();
            string duration = hdRequest_Duration.Text.Trim() + " " + hdRequest_TimeUnit.Text.Trim();
            string barSize = hdRequest_BarSize.Text.Trim();
            string whatToShow = hdRequest_WhatToShow.Text.Trim();
            historicalDataManager.AddRequest(contract, endTime, duration, barSize, whatToShow, 0, 1);
            historicalDataTab.Text = Utils.ContractToString(contract) + " (HD)";
            ShowTab(marketData_MDT, historicalDataTab);
        }

        private void histDataTabClose_MDT_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.marketData_MDT.TabPages.Remove(historicalDataTab);
        }

        private void realTime_Button_Click(object sender, EventArgs e)
        {
            Contract contract = GetMDContract();
            string whatToShow = hdRequest_WhatToShow.Text.Trim();
            realTimeBarManager.AddRequest(contract, whatToShow, true);
            rtBarsTab_MDT.Text = Utils.ContractToString(contract) + " (RTB)";
            ShowTab(marketData_MDT, rtBarsTab_MDT);
        }
        
        private void rtBarsCloseLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            realTimeBarManager.Clear();
            this.marketData_MDT.TabPages.Remove(rtBarsTab_MDT);
        }

        private void scannerRequest_Button_Click(object sender, EventArgs e)
        {
            ScannerSubscription subscription = new ScannerSubscription();
            subscription.ScanCode = scanCode.Text;
            subscription.Instrument = scanInstrument.Text;
            subscription.LocationCode = scanLocation.Text;
            subscription.StockTypeFilter = scanStockType.Text;
            subscription.NumberOfRows = Int32.Parse(scanNumRows.Text);
            scannerManager.AddRequest(subscription);
            ShowTab(marketData_MDT, scannerTab);
        }
        private void scannerTab_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            scannerManager.Clear();
            marketData_MDT.TabPages.Remove(scannerTab);
        }

        private double stringToDouble(string number)
        {
            if (number != null && !number.Equals(""))
                return Double.Parse(number);
            else
                return 0;
        }

        private Contract GetMDContract()
        {   
            Contract contract = new Contract();
            contract.SecType = this.secType_TMD_MDT.Text;
            contract.Symbol = this.symbol_TMD_MDT.Text;
            contract.Exchange = this.exchange_TMD_MDT.Text;
            contract.Currency = this.currency_TMD_MDT.Text;
            contract.Expiry = this.expiry_TMD_MDT.Text;

            contract.Strike = stringToDouble(this.strike_TMD_MDT.Text);
            contract.Multiplier = this.multiplier_TMD_MDT.Text;
            contract.LocalSymbol = this.localSymbol_TMD_MDT.Text;

            return contract;
        }

        private void messageBoxClear_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            messageBox.Clear();
        }

        private void ShowTab(TabControl tabControl, TabPage page)
        {
            if (!tabControl.Contains(page))
            {
                tabControl.TabPages.Add(page);
            }
            tabControl.SelectedTab = page;
        }

        private void executionsRefreshLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void newOrderLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            orderDialog.Visible = true;
        }

    }
}
