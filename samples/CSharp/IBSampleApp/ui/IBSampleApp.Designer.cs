/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using IBSampleApp.types;
using System.Data;
namespace IBSampleApp
{
    partial class IBSampleAppDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            ibClient.ClientSocket.eDisconnect();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IBSampleAppDialog));
            this.TabControl = new System.Windows.Forms.TabControl();
            this.marketDataTab = new System.Windows.Forms.TabPage();
            this.marketData_MDT = new System.Windows.Forms.TabControl();
            this.topMarketDataTab_MDT = new System.Windows.Forms.TabPage();
            this.closeMketDataTab = new System.Windows.Forms.LinkLabel();
            this.marketDataGrid_MDT = new System.Windows.Forms.DataGridView();
            this.marketDataContract = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bidSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bidPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.askPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.askSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closeTickerColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deepBookTab_MDT = new System.Windows.Forms.TabPage();
            this.closeDeepBookLink = new System.Windows.Forms.LinkLabel();
            this.deepBookGrid = new System.Windows.Forms.DataGridView();
            this.bidBookMaker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bidBookSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bidBookPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.askBookPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.askBookSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.askBookMaker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historicalDataTab = new System.Windows.Forms.TabPage();
            this.histDataTabClose_MDT = new System.Windows.Forms.LinkLabel();
            this.barsGrid = new System.Windows.Forms.DataGridView();
            this.hdDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hdOpen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hdHigh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hdLow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hdClose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hdVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hdWap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historicalChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.rtBarsTab_MDT = new System.Windows.Forms.TabPage();
            this.rtBarsCloseLink = new System.Windows.Forms.LinkLabel();
            this.rtBarsGrid = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rtBarsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.scannerTab = new System.Windows.Forms.TabPage();
            this.scannerTab_link = new System.Windows.Forms.LinkLabel();
            this.scannerGrid = new System.Windows.Forms.DataGridView();
            this.scanRank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scanContract = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scanDistance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scanBenchmark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scanProjection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scanLegStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scannerParamsTab = new System.Windows.Forms.TabPage();
            this.scannerParamsOutput = new System.Windows.Forms.TextBox();
            this.dataResults_MDT = new System.Windows.Forms.TabControl();
            this.topMktData_MDT = new System.Windows.Forms.TabPage();
            this.deepBookGroupBox = new System.Windows.Forms.GroupBox();
            this.deepBookEntries = new System.Windows.Forms.TextBox();
            this.deepBookEntriesLabel = new System.Windows.Forms.Label();
            this.deepBook_Button = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cancelMarketDataRequests = new System.Windows.Forms.Button();
            this.primaryExchange = new System.Windows.Forms.TextBox();
            this.primaryExchLabel = new System.Windows.Forms.Label();
            this.genericTickList = new System.Windows.Forms.TextBox();
            this.genericTickListLabel = new System.Windows.Forms.Label();
            this.mdRightLabel = new System.Windows.Forms.Label();
            this.mdContractRight = new System.Windows.Forms.ComboBox();
            this.putcall_label_TMD_MDT = new System.Windows.Forms.Label();
            this.multiplier_TMD_MDT = new System.Windows.Forms.TextBox();
            this.symbol_label_TMD_MDT = new System.Windows.Forms.Label();
            this.marketData_Button = new System.Windows.Forms.Button();
            this.secType_TMD_MDT = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.exchange_label_TMD_MDT = new System.Windows.Forms.Label();
            this.localSymbol_TMD_MDT = new System.Windows.Forms.TextBox();
            this.currency_label_TMD_MDT = new System.Windows.Forms.Label();
            this.lastTradeDateOrContractMonth_TMD_MDT = new System.Windows.Forms.TextBox();
            this.symbol_TMD_MDT = new System.Windows.Forms.TextBox();
            this.strike_TMD_MDT = new System.Windows.Forms.TextBox();
            this.currency_TMD_MDT = new System.Windows.Forms.TextBox();
            this.exchange_TMD_MDT = new System.Windows.Forms.TextBox();
            this.localSymbol_label_TMD_MDT = new System.Windows.Forms.Label();
            this.lastTradeDate_label_TMD_MDT = new System.Windows.Forms.Label();
            this.strike_label_TMD_MDT = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.contractMDRTH = new System.Windows.Forms.CheckBox();
            this.realTime_Button = new System.Windows.Forms.Button();
            this.histData_Button = new System.Windows.Forms.Button();
            this.hdEndDate_label_HDT = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.hdRequest_EndTime = new System.Windows.Forms.TextBox();
            this.hdRequest_WhatToShow = new System.Windows.Forms.ComboBox();
            this.hdRequest_Duration = new System.Windows.Forms.TextBox();
            this.includeExpired = new System.Windows.Forms.CheckBox();
            this.hdRequest_BarSize = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.hdRequest_TimeUnit = new System.Windows.Forms.ComboBox();
            this.marketScanner_MDT = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.scanCode = new System.Windows.Forms.ComboBox();
            this.scanInstrument = new System.Windows.Forms.ComboBox();
            this.scannerRequest_Button = new System.Windows.Forms.Button();
            this.scanLocation = new System.Windows.Forms.ComboBox();
            this.scanStockType = new System.Windows.Forms.ComboBox();
            this.scanNumRows = new System.Windows.Forms.TextBox();
            this.scanNumRows_label = new System.Windows.Forms.Label();
            this.scanCode_label = new System.Windows.Forms.Label();
            this.scanStockType_label = new System.Windows.Forms.Label();
            this.scanInstrument_label = new System.Windows.Forms.Label();
            this.scanLocation_label = new System.Windows.Forms.Label();
            this.scannerParamsRequest_button = new System.Windows.Forms.Button();
            this.tradingTab = new System.Windows.Forms.TabPage();
            this.execFilterGroup = new System.Windows.Forms.GroupBox();
            this.execFilterExchange = new System.Windows.Forms.TextBox();
            this.execFilterSide = new System.Windows.Forms.TextBox();
            this.execFilterSideLabel = new System.Windows.Forms.Label();
            this.execFilterExchangeLabel = new System.Windows.Forms.Label();
            this.execFilterSecTypeLabel = new System.Windows.Forms.Label();
            this.execFilterSymbolLabel = new System.Windows.Forms.Label();
            this.execFilterTimeLabel = new System.Windows.Forms.Label();
            this.execFilterAcctLabel = new System.Windows.Forms.Label();
            this.execFilterClientLabel = new System.Windows.Forms.Label();
            this.execFilterSecType = new System.Windows.Forms.TextBox();
            this.execFilterSymbol = new System.Windows.Forms.TextBox();
            this.execFilterTime = new System.Windows.Forms.TextBox();
            this.execFilterAccount = new System.Windows.Forms.TextBox();
            this.execFilterClientId = new System.Windows.Forms.TextBox();
            this.refreshExecutionsButton = new System.Windows.Forms.Button();
            this.globalCancelButton = new System.Windows.Forms.Button();
            this.clientOrdersButton = new System.Windows.Forms.Button();
            this.refreshOrdersButton = new System.Windows.Forms.Button();
            this.cancelOrdersButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.newOrderLink = new System.Windows.Forms.LinkLabel();
            this.executionsGroup = new System.Windows.Forms.GroupBox();
            this.tradeLogGrid = new System.Windows.Forms.DataGridView();
            this.ExecutionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimeExecColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountExecColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actionExecColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityExecColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionExecColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceExecColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commissionExecColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RealisedPnL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.liveOrdersGroup = new System.Windows.Forms.GroupBox();
            this.liveOrdersGrid = new System.Windows.Forms.DataGridView();
            this.permIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contractColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountInfoTab = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.accSummaryTab = new System.Windows.Forms.TabPage();
            this.accSummaryRequest = new System.Windows.Forms.Button();
            this.accSummaryGrid = new System.Windows.Forms.DataGridView();
            this.tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountSummaryAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accUpdatesTab = new System.Windows.Forms.TabPage();
            this.accUpdatesSubscribedAccount = new System.Windows.Forms.Label();
            this.accUpdatesAccountLabel = new System.Windows.Forms.Label();
            this.accUpdatesLastUpdateValue = new System.Windows.Forms.Label();
            this.accountPortfolioGrid = new System.Windows.Forms.DataGridView();
            this.updatePortfolioContract = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updatePortfolioPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updatePortfolioMarketPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updatePortfolioMarketValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updatePortfolioAvgCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updatePortfolioUnrealisedPnL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updatePortfolioRealisedPnL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountValuesGrid = new System.Windows.Forms.DataGridView();
            this.accUpdatesKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accUpdatesValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accUpdatesCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accUpdatesSubscribe = new System.Windows.Forms.Button();
            this.lastUpdatedLabel = new System.Windows.Forms.Label();
            this.positionsTab = new System.Windows.Forms.TabPage();
            this.positionRequest = new System.Windows.Forms.Button();
            this.positionsGrid = new System.Windows.Forms.DataGridView();
            this.positionContract = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positionAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positionPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positionAvgCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountSelectorLabel = new System.Windows.Forms.Label();
            this.accountSelector = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.underlyingConId = new System.Windows.Forms.TextBox();
            this.queryOptionParams = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.queryOptionChain = new System.Windows.Forms.Button();
            this.optionChainUseSnapshot = new System.Windows.Forms.CheckBox();
            this.optionChainOptionExchangeLabel = new System.Windows.Forms.Label();
            this.optionChainExchange = new System.Windows.Forms.TextBox();
            this.contractFundamentalsGroupBox = new System.Windows.Forms.GroupBox();
            this.fundamentalsQueryButton = new System.Windows.Forms.Button();
            this.fundamentalsReportTypeLabel = new System.Windows.Forms.Label();
            this.fundamentalsReportType = new System.Windows.Forms.ComboBox();
            this.contractDetailsGroupBox = new System.Windows.Forms.GroupBox();
            this.searchContractDetails = new System.Windows.Forms.Button();
            this.conDetSymbolLabel = new System.Windows.Forms.Label();
            this.conDetRightLabel = new System.Windows.Forms.Label();
            this.conDetStrikeLabel = new System.Windows.Forms.Label();
            this.conDetRight = new System.Windows.Forms.ComboBox();
            this.conDetLastTradeDateLabel = new System.Windows.Forms.Label();
            this.conDetSecType = new System.Windows.Forms.ComboBox();
            this.conDetMultiplierLabel = new System.Windows.Forms.Label();
            this.conDetSecTypeLabel = new System.Windows.Forms.Label();
            this.conDetLocalSymbolLabel = new System.Windows.Forms.Label();
            this.conDetExchangeLabel = new System.Windows.Forms.Label();
            this.conDetExchange = new System.Windows.Forms.TextBox();
            this.conDetLocalSymbol = new System.Windows.Forms.TextBox();
            this.conDetMultiplier = new System.Windows.Forms.TextBox();
            this.conDetCurrencyLabel = new System.Windows.Forms.Label();
            this.conDetCurrency = new System.Windows.Forms.TextBox();
            this.conDetLastTradeDateOrContractMonth = new System.Windows.Forms.TextBox();
            this.conDetStrike = new System.Windows.Forms.TextBox();
            this.conDetSymbol = new System.Windows.Forms.TextBox();
            this.contractInfoTab = new System.Windows.Forms.TabControl();
            this.contractDetailsPage = new System.Windows.Forms.TabPage();
            this.contractDetailsGrid = new System.Windows.Forms.DataGridView();
            this.conResSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conResLocalSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conResSecType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conResCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conResExchange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conResPrimaryExch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conResLastTradeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conResMultiplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conResStrike = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conResRight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conResConId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fundamentalsPage = new System.Windows.Forms.TabPage();
            this.fundamentalsOutput = new System.Windows.Forms.TextBox();
            this.optionChainPage = new System.Windows.Forms.TabPage();
            this.optionChainCallGroup = new System.Windows.Forms.GroupBox();
            this.optionChainCallGrid = new System.Windows.Forms.DataGridView();
            this.callLastTradeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.callStrike = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.callBid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.callAsk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.callImpliedVolatility = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.callDelta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.callGamma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.callVega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.callTheta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optionChainPutGroup = new System.Windows.Forms.GroupBox();
            this.optionChainPutGrid = new System.Windows.Forms.DataGridView();
            this.putLastTradeDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.putStrike = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.putBid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.putAsk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.putImpliedVolatility = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.putDelta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.putGamma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.putVega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.putTheta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optionParametersPage = new System.Windows.Forms.TabPage();
            this.listViewOptionParams = new System.Windows.Forms.ListView();
            this.advisorTab = new System.Windows.Forms.TabPage();
            this.advisorProfilesBox = new System.Windows.Forms.GroupBox();
            this.saveProfiles = new System.Windows.Forms.Button();
            this.loadProfiles = new System.Windows.Forms.Button();
            this.advisorProfilesGrid = new System.Windows.Forms.DataGridView();
            this.profileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profileType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.profileAllocations = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.advisorGroupsBox = new System.Windows.Forms.GroupBox();
            this.saveGroups = new System.Windows.Forms.Button();
            this.loadGroups = new System.Windows.Forms.Button();
            this.advisorGroupsGrid = new System.Windows.Forms.DataGridView();
            this.groupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupMethod = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.groupAccounts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.advisorAliasesBox = new System.Windows.Forms.GroupBox();
            this.loadAliases = new System.Windows.Forms.Button();
            this.advisorAliasesGrid = new System.Windows.Forms.DataGridView();
            this.advisorAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.advisorAlias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optionsTab = new System.Windows.Forms.TabPage();
            this.optionExchange = new System.Windows.Forms.TextBox();
            this.optionExchangeLabel = new System.Windows.Forms.Label();
            this.optionsQuantityLabel = new System.Windows.Forms.Label();
            this.optionsPositionsGroupBox = new System.Windows.Forms.GroupBox();
            this.optionPositionsGrid = new System.Windows.Forms.DataGridView();
            this.optionContract = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optionAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optionPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optionMarketPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optionMarketValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optionAverageCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optionUnrealisedPnL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optionRealisedPnL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optionExerciseQuan = new System.Windows.Forms.TextBox();
            this.overrideOption = new System.Windows.Forms.CheckBox();
            this.lapseOption = new System.Windows.Forms.Button();
            this.exerciseOption = new System.Windows.Forms.Button();
            this.exerciseAccountLabel = new System.Windows.Forms.Label();
            this.exerciseAccount = new System.Windows.Forms.ComboBox();
            this.acctPosTab = new System.Windows.Forms.TabPage();
            this.acctPosMultiPanel = new System.Windows.Forms.TabControl();
            this.tabPositionsMulti = new System.Windows.Forms.TabPage();
            this.clearPositionsMulti = new System.Windows.Forms.LinkLabel();
            this.positionsMultiGrid = new System.Windows.Forms.DataGridView();
            this.accountPositionsMulti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelCodePositionsMulti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contractPositionsMulti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positionPositionsMulti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avgCostPositionsMulti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabAccountUpdatesMulti = new System.Windows.Forms.TabPage();
            this.clearAccountUpdatesMulti = new System.Windows.Forms.LinkLabel();
            this.accountUpdatesMultiGrid = new System.Windows.Forms.DataGridView();
            this.accountAccountUpdatesMulti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelCodeAccountUpdatesMulti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyAccountUpdatesMulti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueAccountUpdatesMulti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currencyAccountUpdatesMulti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxRequestData = new System.Windows.Forms.GroupBox();
            this.buttonCancelAccountUpdatesMulti = new System.Windows.Forms.Button();
            this.buttonCancelPositionsMulti = new System.Windows.Forms.Button();
            this.buttonRequestAccountUpdatesMulti = new System.Windows.Forms.Button();
            this.cbLedgerAndNLV = new System.Windows.Forms.CheckBox();
            this.labelAccount = new System.Windows.Forms.Label();
            this.buttonRequestPositionsMulti = new System.Windows.Forms.Button();
            this.labelModelCode = new System.Windows.Forms.Label();
            this.textAccount = new System.Windows.Forms.TextBox();
            this.textModelCode = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.clientid_CT = new System.Windows.Forms.TextBox();
            this.cliet_label_CT = new System.Windows.Forms.Label();
            this.port_CT = new System.Windows.Forms.TextBox();
            this.port_label_CT = new System.Windows.Forms.Label();
            this.host_label_CT = new System.Windows.Forms.Label();
            this.host_CT = new System.Windows.Forms.TextBox();
            this.comboTab = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.comboDeltaNeutralBox = new System.Windows.Forms.GroupBox();
            this.comboDeltaNeutralSet = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboLegsBox = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboLegAction = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.comboLegRatio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboLegDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboLegPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboContractBox = new System.Windows.Forms.GroupBox();
            this.findComboContract = new System.Windows.Forms.LinkLabel();
            this.comboSymbolLabel = new System.Windows.Forms.Label();
            this.comboSymbol = new System.Windows.Forms.TextBox();
            this.comboStrike = new System.Windows.Forms.TextBox();
            this.comboRightLabel = new System.Windows.Forms.Label();
            this.comboLastTradeDate = new System.Windows.Forms.TextBox();
            this.comboStrikeLabel = new System.Windows.Forms.Label();
            this.comboCurrency = new System.Windows.Forms.TextBox();
            this.comboRight = new System.Windows.Forms.ComboBox();
            this.comboCurrencyLabel = new System.Windows.Forms.Label();
            this.comboLastTradeDateLabel = new System.Windows.Forms.Label();
            this.comboMultiplier = new System.Windows.Forms.TextBox();
            this.comboSecType = new System.Windows.Forms.ComboBox();
            this.comboLocalSymbol = new System.Windows.Forms.TextBox();
            this.comboMultiplierLabel = new System.Windows.Forms.Label();
            this.comboExchange = new System.Windows.Forms.TextBox();
            this.comboSecTypeLabel = new System.Windows.Forms.Label();
            this.comboExchangeLabel = new System.Windows.Forms.Label();
            this.comboLocalSymbolLabel = new System.Windows.Forms.Label();
            this.status_CT = new System.Windows.Forms.Label();
            this.status_label_CT = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.messagesTab = new System.Windows.Forms.TabPage();
            this.messageBoxClear_link = new System.Windows.Forms.LinkLabel();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.informationTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.ib_banner = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TabControl.SuspendLayout();
            this.marketDataTab.SuspendLayout();
            this.marketData_MDT.SuspendLayout();
            this.topMarketDataTab_MDT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.marketDataGrid_MDT)).BeginInit();
            this.deepBookTab_MDT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deepBookGrid)).BeginInit();
            this.historicalDataTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.historicalChart)).BeginInit();
            this.rtBarsTab_MDT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rtBarsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtBarsChart)).BeginInit();
            this.scannerTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scannerGrid)).BeginInit();
            this.scannerParamsTab.SuspendLayout();
            this.dataResults_MDT.SuspendLayout();
            this.topMktData_MDT.SuspendLayout();
            this.deepBookGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.marketScanner_MDT.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tradingTab.SuspendLayout();
            this.execFilterGroup.SuspendLayout();
            this.executionsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tradeLogGrid)).BeginInit();
            this.liveOrdersGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.liveOrdersGrid)).BeginInit();
            this.accountInfoTab.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.accSummaryTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accSummaryGrid)).BeginInit();
            this.accUpdatesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accountPortfolioGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountValuesGrid)).BeginInit();
            this.positionsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.positionsGrid)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.contractFundamentalsGroupBox.SuspendLayout();
            this.contractDetailsGroupBox.SuspendLayout();
            this.contractInfoTab.SuspendLayout();
            this.contractDetailsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contractDetailsGrid)).BeginInit();
            this.fundamentalsPage.SuspendLayout();
            this.optionChainPage.SuspendLayout();
            this.optionChainCallGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optionChainCallGrid)).BeginInit();
            this.optionChainPutGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optionChainPutGrid)).BeginInit();
            this.optionParametersPage.SuspendLayout();
            this.advisorTab.SuspendLayout();
            this.advisorProfilesBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advisorProfilesGrid)).BeginInit();
            this.advisorGroupsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advisorGroupsGrid)).BeginInit();
            this.advisorAliasesBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advisorAliasesGrid)).BeginInit();
            this.optionsTab.SuspendLayout();
            this.optionsPositionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optionPositionsGrid)).BeginInit();
            this.acctPosTab.SuspendLayout();
            this.acctPosMultiPanel.SuspendLayout();
            this.tabPositionsMulti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.positionsMultiGrid)).BeginInit();
            this.tabAccountUpdatesMulti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accountUpdatesMultiGrid)).BeginInit();
            this.groupBoxRequestData.SuspendLayout();
            this.comboTab.SuspendLayout();
            this.comboDeltaNeutralBox.SuspendLayout();
            this.comboLegsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.comboContractBox.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.messagesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ib_banner)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl.Controls.Add(this.marketDataTab);
            this.TabControl.Controls.Add(this.tradingTab);
            this.TabControl.Controls.Add(this.accountInfoTab);
            this.TabControl.Controls.Add(this.tabPage1);
            this.TabControl.Controls.Add(this.advisorTab);
            this.TabControl.Controls.Add(this.optionsTab);
            this.TabControl.Controls.Add(this.acctPosTab);
            this.TabControl.Location = new System.Drawing.Point(0, 68);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(1256, 474);
            this.TabControl.TabIndex = 7;
            // 
            // marketDataTab
            // 
            this.marketDataTab.BackColor = System.Drawing.Color.LightGray;
            this.marketDataTab.Controls.Add(this.marketData_MDT);
            this.marketDataTab.Controls.Add(this.dataResults_MDT);
            this.marketDataTab.Location = new System.Drawing.Point(4, 22);
            this.marketDataTab.Name = "marketDataTab";
            this.marketDataTab.Padding = new System.Windows.Forms.Padding(3);
            this.marketDataTab.Size = new System.Drawing.Size(1248, 448);
            this.marketDataTab.TabIndex = 1;
            this.marketDataTab.Text = "Data";
            // 
            // marketData_MDT
            // 
            this.marketData_MDT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.marketData_MDT.Controls.Add(this.topMarketDataTab_MDT);
            this.marketData_MDT.Controls.Add(this.deepBookTab_MDT);
            this.marketData_MDT.Controls.Add(this.historicalDataTab);
            this.marketData_MDT.Controls.Add(this.rtBarsTab_MDT);
            this.marketData_MDT.Controls.Add(this.scannerTab);
            this.marketData_MDT.Controls.Add(this.scannerParamsTab);
            this.marketData_MDT.Location = new System.Drawing.Point(0, 210);
            this.marketData_MDT.Margin = new System.Windows.Forms.Padding(0);
            this.marketData_MDT.Name = "marketData_MDT";
            this.marketData_MDT.SelectedIndex = 0;
            this.marketData_MDT.Size = new System.Drawing.Size(1242, 235);
            this.marketData_MDT.TabIndex = 1;
            // 
            // topMarketDataTab_MDT
            // 
            this.topMarketDataTab_MDT.BackColor = System.Drawing.Color.LightGray;
            this.topMarketDataTab_MDT.Controls.Add(this.closeMketDataTab);
            this.topMarketDataTab_MDT.Controls.Add(this.marketDataGrid_MDT);
            this.topMarketDataTab_MDT.Location = new System.Drawing.Point(4, 22);
            this.topMarketDataTab_MDT.Name = "topMarketDataTab_MDT";
            this.topMarketDataTab_MDT.Padding = new System.Windows.Forms.Padding(3);
            this.topMarketDataTab_MDT.Size = new System.Drawing.Size(1234, 209);
            this.topMarketDataTab_MDT.TabIndex = 0;
            this.topMarketDataTab_MDT.Text = "Market Data";
            // 
            // closeMketDataTab
            // 
            this.closeMketDataTab.AutoSize = true;
            this.closeMketDataTab.Location = new System.Drawing.Point(6, 3);
            this.closeMketDataTab.Name = "closeMketDataTab";
            this.closeMketDataTab.Size = new System.Drawing.Size(31, 13);
            this.closeMketDataTab.TabIndex = 1;
            this.closeMketDataTab.TabStop = true;
            this.closeMketDataTab.Text = "Clear";
            this.closeMketDataTab.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.closeMketDataTab_LinkClicked);
            // 
            // marketDataGrid_MDT
            // 
            this.marketDataGrid_MDT.AllowUserToAddRows = false;
            this.marketDataGrid_MDT.AllowUserToDeleteRows = false;
            this.marketDataGrid_MDT.AllowUserToOrderColumns = true;
            this.marketDataGrid_MDT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.marketDataGrid_MDT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.marketDataGrid_MDT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.marketDataContract,
            this.bidSize,
            this.bidPrice,
            this.askPrice,
            this.askSize,
            this.lastPrice,
            this.volume,
            this.closeTickerColumn});
            this.marketDataGrid_MDT.Location = new System.Drawing.Point(3, 19);
            this.marketDataGrid_MDT.Name = "marketDataGrid_MDT";
            this.marketDataGrid_MDT.ReadOnly = true;
            this.marketDataGrid_MDT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.marketDataGrid_MDT.Size = new System.Drawing.Size(966, 184);
            this.marketDataGrid_MDT.TabIndex = 0;
            this.marketDataGrid_MDT.Visible = false;
            // 
            // marketDataContract
            // 
            this.marketDataContract.HeaderText = "Description";
            this.marketDataContract.Name = "marketDataContract";
            this.marketDataContract.ReadOnly = true;
            this.marketDataContract.Width = 200;
            // 
            // bidSize
            // 
            this.bidSize.HeaderText = "Bid Size";
            this.bidSize.Name = "bidSize";
            this.bidSize.ReadOnly = true;
            // 
            // bidPrice
            // 
            this.bidPrice.HeaderText = "Bid";
            this.bidPrice.Name = "bidPrice";
            this.bidPrice.ReadOnly = true;
            // 
            // askPrice
            // 
            this.askPrice.HeaderText = "Ask";
            this.askPrice.Name = "askPrice";
            this.askPrice.ReadOnly = true;
            // 
            // askSize
            // 
            this.askSize.HeaderText = "Ask Size";
            this.askSize.Name = "askSize";
            this.askSize.ReadOnly = true;
            // 
            // lastPrice
            // 
            this.lastPrice.HeaderText = "Last Size";
            this.lastPrice.Name = "lastPrice";
            this.lastPrice.ReadOnly = true;
            // 
            // volume
            // 
            this.volume.HeaderText = "Volume";
            this.volume.Name = "volume";
            this.volume.ReadOnly = true;
            // 
            // closeTickerColumn
            // 
            this.closeTickerColumn.HeaderText = "Close";
            this.closeTickerColumn.Name = "closeTickerColumn";
            this.closeTickerColumn.ReadOnly = true;
            this.closeTickerColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.closeTickerColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // deepBookTab_MDT
            // 
            this.deepBookTab_MDT.BackColor = System.Drawing.Color.LightGray;
            this.deepBookTab_MDT.Controls.Add(this.closeDeepBookLink);
            this.deepBookTab_MDT.Controls.Add(this.deepBookGrid);
            this.deepBookTab_MDT.Location = new System.Drawing.Point(4, 22);
            this.deepBookTab_MDT.Name = "deepBookTab_MDT";
            this.deepBookTab_MDT.Padding = new System.Windows.Forms.Padding(3);
            this.deepBookTab_MDT.Size = new System.Drawing.Size(1234, 209);
            this.deepBookTab_MDT.TabIndex = 1;
            this.deepBookTab_MDT.Text = "Deep Book";
            // 
            // closeDeepBookLink
            // 
            this.closeDeepBookLink.AutoSize = true;
            this.closeDeepBookLink.Location = new System.Drawing.Point(6, 3);
            this.closeDeepBookLink.Name = "closeDeepBookLink";
            this.closeDeepBookLink.Size = new System.Drawing.Size(33, 13);
            this.closeDeepBookLink.TabIndex = 1;
            this.closeDeepBookLink.TabStop = true;
            this.closeDeepBookLink.Text = "Close";
            this.closeDeepBookLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.closeDeepBookLink_LinkClicked);
            // 
            // deepBookGrid
            // 
            this.deepBookGrid.AllowUserToAddRows = false;
            this.deepBookGrid.AllowUserToDeleteRows = false;
            this.deepBookGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deepBookGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.deepBookGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bidBookMaker,
            this.bidBookSize,
            this.bidBookPrice,
            this.askBookPrice,
            this.askBookSize,
            this.askBookMaker});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.deepBookGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.deepBookGrid.Location = new System.Drawing.Point(4, 19);
            this.deepBookGrid.Name = "deepBookGrid";
            this.deepBookGrid.ReadOnly = true;
            this.deepBookGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.deepBookGrid.Size = new System.Drawing.Size(1224, 184);
            this.deepBookGrid.TabIndex = 0;
            // 
            // bidBookMaker
            // 
            this.bidBookMaker.HeaderText = "Market Maker";
            this.bidBookMaker.Name = "bidBookMaker";
            this.bidBookMaker.ReadOnly = true;
            // 
            // bidBookSize
            // 
            this.bidBookSize.HeaderText = "Bid Size";
            this.bidBookSize.Name = "bidBookSize";
            this.bidBookSize.ReadOnly = true;
            // 
            // bidBookPrice
            // 
            this.bidBookPrice.HeaderText = "Bid Price";
            this.bidBookPrice.Name = "bidBookPrice";
            this.bidBookPrice.ReadOnly = true;
            // 
            // askBookPrice
            // 
            this.askBookPrice.HeaderText = "Ask Price";
            this.askBookPrice.Name = "askBookPrice";
            this.askBookPrice.ReadOnly = true;
            // 
            // askBookSize
            // 
            this.askBookSize.HeaderText = "Ask Size";
            this.askBookSize.Name = "askBookSize";
            this.askBookSize.ReadOnly = true;
            // 
            // askBookMaker
            // 
            this.askBookMaker.HeaderText = "Market Maker";
            this.askBookMaker.Name = "askBookMaker";
            this.askBookMaker.ReadOnly = true;
            // 
            // historicalDataTab
            // 
            this.historicalDataTab.BackColor = System.Drawing.Color.LightGray;
            this.historicalDataTab.Controls.Add(this.histDataTabClose_MDT);
            this.historicalDataTab.Controls.Add(this.barsGrid);
            this.historicalDataTab.Controls.Add(this.historicalChart);
            this.historicalDataTab.Location = new System.Drawing.Point(4, 22);
            this.historicalDataTab.Name = "historicalDataTab";
            this.historicalDataTab.Padding = new System.Windows.Forms.Padding(3);
            this.historicalDataTab.Size = new System.Drawing.Size(1234, 209);
            this.historicalDataTab.TabIndex = 0;
            this.historicalDataTab.Text = "Historical Bars";
            // 
            // histDataTabClose_MDT
            // 
            this.histDataTabClose_MDT.AutoSize = true;
            this.histDataTabClose_MDT.Location = new System.Drawing.Point(6, 3);
            this.histDataTabClose_MDT.Name = "histDataTabClose_MDT";
            this.histDataTabClose_MDT.Size = new System.Drawing.Size(33, 13);
            this.histDataTabClose_MDT.TabIndex = 2;
            this.histDataTabClose_MDT.TabStop = true;
            this.histDataTabClose_MDT.Text = "Close";
            this.histDataTabClose_MDT.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.histDataTabClose_MDT_LinkClicked);
            // 
            // barsGrid
            // 
            this.barsGrid.AllowUserToAddRows = false;
            this.barsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.barsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.barsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hdDate,
            this.hdOpen,
            this.hdHigh,
            this.hdLow,
            this.hdClose,
            this.hdVolume,
            this.hdWap});
            this.barsGrid.Location = new System.Drawing.Point(3, 19);
            this.barsGrid.Name = "barsGrid";
            this.barsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.barsGrid.Size = new System.Drawing.Size(504, 184);
            this.barsGrid.TabIndex = 1;
            // 
            // hdDate
            // 
            this.hdDate.HeaderText = "Date";
            this.hdDate.Name = "hdDate";
            this.hdDate.ReadOnly = true;
            this.hdDate.Width = 80;
            // 
            // hdOpen
            // 
            this.hdOpen.HeaderText = "Open";
            this.hdOpen.Name = "hdOpen";
            this.hdOpen.ReadOnly = true;
            this.hdOpen.Width = 60;
            // 
            // hdHigh
            // 
            this.hdHigh.HeaderText = "High";
            this.hdHigh.Name = "hdHigh";
            this.hdHigh.ReadOnly = true;
            this.hdHigh.Width = 60;
            // 
            // hdLow
            // 
            this.hdLow.HeaderText = "Low";
            this.hdLow.Name = "hdLow";
            this.hdLow.ReadOnly = true;
            this.hdLow.Width = 60;
            // 
            // hdClose
            // 
            this.hdClose.HeaderText = "Close";
            this.hdClose.Name = "hdClose";
            this.hdClose.ReadOnly = true;
            this.hdClose.Width = 60;
            // 
            // hdVolume
            // 
            this.hdVolume.HeaderText = "Volume";
            this.hdVolume.Name = "hdVolume";
            this.hdVolume.ReadOnly = true;
            this.hdVolume.Width = 60;
            // 
            // hdWap
            // 
            this.hdWap.HeaderText = "WAP";
            this.hdWap.Name = "hdWap";
            this.hdWap.ReadOnly = true;
            this.hdWap.Width = 60;
            // 
            // historicalChart
            // 
            this.historicalChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.historicalChart.BackColor = System.Drawing.Color.LightGray;
            this.historicalChart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.historicalChart.BackImageTransparentColor = System.Drawing.Color.Silver;
            this.historicalChart.BackSecondaryColor = System.Drawing.Color.Silver;
            chartArea3.AxisX.MajorGrid.Enabled = false;
            chartArea3.AxisX.MajorTickMark.Enabled = false;
            chartArea3.AxisY.IsStartedFromZero = false;
            chartArea3.Name = "ChartArea1";
            chartArea3.Position.Auto = false;
            chartArea3.Position.Height = 100F;
            chartArea3.Position.Width = 100F;
            this.historicalChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.historicalChart.Legends.Add(legend3);
            this.historicalChart.Location = new System.Drawing.Point(529, 3);
            this.historicalChart.Name = "historicalChart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series3.IsVisibleInLegend = false;
            series3.IsXValueIndexed = true;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series3.YValuesPerPoint = 4;
            this.historicalChart.Series.Add(series3);
            this.historicalChart.Size = new System.Drawing.Size(699, 200);
            this.historicalChart.TabIndex = 0;
            this.historicalChart.Text = "Historical Data";
            // 
            // rtBarsTab_MDT
            // 
            this.rtBarsTab_MDT.BackColor = System.Drawing.Color.LightGray;
            this.rtBarsTab_MDT.Controls.Add(this.rtBarsCloseLink);
            this.rtBarsTab_MDT.Controls.Add(this.rtBarsGrid);
            this.rtBarsTab_MDT.Controls.Add(this.rtBarsChart);
            this.rtBarsTab_MDT.Location = new System.Drawing.Point(4, 22);
            this.rtBarsTab_MDT.Name = "rtBarsTab_MDT";
            this.rtBarsTab_MDT.Padding = new System.Windows.Forms.Padding(3);
            this.rtBarsTab_MDT.Size = new System.Drawing.Size(1234, 209);
            this.rtBarsTab_MDT.TabIndex = 2;
            this.rtBarsTab_MDT.Text = "RT Bars";
            // 
            // rtBarsCloseLink
            // 
            this.rtBarsCloseLink.AutoSize = true;
            this.rtBarsCloseLink.Location = new System.Drawing.Point(6, 4);
            this.rtBarsCloseLink.Name = "rtBarsCloseLink";
            this.rtBarsCloseLink.Size = new System.Drawing.Size(33, 13);
            this.rtBarsCloseLink.TabIndex = 4;
            this.rtBarsCloseLink.TabStop = true;
            this.rtBarsCloseLink.Text = "Close";
            this.rtBarsCloseLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.rtBarsCloseLink_LinkClicked);
            // 
            // rtBarsGrid
            // 
            this.rtBarsGrid.AllowUserToAddRows = false;
            this.rtBarsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rtBarsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rtBarsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.rtBarsGrid.Location = new System.Drawing.Point(5, 20);
            this.rtBarsGrid.Name = "rtBarsGrid";
            this.rtBarsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.rtBarsGrid.Size = new System.Drawing.Size(504, 184);
            this.rtBarsGrid.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Date";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Open";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 60;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "High";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Low";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 60;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Close";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 60;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Volume";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 60;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "WAP";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 60;
            // 
            // rtBarsChart
            // 
            this.rtBarsChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtBarsChart.BackColor = System.Drawing.Color.LightGray;
            this.rtBarsChart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rtBarsChart.BackImageTransparentColor = System.Drawing.Color.Silver;
            this.rtBarsChart.BackSecondaryColor = System.Drawing.Color.Silver;
            chartArea4.AxisX.MajorGrid.Enabled = false;
            chartArea4.AxisX.MajorTickMark.Enabled = false;
            chartArea4.AxisY.IsStartedFromZero = false;
            chartArea4.Name = "ChartArea1";
            chartArea4.Position.Auto = false;
            chartArea4.Position.Height = 100F;
            chartArea4.Position.Width = 100F;
            this.rtBarsChart.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.rtBarsChart.Legends.Add(legend4);
            this.rtBarsChart.Location = new System.Drawing.Point(531, 4);
            this.rtBarsChart.Name = "rtBarsChart";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series4.IsVisibleInLegend = false;
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series4.YValuesPerPoint = 4;
            this.rtBarsChart.Series.Add(series4);
            this.rtBarsChart.Size = new System.Drawing.Size(699, 200);
            this.rtBarsChart.TabIndex = 2;
            this.rtBarsChart.Text = "Historical Data";
            // 
            // scannerTab
            // 
            this.scannerTab.BackColor = System.Drawing.Color.LightGray;
            this.scannerTab.Controls.Add(this.scannerTab_link);
            this.scannerTab.Controls.Add(this.scannerGrid);
            this.scannerTab.Location = new System.Drawing.Point(4, 22);
            this.scannerTab.Name = "scannerTab";
            this.scannerTab.Padding = new System.Windows.Forms.Padding(3);
            this.scannerTab.Size = new System.Drawing.Size(1234, 209);
            this.scannerTab.TabIndex = 3;
            this.scannerTab.Text = "Scanner Results";
            // 
            // scannerTab_link
            // 
            this.scannerTab_link.AutoSize = true;
            this.scannerTab_link.Location = new System.Drawing.Point(6, 3);
            this.scannerTab_link.Name = "scannerTab_link";
            this.scannerTab_link.Size = new System.Drawing.Size(33, 13);
            this.scannerTab_link.TabIndex = 1;
            this.scannerTab_link.TabStop = true;
            this.scannerTab_link.Text = "Close";
            this.scannerTab_link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.scannerTab_link_LinkClicked);
            // 
            // scannerGrid
            // 
            this.scannerGrid.AllowUserToAddRows = false;
            this.scannerGrid.AllowUserToDeleteRows = false;
            this.scannerGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.scannerGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.scanRank,
            this.scanContract,
            this.scanDistance,
            this.scanBenchmark,
            this.scanProjection,
            this.scanLegStr});
            this.scannerGrid.Location = new System.Drawing.Point(4, 28);
            this.scannerGrid.Name = "scannerGrid";
            this.scannerGrid.ReadOnly = true;
            this.scannerGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.scannerGrid.Size = new System.Drawing.Size(765, 157);
            this.scannerGrid.TabIndex = 0;
            // 
            // scanRank
            // 
            this.scanRank.HeaderText = "Rank";
            this.scanRank.Name = "scanRank";
            this.scanRank.ReadOnly = true;
            // 
            // scanContract
            // 
            this.scanContract.HeaderText = "Contract";
            this.scanContract.Name = "scanContract";
            this.scanContract.ReadOnly = true;
            this.scanContract.Width = 200;
            // 
            // scanDistance
            // 
            this.scanDistance.HeaderText = "Distance";
            this.scanDistance.Name = "scanDistance";
            this.scanDistance.ReadOnly = true;
            // 
            // scanBenchmark
            // 
            this.scanBenchmark.HeaderText = "Benchmark";
            this.scanBenchmark.Name = "scanBenchmark";
            this.scanBenchmark.ReadOnly = true;
            // 
            // scanProjection
            // 
            this.scanProjection.HeaderText = "Projection";
            this.scanProjection.Name = "scanProjection";
            this.scanProjection.ReadOnly = true;
            // 
            // scanLegStr
            // 
            this.scanLegStr.HeaderText = "Legs";
            this.scanLegStr.Name = "scanLegStr";
            this.scanLegStr.ReadOnly = true;
            // 
            // scannerParamsTab
            // 
            this.scannerParamsTab.BackColor = System.Drawing.Color.LightGray;
            this.scannerParamsTab.Controls.Add(this.scannerParamsOutput);
            this.scannerParamsTab.Location = new System.Drawing.Point(4, 22);
            this.scannerParamsTab.Name = "scannerParamsTab";
            this.scannerParamsTab.Padding = new System.Windows.Forms.Padding(3);
            this.scannerParamsTab.Size = new System.Drawing.Size(1234, 209);
            this.scannerParamsTab.TabIndex = 4;
            this.scannerParamsTab.Text = "Scanner Parameters";
            // 
            // scannerParamsOutput
            // 
            this.scannerParamsOutput.BackColor = System.Drawing.SystemColors.Control;
            this.scannerParamsOutput.Location = new System.Drawing.Point(4, 6);
            this.scannerParamsOutput.Multiline = true;
            this.scannerParamsOutput.Name = "scannerParamsOutput";
            this.scannerParamsOutput.ReadOnly = true;
            this.scannerParamsOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.scannerParamsOutput.Size = new System.Drawing.Size(1224, 179);
            this.scannerParamsOutput.TabIndex = 0;
            // 
            // dataResults_MDT
            // 
            this.dataResults_MDT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataResults_MDT.Controls.Add(this.topMktData_MDT);
            this.dataResults_MDT.Controls.Add(this.marketScanner_MDT);
            this.dataResults_MDT.Location = new System.Drawing.Point(0, 0);
            this.dataResults_MDT.Name = "dataResults_MDT";
            this.dataResults_MDT.SelectedIndex = 0;
            this.dataResults_MDT.Size = new System.Drawing.Size(1238, 226);
            this.dataResults_MDT.TabIndex = 0;
            // 
            // topMktData_MDT
            // 
            this.topMktData_MDT.BackColor = System.Drawing.Color.LightGray;
            this.topMktData_MDT.Controls.Add(this.deepBookGroupBox);
            this.topMktData_MDT.Controls.Add(this.groupBox2);
            this.topMktData_MDT.Controls.Add(this.groupBox1);
            this.topMktData_MDT.Location = new System.Drawing.Point(4, 22);
            this.topMktData_MDT.Name = "topMktData_MDT";
            this.topMktData_MDT.Padding = new System.Windows.Forms.Padding(3);
            this.topMktData_MDT.Size = new System.Drawing.Size(1230, 200);
            this.topMktData_MDT.TabIndex = 0;
            this.topMktData_MDT.Text = "Market Data";
            // 
            // deepBookGroupBox
            // 
            this.deepBookGroupBox.Controls.Add(this.deepBookEntries);
            this.deepBookGroupBox.Controls.Add(this.deepBookEntriesLabel);
            this.deepBookGroupBox.Controls.Add(this.deepBook_Button);
            this.deepBookGroupBox.Location = new System.Drawing.Point(826, 6);
            this.deepBookGroupBox.Name = "deepBookGroupBox";
            this.deepBookGroupBox.Size = new System.Drawing.Size(214, 179);
            this.deepBookGroupBox.TabIndex = 58;
            this.deepBookGroupBox.TabStop = false;
            this.deepBookGroupBox.Text = "Market Depth";
            // 
            // deepBookEntries
            // 
            this.deepBookEntries.Location = new System.Drawing.Point(104, 20);
            this.deepBookEntries.Name = "deepBookEntries";
            this.deepBookEntries.Size = new System.Drawing.Size(100, 20);
            this.deepBookEntries.TabIndex = 57;
            this.deepBookEntries.Text = "3";
            // 
            // deepBookEntriesLabel
            // 
            this.deepBookEntriesLabel.AutoSize = true;
            this.deepBookEntriesLabel.Location = new System.Drawing.Point(6, 23);
            this.deepBookEntriesLabel.Name = "deepBookEntriesLabel";
            this.deepBookEntriesLabel.Size = new System.Drawing.Size(90, 13);
            this.deepBookEntriesLabel.TabIndex = 56;
            this.deepBookEntriesLabel.Text = "Number of entries";
            // 
            // deepBook_Button
            // 
            this.deepBook_Button.Location = new System.Drawing.Point(126, 144);
            this.deepBook_Button.Name = "deepBook_Button";
            this.deepBook_Button.Size = new System.Drawing.Size(82, 23);
            this.deepBook_Button.TabIndex = 16;
            this.deepBook_Button.Text = "Deep Book";
            this.deepBook_Button.UseVisualStyleBackColor = true;
            this.deepBook_Button.Click += new System.EventHandler(this.deepBook_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cancelMarketDataRequests);
            this.groupBox2.Controls.Add(this.primaryExchange);
            this.groupBox2.Controls.Add(this.primaryExchLabel);
            this.groupBox2.Controls.Add(this.genericTickList);
            this.groupBox2.Controls.Add(this.genericTickListLabel);
            this.groupBox2.Controls.Add(this.mdRightLabel);
            this.groupBox2.Controls.Add(this.mdContractRight);
            this.groupBox2.Controls.Add(this.putcall_label_TMD_MDT);
            this.groupBox2.Controls.Add(this.multiplier_TMD_MDT);
            this.groupBox2.Controls.Add(this.symbol_label_TMD_MDT);
            this.groupBox2.Controls.Add(this.marketData_Button);
            this.groupBox2.Controls.Add(this.secType_TMD_MDT);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.exchange_label_TMD_MDT);
            this.groupBox2.Controls.Add(this.localSymbol_TMD_MDT);
            this.groupBox2.Controls.Add(this.currency_label_TMD_MDT);
            this.groupBox2.Controls.Add(this.lastTradeDateOrContractMonth_TMD_MDT);
            this.groupBox2.Controls.Add(this.symbol_TMD_MDT);
            this.groupBox2.Controls.Add(this.strike_TMD_MDT);
            this.groupBox2.Controls.Add(this.currency_TMD_MDT);
            this.groupBox2.Controls.Add(this.exchange_TMD_MDT);
            this.groupBox2.Controls.Add(this.localSymbol_label_TMD_MDT);
            this.groupBox2.Controls.Add(this.lastTradeDate_label_TMD_MDT);
            this.groupBox2.Controls.Add(this.strike_label_TMD_MDT);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(496, 179);
            this.groupBox2.TabIndex = 55;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Contract";
            // 
            // cancelMarketDataRequests
            // 
            this.cancelMarketDataRequests.Location = new System.Drawing.Point(399, 146);
            this.cancelMarketDataRequests.Name = "cancelMarketDataRequests";
            this.cancelMarketDataRequests.Size = new System.Drawing.Size(75, 23);
            this.cancelMarketDataRequests.TabIndex = 2;
            this.cancelMarketDataRequests.Text = "Stop";
            this.cancelMarketDataRequests.UseVisualStyleBackColor = true;
            this.cancelMarketDataRequests.Click += new System.EventHandler(this.cancelMarketDataRequests_Click);
            // 
            // primaryExchange
            // 
            this.primaryExchange.Location = new System.Drawing.Point(85, 146);
            this.primaryExchange.Name = "primaryExchange";
            this.primaryExchange.Size = new System.Drawing.Size(100, 20);
            this.primaryExchange.TabIndex = 61;
            // 
            // primaryExchLabel
            // 
            this.primaryExchLabel.AutoSize = true;
            this.primaryExchLabel.Location = new System.Drawing.Point(8, 149);
            this.primaryExchLabel.Name = "primaryExchLabel";
            this.primaryExchLabel.Size = new System.Drawing.Size(71, 13);
            this.primaryExchLabel.TabIndex = 60;
            this.primaryExchLabel.Text = "Primary Exch.";
            // 
            // genericTickList
            // 
            this.genericTickList.Location = new System.Drawing.Point(292, 15);
            this.genericTickList.Name = "genericTickList";
            this.genericTickList.Size = new System.Drawing.Size(198, 20);
            this.genericTickList.TabIndex = 59;
            // 
            // genericTickListLabel
            // 
            this.genericTickListLabel.AutoSize = true;
            this.genericTickListLabel.Location = new System.Drawing.Point(191, 18);
            this.genericTickListLabel.Name = "genericTickListLabel";
            this.genericTickListLabel.Size = new System.Drawing.Size(79, 13);
            this.genericTickListLabel.TabIndex = 58;
            this.genericTickListLabel.Text = "Generic tick list";
            // 
            // mdRightLabel
            // 
            this.mdRightLabel.AutoSize = true;
            this.mdRightLabel.Location = new System.Drawing.Point(225, 86);
            this.mdRightLabel.Name = "mdRightLabel";
            this.mdRightLabel.Size = new System.Drawing.Size(45, 13);
            this.mdRightLabel.TabIndex = 57;
            this.mdRightLabel.Text = "Put/Call";
            // 
            // mdContractRight
            // 
            this.mdContractRight.FormattingEnabled = true;
            this.mdContractRight.Location = new System.Drawing.Point(292, 85);
            this.mdContractRight.Name = "mdContractRight";
            this.mdContractRight.Size = new System.Drawing.Size(87, 21);
            this.mdContractRight.TabIndex = 56;
            // 
            // putcall_label_TMD_MDT
            // 
            this.putcall_label_TMD_MDT.AutoSize = true;
            this.putcall_label_TMD_MDT.Location = new System.Drawing.Point(221, 142);
            this.putcall_label_TMD_MDT.Name = "putcall_label_TMD_MDT";
            this.putcall_label_TMD_MDT.Size = new System.Drawing.Size(48, 13);
            this.putcall_label_TMD_MDT.TabIndex = 6;
            this.putcall_label_TMD_MDT.Text = "Multiplier";
            // 
            // multiplier_TMD_MDT
            // 
            this.multiplier_TMD_MDT.Location = new System.Drawing.Point(292, 142);
            this.multiplier_TMD_MDT.Name = "multiplier_TMD_MDT";
            this.multiplier_TMD_MDT.Size = new System.Drawing.Size(87, 20);
            this.multiplier_TMD_MDT.TabIndex = 12;
            // 
            // symbol_label_TMD_MDT
            // 
            this.symbol_label_TMD_MDT.AutoSize = true;
            this.symbol_label_TMD_MDT.Location = new System.Drawing.Point(38, 18);
            this.symbol_label_TMD_MDT.Name = "symbol_label_TMD_MDT";
            this.symbol_label_TMD_MDT.Size = new System.Drawing.Size(41, 13);
            this.symbol_label_TMD_MDT.TabIndex = 1;
            this.symbol_label_TMD_MDT.Text = "Symbol";
            // 
            // marketData_Button
            // 
            this.marketData_Button.Location = new System.Drawing.Point(399, 114);
            this.marketData_Button.Name = "marketData_Button";
            this.marketData_Button.Size = new System.Drawing.Size(75, 23);
            this.marketData_Button.TabIndex = 17;
            this.marketData_Button.Text = "Add Ticker";
            this.marketData_Button.UseVisualStyleBackColor = true;
            this.marketData_Button.Click += new System.EventHandler(this.marketData_Click);
            // 
            // secType_TMD_MDT
            // 
            this.secType_TMD_MDT.FormattingEnabled = true;
            this.secType_TMD_MDT.Items.AddRange(new object[] {
            "STK",
            "OPT",
            "FUT",
            "CASH",
            "BOND",
            "CFD",
            "FOP",
            "WAR",
            "IOPT",
            "FWD",
            "BAG",
            "IND",
            "BILL",
            "FUND",
            "FIXED",
            "SLB",
            "NEWS",
            "CMDTY",
            "BSK",
            "ICU",
            "ICS"});
            this.secType_TMD_MDT.Location = new System.Drawing.Point(85, 40);
            this.secType_TMD_MDT.Name = "secType_TMD_MDT";
            this.secType_TMD_MDT.Size = new System.Drawing.Size(100, 21);
            this.secType_TMD_MDT.TabIndex = 2;
            this.secType_TMD_MDT.Text = "CASH";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "SecType";
            // 
            // exchange_label_TMD_MDT
            // 
            this.exchange_label_TMD_MDT.AutoSize = true;
            this.exchange_label_TMD_MDT.Location = new System.Drawing.Point(24, 93);
            this.exchange_label_TMD_MDT.Name = "exchange_label_TMD_MDT";
            this.exchange_label_TMD_MDT.Size = new System.Drawing.Size(55, 13);
            this.exchange_label_TMD_MDT.TabIndex = 7;
            this.exchange_label_TMD_MDT.Text = "Exchange";
            // 
            // localSymbol_TMD_MDT
            // 
            this.localSymbol_TMD_MDT.Location = new System.Drawing.Point(85, 120);
            this.localSymbol_TMD_MDT.Name = "localSymbol_TMD_MDT";
            this.localSymbol_TMD_MDT.Size = new System.Drawing.Size(100, 20);
            this.localSymbol_TMD_MDT.TabIndex = 15;
            // 
            // currency_label_TMD_MDT
            // 
            this.currency_label_TMD_MDT.AutoSize = true;
            this.currency_label_TMD_MDT.Location = new System.Drawing.Point(30, 67);
            this.currency_label_TMD_MDT.Name = "currency_label_TMD_MDT";
            this.currency_label_TMD_MDT.Size = new System.Drawing.Size(49, 13);
            this.currency_label_TMD_MDT.TabIndex = 8;
            this.currency_label_TMD_MDT.Text = "Currency";
            // 
            // lastTradeDateOrContractMonth_TMD_MDT
            // 
            this.lastTradeDateOrContractMonth_TMD_MDT.Location = new System.Drawing.Point(292, 46);
            this.lastTradeDateOrContractMonth_TMD_MDT.Name = "lastTradeDateOrContractMonth_TMD_MDT";
            this.lastTradeDateOrContractMonth_TMD_MDT.Size = new System.Drawing.Size(100, 20);
            this.lastTradeDateOrContractMonth_TMD_MDT.TabIndex = 14;
            // 
            // symbol_TMD_MDT
            // 
            this.symbol_TMD_MDT.Location = new System.Drawing.Point(85, 15);
            this.symbol_TMD_MDT.Name = "symbol_TMD_MDT";
            this.symbol_TMD_MDT.Size = new System.Drawing.Size(100, 20);
            this.symbol_TMD_MDT.TabIndex = 0;
            this.symbol_TMD_MDT.Text = "EUR";
            // 
            // strike_TMD_MDT
            // 
            this.strike_TMD_MDT.Location = new System.Drawing.Point(292, 113);
            this.strike_TMD_MDT.Name = "strike_TMD_MDT";
            this.strike_TMD_MDT.Size = new System.Drawing.Size(87, 20);
            this.strike_TMD_MDT.TabIndex = 13;
            // 
            // currency_TMD_MDT
            // 
            this.currency_TMD_MDT.Location = new System.Drawing.Point(85, 67);
            this.currency_TMD_MDT.Name = "currency_TMD_MDT";
            this.currency_TMD_MDT.Size = new System.Drawing.Size(100, 20);
            this.currency_TMD_MDT.TabIndex = 10;
            this.currency_TMD_MDT.Text = "USD";
            // 
            // exchange_TMD_MDT
            // 
            this.exchange_TMD_MDT.Location = new System.Drawing.Point(85, 93);
            this.exchange_TMD_MDT.Name = "exchange_TMD_MDT";
            this.exchange_TMD_MDT.Size = new System.Drawing.Size(100, 20);
            this.exchange_TMD_MDT.TabIndex = 11;
            this.exchange_TMD_MDT.Text = "IDEALPRO";
            // 
            // localSymbol_label_TMD_MDT
            // 
            this.localSymbol_label_TMD_MDT.AutoSize = true;
            this.localSymbol_label_TMD_MDT.Location = new System.Drawing.Point(9, 120);
            this.localSymbol_label_TMD_MDT.Name = "localSymbol_label_TMD_MDT";
            this.localSymbol_label_TMD_MDT.Size = new System.Drawing.Size(70, 13);
            this.localSymbol_label_TMD_MDT.TabIndex = 9;
            this.localSymbol_label_TMD_MDT.Text = "Local Symbol";
            // 
            // lastTradeDate_label_TMD_MDT
            // 
            this.lastTradeDate_label_TMD_MDT.Location = new System.Drawing.Point(191, 46);
            this.lastTradeDate_label_TMD_MDT.Name = "lastTradeDate_label_TMD_MDT";
            this.lastTradeDate_label_TMD_MDT.Size = new System.Drawing.Size(92, 28);
            this.lastTradeDate_label_TMD_MDT.TabIndex = 4;
            this.lastTradeDate_label_TMD_MDT.Text = "Last trade date / contract month";
            // 
            // strike_label_TMD_MDT
            // 
            this.strike_label_TMD_MDT.AutoSize = true;
            this.strike_label_TMD_MDT.Location = new System.Drawing.Point(236, 113);
            this.strike_label_TMD_MDT.Name = "strike_label_TMD_MDT";
            this.strike_label_TMD_MDT.Size = new System.Drawing.Size(34, 13);
            this.strike_label_TMD_MDT.TabIndex = 5;
            this.strike_label_TMD_MDT.Text = "Strike";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.contractMDRTH);
            this.groupBox1.Controls.Add(this.realTime_Button);
            this.groupBox1.Controls.Add(this.histData_Button);
            this.groupBox1.Controls.Add(this.hdEndDate_label_HDT);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.hdRequest_EndTime);
            this.groupBox1.Controls.Add(this.hdRequest_WhatToShow);
            this.groupBox1.Controls.Add(this.hdRequest_Duration);
            this.groupBox1.Controls.Add(this.includeExpired);
            this.groupBox1.Controls.Add(this.hdRequest_BarSize);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.hdRequest_TimeUnit);
            this.groupBox1.Location = new System.Drawing.Point(508, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 179);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bar request";
            // 
            // contractMDRTH
            // 
            this.contractMDRTH.AutoSize = true;
            this.contractMDRTH.Location = new System.Drawing.Point(221, 19);
            this.contractMDRTH.Name = "contractMDRTH";
            this.contractMDRTH.Size = new System.Drawing.Size(71, 17);
            this.contractMDRTH.TabIndex = 60;
            this.contractMDRTH.Text = "RTH only";
            this.contractMDRTH.UseVisualStyleBackColor = true;
            // 
            // realTime_Button
            // 
            this.realTime_Button.Location = new System.Drawing.Point(140, 146);
            this.realTime_Button.Name = "realTime_Button";
            this.realTime_Button.Size = new System.Drawing.Size(75, 23);
            this.realTime_Button.TabIndex = 56;
            this.realTime_Button.Text = "Real Time";
            this.realTime_Button.UseVisualStyleBackColor = true;
            this.realTime_Button.Click += new System.EventHandler(this.realTime_Button_Click);
            // 
            // histData_Button
            // 
            this.histData_Button.Location = new System.Drawing.Point(59, 146);
            this.histData_Button.Name = "histData_Button";
            this.histData_Button.Size = new System.Drawing.Size(75, 23);
            this.histData_Button.TabIndex = 54;
            this.histData_Button.Text = "Historical";
            this.histData_Button.UseVisualStyleBackColor = true;
            this.histData_Button.Click += new System.EventHandler(this.histDataButton_Click);
            // 
            // hdEndDate_label_HDT
            // 
            this.hdEndDate_label_HDT.AutoSize = true;
            this.hdEndDate_label_HDT.Location = new System.Drawing.Point(27, 18);
            this.hdEndDate_label_HDT.Name = "hdEndDate_label_HDT";
            this.hdEndDate_label_HDT.Size = new System.Drawing.Size(26, 13);
            this.hdEndDate_label_HDT.TabIndex = 46;
            this.hdEndDate_label_HDT.Text = "End";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 53;
            this.label12.Text = "Show";
            // 
            // hdRequest_EndTime
            // 
            this.hdRequest_EndTime.Location = new System.Drawing.Point(59, 18);
            this.hdRequest_EndTime.Name = "hdRequest_EndTime";
            this.hdRequest_EndTime.Size = new System.Drawing.Size(156, 20);
            this.hdRequest_EndTime.TabIndex = 45;
            this.hdRequest_EndTime.Text = "20130808 23:59:59 GMT";
            // 
            // hdRequest_WhatToShow
            // 
            this.hdRequest_WhatToShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hdRequest_WhatToShow.FormattingEnabled = true;
            this.hdRequest_WhatToShow.Items.AddRange(new object[] {
            "TRADES",
            "MIDPOINT",
            "BID",
            "ASK",
            "BID_ASK",
            "HISTORICAL_VOLATILITY",
            "OPTION_IMPLIED_VOLATILITY",
            "YIELD_BID",
            "YIELD_ASK",
            "YIELD_BID_ASK",
            "YIELD_LAST"});
            this.hdRequest_WhatToShow.Location = new System.Drawing.Point(59, 92);
            this.hdRequest_WhatToShow.Name = "hdRequest_WhatToShow";
            this.hdRequest_WhatToShow.Size = new System.Drawing.Size(156, 20);
            this.hdRequest_WhatToShow.TabIndex = 52;
            this.hdRequest_WhatToShow.Text = "MIDPOINT";
            // 
            // hdRequest_Duration
            // 
            this.hdRequest_Duration.Location = new System.Drawing.Point(59, 41);
            this.hdRequest_Duration.Name = "hdRequest_Duration";
            this.hdRequest_Duration.Size = new System.Drawing.Size(67, 20);
            this.hdRequest_Duration.TabIndex = 47;
            this.hdRequest_Duration.Text = "10";
            // 
            // includeExpired
            // 
            this.includeExpired.AutoSize = true;
            this.includeExpired.Location = new System.Drawing.Point(221, 45);
            this.includeExpired.Name = "includeExpired";
            this.includeExpired.Size = new System.Drawing.Size(61, 17);
            this.includeExpired.TabIndex = 56;
            this.includeExpired.Text = "Expired";
            this.includeExpired.UseVisualStyleBackColor = true;
            // 
            // hdRequest_BarSize
            // 
            this.hdRequest_BarSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hdRequest_BarSize.FormattingEnabled = true;
            this.hdRequest_BarSize.Items.AddRange(new object[] {
            "1 sec",
            "5 secs",
            "15 secs",
            "30 secs",
            "1 min",
            "2 mins",
            "3 mins",
            "5 mins",
            "15 mins",
            "30 mins",
            "1 hour",
            "1 day"});
            this.hdRequest_BarSize.Location = new System.Drawing.Point(59, 66);
            this.hdRequest_BarSize.Name = "hdRequest_BarSize";
            this.hdRequest_BarSize.Size = new System.Drawing.Size(156, 21);
            this.hdRequest_BarSize.TabIndex = 51;
            this.hdRequest_BarSize.Text = "1 day";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 48;
            this.label10.Text = "Duration";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 50;
            this.label11.Text = "Bar Size";
            // 
            // hdRequest_TimeUnit
            // 
            this.hdRequest_TimeUnit.FormattingEnabled = true;
            this.hdRequest_TimeUnit.Items.AddRange(new object[] {
            "S",
            "D",
            "W",
            "M",
            "Y"});
            this.hdRequest_TimeUnit.Location = new System.Drawing.Point(132, 41);
            this.hdRequest_TimeUnit.Name = "hdRequest_TimeUnit";
            this.hdRequest_TimeUnit.Size = new System.Drawing.Size(83, 21);
            this.hdRequest_TimeUnit.TabIndex = 49;
            this.hdRequest_TimeUnit.Text = "D";
            // 
            // marketScanner_MDT
            // 
            this.marketScanner_MDT.BackColor = System.Drawing.Color.LightGray;
            this.marketScanner_MDT.Controls.Add(this.groupBox4);
            this.marketScanner_MDT.Controls.Add(this.scannerParamsRequest_button);
            this.marketScanner_MDT.Location = new System.Drawing.Point(4, 22);
            this.marketScanner_MDT.Name = "marketScanner_MDT";
            this.marketScanner_MDT.Padding = new System.Windows.Forms.Padding(3);
            this.marketScanner_MDT.Size = new System.Drawing.Size(1230, 200);
            this.marketScanner_MDT.TabIndex = 4;
            this.marketScanner_MDT.Text = "Scanner";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.scanCode);
            this.groupBox4.Controls.Add(this.scanInstrument);
            this.groupBox4.Controls.Add(this.scannerRequest_Button);
            this.groupBox4.Controls.Add(this.scanLocation);
            this.groupBox4.Controls.Add(this.scanStockType);
            this.groupBox4.Controls.Add(this.scanNumRows);
            this.groupBox4.Controls.Add(this.scanNumRows_label);
            this.groupBox4.Controls.Add(this.scanCode_label);
            this.groupBox4.Controls.Add(this.scanStockType_label);
            this.groupBox4.Controls.Add(this.scanInstrument_label);
            this.groupBox4.Controls.Add(this.scanLocation_label);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(264, 161);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Scanner Filters";
            // 
            // scanCode
            // 
            this.scanCode.FormattingEnabled = true;
            this.scanCode.Items.AddRange(new object[] {
            "LOW_OPT_VOL_PUT_CALL_RATIO",
            "HIGH_OPT_IMP_VOLAT_OVER_HIST",
            "LOW_OPT_IMP_VOLAT_OVER_HIST",
            "HIGH_OPT_IMP_VOLAT",
            "TOP_OPT_IMP_VOLAT_GAIN",
            "TOP_OPT_IMP_VOLAT_LOSE",
            "HIGH_OPT_VOLUME_PUT_CALL_RATIO",
            "LOW_OPT_VOLUME_PUT_CALL_RATIO",
            "OPT_VOLUME_MOST_ACTIVE",
            "HOT_BY_OPT_VOLUME",
            "HIGH_OPT_OPEN_INTEREST_PUT_CALL_RATIO",
            "LOW_OPT_OPEN_INTEREST_PUT_CALL_RATIO",
            "TOP_PERC_GAIN",
            "MOST_ACTIVE",
            "TOP_PERC_LOSE",
            "HOT_BY_VOLUME",
            "TOP_PERC_GAIN",
            "HOT_BY_PRICE",
            "TOP_TRADE_COUNT",
            "TOP_TRADE_RATE",
            "TOP_PRICE_RANGE",
            "HOT_BY_PRICE_RANGE",
            "TOP_VOLUME_RATE",
            "LOW_OPT_IMP_VOLAT",
            "OPT_OPEN_INTEREST_MOST_ACTIVE",
            "NOT_OPEN",
            "HALTED",
            "TOP_OPEN_PERC_GAIN",
            "TOP_OPEN_PERC_LOSE",
            "HIGH_OPEN_GAP",
            "LOW_OPEN_GAP",
            "LOW_OPT_IMP_VOLAT",
            "TOP_OPT_IMP_VOLAT_GAIN",
            "TOP_OPT_IMP_VOLAT_LOSE",
            "HIGH_VS_13W_HL",
            "LOW_VS_13W_HL",
            "HIGH_VS_26W_HL",
            "LOW_VS_26W_HL",
            "HIGH_VS_52W_HL",
            "LOW_VS_52W_HL",
            "HIGH_SYNTH_BID_REV_NAT_YIELD",
            "LOW_SYNTH_BID_REV_NAT_YIELD"});
            this.scanCode.Location = new System.Drawing.Point(75, 19);
            this.scanCode.Name = "scanCode";
            this.scanCode.Size = new System.Drawing.Size(179, 21);
            this.scanCode.TabIndex = 0;
            this.scanCode.Text = "TOP_PERC_GAIN";
            // 
            // scanInstrument
            // 
            this.scanInstrument.FormattingEnabled = true;
            this.scanInstrument.Items.AddRange(new object[] {
            "STK",
            "STOCK.HK",
            "STOCK.EU"});
            this.scanInstrument.Location = new System.Drawing.Point(75, 46);
            this.scanInstrument.Name = "scanInstrument";
            this.scanInstrument.Size = new System.Drawing.Size(121, 21);
            this.scanInstrument.TabIndex = 1;
            this.scanInstrument.Text = "STOCK.EU";
            // 
            // scannerRequest_Button
            // 
            this.scannerRequest_Button.Location = new System.Drawing.Point(181, 128);
            this.scannerRequest_Button.Name = "scannerRequest_Button";
            this.scannerRequest_Button.Size = new System.Drawing.Size(76, 21);
            this.scannerRequest_Button.TabIndex = 10;
            this.scannerRequest_Button.Text = "Submit";
            this.scannerRequest_Button.UseVisualStyleBackColor = true;
            this.scannerRequest_Button.Click += new System.EventHandler(this.scannerRequest_Button_Click);
            // 
            // scanLocation
            // 
            this.scanLocation.FormattingEnabled = true;
            this.scanLocation.Items.AddRange(new object[] {
            "STK.US",
            "STK.US.MAJOR",
            "STK.US.MINOR",
            "STK.HK.SEHK",
            "STK.HK.ASX",
            "STK.EU"});
            this.scanLocation.Location = new System.Drawing.Point(75, 101);
            this.scanLocation.Name = "scanLocation";
            this.scanLocation.Size = new System.Drawing.Size(121, 21);
            this.scanLocation.TabIndex = 11;
            this.scanLocation.Text = "STK.EU.IBIS";
            // 
            // scanStockType
            // 
            this.scanStockType.FormattingEnabled = true;
            this.scanStockType.Location = new System.Drawing.Point(75, 74);
            this.scanStockType.Name = "scanStockType";
            this.scanStockType.Size = new System.Drawing.Size(121, 21);
            this.scanStockType.TabIndex = 3;
            this.scanStockType.Text = "ALL";
            // 
            // scanNumRows
            // 
            this.scanNumRows.Location = new System.Drawing.Point(75, 128);
            this.scanNumRows.Name = "scanNumRows";
            this.scanNumRows.Size = new System.Drawing.Size(100, 20);
            this.scanNumRows.TabIndex = 4;
            this.scanNumRows.Text = "15";
            // 
            // scanNumRows_label
            // 
            this.scanNumRows_label.AutoSize = true;
            this.scanNumRows_label.Location = new System.Drawing.Point(10, 128);
            this.scanNumRows_label.Name = "scanNumRows_label";
            this.scanNumRows_label.Size = new System.Drawing.Size(59, 13);
            this.scanNumRows_label.TabIndex = 9;
            this.scanNumRows_label.Text = "Num Rows";
            // 
            // scanCode_label
            // 
            this.scanCode_label.AutoSize = true;
            this.scanCode_label.Location = new System.Drawing.Point(9, 19);
            this.scanCode_label.Name = "scanCode_label";
            this.scanCode_label.Size = new System.Drawing.Size(60, 13);
            this.scanCode_label.TabIndex = 5;
            this.scanCode_label.Text = "Scan Code";
            // 
            // scanStockType_label
            // 
            this.scanStockType_label.AutoSize = true;
            this.scanStockType_label.Location = new System.Drawing.Point(7, 74);
            this.scanStockType_label.Name = "scanStockType_label";
            this.scanStockType_label.Size = new System.Drawing.Size(62, 13);
            this.scanStockType_label.TabIndex = 8;
            this.scanStockType_label.Text = "Stock Type";
            // 
            // scanInstrument_label
            // 
            this.scanInstrument_label.AutoSize = true;
            this.scanInstrument_label.Location = new System.Drawing.Point(13, 46);
            this.scanInstrument_label.Name = "scanInstrument_label";
            this.scanInstrument_label.Size = new System.Drawing.Size(56, 13);
            this.scanInstrument_label.TabIndex = 6;
            this.scanInstrument_label.Text = "Instrument";
            // 
            // scanLocation_label
            // 
            this.scanLocation_label.AutoSize = true;
            this.scanLocation_label.Location = new System.Drawing.Point(21, 101);
            this.scanLocation_label.Name = "scanLocation_label";
            this.scanLocation_label.Size = new System.Drawing.Size(48, 13);
            this.scanLocation_label.TabIndex = 7;
            this.scanLocation_label.Text = "Location";
            // 
            // scannerParamsRequest_button
            // 
            this.scannerParamsRequest_button.Location = new System.Drawing.Point(276, 15);
            this.scannerParamsRequest_button.Name = "scannerParamsRequest_button";
            this.scannerParamsRequest_button.Size = new System.Drawing.Size(120, 23);
            this.scannerParamsRequest_button.TabIndex = 12;
            this.scannerParamsRequest_button.Text = "Request Parameters";
            this.scannerParamsRequest_button.UseVisualStyleBackColor = true;
            this.scannerParamsRequest_button.Click += new System.EventHandler(this.scannerParamsRequest_button_Click);
            // 
            // tradingTab
            // 
            this.tradingTab.BackColor = System.Drawing.Color.LightGray;
            this.tradingTab.Controls.Add(this.execFilterGroup);
            this.tradingTab.Controls.Add(this.globalCancelButton);
            this.tradingTab.Controls.Add(this.clientOrdersButton);
            this.tradingTab.Controls.Add(this.refreshOrdersButton);
            this.tradingTab.Controls.Add(this.cancelOrdersButton);
            this.tradingTab.Controls.Add(this.button1);
            this.tradingTab.Controls.Add(this.newOrderLink);
            this.tradingTab.Controls.Add(this.executionsGroup);
            this.tradingTab.Controls.Add(this.liveOrdersGroup);
            this.tradingTab.Location = new System.Drawing.Point(4, 22);
            this.tradingTab.Name = "tradingTab";
            this.tradingTab.Padding = new System.Windows.Forms.Padding(3);
            this.tradingTab.Size = new System.Drawing.Size(1248, 448);
            this.tradingTab.TabIndex = 2;
            this.tradingTab.Text = "Trading";
            // 
            // execFilterGroup
            // 
            this.execFilterGroup.Controls.Add(this.execFilterExchange);
            this.execFilterGroup.Controls.Add(this.execFilterSide);
            this.execFilterGroup.Controls.Add(this.execFilterSideLabel);
            this.execFilterGroup.Controls.Add(this.execFilterExchangeLabel);
            this.execFilterGroup.Controls.Add(this.execFilterSecTypeLabel);
            this.execFilterGroup.Controls.Add(this.execFilterSymbolLabel);
            this.execFilterGroup.Controls.Add(this.execFilterTimeLabel);
            this.execFilterGroup.Controls.Add(this.execFilterAcctLabel);
            this.execFilterGroup.Controls.Add(this.execFilterClientLabel);
            this.execFilterGroup.Controls.Add(this.execFilterSecType);
            this.execFilterGroup.Controls.Add(this.execFilterSymbol);
            this.execFilterGroup.Controls.Add(this.execFilterTime);
            this.execFilterGroup.Controls.Add(this.execFilterAccount);
            this.execFilterGroup.Controls.Add(this.execFilterClientId);
            this.execFilterGroup.Controls.Add(this.refreshExecutionsButton);
            this.execFilterGroup.Location = new System.Drawing.Point(975, 218);
            this.execFilterGroup.Name = "execFilterGroup";
            this.execFilterGroup.Size = new System.Drawing.Size(230, 206);
            this.execFilterGroup.TabIndex = 10;
            this.execFilterGroup.TabStop = false;
            this.execFilterGroup.Text = "Execution Filter";
            // 
            // execFilterExchange
            // 
            this.execFilterExchange.Location = new System.Drawing.Point(65, 70);
            this.execFilterExchange.Name = "execFilterExchange";
            this.execFilterExchange.Size = new System.Drawing.Size(77, 20);
            this.execFilterExchange.TabIndex = 15;
            // 
            // execFilterSide
            // 
            this.execFilterSide.Location = new System.Drawing.Point(65, 96);
            this.execFilterSide.Name = "execFilterSide";
            this.execFilterSide.Size = new System.Drawing.Size(77, 20);
            this.execFilterSide.TabIndex = 14;
            this.execFilterSide.Text = "BUY";
            // 
            // execFilterSideLabel
            // 
            this.execFilterSideLabel.AutoSize = true;
            this.execFilterSideLabel.Location = new System.Drawing.Point(6, 103);
            this.execFilterSideLabel.Name = "execFilterSideLabel";
            this.execFilterSideLabel.Size = new System.Drawing.Size(28, 13);
            this.execFilterSideLabel.TabIndex = 13;
            this.execFilterSideLabel.Text = "Side";
            // 
            // execFilterExchangeLabel
            // 
            this.execFilterExchangeLabel.AutoSize = true;
            this.execFilterExchangeLabel.Location = new System.Drawing.Point(6, 78);
            this.execFilterExchangeLabel.Name = "execFilterExchangeLabel";
            this.execFilterExchangeLabel.Size = new System.Drawing.Size(55, 13);
            this.execFilterExchangeLabel.TabIndex = 12;
            this.execFilterExchangeLabel.Text = "Exchange";
            // 
            // execFilterSecTypeLabel
            // 
            this.execFilterSecTypeLabel.AutoSize = true;
            this.execFilterSecTypeLabel.Location = new System.Drawing.Point(6, 154);
            this.execFilterSecTypeLabel.Name = "execFilterSecTypeLabel";
            this.execFilterSecTypeLabel.Size = new System.Drawing.Size(50, 13);
            this.execFilterSecTypeLabel.TabIndex = 11;
            this.execFilterSecTypeLabel.Text = "SecType";
            // 
            // execFilterSymbolLabel
            // 
            this.execFilterSymbolLabel.AutoSize = true;
            this.execFilterSymbolLabel.Location = new System.Drawing.Point(6, 129);
            this.execFilterSymbolLabel.Name = "execFilterSymbolLabel";
            this.execFilterSymbolLabel.Size = new System.Drawing.Size(41, 13);
            this.execFilterSymbolLabel.TabIndex = 10;
            this.execFilterSymbolLabel.Text = "Symbol";
            // 
            // execFilterTimeLabel
            // 
            this.execFilterTimeLabel.AutoSize = true;
            this.execFilterTimeLabel.Location = new System.Drawing.Point(6, 180);
            this.execFilterTimeLabel.Name = "execFilterTimeLabel";
            this.execFilterTimeLabel.Size = new System.Drawing.Size(30, 13);
            this.execFilterTimeLabel.TabIndex = 9;
            this.execFilterTimeLabel.Text = "Time";
            // 
            // execFilterAcctLabel
            // 
            this.execFilterAcctLabel.AutoSize = true;
            this.execFilterAcctLabel.Location = new System.Drawing.Point(6, 51);
            this.execFilterAcctLabel.Name = "execFilterAcctLabel";
            this.execFilterAcctLabel.Size = new System.Drawing.Size(47, 13);
            this.execFilterAcctLabel.TabIndex = 8;
            this.execFilterAcctLabel.Text = "Account";
            // 
            // execFilterClientLabel
            // 
            this.execFilterClientLabel.AutoSize = true;
            this.execFilterClientLabel.Location = new System.Drawing.Point(6, 26);
            this.execFilterClientLabel.Name = "execFilterClientLabel";
            this.execFilterClientLabel.Size = new System.Drawing.Size(42, 13);
            this.execFilterClientLabel.TabIndex = 7;
            this.execFilterClientLabel.Text = "ClientId";
            // 
            // execFilterSecType
            // 
            this.execFilterSecType.Location = new System.Drawing.Point(65, 147);
            this.execFilterSecType.Name = "execFilterSecType";
            this.execFilterSecType.Size = new System.Drawing.Size(77, 20);
            this.execFilterSecType.TabIndex = 6;
            // 
            // execFilterSymbol
            // 
            this.execFilterSymbol.Location = new System.Drawing.Point(65, 122);
            this.execFilterSymbol.Name = "execFilterSymbol";
            this.execFilterSymbol.Size = new System.Drawing.Size(77, 20);
            this.execFilterSymbol.TabIndex = 5;
            // 
            // execFilterTime
            // 
            this.execFilterTime.Location = new System.Drawing.Point(65, 173);
            this.execFilterTime.Name = "execFilterTime";
            this.execFilterTime.Size = new System.Drawing.Size(101, 20);
            this.execFilterTime.TabIndex = 4;
            // 
            // execFilterAccount
            // 
            this.execFilterAccount.Location = new System.Drawing.Point(65, 44);
            this.execFilterAccount.Name = "execFilterAccount";
            this.execFilterAccount.Size = new System.Drawing.Size(77, 20);
            this.execFilterAccount.TabIndex = 3;
            // 
            // execFilterClientId
            // 
            this.execFilterClientId.Location = new System.Drawing.Point(65, 19);
            this.execFilterClientId.Name = "execFilterClientId";
            this.execFilterClientId.Size = new System.Drawing.Size(77, 20);
            this.execFilterClientId.TabIndex = 2;
            // 
            // refreshExecutionsButton
            // 
            this.refreshExecutionsButton.Location = new System.Drawing.Point(149, 19);
            this.refreshExecutionsButton.Name = "refreshExecutionsButton";
            this.refreshExecutionsButton.Size = new System.Drawing.Size(75, 23);
            this.refreshExecutionsButton.TabIndex = 1;
            this.refreshExecutionsButton.Text = "Refresh";
            this.refreshExecutionsButton.UseVisualStyleBackColor = true;
            this.refreshExecutionsButton.Click += new System.EventHandler(this.refreshExecutionsButton_Click);
            // 
            // globalCancelButton
            // 
            this.globalCancelButton.Location = new System.Drawing.Point(977, 168);
            this.globalCancelButton.Name = "globalCancelButton";
            this.globalCancelButton.Size = new System.Drawing.Size(105, 23);
            this.globalCancelButton.TabIndex = 9;
            this.globalCancelButton.Text = "Global cancel";
            this.globalCancelButton.UseVisualStyleBackColor = true;
            this.globalCancelButton.Click += new System.EventHandler(this.globalCancelButton_Click);
            // 
            // clientOrdersButton
            // 
            this.clientOrdersButton.Location = new System.Drawing.Point(977, 51);
            this.clientOrdersButton.Name = "clientOrdersButton";
            this.clientOrdersButton.Size = new System.Drawing.Size(105, 23);
            this.clientOrdersButton.TabIndex = 8;
            this.clientOrdersButton.Text = "Get client\'s orders";
            this.clientOrdersButton.UseVisualStyleBackColor = true;
            this.clientOrdersButton.Click += new System.EventHandler(this.clientOrdersButton_Click);
            // 
            // refreshOrdersButton
            // 
            this.refreshOrdersButton.Location = new System.Drawing.Point(977, 80);
            this.refreshOrdersButton.Name = "refreshOrdersButton";
            this.refreshOrdersButton.Size = new System.Drawing.Size(105, 23);
            this.refreshOrdersButton.TabIndex = 1;
            this.refreshOrdersButton.Text = "Get all orders";
            this.refreshOrdersButton.UseVisualStyleBackColor = true;
            this.refreshOrdersButton.Click += new System.EventHandler(this.refreshOrdersButton_Click);
            // 
            // cancelOrdersButton
            // 
            this.cancelOrdersButton.Location = new System.Drawing.Point(977, 139);
            this.cancelOrdersButton.Name = "cancelOrdersButton";
            this.cancelOrdersButton.Size = new System.Drawing.Size(105, 23);
            this.cancelOrdersButton.TabIndex = 7;
            this.cancelOrdersButton.Text = "Cancel selection";
            this.cancelOrdersButton.UseVisualStyleBackColor = true;
            this.cancelOrdersButton.Click += new System.EventHandler(this.cancelOrdersButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(977, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Bind TWS orders";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.bindOrdersButton_Click);
            // 
            // newOrderLink
            // 
            this.newOrderLink.AutoSize = true;
            this.newOrderLink.Location = new System.Drawing.Point(974, 26);
            this.newOrderLink.Name = "newOrderLink";
            this.newOrderLink.Size = new System.Drawing.Size(58, 13);
            this.newOrderLink.TabIndex = 3;
            this.newOrderLink.TabStop = true;
            this.newOrderLink.Text = "New Order";
            this.newOrderLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.newOrderLink_LinkClicked);
            // 
            // executionsGroup
            // 
            this.executionsGroup.Controls.Add(this.tradeLogGrid);
            this.executionsGroup.Location = new System.Drawing.Point(9, 218);
            this.executionsGroup.Name = "executionsGroup";
            this.executionsGroup.Size = new System.Drawing.Size(960, 206);
            this.executionsGroup.TabIndex = 2;
            this.executionsGroup.TabStop = false;
            this.executionsGroup.Text = "Trade Log (Executions)";
            // 
            // tradeLogGrid
            // 
            this.tradeLogGrid.AllowUserToAddRows = false;
            this.tradeLogGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tradeLogGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ExecutionId,
            this.dateTimeExecColumn,
            this.accountExecColumn,
            this.dataGridViewTextBoxColumn8,
            this.actionExecColumn,
            this.quantityExecColumn,
            this.descriptionExecColumn,
            this.priceExecColumn,
            this.commissionExecColumn,
            this.RealisedPnL});
            this.tradeLogGrid.Location = new System.Drawing.Point(6, 19);
            this.tradeLogGrid.Name = "tradeLogGrid";
            this.tradeLogGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tradeLogGrid.Size = new System.Drawing.Size(946, 182);
            this.tradeLogGrid.TabIndex = 0;
            // 
            // ExecutionId
            // 
            this.ExecutionId.HeaderText = "Execution ID";
            this.ExecutionId.Name = "ExecutionId";
            this.ExecutionId.ReadOnly = true;
            // 
            // dateTimeExecColumn
            // 
            this.dateTimeExecColumn.HeaderText = "Date/Time";
            this.dateTimeExecColumn.Name = "dateTimeExecColumn";
            this.dateTimeExecColumn.ReadOnly = true;
            // 
            // accountExecColumn
            // 
            this.accountExecColumn.HeaderText = "Account";
            this.accountExecColumn.Name = "accountExecColumn";
            this.accountExecColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Model Code";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // actionExecColumn
            // 
            this.actionExecColumn.HeaderText = "Action";
            this.actionExecColumn.Name = "actionExecColumn";
            this.actionExecColumn.ReadOnly = true;
            // 
            // quantityExecColumn
            // 
            this.quantityExecColumn.HeaderText = "Quantity";
            this.quantityExecColumn.Name = "quantityExecColumn";
            this.quantityExecColumn.ReadOnly = true;
            // 
            // descriptionExecColumn
            // 
            this.descriptionExecColumn.HeaderText = "Description";
            this.descriptionExecColumn.Name = "descriptionExecColumn";
            this.descriptionExecColumn.ReadOnly = true;
            // 
            // priceExecColumn
            // 
            this.priceExecColumn.HeaderText = "Price";
            this.priceExecColumn.Name = "priceExecColumn";
            this.priceExecColumn.ReadOnly = true;
            // 
            // commissionExecColumn
            // 
            this.commissionExecColumn.HeaderText = "Commissions";
            this.commissionExecColumn.Name = "commissionExecColumn";
            this.commissionExecColumn.ReadOnly = true;
            // 
            // RealisedPnL
            // 
            this.RealisedPnL.HeaderText = "RealisedPnL";
            this.RealisedPnL.Name = "RealisedPnL";
            this.RealisedPnL.ReadOnly = true;
            // 
            // liveOrdersGroup
            // 
            this.liveOrdersGroup.Controls.Add(this.liveOrdersGrid);
            this.liveOrdersGroup.Location = new System.Drawing.Point(9, 6);
            this.liveOrdersGroup.Name = "liveOrdersGroup";
            this.liveOrdersGroup.Size = new System.Drawing.Size(960, 206);
            this.liveOrdersGroup.TabIndex = 1;
            this.liveOrdersGroup.TabStop = false;
            this.liveOrdersGroup.Text = "Live Orders - double click to modify.";
            // 
            // liveOrdersGrid
            // 
            this.liveOrdersGrid.AllowUserToAddRows = false;
            this.liveOrdersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.liveOrdersGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.permIdColumn,
            this.clientIdColumn,
            this.orderIdColumn,
            this.accountColumn,
            this.modelCodeColumn,
            this.actionColumn,
            this.quantityColumn,
            this.contractColumn,
            this.statusColumn});
            this.liveOrdersGrid.Location = new System.Drawing.Point(6, 19);
            this.liveOrdersGrid.Name = "liveOrdersGrid";
            this.liveOrdersGrid.ReadOnly = true;
            this.liveOrdersGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.liveOrdersGrid.Size = new System.Drawing.Size(946, 181);
            this.liveOrdersGrid.TabIndex = 0;
            this.liveOrdersGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.liveOrdersGrid_CellCoubleClick);
            // 
            // permIdColumn
            // 
            this.permIdColumn.HeaderText = "Perm ID";
            this.permIdColumn.Name = "permIdColumn";
            this.permIdColumn.ReadOnly = true;
            // 
            // clientIdColumn
            // 
            this.clientIdColumn.HeaderText = "Client ID";
            this.clientIdColumn.Name = "clientIdColumn";
            this.clientIdColumn.ReadOnly = true;
            // 
            // orderIdColumn
            // 
            this.orderIdColumn.HeaderText = "Order ID";
            this.orderIdColumn.Name = "orderIdColumn";
            this.orderIdColumn.ReadOnly = true;
            // 
            // accountColumn
            // 
            this.accountColumn.HeaderText = "Account";
            this.accountColumn.Name = "accountColumn";
            this.accountColumn.ReadOnly = true;
            // 
            // modelCodeColumn
            // 
            this.modelCodeColumn.HeaderText = "Model Code";
            this.modelCodeColumn.Name = "modelCodeColumn";
            this.modelCodeColumn.ReadOnly = true;
            // 
            // actionColumn
            // 
            this.actionColumn.HeaderText = "Action";
            this.actionColumn.Name = "actionColumn";
            this.actionColumn.ReadOnly = true;
            // 
            // quantityColumn
            // 
            this.quantityColumn.HeaderText = "Quantity";
            this.quantityColumn.Name = "quantityColumn";
            this.quantityColumn.ReadOnly = true;
            // 
            // contractColumn
            // 
            this.contractColumn.HeaderText = "Contract";
            this.contractColumn.Name = "contractColumn";
            this.contractColumn.ReadOnly = true;
            this.contractColumn.Width = 120;
            // 
            // statusColumn
            // 
            this.statusColumn.HeaderText = "Status";
            this.statusColumn.Name = "statusColumn";
            this.statusColumn.ReadOnly = true;
            // 
            // accountInfoTab
            // 
            this.accountInfoTab.BackColor = System.Drawing.Color.LightGray;
            this.accountInfoTab.Controls.Add(this.tabControl1);
            this.accountInfoTab.Controls.Add(this.accountSelectorLabel);
            this.accountInfoTab.Controls.Add(this.accountSelector);
            this.accountInfoTab.Location = new System.Drawing.Point(4, 22);
            this.accountInfoTab.Name = "accountInfoTab";
            this.accountInfoTab.Padding = new System.Windows.Forms.Padding(3);
            this.accountInfoTab.Size = new System.Drawing.Size(1248, 448);
            this.accountInfoTab.TabIndex = 3;
            this.accountInfoTab.Text = "Account Info";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.accSummaryTab);
            this.tabControl1.Controls.Add(this.accUpdatesTab);
            this.tabControl1.Controls.Add(this.positionsTab);
            this.tabControl1.Location = new System.Drawing.Point(6, 30);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1236, 424);
            this.tabControl1.TabIndex = 2;
            // 
            // accSummaryTab
            // 
            this.accSummaryTab.BackColor = System.Drawing.Color.LightGray;
            this.accSummaryTab.Controls.Add(this.accSummaryRequest);
            this.accSummaryTab.Controls.Add(this.accSummaryGrid);
            this.accSummaryTab.Location = new System.Drawing.Point(4, 22);
            this.accSummaryTab.Name = "accSummaryTab";
            this.accSummaryTab.Padding = new System.Windows.Forms.Padding(3);
            this.accSummaryTab.Size = new System.Drawing.Size(1228, 398);
            this.accSummaryTab.TabIndex = 0;
            this.accSummaryTab.Text = "Account Summary";
            // 
            // accSummaryRequest
            // 
            this.accSummaryRequest.Location = new System.Drawing.Point(623, 6);
            this.accSummaryRequest.Name = "accSummaryRequest";
            this.accSummaryRequest.Size = new System.Drawing.Size(75, 23);
            this.accSummaryRequest.TabIndex = 1;
            this.accSummaryRequest.Text = "Request";
            this.accSummaryRequest.UseVisualStyleBackColor = true;
            this.accSummaryRequest.Click += new System.EventHandler(this.accSummaryRequest_Click);
            // 
            // accSummaryGrid
            // 
            this.accSummaryGrid.AllowUserToAddRows = false;
            this.accSummaryGrid.AllowUserToDeleteRows = false;
            this.accSummaryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.accSummaryGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tag,
            this.value,
            this.currency,
            this.accountSummaryAccount});
            this.accSummaryGrid.Location = new System.Drawing.Point(6, 6);
            this.accSummaryGrid.Name = "accSummaryGrid";
            this.accSummaryGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.accSummaryGrid.Size = new System.Drawing.Size(611, 386);
            this.accSummaryGrid.TabIndex = 0;
            // 
            // tag
            // 
            this.tag.HeaderText = "Tag";
            this.tag.Name = "tag";
            this.tag.ReadOnly = true;
            this.tag.Width = 150;
            // 
            // value
            // 
            this.value.HeaderText = "Value";
            this.value.Name = "value";
            this.value.ReadOnly = true;
            this.value.Width = 150;
            // 
            // currency
            // 
            this.currency.HeaderText = "Currency";
            this.currency.Name = "currency";
            this.currency.ReadOnly = true;
            this.currency.Width = 150;
            // 
            // accountSummaryAccount
            // 
            this.accountSummaryAccount.HeaderText = "Account";
            this.accountSummaryAccount.Name = "accountSummaryAccount";
            this.accountSummaryAccount.ReadOnly = true;
            // 
            // accUpdatesTab
            // 
            this.accUpdatesTab.BackColor = System.Drawing.Color.LightGray;
            this.accUpdatesTab.Controls.Add(this.accUpdatesSubscribedAccount);
            this.accUpdatesTab.Controls.Add(this.accUpdatesAccountLabel);
            this.accUpdatesTab.Controls.Add(this.accUpdatesLastUpdateValue);
            this.accUpdatesTab.Controls.Add(this.accountPortfolioGrid);
            this.accUpdatesTab.Controls.Add(this.accountValuesGrid);
            this.accUpdatesTab.Controls.Add(this.accUpdatesSubscribe);
            this.accUpdatesTab.Controls.Add(this.lastUpdatedLabel);
            this.accUpdatesTab.Location = new System.Drawing.Point(4, 22);
            this.accUpdatesTab.Name = "accUpdatesTab";
            this.accUpdatesTab.Padding = new System.Windows.Forms.Padding(3);
            this.accUpdatesTab.Size = new System.Drawing.Size(1228, 398);
            this.accUpdatesTab.TabIndex = 1;
            this.accUpdatesTab.Text = "Account Updates";
            // 
            // accUpdatesSubscribedAccount
            // 
            this.accUpdatesSubscribedAccount.AutoSize = true;
            this.accUpdatesSubscribedAccount.Location = new System.Drawing.Point(143, 11);
            this.accUpdatesSubscribedAccount.Name = "accUpdatesSubscribedAccount";
            this.accUpdatesSubscribedAccount.Size = new System.Drawing.Size(16, 13);
            this.accUpdatesSubscribedAccount.TabIndex = 6;
            this.accUpdatesSubscribedAccount.Text = "...";
            // 
            // accUpdatesAccountLabel
            // 
            this.accUpdatesAccountLabel.AutoSize = true;
            this.accUpdatesAccountLabel.Location = new System.Drawing.Point(87, 11);
            this.accUpdatesAccountLabel.Name = "accUpdatesAccountLabel";
            this.accUpdatesAccountLabel.Size = new System.Drawing.Size(50, 13);
            this.accUpdatesAccountLabel.TabIndex = 5;
            this.accUpdatesAccountLabel.Text = "Account:";
            // 
            // accUpdatesLastUpdateValue
            // 
            this.accUpdatesLastUpdateValue.AutoSize = true;
            this.accUpdatesLastUpdateValue.Location = new System.Drawing.Point(303, 11);
            this.accUpdatesLastUpdateValue.Name = "accUpdatesLastUpdateValue";
            this.accUpdatesLastUpdateValue.Size = new System.Drawing.Size(16, 13);
            this.accUpdatesLastUpdateValue.TabIndex = 4;
            this.accUpdatesLastUpdateValue.Text = "...";
            // 
            // accountPortfolioGrid
            // 
            this.accountPortfolioGrid.AllowUserToAddRows = false;
            this.accountPortfolioGrid.AllowUserToDeleteRows = false;
            this.accountPortfolioGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.accountPortfolioGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.updatePortfolioContract,
            this.updatePortfolioPosition,
            this.updatePortfolioMarketPrice,
            this.updatePortfolioMarketValue,
            this.updatePortfolioAvgCost,
            this.updatePortfolioUnrealisedPnL,
            this.updatePortfolioRealisedPnL});
            this.accountPortfolioGrid.Location = new System.Drawing.Point(376, 35);
            this.accountPortfolioGrid.Name = "accountPortfolioGrid";
            this.accountPortfolioGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.accountPortfolioGrid.Size = new System.Drawing.Size(825, 346);
            this.accountPortfolioGrid.TabIndex = 1;
            // 
            // updatePortfolioContract
            // 
            this.updatePortfolioContract.HeaderText = "Contract";
            this.updatePortfolioContract.Name = "updatePortfolioContract";
            this.updatePortfolioContract.ReadOnly = true;
            this.updatePortfolioContract.Width = 140;
            // 
            // updatePortfolioPosition
            // 
            this.updatePortfolioPosition.HeaderText = "Position";
            this.updatePortfolioPosition.Name = "updatePortfolioPosition";
            this.updatePortfolioPosition.ReadOnly = true;
            // 
            // updatePortfolioMarketPrice
            // 
            this.updatePortfolioMarketPrice.HeaderText = "Market Price";
            this.updatePortfolioMarketPrice.Name = "updatePortfolioMarketPrice";
            this.updatePortfolioMarketPrice.ReadOnly = true;
            // 
            // updatePortfolioMarketValue
            // 
            this.updatePortfolioMarketValue.HeaderText = "Market Value";
            this.updatePortfolioMarketValue.Name = "updatePortfolioMarketValue";
            this.updatePortfolioMarketValue.ReadOnly = true;
            // 
            // updatePortfolioAvgCost
            // 
            this.updatePortfolioAvgCost.HeaderText = "Average Cost";
            this.updatePortfolioAvgCost.Name = "updatePortfolioAvgCost";
            this.updatePortfolioAvgCost.ReadOnly = true;
            // 
            // updatePortfolioUnrealisedPnL
            // 
            this.updatePortfolioUnrealisedPnL.HeaderText = "Unrealised P&L";
            this.updatePortfolioUnrealisedPnL.Name = "updatePortfolioUnrealisedPnL";
            this.updatePortfolioUnrealisedPnL.ReadOnly = true;
            this.updatePortfolioUnrealisedPnL.Width = 120;
            // 
            // updatePortfolioRealisedPnL
            // 
            this.updatePortfolioRealisedPnL.HeaderText = "Realised P&L";
            this.updatePortfolioRealisedPnL.Name = "updatePortfolioRealisedPnL";
            this.updatePortfolioRealisedPnL.ReadOnly = true;
            this.updatePortfolioRealisedPnL.Width = 120;
            // 
            // accountValuesGrid
            // 
            this.accountValuesGrid.AllowUserToAddRows = false;
            this.accountValuesGrid.AllowUserToDeleteRows = false;
            this.accountValuesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.accountValuesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.accUpdatesKey,
            this.accUpdatesValue,
            this.accUpdatesCurrency});
            this.accountValuesGrid.Location = new System.Drawing.Point(6, 35);
            this.accountValuesGrid.Name = "accountValuesGrid";
            this.accountValuesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.accountValuesGrid.Size = new System.Drawing.Size(364, 346);
            this.accountValuesGrid.TabIndex = 0;
            // 
            // accUpdatesKey
            // 
            this.accUpdatesKey.HeaderText = "Key";
            this.accUpdatesKey.Name = "accUpdatesKey";
            this.accUpdatesKey.ReadOnly = true;
            this.accUpdatesKey.Width = 150;
            // 
            // accUpdatesValue
            // 
            this.accUpdatesValue.HeaderText = "Value";
            this.accUpdatesValue.Name = "accUpdatesValue";
            this.accUpdatesValue.ReadOnly = true;
            this.accUpdatesValue.Width = 90;
            // 
            // accUpdatesCurrency
            // 
            this.accUpdatesCurrency.HeaderText = "Currency";
            this.accUpdatesCurrency.Name = "accUpdatesCurrency";
            this.accUpdatesCurrency.ReadOnly = true;
            this.accUpdatesCurrency.Width = 60;
            // 
            // accUpdatesSubscribe
            // 
            this.accUpdatesSubscribe.Location = new System.Drawing.Point(6, 6);
            this.accUpdatesSubscribe.Name = "accUpdatesSubscribe";
            this.accUpdatesSubscribe.Size = new System.Drawing.Size(75, 23);
            this.accUpdatesSubscribe.TabIndex = 2;
            this.accUpdatesSubscribe.Text = "Subscribe";
            this.accUpdatesSubscribe.UseVisualStyleBackColor = true;
            this.accUpdatesSubscribe.Click += new System.EventHandler(this.accUpdatesSubscribe_Click);
            // 
            // lastUpdatedLabel
            // 
            this.lastUpdatedLabel.AutoSize = true;
            this.lastUpdatedLabel.Location = new System.Drawing.Point(225, 11);
            this.lastUpdatedLabel.Name = "lastUpdatedLabel";
            this.lastUpdatedLabel.Size = new System.Drawing.Size(72, 13);
            this.lastUpdatedLabel.TabIndex = 3;
            this.lastUpdatedLabel.Text = "Last updated:";
            // 
            // positionsTab
            // 
            this.positionsTab.BackColor = System.Drawing.Color.LightGray;
            this.positionsTab.Controls.Add(this.positionRequest);
            this.positionsTab.Controls.Add(this.positionsGrid);
            this.positionsTab.Location = new System.Drawing.Point(4, 22);
            this.positionsTab.Name = "positionsTab";
            this.positionsTab.Padding = new System.Windows.Forms.Padding(3);
            this.positionsTab.Size = new System.Drawing.Size(1228, 398);
            this.positionsTab.TabIndex = 2;
            this.positionsTab.Text = "Positions (all accounts)";
            // 
            // positionRequest
            // 
            this.positionRequest.Location = new System.Drawing.Point(507, 6);
            this.positionRequest.Name = "positionRequest";
            this.positionRequest.Size = new System.Drawing.Size(75, 23);
            this.positionRequest.TabIndex = 1;
            this.positionRequest.Text = "Request";
            this.positionRequest.UseVisualStyleBackColor = true;
            this.positionRequest.Click += new System.EventHandler(this.positionRequest_Click);
            // 
            // positionsGrid
            // 
            this.positionsGrid.AllowUserToAddRows = false;
            this.positionsGrid.AllowUserToDeleteRows = false;
            this.positionsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.positionsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.positionContract,
            this.positionAccount,
            this.positionPosition,
            this.positionAvgCost});
            this.positionsGrid.Location = new System.Drawing.Point(6, 6);
            this.positionsGrid.Name = "positionsGrid";
            this.positionsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.positionsGrid.Size = new System.Drawing.Size(495, 366);
            this.positionsGrid.TabIndex = 0;
            // 
            // positionContract
            // 
            this.positionContract.HeaderText = "Contract";
            this.positionContract.Name = "positionContract";
            this.positionContract.ReadOnly = true;
            this.positionContract.Width = 150;
            // 
            // positionAccount
            // 
            this.positionAccount.HeaderText = "Account";
            this.positionAccount.Name = "positionAccount";
            this.positionAccount.ReadOnly = true;
            // 
            // positionPosition
            // 
            this.positionPosition.HeaderText = "Position";
            this.positionPosition.Name = "positionPosition";
            this.positionPosition.ReadOnly = true;
            this.positionPosition.Width = 80;
            // 
            // positionAvgCost
            // 
            this.positionAvgCost.HeaderText = "Average Cost";
            this.positionAvgCost.Name = "positionAvgCost";
            this.positionAvgCost.ReadOnly = true;
            // 
            // accountSelectorLabel
            // 
            this.accountSelectorLabel.AutoSize = true;
            this.accountSelectorLabel.Location = new System.Drawing.Point(8, 3);
            this.accountSelectorLabel.Name = "accountSelectorLabel";
            this.accountSelectorLabel.Size = new System.Drawing.Size(85, 13);
            this.accountSelectorLabel.TabIndex = 1;
            this.accountSelectorLabel.Text = "Choose account";
            // 
            // accountSelector
            // 
            this.accountSelector.FormattingEnabled = true;
            this.accountSelector.Location = new System.Drawing.Point(99, 3);
            this.accountSelector.Name = "accountSelector";
            this.accountSelector.Size = new System.Drawing.Size(121, 21);
            this.accountSelector.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightGray;
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.contractFundamentalsGroupBox);
            this.tabPage1.Controls.Add(this.contractDetailsGroupBox);
            this.tabPage1.Controls.Add(this.contractInfoTab);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1248, 448);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "Contract Information";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.underlyingConId);
            this.groupBox5.Controls.Add(this.queryOptionParams);
            this.groupBox5.Location = new System.Drawing.Point(635, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(186, 95);
            this.groupBox5.TabIndex = 46;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Option parameters";
            this.informationTooltip.SetToolTip(this.groupBox5, "Requests all options available for the description provided on the Contract\'s det" +
        "ails section.");
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 49;
            this.label14.Text = "ConId";
            // 
            // underlyingConId
            // 
            this.underlyingConId.Location = new System.Drawing.Point(71, 19);
            this.underlyingConId.Name = "underlyingConId";
            this.underlyingConId.Size = new System.Drawing.Size(100, 20);
            this.underlyingConId.TabIndex = 50;
            // 
            // queryOptionParams
            // 
            this.queryOptionParams.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.queryOptionParams.Location = new System.Drawing.Point(102, 66);
            this.queryOptionParams.Name = "queryOptionParams";
            this.queryOptionParams.Size = new System.Drawing.Size(75, 23);
            this.queryOptionParams.TabIndex = 44;
            this.queryOptionParams.Text = "Request";
            this.informationTooltip.SetToolTip(this.queryOptionParams, "Requests security definition option parameters");
            this.queryOptionParams.UseVisualStyleBackColor = true;
            this.queryOptionParams.Click += new System.EventHandler(this.queryOptionParams_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.queryOptionChain);
            this.groupBox3.Controls.Add(this.optionChainUseSnapshot);
            this.groupBox3.Controls.Add(this.optionChainOptionExchangeLabel);
            this.groupBox3.Controls.Add(this.optionChainExchange);
            this.groupBox3.Location = new System.Drawing.Point(425, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(204, 95);
            this.groupBox3.TabIndex = 45;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Options chain";
            this.informationTooltip.SetToolTip(this.groupBox3, "Requests all options available for the description provided on the Contract\'s det" +
        "ails section.");
            // 
            // queryOptionChain
            // 
            this.queryOptionChain.Location = new System.Drawing.Point(120, 66);
            this.queryOptionChain.Name = "queryOptionChain";
            this.queryOptionChain.Size = new System.Drawing.Size(75, 23);
            this.queryOptionChain.TabIndex = 44;
            this.queryOptionChain.Text = "Request";
            this.informationTooltip.SetToolTip(this.queryOptionChain, "Requests all options available for the underlying provided on the Contract\'s deta" +
        "ils section.");
            this.queryOptionChain.UseVisualStyleBackColor = true;
            this.queryOptionChain.Click += new System.EventHandler(this.queryOptionChain_Click);
            // 
            // optionChainUseSnapshot
            // 
            this.optionChainUseSnapshot.AutoSize = true;
            this.optionChainUseSnapshot.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.optionChainUseSnapshot.Location = new System.Drawing.Point(37, 42);
            this.optionChainUseSnapshot.Name = "optionChainUseSnapshot";
            this.optionChainUseSnapshot.Size = new System.Drawing.Size(115, 17);
            this.optionChainUseSnapshot.TabIndex = 38;
            this.optionChainUseSnapshot.Text = "Use snapshot data";
            this.optionChainUseSnapshot.UseVisualStyleBackColor = true;
            // 
            // optionChainOptionExchangeLabel
            // 
            this.optionChainOptionExchangeLabel.AutoSize = true;
            this.optionChainOptionExchangeLabel.Location = new System.Drawing.Point(34, 19);
            this.optionChainOptionExchangeLabel.Name = "optionChainOptionExchangeLabel";
            this.optionChainOptionExchangeLabel.Size = new System.Drawing.Size(55, 13);
            this.optionChainOptionExchangeLabel.TabIndex = 36;
            this.optionChainOptionExchangeLabel.Text = "Exchange";
            // 
            // optionChainExchange
            // 
            this.optionChainExchange.Location = new System.Drawing.Point(95, 16);
            this.optionChainExchange.Name = "optionChainExchange";
            this.optionChainExchange.Size = new System.Drawing.Size(100, 20);
            this.optionChainExchange.TabIndex = 37;
            this.optionChainExchange.Text = "SMART";
            // 
            // contractFundamentalsGroupBox
            // 
            this.contractFundamentalsGroupBox.Controls.Add(this.fundamentalsQueryButton);
            this.contractFundamentalsGroupBox.Controls.Add(this.fundamentalsReportTypeLabel);
            this.contractFundamentalsGroupBox.Controls.Add(this.fundamentalsReportType);
            this.contractFundamentalsGroupBox.Location = new System.Drawing.Point(425, 107);
            this.contractFundamentalsGroupBox.Name = "contractFundamentalsGroupBox";
            this.contractFundamentalsGroupBox.Size = new System.Drawing.Size(204, 72);
            this.contractFundamentalsGroupBox.TabIndex = 36;
            this.contractFundamentalsGroupBox.TabStop = false;
            this.contractFundamentalsGroupBox.Text = "Fundamentals";
            // 
            // fundamentalsQueryButton
            // 
            this.fundamentalsQueryButton.Location = new System.Drawing.Point(120, 43);
            this.fundamentalsQueryButton.Name = "fundamentalsQueryButton";
            this.fundamentalsQueryButton.Size = new System.Drawing.Size(75, 23);
            this.fundamentalsQueryButton.TabIndex = 36;
            this.fundamentalsQueryButton.Text = "Query";
            this.informationTooltip.SetToolTip(this.fundamentalsQueryButton, "Requests Reuter\'s Fundamentals selected report for the given contract.");
            this.fundamentalsQueryButton.UseVisualStyleBackColor = true;
            this.fundamentalsQueryButton.Click += new System.EventHandler(this.fundamentalsQueryButton_Click);
            // 
            // fundamentalsReportTypeLabel
            // 
            this.fundamentalsReportTypeLabel.AutoSize = true;
            this.fundamentalsReportTypeLabel.Location = new System.Drawing.Point(6, 19);
            this.fundamentalsReportTypeLabel.Name = "fundamentalsReportTypeLabel";
            this.fundamentalsReportTypeLabel.Size = new System.Drawing.Size(62, 13);
            this.fundamentalsReportTypeLabel.TabIndex = 35;
            this.fundamentalsReportTypeLabel.Text = "Report type";
            // 
            // fundamentalsReportType
            // 
            this.fundamentalsReportType.FormattingEnabled = true;
            this.fundamentalsReportType.Location = new System.Drawing.Point(74, 16);
            this.fundamentalsReportType.Name = "fundamentalsReportType";
            this.fundamentalsReportType.Size = new System.Drawing.Size(121, 21);
            this.fundamentalsReportType.TabIndex = 34;
            // 
            // contractDetailsGroupBox
            // 
            this.contractDetailsGroupBox.Controls.Add(this.searchContractDetails);
            this.contractDetailsGroupBox.Controls.Add(this.conDetSymbolLabel);
            this.contractDetailsGroupBox.Controls.Add(this.conDetRightLabel);
            this.contractDetailsGroupBox.Controls.Add(this.conDetStrikeLabel);
            this.contractDetailsGroupBox.Controls.Add(this.conDetRight);
            this.contractDetailsGroupBox.Controls.Add(this.conDetLastTradeDateLabel);
            this.contractDetailsGroupBox.Controls.Add(this.conDetSecType);
            this.contractDetailsGroupBox.Controls.Add(this.conDetMultiplierLabel);
            this.contractDetailsGroupBox.Controls.Add(this.conDetSecTypeLabel);
            this.contractDetailsGroupBox.Controls.Add(this.conDetLocalSymbolLabel);
            this.contractDetailsGroupBox.Controls.Add(this.conDetExchangeLabel);
            this.contractDetailsGroupBox.Controls.Add(this.conDetExchange);
            this.contractDetailsGroupBox.Controls.Add(this.conDetLocalSymbol);
            this.contractDetailsGroupBox.Controls.Add(this.conDetMultiplier);
            this.contractDetailsGroupBox.Controls.Add(this.conDetCurrencyLabel);
            this.contractDetailsGroupBox.Controls.Add(this.conDetCurrency);
            this.contractDetailsGroupBox.Controls.Add(this.conDetLastTradeDateOrContractMonth);
            this.contractDetailsGroupBox.Controls.Add(this.conDetStrike);
            this.contractDetailsGroupBox.Controls.Add(this.conDetSymbol);
            this.contractDetailsGroupBox.Location = new System.Drawing.Point(8, 6);
            this.contractDetailsGroupBox.Name = "contractDetailsGroupBox";
            this.contractDetailsGroupBox.Size = new System.Drawing.Size(399, 173);
            this.contractDetailsGroupBox.TabIndex = 33;
            this.contractDetailsGroupBox.TabStop = false;
            this.contractDetailsGroupBox.Text = "Contract details";
            // 
            // searchContractDetails
            // 
            this.searchContractDetails.Location = new System.Drawing.Point(309, 144);
            this.searchContractDetails.Name = "searchContractDetails";
            this.searchContractDetails.Size = new System.Drawing.Size(75, 23);
            this.searchContractDetails.TabIndex = 34;
            this.searchContractDetails.Text = "Search";
            this.informationTooltip.SetToolTip(this.searchContractDetails, "Looks for all contracts matching the description provided.");
            this.searchContractDetails.UseVisualStyleBackColor = true;
            this.searchContractDetails.Click += new System.EventHandler(this.searchContractDetails_Click);
            // 
            // conDetSymbolLabel
            // 
            this.conDetSymbolLabel.AutoSize = true;
            this.conDetSymbolLabel.Location = new System.Drawing.Point(20, 26);
            this.conDetSymbolLabel.Name = "conDetSymbolLabel";
            this.conDetSymbolLabel.Size = new System.Drawing.Size(41, 13);
            this.conDetSymbolLabel.TabIndex = 17;
            this.conDetSymbolLabel.Text = "Symbol";
            // 
            // conDetRightLabel
            // 
            this.conDetRightLabel.AutoSize = true;
            this.conDetRightLabel.Location = new System.Drawing.Point(16, 127);
            this.conDetRightLabel.Name = "conDetRightLabel";
            this.conDetRightLabel.Size = new System.Drawing.Size(45, 13);
            this.conDetRightLabel.TabIndex = 59;
            this.conDetRightLabel.Text = "Put/Call";
            // 
            // conDetStrikeLabel
            // 
            this.conDetStrikeLabel.AutoSize = true;
            this.conDetStrikeLabel.Location = new System.Drawing.Point(234, 91);
            this.conDetStrikeLabel.Name = "conDetStrikeLabel";
            this.conDetStrikeLabel.Size = new System.Drawing.Size(34, 13);
            this.conDetStrikeLabel.TabIndex = 21;
            this.conDetStrikeLabel.Text = "Strike";
            // 
            // conDetRight
            // 
            this.conDetRight.FormattingEnabled = true;
            this.conDetRight.Location = new System.Drawing.Point(86, 127);
            this.conDetRight.Name = "conDetRight";
            this.conDetRight.Size = new System.Drawing.Size(100, 21);
            this.conDetRight.TabIndex = 58;
            // 
            // conDetLastTradeDateLabel
            // 
            this.conDetLastTradeDateLabel.Location = new System.Drawing.Point(192, 51);
            this.conDetLastTradeDateLabel.Name = "conDetLastTradeDateLabel";
            this.conDetLastTradeDateLabel.Size = new System.Drawing.Size(86, 33);
            this.conDetLastTradeDateLabel.TabIndex = 20;
            this.conDetLastTradeDateLabel.Text = "Last trade date / contract month";
            // 
            // conDetSecType
            // 
            this.conDetSecType.FormattingEnabled = true;
            this.conDetSecType.Items.AddRange(new object[] {
            "STK",
            "OPT",
            "FUT",
            "CASH",
            "BOND",
            "CFD",
            "FOP",
            "WAR",
            "IOPT",
            "FWD",
            "BAG",
            "IND",
            "BILL",
            "FUND",
            "FIXED",
            "SLB",
            "NEWS",
            "CMDTY",
            "BSK",
            "ICU",
            "ICS"});
            this.conDetSecType.Location = new System.Drawing.Point(86, 48);
            this.conDetSecType.Name = "conDetSecType";
            this.conDetSecType.Size = new System.Drawing.Size(100, 21);
            this.conDetSecType.TabIndex = 18;
            this.conDetSecType.Text = "STK";
            // 
            // conDetMultiplierLabel
            // 
            this.conDetMultiplierLabel.AutoSize = true;
            this.conDetMultiplierLabel.Location = new System.Drawing.Point(220, 26);
            this.conDetMultiplierLabel.Name = "conDetMultiplierLabel";
            this.conDetMultiplierLabel.Size = new System.Drawing.Size(48, 13);
            this.conDetMultiplierLabel.TabIndex = 22;
            this.conDetMultiplierLabel.Text = "Multiplier";
            // 
            // conDetSecTypeLabel
            // 
            this.conDetSecTypeLabel.AutoSize = true;
            this.conDetSecTypeLabel.Location = new System.Drawing.Point(11, 48);
            this.conDetSecTypeLabel.Name = "conDetSecTypeLabel";
            this.conDetSecTypeLabel.Size = new System.Drawing.Size(50, 13);
            this.conDetSecTypeLabel.TabIndex = 19;
            this.conDetSecTypeLabel.Text = "SecType";
            // 
            // conDetLocalSymbolLabel
            // 
            this.conDetLocalSymbolLabel.AutoSize = true;
            this.conDetLocalSymbolLabel.Location = new System.Drawing.Point(198, 117);
            this.conDetLocalSymbolLabel.Name = "conDetLocalSymbolLabel";
            this.conDetLocalSymbolLabel.Size = new System.Drawing.Size(70, 13);
            this.conDetLocalSymbolLabel.TabIndex = 25;
            this.conDetLocalSymbolLabel.Text = "Local Symbol";
            // 
            // conDetExchangeLabel
            // 
            this.conDetExchangeLabel.AutoSize = true;
            this.conDetExchangeLabel.Location = new System.Drawing.Point(6, 101);
            this.conDetExchangeLabel.Name = "conDetExchangeLabel";
            this.conDetExchangeLabel.Size = new System.Drawing.Size(55, 13);
            this.conDetExchangeLabel.TabIndex = 23;
            this.conDetExchangeLabel.Text = "Exchange";
            // 
            // conDetExchange
            // 
            this.conDetExchange.Location = new System.Drawing.Point(86, 101);
            this.conDetExchange.Name = "conDetExchange";
            this.conDetExchange.Size = new System.Drawing.Size(100, 20);
            this.conDetExchange.TabIndex = 27;
            this.conDetExchange.Text = "SMART";
            // 
            // conDetLocalSymbol
            // 
            this.conDetLocalSymbol.Location = new System.Drawing.Point(284, 117);
            this.conDetLocalSymbol.Name = "conDetLocalSymbol";
            this.conDetLocalSymbol.Size = new System.Drawing.Size(100, 20);
            this.conDetLocalSymbol.TabIndex = 31;
            // 
            // conDetMultiplier
            // 
            this.conDetMultiplier.Location = new System.Drawing.Point(284, 19);
            this.conDetMultiplier.Name = "conDetMultiplier";
            this.conDetMultiplier.Size = new System.Drawing.Size(100, 20);
            this.conDetMultiplier.TabIndex = 28;
            // 
            // conDetCurrencyLabel
            // 
            this.conDetCurrencyLabel.AutoSize = true;
            this.conDetCurrencyLabel.Location = new System.Drawing.Point(12, 75);
            this.conDetCurrencyLabel.Name = "conDetCurrencyLabel";
            this.conDetCurrencyLabel.Size = new System.Drawing.Size(49, 13);
            this.conDetCurrencyLabel.TabIndex = 24;
            this.conDetCurrencyLabel.Text = "Currency";
            // 
            // conDetCurrency
            // 
            this.conDetCurrency.Location = new System.Drawing.Point(86, 75);
            this.conDetCurrency.Name = "conDetCurrency";
            this.conDetCurrency.Size = new System.Drawing.Size(100, 20);
            this.conDetCurrency.TabIndex = 26;
            this.conDetCurrency.Text = "USD";
            // 
            // conDetLastTradeDateOrContractMonth
            // 
            this.conDetLastTradeDateOrContractMonth.Location = new System.Drawing.Point(284, 58);
            this.conDetLastTradeDateOrContractMonth.Name = "conDetLastTradeDateOrContractMonth";
            this.conDetLastTradeDateOrContractMonth.Size = new System.Drawing.Size(100, 20);
            this.conDetLastTradeDateOrContractMonth.TabIndex = 30;
            // 
            // conDetStrike
            // 
            this.conDetStrike.Location = new System.Drawing.Point(284, 91);
            this.conDetStrike.Name = "conDetStrike";
            this.conDetStrike.Size = new System.Drawing.Size(100, 20);
            this.conDetStrike.TabIndex = 29;
            this.conDetStrike.Text = "10";
            // 
            // conDetSymbol
            // 
            this.conDetSymbol.Location = new System.Drawing.Point(86, 23);
            this.conDetSymbol.Name = "conDetSymbol";
            this.conDetSymbol.Size = new System.Drawing.Size(100, 20);
            this.conDetSymbol.TabIndex = 16;
            this.conDetSymbol.Text = "IBKR";
            // 
            // contractInfoTab
            // 
            this.contractInfoTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contractInfoTab.Controls.Add(this.contractDetailsPage);
            this.contractInfoTab.Controls.Add(this.fundamentalsPage);
            this.contractInfoTab.Controls.Add(this.optionChainPage);
            this.contractInfoTab.Controls.Add(this.optionParametersPage);
            this.contractInfoTab.Location = new System.Drawing.Point(6, 185);
            this.contractInfoTab.Name = "contractInfoTab";
            this.contractInfoTab.SelectedIndex = 0;
            this.contractInfoTab.Size = new System.Drawing.Size(1236, 269);
            this.contractInfoTab.TabIndex = 32;
            // 
            // contractDetailsPage
            // 
            this.contractDetailsPage.BackColor = System.Drawing.Color.LightGray;
            this.contractDetailsPage.Controls.Add(this.contractDetailsGrid);
            this.contractDetailsPage.Location = new System.Drawing.Point(4, 22);
            this.contractDetailsPage.Name = "contractDetailsPage";
            this.contractDetailsPage.Padding = new System.Windows.Forms.Padding(3);
            this.contractDetailsPage.Size = new System.Drawing.Size(1228, 243);
            this.contractDetailsPage.TabIndex = 0;
            this.contractDetailsPage.Text = "Contract Details";
            // 
            // contractDetailsGrid
            // 
            this.contractDetailsGrid.AllowUserToAddRows = false;
            this.contractDetailsGrid.AllowUserToDeleteRows = false;
            this.contractDetailsGrid.AllowUserToOrderColumns = true;
            this.contractDetailsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contractDetailsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.contractDetailsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.conResSymbol,
            this.conResLocalSymbol,
            this.conResSecType,
            this.conResCurrency,
            this.conResExchange,
            this.conResPrimaryExch,
            this.conResLastTradeDate,
            this.conResMultiplier,
            this.conResStrike,
            this.conResRight,
            this.conResConId});
            this.contractDetailsGrid.Location = new System.Drawing.Point(6, 6);
            this.contractDetailsGrid.Name = "contractDetailsGrid";
            this.contractDetailsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.contractDetailsGrid.Size = new System.Drawing.Size(1216, 231);
            this.contractDetailsGrid.TabIndex = 0;
            // 
            // conResSymbol
            // 
            this.conResSymbol.HeaderText = "Symbol";
            this.conResSymbol.Name = "conResSymbol";
            this.conResSymbol.ReadOnly = true;
            // 
            // conResLocalSymbol
            // 
            this.conResLocalSymbol.HeaderText = "Local Symbol";
            this.conResLocalSymbol.Name = "conResLocalSymbol";
            this.conResLocalSymbol.ReadOnly = true;
            // 
            // conResSecType
            // 
            this.conResSecType.HeaderText = "Type";
            this.conResSecType.Name = "conResSecType";
            this.conResSecType.ReadOnly = true;
            // 
            // conResCurrency
            // 
            this.conResCurrency.HeaderText = "Currency";
            this.conResCurrency.Name = "conResCurrency";
            this.conResCurrency.ReadOnly = true;
            // 
            // conResExchange
            // 
            this.conResExchange.HeaderText = "Exchange";
            this.conResExchange.Name = "conResExchange";
            this.conResExchange.ReadOnly = true;
            // 
            // conResPrimaryExch
            // 
            this.conResPrimaryExch.HeaderText = "Primary Exch.";
            this.conResPrimaryExch.Name = "conResPrimaryExch";
            this.conResPrimaryExch.ReadOnly = true;
            // 
            // conResLastTradeDate
            // 
            this.conResLastTradeDate.HeaderText = "lastTradeDate";
            this.conResLastTradeDate.Name = "conResLastTradeDate";
            this.conResLastTradeDate.ReadOnly = true;
            // 
            // conResMultiplier
            // 
            this.conResMultiplier.HeaderText = "Multiplier";
            this.conResMultiplier.Name = "conResMultiplier";
            this.conResMultiplier.ReadOnly = true;
            // 
            // conResStrike
            // 
            this.conResStrike.HeaderText = "Strike";
            this.conResStrike.Name = "conResStrike";
            this.conResStrike.ReadOnly = true;
            // 
            // conResRight
            // 
            this.conResRight.HeaderText = "P/C";
            this.conResRight.Name = "conResRight";
            this.conResRight.ReadOnly = true;
            // 
            // conResConId
            // 
            this.conResConId.HeaderText = "ConId";
            this.conResConId.Name = "conResConId";
            this.conResConId.ReadOnly = true;
            // 
            // fundamentalsPage
            // 
            this.fundamentalsPage.BackColor = System.Drawing.Color.LightGray;
            this.fundamentalsPage.Controls.Add(this.fundamentalsOutput);
            this.fundamentalsPage.Location = new System.Drawing.Point(4, 22);
            this.fundamentalsPage.Name = "fundamentalsPage";
            this.fundamentalsPage.Padding = new System.Windows.Forms.Padding(3);
            this.fundamentalsPage.Size = new System.Drawing.Size(1228, 243);
            this.fundamentalsPage.TabIndex = 1;
            this.fundamentalsPage.Text = "Fundamentals";
            // 
            // fundamentalsOutput
            // 
            this.fundamentalsOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fundamentalsOutput.Location = new System.Drawing.Point(6, 6);
            this.fundamentalsOutput.Multiline = true;
            this.fundamentalsOutput.Name = "fundamentalsOutput";
            this.fundamentalsOutput.ReadOnly = true;
            this.fundamentalsOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.fundamentalsOutput.Size = new System.Drawing.Size(1216, 231);
            this.fundamentalsOutput.TabIndex = 0;
            // 
            // optionChainPage
            // 
            this.optionChainPage.BackColor = System.Drawing.Color.LightGray;
            this.optionChainPage.Controls.Add(this.optionChainCallGroup);
            this.optionChainPage.Controls.Add(this.optionChainPutGroup);
            this.optionChainPage.Location = new System.Drawing.Point(4, 22);
            this.optionChainPage.Name = "optionChainPage";
            this.optionChainPage.Padding = new System.Windows.Forms.Padding(3);
            this.optionChainPage.Size = new System.Drawing.Size(1228, 243);
            this.optionChainPage.TabIndex = 2;
            this.optionChainPage.Text = "Options chain";
            // 
            // optionChainCallGroup
            // 
            this.optionChainCallGroup.Controls.Add(this.optionChainCallGrid);
            this.optionChainCallGroup.Location = new System.Drawing.Point(6, 6);
            this.optionChainCallGroup.Name = "optionChainCallGroup";
            this.optionChainCallGroup.Size = new System.Drawing.Size(590, 231);
            this.optionChainCallGroup.TabIndex = 43;
            this.optionChainCallGroup.TabStop = false;
            this.optionChainCallGroup.Text = "Calls";
            // 
            // optionChainCallGrid
            // 
            this.optionChainCallGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.optionChainCallGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.callLastTradeDate,
            this.callStrike,
            this.callBid,
            this.callAsk,
            this.callImpliedVolatility,
            this.callDelta,
            this.callGamma,
            this.callVega,
            this.callTheta});
            this.optionChainCallGrid.Location = new System.Drawing.Point(6, 19);
            this.optionChainCallGrid.Name = "optionChainCallGrid";
            this.optionChainCallGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.optionChainCallGrid.Size = new System.Drawing.Size(576, 206);
            this.optionChainCallGrid.TabIndex = 40;
            // 
            // callLastTradeDate
            // 
            this.callLastTradeDate.HeaderText = "lastTradeDate";
            this.callLastTradeDate.Name = "callLastTradeDate";
            this.callLastTradeDate.Width = 70;
            // 
            // callStrike
            // 
            this.callStrike.HeaderText = "Strike";
            this.callStrike.Name = "callStrike";
            this.callStrike.Width = 50;
            // 
            // callBid
            // 
            this.callBid.HeaderText = "Bid";
            this.callBid.Name = "callBid";
            this.callBid.ReadOnly = true;
            this.callBid.Width = 50;
            // 
            // callAsk
            // 
            this.callAsk.HeaderText = "Ask";
            this.callAsk.Name = "callAsk";
            this.callAsk.ReadOnly = true;
            this.callAsk.Width = 50;
            // 
            // callImpliedVolatility
            // 
            this.callImpliedVolatility.HeaderText = "Imp. Vol.";
            this.callImpliedVolatility.Name = "callImpliedVolatility";
            this.callImpliedVolatility.ReadOnly = true;
            this.callImpliedVolatility.Width = 80;
            // 
            // callDelta
            // 
            this.callDelta.HeaderText = "Delta";
            this.callDelta.Name = "callDelta";
            this.callDelta.ReadOnly = true;
            this.callDelta.Width = 50;
            // 
            // callGamma
            // 
            this.callGamma.HeaderText = "Gamma";
            this.callGamma.Name = "callGamma";
            this.callGamma.ReadOnly = true;
            this.callGamma.Width = 50;
            // 
            // callVega
            // 
            this.callVega.HeaderText = "Vega";
            this.callVega.Name = "callVega";
            this.callVega.ReadOnly = true;
            this.callVega.Width = 50;
            // 
            // callTheta
            // 
            this.callTheta.HeaderText = "Theta";
            this.callTheta.Name = "callTheta";
            this.callTheta.ReadOnly = true;
            this.callTheta.Width = 50;
            // 
            // optionChainPutGroup
            // 
            this.optionChainPutGroup.Controls.Add(this.optionChainPutGrid);
            this.optionChainPutGroup.Location = new System.Drawing.Point(622, 6);
            this.optionChainPutGroup.Name = "optionChainPutGroup";
            this.optionChainPutGroup.Size = new System.Drawing.Size(591, 231);
            this.optionChainPutGroup.TabIndex = 42;
            this.optionChainPutGroup.TabStop = false;
            this.optionChainPutGroup.Text = "Puts";
            // 
            // optionChainPutGrid
            // 
            this.optionChainPutGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.optionChainPutGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.putLastTradeDate,
            this.putStrike,
            this.putBid,
            this.putAsk,
            this.putImpliedVolatility,
            this.putDelta,
            this.putGamma,
            this.putVega,
            this.putTheta});
            this.optionChainPutGrid.Location = new System.Drawing.Point(6, 19);
            this.optionChainPutGrid.Name = "optionChainPutGrid";
            this.optionChainPutGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.optionChainPutGrid.Size = new System.Drawing.Size(579, 206);
            this.optionChainPutGrid.TabIndex = 41;
            // 
            // putLastTradeDate
            // 
            this.putLastTradeDate.HeaderText = "lastTradeDate";
            this.putLastTradeDate.Name = "putLastTradeDate";
            this.putLastTradeDate.Width = 70;
            // 
            // putStrike
            // 
            this.putStrike.HeaderText = "Strike";
            this.putStrike.Name = "putStrike";
            this.putStrike.Width = 50;
            // 
            // putBid
            // 
            this.putBid.HeaderText = "Bid";
            this.putBid.Name = "putBid";
            this.putBid.ReadOnly = true;
            this.putBid.Width = 50;
            // 
            // putAsk
            // 
            this.putAsk.HeaderText = "Ask";
            this.putAsk.Name = "putAsk";
            this.putAsk.ReadOnly = true;
            this.putAsk.Width = 50;
            // 
            // putImpliedVolatility
            // 
            this.putImpliedVolatility.HeaderText = "Imp. Vol.";
            this.putImpliedVolatility.Name = "putImpliedVolatility";
            this.putImpliedVolatility.ReadOnly = true;
            this.putImpliedVolatility.Width = 80;
            // 
            // putDelta
            // 
            this.putDelta.HeaderText = "Delta";
            this.putDelta.Name = "putDelta";
            this.putDelta.ReadOnly = true;
            this.putDelta.Width = 50;
            // 
            // putGamma
            // 
            this.putGamma.HeaderText = "Gamma";
            this.putGamma.Name = "putGamma";
            this.putGamma.ReadOnly = true;
            this.putGamma.Width = 50;
            // 
            // putVega
            // 
            this.putVega.HeaderText = "Vega";
            this.putVega.Name = "putVega";
            this.putVega.ReadOnly = true;
            this.putVega.Width = 50;
            // 
            // putTheta
            // 
            this.putTheta.HeaderText = "Theta";
            this.putTheta.Name = "putTheta";
            this.putTheta.ReadOnly = true;
            this.putTheta.Width = 50;
            // 
            // optionParametersPage
            // 
            this.optionParametersPage.Controls.Add(this.listViewOptionParams);
            this.optionParametersPage.Location = new System.Drawing.Point(4, 22);
            this.optionParametersPage.Name = "optionParametersPage";
            this.optionParametersPage.Size = new System.Drawing.Size(1228, 243);
            this.optionParametersPage.TabIndex = 3;
            this.optionParametersPage.Text = "Option parameters";
            this.optionParametersPage.UseVisualStyleBackColor = true;
            // 
            // listViewOptionParams
            // 
            this.listViewOptionParams.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewOptionParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewOptionParams.Location = new System.Drawing.Point(0, 0);
            this.listViewOptionParams.Name = "listViewOptionParams";
            this.listViewOptionParams.Size = new System.Drawing.Size(1228, 243);
            this.listViewOptionParams.TabIndex = 0;
            this.listViewOptionParams.UseCompatibleStateImageBehavior = false;
            this.listViewOptionParams.View = System.Windows.Forms.View.Details;
            // 
            // advisorTab
            // 
            this.advisorTab.BackColor = System.Drawing.Color.LightGray;
            this.advisorTab.Controls.Add(this.advisorProfilesBox);
            this.advisorTab.Controls.Add(this.advisorGroupsBox);
            this.advisorTab.Controls.Add(this.advisorAliasesBox);
            this.advisorTab.Location = new System.Drawing.Point(4, 22);
            this.advisorTab.Name = "advisorTab";
            this.advisorTab.Padding = new System.Windows.Forms.Padding(3);
            this.advisorTab.Size = new System.Drawing.Size(1248, 448);
            this.advisorTab.TabIndex = 5;
            this.advisorTab.Text = "Financial Advisor";
            // 
            // advisorProfilesBox
            // 
            this.advisorProfilesBox.Controls.Add(this.saveProfiles);
            this.advisorProfilesBox.Controls.Add(this.loadProfiles);
            this.advisorProfilesBox.Controls.Add(this.advisorProfilesGrid);
            this.advisorProfilesBox.Location = new System.Drawing.Point(366, 229);
            this.advisorProfilesBox.Name = "advisorProfilesBox";
            this.advisorProfilesBox.Size = new System.Drawing.Size(774, 236);
            this.advisorProfilesBox.TabIndex = 2;
            this.advisorProfilesBox.TabStop = false;
            this.advisorProfilesBox.Text = "Profiles";
            // 
            // saveProfiles
            // 
            this.saveProfiles.Location = new System.Drawing.Point(87, 19);
            this.saveProfiles.Name = "saveProfiles";
            this.saveProfiles.Size = new System.Drawing.Size(75, 23);
            this.saveProfiles.TabIndex = 3;
            this.saveProfiles.Text = "Save";
            this.saveProfiles.UseVisualStyleBackColor = true;
            this.saveProfiles.Click += new System.EventHandler(this.saveProfiles_Click);
            // 
            // loadProfiles
            // 
            this.loadProfiles.Location = new System.Drawing.Point(6, 19);
            this.loadProfiles.Name = "loadProfiles";
            this.loadProfiles.Size = new System.Drawing.Size(75, 23);
            this.loadProfiles.TabIndex = 2;
            this.loadProfiles.Text = "Load";
            this.loadProfiles.UseVisualStyleBackColor = true;
            this.loadProfiles.Click += new System.EventHandler(this.loadProfiles_Click);
            // 
            // advisorProfilesGrid
            // 
            this.advisorProfilesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advisorProfilesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.profileName,
            this.profileType,
            this.profileAllocations});
            this.advisorProfilesGrid.Location = new System.Drawing.Point(6, 48);
            this.advisorProfilesGrid.Name = "advisorProfilesGrid";
            this.advisorProfilesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.advisorProfilesGrid.Size = new System.Drawing.Size(759, 182);
            this.advisorProfilesGrid.TabIndex = 1;
            // 
            // profileName
            // 
            this.profileName.HeaderText = "Name";
            this.profileName.Name = "profileName";
            this.profileName.Width = 150;
            // 
            // profileType
            // 
            this.profileType.HeaderText = "Type";
            this.profileType.Name = "profileType";
            this.profileType.Width = 150;
            // 
            // profileAllocations
            // 
            this.profileAllocations.HeaderText = "Allocations";
            this.profileAllocations.Name = "profileAllocations";
            this.profileAllocations.Width = 400;
            // 
            // advisorGroupsBox
            // 
            this.advisorGroupsBox.Controls.Add(this.saveGroups);
            this.advisorGroupsBox.Controls.Add(this.loadGroups);
            this.advisorGroupsBox.Controls.Add(this.advisorGroupsGrid);
            this.advisorGroupsBox.Location = new System.Drawing.Point(366, 6);
            this.advisorGroupsBox.Name = "advisorGroupsBox";
            this.advisorGroupsBox.Size = new System.Drawing.Size(774, 217);
            this.advisorGroupsBox.TabIndex = 1;
            this.advisorGroupsBox.TabStop = false;
            this.advisorGroupsBox.Text = "Groups";
            // 
            // saveGroups
            // 
            this.saveGroups.Location = new System.Drawing.Point(87, 19);
            this.saveGroups.Name = "saveGroups";
            this.saveGroups.Size = new System.Drawing.Size(75, 23);
            this.saveGroups.TabIndex = 2;
            this.saveGroups.Text = "Save";
            this.saveGroups.UseVisualStyleBackColor = true;
            this.saveGroups.Click += new System.EventHandler(this.saveGroups_Click);
            // 
            // loadGroups
            // 
            this.loadGroups.Location = new System.Drawing.Point(6, 19);
            this.loadGroups.Name = "loadGroups";
            this.loadGroups.Size = new System.Drawing.Size(75, 23);
            this.loadGroups.TabIndex = 1;
            this.loadGroups.Text = "Load";
            this.loadGroups.UseVisualStyleBackColor = true;
            this.loadGroups.Click += new System.EventHandler(this.loadGroups_Click);
            // 
            // advisorGroupsGrid
            // 
            this.advisorGroupsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advisorGroupsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.groupName,
            this.groupMethod,
            this.groupAccounts});
            this.advisorGroupsGrid.Location = new System.Drawing.Point(6, 48);
            this.advisorGroupsGrid.Name = "advisorGroupsGrid";
            this.advisorGroupsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.advisorGroupsGrid.Size = new System.Drawing.Size(759, 163);
            this.advisorGroupsGrid.TabIndex = 0;
            // 
            // groupName
            // 
            this.groupName.HeaderText = "Name";
            this.groupName.Name = "groupName";
            this.groupName.Width = 150;
            // 
            // groupMethod
            // 
            this.groupMethod.HeaderText = "Default Method";
            this.groupMethod.Name = "groupMethod";
            this.groupMethod.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.groupMethod.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.groupMethod.Width = 150;
            // 
            // groupAccounts
            // 
            this.groupAccounts.HeaderText = "Accounts";
            this.groupAccounts.Name = "groupAccounts";
            this.groupAccounts.Width = 400;
            // 
            // advisorAliasesBox
            // 
            this.advisorAliasesBox.Controls.Add(this.loadAliases);
            this.advisorAliasesBox.Controls.Add(this.advisorAliasesGrid);
            this.advisorAliasesBox.Location = new System.Drawing.Point(6, 6);
            this.advisorAliasesBox.Name = "advisorAliasesBox";
            this.advisorAliasesBox.Size = new System.Drawing.Size(354, 459);
            this.advisorAliasesBox.TabIndex = 0;
            this.advisorAliasesBox.TabStop = false;
            this.advisorAliasesBox.Text = "Aliases";
            // 
            // loadAliases
            // 
            this.loadAliases.Location = new System.Drawing.Point(6, 19);
            this.loadAliases.Name = "loadAliases";
            this.loadAliases.Size = new System.Drawing.Size(75, 23);
            this.loadAliases.TabIndex = 1;
            this.loadAliases.Text = "Load";
            this.loadAliases.UseVisualStyleBackColor = true;
            this.loadAliases.Click += new System.EventHandler(this.loadAliases_Click);
            // 
            // advisorAliasesGrid
            // 
            this.advisorAliasesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advisorAliasesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.advisorAccount,
            this.advisorAlias});
            this.advisorAliasesGrid.Location = new System.Drawing.Point(6, 48);
            this.advisorAliasesGrid.Name = "advisorAliasesGrid";
            this.advisorAliasesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.advisorAliasesGrid.Size = new System.Drawing.Size(342, 405);
            this.advisorAliasesGrid.TabIndex = 0;
            // 
            // advisorAccount
            // 
            this.advisorAccount.HeaderText = "Account";
            this.advisorAccount.Name = "advisorAccount";
            this.advisorAccount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.advisorAccount.Width = 130;
            // 
            // advisorAlias
            // 
            this.advisorAlias.HeaderText = "Alias";
            this.advisorAlias.Name = "advisorAlias";
            this.advisorAlias.Width = 150;
            // 
            // optionsTab
            // 
            this.optionsTab.BackColor = System.Drawing.Color.LightGray;
            this.optionsTab.Controls.Add(this.optionExchange);
            this.optionsTab.Controls.Add(this.optionExchangeLabel);
            this.optionsTab.Controls.Add(this.optionsQuantityLabel);
            this.optionsTab.Controls.Add(this.optionsPositionsGroupBox);
            this.optionsTab.Controls.Add(this.optionExerciseQuan);
            this.optionsTab.Controls.Add(this.overrideOption);
            this.optionsTab.Controls.Add(this.lapseOption);
            this.optionsTab.Controls.Add(this.exerciseOption);
            this.optionsTab.Controls.Add(this.exerciseAccountLabel);
            this.optionsTab.Controls.Add(this.exerciseAccount);
            this.optionsTab.Location = new System.Drawing.Point(4, 22);
            this.optionsTab.Name = "optionsTab";
            this.optionsTab.Padding = new System.Windows.Forms.Padding(3);
            this.optionsTab.Size = new System.Drawing.Size(1248, 448);
            this.optionsTab.TabIndex = 7;
            this.optionsTab.Text = "Option exercising";
            this.optionsTab.Click += new System.EventHandler(this.optionsTab_Click);
            // 
            // optionExchange
            // 
            this.optionExchange.Location = new System.Drawing.Point(1041, 77);
            this.optionExchange.Name = "optionExchange";
            this.optionExchange.Size = new System.Drawing.Size(100, 20);
            this.optionExchange.TabIndex = 12;
            // 
            // optionExchangeLabel
            // 
            this.optionExchangeLabel.AutoSize = true;
            this.optionExchangeLabel.Location = new System.Drawing.Point(980, 80);
            this.optionExchangeLabel.Name = "optionExchangeLabel";
            this.optionExchangeLabel.Size = new System.Drawing.Size(55, 13);
            this.optionExchangeLabel.TabIndex = 11;
            this.optionExchangeLabel.Text = "Exchange";
            // 
            // optionsQuantityLabel
            // 
            this.optionsQuantityLabel.AutoSize = true;
            this.optionsQuantityLabel.Location = new System.Drawing.Point(980, 52);
            this.optionsQuantityLabel.Name = "optionsQuantityLabel";
            this.optionsQuantityLabel.Size = new System.Drawing.Size(46, 13);
            this.optionsQuantityLabel.TabIndex = 10;
            this.optionsQuantityLabel.Text = "Quantity";
            // 
            // optionsPositionsGroupBox
            // 
            this.optionsPositionsGroupBox.Controls.Add(this.optionPositionsGrid);
            this.optionsPositionsGroupBox.Location = new System.Drawing.Point(12, 33);
            this.optionsPositionsGroupBox.Name = "optionsPositionsGroupBox";
            this.optionsPositionsGroupBox.Size = new System.Drawing.Size(962, 237);
            this.optionsPositionsGroupBox.TabIndex = 9;
            this.optionsPositionsGroupBox.TabStop = false;
            this.optionsPositionsGroupBox.Text = "Option long positions";
            // 
            // optionPositionsGrid
            // 
            this.optionPositionsGrid.AllowUserToAddRows = false;
            this.optionPositionsGrid.AllowUserToDeleteRows = false;
            this.optionPositionsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.optionPositionsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.optionContract,
            this.optionAccount,
            this.optionPosition,
            this.optionMarketPrice,
            this.optionMarketValue,
            this.optionAverageCost,
            this.optionUnrealisedPnL,
            this.optionRealisedPnL});
            this.optionPositionsGrid.Location = new System.Drawing.Point(10, 19);
            this.optionPositionsGrid.Name = "optionPositionsGrid";
            this.optionPositionsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.optionPositionsGrid.Size = new System.Drawing.Size(946, 207);
            this.optionPositionsGrid.TabIndex = 4;
            // 
            // optionContract
            // 
            this.optionContract.HeaderText = "Contract";
            this.optionContract.Name = "optionContract";
            this.optionContract.ReadOnly = true;
            this.optionContract.Width = 140;
            // 
            // optionAccount
            // 
            this.optionAccount.HeaderText = "Account";
            this.optionAccount.Name = "optionAccount";
            this.optionAccount.ReadOnly = true;
            // 
            // optionPosition
            // 
            this.optionPosition.HeaderText = "Position";
            this.optionPosition.Name = "optionPosition";
            this.optionPosition.ReadOnly = true;
            // 
            // optionMarketPrice
            // 
            this.optionMarketPrice.HeaderText = "Market Price";
            this.optionMarketPrice.Name = "optionMarketPrice";
            this.optionMarketPrice.ReadOnly = true;
            // 
            // optionMarketValue
            // 
            this.optionMarketValue.HeaderText = "Market Value";
            this.optionMarketValue.Name = "optionMarketValue";
            this.optionMarketValue.ReadOnly = true;
            // 
            // optionAverageCost
            // 
            this.optionAverageCost.HeaderText = "Average Cost";
            this.optionAverageCost.Name = "optionAverageCost";
            this.optionAverageCost.ReadOnly = true;
            // 
            // optionUnrealisedPnL
            // 
            this.optionUnrealisedPnL.HeaderText = "Unrealised P&L";
            this.optionUnrealisedPnL.Name = "optionUnrealisedPnL";
            this.optionUnrealisedPnL.ReadOnly = true;
            this.optionUnrealisedPnL.Width = 120;
            // 
            // optionRealisedPnL
            // 
            this.optionRealisedPnL.HeaderText = "Realised P&L";
            this.optionRealisedPnL.Name = "optionRealisedPnL";
            this.optionRealisedPnL.ReadOnly = true;
            this.optionRealisedPnL.Width = 120;
            // 
            // optionExerciseQuan
            // 
            this.optionExerciseQuan.Location = new System.Drawing.Point(1041, 52);
            this.optionExerciseQuan.Name = "optionExerciseQuan";
            this.optionExerciseQuan.Size = new System.Drawing.Size(100, 20);
            this.optionExerciseQuan.TabIndex = 8;
            this.optionExerciseQuan.Text = "0";
            // 
            // overrideOption
            // 
            this.overrideOption.AutoSize = true;
            this.overrideOption.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.overrideOption.Location = new System.Drawing.Point(1075, 103);
            this.overrideOption.Name = "overrideOption";
            this.overrideOption.Size = new System.Drawing.Size(66, 17);
            this.overrideOption.TabIndex = 7;
            this.overrideOption.Text = "Override";
            this.overrideOption.UseVisualStyleBackColor = true;
            // 
            // lapseOption
            // 
            this.lapseOption.Location = new System.Drawing.Point(980, 155);
            this.lapseOption.Name = "lapseOption";
            this.lapseOption.Size = new System.Drawing.Size(75, 23);
            this.lapseOption.TabIndex = 6;
            this.lapseOption.Text = "Lapse";
            this.lapseOption.UseVisualStyleBackColor = true;
            this.lapseOption.Click += new System.EventHandler(this.lapseOption_Click);
            // 
            // exerciseOption
            // 
            this.exerciseOption.Location = new System.Drawing.Point(980, 126);
            this.exerciseOption.Name = "exerciseOption";
            this.exerciseOption.Size = new System.Drawing.Size(75, 23);
            this.exerciseOption.TabIndex = 5;
            this.exerciseOption.Text = "Exercise";
            this.exerciseOption.UseVisualStyleBackColor = true;
            this.exerciseOption.Click += new System.EventHandler(this.exerciseOption_Click);
            // 
            // exerciseAccountLabel
            // 
            this.exerciseAccountLabel.AutoSize = true;
            this.exerciseAccountLabel.Location = new System.Drawing.Point(19, 17);
            this.exerciseAccountLabel.Name = "exerciseAccountLabel";
            this.exerciseAccountLabel.Size = new System.Drawing.Size(85, 13);
            this.exerciseAccountLabel.TabIndex = 3;
            this.exerciseAccountLabel.Text = "Choose account";
            // 
            // exerciseAccount
            // 
            this.exerciseAccount.FormattingEnabled = true;
            this.exerciseAccount.Location = new System.Drawing.Point(110, 14);
            this.exerciseAccount.Name = "exerciseAccount";
            this.exerciseAccount.Size = new System.Drawing.Size(121, 21);
            this.exerciseAccount.TabIndex = 2;
            this.exerciseAccount.SelectedIndexChanged += new System.EventHandler(this.exerciseAccount_SelectedIndexChanged);
            // 
            // acctPosTab
            // 
            this.acctPosTab.BackColor = System.Drawing.Color.LightGray;
            this.acctPosTab.Controls.Add(this.acctPosMultiPanel);
            this.acctPosTab.Controls.Add(this.groupBoxRequestData);
            this.acctPosTab.Location = new System.Drawing.Point(4, 22);
            this.acctPosTab.Name = "acctPosTab";
            this.acctPosTab.Padding = new System.Windows.Forms.Padding(3);
            this.acctPosTab.Size = new System.Drawing.Size(1248, 448);
            this.acctPosTab.TabIndex = 8;
            this.acctPosTab.Text = "Acct/Pos Multi";
            // 
            // acctPosMultiPanel
            // 
            this.acctPosMultiPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.acctPosMultiPanel.Controls.Add(this.tabPositionsMulti);
            this.acctPosMultiPanel.Controls.Add(this.tabAccountUpdatesMulti);
            this.acctPosMultiPanel.Location = new System.Drawing.Point(5, 124);
            this.acctPosMultiPanel.Margin = new System.Windows.Forms.Padding(0);
            this.acctPosMultiPanel.Name = "acctPosMultiPanel";
            this.acctPosMultiPanel.SelectedIndex = 0;
            this.acctPosMultiPanel.Size = new System.Drawing.Size(1242, 217);
            this.acctPosMultiPanel.TabIndex = 1;
            // 
            // tabPositionsMulti
            // 
            this.tabPositionsMulti.BackColor = System.Drawing.Color.LightGray;
            this.tabPositionsMulti.Controls.Add(this.clearPositionsMulti);
            this.tabPositionsMulti.Controls.Add(this.positionsMultiGrid);
            this.tabPositionsMulti.Location = new System.Drawing.Point(4, 22);
            this.tabPositionsMulti.Name = "tabPositionsMulti";
            this.tabPositionsMulti.Padding = new System.Windows.Forms.Padding(3);
            this.tabPositionsMulti.Size = new System.Drawing.Size(1234, 191);
            this.tabPositionsMulti.TabIndex = 0;
            this.tabPositionsMulti.Text = "Positions Multi";
            // 
            // clearPositionsMulti
            // 
            this.clearPositionsMulti.AutoSize = true;
            this.clearPositionsMulti.Location = new System.Drawing.Point(6, 3);
            this.clearPositionsMulti.Name = "clearPositionsMulti";
            this.clearPositionsMulti.Size = new System.Drawing.Size(31, 13);
            this.clearPositionsMulti.TabIndex = 6;
            this.clearPositionsMulti.TabStop = true;
            this.clearPositionsMulti.Text = "Clear";
            this.clearPositionsMulti.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.clearPositionsMulti_LinkClicked);
            // 
            // positionsMultiGrid
            // 
            this.positionsMultiGrid.AllowUserToAddRows = false;
            this.positionsMultiGrid.AllowUserToDeleteRows = false;
            this.positionsMultiGrid.AllowUserToOrderColumns = true;
            this.positionsMultiGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.positionsMultiGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.positionsMultiGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.accountPositionsMulti,
            this.modelCodePositionsMulti,
            this.contractPositionsMulti,
            this.positionPositionsMulti,
            this.avgCostPositionsMulti});
            this.positionsMultiGrid.Location = new System.Drawing.Point(3, 19);
            this.positionsMultiGrid.Name = "positionsMultiGrid";
            this.positionsMultiGrid.ReadOnly = true;
            this.positionsMultiGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.positionsMultiGrid.Size = new System.Drawing.Size(1225, 166);
            this.positionsMultiGrid.TabIndex = 0;
            // 
            // accountPositionsMulti
            // 
            this.accountPositionsMulti.HeaderText = "Account";
            this.accountPositionsMulti.Name = "accountPositionsMulti";
            this.accountPositionsMulti.ReadOnly = true;
            // 
            // modelCodePositionsMulti
            // 
            this.modelCodePositionsMulti.HeaderText = "Model Code";
            this.modelCodePositionsMulti.Name = "modelCodePositionsMulti";
            this.modelCodePositionsMulti.ReadOnly = true;
            // 
            // contractPositionsMulti
            // 
            this.contractPositionsMulti.HeaderText = "Contract";
            this.contractPositionsMulti.Name = "contractPositionsMulti";
            this.contractPositionsMulti.ReadOnly = true;
            this.contractPositionsMulti.Width = 300;
            // 
            // positionPositionsMulti
            // 
            this.positionPositionsMulti.HeaderText = "Position";
            this.positionPositionsMulti.Name = "positionPositionsMulti";
            this.positionPositionsMulti.ReadOnly = true;
            // 
            // avgCostPositionsMulti
            // 
            this.avgCostPositionsMulti.HeaderText = "Avg Cost";
            this.avgCostPositionsMulti.Name = "avgCostPositionsMulti";
            this.avgCostPositionsMulti.ReadOnly = true;
            // 
            // tabAccountUpdatesMulti
            // 
            this.tabAccountUpdatesMulti.BackColor = System.Drawing.Color.LightGray;
            this.tabAccountUpdatesMulti.Controls.Add(this.clearAccountUpdatesMulti);
            this.tabAccountUpdatesMulti.Controls.Add(this.accountUpdatesMultiGrid);
            this.tabAccountUpdatesMulti.Location = new System.Drawing.Point(4, 22);
            this.tabAccountUpdatesMulti.Name = "tabAccountUpdatesMulti";
            this.tabAccountUpdatesMulti.Padding = new System.Windows.Forms.Padding(3);
            this.tabAccountUpdatesMulti.Size = new System.Drawing.Size(1234, 191);
            this.tabAccountUpdatesMulti.TabIndex = 1;
            this.tabAccountUpdatesMulti.Text = "Account Updates Multi";
            // 
            // clearAccountUpdatesMulti
            // 
            this.clearAccountUpdatesMulti.AutoSize = true;
            this.clearAccountUpdatesMulti.Location = new System.Drawing.Point(6, 3);
            this.clearAccountUpdatesMulti.Name = "clearAccountUpdatesMulti";
            this.clearAccountUpdatesMulti.Size = new System.Drawing.Size(31, 13);
            this.clearAccountUpdatesMulti.TabIndex = 0;
            this.clearAccountUpdatesMulti.TabStop = true;
            this.clearAccountUpdatesMulti.Text = "Clear";
            this.clearAccountUpdatesMulti.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.clearAccountUpdatesMulti_LinkClicked);
            // 
            // accountUpdatesMultiGrid
            // 
            this.accountUpdatesMultiGrid.AllowUserToAddRows = false;
            this.accountUpdatesMultiGrid.AllowUserToDeleteRows = false;
            this.accountUpdatesMultiGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.accountUpdatesMultiGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.accountUpdatesMultiGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.accountAccountUpdatesMulti,
            this.modelCodeAccountUpdatesMulti,
            this.keyAccountUpdatesMulti,
            this.valueAccountUpdatesMulti,
            this.currencyAccountUpdatesMulti});
            this.accountUpdatesMultiGrid.Location = new System.Drawing.Point(4, 19);
            this.accountUpdatesMultiGrid.Name = "accountUpdatesMultiGrid";
            this.accountUpdatesMultiGrid.ReadOnly = true;
            this.accountUpdatesMultiGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.accountUpdatesMultiGrid.Size = new System.Drawing.Size(1224, 166);
            this.accountUpdatesMultiGrid.TabIndex = 1;
            // 
            // accountAccountUpdatesMulti
            // 
            this.accountAccountUpdatesMulti.HeaderText = "Account";
            this.accountAccountUpdatesMulti.Name = "accountAccountUpdatesMulti";
            this.accountAccountUpdatesMulti.ReadOnly = true;
            // 
            // modelCodeAccountUpdatesMulti
            // 
            this.modelCodeAccountUpdatesMulti.HeaderText = "Model Code";
            this.modelCodeAccountUpdatesMulti.Name = "modelCodeAccountUpdatesMulti";
            this.modelCodeAccountUpdatesMulti.ReadOnly = true;
            // 
            // keyAccountUpdatesMulti
            // 
            this.keyAccountUpdatesMulti.HeaderText = "Key";
            this.keyAccountUpdatesMulti.Name = "keyAccountUpdatesMulti";
            this.keyAccountUpdatesMulti.ReadOnly = true;
            // 
            // valueAccountUpdatesMulti
            // 
            this.valueAccountUpdatesMulti.HeaderText = "Value";
            this.valueAccountUpdatesMulti.Name = "valueAccountUpdatesMulti";
            this.valueAccountUpdatesMulti.ReadOnly = true;
            // 
            // currencyAccountUpdatesMulti
            // 
            this.currencyAccountUpdatesMulti.HeaderText = "Currency";
            this.currencyAccountUpdatesMulti.Name = "currencyAccountUpdatesMulti";
            this.currencyAccountUpdatesMulti.ReadOnly = true;
            this.currencyAccountUpdatesMulti.Width = 50;
            // 
            // groupBoxRequestData
            // 
            this.groupBoxRequestData.Controls.Add(this.buttonCancelAccountUpdatesMulti);
            this.groupBoxRequestData.Controls.Add(this.buttonCancelPositionsMulti);
            this.groupBoxRequestData.Controls.Add(this.buttonRequestAccountUpdatesMulti);
            this.groupBoxRequestData.Controls.Add(this.cbLedgerAndNLV);
            this.groupBoxRequestData.Controls.Add(this.labelAccount);
            this.groupBoxRequestData.Controls.Add(this.buttonRequestPositionsMulti);
            this.groupBoxRequestData.Controls.Add(this.labelModelCode);
            this.groupBoxRequestData.Controls.Add(this.textAccount);
            this.groupBoxRequestData.Controls.Add(this.textModelCode);
            this.groupBoxRequestData.Location = new System.Drawing.Point(6, 6);
            this.groupBoxRequestData.Name = "groupBoxRequestData";
            this.groupBoxRequestData.Size = new System.Drawing.Size(515, 92);
            this.groupBoxRequestData.TabIndex = 0;
            this.groupBoxRequestData.TabStop = false;
            this.groupBoxRequestData.Text = "Request Data";
            // 
            // buttonCancelAccountUpdatesMulti
            // 
            this.buttonCancelAccountUpdatesMulti.Location = new System.Drawing.Point(350, 48);
            this.buttonCancelAccountUpdatesMulti.Name = "buttonCancelAccountUpdatesMulti";
            this.buttonCancelAccountUpdatesMulti.Size = new System.Drawing.Size(153, 23);
            this.buttonCancelAccountUpdatesMulti.TabIndex = 9;
            this.buttonCancelAccountUpdatesMulti.Text = "Cancel Acct Updates Multi";
            this.buttonCancelAccountUpdatesMulti.UseVisualStyleBackColor = true;
            this.buttonCancelAccountUpdatesMulti.Click += new System.EventHandler(this.buttonCancelAccountUpdatesMulti_Click);
            // 
            // buttonCancelPositionsMulti
            // 
            this.buttonCancelPositionsMulti.Location = new System.Drawing.Point(350, 19);
            this.buttonCancelPositionsMulti.Name = "buttonCancelPositionsMulti";
            this.buttonCancelPositionsMulti.Size = new System.Drawing.Size(153, 23);
            this.buttonCancelPositionsMulti.TabIndex = 8;
            this.buttonCancelPositionsMulti.Text = "Cancel Positions Multi";
            this.buttonCancelPositionsMulti.UseVisualStyleBackColor = true;
            this.buttonCancelPositionsMulti.Click += new System.EventHandler(this.buttonCancelPositionsMulti_Click);
            // 
            // buttonRequestAccountUpdatesMulti
            // 
            this.buttonRequestAccountUpdatesMulti.Location = new System.Drawing.Point(191, 48);
            this.buttonRequestAccountUpdatesMulti.Name = "buttonRequestAccountUpdatesMulti";
            this.buttonRequestAccountUpdatesMulti.Size = new System.Drawing.Size(153, 23);
            this.buttonRequestAccountUpdatesMulti.TabIndex = 7;
            this.buttonRequestAccountUpdatesMulti.Text = "Req Account Updates Multi";
            this.buttonRequestAccountUpdatesMulti.UseVisualStyleBackColor = true;
            this.buttonRequestAccountUpdatesMulti.Click += new System.EventHandler(this.buttonRequestAccountUpdatesMulti_Click);
            // 
            // cbLedgerAndNLV
            // 
            this.cbLedgerAndNLV.AutoSize = true;
            this.cbLedgerAndNLV.Location = new System.Drawing.Point(85, 67);
            this.cbLedgerAndNLV.Name = "cbLedgerAndNLV";
            this.cbLedgerAndNLV.Size = new System.Drawing.Size(99, 17);
            this.cbLedgerAndNLV.TabIndex = 4;
            this.cbLedgerAndNLV.Text = "LedgerAndNLV";
            this.cbLedgerAndNLV.UseVisualStyleBackColor = true;
            // 
            // labelAccount
            // 
            this.labelAccount.AutoSize = true;
            this.labelAccount.Location = new System.Drawing.Point(32, 22);
            this.labelAccount.Name = "labelAccount";
            this.labelAccount.Size = new System.Drawing.Size(47, 13);
            this.labelAccount.TabIndex = 0;
            this.labelAccount.Text = "Account";
            // 
            // buttonRequestPositionsMulti
            // 
            this.buttonRequestPositionsMulti.Location = new System.Drawing.Point(191, 19);
            this.buttonRequestPositionsMulti.Name = "buttonRequestPositionsMulti";
            this.buttonRequestPositionsMulti.Size = new System.Drawing.Size(153, 23);
            this.buttonRequestPositionsMulti.TabIndex = 5;
            this.buttonRequestPositionsMulti.Text = "Request Positions Multi";
            this.buttonRequestPositionsMulti.UseVisualStyleBackColor = true;
            this.buttonRequestPositionsMulti.Click += new System.EventHandler(this.buttonRequestPositionsMulti_Click);
            // 
            // labelModelCode
            // 
            this.labelModelCode.AutoSize = true;
            this.labelModelCode.Location = new System.Drawing.Point(15, 48);
            this.labelModelCode.Name = "labelModelCode";
            this.labelModelCode.Size = new System.Drawing.Size(64, 13);
            this.labelModelCode.TabIndex = 1;
            this.labelModelCode.Text = "Model Code";
            // 
            // textAccount
            // 
            this.textAccount.Location = new System.Drawing.Point(85, 15);
            this.textAccount.Name = "textAccount";
            this.textAccount.Size = new System.Drawing.Size(100, 20);
            this.textAccount.TabIndex = 2;
            // 
            // textModelCode
            // 
            this.textModelCode.Location = new System.Drawing.Point(85, 41);
            this.textModelCode.Name = "textModelCode";
            this.textModelCode.Size = new System.Drawing.Size(100, 20);
            this.textModelCode.TabIndex = 3;
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(1181, 12);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 6;
            this.connectButton.Text = "Connect";
            this.informationTooltip.SetToolTip(this.connectButton, "Connects to TWS or IB Gateway.");
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // clientid_CT
            // 
            this.clientid_CT.Location = new System.Drawing.Point(1092, 15);
            this.clientid_CT.Name = "clientid_CT";
            this.clientid_CT.Size = new System.Drawing.Size(83, 20);
            this.clientid_CT.TabIndex = 5;
            this.clientid_CT.Text = "1";
            this.informationTooltip.SetToolTip(this.clientid_CT, "Each TWS can handle up to 8 simultaneous clients identifed by a unique Id.");
            // 
            // cliet_label_CT
            // 
            this.cliet_label_CT.AutoSize = true;
            this.cliet_label_CT.Location = new System.Drawing.Point(1041, 22);
            this.cliet_label_CT.Name = "cliet_label_CT";
            this.cliet_label_CT.Size = new System.Drawing.Size(45, 13);
            this.cliet_label_CT.TabIndex = 4;
            this.cliet_label_CT.Text = "Client Id";
            // 
            // port_CT
            // 
            this.port_CT.Location = new System.Drawing.Point(952, 16);
            this.port_CT.Name = "port_CT";
            this.port_CT.Size = new System.Drawing.Size(83, 20);
            this.port_CT.TabIndex = 3;
            this.port_CT.Text = "7496";
            this.informationTooltip.SetToolTip(this.port_CT, "TWS\' listening port.");
            // 
            // port_label_CT
            // 
            this.port_label_CT.AutoSize = true;
            this.port_label_CT.Location = new System.Drawing.Point(920, 22);
            this.port_label_CT.Name = "port_label_CT";
            this.port_label_CT.Size = new System.Drawing.Size(26, 13);
            this.port_label_CT.TabIndex = 2;
            this.port_label_CT.Text = "Port";
            // 
            // host_label_CT
            // 
            this.host_label_CT.AutoSize = true;
            this.host_label_CT.Location = new System.Drawing.Point(796, 22);
            this.host_label_CT.Name = "host_label_CT";
            this.host_label_CT.Size = new System.Drawing.Size(29, 13);
            this.host_label_CT.TabIndex = 0;
            this.host_label_CT.Text = "Host";
            // 
            // host_CT
            // 
            this.host_CT.Location = new System.Drawing.Point(831, 16);
            this.host_CT.Name = "host_CT";
            this.host_CT.Size = new System.Drawing.Size(83, 20);
            this.host_CT.TabIndex = 1;
            this.informationTooltip.SetToolTip(this.host_CT, "TWS host\'s IP address (leave blank if TWS is running on the same machine).");
            // 
            // comboTab
            // 
            this.comboTab.BackColor = System.Drawing.Color.LightGray;
            this.comboTab.Controls.Add(this.button2);
            this.comboTab.Controls.Add(this.comboDeltaNeutralBox);
            this.comboTab.Controls.Add(this.comboLegsBox);
            this.comboTab.Controls.Add(this.comboContractBox);
            this.comboTab.Location = new System.Drawing.Point(4, 22);
            this.comboTab.Name = "comboTab";
            this.comboTab.Padding = new System.Windows.Forms.Padding(3);
            this.comboTab.Size = new System.Drawing.Size(1248, 430);
            this.comboTab.TabIndex = 6;
            this.comboTab.Text = "Combo Trading (in progress)";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(792, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 84;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboDeltaNeutralBox
            // 
            this.comboDeltaNeutralBox.Controls.Add(this.comboDeltaNeutralSet);
            this.comboDeltaNeutralBox.Controls.Add(this.label2);
            this.comboDeltaNeutralBox.Controls.Add(this.label5);
            this.comboDeltaNeutralBox.Controls.Add(this.textBox1);
            this.comboDeltaNeutralBox.Controls.Add(this.label6);
            this.comboDeltaNeutralBox.Controls.Add(this.textBox2);
            this.comboDeltaNeutralBox.Controls.Add(this.textBox4);
            this.comboDeltaNeutralBox.Controls.Add(this.textBox3);
            this.comboDeltaNeutralBox.Controls.Add(this.comboBox1);
            this.comboDeltaNeutralBox.Controls.Add(this.label3);
            this.comboDeltaNeutralBox.Controls.Add(this.label4);
            this.comboDeltaNeutralBox.Location = new System.Drawing.Point(890, 6);
            this.comboDeltaNeutralBox.Name = "comboDeltaNeutralBox";
            this.comboDeltaNeutralBox.Size = new System.Drawing.Size(190, 155);
            this.comboDeltaNeutralBox.TabIndex = 83;
            this.comboDeltaNeutralBox.TabStop = false;
            this.comboDeltaNeutralBox.Text = "Delta Neutral";
            // 
            // comboDeltaNeutralSet
            // 
            this.comboDeltaNeutralSet.Location = new System.Drawing.Point(145, 17);
            this.comboDeltaNeutralSet.Name = "comboDeltaNeutralSet";
            this.comboDeltaNeutralSet.Size = new System.Drawing.Size(37, 23);
            this.comboDeltaNeutralSet.TabIndex = 84;
            this.comboDeltaNeutralSet.Text = "Set";
            this.comboDeltaNeutralSet.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 85;
            this.label2.Text = "Symbol";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 87;
            this.label5.Text = "SecType";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(71, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(68, 20);
            this.textBox1.TabIndex = 84;
            this.textBox1.Text = "IBKR";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 89;
            this.label6.Text = "Exchange";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(71, 124);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(67, 20);
            this.textBox2.TabIndex = 93;
            this.textBox2.Text = "20130908";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(71, 98);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(68, 20);
            this.textBox4.TabIndex = 92;
            this.textBox4.Text = "ISLAND";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(71, 72);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(68, 20);
            this.textBox3.TabIndex = 91;
            this.textBox3.Text = "USD";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "STK",
            "OPT",
            "FUT",
            "CASH",
            "BOND",
            "CFD",
            "FOP",
            "WAR",
            "IOPT",
            "FWD",
            "BAG",
            "IND",
            "BILL",
            "FUND",
            "FIXED",
            "SLB",
            "NEWS",
            "CMDTY",
            "BSK",
            "ICU",
            "ICS"});
            this.comboBox1.Location = new System.Drawing.Point(71, 45);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(68, 21);
            this.comboBox1.TabIndex = 86;
            this.comboBox1.Text = "STK";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 90;
            this.label3.Text = "Currency";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 88;
            this.label4.Text = "lastTradeDate";
            // 
            // comboLegsBox
            // 
            this.comboLegsBox.Controls.Add(this.dataGridView1);
            this.comboLegsBox.Location = new System.Drawing.Point(317, 6);
            this.comboLegsBox.Name = "comboLegsBox";
            this.comboLegsBox.Size = new System.Drawing.Size(469, 155);
            this.comboLegsBox.TabIndex = 80;
            this.comboLegsBox.TabStop = false;
            this.comboLegsBox.Text = "Combo legs";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.comboLegAction,
            this.comboLegRatio,
            this.comboLegDescription,
            this.comboLegPrice});
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(453, 130);
            this.dataGridView1.TabIndex = 0;
            // 
            // comboLegAction
            // 
            this.comboLegAction.HeaderText = "Action";
            this.comboLegAction.Name = "comboLegAction";
            this.comboLegAction.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.comboLegAction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.comboLegAction.Width = 50;
            // 
            // comboLegRatio
            // 
            this.comboLegRatio.HeaderText = "Ratio";
            this.comboLegRatio.Name = "comboLegRatio";
            this.comboLegRatio.Width = 50;
            // 
            // comboLegDescription
            // 
            this.comboLegDescription.HeaderText = "Description";
            this.comboLegDescription.Name = "comboLegDescription";
            this.comboLegDescription.Width = 200;
            // 
            // comboLegPrice
            // 
            this.comboLegPrice.HeaderText = "Price";
            this.comboLegPrice.Name = "comboLegPrice";
            // 
            // comboContractBox
            // 
            this.comboContractBox.Controls.Add(this.findComboContract);
            this.comboContractBox.Controls.Add(this.comboSymbolLabel);
            this.comboContractBox.Controls.Add(this.comboSymbol);
            this.comboContractBox.Controls.Add(this.comboStrike);
            this.comboContractBox.Controls.Add(this.comboRightLabel);
            this.comboContractBox.Controls.Add(this.comboLastTradeDate);
            this.comboContractBox.Controls.Add(this.comboStrikeLabel);
            this.comboContractBox.Controls.Add(this.comboCurrency);
            this.comboContractBox.Controls.Add(this.comboRight);
            this.comboContractBox.Controls.Add(this.comboCurrencyLabel);
            this.comboContractBox.Controls.Add(this.comboLastTradeDateLabel);
            this.comboContractBox.Controls.Add(this.comboMultiplier);
            this.comboContractBox.Controls.Add(this.comboSecType);
            this.comboContractBox.Controls.Add(this.comboLocalSymbol);
            this.comboContractBox.Controls.Add(this.comboMultiplierLabel);
            this.comboContractBox.Controls.Add(this.comboExchange);
            this.comboContractBox.Controls.Add(this.comboSecTypeLabel);
            this.comboContractBox.Controls.Add(this.comboExchangeLabel);
            this.comboContractBox.Controls.Add(this.comboLocalSymbolLabel);
            this.comboContractBox.Location = new System.Drawing.Point(9, 6);
            this.comboContractBox.Name = "comboContractBox";
            this.comboContractBox.Size = new System.Drawing.Size(293, 155);
            this.comboContractBox.TabIndex = 79;
            this.comboContractBox.TabStop = false;
            this.comboContractBox.Text = "Contract";
            // 
            // findComboContract
            // 
            this.findComboContract.AutoSize = true;
            this.findComboContract.Location = new System.Drawing.Point(253, 131);
            this.findComboContract.Name = "findComboContract";
            this.findComboContract.Size = new System.Drawing.Size(27, 13);
            this.findComboContract.TabIndex = 84;
            this.findComboContract.TabStop = true;
            this.findComboContract.Text = "Find";
            this.findComboContract.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.findComboContract_LinkClicked);
            // 
            // comboSymbolLabel
            // 
            this.comboSymbolLabel.AutoSize = true;
            this.comboSymbolLabel.Location = new System.Drawing.Point(16, 22);
            this.comboSymbolLabel.Name = "comboSymbolLabel";
            this.comboSymbolLabel.Size = new System.Drawing.Size(41, 13);
            this.comboSymbolLabel.TabIndex = 61;
            this.comboSymbolLabel.Text = "Symbol";
            // 
            // comboSymbol
            // 
            this.comboSymbol.Location = new System.Drawing.Point(63, 19);
            this.comboSymbol.Name = "comboSymbol";
            this.comboSymbol.Size = new System.Drawing.Size(68, 20);
            this.comboSymbol.TabIndex = 60;
            this.comboSymbol.Text = "IBKR";
            // 
            // comboStrike
            // 
            this.comboStrike.Location = new System.Drawing.Point(213, 71);
            this.comboStrike.Name = "comboStrike";
            this.comboStrike.Size = new System.Drawing.Size(67, 20);
            this.comboStrike.TabIndex = 73;
            // 
            // comboRightLabel
            // 
            this.comboRightLabel.AutoSize = true;
            this.comboRightLabel.Location = new System.Drawing.Point(12, 123);
            this.comboRightLabel.Name = "comboRightLabel";
            this.comboRightLabel.Size = new System.Drawing.Size(45, 13);
            this.comboRightLabel.TabIndex = 78;
            this.comboRightLabel.Text = "Put/Call";
            // 
            // comboLastTradeDate
            // 
            this.comboLastTradeDate.Location = new System.Drawing.Point(213, 45);
            this.comboLastTradeDate.Name = "comboLastTradeDate";
            this.comboLastTradeDate.Size = new System.Drawing.Size(67, 20);
            this.comboLastTradeDate.TabIndex = 74;
            this.comboLastTradeDate.Text = "20130908";
            // 
            // comboStrikeLabel
            // 
            this.comboStrikeLabel.AutoSize = true;
            this.comboStrikeLabel.Location = new System.Drawing.Point(173, 71);
            this.comboStrikeLabel.Name = "comboStrikeLabel";
            this.comboStrikeLabel.Size = new System.Drawing.Size(34, 13);
            this.comboStrikeLabel.TabIndex = 65;
            this.comboStrikeLabel.Text = "Strike";
            // 
            // comboCurrency
            // 
            this.comboCurrency.Location = new System.Drawing.Point(63, 71);
            this.comboCurrency.Name = "comboCurrency";
            this.comboCurrency.Size = new System.Drawing.Size(68, 20);
            this.comboCurrency.TabIndex = 70;
            this.comboCurrency.Text = "USD";
            // 
            // comboRight
            // 
            this.comboRight.FormattingEnabled = true;
            this.comboRight.Location = new System.Drawing.Point(63, 123);
            this.comboRight.Name = "comboRight";
            this.comboRight.Size = new System.Drawing.Size(68, 21);
            this.comboRight.TabIndex = 77;
            // 
            // comboCurrencyLabel
            // 
            this.comboCurrencyLabel.AutoSize = true;
            this.comboCurrencyLabel.Location = new System.Drawing.Point(8, 71);
            this.comboCurrencyLabel.Name = "comboCurrencyLabel";
            this.comboCurrencyLabel.Size = new System.Drawing.Size(49, 13);
            this.comboCurrencyLabel.TabIndex = 68;
            this.comboCurrencyLabel.Text = "Currency";
            // 
            // comboLastTradeDateLabel
            // 
            this.comboLastTradeDateLabel.AutoSize = true;
            this.comboLastTradeDateLabel.Location = new System.Drawing.Point(172, 44);
            this.comboLastTradeDateLabel.Name = "comboLastTradeDateLabel";
            this.comboLastTradeDateLabel.Size = new System.Drawing.Size(74, 13);
            this.comboLastTradeDateLabel.TabIndex = 64;
            this.comboLastTradeDateLabel.Text = "lastTradeDate";
            // 
            // comboMultiplier
            // 
            this.comboMultiplier.Location = new System.Drawing.Point(213, 22);
            this.comboMultiplier.Name = "comboMultiplier";
            this.comboMultiplier.Size = new System.Drawing.Size(67, 20);
            this.comboMultiplier.TabIndex = 72;
            // 
            // comboSecType
            // 
            this.comboSecType.FormattingEnabled = true;
            this.comboSecType.Items.AddRange(new object[] {
            "STK",
            "OPT",
            "FUT",
            "CASH",
            "BOND",
            "CFD",
            "FOP",
            "WAR",
            "IOPT",
            "FWD",
            "BAG",
            "IND",
            "BILL",
            "FUND",
            "FIXED",
            "SLB",
            "NEWS",
            "CMDTY",
            "BSK",
            "ICU",
            "ICS"});
            this.comboSecType.Location = new System.Drawing.Point(63, 44);
            this.comboSecType.Name = "comboSecType";
            this.comboSecType.Size = new System.Drawing.Size(68, 21);
            this.comboSecType.TabIndex = 62;
            this.comboSecType.Text = "STK";
            // 
            // comboLocalSymbol
            // 
            this.comboLocalSymbol.Location = new System.Drawing.Point(213, 97);
            this.comboLocalSymbol.Name = "comboLocalSymbol";
            this.comboLocalSymbol.Size = new System.Drawing.Size(67, 20);
            this.comboLocalSymbol.TabIndex = 75;
            // 
            // comboMultiplierLabel
            // 
            this.comboMultiplierLabel.AutoSize = true;
            this.comboMultiplierLabel.Location = new System.Drawing.Point(159, 22);
            this.comboMultiplierLabel.Name = "comboMultiplierLabel";
            this.comboMultiplierLabel.Size = new System.Drawing.Size(48, 13);
            this.comboMultiplierLabel.TabIndex = 66;
            this.comboMultiplierLabel.Text = "Multiplier";
            // 
            // comboExchange
            // 
            this.comboExchange.Location = new System.Drawing.Point(63, 97);
            this.comboExchange.Name = "comboExchange";
            this.comboExchange.Size = new System.Drawing.Size(68, 20);
            this.comboExchange.TabIndex = 71;
            this.comboExchange.Text = "ISLAND";
            // 
            // comboSecTypeLabel
            // 
            this.comboSecTypeLabel.AutoSize = true;
            this.comboSecTypeLabel.Location = new System.Drawing.Point(7, 44);
            this.comboSecTypeLabel.Name = "comboSecTypeLabel";
            this.comboSecTypeLabel.Size = new System.Drawing.Size(50, 13);
            this.comboSecTypeLabel.TabIndex = 63;
            this.comboSecTypeLabel.Text = "SecType";
            // 
            // comboExchangeLabel
            // 
            this.comboExchangeLabel.AutoSize = true;
            this.comboExchangeLabel.Location = new System.Drawing.Point(2, 97);
            this.comboExchangeLabel.Name = "comboExchangeLabel";
            this.comboExchangeLabel.Size = new System.Drawing.Size(55, 13);
            this.comboExchangeLabel.TabIndex = 67;
            this.comboExchangeLabel.Text = "Exchange";
            // 
            // comboLocalSymbolLabel
            // 
            this.comboLocalSymbolLabel.AutoSize = true;
            this.comboLocalSymbolLabel.Location = new System.Drawing.Point(137, 97);
            this.comboLocalSymbolLabel.Name = "comboLocalSymbolLabel";
            this.comboLocalSymbolLabel.Size = new System.Drawing.Size(70, 13);
            this.comboLocalSymbolLabel.TabIndex = 69;
            this.comboLocalSymbolLabel.Text = "Local Symbol";
            // 
            // status_CT
            // 
            this.status_CT.AutoSize = true;
            this.status_CT.Location = new System.Drawing.Point(47, 144);
            this.status_CT.Name = "status_CT";
            this.status_CT.Size = new System.Drawing.Size(82, 13);
            this.status_CT.TabIndex = 9;
            this.status_CT.Text = "Disconnected...";
            // 
            // status_label_CT
            // 
            this.status_label_CT.AutoSize = true;
            this.status_label_CT.Location = new System.Drawing.Point(6, 144);
            this.status_label_CT.Name = "status_label_CT";
            this.status_label_CT.Size = new System.Drawing.Size(40, 13);
            this.status_label_CT.TabIndex = 8;
            this.status_label_CT.Text = "Status:";
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.messagesTab);
            this.tabControl2.Location = new System.Drawing.Point(0, 545);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1256, 186);
            this.tabControl2.TabIndex = 8;
            // 
            // messagesTab
            // 
            this.messagesTab.BackColor = System.Drawing.Color.LightGray;
            this.messagesTab.Controls.Add(this.messageBoxClear_link);
            this.messagesTab.Controls.Add(this.messageBox);
            this.messagesTab.Controls.Add(this.status_CT);
            this.messagesTab.Controls.Add(this.status_label_CT);
            this.messagesTab.Location = new System.Drawing.Point(4, 22);
            this.messagesTab.Name = "messagesTab";
            this.messagesTab.Padding = new System.Windows.Forms.Padding(3);
            this.messagesTab.Size = new System.Drawing.Size(1248, 160);
            this.messagesTab.TabIndex = 0;
            this.messagesTab.Text = "Messages";
            // 
            // messageBoxClear_link
            // 
            this.messageBoxClear_link.AutoSize = true;
            this.messageBoxClear_link.Location = new System.Drawing.Point(6, 2);
            this.messageBoxClear_link.Name = "messageBoxClear_link";
            this.messageBoxClear_link.Size = new System.Drawing.Size(31, 13);
            this.messageBoxClear_link.TabIndex = 11;
            this.messageBoxClear_link.TabStop = true;
            this.messageBoxClear_link.Text = "Clear";
            this.messageBoxClear_link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.messageBoxClear_link_LinkClicked);
            // 
            // messageBox
            // 
            this.messageBox.AcceptsReturn = true;
            this.messageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageBox.Location = new System.Drawing.Point(6, 18);
            this.messageBox.Multiline = true;
            this.messageBox.Name = "messageBox";
            this.messageBox.ReadOnly = true;
            this.messageBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.messageBox.Size = new System.Drawing.Size(1236, 123);
            this.messageBox.TabIndex = 10;
            // 
            // informationTooltip
            // 
            this.informationTooltip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // ib_banner
            // 
            this.ib_banner.Image = ((System.Drawing.Image)(resources.GetObject("ib_banner.Image")));
            this.ib_banner.Location = new System.Drawing.Point(4, 4);
            this.ib_banner.Name = "ib_banner";
            this.ib_banner.Size = new System.Drawing.Size(238, 32);
            this.ib_banner.TabIndex = 9;
            this.ib_banner.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(512, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(734, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Live Trading ports: TWS: 7496; IB Gateway: 4001. Simulated Trading ports for new " +
    "installations of version 954.1 or newer:  TWS: 7497; IB Gateway: 4002";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Expirations";
            this.columnHeader1.Width = 141;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Strikes";
            this.columnHeader2.Width = 71;
            // 
            // IBSampleAppDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1263, 740);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ib_banner);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.clientid_CT);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.cliet_label_CT);
            this.Controls.Add(this.host_CT);
            this.Controls.Add(this.port_CT);
            this.Controls.Add(this.host_label_CT);
            this.Controls.Add(this.port_label_CT);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IBSampleAppDialog";
            this.Text = "Interactive Brokers - Sample Application C# TWS API v. 9.72";
            this.TabControl.ResumeLayout(false);
            this.marketDataTab.ResumeLayout(false);
            this.marketData_MDT.ResumeLayout(false);
            this.topMarketDataTab_MDT.ResumeLayout(false);
            this.topMarketDataTab_MDT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.marketDataGrid_MDT)).EndInit();
            this.deepBookTab_MDT.ResumeLayout(false);
            this.deepBookTab_MDT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deepBookGrid)).EndInit();
            this.historicalDataTab.ResumeLayout(false);
            this.historicalDataTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.historicalChart)).EndInit();
            this.rtBarsTab_MDT.ResumeLayout(false);
            this.rtBarsTab_MDT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rtBarsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtBarsChart)).EndInit();
            this.scannerTab.ResumeLayout(false);
            this.scannerTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scannerGrid)).EndInit();
            this.scannerParamsTab.ResumeLayout(false);
            this.scannerParamsTab.PerformLayout();
            this.dataResults_MDT.ResumeLayout(false);
            this.topMktData_MDT.ResumeLayout(false);
            this.deepBookGroupBox.ResumeLayout(false);
            this.deepBookGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.marketScanner_MDT.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tradingTab.ResumeLayout(false);
            this.tradingTab.PerformLayout();
            this.execFilterGroup.ResumeLayout(false);
            this.execFilterGroup.PerformLayout();
            this.executionsGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tradeLogGrid)).EndInit();
            this.liveOrdersGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.liveOrdersGrid)).EndInit();
            this.accountInfoTab.ResumeLayout(false);
            this.accountInfoTab.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.accSummaryTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.accSummaryGrid)).EndInit();
            this.accUpdatesTab.ResumeLayout(false);
            this.accUpdatesTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accountPortfolioGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountValuesGrid)).EndInit();
            this.positionsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.positionsGrid)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.contractFundamentalsGroupBox.ResumeLayout(false);
            this.contractFundamentalsGroupBox.PerformLayout();
            this.contractDetailsGroupBox.ResumeLayout(false);
            this.contractDetailsGroupBox.PerformLayout();
            this.contractInfoTab.ResumeLayout(false);
            this.contractDetailsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contractDetailsGrid)).EndInit();
            this.fundamentalsPage.ResumeLayout(false);
            this.fundamentalsPage.PerformLayout();
            this.optionChainPage.ResumeLayout(false);
            this.optionChainCallGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.optionChainCallGrid)).EndInit();
            this.optionChainPutGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.optionChainPutGrid)).EndInit();
            this.optionParametersPage.ResumeLayout(false);
            this.advisorTab.ResumeLayout(false);
            this.advisorProfilesBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advisorProfilesGrid)).EndInit();
            this.advisorGroupsBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advisorGroupsGrid)).EndInit();
            this.advisorAliasesBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advisorAliasesGrid)).EndInit();
            this.optionsTab.ResumeLayout(false);
            this.optionsTab.PerformLayout();
            this.optionsPositionsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.optionPositionsGrid)).EndInit();
            this.acctPosTab.ResumeLayout(false);
            this.acctPosMultiPanel.ResumeLayout(false);
            this.tabPositionsMulti.ResumeLayout(false);
            this.tabPositionsMulti.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.positionsMultiGrid)).EndInit();
            this.tabAccountUpdatesMulti.ResumeLayout(false);
            this.tabAccountUpdatesMulti.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accountUpdatesMultiGrid)).EndInit();
            this.groupBoxRequestData.ResumeLayout(false);
            this.groupBoxRequestData.PerformLayout();
            this.comboTab.ResumeLayout(false);
            this.comboDeltaNeutralBox.ResumeLayout(false);
            this.comboDeltaNeutralBox.PerformLayout();
            this.comboLegsBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.comboContractBox.ResumeLayout(false);
            this.comboContractBox.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.messagesTab.ResumeLayout(false);
            this.messagesTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ib_banner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage marketDataTab;
        private System.Windows.Forms.Label cliet_label_CT;
        private System.Windows.Forms.TextBox port_CT;
        private System.Windows.Forms.Label port_label_CT;
        private System.Windows.Forms.Label host_label_CT;
        private System.Windows.Forms.TextBox host_CT;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage messagesTab;
        private System.Windows.Forms.TextBox clientid_CT;
        private System.Windows.Forms.TabPage tradingTab;
        private System.Windows.Forms.TabPage accountInfoTab;
        private System.Windows.Forms.Label status_label_CT;
        private System.Windows.Forms.Label status_CT;
        private System.Windows.Forms.TabControl marketData_MDT;
        private System.Windows.Forms.TabPage topMarketDataTab_MDT;
        private System.Windows.Forms.DataGridView marketDataGrid_MDT;
        private System.Windows.Forms.LinkLabel closeMketDataTab;
        private System.Windows.Forms.TabPage deepBookTab_MDT;
        private System.Windows.Forms.DataGridView deepBookGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn bidBookMaker;
        private System.Windows.Forms.DataGridViewTextBoxColumn bidBookSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn bidBookPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn askBookPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn askBookSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn askBookMaker;
        private System.Windows.Forms.LinkLabel closeDeepBookLink;
        private System.Windows.Forms.TabPage historicalDataTab;
        private System.Windows.Forms.DataGridView barsGrid;
        private System.Windows.Forms.DataVisualization.Charting.Chart historicalChart;
        private System.Windows.Forms.DataGridViewTextBoxColumn hdDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn hdOpen;
        private System.Windows.Forms.DataGridViewTextBoxColumn hdHigh;
        private System.Windows.Forms.DataGridViewTextBoxColumn hdLow;
        private System.Windows.Forms.DataGridViewTextBoxColumn hdClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn hdVolume;
        private System.Windows.Forms.DataGridViewTextBoxColumn hdWap;
        private System.Windows.Forms.TabControl dataResults_MDT;
        private System.Windows.Forms.TabPage topMktData_MDT;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button deepBook_Button;
        private System.Windows.Forms.Label symbol_label_TMD_MDT;
        private System.Windows.Forms.Button marketData_Button;
        private System.Windows.Forms.ComboBox secType_TMD_MDT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label exchange_label_TMD_MDT;
        private System.Windows.Forms.TextBox localSymbol_TMD_MDT;
        private System.Windows.Forms.Label currency_label_TMD_MDT;
        private System.Windows.Forms.TextBox lastTradeDateOrContractMonth_TMD_MDT;
        private System.Windows.Forms.TextBox symbol_TMD_MDT;
        private System.Windows.Forms.TextBox strike_TMD_MDT;
        private System.Windows.Forms.TextBox currency_TMD_MDT;
        private System.Windows.Forms.TextBox multiplier_TMD_MDT;
        private System.Windows.Forms.TextBox exchange_TMD_MDT;
        private System.Windows.Forms.Label localSymbol_label_TMD_MDT;
        private System.Windows.Forms.Label putcall_label_TMD_MDT;
        private System.Windows.Forms.Label lastTradeDate_label_TMD_MDT;
        private System.Windows.Forms.Label strike_label_TMD_MDT;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button realTime_Button;
        private System.Windows.Forms.Button histData_Button;
        private System.Windows.Forms.Label hdEndDate_label_HDT;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox hdRequest_EndTime;
        private System.Windows.Forms.ComboBox hdRequest_WhatToShow;
        private System.Windows.Forms.TextBox hdRequest_Duration;
        private System.Windows.Forms.ComboBox hdRequest_BarSize;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox hdRequest_TimeUnit;
        private System.Windows.Forms.TabPage marketScanner_MDT;
        private System.Windows.Forms.LinkLabel histDataTabClose_MDT;
        private System.Windows.Forms.TabPage rtBarsTab_MDT;
        private System.Windows.Forms.DataGridView rtBarsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataVisualization.Charting.Chart rtBarsChart;
        private System.Windows.Forms.LinkLabel rtBarsCloseLink;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label scanNumRows_label;
        private System.Windows.Forms.Label scanStockType_label;
        private System.Windows.Forms.Label scanLocation_label;
        private System.Windows.Forms.Label scanInstrument_label;
        private System.Windows.Forms.Label scanCode_label;
        private System.Windows.Forms.TextBox scanNumRows;
        private System.Windows.Forms.ComboBox scanStockType;
        private System.Windows.Forms.ComboBox scanInstrument;
        private System.Windows.Forms.ComboBox scanCode;
        private System.Windows.Forms.Button scannerRequest_Button;
        private System.Windows.Forms.TabPage scannerTab;
        private System.Windows.Forms.DataGridView scannerGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn scanRank;
        private System.Windows.Forms.DataGridViewTextBoxColumn scanContract;
        private System.Windows.Forms.DataGridViewTextBoxColumn scanDistance;
        private System.Windows.Forms.DataGridViewTextBoxColumn scanBenchmark;
        private System.Windows.Forms.DataGridViewTextBoxColumn scanProjection;
        private System.Windows.Forms.DataGridViewTextBoxColumn scanLegStr;
        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.LinkLabel messageBoxClear_link;
        private System.Windows.Forms.ComboBox scanLocation;
        private System.Windows.Forms.LinkLabel scannerTab_link;
        private System.Windows.Forms.DataGridView liveOrdersGrid;
        private System.Windows.Forms.GroupBox executionsGroup;
        private System.Windows.Forms.GroupBox liveOrdersGroup;
        private System.Windows.Forms.DataGridView tradeLogGrid;
        private System.Windows.Forms.LinkLabel newOrderLink;
        private System.Windows.Forms.Button refreshExecutionsButton;
        private System.Windows.Forms.Button refreshOrdersButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cancelOrdersButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn permIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn actionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contractColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusColumn;
        private System.Windows.Forms.Button clientOrdersButton;
        private System.Windows.Forms.Button globalCancelButton;
        private System.Windows.Forms.Label accountSelectorLabel;
        private System.Windows.Forms.ComboBox accountSelector;
        private System.Windows.Forms.Label lastUpdatedLabel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage accSummaryTab;
        private System.Windows.Forms.TabPage accUpdatesTab;
        private System.Windows.Forms.Label accUpdatesLastUpdateValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExecutionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateTimeExecColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountExecColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn actionExecColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityExecColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionExecColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceExecColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commissionExecColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RealisedPnL;
        private System.Windows.Forms.TabPage positionsTab;
        private System.Windows.Forms.DataGridView accSummaryGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn tag;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
        private System.Windows.Forms.DataGridViewTextBoxColumn currency;
        private System.Windows.Forms.DataGridView accountValuesGrid;
        private System.Windows.Forms.DataGridView accountPortfolioGrid;
        private System.Windows.Forms.DataGridView positionsGrid;
        private System.Windows.Forms.Button accUpdatesSubscribe;
        private System.Windows.Forms.Button positionRequest;
        private System.Windows.Forms.Button accSummaryRequest;
        private System.Windows.Forms.Label accUpdatesAccountLabel;
        private System.Windows.Forms.Label accUpdatesSubscribedAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn updatePortfolioContract;
        private System.Windows.Forms.DataGridViewTextBoxColumn updatePortfolioPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn updatePortfolioMarketPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn updatePortfolioMarketValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn updatePortfolioAvgCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn updatePortfolioUnrealisedPnL;
        private System.Windows.Forms.DataGridViewTextBoxColumn updatePortfolioRealisedPnL;
        private System.Windows.Forms.DataGridViewTextBoxColumn accUpdatesKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn accUpdatesValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn accUpdatesCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionContract;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionAvgCost;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label conDetSymbolLabel;
        private System.Windows.Forms.ComboBox conDetSecType;
        private System.Windows.Forms.Label conDetSecTypeLabel;
        private System.Windows.Forms.Label conDetExchangeLabel;
        private System.Windows.Forms.TextBox conDetLocalSymbol;
        private System.Windows.Forms.Label conDetCurrencyLabel;
        private System.Windows.Forms.TextBox conDetLastTradeDateOrContractMonth;
        private System.Windows.Forms.TextBox conDetSymbol;
        private System.Windows.Forms.TextBox conDetStrike;
        private System.Windows.Forms.TextBox conDetCurrency;
        private System.Windows.Forms.TextBox conDetMultiplier;
        private System.Windows.Forms.TextBox conDetExchange;
        private System.Windows.Forms.Label conDetLocalSymbolLabel;
        private System.Windows.Forms.Label conDetMultiplierLabel;
        private System.Windows.Forms.Label conDetLastTradeDateLabel;
        private System.Windows.Forms.Label conDetStrikeLabel;
        private System.Windows.Forms.TabControl contractInfoTab;
        private System.Windows.Forms.TabPage contractDetailsPage;
        private System.Windows.Forms.TabPage fundamentalsPage;
        private System.Windows.Forms.DataGridView contractDetailsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn conResSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn conResLocalSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn conResSecType;
        private System.Windows.Forms.DataGridViewTextBoxColumn conResCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn conResExchange;
        private System.Windows.Forms.DataGridViewTextBoxColumn conResPrimaryExch;
        private System.Windows.Forms.DataGridViewTextBoxColumn conResLastTradeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn conResMultiplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn conResStrike;
        private System.Windows.Forms.DataGridViewTextBoxColumn conResRight;
        private System.Windows.Forms.DataGridViewTextBoxColumn conResConId;
        private System.Windows.Forms.GroupBox contractDetailsGroupBox;
        private System.Windows.Forms.TextBox fundamentalsOutput;
        private System.Windows.Forms.Button searchContractDetails;
        private System.Windows.Forms.ComboBox fundamentalsReportType;
        private System.Windows.Forms.Label fundamentalsReportTypeLabel;
        private System.Windows.Forms.GroupBox contractFundamentalsGroupBox;
        private System.Windows.Forms.Button fundamentalsQueryButton;
        private System.Windows.Forms.TabPage advisorTab;
        private System.Windows.Forms.GroupBox advisorAliasesBox;
        private System.Windows.Forms.GroupBox advisorGroupsBox;
        private System.Windows.Forms.GroupBox advisorProfilesBox;
        private System.Windows.Forms.DataGridView advisorGroupsGrid;
        private System.Windows.Forms.DataGridView advisorProfilesGrid;
        private System.Windows.Forms.DataGridView advisorAliasesGrid;
        private System.Windows.Forms.Button loadGroups;
        private System.Windows.Forms.Button loadAliases;
        private System.Windows.Forms.Button loadProfiles;
        private System.Windows.Forms.Button saveProfiles;
        private System.Windows.Forms.Button saveGroups;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupName;
        private System.Windows.Forms.DataGridViewComboBoxColumn groupMethod;// = new System.Windows.Forms.DataGridViewComboBoxColumn();
        private System.Windows.Forms.DataGridViewTextBoxColumn groupAccounts;
        private System.Windows.Forms.DataGridViewTextBoxColumn profileName;
        private System.Windows.Forms.DataGridViewComboBoxColumn profileType;
        private System.Windows.Forms.DataGridViewTextBoxColumn profileAllocations;
        private System.Windows.Forms.DataGridViewTextBoxColumn advisorAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn advisorAlias;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountSummaryAccount;
        private System.Windows.Forms.TabPage comboTab;
        private System.Windows.Forms.Label mdRightLabel;
        private System.Windows.Forms.ComboBox mdContractRight;
        private System.Windows.Forms.Label conDetRightLabel;
        private System.Windows.Forms.ComboBox conDetRight;
        private System.Windows.Forms.Label comboSymbolLabel;
        private System.Windows.Forms.Label comboRightLabel;
        private System.Windows.Forms.Label comboStrikeLabel;
        private System.Windows.Forms.ComboBox comboRight;
        private System.Windows.Forms.Label comboLastTradeDateLabel;
        private System.Windows.Forms.ComboBox comboSecType;
        private System.Windows.Forms.Label comboMultiplierLabel;
        private System.Windows.Forms.Label comboSecTypeLabel;
        private System.Windows.Forms.Label comboLocalSymbolLabel;
        private System.Windows.Forms.Label comboExchangeLabel;
        private System.Windows.Forms.TextBox comboExchange;
        private System.Windows.Forms.TextBox comboLocalSymbol;
        private System.Windows.Forms.TextBox comboMultiplier;
        private System.Windows.Forms.Label comboCurrencyLabel;
        private System.Windows.Forms.TextBox comboCurrency;
        private System.Windows.Forms.TextBox comboLastTradeDate;
        private System.Windows.Forms.TextBox comboStrike;
        private System.Windows.Forms.TextBox comboSymbol;
        private System.Windows.Forms.GroupBox comboContractBox;
        private System.Windows.Forms.GroupBox comboLegsBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox comboDeltaNeutralBox;
        private System.Windows.Forms.Button comboDeltaNeutralSet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel findComboContract;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewComboBoxColumn comboLegAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn comboLegRatio;
        private System.Windows.Forms.DataGridViewTextBoxColumn comboLegDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn comboLegPrice;
        private System.Windows.Forms.CheckBox includeExpired;
        private System.Windows.Forms.TabPage optionsTab;
        private System.Windows.Forms.Label optionChainOptionExchangeLabel;
        private System.Windows.Forms.TextBox optionChainExchange;
        private System.Windows.Forms.CheckBox optionChainUseSnapshot;
        private System.Windows.Forms.DataGridView optionChainCallGrid;
        private System.Windows.Forms.DataGridView optionChainPutGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn putLastTradeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn putStrike;
        private System.Windows.Forms.DataGridViewTextBoxColumn putBid;
        private System.Windows.Forms.DataGridViewTextBoxColumn putAsk;
        private System.Windows.Forms.DataGridViewTextBoxColumn putImpliedVolatility;
        private System.Windows.Forms.DataGridViewTextBoxColumn putDelta;
        private System.Windows.Forms.DataGridViewTextBoxColumn putGamma;
        private System.Windows.Forms.DataGridViewTextBoxColumn putVega;
        private System.Windows.Forms.DataGridViewTextBoxColumn putTheta;
        private System.Windows.Forms.DataGridViewTextBoxColumn callLastTradeDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn callStrike;
        private System.Windows.Forms.DataGridViewTextBoxColumn callBid;
        private System.Windows.Forms.DataGridViewTextBoxColumn callAsk;
        private System.Windows.Forms.DataGridViewTextBoxColumn callImpliedVolatility;
        private System.Windows.Forms.DataGridViewTextBoxColumn callDelta;
        private System.Windows.Forms.DataGridViewTextBoxColumn callGamma;
        private System.Windows.Forms.DataGridViewTextBoxColumn callVega;
        private System.Windows.Forms.DataGridViewTextBoxColumn callTheta;
        private System.Windows.Forms.GroupBox optionChainCallGroup;
        private System.Windows.Forms.GroupBox optionChainPutGroup;
        private System.Windows.Forms.Button queryOptionChain;
        private System.Windows.Forms.TabPage optionChainPage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolTip informationTooltip;
        private System.Windows.Forms.Label exerciseAccountLabel;
        private System.Windows.Forms.ComboBox exerciseAccount;
        private System.Windows.Forms.DataGridView optionPositionsGrid;
        private System.Windows.Forms.TextBox optionExerciseQuan;
        private System.Windows.Forms.CheckBox overrideOption;
        private System.Windows.Forms.Button lapseOption;
        private System.Windows.Forms.Button exerciseOption;
        private System.Windows.Forms.GroupBox optionsPositionsGroupBox;
        private System.Windows.Forms.Label optionsQuantityLabel;
        private System.Windows.Forms.TextBox genericTickList;
        private System.Windows.Forms.Label genericTickListLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn marketDataContract;
        private System.Windows.Forms.DataGridViewTextBoxColumn bidSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn bidPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn askPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn askSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn volume;
        private System.Windows.Forms.DataGridViewTextBoxColumn closeTickerColumn;
        private System.Windows.Forms.Button cancelMarketDataRequests;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionContract;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionMarketPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionMarketValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionAverageCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionUnrealisedPnL;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionRealisedPnL;
        private System.Windows.Forms.Label optionExchangeLabel;
        private System.Windows.Forms.TextBox optionExchange;
        private System.Windows.Forms.Label deepBookEntriesLabel;
        private System.Windows.Forms.TextBox deepBookEntries;
        private System.Windows.Forms.GroupBox deepBookGroupBox;
        private System.Windows.Forms.CheckBox contractMDRTH;
        private System.Windows.Forms.Label primaryExchLabel;
        private System.Windows.Forms.TextBox primaryExchange;
        private System.Windows.Forms.TabPage scannerParamsTab;
        private System.Windows.Forms.TextBox scannerParamsOutput;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button scannerParamsRequest_button;
        private System.Windows.Forms.GroupBox execFilterGroup;
        private System.Windows.Forms.Label execFilterClientLabel;
        private System.Windows.Forms.TextBox execFilterSecType;
        private System.Windows.Forms.TextBox execFilterSymbol;
        private System.Windows.Forms.TextBox execFilterTime;
        private System.Windows.Forms.TextBox execFilterAccount;
        private System.Windows.Forms.TextBox execFilterClientId;
        private System.Windows.Forms.TextBox execFilterExchange;
        private System.Windows.Forms.TextBox execFilterSide;
        private System.Windows.Forms.Label execFilterSideLabel;
        private System.Windows.Forms.Label execFilterExchangeLabel;
        private System.Windows.Forms.Label execFilterSecTypeLabel;
        private System.Windows.Forms.Label execFilterSymbolLabel;
        private System.Windows.Forms.Label execFilterTimeLabel;
        private System.Windows.Forms.Label execFilterAcctLabel;
        private System.Windows.Forms.PictureBox ib_banner;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage acctPosTab;
        private System.Windows.Forms.GroupBox groupBoxRequestData;
        private System.Windows.Forms.CheckBox cbLedgerAndNLV;
        private System.Windows.Forms.Label labelAccount;
        private System.Windows.Forms.Button buttonRequestPositionsMulti;
        private System.Windows.Forms.Label labelModelCode;
        private System.Windows.Forms.TextBox textAccount;
        private System.Windows.Forms.TextBox textModelCode;
        private System.Windows.Forms.TabControl acctPosMultiPanel;
        private System.Windows.Forms.TabPage tabPositionsMulti;
        private System.Windows.Forms.LinkLabel clearPositionsMulti;
        private System.Windows.Forms.DataGridView positionsMultiGrid;
        private System.Windows.Forms.TabPage tabAccountUpdatesMulti;
        private System.Windows.Forms.LinkLabel clearAccountUpdatesMulti;
        private System.Windows.Forms.DataGridView accountUpdatesMultiGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountAccountUpdatesMulti;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelCodeAccountUpdatesMulti;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyAccountUpdatesMulti;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueAccountUpdatesMulti;
        private System.Windows.Forms.DataGridViewTextBoxColumn currencyAccountUpdatesMulti;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountPositionsMulti;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelCodePositionsMulti;
        private System.Windows.Forms.DataGridViewTextBoxColumn contractPositionsMulti;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionPositionsMulti;
        private System.Windows.Forms.DataGridViewTextBoxColumn avgCostPositionsMulti;
        private System.Windows.Forms.Button buttonRequestAccountUpdatesMulti;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelCodeColumn;
        private System.Windows.Forms.Button buttonCancelPositionsMulti;
        private System.Windows.Forms.Button buttonCancelAccountUpdatesMulti;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox underlyingConId;
        private System.Windows.Forms.Button queryOptionParams;
        private System.Windows.Forms.TabPage optionParametersPage;
        private System.Windows.Forms.ListView listViewOptionParams;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}

