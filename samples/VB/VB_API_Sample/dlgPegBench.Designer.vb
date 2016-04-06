<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgPegBench
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cbPeggedChangeType = New System.Windows.Forms.ComboBox()
        Me.tbReferenceChangeAmount = New System.Windows.Forms.TextBox()
        Me.tbPeggedChangeAmount = New System.Windows.Forms.TextBox()
        Me.tbStartingReferencePrice = New System.Windows.Forms.TextBox()
        Me.label10 = New System.Windows.Forms.Label()
        Me.label9 = New System.Windows.Forms.Label()
        Me.label8 = New System.Windows.Forms.Label()
        Me.label7 = New System.Windows.Forms.Label()
        Me.label6 = New System.Windows.Forms.Label()
        Me.tbStartingPrice = New System.Windows.Forms.TextBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.tbReferenceContractId = New System.Windows.Forms.TextBox()
        Me.tbReferenceContractExchange = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cbPeggedChangeType
        '
        Me.cbPeggedChangeType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbPeggedChangeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPeggedChangeType.FormattingEnabled = True
        Me.cbPeggedChangeType.Items.AddRange(New Object() {"Increase", "Decrease"})
        Me.cbPeggedChangeType.Location = New System.Drawing.Point(167, 137)
        Me.cbPeggedChangeType.Name = "cbPeggedChangeType"
        Me.cbPeggedChangeType.Size = New System.Drawing.Size(195, 21)
        Me.cbPeggedChangeType.TabIndex = 21
        '
        'tbReferenceChangeAmount
        '
        Me.tbReferenceChangeAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbReferenceChangeAmount.Location = New System.Drawing.Point(167, 163)
        Me.tbReferenceChangeAmount.Name = "tbReferenceChangeAmount"
        Me.tbReferenceChangeAmount.Size = New System.Drawing.Size(195, 20)
        Me.tbReferenceChangeAmount.TabIndex = 20
        '
        'tbPeggedChangeAmount
        '
        Me.tbPeggedChangeAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbPeggedChangeAmount.Location = New System.Drawing.Point(167, 111)
        Me.tbPeggedChangeAmount.Name = "tbPeggedChangeAmount"
        Me.tbPeggedChangeAmount.Size = New System.Drawing.Size(195, 20)
        Me.tbPeggedChangeAmount.TabIndex = 19
        '
        'tbStartingReferencePrice
        '
        Me.tbStartingReferencePrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbStartingReferencePrice.Location = New System.Drawing.Point(167, 85)
        Me.tbStartingReferencePrice.Name = "tbStartingReferencePrice"
        Me.tbStartingReferencePrice.Size = New System.Drawing.Size(195, 20)
        Me.tbStartingReferencePrice.TabIndex = 18
        '
        'label10
        '
        Me.label10.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip
        Me.label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label10.AutoSize = True
        Me.label10.Location = New System.Drawing.Point(12, 166)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(134, 13)
        Me.label10.TabIndex = 17
        Me.label10.Text = "Reference change amount"
        '
        'label9
        '
        Me.label9.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip
        Me.label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(12, 140)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(106, 13)
        Me.label9.TabIndex = 16
        Me.label9.Text = "Pegged change type"
        '
        'label8
        '
        Me.label8.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip
        Me.label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(12, 114)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(121, 13)
        Me.label8.TabIndex = 15
        Me.label8.Text = "Pegged change amount"
        '
        'label7
        '
        Me.label7.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip
        Me.label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(12, 88)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(117, 13)
        Me.label7.TabIndex = 14
        Me.label7.Text = "Starting reference price"
        '
        'label6
        '
        Me.label6.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(12, 35)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(110, 13)
        Me.label6.TabIndex = 13
        Me.label6.Text = "Reference contract id"
        '
        'tbStartingPrice
        '
        Me.tbStartingPrice.Location = New System.Drawing.Point(167, 6)
        Me.tbStartingPrice.Name = "tbStartingPrice"
        Me.tbStartingPrice.Size = New System.Drawing.Size(195, 20)
        Me.tbStartingPrice.TabIndex = 12
        '
        'label4
        '
        Me.label4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(12, 9)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(69, 13)
        Me.label4.TabIndex = 11
        Me.label4.Text = "Starting price"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(209, 202)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 22
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(290, 202)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 23
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'tbReferenceContractId
        '
        Me.tbReferenceContractId.Location = New System.Drawing.Point(167, 32)
        Me.tbReferenceContractId.Name = "tbReferenceContractId"
        Me.tbReferenceContractId.Size = New System.Drawing.Size(195, 20)
        Me.tbReferenceContractId.TabIndex = 24
        '
        'tbReferenceContractExchange
        '
        Me.tbReferenceContractExchange.Location = New System.Drawing.Point(167, 58)
        Me.tbReferenceContractExchange.Name = "tbReferenceContractExchange"
        Me.tbReferenceContractExchange.Size = New System.Drawing.Size(195, 20)
        Me.tbReferenceContractExchange.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(149, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Reference contract exchange"
        '
        'dlgPegBench
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(377, 237)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbReferenceContractExchange)
        Me.Controls.Add(Me.tbReferenceContractId)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.cbPeggedChangeType)
        Me.Controls.Add(Me.tbReferenceChangeAmount)
        Me.Controls.Add(Me.tbPeggedChangeAmount)
        Me.Controls.Add(Me.tbStartingReferencePrice)
        Me.Controls.Add(Me.label10)
        Me.Controls.Add(Me.label9)
        Me.Controls.Add(Me.label8)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.tbStartingPrice)
        Me.Controls.Add(Me.label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "dlgPegBench"
        Me.Text = "dlgPegBench"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents cbPeggedChangeType As System.Windows.Forms.ComboBox
    Private WithEvents tbReferenceChangeAmount As System.Windows.Forms.TextBox
    Private WithEvents tbPeggedChangeAmount As System.Windows.Forms.TextBox
    Private WithEvents tbStartingReferencePrice As System.Windows.Forms.TextBox
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents tbStartingPrice As System.Windows.Forms.TextBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents tbReferenceContractId As System.Windows.Forms.TextBox
    Friend WithEvents tbReferenceContractExchange As System.Windows.Forms.TextBox
    Private WithEvents Label1 As System.Windows.Forms.Label
End Class
