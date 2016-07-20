namespace IBSampleApp.ui
{
    partial class ContractSearchDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbExchange = new System.Windows.Forms.TextBox();
            this.tbCurrency = new System.Windows.Forms.TextBox();
            this.tbSymbol = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox = new System.Windows.Forms.ListBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.cbSecType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Security type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Symbol";
            // 
            // tbExchange
            // 
            this.tbExchange.Location = new System.Drawing.Point(86, 90);
            this.tbExchange.Name = "tbExchange";
            this.tbExchange.Size = new System.Drawing.Size(100, 20);
            this.tbExchange.TabIndex = 4;
            // 
            // tbCurrency
            // 
            this.tbCurrency.Location = new System.Drawing.Point(86, 64);
            this.tbCurrency.Name = "tbCurrency";
            this.tbCurrency.Size = new System.Drawing.Size(100, 20);
            this.tbCurrency.TabIndex = 3;
            // 
            // tbSymbol
            // 
            this.tbSymbol.Location = new System.Drawing.Point(86, 38);
            this.tbSymbol.Name = "tbSymbol";
            this.tbSymbol.Size = new System.Drawing.Size(100, 20);
            this.tbSymbol.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Currency";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Exchange";
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(12, 116);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(260, 147);
            this.listBox.TabIndex = 5;
            this.listBox.DoubleClick += new System.EventHandler(this.listBox_DoubleClick);
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(197, 269);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(75, 23);
            this.btSearch.TabIndex = 6;
            this.btSearch.Text = "Search";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // cbSecType
            // 
            this.cbSecType.FormattingEnabled = true;
            this.cbSecType.Items.AddRange(new object[] {
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
            this.cbSecType.Location = new System.Drawing.Point(86, 11);
            this.cbSecType.Name = "cbSecType";
            this.cbSecType.Size = new System.Drawing.Size(100, 21);
            this.cbSecType.TabIndex = 1;
            // 
            // ContractSearchDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 298);
            this.Controls.Add(this.cbSecType);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbSymbol);
            this.Controls.Add(this.tbCurrency);
            this.Controls.Add(this.tbExchange);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ContractSearchDialog";
            this.Text = "Search contract";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbExchange;
        private System.Windows.Forms.TextBox tbCurrency;
        private System.Windows.Forms.TextBox tbSymbol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.ComboBox cbSecType;
    }
}