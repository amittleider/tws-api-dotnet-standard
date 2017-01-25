' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.


Option Explicit On
Imports System.Xml
Imports System.Collections.Generic
Imports IBApi

Friend Class MainForm
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
    Protected Overloads Overrides Sub Dispose(Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public WithEvents cmdReqHistoricalData As System.Windows.Forms.Button
    Public WithEvents cmdFinancialAdvisor As System.Windows.Forms.Button
    Public WithEvents cmdReqAllOpenOrders As System.Windows.Forms.Button
    Public WithEvents cmdReqAutoOpenOrders As System.Windows.Forms.Button
    Public WithEvents cmdServerLogLevel As System.Windows.Forms.Button
    Public WithEvents cmdReqNews As System.Windows.Forms.Button
    Public WithEvents cmdReqAcctData As System.Windows.Forms.Button
    Public WithEvents cmdReqExecutions As System.Windows.Forms.Button
    Public WithEvents cmdReqIds As System.Windows.Forms.Button
    Public WithEvents cmdClearForm As System.Windows.Forms.Button
    Public WithEvents cmdClose As System.Windows.Forms.Button
    Public WithEvents cmdDisconnect As System.Windows.Forms.Button
    Public WithEvents cmdReqMktData As System.Windows.Forms.Button
    Public WithEvents cmdReqMktDepth As System.Windows.Forms.Button
    Public WithEvents cmdCancelMktDepth As System.Windows.Forms.Button
    Public WithEvents cmdPlaceOrder As System.Windows.Forms.Button
    Public WithEvents cmdCancelOrder As System.Windows.Forms.Button
    Public WithEvents cmdExtendedOrderAtribs As System.Windows.Forms.Button
    Public WithEvents cmdReqContractData As System.Windows.Forms.Button
    Public WithEvents cmdReqOpenOrders As System.Windows.Forms.Button
    Public WithEvents cmdConnect As System.Windows.Forms.Button
    Public WithEvents lstErrors As System.Windows.Forms.ListBox
    Public WithEvents lstServerResponses As System.Windows.Forms.ListBox
    Public WithEvents lstMktData As System.Windows.Forms.ListBox
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Public WithEvents cmdReqAccts As System.Windows.Forms.Button
    Public WithEvents cmdExerciseOptions As System.Windows.Forms.Button
    Public WithEvents cmdCancelHistData As System.Windows.Forms.Button
    Public WithEvents cmdReqRealTimeBars As System.Windows.Forms.Button
    Public WithEvents cmdCancelRealTimeBars As System.Windows.Forms.Button
    Public WithEvents cmdReqCurrentTime As System.Windows.Forms.Button
    Public WithEvents cmdWhatIf As System.Windows.Forms.Button
    Friend WithEvents cmdCalcImpliedVolatility As System.Windows.Forms.Button
    Friend WithEvents cmdCalcOptionPrice As System.Windows.Forms.Button
    Friend WithEvents cmdCancelCalcImpliedVolatility As System.Windows.Forms.Button
    Friend WithEvents cmdCancelCalcOptionPrice As System.Windows.Forms.Button
    Friend WithEvents cmdReqGlobalCancel As System.Windows.Forms.Button
    Friend WithEvents cmdReqMarketDataType As System.Windows.Forms.Button
    Public WithEvents cmdCancelMktData As System.Windows.Forms.Button
    Friend WithEvents cmdReqPositions As System.Windows.Forms.Button
    Friend WithEvents cmdReqAccountSummary As System.Windows.Forms.Button
    Friend WithEvents cmdCancelAccountSummary As System.Windows.Forms.Button
    Friend WithEvents cmdCancelPositions As System.Windows.Forms.Button
    Friend WithEvents cmdGroups As System.Windows.Forms.Button
    Friend WithEvents cmdReqFundamentalData As System.Windows.Forms.Button
    Friend WithEvents cmdCancelFundamentalData As System.Windows.Forms.Button
    Friend WithEvents cmdReqPositionsMulti As System.Windows.Forms.Button
    Friend WithEvents cmdCancelPositionsMulti As System.Windows.Forms.Button
    Friend WithEvents cmdReqAccountUpdatesMulti As System.Windows.Forms.Button
    Friend WithEvents cmdCancelAccountUpdatesMulti As System.Windows.Forms.Button
    Friend WithEvents cmdReqSecDefOptParams As System.Windows.Forms.Button
    Friend WithEvents cmdFamilyCodes As System.Windows.Forms.Button
    Friend WithEvents cmdReqMatchingSymbols As System.Windows.Forms.Button
    Friend WithEvents cmdReqMktDepthExchanges As System.Windows.Forms.Button
    Friend WithEvents cmdReqSmartComponents As System.Windows.Forms.Button
    Friend WithEvents cmdReqNewsProviders As System.Windows.Forms.Button
    Friend WithEvents cmdReqNewsArticle As System.Windows.Forms.Button
    Friend WithEvents cmdReqHistoricalNews As System.Windows.Forms.Button
    Public WithEvents cmdReqHeadTimestamp As System.Windows.Forms.Button
    Public WithEvents cmdScanner As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdReqHistoricalData = New System.Windows.Forms.Button()
        Me.cmdFinancialAdvisor = New System.Windows.Forms.Button()
        Me.cmdReqAccts = New System.Windows.Forms.Button()
        Me.cmdReqAllOpenOrders = New System.Windows.Forms.Button()
        Me.cmdReqAutoOpenOrders = New System.Windows.Forms.Button()
        Me.cmdServerLogLevel = New System.Windows.Forms.Button()
        Me.cmdReqNews = New System.Windows.Forms.Button()
        Me.cmdReqAcctData = New System.Windows.Forms.Button()
        Me.cmdReqExecutions = New System.Windows.Forms.Button()
        Me.cmdReqIds = New System.Windows.Forms.Button()
        Me.cmdClearForm = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdDisconnect = New System.Windows.Forms.Button()
        Me.cmdReqMktData = New System.Windows.Forms.Button()
        Me.cmdReqMktDepth = New System.Windows.Forms.Button()
        Me.cmdCancelMktDepth = New System.Windows.Forms.Button()
        Me.cmdPlaceOrder = New System.Windows.Forms.Button()
        Me.cmdCancelOrder = New System.Windows.Forms.Button()
        Me.cmdExtendedOrderAtribs = New System.Windows.Forms.Button()
        Me.cmdReqContractData = New System.Windows.Forms.Button()
        Me.cmdReqOpenOrders = New System.Windows.Forms.Button()
        Me.cmdConnect = New System.Windows.Forms.Button()
        Me.lstErrors = New System.Windows.Forms.ListBox()
        Me.lstServerResponses = New System.Windows.Forms.ListBox()
        Me.lstMktData = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdExerciseOptions = New System.Windows.Forms.Button()
        Me.cmdCancelHistData = New System.Windows.Forms.Button()
        Me.cmdScanner = New System.Windows.Forms.Button()
        Me.cmdReqRealTimeBars = New System.Windows.Forms.Button()
        Me.cmdCancelRealTimeBars = New System.Windows.Forms.Button()
        Me.cmdReqCurrentTime = New System.Windows.Forms.Button()
        Me.cmdWhatIf = New System.Windows.Forms.Button()
        Me.cmdCalcImpliedVolatility = New System.Windows.Forms.Button()
        Me.cmdCalcOptionPrice = New System.Windows.Forms.Button()
        Me.cmdCancelCalcImpliedVolatility = New System.Windows.Forms.Button()
        Me.cmdCancelCalcOptionPrice = New System.Windows.Forms.Button()
        Me.cmdReqGlobalCancel = New System.Windows.Forms.Button()
        Me.cmdReqMarketDataType = New System.Windows.Forms.Button()
        Me.cmdCancelMktData = New System.Windows.Forms.Button()
        Me.cmdReqPositions = New System.Windows.Forms.Button()
        Me.cmdReqAccountSummary = New System.Windows.Forms.Button()
        Me.cmdCancelAccountSummary = New System.Windows.Forms.Button()
        Me.cmdCancelPositions = New System.Windows.Forms.Button()
        Me.cmdGroups = New System.Windows.Forms.Button()
        Me.cmdReqFundamentalData = New System.Windows.Forms.Button()
        Me.cmdCancelFundamentalData = New System.Windows.Forms.Button()
        Me.cmdReqPositionsMulti = New System.Windows.Forms.Button()
        Me.cmdCancelPositionsMulti = New System.Windows.Forms.Button()
        Me.cmdReqAccountUpdatesMulti = New System.Windows.Forms.Button()
        Me.cmdCancelAccountUpdatesMulti = New System.Windows.Forms.Button()
        Me.cmdReqSecDefOptParams = New System.Windows.Forms.Button()
        Me.cmdFamilyCodes = New System.Windows.Forms.Button()
        Me.cmdReqMatchingSymbols = New System.Windows.Forms.Button()
        Me.cmdReqMktDepthExchanges = New System.Windows.Forms.Button()
        Me.cmdReqSmartComponents = New System.Windows.Forms.Button()
        Me.cmdReqNewsProviders = New System.Windows.Forms.Button()
        Me.cmdReqNewsArticle = New System.Windows.Forms.Button()
        Me.cmdReqHistoricalNews = New System.Windows.Forms.Button()
        Me.cmdReqHeadTimestamp = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdReqHistoricalData
        '
        Me.cmdReqHistoricalData.BackColor = System.Drawing.SystemColors.Control
        Me.cmdReqHistoricalData.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdReqHistoricalData.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReqHistoricalData.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdReqHistoricalData.Location = New System.Drawing.Point(544, 60)
        Me.cmdReqHistoricalData.Name = "cmdReqHistoricalData"
        Me.cmdReqHistoricalData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdReqHistoricalData.Size = New System.Drawing.Size(134, 21)
        Me.cmdReqHistoricalData.TabIndex = 6
        Me.cmdReqHistoricalData.Text = "Historical Data..."
        Me.cmdReqHistoricalData.UseVisualStyleBackColor = True
        '
        'cmdFinancialAdvisor
        '
        Me.cmdFinancialAdvisor.BackColor = System.Drawing.SystemColors.Control
        Me.cmdFinancialAdvisor.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdFinancialAdvisor.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFinancialAdvisor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdFinancialAdvisor.Location = New System.Drawing.Point(543, 437)
        Me.cmdFinancialAdvisor.Name = "cmdFinancialAdvisor"
        Me.cmdFinancialAdvisor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdFinancialAdvisor.Size = New System.Drawing.Size(134, 21)
        Me.cmdFinancialAdvisor.TabIndex = 34
        Me.cmdFinancialAdvisor.Text = "Financial Advisor"
        Me.cmdFinancialAdvisor.UseVisualStyleBackColor = True
        '
        'cmdReqAccts
        '
        Me.cmdReqAccts.BackColor = System.Drawing.SystemColors.Control
        Me.cmdReqAccts.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdReqAccts.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReqAccts.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdReqAccts.Location = New System.Drawing.Point(684, 410)
        Me.cmdReqAccts.Name = "cmdReqAccts"
        Me.cmdReqAccts.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdReqAccts.Size = New System.Drawing.Size(134, 21)
        Me.cmdReqAccts.TabIndex = 33
        Me.cmdReqAccts.Text = "Req Accounts"
        Me.cmdReqAccts.UseVisualStyleBackColor = True
        '
        'cmdReqAllOpenOrders
        '
        Me.cmdReqAllOpenOrders.BackColor = System.Drawing.SystemColors.Control
        Me.cmdReqAllOpenOrders.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdReqAllOpenOrders.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReqAllOpenOrders.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdReqAllOpenOrders.Location = New System.Drawing.Point(544, 329)
        Me.cmdReqAllOpenOrders.Name = "cmdReqAllOpenOrders"
        Me.cmdReqAllOpenOrders.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdReqAllOpenOrders.Size = New System.Drawing.Size(134, 21)
        Me.cmdReqAllOpenOrders.TabIndex = 26
        Me.cmdReqAllOpenOrders.Text = "Req All Open Orders"
        Me.cmdReqAllOpenOrders.UseVisualStyleBackColor = True
        '
        'cmdReqAutoOpenOrders
        '
        Me.cmdReqAutoOpenOrders.BackColor = System.Drawing.SystemColors.Control
        Me.cmdReqAutoOpenOrders.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdReqAutoOpenOrders.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReqAutoOpenOrders.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdReqAutoOpenOrders.Location = New System.Drawing.Point(684, 329)
        Me.cmdReqAutoOpenOrders.Name = "cmdReqAutoOpenOrders"
        Me.cmdReqAutoOpenOrders.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdReqAutoOpenOrders.Size = New System.Drawing.Size(134, 21)
        Me.cmdReqAutoOpenOrders.TabIndex = 27
        Me.cmdReqAutoOpenOrders.Text = "Req Auto Open Orders"
        Me.cmdReqAutoOpenOrders.UseVisualStyleBackColor = True
        '
        'cmdServerLogLevel
        '
        Me.cmdServerLogLevel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdServerLogLevel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdServerLogLevel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdServerLogLevel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdServerLogLevel.Location = New System.Drawing.Point(544, 410)
        Me.cmdServerLogLevel.Name = "cmdServerLogLevel"
        Me.cmdServerLogLevel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdServerLogLevel.Size = New System.Drawing.Size(134, 21)
        Me.cmdServerLogLevel.TabIndex = 32
        Me.cmdServerLogLevel.Text = "Log Configuration..."
        Me.cmdServerLogLevel.UseVisualStyleBackColor = True
        '
        'cmdReqNews
        '
        Me.cmdReqNews.BackColor = System.Drawing.SystemColors.Control
        Me.cmdReqNews.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdReqNews.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReqNews.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdReqNews.Location = New System.Drawing.Point(683, 383)
        Me.cmdReqNews.Name = "cmdReqNews"
        Me.cmdReqNews.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdReqNews.Size = New System.Drawing.Size(134, 21)
        Me.cmdReqNews.TabIndex = 31
        Me.cmdReqNews.Text = "Req News Bulletins..."
        Me.cmdReqNews.UseVisualStyleBackColor = True
        '
        'cmdReqAcctData
        '
        Me.cmdReqAcctData.BackColor = System.Drawing.SystemColors.Control
        Me.cmdReqAcctData.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdReqAcctData.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReqAcctData.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdReqAcctData.Location = New System.Drawing.Point(544, 356)
        Me.cmdReqAcctData.Name = "cmdReqAcctData"
        Me.cmdReqAcctData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdReqAcctData.Size = New System.Drawing.Size(134, 21)
        Me.cmdReqAcctData.TabIndex = 28
        Me.cmdReqAcctData.Text = "Req Acct Data..."
        Me.cmdReqAcctData.UseVisualStyleBackColor = True
        '
        'cmdReqExecutions
        '
        Me.cmdReqExecutions.BackColor = System.Drawing.SystemColors.Control
        Me.cmdReqExecutions.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdReqExecutions.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReqExecutions.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdReqExecutions.Location = New System.Drawing.Point(684, 356)
        Me.cmdReqExecutions.Name = "cmdReqExecutions"
        Me.cmdReqExecutions.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdReqExecutions.Size = New System.Drawing.Size(134, 21)
        Me.cmdReqExecutions.TabIndex = 29
        Me.cmdReqExecutions.Text = "Req Executions..."
        Me.cmdReqExecutions.UseVisualStyleBackColor = True
        '
        'cmdReqIds
        '
        Me.cmdReqIds.BackColor = System.Drawing.SystemColors.Control
        Me.cmdReqIds.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdReqIds.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReqIds.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdReqIds.Location = New System.Drawing.Point(543, 383)
        Me.cmdReqIds.Name = "cmdReqIds"
        Me.cmdReqIds.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdReqIds.Size = New System.Drawing.Size(134, 21)
        Me.cmdReqIds.TabIndex = 30
        Me.cmdReqIds.Text = "Req Next Id..."
        Me.cmdReqIds.UseVisualStyleBackColor = True
        '
        'cmdClearForm
        '
        Me.cmdClearForm.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClearForm.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClearForm.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClearForm.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClearForm.Location = New System.Drawing.Point(224, 697)
        Me.cmdClearForm.Name = "cmdClearForm"
        Me.cmdClearForm.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClearForm.Size = New System.Drawing.Size(89, 25)
        Me.cmdClearForm.TabIndex = 59
        Me.cmdClearForm.Text = "Clear"
        Me.cmdClearForm.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(320, 697)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(89, 25)
        Me.cmdClose.TabIndex = 60
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdDisconnect
        '
        Me.cmdDisconnect.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDisconnect.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdDisconnect.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDisconnect.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdDisconnect.Location = New System.Drawing.Point(320, 4)
        Me.cmdDisconnect.Name = "cmdDisconnect"
        Me.cmdDisconnect.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdDisconnect.Size = New System.Drawing.Size(113, 25)
        Me.cmdDisconnect.TabIndex = 1
        Me.cmdDisconnect.Text = "Disconnect"
        Me.cmdDisconnect.UseVisualStyleBackColor = True
        '
        'cmdReqMktData
        '
        Me.cmdReqMktData.BackColor = System.Drawing.SystemColors.Control
        Me.cmdReqMktData.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdReqMktData.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReqMktData.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdReqMktData.Location = New System.Drawing.Point(544, 6)
        Me.cmdReqMktData.Name = "cmdReqMktData"
        Me.cmdReqMktData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdReqMktData.Size = New System.Drawing.Size(134, 21)
        Me.cmdReqMktData.TabIndex = 2
        Me.cmdReqMktData.Text = "Req Mkt Data..."
        Me.cmdReqMktData.UseVisualStyleBackColor = True
        '
        'cmdReqMktDepth
        '
        Me.cmdReqMktDepth.BackColor = System.Drawing.SystemColors.Control
        Me.cmdReqMktDepth.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdReqMktDepth.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReqMktDepth.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdReqMktDepth.Location = New System.Drawing.Point(544, 33)
        Me.cmdReqMktDepth.Name = "cmdReqMktDepth"
        Me.cmdReqMktDepth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdReqMktDepth.Size = New System.Drawing.Size(134, 21)
        Me.cmdReqMktDepth.TabIndex = 4
        Me.cmdReqMktDepth.Text = "Req Mkt Depth..."
        Me.cmdReqMktDepth.UseVisualStyleBackColor = True
        '
        'cmdCancelMktDepth
        '
        Me.cmdCancelMktDepth.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancelMktDepth.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancelMktDepth.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelMktDepth.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancelMktDepth.Location = New System.Drawing.Point(684, 33)
        Me.cmdCancelMktDepth.Name = "cmdCancelMktDepth"
        Me.cmdCancelMktDepth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancelMktDepth.Size = New System.Drawing.Size(134, 21)
        Me.cmdCancelMktDepth.TabIndex = 5
        Me.cmdCancelMktDepth.Text = "Cancel Mkt Depth..."
        Me.cmdCancelMktDepth.UseVisualStyleBackColor = True
        '
        'cmdPlaceOrder
        '
        Me.cmdPlaceOrder.BackColor = System.Drawing.SystemColors.Control
        Me.cmdPlaceOrder.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdPlaceOrder.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPlaceOrder.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPlaceOrder.Location = New System.Drawing.Point(543, 248)
        Me.cmdPlaceOrder.Name = "cmdPlaceOrder"
        Me.cmdPlaceOrder.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPlaceOrder.Size = New System.Drawing.Size(134, 21)
        Me.cmdPlaceOrder.TabIndex = 20
        Me.cmdPlaceOrder.Text = "Place Order..."
        Me.cmdPlaceOrder.UseVisualStyleBackColor = True
        '
        'cmdCancelOrder
        '
        Me.cmdCancelOrder.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancelOrder.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancelOrder.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelOrder.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancelOrder.Location = New System.Drawing.Point(684, 248)
        Me.cmdCancelOrder.Name = "cmdCancelOrder"
        Me.cmdCancelOrder.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancelOrder.Size = New System.Drawing.Size(134, 21)
        Me.cmdCancelOrder.TabIndex = 21
        Me.cmdCancelOrder.Text = "Cancel Order..."
        Me.cmdCancelOrder.UseVisualStyleBackColor = True
        '
        'cmdExtendedOrderAtribs
        '
        Me.cmdExtendedOrderAtribs.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExtendedOrderAtribs.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExtendedOrderAtribs.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExtendedOrderAtribs.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExtendedOrderAtribs.Location = New System.Drawing.Point(684, 275)
        Me.cmdExtendedOrderAtribs.Name = "cmdExtendedOrderAtribs"
        Me.cmdExtendedOrderAtribs.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExtendedOrderAtribs.Size = New System.Drawing.Size(134, 21)
        Me.cmdExtendedOrderAtribs.TabIndex = 23
        Me.cmdExtendedOrderAtribs.Text = "Extended..."
        Me.cmdExtendedOrderAtribs.UseVisualStyleBackColor = True
        '
        'cmdReqContractData
        '
        Me.cmdReqContractData.BackColor = System.Drawing.SystemColors.Control
        Me.cmdReqContractData.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdReqContractData.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReqContractData.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdReqContractData.Location = New System.Drawing.Point(544, 302)
        Me.cmdReqContractData.Name = "cmdReqContractData"
        Me.cmdReqContractData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdReqContractData.Size = New System.Drawing.Size(134, 21)
        Me.cmdReqContractData.TabIndex = 24
        Me.cmdReqContractData.Text = "Req Contract Data..."
        Me.cmdReqContractData.UseVisualStyleBackColor = True
        '
        'cmdReqOpenOrders
        '
        Me.cmdReqOpenOrders.BackColor = System.Drawing.SystemColors.Control
        Me.cmdReqOpenOrders.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdReqOpenOrders.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReqOpenOrders.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdReqOpenOrders.Location = New System.Drawing.Point(684, 302)
        Me.cmdReqOpenOrders.Name = "cmdReqOpenOrders"
        Me.cmdReqOpenOrders.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdReqOpenOrders.Size = New System.Drawing.Size(134, 21)
        Me.cmdReqOpenOrders.TabIndex = 25
        Me.cmdReqOpenOrders.Text = "Req Open Orders"
        Me.cmdReqOpenOrders.UseVisualStyleBackColor = True
        '
        'cmdConnect
        '
        Me.cmdConnect.BackColor = System.Drawing.SystemColors.Control
        Me.cmdConnect.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdConnect.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdConnect.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdConnect.Location = New System.Drawing.Point(200, 4)
        Me.cmdConnect.Name = "cmdConnect"
        Me.cmdConnect.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdConnect.Size = New System.Drawing.Size(113, 25)
        Me.cmdConnect.TabIndex = 0
        Me.cmdConnect.Text = "Connect..."
        Me.cmdConnect.UseVisualStyleBackColor = True
        '
        'lstErrors
        '
        Me.lstErrors.BackColor = System.Drawing.SystemColors.Window
        Me.lstErrors.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstErrors.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstErrors.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstErrors.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstErrors.HorizontalScrollbar = True
        Me.lstErrors.ItemHeight = 14
        Me.lstErrors.Location = New System.Drawing.Point(8, 447)
        Me.lstErrors.Name = "lstErrors"
        Me.lstErrors.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstErrors.Size = New System.Drawing.Size(529, 168)
        Me.lstErrors.TabIndex = 58
        '
        'lstServerResponses
        '
        Me.lstServerResponses.BackColor = System.Drawing.SystemColors.Window
        Me.lstServerResponses.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstServerResponses.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstServerResponses.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstServerResponses.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstServerResponses.HorizontalScrollbar = True
        Me.lstServerResponses.ItemHeight = 14
        Me.lstServerResponses.Location = New System.Drawing.Point(8, 248)
        Me.lstServerResponses.Name = "lstServerResponses"
        Me.lstServerResponses.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstServerResponses.Size = New System.Drawing.Size(529, 168)
        Me.lstServerResponses.TabIndex = 56
        '
        'lstMktData
        '
        Me.lstMktData.BackColor = System.Drawing.SystemColors.Window
        Me.lstMktData.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstMktData.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstMktData.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstMktData.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstMktData.HorizontalScrollbar = True
        Me.lstMktData.ItemHeight = 14
        Me.lstMktData.Location = New System.Drawing.Point(8, 49)
        Me.lstMktData.Name = "lstMktData"
        Me.lstMktData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstMktData.Size = New System.Drawing.Size(529, 168)
        Me.lstMktData.TabIndex = 54
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Gainsboro
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 431)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(120, 17)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "Errors and Messages"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 232)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(136, 17)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "TWS Server Responses"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(144, 17)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Market and Historical Data"
        '
        'cmdExerciseOptions
        '
        Me.cmdExerciseOptions.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExerciseOptions.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExerciseOptions.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExerciseOptions.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExerciseOptions.Location = New System.Drawing.Point(544, 275)
        Me.cmdExerciseOptions.Name = "cmdExerciseOptions"
        Me.cmdExerciseOptions.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExerciseOptions.Size = New System.Drawing.Size(134, 21)
        Me.cmdExerciseOptions.TabIndex = 22
        Me.cmdExerciseOptions.Text = "Exercise Options..."
        Me.cmdExerciseOptions.UseVisualStyleBackColor = True
        '
        'cmdCancelHistData
        '
        Me.cmdCancelHistData.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancelHistData.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancelHistData.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelHistData.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancelHistData.Location = New System.Drawing.Point(684, 60)
        Me.cmdCancelHistData.Name = "cmdCancelHistData"
        Me.cmdCancelHistData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancelHistData.Size = New System.Drawing.Size(134, 21)
        Me.cmdCancelHistData.TabIndex = 7
        Me.cmdCancelHistData.Text = "Cancel Hist. Data..."
        Me.cmdCancelHistData.UseVisualStyleBackColor = True
        '
        'cmdScanner
        '
        Me.cmdScanner.BackColor = System.Drawing.SystemColors.Control
        Me.cmdScanner.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdScanner.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdScanner.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdScanner.Location = New System.Drawing.Point(684, 140)
        Me.cmdScanner.Name = "cmdScanner"
        Me.cmdScanner.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdScanner.Size = New System.Drawing.Size(134, 21)
        Me.cmdScanner.TabIndex = 13
        Me.cmdScanner.Text = "Market Scanner..."
        Me.cmdScanner.UseVisualStyleBackColor = True
        '
        'cmdReqRealTimeBars
        '
        Me.cmdReqRealTimeBars.BackColor = System.Drawing.SystemColors.Control
        Me.cmdReqRealTimeBars.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdReqRealTimeBars.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReqRealTimeBars.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdReqRealTimeBars.Location = New System.Drawing.Point(544, 113)
        Me.cmdReqRealTimeBars.Name = "cmdReqRealTimeBars"
        Me.cmdReqRealTimeBars.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdReqRealTimeBars.Size = New System.Drawing.Size(134, 21)
        Me.cmdReqRealTimeBars.TabIndex = 10
        Me.cmdReqRealTimeBars.Text = "Real Time Bars"
        Me.cmdReqRealTimeBars.UseVisualStyleBackColor = True
        '
        'cmdCancelRealTimeBars
        '
        Me.cmdCancelRealTimeBars.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancelRealTimeBars.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancelRealTimeBars.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelRealTimeBars.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancelRealTimeBars.Location = New System.Drawing.Point(684, 113)
        Me.cmdCancelRealTimeBars.Name = "cmdCancelRealTimeBars"
        Me.cmdCancelRealTimeBars.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancelRealTimeBars.Size = New System.Drawing.Size(134, 21)
        Me.cmdCancelRealTimeBars.TabIndex = 11
        Me.cmdCancelRealTimeBars.Text = "Canc Real Time Bars"
        Me.cmdCancelRealTimeBars.UseVisualStyleBackColor = True
        '
        'cmdReqCurrentTime
        '
        Me.cmdReqCurrentTime.BackColor = System.Drawing.SystemColors.Control
        Me.cmdReqCurrentTime.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdReqCurrentTime.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReqCurrentTime.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdReqCurrentTime.Location = New System.Drawing.Point(544, 140)
        Me.cmdReqCurrentTime.Name = "cmdReqCurrentTime"
        Me.cmdReqCurrentTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdReqCurrentTime.Size = New System.Drawing.Size(134, 21)
        Me.cmdReqCurrentTime.TabIndex = 12
        Me.cmdReqCurrentTime.Text = "Current Time"
        Me.cmdReqCurrentTime.UseVisualStyleBackColor = True
        '
        'cmdWhatIf
        '
        Me.cmdWhatIf.BackColor = System.Drawing.SystemColors.Control
        Me.cmdWhatIf.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdWhatIf.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdWhatIf.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdWhatIf.Location = New System.Drawing.Point(544, 221)
        Me.cmdWhatIf.Name = "cmdWhatIf"
        Me.cmdWhatIf.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdWhatIf.Size = New System.Drawing.Size(134, 21)
        Me.cmdWhatIf.TabIndex = 18
        Me.cmdWhatIf.Text = "What If..."
        Me.cmdWhatIf.UseVisualStyleBackColor = True
        '
        'cmdCalcImpliedVolatility
        '
        Me.cmdCalcImpliedVolatility.Location = New System.Drawing.Point(543, 167)
        Me.cmdCalcImpliedVolatility.Name = "cmdCalcImpliedVolatility"
        Me.cmdCalcImpliedVolatility.Size = New System.Drawing.Size(134, 21)
        Me.cmdCalcImpliedVolatility.TabIndex = 14
        Me.cmdCalcImpliedVolatility.Text = "Calc Implied Volatility"
        Me.cmdCalcImpliedVolatility.UseVisualStyleBackColor = True
        '
        'cmdCalcOptionPrice
        '
        Me.cmdCalcOptionPrice.Location = New System.Drawing.Point(543, 194)
        Me.cmdCalcOptionPrice.Name = "cmdCalcOptionPrice"
        Me.cmdCalcOptionPrice.Size = New System.Drawing.Size(134, 21)
        Me.cmdCalcOptionPrice.TabIndex = 16
        Me.cmdCalcOptionPrice.Text = "Calc Option Price"
        Me.cmdCalcOptionPrice.UseVisualStyleBackColor = True
        '
        'cmdCancelCalcImpliedVolatility
        '
        Me.cmdCancelCalcImpliedVolatility.Location = New System.Drawing.Point(684, 167)
        Me.cmdCancelCalcImpliedVolatility.Name = "cmdCancelCalcImpliedVolatility"
        Me.cmdCancelCalcImpliedVolatility.Size = New System.Drawing.Size(134, 21)
        Me.cmdCancelCalcImpliedVolatility.TabIndex = 15
        Me.cmdCancelCalcImpliedVolatility.Text = "Cancel Calc Impl Vol"
        Me.cmdCancelCalcImpliedVolatility.UseVisualStyleBackColor = True
        '
        'cmdCancelCalcOptionPrice
        '
        Me.cmdCancelCalcOptionPrice.Location = New System.Drawing.Point(684, 194)
        Me.cmdCancelCalcOptionPrice.Name = "cmdCancelCalcOptionPrice"
        Me.cmdCancelCalcOptionPrice.Size = New System.Drawing.Size(134, 21)
        Me.cmdCancelCalcOptionPrice.TabIndex = 17
        Me.cmdCancelCalcOptionPrice.Text = "Cancel Calc Opt Price"
        Me.cmdCancelCalcOptionPrice.UseVisualStyleBackColor = True
        '
        'cmdReqGlobalCancel
        '
        Me.cmdReqGlobalCancel.Location = New System.Drawing.Point(684, 437)
        Me.cmdReqGlobalCancel.Name = "cmdReqGlobalCancel"
        Me.cmdReqGlobalCancel.Size = New System.Drawing.Size(134, 21)
        Me.cmdReqGlobalCancel.TabIndex = 35
        Me.cmdReqGlobalCancel.Text = "Global Cancel"
        Me.cmdReqGlobalCancel.UseVisualStyleBackColor = True
        '
        'cmdReqMarketDataType
        '
        Me.cmdReqMarketDataType.Location = New System.Drawing.Point(544, 464)
        Me.cmdReqMarketDataType.Name = "cmdReqMarketDataType"
        Me.cmdReqMarketDataType.Size = New System.Drawing.Size(134, 36)
        Me.cmdReqMarketDataType.TabIndex = 36
        Me.cmdReqMarketDataType.Text = "Req Mkt Data Type"
        Me.cmdReqMarketDataType.UseVisualStyleBackColor = True
        '
        'cmdCancelMktData
        '
        Me.cmdCancelMktData.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancelMktData.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancelMktData.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelMktData.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancelMktData.Location = New System.Drawing.Point(684, 6)
        Me.cmdCancelMktData.Name = "cmdCancelMktData"
        Me.cmdCancelMktData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancelMktData.Size = New System.Drawing.Size(134, 21)
        Me.cmdCancelMktData.TabIndex = 3
        Me.cmdCancelMktData.Text = "Cancel Mkt Data..."
        Me.cmdCancelMktData.UseVisualStyleBackColor = True
        '
        'cmdReqPositions
        '
        Me.cmdReqPositions.Location = New System.Drawing.Point(544, 506)
        Me.cmdReqPositions.Name = "cmdReqPositions"
        Me.cmdReqPositions.Size = New System.Drawing.Size(134, 21)
        Me.cmdReqPositions.TabIndex = 38
        Me.cmdReqPositions.Text = "Req Positions"
        Me.cmdReqPositions.UseVisualStyleBackColor = True
        '
        'cmdReqAccountSummary
        '
        Me.cmdReqAccountSummary.Location = New System.Drawing.Point(544, 532)
        Me.cmdReqAccountSummary.Name = "cmdReqAccountSummary"
        Me.cmdReqAccountSummary.Size = New System.Drawing.Size(134, 21)
        Me.cmdReqAccountSummary.TabIndex = 40
        Me.cmdReqAccountSummary.Text = "Req Acct Summary"
        Me.cmdReqAccountSummary.UseVisualStyleBackColor = True
        '
        'cmdCancelAccountSummary
        '
        Me.cmdCancelAccountSummary.Location = New System.Drawing.Point(683, 533)
        Me.cmdCancelAccountSummary.Name = "cmdCancelAccountSummary"
        Me.cmdCancelAccountSummary.Size = New System.Drawing.Size(134, 21)
        Me.cmdCancelAccountSummary.TabIndex = 41
        Me.cmdCancelAccountSummary.Text = "Cancel Acct Summary"
        Me.cmdCancelAccountSummary.UseVisualStyleBackColor = True
        '
        'cmdCancelPositions
        '
        Me.cmdCancelPositions.Location = New System.Drawing.Point(683, 506)
        Me.cmdCancelPositions.Name = "cmdCancelPositions"
        Me.cmdCancelPositions.Size = New System.Drawing.Size(134, 21)
        Me.cmdCancelPositions.TabIndex = 39
        Me.cmdCancelPositions.Text = "Cancel Positions"
        Me.cmdCancelPositions.UseVisualStyleBackColor = True
        '
        'cmdGroups
        '
        Me.cmdGroups.Location = New System.Drawing.Point(545, 560)
        Me.cmdGroups.Name = "cmdGroups"
        Me.cmdGroups.Size = New System.Drawing.Size(133, 21)
        Me.cmdGroups.TabIndex = 42
        Me.cmdGroups.Text = "Groups"
        Me.cmdGroups.UseVisualStyleBackColor = True
        '
        'cmdReqFundamentalData
        '
        Me.cmdReqFundamentalData.Location = New System.Drawing.Point(545, 87)
        Me.cmdReqFundamentalData.Name = "cmdReqFundamentalData"
        Me.cmdReqFundamentalData.Size = New System.Drawing.Size(134, 21)
        Me.cmdReqFundamentalData.TabIndex = 8
        Me.cmdReqFundamentalData.Text = "Fundamental Data..."
        Me.cmdReqFundamentalData.UseVisualStyleBackColor = True
        '
        'cmdCancelFundamentalData
        '
        Me.cmdCancelFundamentalData.Location = New System.Drawing.Point(684, 87)
        Me.cmdCancelFundamentalData.Name = "cmdCancelFundamentalData"
        Me.cmdCancelFundamentalData.Size = New System.Drawing.Size(134, 21)
        Me.cmdCancelFundamentalData.TabIndex = 9
        Me.cmdCancelFundamentalData.Text = "Cancel Fund. Data..."
        Me.cmdCancelFundamentalData.UseVisualStyleBackColor = True
        '
        'cmdReqPositionsMulti
        '
        Me.cmdReqPositionsMulti.Location = New System.Drawing.Point(544, 587)
        Me.cmdReqPositionsMulti.Name = "cmdReqPositionsMulti"
        Me.cmdReqPositionsMulti.Size = New System.Drawing.Size(134, 21)
        Me.cmdReqPositionsMulti.TabIndex = 44
        Me.cmdReqPositionsMulti.Text = "Req Positions Multi"
        Me.cmdReqPositionsMulti.UseVisualStyleBackColor = True
        '
        'cmdCancelPositionsMulti
        '
        Me.cmdCancelPositionsMulti.Location = New System.Drawing.Point(683, 587)
        Me.cmdCancelPositionsMulti.Name = "cmdCancelPositionsMulti"
        Me.cmdCancelPositionsMulti.Size = New System.Drawing.Size(134, 21)
        Me.cmdCancelPositionsMulti.TabIndex = 45
        Me.cmdCancelPositionsMulti.Text = "Cancel Positions Multi"
        Me.cmdCancelPositionsMulti.UseVisualStyleBackColor = True
        '
        'cmdReqAccountUpdatesMulti
        '
        Me.cmdReqAccountUpdatesMulti.Location = New System.Drawing.Point(543, 614)
        Me.cmdReqAccountUpdatesMulti.Name = "cmdReqAccountUpdatesMulti"
        Me.cmdReqAccountUpdatesMulti.Size = New System.Drawing.Size(134, 21)
        Me.cmdReqAccountUpdatesMulti.TabIndex = 46
        Me.cmdReqAccountUpdatesMulti.Text = "Req Acct Upd Multi"
        Me.cmdReqAccountUpdatesMulti.UseVisualStyleBackColor = True
        '
        'cmdCancelAccountUpdatesMulti
        '
        Me.cmdCancelAccountUpdatesMulti.Location = New System.Drawing.Point(683, 614)
        Me.cmdCancelAccountUpdatesMulti.Name = "cmdCancelAccountUpdatesMulti"
        Me.cmdCancelAccountUpdatesMulti.Size = New System.Drawing.Size(134, 21)
        Me.cmdCancelAccountUpdatesMulti.TabIndex = 47
        Me.cmdCancelAccountUpdatesMulti.Text = "Cancel Acct Upd Multi"
        Me.cmdCancelAccountUpdatesMulti.UseVisualStyleBackColor = True
        '
        'cmdReqSecDefOptParams
        '
        Me.cmdReqSecDefOptParams.Location = New System.Drawing.Point(683, 464)
        Me.cmdReqSecDefOptParams.Name = "cmdReqSecDefOptParams"
        Me.cmdReqSecDefOptParams.Size = New System.Drawing.Size(134, 36)
        Me.cmdReqSecDefOptParams.TabIndex = 37
        Me.cmdReqSecDefOptParams.Text = "Req Sec Def Opt Params"
        Me.cmdReqSecDefOptParams.UseVisualStyleBackColor = True
        '
        'cmdFamilyCodes
        '
        Me.cmdFamilyCodes.Location = New System.Drawing.Point(684, 221)
        Me.cmdFamilyCodes.Name = "cmdFamilyCodes"
        Me.cmdFamilyCodes.Size = New System.Drawing.Size(133, 21)
        Me.cmdFamilyCodes.TabIndex = 19
        Me.cmdFamilyCodes.Text = "Req Family Codes"
        Me.cmdFamilyCodes.UseVisualStyleBackColor = True
        '
        'cmdReqMatchingSymbols
        '
        Me.cmdReqMatchingSymbols.Location = New System.Drawing.Point(684, 560)
        Me.cmdReqMatchingSymbols.Name = "cmdReqMatchingSymbols"
        Me.cmdReqMatchingSymbols.Size = New System.Drawing.Size(134, 21)
        Me.cmdReqMatchingSymbols.TabIndex = 43
        Me.cmdReqMatchingSymbols.Text = "Req Matching Symbols"
        Me.cmdReqMatchingSymbols.UseVisualStyleBackColor = True
        '
        'cmdReqMktDepthExchanges
        '
        Me.cmdReqMktDepthExchanges.Location = New System.Drawing.Point(543, 641)
        Me.cmdReqMktDepthExchanges.Name = "cmdReqMktDepthExchanges"
        Me.cmdReqMktDepthExchanges.Size = New System.Drawing.Size(134, 21)
        Me.cmdReqMktDepthExchanges.TabIndex = 48
        Me.cmdReqMktDepthExchanges.Text = "Req Mkt Depth Exch"
        Me.cmdReqMktDepthExchanges.UseVisualStyleBackColor = True
        '
        'cmdReqSmartComponents
        '
        Me.cmdReqSmartComponents.Location = New System.Drawing.Point(545, 668)
        Me.cmdReqSmartComponents.Name = "cmdReqSmartComponents"
        Me.cmdReqSmartComponents.Size = New System.Drawing.Size(134, 21)
        Me.cmdReqSmartComponents.TabIndex = 50
        Me.cmdReqSmartComponents.Text = "Req Smart Components"
        Me.cmdReqSmartComponents.UseVisualStyleBackColor = True
        '
        'cmdReqNewsProviders
        '
        Me.cmdReqNewsProviders.Location = New System.Drawing.Point(684, 641)
        Me.cmdReqNewsProviders.Name = "cmdReqNewsProviders"
        Me.cmdReqNewsProviders.Size = New System.Drawing.Size(134, 21)
        Me.cmdReqNewsProviders.TabIndex = 49
        Me.cmdReqNewsProviders.Text = "Req News Providers"
        Me.cmdReqNewsProviders.UseVisualStyleBackColor = True
        '
        'cmdReqNewsArticle
        '
        Me.cmdReqNewsArticle.Location = New System.Drawing.Point(685, 668)
        Me.cmdReqNewsArticle.Name = "cmdReqNewsArticle"
        Me.cmdReqNewsArticle.Size = New System.Drawing.Size(134, 21)
        Me.cmdReqNewsArticle.TabIndex = 51
        Me.cmdReqNewsArticle.Text = "Req News Article"
        Me.cmdReqNewsArticle.UseVisualStyleBackColor = True
        '
        'cmdReqHistoricalNews
        '
        Me.cmdReqHistoricalNews.Location = New System.Drawing.Point(545, 695)
        Me.cmdReqHistoricalNews.Name = "cmdReqHistoricalNews"
        Me.cmdReqHistoricalNews.Size = New System.Drawing.Size(134, 21)
        Me.cmdReqHistoricalNews.TabIndex = 52
        Me.cmdReqHistoricalNews.Text = "Req Historical News"
        Me.cmdReqHistoricalNews.UseVisualStyleBackColor = True
        '
        'cmdReqHeadTimestamp
        '
        Me.cmdReqHeadTimestamp.BackColor = System.Drawing.SystemColors.Control
        Me.cmdReqHeadTimestamp.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdReqHeadTimestamp.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReqHeadTimestamp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdReqHeadTimestamp.Location = New System.Drawing.Point(683, 695)
        Me.cmdReqHeadTimestamp.Name = "cmdReqHeadTimestamp"
        Me.cmdReqHeadTimestamp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdReqHeadTimestamp.Size = New System.Drawing.Size(134, 21)
        Me.cmdReqHeadTimestamp.TabIndex = 61
        Me.cmdReqHeadTimestamp.Text = "Req Head Time Stamp..."
        Me.cmdReqHeadTimestamp.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(823, 733)
        Me.Controls.Add(Me.cmdReqHeadTimestamp)
        Me.Controls.Add(Me.cmdReqHistoricalNews)
        Me.Controls.Add(Me.cmdReqNewsArticle)
        Me.Controls.Add(Me.cmdReqNewsProviders)
        Me.Controls.Add(Me.cmdReqSmartComponents)
        Me.Controls.Add(Me.cmdReqMktDepthExchanges)
        Me.Controls.Add(Me.cmdFamilyCodes)
        Me.Controls.Add(Me.cmdReqMatchingSymbols)
        Me.Controls.Add(Me.cmdReqSecDefOptParams)
        Me.Controls.Add(Me.cmdCancelAccountUpdatesMulti)
        Me.Controls.Add(Me.cmdReqAccountUpdatesMulti)
        Me.Controls.Add(Me.cmdCancelPositionsMulti)
        Me.Controls.Add(Me.cmdReqPositionsMulti)
        Me.Controls.Add(Me.cmdCancelFundamentalData)
        Me.Controls.Add(Me.cmdReqFundamentalData)
        Me.Controls.Add(Me.cmdGroups)
        Me.Controls.Add(Me.cmdCancelPositions)
        Me.Controls.Add(Me.cmdCancelAccountSummary)
        Me.Controls.Add(Me.cmdReqAccountSummary)
        Me.Controls.Add(Me.cmdReqPositions)
        Me.Controls.Add(Me.cmdReqMarketDataType)
        Me.Controls.Add(Me.cmdReqGlobalCancel)
        Me.Controls.Add(Me.cmdCancelCalcOptionPrice)
        Me.Controls.Add(Me.cmdCancelCalcImpliedVolatility)
        Me.Controls.Add(Me.cmdCalcOptionPrice)
        Me.Controls.Add(Me.cmdCalcImpliedVolatility)
        Me.Controls.Add(Me.cmdWhatIf)
        Me.Controls.Add(Me.cmdReqCurrentTime)
        Me.Controls.Add(Me.cmdCancelRealTimeBars)
        Me.Controls.Add(Me.cmdReqRealTimeBars)
        Me.Controls.Add(Me.cmdCancelHistData)
        Me.Controls.Add(Me.cmdScanner)
        Me.Controls.Add(Me.cmdExerciseOptions)
        Me.Controls.Add(Me.cmdReqHistoricalData)
        Me.Controls.Add(Me.cmdFinancialAdvisor)
        Me.Controls.Add(Me.cmdReqAccts)
        Me.Controls.Add(Me.cmdReqAllOpenOrders)
        Me.Controls.Add(Me.cmdReqAutoOpenOrders)
        Me.Controls.Add(Me.cmdServerLogLevel)
        Me.Controls.Add(Me.cmdReqNews)
        Me.Controls.Add(Me.cmdReqAcctData)
        Me.Controls.Add(Me.cmdReqExecutions)
        Me.Controls.Add(Me.cmdReqIds)
        Me.Controls.Add(Me.cmdClearForm)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdDisconnect)
        Me.Controls.Add(Me.cmdReqMktData)
        Me.Controls.Add(Me.cmdCancelMktData)
        Me.Controls.Add(Me.cmdReqMktDepth)
        Me.Controls.Add(Me.cmdCancelMktDepth)
        Me.Controls.Add(Me.cmdPlaceOrder)
        Me.Controls.Add(Me.cmdCancelOrder)
        Me.Controls.Add(Me.cmdExtendedOrderAtribs)
        Me.Controls.Add(Me.cmdReqContractData)
        Me.Controls.Add(Me.cmdReqOpenOrders)
        Me.Controls.Add(Me.cmdConnect)
        Me.Controls.Add(Me.lstErrors)
        Me.Controls.Add(Me.lstServerResponses)
        Me.Controls.Add(Me.lstMktData)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(348, 193)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MainForm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VB.NET Sample"
        Me.ResumeLayout(False)

    End Sub
