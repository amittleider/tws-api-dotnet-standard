' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Option Strict Off
Option Explicit On

Imports System.Collections.Generic

Friend Class dlgOrder
    Inherits System.Windows.Forms.Form
#Region "Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()
        If m_vb6FormDefInstance Is Nothing Then
            If m_InitializingDefInstance Then
                m_vb6FormDefInstance = Me
            Else
                Try
                    'For the start-up form, the first instance created is the default instance.
                    If System.Reflection.Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is Me.GetType Then
                        m_vb6FormDefInstance = Me
                    End If
                Catch
                End Try
            End If
        End If
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        Form_Initialize_Renamed()
    End Sub
    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public WithEvents txtFormatDate As System.Windows.Forms.TextBox
    Public WithEvents txtUseRTH As System.Windows.Forms.TextBox
    Public WithEvents txtWhatToShow As System.Windows.Forms.TextBox
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    Public WithEvents cmdOk As System.Windows.Forms.Button
    Public WithEvents TextMultiplier As System.Windows.Forms.TextBox
    Public WithEvents TxtPrimaryExchange As System.Windows.Forms.TextBox
    Public WithEvents txtRight As System.Windows.Forms.TextBox
    Public WithEvents txtLocalSymbol As System.Windows.Forms.TextBox
    Public WithEvents txtCurrency As System.Windows.Forms.TextBox
    Public WithEvents txtExchange As System.Windows.Forms.TextBox
    Public WithEvents txtStrike As System.Windows.Forms.TextBox
    Public WithEvents txtExpiry As System.Windows.Forms.TextBox
    Public WithEvents txtSecType As System.Windows.Forms.TextBox
    Public WithEvents txtSymbol As System.Windows.Forms.TextBox
    Public WithEvents frameTickerDesc As System.Windows.Forms.GroupBox
    Public WithEvents txtReqId As System.Windows.Forms.TextBox
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Public WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents txtDuration As System.Windows.Forms.TextBox
    Public WithEvents txtBarSizeSetting As System.Windows.Forms.TextBox
    Public WithEvents txtEndDateTime As System.Windows.Forms.TextBox
    Public WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Public WithEvents txtExerciseAction As System.Windows.Forms.TextBox
    Public WithEvents txtExerciseQuantity As System.Windows.Forms.TextBox
    Public WithEvents txtExerciseOverride As System.Windows.Forms.TextBox
    Public WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Public WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Public WithEvents txtGenericTickTags As System.Windows.Forms.TextBox
    Public WithEvents txtNumRows As System.Windows.Forms.TextBox
    Public WithEvents Label24 As System.Windows.Forms.Label
    Public WithEvents Label23 As System.Windows.Forms.Label
    Public WithEvents Label21 As System.Windows.Forms.Label
    Public WithEvents Label20 As System.Windows.Forms.Label
    Public WithEvents Label19 As System.Windows.Forms.Label
    Public WithEvents Label25 As System.Windows.Forms.Label
    Public WithEvents Label39 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label37 As System.Windows.Forms.Label
    Public WithEvents Label53 As System.Windows.Forms.Label
    Public WithEvents Label54 As System.Windows.Forms.Label
    Public WithEvents Label55 As System.Windows.Forms.Label
    Public WithEvents Label56 As System.Windows.Forms.Label
    Public WithEvents Label57 As System.Windows.Forms.Label
    Public WithEvents Label58 As System.Windows.Forms.Label
    Public WithEvents Label22 As System.Windows.Forms.Label
    Public WithEvents Label36 As System.Windows.Forms.Label
    Public WithEvents Label35 As System.Windows.Forms.Label
    Public WithEvents Label30 As System.Windows.Forms.Label
    Public WithEvents Label38 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkSnapshotMktData As System.Windows.Forms.CheckBox
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents txtConId As System.Windows.Forms.TextBox
    Public WithEvents Label27 As System.Windows.Forms.Label
    Public WithEvents cmdSetShareAllocation As System.Windows.Forms.Button
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents Label14 As System.Windows.Forms.Label
    Public WithEvents Label15 As System.Windows.Forms.Label
    Public WithEvents Label16 As System.Windows.Forms.Label
    Public WithEvents txtAction As System.Windows.Forms.TextBox
    Public WithEvents txtQuantity As System.Windows.Forms.TextBox
    Public WithEvents txtOrderType As System.Windows.Forms.TextBox
    Public WithEvents txtLmtPrice As System.Windows.Forms.TextBox
    Public WithEvents txtAuxPrice As System.Windows.Forms.TextBox
    Public WithEvents cmdAddCmboLegs As System.Windows.Forms.Button
    Public WithEvents tGTD As System.Windows.Forms.TextBox
    Public WithEvents tGAT As System.Windows.Forms.TextBox
    Public WithEvents cmdUnderComp As System.Windows.Forms.Button
    Public WithEvents cmdAlgoParams As System.Windows.Forms.Button
    Public WithEvents frameOrderDesc As System.Windows.Forms.GroupBox
    Friend WithEvents txtSecId As System.Windows.Forms.TextBox
    Friend WithEvents txtSecIdType As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents labelMarketDataType As System.Windows.Forms.Label
    Public WithEvents frameMarketDataType As System.Windows.Forms.GroupBox
    Friend WithEvents cmbMarketDataType As System.Windows.Forms.ComboBox
    Public WithEvents cmdSmartComboRoutingParams As System.Windows.Forms.Button
    Public WithEvents txtTradingClass As System.Windows.Forms.TextBox
    Public WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdOptions As System.Windows.Forms.Button
    Public WithEvents txtIncludeExpired As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.txtEndDateTime = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.txtBarSizeSetting = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtFormatDate = New System.Windows.Forms.TextBox
        Me.txtUseRTH = New System.Windows.Forms.TextBox
        Me.txtWhatToShow = New System.Windows.Forms.TextBox
        Me.txtDuration = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.frameTickerDesc = New System.Windows.Forms.GroupBox
        Me.txtTradingClass = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtSecId = New System.Windows.Forms.TextBox
        Me.txtSecIdType = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtConId = New System.Windows.Forms.TextBox
        Me.txtIncludeExpired = New System.Windows.Forms.TextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextMultiplier = New System.Windows.Forms.TextBox
        Me.TxtPrimaryExchange = New System.Windows.Forms.TextBox
        Me.txtRight = New System.Windows.Forms.TextBox
        Me.txtLocalSymbol = New System.Windows.Forms.TextBox
        Me.txtCurrency = New System.Windows.Forms.TextBox
        Me.txtExchange = New System.Windows.Forms.TextBox
        Me.txtStrike = New System.Windows.Forms.TextBox
        Me.txtExpiry = New System.Windows.Forms.TextBox
        Me.txtSecType = New System.Windows.Forms.TextBox
        Me.txtSymbol = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label53 = New System.Windows.Forms.Label
        Me.Label54 = New System.Windows.Forms.Label
        Me.Label55 = New System.Windows.Forms.Label
        Me.Label56 = New System.Windows.Forms.Label
        Me.Label57 = New System.Windows.Forms.Label
        Me.Label58 = New System.Windows.Forms.Label
        Me.txtReqId = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkSnapshotMktData = New System.Windows.Forms.CheckBox
        Me.txtGenericTickTags = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtExerciseOverride = New System.Windows.Forms.TextBox
        Me.Label36 = New System.Windows.Forms.Label
        Me.txtExerciseQuantity = New System.Windows.Forms.TextBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.txtExerciseAction = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtNumRows = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.cmdSetShareAllocation = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtAction = New System.Windows.Forms.TextBox
        Me.txtQuantity = New System.Windows.Forms.TextBox
        Me.txtOrderType = New System.Windows.Forms.TextBox
        Me.txtLmtPrice = New System.Windows.Forms.TextBox
        Me.txtAuxPrice = New System.Windows.Forms.TextBox
        Me.cmdAddCmboLegs = New System.Windows.Forms.Button
        Me.tGTD = New System.Windows.Forms.TextBox
        Me.tGAT = New System.Windows.Forms.TextBox
        Me.cmdUnderComp = New System.Windows.Forms.Button
        Me.cmdAlgoParams = New System.Windows.Forms.Button
        Me.frameOrderDesc = New System.Windows.Forms.GroupBox
        Me.cmdOptions = New System.Windows.Forms.Button
        Me.cmdSmartComboRoutingParams = New System.Windows.Forms.Button
        Me.labelMarketDataType = New System.Windows.Forms.Label
        Me.frameMarketDataType = New System.Windows.Forms.GroupBox
        Me.cmbMarketDataType = New System.Windows.Forms.ComboBox
        Me.Frame1.SuspendLayout()
        Me.frameTickerDesc.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.frameOrderDesc.SuspendLayout()
        Me.frameMarketDataType.SuspendLayout()
        Me.SuspendLayout()
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.txtEndDateTime)
        Me.Frame1.Controls.Add(Me.Label24)
        Me.Frame1.Controls.Add(Me.txtBarSizeSetting)
        Me.Frame1.Controls.Add(Me.Label23)
        Me.Frame1.Controls.Add(Me.txtFormatDate)
        Me.Frame1.Controls.Add(Me.txtUseRTH)
        Me.Frame1.Controls.Add(Me.txtWhatToShow)
        Me.Frame1.Controls.Add(Me.txtDuration)
        Me.Frame1.Controls.Add(Me.Label21)
        Me.Frame1.Controls.Add(Me.Label20)
        Me.Frame1.Controls.Add(Me.Label19)
        Me.Frame1.Controls.Add(Me.Label25)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(232, 420)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(232, 220)
        Me.Frame1.TabIndex = 6
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Historical Data"
        '
        'txtEndDateTime
        '
        Me.txtEndDateTime.AcceptsReturn = True
        Me.txtEndDateTime.BackColor = System.Drawing.SystemColors.Window
        Me.txtEndDateTime.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEndDateTime.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEndDateTime.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtEndDateTime.Location = New System.Drawing.Point(104, 21)
        Me.txtEndDateTime.MaxLength = 0
        Me.txtEndDateTime.Name = "txtEndDateTime"
        Me.txtEndDateTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtEndDateTime.Size = New System.Drawing.Size(120, 20)
        Me.txtEndDateTime.TabIndex = 1
        Me.txtEndDateTime.Text = "YYYYMMDD hh:mm:ss [TMZ]"
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.SystemColors.Control
        Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label24.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(13, 24)
        Me.Label24.Name = "Label24"
        Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label24.Size = New System.Drawing.Size(80, 20)
        Me.Label24.TabIndex = 0
        Me.Label24.Text = "End Date/Time"
        '
        'txtBarSizeSetting
        '
        Me.txtBarSizeSetting.AcceptsReturn = True
        Me.txtBarSizeSetting.BackColor = System.Drawing.SystemColors.Window
        Me.txtBarSizeSetting.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBarSizeSetting.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarSizeSetting.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBarSizeSetting.Location = New System.Drawing.Point(104, 81)
        Me.txtBarSizeSetting.MaxLength = 0
        Me.txtBarSizeSetting.Name = "txtBarSizeSetting"
        Me.txtBarSizeSetting.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBarSizeSetting.Size = New System.Drawing.Size(120, 20)
        Me.txtBarSizeSetting.TabIndex = 5
        Me.txtBarSizeSetting.Text = "1 day"
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.SystemColors.Control
        Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label23.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(13, 84)
        Me.Label23.Name = "Label23"
        Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label23.Size = New System.Drawing.Size(80, 20)
        Me.Label23.TabIndex = 4
        Me.Label23.Text = "Bar Size"
        '
        'txtFormatDate
        '
        Me.txtFormatDate.AcceptsReturn = True
        Me.txtFormatDate.BackColor = System.Drawing.SystemColors.Window
        Me.txtFormatDate.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFormatDate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFormatDate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFormatDate.Location = New System.Drawing.Point(104, 171)
        Me.txtFormatDate.MaxLength = 0
        Me.txtFormatDate.Name = "txtFormatDate"
        Me.txtFormatDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFormatDate.Size = New System.Drawing.Size(120, 20)
        Me.txtFormatDate.TabIndex = 11
        Me.txtFormatDate.Text = "1"
        '
        'txtUseRTH
        '
        Me.txtUseRTH.AcceptsReturn = True
        Me.txtUseRTH.BackColor = System.Drawing.SystemColors.Window
        Me.txtUseRTH.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUseRTH.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUseRTH.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtUseRTH.Location = New System.Drawing.Point(104, 141)
        Me.txtUseRTH.MaxLength = 0
        Me.txtUseRTH.Name = "txtUseRTH"
        Me.txtUseRTH.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtUseRTH.Size = New System.Drawing.Size(120, 20)
        Me.txtUseRTH.TabIndex = 9
        Me.txtUseRTH.Text = "1"
        '
        'txtWhatToShow
        '
        Me.txtWhatToShow.AcceptsReturn = True
        Me.txtWhatToShow.BackColor = System.Drawing.SystemColors.Window
        Me.txtWhatToShow.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtWhatToShow.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWhatToShow.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtWhatToShow.Location = New System.Drawing.Point(104, 111)
        Me.txtWhatToShow.MaxLength = 0
        Me.txtWhatToShow.Name = "txtWhatToShow"
        Me.txtWhatToShow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtWhatToShow.Size = New System.Drawing.Size(120, 20)
        Me.txtWhatToShow.TabIndex = 7
        Me.txtWhatToShow.Text = "TRADES"
        '
        'txtDuration
        '
        Me.txtDuration.AcceptsReturn = True
        Me.txtDuration.BackColor = System.Drawing.SystemColors.Window
        Me.txtDuration.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDuration.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDuration.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDuration.Location = New System.Drawing.Point(104, 51)
        Me.txtDuration.MaxLength = 0
        Me.txtDuration.Name = "txtDuration"
        Me.txtDuration.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDuration.Size = New System.Drawing.Size(120, 20)
        Me.txtDuration.TabIndex = 3
        Me.txtDuration.Text = "1 M"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.SystemColors.Control
        Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label21.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(13, 171)
        Me.Label21.Name = "Label21"
        Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label21.Size = New System.Drawing.Size(80, 33)
        Me.Label21.TabIndex = 10
        Me.Label21.Text = "Date Format Style (1 or 2)"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.SystemColors.Control
        Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label20.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(13, 141)
        Me.Label20.Name = "Label20"
        Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label20.Size = New System.Drawing.Size(80, 29)
        Me.Label20.TabIndex = 8
        Me.Label20.Text = "Regular Trading Hours (1 or 0)"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.SystemColors.Control
        Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(13, 114)
        Me.Label19.Name = "Label19"
        Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label19.Size = New System.Drawing.Size(80, 20)
        Me.Label19.TabIndex = 6
        Me.Label19.Text = "What To Show"
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.SystemColors.Control
        Me.Label25.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label25.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(13, 54)
        Me.Label25.Name = "Label25"
        Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label25.Size = New System.Drawing.Size(80, 20)
        Me.Label25.TabIndex = 2
        Me.Label25.Text = "Duration"
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(232, 751)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancel.TabIndex = 9
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdOk
        '
        Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOk.Location = New System.Drawing.Point(151, 751)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOk.Size = New System.Drawing.Size(73, 25)
        Me.cmdOk.TabIndex = 8
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'frameTickerDesc
        '
        Me.frameTickerDesc.BackColor = System.Drawing.SystemColors.Control
        Me.frameTickerDesc.Controls.Add(Me.txtTradingClass)
        Me.frameTickerDesc.Controls.Add(Me.Label8)
        Me.frameTickerDesc.Controls.Add(Me.txtSecId)
        Me.frameTickerDesc.Controls.Add(Me.txtSecIdType)
        Me.frameTickerDesc.Controls.Add(Me.Label7)
        Me.frameTickerDesc.Controls.Add(Me.Label6)
        Me.frameTickerDesc.Controls.Add(Me.Label3)
        Me.frameTickerDesc.Controls.Add(Me.txtConId)
        Me.frameTickerDesc.Controls.Add(Me.txtIncludeExpired)
        Me.frameTickerDesc.Controls.Add(Me.Label39)
        Me.frameTickerDesc.Controls.Add(Me.Label4)
        Me.frameTickerDesc.Controls.Add(Me.TextMultiplier)
        Me.frameTickerDesc.Controls.Add(Me.TxtPrimaryExchange)
        Me.frameTickerDesc.Controls.Add(Me.txtRight)
        Me.frameTickerDesc.Controls.Add(Me.txtLocalSymbol)
        Me.frameTickerDesc.Controls.Add(Me.txtCurrency)
        Me.frameTickerDesc.Controls.Add(Me.txtExchange)
        Me.frameTickerDesc.Controls.Add(Me.txtStrike)
        Me.frameTickerDesc.Controls.Add(Me.txtExpiry)
        Me.frameTickerDesc.Controls.Add(Me.txtSecType)
        Me.frameTickerDesc.Controls.Add(Me.txtSymbol)
        Me.frameTickerDesc.Controls.Add(Me.Label5)
        Me.frameTickerDesc.Controls.Add(Me.Label2)
        Me.frameTickerDesc.Controls.Add(Me.Label37)
        Me.frameTickerDesc.Controls.Add(Me.Label53)
        Me.frameTickerDesc.Controls.Add(Me.Label54)
        Me.frameTickerDesc.Controls.Add(Me.Label55)
        Me.frameTickerDesc.Controls.Add(Me.Label56)
        Me.frameTickerDesc.Controls.Add(Me.Label57)
        Me.frameTickerDesc.Controls.Add(Me.Label58)
        Me.frameTickerDesc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frameTickerDesc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frameTickerDesc.Location = New System.Drawing.Point(8, 48)
        Me.frameTickerDesc.Name = "frameTickerDesc"
        Me.frameTickerDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frameTickerDesc.Size = New System.Drawing.Size(216, 461)
        Me.frameTickerDesc.TabIndex = 1
        Me.frameTickerDesc.TabStop = False
        Me.frameTickerDesc.Text = "Ticker Description"
        '
        'txtTradingClass
        '
        Me.txtTradingClass.AcceptsReturn = True
        Me.txtTradingClass.BackColor = System.Drawing.SystemColors.Window
        Me.txtTradingClass.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTradingClass.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTradingClass.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTradingClass.Location = New System.Drawing.Point(120, 336)
        Me.txtTradingClass.MaxLength = 0
        Me.txtTradingClass.Name = "txtTradingClass"
        Me.txtTradingClass.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTradingClass.Size = New System.Drawing.Size(88, 20)
        Me.txtTradingClass.TabIndex = 23
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(8, 339)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(73, 17)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Trading Class"
        '
        'txtSecId
        '
        Me.txtSecId.Location = New System.Drawing.Point(120, 423)
        Me.txtSecId.Name = "txtSecId"
        Me.txtSecId.Size = New System.Drawing.Size(85, 20)
        Me.txtSecId.TabIndex = 29
        '
        'txtSecIdType
        '
        Me.txtSecIdType.Location = New System.Drawing.Point(120, 395)
        Me.txtSecIdType.Name = "txtSecIdType"
        Me.txtSecIdType.Size = New System.Drawing.Size(86, 20)
        Me.txtSecIdType.TabIndex = 27
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 425)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 14)
        Me.Label7.TabIndex = 28
        Me.Label7.Text = "Sec Id"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 397)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 14)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Sec Id Type"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(73, 17)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Contract Id"
        '
        'txtConId
        '
        Me.txtConId.AcceptsReturn = True
        Me.txtConId.BackColor = System.Drawing.SystemColors.Window
        Me.txtConId.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtConId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtConId.Location = New System.Drawing.Point(120, 19)
        Me.txtConId.MaxLength = 0
        Me.txtConId.Name = "txtConId"
        Me.txtConId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtConId.Size = New System.Drawing.Size(88, 20)
        Me.txtConId.TabIndex = 1
        Me.txtConId.Text = "0"
        '
        'txtIncludeExpired
        '
        Me.txtIncludeExpired.AcceptsReturn = True
        Me.txtIncludeExpired.BackColor = System.Drawing.SystemColors.Window
        Me.txtIncludeExpired.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtIncludeExpired.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIncludeExpired.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtIncludeExpired.Location = New System.Drawing.Point(120, 366)
        Me.txtIncludeExpired.MaxLength = 0
        Me.txtIncludeExpired.Name = "txtIncludeExpired"
        Me.txtIncludeExpired.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtIncludeExpired.Size = New System.Drawing.Size(88, 20)
        Me.txtIncludeExpired.TabIndex = 25
        Me.txtIncludeExpired.Text = "0"
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.SystemColors.Control
        Me.Label39.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label39.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label39.Location = New System.Drawing.Point(7, 371)
        Me.Label39.Name = "Label39"
        Me.Label39.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label39.Size = New System.Drawing.Size(88, 17)
        Me.Label39.TabIndex = 24
        Me.Label39.Text = "Include Expired"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(8, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(73, 17)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Expiry"
        '
        'TextMultiplier
        '
        Me.TextMultiplier.AcceptsReturn = True
        Me.TextMultiplier.BackColor = System.Drawing.SystemColors.Window
        Me.TextMultiplier.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextMultiplier.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextMultiplier.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TextMultiplier.Location = New System.Drawing.Point(120, 191)
        Me.TextMultiplier.MaxLength = 0
        Me.TextMultiplier.Name = "TextMultiplier"
        Me.TextMultiplier.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextMultiplier.Size = New System.Drawing.Size(88, 20)
        Me.TextMultiplier.TabIndex = 13
        '
        'TxtPrimaryExchange
        '
        Me.TxtPrimaryExchange.AcceptsReturn = True
        Me.TxtPrimaryExchange.BackColor = System.Drawing.SystemColors.Window
        Me.TxtPrimaryExchange.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtPrimaryExchange.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrimaryExchange.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtPrimaryExchange.Location = New System.Drawing.Point(120, 249)
        Me.TxtPrimaryExchange.MaxLength = 0
        Me.TxtPrimaryExchange.Name = "TxtPrimaryExchange"
        Me.TxtPrimaryExchange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtPrimaryExchange.Size = New System.Drawing.Size(88, 20)
        Me.TxtPrimaryExchange.TabIndex = 17
        Me.TxtPrimaryExchange.Text = "ISLAND"
        '
        'txtRight
        '
        Me.txtRight.AcceptsReturn = True
        Me.txtRight.BackColor = System.Drawing.SystemColors.Window
        Me.txtRight.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRight.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRight.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRight.Location = New System.Drawing.Point(120, 163)
        Me.txtRight.MaxLength = 0
        Me.txtRight.Name = "txtRight"
        Me.txtRight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRight.Size = New System.Drawing.Size(88, 20)
        Me.txtRight.TabIndex = 11
        '
        'txtLocalSymbol
        '
        Me.txtLocalSymbol.AcceptsReturn = True
        Me.txtLocalSymbol.BackColor = System.Drawing.SystemColors.Window
        Me.txtLocalSymbol.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLocalSymbol.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocalSymbol.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLocalSymbol.Location = New System.Drawing.Point(120, 306)
        Me.txtLocalSymbol.MaxLength = 0
        Me.txtLocalSymbol.Name = "txtLocalSymbol"
        Me.txtLocalSymbol.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLocalSymbol.Size = New System.Drawing.Size(88, 20)
        Me.txtLocalSymbol.TabIndex = 21
        '
        'txtCurrency
        '
        Me.txtCurrency.AcceptsReturn = True
        Me.txtCurrency.BackColor = System.Drawing.SystemColors.Window
        Me.txtCurrency.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCurrency.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrency.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCurrency.Location = New System.Drawing.Point(120, 277)
        Me.txtCurrency.MaxLength = 0
        Me.txtCurrency.Name = "txtCurrency"
        Me.txtCurrency.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCurrency.Size = New System.Drawing.Size(88, 20)
        Me.txtCurrency.TabIndex = 19
        Me.txtCurrency.Text = "USD"
        '
        'txtExchange
        '
        Me.txtExchange.AcceptsReturn = True
        Me.txtExchange.BackColor = System.Drawing.SystemColors.Window
        Me.txtExchange.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtExchange.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExchange.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtExchange.Location = New System.Drawing.Point(120, 220)
        Me.txtExchange.MaxLength = 0
        Me.txtExchange.Name = "txtExchange"
        Me.txtExchange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtExchange.Size = New System.Drawing.Size(88, 20)
        Me.txtExchange.TabIndex = 15
        Me.txtExchange.Text = "SMART"
        '
        'txtStrike
        '
        Me.txtStrike.AcceptsReturn = True
        Me.txtStrike.BackColor = System.Drawing.SystemColors.Window
        Me.txtStrike.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStrike.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStrike.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStrike.Location = New System.Drawing.Point(120, 134)
        Me.txtStrike.MaxLength = 0
        Me.txtStrike.Name = "txtStrike"
        Me.txtStrike.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStrike.Size = New System.Drawing.Size(88, 20)
        Me.txtStrike.TabIndex = 9
        Me.txtStrike.Text = "0"
        '
        'txtExpiry
        '
        Me.txtExpiry.AcceptsReturn = True
        Me.txtExpiry.BackColor = System.Drawing.SystemColors.Window
        Me.txtExpiry.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtExpiry.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExpiry.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtExpiry.Location = New System.Drawing.Point(120, 104)
        Me.txtExpiry.MaxLength = 0
        Me.txtExpiry.Name = "txtExpiry"
        Me.txtExpiry.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtExpiry.Size = New System.Drawing.Size(88, 20)
        Me.txtExpiry.TabIndex = 7
        '
        'txtSecType
        '
        Me.txtSecType.AcceptsReturn = True
        Me.txtSecType.BackColor = System.Drawing.SystemColors.Window
        Me.txtSecType.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSecType.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSecType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSecType.Location = New System.Drawing.Point(120, 76)
        Me.txtSecType.MaxLength = 0
        Me.txtSecType.Name = "txtSecType"
        Me.txtSecType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSecType.Size = New System.Drawing.Size(88, 20)
        Me.txtSecType.TabIndex = 5
        Me.txtSecType.Text = "STK"
        '
        'txtSymbol
        '
        Me.txtSymbol.AcceptsReturn = True
        Me.txtSymbol.BackColor = System.Drawing.SystemColors.Window
        Me.txtSymbol.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSymbol.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSymbol.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSymbol.Location = New System.Drawing.Point(120, 47)
        Me.txtSymbol.MaxLength = 0
        Me.txtSymbol.Name = "txtSymbol"
        Me.txtSymbol.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSymbol.Size = New System.Drawing.Size(88, 20)
        Me.txtSymbol.TabIndex = 3
        Me.txtSymbol.Text = "QQQQ"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(7, 138)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(73, 17)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Strike"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(7, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(73, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Symbol"
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.SystemColors.Control
        Me.Label37.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label37.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label37.Location = New System.Drawing.Point(7, 79)
        Me.Label37.Name = "Label37"
        Me.Label37.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label37.Size = New System.Drawing.Size(73, 17)
        Me.Label37.TabIndex = 4
        Me.Label37.Text = "Type"
        '
        'Label53
        '
        Me.Label53.BackColor = System.Drawing.SystemColors.Control
        Me.Label53.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label53.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label53.Location = New System.Drawing.Point(8, 196)
        Me.Label53.Name = "Label53"
        Me.Label53.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label53.Size = New System.Drawing.Size(73, 17)
        Me.Label53.TabIndex = 12
        Me.Label53.Text = "Multiplier"
        '
        'Label54
        '
        Me.Label54.BackColor = System.Drawing.SystemColors.Control
        Me.Label54.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label54.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label54.Location = New System.Drawing.Point(7, 254)
        Me.Label54.Name = "Label54"
        Me.Label54.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label54.Size = New System.Drawing.Size(97, 17)
        Me.Label54.TabIndex = 16
        Me.Label54.Text = "Primary Exchange"
        '
        'Label55
        '
        Me.Label55.BackColor = System.Drawing.SystemColors.Control
        Me.Label55.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label55.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label55.Location = New System.Drawing.Point(8, 167)
        Me.Label55.Name = "Label55"
        Me.Label55.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label55.Size = New System.Drawing.Size(73, 17)
        Me.Label55.TabIndex = 10
        Me.Label55.Text = "Right"
        '
        'Label56
        '
        Me.Label56.BackColor = System.Drawing.SystemColors.Control
        Me.Label56.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label56.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label56.Location = New System.Drawing.Point(8, 311)
        Me.Label56.Name = "Label56"
        Me.Label56.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label56.Size = New System.Drawing.Size(73, 17)
        Me.Label56.TabIndex = 20
        Me.Label56.Text = "Local Symbol"
        '
        'Label57
        '
        Me.Label57.BackColor = System.Drawing.SystemColors.Control
        Me.Label57.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label57.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label57.Location = New System.Drawing.Point(8, 282)
        Me.Label57.Name = "Label57"
        Me.Label57.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label57.Size = New System.Drawing.Size(73, 17)
        Me.Label57.TabIndex = 18
        Me.Label57.Text = "Currency"
        '
        'Label58
        '
        Me.Label58.BackColor = System.Drawing.SystemColors.Control
        Me.Label58.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label58.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label58.Location = New System.Drawing.Point(8, 224)
        Me.Label58.Name = "Label58"
        Me.Label58.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label58.Size = New System.Drawing.Size(73, 17)
        Me.Label58.TabIndex = 14
        Me.Label58.Text = "Exchange"
        '
        'txtReqId
        '
        Me.txtReqId.AcceptsReturn = True
        Me.txtReqId.BackColor = System.Drawing.SystemColors.Window
        Me.txtReqId.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtReqId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReqId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtReqId.Location = New System.Drawing.Point(80, 16)
        Me.txtReqId.MaxLength = 0
        Me.txtReqId.Name = "txtReqId"
        Me.txtReqId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtReqId.Size = New System.Drawing.Size(105, 20)
        Me.txtReqId.TabIndex = 1
        Me.txtReqId.Text = "0"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.chkSnapshotMktData)
        Me.GroupBox1.Controls.Add(Me.txtGenericTickTags)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(8, 576)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox1.Size = New System.Drawing.Size(216, 64)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Market Data"
        '
        'chkSnapshotMktData
        '
        Me.chkSnapshotMktData.AutoSize = True
        Me.chkSnapshotMktData.Location = New System.Drawing.Point(11, 41)
        Me.chkSnapshotMktData.Name = "chkSnapshotMktData"
        Me.chkSnapshotMktData.Size = New System.Drawing.Size(72, 18)
        Me.chkSnapshotMktData.TabIndex = 2
        Me.chkSnapshotMktData.Text = "Snapshot"
        Me.chkSnapshotMktData.UseVisualStyleBackColor = True
        '
        'txtGenericTickTags
        '
        Me.txtGenericTickTags.AcceptsReturn = True
        Me.txtGenericTickTags.BackColor = System.Drawing.SystemColors.Window
        Me.txtGenericTickTags.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGenericTickTags.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGenericTickTags.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtGenericTickTags.Location = New System.Drawing.Point(120, 19)
        Me.txtGenericTickTags.MaxLength = 0
        Me.txtGenericTickTags.Name = "txtGenericTickTags"
        Me.txtGenericTickTags.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtGenericTickTags.Size = New System.Drawing.Size(88, 20)
        Me.txtGenericTickTags.TabIndex = 1
        Me.txtGenericTickTags.Text = "100,101,104,105,106,107,165,221,225,233,236,258,293,294,295,318"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.SystemColors.Control
        Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label22.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(8, 22)
        Me.Label22.Name = "Label22"
        Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label22.Size = New System.Drawing.Size(96, 16)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "Generic Tick Tags"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Controls.Add(Me.txtExerciseOverride)
        Me.GroupBox2.Controls.Add(Me.Label36)
        Me.GroupBox2.Controls.Add(Me.txtExerciseQuantity)
        Me.GroupBox2.Controls.Add(Me.Label35)
        Me.GroupBox2.Controls.Add(Me.txtExerciseAction)
        Me.GroupBox2.Controls.Add(Me.Label30)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox2.Location = New System.Drawing.Point(8, 646)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox2.Size = New System.Drawing.Size(216, 100)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Options Exercise"
        '
        'txtExerciseOverride
        '
        Me.txtExerciseOverride.AcceptsReturn = True
        Me.txtExerciseOverride.BackColor = System.Drawing.SystemColors.Window
        Me.txtExerciseOverride.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtExerciseOverride.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExerciseOverride.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtExerciseOverride.Location = New System.Drawing.Point(120, 71)
        Me.txtExerciseOverride.MaxLength = 0
        Me.txtExerciseOverride.Name = "txtExerciseOverride"
        Me.txtExerciseOverride.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtExerciseOverride.Size = New System.Drawing.Size(88, 20)
        Me.txtExerciseOverride.TabIndex = 5
        Me.txtExerciseOverride.Text = "0"
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.SystemColors.Control
        Me.Label36.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label36.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label36.Location = New System.Drawing.Point(8, 72)
        Me.Label36.Name = "Label36"
        Me.Label36.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label36.Size = New System.Drawing.Size(88, 16)
        Me.Label36.TabIndex = 4
        Me.Label36.Text = "Override (0 or 1)"
        '
        'txtExerciseQuantity
        '
        Me.txtExerciseQuantity.AcceptsReturn = True
        Me.txtExerciseQuantity.BackColor = System.Drawing.SystemColors.Window
        Me.txtExerciseQuantity.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtExerciseQuantity.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExerciseQuantity.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtExerciseQuantity.Location = New System.Drawing.Point(120, 45)
        Me.txtExerciseQuantity.MaxLength = 0
        Me.txtExerciseQuantity.Name = "txtExerciseQuantity"
        Me.txtExerciseQuantity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtExerciseQuantity.Size = New System.Drawing.Size(88, 20)
        Me.txtExerciseQuantity.TabIndex = 3
        Me.txtExerciseQuantity.Text = "1"
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.SystemColors.Control
        Me.Label35.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label35.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label35.Location = New System.Drawing.Point(8, 48)
        Me.Label35.Name = "Label35"
        Me.Label35.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label35.Size = New System.Drawing.Size(108, 24)
        Me.Label35.TabIndex = 2
        Me.Label35.Text = "Number of Contracts"
        '
        'txtExerciseAction
        '
        Me.txtExerciseAction.AcceptsReturn = True
        Me.txtExerciseAction.BackColor = System.Drawing.SystemColors.Window
        Me.txtExerciseAction.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtExerciseAction.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExerciseAction.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtExerciseAction.Location = New System.Drawing.Point(120, 19)
        Me.txtExerciseAction.MaxLength = 0
        Me.txtExerciseAction.Name = "txtExerciseAction"
        Me.txtExerciseAction.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtExerciseAction.Size = New System.Drawing.Size(88, 20)
        Me.txtExerciseAction.TabIndex = 1
        Me.txtExerciseAction.Text = "1"
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.SystemColors.Control
        Me.Label30.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label30.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.Location = New System.Drawing.Point(7, 22)
        Me.Label30.Name = "Label30"
        Me.Label30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label30.Size = New System.Drawing.Size(88, 16)
        Me.Label30.TabIndex = 0
        Me.Label30.Text = "Action (1 or 2)"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox3.Controls.Add(Me.Label38)
        Me.GroupBox3.Controls.Add(Me.txtReqId)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox3.Location = New System.Drawing.Point(8, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox3.Size = New System.Drawing.Size(456, 41)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.SystemColors.Control
        Me.Label38.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label38.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label38.Location = New System.Drawing.Point(16, 16)
        Me.Label38.Name = "Label38"
        Me.Label38.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label38.Size = New System.Drawing.Size(57, 17)
        Me.Label38.TabIndex = 0
        Me.Label38.Text = "Ticker ID"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox4.Controls.Add(Me.txtNumRows)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox4.Location = New System.Drawing.Point(8, 515)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox4.Size = New System.Drawing.Size(216, 55)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Market Depth"
        '
        'txtNumRows
        '
        Me.txtNumRows.AcceptsReturn = True
        Me.txtNumRows.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumRows.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumRows.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumRows.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtNumRows.Location = New System.Drawing.Point(120, 19)
        Me.txtNumRows.MaxLength = 0
        Me.txtNumRows.Name = "txtNumRows"
        Me.txtNumRows.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNumRows.Size = New System.Drawing.Size(88, 20)
        Me.txtNumRows.TabIndex = 1
        Me.txtNumRows.Text = "20"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(96, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Max Market Depth Rows"
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.SystemColors.Control
        Me.Label27.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label27.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label27.Location = New System.Drawing.Point(13, 82)
        Me.Label27.Name = "Label27"
        Me.Label27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label27.Size = New System.Drawing.Size(89, 20)
        Me.Label27.TabIndex = 4
        Me.Label27.Text = "Order Type"
        '
        'cmdSetShareAllocation
        '
        Me.cmdSetShareAllocation.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSetShareAllocation.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSetShareAllocation.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSetShareAllocation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSetShareAllocation.Location = New System.Drawing.Point(17, 228)
        Me.cmdSetShareAllocation.Name = "cmdSetShareAllocation"
        Me.cmdSetShareAllocation.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSetShareAllocation.Size = New System.Drawing.Size(99, 25)
        Me.cmdSetShareAllocation.TabIndex = 14
        Me.cmdSetShareAllocation.Text = "FA Alloc"
        Me.cmdSetShareAllocation.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(13, 27)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(89, 20)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Action"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(13, 54)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(89, 20)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Quantity"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(13, 103)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(89, 30)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "Lmt/Opt Price / Volatility"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.Control
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(13, 138)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(89, 20)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "Aux/Under Price"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.Control
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(13, 195)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(89, 20)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "Good Till Date"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.Control
        Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(13, 167)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label16.Size = New System.Drawing.Size(89, 20)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "Good After Time"
        '
        'txtAction
        '
        Me.txtAction.AcceptsReturn = True
        Me.txtAction.BackColor = System.Drawing.SystemColors.Window
        Me.txtAction.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAction.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAction.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAction.Location = New System.Drawing.Point(112, 24)
        Me.txtAction.MaxLength = 0
        Me.txtAction.Name = "txtAction"
        Me.txtAction.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAction.Size = New System.Drawing.Size(112, 20)
        Me.txtAction.TabIndex = 1
        Me.txtAction.Text = "BUY"
        '
        'txtQuantity
        '
        Me.txtQuantity.AcceptsReturn = True
        Me.txtQuantity.BackColor = System.Drawing.SystemColors.Window
        Me.txtQuantity.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtQuantity.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuantity.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtQuantity.Location = New System.Drawing.Point(112, 51)
        Me.txtQuantity.MaxLength = 0
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtQuantity.Size = New System.Drawing.Size(112, 20)
        Me.txtQuantity.TabIndex = 3
        Me.txtQuantity.Text = "10"
        '
        'txtOrderType
        '
        Me.txtOrderType.AcceptsReturn = True
        Me.txtOrderType.BackColor = System.Drawing.SystemColors.Window
        Me.txtOrderType.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOrderType.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrderType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOrderType.Location = New System.Drawing.Point(112, 79)
        Me.txtOrderType.MaxLength = 0
        Me.txtOrderType.Name = "txtOrderType"
        Me.txtOrderType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtOrderType.Size = New System.Drawing.Size(112, 20)
        Me.txtOrderType.TabIndex = 5
        Me.txtOrderType.Text = "LMT"
        '
        'txtLmtPrice
        '
        Me.txtLmtPrice.AcceptsReturn = True
        Me.txtLmtPrice.BackColor = System.Drawing.SystemColors.Window
        Me.txtLmtPrice.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLmtPrice.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLmtPrice.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLmtPrice.Location = New System.Drawing.Point(112, 107)
        Me.txtLmtPrice.MaxLength = 0
        Me.txtLmtPrice.Name = "txtLmtPrice"
        Me.txtLmtPrice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLmtPrice.Size = New System.Drawing.Size(112, 20)
        Me.txtLmtPrice.TabIndex = 7
        Me.txtLmtPrice.Text = "40"
        '
        'txtAuxPrice
        '
        Me.txtAuxPrice.AcceptsReturn = True
        Me.txtAuxPrice.BackColor = System.Drawing.SystemColors.Window
        Me.txtAuxPrice.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAuxPrice.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAuxPrice.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAuxPrice.Location = New System.Drawing.Point(112, 135)
        Me.txtAuxPrice.MaxLength = 0
        Me.txtAuxPrice.Name = "txtAuxPrice"
        Me.txtAuxPrice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAuxPrice.Size = New System.Drawing.Size(112, 20)
        Me.txtAuxPrice.TabIndex = 9
        Me.txtAuxPrice.Text = "0"
        '
        'cmdAddCmboLegs
        '
        Me.cmdAddCmboLegs.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAddCmboLegs.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAddCmboLegs.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddCmboLegs.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAddCmboLegs.Location = New System.Drawing.Point(122, 228)
        Me.cmdAddCmboLegs.Name = "cmdAddCmboLegs"
        Me.cmdAddCmboLegs.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAddCmboLegs.Size = New System.Drawing.Size(99, 25)
        Me.cmdAddCmboLegs.TabIndex = 15
        Me.cmdAddCmboLegs.Text = "Combo Legs"
        Me.cmdAddCmboLegs.UseVisualStyleBackColor = False
        '
        'tGTD
        '
        Me.tGTD.AcceptsReturn = True
        Me.tGTD.BackColor = System.Drawing.SystemColors.Window
        Me.tGTD.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tGTD.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tGTD.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tGTD.Location = New System.Drawing.Point(112, 192)
        Me.tGTD.MaxLength = 0
        Me.tGTD.Name = "tGTD"
        Me.tGTD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tGTD.Size = New System.Drawing.Size(112, 20)
        Me.tGTD.TabIndex = 13
        '
        'tGAT
        '
        Me.tGAT.AcceptsReturn = True
        Me.tGAT.BackColor = System.Drawing.SystemColors.Window
        Me.tGAT.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tGAT.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tGAT.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tGAT.Location = New System.Drawing.Point(112, 164)
        Me.tGAT.MaxLength = 0
        Me.tGAT.Name = "tGAT"
        Me.tGAT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tGAT.Size = New System.Drawing.Size(112, 20)
        Me.tGAT.TabIndex = 11
        '
        'cmdUnderComp
        '
        Me.cmdUnderComp.BackColor = System.Drawing.SystemColors.Control
        Me.cmdUnderComp.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdUnderComp.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUnderComp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdUnderComp.Location = New System.Drawing.Point(17, 264)
        Me.cmdUnderComp.Name = "cmdUnderComp"
        Me.cmdUnderComp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdUnderComp.Size = New System.Drawing.Size(99, 25)
        Me.cmdUnderComp.TabIndex = 16
        Me.cmdUnderComp.Text = "Delta Neutral"
        Me.cmdUnderComp.UseVisualStyleBackColor = False
        '
        'cmdAlgoParams
        '
        Me.cmdAlgoParams.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAlgoParams.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAlgoParams.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAlgoParams.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAlgoParams.Location = New System.Drawing.Point(122, 264)
        Me.cmdAlgoParams.Name = "cmdAlgoParams"
        Me.cmdAlgoParams.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAlgoParams.Size = New System.Drawing.Size(99, 25)
        Me.cmdAlgoParams.TabIndex = 17
        Me.cmdAlgoParams.Text = "Algo Params"
        Me.cmdAlgoParams.UseVisualStyleBackColor = False
        '
        'frameOrderDesc
        '
        Me.frameOrderDesc.BackColor = System.Drawing.SystemColors.Control
        Me.frameOrderDesc.Controls.Add(Me.cmdOptions)
        Me.frameOrderDesc.Controls.Add(Me.cmdSmartComboRoutingParams)
        Me.frameOrderDesc.Controls.Add(Me.cmdAlgoParams)
        Me.frameOrderDesc.Controls.Add(Me.cmdUnderComp)
        Me.frameOrderDesc.Controls.Add(Me.tGAT)
        Me.frameOrderDesc.Controls.Add(Me.tGTD)
        Me.frameOrderDesc.Controls.Add(Me.cmdAddCmboLegs)
        Me.frameOrderDesc.Controls.Add(Me.txtAuxPrice)
        Me.frameOrderDesc.Controls.Add(Me.txtLmtPrice)
        Me.frameOrderDesc.Controls.Add(Me.txtOrderType)
        Me.frameOrderDesc.Controls.Add(Me.txtQuantity)
        Me.frameOrderDesc.Controls.Add(Me.txtAction)
        Me.frameOrderDesc.Controls.Add(Me.Label16)
        Me.frameOrderDesc.Controls.Add(Me.Label15)
        Me.frameOrderDesc.Controls.Add(Me.Label14)
        Me.frameOrderDesc.Controls.Add(Me.Label13)
        Me.frameOrderDesc.Controls.Add(Me.Label11)
        Me.frameOrderDesc.Controls.Add(Me.Label10)
        Me.frameOrderDesc.Controls.Add(Me.cmdSetShareAllocation)
        Me.frameOrderDesc.Controls.Add(Me.Label27)
        Me.frameOrderDesc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frameOrderDesc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frameOrderDesc.Location = New System.Drawing.Point(232, 48)
        Me.frameOrderDesc.Name = "frameOrderDesc"
        Me.frameOrderDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frameOrderDesc.Size = New System.Drawing.Size(232, 366)
        Me.frameOrderDesc.TabIndex = 5
        Me.frameOrderDesc.TabStop = False
        Me.frameOrderDesc.Text = "Order Description"
        '
        'cmdOptions
        '
        Me.cmdOptions.Enabled = False
        Me.cmdOptions.Location = New System.Drawing.Point(122, 301)
        Me.cmdOptions.Name = "cmdOptions"
        Me.cmdOptions.Size = New System.Drawing.Size(99, 25)
        Me.cmdOptions.TabIndex = 19
        Me.cmdOptions.Text = "Options"
        Me.cmdOptions.UseVisualStyleBackColor = True
        '
        'cmdSmartComboRoutingParams
        '
        Me.cmdSmartComboRoutingParams.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSmartComboRoutingParams.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSmartComboRoutingParams.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSmartComboRoutingParams.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSmartComboRoutingParams.Location = New System.Drawing.Point(17, 301)
        Me.cmdSmartComboRoutingParams.Name = "cmdSmartComboRoutingParams"
        Me.cmdSmartComboRoutingParams.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSmartComboRoutingParams.Size = New System.Drawing.Size(99, 25)
        Me.cmdSmartComboRoutingParams.TabIndex = 18
        Me.cmdSmartComboRoutingParams.Text = "Cmb Rou Params"
        Me.cmdSmartComboRoutingParams.UseVisualStyleBackColor = False
        '
        'labelMarketDataType
        '
        Me.labelMarketDataType.BackColor = System.Drawing.SystemColors.Control
        Me.labelMarketDataType.Cursor = System.Windows.Forms.Cursors.Default
        Me.labelMarketDataType.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelMarketDataType.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labelMarketDataType.Location = New System.Drawing.Point(8, 22)
        Me.labelMarketDataType.Name = "labelMarketDataType"
        Me.labelMarketDataType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.labelMarketDataType.Size = New System.Drawing.Size(96, 17)
        Me.labelMarketDataType.TabIndex = 0
        Me.labelMarketDataType.Text = "Market Data Type"
        '
        'frameMarketDataType
        '
        Me.frameMarketDataType.BackColor = System.Drawing.SystemColors.Control
        Me.frameMarketDataType.Controls.Add(Me.cmbMarketDataType)
        Me.frameMarketDataType.Controls.Add(Me.labelMarketDataType)
        Me.frameMarketDataType.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frameMarketDataType.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frameMarketDataType.Location = New System.Drawing.Point(234, 649)
        Me.frameMarketDataType.Name = "frameMarketDataType"
        Me.frameMarketDataType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frameMarketDataType.Size = New System.Drawing.Size(228, 52)
        Me.frameMarketDataType.TabIndex = 7
        Me.frameMarketDataType.TabStop = False
        Me.frameMarketDataType.Text = "Market Data Type"
        '
        'cmbMarketDataType
        '
        Me.cmbMarketDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMarketDataType.FormattingEnabled = True
        Me.cmbMarketDataType.Location = New System.Drawing.Point(104, 21)
        Me.cmbMarketDataType.Name = "cmbMarketDataType"
        Me.cmbMarketDataType.Size = New System.Drawing.Size(120, 22)
        Me.cmbMarketDataType.TabIndex = 1
        '
        'dlgOrder
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(474, 782)
        Me.Controls.Add(Me.frameMarketDataType)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.frameOrderDesc)
        Me.Controls.Add(Me.frameTickerDesc)
        Me.Controls.Add(Me.GroupBox3)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(-66, 115)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgOrder"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Request Market Data"
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.frameTickerDesc.ResumeLayout(False)
        Me.frameTickerDesc.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.frameOrderDesc.ResumeLayout(False)
        Me.frameOrderDesc.PerformLayout()
        Me.frameMarketDataType.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region
#Region "Upgrade Support "
    Private Shared m_vb6FormDefInstance As dlgOrder
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As dlgOrder
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New dlgOrder()
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal value As dlgOrder)
            m_vb6FormDefInstance = value
        End Set
    End Property
