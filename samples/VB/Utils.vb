' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Option Strict Off
Option Explicit On
Friend Class Utils
	' Enums
	Public Enum TickType
		BID_SIZE = 0
		BID_PRICE
		ASK_PRICE
		ASK_SIZE
		LAST_PRICE
		LAST_SIZE
		HIGH
		LOW
		VOLUME
        CLOSE_PRICE
        BID_OPTION_COMPUTATION
        ASK_OPTION_COMPUTATION
        LAST_OPTION_COMPUTATION
        MODEL_OPTION
        OPEN_TICK
        LOW_13_WEEK
        HIGH_13_WEEK
        LOW_26_WEEK
        HIGH_26_WEEK
        LOW_52_WEEK
        HIGH_52_WEEK
        AVG_VOLUME
        OPEN_INTEREST
        OPTION_HISTORICAL_VOL
        OPTION_IMPLIED_VOL
        OPTION_BID_EXCH
        OPTION_ASK_EXCH
        OPTION_CALL_OPEN_INTEREST
        OPTION_PUT_OPEN_INTEREST
        OPTION_CALL_VOLUME
        OPTION_PUT_VOLUME
        INDEX_FUTURE_PREMIUM
        BID_EXCH
        ASK_EXCH
        AUCTION_VOLUME
        AUCTION_PRICE
        AUCTION_IMBALANCE
        MARK_PRICE
        BID_EFP_COMPUTATION
        ASK_EFP_COMPUTATION
        LAST_EFP_COMPUTATION
        OPEN_EFP_COMPUTATION
        HIGH_EFP_COMPUTATION
        LOW_EFP_COMPUTATION
        CLOSE_EFP_COMPUTATION
        LAST_TIMESTAMP
        SHORTABLE
        FUNDAMENTAL_RATIOS
        RT_VOLUME
        HALTED
        BID_YIELD
        ASK_YIELD
        LAST_YIELD
        CUST_OPTION_COMPUTATION
        TRADE_COUNT
        TRADE_RATE
        VOLUME_RATE
        LAST_RTH_TRADE
    End Enum

    Public Enum List_Types
        MKT_DATA = 0
        SERVER_RESPONSES
        ERRORS
        ACCOUNT_DATA
        PORTFOLIO_DATA
        DISPLAY_GROUPS_DATA
    End Enum

    Public Enum FA_Message_Type
        GROUPS = 1
        PROFILES = 2
        ALIASES = 3
    End Enum

    Public Shared ReadOnly CRSTR As String = Chr(13)
    Public Shared ReadOnly LFSTR As String = Chr(10)
    Public Shared ReadOnly CRLFSTR As String = CRSTR & LFSTR

    ' Win32 API functions
    Private Declare Function SendMessageByNum Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

    ' Constants
    Private Const LB_SETHORZEXTENT As Short = &H194S

    Private m_dlgMainWnd As dlgMainWnd
    Private m_dlgAcctData As dlgAcctData
    Private m_dlgGroups As dlgGroups

    '================================================================================
    ' Public Helper Routines
    '================================================================================
    Public Sub init(ByVal dlgMainWnd As System.Windows.Forms.Form, ByVal dlgAcctData As System.Windows.Forms.Form, ByVal dlgGroups As System.Windows.Forms.Form)
        m_dlgMainWnd = dlgMainWnd
        m_dlgAcctData = dlgAcctData
        m_dlgGroups = dlgGroups
    End Sub
    '--------------------------------------------------------------------------------
    ' Display an XML message
    '--------------------------------------------------------------------------------
    Public Sub displayMultiline(ByRef listType As List_Types, ByRef xml As String)
        Dim ctr As Object
        Dim FOUR_SPACES As Object
        Dim CRLFSTR As Object
        Dim CRSTR As Object
        Dim LFSTR As Object
        Dim TABSTR As Object
        TABSTR = Chr(9)
        LFSTR = Chr(10)
        CRSTR = Chr(13)
        CRLFSTR = CRSTR & LFSTR
        FOUR_SPACES = "    "
        Dim text As String
        Dim strArray() As String
        text = Replace(xml, TABSTR, FOUR_SPACES)
        strArray = Split(text, LFSTR) ' VB.NET must be removing the CR
        For ctr = 0 To UBound(strArray)
            Dim line As String
            line = strArray(ctr)
            If Len(line) > 1020 Then
                line = Left(line, 1020) & " ..."
            End If
            Call addListItem(listType, line)
        Next
    End Sub
    Public Function faMsgTypeName(ByVal faMsgType As FA_Message_Type) As Object
        Select Case faMsgType
            Case FA_Message_Type.GROUPS
                faMsgTypeName = "GROUPS"
            Case FA_Message_Type.PROFILES
                faMsgTypeName = "PROFILES"
            Case FA_Message_Type.ALIASES
                faMsgTypeName = "ALIASES"
            Case Else
                faMsgTypeName = "UNKNOWN"
        End Select
    End Function
    '--------------------------------------------------------------------------------
    ' Add an item to one of the display listboxes
    '--------------------------------------------------------------------------------
    Public Sub addListItem(ByRef listType As List_Types, ByRef data As String, Optional ByVal scrollList As Boolean = True)
        Dim listBox As System.Windows.Forms.ListBox
        Select Case listType
            Case List_Types.MKT_DATA
                listBox = m_dlgMainWnd.lstMktData
            Case List_Types.SERVER_RESPONSES
                listBox = m_dlgMainWnd.lstServerResponses
            Case List_Types.ERRORS
                listBox = m_dlgMainWnd.lstErrors
            Case List_Types.ACCOUNT_DATA
                listBox = m_dlgAcctData.lstKeyValueData
            Case List_Types.PORTFOLIO_DATA
                listBox = m_dlgAcctData.lstPortfolioData
            Case List_Types.DISPLAY_GROUPS_DATA
                listBox = m_dlgGroups.lstGroupMessages
            Case Else
                Return
        End Select
        Dim lines() As String = data.Split(LFSTR.ToCharArray, 500)
        For ctr As Integer = 0 To lines.GetLength(0) - 1
            Dim theLine As String = lines(ctr).Replace(CRSTR, "")
            listBox.Items.Add(theLine)
        Next
        If scrollList Then
            listBox.TopIndex = listBox.Items.Count - 1
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Returns the tick display string used when adding tick data to the display list.
    '--------------------------------------------------------------------------------
    Public Function getField(ByRef field As TickType) As Object
        Select Case field
            Case TickType.BID_SIZE : getField = "bidSize"
            Case TickType.BID_PRICE : getField = "bidPrice"
            Case TickType.ASK_PRICE : getField = "askPrice"
            Case TickType.ASK_SIZE : getField = "askSize"
            Case TickType.LAST_PRICE : getField = "lastPrice"
            Case TickType.LAST_SIZE : getField = "lastSize"
            Case TickType.HIGH : getField = "high"
            Case TickType.LOW : getField = "low"
            Case TickType.VOLUME : getField = "volume"
            Case TickType.CLOSE_PRICE : getField = "close"
            Case TickType.BID_OPTION_COMPUTATION : getField = "bidOptComp"
            Case TickType.ASK_OPTION_COMPUTATION : getField = "askOptComp"
            Case TickType.LAST_OPTION_COMPUTATION : getField = "lastOptComp"
            Case TickType.MODEL_OPTION : getField = "modelOption"
            Case TickType.OPEN_TICK : getField = "open"
            Case TickType.LOW_13_WEEK : getField = "13WeekLow"
            Case TickType.HIGH_13_WEEK : getField = "13WeekHigh"
            Case TickType.LOW_26_WEEK : getField = "26WeekLow"
            Case TickType.HIGH_26_WEEK : getField = "26WeekHigh"
            Case TickType.LOW_52_WEEK : getField = "52WeekLow"
            Case TickType.HIGH_52_WEEK : getField = "52WeekHigh"
            Case TickType.AVG_VOLUME : getField = "AvgVolume"
            Case TickType.OPEN_INTEREST : getField = "OpenInterest"
            Case TickType.OPTION_HISTORICAL_VOL : getField = "OptionHistoricalVolatility"
            Case TickType.OPTION_IMPLIED_VOL : getField = "OptionImpliedVolatility"
            Case TickType.OPTION_BID_EXCH : getField = "OptionBidExchStr"
            Case TickType.OPTION_ASK_EXCH : getField = "OptionAskExchStr"
            Case TickType.OPTION_CALL_OPEN_INTEREST : getField = "OptionCallOpenInterest"
            Case TickType.OPTION_PUT_OPEN_INTEREST : getField = "OptionPutOpenInterest"
            Case TickType.OPTION_CALL_VOLUME : getField = "OptionCallVolume"
            Case TickType.OPTION_PUT_VOLUME : getField = "OptionPutVolume"
            Case TickType.INDEX_FUTURE_PREMIUM : getField = "IndexFuturePremium"
            Case TickType.BID_EXCH : getField = "bidExch"
            Case TickType.ASK_EXCH : getField = "askExch"
            Case TickType.AUCTION_VOLUME : getField = "auctionVolume"
            Case TickType.AUCTION_PRICE : getField = "auctionPrice"
            Case TickType.AUCTION_IMBALANCE : getField = "auctionImbalance"
            Case TickType.MARK_PRICE : getField = "markPrice"
            Case TickType.BID_EFP_COMPUTATION : getField = "bidEFP"
            Case TickType.ASK_EFP_COMPUTATION : getField = "askEFP"
            Case TickType.LAST_EFP_COMPUTATION : getField = "lastEFP"
            Case TickType.OPEN_EFP_COMPUTATION : getField = "openEFP"
            Case TickType.HIGH_EFP_COMPUTATION : getField = "highEFP"
            Case TickType.LOW_EFP_COMPUTATION : getField = "lowEFP"
            Case TickType.CLOSE_EFP_COMPUTATION : getField = "closeEFP"
            Case TickType.LAST_TIMESTAMP : getField = "lastTimestamp"
            Case TickType.SHORTABLE : getField = "shortable"
            Case TickType.FUNDAMENTAL_RATIOS : getField = "fundamentals"
            Case TickType.RT_VOLUME : getField = "RTVolume"
            Case TickType.HALTED : getField = "halted"
            Case TickType.BID_YIELD : getField = "bidYield"
            Case TickType.ASK_YIELD : getField = "askYield"
            Case TickType.LAST_YIELD : getField = "lastYield"
            Case TickType.CUST_OPTION_COMPUTATION : getField = "custOptComp"
            Case TickType.TRADE_COUNT : getField = "trades"
            Case TickType.TRADE_RATE : getField = "trades/min"
            Case TickType.VOLUME_RATE : getField = "volume/min"
            Case TickType.LAST_RTH_TRADE : getField = "lastRTHTrade"
            Case Else : getField = "unknown"
        End Select
    End Function
End Class