#End Region

#Region "Upgrade Support "
    Private Shared m_vb6FormDefInstance As MainForm
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As MainForm
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New MainForm()
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(value As MainForm)
            m_vb6FormDefInstance = value
        End Set
    End Property
#End Region

#Region "Member variables"

    Private m_Tws As Tws
    Private WithEvents m_apiEvents As ApiEventSource
    Public m_api As EClient

    ' data members
    Private m_contractInfo As IBApi.Contract
    Private m_orderInfo As IBApi.Order
    Private m_execFilter As IBApi.ExecutionFilter
    Private m_underComp As IBApi.UnderComp
    Private m_mktDataOptions As List(Of IBApi.TagValue)
    Private m_chartOptions As List(Of IBApi.TagValue)
    Private m_mktDepthOptions As List(Of IBApi.TagValue)
    Private m_realTimeBarsOptions As List(Of IBApi.TagValue)

    Private m_dlgOrder As New dlgOrder
    Private m_dlgConnect As New dlgConnect
    Private m_dlgMktDepth As New dlgMktDepth
    Private m_dlgAcctData As New dlgAcctData
    Private m_utils As New Utils
    Private m_dlgNewsBulletins As New dlgNewsBulletins
    Private m_dlgLogConfig As New dlgLogConfig
    Private m_dlgFinancialAdvisor As New dlgFinancialAdvisor
    Private m_dlgScanner As New dlgScanner
    Private m_dlgGroups As New dlgGroups

    Private m_faAccount, faError As Boolean
    Private m_faAcctsList As String
    Private m_faGroupXML As String
    Private m_faProfilesXML As String
    Private m_faAliasesXML As String
    Private m_faErrorCodes(5) As Integer

    Private Const MarketDepthDataResetError As Integer = 317

