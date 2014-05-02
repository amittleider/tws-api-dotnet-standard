' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Option Strict Off
Option Explicit On 
Public Class dlgOrderAttribs
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
    Public WithEvents txtRule80A As System.Windows.Forms.TextBox
    Public WithEvents txtSettlingFirm As System.Windows.Forms.TextBox
    Public WithEvents txtMinQty As System.Windows.Forms.TextBox
    Public WithEvents txtPercentOffset As System.Windows.Forms.TextBox
    Public WithEvents txtETradeOnly As System.Windows.Forms.TextBox
    Public WithEvents txtFirmQuoteOnly As System.Windows.Forms.TextBox
    Public WithEvents txtNBBOPriceCap As System.Windows.Forms.TextBox
    Public WithEvents txtAuctionStrategy As System.Windows.Forms.TextBox
    Public WithEvents txtStartingPrice As System.Windows.Forms.TextBox
    Public WithEvents txtStockRefPrice As System.Windows.Forms.TextBox
    Public WithEvents txtDelta As System.Windows.Forms.TextBox
    Public WithEvents txtStockRangeLower As System.Windows.Forms.TextBox
    Public WithEvents txtStockRangeUpper As System.Windows.Forms.TextBox
    Public WithEvents txtAllOrNone As System.Windows.Forms.TextBox
    Public WithEvents txtOcaType As System.Windows.Forms.TextBox
    Public WithEvents txtShortSaleSlot As System.Windows.Forms.TextBox
    Public WithEvents txtDesignatedLocation As System.Windows.Forms.TextBox
    Public WithEvents txtDiscretionaryAmt As System.Windows.Forms.TextBox
    Public WithEvents cmdOk As System.Windows.Forms.Button
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    Public WithEvents txtHidden As System.Windows.Forms.TextBox
    Public WithEvents txtOutsideRth As System.Windows.Forms.TextBox
    Public WithEvents txtTriggerMethod As System.Windows.Forms.TextBox
    Public WithEvents txtDisplaySize As System.Windows.Forms.TextBox
    Public WithEvents txtSweepToFill As System.Windows.Forms.TextBox
    Public WithEvents txtBlockOrder As System.Windows.Forms.TextBox
    Public WithEvents txtTransmit As System.Windows.Forms.TextBox
    Public WithEvents txtParentId As System.Windows.Forms.TextBox
    Public WithEvents txtOrderRef As System.Windows.Forms.TextBox
    Public WithEvents txtOrigin As System.Windows.Forms.TextBox
    Public WithEvents txtOpenClose As System.Windows.Forms.TextBox
    Public WithEvents txtAccount As System.Windows.Forms.TextBox
    Public WithEvents txtOCA As System.Windows.Forms.TextBox
    Public WithEvents txtTIF As System.Windows.Forms.TextBox
    Public WithEvents Label35 As System.Windows.Forms.Label
    Public WithEvents Label34 As System.Windows.Forms.Label
    Public WithEvents Label33 As System.Windows.Forms.Label
    Public WithEvents Label32 As System.Windows.Forms.Label
    Public WithEvents Label31 As System.Windows.Forms.Label
    Public WithEvents Label30 As System.Windows.Forms.Label
    Public WithEvents Label29 As System.Windows.Forms.Label
    Public WithEvents Label28 As System.Windows.Forms.Label
    Public WithEvents Label27 As System.Windows.Forms.Label
    Public WithEvents Label26 As System.Windows.Forms.Label
    Public WithEvents Label25 As System.Windows.Forms.Label
    Public WithEvents Label24 As System.Windows.Forms.Label
    Public WithEvents Label23 As System.Windows.Forms.Label
    Public WithEvents Label20 As System.Windows.Forms.Label
    Public WithEvents Label19 As System.Windows.Forms.Label
    Public WithEvents Label17 As System.Windows.Forms.Label
    Public WithEvents Label16 As System.Windows.Forms.Label
    Public WithEvents Label15 As System.Windows.Forms.Label
    Public WithEvents Label14 As System.Windows.Forms.Label
    Public WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents Label10 As System.Windows.Forms.Label
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents Label8 As System.Windows.Forms.Label
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Public WithEvents txtVolatility As System.Windows.Forms.TextBox
    Public WithEvents txtVolatilityType As System.Windows.Forms.TextBox
    Public WithEvents txtContinuousUpdate As System.Windows.Forms.TextBox
    Public WithEvents txtReferencePriceType As System.Windows.Forms.TextBox
    Public WithEvents Label21 As System.Windows.Forms.Label
    Public WithEvents Label22 As System.Windows.Forms.Label
    Public WithEvents Label36 As System.Windows.Forms.Label
    Public WithEvents Label37 As System.Windows.Forms.Label
    Public WithEvents Label40 As System.Windows.Forms.Label
    Public WithEvents txtDeltaNeutralOrderType As System.Windows.Forms.TextBox
    Public WithEvents txtDeltaNeutralAuxPrice As System.Windows.Forms.TextBox
    Public WithEvents Label38 As System.Windows.Forms.Label
    Public WithEvents txtTrailStopPrice As System.Windows.Forms.TextBox
    Public WithEvents Label39 As System.Windows.Forms.Label
    Public WithEvents txtOverridePercentageConstraints As System.Windows.Forms.TextBox
    Public WithEvents txtScaleInitLevelSize As System.Windows.Forms.TextBox
    Public WithEvents txtScaleSubsLevelSize As System.Windows.Forms.TextBox
    Public WithEvents txtScalePriceIncr As System.Windows.Forms.TextBox
    Public WithEvents Label42 As System.Windows.Forms.Label
    Public WithEvents Label43 As System.Windows.Forms.Label
    Public WithEvents Label44 As System.Windows.Forms.Label
    Public WithEvents txtClearingAccount As System.Windows.Forms.TextBox
    Public WithEvents Label18 As System.Windows.Forms.Label
    Public WithEvents txtClearingIntent As System.Windows.Forms.TextBox
    Public WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents txtExemptCode As System.Windows.Forms.TextBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Public WithEvents txtHedgeType As System.Windows.Forms.TextBox
    Public WithEvents txtHedgeParam As System.Windows.Forms.TextBox
    Public WithEvents LabelHedgeType As System.Windows.Forms.Label
    Public WithEvents LabelHedgeParam As System.Windows.Forms.Label
    Friend WithEvents checkOptOutSmartRouting As System.Windows.Forms.CheckBox
    Public WithEvents Label47 As System.Windows.Forms.Label
    Public WithEvents Label48 As System.Windows.Forms.Label
    Public WithEvents Label49 As System.Windows.Forms.Label
    Public WithEvents Label50 As System.Windows.Forms.Label
    Public WithEvents txtDeltaNeutralConId As System.Windows.Forms.TextBox
    Public WithEvents txtDeltaNeutralClearingIntent As System.Windows.Forms.TextBox
    Public WithEvents txtDeltaNeutralClearingAccount As System.Windows.Forms.TextBox
    Public WithEvents txtDeltaNeutralSettlingFirm As System.Windows.Forms.TextBox
    Public WithEvents Label51 As System.Windows.Forms.Label
    Public WithEvents Label52 As System.Windows.Forms.Label
    Public WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents checkScaleAutoReset As System.Windows.Forms.CheckBox
    Public WithEvents txtScalePriceAdjustValue As System.Windows.Forms.TextBox
    Public WithEvents Label54 As System.Windows.Forms.Label
    Public WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents checkScaleRandomPercent As System.Windows.Forms.CheckBox
    Public WithEvents txtScalePriceAdjustInterval As System.Windows.Forms.TextBox
    Public WithEvents txtScaleInitPosition As System.Windows.Forms.TextBox
    Public WithEvents txtScaleInitFillQty As System.Windows.Forms.TextBox
    Public WithEvents txtScaleProfitOffset As System.Windows.Forms.TextBox
    Public WithEvents Label56 As System.Windows.Forms.Label
    Public WithEvents txtTrailingPercent As System.Windows.Forms.TextBox
    Public WithEvents txtDeltaNeutralOpenClose As System.Windows.Forms.TextBox
    Public WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents checkDeltaNeutralShortSale As System.Windows.Forms.CheckBox
    Public WithEvents txtDeltaNeutralShortSaleSlot As System.Windows.Forms.TextBox
    Public WithEvents Label58 As System.Windows.Forms.Label
    Public WithEvents txtDeltaNeutralDesignatedLocation As System.Windows.Forms.TextBox
    Public WithEvents Label59 As System.Windows.Forms.Label
    Public WithEvents txtActiveStopTime As System.Windows.Forms.TextBox
    Public WithEvents txtActiveStartTime As System.Windows.Forms.TextBox
    Public WithEvents txtScaleTable As System.Windows.Forms.TextBox
    Public WithEvents Label60 As System.Windows.Forms.Label
    Public WithEvents Label61 As System.Windows.Forms.Label
    Public WithEvents Label62 As System.Windows.Forms.Label
    Public WithEvents Label41 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtHedgeParam = New System.Windows.Forms.TextBox
        Me.txtRule80A = New System.Windows.Forms.TextBox
        Me.txtSettlingFirm = New System.Windows.Forms.TextBox
        Me.txtMinQty = New System.Windows.Forms.TextBox
        Me.txtPercentOffset = New System.Windows.Forms.TextBox
        Me.txtETradeOnly = New System.Windows.Forms.TextBox
        Me.txtFirmQuoteOnly = New System.Windows.Forms.TextBox
        Me.txtNBBOPriceCap = New System.Windows.Forms.TextBox
        Me.txtAuctionStrategy = New System.Windows.Forms.TextBox
        Me.txtStartingPrice = New System.Windows.Forms.TextBox
        Me.txtStockRefPrice = New System.Windows.Forms.TextBox
        Me.txtDelta = New System.Windows.Forms.TextBox
        Me.txtStockRangeLower = New System.Windows.Forms.TextBox
        Me.txtStockRangeUpper = New System.Windows.Forms.TextBox
        Me.txtAllOrNone = New System.Windows.Forms.TextBox
        Me.txtOcaType = New System.Windows.Forms.TextBox
        Me.txtShortSaleSlot = New System.Windows.Forms.TextBox
        Me.txtDesignatedLocation = New System.Windows.Forms.TextBox
        Me.txtDiscretionaryAmt = New System.Windows.Forms.TextBox
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.txtHidden = New System.Windows.Forms.TextBox
        Me.txtOutsideRth = New System.Windows.Forms.TextBox
        Me.txtTriggerMethod = New System.Windows.Forms.TextBox
        Me.txtDisplaySize = New System.Windows.Forms.TextBox
        Me.txtSweepToFill = New System.Windows.Forms.TextBox
        Me.txtBlockOrder = New System.Windows.Forms.TextBox
        Me.txtTransmit = New System.Windows.Forms.TextBox
        Me.txtParentId = New System.Windows.Forms.TextBox
        Me.txtOrderRef = New System.Windows.Forms.TextBox
        Me.txtOrigin = New System.Windows.Forms.TextBox
        Me.txtOpenClose = New System.Windows.Forms.TextBox
        Me.txtAccount = New System.Windows.Forms.TextBox
        Me.txtOCA = New System.Windows.Forms.TextBox
        Me.txtTIF = New System.Windows.Forms.TextBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtVolatility = New System.Windows.Forms.TextBox
        Me.txtVolatilityType = New System.Windows.Forms.TextBox
        Me.txtDeltaNeutralOrderType = New System.Windows.Forms.TextBox
        Me.txtContinuousUpdate = New System.Windows.Forms.TextBox
        Me.txtReferencePriceType = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.txtDeltaNeutralAuxPrice = New System.Windows.Forms.TextBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.txtTrailStopPrice = New System.Windows.Forms.TextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.txtOverridePercentageConstraints = New System.Windows.Forms.TextBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.txtScaleInitLevelSize = New System.Windows.Forms.TextBox
        Me.txtScaleSubsLevelSize = New System.Windows.Forms.TextBox
        Me.txtScalePriceIncr = New System.Windows.Forms.TextBox
        Me.Label42 = New System.Windows.Forms.Label
        Me.Label43 = New System.Windows.Forms.Label
        Me.Label44 = New System.Windows.Forms.Label
        Me.txtClearingAccount = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtClearingIntent = New System.Windows.Forms.TextBox
        Me.Label45 = New System.Windows.Forms.Label
        Me.txtExemptCode = New System.Windows.Forms.TextBox
        Me.Label46 = New System.Windows.Forms.Label
        Me.txtHedgeType = New System.Windows.Forms.TextBox
        Me.LabelHedgeType = New System.Windows.Forms.Label
        Me.LabelHedgeParam = New System.Windows.Forms.Label
        Me.checkOptOutSmartRouting = New System.Windows.Forms.CheckBox
        Me.Label47 = New System.Windows.Forms.Label
        Me.Label48 = New System.Windows.Forms.Label
        Me.Label49 = New System.Windows.Forms.Label
        Me.Label50 = New System.Windows.Forms.Label
        Me.txtDeltaNeutralConId = New System.Windows.Forms.TextBox
        Me.txtDeltaNeutralClearingIntent = New System.Windows.Forms.TextBox
        Me.txtDeltaNeutralClearingAccount = New System.Windows.Forms.TextBox
        Me.txtDeltaNeutralSettlingFirm = New System.Windows.Forms.TextBox
        Me.Label51 = New System.Windows.Forms.Label
        Me.Label52 = New System.Windows.Forms.Label
        Me.Label53 = New System.Windows.Forms.Label
        Me.checkScaleAutoReset = New System.Windows.Forms.CheckBox
        Me.txtScalePriceAdjustValue = New System.Windows.Forms.TextBox
        Me.Label54 = New System.Windows.Forms.Label
        Me.Label55 = New System.Windows.Forms.Label
        Me.checkScaleRandomPercent = New System.Windows.Forms.CheckBox
        Me.txtScalePriceAdjustInterval = New System.Windows.Forms.TextBox
        Me.txtScaleInitPosition = New System.Windows.Forms.TextBox
        Me.txtScaleInitFillQty = New System.Windows.Forms.TextBox
        Me.txtScaleProfitOffset = New System.Windows.Forms.TextBox
        Me.Label56 = New System.Windows.Forms.Label
        Me.txtTrailingPercent = New System.Windows.Forms.TextBox
        Me.txtDeltaNeutralOpenClose = New System.Windows.Forms.TextBox
        Me.Label57 = New System.Windows.Forms.Label
        Me.checkDeltaNeutralShortSale = New System.Windows.Forms.CheckBox
        Me.txtDeltaNeutralShortSaleSlot = New System.Windows.Forms.TextBox
        Me.Label58 = New System.Windows.Forms.Label
        Me.txtDeltaNeutralDesignatedLocation = New System.Windows.Forms.TextBox
        Me.Label59 = New System.Windows.Forms.Label
        Me.txtActiveStopTime = New System.Windows.Forms.TextBox
        Me.txtActiveStartTime = New System.Windows.Forms.TextBox
        Me.txtScaleTable = New System.Windows.Forms.TextBox
        Me.Label60 = New System.Windows.Forms.Label
        Me.Label61 = New System.Windows.Forms.Label
        Me.Label62 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtHedgeParam
        '
        Me.txtHedgeParam.AcceptsReturn = True
        Me.txtHedgeParam.BackColor = System.Drawing.SystemColors.Window
        Me.txtHedgeParam.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHedgeParam.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHedgeParam.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHedgeParam.Location = New System.Drawing.Point(143, 444)
        Me.txtHedgeParam.MaxLength = 0
        Me.txtHedgeParam.Name = "txtHedgeParam"
        Me.txtHedgeParam.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHedgeParam.Size = New System.Drawing.Size(85, 20)
        Me.txtHedgeParam.TabIndex = 37
        Me.ToolTip1.SetToolTip(Me.txtHedgeParam, "Allowed values are 'beta' for beta hedge and 'ratio' for pair hedge")
        '
        'txtRule80A
        '
        Me.txtRule80A.AcceptsReturn = True
        Me.txtRule80A.BackColor = System.Drawing.SystemColors.Window
        Me.txtRule80A.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRule80A.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRule80A.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRule80A.Location = New System.Drawing.Point(144, 394)
        Me.txtRule80A.MaxLength = 0
        Me.txtRule80A.Name = "txtRule80A"
        Me.txtRule80A.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRule80A.Size = New System.Drawing.Size(85, 20)
        Me.txtRule80A.TabIndex = 33
        '
        'txtSettlingFirm
        '
        Me.txtSettlingFirm.AcceptsReturn = True
        Me.txtSettlingFirm.BackColor = System.Drawing.SystemColors.Window
        Me.txtSettlingFirm.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSettlingFirm.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSettlingFirm.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSettlingFirm.Location = New System.Drawing.Point(144, 106)
        Me.txtSettlingFirm.MaxLength = 0
        Me.txtSettlingFirm.Name = "txtSettlingFirm"
        Me.txtSettlingFirm.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSettlingFirm.Size = New System.Drawing.Size(85, 20)
        Me.txtSettlingFirm.TabIndex = 9
        '
        'txtMinQty
        '
        Me.txtMinQty.AcceptsReturn = True
        Me.txtMinQty.BackColor = System.Drawing.SystemColors.Window
        Me.txtMinQty.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMinQty.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMinQty.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMinQty.Location = New System.Drawing.Point(432, 82)
        Me.txtMinQty.MaxLength = 0
        Me.txtMinQty.Name = "txtMinQty"
        Me.txtMinQty.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMinQty.Size = New System.Drawing.Size(85, 20)
        Me.txtMinQty.TabIndex = 46
        '
        'txtPercentOffset
        '
        Me.txtPercentOffset.AcceptsReturn = True
        Me.txtPercentOffset.BackColor = System.Drawing.SystemColors.Window
        Me.txtPercentOffset.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPercentOffset.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPercentOffset.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPercentOffset.Location = New System.Drawing.Point(432, 106)
        Me.txtPercentOffset.MaxLength = 0
        Me.txtPercentOffset.Name = "txtPercentOffset"
        Me.txtPercentOffset.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPercentOffset.Size = New System.Drawing.Size(85, 20)
        Me.txtPercentOffset.TabIndex = 48
        '
        'txtETradeOnly
        '
        Me.txtETradeOnly.AcceptsReturn = True
        Me.txtETradeOnly.BackColor = System.Drawing.SystemColors.Window
        Me.txtETradeOnly.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtETradeOnly.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtETradeOnly.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtETradeOnly.Location = New System.Drawing.Point(432, 130)
        Me.txtETradeOnly.MaxLength = 0
        Me.txtETradeOnly.Name = "txtETradeOnly"
        Me.txtETradeOnly.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtETradeOnly.Size = New System.Drawing.Size(85, 20)
        Me.txtETradeOnly.TabIndex = 50
        Me.txtETradeOnly.Text = "0"
        '
        'txtFirmQuoteOnly
        '
        Me.txtFirmQuoteOnly.AcceptsReturn = True
        Me.txtFirmQuoteOnly.BackColor = System.Drawing.SystemColors.Window
        Me.txtFirmQuoteOnly.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFirmQuoteOnly.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirmQuoteOnly.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFirmQuoteOnly.Location = New System.Drawing.Point(432, 154)
        Me.txtFirmQuoteOnly.MaxLength = 0
        Me.txtFirmQuoteOnly.Name = "txtFirmQuoteOnly"
        Me.txtFirmQuoteOnly.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFirmQuoteOnly.Size = New System.Drawing.Size(85, 20)
        Me.txtFirmQuoteOnly.TabIndex = 52
        Me.txtFirmQuoteOnly.Text = "0"
        '
        'txtNBBOPriceCap
        '
        Me.txtNBBOPriceCap.AcceptsReturn = True
        Me.txtNBBOPriceCap.BackColor = System.Drawing.SystemColors.Window
        Me.txtNBBOPriceCap.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNBBOPriceCap.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNBBOPriceCap.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtNBBOPriceCap.Location = New System.Drawing.Point(432, 178)
        Me.txtNBBOPriceCap.MaxLength = 0
        Me.txtNBBOPriceCap.Name = "txtNBBOPriceCap"
        Me.txtNBBOPriceCap.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNBBOPriceCap.Size = New System.Drawing.Size(85, 20)
        Me.txtNBBOPriceCap.TabIndex = 54
        '
        'txtAuctionStrategy
        '
        Me.txtAuctionStrategy.AcceptsReturn = True
        Me.txtAuctionStrategy.BackColor = System.Drawing.SystemColors.Window
        Me.txtAuctionStrategy.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAuctionStrategy.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAuctionStrategy.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAuctionStrategy.Location = New System.Drawing.Point(432, 370)
        Me.txtAuctionStrategy.MaxLength = 0
        Me.txtAuctionStrategy.Name = "txtAuctionStrategy"
        Me.txtAuctionStrategy.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAuctionStrategy.Size = New System.Drawing.Size(85, 20)
        Me.txtAuctionStrategy.TabIndex = 70
        Me.txtAuctionStrategy.Text = "0"
        '
        'txtStartingPrice
        '
        Me.txtStartingPrice.AcceptsReturn = True
        Me.txtStartingPrice.BackColor = System.Drawing.SystemColors.Window
        Me.txtStartingPrice.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStartingPrice.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStartingPrice.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStartingPrice.Location = New System.Drawing.Point(432, 394)
        Me.txtStartingPrice.MaxLength = 0
        Me.txtStartingPrice.Name = "txtStartingPrice"
        Me.txtStartingPrice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStartingPrice.Size = New System.Drawing.Size(85, 20)
        Me.txtStartingPrice.TabIndex = 72
        '
        'txtStockRefPrice
        '
        Me.txtStockRefPrice.AcceptsReturn = True
        Me.txtStockRefPrice.BackColor = System.Drawing.SystemColors.Window
        Me.txtStockRefPrice.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStockRefPrice.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockRefPrice.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStockRefPrice.Location = New System.Drawing.Point(432, 418)
        Me.txtStockRefPrice.MaxLength = 0
        Me.txtStockRefPrice.Name = "txtStockRefPrice"
        Me.txtStockRefPrice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStockRefPrice.Size = New System.Drawing.Size(85, 20)
        Me.txtStockRefPrice.TabIndex = 74
        '
        'txtDelta
        '
        Me.txtDelta.AcceptsReturn = True
        Me.txtDelta.BackColor = System.Drawing.SystemColors.Window
        Me.txtDelta.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDelta.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDelta.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDelta.Location = New System.Drawing.Point(432, 442)
        Me.txtDelta.MaxLength = 0
        Me.txtDelta.Name = "txtDelta"
        Me.txtDelta.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDelta.Size = New System.Drawing.Size(85, 20)
        Me.txtDelta.TabIndex = 76
        '
        'txtStockRangeLower
        '
        Me.txtStockRangeLower.AcceptsReturn = True
        Me.txtStockRangeLower.BackColor = System.Drawing.SystemColors.Window
        Me.txtStockRangeLower.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStockRangeLower.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockRangeLower.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStockRangeLower.Location = New System.Drawing.Point(432, 468)
        Me.txtStockRangeLower.MaxLength = 0
        Me.txtStockRangeLower.Name = "txtStockRangeLower"
        Me.txtStockRangeLower.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStockRangeLower.Size = New System.Drawing.Size(85, 20)
        Me.txtStockRangeLower.TabIndex = 78
        '
        'txtStockRangeUpper
        '
        Me.txtStockRangeUpper.AcceptsReturn = True
        Me.txtStockRangeUpper.BackColor = System.Drawing.SystemColors.Window
        Me.txtStockRangeUpper.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStockRangeUpper.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockRangeUpper.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtStockRangeUpper.Location = New System.Drawing.Point(432, 494)
        Me.txtStockRangeUpper.MaxLength = 0
        Me.txtStockRangeUpper.Name = "txtStockRangeUpper"
        Me.txtStockRangeUpper.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtStockRangeUpper.Size = New System.Drawing.Size(85, 20)
        Me.txtStockRangeUpper.TabIndex = 80
        '
        'txtAllOrNone
        '
        Me.txtAllOrNone.AcceptsReturn = True
        Me.txtAllOrNone.BackColor = System.Drawing.SystemColors.Window
        Me.txtAllOrNone.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAllOrNone.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAllOrNone.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAllOrNone.Location = New System.Drawing.Point(432, 58)
        Me.txtAllOrNone.MaxLength = 0
        Me.txtAllOrNone.Name = "txtAllOrNone"
        Me.txtAllOrNone.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAllOrNone.Size = New System.Drawing.Size(85, 20)
        Me.txtAllOrNone.TabIndex = 44
        Me.txtAllOrNone.Text = "0"
        '
        'txtOcaType
        '
        Me.txtOcaType.AcceptsReturn = True
        Me.txtOcaType.BackColor = System.Drawing.SystemColors.Window
        Me.txtOcaType.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOcaType.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOcaType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOcaType.Location = New System.Drawing.Point(144, 58)
        Me.txtOcaType.MaxLength = 0
        Me.txtOcaType.Name = "txtOcaType"
        Me.txtOcaType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtOcaType.Size = New System.Drawing.Size(85, 20)
        Me.txtOcaType.TabIndex = 5
        Me.txtOcaType.Text = "0"
        '
        'txtShortSaleSlot
        '
        Me.txtShortSaleSlot.AcceptsReturn = True
        Me.txtShortSaleSlot.BackColor = System.Drawing.SystemColors.Window
        Me.txtShortSaleSlot.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtShortSaleSlot.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShortSaleSlot.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtShortSaleSlot.Location = New System.Drawing.Point(432, 346)
        Me.txtShortSaleSlot.MaxLength = 0
        Me.txtShortSaleSlot.Name = "txtShortSaleSlot"
        Me.txtShortSaleSlot.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtShortSaleSlot.Size = New System.Drawing.Size(85, 20)
        Me.txtShortSaleSlot.TabIndex = 68
        '
        'txtDesignatedLocation
        '
        Me.txtDesignatedLocation.AcceptsReturn = True
        Me.txtDesignatedLocation.BackColor = System.Drawing.SystemColors.Window
        Me.txtDesignatedLocation.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDesignatedLocation.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesignatedLocation.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDesignatedLocation.Location = New System.Drawing.Point(144, 346)
        Me.txtDesignatedLocation.MaxLength = 0
        Me.txtDesignatedLocation.Name = "txtDesignatedLocation"
        Me.txtDesignatedLocation.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDesignatedLocation.Size = New System.Drawing.Size(85, 20)
        Me.txtDesignatedLocation.TabIndex = 29
        '
        'txtDiscretionaryAmt
        '
        Me.txtDiscretionaryAmt.AcceptsReturn = True
        Me.txtDiscretionaryAmt.BackColor = System.Drawing.SystemColors.Window
        Me.txtDiscretionaryAmt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDiscretionaryAmt.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiscretionaryAmt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDiscretionaryAmt.Location = New System.Drawing.Point(432, 322)
        Me.txtDiscretionaryAmt.MaxLength = 0
        Me.txtDiscretionaryAmt.Name = "txtDiscretionaryAmt"
        Me.txtDiscretionaryAmt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDiscretionaryAmt.Size = New System.Drawing.Size(85, 20)
        Me.txtDiscretionaryAmt.TabIndex = 66
        Me.txtDiscretionaryAmt.Text = "0"
        '
        'cmdOk
        '
        Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOk.Location = New System.Drawing.Point(345, 599)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOk.Size = New System.Drawing.Size(73, 25)
        Me.cmdOk.TabIndex = 132
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(456, 599)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancel.TabIndex = 133
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'txtHidden
        '
        Me.txtHidden.AcceptsReturn = True
        Me.txtHidden.BackColor = System.Drawing.SystemColors.Window
        Me.txtHidden.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHidden.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHidden.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHidden.Location = New System.Drawing.Point(432, 298)
        Me.txtHidden.MaxLength = 0
        Me.txtHidden.Name = "txtHidden"
        Me.txtHidden.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHidden.Size = New System.Drawing.Size(85, 20)
        Me.txtHidden.TabIndex = 64
        Me.txtHidden.Text = "0"
        '
        'txtOutsideRth
        '
        Me.txtOutsideRth.AcceptsReturn = True
        Me.txtOutsideRth.BackColor = System.Drawing.SystemColors.Window
        Me.txtOutsideRth.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOutsideRth.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOutsideRth.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOutsideRth.Location = New System.Drawing.Point(432, 274)
        Me.txtOutsideRth.MaxLength = 0
        Me.txtOutsideRth.Name = "txtOutsideRth"
        Me.txtOutsideRth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtOutsideRth.Size = New System.Drawing.Size(85, 20)
        Me.txtOutsideRth.TabIndex = 62
        Me.txtOutsideRth.Text = "0"
        '
        'txtTriggerMethod
        '
        Me.txtTriggerMethod.AcceptsReturn = True
        Me.txtTriggerMethod.BackColor = System.Drawing.SystemColors.Window
        Me.txtTriggerMethod.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTriggerMethod.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTriggerMethod.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTriggerMethod.Location = New System.Drawing.Point(432, 250)
        Me.txtTriggerMethod.MaxLength = 0
        Me.txtTriggerMethod.Name = "txtTriggerMethod"
        Me.txtTriggerMethod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTriggerMethod.Size = New System.Drawing.Size(85, 20)
        Me.txtTriggerMethod.TabIndex = 60
        Me.txtTriggerMethod.Text = "0"
        '
        'txtDisplaySize
        '
        Me.txtDisplaySize.AcceptsReturn = True
        Me.txtDisplaySize.BackColor = System.Drawing.SystemColors.Window
        Me.txtDisplaySize.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDisplaySize.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDisplaySize.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDisplaySize.Location = New System.Drawing.Point(432, 226)
        Me.txtDisplaySize.MaxLength = 0
        Me.txtDisplaySize.Name = "txtDisplaySize"
        Me.txtDisplaySize.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDisplaySize.Size = New System.Drawing.Size(85, 20)
        Me.txtDisplaySize.TabIndex = 58
        Me.txtDisplaySize.Text = "0"
        '
        'txtSweepToFill
        '
        Me.txtSweepToFill.AcceptsReturn = True
        Me.txtSweepToFill.BackColor = System.Drawing.SystemColors.Window
        Me.txtSweepToFill.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSweepToFill.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSweepToFill.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSweepToFill.Location = New System.Drawing.Point(144, 322)
        Me.txtSweepToFill.MaxLength = 0
        Me.txtSweepToFill.Name = "txtSweepToFill"
        Me.txtSweepToFill.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSweepToFill.Size = New System.Drawing.Size(85, 20)
        Me.txtSweepToFill.TabIndex = 27
        Me.txtSweepToFill.Text = "0"
        '
        'txtBlockOrder
        '
        Me.txtBlockOrder.AcceptsReturn = True
        Me.txtBlockOrder.BackColor = System.Drawing.SystemColors.Window
        Me.txtBlockOrder.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBlockOrder.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBlockOrder.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBlockOrder.Location = New System.Drawing.Point(144, 298)
        Me.txtBlockOrder.MaxLength = 0
        Me.txtBlockOrder.Name = "txtBlockOrder"
        Me.txtBlockOrder.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBlockOrder.Size = New System.Drawing.Size(85, 20)
        Me.txtBlockOrder.TabIndex = 25
        Me.txtBlockOrder.Text = "0"
        '
        'txtTransmit
        '
        Me.txtTransmit.AcceptsReturn = True
        Me.txtTransmit.BackColor = System.Drawing.SystemColors.Window
        Me.txtTransmit.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTransmit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransmit.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTransmit.Location = New System.Drawing.Point(144, 274)
        Me.txtTransmit.MaxLength = 0
        Me.txtTransmit.Name = "txtTransmit"
        Me.txtTransmit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTransmit.Size = New System.Drawing.Size(85, 20)
        Me.txtTransmit.TabIndex = 23
        Me.txtTransmit.Text = "1"
        '
        'txtParentId
        '
        Me.txtParentId.AcceptsReturn = True
        Me.txtParentId.BackColor = System.Drawing.SystemColors.Window
        Me.txtParentId.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtParentId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtParentId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtParentId.Location = New System.Drawing.Point(144, 250)
        Me.txtParentId.MaxLength = 0
        Me.txtParentId.Name = "txtParentId"
        Me.txtParentId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtParentId.Size = New System.Drawing.Size(85, 20)
        Me.txtParentId.TabIndex = 21
        Me.txtParentId.Text = "0"
        '
        'txtOrderRef
        '
        Me.txtOrderRef.AcceptsReturn = True
        Me.txtOrderRef.BackColor = System.Drawing.SystemColors.Window
        Me.txtOrderRef.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOrderRef.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrderRef.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOrderRef.Location = New System.Drawing.Point(144, 226)
        Me.txtOrderRef.MaxLength = 0
        Me.txtOrderRef.Name = "txtOrderRef"
        Me.txtOrderRef.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtOrderRef.Size = New System.Drawing.Size(85, 20)
        Me.txtOrderRef.TabIndex = 19
        '
        'txtOrigin
        '
        Me.txtOrigin.AcceptsReturn = True
        Me.txtOrigin.BackColor = System.Drawing.SystemColors.Window
        Me.txtOrigin.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOrigin.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrigin.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOrigin.Location = New System.Drawing.Point(144, 202)
        Me.txtOrigin.MaxLength = 0
        Me.txtOrigin.Name = "txtOrigin"
        Me.txtOrigin.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtOrigin.Size = New System.Drawing.Size(85, 20)
        Me.txtOrigin.TabIndex = 17
        Me.txtOrigin.Text = "0"
        '
        'txtOpenClose
        '
        Me.txtOpenClose.AcceptsReturn = True
        Me.txtOpenClose.BackColor = System.Drawing.SystemColors.Window
        Me.txtOpenClose.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOpenClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOpenClose.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOpenClose.Location = New System.Drawing.Point(144, 178)
        Me.txtOpenClose.MaxLength = 0
        Me.txtOpenClose.Name = "txtOpenClose"
        Me.txtOpenClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtOpenClose.Size = New System.Drawing.Size(85, 20)
        Me.txtOpenClose.TabIndex = 15
        Me.txtOpenClose.Text = "O"
        '
        'txtAccount
        '
        Me.txtAccount.AcceptsReturn = True
        Me.txtAccount.BackColor = System.Drawing.SystemColors.Window
        Me.txtAccount.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAccount.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccount.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAccount.Location = New System.Drawing.Point(144, 82)
        Me.txtAccount.MaxLength = 0
        Me.txtAccount.Name = "txtAccount"
        Me.txtAccount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAccount.Size = New System.Drawing.Size(85, 20)
        Me.txtAccount.TabIndex = 7
        '
        'txtOCA
        '
        Me.txtOCA.AcceptsReturn = True
        Me.txtOCA.BackColor = System.Drawing.SystemColors.Window
        Me.txtOCA.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOCA.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOCA.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOCA.Location = New System.Drawing.Point(144, 34)
        Me.txtOCA.MaxLength = 0
        Me.txtOCA.Name = "txtOCA"
        Me.txtOCA.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtOCA.Size = New System.Drawing.Size(85, 20)
        Me.txtOCA.TabIndex = 3
        '
        'txtTIF
        '
        Me.txtTIF.AcceptsReturn = True
        Me.txtTIF.BackColor = System.Drawing.SystemColors.Window
        Me.txtTIF.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTIF.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTIF.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTIF.Location = New System.Drawing.Point(144, 10)
        Me.txtTIF.MaxLength = 0
        Me.txtTIF.Name = "txtTIF"
        Me.txtTIF.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTIF.Size = New System.Drawing.Size(85, 20)
        Me.txtTIF.TabIndex = 1
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.SystemColors.Control
        Me.Label35.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label35.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label35.Location = New System.Drawing.Point(16, 396)
        Me.Label35.Name = "Label35"
        Me.Label35.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label35.Size = New System.Drawing.Size(73, 17)
        Me.Label35.TabIndex = 32
        Me.Label35.Text = "Rule 80 A"
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.SystemColors.Control
        Me.Label34.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label34.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label34.Location = New System.Drawing.Point(16, 108)
        Me.Label34.Name = "Label34"
        Me.Label34.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label34.Size = New System.Drawing.Size(73, 17)
        Me.Label34.TabIndex = 8
        Me.Label34.Text = "Settling Firm"
        '
        'Label33
        '
        Me.Label33.BackColor = System.Drawing.SystemColors.Control
        Me.Label33.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label33.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label33.Location = New System.Drawing.Point(264, 83)
        Me.Label33.Name = "Label33"
        Me.Label33.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label33.Size = New System.Drawing.Size(121, 17)
        Me.Label33.TabIndex = 45
        Me.Label33.Text = "Minimum Quantity"
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.SystemColors.Control
        Me.Label32.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label32.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label32.Location = New System.Drawing.Point(264, 108)
        Me.Label32.Name = "Label32"
        Me.Label32.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label32.Size = New System.Drawing.Size(105, 17)
        Me.Label32.TabIndex = 47
        Me.Label32.Text = "Percent Offset"
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.SystemColors.Control
        Me.Label31.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label31.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label31.Location = New System.Drawing.Point(264, 132)
        Me.Label31.Name = "Label31"
        Me.Label31.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label31.Size = New System.Drawing.Size(136, 17)
        Me.Label31.TabIndex = 49
        Me.Label31.Text = "Electronic Exchange Only"
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.SystemColors.Control
        Me.Label30.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label30.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.Location = New System.Drawing.Point(264, 156)
        Me.Label30.Name = "Label30"
        Me.Label30.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label30.Size = New System.Drawing.Size(105, 17)
        Me.Label30.TabIndex = 51
        Me.Label30.Text = "Firm Quote Only"
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.SystemColors.Control
        Me.Label29.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label29.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label29.Location = New System.Drawing.Point(264, 180)
        Me.Label29.Name = "Label29"
        Me.Label29.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label29.Size = New System.Drawing.Size(105, 17)
        Me.Label29.TabIndex = 53
        Me.Label29.Text = "NBBO Price Cap"
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.SystemColors.Control
        Me.Label28.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label28.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label28.Location = New System.Drawing.Point(264, 372)
        Me.Label28.Name = "Label28"
        Me.Label28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label28.Size = New System.Drawing.Size(120, 17)
        Me.Label28.TabIndex = 69
        Me.Label28.Text = "BOX: Auction Strategy"
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.SystemColors.Control
        Me.Label27.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label27.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label27.Location = New System.Drawing.Point(264, 397)
        Me.Label27.Name = "Label27"
        Me.Label27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label27.Size = New System.Drawing.Size(113, 17)
        Me.Label27.TabIndex = 71
        Me.Label27.Text = "BOX: Starting Price"
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.SystemColors.Control
        Me.Label26.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label26.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(264, 420)
        Me.Label26.Name = "Label26"
        Me.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label26.Size = New System.Drawing.Size(113, 17)
        Me.Label26.TabIndex = 73
        Me.Label26.Text = "BOX: Stock Ref Price"
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.SystemColors.Control
        Me.Label25.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label25.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(264, 445)
        Me.Label25.Name = "Label25"
        Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label25.Size = New System.Drawing.Size(73, 17)
        Me.Label25.TabIndex = 75
        Me.Label25.Text = "BOX: Delta"
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.SystemColors.Control
        Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label24.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(264, 471)
        Me.Label24.Name = "Label24"
        Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label24.Size = New System.Drawing.Size(160, 17)
        Me.Label24.TabIndex = 77
        Me.Label24.Text = "BOX/VOL: Stock Range Lower"
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.SystemColors.Control
        Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label23.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(264, 497)
        Me.Label23.Name = "Label23"
        Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label23.Size = New System.Drawing.Size(160, 17)
        Me.Label23.TabIndex = 79
        Me.Label23.Text = "BOX/VOL: Stock Range Upper"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.SystemColors.Control
        Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label20.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(264, 59)
        Me.Label20.Name = "Label20"
        Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label20.Size = New System.Drawing.Size(73, 17)
        Me.Label20.TabIndex = 43
        Me.Label20.Text = "All or None"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.SystemColors.Control
        Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(16, 59)
        Me.Label19.Name = "Label19"
        Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label19.Size = New System.Drawing.Size(65, 17)
        Me.Label19.TabIndex = 4
        Me.Label19.Text = "OCA type"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.Control
        Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(264, 348)
        Me.Label17.Name = "Label17"
        Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label17.Size = New System.Drawing.Size(152, 17)
        Me.Label17.TabIndex = 67
        Me.Label17.Text = "Short Sales Slot"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.SystemColors.Control
        Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(16, 348)
        Me.Label16.Name = "Label16"
        Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label16.Size = New System.Drawing.Size(113, 17)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "Designated Location"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.SystemColors.Control
        Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(264, 324)
        Me.Label15.Name = "Label15"
        Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label15.Size = New System.Drawing.Size(152, 17)
        Me.Label15.TabIndex = 65
        Me.Label15.Text = "Discretionary Amt"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.Control
        Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(264, 300)
        Me.Label14.Name = "Label14"
        Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label14.Size = New System.Drawing.Size(65, 17)
        Me.Label14.TabIndex = 63
        Me.Label14.Text = "Hidden"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(264, 276)
        Me.Label13.Name = "Label13"
        Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label13.Size = New System.Drawing.Size(81, 15)
        Me.Label13.TabIndex = 61
        Me.Label13.Text = "Outside RTH"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.Control
        Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(264, 252)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(88, 17)
        Me.Label12.TabIndex = 59
        Me.Label12.Text = "Trigger Method"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(264, 228)
        Me.Label11.Name = "Label11"
        Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label11.Size = New System.Drawing.Size(65, 17)
        Me.Label11.TabIndex = 57
        Me.Label11.Text = "Display Size"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(16, 324)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(88, 17)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "Sweep to Fill"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(16, 300)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(65, 17)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Block Order"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(16, 276)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label8.Size = New System.Drawing.Size(65, 17)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Transmit"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(16, 252)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(65, 17)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Parent Id"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(16, 228)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(65, 17)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Order Ref"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(16, 204)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(65, 17)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Origin"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(16, 180)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(65, 17)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Open/Close"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(16, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(65, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Account"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(16, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(65, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "OCA group"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(88, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Time in Force"
        '
        'txtVolatility
        '
        Me.txtVolatility.AcceptsReturn = True
        Me.txtVolatility.BackColor = System.Drawing.SystemColors.Window
        Me.txtVolatility.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVolatility.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVolatility.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtVolatility.Location = New System.Drawing.Point(753, 10)
        Me.txtVolatility.MaxLength = 0
        Me.txtVolatility.Name = "txtVolatility"
        Me.txtVolatility.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVolatility.Size = New System.Drawing.Size(85, 20)
        Me.txtVolatility.TabIndex = 88
        '
        'txtVolatilityType
        '
        Me.txtVolatilityType.AcceptsReturn = True
        Me.txtVolatilityType.BackColor = System.Drawing.SystemColors.Window
        Me.txtVolatilityType.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVolatilityType.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVolatilityType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtVolatilityType.Location = New System.Drawing.Point(753, 34)
        Me.txtVolatilityType.MaxLength = 0
        Me.txtVolatilityType.Name = "txtVolatilityType"
        Me.txtVolatilityType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtVolatilityType.Size = New System.Drawing.Size(85, 20)
        Me.txtVolatilityType.TabIndex = 90
        '
        'txtDeltaNeutralOrderType
        '
        Me.txtDeltaNeutralOrderType.AcceptsReturn = True
        Me.txtDeltaNeutralOrderType.BackColor = System.Drawing.SystemColors.Window
        Me.txtDeltaNeutralOrderType.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDeltaNeutralOrderType.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeltaNeutralOrderType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDeltaNeutralOrderType.Location = New System.Drawing.Point(753, 58)
        Me.txtDeltaNeutralOrderType.MaxLength = 0
        Me.txtDeltaNeutralOrderType.Name = "txtDeltaNeutralOrderType"
        Me.txtDeltaNeutralOrderType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDeltaNeutralOrderType.Size = New System.Drawing.Size(85, 20)
        Me.txtDeltaNeutralOrderType.TabIndex = 92
        '
        'txtContinuousUpdate
        '
        Me.txtContinuousUpdate.AcceptsReturn = True
        Me.txtContinuousUpdate.BackColor = System.Drawing.SystemColors.Window
        Me.txtContinuousUpdate.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtContinuousUpdate.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContinuousUpdate.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtContinuousUpdate.Location = New System.Drawing.Point(753, 298)
        Me.txtContinuousUpdate.MaxLength = 0
        Me.txtContinuousUpdate.Name = "txtContinuousUpdate"
        Me.txtContinuousUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtContinuousUpdate.Size = New System.Drawing.Size(85, 20)
        Me.txtContinuousUpdate.TabIndex = 111
        '
        'txtReferencePriceType
        '
        Me.txtReferencePriceType.AcceptsReturn = True
        Me.txtReferencePriceType.BackColor = System.Drawing.SystemColors.Window
        Me.txtReferencePriceType.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtReferencePriceType.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReferencePriceType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtReferencePriceType.Location = New System.Drawing.Point(753, 322)
        Me.txtReferencePriceType.MaxLength = 0
        Me.txtReferencePriceType.Name = "txtReferencePriceType"
        Me.txtReferencePriceType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtReferencePriceType.Size = New System.Drawing.Size(85, 20)
        Me.txtReferencePriceType.TabIndex = 113
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.SystemColors.Control
        Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label21.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(550, 11)
        Me.Label21.Name = "Label21"
        Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label21.Size = New System.Drawing.Size(105, 17)
        Me.Label21.TabIndex = 87
        Me.Label21.Text = "VOL: Volatility"
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.SystemColors.Control
        Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label22.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(550, 35)
        Me.Label22.Name = "Label22"
        Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label22.Size = New System.Drawing.Size(144, 16)
        Me.Label22.TabIndex = 89
        Me.Label22.Text = "VOL: Volatility Type (1 or 2)"
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.SystemColors.Control
        Me.Label36.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label36.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label36.Location = New System.Drawing.Point(550, 59)
        Me.Label36.Name = "Label36"
        Me.Label36.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label36.Size = New System.Drawing.Size(152, 17)
        Me.Label36.TabIndex = 91
        Me.Label36.Text = "VOL: Hedge Delta Order Type"
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.SystemColors.Control
        Me.Label37.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label37.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label37.Location = New System.Drawing.Point(550, 300)
        Me.Label37.Name = "Label37"
        Me.Label37.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label37.Size = New System.Drawing.Size(128, 17)
        Me.Label37.TabIndex = 110
        Me.Label37.Text = "VOL: Continuous Update"
        '
        'Label40
        '
        Me.Label40.BackColor = System.Drawing.SystemColors.Control
        Me.Label40.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label40.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label40.Location = New System.Drawing.Point(550, 324)
        Me.Label40.Name = "Label40"
        Me.Label40.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label40.Size = New System.Drawing.Size(181, 19)
        Me.Label40.TabIndex = 112
        Me.Label40.Text = "VOL: Reference Price Type (1 or 2)"
        '
        'txtDeltaNeutralAuxPrice
        '
        Me.txtDeltaNeutralAuxPrice.AcceptsReturn = True
        Me.txtDeltaNeutralAuxPrice.BackColor = System.Drawing.SystemColors.Window
        Me.txtDeltaNeutralAuxPrice.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDeltaNeutralAuxPrice.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeltaNeutralAuxPrice.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDeltaNeutralAuxPrice.Location = New System.Drawing.Point(753, 82)
        Me.txtDeltaNeutralAuxPrice.MaxLength = 0
        Me.txtDeltaNeutralAuxPrice.Name = "txtDeltaNeutralAuxPrice"
        Me.txtDeltaNeutralAuxPrice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDeltaNeutralAuxPrice.Size = New System.Drawing.Size(85, 20)
        Me.txtDeltaNeutralAuxPrice.TabIndex = 94
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.SystemColors.Control
        Me.Label38.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label38.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label38.Location = New System.Drawing.Point(550, 84)
        Me.Label38.Name = "Label38"
        Me.Label38.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label38.Size = New System.Drawing.Size(152, 17)
        Me.Label38.TabIndex = 93
        Me.Label38.Text = "VOL: Hedge Delta Aux Price"
        '
        'txtTrailStopPrice
        '
        Me.txtTrailStopPrice.AcceptsReturn = True
        Me.txtTrailStopPrice.BackColor = System.Drawing.SystemColors.Window
        Me.txtTrailStopPrice.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTrailStopPrice.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTrailStopPrice.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTrailStopPrice.Location = New System.Drawing.Point(432, 10)
        Me.txtTrailStopPrice.MaxLength = 0
        Me.txtTrailStopPrice.Name = "txtTrailStopPrice"
        Me.txtTrailStopPrice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTrailStopPrice.Size = New System.Drawing.Size(85, 20)
        Me.txtTrailStopPrice.TabIndex = 40
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.SystemColors.Control
        Me.Label39.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label39.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label39.Location = New System.Drawing.Point(264, 11)
        Me.Label39.Name = "Label39"
        Me.Label39.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label39.Size = New System.Drawing.Size(96, 17)
        Me.Label39.TabIndex = 39
        Me.Label39.Text = "Trail Stop Price"
        '
        'txtOverridePercentageConstraints
        '
        Me.txtOverridePercentageConstraints.AcceptsReturn = True
        Me.txtOverridePercentageConstraints.BackColor = System.Drawing.SystemColors.Window
        Me.txtOverridePercentageConstraints.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOverridePercentageConstraints.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOverridePercentageConstraints.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOverridePercentageConstraints.Location = New System.Drawing.Point(432, 202)
        Me.txtOverridePercentageConstraints.MaxLength = 0
        Me.txtOverridePercentageConstraints.Name = "txtOverridePercentageConstraints"
        Me.txtOverridePercentageConstraints.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtOverridePercentageConstraints.Size = New System.Drawing.Size(85, 20)
        Me.txtOverridePercentageConstraints.TabIndex = 56
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.SystemColors.Control
        Me.Label41.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label41.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label41.Location = New System.Drawing.Point(264, 204)
        Me.Label41.Name = "Label41"
        Me.Label41.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label41.Size = New System.Drawing.Size(168, 17)
        Me.Label41.TabIndex = 55
        Me.Label41.Text = "Override Percentage Constraints"
        '
        'txtScaleInitLevelSize
        '
        Me.txtScaleInitLevelSize.AcceptsReturn = True
        Me.txtScaleInitLevelSize.BackColor = System.Drawing.SystemColors.Window
        Me.txtScaleInitLevelSize.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtScaleInitLevelSize.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtScaleInitLevelSize.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtScaleInitLevelSize.Location = New System.Drawing.Point(753, 346)
        Me.txtScaleInitLevelSize.MaxLength = 0
        Me.txtScaleInitLevelSize.Name = "txtScaleInitLevelSize"
        Me.txtScaleInitLevelSize.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtScaleInitLevelSize.Size = New System.Drawing.Size(85, 20)
        Me.txtScaleInitLevelSize.TabIndex = 115
        '
        'txtScaleSubsLevelSize
        '
        Me.txtScaleSubsLevelSize.AcceptsReturn = True
        Me.txtScaleSubsLevelSize.BackColor = System.Drawing.SystemColors.Window
        Me.txtScaleSubsLevelSize.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtScaleSubsLevelSize.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtScaleSubsLevelSize.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtScaleSubsLevelSize.Location = New System.Drawing.Point(753, 370)
        Me.txtScaleSubsLevelSize.MaxLength = 0
        Me.txtScaleSubsLevelSize.Name = "txtScaleSubsLevelSize"
        Me.txtScaleSubsLevelSize.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtScaleSubsLevelSize.Size = New System.Drawing.Size(85, 20)
        Me.txtScaleSubsLevelSize.TabIndex = 117
        '
        'txtScalePriceIncr
        '
        Me.txtScalePriceIncr.AcceptsReturn = True
        Me.txtScalePriceIncr.BackColor = System.Drawing.SystemColors.Window
        Me.txtScalePriceIncr.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtScalePriceIncr.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtScalePriceIncr.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtScalePriceIncr.Location = New System.Drawing.Point(753, 394)
        Me.txtScalePriceIncr.MaxLength = 0
        Me.txtScalePriceIncr.Name = "txtScalePriceIncr"
        Me.txtScalePriceIncr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtScalePriceIncr.Size = New System.Drawing.Size(85, 20)
        Me.txtScalePriceIncr.TabIndex = 119
        '
        'Label42
        '
        Me.Label42.BackColor = System.Drawing.SystemColors.Control
        Me.Label42.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label42.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label42.Location = New System.Drawing.Point(550, 348)
        Me.Label42.Name = "Label42"
        Me.Label42.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label42.Size = New System.Drawing.Size(128, 17)
        Me.Label42.TabIndex = 114
        Me.Label42.Text = "SCALE: Init Level Size"
        '
        'Label43
        '
        Me.Label43.BackColor = System.Drawing.SystemColors.Control
        Me.Label43.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label43.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label43.Location = New System.Drawing.Point(550, 372)
        Me.Label43.Name = "Label43"
        Me.Label43.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label43.Size = New System.Drawing.Size(128, 17)
        Me.Label43.TabIndex = 116
        Me.Label43.Text = "SCALE: Subs Level Size"
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.SystemColors.Control
        Me.Label44.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label44.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label44.Location = New System.Drawing.Point(550, 396)
        Me.Label44.Name = "Label44"
        Me.Label44.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label44.Size = New System.Drawing.Size(128, 17)
        Me.Label44.TabIndex = 118
        Me.Label44.Text = "SCALE: Price Increment"
        '
        'txtClearingAccount
        '
        Me.txtClearingAccount.AcceptsReturn = True
        Me.txtClearingAccount.BackColor = System.Drawing.SystemColors.Window
        Me.txtClearingAccount.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtClearingAccount.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClearingAccount.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtClearingAccount.Location = New System.Drawing.Point(144, 130)
        Me.txtClearingAccount.MaxLength = 0
        Me.txtClearingAccount.Name = "txtClearingAccount"
        Me.txtClearingAccount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtClearingAccount.Size = New System.Drawing.Size(85, 20)
        Me.txtClearingAccount.TabIndex = 11
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.SystemColors.Control
        Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label18.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(17, 132)
        Me.Label18.Name = "Label18"
        Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label18.Size = New System.Drawing.Size(96, 17)
        Me.Label18.TabIndex = 10
        Me.Label18.Text = "Clearing Account"
        '
        'txtClearingIntent
        '
        Me.txtClearingIntent.AcceptsReturn = True
        Me.txtClearingIntent.BackColor = System.Drawing.SystemColors.Window
        Me.txtClearingIntent.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtClearingIntent.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClearingIntent.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtClearingIntent.Location = New System.Drawing.Point(144, 154)
        Me.txtClearingIntent.MaxLength = 0
        Me.txtClearingIntent.Name = "txtClearingIntent"
        Me.txtClearingIntent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtClearingIntent.Size = New System.Drawing.Size(85, 20)
        Me.txtClearingIntent.TabIndex = 13
        '
        'Label45
        '
        Me.Label45.BackColor = System.Drawing.SystemColors.Control
        Me.Label45.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label45.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label45.Location = New System.Drawing.Point(17, 156)
        Me.Label45.Name = "Label45"
        Me.Label45.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label45.Size = New System.Drawing.Size(96, 17)
        Me.Label45.TabIndex = 12
        Me.Label45.Text = "Clearing Intent"
        '
        'txtExemptCode
        '
        Me.txtExemptCode.Location = New System.Drawing.Point(144, 370)
        Me.txtExemptCode.Name = "txtExemptCode"
        Me.txtExemptCode.Size = New System.Drawing.Size(84, 20)
        Me.txtExemptCode.TabIndex = 31
        Me.txtExemptCode.Text = "-1"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(16, 373)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(70, 14)
        Me.Label46.TabIndex = 30
        Me.Label46.Text = "Exempt Code"
        '
        'txtHedgeType
        '
        Me.txtHedgeType.AcceptsReturn = True
        Me.txtHedgeType.BackColor = System.Drawing.SystemColors.Window
        Me.txtHedgeType.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHedgeType.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHedgeType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHedgeType.Location = New System.Drawing.Point(143, 418)
        Me.txtHedgeType.MaxLength = 0
        Me.txtHedgeType.Name = "txtHedgeType"
        Me.txtHedgeType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHedgeType.Size = New System.Drawing.Size(85, 20)
        Me.txtHedgeType.TabIndex = 35
        '
        'LabelHedgeType
        '
        Me.LabelHedgeType.BackColor = System.Drawing.SystemColors.Control
        Me.LabelHedgeType.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabelHedgeType.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHedgeType.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelHedgeType.Location = New System.Drawing.Point(16, 421)
        Me.LabelHedgeType.Name = "LabelHedgeType"
        Me.LabelHedgeType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabelHedgeType.Size = New System.Drawing.Size(73, 17)
        Me.LabelHedgeType.TabIndex = 34
        Me.LabelHedgeType.Text = "Hedge: type"
        '
        'LabelHedgeParam
        '
        Me.LabelHedgeParam.BackColor = System.Drawing.SystemColors.Control
        Me.LabelHedgeParam.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabelHedgeParam.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHedgeParam.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelHedgeParam.Location = New System.Drawing.Point(16, 447)
        Me.LabelHedgeParam.Name = "LabelHedgeParam"
        Me.LabelHedgeParam.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabelHedgeParam.Size = New System.Drawing.Size(85, 17)
        Me.LabelHedgeParam.TabIndex = 36
        Me.LabelHedgeParam.Text = "Hedge: param"
        '
        'checkOptOutSmartRouting
        '
        Me.checkOptOutSmartRouting.AutoSize = True
        Me.checkOptOutSmartRouting.Location = New System.Drawing.Point(16, 471)
        Me.checkOptOutSmartRouting.Name = "checkOptOutSmartRouting"
        Me.checkOptOutSmartRouting.Size = New System.Drawing.Size(166, 18)
        Me.checkOptOutSmartRouting.TabIndex = 38
        Me.checkOptOutSmartRouting.Text = "Opting out of SMART Routing"
        Me.checkOptOutSmartRouting.UseVisualStyleBackColor = True
        '
        'Label47
        '
        Me.Label47.BackColor = System.Drawing.SystemColors.Control
        Me.Label47.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label47.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label47.Location = New System.Drawing.Point(550, 108)
        Me.Label47.Name = "Label47"
        Me.Label47.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label47.Size = New System.Drawing.Size(152, 17)
        Me.Label47.TabIndex = 95
        Me.Label47.Text = "VOL: Hedge Delta Con Id"
        '
        'Label48
        '
        Me.Label48.BackColor = System.Drawing.SystemColors.Control
        Me.Label48.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label48.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label48.Location = New System.Drawing.Point(550, 132)
        Me.Label48.Name = "Label48"
        Me.Label48.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label48.Size = New System.Drawing.Size(181, 17)
        Me.Label48.TabIndex = 97
        Me.Label48.Text = "VOL: Hedge Delta Settling Firm"
        '
        'Label49
        '
        Me.Label49.BackColor = System.Drawing.SystemColors.Control
        Me.Label49.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label49.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label49.Location = New System.Drawing.Point(550, 156)
        Me.Label49.Name = "Label49"
        Me.Label49.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label49.Size = New System.Drawing.Size(188, 17)
        Me.Label49.TabIndex = 99
        Me.Label49.Text = "VOL: Hedge Delta Clearing Account"
        '
        'Label50
        '
        Me.Label50.BackColor = System.Drawing.SystemColors.Control
        Me.Label50.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label50.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label50.Location = New System.Drawing.Point(550, 180)
        Me.Label50.Name = "Label50"
        Me.Label50.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label50.Size = New System.Drawing.Size(181, 17)
        Me.Label50.TabIndex = 101
        Me.Label50.Text = "VOL: Hedge Delta Clearing Intent"
        '
        'txtDeltaNeutralConId
        '
        Me.txtDeltaNeutralConId.AcceptsReturn = True
        Me.txtDeltaNeutralConId.BackColor = System.Drawing.SystemColors.Window
        Me.txtDeltaNeutralConId.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDeltaNeutralConId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeltaNeutralConId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDeltaNeutralConId.Location = New System.Drawing.Point(753, 106)
        Me.txtDeltaNeutralConId.MaxLength = 0
        Me.txtDeltaNeutralConId.Name = "txtDeltaNeutralConId"
        Me.txtDeltaNeutralConId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDeltaNeutralConId.Size = New System.Drawing.Size(85, 20)
        Me.txtDeltaNeutralConId.TabIndex = 96
        '
        'txtDeltaNeutralClearingIntent
        '
        Me.txtDeltaNeutralClearingIntent.AcceptsReturn = True
        Me.txtDeltaNeutralClearingIntent.BackColor = System.Drawing.SystemColors.Window
        Me.txtDeltaNeutralClearingIntent.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDeltaNeutralClearingIntent.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeltaNeutralClearingIntent.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDeltaNeutralClearingIntent.Location = New System.Drawing.Point(753, 178)
        Me.txtDeltaNeutralClearingIntent.MaxLength = 0
        Me.txtDeltaNeutralClearingIntent.Name = "txtDeltaNeutralClearingIntent"
        Me.txtDeltaNeutralClearingIntent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDeltaNeutralClearingIntent.Size = New System.Drawing.Size(85, 20)
        Me.txtDeltaNeutralClearingIntent.TabIndex = 102
        '
        'txtDeltaNeutralClearingAccount
        '
        Me.txtDeltaNeutralClearingAccount.AcceptsReturn = True
        Me.txtDeltaNeutralClearingAccount.BackColor = System.Drawing.SystemColors.Window
        Me.txtDeltaNeutralClearingAccount.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDeltaNeutralClearingAccount.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeltaNeutralClearingAccount.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDeltaNeutralClearingAccount.Location = New System.Drawing.Point(753, 154)
        Me.txtDeltaNeutralClearingAccount.MaxLength = 0
        Me.txtDeltaNeutralClearingAccount.Name = "txtDeltaNeutralClearingAccount"
        Me.txtDeltaNeutralClearingAccount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDeltaNeutralClearingAccount.Size = New System.Drawing.Size(85, 20)
        Me.txtDeltaNeutralClearingAccount.TabIndex = 100
        '
        'txtDeltaNeutralSettlingFirm
        '
        Me.txtDeltaNeutralSettlingFirm.AcceptsReturn = True
        Me.txtDeltaNeutralSettlingFirm.BackColor = System.Drawing.SystemColors.Window
        Me.txtDeltaNeutralSettlingFirm.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDeltaNeutralSettlingFirm.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeltaNeutralSettlingFirm.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDeltaNeutralSettlingFirm.Location = New System.Drawing.Point(753, 130)
        Me.txtDeltaNeutralSettlingFirm.MaxLength = 0
        Me.txtDeltaNeutralSettlingFirm.Name = "txtDeltaNeutralSettlingFirm"
        Me.txtDeltaNeutralSettlingFirm.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDeltaNeutralSettlingFirm.Size = New System.Drawing.Size(85, 20)
        Me.txtDeltaNeutralSettlingFirm.TabIndex = 98
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.SystemColors.Control
        Me.Label51.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label51.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label51.Location = New System.Drawing.Point(550, 420)
        Me.Label51.Name = "Label51"
        Me.Label51.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label51.Size = New System.Drawing.Size(181, 17)
        Me.Label51.TabIndex = 120
        Me.Label51.Text = "SCALE: Price Adjust Value"
        '
        'Label52
        '
        Me.Label52.BackColor = System.Drawing.SystemColors.Control
        Me.Label52.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label52.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label52.Location = New System.Drawing.Point(550, 444)
        Me.Label52.Name = "Label52"
        Me.Label52.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label52.Size = New System.Drawing.Size(181, 17)
        Me.Label52.TabIndex = 122
        Me.Label52.Text = "SCALE: Price Adjust Interval"
        '
        'Label53
        '
        Me.Label53.BackColor = System.Drawing.SystemColors.Control
        Me.Label53.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label53.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label53.Location = New System.Drawing.Point(550, 469)
        Me.Label53.Name = "Label53"
        Me.Label53.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label53.Size = New System.Drawing.Size(181, 17)
        Me.Label53.TabIndex = 124
        Me.Label53.Text = "SCALE: Profit Offset"
        '
        'checkScaleAutoReset
        '
        Me.checkScaleAutoReset.AutoSize = True
        Me.checkScaleAutoReset.Location = New System.Drawing.Point(550, 490)
        Me.checkScaleAutoReset.Name = "checkScaleAutoReset"
        Me.checkScaleAutoReset.Size = New System.Drawing.Size(120, 18)
        Me.checkScaleAutoReset.TabIndex = 126
        Me.checkScaleAutoReset.Text = "SCALE: Auto Reset"
        Me.checkScaleAutoReset.UseVisualStyleBackColor = True
        '
        'txtScalePriceAdjustValue
        '
        Me.txtScalePriceAdjustValue.AcceptsReturn = True
        Me.txtScalePriceAdjustValue.BackColor = System.Drawing.SystemColors.Window
        Me.txtScalePriceAdjustValue.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtScalePriceAdjustValue.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtScalePriceAdjustValue.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtScalePriceAdjustValue.Location = New System.Drawing.Point(753, 418)
        Me.txtScalePriceAdjustValue.MaxLength = 0
        Me.txtScalePriceAdjustValue.Name = "txtScalePriceAdjustValue"
        Me.txtScalePriceAdjustValue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtScalePriceAdjustValue.Size = New System.Drawing.Size(85, 20)
        Me.txtScalePriceAdjustValue.TabIndex = 121
        '
        'Label54
        '
        Me.Label54.BackColor = System.Drawing.SystemColors.Control
        Me.Label54.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label54.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label54.Location = New System.Drawing.Point(550, 517)
        Me.Label54.Name = "Label54"
        Me.Label54.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label54.Size = New System.Drawing.Size(181, 17)
        Me.Label54.TabIndex = 127
        Me.Label54.Text = "SCALE: Init Position"
        '
        'Label55
        '
        Me.Label55.BackColor = System.Drawing.SystemColors.Control
        Me.Label55.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label55.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label55.Location = New System.Drawing.Point(550, 543)
        Me.Label55.Name = "Label55"
        Me.Label55.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label55.Size = New System.Drawing.Size(181, 17)
        Me.Label55.TabIndex = 129
        Me.Label55.Text = "SCALE: Init Fill Qty"
        '
        'checkScaleRandomPercent
        '
        Me.checkScaleRandomPercent.AutoSize = True
        Me.checkScaleRandomPercent.Location = New System.Drawing.Point(550, 567)
        Me.checkScaleRandomPercent.Name = "checkScaleRandomPercent"
        Me.checkScaleRandomPercent.Size = New System.Drawing.Size(145, 18)
        Me.checkScaleRandomPercent.TabIndex = 131
        Me.checkScaleRandomPercent.Text = "SCALE: Random Percent"
        Me.checkScaleRandomPercent.UseVisualStyleBackColor = True
        '
        'txtScalePriceAdjustInterval
        '
        Me.txtScalePriceAdjustInterval.AcceptsReturn = True
        Me.txtScalePriceAdjustInterval.BackColor = System.Drawing.SystemColors.Window
        Me.txtScalePriceAdjustInterval.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtScalePriceAdjustInterval.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtScalePriceAdjustInterval.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtScalePriceAdjustInterval.Location = New System.Drawing.Point(753, 442)
        Me.txtScalePriceAdjustInterval.MaxLength = 0
        Me.txtScalePriceAdjustInterval.Name = "txtScalePriceAdjustInterval"
        Me.txtScalePriceAdjustInterval.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtScalePriceAdjustInterval.Size = New System.Drawing.Size(85, 20)
        Me.txtScalePriceAdjustInterval.TabIndex = 123
        '
        'txtScaleInitPosition
        '
        Me.txtScaleInitPosition.AcceptsReturn = True
        Me.txtScaleInitPosition.BackColor = System.Drawing.SystemColors.Window
        Me.txtScaleInitPosition.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtScaleInitPosition.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtScaleInitPosition.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtScaleInitPosition.Location = New System.Drawing.Point(753, 514)
        Me.txtScaleInitPosition.MaxLength = 0
        Me.txtScaleInitPosition.Name = "txtScaleInitPosition"
        Me.txtScaleInitPosition.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtScaleInitPosition.Size = New System.Drawing.Size(85, 20)
        Me.txtScaleInitPosition.TabIndex = 128
        '
        'txtScaleInitFillQty
        '
        Me.txtScaleInitFillQty.AcceptsReturn = True
        Me.txtScaleInitFillQty.BackColor = System.Drawing.SystemColors.Window
        Me.txtScaleInitFillQty.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtScaleInitFillQty.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtScaleInitFillQty.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtScaleInitFillQty.Location = New System.Drawing.Point(753, 540)
        Me.txtScaleInitFillQty.MaxLength = 0
        Me.txtScaleInitFillQty.Name = "txtScaleInitFillQty"
        Me.txtScaleInitFillQty.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtScaleInitFillQty.Size = New System.Drawing.Size(85, 20)
        Me.txtScaleInitFillQty.TabIndex = 130
        '
        'txtScaleProfitOffset
        '
        Me.txtScaleProfitOffset.AcceptsReturn = True
        Me.txtScaleProfitOffset.BackColor = System.Drawing.SystemColors.Window
        Me.txtScaleProfitOffset.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtScaleProfitOffset.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtScaleProfitOffset.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtScaleProfitOffset.Location = New System.Drawing.Point(753, 466)
        Me.txtScaleProfitOffset.MaxLength = 0
        Me.txtScaleProfitOffset.Name = "txtScaleProfitOffset"
        Me.txtScaleProfitOffset.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtScaleProfitOffset.Size = New System.Drawing.Size(85, 20)
        Me.txtScaleProfitOffset.TabIndex = 125
        '
        'Label56
        '
        Me.Label56.BackColor = System.Drawing.SystemColors.Control
        Me.Label56.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label56.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label56.Location = New System.Drawing.Point(264, 35)
        Me.Label56.Name = "Label56"
        Me.Label56.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label56.Size = New System.Drawing.Size(136, 17)
        Me.Label56.TabIndex = 41
        Me.Label56.Text = "Trailing Percent"
        '
        'txtTrailingPercent
        '
        Me.txtTrailingPercent.AcceptsReturn = True
        Me.txtTrailingPercent.BackColor = System.Drawing.SystemColors.Window
        Me.txtTrailingPercent.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTrailingPercent.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTrailingPercent.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTrailingPercent.Location = New System.Drawing.Point(432, 34)
        Me.txtTrailingPercent.MaxLength = 0
        Me.txtTrailingPercent.Name = "txtTrailingPercent"
        Me.txtTrailingPercent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTrailingPercent.Size = New System.Drawing.Size(85, 20)
        Me.txtTrailingPercent.TabIndex = 42
        '
        'txtDeltaNeutralOpenClose
        '
        Me.txtDeltaNeutralOpenClose.AcceptsReturn = True
        Me.txtDeltaNeutralOpenClose.BackColor = System.Drawing.SystemColors.Window
        Me.txtDeltaNeutralOpenClose.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDeltaNeutralOpenClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeltaNeutralOpenClose.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDeltaNeutralOpenClose.Location = New System.Drawing.Point(753, 202)
        Me.txtDeltaNeutralOpenClose.MaxLength = 0
        Me.txtDeltaNeutralOpenClose.Name = "txtDeltaNeutralOpenClose"
        Me.txtDeltaNeutralOpenClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDeltaNeutralOpenClose.Size = New System.Drawing.Size(85, 20)
        Me.txtDeltaNeutralOpenClose.TabIndex = 104
        '
        'Label57
        '
        Me.Label57.BackColor = System.Drawing.SystemColors.Control
        Me.Label57.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label57.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label57.Location = New System.Drawing.Point(550, 204)
        Me.Label57.Name = "Label57"
        Me.Label57.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label57.Size = New System.Drawing.Size(181, 17)
        Me.Label57.TabIndex = 103
        Me.Label57.Text = "VOL: Hedge Delta Open/Close"
        '
        'checkDeltaNeutralShortSale
        '
        Me.checkDeltaNeutralShortSale.AutoSize = True
        Me.checkDeltaNeutralShortSale.Location = New System.Drawing.Point(553, 228)
        Me.checkDeltaNeutralShortSale.Name = "checkDeltaNeutralShortSale"
        Me.checkDeltaNeutralShortSale.Size = New System.Drawing.Size(165, 18)
        Me.checkDeltaNeutralShortSale.TabIndex = 105
        Me.checkDeltaNeutralShortSale.Text = "VOL: Hedge Delta Short Sale"
        Me.checkDeltaNeutralShortSale.UseVisualStyleBackColor = True
        '
        'txtDeltaNeutralShortSaleSlot
        '
        Me.txtDeltaNeutralShortSaleSlot.AcceptsReturn = True
        Me.txtDeltaNeutralShortSaleSlot.BackColor = System.Drawing.SystemColors.Window
        Me.txtDeltaNeutralShortSaleSlot.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDeltaNeutralShortSaleSlot.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeltaNeutralShortSaleSlot.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDeltaNeutralShortSaleSlot.Location = New System.Drawing.Point(753, 250)
        Me.txtDeltaNeutralShortSaleSlot.MaxLength = 0
        Me.txtDeltaNeutralShortSaleSlot.Name = "txtDeltaNeutralShortSaleSlot"
        Me.txtDeltaNeutralShortSaleSlot.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDeltaNeutralShortSaleSlot.Size = New System.Drawing.Size(85, 20)
        Me.txtDeltaNeutralShortSaleSlot.TabIndex = 107
        Me.txtDeltaNeutralShortSaleSlot.Text = "0"
        '
        'Label58
        '
        Me.Label58.BackColor = System.Drawing.SystemColors.Control
        Me.Label58.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label58.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label58.Location = New System.Drawing.Point(550, 252)
        Me.Label58.Name = "Label58"
        Me.Label58.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label58.Size = New System.Drawing.Size(181, 17)
        Me.Label58.TabIndex = 106
        Me.Label58.Text = "VOL: Hedge Delta Short Sale Slot"
        '
        'txtDeltaNeutralDesignatedLocation
        '
        Me.txtDeltaNeutralDesignatedLocation.AcceptsReturn = True
        Me.txtDeltaNeutralDesignatedLocation.BackColor = System.Drawing.SystemColors.Window
        Me.txtDeltaNeutralDesignatedLocation.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDeltaNeutralDesignatedLocation.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDeltaNeutralDesignatedLocation.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDeltaNeutralDesignatedLocation.Location = New System.Drawing.Point(753, 274)
        Me.txtDeltaNeutralDesignatedLocation.MaxLength = 0
        Me.txtDeltaNeutralDesignatedLocation.Name = "txtDeltaNeutralDesignatedLocation"
        Me.txtDeltaNeutralDesignatedLocation.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDeltaNeutralDesignatedLocation.Size = New System.Drawing.Size(85, 20)
        Me.txtDeltaNeutralDesignatedLocation.TabIndex = 109
        '
        'Label59
        '
        Me.Label59.BackColor = System.Drawing.SystemColors.Control
        Me.Label59.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label59.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label59.Location = New System.Drawing.Point(550, 269)
        Me.Label59.Name = "Label59"
        Me.Label59.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label59.Size = New System.Drawing.Size(181, 29)
        Me.Label59.TabIndex = 108
        Me.Label59.Text = "VOL: Hedge Delta Designated Location"
        '
        'txtActiveStopTime
        '
        Me.txtActiveStopTime.AcceptsReturn = True
        Me.txtActiveStopTime.BackColor = System.Drawing.SystemColors.Window
        Me.txtActiveStopTime.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtActiveStopTime.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtActiveStopTime.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtActiveStopTime.Location = New System.Drawing.Point(432, 567)
        Me.txtActiveStopTime.MaxLength = 0
        Me.txtActiveStopTime.Name = "txtActiveStopTime"
        Me.txtActiveStopTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtActiveStopTime.Size = New System.Drawing.Size(85, 20)
        Me.txtActiveStopTime.TabIndex = 86
        '
        'txtActiveStartTime
        '
        Me.txtActiveStartTime.AcceptsReturn = True
        Me.txtActiveStartTime.BackColor = System.Drawing.SystemColors.Window
        Me.txtActiveStartTime.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtActiveStartTime.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtActiveStartTime.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtActiveStartTime.Location = New System.Drawing.Point(432, 543)
        Me.txtActiveStartTime.MaxLength = 0
        Me.txtActiveStartTime.Name = "txtActiveStartTime"
        Me.txtActiveStartTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtActiveStartTime.Size = New System.Drawing.Size(85, 20)
        Me.txtActiveStartTime.TabIndex = 84
        '
        'txtScaleTable
        '
        Me.txtScaleTable.AcceptsReturn = True
        Me.txtScaleTable.BackColor = System.Drawing.SystemColors.Window
        Me.txtScaleTable.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtScaleTable.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtScaleTable.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtScaleTable.Location = New System.Drawing.Point(432, 519)
        Me.txtScaleTable.MaxLength = 0
        Me.txtScaleTable.Name = "txtScaleTable"
        Me.txtScaleTable.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtScaleTable.Size = New System.Drawing.Size(85, 20)
        Me.txtScaleTable.TabIndex = 82
        '
        'Label60
        '
        Me.Label60.BackColor = System.Drawing.SystemColors.Control
        Me.Label60.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label60.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label60.Location = New System.Drawing.Point(264, 570)
        Me.Label60.Name = "Label60"
        Me.Label60.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label60.Size = New System.Drawing.Size(160, 17)
        Me.Label60.TabIndex = 85
        Me.Label60.Text = "Active Stop Time"
        '
        'Label61
        '
        Me.Label61.BackColor = System.Drawing.SystemColors.Control
        Me.Label61.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label61.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label61.Location = New System.Drawing.Point(264, 545)
        Me.Label61.Name = "Label61"
        Me.Label61.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label61.Size = New System.Drawing.Size(160, 17)
        Me.Label61.TabIndex = 83
        Me.Label61.Text = "Active Start Time"
        '
        'Label62
        '
        Me.Label62.BackColor = System.Drawing.SystemColors.Control
        Me.Label62.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label62.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label62.Location = New System.Drawing.Point(264, 521)
        Me.Label62.Name = "Label62"
        Me.Label62.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label62.Size = New System.Drawing.Size(160, 17)
        Me.Label62.TabIndex = 81
        Me.Label62.Text = "SCALE: Scale Table"
        '
        'dlgOrderAttribs
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(850, 638)
        Me.Controls.Add(Me.txtActiveStopTime)
        Me.Controls.Add(Me.txtActiveStartTime)
        Me.Controls.Add(Me.txtScaleTable)
        Me.Controls.Add(Me.Label60)
        Me.Controls.Add(Me.Label61)
        Me.Controls.Add(Me.Label62)
        Me.Controls.Add(Me.Label59)
        Me.Controls.Add(Me.txtDeltaNeutralDesignatedLocation)
        Me.Controls.Add(Me.Label58)
        Me.Controls.Add(Me.txtDeltaNeutralShortSaleSlot)
        Me.Controls.Add(Me.checkDeltaNeutralShortSale)
        Me.Controls.Add(Me.Label57)
        Me.Controls.Add(Me.txtDeltaNeutralOpenClose)
        Me.Controls.Add(Me.txtTrailingPercent)
        Me.Controls.Add(Me.Label56)
        Me.Controls.Add(Me.txtScaleProfitOffset)
        Me.Controls.Add(Me.txtScaleInitFillQty)
        Me.Controls.Add(Me.txtScaleInitPosition)
        Me.Controls.Add(Me.txtScalePriceAdjustInterval)
        Me.Controls.Add(Me.checkScaleRandomPercent)
        Me.Controls.Add(Me.Label55)
        Me.Controls.Add(Me.Label54)
        Me.Controls.Add(Me.txtScalePriceAdjustValue)
        Me.Controls.Add(Me.checkScaleAutoReset)
        Me.Controls.Add(Me.Label53)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.txtDeltaNeutralSettlingFirm)
        Me.Controls.Add(Me.txtDeltaNeutralClearingAccount)
        Me.Controls.Add(Me.txtDeltaNeutralClearingIntent)
        Me.Controls.Add(Me.txtDeltaNeutralConId)
        Me.Controls.Add(Me.Label50)
        Me.Controls.Add(Me.Label49)
        Me.Controls.Add(Me.Label48)
        Me.Controls.Add(Me.Label47)
        Me.Controls.Add(Me.checkOptOutSmartRouting)
        Me.Controls.Add(Me.LabelHedgeParam)
        Me.Controls.Add(Me.LabelHedgeType)
        Me.Controls.Add(Me.txtHedgeParam)
        Me.Controls.Add(Me.txtHedgeType)
        Me.Controls.Add(Me.Label46)
        Me.Controls.Add(Me.txtExemptCode)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.txtClearingIntent)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtClearingAccount)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.txtScalePriceIncr)
        Me.Controls.Add(Me.txtScaleSubsLevelSize)
        Me.Controls.Add(Me.txtScaleInitLevelSize)
        Me.Controls.Add(Me.txtOverridePercentageConstraints)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.txtTrailStopPrice)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.txtDeltaNeutralAuxPrice)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.txtVolatility)
        Me.Controls.Add(Me.txtVolatilityType)
        Me.Controls.Add(Me.txtDeltaNeutralOrderType)
        Me.Controls.Add(Me.txtContinuousUpdate)
        Me.Controls.Add(Me.txtReferencePriceType)
        Me.Controls.Add(Me.txtRule80A)
        Me.Controls.Add(Me.txtSettlingFirm)
        Me.Controls.Add(Me.txtMinQty)
        Me.Controls.Add(Me.txtPercentOffset)
        Me.Controls.Add(Me.txtETradeOnly)
        Me.Controls.Add(Me.txtFirmQuoteOnly)
        Me.Controls.Add(Me.txtNBBOPriceCap)
        Me.Controls.Add(Me.txtAuctionStrategy)
        Me.Controls.Add(Me.txtStartingPrice)
        Me.Controls.Add(Me.txtStockRefPrice)
        Me.Controls.Add(Me.txtDelta)
        Me.Controls.Add(Me.txtStockRangeLower)
        Me.Controls.Add(Me.txtStockRangeUpper)
        Me.Controls.Add(Me.txtAllOrNone)
        Me.Controls.Add(Me.txtOcaType)
        Me.Controls.Add(Me.txtShortSaleSlot)
        Me.Controls.Add(Me.txtDesignatedLocation)
        Me.Controls.Add(Me.txtDiscretionaryAmt)
        Me.Controls.Add(Me.txtHidden)
        Me.Controls.Add(Me.txtOutsideRth)
        Me.Controls.Add(Me.txtTriggerMethod)
        Me.Controls.Add(Me.txtDisplaySize)
        Me.Controls.Add(Me.txtSweepToFill)
        Me.Controls.Add(Me.txtBlockOrder)
        Me.Controls.Add(Me.txtTransmit)
        Me.Controls.Add(Me.txtParentId)
        Me.Controls.Add(Me.txtOrderRef)
        Me.Controls.Add(Me.txtOrigin)
        Me.Controls.Add(Me.txtOpenClose)
        Me.Controls.Add(Me.txtAccount)
        Me.Controls.Add(Me.txtOCA)
        Me.Controls.Add(Me.txtTIF)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(1030, 270)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgOrderAttribs"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Extended Order Attributes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
