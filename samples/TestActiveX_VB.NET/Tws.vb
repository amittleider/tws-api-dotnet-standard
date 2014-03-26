Class Tws
    Implements IBApi.EWrapper

#Region "IBApi.EWrapper"
    Public Sub accountDownloadEnd(account As String) Implements IBApi.EWrapper.accountDownloadEnd

    End Sub

    Public Sub accountSummary(reqId As Integer, account As String, tag As String, value As String, currency As String) Implements IBApi.EWrapper.accountSummary

    End Sub

    Public Sub accountSummaryEnd(reqId As Integer) Implements IBApi.EWrapper.accountSummaryEnd

    End Sub

    Public Sub commissionReport(commissionReport As IBApi.CommissionReport) Implements IBApi.EWrapper.commissionReport

    End Sub

    Public Sub connectionClosed() Implements IBApi.EWrapper.connectionClosed

    End Sub

    Public Sub contractDetails(reqId As Integer, contractDetails As IBApi.ContractDetails) Implements IBApi.EWrapper.contractDetails

    End Sub

    Public Sub contractDetailsEnd(reqId As Integer) Implements IBApi.EWrapper.contractDetailsEnd

    End Sub

    Public Sub currentTime(time As Long) Implements IBApi.EWrapper.currentTime

    End Sub

    Public Sub deltaNeutralValidation(reqId As Integer, underComp As IBApi.UnderComp) Implements IBApi.EWrapper.deltaNeutralValidation

    End Sub

    Public Sub displayGroupList(reqId As Integer, groups As String) Implements IBApi.EWrapper.displayGroupList

    End Sub

    Public Sub displayGroupUpdated(reqId As Integer, contractInfo As String) Implements IBApi.EWrapper.displayGroupUpdated

    End Sub

    Public Sub [error](id As Integer, errorCode As Integer, errorMsg As String) Implements IBApi.EWrapper.error
        RaiseEvent OnErrMsg(Me, New AxTWSLib._DTwsEvents_errMsgEvent With {.id = id, .errorCode = errorCode, .errorMsg = errorMsg})
    End Sub

    Public Sub [error](str As String) Implements IBApi.EWrapper.error

    End Sub

    Public Sub [error](e As Exception) Implements IBApi.EWrapper.error

    End Sub

    Public Sub execDetails(reqId As Integer, contract As IBApi.Contract, execution As IBApi.Execution) Implements IBApi.EWrapper.execDetails

    End Sub

    Public Sub execDetailsEnd(reqId As Integer) Implements IBApi.EWrapper.execDetailsEnd

    End Sub

    Public Sub fundamentalData(reqId As Integer, data As String) Implements IBApi.EWrapper.fundamentalData

    End Sub

    Public Sub historicalData(reqId As Integer, [date] As String, open As Double, high As Double, low As Double, close As Double, volume As Integer, count As Integer, WAP As Double, hasGaps As Boolean) Implements IBApi.EWrapper.historicalData

    End Sub

    Public Sub historicalDataEnd(reqId As Integer, start As String, [end] As String) Implements IBApi.EWrapper.historicalDataEnd

    End Sub

    Public Sub managedAccounts(accountsList As String) Implements IBApi.EWrapper.managedAccounts

    End Sub

    Public Sub marketDataType(reqId As Integer, marketDataType As Integer) Implements IBApi.EWrapper.marketDataType

    End Sub

    Public Sub nextValidId(orderId As Integer) Implements IBApi.EWrapper.nextValidId
        RaiseEvent OnNextValidId(Me, New AxTWSLib._DTwsEvents_nextValidIdEvent With {.Id = orderId})
    End Sub

    Public Sub openOrder(orderId As Integer, contract As IBApi.Contract, order As IBApi.Order, orderState As IBApi.OrderState) Implements IBApi.EWrapper.openOrder

    End Sub

    Public Sub openOrderEnd() Implements IBApi.EWrapper.openOrderEnd

    End Sub

    Public Sub orderStatus(orderId As Integer, status As String, filled As Integer, remaining As Integer, avgFillPrice As Double, permId As Integer, parentId As Integer, lastFillPrice As Double, clientId As Integer, whyHeld As String) Implements IBApi.EWrapper.orderStatus

    End Sub

    Public Sub position(account As String, contract As IBApi.Contract, pos As Integer, avgCost As Double) Implements IBApi.EWrapper.position

    End Sub

    Public Sub positionEnd() Implements IBApi.EWrapper.positionEnd

    End Sub

    Public Sub realtimeBar(reqId As Integer, time As Long, open As Double, high As Double, low As Double, close As Double, volume As Long, WAP As Double, count As Integer) Implements IBApi.EWrapper.realtimeBar

    End Sub

    Public Sub receiveFA(faDataType As Integer, faXmlData As String) Implements IBApi.EWrapper.receiveFA

    End Sub

    Public Sub scannerData(reqId As Integer, rank As Integer, contractDetails As IBApi.ContractDetails, distance As String, benchmark As String, projection As String, legsStr As String) Implements IBApi.EWrapper.scannerData

    End Sub

    Public Sub scannerDataEnd(reqId As Integer) Implements IBApi.EWrapper.scannerDataEnd

    End Sub

    Public Sub scannerParameters(xml As String) Implements IBApi.EWrapper.scannerParameters

    End Sub

    Public Sub tickEFP(tickerId As Integer, tickType As Integer, basisPoints As Double, formattedBasisPoints As String, impliedFuture As Double, holdDays As Integer, futureExpiry As String, dividendImpact As Double, dividendsToExpiry As Double) Implements IBApi.EWrapper.tickEFP

    End Sub

    Public Sub tickGeneric(tickerId As Integer, field As Integer, value As Double) Implements IBApi.EWrapper.tickGeneric

    End Sub

    Public Sub tickOptionComputation(tickerId As Integer, field As Integer, impliedVolatility As Double, delta As Double, optPrice As Double, pvDividend As Double, gamma As Double, vega As Double, theta As Double, undPrice As Double) Implements IBApi.EWrapper.tickOptionComputation

    End Sub

    Public Sub tickPrice(tickerId As Integer, field As Integer, price As Double, canAutoExecute As Integer) Implements IBApi.EWrapper.tickPrice

    End Sub

    Public Sub tickSize(tickerId As Integer, field As Integer, size As Integer) Implements IBApi.EWrapper.tickSize

    End Sub

    Public Sub tickSnapshotEnd(tickerId As Integer) Implements IBApi.EWrapper.tickSnapshotEnd

    End Sub

    Public Sub tickString(tickerId As Integer, field As Integer, value As String) Implements IBApi.EWrapper.tickString

    End Sub

    Public Sub updateAccountTime(timestamp As String) Implements IBApi.EWrapper.updateAccountTime

    End Sub

    Public Sub updateAccountValue(key As String, value As String, currency As String, accountName As String) Implements IBApi.EWrapper.updateAccountValue

    End Sub

    Public Sub updateMktDepth(tickerId As Integer, position As Integer, operation As Integer, side As Integer, price As Double, size As Integer) Implements IBApi.EWrapper.updateMktDepth

    End Sub

    Public Sub updateMktDepthL2(tickerId As Integer, position As Integer, marketMaker As String, operation As Integer, side As Integer, price As Double, size As Integer) Implements IBApi.EWrapper.updateMktDepthL2

    End Sub

    Public Sub updateNewsBulletin(msgId As Integer, msgType As Integer, message As String, origExchange As String) Implements IBApi.EWrapper.updateNewsBulletin

    End Sub

    Public Sub updatePortfolio(contract As IBApi.Contract, position As Integer, marketPrice As Double, marketValue As Double, averageCost As Double, unrealisedPNL As Double, realisedPNL As Double, accountName As String) Implements IBApi.EWrapper.updatePortfolio

    End Sub

    Public Sub verifyCompleted(isSuccessful As Boolean, errorText As String) Implements IBApi.EWrapper.verifyCompleted

    End Sub

    Public Sub verifyMessageAPI(apiData As String) Implements IBApi.EWrapper.verifyMessageAPI

    End Sub
