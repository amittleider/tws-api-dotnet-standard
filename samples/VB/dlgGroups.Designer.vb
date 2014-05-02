' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgGroups
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
        Me.labelId = New System.Windows.Forms.Label
        Me.textId = New System.Windows.Forms.TextBox
        Me.cmdQueryDisplayGroups = New System.Windows.Forms.Button
        Me.comboDisplayGroups = New System.Windows.Forms.ComboBox
        Me.labelDisplayGroups = New System.Windows.Forms.Label
        Me.cmdSubscribeToGroupEvents = New System.Windows.Forms.Button
        Me.cmdUnsubscribeFromGroupEvents = New System.Windows.Forms.Button
        Me.cmdUpdateDisplayGroup = New System.Windows.Forms.Button
        Me.labelContractInfo = New System.Windows.Forms.Label
        Me.textContractInfo = New System.Windows.Forms.TextBox
        Me.lstGroupMessages = New System.Windows.Forms.ListBox
        Me.cmdReset = New System.Windows.Forms.Button
        Me.cmdClose = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'labelId
        '
        Me.labelId.AutoSize = True
        Me.labelId.Location = New System.Drawing.Point(12, 14)
        Me.labelId.Name = "labelId"
        Me.labelId.Size = New System.Drawing.Size(16, 13)
        Me.labelId.TabIndex = 0
        Me.labelId.Text = "Id"
        '
        'textId
        '
        Me.textId.Location = New System.Drawing.Point(42, 7)
        Me.textId.Name = "textId"
        Me.textId.Size = New System.Drawing.Size(73, 20)
        Me.textId.TabIndex = 1
        Me.textId.Text = "0"
        '
        'cmdQueryDisplayGroups
        '
        Me.cmdQueryDisplayGroups.Location = New System.Drawing.Point(12, 36)
        Me.cmdQueryDisplayGroups.Name = "cmdQueryDisplayGroups"
        Me.cmdQueryDisplayGroups.Size = New System.Drawing.Size(173, 23)
        Me.cmdQueryDisplayGroups.TabIndex = 2
        Me.cmdQueryDisplayGroups.Text = "Query Display Groups"
        Me.cmdQueryDisplayGroups.UseVisualStyleBackColor = True
        '
        'comboDisplayGroups
        '
        Me.comboDisplayGroups.FormattingEnabled = True
        Me.comboDisplayGroups.Location = New System.Drawing.Point(202, 65)
        Me.comboDisplayGroups.Name = "comboDisplayGroups"
        Me.comboDisplayGroups.Size = New System.Drawing.Size(174, 21)
        Me.comboDisplayGroups.TabIndex = 3
        '
        'labelDisplayGroups
        '
        Me.labelDisplayGroups.AutoSize = True
        Me.labelDisplayGroups.Location = New System.Drawing.Point(12, 68)
        Me.labelDisplayGroups.Name = "labelDisplayGroups"
        Me.labelDisplayGroups.Size = New System.Drawing.Size(78, 13)
        Me.labelDisplayGroups.TabIndex = 4
        Me.labelDisplayGroups.Text = "Display Groups"
        '
        'cmdSubscribeToGroupEvents
        '
        Me.cmdSubscribeToGroupEvents.Location = New System.Drawing.Point(12, 93)
        Me.cmdSubscribeToGroupEvents.Name = "cmdSubscribeToGroupEvents"
        Me.cmdSubscribeToGroupEvents.Size = New System.Drawing.Size(174, 21)
        Me.cmdSubscribeToGroupEvents.TabIndex = 5
        Me.cmdSubscribeToGroupEvents.Text = "Subscribe To Group Events"
        Me.cmdSubscribeToGroupEvents.UseVisualStyleBackColor = True
        '
        'cmdUnsubscribeFromGroupEvents
        '
        Me.cmdUnsubscribeFromGroupEvents.Location = New System.Drawing.Point(202, 93)
        Me.cmdUnsubscribeFromGroupEvents.Name = "cmdUnsubscribeFromGroupEvents"
        Me.cmdUnsubscribeFromGroupEvents.Size = New System.Drawing.Size(174, 21)
        Me.cmdUnsubscribeFromGroupEvents.TabIndex = 6
        Me.cmdUnsubscribeFromGroupEvents.Text = "Unsubscribe From Group Events"
        Me.cmdUnsubscribeFromGroupEvents.UseVisualStyleBackColor = True
        '
        'cmdUpdateDisplayGroup
        '
        Me.cmdUpdateDisplayGroup.Location = New System.Drawing.Point(12, 126)
        Me.cmdUpdateDisplayGroup.Name = "cmdUpdateDisplayGroup"
        Me.cmdUpdateDisplayGroup.Size = New System.Drawing.Size(174, 21)
        Me.cmdUpdateDisplayGroup.TabIndex = 7
        Me.cmdUpdateDisplayGroup.Text = "Update Display Group"
        Me.cmdUpdateDisplayGroup.UseVisualStyleBackColor = True
        '
        'labelContractInfo
        '
        Me.labelContractInfo.AutoSize = True
        Me.labelContractInfo.Location = New System.Drawing.Point(14, 160)
        Me.labelContractInfo.Name = "labelContractInfo"
        Me.labelContractInfo.Size = New System.Drawing.Size(68, 13)
        Me.labelContractInfo.TabIndex = 8
        Me.labelContractInfo.Text = "Contract Info"
        '
        'textContractInfo
        '
        Me.textContractInfo.Location = New System.Drawing.Point(205, 150)
        Me.textContractInfo.Name = "textContractInfo"
        Me.textContractInfo.Size = New System.Drawing.Size(170, 20)
        Me.textContractInfo.TabIndex = 9
        '
        'lstGroupMessages
        '
        Me.lstGroupMessages.FormattingEnabled = True
        Me.lstGroupMessages.Location = New System.Drawing.Point(20, 191)
        Me.lstGroupMessages.Name = "lstGroupMessages"
        Me.lstGroupMessages.Size = New System.Drawing.Size(354, 186)
        Me.lstGroupMessages.TabIndex = 10
        '
        'cmdReset
        '
        Me.cmdReset.Location = New System.Drawing.Point(111, 391)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(81, 21)
        Me.cmdReset.TabIndex = 11
        Me.cmdReset.Text = "Reset"
        Me.cmdReset.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(208, 391)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(81, 21)
        Me.cmdClose.TabIndex = 12
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'dlgGroups
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(388, 421)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdReset)
        Me.Controls.Add(Me.lstGroupMessages)
        Me.Controls.Add(Me.textContractInfo)
        Me.Controls.Add(Me.labelContractInfo)
        Me.Controls.Add(Me.cmdUpdateDisplayGroup)
        Me.Controls.Add(Me.cmdUnsubscribeFromGroupEvents)
        Me.Controls.Add(Me.cmdSubscribeToGroupEvents)
        Me.Controls.Add(Me.labelDisplayGroups)
        Me.Controls.Add(Me.comboDisplayGroups)
        Me.Controls.Add(Me.cmdQueryDisplayGroups)
        Me.Controls.Add(Me.textId)
        Me.Controls.Add(Me.labelId)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgGroups"
        Me.ShowIcon = False
        Me.Text = "Display Groups"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents labelId As System.Windows.Forms.Label
    Friend WithEvents textId As System.Windows.Forms.TextBox
    Friend WithEvents cmdQueryDisplayGroups As System.Windows.Forms.Button
    Friend WithEvents comboDisplayGroups As System.Windows.Forms.ComboBox
    Friend WithEvents labelDisplayGroups As System.Windows.Forms.Label
    Friend WithEvents cmdSubscribeToGroupEvents As System.Windows.Forms.Button
    Friend WithEvents cmdUnsubscribeFromGroupEvents As System.Windows.Forms.Button
    Friend WithEvents cmdUpdateDisplayGroup As System.Windows.Forms.Button
    Friend WithEvents labelContractInfo As System.Windows.Forms.Label
    Friend WithEvents textContractInfo As System.Windows.Forms.TextBox
    Friend WithEvents lstGroupMessages As System.Windows.Forms.ListBox
    Friend WithEvents cmdReset As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
End Class