#End Region
    ' Enums
    Public Enum Dlg_Type
        REQ_MKT_DATA_DLG = 1
        CANCEL_MKT_DATA_DLG
        REQ_MKT_DEPTH_DLG
        CANCEL_MKT_DEPTH_DLG
        PLACE_ORDER_DLG
        CANCEL_ORDER_DLG
        REQ_CONTRACT_DETAILS_DLG
        REQ_HISTORICAL_DATA
        EXERCISE_OPTIONS
        CANCEL_HIST_DATA_DLG
        REQ_REAL_TIME_BARS_DLG
        CANCEL_REAL_TIME_BARS_DLG
        CALCULATE_IMPLIED_VOLATILITY
        CALCULATE_OPTION_PRICE
        CANCEL_CALCULATE_IMPLIED_VOLATILITY
        CANCEL_CALCULATE_OPTION_PRICE
        REQ_MARKET_DATA_TYPE
        REQ_FUNDAMENTAL_DATA
        CANCEL_FUNDAMENTAL_DATA
    End Enum

    Public Enum MARKET_DATA_TYPE
        REALTIME = 1
        FROZEN = 2
    End Enum


    ' ========================================================
    ' Member variables
    ' ========================================================
    Private m_mainWnd As dlgMainWnd
    Private m_arrDlgTitles As New Collection

    Private m_orderId As Integer

    Private m_contractInfo As IBApi.Contract
    Private m_orderInfo As IBApi.Order
    Private m_underComp As IBApi.UnderComp

    Private m_faMethod, m_faGroup, m_faPercentage As Object
    Private m_faProfile As String

    Private m_genericTickTags As String
    Private m_snapshotMktData As Boolean

    Private m_numRows As Integer

    Private m_exerciseAction As Integer
    Private m_exerciseQuantity As Integer
    Private m_exerciseOverride As Integer

    Private m_barSizeSetting As String
    Private m_duration As String
    Private m_endDateTime As String
    Private m_useRTH As Integer
    Private m_whatToShow As String
    Private m_formatDate As Integer

    Private m_marketDataType As Integer
    Private m_optionsDlgTitle As String
    Private m_options As List(Of IBApi.TagValue)

    Private m_ok As Boolean

    ' ========================================================
    ' Get/Set Methods
    ' ========================================================
    Public ReadOnly Property options() As List(Of IBApi.TagValue)
        Get
            options = m_options
        End Get
    End Property

    Public Property histBarSizeSetting() As String
        Get
            histBarSizeSetting = m_barSizeSetting
        End Get
        Set(ByVal Value As String)
            m_barSizeSetting = Value
            txtBarSizeSetting.Text = m_barSizeSetting
        End Set
    End Property
    Public Property genericTickTags() As String
        Get
            genericTickTags = m_genericTickTags
        End Get
        Set(ByVal Value As String)
            m_genericTickTags = Value
            txtGenericTickTags.Text = m_genericTickTags
        End Set
    End Property
    Public Property histEndDateTime() As String
        Get
            histEndDateTime = m_endDateTime
        End Get
        Set(ByVal Value As String)
            m_endDateTime = Value
            txtEndDateTime.Text = m_endDateTime
        End Set
    End Property
    Public Property histDuration() As String
        Get
            histDuration = m_duration
        End Get
        Set(ByVal Value As String)
            m_duration = Value
            txtDuration.Text = m_duration
        End Set
    End Property
    Public Property formatDate() As Integer
        Get
            formatDate = m_formatDate
        End Get
        Set(ByVal Value As Integer)
            m_formatDate = Value
            txtFormatDate.Text = m_formatDate
        End Set
    End Property
    Public Property whatToShow() As String
        Get
            whatToShow = m_whatToShow
        End Get
        Set(ByVal Value As String)
            m_whatToShow = Value
            txtWhatToShow.Text = m_whatToShow
        End Set
    End Property
    Public Property useRTH() As Integer
        Get
            useRTH = m_useRTH
        End Get
        Set(ByVal Value As Integer)
            m_useRTH = Value
            txtUseRTH.Text = CStr(m_useRTH)
        End Set
    End Property
    Public Property orderId() As Integer
        Get
            orderId = m_orderId
        End Get
        Set(ByVal Value As Integer)
            m_orderId = Value
            txtReqId.Text = CStr(m_orderId)
        End Set
    End Property
    Public Property exerciseAction() As Integer
        Get
            exerciseAction = m_exerciseAction
        End Get
        Set(ByVal Value As Integer)
            m_exerciseAction = Value
            txtExerciseAction.Text = CStr(m_exerciseAction)
        End Set
    End Property
    Public Property exerciseQuantity() As Integer
        Get
            exerciseQuantity = m_exerciseQuantity
        End Get
        Set(ByVal Value As Integer)
            m_exerciseQuantity = Value
            txtExerciseQuantity.Text = CStr(m_exerciseQuantity)
        End Set
    End Property
    Public Property exerciseOverride() As Integer
        Get
            exerciseOverride = m_exerciseOverride
        End Get
        Set(ByVal Value As Integer)
            m_exerciseOverride = Value
            txtExerciseOverride.Text = CStr(m_exerciseOverride)
        End Set
    End Property
    Public Property numRows() As Integer
        Get
            numRows = m_numRows
        End Get
        Set(ByVal Value As Integer)
            m_numRows = Value
            txtNumRows.Text = CStr(m_numRows)
        End Set
    End Property

    Public ReadOnly Property snapshotMktData() As Boolean
        Get
            snapshotMktData = m_snapshotMktData
        End Get
    End Property
    Public ReadOnly Property marketDataType() As Integer
        Get
            marketDataType = m_marketDataType
        End Get
    End Property
    Public ReadOnly Property ok() As Boolean
        Get
            ok = m_ok
        End Get
    End Property

    ' ========================================================
    ' Button Events
    ' ========================================================
    Private Sub cmdAddCmboLegs_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAddCmboLegs.Click
        Dim dlgComboLegs As New dlgComboOrderLegs

        dlgComboLegs.Init(m_contractInfo.ComboLegs, m_orderInfo.OrderComboLegs, m_mainWnd.Tws1)
        dlgComboLegs.ShowDialog()
        If dlgComboLegs.ok Then
            Dim comboLegs As List(Of IBApi.ComboLeg)
            comboLegs = dlgComboLegs.comboLegs
            m_contractInfo.ComboLegs = comboLegs
            Dim orderComboLegs As List(Of IBApi.OrderComboLeg)
            orderComboLegs = dlgComboLegs.orderComboLegs
            m_orderInfo.OrderComboLegs = orderComboLegs
        End If
    End Sub

    Private Sub cmdAlgoParams_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAlgoParams.Click
        'Dim dlg As New dlgAlgoParams

        'dlg.init(m_orderInfo.AlgoStrategy, m_orderInfo.AlgoParams, m_mainWnd.Tws1)
        'Dim res As DialogResult
        'res = dlg.ShowDialog()
        'If res = Windows.Forms.DialogResult.OK Then
        '    m_orderInfo.AlgoStrategy = dlg.algoStrategy
        '    m_orderInfo.AlgoParams = dlg.algoParams
        'End If
    End Sub

    Private Sub cmdSetShareAllocation_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSetShareAllocation.Click
        Dim dlg As New dlgSharesAlloc

        With dlg
            .init((m_mainWnd.FAManagedAccounts))
            .ShowDialog()
            If .ok Then
                m_faGroup = .faGroup
                m_faMethod = .faMethod
                m_faPercentage = .faPercentage
                m_faProfile = .faProfile
            End If
        End With
    End Sub

    Private Sub cmdUnderComp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUnderComp.Click
        Dim dlg As New dlgUnderComp

        With dlg
            .init(m_underComp)
            Dim res As DialogResult
            res = .ShowDialog()
            Select Case res
                Case Windows.Forms.DialogResult.OK : m_contractInfo.UnderComp = m_underComp
                Case Windows.Forms.DialogResult.Abort : m_contractInfo.UnderComp = Nothing
            End Select
        End With
    End Sub

    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
        ' Move UI data into member fields
        m_orderId = CInt(txtReqId.Text)

        m_contractInfo.ConId = CInt(txtConId.Text)
        m_contractInfo.Symbol = txtSymbol.Text
        m_contractInfo.SecType = txtSecType.Text
        m_contractInfo.Expiry = txtExpiry.Text
        m_contractInfo.Strike = CDbl(txtStrike.Text)
        m_contractInfo.Right = txtRight.Text
        m_contractInfo.Multiplier = TextMultiplier.Text
        m_contractInfo.Exchange = txtExchange.Text
        m_contractInfo.PrimaryExch = TxtPrimaryExchange.Text
        m_contractInfo.Currency = txtCurrency.Text
        m_contractInfo.LocalSymbol = txtLocalSymbol.Text
        m_contractInfo.TradingClass = txtTradingClass.Text
        m_contractInfo.IncludeExpired = CBool(txtIncludeExpired.Text)
        m_contractInfo.SecIdType = txtSecIdType.Text
        m_contractInfo.SecId = txtSecId.Text

        m_orderInfo.Action = txtAction.Text
        m_orderInfo.TotalQuantity = CInt(txtQuantity.Text)
        m_orderInfo.OrderType = txtOrderType.Text
        m_orderInfo.LmtPrice = dval(txtLmtPrice.Text)
        m_orderInfo.AuxPrice = dval(txtAuxPrice.Text)

        m_orderInfo.GoodAfterTime = tGAT.Text
        m_orderInfo.GoodTillDate = tGTD.Text

        m_orderInfo.FaGroup = m_faGroup
        m_orderInfo.FaMethod = m_faMethod
        m_orderInfo.FaPercentage = m_faPercentage
        m_orderInfo.FaProfile = m_faProfile

        m_genericTickTags = txtGenericTickTags.Text
        m_snapshotMktData = chkSnapshotMktData.CheckState

        m_numRows = CInt(txtNumRows.Text)

        m_endDateTime = txtEndDateTime.Text
        m_duration = txtDuration.Text
        m_barSizeSetting = txtBarSizeSetting.Text
        m_whatToShow = txtWhatToShow.Text
        m_useRTH = CInt(txtUseRTH.Text)
        m_formatDate = txtFormatDate.Text

        m_marketDataType = cmbMarketDataType.SelectedIndex + 1

        m_exerciseAction = CInt(txtExerciseAction.Text)
        m_exerciseQuantity = CInt(txtExerciseQuantity.Text)
        m_exerciseOverride = CInt(txtExerciseOverride.Text)

        m_ok = True
        m_contractInfo = Nothing
        m_orderInfo = Nothing
        Hide()
    End Sub
    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        m_ok = False
        m_contractInfo = Nothing
        m_orderInfo = Nothing
        Hide()
    End Sub

    ' ========================================================
    ' Public Methods
    ' ========================================================
    '--------------------------------------------------------------------------------
    ' Sets the dialog field and button states based on the dialog type
    '--------------------------------------------------------------------------------
    Public Sub init(ByRef dlgType As Dlg_Type, ByVal contractInfo As IBApi.Contract, _
        ByVal orderInfo As IBApi.Order, ByVal underComp As IBApi.UnderComp, _
        ByVal options As List(Of IBApi.TagValue), _
        ByVal mainWin As System.Windows.Forms.Form)
        m_ok = False

        m_contractInfo = contractInfo
        m_orderInfo = orderInfo
        m_underComp = underComp
        m_options = options

        m_mainWnd = dlgMainWnd.DefInstance
        Text = m_arrDlgTitles.Item(dlgType)

        cmdSetShareAllocation.Enabled = (m_mainWnd.isFAAccount() And dlgType = Dlg_Type.PLACE_ORDER_DLG)
        cmdAddCmboLegs.Enabled = _
            (dlgType = Dlg_Type.PLACE_ORDER_DLG Or _
            dlgType = Dlg_Type.REQ_HISTORICAL_DATA Or _
            dlgType = Dlg_Type.REQ_MKT_DATA_DLG)

        cmdUnderComp.Enabled = _
            (dlgType = Dlg_Type.PLACE_ORDER_DLG Or _
            dlgType = Dlg_Type.REQ_MKT_DATA_DLG)

        cmdAlgoParams.Enabled = _
            (dlgType = Dlg_Type.PLACE_ORDER_DLG)

        cmdSmartComboRoutingParams.Enabled = _
            (dlgType = Dlg_Type.PLACE_ORDER_DLG)

        cmdOptions.Enabled = _
            (dlgType = Dlg_Type.PLACE_ORDER_DLG Or _
            dlgType = Dlg_Type.REQ_MKT_DATA_DLG Or _
            dlgType = Dlg_Type.REQ_MKT_DEPTH_DLG Or _
            dlgType = Dlg_Type.REQ_HISTORICAL_DATA Or _
            dlgType = Dlg_Type.REQ_REAL_TIME_BARS_DLG)

        If Not (dlgType = Dlg_Type.PLACE_ORDER_DLG Or _
            dlgType = Dlg_Type.REQ_MKT_DATA_DLG Or _
            dlgType = Dlg_Type.REQ_MKT_DEPTH_DLG Or _
            dlgType = Dlg_Type.REQ_HISTORICAL_DATA Or _
            dlgType = Dlg_Type.REQ_REAL_TIME_BARS_DLG) Then
            cmdOptions.Text = "Options"
        End If

        txtReqId.Enabled = True
        txtBarSizeSetting.Enabled = (dlgType = Dlg_Type.REQ_HISTORICAL_DATA Or _
                            dlgType = Dlg_Type.REQ_REAL_TIME_BARS_DLG)
        txtDuration.Enabled = (dlgType = Dlg_Type.REQ_HISTORICAL_DATA)
        txtEndDateTime.Enabled = (dlgType = Dlg_Type.REQ_HISTORICAL_DATA)
        txtWhatToShow.Enabled = (dlgType = Dlg_Type.REQ_HISTORICAL_DATA Or _
                                 dlgType = Dlg_Type.REQ_REAL_TIME_BARS_DLG Or _
                                 dlgType = Dlg_Type.REQ_FUNDAMENTAL_DATA)
        txtUseRTH.Enabled = (dlgType = Dlg_Type.REQ_HISTORICAL_DATA Or _
                             dlgType = Dlg_Type.REQ_REAL_TIME_BARS_DLG)
        txtFormatDate.Enabled = (dlgType = Dlg_Type.REQ_HISTORICAL_DATA)
        txtGenericTickTags.Enabled = (dlgType = Dlg_Type.REQ_MKT_DATA_DLG)
        chkSnapshotMktData.Enabled = (dlgType = Dlg_Type.REQ_MKT_DATA_DLG)
        txtNumRows.Enabled = (dlgType = Dlg_Type.REQ_MKT_DEPTH_DLG)
        txtExerciseAction.Enabled = (dlgType = Dlg_Type.EXERCISE_OPTIONS)
        txtExerciseQuantity.Enabled = (dlgType = Dlg_Type.EXERCISE_OPTIONS)
        txtExerciseOverride.Enabled = (dlgType = Dlg_Type.EXERCISE_OPTIONS)
        txtIncludeExpired.Enabled = (dlgType = Dlg_Type.REQ_HISTORICAL_DATA Or _
                                     dlgType = Dlg_Type.REQ_CONTRACT_DETAILS_DLG)

        cmbMarketDataType.Enabled = (dlgType = Dlg_Type.REQ_MARKET_DATA_TYPE)

        ' enable or disable contract fields
        If dlgType = Dlg_Type.CANCEL_MKT_DATA_DLG Or _
           dlgType = Dlg_Type.CANCEL_MKT_DEPTH_DLG Or _
           dlgType = Dlg_Type.CANCEL_ORDER_DLG Or _
           dlgType = Dlg_Type.CANCEL_HIST_DATA_DLG Or _
           dlgType = Dlg_Type.CANCEL_REAL_TIME_BARS_DLG Or _
           dlgType = Dlg_Type.CANCEL_CALCULATE_IMPLIED_VOLATILITY Or _
           dlgType = Dlg_Type.CANCEL_CALCULATE_OPTION_PRICE Or _
           dlgType = Dlg_Type.REQ_MARKET_DATA_TYPE Then
            txtConId.Enabled = False
            txtSymbol.Enabled = False
            txtSecType.Enabled = False
            txtExpiry.Enabled = False
            txtStrike.Enabled = False
            txtRight.Enabled = False
            TextMultiplier.Enabled = False
            txtExchange.Enabled = False
            TxtPrimaryExchange.Enabled = False
            txtCurrency.Enabled = False
            txtLocalSymbol.Enabled = False
            txtTradingClass.Enabled = False
        Else
            txtConId.Enabled = True
            txtSymbol.Enabled = True
            txtSecType.Enabled = True
            txtExpiry.Enabled = True
            txtStrike.Enabled = True
            txtRight.Enabled = True
            TextMultiplier.Enabled = True
            txtExchange.Enabled = True
            txtCurrency.Enabled = True
            txtLocalSymbol.Enabled = True
            txtTradingClass.Enabled = True
            TxtPrimaryExchange.Enabled = True
        End If

        ' enable or disable order fields
        If dlgType = Dlg_Type.PLACE_ORDER_DLG Then
            txtAction.Enabled = True
            txtQuantity.Enabled = True
            txtOrderType.Enabled = True
            txtLmtPrice.Enabled = True
            txtAuxPrice.Enabled = True
            tGAT.Enabled = True
            tGTD.Enabled = True
        Else
            txtAction.Enabled = False
            txtQuantity.Enabled = False
            txtOrderType.Enabled = False
            txtLmtPrice.Enabled = False
            txtAuxPrice.Enabled = False
            tGAT.Enabled = False
            tGTD.Enabled = False
        End If

        If dlgType = Dlg_Type.CALCULATE_IMPLIED_VOLATILITY Or dlgType = Dlg_Type.CALCULATE_OPTION_PRICE Then
            txtLmtPrice.Enabled = True
            txtAuxPrice.Enabled = True
        End If

        If dlgType = Dlg_Type.PLACE_ORDER_DLG Or dlgType = Dlg_Type.REQ_CONTRACT_DETAILS_DLG Then
            txtSecIdType.Enabled = True
            txtSecId.Enabled = True
        Else
            txtSecIdType.Enabled = False
            txtSecId.Enabled = False
        End If

        If dlgType = Dlg_Type.REQ_MARKET_DATA_TYPE Then
            cmbMarketDataType.Enabled = True
            txtReqId.Enabled = False
            txtConId.Enabled = False
            cmdAlgoParams.Enabled = False
            cmdSmartComboRoutingParams.Enabled = False
        End If

        If dlgType = Dlg_Type.PLACE_ORDER_DLG Then
            m_optionsDlgTitle = "Order Misc Options"
            cmdOptions.Text = "Ord Misc Options"
        End If

        If dlgType = Dlg_Type.REQ_HISTORICAL_DATA Then
            m_optionsDlgTitle = "Chart Options"
            cmdOptions.Text = "Chart Options"
        End If

        If dlgType = Dlg_Type.REQ_MKT_DATA_DLG Then
            m_optionsDlgTitle = "Market Data Options"
            cmdOptions.Text = "Mkt Data Options"
        End If

        If dlgType = Dlg_Type.REQ_MKT_DEPTH_DLG Then
            m_optionsDlgTitle = "Market Depth Options"
            cmdOptions.Text = "Mkt Depth Opts"
        End If

        If dlgType = Dlg_Type.REQ_REAL_TIME_BARS_DLG Then
            m_optionsDlgTitle = "Real Time Bars Options"
            cmdOptions.Text = "RTB Options"
        End If

    End Sub
    '--------------------------------------------------------------------------------
    ' Set the various dialog title string for each dialog type and the initial
    ' dialog data.
    '--------------------------------------------------------------------------------
    Private Sub Form_Initialize_Renamed()

        m_orderId = 0

        txtEndDateTime.Text = Format(Now(), "yyyyMMdd HH:mm:ss")

        m_arrDlgTitles.Add("Request Market Data")
        m_arrDlgTitles.Add("Cancel Market Data")
        m_arrDlgTitles.Add("Request Market Depth")
        m_arrDlgTitles.Add("Cancel Market Depth")
        m_arrDlgTitles.Add("Place Order")
        m_arrDlgTitles.Add("Cancel Order")
        m_arrDlgTitles.Add("Request Contract Details")
        m_arrDlgTitles.Add("Request Historical Data")
        m_arrDlgTitles.Add("Exercise Options")
        m_arrDlgTitles.Add("Cancel Historical Data")
        m_arrDlgTitles.Add("Request Real Time Bars")
        m_arrDlgTitles.Add("Cancel Real Time Bars")
        m_arrDlgTitles.Add("Calculate Implied Volatility")
        m_arrDlgTitles.Add("Calculate Option Price")
        m_arrDlgTitles.Add("Cancel Calculate Implied Volatility")
        m_arrDlgTitles.Add("Cancel Calculate Option Price")
        m_arrDlgTitles.Add("Request Market Data Type")
        m_arrDlgTitles.Add("Request Fundamental Data")
        m_arrDlgTitles.Add("Cancel Fundamental Data")

        cmbMarketDataType.Items.Clear()
        cmbMarketDataType.Items.Add(("Real-Time"))
        cmbMarketDataType.Items.Add(("Frozen"))
        cmbMarketDataType.SelectedIndex = MARKET_DATA_TYPE.REALTIME - 1

    End Sub

    Private Sub cmdSmartComboRoutingParams_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSmartComboRoutingParams.Click
        'Dim dlg As New dlgSmartComboRoutingParams

        'dlg.init(m_orderInfo.SmartComboRoutingParams, m_mainWnd.Tws1, "Smart Combo Routing Params")
        'Dim res As DialogResult
        'res = dlg.ShowDialog()
        'If res = Windows.Forms.DialogResult.OK Then
        '    m_orderInfo.SmartComboRoutingParams = dlg.smartComboRoutingParams
        'End If

    End Sub

    Private Sub cmdOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOptions.Click
        'Dim dlg As New dlgSmartComboRoutingParams

        'dlg.init(m_options, m_mainWnd.Tws1, m_optionsDlgTitle)
        'Dim res As DialogResult
        'res = dlg.ShowDialog()
        'If res = Windows.Forms.DialogResult.OK Then
        '    m_options = dlg.smartComboRoutingParams
        'End If

    End Sub


    Private Function dval(ByVal text As String) As Double
        If Len(text) = 0 Then
            dval = Double.MaxValue
        Else
            dval = CDbl(text)
        End If
    End Function
End Class
