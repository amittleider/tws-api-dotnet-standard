' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.


Option Explicit On
Friend Class Utils
    ' Enums
    Public Enum TickType
        BidSize
        BidPrice
        AskPrice
        AskSize
        LastPrice
        LastSize
        High
        Low
        Volume
        Close
        BidOptComp
        AskOptComp
        LastOptComp
        ModelOption
        Open
        Low13Week
        High13Week
        Low26Week
        High26Week
        Low52Week
        High52Week
        AvgVolume
        OpenInterest
        OptionHistoricalVolatility
        OptionImpliedVolatility
        OptionBidExchStr
        OptionAskExchStr
        OptionCallOpenInterest
        OptionPutOpenInterest
        OptionCallVolume
        OptionPutVolume
        IndexFuturePremium
        BidExch
        AskExch
        AuctionVolume
        AuctionPrice
        AuctionImbalance
        MarkPrice
        BidEFP
        AskEFP
        LastEFP
        OpenEFP
        HighEFP
        LowEFP
        CloseEFP
        LastTimestamp
        Shortable
        Fundamentals
        RTVolume
        Halted
        BidYield
        AskYield
        LastYield
        CustOptComp
        Trades
        TradesPerMin
        VolumePerMin
        LastRTHTrade
        RTHistoricalVol
        IBDividends
        BondFactorMultiplier
        RegulatoryImbalance
        NewsTick
        ShortTermVolume3Min
        ShortTermVolume5Min
        ShortTermVolume10Min
        DelayedBid
        DelayedAsk
        DelayedLast
        DelayedBidSize
        DelayedAskSize
        DelayedLastSize
        DelayedHigh
        DelayedLow
        DelayedVolume
        DelayedClose
        DelayedOpen
        RTTrdVolume
        CreditmanMarkPrice
        CreditmanSlowMarkPrice
        DelayedBidOptComp
        DelayedAskOptComp
        DelayedLastOptComp
        DelayedModelOptComp
        LastExchange
        LastRegTime
        FuturesOpenInterest
        AvgOptVolume
        Unknown
    End Enum

    Public Enum ListType
        MarketData = 0
        ServerResponses
        Errors
        AccountData
        PortfolioData
        DisplayGroupsData
    End Enum

    Public Enum FaMessageType
        Groups = 1
        Profiles = 2
        Aliases = 3
    End Enum

    Public Const CRSTR = Chr(13)
    Public Const LFSTR = Chr(10)
    Public Const CRLFSTR = CRSTR & LFSTR
    Public Const TABSTR = Chr(9)


    Private m_dlgMainWnd As MainForm
    Private m_dlgAcctData As dlgAcctData
    Private m_dlgGroups As dlgGroups

    '================================================================================
    ' Public Helper Routines
    '================================================================================

    Public Sub init(dlgMainWnd As System.Windows.Forms.Form, dlgAcctData As System.Windows.Forms.Form, dlgGroups As System.Windows.Forms.Form)
        m_dlgMainWnd = dlgMainWnd
        m_dlgAcctData = dlgAcctData
        m_dlgGroups = dlgGroups
    End Sub

    '--------------------------------------------------------------------------------
    ' Display an XML message
    '--------------------------------------------------------------------------------
    Public Sub displayMultiline(listType As ListType, xml As String)
        Dim text = Replace(xml, TABSTR, "    ")
        Dim strArray = Split(text, LFSTR) ' VB.NET must be removing the CR
        For Each line In strArray
            If Len(line) > 1020 Then
                line = Left(line, 1020) & " ..."
            End If
            addListItem(listType, line)
        Next
    End Sub

    Public Function faMsgTypeName(faMsgType As FaMessageType) As Object
        Return [Enum].GetName(GetType(FaMessageType), faMsgType)
    End Function

    '--------------------------------------------------------------------------------
    ' Add an item to one of the display listboxes
    '--------------------------------------------------------------------------------
    Public Sub addListItem(listType As ListType, data As String, Optional scrollList As Boolean = True)
        Dim listBox As System.Windows.Forms.ListBox
        Select Case listType
            Case ListType.MarketData
                listBox = m_dlgMainWnd.lstMktData
            Case ListType.ServerResponses
                listBox = m_dlgMainWnd.lstServerResponses
            Case ListType.Errors
                listBox = m_dlgMainWnd.lstErrors
            Case ListType.AccountData
                listBox = m_dlgAcctData.lstKeyValueData
            Case ListType.PortfolioData
                listBox = m_dlgAcctData.lstPortfolioData
            Case ListType.DisplayGroupsData
                listBox = m_dlgGroups.lstGroupMessages
            Case Else
                Return
        End Select
        Dim lines() As String = data.Split({LFSTR}, 500)
        For Each line In lines
            listBox.Items.Add(line.Replace(CRSTR, ""))
        Next
        If scrollList Then
            listBox.TopIndex = listBox.Items.Count - 1
        End If
    End Sub

    '--------------------------------------------------------------------------------
    ' Returns the tick display string used when adding tick data to the display list.
    '--------------------------------------------------------------------------------
    Public Function getField(field As TickType) As Object
        Return [Enum].GetName(GetType(TickType), field)
    End Function

    Public Shared Function StringToDouble(val As String) As Double
        Return If(String.IsNullOrWhiteSpace(val), Double.MaxValue, CDbl(val))
    End Function

    Public Shared Function UnixMillisecondsToString(unixTime As Long, dateFormat As String) As String
        UnixMillisecondsToString = DateAdd(DateInterval.Second, unixTime / 1000, DateSerial(1970, 1, 1)).ToString(dateFormat)
    End Function

End Class
