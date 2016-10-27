namespace IBSampleApp.ui
{
    partial class ConditionDialog
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
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.percentPanel = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.percent = new System.Windows.Forms.TextBox();
            this.percentOperator = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.percentUnderlying = new IBSampleApp.ui.ContractSearchControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.volumePanel = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.volume = new System.Windows.Forms.TextBox();
            this.volumeOperator = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.volumeUnderlying = new IBSampleApp.ui.ContractSearchControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.timePanel = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.TextBox();
            this.timeOperator = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tradePanel = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tradeType = new System.Windows.Forms.TextBox();
            this.tradeExchange = new System.Windows.Forms.TextBox();
            this.tradeUnderlying = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.marginPanel = new System.Windows.Forms.Panel();
            this.marginOperator = new System.Windows.Forms.ComboBox();
            this.marginCushion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pricePanel = new System.Windows.Forms.Panel();
            this.priceUnderlying = new IBSampleApp.ui.ContractSearchControl();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.priceOperator = new System.Windows.Forms.ComboBox();
            this.price = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.conditionPage = new System.Windows.Forms.TabPage();
            this.conditionPanel = new System.Windows.Forms.Panel();
            this.back = new System.Windows.Forms.Button();
            this.apply = new System.Windows.Forms.Button();
            this.conditionTypePage = new System.Windows.Forms.TabPage();
            this.percentRb = new System.Windows.Forms.RadioButton();
            this.volumeRb = new System.Windows.Forms.RadioButton();
            this.timeRb = new System.Windows.Forms.RadioButton();
            this.tradeRb = new System.Windows.Forms.RadioButton();
            this.marginRb = new System.Windows.Forms.RadioButton();
            this.priceRb = new System.Windows.Forms.RadioButton();
            this.next = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.priceMethod = new System.Windows.Forms.ComboBox();
            this.tabPage6.SuspendLayout();
            this.percentPanel.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.volumePanel.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.timePanel.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tradePanel.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.marginPanel.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pricePanel.SuspendLayout();
            this.conditionPage.SuspendLayout();
            this.conditionTypePage.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.percentPanel);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(293, 136);
            this.tabPage6.TabIndex = 7;
            this.tabPage6.Text = "Percent";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // percentPanel
            // 
            this.percentPanel.Controls.Add(this.label14);
            this.percentPanel.Controls.Add(this.percent);
            this.percentPanel.Controls.Add(this.percentOperator);
            this.percentPanel.Controls.Add(this.label13);
            this.percentPanel.Controls.Add(this.label12);
            this.percentPanel.Controls.Add(this.percentUnderlying);
            this.percentPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.percentPanel.Location = new System.Drawing.Point(0, 0);
            this.percentPanel.Name = "percentPanel";
            this.percentPanel.Size = new System.Drawing.Size(293, 100);
            this.percentPanel.TabIndex = 32;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "Underlying";
            // 
            // percent
            // 
            this.percent.Location = new System.Drawing.Point(115, 58);
            this.percent.Name = "percent";
            this.percent.Size = new System.Drawing.Size(167, 20);
            this.percent.TabIndex = 28;
            // 
            // percentOperator
            // 
            this.percentOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.percentOperator.FormattingEnabled = true;
            this.percentOperator.Items.AddRange(new object[] {
            "<=",
            ">="});
            this.percentOperator.Location = new System.Drawing.Point(115, 31);
            this.percentOperator.Name = "percentOperator";
            this.percentOperator.Size = new System.Drawing.Size(167, 21);
            this.percentOperator.TabIndex = 27;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 34);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Operator";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 61);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "Percentage change";
            // 
            // percentUnderlying
            // 
            this.percentUnderlying.Contract = null;
            this.percentUnderlying.IBClient = null;
            this.percentUnderlying.Location = new System.Drawing.Point(74, 12);
            this.percentUnderlying.Name = "percentUnderlying";
            this.percentUnderlying.Size = new System.Drawing.Size(206, 13);
            this.percentUnderlying.TabIndex = 31;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.volumePanel);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(293, 136);
            this.tabPage5.TabIndex = 6;
            this.tabPage5.Text = "Volume";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // volumePanel
            // 
            this.volumePanel.Controls.Add(this.label19);
            this.volumePanel.Controls.Add(this.volume);
            this.volumePanel.Controls.Add(this.volumeOperator);
            this.volumePanel.Controls.Add(this.label17);
            this.volumePanel.Controls.Add(this.label16);
            this.volumePanel.Controls.Add(this.volumeUnderlying);
            this.volumePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.volumePanel.Location = new System.Drawing.Point(0, 0);
            this.volumePanel.Name = "volumePanel";
            this.volumePanel.Size = new System.Drawing.Size(293, 100);
            this.volumePanel.TabIndex = 26;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(8, 11);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(57, 13);
            this.label19.TabIndex = 18;
            this.label19.Text = "Underlying";
            // 
            // volume
            // 
            this.volume.Location = new System.Drawing.Point(74, 57);
            this.volume.Name = "volume";
            this.volume.Size = new System.Drawing.Size(208, 20);
            this.volume.TabIndex = 22;
            // 
            // volumeOperator
            // 
            this.volumeOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.volumeOperator.FormattingEnabled = true;
            this.volumeOperator.Items.AddRange(new object[] {
            "<=",
            ">="});
            this.volumeOperator.Location = new System.Drawing.Point(74, 30);
            this.volumeOperator.Name = "volumeOperator";
            this.volumeOperator.Size = new System.Drawing.Size(208, 21);
            this.volumeOperator.TabIndex = 21;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 33);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 13);
            this.label17.TabIndex = 23;
            this.label17.Text = "Operator";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 60);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 13);
            this.label16.TabIndex = 24;
            this.label16.Text = "Volume";
            // 
            // volumeUnderlying
            // 
            this.volumeUnderlying.Contract = null;
            this.volumeUnderlying.IBClient = null;
            this.volumeUnderlying.Location = new System.Drawing.Point(74, 11);
            this.volumeUnderlying.Name = "volumeUnderlying";
            this.volumeUnderlying.Size = new System.Drawing.Size(206, 13);
            this.volumeUnderlying.TabIndex = 25;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.timePanel);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(293, 136);
            this.tabPage4.TabIndex = 5;
            this.tabPage4.Text = "Time";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // timePanel
            // 
            this.timePanel.Controls.Add(this.label11);
            this.timePanel.Controls.Add(this.label10);
            this.timePanel.Controls.Add(this.time);
            this.timePanel.Controls.Add(this.timeOperator);
            this.timePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.timePanel.Location = new System.Drawing.Point(0, 0);
            this.timePanel.Name = "timePanel";
            this.timePanel.Size = new System.Drawing.Size(293, 100);
            this.timePanel.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Time";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Operator";
            // 
            // time
            // 
            this.time.Location = new System.Drawing.Point(77, 52);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(209, 20);
            this.time.TabIndex = 6;
            // 
            // timeOperator
            // 
            this.timeOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeOperator.FormattingEnabled = true;
            this.timeOperator.Items.AddRange(new object[] {
            "<=",
            ">="});
            this.timeOperator.Location = new System.Drawing.Point(77, 25);
            this.timeOperator.Name = "timeOperator";
            this.timeOperator.Size = new System.Drawing.Size(208, 21);
            this.timeOperator.TabIndex = 9;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tradePanel);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(293, 136);
            this.tabPage3.TabIndex = 4;
            this.tabPage3.Text = "Trade";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tradePanel
            // 
            this.tradePanel.Controls.Add(this.label9);
            this.tradePanel.Controls.Add(this.label8);
            this.tradePanel.Controls.Add(this.label7);
            this.tradePanel.Controls.Add(this.tradeType);
            this.tradePanel.Controls.Add(this.tradeExchange);
            this.tradePanel.Controls.Add(this.tradeUnderlying);
            this.tradePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tradePanel.Location = new System.Drawing.Point(0, 0);
            this.tradePanel.Name = "tradePanel";
            this.tradePanel.Size = new System.Drawing.Size(293, 106);
            this.tradePanel.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Type";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Exchange";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Underlying";
            // 
            // tradeType
            // 
            this.tradeType.Location = new System.Drawing.Point(71, 67);
            this.tradeType.Name = "tradeType";
            this.tradeType.Size = new System.Drawing.Size(214, 20);
            this.tradeType.TabIndex = 2;
            // 
            // tradeExchange
            // 
            this.tradeExchange.Location = new System.Drawing.Point(71, 41);
            this.tradeExchange.Name = "tradeExchange";
            this.tradeExchange.Size = new System.Drawing.Size(214, 20);
            this.tradeExchange.TabIndex = 1;
            // 
            // tradeUnderlying
            // 
            this.tradeUnderlying.Location = new System.Drawing.Point(71, 15);
            this.tradeUnderlying.Name = "tradeUnderlying";
            this.tradeUnderlying.Size = new System.Drawing.Size(214, 20);
            this.tradeUnderlying.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.marginPanel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(293, 136);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "Margin";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // marginPanel
            // 
            this.marginPanel.Controls.Add(this.marginOperator);
            this.marginPanel.Controls.Add(this.marginCushion);
            this.marginPanel.Controls.Add(this.label5);
            this.marginPanel.Controls.Add(this.label6);
            this.marginPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.marginPanel.Location = new System.Drawing.Point(0, 0);
            this.marginPanel.Name = "marginPanel";
            this.marginPanel.Size = new System.Drawing.Size(293, 136);
            this.marginPanel.TabIndex = 4;
            // 
            // marginOperator
            // 
            this.marginOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.marginOperator.FormattingEnabled = true;
            this.marginOperator.Items.AddRange(new object[] {
            "<=",
            ">="});
            this.marginOperator.Location = new System.Drawing.Point(76, 26);
            this.marginOperator.Name = "marginOperator";
            this.marginOperator.Size = new System.Drawing.Size(208, 21);
            this.marginOperator.TabIndex = 5;
            // 
            // marginCushion
            // 
            this.marginCushion.Location = new System.Drawing.Point(76, 53);
            this.marginCushion.Name = "marginCushion";
            this.marginCushion.Size = new System.Drawing.Size(209, 20);
            this.marginCushion.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Operator";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Cushion (%)";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pricePanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(293, 136);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Price";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pricePanel
            // 
            this.pricePanel.Controls.Add(this.priceMethod);
            this.pricePanel.Controls.Add(this.priceUnderlying);
            this.pricePanel.Controls.Add(this.label4);
            this.pricePanel.Controls.Add(this.label3);
            this.pricePanel.Controls.Add(this.label2);
            this.pricePanel.Controls.Add(this.priceOperator);
            this.pricePanel.Controls.Add(this.price);
            this.pricePanel.Controls.Add(this.label1);
            this.pricePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pricePanel.Location = new System.Drawing.Point(0, 0);
            this.pricePanel.Name = "pricePanel";
            this.pricePanel.Size = new System.Drawing.Size(293, 105);
            this.pricePanel.TabIndex = 0;
            // 
            // priceUnderlying
            // 
            this.priceUnderlying.Contract = null;
            this.priceUnderlying.IBClient = null;
            this.priceUnderlying.Location = new System.Drawing.Point(74, 9);
            this.priceUnderlying.Name = "priceUnderlying";
            this.priceUnderlying.Size = new System.Drawing.Size(206, 13);
            this.priceUnderlying.TabIndex = 17;
            this.priceUnderlying.Text = "contractSearchControl1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Operator";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Method";
            // 
            // priceOperator
            // 
            this.priceOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.priceOperator.FormattingEnabled = true;
            this.priceOperator.Items.AddRange(new object[] {
            "<=",
            ">="});
            this.priceOperator.Location = new System.Drawing.Point(74, 51);
            this.priceOperator.Name = "priceOperator";
            this.priceOperator.Size = new System.Drawing.Size(208, 21);
            this.priceOperator.TabIndex = 4;
            // 
            // price
            // 
            this.price.Location = new System.Drawing.Point(74, 78);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(208, 20);
            this.price.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Underlying";
            // 
            // conditionPage
            // 
            this.conditionPage.Controls.Add(this.conditionPanel);
            this.conditionPage.Controls.Add(this.back);
            this.conditionPage.Controls.Add(this.apply);
            this.conditionPage.Location = new System.Drawing.Point(4, 22);
            this.conditionPage.Name = "conditionPage";
            this.conditionPage.Padding = new System.Windows.Forms.Padding(3);
            this.conditionPage.Size = new System.Drawing.Size(293, 136);
            this.conditionPage.TabIndex = 1;
            this.conditionPage.Text = "Condition";
            this.conditionPage.UseVisualStyleBackColor = true;
            // 
            // conditionPanel
            // 
            this.conditionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.conditionPanel.Location = new System.Drawing.Point(3, 3);
            this.conditionPanel.Name = "conditionPanel";
            this.conditionPanel.Size = new System.Drawing.Size(287, 100);
            this.conditionPanel.TabIndex = 3;
            // 
            // back
            // 
            this.back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.back.Location = new System.Drawing.Point(129, 105);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(75, 23);
            this.back.TabIndex = 1;
            this.back.Text = "Back";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // apply
            // 
            this.apply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.apply.Location = new System.Drawing.Point(210, 105);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(75, 23);
            this.apply.TabIndex = 2;
            this.apply.Text = "Apply";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.apply_Click);
            // 
            // conditionTypePage
            // 
            this.conditionTypePage.Controls.Add(this.percentRb);
            this.conditionTypePage.Controls.Add(this.volumeRb);
            this.conditionTypePage.Controls.Add(this.timeRb);
            this.conditionTypePage.Controls.Add(this.tradeRb);
            this.conditionTypePage.Controls.Add(this.marginRb);
            this.conditionTypePage.Controls.Add(this.priceRb);
            this.conditionTypePage.Controls.Add(this.next);
            this.conditionTypePage.Location = new System.Drawing.Point(4, 22);
            this.conditionTypePage.Name = "conditionTypePage";
            this.conditionTypePage.Padding = new System.Windows.Forms.Padding(3);
            this.conditionTypePage.Size = new System.Drawing.Size(293, 136);
            this.conditionTypePage.TabIndex = 0;
            this.conditionTypePage.Text = "Condition type";
            this.conditionTypePage.UseVisualStyleBackColor = true;
            // 
            // percentRb
            // 
            this.percentRb.AutoSize = true;
            this.percentRb.Location = new System.Drawing.Point(183, 52);
            this.percentRb.Name = "percentRb";
            this.percentRb.Size = new System.Drawing.Size(102, 17);
            this.percentRb.TabIndex = 6;
            this.percentRb.Text = "Percent Change";
            this.percentRb.UseVisualStyleBackColor = true;
            // 
            // volumeRb
            // 
            this.volumeRb.AutoSize = true;
            this.volumeRb.Location = new System.Drawing.Point(183, 29);
            this.volumeRb.Name = "volumeRb";
            this.volumeRb.Size = new System.Drawing.Size(60, 17);
            this.volumeRb.TabIndex = 5;
            this.volumeRb.Text = "Volume";
            this.volumeRb.UseVisualStyleBackColor = true;
            // 
            // timeRb
            // 
            this.timeRb.AutoSize = true;
            this.timeRb.Location = new System.Drawing.Point(183, 6);
            this.timeRb.Name = "timeRb";
            this.timeRb.Size = new System.Drawing.Size(48, 17);
            this.timeRb.TabIndex = 4;
            this.timeRb.Text = "Time";
            this.timeRb.UseVisualStyleBackColor = true;
            // 
            // tradeRb
            // 
            this.tradeRb.AutoSize = true;
            this.tradeRb.Location = new System.Drawing.Point(8, 52);
            this.tradeRb.Name = "tradeRb";
            this.tradeRb.Size = new System.Drawing.Size(53, 17);
            this.tradeRb.TabIndex = 3;
            this.tradeRb.Text = "Trade";
            this.tradeRb.UseVisualStyleBackColor = true;
            // 
            // marginRb
            // 
            this.marginRb.AutoSize = true;
            this.marginRb.Location = new System.Drawing.Point(8, 29);
            this.marginRb.Name = "marginRb";
            this.marginRb.Size = new System.Drawing.Size(98, 17);
            this.marginRb.TabIndex = 2;
            this.marginRb.Text = "Margin Cushion";
            this.marginRb.UseVisualStyleBackColor = true;
            // 
            // priceRb
            // 
            this.priceRb.AutoSize = true;
            this.priceRb.Checked = true;
            this.priceRb.Location = new System.Drawing.Point(8, 6);
            this.priceRb.Name = "priceRb";
            this.priceRb.Size = new System.Drawing.Size(49, 17);
            this.priceRb.TabIndex = 1;
            this.priceRb.TabStop = true;
            this.priceRb.Text = "Price";
            this.priceRb.UseVisualStyleBackColor = true;
            // 
            // next
            // 
            this.next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.next.Location = new System.Drawing.Point(210, 105);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(75, 23);
            this.next.TabIndex = 7;
            this.next.Text = "Next";
            this.next.UseVisualStyleBackColor = true;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.conditionTypePage);
            this.tabControl1.Controls.Add(this.conditionPage);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(301, 162);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // priceMethod
            // 
            this.priceMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.priceMethod.FormattingEnabled = true;
            this.priceMethod.Location = new System.Drawing.Point(74, 25);
            this.priceMethod.Name = "priceMethod";
            this.priceMethod.Size = new System.Drawing.Size(206, 21);
            this.priceMethod.TabIndex = 18;
            // 
            // ConditionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 162);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ConditionDialog";
            this.Text = "Condition";
            this.tabPage6.ResumeLayout(false);
            this.percentPanel.ResumeLayout(false);
            this.percentPanel.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.volumePanel.ResumeLayout(false);
            this.volumePanel.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.timePanel.ResumeLayout(false);
            this.timePanel.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tradePanel.ResumeLayout(false);
            this.tradePanel.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.marginPanel.ResumeLayout(false);
            this.marginPanel.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.pricePanel.ResumeLayout(false);
            this.pricePanel.PerformLayout();
            this.conditionPage.ResumeLayout(false);
            this.conditionTypePage.ResumeLayout(false);
            this.conditionTypePage.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage6;
        private ContractSearchControl percentUnderlying;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox percentOperator;
        private System.Windows.Forms.TextBox percent;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabPage tabPage5;
        private ContractSearchControl volumeUnderlying;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox volumeOperator;
        private System.Windows.Forms.TextBox volume;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ComboBox timeOperator;
        private System.Windows.Forms.TextBox time;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel tradePanel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tradeType;
        private System.Windows.Forms.TextBox tradeExchange;
        private System.Windows.Forms.TextBox tradeUnderlying;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel marginPanel;
        private System.Windows.Forms.ComboBox marginOperator;
        private System.Windows.Forms.TextBox marginCushion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel pricePanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox priceOperator;
        private System.Windows.Forms.TextBox price;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage conditionPage;
        private System.Windows.Forms.Panel conditionPanel;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button apply;
        private System.Windows.Forms.TabPage conditionTypePage;
        private System.Windows.Forms.RadioButton percentRb;
        private System.Windows.Forms.RadioButton volumeRb;
        private System.Windows.Forms.RadioButton timeRb;
        private System.Windows.Forms.RadioButton tradeRb;
        private System.Windows.Forms.RadioButton marginRb;
        private System.Windows.Forms.RadioButton priceRb;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Panel percentPanel;
        private System.Windows.Forms.Panel volumePanel;
        private System.Windows.Forms.Panel timePanel;
        private ContractSearchControl priceUnderlying;
        private System.Windows.Forms.ComboBox priceMethod;




    }
}