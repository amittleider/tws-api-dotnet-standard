Class Tws
    Implements IBApi.EWrapper

#Region "IBApi.EWrapper"

    Event OnUpdateMktDepthL2(tws As Tws, p2 As Object)

    Event OnaccountDownloadEnd(tws As Tws, p2 As Object)

    Event OnaccountSummary(tws As Tws, p2 As Object)

    Event OnaccountSummaryEnd(tws As Tws, p2 As Object)

    Event OncommissionReport(tws As Tws, p2 As Object)

    Event OncontractDetails(tws As Tws, p2 As Object)

    Event OncontractDetailsEnd(tws As Tws, p2 As Object)

    Event OncurrentTime(tws As Tws, p2 As Object)

    Event OndeltaNeutralValidation(tws As Tws, p2 As Object)

    Event OndisplayGroupList(tws As Tws, p2 As Object)

    Event OndisplayGroupUpdated(tws As Tws, p2 As Object)

    Event OnexecDetails(tws As Tws, p2 As Object)

    Event OnexecDetailsEnd(tws As Tws, p2 As Object)

    Event OnfundamentalData(tws As Tws, p2 As Object)

    Event OnmanagedAccounts(tws As Tws, p2 As Object)

    Event OnmarketDataType(tws As Tws, p2 As Object)

    Event OnopenOrder(tws As Tws, p2 As Object)

    Event OnorderStatus(tws As Tws, p2 As Object)

    Event Onposition(tws As Tws, p2 As Object)

    Event OnrealtimeBar(tws As Tws, p2 As Object)

    Event OnreceiveFA(tws As Tws, p2 As Object)

    Event OnscannerData(tws As Tws, p2 As Object)

    Event OnscannerDataEnd(tws As Tws, p2 As Object)

    Event OnscannerParameters(tws As Tws, p2 As Object)

    Event OntickSnapshotEnd(tws As Tws, p2 As Object)

    Event OnupdateAccountTime(tws As Tws, p2 As Object)

    Event OnupdateAccountValue(tws As Tws, p2 As Object)

    Event OnupdateNewsBulletin(tws As Tws, p2 As Object)

    Event OnupdatePortfolio(tws As Tws, p2 As Object)

    Event OnverifyCompleted(tws As Tws, p2 As Object)

    Event OnverifyMessageAPI(tws As Tws, p2 As Object)

    Public Sub accountDownloadEnd(account As String) Implements IBApi.EWrapper.accountDownloadEnd
        RaiseEvent OnaccountDownloadEnd(Me, New AxTWSLib._DTwsEvents_accountDownloadEndEvent With {
        .account = account
                })
    End Sub

    Public Sub accountSummary(reqId As Integer, account As String, tag As String, value As String, currency As String) Implements IBApi.EWrapper.accountSummary
        RaiseEvent OnaccountSummary(Me, New AxTWSLib._DTwsEvents_accountSummaryEvent With {
         .reqId = reqId,
         .account = account,
         .tag = tag,
         .value = value,
         .currency = currency
        })
    End Sub

    Public Sub accountSummaryEnd(reqId As Integer) Implements IBApi.EWrapper.accountSummaryEnd
        RaiseEvent OnaccountSummaryEnd(Me, New AxTWSLib._DTwsEvents_accountSummaryEndEvent With {
        .reqId = reqId
        })
    End Sub

    Public Sub commissionReport(commissionReport As IBApi.CommissionReport) Implements IBApi.EWrapper.commissionReport
        RaiseEvent OncommissionReport(Me, New AxTWSLib._DTwsEvents_commissionReportEvent With {
        .commissionReport = commissionReport
        })
    End Sub

    Public Sub connectionClosed() Implements IBApi.EWrapper.connectionClosed
        RaiseEvent OnConnectionClosed(Me, EventArgs.Empty)
    End Sub

    Public Sub contractDetails(reqId As Integer, contractDetails As IBApi.ContractDetails) Implements IBApi.EWrapper.contractDetails
        RaiseEvent OncontractDetails(Me, New AxTWSLib._DTwsEvents_contractDetailsEvent With {
        .reqId = reqId,
         .contractDetails = contractDetails
        })
    End Sub

    Public Sub contractDetailsEnd(reqId As Integer) Implements IBApi.EWrapper.contractDetailsEnd
        RaiseEvent OncontractDetailsEnd(Me, New AxTWSLib._DTwsEvents_contractDetailsEndEvent With {
        .reqId = reqId
        })
    End Sub

    Public Sub currentTime(time As Long) Implements IBApi.EWrapper.currentTime
        RaiseEvent OncurrentTime(Me, New AxTWSLib._DTwsEvents_currentTimeEvent With {
        .time = time
        })
    End Sub

    Public Sub deltaNeutralValidation(reqId As Integer, underComp As IBApi.UnderComp) Implements IBApi.EWrapper.deltaNeutralValidation
        RaiseEvent OndeltaNeutralValidation(Me, New AxTWSLib._DTwsEvents_deltaNeutralValidationEvent With {
         .reqId = reqId,
         .underComp = underComp
        })
    End Sub

    Public Sub displayGroupList(reqId As Integer, groups As String) Implements IBApi.EWrapper.displayGroupList
        RaiseEvent OndisplayGroupList(Me, New AxTWSLib._DTwsEvents_displayGroupListEvent With {
         .reqId = reqId,
         .groups = groups
        })
    End Sub

    Public Sub displayGroupUpdated(reqId As Integer, contractInfo As String) Implements IBApi.EWrapper.displayGroupUpdated
        RaiseEvent OndisplayGroupUpdated(Me, New AxTWSLib._DTwsEvents_displayGroupUpdatedEvent With {
         .reqId = reqId,
         .contractInfo = contractInfo
        })
    End Sub

    Public Sub [error](id As Integer, errorCode As Integer, errorMsg As String) Implements IBApi.EWrapper.error
        RaiseEvent OnErrMsg(Me, New AxTWSLib._DTwsEvents_errMsgEvent With {.id = id, .errorCode = errorCode, .errorMsg = errorMsg})
    End Sub

    Public Sub [error](str As String) Implements IBApi.EWrapper.error
        RaiseEvent OnErrMsg(Me, New AxTWSLib._DTwsEvents_errMsgEvent With {.id = -1, .errorCode = -1, .errorMsg = str})
    End Sub

    Public Sub [error](e As Exception) Implements IBApi.EWrapper.error
        RaiseEvent OnErrMsg(Me, New AxTWSLib._DTwsEvents_errMsgEvent With {.id = -1, .errorCode = -1, .errorMsg = e.Message})
    End Sub

    Public Sub execDetails(reqId As Integer, contract As IBApi.Contract, execution As IBApi.Execution) Implements IBApi.EWrapper.execDetails
        RaiseEvent OnexecDetails(Me, New AxTWSLib._DTwsEvents_execDetailsEvent With {
        .reqId = reqId,
         .contract = contract,
         .execution = execution
        })
    End Sub

    Public Sub execDetailsEnd(reqId As Integer) Implements IBApi.EWrapper.execDetailsEnd
        RaiseEvent OnexecDetailsEnd(Me, New AxTWSLib._DTwsEvents_execDetailsEndEvent With {
        .reqId = reqId
        })
    End Sub

    Public Sub fundamentalData(reqId As Integer, data As String) Implements IBApi.EWrapper.fundamentalData
        RaiseEvent OnfundamentalData(Me, New AxTWSLib._DTwsEvents_fundamentalDataEvent With {
        .reqId = reqId,
         .data = data
        })
    End Sub

    Public Sub historicalData(reqId As Integer, [date] As String, open As Double, high As Double, low As Double, close As Double, volume As Integer, count As Integer, WAP As Double, hasGaps As Boolean) Implements IBApi.EWrapper.historicalData

    End Sub

    Public Sub historicalDataEnd(reqId As Integer, start As String, [end] As String) Implements IBApi.EWrapper.historicalDataEnd

    End Sub

    Public Sub managedAccounts(accountsList As String) Implements IBApi.EWrapper.managedAccounts
        RaiseEvent OnmanagedAccounts(Me, New AxTWSLib._DTwsEvents_managedAccountsEvent With {
        .accountsList = accountsList
        })
    End Sub

    Public Sub marketDataType(reqId As Integer, marketDataType As Integer) Implements IBApi.EWrapper.marketDataType
        RaiseEvent OnmarketDataType(Me, New AxTWSLib._DTwsEvents_marketDataTypeEvent With {
        .reqId = reqId,
         .marketDataType = marketDataType
        })
    End Sub

    Public Sub nextValidId(orderId As Integer) Implements IBApi.EWrapper.nextValidId
        RaiseEvent OnNextValidId(Me, New AxTWSLib._DTwsEvents_nextValidIdEvent With {.Id = orderId})
    End Sub

    Public Sub openOrder(orderId As Integer, contract As IBApi.Contract, order As IBApi.Order, orderState As IBApi.OrderState) Implements IBApi.EWrapper.openOrder
        RaiseEvent OnopenOrder(Me, New AxTWSLib._DTwsEvents_openOrderEvent With {
        .orderId = orderId,
         .contract = contract,
         .order = order,
         .orderState = orderState
        })
    End Sub

    Public Sub openOrderEnd() Implements IBApi.EWrapper.openOrderEnd

    End Sub

    Public Sub orderStatus(orderId As Integer, status As String, filled As Integer, remaining As Integer, avgFillPrice As Double, permId As Integer, parentId As Integer, lastFillPrice As Double, clientId As Integer, whyHeld As String) Implements IBApi.EWrapper.orderStatus
        RaiseEvent OnorderStatus(Me, New AxTWSLib._DTwsEvents_orderStatusEvent With {
        .orderId = orderId,
         .status = status,
         .filled = filled,
         .remaining = remaining,
         .avgFillPrice = avgFillPrice,
         .permId = permId,
         .parentId = parentId,
         .lastFillPrice = lastFillPrice,
         .clientId = clientId,
         .whyHeld = whyHeld
        })
    End Sub

    Public Sub position(account As String, contract As IBApi.Contract, pos As Integer, avgCost As Double) Implements IBApi.EWrapper.position
        RaiseEvent Onposition(Me, New AxTWSLib._DTwsEvents_positionEvent With {
        .account = account,
         .contract = contract,
         .pos = pos,
         .avgCost = avgCost
        })
    End Sub

    Public Sub positionEnd() Implements IBApi.EWrapper.positionEnd

    End Sub

    Public Sub realtimeBar(reqId As Integer, time As Long, open As Double, high As Double, low As Double, close As Double, volume As Long, WAP As Double, count As Integer) Implements IBApi.EWrapper.realtimeBar
        RaiseEvent OnrealtimeBar(Me, New AxTWSLib._DTwsEvents_realtimeBarEvent With {
        .reqId = reqId,
         .time = time,
         .open = open,
         .high = high,
         .low = low,
         .close = close,
         .volume = volume,
         .WAP = WAP,
         .count = count
        })
    End Sub

    Public Sub receiveFA(faDataType As Integer, faXmlData As String) Implements IBApi.EWrapper.receiveFA
        RaiseEvent OnreceiveFA(Me, New AxTWSLib._DTwsEvents_receiveFAEvent With {
        .faDataType = faDataType,
         .faXmlData = faXmlData
        })
    End Sub

    Public Sub scannerData(reqId As Integer, rank As Integer, contractDetails As IBApi.ContractDetails, distance As String, benchmark As String, projection As String, legsStr As String) Implements IBApi.EWrapper.scannerData
        RaiseEvent OnscannerData(Me, New AxTWSLib._DTwsEvents_scannerDataEvent With {
        .reqId = reqId,
         .rank = rank,
         .contractDetails = contractDetails,
         .distance = distance,
         .benchmark = benchmark,
         .projection = projection,
         .legsStr = legsStr
        })
    End Sub

    Public Sub scannerDataEnd(reqId As Integer) Implements IBApi.EWrapper.scannerDataEnd
        RaiseEvent OnscannerDataEnd(Me, New AxTWSLib._DTwsEvents_scannerDataEndEvent With {
        .reqId = reqId
        })
    End Sub

    Public Sub scannerParameters(xml As String) Implements IBApi.EWrapper.scannerParameters
        RaiseEvent OnscannerParameters(Me, New AxTWSLib._DTwsEvents_scannerParametersEvent With {
        .xml = xml
        })
    End Sub

    Public Sub tickEFP(tickerId As Integer, tickType As Integer, basisPoints As Double, formattedBasisPoints As String, impliedFuture As Double, holdDays As Integer, futureExpiry As String, dividendImpact As Double, dividendsToExpiry As Double) Implements IBApi.EWrapper.tickEFP
        RaiseEvent OnTickEFP(Me, New AxTWSLib._DTwsEvents_tickEFPEvent With {
                             .tickerId = tickerId,
                             .field = tickType,
                             .basisPoints = basisPoints,
                             .formattedBasisPoints = formattedBasisPoints,
                             .impliedFuture = impliedFuture,
                             .holdDays = holdDays,
                             .futureExpiry = futureExpiry,
                             .dividendImpact = dividendImpact,
                             .dividendsToExpiry = dividendsToExpiry
                         })
    End Sub

    Public Sub tickGeneric(tickerId As Integer, field As Integer, value As Double) Implements IBApi.EWrapper.tickGeneric
        RaiseEvent OnTickGeneric(Me, New AxTWSLib._DTwsEvents_tickGenericEvent With {.id = tickerId, .tickType = field, .value = value})
    End Sub

    Public Sub tickOptionComputation(tickerId As Integer, field As Integer, impliedVolatility As Double, delta As Double, optPrice As Double, pvDividend As Double, gamma As Double, vega As Double, theta As Double, undPrice As Double) Implements IBApi.EWrapper.tickOptionComputation
        RaiseEvent OnTickOptionComputation(Me, New AxTWSLib._DTwsEvents_tickOptionComputationEvent With {
                                           .tickerId = tickerId,
                                           .tickType = field,
                                           .impliedVolatility = impliedVolatility,
                                           .delta = delta,
                                           .optPrice = optPrice,
                                           .pvDividend = pvDividend,
                                           .gamma = gamma,
                                           .vega = vega,
                                           .theta = theta,
                                           .undPrice = undPrice
        })
    End Sub

    Public Sub tickPrice(tickerId As Integer, field As Integer, price As Double, canAutoExecute As Integer) Implements IBApi.EWrapper.tickPrice
        RaiseEvent OnTickPrice(Me, New AxTWSLib._DTwsEvents_tickPriceEvent With {.id = tickerId, .price = price, .tickType = field, .canAutoExecute = canAutoExecute})
    End Sub

    Public Sub tickSize(tickerId As Integer, field As Integer, size As Integer) Implements IBApi.EWrapper.tickSize
        RaiseEvent OnTickSize(Me, New AxTWSLib._DTwsEvents_tickSizeEvent With {.id = tickerId, .size = size, .tickType = field})
    End Sub

    Public Sub tickSnapshotEnd(tickerId As Integer) Implements IBApi.EWrapper.tickSnapshotEnd
        RaiseEvent OntickSnapshotEnd(Me, New AxTWSLib._DTwsEvents_tickSnapshotEndEvent With {
        .tickerId = tickerId
        })
    End Sub

    Public Sub tickString(tickerId As Integer, field As Integer, value As String) Implements IBApi.EWrapper.tickString
        RaiseEvent OnTickString(Me, New AxTWSLib._DTwsEvents_tickStringEvent With {.id = tickerId, .tickType = field, .value = value})
    End Sub

    Public Sub updateAccountTime(timestamp As String) Implements IBApi.EWrapper.updateAccountTime
        RaiseEvent OnupdateAccountTime(Me, New AxTWSLib._DTwsEvents_updateAccountTimeEvent With {
        .timestamp = timestamp
        })
    End Sub

    Public Sub updateAccountValue(key As String, value As String, currency As String, accountName As String) Implements IBApi.EWrapper.updateAccountValue
        RaiseEvent OnupdateAccountValue(Me, New AxTWSLib._DTwsEvents_updateAccountValueEvent With {
        .key = key,
         .value = value,
         .currency = currency,
         .accountName = accountName
        })
    End Sub

    Public Sub updateMktDepth(tickerId As Integer, position As Integer, operation As Integer, side As Integer, price As Double, size As Integer) Implements IBApi.EWrapper.updateMktDepth
        RaiseEvent OnUpdateMktDepth(Me, New AxTWSLib._DTwsEvents_updateMktDepthEvent With {
                                    .tickerId = tickerId,
                                    .position = position,
                                    .operation = operation,
                                    .side = side,
                                    .price = price,
                                    .size = size
                                })
    End Sub

    Public Sub updateMktDepthL2(tickerId As Integer, position As Integer, marketMaker As String, operation As Integer, side As Integer, price As Double, size As Integer) Implements IBApi.EWrapper.updateMktDepthL2
        RaiseEvent OnUpdateMktDepthL2(Me, New AxTWSLib._DTwsEvents_updateMktDepthL2Event With {
                                      .tickerId = tickerId,
                                      .position = position,
                                      .marketMaker = marketMaker,
                                      .operation = operation,
                                      .side = side,
                                      .price = price,
                                      .size = size
                                  })
    End Sub

    Public Sub updateNewsBulletin(msgId As Integer, msgType As Integer, message As String, origExchange As String) Implements IBApi.EWrapper.updateNewsBulletin
        RaiseEvent OnupdateNewsBulletin(Me, New AxTWSLib._DTwsEvents_updateNewsBulletinEvent With {
        .msgId = msgId,
         .msgType = msgType,
         .message = message,
         .origExchange = origExchange
        })
    End Sub

    Public Sub updatePortfolio(contract As IBApi.Contract, position As Integer, marketPrice As Double, marketValue As Double, averageCost As Double, unrealisedPNL As Double, realisedPNL As Double, accountName As String) Implements IBApi.EWrapper.updatePortfolio
        RaiseEvent OnupdatePortfolio(Me, New AxTWSLib._DTwsEvents_updatePortfolioEvent With {
        .contract = contract,
         .position = position,
         .marketPrice = marketPrice,
         .marketValue = marketValue,
         .averageCost = averageCost,
         .unrealisedPNL = unrealisedPNL,
         .realisedPNL = realisedPNL,
         .accountName = accountName
        })
    End Sub

    Public Sub verifyCompleted(isSuccessful As Boolean, errorText As String) Implements IBApi.EWrapper.verifyCompleted
        RaiseEvent OnverifyCompleted(Me, New AxTWSLib._DTwsEvents_verifyCompletedEvent With {
        .isSuccessful = isSuccessful,
         .errorText = errorText
        })
    End Sub

    Public Sub verifyMessageAPI(apiData As String) Implements IBApi.EWrapper.verifyMessageAPI
        RaiseEvent OnverifyMessageAPI(Me, New AxTWSLib._DTwsEvents_verifyMessageAPIEvent With {
        .apiData = apiData
        })
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
    Event OnConnectionClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
    Event OnTickPrice(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickPriceEvent)
    Event OnTickSize(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickSizeEvent)
    Event OnTickGeneric(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickGenericEvent)
    Event OnTickString(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickStringEvent)
    Event OnTickEFP(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickEFPEvent)
    Event OnTickOptionComputation(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_tickOptionComputationEvent)
    Event OnUpdateMktDepth(ByVal eventSender As System.Object, ByVal eventArgs As AxTWSLib._DTwsEvents_updateMktDepthEvent)
End Class
