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
using IBApi;
using IBSampleApp.ui;
using IBSampleApp.messages;
using IBSampleApp.types;

namespace IBSampleApp
{
    public partial class OrderDialog : Form
    {
        private MarginDialog marginDialog;
        private OrderManager orderManager;
        private int orderId;
        private BindingSource orderBindingSource = new BindingSource();

        public OrderDialog(OrderManager orderManager)
        {
            InitializeComponent();
            InitialiseDropDowns();

            this.orderManager = orderManager;
            marginDialog = new MarginDialog();
            contractSearchControl1.IBClient = orderManager.IBClient;
            conditionList.CellFormatting += conditionList_CellFormatting;
            conditionList.DataSource = orderBindingSource;
            conditionList.AutoGenerateColumns = false;
            conditionList.CellParsing += conditionList_CellParsing;
            orderBindingSource.DataSource = new List<OrderCondition>();
            cancelOrder.SelectedIndex = 0;
        }

        void conditionList_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.ParsingApplied = false;

                return;
            }

            (orderBindingSource[e.RowIndex] as OrderCondition).IsConjunctionConnection = e.Value.ToString().Equals("and", StringComparison.InvariantCultureIgnoreCase);
        }

        void conditionList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (orderBindingSource.Count <= e.RowIndex)
                return;

            OrderCondition obj = orderBindingSource[e.RowIndex] as OrderCondition;

            e.FormattingApplied = true;

            switch (e.ColumnIndex)
            {
                case 0:
                    e.Value = obj.ToString();
                    break;

                case 1:
                    e.Value = obj.IsConjunctionConnection ? "and" : "or";
                    break;

                default:
                    e.FormattingApplied = false;
                    break;
            }
        }

        public Order CurrentOrder
        {
            set { SetOrder(value); }
        }

        private void sendOrderButton_Click(object sender, EventArgs e)
        {
            Contract contract = GetOrderContract();
            Order order = GetOrder();
            orderManager.PlaceOrder(contract, order);
            if (orderId != 0)
                orderId = 0;
            this.Visible = false;
        }

        private void checkMarginButton_Click(object sender, EventArgs e)
        {
            Contract contract = GetOrderContract();
            Order order = GetOrder();
            order.WhatIf = true;
            orderManager.PlaceOrder(contract, order);
        }

        public void HandleIncomingMessage(IBMessage message)
        {
            ProcessMessage(message);
        }

        private void ProcessMessage(IBMessage message)
        {
            switch (message.Type)
            {
                case MessageType.OpenOrder:
                    HandleOpenOrder((OpenOrderMessage)message);
                    break;
                case MessageType.SoftDollarTiers:
                    HandleSoftDollarTiers((SoftDollarTiersMessage)message);
                    break;
            }
        }

        private void HandleSoftDollarTiers(SoftDollarTiersMessage softDollarTiersMessage)
        {
            softDollarTier.Items.AddRange(softDollarTiersMessage.Tiers);
        }

        private void HandleOpenOrder(OpenOrderMessage openOrderMessage)
        {
            if (openOrderMessage.Order.WhatIf)
                this.marginDialog.UpdateMarginInformation(openOrderMessage.OrderState);
        }

        private void closeOrderDialogButton_Click(object sender, EventArgs e)
        {
            if (orderId != 0)
                orderId = 0;
            this.Visible = false;
        }

        private void AlgoStrategy_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox algoStrategyCombo = (ComboBox)sender;
            string selectedStrategy = (string)algoStrategyCombo.SelectedItem;
            DisableAlgoParams();
            switch (selectedStrategy)
            {
                case "Vwap":
                    EnableVWap();
                    break;
                case "Twap":
                    EnableTWap();
                    break;
                case "ArrivalPx":
                    EnableArrivalPx();
                    break;
                case "DarkIce":
                    EnableDarkIce();
                    break;
                case "PctVol":
                    EnablePctVol();
                    break;
            }
        }

        private void DisableAlgoParams()
        {
            startTime.Enabled = false;
            endTime.Enabled = false;
            allowPastEndTime.Enabled = false;
            maxPctVol.Enabled = false;
            pctVol.Enabled = false;
            strategyType.Enabled = false;
            noTakeLiq.Enabled = false;
            riskAversion.Enabled = false;
            forceCompletion.Enabled = false;
            displaySizeAlgo.Enabled = false;
            getDone.Enabled = false;
            noTradeAhead.Enabled = false;
            useOddLots.Enabled = false;
        }

        public void SetManagedAccounts(List<string> managedAccounts)
        {
            account.Items.AddRange(managedAccounts.ToArray());
            account.SelectedIndex = 0;
        }

        private Contract GetOrderContract()
        {
            Contract contract = new Contract();
            contract.Symbol = contractSymbol.Text;
            contract.SecType = contractSecType.Text;
            contract.Currency = contractCurrency.Text;
            contract.Exchange = contractExchange.Text;
            contract.LastTradeDateOrContractMonth = contractLastTradeDateOrContractMonth.Text;
            if (!contractStrike.Text.Equals(""))
                contract.Strike = Double.Parse(contractStrike.Text);
            if (!contractRight.Text.Equals("") || !contractRight.Text.Equals("None"))
                contract.Right = (string)((IBType)contractRight.SelectedItem).Value;
            contract.LocalSymbol = contractLocalSymbol.Text;
            contract.PrimaryExch = contractPrimaryExch.Text;
            return contract;
        }

        public void SetOrderContract(Contract contract)
        {
            contractSymbol.Text = contract.Symbol;
            contractSecType.Text = contract.SecType;
            contractCurrency.Text = contract.Currency;
            contractExchange.Text = contract.Exchange;
            contractLastTradeDateOrContractMonth.Text = contract.LastTradeDateOrContractMonth;
            contractStrike.Text = contract.Strike.ToString();
            contractRight.Text = contract.Right;
            contractLocalSymbol.Text = contract.LocalSymbol;
        }

        private Order GetOrder()
        {
            Order order = new Order();
            if (orderId != 0)
                order.OrderId = orderId;
            order.Action = action.Text;
            order.OrderType = orderType.Text;
            if (!lmtPrice.Text.Equals(""))
                order.LmtPrice = Double.Parse(lmtPrice.Text);
            if (!quantity.Text.Equals(""))
                order.TotalQuantity = Double.Parse(quantity.Text);
            order.Account = account.Text;
            order.ModelCode = modelCode.Text;
            order.Tif = timeInForce.Text;
            if (!auxPrice.Text.Equals(""))
                order.AuxPrice = Double.Parse(auxPrice.Text);
            if (!displaySize.Text.Equals(""))
                order.DisplaySize = Int32.Parse(displaySize.Text);

            FillExtendedOrderAttributes(order);
            FillAdvisorAttributes(order);
            FillVolatilityAttributes(order);
            FillScaleAttributes(order);
            FillAlgoAttributes(order);
            FillPegToBench(order);
            FillAdjustedStops(order);
            FillConditions(order);

            return order;
        }

        private void FillConditions(Order order)
        {
            order.Conditions = orderBindingSource.DataSource as List<OrderCondition>;
            order.ConditionsIgnoreRth = ignoreRth.Checked;
            order.ConditionsCancelOrder = cancelOrder.SelectedIndex == 1;
        }

        private void FillAdjustedStops(Order order)
        {
            if (cbAdjustedOrderType.SelectedIndex > 0)
                order.AdjustedOrderType = cbAdjustedOrderType.Text;

            if (!string.IsNullOrWhiteSpace(tbTriggerPrice.Text))
                order.TriggerPrice = double.Parse(tbTriggerPrice.Text);

            if (!string.IsNullOrWhiteSpace(tbAdjustedStopPrice.Text))
                order.AdjustedStopPrice = double.Parse(tbAdjustedStopPrice.Text);

            if (!string.IsNullOrWhiteSpace(tbAdjustedStopLimitPrice.Text))
                order.AdjustedStopLimitPrice = double.Parse(tbAdjustedStopLimitPrice.Text);

            if (!string.IsNullOrWhiteSpace(tbAdjustedTrailingAmnt.Text))
                order.AdjustedTrailingAmount = double.Parse(tbAdjustedTrailingAmnt.Text);

            order.AdjustableTrailingUnit = (cbAdjustedTrailingAmntUnit.SelectedItem as TrailingAmountUnit).Val;
            order.LmtPriceOffset = order.LmtPrice - order.AuxPrice;
        }

        private void FillPegToBench(Order order)
        {
            if (!string.IsNullOrWhiteSpace(tbStartingPrice.Text))
                order.StartingPrice = double.Parse(tbStartingPrice.Text);

            if (!string.IsNullOrWhiteSpace(tbStartingReferencePrice.Text))
                order.StockRefPrice = double.Parse(tbStartingReferencePrice.Text);

            if (!string.IsNullOrWhiteSpace(tbPeggedChangeAmount.Text))
                order.PeggedChangeAmount = double.Parse(tbPeggedChangeAmount.Text);

            if (!string.IsNullOrWhiteSpace(tbReferenceChangeAmount.Text))
                order.ReferenceChangeAmount = double.Parse(tbReferenceChangeAmount.Text);

            if (!string.IsNullOrWhiteSpace(pgdStockRangeLower.Text))
                order.StockRangeLower = double.Parse(pgdStockRangeLower.Text);

            if (!string.IsNullOrWhiteSpace(pgdStockRangeUpper.Text))
                order.StockRangeUpper = double.Parse(pgdStockRangeUpper.Text);

            order.IsPeggedChangeAmountDecrease = cbPeggedChangeType.SelectedIndex == 1;

            if (contractSearchControl1.Contract != null)
            {
                order.ReferenceContractId = contractSearchControl1.Contract.ConId;
                order.ReferenceExchange = contractSearchControl1.Contract.Exchange;
            }
        }

        private void FillExtendedOrderAttributes(Order order)
        {
            order.OrderRef = orderReference.Text;
            if (!minQty.Text.Equals(""))
                order.MinQty = Int32.Parse(minQty.Text);
            order.GoodAfterTime = goodAfter.Text;
            order.GoodTillDate = goodUntil.Text;
            order.Rule80A = (string)((IBType)rule80A.SelectedItem).Value;
            order.TriggerMethod = (int)((IBType)triggerMethod.SelectedItem).Value;

            if (!percentOffset.Text.Equals(""))
                order.PercentOffset = Double.Parse(percentOffset.Text);
            if (!trailStopPrice.Text.Equals(""))
                order.TrailStopPrice = Double.Parse(trailStopPrice.Text);
            if (!trailingPercent.Text.Equals(""))
                order.TrailingPercent = Double.Parse(trailingPercent.Text);
            if (!discretionaryAmount.Text.Equals(""))
                order.DiscretionaryAmt = Int32.Parse(discretionaryAmount.Text);
            if (!nbboPriceCap.Text.Equals(""))
                order.NbboPriceCap = Double.Parse(nbboPriceCap.Text);

            order.OcaGroup = ocaGroup.Text;
            order.OcaType = (int)((IBType)ocaType.SelectedItem).Value;
            order.HedgeType = (string)((IBType)hedgeType.SelectedItem).Value;
            order.HedgeParam = hedgeParam.Text;

            order.NotHeld = notHeld.Checked;
            order.BlockOrder = block.Checked;
            order.SweepToFill = sweepToFill.Checked;
            order.Hidden = hidden.Checked;
            order.OutsideRth = outsideRTH.Checked;
            order.AllOrNone = allOrNone.Checked;
            order.OverridePercentageConstraints = overrideConstraints.Checked;
            order.ETradeOnly = eTrade.Checked;
            order.FirmQuoteOnly = firmQuote.Checked;
            order.OptOutSmartRouting = optOutSmart.Checked;
            order.Transmit = transmit.Checked;
            order.Tier = softDollarTier.SelectedItem as SoftDollarTier ?? new SoftDollarTier("", "", "");
        }

        private void FillVolatilityAttributes(Order order)
        {
            if (!volatility.Text.Equals(""))
                order.Volatility = Double.Parse(volatility.Text);
            order.VolatilityType = (int)((IBType)volatilityType.SelectedItem).Value;
            if (continuousUpdate.Checked)
                order.ContinuousUpdate = 1;
            else
                order.ContinuousUpdate = 0;
            order.ReferencePriceType = (int)((IBType)optionReferencePrice.SelectedItem).Value;

            if (!deltaNeutralOrderType.Text.Equals("None"))
                order.DeltaNeutralOrderType = deltaNeutralOrderType.Text;

            if (!deltaNeutralAuxPrice.Text.Equals(""))
                order.DeltaNeutralAuxPrice = Double.Parse(deltaNeutralAuxPrice.Text);
            if (!deltaNeutralConId.Text.Equals(""))
                order.DeltaNeutralConId = Int32.Parse(deltaNeutralConId.Text);
            if (!stockRangeLower.Text.Equals(""))
                order.StockRangeLower = Double.Parse(stockRangeLower.Text);
            if (!stockRangeUpper.Text.Equals(""))
                order.StockRangeUpper = Double.Parse(stockRangeUpper.Text);
        }

        private void FillAdvisorAttributes(Order order)
        {
            order.FaGroup = faGroup.Text;
            order.FaPercentage = faPercentage.Text;
            order.FaMethod = (string)((IBType)faMethod.SelectedItem).Value;
            order.FaProfile = faProfile.Text;
        }

        private void FillScaleAttributes(Order order)
        {
            if (!initialLevelSize.Text.Equals(""))
                order.ScaleInitLevelSize = Int32.Parse(initialLevelSize.Text);
            if (!subsequentLevelSize.Text.Equals(""))
                order.ScaleSubsLevelSize = Int32.Parse(subsequentLevelSize.Text);
            if (!priceIncrement.Text.Equals(""))
                order.ScalePriceIncrement = Double.Parse(priceIncrement.Text);
            if (!priceAdjustValue.Text.Equals(""))
                order.ScalePriceAdjustValue = Double.Parse(priceAdjustValue.Text);
            if (!priceAdjustInterval.Text.Equals(""))
                order.ScalePriceAdjustInterval = Int32.Parse(priceAdjustInterval.Text);
            if (!profitOffset.Text.Equals(""))
                order.ScaleProfitOffset = Double.Parse(profitOffset.Text);
            if (!initialPosition.Text.Equals(""))
                order.ScaleInitPosition = Int32.Parse(initialPosition.Text);
            if (!initialFillQuantity.Text.Equals(""))
                order.ScaleInitFillQty = Int32.Parse(initialFillQuantity.Text);

            order.ScaleAutoReset = autoReset.Checked;
            order.ScaleRandomPercent = randomiseSize.Checked;
        }

        private void FillAlgoAttributes(Order order)
        {
            if (algoStrategy.Text.Equals("") || algoStrategy.Text.Equals("None"))
                return;
            List<TagValue> algoParams = new List<TagValue>();
            algoParams.Add(new TagValue("startTime", startTime.Text));
            algoParams.Add(new TagValue("endTime", endTime.Text));

            order.AlgoStrategy = algoStrategy.Text;

            /*Vwap Twap ArrivalPx DarkIce PctVol*/
            if (order.AlgoStrategy.Equals("VWap"))
            {
                algoParams.Add(new TagValue("maxPctVol", maxPctVol.Text));
                algoParams.Add(new TagValue("noTakeLiq", noTakeLiq.Text));
                algoParams.Add(new TagValue("getDone", getDone.Text));
                algoParams.Add(new TagValue("noTradeAhead", noTradeAhead.Text));
                algoParams.Add(new TagValue("useOddLots", useOddLots.Text));
                algoParams.Add(new TagValue("allowPastEndTime", allowPastEndTime.Text));
            }

            if (order.AlgoStrategy.Equals("Twap"))
            {
                algoParams.Add(new TagValue("strategyType", strategyType.Text));
                algoParams.Add(new TagValue("allowPastEndTime", allowPastEndTime.Text));
            }

            if (order.AlgoStrategy.Equals("ArrivalPx"))
            {
                algoParams.Add(new TagValue("allowPastEndTime", allowPastEndTime.Text));
                algoParams.Add(new TagValue("maxPctVol", maxPctVol.Text));
                algoParams.Add(new TagValue("riskAversion", riskAversion.Text));
                algoParams.Add(new TagValue("forceCompletion", forceCompletion.Text));
            }

            if (order.AlgoStrategy.Equals("DarkIce"))
            {
                algoParams.Add(new TagValue("allowPastEndTime", allowPastEndTime.Text));
                algoParams.Add(new TagValue("displaySize", displaySizeAlgo.Text));
            }

            if (order.AlgoStrategy.Equals("PctVol"))
            {
                algoParams.Add(new TagValue("pctVol", pctVol.Text));
                algoParams.Add(new TagValue("noTakeLiq", noTakeLiq.Text));
            }
            order.AlgoParams = algoParams;
        }

        public async void SetOrder(Order order)
        {
            orderId = order.OrderId;
            action.Text = order.Action;
            orderType.Text = order.OrderType;
            lmtPrice.Text = doubleToStr(order.LmtPrice);
            quantity.Text = doubleToStr(order.TotalQuantity);
            account.Text = order.Account;
            modelCode.Text = order.ModelCode;
            timeInForce.Text = order.Tif;
            auxPrice.Text = doubleToStr(order.AuxPrice);
            displaySize.Text = order.DisplaySize.ToString();

            //order = GetExtendedOrderAttributes(order);
            //order = GetAdvisorAttributes(order);
            //order = GetVolatilityAttributes(order);
            //order = GetScaleAttributes(order);
            //order = GetAlgoAttributes(order);

            var c = await orderManager.IBClient.ResolveContractAsync(order.ReferenceContractId, order.ReferenceExchange);

            contractSearchControl1.Contract = c;

            if (order.OrderType == "PEG BENCH")
            {
                tbStartingPrice.Text = doubleToStr(order.StartingPrice);
                tbStartingReferencePrice.Text = doubleToStr(order.StockRefPrice);
                tbPeggedChangeAmount.Text = doubleToStr(order.PeggedChangeAmount);
                cbPeggedChangeType.SelectedIndex = order.IsPeggedChangeAmountDecrease ? 1 : 0;
                tbReferenceChangeAmount.Text = doubleToStr(order.ReferenceChangeAmount);
                pgdStockRangeUpper.Text = doubleToStr(order.StockRangeUpper);
                pgdStockRangeLower.Text = doubleToStr(order.StockRangeLower);
            }

            cbAdjustedOrderType.Text = order.AdjustedOrderType;
            tbTriggerPrice.Text = doubleToStr(order.TriggerPrice);
            tbAdjustedStopPrice.Text = doubleToStr(order.AdjustedStopPrice);
            tbAdjustedStopLimitPrice.Text = doubleToStr(order.AdjustedStopLimitPrice);
            tbAdjustedTrailingAmnt.Text = doubleToStr(order.AdjustedTrailingAmount);
            cbAdjustedTrailingAmntUnit.SelectedItem = (TrailingAmountUnit)order.AdjustableTrailingUnit;
            orderBindingSource.DataSource = order.Conditions;
            ignoreRth.Checked = order.ConditionsIgnoreRth;
            cancelOrder.SelectedIndex = order.ConditionsCancelOrder ? 1 : 0;
        }

        string doubleToStr(double val)
        {
            return val != double.MaxValue ? val.ToString() : "";
        }

        private void EnableVWap()
        {
            startTime.Enabled = true;
            endTime.Enabled = true;
            maxPctVol.Enabled = true;
            noTakeLiq.Enabled = true;
            getDone.Enabled = true;
            noTradeAhead.Enabled = true;
            useOddLots.Enabled = true;
        }

        private void EnableTWap()
        {
            startTime.Enabled = true;
            endTime.Enabled = true;
            allowPastEndTime.Enabled = true;
            strategyType.Enabled = true;
        }

        private void EnableArrivalPx()
        {
            startTime.Enabled = true;
            endTime.Enabled = true;
            allowPastEndTime.Enabled = true;
            maxPctVol.Enabled = true;
            riskAversion.Enabled = true;
            forceCompletion.Enabled = true;
        }

        private void EnableDarkIce()
        {
            startTime.Enabled = true;
            endTime.Enabled = true;
            allowPastEndTime.Enabled = true;
            displaySizeAlgo.Enabled = true;
        }

        private void EnablePctVol()
        {
            startTime.Enabled = true;
            endTime.Enabled = true;
            pctVol.Enabled = true;
            noTakeLiq.Enabled = true;
        }

        private void InitialiseDropDowns()
        {
            rule80A.Items.AddRange(Rule80A.GetAll());
            rule80A.SelectedIndex = 0;

            triggerMethod.Items.AddRange(IBSampleApp.types.TriggerMethod.GetAll());
            triggerMethod.SelectedIndex = 0;

            faMethod.Items.AddRange(FaMethod.GetAll());
            faMethod.SelectedIndex = 0;

            ocaType.Items.AddRange(OCAType.GetAll());
            ocaType.SelectedIndex = 0;

            hedgeType.Items.AddRange(HedgeType.GetAll());
            hedgeType.SelectedIndex = 0;

            optionReferencePrice.Items.AddRange(ReferencePriceType.GetAll());
            optionReferencePrice.SelectedIndex = 0;

            volatilityType.Items.AddRange(VolatilityType.GetAll());
            volatilityType.SelectedIndex = 0;

            contractRight.Items.AddRange(ContractRight.GetAll());
            contractRight.SelectedIndex = 0;

            cbPeggedChangeType.SelectedIndex = 0;
            cbAdjustedOrderType.SelectedIndex = 0;
            cbAdjustedTrailingAmntUnit.Items[0] = TrailingAmountUnit.amnt;
            cbAdjustedTrailingAmntUnit.Items[1] = TrailingAmountUnit.percent;
            cbAdjustedTrailingAmntUnit.SelectedIndex = 0;
        }

        int reqId = 0;

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            if (orderManager != null && orderManager.IBClient != null && orderManager.IBClient.ClientSocket != null && orderManager.IBClient.ClientSocket.IsConnected())
                orderManager.IBClient.ClientSocket.reqSoftDollarTiers(reqId++);
        }

        class TrailingAmountUnit
        {
            public int Val { get; private set; }
            string txt;

            public override string ToString()
            {
                return txt;
            }

            private TrailingAmountUnit(int value, string text)
            {
                Val = value;
                txt = text;
            }

            public static explicit operator TrailingAmountUnit(int val)
            {
                if (val == 0)
                    return amnt;

                if (val == 100)
                    return percent;

                return null;
            }

            public static TrailingAmountUnit amnt = new TrailingAmountUnit(0, "amount"), percent = new TrailingAmountUnit(100, "%");
        }

        private void lbAddCondition_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var dlg = new ConditionDialog(null, orderManager.IBClient);

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                orderBindingSource.Add(dlg.Condition);
            }
        }

        private OrderCondition selectedCondition
        {
            get
            {
                if (conditionList.SelectedCells.Count == 0 || conditionList.SelectedCells[0].RowIndex == -1)
                    return null;

                return orderBindingSource[conditionList.SelectedCells[0].RowIndex] as OrderCondition;
            }

            set
            {
                if (conditionList.SelectedCells.Count > 0 && conditionList.SelectedCells[0].RowIndex != -1)
                    orderBindingSource[conditionList.SelectedCells[0].RowIndex] = value;
            }
        }

        private void lbRemoveCondition_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            orderBindingSource.Remove(selectedCondition);
        }

        private void conditionList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var dlg = new ConditionDialog(selectedCondition, orderManager.IBClient);

                if (dlg.ShowDialog() == DialogResult.OK)
                    selectedCondition = dlg.Condition;
            }
        }
    }
}