#End Region
    Sub reqScannerParameters()
        Throw New NotImplementedException
    End Sub

    Sub cancelScannerSubscription(id As Short)
        Throw New NotImplementedException
    End Sub

    Sub reqScannerSubscriptionEx(id As Integer, subscription As IBApi.ScannerSubscription, scannerSubscriptionOptions As Generic.List(Of IBApi.TagValue))
        Throw New NotImplementedException
    End Sub

    Sub connect(p1 As String, p2 As Integer, p3 As Integer, p4 As Boolean)
        Throw New NotImplementedException
    End Sub

    Function serverVersion() As Integer
        Throw New NotImplementedException
    End Function

    Function TwsConnectionTime() As String
        Throw New NotImplementedException
    End Function

    Sub disconnect()
        Throw New NotImplementedException
    End Sub

    Sub reqMktDataEx(p1 As Integer, m_contractInfo As IBApi.Contract, p3 As String, p4 As Boolean, m_mktDataOptions As Generic.List(Of IBApi.TagValue))
        Throw New NotImplementedException
    End Sub

    Sub cancelMktData(p1 As Integer)
        Throw New NotImplementedException
    End Sub

    Sub reqMktDepthEx(p1 As Integer, m_contractInfo As IBApi.Contract, p3 As Integer, m_mktDepthOptions As Generic.List(Of IBApi.TagValue))
        Throw New NotImplementedException
    End Sub

    Sub cancelMktDepth(p1 As Integer)
        Throw New NotImplementedException
    End Sub

    Sub reqHistoricalDataEx(p1 As Integer, m_contractInfo As IBApi.Contract, p3 As String, p4 As String, p5 As String, p6 As String, p7 As Integer, p8 As Integer, m_chartOptions As Generic.List(Of IBApi.TagValue))
        Throw New NotImplementedException
    End Sub

    Sub cancelHistoricalData(p1 As Integer)
        Throw New NotImplementedException
    End Sub

    Sub reqFundamentalData(p1 As Integer, m_contractInfo As IBApi.Contract, p3 As String)
        Throw New NotImplementedException
    End Sub

    Sub cancelFundamentalData(p1 As Integer)
        Throw New NotImplementedException
    End Sub

    Sub reqRealTimeBarsEx(p1 As Integer, m_contractInfo As IBApi.Contract, p3 As Integer, p4 As String, p5 As Integer, m_realTimeBarsOptions As Generic.List(Of IBApi.TagValue))
        Throw New NotImplementedException
    End Sub

    Sub cancelRealTimeBars(p1 As Integer)
        Throw New NotImplementedException
    End Sub

    Sub reqCurrentTime()
        Throw New NotImplementedException
    End Sub

    Sub placeOrderEx(p1 As Integer, m_contractInfo As IBApi.Contract, m_orderInfo As IBApi.Order)
        Throw New NotImplementedException
    End Sub

    Sub cancelOrder(p1 As Integer)
        Throw New NotImplementedException
    End Sub

    Sub exerciseOptionsEx(p1 As Integer, m_contractInfo As IBApi.Contract, p3 As Integer, p4 As Integer, p5 As String, p6 As Integer)
        Throw New NotImplementedException
    End Sub

    Sub reqContractDetailsEx(p1 As Integer, m_contractInfo As IBApi.Contract)
        Throw New NotImplementedException
    End Sub

    Sub reqOpenOrders()
        Throw New NotImplementedException
    End Sub

    Sub reqAllOpenOrders()
        Throw New NotImplementedException
    End Sub

    Sub reqAutoOpenOrders(p1 As Boolean)
        Throw New NotImplementedException
    End Sub

    Sub reqAccountUpdates(p1 As Boolean, p2 As String)
        Throw New NotImplementedException
    End Sub

    Sub reqExecutionsEx(p1 As Integer, m_execFilter As IBApi.ExecutionFilter)
        Throw New NotImplementedException
    End Sub

    Sub reqIds(p1 As Integer)
        Throw New NotImplementedException
    End Sub

    Sub reqNewsBulletins(p1 As Boolean)
        Throw New NotImplementedException
    End Sub

    Sub cancelNewsBulletins()
        Throw New NotImplementedException
    End Sub

    Sub setServerLogLevel(p1 As Short)
        Throw New NotImplementedException
    End Sub

    Sub reqManagedAccts()
        Throw New NotImplementedException
    End Sub

    Sub requestFA(fA_Message_Type As Utils.FA_Message_Type)
        Throw New NotImplementedException
    End Sub

    Sub calculateImpliedVolatility(p1 As Integer, m_contractInfo As IBApi.Contract, p3 As Double, p4 As Double)
        Throw New NotImplementedException
    End Sub

    Sub calculateOptionPrice(p1 As Integer, m_contractInfo As IBApi.Contract, p3 As Double, p4 As Double)
        Throw New NotImplementedException
    End Sub

    Sub cancelCalculateImpliedVolatility(p1 As Integer)
        Throw New NotImplementedException
    End Sub

    Sub cancelCalculateOptionPrice(p1 As Integer)
        Throw New NotImplementedException
    End Sub

    Sub reqGlobalCancel()
        Throw New NotImplementedException
    End Sub

    Sub reqMarketDataType(p1 As Integer)
        Throw New NotImplementedException
    End Sub

    Sub reqPositions()
        Throw New NotImplementedException
    End Sub

    Sub cancelPositions()
        Throw New NotImplementedException
    End Sub

    Sub reqAccountSummary(p1 As Integer, p2 As String, p3 As String)
        Throw New NotImplementedException
    End Sub

    Sub cancelAccountSummary(p1 As Integer)
        Throw New NotImplementedException
    End Sub

    Event OnNextValidId(ByVal sender As Object, ByVal eventArgs As AxTWSLib._DTwsEvents_nextValidIdEvent)
    Event OnErrMsg(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_errMsgEvent)

End Class