#End Region

#Region "Form event handlers"

    Private Sub Form_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If m_api IsNot Nothing Then m_api.eDisconnect()
    End Sub

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        m_utils.init(Me, m_dlgAcctData, m_dlgGroups)
        m_dlgAcctData.init(m_utils)
        m_dlgScanner.init(Me)

        m_faErrorCodes(0) = 503
        m_faErrorCodes(1) = 504
        m_faErrorCodes(2) = 505
        m_faErrorCodes(3) = 522
        m_faErrorCodes(4) = 1100
        m_faErrorCodes(5) = 321

        m_contractInfo = New IBApi.Contract
        m_orderInfo = New IBApi.Order
        m_execFilter = New IBApi.ExecutionFilter
        m_underComp = New IBApi.UnderComp

    End Sub

#End Region

#Region "Properties"

    Public ReadOnly Property Api As EClient
        Get
            Return m_api
        End Get
    End Property

    Public ReadOnly Property IsFAAccount() As Boolean
        Get
            IsFAAccount = m_faAccount
        End Get
    End Property

    Public ReadOnly Property FAManagedAccounts() As String
        Get
            FAManagedAccounts = m_faAcctsList
        End Get
    End Property

#End Region

#Region "Control event handlers"

    '--------------------------------------------------------------------------------
    ' Connect this API client to the TWS instance
    '--------------------------------------------------------------------------------
    Private Sub cmdConnect_Click(sender As Object, e As EventArgs) Handles cmdConnect.Click
        ' assume this is a non Financial Advisor account. If it is the managedAccounts()
        ' event will be fired.
        m_faAccount = False

        m_dlgConnect.ShowDialog()
        If m_dlgConnect.ok Then
            With m_dlgConnect
                m_utils.addListItem(Utils.ListType.ServerResponses,
                     "Connecting to Tws using clientId " & .clientId & " ...")

                m_Tws = New Tws(Me)
                m_apiEvents = m_Tws.ApiEvents
                m_api = m_Tws.ApiClient

                m_Tws.Connect(.hostIP, .port, .clientId, False, m_dlgConnect.optCaps)
                If (m_api.ServerVersion() > 0) Then
                    Dim msg = "Connected to Tws server version " & m_api.ServerVersion() &
                          " at " & m_api.ServerTime()
                    m_utils.addListItem(Utils.ListType.ServerResponses, msg)
                End If
            End With
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Disconnect this API client from the TWS instance
    '--------------------------------------------------------------------------------
    Private Sub cmdDisconnect_Click(sender As Object, e As EventArgs) Handles cmdDisconnect.Click
        m_api.eDisconnect()
    End Sub

    '--------------------------------------------------------------------------------
    ' Request market data for a security
    '--------------------------------------------------------------------------------
    Private Sub cmdReqMktData_Click(sender As Object, e As EventArgs) Handles cmdReqMktData.Click
        ' Set the dialog state
        m_dlgOrder.init(dlgOrder.DialogType.RequestMarketData,
            m_contractInfo, m_orderInfo, m_underComp, m_mktDataOptions, Me)

        m_dlgOrder.ShowDialog()

        m_mktDataOptions = m_dlgOrder.options

        If m_dlgOrder.ok Then
            m_api.reqMktData(m_dlgOrder.orderId, m_contractInfo,
                    m_dlgOrder.genericTickTags, m_dlgOrder.snapshotMktData, m_dlgOrder.regulatorySnapshotMktData, m_mktDataOptions)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Cancel market data for a security
    '--------------------------------------------------------------------------------
    Private Sub cmdCancelMktData_Click(sender As Object, e As EventArgs) Handles cmdCancelMktData.Click
        ' Set the dialog state
        m_dlgOrder.init(dlgOrder.DialogType.CancelMarketData,
            m_contractInfo, m_orderInfo, m_underComp, Nothing, Me)

        m_dlgOrder.ShowDialog()
        If m_dlgOrder.ok Then
            m_api.cancelMktData(m_dlgOrder.orderId)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Request market depth for a security
    '--------------------------------------------------------------------------------
    Private Sub cmdReqMktDepth_Click(sender As Object, e As EventArgs) Handles cmdReqMktDepth.Click
        ' Set the dialog state
        m_dlgOrder.init(dlgOrder.DialogType.RequestMarketDepth,
            m_contractInfo, m_orderInfo, m_underComp, m_mktDepthOptions, Me)

        m_dlgOrder.ShowDialog()

        m_mktDepthOptions = m_dlgOrder.options

        If m_dlgOrder.ok Then

            m_dlgMktDepth.init(m_dlgOrder.numRows, m_contractInfo)
            m_api.reqMarketDepth(m_dlgOrder.orderId, m_contractInfo, m_dlgOrder.numRows, m_mktDepthOptions)
            m_dlgMktDepth.ShowDialog()

            ' unsubscribe to mkt depth when the dialog is closed
            m_api.cancelMktDepth(m_dlgOrder.orderId)

        End If

    End Sub

    '--------------------------------------------------------------------------------
    ' Cancel market depth for a security
    '--------------------------------------------------------------------------------
    Private Sub cmdCancelMktDepth_Click(sender As Object, e As EventArgs) Handles cmdCancelMktDepth.Click
        ' Set the dialog state
        m_dlgOrder.init(dlgOrder.DialogType.CancelMarketDepth,
            m_contractInfo, m_orderInfo, m_underComp, Nothing, Me)

        m_dlgOrder.ShowDialog()
        If m_dlgOrder.ok Then
            m_api.cancelMktDepth(m_dlgOrder.orderId)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Request historical market data for a security
    '--------------------------------------------------------------------------------
    Private Sub cmdReqHistoricalData_Click(sender As Object, e As EventArgs) Handles cmdReqHistoricalData.Click
        ' Set the dialog state
        m_dlgOrder.init(dlgOrder.DialogType.RequestHistoricalData,
            m_contractInfo, m_orderInfo, m_underComp, m_chartOptions, Me)

        m_dlgOrder.ShowDialog()

        m_chartOptions = m_dlgOrder.options

        If m_dlgOrder.ok Then

            m_api.reqHistoricalData(m_dlgOrder.orderId, m_contractInfo,
                m_dlgOrder.histEndDateTime, m_dlgOrder.histDuration, m_dlgOrder.histBarSizeSetting,
                m_dlgOrder.whatToShow, m_dlgOrder.useRTH, m_dlgOrder.formatDate, m_chartOptions)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Cancel historical market data for a security
    '--------------------------------------------------------------------------------
    Private Sub cmdCancelHistData_Click(sender As Object, e As EventArgs) Handles cmdCancelHistData.Click
        ' Set the dialog state
        m_dlgOrder.init(dlgOrder.DialogType.CancelHistoricalData,
            m_contractInfo, m_orderInfo, m_underComp, Nothing, Me)

        m_dlgOrder.ShowDialog()
        If m_dlgOrder.ok Then
            m_api.cancelHistoricalData(m_dlgOrder.orderId)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Request fundamental data for a security
    '--------------------------------------------------------------------------------
    Private Sub cmdReqFundamentalData_Click(sender As Object, e As EventArgs) Handles cmdReqFundamentalData.Click
        ' Set the dialog state
        m_dlgOrder.init(dlgOrder.DialogType.RequestFundamentalData,
            m_contractInfo, m_orderInfo, m_underComp, Nothing, Me)
        m_dlgOrder.ShowDialog()

        If m_dlgOrder.ok Then
            m_api.reqFundamentalData(m_dlgOrder.orderId, m_contractInfo, m_dlgOrder.whatToShow, Nothing)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Cancel fundamental data for a security
    '--------------------------------------------------------------------------------
    Private Sub cmdCancelFundamentalData_Click(sender As Object, e As EventArgs) Handles cmdCancelFundamentalData.Click
        ' Set the dialog state
        m_dlgOrder.init(dlgOrder.DialogType.CancelFundamentalData,
            m_contractInfo, m_orderInfo, m_underComp, Nothing, Me)

        m_dlgOrder.ShowDialog()
        m_api.cancelFundamentalData(m_dlgOrder.orderId)

    End Sub

    '--------------------------------------------------------------------------------
    ' Request real time bars for a security
    '--------------------------------------------------------------------------------
    Private Sub cmdReqRealTimeBars_Click(sender As Object, e As EventArgs) Handles cmdReqRealTimeBars.Click
        ' Set the dialog state
        m_dlgOrder.init(dlgOrder.DialogType.RequestRealtimeBars,
            m_contractInfo, m_orderInfo, m_underComp, m_realTimeBarsOptions, Me)

        m_dlgOrder.ShowDialog()

        m_realTimeBarsOptions = m_dlgOrder.options

        If m_dlgOrder.ok Then
            m_api.reqRealTimeBars(m_dlgOrder.orderId, m_contractInfo,
                                        5, m_dlgOrder.whatToShow, m_dlgOrder.useRTH, m_realTimeBarsOptions)
        End If

    End Sub

    '--------------------------------------------------------------------------------
    ' Cancel real time bars for a security
    '--------------------------------------------------------------------------------
    Private Sub cmdCancelRealTimeBars_Click(sender As Object, e As EventArgs) Handles cmdCancelRealTimeBars.Click
        ' Set the dialog state
        m_dlgOrder.init(dlgOrder.DialogType.CancelRealtimeBars,
            m_contractInfo, m_orderInfo, m_underComp, Nothing, Me)

        m_dlgOrder.ShowDialog()
        If m_dlgOrder.ok Then
            m_api.cancelRealTimeBars(m_dlgOrder.orderId)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Request current server time
    '--------------------------------------------------------------------------------
    Private Sub cmdReqCurrentTime_Click(sender As Object, e As EventArgs) Handles cmdReqCurrentTime.Click
        m_api.reqCurrentTime()
    End Sub

    '--------------------------------------------------------------------------------
    ' Perform market scans
    '--------------------------------------------------------------------------------
    Private Sub cmdScanner_Click(sender As Object, e As EventArgs) Handles cmdScanner.Click
        m_dlgScanner.ShowDialog()
    End Sub

    '--------------------------------------------------------------------------------
    ' Place a new or modify an existing order
    '--------------------------------------------------------------------------------
    Private Sub cmdWhatIf_Click(sender As Object, e As EventArgs) Handles cmdWhatIf.Click
        placeOrderImpl(True)
    End Sub
    Private Sub cmdPlaceOrder_Click(sender As Object, e As EventArgs) Handles cmdPlaceOrder.Click
        placeOrderImpl(False)
    End Sub
    Private Sub placeOrderImpl(whatIf As Boolean)

        ' Set the dialog state
        m_dlgOrder.init(dlgOrder.DialogType.PlaceOrder,
            m_contractInfo, m_orderInfo, m_underComp, m_orderInfo.OrderMiscOptions, Me)

        m_dlgOrder.ShowDialog()

        m_orderInfo.OrderMiscOptions = m_dlgOrder.options

        If m_dlgOrder.ok Then

            Dim savedWhatIf = m_orderInfo.WhatIf()
            m_orderInfo.WhatIf = whatIf
            m_api.placeOrder(m_dlgOrder.orderId, m_contractInfo, m_orderInfo)
            m_orderInfo.WhatIf = savedWhatIf
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Cancel an exisiting order
    '--------------------------------------------------------------------------------
    Private Sub cmdCancelOrder_Click(sender As Object, e As EventArgs) Handles cmdCancelOrder.Click
        ' Set the dialog state
        m_dlgOrder.init(dlgOrder.DialogType.CancelOrder,
            m_contractInfo, m_orderInfo, m_underComp, Nothing, Me)

        m_dlgOrder.ShowDialog()
        If m_dlgOrder.ok Then
            m_api.cancelOrder(m_dlgOrder.orderId)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Exercise options
    '--------------------------------------------------------------------------------
    Private Sub cmdExerciseOptions_Click(sender As Object, e As EventArgs) Handles cmdExerciseOptions.Click
        ' Set the dialog state
        m_dlgOrder.init(dlgOrder.DialogType.ExerciseOptions,
            m_contractInfo, m_orderInfo, m_underComp, Nothing, Me)

        m_dlgOrder.ShowDialog()
        If m_dlgOrder.ok Then
            ' TODO: get account in a less convoluted way
            m_api.exerciseOptions(m_dlgOrder.orderId, m_contractInfo,
                            m_dlgOrder.exerciseAction, m_dlgOrder.exerciseQuantity,
                            m_orderInfo.Account, m_dlgOrder.exerciseOverride)
        End If

    End Sub

    '--------------------------------------------------------------------------------
    ' Sets the extended order attributes
    '--------------------------------------------------------------------------------
    Private Sub cmdExtendedOrderAtribs_Click(sender As Object, e As EventArgs) Handles cmdExtendedOrderAtribs.Click
        Dim dlgOrderAttribs As New dlgOrderAttribs

        dlgOrderAttribs.init(Me, m_orderInfo)
        dlgOrderAttribs.ShowDialog()
        ' nothing to do besides that
    End Sub

    '--------------------------------------------------------------------------------
    ' Request the details for a contract
    '--------------------------------------------------------------------------------
    Private Sub cmdReqContractData_Click(sender As Object, e As EventArgs) Handles cmdReqContractData.Click
        ' Set the dialog state
        m_dlgOrder.init(dlgOrder.DialogType.RequestContractDetails,
            m_contractInfo, m_orderInfo, m_underComp, Nothing, Me)

        m_dlgOrder.ShowDialog()
        If m_dlgOrder.ok Then
            m_api.reqContractDetails(m_dlgOrder.orderId, m_contractInfo)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Request all the API open orders that were placed by this client. Note the
    ' clientID with a client id of 0 returns its, plus the TWS TWS open orders. Once
    ' requested the TWS orders retain their API asociation.
    '--------------------------------------------------------------------------------
    Private Sub cmdReqOpenOrders_Click(sender As Object, e As EventArgs) Handles cmdReqOpenOrders.Click
        m_api.reqOpenOrders()
    End Sub

    '--------------------------------------------------------------------------------
    ' Request the list of all the current open orders (from API clients and TWS). Note
    ' that no API order assoication is made.
    '--------------------------------------------------------------------------------
    Private Sub cmdReqAllOpenOrders_Click(sender As Object, e As EventArgs) Handles cmdReqAllOpenOrders.Click
        m_api.reqAllOpenOrders()
    End Sub

    '--------------------------------------------------------------------------------
    ' Request that all new TWS orders are automatically associated with this client.
    ' NOTE: This feature is only available for a client with client id of 0.
    '--------------------------------------------------------------------------------
    Private Sub cmdReqAutoOpenOrders_Click(sender As Object, e As EventArgs) Handles cmdReqAutoOpenOrders.Click
        m_api.reqAutoOpenOrders(True)
    End Sub

    '--------------------------------------------------------------------------------
    ' Requests account details
    '--------------------------------------------------------------------------------
    Private Sub cmdReqAcctData_Click(sender As Object, e As EventArgs) Handles cmdReqAcctData.Click
        Dim dlg As New dlgAcctUpdates

        dlg.ShowDialog()
        If (dlg.ok) Then
            If dlg.subscribe Then
                m_dlgAcctData.accountDownloadBegin(dlg.acctCode)
            End If
            m_api.reqAccountUpdates(CBool(dlg.subscribe), dlg.acctCode)
            If CBool(dlg.subscribe) Then
                m_dlgAcctData.ShowDialog()
            End If
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Request all todays execution reports
    '--------------------------------------------------------------------------------
    Private Sub cmdReqExecutions_Click(sender As Object, e As EventArgs) Handles cmdReqExecutions.Click
        Dim dlgExecFilter As New dlgExecFilter

        dlgExecFilter.init(m_execFilter)
        dlgExecFilter.ShowDialog()
        If dlgExecFilter.ok Then
            m_api.reqExecutions(dlgExecFilter.reqId, m_execFilter)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Requests the next avaliable order id for placing an order
    '--------------------------------------------------------------------------------
    Private Sub cmdReqIds_Click(sender As Object, e As EventArgs) Handles cmdReqIds.Click
        m_api.reqIds(1)
    End Sub

    '--------------------------------------------------------------------------------
    ' Requests to be notified for new IB news bulletins
    '--------------------------------------------------------------------------------
    Private Sub cmdReqNews_Click(sender As Object, e As EventArgs) Handles cmdReqNews.Click
        m_dlgNewsBulletins.ShowDialog()
        If m_dlgNewsBulletins.ok Then
            If m_dlgNewsBulletins.subscribe = True Then
                m_api.reqNewsBulletins(m_dlgNewsBulletins.allMsgs)
            Else
                m_api.cancelNewsBulletin()
            End If
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Sets the TWS server logging level
    '--------------------------------------------------------------------------------
    Private Sub cmdServerLogLevel_Click(sender As Object, e As EventArgs) Handles cmdServerLogLevel.Click
        m_dlgLogConfig.ShowDialog()
        If m_dlgLogConfig.ok Then
            m_api.setServerLogLevel(m_dlgLogConfig.serverLogLevel())
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Request managed accounts
    '--------------------------------------------------------------------------------
    Private Sub cmdReqAccts_Click(sender As Object, e As EventArgs) Handles cmdReqAccts.Click
        m_api.reqManagedAccts()
    End Sub

    Private Sub cmdFinancialAdvisor_Click(sender As Object, e As EventArgs) Handles cmdFinancialAdvisor.Click
        m_faGroupXML = ""
        m_faProfilesXML = ""
        m_faAliasesXML = ""
        faError = False
        m_api.requestFA(Utils.FaMessageType.Aliases)
        m_api.requestFA(Utils.FaMessageType.Groups)
        m_api.requestFA(Utils.FaMessageType.Profiles)
    End Sub

    '--------------------------------------------------------------------------------
    ' Calculate Implied Volatility
    '--------------------------------------------------------------------------------
    Private Sub cmdCalcImpliedVolatility_Click(sender As Object, e As EventArgs) Handles cmdCalcImpliedVolatility.Click
        ' Set the dialog state
        m_dlgOrder.init(dlgOrder.DialogType.CalculateImpliedVolatility,
            m_contractInfo, m_orderInfo, m_underComp, Nothing, Me)

        m_dlgOrder.ShowDialog()

        If m_dlgOrder.ok Then
            m_api.calculateImpliedVolatility(m_dlgOrder.orderId, m_contractInfo, m_orderInfo.LmtPrice, m_orderInfo.AuxPrice, Nothing)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Calculate Option Price
    '--------------------------------------------------------------------------------
    Private Sub cmdCalcOptionPrice_Click(sender As Object, e As EventArgs) Handles cmdCalcOptionPrice.Click
        ' Set the dialog state
        m_dlgOrder.init(dlgOrder.DialogType.CalculateOptionPrice,
            m_contractInfo, m_orderInfo, m_underComp, Nothing, Me)
        m_dlgOrder.ShowDialog()

        If m_dlgOrder.ok Then

            m_api.calculateOptionPrice(m_dlgOrder.orderId, m_contractInfo, m_orderInfo.LmtPrice, m_orderInfo.AuxPrice, Nothing)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Cancel Calculate Implied Volatility
    '--------------------------------------------------------------------------------
    Private Sub cmdCancelCalcImpliedVolatility_Click(sender As Object, e As EventArgs) Handles cmdCancelCalcImpliedVolatility.Click
        ' Set the dialog state
        m_dlgOrder.init(dlgOrder.DialogType.CancelCalculateImpliedVolatility,
            m_contractInfo, m_orderInfo, m_underComp, Nothing, Me)

        m_dlgOrder.ShowDialog()
        If m_dlgOrder.ok Then
            m_api.cancelCalculateImpliedVolatility(m_dlgOrder.orderId)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Cancel Calculate Option Price
    '--------------------------------------------------------------------------------
    Private Sub cmdCancelCalcOptionPrice_Click(sender As Object, e As EventArgs) Handles cmdCancelCalcOptionPrice.Click
        ' Set the dialog state
        m_dlgOrder.init(dlgOrder.DialogType.CancelCalculateOptionPrice,
   m_contractInfo, m_orderInfo, m_underComp, Nothing, Me)

        m_dlgOrder.ShowDialog()
        If m_dlgOrder.ok Then
            m_api.cancelCalculateOptionPrice(m_dlgOrder.orderId)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Request global cancel
    '--------------------------------------------------------------------------------
    Private Sub cmdReqGlobalCancel_Click(sender As Object, e As EventArgs) Handles cmdReqGlobalCancel.Click
        m_api.reqGlobalCancel()
    End Sub

    '--------------------------------------------------------------------------------
    ' Request market data type
    '--------------------------------------------------------------------------------
    Private Sub cmdReqMarketDataType_Click(sender As Object, e As EventArgs) Handles cmdReqMarketDataType.Click
        ' Set the dialog state
        m_dlgOrder.init(dlgOrder.DialogType.RequestMarketDataType,
            m_contractInfo, m_orderInfo, m_underComp, Nothing, Me)

        m_dlgOrder.ShowDialog()
        If m_dlgOrder.ok Then
            m_api.reqMarketDataType(m_dlgOrder.marketDataType)
        End If

        Select Case m_dlgOrder.marketDataType
            Case dlgOrder.MarketDataTypes.Realtime
                m_utils.addListItem(Utils.ListType.ServerResponses, "Frozen, Delayed and Delayed-Frozen market data types are disabled")
            Case dlgOrder.MarketDataTypes.Frozen
                m_utils.addListItem(Utils.ListType.ServerResponses, "Frozen market data type is enabled")
            Case dlgOrder.MarketDataTypes.Delayed
                m_utils.addListItem(Utils.ListType.ServerResponses, "Delayed market data type is enabled, Delayed-Frozen market data type is disabled")
            Case dlgOrder.MarketDataTypes.DelayedFrozen
                m_utils.addListItem(Utils.ListType.ServerResponses, "Delayed and Delayed-Frozen market data types are enabled")
            Case Else
                m_utils.addListItem(Utils.ListType.Errors, "Unknown market data type")
        End Select
    End Sub

    '--------------------------------------------------------------------------------
    ' Request positions
    '--------------------------------------------------------------------------------
    Private Sub cmdReqPositions_Click(sender As Object, e As EventArgs) Handles cmdReqPositions.Click
        m_api.reqPositions()
    End Sub

    '--------------------------------------------------------------------------------
    ' Cancel positions
    '--------------------------------------------------------------------------------
    Private Sub cmdCancelPositions_Click(sender As Object, e As EventArgs) Handles cmdCancelPositions.Click
        m_api.cancelPositions()
    End Sub

    '--------------------------------------------------------------------------------
    ' Request account summary
    '--------------------------------------------------------------------------------
    Private Sub cmdReqAccountSummary_Click(sender As Object, e As EventArgs) Handles cmdReqAccountSummary.Click

        Dim dlgAccountSummary As New dlgAccountSummary

        ' Set the dialog state
        dlgAccountSummary.init(dlgAccountSummary.Dlg_Type.REQUEST_ACCOUNT_SUMMARY)
        dlgAccountSummary.ShowDialog()

        If dlgAccountSummary.ok Then
            m_api.reqAccountSummary(dlgAccountSummary.reqId, dlgAccountSummary.groupName, dlgAccountSummary.tags)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Cancel account summary
    '--------------------------------------------------------------------------------
    Private Sub cmdCancelAccountSummary_Click(sender As Object, e As EventArgs) Handles cmdCancelAccountSummary.Click

        Dim dlgAccountSummary As New dlgAccountSummary

        ' Set the dialog state
        dlgAccountSummary.init(dlgAccountSummary.Dlg_Type.CANCEL_ACCOUNT_SUMMARY)
        dlgAccountSummary.ShowDialog()

        If dlgAccountSummary.ok Then
            m_api.cancelAccountSummary(dlgAccountSummary.reqId)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Open Groups dialog
    '--------------------------------------------------------------------------------
    Private Sub cmdGroups_Click(sender As Object, e As EventArgs) Handles cmdGroups.Click
        m_dlgGroups.init(m_utils, Me)
        m_dlgGroups.ShowDialog()
    End Sub

    '--------------------------------------------------------------------------------
    ' Request Positions Multi
    '--------------------------------------------------------------------------------
    Private Sub cmdReqPositionsMulti_Click(sender As Object, e As EventArgs) Handles cmdReqPositionsMulti.Click
        Dim dlgPositions As New dlgPositions

        ' Set the dialog state
        dlgPositions.init(dlgPositions.DialogType.RequestPositionsMulti)
        dlgPositions.ShowDialog()

        If dlgPositions.ok Then
            m_api.reqPositionsMulti(dlgPositions.id, dlgPositions.account, dlgPositions.modelCode)
        End If

    End Sub

    '--------------------------------------------------------------------------------
    ' Cancel Positions Multi
    '--------------------------------------------------------------------------------
    Private Sub cmdCancelPositionsMulti_Click(sender As Object, e As EventArgs) Handles cmdCancelPositionsMulti.Click
        Dim dlgPositions As New dlgPositions

        ' Set the dialog state
        dlgPositions.init(dlgPositions.DialogType.CancelPositionsMulti)
        dlgPositions.ShowDialog()

        If dlgPositions.ok Then
            m_api.cancelPositionsMulti(dlgPositions.id)
        End If


    End Sub

    '--------------------------------------------------------------------------------
    ' Request Account Updates Multi
    '--------------------------------------------------------------------------------
    Private Sub cmdReqAccountUpdatesMulti_Click(sender As Object, e As EventArgs) Handles cmdReqAccountUpdatesMulti.Click
        Dim dlgPositions As New dlgPositions

        ' Set the dialog state
        dlgPositions.init(dlgPositions.DialogType.RequestAccountUpdatesMulti)
        dlgPositions.ShowDialog()

        If dlgPositions.ok Then
            m_api.reqAccountUpdatesMulti(dlgPositions.id, dlgPositions.account, dlgPositions.modelCode, dlgPositions.ledgerAndNLV)
        End If

    End Sub

    '--------------------------------------------------------------------------------
    ' Cancel Account Updates Multi
    '--------------------------------------------------------------------------------
    Private Sub cmdCancelAccountUpdatesMulti_Click(sender As Object, e As EventArgs) Handles cmdCancelAccountUpdatesMulti.Click
        Dim dlgPositions As New dlgPositions

        ' Set the dialog state
        dlgPositions.init(dlgPositions.DialogType.CancelAccountUpdatesMulti)
        dlgPositions.ShowDialog()

        If dlgPositions.ok Then
            m_api.cancelAccountUpdatesMulti(dlgPositions.id)
        End If

    End Sub

    '--------------------------------------------------------------------------------
    ' Request Market Depth Exchanges
    '--------------------------------------------------------------------------------
    Private Sub cmdReqMktDepthExchanges_Click(sender As Object, e As EventArgs) Handles cmdReqMktDepthExchanges.Click
        m_api.reqMktDepthExchanges()
    End Sub

    '--------------------------------------------------------------------------------
    ' Clear the form display lists
    '--------------------------------------------------------------------------------
    Private Sub cmdClearForm_Click(sender As Object, e As EventArgs) Handles cmdClearForm.Click
        lstMktData.Items.Clear()
        lstServerResponses.Items.Clear()
        lstErrors.Items.Clear()
    End Sub

    '--------------------------------------------------------------------------------
    ' Shutdown the app
    '--------------------------------------------------------------------------------
    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdReqSecDefOptParams_Click(sender As Object, e As EventArgs) Handles cmdReqSecDefOptParams.Click
        Dim dlg = New dlgSecDefOptParamsReq()

        If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            m_api.reqSecDefOptParams(dlg.reqId, dlg.symbol, dlg.exchange, dlg.secType, dlg.conId)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Request Family Codes
    '--------------------------------------------------------------------------------
    Private Sub cmdFamilyCodes_Click(sender As Object, e As EventArgs) Handles cmdFamilyCodes.Click
        m_api.reqFamilyCodes()
    End Sub

    '--------------------------------------------------------------------------------
    ' Request Matching Symbols
    '--------------------------------------------------------------------------------
    Private Sub cmdReqMatchingSymbols_Click(sender As Object, e As EventArgs) Handles cmdReqMatchingSymbols.Click
        ' Set the dialog state
        m_dlgOrder.init(dlgOrder.DialogType.RequestMatchingSymbols,
        m_contractInfo, m_orderInfo, m_underComp, Nothing, Me)

        m_dlgOrder.ShowDialog()

        If m_dlgOrder.ok Then
            m_api.reqMatchingSymbols(m_dlgOrder.orderId, m_contractInfo.Symbol)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Request News Providers
    '--------------------------------------------------------------------------------
    Private Sub cmdReqNewsProviders_Click(sender As Object, e As EventArgs) Handles cmdReqNewsProviders.Click
        m_api.reqNewsProviders()
    End Sub


    Private Sub cmdReqSmartComponents_Click(sender As Object, e As EventArgs) Handles cmdReqSmartComponents.Click
        Dim dlg = New dlgSmartComponents

        If dlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            m_api.reqSmartComponents(CInt(dlg.txtReqId.Text), dlg.txtBBOExchange.Text)
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Request News Article
    '--------------------------------------------------------------------------------
    Private Sub cmdReqNewsArticle_Click(sender As Object, e As EventArgs) Handles cmdReqNewsArticle.Click
        Dim dlgNewsArticle As New dlgNewsArticle

        ' Set the dialog state
        dlgNewsArticle.init()
        dlgNewsArticle.ShowDialog()

        If dlgNewsArticle.ok Then
            m_api.reqNewsArticle(dlgNewsArticle.requestId, dlgNewsArticle.providerCode, dlgNewsArticle.articleId)
        End If

    End Sub

    '--------------------------------------------------------------------------------
    ' Request Historical News
    '--------------------------------------------------------------------------------
    Private Sub cmdReqHistoricalNews_Click(sender As Object, e As EventArgs) Handles cmdReqHistoricalNews.Click
        Dim dlg = New dlgHistoricalNews()
        dlg.ShowDialog()

        If dlg.ok Then
            m_api.reqHistoricalNews(dlg.requestId, dlg.conId, dlg.providerCodes, dlg.startDateTime, dlg.endDateTime, dlg.totalResults)
        End If
    End Sub

