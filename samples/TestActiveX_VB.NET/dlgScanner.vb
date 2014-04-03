' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Option Strict Off
Option Explicit On

Imports System.Collections.Generic

Friend Class dlgScanner
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
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents cmdCancelSubscription As System.Windows.Forms.Button
    Public WithEvents cmdSubscribe As System.Windows.Forms.Button
    Public WithEvents cmdRequestParameters As System.Windows.Forms.Button
    Public WithEvents txtReqId As System.Windows.Forms.TextBox
    Public WithEvents txtNumberOfRows As System.Windows.Forms.TextBox
    Public WithEvents txtInstrument As System.Windows.Forms.TextBox
    Public WithEvents txtLocationCode As System.Windows.Forms.TextBox
    Public WithEvents txtScanCode As System.Windows.Forms.TextBox
    Public WithEvents txtAboveVolume As System.Windows.Forms.TextBox
    Public WithEvents txtMarketCapBelow As System.Windows.Forms.TextBox
    Public WithEvents txtMoodyRatingAbove As System.Windows.Forms.TextBox
    Public WithEvents txtAbovePrice As System.Windows.Forms.TextBox
    Public WithEvents TxtMarketCapAbove As System.Windows.Forms.TextBox
    Public WithEvents txtBelowPrice As System.Windows.Forms.TextBox
    Public WithEvents txtMoodyRatingBelow As System.Windows.Forms.TextBox
    Public WithEvents txtSpRatingAbove As System.Windows.Forms.TextBox
    Public WithEvents txtMaturityDateBelow As System.Windows.Forms.TextBox
    Public WithEvents txtCouponRateBelow As System.Windows.Forms.TextBox
    Public WithEvents txtExcludeConvertibles As System.Windows.Forms.TextBox
    Public WithEvents txtSpRatingBelow As System.Windows.Forms.TextBox
    Public WithEvents txtCouponRateAbove As System.Windows.Forms.TextBox
    Public WithEvents txtMaturityDateAbove As System.Windows.Forms.TextBox
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label19 As System.Windows.Forms.Label
    Public WithEvents Label16 As System.Windows.Forms.Label
    Public WithEvents Label15 As System.Windows.Forms.Label
    Public WithEvents Label14 As System.Windows.Forms.Label
    Public WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents Label17 As System.Windows.Forms.Label
    Public WithEvents Label18 As System.Windows.Forms.Label
    Public WithEvents frameTickerDesc As System.Windows.Forms.GroupBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Public WithEvents Label20 As System.Windows.Forms.Label
    Public WithEvents txtScannerSettingPairs As System.Windows.Forms.TextBox
    Public WithEvents txtAverageOptionVolumeAbove As System.Windows.Forms.TextBox
    Public WithEvents Label21 As System.Windows.Forms.Label
    Public WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cmdOptions As System.Windows.Forms.Button
    Public WithEvents txtStockTypeFilter As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdCancelSubscription = New System.Windows.Forms.Button
        Me.cmdSubscribe = New System.Windows.Forms.Button
        Me.cmdRequestParameters = New System.Windows.Forms.Button
        Me.txtReqId = New System.Windows.Forms.TextBox
        Me.frameTickerDesc = New System.Windows.Forms.GroupBox
        Me.txtStockTypeFilter = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtAverageOptionVolumeAbove = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtScannerSettingPairs = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtNumberOfRows = New System.Windows.Forms.TextBox
        Me.txtInstrument = New System.Windows.Forms.TextBox
        Me.txtLocationCode = New System.Windows.Forms.TextBox
        Me.txtScanCode = New System.Windows.Forms.TextBox
        Me.txtAboveVolume = New System.Windows.Forms.TextBox
        Me.txtMarketCapBelow = New System.Windows.Forms.TextBox
        Me.txtMoodyRatingAbove = New System.Windows.Forms.TextBox
        Me.txtAbovePrice = New System.Windows.Forms.TextBox
        Me.TxtMarketCapAbove = New System.Windows.Forms.TextBox
        Me.txtBelowPrice = New System.Windows.Forms.TextBox
        Me.txtMoodyRatingBelow = New System.Windows.Forms.TextBox
        Me.txtSpRatingAbove = New System.Windows.Forms.TextBox
        Me.txtMaturityDateBelow = New System.Windows.Forms.TextBox
        Me.txtCouponRateBelow = New System.Windows.Forms.TextBox
        Me.txtExcludeConvertibles = New System.Windows.Forms.TextBox
        Me.txtSpRatingBelow = New System.Windows.Forms.TextBox
        Me.txtCouponRateAbove = New System.Windows.Forms.TextBox
        Me.txtMaturityDateAbove = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdOptions = New System.Windows.Forms.Button
        Me.frameTickerDesc.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCancelSubscription
        '
        Me.cmdCancelSubscription.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancelSubscription.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancelSubscription.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelSubscription.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancelSubscription.Location = New System.Drawing.Point(211, 576)
        Me.cmdCancelSubscription.Name = "cmdCancelSubscription"
        Me.cmdCancelSubscription.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancelSubscription.Size = New System.Drawing.Size(113, 25)
        Me.cmdCancelSubscription.TabIndex = 5
        Me.cmdCancelSubscription.Text = "Cancel Subscription"
        Me.cmdCancelSubscription.UseVisualStyleBackColor = False
        '
        'cmdSubscribe
        '
        Me.cmdSubscribe.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSubscribe.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSubscribe.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSubscribe.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSubscribe.Location = New System.Drawing.Point(126, 576)
        Me.cmdSubscribe.Name = "cmdSubscribe"
        Me.cmdSubscribe.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSubscribe.Size = New System.Drawing.Size(78, 25)
        Me.cmdSubscribe.TabIndex = 4
        Me.cmdSubscribe.Text = "Subscribe"
        Me.cmdSubscribe.UseVisualStyleBackColor = False
        '
        'cmdRequestParameters
        '
        Me.cmdRequestParameters.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRequestParameters.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRequestParameters.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRequestParameters.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRequestParameters.Location = New System.Drawing.Point(0, 576)
        Me.cmdRequestParameters.Name = "cmdRequestParameters"
        Me.cmdRequestParameters.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRequestParameters.Size = New System.Drawing.Size(121, 25)
        Me.cmdRequestParameters.TabIndex = 3
        Me.cmdRequestParameters.Text = "Request Parameters"
        Me.cmdRequestParameters.UseVisualStyleBackColor = False
        '
        'txtReqId
        '
        Me.txtReqId.AcceptsReturn = True
        Me.txtReqId.BackColor = System.Drawing.SystemColors.Window
        Me.txtReqId.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtReqId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReqId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtReqId.Location = New System.Drawing.Point(200, 24)
        Me.txtReqId.MaxLength = 0
        Me.txtReqId.Name = "txtReqId"
        Me.txtReqId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtReqId.Size = New System.Drawing.Size(185, 20)
        Me.txtReqId.TabIndex = 1
        Me.txtReqId.Text = "0"
        '
        'frameTickerDesc
        '
        Me.frameTickerDesc.BackColor = System.Drawing.SystemColors.Control
        Me.frameTickerDesc.Controls.Add(Me.txtStockTypeFilter)
        Me.frameTickerDesc.Controls.Add(Me.Label22)
        Me.frameTickerDesc.Controls.Add(Me.txtAverageOptionVolumeAbove)
        Me.frameTickerDesc.Controls.Add(Me.Label21)
        Me.frameTickerDesc.Controls.Add(Me.txtScannerSettingPairs)
        Me.frameTickerDesc.Controls.Add(Me.Label20)
        Me.frameTickerDesc.Controls.Add(Me.txtNumberOfRows)
        Me.frameTickerDesc.Controls.Add(Me.txtInstrument)
        Me.frameTickerDesc.Controls.Add(Me.txtLocationCode)
        Me.frameTickerDesc.Controls.Add(Me.txtScanCode)
        Me.frameTickerDesc.Controls.Add(Me.txtAboveVolume)
        Me.frameTickerDesc.Controls.Add(Me.txtMarketCapBelow)
        Me.frameTickerDesc.Controls.Add(Me.txtMoodyRatingAbove)
        Me.frameTickerDesc.Controls.Add(Me.txtAbovePrice)
        Me.frameTickerDesc.Controls.Add(Me.TxtMarketCapAbove)
        Me.frameTickerDesc.Controls.Add(Me.txtBelowPrice)
        Me.frameTickerDesc.Controls.Add(Me.txtMoodyRatingBelow)
        Me.frameTickerDesc.Controls.Add(Me.txtSpRatingAbove)
        Me.frameTickerDesc.Controls.Add(Me.txtMaturityDateBelow)
        Me.frameTickerDesc.Controls.Add(Me.txtCouponRateBelow)
        Me.frameTickerDesc.Controls.Add(Me.txtExcludeConvertibles)
        Me.frameTickerDesc.Controls.Add(Me.txtSpRatingBelow)
        Me.frameTickerDesc.Controls.Add(Me.txtCouponRateAbove)
        Me.frameTickerDesc.Controls.Add(Me.txtMaturityDateAbove)
        Me.frameTickerDesc.Controls.Add(Me.Label2)
        Me.frameTickerDesc.Controls.Add(Me.Label19)
        Me.frameTickerDesc.Controls.Add(Me.Label16)
        Me.frameTickerDesc.Controls.Add(Me.Label15)
        Me.frameTickerDesc.Controls.Add(Me.Label14)
        Me.frameTickerDesc.Controls.Add(Me.Label13)
        Me.frameTickerDesc.Controls.Add(Me.Label12)
        Me.frameTickerDesc.Controls.Add(Me.Label11)
        Me.frameTickerDesc.Controls.Add(Me.Label10)
        Me.frameTickerDesc.Controls.Add(Me.Label3)
        Me.frameTickerDesc.Controls.Add(Me.Label4)
        Me.frameTickerDesc.Controls.Add(Me.Label5)
        Me.frameTickerDesc.Controls.Add(Me.Label6)
        Me.frameTickerDesc.Controls.Add(Me.Label7)
        Me.frameTickerDesc.Controls.Add(Me.Label8)
        Me.frameTickerDesc.Controls.Add(Me.Label9)
        Me.frameTickerDesc.Controls.Add(Me.Label17)
        Me.frameTickerDesc.Controls.Add(Me.Label18)
        Me.frameTickerDesc.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frameTickerDesc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frameTickerDesc.Location = New System.Drawing.Point(0, 56)
        Me.frameTickerDesc.Name = "frameTickerDesc"
        Me.frameTickerDesc.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frameTickerDesc.Size = New System.Drawing.Size(393, 512)
        Me.frameTickerDesc.TabIndex = 2
        Me.frameTickerDesc.TabStop = False
        Me.frameTickerDesc.Text = "Subscription Info"
        '
        'txtStockTypeFilter
        '
        Me.txtStockTypeFilter.AcceptsReturn = True
        Me.txtStockTypeFilter.BackColor = System.Drawing.SystemColors.Window
        Me.txtStockTypeFilter.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStockTypeFilter.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockTypeFilter.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStockTypeFilter.Location = New System.Drawing.Point(200, 484)
        Me.txtStockTypeFilter.MaxLength = 0
        Me.txtStockTypeFilter.Name = "txtStockTypeFilter"
        Me.txtStockTypeFilter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStockTypeFilter.Size = New System.Drawing.Size(185, 20)
        Me.txtStockTypeFilter.TabIndex = 41
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.SystemColors.Control
        Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label22.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(16, 487)
        Me.Label22.Name = "Label22"
        Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label22.Size = New System.Drawing.Size(113, 13)
        Me.Label22.TabIndex = 40
        Me.Label22.Text = "Stock Type Filter"
        '
        'txtAverageOptionVolumeAbove
        '
        Me.txtAverageOptionVolumeAbove.AcceptsReturn = True
        Me.txtAverageOptionVolumeAbove.BackColor = System.Drawing.SystemColors.Window
        Me.txtAverageOptionVolumeAbove.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAverageOptionVolumeAbove.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAverageOptionVolumeAbove.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAverageOptionVolumeAbove.Location = New System.Drawing.Point(200, 185)
        Me.txtAverageOptionVolumeAbove.MaxLength = 0
        Me.txtAverageOptionVolumeAbove.Name = "txtAverageOptionVolumeAbove"
        Me.txtAverageOptionVolumeAbove.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAverageOptionVolumeAbove.Size = New System.Drawing.Size(185, 20)
        Me.txtAverageOptionVolumeAbove.TabIndex = 15
        Me.txtAverageOptionVolumeAbove.Text = "0"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.SystemColors.Control
        Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label21.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(16, 188)
        Me.Label21.Name = "Label21"
        Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label21.Size = New System.Drawing.Size(160, 13)
        Me.Label21.TabIndex = 14
        Me.Label21.Text = "Average Option Volume Above"
        '
        'txtScannerSettingPairs
        '
        Me.txtScannerSettingPairs.AcceptsReturn = True
        Me.txtScannerSettingPairs.BackColor = System.Drawing.SystemColors.Window
        Me.txtScannerSettingPairs.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtScannerSettingPairs.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtScannerSettingPairs.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtScannerSettingPairs.Location = New System.Drawing.Point(200, 461)
        Me.txtScannerSettingPairs.MaxLength = 0
        Me.txtScannerSettingPairs.Name = "txtScannerSettingPairs"
        Me.txtScannerSettingPairs.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtScannerSettingPairs.Size = New System.Drawing.Size(185, 20)
        Me.txtScannerSettingPairs.TabIndex = 39
        Me.txtScannerSettingPairs.Text = "Annual,true"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.SystemColors.Control
        Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label20.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(16, 464)
        Me.Label20.Name = "Label20"
        Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label20.Size = New System.Drawing.Size(113, 13)
        Me.Label20.TabIndex = 38
        Me.Label20.Text = "Scanner Setting Pairs"
        '
        'txtNumberOfRows
        '
        Me.txtNumberOfRows.AcceptsReturn = True
        Me.txtNumberOfRows.BackColor = System.Drawing.SystemColors.Window
        Me.txtNumberOfRows.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumberOfRows.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumberOfRows.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtNumberOfRows.Location = New System.Drawing.Point(200, 24)
        Me.txtNumberOfRows.MaxLength = 0
        Me.txtNumberOfRows.Name = "txtNumberOfRows"
        Me.txtNumberOfRows.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNumberOfRows.Size = New System.Drawing.Size(185, 20)
        Me.txtNumberOfRows.TabIndex = 1
        Me.txtNumberOfRows.Text = "10"
        '
        'txtInstrument
        '
        Me.txtInstrument.AcceptsReturn = True
        Me.txtInstrument.BackColor = System.Drawing.SystemColors.Window
        Me.txtInstrument.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtInstrument.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInstrument.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtInstrument.Location = New System.Drawing.Point(200, 47)
        Me.txtInstrument.MaxLength = 0
        Me.txtInstrument.Name = "txtInstrument"
        Me.txtInstrument.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtInstrument.Size = New System.Drawing.Size(185, 20)
        Me.txtInstrument.TabIndex = 3
        Me.txtInstrument.Text = "STK"
        '
        'txtLocationCode
        '
        Me.txtLocationCode.AcceptsReturn = True
        Me.txtLocationCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtLocationCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLocationCode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocationCode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLocationCode.Location = New System.Drawing.Point(200, 70)
        Me.txtLocationCode.MaxLength = 0
        Me.txtLocationCode.Name = "txtLocationCode"
        Me.txtLocationCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLocationCode.Size = New System.Drawing.Size(185, 20)
        Me.txtLocationCode.TabIndex = 5
        Me.txtLocationCode.Text = "STK.US.MAJOR"
        '
        'txtScanCode
        '
        Me.txtScanCode.AcceptsReturn = True
        Me.txtScanCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtScanCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtScanCode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtScanCode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtScanCode.Location = New System.Drawing.Point(200, 93)
        Me.txtScanCode.MaxLength = 0
        Me.txtScanCode.Name = "txtScanCode"
        Me.txtScanCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtScanCode.Size = New System.Drawing.Size(185, 20)
        Me.txtScanCode.TabIndex = 7
        Me.txtScanCode.Text = "TOP_PERC_GAIN"
        '
        'txtAboveVolume
        '
        Me.txtAboveVolume.AcceptsReturn = True
        Me.txtAboveVolume.BackColor = System.Drawing.SystemColors.Window
        Me.txtAboveVolume.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAboveVolume.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAboveVolume.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAboveVolume.Location = New System.Drawing.Point(200, 162)
        Me.txtAboveVolume.MaxLength = 0
        Me.txtAboveVolume.Name = "txtAboveVolume"
        Me.txtAboveVolume.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAboveVolume.Size = New System.Drawing.Size(185, 20)
        Me.txtAboveVolume.TabIndex = 13
        Me.txtAboveVolume.Text = "0"
        '
        'txtMarketCapBelow
        '
        Me.txtMarketCapBelow.AcceptsReturn = True
        Me.txtMarketCapBelow.BackColor = System.Drawing.SystemColors.Window
        Me.txtMarketCapBelow.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMarketCapBelow.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMarketCapBelow.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMarketCapBelow.Location = New System.Drawing.Point(200, 231)
        Me.txtMarketCapBelow.MaxLength = 0
        Me.txtMarketCapBelow.Name = "txtMarketCapBelow"
        Me.txtMarketCapBelow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMarketCapBelow.Size = New System.Drawing.Size(185, 20)
        Me.txtMarketCapBelow.TabIndex = 19
        '
        'txtMoodyRatingAbove
        '
        Me.txtMoodyRatingAbove.AcceptsReturn = True
        Me.txtMoodyRatingAbove.BackColor = System.Drawing.SystemColors.Window
        Me.txtMoodyRatingAbove.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMoodyRatingAbove.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMoodyRatingAbove.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMoodyRatingAbove.Location = New System.Drawing.Point(200, 254)
        Me.txtMoodyRatingAbove.MaxLength = 0
        Me.txtMoodyRatingAbove.Name = "txtMoodyRatingAbove"
        Me.txtMoodyRatingAbove.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMoodyRatingAbove.Size = New System.Drawing.Size(185, 20)
        Me.txtMoodyRatingAbove.TabIndex = 21
        '
        'txtAbovePrice
        '
        Me.txtAbovePrice.AcceptsReturn = True
        Me.txtAbovePrice.BackColor = System.Drawing.SystemColors.Window
        Me.txtAbovePrice.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAbovePrice.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAbovePrice.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAbovePrice.Location = New System.Drawing.Point(200, 116)
        Me.txtAbovePrice.MaxLength = 0
        Me.txtAbovePrice.Name = "txtAbovePrice"
        Me.txtAbovePrice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAbovePrice.Size = New System.Drawing.Size(185, 20)
        Me.txtAbovePrice.TabIndex = 9
        Me.txtAbovePrice.Text = "3"
        '
        'TxtMarketCapAbove
        '
        Me.TxtMarketCapAbove.AcceptsReturn = True
        Me.TxtMarketCapAbove.BackColor = System.Drawing.SystemColors.Window
        Me.TxtMarketCapAbove.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtMarketCapAbove.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMarketCapAbove.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtMarketCapAbove.Location = New System.Drawing.Point(200, 208)
        Me.TxtMarketCapAbove.MaxLength = 0
        Me.TxtMarketCapAbove.Name = "TxtMarketCapAbove"
        Me.TxtMarketCapAbove.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtMarketCapAbove.Size = New System.Drawing.Size(185, 20)
        Me.TxtMarketCapAbove.TabIndex = 17
        Me.TxtMarketCapAbove.Text = "100000000"
        '
        'txtBelowPrice
        '
        Me.txtBelowPrice.AcceptsReturn = True
        Me.txtBelowPrice.BackColor = System.Drawing.SystemColors.Window
        Me.txtBelowPrice.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBelowPrice.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBelowPrice.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBelowPrice.Location = New System.Drawing.Point(200, 139)
        Me.txtBelowPrice.MaxLength = 0
        Me.txtBelowPrice.Name = "txtBelowPrice"
        Me.txtBelowPrice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBelowPrice.Size = New System.Drawing.Size(185, 20)
        Me.txtBelowPrice.TabIndex = 11
        '
        'txtMoodyRatingBelow
        '
        Me.txtMoodyRatingBelow.AcceptsReturn = True
        Me.txtMoodyRatingBelow.BackColor = System.Drawing.SystemColors.Window
        Me.txtMoodyRatingBelow.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMoodyRatingBelow.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMoodyRatingBelow.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMoodyRatingBelow.Location = New System.Drawing.Point(200, 277)
        Me.txtMoodyRatingBelow.MaxLength = 0
        Me.txtMoodyRatingBelow.Name = "txtMoodyRatingBelow"
        Me.txtMoodyRatingBelow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMoodyRatingBelow.Size = New System.Drawing.Size(185, 20)
        Me.txtMoodyRatingBelow.TabIndex = 23
        '
        'txtSpRatingAbove
        '
        Me.txtSpRatingAbove.AcceptsReturn = True
        Me.txtSpRatingAbove.BackColor = System.Drawing.SystemColors.Window
        Me.txtSpRatingAbove.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSpRatingAbove.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpRatingAbove.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSpRatingAbove.Location = New System.Drawing.Point(200, 300)
        Me.txtSpRatingAbove.MaxLength = 0
        Me.txtSpRatingAbove.Name = "txtSpRatingAbove"
        Me.txtSpRatingAbove.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSpRatingAbove.Size = New System.Drawing.Size(185, 20)
        Me.txtSpRatingAbove.TabIndex = 25
        '
        'txtMaturityDateBelow
        '
        Me.txtMaturityDateBelow.AcceptsReturn = True
        Me.txtMaturityDateBelow.BackColor = System.Drawing.SystemColors.Window
        Me.txtMaturityDateBelow.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMaturityDateBelow.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaturityDateBelow.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMaturityDateBelow.Location = New System.Drawing.Point(200, 369)
        Me.txtMaturityDateBelow.MaxLength = 0
        Me.txtMaturityDateBelow.Name = "txtMaturityDateBelow"
        Me.txtMaturityDateBelow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMaturityDateBelow.Size = New System.Drawing.Size(185, 20)
        Me.txtMaturityDateBelow.TabIndex = 31
        '
        'txtCouponRateBelow
        '
        Me.txtCouponRateBelow.AcceptsReturn = True
        Me.txtCouponRateBelow.BackColor = System.Drawing.SystemColors.Window
        Me.txtCouponRateBelow.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCouponRateBelow.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCouponRateBelow.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCouponRateBelow.Location = New System.Drawing.Point(200, 415)
        Me.txtCouponRateBelow.MaxLength = 0
        Me.txtCouponRateBelow.Name = "txtCouponRateBelow"
        Me.txtCouponRateBelow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCouponRateBelow.Size = New System.Drawing.Size(185, 20)
        Me.txtCouponRateBelow.TabIndex = 35
        '
        'txtExcludeConvertibles
        '
        Me.txtExcludeConvertibles.AcceptsReturn = True
        Me.txtExcludeConvertibles.BackColor = System.Drawing.SystemColors.Window
        Me.txtExcludeConvertibles.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtExcludeConvertibles.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExcludeConvertibles.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtExcludeConvertibles.Location = New System.Drawing.Point(200, 438)
        Me.txtExcludeConvertibles.MaxLength = 0
        Me.txtExcludeConvertibles.Name = "txtExcludeConvertibles"
        Me.txtExcludeConvertibles.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtExcludeConvertibles.Size = New System.Drawing.Size(185, 20)
        Me.txtExcludeConvertibles.TabIndex = 37
        Me.txtExcludeConvertibles.Text = "0"
        '
        'txtSpRatingBelow
        '
        Me.txtSpRatingBelow.AcceptsReturn = True
        Me.txtSpRatingBelow.BackColor = System.Drawing.SystemColors.Window
        Me.txtSpRatingBelow.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSpRatingBelow.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpRatingBelow.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSpRatingBelow.Location = New System.Drawing.Point(200, 323)
        Me.txtSpRatingBelow.MaxLength = 0
        Me.txtSpRatingBelow.Name = "txtSpRatingBelow"
        Me.txtSpRatingBelow.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSpRatingBelow.Size = New System.Drawing.Size(185, 20)
        Me.txtSpRatingBelow.TabIndex = 27
        '
        'txtCouponRateAbove
        '
        Me.txtCouponRateAbove.AcceptsReturn = True
        Me.txtCouponRateAbove.BackColor = System.Drawing.SystemColors.Window
        Me.txtCouponRateAbove.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCouponRateAbove.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCouponRateAbove.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCouponRateAbove.Location = New System.Drawing.Point(200, 392)
        Me.txtCouponRateAbove.MaxLength = 0
        Me.txtCouponRateAbove.Name = "txtCouponRateAbove"
        Me.txtCouponRateAbove.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCouponRateAbove.Size = New System.Drawing.Size(185, 20)
        Me.txtCouponRateAbove.TabIndex = 33
        '
        'txtMaturityDateAbove
        '
        Me.txtMaturityDateAbove.AcceptsReturn = True
        Me.txtMaturityDateAbove.BackColor = System.Drawing.SystemColors.Window
        Me.txtMaturityDateAbove.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMaturityDateAbove.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaturityDateAbove.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMaturityDateAbove.Location = New System.Drawing.Point(200, 346)
        Me.txtMaturityDateAbove.MaxLength = 0
        Me.txtMaturityDateAbove.Name = "txtMaturityDateAbove"
        Me.txtMaturityDateAbove.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMaturityDateAbove.Size = New System.Drawing.Size(185, 20)
        Me.txtMaturityDateAbove.TabIndex = 29
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(16, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(113, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Number of Rows"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.SystemColors.Control
        Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(16, 280)
        Me.Label19.Name = "Label19"
        Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label19.Size = New System.Drawing.Size(129, 13)
        Me.Label19.TabIndex = 22
        Me.Label19.Text = "Moody Rating Below"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.Control
        Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(16, 303)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label16.Size = New System.Drawing.Size(113, 13)
        Me.Label16.TabIndex = 24
        Me.Label16.Text = "S and P Rating Above"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.Control
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(16, 372)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(113, 13)
        Me.Label15.TabIndex = 30
        Me.Label15.Text = "Maturity Date Below"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.Control
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(16, 418)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(105, 13)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "Coupon Rate Below"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(16, 441)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(113, 13)
        Me.Label13.TabIndex = 36
        Me.Label13.Text = "Exclude Convertibles"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(16, 326)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(113, 13)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "S and P Rating Below"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(16, 395)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(97, 13)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "Coupon Rate Above"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(16, 349)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(113, 13)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Maturity Date Above"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(16, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(113, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Instrument"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(16, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Location Code"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(16, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Scan Code"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(16, 165)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(88, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Above Volume"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(16, 234)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(105, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Market Cap Below"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(16, 257)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(113, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Moody Rating Above"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(16, 119)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(73, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Above Price"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.Control
        Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(16, 211)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(97, 13)
        Me.Label17.TabIndex = 16
        Me.Label17.Text = "Market Cap Above"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.SystemColors.Control
        Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label18.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(16, 142)
        Me.Label18.Name = "Label18"
        Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label18.Size = New System.Drawing.Size(73, 13)
        Me.Label18.TabIndex = 10
        Me.Label18.Text = "Below Price"
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(8, 8)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(385, 41)
        Me.Frame1.TabIndex = 0
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Message Id"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(57, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Id"
        '
        'cmdOptions
        '
        Me.cmdOptions.Location = New System.Drawing.Point(327, 576)
        Me.cmdOptions.Name = "cmdOptions"
        Me.cmdOptions.Size = New System.Drawing.Size(66, 25)
        Me.cmdOptions.TabIndex = 6
        Me.cmdOptions.Text = "Options"
        Me.cmdOptions.UseVisualStyleBackColor = True
        '
        'dlgScanner
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(395, 605)
        Me.Controls.Add(Me.cmdOptions)
        Me.Controls.Add(Me.cmdCancelSubscription)
        Me.Controls.Add(Me.cmdSubscribe)
        Me.Controls.Add(Me.cmdRequestParameters)
        Me.Controls.Add(Me.txtReqId)
        Me.Controls.Add(Me.frameTickerDesc)
        Me.Controls.Add(Me.Frame1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "dlgScanner"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Market Scanner"
        Me.frameTickerDesc.ResumeLayout(False)
        Me.frameTickerDesc.PerformLayout()
        Me.Frame1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
#Region "Upgrade Support "
    Private Shared m_vb6FormDefInstance As dlgScanner
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As dlgScanner
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New dlgScanner()
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(value As dlgScanner)
            m_vb6FormDefInstance = value
        End Set
    End Property
#End Region
    Private m_subscription As IBApi.ScannerSubscription
    Private m_mainWnd As dlgMainWnd

    Private m_id As Integer
    Private m_ok As Boolean
    Private m_scannerSubscriptionOptions As List(Of IBApi.TagValue)

    ' ========================================================
    ' Public Methods
    ' ========================================================
    Public Sub init(ByRef mainWin As System.Windows.Forms.Form)
        m_ok = False
        m_mainWnd = mainWin
        m_subscription = New IBApi.ScannerSubscription
    End Sub

    ' ========================================================
    ' Private Methods
    ' ========================================================
    Private Sub cmdCancel_Click()
        m_ok = False
        Hide()
    End Sub

    Private Sub cmdRequestParameters_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRequestParameters.Click
        Call m_mainWnd.requestScannerParameters()
        Hide()
    End Sub

    Private Sub cmdCancelSubscription_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancelSubscription.Click
        Call populateSubscription()
        Call m_mainWnd.cancelScannerSubscription(m_id)
        Hide()
    End Sub

    Private Sub cmdSubscribe_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSubscribe.Click
        Call populateSubscription()
        Call m_mainWnd.scannerSubscription(m_id, m_subscription, m_scannerSubscriptionOptions)
        Hide()
    End Sub

    Private Sub cmdOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOptions.Click
        'Dim dlg As New dlgSmartComboRoutingParams
        'dlg.init(m_scannerSubscriptionOptions, m_mainWnd.Tws1, "Scanner Subscription Options")
        'Dim res As DialogResult
        'res = dlg.ShowDialog()
        'If res = Windows.Forms.DialogResult.OK Then
        '    m_scannerSubscriptionOptions = dlg.smartComboRoutingParams
        'End If
    End Sub

    Private Sub populateSubscription()
        m_id = CInt(txtReqId.Text)
        With m_subscription
            .NumberOfRows = numFromText(txtNumberOfRows.Text)
            .Instrument = txtInstrument.Text
            .LocationCode = txtLocationCode.Text
            .ScanCode = txtScanCode.Text
            .AbovePrice = numFromText(txtAbovePrice.Text)
            .BelowPrice = numFromText(txtBelowPrice.Text)
            .AboveVolume = numFromText(txtAboveVolume.Text)
            .AverageOptionVolumeAbove = numFromText(txtAverageOptionVolumeAbove.Text)
            .MarketCapAbove = numFromText(TxtMarketCapAbove.Text)
            .MarketCapBelow = numFromText(txtMarketCapBelow.Text)
            .MoodyRatingAbove = txtMoodyRatingAbove.Text
            .MoodyRatingBelow = txtMoodyRatingBelow.Text
            .SpRatingAbove = txtSpRatingAbove.Text
            .SpRatingBelow = txtSpRatingBelow.Text
            .MaturityDateAbove = txtMaturityDateAbove.Text
            .MaturityDateBelow = txtMaturityDateBelow.Text
            .CouponRateAbove = numFromText(txtCouponRateAbove.Text)
            .CouponRateBelow = numFromText(txtCouponRateBelow.Text)
            .ExcludeConvertible = numFromText(txtExcludeConvertibles.Text)
            .ScannerSettingPairs = txtScannerSettingPairs.Text
            .StockTypeFilter = txtStockTypeFilter.Text
        End With
    End Sub

    Private Function numFromText(ByRef textStr As String) As Double
        If textStr = "" Then
            numFromText = -1
        Else
            numFromText = CDbl(textStr)
        End If
    End Function
End Class