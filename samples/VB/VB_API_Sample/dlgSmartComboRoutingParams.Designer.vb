' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgSmartComboRoutingParams
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.frmParameters = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmdAddParam = New System.Windows.Forms.Button()
        Me.cmdRemoveParam = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtValue = New System.Windows.Forms.TextBox()
        Me.lblParam = New System.Windows.Forms.Label()
        Me.lblValue = New System.Windows.Forms.Label()
        Me.txtParam = New System.Windows.Forms.TextBox()
        Me.grdParams = New System.Windows.Forms.ListView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.frmParameters.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(121, 338)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'frmParameters
        '
        Me.frmParameters.Controls.Add(Me.TableLayoutPanel3)
        Me.frmParameters.Controls.Add(Me.TableLayoutPanel2)
        Me.frmParameters.Controls.Add(Me.grdParams)
        Me.frmParameters.Location = New System.Drawing.Point(18, 12)
        Me.frmParameters.Name = "frmParameters"
        Me.frmParameters.Size = New System.Drawing.Size(249, 327)
        Me.frmParameters.TabIndex = 2
        Me.frmParameters.TabStop = False
        Me.frmParameters.Text = "Parameters"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.cmdAddParam, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.cmdRemoveParam, 1, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(86, 289)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel3.TabIndex = 2
        '
        'cmdAddParam
        '
        Me.cmdAddParam.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdAddParam.Location = New System.Drawing.Point(3, 3)
        Me.cmdAddParam.Name = "cmdAddParam"
        Me.cmdAddParam.Size = New System.Drawing.Size(67, 23)
        Me.cmdAddParam.TabIndex = 0
        Me.cmdAddParam.Text = "Add"
        '
        'cmdRemoveParam
        '
        Me.cmdRemoveParam.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmdRemoveParam.Location = New System.Drawing.Point(76, 3)
        Me.cmdRemoveParam.Name = "cmdRemoveParam"
        Me.cmdRemoveParam.Size = New System.Drawing.Size(67, 23)
        Me.cmdRemoveParam.TabIndex = 1
        Me.cmdRemoveParam.Text = "Remove"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0777!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.9223!))
        Me.TableLayoutPanel2.Controls.Add(Me.txtValue, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblParam, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblValue, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.txtParam, 1, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(6, 215)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.9925!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0075!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(226, 68)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'txtValue
        '
        Me.txtValue.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtValue.Location = New System.Drawing.Point(63, 40)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(156, 20)
        Me.txtValue.TabIndex = 1
        '
        'lblParam
        '
        Me.lblParam.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblParam.AutoSize = True
        Me.lblParam.Location = New System.Drawing.Point(8, 10)
        Me.lblParam.Name = "lblParam"
        Me.lblParam.Size = New System.Drawing.Size(40, 13)
        Me.lblParam.TabIndex = 3
        Me.lblParam.Text = "Param:"
        '
        'lblValue
        '
        Me.lblValue.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblValue.AutoSize = True
        Me.lblValue.Location = New System.Drawing.Point(9, 44)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(37, 13)
        Me.lblValue.TabIndex = 4
        Me.lblValue.Text = "Value:"
        '
        'txtParam
        '
        Me.txtParam.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtParam.Location = New System.Drawing.Point(64, 6)
        Me.txtParam.Name = "txtParam"
        Me.txtParam.Size = New System.Drawing.Size(154, 20)
        Me.txtParam.TabIndex = 0
        '
        'grdParams
        '
        Me.grdParams.AutoArrange = False
        Me.grdParams.FullRowSelect = True
        Me.grdParams.HideSelection = False
        Me.grdParams.Location = New System.Drawing.Point(6, 19)
        Me.grdParams.Name = "grdParams"
        Me.grdParams.Size = New System.Drawing.Size(226, 190)
        Me.grdParams.TabIndex = 0
        Me.grdParams.UseCompatibleStateImageBehavior = False
        Me.grdParams.View = System.Windows.Forms.View.Details
        '
        'Column1
        '
        Me.Column1.HeaderText = "Column1"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Column2"
        Me.Column2.Name = "Column2"
        '
        'dlgSmartComboRoutingParams
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 379)
        Me.Controls.Add(Me.frmParameters)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgSmartComboRoutingParams"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Smart Combo Routing Parameters"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.frmParameters.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents frmParameters As System.Windows.Forms.GroupBox
    Friend WithEvents grdParams As ListView
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents lblParam As System.Windows.Forms.Label
    Friend WithEvents lblValue As System.Windows.Forms.Label
    Friend WithEvents txtParam As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmdAddParam As System.Windows.Forms.Button
    Friend WithEvents cmdRemoveParam As System.Windows.Forms.Button
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