#End Region

#Region "API event handlers"

    '--------------------------------------------------------------------------------
    ' Returns the next valid order id upon connection - triggered by the connect() and
    ' reqNextValidId() methods
    '--------------------------------------------------------------------------------
    Private Sub Api_nextValidId(sender As Object, e As NextValidIdEventArgs) Handles m_apiEvents.NextValidId
        m_dlgOrder.orderId = e.Id
    End Sub

    '--------------------------------------------------------------------------------
    ' Notify the users of any API request processing errors and displays them in the
    ' server responses listbox
    '--------------------------------------------------------------------------------
    Private Sub Api_errMsg(sender As Object, e As ErrMsgEventArgs) Handles m_apiEvents.ErrMsg
        Dim msg = "id: " & e.id & " | Error Code: " & e.errorCode & " | Error Msg: " & e.errorMsg
        m_utils.addListItem(Utils.ListType.Errors, msg)

        ' move into view
        lstErrors.TopIndex = lstErrors.Items.Count - 1

        For Each errorCode In m_faErrorCodes
            If e.errorCode = errorCode Then faError = True
        Next

        If e.errorCode = MarketDepthDataResetError Then
            'm_dlgMktDepth.clear()
        End If

    End Sub

    '--------------------------------------------------------------------------------
    ' Notification that the TWS-API connection has been broken.
    '--------------------------------------------------------------------------------
    Private Sub Api_connectionClosed(sender As Object, e As EventArgs) Handles m_apiEvents.ConnectionClosed
        m_utils.addListItem(Utils.ListType.Errors, "Connection to Tws has been closed")

        ' move into view
        lstErrors.TopIndex = lstErrors.Items.Count - 1
    End Sub

    '--------------------------------------------------------------------------------
    ' Market data price tick event - triggered by the reqMktData() method
    '--------------------------------------------------------------------------------
    Private Sub Api_tickPrice(sender As Object, e As TickPriceEventArgs) Handles m_apiEvents.TickPrice
        Dim mktDataStr = "id=" & e.id & " " & m_utils.getField(e.tickType) & "=" & e.price
        If (e.attribs.CanAutoExecute <> 0) Then
            mktDataStr = mktDataStr & " canAutoExecute"
        Else
            mktDataStr = mktDataStr & " noAutoExecute"
        End If

        mktDataStr = mktDataStr & " " & e.attribs.PastLimit

        m_utils.addListItem(Utils.ListType.MarketData, mktDataStr)

        ' move into view
        lstMktData.TopIndex = lstMktData.Items.Count - 1
    End Sub

    '--------------------------------------------------------------------------------
    ' Market data size tick event - triggered by the reqMktData() method
    '--------------------------------------------------------------------------------
    Private Sub Api_tickSize(sender As Object, e As TickSizeEventArgs) Handles m_apiEvents.TickSize
        Dim mktDataStr = "id=" & e.id & " " & m_utils.getField(e.tickType) & "=" & e.size
        m_utils.addListItem(Utils.ListType.MarketData, mktDataStr)

        ' move into view
        lstMktData.TopIndex = lstMktData.Items.Count - 1
    End Sub

    '--------------------------------------------------------------------------------
    ' Market data generic tick event - triggered by the reqMktData() method
    '--------------------------------------------------------------------------------
    Private Sub Api_tickGeneric(sender As Object, e As TickGenericEventArgs) Handles m_apiEvents.TickGeneric
        Dim mktDataStr As String

        mktDataStr = "id=" & e.id & " " & m_utils.getField(e.tickType) & "=" & e.value
        m_utils.addListItem(Utils.ListType.MarketData, mktDataStr)

        ' move into view
        lstMktData.TopIndex = lstMktData.Items.Count - 1
    End Sub

    '--------------------------------------------------------------------------------
    ' Market data string tick event - triggered by the reqMktData() method
    '--------------------------------------------------------------------------------
    Private Sub Api_tickString(sender As Object, e As TickStringEventArgs) Handles m_apiEvents.TickString
        Dim mktDataStr = "id=" & e.id & " " & m_utils.getField(e.tickType) & "=" & e.value
        m_utils.addListItem(Utils.ListType.MarketData, mktDataStr)

        ' move into view
        lstMktData.TopIndex = lstMktData.Items.Count - 1
    End Sub

    '--------------------------------------------------------------------------------
    ' Market data EFP computation event - triggered by the reqMktData() method
    '--------------------------------------------------------------------------------
    Private Sub Api_tickEFP(sender As Object, e As TickEFPEventArgs) Handles m_apiEvents.TickEFP
        Dim mktDataStr = "id=" & e.tickerId & " " & m_utils.getField(e.field) & ":" &
             e.basisPoints & " / " & e.formattedBasisPoints &
             " totalDividends=" & e.totalDividends & " holdDays=" & e.holdDays &
             " futureLastTradeDate=" & e.futureLastTradeDate & " dividendImpact=" & e.dividendImpact &
             " dividendsToLastTradeDate=" & e.dividendsToLastTradeDate

        m_utils.addListItem(Utils.ListType.MarketData, mktDataStr)

        ' move into view
        lstMktData.TopIndex = lstMktData.Items.Count - 1
    End Sub

    '--------------------------------------------------------------------------------
    ' Market data option computation tick event - triggered by the reqMktData() method
    '--------------------------------------------------------------------------------
    Private Sub Api_tickOptionComputation(sender As Object, e As TickOptionComputationEventArgs) Handles m_apiEvents.TickOptionComputation
        Dim volStr As String, deltaStr As String, gammaStr As String, vegaStr As String,
            thetaStr As String, optPriceStr As String, pvDividendStr As String, undPriceStr As String

        If e.impliedVolatility = Double.MaxValue Or e.impliedVolatility < 0 Then
            volStr = "N/A"
        Else
            volStr = e.impliedVolatility
        End If
        If e.delta = Double.MaxValue Or Math.Abs(e.delta) > 1 Then
            deltaStr = "N/A"
        Else
            deltaStr = e.delta
        End If
        If e.gamma = Double.MaxValue Or Math.Abs(e.gamma) > 1 Then
            gammaStr = "N/A"
        Else
            gammaStr = e.gamma
        End If
        If e.vega = Double.MaxValue Or Math.Abs(e.vega) > 1 Then
            vegaStr = "N/A"
        Else
            vegaStr = e.vega
        End If
        If e.theta = Double.MaxValue Or Math.Abs(e.theta) > 1 Then
            thetaStr = "N/A"
        Else
            thetaStr = e.theta
        End If
        If e.optPrice = Double.MaxValue Then
            optPriceStr = "N/A"
        Else
            optPriceStr = e.optPrice
        End If
        If e.pvDividend = Double.MaxValue Then
            pvDividendStr = "N/A"
        Else
            pvDividendStr = e.pvDividend
        End If
        If e.undPrice = Double.MaxValue Then
            undPriceStr = "N/A"
        Else
            undPriceStr = e.undPrice
        End If
        Dim mktDataStr = "id = " & e.tickerId & " " & m_utils.getField(e.tickType) & " vol = " & volStr & " delta = " & deltaStr &
            " gamma = " & gammaStr & " vega = " & vegaStr & " theta = " & thetaStr &
            " optPrice = " & optPriceStr & " pvDividend = " & pvDividendStr & " undPrice = " & undPriceStr
        m_utils.addListItem(Utils.ListType.MarketData, mktDataStr)
    End Sub

    '--------------------------------------------------------------------------------
    ' Market depth book entry - triggered by the reqMktDepth() method
    '--------------------------------------------------------------------------------
    Private Sub Api_updateMktDepth(sender As Object, e As UpdateMktDepthEventArgs) Handles m_apiEvents.UpdateMktDepth
        m_dlgMktDepth.updateMktDepth(e.tickerId, e.position, " ", e.operation, e.side, e.price, e.size)
    End Sub

    '--------------------------------------------------------------------------------
    ' Market depth Level II book entry - triggered by the reqMktDepth() method
    '--------------------------------------------------------------------------------
    Private Sub Api_updateMktDepthL2(sender As Object, e As UpdateMktDepthL2EventArgs) Handles m_apiEvents.UpdateMktDepthL2
        m_dlgMktDepth.updateMktDepth(e.tickerId, e.position, e.marketMaker, e.operation, e.side, e.price, e.size)
    End Sub

    '--------------------------------------------------------------------------------
    ' Historical data tick event - triggered by the reqHistoricalData() method
    '--------------------------------------------------------------------------------
    Private Sub Api_historicalData(sender As Object, e As HistoricalDataEventArgs) Handles m_apiEvents.HistoricalData
        Dim mktDataStr = "id=" & e.reqId & " date=" & e.date & " open=" & e.open & " high=" & e.high &
                     " low=" & e.low & " close=" & e.close & " volume=" & e.volume &
                     " barCount=" & e.count & " WAP=" & e.WAP
        If (e.hasGaps <> 0) Then
            mktDataStr = mktDataStr & " has gaps"
        Else
            mktDataStr = mktDataStr & " no gaps"
        End If
        m_utils.addListItem(Utils.ListType.MarketData, mktDataStr)

        ' move into view
        lstMktData.TopIndex = lstMktData.Items.Count - 1
    End Sub

    '--------------------------------------------------------------------------------
    ' Historical data end event - triggered by the reqHistoricalData() method after all historical data has been received
    '--------------------------------------------------------------------------------
    Private Sub Api_historicalDataEnd(sender As Object, e As HistoricalDataEndEventArgs) Handles m_apiEvents.HistoricalDataEnd
        Dim mktDataStr = "id=" & e.reqId & " start=" & e.start & " end=" & e.end
        m_utils.addListItem(Utils.ListType.MarketData, mktDataStr)

        ' move into view
        lstMktData.TopIndex = lstMktData.Items.Count - 1
    End Sub

    '--------------------------------------------------------------------------------
    ' Real Time Bar event - triggered by the reqRealTimeBar() method
    '--------------------------------------------------------------------------------
    Private Sub Api_realtimeBar(sender As Object, e As RealtimeBarEventArgs) Handles m_apiEvents.RealtimeBar

        Dim mktDataStr = "id=" & e.reqId & " time=" & e.time & " open=" & e.open & " high=" & e.high &
                     " low=" & e.low & " close=" & e.close & " volume=" & e.volume & " WAP=" & e.WAP & " count=" & e.count

        m_utils.addListItem(Utils.ListType.MarketData, mktDataStr)

        ' move into view
        lstMktData.TopIndex = lstMktData.Items.Count - 1
    End Sub

    '--------------------------------------------------------------------------------
    ' Fundamental Data event - triggered by the reqFundamentalData() method
    '--------------------------------------------------------------------------------
    Private Sub Api_fundamentalData(sender As Object, e As FundamentalDataEventArgs) Handles m_apiEvents.FundamentalData

        With e
            m_utils.addListItem(Utils.ListType.MarketData, "fund reqId=" & .reqId & " len=" & Len(.data))
            m_utils.displayMultiline(Utils.ListType.MarketData, .data)
        End With

    End Sub

    '--------------------------------------------------------------------------------
    ' Current Time event - triggered by the reqCurrentTime() methods
    '--------------------------------------------------------------------------------
    Private Sub Api_currentTime(sender As Object, e As CurrentTimeEventArgs) Handles m_apiEvents.CurrentTime
        Dim offset = lstServerResponses.Items.Count
        Dim displayString = "current time = " & e.time

        m_utils.addListItem(Utils.ListType.ServerResponses, displayString)

        ' move into view
        lstServerResponses.TopIndex = offset
    End Sub

    '--------------------------------------------------------------------------------
    ' Market Scanner related events
    '--------------------------------------------------------------------------------
    Private Sub Api_scannerParameters(sender As Object, e As ScannerParametersEventArgs) Handles m_apiEvents.ScannerParameters
        Dim xmlDoc = ProduceXMLDoc()
        xmlDoc.LoadXml(e.xml)
        Dim node1 = getRootNode(xmlDoc)
        m_utils.addListItem(Utils.ListType.ServerResponses, "SCANNER PARAMETERS " & node1.Name & " document.")
        node1 = node1.SelectSingleNode("InstrumentList")
        Dim name1 = parseNode(node1.FirstChild, "name")
        Dim theType1 = parseNode(node1.FirstChild, "type")
        Dim name2 = parseNode(node1.FirstChild.NextSibling, "name")
        Dim theType2 = parseNode(node1.FirstChild.NextSibling, "type")
        m_utils.addListItem(Utils.ListType.ServerResponses, "InstrumentList starts with (" & name1 & "," & theType1 & ") " & "followed by (" & name2 & "," & theType2 & ")")
        m_utils.displayMultiline(Utils.ListType.ServerResponses, (e.xml))
    End Sub

    Private Sub Api_scannerData(sender As Object, e As ScannerDataEventArgs) Handles m_apiEvents.ScannerData
        Dim contractDetails = e.contractDetails

        Dim contract = contractDetails.Summary

        Dim mktDataStr = "id=" & e.reqId & " rank=" & e.rank & " conId=" & contract.ConId &
                     " symbol=" & contract.Symbol & " secType=" & contract.SecType & " currency=" & contract.Currency &
                     " localSymbol=" & contract.LocalSymbol & " marketName=" & contractDetails.MarketName &
                     " tradingClass=" & contract.TradingClass & " distance=" & e.distance &
                     " benchmark=" & e.benchmark & " projection=" & e.projection &
                     " legsStr=" & e.legsStr
        m_utils.addListItem(Utils.ListType.MarketData, mktDataStr)

        ' move into view
        lstMktData.TopIndex = lstMktData.Items.Count - 1
    End Sub
    Private Sub Api_scannerDataEnd(sender As Object, e As ScannerDataEndEventArgs) Handles m_apiEvents.ScannerDataEnd
        Dim str = "id=" & e.reqId & " =============== end ==============="
        m_utils.addListItem(Utils.ListType.MarketData, str)

        ' move into view
        lstMktData.TopIndex = lstMktData.Items.Count - 1
    End Sub

    '--------------------------------------------------------------------------------
    ' Notification of an updates order status - triggered by an order state change.
    '--------------------------------------------------------------------------------
    Private Sub Api_orderStatus(sender As Object, e As OrderStatusEventArgs) Handles m_apiEvents.OrderStatus
        Dim offset = lstServerResponses.Items.Count
        Dim msg = "order status: orderId=" & e.orderId & " client id=" & e.clientId & " permId=" & e.permId &
              " status=" & e.status & " filled=" & e.filled & " remaining=" & e.remaining &
              " avgFillPrice=" & e.avgFillPrice & " lastFillPrice=" & e.lastFillPrice &
              " parentId=" & e.parentId & " whyHeld=" & e.whyHeld

        m_utils.addListItem(Utils.ListType.ServerResponses, msg)

        ' move into view
        lstServerResponses.TopIndex = offset
    End Sub

    '--------------------------------------------------------------------------------
    ' The details for a requested contract - triggered by the reqContractDetailsEx method
    '--------------------------------------------------------------------------------
    Private Sub Api_contractDetails(sender As Object, e As ContractDetailsEventArgs) Handles m_apiEvents.ContractDetails
        Dim offset = lstServerResponses.Items.Count
        m_utils.addListItem(Utils.ListType.ServerResponses, "reqId = " & e.reqId & " ===================================")

        Dim contract = e.contractDetails.Summary
        m_utils.addListItem(Utils.ListType.ServerResponses, " ---- Contract Details Begin ----")
        m_utils.addListItem(Utils.ListType.ServerResponses, "Contract:")
        m_utils.addListItem(Utils.ListType.ServerResponses, "  conId = " & contract.ConId)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  symbol = " & contract.Symbol)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  secType = " & contract.SecType)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  lastTradeDate = " & contract.LastTradeDateOrContractMonth)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  strike = " & contract.Strike)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  right = " & contract.Right)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  multiplier = " & contract.Multiplier)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  exchange = " & contract.Exchange)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  primaryExchange = " & contract.PrimaryExch)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  currency = " & contract.Currency)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  localSymbol = " & contract.LocalSymbol)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  tradingClass = " & contract.TradingClass)

        Dim contractDetails = e.contractDetails
        m_utils.addListItem(Utils.ListType.ServerResponses, "Details:")
        m_utils.addListItem(Utils.ListType.ServerResponses, "  marketName = " & contractDetails.MarketName)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  minTick = " & contractDetails.MinTick)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  priceMagnifier = " & contractDetails.PriceMagnifier)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  orderTypes = " & contractDetails.OrderTypes)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  validExchanges = " & contractDetails.ValidExchanges)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  underConId = " & contractDetails.UnderConId)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  longName = " & contractDetails.LongName)

        If (contract.SecType <> "BOND") Then
            m_utils.addListItem(Utils.ListType.ServerResponses, "  contractMonth = " & contractDetails.ContractMonth)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  industry = " & contractDetails.Industry)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  category = " & contractDetails.Category)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  subcategory = " & contractDetails.Subcategory)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  timeZoneId = " & contractDetails.TimeZoneId)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  tradingHours = " & contractDetails.TradingHours)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  liquidHours = " & contractDetails.LiquidHours)
        End If
        m_utils.addListItem(Utils.ListType.ServerResponses, "  evRule = " & contractDetails.EvRule)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  evMultiplier = " & contractDetails.EvMultiplier)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  mdSizeMultiplier = " & contractDetails.MdSizeMultiplier)

        If (contract.SecType = "BOND") Then

            m_utils.addListItem(Utils.ListType.ServerResponses, "Bond Details:")
            m_utils.addListItem(Utils.ListType.ServerResponses, "  cusip = " & contractDetails.Cusip)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  ratings = " & contractDetails.Ratings)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  descAppend = " & contractDetails.DescAppend)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  bondType = " & contractDetails.BondType)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  couponType = " & contractDetails.CouponType)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  callable = " & contractDetails.Callable)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  putable = " & contractDetails.Putable)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  coupon = " & contractDetails.Coupon)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  convertible = " & contractDetails.Convertible)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  maturity = " & contractDetails.Maturity)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  issueDate = " & contractDetails.IssueDate)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  nextOptionDate = " & contractDetails.NextOptionDate)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  nextOptionType = " & contractDetails.NextOptionType)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  nextOptionPartial = " & contractDetails.NextOptionPartial)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  notes = " & contractDetails.Notes)


        End If

        ' CUSIP/ISIN/etc.
        m_utils.addListItem(Utils.ListType.ServerResponses, "  secIdList={")
        Dim secIdList = contractDetails.SecIdList
        If (Not secIdList Is Nothing) Then
            For Each param In secIdList
                m_utils.addListItem(Utils.ListType.ServerResponses, "    " & param.Tag & "=" & param.Value)
            Next
        End If
        m_utils.addListItem(Utils.ListType.ServerResponses, "  }")

        m_utils.addListItem(Utils.ListType.ServerResponses, " ---- Contract Details End ----")

        ' move into view
        lstServerResponses.TopIndex = offset
    End Sub

    Private Sub Api_contractDetailsEnd(sender As Object, e As ContractDetailsEndEventArgs) Handles m_apiEvents.ContractDetailsEnd
        Dim offset = lstServerResponses.Items.Count
        m_utils.addListItem(Utils.ListType.ServerResponses, "reqId = " & e.reqId & " =============== end ===============")

        ' move into view
        lstServerResponses.TopIndex = offset
    End Sub

    '--------------------------------------------------------------------------------
    ' Returns the details for an open order - triggered by the reqOpenOrders() method
    '--------------------------------------------------------------------------------
    Private Sub Api_openOrder(sender As Object, e As OpenOrderEventArgs) Handles m_apiEvents.OpenOrder
        m_utils.addListItem(Utils.ListType.ServerResponses, "OpenOrderEx called, orderId=" & e.orderId)

        Dim order = e.order
        m_utils.addListItem(Utils.ListType.ServerResponses, "Order:")
        m_utils.addListItem(Utils.ListType.ServerResponses, "  orderId=" & order.OrderId)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  clientId=" & order.ClientId)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  permId=" & order.PermId)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  action=" & order.Action)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  quantity=" & order.TotalQuantity)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  orderType=" & order.OrderType)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  lmtPrice=" & DblMaxStr(order.LmtPrice))
        m_utils.addListItem(Utils.ListType.ServerResponses, "  auxPrice=" & DblMaxStr(order.AuxPrice))
        m_utils.addListItem(Utils.ListType.ServerResponses, "  cashQty=" & DblMaxStr(order.CashQty))

        Dim contract = e.contract
        m_utils.addListItem(Utils.ListType.ServerResponses, "Contract:")
        m_utils.addListItem(Utils.ListType.ServerResponses, "  conId=" & contract.ConId)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  symbol=" & contract.Symbol)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  secType=" & contract.SecType)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  lastTradeDate=" & contract.LastTradeDateOrContractMonth)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  strike=" & contract.Strike)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  right=" & contract.Right)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  multiplier=" & contract.Multiplier)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  exchange=" & contract.Exchange)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  primaryExchange=" & contract.PrimaryExch)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  currency=" & contract.Currency)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  localSymbol=" & contract.LocalSymbol)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  tradingClass=" & contract.TradingClass)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  comboLegsDescrip=" & contract.ComboLegsDescription)

        ' combo legs
        m_utils.addListItem(Utils.ListType.ServerResponses, "  comboLegs={")

        If contract.ComboLegs IsNot Nothing Then
            Dim comboLegsCount = contract.ComboLegs.Count

            Dim orderComboLegsCount = 0
            If order.OrderComboLegs IsNot Nothing Then
                orderComboLegsCount = order.OrderComboLegs.Count()
            End If

            Dim i = 0
            For Each comboLeg In contract.ComboLegs
                Dim orderComboLegPriceStr = ""

                If comboLegsCount = orderComboLegsCount Then
                    Dim orderComboLeg = order.OrderComboLegs.Item(i)
                    orderComboLegPriceStr = " price=" & DblMaxStr(orderComboLeg.Price)
                End If

                m_utils.addListItem(Utils.ListType.ServerResponses,
                                    "    leg " & (i + 1) &
                                    ": conId=" & comboLeg.ConId & " ratio=" & comboLeg.Ratio & " action=" & comboLeg.Action &
                                    " exchange = " & comboLeg.Exchange & " openClose=" & comboLeg.OpenClose &
                                    " shortSaleSlot=" & comboLeg.ShortSaleSlot & " designatedLocation=" & comboLeg.DesignatedLocation &
                                    " exemptCode=" & comboLeg.ExemptCode & orderComboLegPriceStr)
                i += 1
            Next
        End If
        m_utils.addListItem(Utils.ListType.ServerResponses, "  }")

        Dim underComp = contract.UnderComp

        If (Not underComp Is Nothing) Then
            With underComp
                m_utils.addListItem(Utils.ListType.ServerResponses, "  underComp.conId=" & .ConId)
                m_utils.addListItem(Utils.ListType.ServerResponses, "  underComp.delta=" & .Delta)
                m_utils.addListItem(Utils.ListType.ServerResponses, "  underComp.delta=" & .Price)
            End With
        End If


        m_utils.addListItem(Utils.ListType.ServerResponses, "Order (extended):")
        m_utils.addListItem(Utils.ListType.ServerResponses, "  timeInForce=" & order.Tif)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  ocaGroup=" & order.OcaGroup)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  ocaType=" & order.OcaType)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  orderRef=" & order.OrderRef)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  transmit=" & order.Transmit)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  parentId=" & order.ParentId)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  blockOrder=" & order.BlockOrder)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  sweepToFill=" & order.SweepToFill)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  displaySize=" & order.DisplaySize)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  triggerMethod=" & order.TriggerMethod)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  outsideRth=" & order.OutsideRth)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  hidden=" & order.Hidden)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  goodAfterTime=" & order.GoodAfterTime)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  goodTillDate=" & order.GoodTillDate)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  overridePercentageConstraints=" & order.OverridePercentageConstraints)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  rule80A=" & order.Rule80A)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  allOrNone=" & order.AllOrNone)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  minQty=" & IntMaxStr(order.MinQty))
        m_utils.addListItem(Utils.ListType.ServerResponses, "  percentOffset=" & DblMaxStr(order.PercentOffset))
        m_utils.addListItem(Utils.ListType.ServerResponses, "  trailStopPrice=" & DblMaxStr(order.TrailStopPrice))
        m_utils.addListItem(Utils.ListType.ServerResponses, "  trailingPercent=" & DblMaxStr(order.TrailingPercent))
        m_utils.addListItem(Utils.ListType.ServerResponses, "  whatIf=" & order.WhatIf)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  notHeld=" & order.NotHeld)

        ' Financial advisors only
        m_utils.addListItem(Utils.ListType.ServerResponses, "  faGroup=" & order.FaGroup)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  faProfile=" & order.FaProfile)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  faMethod=" & order.FaMethod)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  faPercentage=" & order.FaPercentage)

        ' Clearing info
        m_utils.addListItem(Utils.ListType.ServerResponses, "  account=" & order.Account)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  modelCode=" & order.ModelCode)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  settlingFirm=" & order.SettlingFirm)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  clearingAccount=" & order.ClearingAccount)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  clearingIntent=" & order.ClearingIntent)

        ' Institutional orders only
        m_utils.addListItem(Utils.ListType.ServerResponses, "  openClose=" & order.OpenClose)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  origin=" & order.Origin)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  shortSaleSlot=" & order.ShortSaleSlot)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  designatedLocation=" & order.DesignatedLocation)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  exemptCode=" & order.ExemptCode)

        ' SMART routing only
        m_utils.addListItem(Utils.ListType.ServerResponses, "  discretionaryAmt=" & order.DiscretionaryAmt)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  eTradeOnly=" & order.ETradeOnly)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  firmQuoteOnly=" & order.FirmQuoteOnly)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  nbboPriceCap=" & DblMaxStr(order.NbboPriceCap))
        m_utils.addListItem(Utils.ListType.ServerResponses, "  optOutSmartRouting=" & order.OptOutSmartRouting)

        ' BOX or VOL orders only
        m_utils.addListItem(Utils.ListType.ServerResponses, "  auctionStrategy=" & order.AuctionStrategy)

        ' BOX order only
        m_utils.addListItem(Utils.ListType.ServerResponses, "  startingPrice=" & DblMaxStr(order.StartingPrice))
        m_utils.addListItem(Utils.ListType.ServerResponses, "  stockRefPrice=" & DblMaxStr(order.StockRefPrice))
        m_utils.addListItem(Utils.ListType.ServerResponses, "  delta=" & DblMaxStr(order.Delta))

        ' pegged to stock or VOL orders
        m_utils.addListItem(Utils.ListType.ServerResponses, "  stockRangeLower=" & DblMaxStr(order.StockRangeLower))
        m_utils.addListItem(Utils.ListType.ServerResponses, "  stockRangeUpper=" & DblMaxStr(order.StockRangeUpper))

        ' VOLATILITY orders only
        m_utils.addListItem(Utils.ListType.ServerResponses, "  volatility=" & DblMaxStr(order.Volatility))
        m_utils.addListItem(Utils.ListType.ServerResponses, "  volatilityType=" & order.VolatilityType)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  continuousUpdate=" & order.ContinuousUpdate)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  referencePriceType=" & order.ReferencePriceType)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  deltaNeutralOrderType=" & order.DeltaNeutralOrderType)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  deltaNeutralAuxPrice=" & DblMaxStr(order.DeltaNeutralAuxPrice))
        m_utils.addListItem(Utils.ListType.ServerResponses, "  deltaNeutralConId=" & order.DeltaNeutralConId)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  deltaNeutralSettlingFirm=" & order.DeltaNeutralSettlingFirm)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  deltaNeutralClearingAccount=" & order.DeltaNeutralClearingAccount)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  deltaNeutralClearingIntent=" & order.DeltaNeutralClearingIntent)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  deltaNeutralOpenClose=" & order.DeltaNeutralOpenClose)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  deltaNeutralShortSale=" & order.DeltaNeutralShortSale)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  deltaNeutralShortSaleSlot=" & order.DeltaNeutralShortSaleSlot)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  deltaNeutralDesignatedlocation=" & order.DeltaNeutralDesignatedLocation)

        ' COMBO orders only
        m_utils.addListItem(Utils.ListType.ServerResponses, "  basisPoints=" & DblMaxStr(order.BasisPoints))
        m_utils.addListItem(Utils.ListType.ServerResponses, "  basisPointsType=" & IntMaxStr(order.BasisPointsType))

        ' SCALE orders only
        m_utils.addListItem(Utils.ListType.ServerResponses, "  scaleInitLevelSize=" & IntMaxStr(order.ScaleInitLevelSize))
        m_utils.addListItem(Utils.ListType.ServerResponses, "  scaleSubsLevelSize=" & IntMaxStr(order.ScaleSubsLevelSize))
        m_utils.addListItem(Utils.ListType.ServerResponses, "  scalePriceIncrement=" & DblMaxStr(order.ScalePriceIncrement))
        m_utils.addListItem(Utils.ListType.ServerResponses, "  scalePriceAdjustValue=" & DblMaxStr(order.ScalePriceAdjustValue))
        m_utils.addListItem(Utils.ListType.ServerResponses, "  scalePriceAdjustInterval=" & IntMaxStr(order.ScalePriceAdjustInterval))
        m_utils.addListItem(Utils.ListType.ServerResponses, "  scaleProfitOffset=" & DblMaxStr(order.ScaleProfitOffset))
        m_utils.addListItem(Utils.ListType.ServerResponses, "  scaleAutoReset=" & order.ScaleAutoReset)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  scaleInitPosition=" & IntMaxStr(order.ScaleInitPosition))
        m_utils.addListItem(Utils.ListType.ServerResponses, "  scaleInitFillQty=" & IntMaxStr(order.ScaleInitFillQty))
        m_utils.addListItem(Utils.ListType.ServerResponses, "  scaleRandomPercent=" & IntMaxStr(order.ScaleRandomPercent))

        ' HEDGE orders only
        m_utils.addListItem(Utils.ListType.ServerResponses, "  hedgeType=" & order.HedgeType)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  hedgeParam=" & order.HedgeParam)

        ' Solicited orders only
        m_utils.addListItem(Utils.ListType.ServerResponses, "  solicited=" & order.Solicited)

        m_utils.addListItem(Utils.ListType.ServerResponses, "  randomize size=" & order.RandomizeSize)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  randomize price=" & order.RandomizePrice)

        ' ALGO orders only
        Dim algoStrategy = order.AlgoStrategy
        If (algoStrategy <> "") Then
            m_utils.addListItem(Utils.ListType.ServerResponses, "  algoStrategy=" & algoStrategy)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  algoParams={")
            If (order.AlgoParams IsNot Nothing) Then
                For Each param In order.AlgoParams
                    m_utils.addListItem(Utils.ListType.ServerResponses, "    " & param.Tag & "=" & param.Value)
                Next
            End If
            m_utils.addListItem(Utils.ListType.ServerResponses, "  }")
        End If

        ' Smart combo routing params
        m_utils.addListItem(Utils.ListType.ServerResponses, "  smartComboRoutingParams={")
        If (order.SmartComboRoutingParams IsNot Nothing) Then
            For Each param In order.SmartComboRoutingParams
                m_utils.addListItem(Utils.ListType.ServerResponses, "    " & param.Tag & "=" & param.Value)
            Next
        End If
        m_utils.addListItem(Utils.ListType.ServerResponses, "  }")

        Dim orderState = e.orderState
        m_utils.addListItem(Utils.ListType.ServerResponses, "OrderState:")
        m_utils.addListItem(Utils.ListType.ServerResponses, "  status=" & orderState.Status)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  initMargin=" & orderState.InitMargin)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  maintMargin=" & orderState.MaintMargin)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  equityWithLoan=" & orderState.EquityWithLoan)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  commission=" & DblMaxStr(orderState.Commission))
        m_utils.addListItem(Utils.ListType.ServerResponses, "  minCommission=" & DblMaxStr(orderState.MinCommission))
        m_utils.addListItem(Utils.ListType.ServerResponses, "  maxCommission=" & DblMaxStr(orderState.MaxCommission))
        m_utils.addListItem(Utils.ListType.ServerResponses, "  comissionCurrency=" & orderState.CommissionCurrency)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  warningText=" & orderState.WarningText)

        m_utils.addListItem(Utils.ListType.ServerResponses, "===============================")

    End Sub

    Private Sub Api_openOrderEnd(sender As Object, e As EventArgs) Handles m_apiEvents.OpenOrderEnd
        m_utils.addListItem(Utils.ListType.ServerResponses, "============= end =============")

        ' move into view
        lstServerResponses.TopIndex = lstServerResponses.Items.Count - 1
    End Sub

    Private Sub Api_deltaNeutralValidation(sender As Object, e As DeltaNeutralValidationEventArgs) Handles m_apiEvents.DeltaNeutralValidation
        m_utils.addListItem(Utils.ListType.ServerResponses, "deltaNeutralValidation called, reqId=" & e.reqId)

        Dim underComp = e.underComp

        If (underComp IsNot Nothing) Then
            With underComp
                m_utils.addListItem(Utils.ListType.ServerResponses, "  underComp.conId=" & .ConId)
                m_utils.addListItem(Utils.ListType.ServerResponses, "  underComp.delta=" & .Delta)
                m_utils.addListItem(Utils.ListType.ServerResponses, "  underComp.delta=" & .Price)
            End With
        End If
    End Sub

    Private Sub Api_tickSnapshotEnd(sender As Object, e As TickSnapshotEndEventArgs) Handles m_apiEvents.TickSnapshotEnd
        m_utils.addListItem(Utils.ListType.MarketData, "id=" & e.tickerId & " =============== end ===============")

        ' move into view
        lstServerResponses.TopIndex = lstServerResponses.Items.Count - 1
    End Sub

    '--------------------------------------------------------------------------------
    ' Notification of an updated/new portfolio position - triggered by the reqAcctUpdates() method
    '--------------------------------------------------------------------------------
    Private Sub Api_updatePortfolio(sender As Object, e As UpdatePortfolioEventArgs) Handles m_apiEvents.UpdatePortfolio
        m_dlgAcctData.updatePortfolio(e.contract, e.position, e.marketPrice, e.marketValue, e.averageCost, e.unrealisedPNL, e.realisedPNL, e.accountName)
    End Sub

    '--------------------------------------------------------------------------------
    ' Notification of a server time update - triggered by the reqAcctUpdates() method
    '--------------------------------------------------------------------------------
    Private Sub Api_updateAccountTime(sender As Object, e As UpdateAccountTimeEventArgs) Handles m_apiEvents.UpdateAccountTime
        m_dlgAcctData.updateAccountTime(e.timestamp)
    End Sub

    '--------------------------------------------------------------------------------
    ' Notification of an account proprty update - triggered by the reqAcctUpdates() method
    '--------------------------------------------------------------------------------
    Private Sub Api_updateAccountValue(sender As Object, e As UpdateAccountValueEventArgs) Handles m_apiEvents.UpdateAccountValue
        m_dlgAcctData.updateAccountValue(e.key, e.value, e.currency, e.accountName)
    End Sub

    Private Sub Api_accountDownloadEnd(sender As Object, e As AccountDownloadEndEventArgs) Handles m_apiEvents.AccountDownloadEnd
        Dim accountName = e.account
        m_dlgAcctData.accountDownloadEnd(accountName)
        m_utils.addListItem(Utils.ListType.ServerResponses, "Account Download End:" & accountName)
    End Sub

    '--------------------------------------------------------------------------------
    ' An order execution report. This event is triggered by the explicit request for
    ' execution reports reqExecutionDetials(), and also by order state changes method
    '--------------------------------------------------------------------------------
    Private Sub Api_execDetails(sender As Object, e As ExecDetailsEventArgs) Handles m_apiEvents.ExecDetails
        Dim offset = lstServerResponses.Items.Count
        m_utils.addListItem(Utils.ListType.ServerResponses, " ---- Execution Details begin ----")

        m_utils.addListItem(Utils.ListType.ServerResponses, "reqId = " & e.reqId)

        m_utils.addListItem(Utils.ListType.ServerResponses, "Contract:")
        With e.contract

            m_utils.addListItem(Utils.ListType.ServerResponses, "  conId=" & .ConId)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  symbol=" & .Symbol)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  secType=" & .SecType)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  lastTradeDate=" & .LastTradeDateOrContractMonth)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  strike=" & .Strike)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  right=" & .Right)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  multiplier=" & .Multiplier)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  exchange=" & .Exchange)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  primaryExchange=" & .PrimaryExch)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  currency=" & .Currency)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  localSymbol=" & .LocalSymbol)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  tradingClass=" & .TradingClass)

        End With

        m_utils.addListItem(Utils.ListType.ServerResponses, "Execution:")
        With e.execution

            m_utils.addListItem(Utils.ListType.ServerResponses, "  execId = " & .ExecId)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  orderId = " & .OrderId)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  clientId = " & .ClientId)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  permId = " & .PermId)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  time = " & .Time)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  acctNumber = " & .AcctNumber)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  modelCode = " & .ModelCode)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  exchange = " & .Exchange)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  side = " & .Side)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  shares = " & .Shares)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  price = " & .Price)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  liquidation = " & .Liquidation)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  cumQty = " & .CumQty)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  avgPrice = " & .AvgPrice)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  orderRef = " & .OrderRef)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  evRule = " & .EvRule)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  evMultiplier = " & .EvMultiplier)

        End With

        m_utils.addListItem(Utils.ListType.ServerResponses, " ---- Execution Details End ----")

        ' move into view
        lstServerResponses.TopIndex = offset
    End Sub

    Private Sub Api_execDetailsEnd(sender As Object, e As ExecDetailsEndEventArgs) Handles m_apiEvents.ExecDetailsEnd
        m_utils.addListItem(Utils.ListType.ServerResponses, "reqId = " & e.reqId & " =============== end ===============")

        ' move into view
        lstServerResponses.TopIndex = lstServerResponses.Items.Count - 1
    End Sub

    '--------------------------------------------------------------------------------
    ' Notification of a new IB news bulletin
    '--------------------------------------------------------------------------------
    Private Sub Api_updateNewsBulletin(sender As Object, e As UpdateNewsBulletinEventArgs) Handles m_apiEvents.UpdateNewsBulletin
        Dim dlg As New dlgServerResponse
        dlg.Text = "IB News Bulletin"
        dlg.lblMsg.Text = " MsgId=" & e.msgId & " :: MsgType=" & e.msgType & " :: Origin=" & e.origExchange & " :: Message=" & e.message
        dlg.Show()
    End Sub

    '--------------------------------------------------------------------------------
    ' Notification of the FA managed accounts (comma delimited list of account codes)
    '--------------------------------------------------------------------------------
    Private Sub Api_managedAccounts(sender As Object, e As ManagedAccountsEventArgs) Handles m_apiEvents.ManagedAccounts
        Dim msg = "Connected : The list of managed accounts are : [" & e.accountsList & "]"
        m_utils.addListItem(Utils.ListType.ServerResponses, msg)

        m_faAccount = True
        m_faAcctsList = e.accountsList
    End Sub

    Private Sub Api_receiveFA(sender As Object, e As ReceiveFAEventArgs) Handles m_apiEvents.ReceiveFA
        Dim fname = m_utils.faMsgTypeName(e.faDataType)
        m_utils.addListItem(Utils.ListType.ServerResponses, "FA: " & fname & "=" & e.faXmlData)
        Select Case e.faDataType
            Case Utils.FaMessageType.Groups
                m_faGroupXML = e.faXmlData
            Case Utils.FaMessageType.Profiles
                m_faProfilesXML = e.faXmlData
            Case Utils.FaMessageType.Aliases
                m_faAliasesXML = e.faXmlData
        End Select

        If faError = False And m_faGroupXML <> "" And m_faProfilesXML <> "" And m_faAliasesXML <> "" Then

            m_dlgFinancialAdvisor.init(m_utils, m_faGroupXML, m_faProfilesXML, m_faAliasesXML)
            m_dlgFinancialAdvisor.ShowDialog()
            If m_dlgFinancialAdvisor.ok Then
                m_api.replaceFA(Utils.FaMessageType.Groups, m_dlgFinancialAdvisor.groupsXML)
                m_api.replaceFA(Utils.FaMessageType.Profiles, m_dlgFinancialAdvisor.profilesXML)
                m_api.replaceFA(Utils.FaMessageType.Aliases, m_dlgFinancialAdvisor.aliasesXML)
            End If

        End If

    End Sub

    '--------------------------------------------------------------------------------
    ' Market Data Type
    '--------------------------------------------------------------------------------
    Private Sub Api_marketDataType(sender As Object, e As MarketDataTypeEventArgs) Handles m_apiEvents.MarketDataType
        Dim msg = "id=" & e.reqId & " marketDataType=" & [Enum].GetName(GetType(dlgOrder.MarketDataTypes), e.marketDataType)
        m_utils.addListItem(Utils.ListType.MarketData, msg)
    End Sub

    '--------------------------------------------------------------------------------
    ' Commission Report
    '--------------------------------------------------------------------------------
    Private Sub Api_commissionReport(sender As Object, e As CommissionReportEventArgs) Handles m_apiEvents.CommissionReport
        Dim offset = lstServerResponses.Items.Count

        m_utils.addListItem(Utils.ListType.ServerResponses, " ---- Commission Report ----")

        With e.commissionReport
            m_utils.addListItem(Utils.ListType.ServerResponses, "  execId=" & .ExecId)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  commission=" & DblMaxStr(.Commission))
            m_utils.addListItem(Utils.ListType.ServerResponses, "  currency=" & .Currency)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  realizedPNL=" & DblMaxStr(.RealizedPNL))
            m_utils.addListItem(Utils.ListType.ServerResponses, "  yield=" & DblMaxStr(.Yield))
            m_utils.addListItem(Utils.ListType.ServerResponses, "  yieldRedemptionDate=" & IntMaxStr(.YieldRedemptionDate))

        End With

        m_utils.addListItem(Utils.ListType.ServerResponses, " ---- Commission Report End ----")

        ' move into view
        lstServerResponses.TopIndex = offset
    End Sub


    '--------------------------------------------------------------------------------
    ' Position
    '--------------------------------------------------------------------------------
    Private Sub Api_position(sender As Object, e As PositionEventArgs) Handles m_apiEvents.Position
        Dim offset = lstServerResponses.Items.Count

        m_utils.addListItem(Utils.ListType.ServerResponses, " ---- Position ----")
        m_utils.addListItem(Utils.ListType.ServerResponses, "account=" & e.account)
        m_utils.addListItem(Utils.ListType.ServerResponses, "Contract:")

        With e.contract
            m_utils.addListItem(Utils.ListType.ServerResponses, "  conId=" & .ConId)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  symbol=" & .Symbol)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  secType=" & .SecType)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  lastTradeDate=" & .LastTradeDateOrContractMonth)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  strike=" & .Strike)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  right=" & .Right)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  multiplier=" & .Multiplier)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  exchange=" & .Exchange)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  primaryExchange=" & .PrimaryExch)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  currency=" & .Currency)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  localSymbol=" & .LocalSymbol)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  tradingClass=" & .TradingClass)
        End With

        m_utils.addListItem(Utils.ListType.ServerResponses, "position=" & IntMaxStr(e.pos))
        m_utils.addListItem(Utils.ListType.ServerResponses, "avgCost=" & DblMaxStr(e.avgCost))
        m_utils.addListItem(Utils.ListType.ServerResponses, " ---- Position End ----")

        ' move into view
        lstServerResponses.TopIndex = offset

    End Sub

    '--------------------------------------------------------------------------------
    ' Position End
    '--------------------------------------------------------------------------------
    Private Sub Api_positionEnd(sender As Object, e As EventArgs) Handles m_apiEvents.PositionEnd
        m_utils.addListItem(Utils.ListType.ServerResponses, " ==== Position End ==== ")

        ' move into view
        lstServerResponses.TopIndex = lstServerResponses.Items.Count - 1
    End Sub

    '--------------------------------------------------------------------------------
    ' Account Summary
    '--------------------------------------------------------------------------------
    Private Sub Api_accountSummary(sender As Object, e As AccountSummaryEventArgs) Handles m_apiEvents.AccountSummary
        Dim offset = lstServerResponses.Items.Count

        m_utils.addListItem(Utils.ListType.ServerResponses, " ---- Account Summary ----")
        m_utils.addListItem(Utils.ListType.ServerResponses, "reqId=" & e.reqId)
        m_utils.addListItem(Utils.ListType.ServerResponses, "account=" & e.account)
        m_utils.addListItem(Utils.ListType.ServerResponses, "tag=" & e.tag)
        m_utils.addListItem(Utils.ListType.ServerResponses, "value=" & e.value)
        m_utils.addListItem(Utils.ListType.ServerResponses, "currency=" & e.currency)
        m_utils.addListItem(Utils.ListType.ServerResponses, " ---- Account Summary End ----")

        ' move into view
        lstServerResponses.TopIndex = offset
    End Sub

    '--------------------------------------------------------------------------------
    ' Account Summary End
    '--------------------------------------------------------------------------------
    Private Sub Api_accountSummaryEnd(sender As Object, e As AccountSummaryEndEventArgs) Handles m_apiEvents.AccountSummaryEnd
        m_utils.addListItem(Utils.ListType.ServerResponses, "reqId = " & e.reqId & " =============== end ===============")

        ' move into view
        lstServerResponses.TopIndex = lstServerResponses.Items.Count - 1

    End Sub

    '--------------------------------------------------------------------------------
    ' Display Group List
    '--------------------------------------------------------------------------------
    Private Sub Api_displayGroupList(sender As Object, e As DisplayGroupListEventArgs) Handles m_apiEvents.DisplayGroupList
        m_dlgGroups.displayGroupList(e.reqId, e.groups)
    End Sub

    Private Sub Api_displayGroupUpdated(sender As Object, e As DisplayGroupUpdatedEventArgs) Handles m_apiEvents.DisplayGroupUpdated
        m_dlgGroups.displayGroupUpdated(e.reqId, e.contractInfo)
    End Sub

    '--------------------------------------------------------------------------------
    ' Position Multi
    '--------------------------------------------------------------------------------
    Private Sub Api_positionMulti(sender As Object, e As PositionMultiEventArgs) Handles m_apiEvents.PositionMulti
        Dim offset = lstServerResponses.Items.Count

        m_utils.addListItem(Utils.ListType.ServerResponses, " ---- Position Multi ----")
        m_utils.addListItem(Utils.ListType.ServerResponses, "reqId=" & e.reqId)
        m_utils.addListItem(Utils.ListType.ServerResponses, "account=" & e.account)
        m_utils.addListItem(Utils.ListType.ServerResponses, "modelCode=" & e.modelCode)
        m_utils.addListItem(Utils.ListType.ServerResponses, "Contract:")

        With e.contract
            m_utils.addListItem(Utils.ListType.ServerResponses, "  conId=" & .ConId)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  symbol=" & .Symbol)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  secType=" & .SecType)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  lastTradeDate=" & .LastTradeDateOrContractMonth)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  strike=" & .Strike)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  right=" & .Right)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  multiplier=" & .Multiplier)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  exchange=" & .Exchange)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  primaryExchange=" & .PrimaryExch)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  currency=" & .Currency)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  localSymbol=" & .LocalSymbol)
            m_utils.addListItem(Utils.ListType.ServerResponses, "  tradingClass=" & .TradingClass)
        End With

        m_utils.addListItem(Utils.ListType.ServerResponses, "position=" & IntMaxStr(e.pos))
        m_utils.addListItem(Utils.ListType.ServerResponses, "avgCost=" & DblMaxStr(e.avgCost))
        m_utils.addListItem(Utils.ListType.ServerResponses, " ---- Position Multi End ----")

        ' move into view
        lstServerResponses.TopIndex = offset
    End Sub

    '--------------------------------------------------------------------------------
    ' Position Multi End
    '--------------------------------------------------------------------------------
    Private Sub Api_positionMultiEnd(sender As Object, e As PositionMultiEndEventArgs) Handles m_apiEvents.PositionMultiEnd
        m_utils.addListItem(Utils.ListType.ServerResponses, "reqId=" & e.reqId & " ==== Position Multi End ==== ")

        ' move into view
        lstServerResponses.TopIndex = lstServerResponses.Items.Count - 1
    End Sub

    '--------------------------------------------------------------------------------
    ' Account Update Multi
    '--------------------------------------------------------------------------------
    Private Sub Api_accountUpdateMulti(sender As Object, e As AccountUpdateMultiEventArgs) Handles m_apiEvents.AccountUpdateMulti
        Dim offset = lstServerResponses.Items.Count

        m_utils.addListItem(Utils.ListType.ServerResponses, "reqId=" & e.reqId & " account=" & e.account & " modelCode=" & e.modelCode & " key=" & e.key & " value=" & e.value & " currency=" & e.currency)

        ' move into view
        lstServerResponses.TopIndex = offset
    End Sub

    '--------------------------------------------------------------------------------
    ' Account Update Multi End
    '--------------------------------------------------------------------------------
    Private Sub Api_accountUpdateMultiEnd(sender As Object, e As AccountUpdateMultiEndEventArgs) Handles m_apiEvents.AccountUpdateMultiEnd
        m_utils.addListItem(Utils.ListType.ServerResponses, "reqId=" & e.reqId & " ==== Account Update Multi End ==== ")

        ' move into view
        lstServerResponses.TopIndex = lstServerResponses.Items.Count - 1
    End Sub

    Private Sub Api_verifyCompleted(sender As Object, e As VerifyCompletedEventArgs) Handles m_apiEvents.VerifyCompleted
        m_api.startApi()
    End Sub

    Private Sub Api_verifyAndAuthCompleted(sender As Object, e As VerifyAndAuthCompletedEventArgs) Handles m_apiEvents.VerifyAndAuthCompleted
        m_api.startApi()
    End Sub

    '--------------------------------------------------------------------------------
    ' Security Definition Option Parameter
    '--------------------------------------------------------------------------------
    Private Sub Api_SecurityDefinitionOptionParameter(sender As Object, e As SecurityDefinitionOptionParameterEventArgs) Handles m_apiEvents.SecurityDefinitionOptionParameter
        Dim displayString = String.Format("reqId: {0}, exchange {1}, underlyingConId: {2}, tradingClass: {3}, multiplier: {4}, expirations: {5}, strikes: {6}",
            e.reqId,
            e.exchange,
            e.underlyingConId,
            e.tradingClass,
            e.multiplier,
            String.Join(",", e.expirations),
            String.Join(", ", e.strikes))

        m_utils.addListItem(Utils.ListType.ServerResponses, displayString)

        ' move into view
        lstServerResponses.TopIndex = lstServerResponses.Items.Count - 1
    End Sub

    '--------------------------------------------------------------------------------
    ' Family Codes
    '--------------------------------------------------------------------------------
    Private Sub Api_FamilyCodes(sender As Object, e As FamilyCodesEventArgs) Handles m_apiEvents.FamilyCodes
        Dim offset = lstServerResponses.Items.Count

        m_utils.addListItem(Utils.ListType.ServerResponses, " ==== Family Codes Begin (total=" & e.familyCodes.Length & ") ====")
        Dim count = 0
        For Each familyCode As FamilyCode In e.familyCodes
            m_utils.addListItem(Utils.ListType.ServerResponses, "Family Code (" & count & ") - accountID=" & familyCode.AccountID & " familyCode=" & familyCode.FamilyCodeStr)
            count += 1
        Next
        m_utils.addListItem(Utils.ListType.ServerResponses, " ==== Family Codes End (total=" & e.familyCodes.Length & ") ====")

        ' move into view
        lstServerResponses.TopIndex = offset
    End Sub

    '--------------------------------------------------------------------------------
    ' Symbol Samples
    '--------------------------------------------------------------------------------
    Private Sub Api_SymbolSamples(sender As Object, e As SymbolSamplesEventArgs) Handles m_apiEvents.SymbolSamples
        Dim offset = lstServerResponses.Items.Count

        m_utils.addListItem(Utils.ListType.ServerResponses, " ==== Symbol Samples (total=" & e.contractDescriptions.Length & ") reqId=" & e.reqId & " ====")
        Dim count As Integer = 0
        For Each cd As ContractDescription In e.contractDescriptions
            m_utils.addListItem(Utils.ListType.ServerResponses, " ---- Contract Description (" & count & ") ----")
            With cd.Contract
                m_utils.addListItem(Utils.ListType.ServerResponses, "conId=" & .ConId)
                m_utils.addListItem(Utils.ListType.ServerResponses, "symbol=" & .Symbol)
                m_utils.addListItem(Utils.ListType.ServerResponses, "secType=" & .SecType)
                m_utils.addListItem(Utils.ListType.ServerResponses, "primExch=" & .PrimaryExch)
                m_utils.addListItem(Utils.ListType.ServerResponses, "currency=" & .Currency)
            End With

            Dim displayString = "derivative secTypes="
            For Each derivativeSecType As String In cd.DerivativeSecTypes
                displayString += (derivativeSecType & " ")
            Next
            m_utils.addListItem(Utils.ListType.ServerResponses, displayString)
            m_utils.addListItem(Utils.ListType.ServerResponses, " ---- Contract Description End (" & count & ") ----")
            count += 1
        Next
        m_utils.addListItem(Utils.ListType.ServerResponses, " ==== Symbol Samples End (total=" & e.contractDescriptions.Length & ") reqId=" & e.reqId & " ====")

        ' move into view
        lstServerResponses.TopIndex = offset
    End Sub

    '--------------------------------------------------------------------------------
    ' Bond Contract Details
    '--------------------------------------------------------------------------------
    Private Sub Api_BondContractDetails(sender As Object, e As BondContractDetailsEventArgs) Handles m_apiEvents.BondContractDetails
        Dim offset = lstServerResponses.Items.Count

        m_utils.addListItem(Utils.ListType.ServerResponses, "reqId = " & e.reqId & " ===================================")

        Dim contract = e.contractDetails.Summary
        m_utils.addListItem(Utils.ListType.ServerResponses, " ---- Bond Contract Details Begin ----")
        m_utils.addListItem(Utils.ListType.ServerResponses, "Contract:")
        m_utils.addListItem(Utils.ListType.ServerResponses, "  conId = " & contract.ConId)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  symbol = " & contract.Symbol)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  secType = " & contract.SecType)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  exchange = " & contract.Exchange)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  currency = " & contract.Currency)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  tradingClass = " & contract.TradingClass)

        Dim contractDetails = e.contractDetails
        m_utils.addListItem(Utils.ListType.ServerResponses, "Contract Details:")
        m_utils.addListItem(Utils.ListType.ServerResponses, "  marketName = " & contractDetails.MarketName)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  minTick = " & contractDetails.MinTick)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  orderTypes = " & contractDetails.OrderTypes)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  validExchanges = " & contractDetails.ValidExchanges)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  longName = " & contractDetails.LongName)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  evRule = " & contractDetails.EvRule)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  evMultiplier = " & contractDetails.EvMultiplier)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  mdSizeMultiplier = " & contractDetails.MdSizeMultiplier)

        m_utils.addListItem(Utils.ListType.ServerResponses, "Bond Details:")
        m_utils.addListItem(Utils.ListType.ServerResponses, "  cusip = " & contractDetails.Cusip)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  ratings = " & contractDetails.Ratings)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  descAppend = " & contractDetails.DescAppend)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  bondType = " & contractDetails.BondType)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  couponType = " & contractDetails.CouponType)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  callable = " & contractDetails.Callable)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  putable = " & contractDetails.Putable)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  coupon = " & contractDetails.Coupon)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  convertible = " & contractDetails.Convertible)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  maturity = " & contractDetails.Maturity)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  issueDate = " & contractDetails.IssueDate)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  nextOptionDate = " & contractDetails.NextOptionDate)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  nextOptionType = " & contractDetails.NextOptionType)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  nextOptionPartial = " & contractDetails.NextOptionPartial)
        m_utils.addListItem(Utils.ListType.ServerResponses, "  notes = " & contractDetails.Notes)

        ' CUSIP/ISIN/etc.
        m_utils.addListItem(Utils.ListType.ServerResponses, "  secIdList={")
        Dim secIdList = contractDetails.SecIdList
        If (secIdList IsNot Nothing) Then
            For Each param In secIdList
                m_utils.addListItem(Utils.ListType.ServerResponses, "    " & param.Tag & "=" & param.Value)
            Next
        End If
        m_utils.addListItem(Utils.ListType.ServerResponses, "  }")

        m_utils.addListItem(Utils.ListType.ServerResponses, " ---- Bond Contract Details End ----")

        ' move into view
        lstServerResponses.TopIndex = offset
    End Sub

    '--------------------------------------------------------------------------------
    ' Market Depth Exchanges
    '--------------------------------------------------------------------------------
    Private Sub Api_MktDepthExchanges(sender As Object, e As MktDepthExchangesEventArgs) Handles m_apiEvents.MktDepthExchanges
        Dim offset As Long
        offset = lstServerResponses.Items.Count

        m_utils.addListItem(Utils.ListType.ServerResponses, " ==== Market Depth Exchanges Begin (total=" & e.depthMktDataDescriptions.Length & ") ====")
        Dim count As Integer = 0
        For Each depthMktDataDescription As DepthMktDataDescription In e.depthMktDataDescriptions
            m_utils.addListItem(Utils.ListType.ServerResponses, "Depth Market Data Description (" & count & ") - exchange=" & depthMktDataDescription.Exchange & " secType=" & depthMktDataDescription.SecType & " isL2=" & depthMktDataDescription.IsL2)
            count += 1
        Next
        m_utils.addListItem(Utils.ListType.ServerResponses, " ==== Market Depth Exchanges End (total=" & e.depthMktDataDescriptions.Length & ") ====")

        ' move into view
        lstServerResponses.TopIndex = offset
    End Sub

    '--------------------------------------------------------------------------------
    ' Tick News
    '--------------------------------------------------------------------------------
    Private Sub Api_TickNews(sender As Object, e As TickNewsEventArgs) Handles m_apiEvents.TickNews
        Dim offset = lstServerResponses.Items.Count

        m_utils.addListItem(Utils.ListType.ServerResponses, " ---- Tick News Begin ----")
        m_utils.addListItem(Utils.ListType.ServerResponses, "tickerId=" & e.tickerId)
        m_utils.addListItem(Utils.ListType.ServerResponses, "timeStamp=" & Utils.UnixMillisecondsToString(e.timeStamp, "yyyy-MM-dd HH:mm:ss zzz"))
        m_utils.addListItem(Utils.ListType.ServerResponses, "providerCode=" & e.providerCode)
        m_utils.addListItem(Utils.ListType.ServerResponses, "articleId=" & e.articleId)
        m_utils.addListItem(Utils.ListType.ServerResponses, "headline=" & e.headline)
        m_utils.addListItem(Utils.ListType.ServerResponses, "extraData=" & e.extraData)
        m_utils.addListItem(Utils.ListType.ServerResponses, " ---- Tick News End ----")

        ' move into view
        lstServerResponses.TopIndex = offset
    End Sub

    Private Sub Api_TickReqParams(sender As Object, e As TickReqParamsEventArgs) Handles m_apiEvents.TickReqParams
        m_utils.addListItem(Utils.ListType.ServerResponses, " ---- Tick Req Params Begin ----")
        m_utils.addListItem(Utils.ListType.ServerResponses, "tickerId=" & e.tickerId)
        m_utils.addListItem(Utils.ListType.ServerResponses, "minTick=" & e.minTick)
        m_utils.addListItem(Utils.ListType.ServerResponses, "bboExchange=" & e.bboExchange)
        m_utils.addListItem(Utils.ListType.ServerResponses, "snapshotPermissions=" & e.snapshotPermissions)
        m_utils.addListItem(Utils.ListType.ServerResponses, " ---- Tick Req Params End ----")
    End Sub

    Private Sub Api_SmartComponents(sender As ApiEventSource, e As SmartComponentsEventArgs) Handles m_apiEvents.SmartComponents
        m_utils.addListItem(Utils.ListType.ServerResponses, " ---- Smart Components Begin ----")

        For Each item In e.theMap
            m_utils.addListItem(Utils.ListType.ServerResponses, "bitNumber=" & item.Key)
            m_utils.addListItem(Utils.ListType.ServerResponses, "Exchange=" & item.Value.Key)
            m_utils.addListItem(Utils.ListType.ServerResponses, "Exchange letter=" & item.Value.Value)
        Next

        m_utils.addListItem(Utils.ListType.ServerResponses, " ---- Smart Components End ----")
    End Sub

    '--------------------------------------------------------------------------------
    ' News Providers
    '--------------------------------------------------------------------------------
    Private Sub Api_NewsProviders(sender As Object, e As NewsProvidersEventArgs) Handles m_apiEvents.NewsProviders
        Dim offset As Long
        offset = lstServerResponses.Items.Count

        m_utils.addListItem(Utils.ListType.ServerResponses, " ==== News Providers Begin (total=" & e.newsProviders.Length & ") ====")
        Dim count As Integer = 0
        For Each newsProvider As NewsProvider In e.newsProviders
            m_utils.addListItem(Utils.ListType.ServerResponses, "News Provider (" & count & ") - code=" & newsProvider.ProviderCode & " name=" & newsProvider.ProviderName)
            count += 1
        Next
        m_utils.addListItem(Utils.ListType.ServerResponses, " ==== News Providers End (total=" & e.newsProviders.Length & ") ====")

        ' move into view
        lstServerResponses.TopIndex = offset
    End Sub

    '--------------------------------------------------------------------------------
    ' News Article
    '--------------------------------------------------------------------------------
    Private Sub Api_NewsArticle(sender As Object, e As NewsArticleEventArgs) Handles m_apiEvents.NewsArticle
        Dim offset = lstServerResponses.Items.Count

        m_utils.addListItem(Utils.ListType.ServerResponses, " ==== News Article Begin requestId=" & e.requestId & " ====")
        m_utils.addListItem(Utils.ListType.ServerResponses, " Article Type: " & e.articleType)
        m_utils.addListItem(Utils.ListType.ServerResponses, " Article Text: ")
        If e.articleType = 0 Then
            m_utils.addListItem(Utils.ListType.ServerResponses, e.articleText)
        ElseIf e.articleType = 1 Then
            m_utils.addListItem(Utils.ListType.ServerResponses, "article text is binary/pdf and cannot be displayed")

        End If
        m_utils.addListItem(Utils.ListType.ServerResponses, " ==== News Article End requestId=" & e.requestId & " ====")

        ' move into view
        lstServerResponses.TopIndex = offset
    End Sub

    '--------------------------------------------------------------------------------
    ' Historical News
    '--------------------------------------------------------------------------------
    Private Sub Api_HistoricalNews(sender As Object, e As HistoricalNewsEventArgs) Handles m_apiEvents.HistoricalNews
        Dim offset = lstServerResponses.Items.Count

        m_utils.addListItem(Utils.ListType.ServerResponses, " ---- Historical News Begin ----")
        m_utils.addListItem(Utils.ListType.ServerResponses, "requestId=" & e.requestId)
        m_utils.addListItem(Utils.ListType.ServerResponses, "time=" & e.time)
        m_utils.addListItem(Utils.ListType.ServerResponses, "providerCode=" & e.providerCode)
        m_utils.addListItem(Utils.ListType.ServerResponses, "articleId=" & e.articleId)
        m_utils.addListItem(Utils.ListType.ServerResponses, "headline=" & e.headline)
        m_utils.addListItem(Utils.ListType.ServerResponses, " ---- Historical News End ----")

        ' move into view
        lstServerResponses.TopIndex = offset

    End Sub

    '--------------------------------------------------------------------------------
    ' Historical News End
    '--------------------------------------------------------------------------------
    Private Sub Api_HistoricalNewsEnd(sender As Object, e As HistoricalNewsEndEventArgs) Handles m_apiEvents.HistoricalNewsEnd
        Dim hasMoreStr As String
        If e.hasMore Then
            hasMoreStr = "> has more ..."
        Else
            hasMoreStr = ""
        End If

        m_utils.addListItem(Utils.ListType.ServerResponses, "requestId = " & e.requestId & " ===== Historical News End ====" & hasMoreStr)

        ' move into view
        lstServerResponses.TopIndex = lstServerResponses.Items.Count - 1
    End Sub

    '--------------------------------------------------------------------------------
    ' Head time stamp
    '--------------------------------------------------------------------------------
    Private Sub m_apiEvents_HeadTimestamp(sender As ApiEventSource, e As HeadTimestampEventArgs) Handles m_apiEvents.HeadTimestamp
        Dim displayString = "Head time stamp: request id - " & e.requestId & ", time stamp - " & e.timeStamp

        m_utils.addListItem(Utils.ListType.ServerResponses, displayString)
    End Sub