#Region "Upgrade Support "
    Private Shared m_vb6FormDefInstance As dlgOrderAttribs
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As dlgOrderAttribs
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New dlgOrderAttribs
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal Value As dlgOrderAttribs)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region
    ' ========================================================
    ' Member variables
    ' ========================================================
    Private m_orderInfo As IBApi.Order
    Private m_mainWnd As dlgMainWnd

    Private m_ok As Boolean

    ' ========================================================
    ' Public Methods
    ' ========================================================
    Public Sub init(ByRef mainWin As Form, ByVal orderInfo As IBApi.Order)

        m_mainWnd = dlgMainWnd
        m_orderInfo = orderInfo

        m_ok = False

        txtTIF.Text = m_orderInfo.Tif
        txtActiveStartTime.Text = m_orderInfo.activeStartTime
        txtActiveStopTime.Text = m_orderInfo.activeStopTime
        txtOCA.Text = m_orderInfo.ocaGroup
        txtOcaType.Text = m_orderInfo.ocaType
        txtOrderRef.Text = m_orderInfo.orderRef
        txtTransmit.Text = m_orderInfo.transmit
        txtParentId.Text = m_orderInfo.parentId
        txtBlockOrder.Text = m_orderInfo.blockOrder
        txtSweepToFill.Text = m_orderInfo.sweepToFill
        txtDisplaySize.Text = m_orderInfo.displaySize
        txtTriggerMethod.Text = m_orderInfo.triggerMethod
        txtOutsideRth.Text = m_orderInfo.outsideRth
        txtHidden.Text = m_orderInfo.hidden
        txtOverridePercentageConstraints.Text = m_orderInfo.overridePercentageConstraints
        txtRule80A.Text = m_orderInfo.rule80A
        txtAllOrNone.Text = m_orderInfo.allOrNone
        txtMinQty.Text = ivalStr(m_orderInfo.minQty)
        txtPercentOffset.Text = dvalStr(m_orderInfo.percentOffset)
        txtTrailStopPrice.Text = dvalStr(m_orderInfo.trailStopPrice)
        txtTrailingPercent.Text = dvalStr(m_orderInfo.trailingPercent)

        ' Institutional orders only
        txtOpenClose.Text = m_orderInfo.openClose
        txtOrigin.Text = m_orderInfo.origin
        txtShortSaleSlot.Text = m_orderInfo.shortSaleSlot
        txtDesignatedLocation.Text = m_orderInfo.designatedLocation
        txtExemptCode.Text = m_orderInfo.exemptCode

        'SMART routing only
        txtDiscretionaryAmt.Text = m_orderInfo.discretionaryAmt
        txtETradeOnly.Text = m_orderInfo.eTradeOnly
        txtFirmQuoteOnly.Text = m_orderInfo.firmQuoteOnly
        txtNBBOPriceCap.Text = dvalStr(m_orderInfo.nbboPriceCap)
        checkOptOutSmartRouting.Checked = m_orderInfo.optOutSmartRouting

        ' BOX or VOL orders only
        txtAuctionStrategy.Text = m_orderInfo.auctionStrategy

        'BOX orders only
        txtStartingPrice.Text = dvalStr(m_orderInfo.startingPrice)
        txtStockRefPrice.Text = dvalStr(m_orderInfo.stockRefPrice)
        txtDelta.Text = dvalStr(m_orderInfo.delta)

        ' pegged to stock or VOL orders
        txtStockRangeLower.Text = dvalStr(m_orderInfo.stockRangeLower)
        txtStockRangeUpper.Text = dvalStr(m_orderInfo.stockRangeUpper)

        ' VOLATILITY orders only
        txtVolatility.Text = dvalStr(m_orderInfo.volatility)
        txtVolatilityType.Text = ivalStr(m_orderInfo.volatilityType)
        txtContinuousUpdate.Text = m_orderInfo.continuousUpdate
        txtReferencePriceType.Text = ivalStr(m_orderInfo.referencePriceType)
        txtDeltaNeutralOrderType.Text = m_orderInfo.deltaNeutralOrderType
        txtDeltaNeutralAuxPrice.Text = dvalStr(m_orderInfo.deltaNeutralAuxPrice)
        txtDeltaNeutralConId.Text = ivalStr(m_orderInfo.deltaNeutralConId)
        txtDeltaNeutralSettlingFirm.Text = m_orderInfo.deltaNeutralSettlingFirm
        txtDeltaNeutralClearingAccount.Text = m_orderInfo.deltaNeutralClearingAccount
        txtDeltaNeutralClearingIntent.Text = m_orderInfo.deltaNeutralClearingIntent
        txtDeltaNeutralOpenClose.Text = m_orderInfo.deltaNeutralOpenClose
        checkDeltaNeutralShortSale.Checked = m_orderInfo.deltaNeutralShortSale
        txtDeltaNeutralShortSaleSlot.Text = ivalStr(m_orderInfo.deltaNeutralShortSaleSlot)
        txtDeltaNeutralDesignatedLocation.Text = m_orderInfo.deltaNeutralDesignatedLocation

        ' SCALE orders only
        txtScaleInitLevelSize.Text = ivalStr(m_orderInfo.scaleInitLevelSize)
        txtScaleSubsLevelSize.Text = ivalStr(m_orderInfo.scaleSubsLevelSize)
        txtScalePriceIncr.Text = dvalStr(m_orderInfo.scalePriceIncrement)
        txtScalePriceAdjustValue.Text = dvalStr(m_orderInfo.scalePriceAdjustValue)
        txtScalePriceAdjustInterval.Text = ivalStr(m_orderInfo.scalePriceAdjustInterval)
        txtScaleProfitOffset.Text = dvalStr(m_orderInfo.scaleProfitOffset)
        checkScaleAutoReset.Checked = m_orderInfo.scaleAutoReset
        txtScaleInitPosition.Text = ivalStr(m_orderInfo.scaleInitPosition)
        txtScaleInitFillQty.Text = ivalStr(m_orderInfo.scaleInitFillQty)
        checkScaleRandomPercent.Checked = m_orderInfo.scaleRandomPercent
        txtScaleTable.Text = m_orderInfo.scaleTable

        ' HEDGE orders only
        txtHedgeType.Text = m_orderInfo.hedgeType
        txtHedgeParam.Text = m_orderInfo.hedgeParam

        ' Clearing info
        txtAccount.Text = m_orderInfo.account
        txtSettlingFirm.Text = m_orderInfo.settlingFirm
        txtClearingAccount.Text = m_orderInfo.clearingAccount
        txtClearingIntent.Text = m_orderInfo.clearingIntent

    End Sub

    ' ========================================================
    ' Get/Set Methods
    ' ========================================================
    Public ReadOnly Property ok() As Boolean
        Get
            ok = m_ok
        End Get
    End Property
    Private Function ivalStr(ByVal val As Long) As String
        If val = Int32.MaxValue Then
            ivalStr = ""
        Else
            ivalStr = val
        End If
    End Function
    Private Function dvalStr(ByVal val As Double) As String
        If val = Double.MaxValue Then
            dvalStr = ""
        Else
            dvalStr = val
        End If
    End Function
    Private Function bval(ByVal text As String) As Boolean
        If Len(text) = 0 Then
            bval = False
        Else
            bval = CBool(text)
        End If
    End Function
    Private Function ival(ByVal text As String) As Integer
        If Len(text) = 0 Then
            ival = Int32.MaxValue
        Else
            ival = CInt(text)
        End If
    End Function
    Private Function dval(ByVal text As String) As Double
        If Len(text) = 0 Then
            dval = Double.MaxValue
        Else
            dval = CDbl(text)
        End If
    End Function
    ' ========================================================
    ' Button Events
    ' ========================================================
    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click

        m_orderInfo.Tif = txtTIF.Text
        m_orderInfo.activeStartTime = txtActiveStartTime.Text
        m_orderInfo.activeStopTime = txtActiveStopTime.Text
        m_orderInfo.ocaGroup = txtOCA.Text
        m_orderInfo.ocaType = ival(txtOcaType.Text)
        m_orderInfo.orderRef = txtOrderRef.Text
        m_orderInfo.transmit = bval(txtTransmit.Text)
        m_orderInfo.parentId = ival(txtParentId.Text)
        m_orderInfo.blockOrder = bval(txtBlockOrder.Text)
        m_orderInfo.sweepToFill = bval(txtSweepToFill.Text)
        m_orderInfo.displaySize = ival(txtDisplaySize.Text)
        m_orderInfo.triggerMethod = txtTriggerMethod.Text
        m_orderInfo.outsideRth = bval(txtOutsideRth.Text)
        m_orderInfo.hidden = txtHidden.Text
        m_orderInfo.overridePercentageConstraints = bval(txtOverridePercentageConstraints.Text)
        m_orderInfo.rule80A = txtRule80A.Text
        m_orderInfo.allOrNone = bval(txtAllOrNone.Text)
        m_orderInfo.minQty = ival(txtMinQty.Text)
        m_orderInfo.percentOffset = dval(txtPercentOffset.Text)
        m_orderInfo.trailStopPrice = dval(txtTrailStopPrice.Text)
        m_orderInfo.trailingPercent = dval(txtTrailingPercent.Text)

        ' Institutional orders only
        m_orderInfo.openClose = txtOpenClose.Text
        m_orderInfo.origin = ival(txtOrigin.Text)
        m_orderInfo.shortSaleSlot = ival(txtShortSaleSlot.Text)
        m_orderInfo.designatedLocation = txtDesignatedLocation.Text
        If Not String.IsNullOrEmpty(txtExemptCode.Text) Then
            m_orderInfo.exemptCode = ival(txtExemptCode.Text)
        Else
            m_orderInfo.exemptCode = ival("-1")
        End If

        'SMART routing only
        m_orderInfo.discretionaryAmt = dval(txtDiscretionaryAmt.Text)
        m_orderInfo.eTradeOnly = bval(txtETradeOnly.Text)
        m_orderInfo.firmQuoteOnly = bval(txtFirmQuoteOnly.Text)
        m_orderInfo.nbboPriceCap = dval(txtNBBOPriceCap.Text)
        m_orderInfo.optOutSmartRouting = checkOptOutSmartRouting.Checked

        ' BOX or VOL orders only
        m_orderInfo.auctionStrategy = ival(txtAuctionStrategy.Text)

        'BOX orders only
        m_orderInfo.startingPrice = dval(txtStartingPrice.Text)
        m_orderInfo.stockRefPrice = dval(txtStockRefPrice.Text)
        m_orderInfo.delta = dval(txtDelta.Text)

        ' pegged to stock or VOL orders
        m_orderInfo.stockRangeLower = dval(txtStockRangeLower.Text)
        m_orderInfo.stockRangeUpper = dval(txtStockRangeUpper.Text)

        ' VOLATILITY orders only
        m_orderInfo.volatility = dval(txtVolatility.Text)
        m_orderInfo.volatilityType = ival(txtVolatilityType.Text)
        m_orderInfo.continuousUpdate = bval(txtContinuousUpdate.Text)
        m_orderInfo.referencePriceType = ival(txtReferencePriceType.Text)
        m_orderInfo.deltaNeutralOrderType = txtDeltaNeutralOrderType.Text
        m_orderInfo.deltaNeutralAuxPrice = dval(txtDeltaNeutralAuxPrice.Text)
        m_orderInfo.deltaNeutralConId = ival(txtDeltaNeutralConId.Text)
        m_orderInfo.deltaNeutralSettlingFirm = txtDeltaNeutralSettlingFirm.Text
        m_orderInfo.deltaNeutralClearingAccount = txtDeltaNeutralClearingAccount.Text
        m_orderInfo.deltaNeutralClearingIntent = txtDeltaNeutralClearingIntent.Text
        m_orderInfo.deltaNeutralOpenClose = txtDeltaNeutralOpenClose.Text
        m_orderInfo.deltaNeutralShortSale = checkDeltaNeutralShortSale.Checked
        m_orderInfo.deltaNeutralShortSaleSlot = ival(txtDeltaNeutralShortSaleSlot.Text)
        m_orderInfo.deltaNeutralDesignatedLocation = txtDeltaNeutralDesignatedLocation.Text

        ' SCALE orders only
        m_orderInfo.scaleInitLevelSize = ival(txtScaleInitLevelSize.Text)
        m_orderInfo.scaleSubsLevelSize = ival(txtScaleSubsLevelSize.Text)
        m_orderInfo.scalePriceIncrement = dval(txtScalePriceIncr.Text)
        m_orderInfo.scalePriceAdjustValue = dval(txtScalePriceAdjustValue.Text)
        m_orderInfo.scalePriceAdjustInterval = ival(txtScalePriceAdjustInterval.Text)
        m_orderInfo.scaleProfitOffset = dval(txtScaleProfitOffset.Text)
        m_orderInfo.scaleAutoReset = checkScaleAutoReset.Checked
        m_orderInfo.scaleInitPosition = ival(txtScaleInitPosition.Text)
        m_orderInfo.scaleInitFillQty = ival(txtScaleInitFillQty.Text)
        m_orderInfo.scaleRandomPercent = checkScaleRandomPercent.Checked
        m_orderInfo.scaleTable = txtScaleTable.Text

        ' HEDGE orders only
        m_orderInfo.hedgeType = txtHedgeType.Text
        m_orderInfo.hedgeParam = txtHedgeParam.Text

        ' Clearing info
        m_orderInfo.account = txtAccount.Text
        m_orderInfo.settlingFirm = txtSettlingFirm.Text
        m_orderInfo.clearingAccount = txtClearingAccount.Text
        m_orderInfo.clearingIntent = txtClearingIntent.Text

        m_ok = True
        Hide()
    End Sub
    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        m_ok = False
        Hide()
    End Sub
End Class