namespace IBSampleApp
{
    partial class OrderDialog
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.contractSymbol = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.orderContractTab = new System.Windows.Forms.TabPage();
            this.baseGroup = new System.Windows.Forms.GroupBox();
            this.contractGroup = new System.Windows.Forms.GroupBox();
            this.orderLocalSymbol = new System.Windows.Forms.Label();
            this.orderCurrencyLabel = new System.Windows.Forms.Label();
            this.orderExchangeLabel = new System.Windows.Forms.Label();
            this.orderSymbolLabel = new System.Windows.Forms.Label();
            this.orderMultiplierLabel = new System.Windows.Forms.Label();
            this.orderRightLabel = new System.Windows.Forms.Label();
            this.contractSecType = new System.Windows.Forms.ComboBox();
            this.orderStrikeLabel = new System.Windows.Forms.Label();
            this.contractExpiry = new System.Windows.Forms.TextBox();
            this.orderExpiryLabel = new System.Windows.Forms.Label();
            this.contractStrike = new System.Windows.Forms.TextBox();
            this.orderSecTypeLabel = new System.Windows.Forms.Label();
            this.contractRight = new System.Windows.Forms.ComboBox();
            this.contractLocalSymbol = new System.Windows.Forms.TextBox();
            this.contractMultiplier = new System.Windows.Forms.TextBox();
            this.contractCurrency = new System.Windows.Forms.TextBox();
            this.contractExchange = new System.Windows.Forms.TextBox();
            this.extendedOrderTab = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.trailingPercentLabel = new System.Windows.Forms.Label();
            this.transmit = new System.Windows.Forms.CheckBox();
            this.nbboPriceCap = new System.Windows.Forms.TextBox();
            this.firmQuote = new System.Windows.Forms.CheckBox();
            this.discretionaryAmount = new System.Windows.Forms.TextBox();
            this.overrideConstraints = new System.Windows.Forms.CheckBox();
            this.eTrade = new System.Windows.Forms.CheckBox();
            this.optOutSmart = new System.Windows.Forms.CheckBox();
            this.trailingPercent = new System.Windows.Forms.TextBox();
            this.hidden = new System.Windows.Forms.CheckBox();
            this.outsideRTH = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.allOrNone = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.notHeld = new System.Windows.Forms.CheckBox();
            this.block = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sweepToFill = new System.Windows.Forms.CheckBox();
            this.percentOffsetLabel = new System.Windows.Forms.Label();
            this.tiggerMethodLabel = new System.Windows.Forms.Label();
            this.rule80ALabel = new System.Windows.Forms.Label();
            this.goodUntilLabel = new System.Windows.Forms.Label();
            this.goodAfterLabel = new System.Windows.Forms.Label();
            this.ocaGroup = new System.Windows.Forms.TextBox();
            this.hedgeParam = new System.Windows.Forms.TextBox();
            this.ocaType = new System.Windows.Forms.ComboBox();
            this.hedgeType = new System.Windows.Forms.ComboBox();
            this.orderMinQtyLabel = new System.Windows.Forms.Label();
            this.orderRefLabel = new System.Windows.Forms.Label();
            this.trailStopPrice = new System.Windows.Forms.TextBox();
            this.percentOffset = new System.Windows.Forms.TextBox();
            this.triggerMethod = new System.Windows.Forms.ComboBox();
            this.rule80A = new System.Windows.Forms.ComboBox();
            this.goodUntil = new System.Windows.Forms.TextBox();
            this.goodAfter = new System.Windows.Forms.TextBox();
            this.minQty = new System.Windows.Forms.TextBox();
            this.reference = new System.Windows.Forms.TextBox();
            this.sendOrderButton = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.orderContractTab.SuspendLayout();
            this.contractGroup.SuspendLayout();
            this.extendedOrderTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // contractSymbol
            // 
            this.contractSymbol.Location = new System.Drawing.Point(84, 25);
            this.contractSymbol.Name = "contractSymbol";
            this.contractSymbol.Size = new System.Drawing.Size(71, 20);
            this.contractSymbol.TabIndex = 0;
            this.contractSymbol.Text = "EUR";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.orderContractTab);
            this.tabControl1.Controls.Add(this.extendedOrderTab);
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(582, 288);
            this.tabControl1.TabIndex = 1;
            // 
            // orderContractTab
            // 
            this.orderContractTab.BackColor = System.Drawing.Color.LightGray;
            this.orderContractTab.Controls.Add(this.baseGroup);
            this.orderContractTab.Controls.Add(this.contractGroup);
            this.orderContractTab.Location = new System.Drawing.Point(4, 22);
            this.orderContractTab.Name = "orderContractTab";
            this.orderContractTab.Padding = new System.Windows.Forms.Padding(3);
            this.orderContractTab.Size = new System.Drawing.Size(574, 262);
            this.orderContractTab.TabIndex = 0;
            this.orderContractTab.Text = "Basic Order";
            // 
            // baseGroup
            // 
            this.baseGroup.Location = new System.Drawing.Point(324, 6);
            this.baseGroup.Name = "baseGroup";
            this.baseGroup.Size = new System.Drawing.Size(244, 214);
            this.baseGroup.TabIndex = 15;
            this.baseGroup.TabStop = false;
            this.baseGroup.Text = "Order Base Attributes";
            // 
            // contractGroup
            // 
            this.contractGroup.Controls.Add(this.orderLocalSymbol);
            this.contractGroup.Controls.Add(this.orderCurrencyLabel);
            this.contractGroup.Controls.Add(this.orderExchangeLabel);
            this.contractGroup.Controls.Add(this.orderSymbolLabel);
            this.contractGroup.Controls.Add(this.orderMultiplierLabel);
            this.contractGroup.Controls.Add(this.contractSymbol);
            this.contractGroup.Controls.Add(this.orderRightLabel);
            this.contractGroup.Controls.Add(this.contractSecType);
            this.contractGroup.Controls.Add(this.orderStrikeLabel);
            this.contractGroup.Controls.Add(this.contractExpiry);
            this.contractGroup.Controls.Add(this.orderExpiryLabel);
            this.contractGroup.Controls.Add(this.contractStrike);
            this.contractGroup.Controls.Add(this.orderSecTypeLabel);
            this.contractGroup.Controls.Add(this.contractRight);
            this.contractGroup.Controls.Add(this.contractLocalSymbol);
            this.contractGroup.Controls.Add(this.contractMultiplier);
            this.contractGroup.Controls.Add(this.contractCurrency);
            this.contractGroup.Controls.Add(this.contractExchange);
            this.contractGroup.Location = new System.Drawing.Point(6, 6);
            this.contractGroup.Name = "contractGroup";
            this.contractGroup.Size = new System.Drawing.Size(312, 214);
            this.contractGroup.TabIndex = 14;
            this.contractGroup.TabStop = false;
            this.contractGroup.Text = "Contract";
            // 
            // orderLocalSymbol
            // 
            this.orderLocalSymbol.AutoSize = true;
            this.orderLocalSymbol.Location = new System.Drawing.Point(8, 130);
            this.orderLocalSymbol.Name = "orderLocalSymbol";
            this.orderLocalSymbol.Size = new System.Drawing.Size(70, 13);
            this.orderLocalSymbol.TabIndex = 16;
            this.orderLocalSymbol.Text = "Local Symbol";
            // 
            // orderCurrencyLabel
            // 
            this.orderCurrencyLabel.AutoSize = true;
            this.orderCurrencyLabel.Location = new System.Drawing.Point(29, 104);
            this.orderCurrencyLabel.Name = "orderCurrencyLabel";
            this.orderCurrencyLabel.Size = new System.Drawing.Size(49, 13);
            this.orderCurrencyLabel.TabIndex = 15;
            this.orderCurrencyLabel.Text = "Currency";
            // 
            // orderExchangeLabel
            // 
            this.orderExchangeLabel.AutoSize = true;
            this.orderExchangeLabel.Location = new System.Drawing.Point(23, 78);
            this.orderExchangeLabel.Name = "orderExchangeLabel";
            this.orderExchangeLabel.Size = new System.Drawing.Size(55, 13);
            this.orderExchangeLabel.TabIndex = 14;
            this.orderExchangeLabel.Text = "Exchange";
            // 
            // orderSymbolLabel
            // 
            this.orderSymbolLabel.AutoSize = true;
            this.orderSymbolLabel.Location = new System.Drawing.Point(37, 25);
            this.orderSymbolLabel.Name = "orderSymbolLabel";
            this.orderSymbolLabel.Size = new System.Drawing.Size(41, 13);
            this.orderSymbolLabel.TabIndex = 0;
            this.orderSymbolLabel.Text = "Symbol";
            // 
            // orderMultiplierLabel
            // 
            this.orderMultiplierLabel.AutoSize = true;
            this.orderMultiplierLabel.Location = new System.Drawing.Point(173, 104);
            this.orderMultiplierLabel.Name = "orderMultiplierLabel";
            this.orderMultiplierLabel.Size = new System.Drawing.Size(48, 13);
            this.orderMultiplierLabel.TabIndex = 13;
            this.orderMultiplierLabel.Text = "Multiplier";
            // 
            // orderRightLabel
            // 
            this.orderRightLabel.AutoSize = true;
            this.orderRightLabel.Location = new System.Drawing.Point(173, 81);
            this.orderRightLabel.Name = "orderRightLabel";
            this.orderRightLabel.Size = new System.Drawing.Size(45, 13);
            this.orderRightLabel.TabIndex = 12;
            this.orderRightLabel.Text = "Put/Call";
            // 
            // contractSecType
            // 
            this.contractSecType.FormattingEnabled = true;
            this.contractSecType.Items.AddRange(new object[] {
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
            this.contractSecType.Location = new System.Drawing.Point(84, 51);
            this.contractSecType.Name = "contractSecType";
            this.contractSecType.Size = new System.Drawing.Size(71, 21);
            this.contractSecType.TabIndex = 1;
            this.contractSecType.Text = "CASH";
            // 
            // orderStrikeLabel
            // 
            this.orderStrikeLabel.AutoSize = true;
            this.orderStrikeLabel.Location = new System.Drawing.Point(179, 54);
            this.orderStrikeLabel.Name = "orderStrikeLabel";
            this.orderStrikeLabel.Size = new System.Drawing.Size(34, 13);
            this.orderStrikeLabel.TabIndex = 11;
            this.orderStrikeLabel.Text = "Strike";
            // 
            // contractExpiry
            // 
            this.contractExpiry.Location = new System.Drawing.Point(230, 25);
            this.contractExpiry.Name = "contractExpiry";
            this.contractExpiry.Size = new System.Drawing.Size(71, 20);
            this.contractExpiry.TabIndex = 2;
            // 
            // orderExpiryLabel
            // 
            this.orderExpiryLabel.AutoSize = true;
            this.orderExpiryLabel.Location = new System.Drawing.Point(183, 25);
            this.orderExpiryLabel.Name = "orderExpiryLabel";
            this.orderExpiryLabel.Size = new System.Drawing.Size(35, 13);
            this.orderExpiryLabel.TabIndex = 10;
            this.orderExpiryLabel.Text = "Expiry";
            // 
            // contractStrike
            // 
            this.contractStrike.Location = new System.Drawing.Point(230, 54);
            this.contractStrike.Name = "contractStrike";
            this.contractStrike.Size = new System.Drawing.Size(71, 20);
            this.contractStrike.TabIndex = 3;
            // 
            // orderSecTypeLabel
            // 
            this.orderSecTypeLabel.AutoSize = true;
            this.orderSecTypeLabel.Location = new System.Drawing.Point(28, 51);
            this.orderSecTypeLabel.Name = "orderSecTypeLabel";
            this.orderSecTypeLabel.Size = new System.Drawing.Size(50, 13);
            this.orderSecTypeLabel.TabIndex = 9;
            this.orderSecTypeLabel.Text = "SecType";
            // 
            // contractRight
            // 
            this.contractRight.FormattingEnabled = true;
            this.contractRight.Items.AddRange(new object[] {
            "N/A",
            "Put",
            "Call"});
            this.contractRight.Location = new System.Drawing.Point(230, 80);
            this.contractRight.Name = "contractRight";
            this.contractRight.Size = new System.Drawing.Size(71, 21);
            this.contractRight.TabIndex = 4;
            this.contractRight.Text = "N/A";
            // 
            // contractLocalSymbol
            // 
            this.contractLocalSymbol.Location = new System.Drawing.Point(84, 130);
            this.contractLocalSymbol.Name = "contractLocalSymbol";
            this.contractLocalSymbol.Size = new System.Drawing.Size(71, 20);
            this.contractLocalSymbol.TabIndex = 8;
            // 
            // contractMultiplier
            // 
            this.contractMultiplier.Location = new System.Drawing.Point(230, 107);
            this.contractMultiplier.Name = "contractMultiplier";
            this.contractMultiplier.Size = new System.Drawing.Size(71, 20);
            this.contractMultiplier.TabIndex = 5;
            // 
            // contractCurrency
            // 
            this.contractCurrency.Location = new System.Drawing.Point(84, 104);
            this.contractCurrency.Name = "contractCurrency";
            this.contractCurrency.Size = new System.Drawing.Size(71, 20);
            this.contractCurrency.TabIndex = 7;
            this.contractCurrency.Text = "USD";
            // 
            // contractExchange
            // 
            this.contractExchange.Location = new System.Drawing.Point(84, 78);
            this.contractExchange.Name = "contractExchange";
            this.contractExchange.Size = new System.Drawing.Size(71, 20);
            this.contractExchange.TabIndex = 6;
            this.contractExchange.Text = "IDEALPRO";
            // 
            // extendedOrderTab
            // 
            this.extendedOrderTab.BackColor = System.Drawing.Color.LightGray;
            this.extendedOrderTab.Controls.Add(this.label6);
            this.extendedOrderTab.Controls.Add(this.label5);
            this.extendedOrderTab.Controls.Add(this.trailingPercentLabel);
            this.extendedOrderTab.Controls.Add(this.transmit);
            this.extendedOrderTab.Controls.Add(this.nbboPriceCap);
            this.extendedOrderTab.Controls.Add(this.firmQuote);
            this.extendedOrderTab.Controls.Add(this.discretionaryAmount);
            this.extendedOrderTab.Controls.Add(this.overrideConstraints);
            this.extendedOrderTab.Controls.Add(this.eTrade);
            this.extendedOrderTab.Controls.Add(this.optOutSmart);
            this.extendedOrderTab.Controls.Add(this.trailingPercent);
            this.extendedOrderTab.Controls.Add(this.hidden);
            this.extendedOrderTab.Controls.Add(this.outsideRTH);
            this.extendedOrderTab.Controls.Add(this.label3);
            this.extendedOrderTab.Controls.Add(this.allOrNone);
            this.extendedOrderTab.Controls.Add(this.label2);
            this.extendedOrderTab.Controls.Add(this.notHeld);
            this.extendedOrderTab.Controls.Add(this.block);
            this.extendedOrderTab.Controls.Add(this.label1);
            this.extendedOrderTab.Controls.Add(this.sweepToFill);
            this.extendedOrderTab.Controls.Add(this.percentOffsetLabel);
            this.extendedOrderTab.Controls.Add(this.tiggerMethodLabel);
            this.extendedOrderTab.Controls.Add(this.rule80ALabel);
            this.extendedOrderTab.Controls.Add(this.goodUntilLabel);
            this.extendedOrderTab.Controls.Add(this.goodAfterLabel);
            this.extendedOrderTab.Controls.Add(this.ocaGroup);
            this.extendedOrderTab.Controls.Add(this.hedgeParam);
            this.extendedOrderTab.Controls.Add(this.ocaType);
            this.extendedOrderTab.Controls.Add(this.hedgeType);
            this.extendedOrderTab.Controls.Add(this.orderMinQtyLabel);
            this.extendedOrderTab.Controls.Add(this.orderRefLabel);
            this.extendedOrderTab.Controls.Add(this.trailStopPrice);
            this.extendedOrderTab.Controls.Add(this.percentOffset);
            this.extendedOrderTab.Controls.Add(this.triggerMethod);
            this.extendedOrderTab.Controls.Add(this.rule80A);
            this.extendedOrderTab.Controls.Add(this.goodUntil);
            this.extendedOrderTab.Controls.Add(this.goodAfter);
            this.extendedOrderTab.Controls.Add(this.minQty);
            this.extendedOrderTab.Controls.Add(this.reference);
            this.extendedOrderTab.Location = new System.Drawing.Point(4, 22);
            this.extendedOrderTab.Name = "extendedOrderTab";
            this.extendedOrderTab.Padding = new System.Windows.Forms.Padding(3);
            this.extendedOrderTab.Size = new System.Drawing.Size(574, 262);
            this.extendedOrderTab.TabIndex = 1;
            this.extendedOrderTab.Text = "Extended Attributes";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(245, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "NBBO price cap";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Discretionary amount";
            // 
            // trailingPercentLabel
            // 
            this.trailingPercentLabel.AutoSize = true;
            this.trailingPercentLabel.Location = new System.Drawing.Point(33, 220);
            this.trailingPercentLabel.Name = "trailingPercentLabel";
            this.trailingPercentLabel.Size = new System.Drawing.Size(80, 13);
            this.trailingPercentLabel.TabIndex = 38;
            this.trailingPercentLabel.Text = "Trailing percent";
            // 
            // transmit
            // 
            this.transmit.AutoSize = true;
            this.transmit.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.transmit.Location = new System.Drawing.Point(484, 138);
            this.transmit.Name = "transmit";
            this.transmit.Size = new System.Drawing.Size(66, 17);
            this.transmit.TabIndex = 31;
            this.transmit.Text = "Transmit";
            this.transmit.UseVisualStyleBackColor = true;
            // 
            // nbboPriceCap
            // 
            this.nbboPriceCap.Location = new System.Drawing.Point(335, 46);
            this.nbboPriceCap.Name = "nbboPriceCap";
            this.nbboPriceCap.Size = new System.Drawing.Size(70, 20);
            this.nbboPriceCap.TabIndex = 37;
            // 
            // firmQuote
            // 
            this.firmQuote.AutoSize = true;
            this.firmQuote.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.firmQuote.Location = new System.Drawing.Point(378, 205);
            this.firmQuote.Name = "firmQuote";
            this.firmQuote.Size = new System.Drawing.Size(97, 17);
            this.firmQuote.TabIndex = 22;
            this.firmQuote.Text = "Firm quote only";
            this.firmQuote.UseVisualStyleBackColor = true;
            // 
            // discretionaryAmount
            // 
            this.discretionaryAmount.Location = new System.Drawing.Point(335, 20);
            this.discretionaryAmount.Name = "discretionaryAmount";
            this.discretionaryAmount.Size = new System.Drawing.Size(70, 20);
            this.discretionaryAmount.TabIndex = 36;
            // 
            // overrideConstraints
            // 
            this.overrideConstraints.AutoSize = true;
            this.overrideConstraints.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.overrideConstraints.Location = new System.Drawing.Point(355, 161);
            this.overrideConstraints.Name = "overrideConstraints";
            this.overrideConstraints.Size = new System.Drawing.Size(120, 17);
            this.overrideConstraints.TabIndex = 20;
            this.overrideConstraints.Text = "Override constraints";
            this.overrideConstraints.UseVisualStyleBackColor = true;
            // 
            // eTrade
            // 
            this.eTrade.AutoSize = true;
            this.eTrade.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.eTrade.Location = new System.Drawing.Point(393, 184);
            this.eTrade.Name = "eTrade";
            this.eTrade.Size = new System.Drawing.Size(82, 17);
            this.eTrade.TabIndex = 21;
            this.eTrade.Text = "E-trade only";
            this.eTrade.UseVisualStyleBackColor = true;
            // 
            // optOutSmart
            // 
            this.optOutSmart.AutoSize = true;
            this.optOutSmart.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.optOutSmart.Location = new System.Drawing.Point(338, 228);
            this.optOutSmart.Name = "optOutSmart";
            this.optOutSmart.Size = new System.Drawing.Size(137, 17);
            this.optOutSmart.TabIndex = 30;
            this.optOutSmart.Text = "Opt out SMART routing";
            this.optOutSmart.UseVisualStyleBackColor = true;
            // 
            // trailingPercent
            // 
            this.trailingPercent.Location = new System.Drawing.Point(112, 220);
            this.trailingPercent.Name = "trailingPercent";
            this.trailingPercent.Size = new System.Drawing.Size(70, 20);
            this.trailingPercent.TabIndex = 35;
            // 
            // hidden
            // 
            this.hidden.AutoSize = true;
            this.hidden.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.hidden.Location = new System.Drawing.Point(272, 205);
            this.hidden.Name = "hidden";
            this.hidden.Size = new System.Drawing.Size(60, 17);
            this.hidden.TabIndex = 11;
            this.hidden.Text = "Hidden";
            this.hidden.UseVisualStyleBackColor = true;
            // 
            // outsideRTH
            // 
            this.outsideRTH.AutoSize = true;
            this.outsideRTH.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.outsideRTH.Location = new System.Drawing.Point(231, 228);
            this.outsideRTH.Name = "outsideRTH";
            this.outsideRTH.Size = new System.Drawing.Size(101, 17);
            this.outsideRTH.TabIndex = 18;
            this.outsideRTH.Text = "Fill outside RTH";
            this.outsideRTH.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Hedge type and param";
            // 
            // allOrNone
            // 
            this.allOrNone.AutoSize = true;
            this.allOrNone.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.allOrNone.Location = new System.Drawing.Point(399, 138);
            this.allOrNone.Name = "allOrNone";
            this.allOrNone.Size = new System.Drawing.Size(76, 17);
            this.allOrNone.TabIndex = 19;
            this.allOrNone.Text = "All or none";
            this.allOrNone.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "OCA group and type";
            // 
            // notHeld
            // 
            this.notHeld.AutoSize = true;
            this.notHeld.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.notHeld.Location = new System.Drawing.Point(266, 138);
            this.notHeld.Name = "notHeld";
            this.notHeld.Size = new System.Drawing.Size(66, 17);
            this.notHeld.TabIndex = 15;
            this.notHeld.Text = "Not held";
            this.notHeld.UseVisualStyleBackColor = true;
            // 
            // block
            // 
            this.block.AutoSize = true;
            this.block.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.block.Location = new System.Drawing.Point(252, 161);
            this.block.Name = "block";
            this.block.Size = new System.Drawing.Size(80, 17);
            this.block.TabIndex = 16;
            this.block.Text = "Block order";
            this.block.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Trail order stop price";
            // 
            // sweepToFill
            // 
            this.sweepToFill.AutoSize = true;
            this.sweepToFill.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.sweepToFill.Location = new System.Drawing.Point(249, 184);
            this.sweepToFill.Name = "sweepToFill";
            this.sweepToFill.Size = new System.Drawing.Size(83, 17);
            this.sweepToFill.TabIndex = 17;
            this.sweepToFill.Text = "Sweep to fill";
            this.sweepToFill.UseVisualStyleBackColor = true;
            // 
            // percentOffsetLabel
            // 
            this.percentOffsetLabel.AutoSize = true;
            this.percentOffsetLabel.Location = new System.Drawing.Point(31, 169);
            this.percentOffsetLabel.Name = "percentOffsetLabel";
            this.percentOffsetLabel.Size = new System.Drawing.Size(75, 13);
            this.percentOffsetLabel.TabIndex = 29;
            this.percentOffsetLabel.Text = "Percent Offset";
            // 
            // tiggerMethodLabel
            // 
            this.tiggerMethodLabel.AutoSize = true;
            this.tiggerMethodLabel.Location = new System.Drawing.Point(27, 142);
            this.tiggerMethodLabel.Name = "tiggerMethodLabel";
            this.tiggerMethodLabel.Size = new System.Drawing.Size(79, 13);
            this.tiggerMethodLabel.TabIndex = 28;
            this.tiggerMethodLabel.Text = "Trigger Method";
            // 
            // rule80ALabel
            // 
            this.rule80ALabel.AutoSize = true;
            this.rule80ALabel.Location = new System.Drawing.Point(55, 115);
            this.rule80ALabel.Name = "rule80ALabel";
            this.rule80ALabel.Size = new System.Drawing.Size(51, 13);
            this.rule80ALabel.TabIndex = 27;
            this.rule80ALabel.Text = "Rule 80A";
            // 
            // goodUntilLabel
            // 
            this.goodUntilLabel.AutoSize = true;
            this.goodUntilLabel.Location = new System.Drawing.Point(51, 91);
            this.goodUntilLabel.Name = "goodUntilLabel";
            this.goodUntilLabel.Size = new System.Drawing.Size(55, 13);
            this.goodUntilLabel.TabIndex = 26;
            this.goodUntilLabel.Text = "Good until";
            // 
            // goodAfterLabel
            // 
            this.goodAfterLabel.AutoSize = true;
            this.goodAfterLabel.Location = new System.Drawing.Point(49, 65);
            this.goodAfterLabel.Name = "goodAfterLabel";
            this.goodAfterLabel.Size = new System.Drawing.Size(57, 13);
            this.goodAfterLabel.TabIndex = 25;
            this.goodAfterLabel.Text = "Good after";
            // 
            // ocaGroup
            // 
            this.ocaGroup.Location = new System.Drawing.Point(334, 72);
            this.ocaGroup.Name = "ocaGroup";
            this.ocaGroup.Size = new System.Drawing.Size(70, 20);
            this.ocaGroup.TabIndex = 11;
            // 
            // hedgeParam
            // 
            this.hedgeParam.Location = new System.Drawing.Point(410, 99);
            this.hedgeParam.Name = "hedgeParam";
            this.hedgeParam.Size = new System.Drawing.Size(53, 20);
            this.hedgeParam.TabIndex = 14;
            // 
            // ocaType
            // 
            this.ocaType.FormattingEnabled = true;
            this.ocaType.Location = new System.Drawing.Point(410, 72);
            this.ocaType.Name = "ocaType";
            this.ocaType.Size = new System.Drawing.Size(140, 21);
            this.ocaType.TabIndex = 12;
            this.ocaType.Text = "ReduceWithoutBlocking";
            // 
            // hedgeType
            // 
            this.hedgeType.FormattingEnabled = true;
            this.hedgeType.Location = new System.Drawing.Point(334, 98);
            this.hedgeType.Name = "hedgeType";
            this.hedgeType.Size = new System.Drawing.Size(70, 21);
            this.hedgeType.TabIndex = 13;
            // 
            // orderMinQtyLabel
            // 
            this.orderMinQtyLabel.AutoSize = true;
            this.orderMinQtyLabel.Location = new System.Drawing.Point(57, 39);
            this.orderMinQtyLabel.Name = "orderMinQtyLabel";
            this.orderMinQtyLabel.Size = new System.Drawing.Size(49, 13);
            this.orderMinQtyLabel.TabIndex = 24;
            this.orderMinQtyLabel.Text = "Min. Qty.";
            // 
            // orderRefLabel
            // 
            this.orderRefLabel.AutoSize = true;
            this.orderRefLabel.Location = new System.Drawing.Point(50, 13);
            this.orderRefLabel.Name = "orderRefLabel";
            this.orderRefLabel.Size = new System.Drawing.Size(56, 13);
            this.orderRefLabel.TabIndex = 23;
            this.orderRefLabel.Text = "Order Ref.";
            // 
            // trailStopPrice
            // 
            this.trailStopPrice.Location = new System.Drawing.Point(112, 194);
            this.trailStopPrice.Name = "trailStopPrice";
            this.trailStopPrice.Size = new System.Drawing.Size(70, 20);
            this.trailStopPrice.TabIndex = 7;
            // 
            // percentOffset
            // 
            this.percentOffset.Location = new System.Drawing.Point(112, 169);
            this.percentOffset.Name = "percentOffset";
            this.percentOffset.Size = new System.Drawing.Size(70, 20);
            this.percentOffset.TabIndex = 6;
            // 
            // triggerMethod
            // 
            this.triggerMethod.FormattingEnabled = true;
            this.triggerMethod.Location = new System.Drawing.Point(112, 142);
            this.triggerMethod.Name = "triggerMethod";
            this.triggerMethod.Size = new System.Drawing.Size(70, 21);
            this.triggerMethod.TabIndex = 5;
            // 
            // rule80A
            // 
            this.rule80A.FormattingEnabled = true;
            this.rule80A.Location = new System.Drawing.Point(112, 115);
            this.rule80A.Name = "rule80A";
            this.rule80A.Size = new System.Drawing.Size(70, 21);
            this.rule80A.TabIndex = 4;
            // 
            // goodUntil
            // 
            this.goodUntil.Location = new System.Drawing.Point(112, 91);
            this.goodUntil.Name = "goodUntil";
            this.goodUntil.Size = new System.Drawing.Size(70, 20);
            this.goodUntil.TabIndex = 3;
            // 
            // goodAfter
            // 
            this.goodAfter.Location = new System.Drawing.Point(112, 65);
            this.goodAfter.Name = "goodAfter";
            this.goodAfter.Size = new System.Drawing.Size(70, 20);
            this.goodAfter.TabIndex = 2;
            // 
            // minQty
            // 
            this.minQty.Location = new System.Drawing.Point(112, 39);
            this.minQty.Name = "minQty";
            this.minQty.Size = new System.Drawing.Size(70, 20);
            this.minQty.TabIndex = 1;
            // 
            // reference
            // 
            this.reference.Location = new System.Drawing.Point(112, 13);
            this.reference.Name = "reference";
            this.reference.Size = new System.Drawing.Size(70, 20);
            this.reference.TabIndex = 0;
            // 
            // sendOrderButton
            // 
            this.sendOrderButton.Location = new System.Drawing.Point(12, 295);
            this.sendOrderButton.Name = "sendOrderButton";
            this.sendOrderButton.Size = new System.Drawing.Size(75, 23);
            this.sendOrderButton.TabIndex = 2;
            this.sendOrderButton.Text = "Send";
            this.sendOrderButton.UseVisualStyleBackColor = true;
            this.sendOrderButton.Click += new System.EventHandler(this.sendOrderButton_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(383, 188);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(70, 20);
            this.textBox6.TabIndex = 8;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(383, 214);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(70, 20);
            this.textBox7.TabIndex = 9;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(383, 240);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(70, 20);
            this.textBox8.TabIndex = 10;
            // 
            // OrderDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 325);
            this.Controls.Add(this.sendOrderButton);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Name = "OrderDialog";
            this.Text = "Order";
            this.tabControl1.ResumeLayout(false);
            this.orderContractTab.ResumeLayout(false);
            this.contractGroup.ResumeLayout(false);
            this.contractGroup.PerformLayout();
            this.extendedOrderTab.ResumeLayout(false);
            this.extendedOrderTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage orderContractTab;
        private System.Windows.Forms.TabPage extendedOrderTab;
        private System.Windows.Forms.Button sendOrderButton;

        private System.Windows.Forms.ComboBox contractSecType;
        private System.Windows.Forms.TextBox contractExpiry;
        private System.Windows.Forms.TextBox contractStrike;
        private System.Windows.Forms.ComboBox contractRight;
        private System.Windows.Forms.TextBox contractMultiplier;
        private System.Windows.Forms.TextBox contractExchange;
        private System.Windows.Forms.TextBox contractCurrency;
        private System.Windows.Forms.TextBox contractLocalSymbol;        
        private System.Windows.Forms.GroupBox contractGroup;
        private System.Windows.Forms.GroupBox baseGroup;
        private System.Windows.Forms.TextBox contractSymbol;
        private System.Windows.Forms.TextBox reference;        
        private System.Windows.Forms.CheckBox firmQuote;
        private System.Windows.Forms.CheckBox eTrade;
        private System.Windows.Forms.CheckBox overrideConstraints;
        private System.Windows.Forms.CheckBox allOrNone;
        private System.Windows.Forms.CheckBox outsideRTH;
        private System.Windows.Forms.CheckBox hidden;
        private System.Windows.Forms.CheckBox sweepToFill;
        private System.Windows.Forms.CheckBox block;
        private System.Windows.Forms.CheckBox notHeld;
        private System.Windows.Forms.TextBox hedgeParam;
        private System.Windows.Forms.TextBox trailStopPrice;
        private System.Windows.Forms.TextBox percentOffset;
        private System.Windows.Forms.ComboBox hedgeType;
        private System.Windows.Forms.ComboBox triggerMethod;
        private System.Windows.Forms.ComboBox rule80A;
        private System.Windows.Forms.ComboBox ocaType;
        private System.Windows.Forms.TextBox goodUntil;
        private System.Windows.Forms.TextBox ocaGroup;
        private System.Windows.Forms.TextBox goodAfter;
        private System.Windows.Forms.TextBox minQty;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.CheckBox transmit;
        private System.Windows.Forms.CheckBox optOutSmart;
        private System.Windows.Forms.TextBox nbboPriceCap;
        private System.Windows.Forms.TextBox discretionaryAmount;
        private System.Windows.Forms.TextBox trailingPercent;

        private System.Windows.Forms.Label orderSymbolLabel;
        private System.Windows.Forms.Label orderSecTypeLabel;
        private System.Windows.Forms.Label orderExpiryLabel;
        private System.Windows.Forms.Label orderStrikeLabel;
        private System.Windows.Forms.Label orderRightLabel;
        private System.Windows.Forms.Label orderMultiplierLabel;
        private System.Windows.Forms.Label orderExchangeLabel;
        private System.Windows.Forms.Label orderCurrencyLabel;
        private System.Windows.Forms.Label orderLocalSymbol;
        private System.Windows.Forms.Label tiggerMethodLabel;
        private System.Windows.Forms.Label rule80ALabel;
        private System.Windows.Forms.Label goodUntilLabel;
        private System.Windows.Forms.Label goodAfterLabel;
        private System.Windows.Forms.Label orderMinQtyLabel;
        private System.Windows.Forms.Label orderRefLabel;
        private System.Windows.Forms.Label percentOffsetLabel;        
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label trailingPercentLabel;
        
    }
}