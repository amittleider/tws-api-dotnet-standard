<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgAdjustStop
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
        Me.label16 = New System.Windows.Forms.Label()
        Me.cbAdjustedTrailingAmntUnit = New System.Windows.Forms.ComboBox()
        Me.tbAdjustedTrailingAmnt = New System.Windows.Forms.TextBox()
        Me.label15 = New System.Windows.Forms.Label()
        Me.tbAdjustedStopLimitPrice = New System.Windows.Forms.TextBox()
        Me.label14 = New System.Windows.Forms.Label()
        Me.tbAdjustedStopPrice = New System.Windows.Forms.TextBox()
        Me.label13 = New System.Windows.Forms.Label()
        Me.tbTriggerPrice = New System.Windows.Forms.TextBox()
        Me.label12 = New System.Windows.Forms.Label()
        Me.cbAdjustedOrderType = New System.Windows.Forms.ComboBox()
        Me.label11 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'label16
        '
        Me.label16.AutoSize = True
        Me.label16.Location = New System.Drawing.Point(13, 146)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(139, 13)
        Me.label16.TabIndex = 25
        Me.label16.Text = "Adjusted trailing amount unit"
        '
        'cbAdjustedTrailingAmntUnit
        '
        Me.cbAdjustedTrailingAmntUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAdjustedTrailingAmntUnit.FormattingEnabled = True
        Me.cbAdjustedTrailingAmntUnit.Items.AddRange(New Object() {"amonunt", "%"})
        Me.cbAdjustedTrailingAmntUnit.Location = New System.Drawing.Point(162, 143)
        Me.cbAdjustedTrailingAmntUnit.Name = "cbAdjustedTrailingAmntUnit"
        Me.cbAdjustedTrailingAmntUnit.Size = New System.Drawing.Size(121, 21)
        Me.cbAdjustedTrailingAmntUnit.TabIndex = 23
        '
        'tbAdjustedTrailingAmnt
        '
        Me.tbAdjustedTrailingAmnt.Location = New System.Drawing.Point(162, 117)
        Me.tbAdjustedTrailingAmnt.Name = "tbAdjustedTrailingAmnt"
        Me.tbAdjustedTrailingAmnt.Size = New System.Drawing.Size(121, 20)
        Me.tbAdjustedTrailingAmnt.TabIndex = 21
        '
        'label15
        '
        Me.label15.AutoSize = True
        Me.label15.Location = New System.Drawing.Point(13, 120)
        Me.label15.Name = "label15"
        Me.label15.Size = New System.Drawing.Size(119, 13)
        Me.label15.TabIndex = 24
        Me.label15.Text = "Adjusted trailing amount"
        '
        'tbAdjustedStopLimitPrice
        '
        Me.tbAdjustedStopLimitPrice.Location = New System.Drawing.Point(162, 91)
        Me.tbAdjustedStopLimitPrice.Name = "tbAdjustedStopLimitPrice"
        Me.tbAdjustedStopLimitPrice.Size = New System.Drawing.Size(121, 20)
        Me.tbAdjustedStopLimitPrice.TabIndex = 20
        '
        'label14
        '
        Me.label14.AutoSize = True
        Me.label14.Location = New System.Drawing.Point(13, 94)
        Me.label14.Name = "label14"
        Me.label14.Size = New System.Drawing.Size(115, 13)
        Me.label14.TabIndex = 22
        Me.label14.Text = "Adusted stop limit price"
        '
        'tbAdjustedStopPrice
        '
        Me.tbAdjustedStopPrice.Location = New System.Drawing.Point(162, 65)
        Me.tbAdjustedStopPrice.Name = "tbAdjustedStopPrice"
        Me.tbAdjustedStopPrice.Size = New System.Drawing.Size(121, 20)
        Me.tbAdjustedStopPrice.TabIndex = 18
        '
        'label13
        '
        Me.label13.AutoSize = True
        Me.label13.Location = New System.Drawing.Point(13, 68)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(97, 13)
        Me.label13.TabIndex = 19
        Me.label13.Text = "Adjusted stop price"
        '
        'tbTriggerPrice
        '
        Me.tbTriggerPrice.Location = New System.Drawing.Point(162, 39)
        Me.tbTriggerPrice.Name = "tbTriggerPrice"
        Me.tbTriggerPrice.Size = New System.Drawing.Size(121, 20)
        Me.tbTriggerPrice.TabIndex = 17
        '
        'label12
        '
        Me.label12.AutoSize = True
        Me.label12.Location = New System.Drawing.Point(13, 15)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(98, 13)
        Me.label12.TabIndex = 15
        Me.label12.Text = "Adjust to order type"
        '
        'cbAdjustedOrderType
        '
        Me.cbAdjustedOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAdjustedOrderType.FormattingEnabled = True
        Me.cbAdjustedOrderType.Items.AddRange(New Object() {"", "STP", "STP LMT", "TRAIL", "TRAIL LIMIT"})
        Me.cbAdjustedOrderType.Location = New System.Drawing.Point(162, 12)
        Me.cbAdjustedOrderType.Name = "cbAdjustedOrderType"
        Me.cbAdjustedOrderType.Size = New System.Drawing.Size(121, 21)
        Me.cbAdjustedOrderType.TabIndex = 16
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Location = New System.Drawing.Point(13, 42)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(66, 13)
        Me.label11.TabIndex = 13
        Me.label11.Text = "Trigger price"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(208, 176)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 28
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(127, 176)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 27
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'dlgAdjustStop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(295, 211)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.label16)
        Me.Controls.Add(Me.cbAdjustedTrailingAmntUnit)
        Me.Controls.Add(Me.tbAdjustedTrailingAmnt)
        Me.Controls.Add(Me.label15)
        Me.Controls.Add(Me.tbAdjustedStopLimitPrice)
        Me.Controls.Add(Me.label14)
        Me.Controls.Add(Me.tbAdjustedStopPrice)
        Me.Controls.Add(Me.label13)
        Me.Controls.Add(Me.tbTriggerPrice)
        Me.Controls.Add(Me.label12)
        Me.Controls.Add(Me.cbAdjustedOrderType)
        Me.Controls.Add(Me.label11)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "dlgAdjustStop"
        Me.Text = "Adjustable stops"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents label16 As System.Windows.Forms.Label
    Private WithEvents cbAdjustedTrailingAmntUnit As System.Windows.Forms.ComboBox
    Private WithEvents tbAdjustedTrailingAmnt As System.Windows.Forms.TextBox
    Private WithEvents label15 As System.Windows.Forms.Label
    Private WithEvents tbAdjustedStopLimitPrice As System.Windows.Forms.TextBox
    Private WithEvents label14 As System.Windows.Forms.Label
    Private WithEvents tbAdjustedStopPrice As System.Windows.Forms.TextBox
    Private WithEvents label13 As System.Windows.Forms.Label
    Private WithEvents tbTriggerPrice As System.Windows.Forms.TextBox
    Private WithEvents label12 As System.Windows.Forms.Label
    Private WithEvents cbAdjustedOrderType As System.Windows.Forms.ComboBox
    Private WithEvents label11 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