#End Region

#Region "Helper methods"

    Private Function PopulateXMLDoc(xmlDoc As XmlDocument, rootName As String) As XmlElement

        ' this application doesn't need the Processing instruction
        ' Dim node As IXMLDOMNode
        ' Set node = xmlDoc.createProcessingInstruction("xml", "version='1.0'")
        ' xmlDoc.appendChild node
        ' Set node = Nothing

        Dim rootNode = xmlDoc.CreateElement(rootName)
        xmlDoc.AppendChild(rootNode)
        AppendNewLineAndTab(xmlDoc, rootNode)
        PopulateXMLDoc = rootNode
    End Function

    Private Sub AppendNewLineAndTab(xmlDoc As XmlDocument, node As XmlNode)
        node.AppendChild(xmlDoc.CreateTextNode(vbNewLine + vbTab))
    End Sub

    Private Sub AppendNewLine(xmlDoc As XmlDocument, node As XmlNode)
        node.AppendChild(xmlDoc.CreateTextNode(vbNewLine))
    End Sub

    Private Sub SetElemAttr(xmlDoc As XmlDocument,
                           elem As XmlElement,
                           attrName As String,
                           attrValue As String)
        Dim attr = xmlDoc.CreateAttribute(attrName)
        attr.Value = attrValue
        elem.SetAttributeNode(attr)
        attr = Nothing
    End Sub

    Private Function AddNodeToXMLDoc(xmlDoc As XmlDocument,
                                    node As XmlElement, nodeName As String,
                                    nodeValue As String) As XmlNode
        Dim newNode = xmlDoc.CreateElement(nodeName)
        If nodeValue <> Nothing Then
            newNode.InnerText = nodeValue
        End If
        node.AppendChild(newNode)
        AddNodeToXMLDoc = newNode
    End Function

    Private Function ProduceXMLDoc() As XmlDocument
        Dim xmlDoc = New XmlDocument
        ' xmlDoc.async = False
        ' xmlDoc.validateOnParse = False
        ' xmlDoc.resolveExternals = False
        ProduceXMLDoc = xmlDoc
    End Function

    Private Function findNode(xmlDoc As XmlDocument, nodeName As String, withName As String, withValue As String) As XmlNode
        Dim node1 = getRootNode(xmlDoc)
        Dim nodeList = getNodeList(node1, nodeName)
        Dim node2 = getNodeFromList(nodeList, withName, withValue)
        Return node2
    End Function

    Private Function removeNode(xmlDoc As XmlDocument, nodeName As String, withName As String, withValue As String) As XmlNode
        Dim node2 = findNode(xmlDoc, nodeName, withName, withValue)
        If node2 IsNot Nothing Then
            getRootNode(xmlDoc).RemoveChild(node2)
        End If
        Return node2
    End Function

    Private Function getRootNode(xmlDoc As XmlDocument) As XmlNode
        Return xmlDoc.SelectSingleNode("/*")
    End Function

    Private Function getNode(node As XmlNode,
                               nodeName As String) As XmlNode
        getNode = node.SelectSingleNode(nodeName)
    End Function

    Private Function getNodeList(node As XmlNode,
                               nodeName As String) As XmlNodeList
        getNodeList = node.SelectNodes(nodeName)
    End Function

    Private Function getNodeFromList(nodeList As XmlNodeList, name As String, value As String) As XmlNode
        For ctr As Integer = 0 To nodeList.Count - 1
            Dim node = nodeList.Item(ctr)
            Dim element = node.Item(name)
            If element.InnerText = value Then
                Return node
            End If
        Next
        Return Nothing
    End Function

    Private Function parseNode(node As XmlNode,
                               nodeName As String) As String
        Return node.SelectSingleNode(nodeName).InnerText
    End Function

    Private Function IntMaxStr(intVal As Integer) As String
        If intVal = Integer.MaxValue Then
            Return ""
        Else
            Return CStr(intVal)
        End If
    End Function

    Private Function DblMaxStr(dblVal As Double) As String
        If dblVal = Double.MaxValue Then
            Return ""
        Else
            Return CStr(dblVal)
        End If
    End Function

#End Region

    Private Sub cmdReqHeadTimestamp_Click(sender As Object, e As EventArgs) Handles cmdReqHeadTimestamp.Click
        ' Set the dialog state
        m_dlgOrder.init(dlgOrder.DialogType.RequestHistoricalData,
            m_contractInfo, m_orderInfo, m_underComp, m_chartOptions, Me)

        m_dlgOrder.ShowDialog()

        m_chartOptions = m_dlgOrder.options

        If m_dlgOrder.ok Then

            m_api.reqHeadTimestamp(m_dlgOrder.orderId, m_contractInfo,
                m_dlgOrder.whatToShow, m_dlgOrder.useRTH, m_dlgOrder.formatDate)
        End If
    End Sub
End Class
