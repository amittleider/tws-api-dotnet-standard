' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgAlgoParams
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
        Me.frmAlgorithm = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblStrategy = New System.Windows.Forms.Label()
        Me.txtStrategy = New System.Windows.Forms.TextBox()
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
        Me.TableLayoutPanel1.SuspendLayout()
        Me.frmAlgorithm.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(121, 425)
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
        'frmAlgorithm
        '
        Me.frmAlgorithm.Controls.Add(Me.TableLayoutPanel4)
        Me.frmAlgorithm.Location = New System.Drawing.Point(16, 7)
        Me.frmAlgorithm.Name = "frmAlgorithm"
        Me.frmAlgorithm.Size = New System.Drawing.Size(251, 74)
        Me.frmAlgorithm.TabIndex = 1
        Me.frmAlgorithm.TabStop = False
        Me.frmAlgorithm.Text = "Algorithm"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.08!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.92!))
        Me.TableLayoutPanel4.Controls.Add(Me.lblStrategy, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.txtStrategy, 1, 0)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(13, 19)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(226, 39)
        Me.TableLayoutPanel4.TabIndex = 2
        '
        'lblStrategy
        '
        Me.lblStrategy.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblStrategy.AutoSize = True
        Me.lblStrategy.Location = New System.Drawing.Point(3, 13)
        Me.lblStrategy.Name = "lblStrategy"
        Me.lblStrategy.Size = New System.Drawing.Size(49, 13)
        Me.lblStrategy.TabIndex = 3
        Me.lblStrategy.Text = "Strategy:"
        '
        'txtStrategy
        '
        Me.txtStrategy.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtStrategy.Location = New System.Drawing.Point(64, 9)
        Me.txtStrategy.Name = "txtStrategy"
        Me.txtStrategy.Size = New System.Drawing.Size(154, 20)
        Me.txtStrategy.TabIndex = 0
        '
        'frmParameters
        '
        Me.frmParameters.Controls.Add(Me.TableLayoutPanel3)
        Me.frmParameters.Controls.Add(Me.TableLayoutPanel2)
        Me.frmParameters.Controls.Add(Me.grdParams)
        Me.frmParameters.Location = New System.Drawing.Point(18, 87)
        Me.frmParameters.Name = "frmParameters"
        Me.frmParameters.Size = New System.Drawing.Size(249, 331)
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
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(91, 293)
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
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(11, 215)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.9925!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0075!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(226, 72)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'txtValue
        '
        Me.txtValue.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtValue.Location = New System.Drawing.Point(63, 43)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(156, 20)
        Me.txtValue.TabIndex = 1
        '
        'lblParam
        '
        Me.lblParam.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblParam.AutoSize = True
        Me.lblParam.Location = New System.Drawing.Point(8, 11)
        Me.lblParam.Name = "lblParam"
        Me.lblParam.Size = New System.Drawing.Size(40, 13)
        Me.lblParam.TabIndex = 3
        Me.lblParam.Text = "Param:"
        '
        'lblValue
        '
        Me.lblValue.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblValue.AutoSize = True
        Me.lblValue.Location = New System.Drawing.Point(9, 47)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(37, 13)
        Me.lblValue.TabIndex = 4
        Me.lblValue.Text = "Value:"
        '
        'txtParam
        '
        Me.txtParam.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtParam.Location = New System.Drawing.Point(64, 7)
        Me.txtParam.Name = "txtParam"
        Me.txtParam.Size = New System.Drawing.Size(154, 20)
        Me.txtParam.TabIndex = 0
        '
        'grdParams
        '
        Me.grdParams.FullRowSelect = True
        Me.grdParams.Location = New System.Drawing.Point(11, 19)
        Me.grdParams.Name = "grdParams"
        Me.grdParams.Size = New System.Drawing.Size(226, 190)
        Me.grdParams.TabIndex = 0
        Me.grdParams.UseCompatibleStateImageBehavior = False
        Me.grdParams.View = System.Windows.Forms.View.Details
        '
        'dlgAlgoParams
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 466)
        Me.Controls.Add(Me.frmParameters)
        Me.Controls.Add(Me.frmAlgorithm)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgAlgoParams"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Algo Order Parameters"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.frmAlgorithm.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.frmParameters.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents frmAlgorithm As System.Windows.Forms.GroupBox
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
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblStrategy As System.Windows.Forms.Label
    Friend WithEvents txtStrategy As System.Windows.Forms.TextBox

End Class
