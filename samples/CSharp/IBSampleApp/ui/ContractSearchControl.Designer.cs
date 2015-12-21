namespace IBSampleApp.ui
{
    partial class ContractSearchControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.clear = new System.Windows.Forms.LinkLabel();
            this.searchContractLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // clear
            // 
            this.clear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clear.AutoSize = true;
            this.clear.Location = new System.Drawing.Point(177, 0);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(30, 13);
            this.clear.TabIndex = 14;
            this.clear.TabStop = true;
            this.clear.Text = "clear";
            this.clear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.clear_LinkClicked);
            // 
            // searchContractLink
            // 
            this.searchContractLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.searchContractLink.AutoSize = true;
            this.searchContractLink.Location = new System.Drawing.Point(-3, 0);
            this.searchContractLink.Name = "searchContractLink";
            this.searchContractLink.Size = new System.Drawing.Size(48, 13);
            this.searchContractLink.TabIndex = 13;
            this.searchContractLink.TabStop = true;
            this.searchContractLink.Text = "search...";
            this.searchContractLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.searchContractLink_LinkClicked);
            // 
            // ContractSearchControl
            // 
            this.Controls.Add(this.clear);
            this.Controls.Add(this.searchContractLink);
            this.Name = "ContractSearchControl";
            this.Size = new System.Drawing.Size(206, 13);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel clear;
        private System.Windows.Forms.LinkLabel searchContractLink;
    }
}
