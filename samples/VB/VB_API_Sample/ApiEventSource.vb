' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Imports IBApi
Imports System.Collections.Generic

Friend Class ApiEventSource
    Implements IBApi.EWrapper

    Private m_Api As EClient
    Private m_form As Form

    Sub New(form As Form)
        m_form = form
    End Sub

    Friend WriteOnly Property ApiClient As EClient
        Set
            m_Api = Value
        End Set
    End Property

    Sub InvokeIfRequired(action As Action)
        If m_form.IsDisposed Then Exit Sub

        If m_form.InvokeRequired Then
            m_form.Invoke(action)
        Else
            action()
        End If
    End Sub

#Region "IBApi.EWrapper"

    Private Sub EWrapper_AccountDownloadEnd(account As String) Implements IBApi.EWrapper.accountDownloadEnd
        InvokeIfRequired(Sub()
                             RaiseEvent AccountDownloadEnd(Me, New AccountDownloadEndEventArgs With {
                                 .account = account
                                         })
                         End Sub)
    End Sub

    Private Sub EWrapper_AccountSummary(reqId As Integer, account As String, tag As String, value As String, currency As String) Implements IBApi.EWrapper.accountSummary
        InvokeIfRequired(Sub()
                             RaiseEvent AccountSummary(Me, New AccountSummaryEventArgs With {
                                                                      .reqId = reqId,
                                                                      .account = account,
                                                                      .tag = tag,
                                                                      .value = value,
                                                                      .currency = currency
                                                                     })
                         End Sub)
    End Sub

    Private Sub EWrapper_AccountSummaryEnd(reqId As Integer) Implements IBApi.EWrapper.accountSummaryEnd
        InvokeIfRequired(Sub()
                             RaiseEvent AccountSummaryEnd(Me, New AccountSummaryEndEventArgs With {
                                                                     .reqId = reqId
                                                                     })
                         End Sub)
    End Sub

    Private Sub EWrapper_CommissionReport(commissionReport As IBApi.CommissionReport) Implements IBApi.EWrapper.commissionReport
        InvokeIfRequired(Sub()
                             RaiseEvent commissionReport(Me, New CommissionReportEventArgs With {
                                                                     .commissionReport = commissionReport
                                                                     })
                         End Sub)
    End Sub

    Private Sub EWrapper_ConnectionClosed() Implements IBApi.EWrapper.connectionClosed
        InvokeIfRequired(Sub()
                             RaiseEvent ConnectionClosed(Me, EventArgs.Empty)
                         End Sub)
    End Sub

    Private Sub EWrapper_ContractDetails(reqId As Integer, contractDetails As IBApi.ContractDetails) Implements IBApi.EWrapper.contractDetails
        InvokeIfRequired(Sub()
                             RaiseEvent contractDetails(Me, New ContractDetailsEventArgs With {
                                                                     .reqId = reqId,
                                                                      .contractDetails = contractDetails
                                                                     })
                         End Sub)
    End Sub

    Private Sub EWrapper_ContractDetailsEnd(reqId As Integer) Implements IBApi.EWrapper.contractDetailsEnd
        InvokeIfRequired(Sub()
                             RaiseEvent ContractDetailsEnd(Me, New ContractDetailsEndEventArgs With {
                                                                     .reqId = reqId
                                                                     })
                         End Sub)
    End Sub

    Private Sub EWrapper_CurrentTime(time As Long) Implements IBApi.EWrapper.currentTime
        InvokeIfRequired(Sub()
                             RaiseEvent CurrentTime(Me, New CurrentTimeEventArgs With {
                                                                     .time = time
                                                                     })
                         End Sub)
    End Sub

    Private Sub EWrapper_DeltaNeutralValidation(reqId As Integer, underComp As IBApi.UnderComp) Implements IBApi.EWrapper.deltaNeutralValidation
        InvokeIfRequired(Sub()
                             RaiseEvent DeltaNeutralValidation(Me, New DeltaNeutralValidationEventArgs With {
                                                                      .reqId = reqId,
                                                                      .underComp = underComp
                                                                     })
                         End Sub)
    End Sub

    Private Sub EWrapper_DisplayGroupList(reqId As Integer, groups As String) Implements IBApi.EWrapper.displayGroupList
        InvokeIfRequired(Sub()
                             RaiseEvent DisplayGroupList(Me, New DisplayGroupListEventArgs With {
                                                                      .reqId = reqId,
                                                                      .groups = groups
                                                                     })
                         End Sub)
    End Sub

    Private Sub EWrapper_DisplayGroupUpdated(reqId As Integer, contractInfo As String) Implements IBApi.EWrapper.displayGroupUpdated
        InvokeIfRequired(Sub()
                             RaiseEvent DisplayGroupUpdated(Me, New DisplayGroupUpdatedEventArgs With {
                                                                      .reqId = reqId,
                                                                      .contractInfo = contractInfo
                                                                     })
                         End Sub)
    End Sub

    Private Sub EWrapper_Error(id As Integer, errorCode As Integer, errorMsg As String) Implements IBApi.EWrapper.error
        InvokeIfRequired(Sub()
                             RaiseEvent ErrMsg(Me, New ErrMsgEventArgs With {.id = id, .errorCode = errorCode, .errorMsg = errorMsg})
                         End Sub)
    End Sub

    Private Sub EWrapper_Error(str As String) Implements IBApi.EWrapper.error
        InvokeIfRequired(Sub()
                             RaiseEvent ErrMsg(Me, New ErrMsgEventArgs With {.id = -1, .errorCode = -1, .errorMsg = str})
                         End Sub)
    End Sub

    Private Sub EWrapper_Error(e As Exception) Implements IBApi.EWrapper.error
        InvokeIfRequired(Sub()
                             RaiseEvent ErrMsg(Me, New ErrMsgEventArgs With {.id = -1, .errorCode = -1, .errorMsg = e.Message})
                         End Sub)
    End Sub

    Private Sub EWrapper_ExecDetails(reqId As Integer, contract As IBApi.Contract, execution As IBApi.Execution) Implements IBApi.EWrapper.execDetails
        InvokeIfRequired(Sub()
                             RaiseEvent ExecDetails(Me, New ExecDetailsEventArgs With {
                                                                     .reqId = reqId,
                                                                      .contract = contract,
                                                                      .execution = execution
                                                                     })
                         End Sub)
    End Sub

    Private Sub EWrapper_ExecDetailsEnd(reqId As Integer) Implements IBApi.EWrapper.execDetailsEnd
        InvokeIfRequired(Sub()
                             RaiseEvent ExecDetailsEnd(Me, New ExecDetailsEndEventArgs With {
                                                                     .reqId = reqId
                                                                     })
                         End Sub)
    End Sub

    Private Sub EWrapper_FundamentalData(reqId As Integer, data As String) Implements IBApi.EWrapper.fundamentalData
        InvokeIfRequired(Sub()
                             RaiseEvent FundamentalData(Me, New FundamentalDataEventArgs With {
                                                                     .reqId = reqId,
                                                                      .data = data
                                                                     })
                         End Sub)
    End Sub

    Private Sub EWrapper_HistoricalData(reqId As Integer, [date] As String, open As Double, high As Double, low As Double, close As Double, volume As Integer, count As Integer, WAP As Double, hasGaps As Boolean) Implements IBApi.EWrapper.historicalData
        InvokeIfRequired(Sub()
                             RaiseEvent HistoricalData(Me, New HistoricalDataEventArgs With {
                                                                                                 .reqId = reqId,
                                                                                                 .[date] = [date],
                                                                                                 .open = open,
                                                                                                 .high = high,
                                                                                                 .low = low,
                                                                                                 .close = close,
                                                                                                 .volume = volume,
                                                                                                 .count = count,
                                                                                                 .WAP = WAP,
                                                                                                 .hasGaps = hasGaps
                                                                                             })
                         End Sub)
    End Sub

    Private Sub EWrapper_HistoricalDataEnd(reqId As Integer, start As String, [end] As String) Implements IBApi.EWrapper.historicalDataEnd
        InvokeIfRequired(Sub()
                             RaiseEvent HistoricalDataEnd(Me, New HistoricalDataEndEventArgs With {
                                                                                                    .reqId = reqId,
                                                                                                    .start = start,
                                                                                                    .[end] = [end]
                                                                                                    })
                         End Sub)
    End Sub

    Private Sub EWrapper_ManagedAccounts(accountsList As String) Implements IBApi.EWrapper.managedAccounts
        InvokeIfRequired(Sub()
                             RaiseEvent ManagedAccounts(Me, New ManagedAccountsEventArgs With {
                                                                     .accountsList = accountsList
                                                                     })
                         End Sub)
    End Sub

    Private Sub EWrapper_MarketDataType(reqId As Integer, marketDataType As Integer) Implements IBApi.EWrapper.marketDataType
        InvokeIfRequired(Sub()
                             RaiseEvent marketDataType(Me, New MarketDataTypeEventArgs With {
                                                                     .reqId = reqId,
                                                                      .marketDataType = marketDataType
                                                                     })
                         End Sub)
    End Sub

    Private Sub EWrapper_NextValidId(orderId As Integer) Implements IBApi.EWrapper.nextValidId
        InvokeIfRequired(Sub()
                             RaiseEvent NextValidId(Me, New NextValidIdEventArgs With {.Id = orderId})
                         End Sub)
    End Sub

    Private Sub EWrapper_OpenOrder(orderId As Integer, contract As IBApi.Contract, order As IBApi.Order, orderState As IBApi.OrderState) Implements IBApi.EWrapper.openOrder
        InvokeIfRequired(Sub()
                             RaiseEvent OpenOrder(Me, New OpenOrderEventArgs With {
                                                                     .orderId = orderId,
                                                                      .contract = contract,
                                                                      .order = order,
                                                                      .orderState = orderState
                                                                     })
                         End Sub)
    End Sub

    Private Sub EWrapper_OpenOrderEnd() Implements IBApi.EWrapper.openOrderEnd
        InvokeIfRequired(Sub()
                             RaiseEvent OpenOrderEnd(Me, EventArgs.Empty)
                         End Sub)
    End Sub

    Private Sub EWrapper_OrderStatus(orderId As Integer, status As String, filled As Double, remaining As Double, avgFillPrice As Double, permId As Integer, parentId As Integer, lastFillPrice As Double, clientId As Integer, whyHeld As String) Implements IBApi.EWrapper.orderStatus
        InvokeIfRequired(Sub()
                             RaiseEvent OrderStatus(Me, New OrderStatusEventArgs With {
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
                         End Sub)
    End Sub

    Private Sub EWrapper_Position(account As String, contract As IBApi.Contract, pos As Double, avgCost As Double) Implements IBApi.EWrapper.position
        InvokeIfRequired(Sub()
                             RaiseEvent Position(Me, New PositionEventArgs With {
                                                                     .account = account,
                                                                      .contract = contract,
                                                                      .pos = pos,
                                                                      .avgCost = avgCost
                                                                     })
                         End Sub)
    End Sub

    Private Sub EWrapper_PositionEnd() Implements IBApi.EWrapper.positionEnd
        InvokeIfRequired(Sub()
                             RaiseEvent PositionEnd(Me, EventArgs.Empty)
                         End Sub)
    End Sub

    Private Sub EWrapper_RealtimeBar(reqId As Integer, time As Long, open As Double, high As Double, low As Double, close As Double, volume As Long, WAP As Double, count As Integer) Implements IBApi.EWrapper.realtimeBar
        InvokeIfRequired(Sub()
                             RaiseEvent RealtimeBar(Me, New RealtimeBarEventArgs With {
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
                         End Sub)
    End Sub

    Private Sub EWrapper_ReceiveFA(faDataType As Integer, faXmlData As String) Implements IBApi.EWrapper.receiveFA
        InvokeIfRequired(Sub()
                             RaiseEvent ReceiveFA(Me, New ReceiveFAEventArgs With {
                                                                     .faDataType = faDataType,
                                                                      .faXmlData = faXmlData
                                                                     })
                         End Sub)
    End Sub

    Private Sub EWrapper_ScannerData(reqId As Integer, rank As Integer, contractDetails As IBApi.ContractDetails, distance As String, benchmark As String, projection As String, legsStr As String) Implements IBApi.EWrapper.scannerData
        InvokeIfRequired(Sub()
                             RaiseEvent ScannerData(Me, New ScannerDataEventArgs With {
                                                                     .reqId = reqId,
                                                                      .rank = rank,
                                                                      .contractDetails = contractDetails,
                                                                      .distance = distance,
                                                                      .benchmark = benchmark,
                                                                      .projection = projection,
                                                                      .legsStr = legsStr
                                                                     })
                         End Sub)
    End Sub

    Private Sub EWrapper_ScannerDataEnd(reqId As Integer) Implements IBApi.EWrapper.scannerDataEnd
        InvokeIfRequired(Sub()
                             RaiseEvent ScannerDataEnd(Me, New ScannerDataEndEventArgs With {
                                                                     .reqId = reqId
                                                                     })
                         End Sub)
    End Sub

    Private Sub EWrapper_ScannerParameters(xml As String) Implements IBApi.EWrapper.scannerParameters
        InvokeIfRequired(Sub()
                             RaiseEvent ScannerParameters(Me, New ScannerParametersEventArgs With {
                                                                     .xml = xml
                                                                     })
                         End Sub)
    End Sub

    Private Sub EWrapper_TickEFP(tickerId As Integer, tickType As Integer, basisPoints As Double, formattedBasisPoints As String, impliedFuture As Double, holdDays As Integer, futureLastTradeDate As String, dividendImpact As Double, dividendsToLastTradeDate As Double) Implements IBApi.EWrapper.tickEFP
        InvokeIfRequired(Sub()
                             RaiseEvent TickEFP(Me, New TickEFPEventArgs With {
                                                                                          .tickerId = tickerId,
                                                                                          .field = tickType,
                                                                                          .basisPoints = basisPoints,
                                                                                          .formattedBasisPoints = formattedBasisPoints,
                                                                                          .impliedFuture = impliedFuture,
                                                                                          .holdDays = holdDays,
                                                                                          .futureLastTradeDate = futureLastTradeDate,
                                                                                          .dividendImpact = dividendImpact,
                                                                                          .dividendsToLastTradeDate = dividendsToLastTradeDate
                                                                                      })
                         End Sub)
    End Sub

    Private Sub EWrapper_TickGeneric(tickerId As Integer, field As Integer, value As Double) Implements IBApi.EWrapper.tickGeneric
        InvokeIfRequired(Sub()
                             RaiseEvent TickGeneric(Me, New TickGenericEventArgs With {.id = tickerId, .tickType = field, .value = value})
                         End Sub)
    End Sub

    Private Sub EWrapper_TickOptionComputation(tickerId As Integer, field As Integer, impliedVolatility As Double, delta As Double, optPrice As Double, pvDividend As Double, gamma As Double, vega As Double, theta As Double, undPrice As Double) Implements IBApi.EWrapper.tickOptionComputation
        InvokeIfRequired(Sub()
                             RaiseEvent TickOptionComputation(Me, New TickOptionComputationEventArgs With {
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
                         End Sub)
    End Sub

    Private Sub EWrapper_TickPrice(tickerId As Integer, field As Integer, price As Double, attribs As TickAttrib) Implements IBApi.EWrapper.tickPrice
        InvokeIfRequired(Sub()
                             RaiseEvent TickPrice(Me, New TickPriceEventArgs With {.id = tickerId, .price = price, .tickType = field, .attribs = attribs})
                         End Sub)
    End Sub

    Private Sub EWrapper_TickSize(tickerId As Integer, field As Integer, size As Integer) Implements IBApi.EWrapper.tickSize
        InvokeIfRequired(Sub()
                             RaiseEvent TickSize(Me, New TickSizeEventArgs With {.id = tickerId, .size = size, .tickType = field})
                         End Sub)
    End Sub

    Private Sub EWrapper_TickSnapshotEnd(tickerId As Integer) Implements IBApi.EWrapper.tickSnapshotEnd
        InvokeIfRequired(Sub()
                             RaiseEvent TickSnapshotEnd(Me, New TickSnapshotEndEventArgs With {
                                                                     .tickerId = tickerId
                                                                     })
                         End Sub)
    End Sub

    Private Sub EWrapper_TickString(tickerId As Integer, field As Integer, value As String) Implements IBApi.EWrapper.tickString
        InvokeIfRequired(Sub()
                             RaiseEvent TickString(Me, New TickStringEventArgs With {.id = tickerId, .tickType = field, .value = value})
                         End Sub)
    End Sub

    Private Sub EWrapper_UpdateAccountTime(timestamp As String) Implements IBApi.EWrapper.updateAccountTime
        InvokeIfRequired(Sub()
                             RaiseEvent UpdateAccountTime(Me, New UpdateAccountTimeEventArgs With {
                                                                     .timestamp = timestamp
                                                                     })
                         End Sub)
    End Sub

    Private Sub EWrapper_UpdateAccountValue(key As String, value As String, currency As String, accountName As String) Implements IBApi.EWrapper.updateAccountValue
        InvokeIfRequired(Sub()
                             RaiseEvent UpdateAccountValue(Me, New UpdateAccountValueEventArgs With {
                                                                     .key = key,
                                                                      .value = value,
                                                                      .currency = currency,
                                                                      .accountName = accountName
                                                                     })
                         End Sub)
    End Sub

    Private Sub EWrapper_UpdateMktDepth(tickerId As Integer, position As Integer, operation As Integer, side As Integer, price As Double, size As Integer) Implements IBApi.EWrapper.updateMktDepth
        InvokeIfRequired(Sub()
                             RaiseEvent UpdateMktDepth(Me, New UpdateMktDepthEventArgs With {
                                                                                                 .tickerId = tickerId,
                                                                                                 .position = position,
                                                                                                 .operation = operation,
                                                                                                 .side = side,
                                                                                                 .price = price,
                                                                                                 .size = size
                                                                                             })
                         End Sub)
    End Sub

    Private Sub EWrapper_UpdateMktDepthL2(tickerId As Integer, position As Integer, marketMaker As String, operation As Integer, side As Integer, price As Double, size As Integer) Implements IBApi.EWrapper.updateMktDepthL2
        InvokeIfRequired(Sub()
                             RaiseEvent UpdateMktDepthL2(Me, New UpdateMktDepthL2EventArgs With {
                                                                                                   .tickerId = tickerId,
                                                                                                   .position = position,
                                                                                                   .marketMaker = marketMaker,
                                                                                                   .operation = operation,
                                                                                                   .side = side,
                                                                                                   .price = price,
                                                                                                   .size = size
                                                                                               })
                         End Sub)
    End Sub

    Private Sub EWrapper_UpdateNewsBulletin(msgId As Integer, msgType As Integer, message As String, origExchange As String) Implements IBApi.EWrapper.updateNewsBulletin
        InvokeIfRequired(Sub()
                             RaiseEvent UpdateNewsBulletin(Me, New UpdateNewsBulletinEventArgs With {
                                                                     .msgId = msgId,
                                                                      .msgType = msgType,
                                                                      .message = message,
                                                                      .origExchange = origExchange
                                                                     })
                         End Sub)
    End Sub

    Private Sub EWrapper_UpdatePortfolio(contract As IBApi.Contract, position As Double, marketPrice As Double, marketValue As Double, averageCost As Double, unrealisedPNL As Double, realisedPNL As Double, accountName As String) Implements IBApi.EWrapper.updatePortfolio
        InvokeIfRequired(Sub()
                             RaiseEvent UpdatePortfolio(Me, New UpdatePortfolioEventArgs With {
                                                                     .contract = contract,
                                                                      .position = position,
                                                                      .marketPrice = marketPrice,
                                                                      .marketValue = marketValue,
                                                                      .averageCost = averageCost,
                                                                      .unrealisedPNL = unrealisedPNL,
                                                                      .realisedPNL = realisedPNL,
                                                                      .accountName = accountName
                                                                     })
                         End Sub)
    End Sub

    Private Sub EWrapper_VerifyCompleted(isSuccessful As Boolean, errorText As String) Implements IBApi.EWrapper.verifyCompleted
        InvokeIfRequired(Sub()
                             RaiseEvent VerifyCompleted(Me, New VerifyCompletedEventArgs With {
                                                                     .isSuccessful = isSuccessful,
                                                                      .errorText = errorText
                                                                     })
                         End Sub)
    End Sub

    Private Sub EWrapper_VerifyMessageAPI(apiData As String) Implements IBApi.EWrapper.verifyMessageAPI
        InvokeIfRequired(Sub()
                             RaiseEvent VerifyMessageAPI(Me, New VerifyMessageAPIEventArgs With {
                                                                     .apiData = apiData
                                                                     })
                         End Sub)
    End Sub

    Private Sub EWrapper_VerifyAndAuthCompleted(isSuccessful As Boolean, errorText As String) Implements IBApi.EWrapper.verifyAndAuthCompleted
        InvokeIfRequired(Sub()
                             RaiseEvent VerifyAndAuthCompleted(Me, New VerifyAndAuthCompletedEventArgs With {
                                                                     .isSuccessful = isSuccessful,
                                                                     .errorText = errorText
                                                                     })
                         End Sub)
    End Sub

    Private Sub EWrapper_VerifyAndAuthMessageAPI(apiData As String, xyzChallenge As String) Implements IBApi.EWrapper.verifyAndAuthMessageAPI
        InvokeIfRequired(Sub()
                             RaiseEvent VerifyAndAuthMessageAPI(Me, New VerifyAndAuthMessageAPIEventArgs With {
                                                                     .apiData = apiData,
                                                                     .xyzChallenge = xyzChallenge
                                                                     })
                         End Sub)
    End Sub

    Private Sub EWrapper_ConnectAck() Implements EWrapper.connectAck
        If m_Api.AsyncEConnect Then
            m_Api.startApi()
        End If
    End Sub

    Private Sub EWrapper_PositionMulti(reqId As Integer, account As String, modelCode As String, contract As IBApi.Contract, pos As Double, avgCost As Double) Implements IBApi.EWrapper.positionMulti
        InvokeIfRequired(Sub()
                             RaiseEvent PositionMulti(Me, New PositionMultiEventArgs With {
                                                           .reqId = reqId,
                                                           .account = account,
                                                           .modelCode = modelCode,
                                                           .contract = contract,
                                                           .pos = pos,
                                                           .avgCost = avgCost
                                                           })
                         End Sub)
    End Sub

    Private Sub EWrapper_PositionMultiEnd(reqId As Integer) Implements IBApi.EWrapper.positionMultiEnd
        InvokeIfRequired(Sub()
                             RaiseEvent PositionMultiEnd(Me, New PositionMultiEndEventArgs With {
                                                              .reqId = reqId
                                                              })
                         End Sub)
    End Sub

    Private Sub EWrapper_AccountUpdateMulti(reqId As Integer, account As String, modelCode As String, key As String, value As String, currency As String) Implements IBApi.EWrapper.accountUpdateMulti
        InvokeIfRequired(Sub()
                             RaiseEvent AccountUpdateMulti(Me, New AccountUpdateMultiEventArgs With {
                                                                .reqId = reqId,
                                                                .account = account,
                                                                .modelCode = modelCode,
                                                                .key = key,
                                                                .value = value,
                                                                .currency = currency
                                                                })
                         End Sub)
    End Sub

    Private Sub EWrapper_AccountUpdateMultiEnd(reqId As Integer) Implements IBApi.EWrapper.accountUpdateMultiEnd
        InvokeIfRequired(Sub()
                             RaiseEvent AccountUpdateMultiEnd(Me, New AccountUpdateMultiEndEventArgs With {
                                                              .reqId = reqId
                                                              })
                         End Sub)
    End Sub

    Private Sub EWrapper_BondContractDetails(reqId As Integer, contractDetails As IBApi.ContractDetails) Implements IBApi.EWrapper.bondContractDetails
        InvokeIfRequired(Sub()
                             RaiseEvent BondContractDetails(Me, New BondContractDetailsEventArgs With {
                                                                     .reqId = reqId,
                                                                      .contractDetails = contractDetails
                                                                     })
                         End Sub)

    End Sub

    Private Sub EWrapper_SecurityDefinitionOptionParameter(reqId As Integer, exchange As String, underlyingConId As Integer, tradingClass As String, multiplier As String, expirations As HashSet(Of String), strikes As HashSet(Of Double)) Implements EWrapper.securityDefinitionOptionParameter
        InvokeIfRequired(Sub()
                             RaiseEvent SecurityDefinitionOptionParameter(Me, New SecurityDefinitionOptionParameterEventArgs With {
                                                                                .reqId = reqId,
                                                                                .exchange = exchange,
                                                                                .underlyingConId = underlyingConId,
                                                                                .tradingClass = tradingClass,
                                                                                .multiplier = multiplier,
                                                                                .expirations = expirations,
                                                                                .strikes = strikes
                                                                            })
                         End Sub)
    End Sub

    Private Sub EWrapper_SecurityDefinitionOptionParameterEnd(reqId As Integer) Implements EWrapper.securityDefinitionOptionParameterEnd
        InvokeIfRequired(Sub()
                             RaiseEvent SecurityDefinitionOptionParameterEnd(Me, New SecurityDefinitionOptionParameterEndEventArgs With {
                                                              .reqId = reqId
                                                              })
                         End Sub)
    End Sub

    Private Sub EWrapper_FamilyCodes(familyCodes() As FamilyCode) Implements EWrapper.familyCodes
        InvokeIfRequired(Sub()
                             RaiseEvent familyCodes(Me, New FamilyCodesEventArgs With {
                                                              .familyCodes = familyCodes
                                                            })
                         End Sub)
    End Sub

    Private Sub EWrapper_SymbolSamples(reqId As Integer, contractDescriptions() As ContractDescription) Implements EWrapper.symbolSamples
        InvokeIfRequired(Sub()
                             RaiseEvent SymbolSamples(Me, New SymbolSamplesEventArgs With {
                                                            .reqId = reqId,
                                                            .contractDescriptions = contractDescriptions
                                                            })
                         End Sub)
    End Sub

    Private Sub EWrapper_SoftDollarTiers(requestId As Integer, tiers() As SoftDollarTier) Implements EWrapper.softDollarTiers

    End Sub

    Public Sub EWrapper_MktDepthExchanges(depthMktDataDescriptions() As DepthMktDataDescription) Implements EWrapper.mktDepthExchanges
    End Sub

#End Region

#Region "Event declarations"

    Event NextValidId(sender As Object, e As NextValidIdEventArgs)
    Event ErrMsg(sender As Object, e As ErrMsgEventArgs)
    Event ConnectionClosed(sender As Object, e As System.EventArgs)
    Event TickPrice(sender As Object, e As TickPriceEventArgs)
    Event TickSize(sender As Object, e As TickSizeEventArgs)
    Event TickGeneric(sender As Object, e As TickGenericEventArgs)
    Event TickString(sender As Object, e As TickStringEventArgs)
    Event TickEFP(sender As Object, e As TickEFPEventArgs)
    Event TickOptionComputation(sender As Object, e As TickOptionComputationEventArgs)
    Event UpdateMktDepth(sender As Object, e As UpdateMktDepthEventArgs)
    Event AccountDownloadEnd(sender As Object, e As AccountDownloadEndEventArgs)
    Event AccountSummary(sender As Object, e As AccountSummaryEventArgs)
    Event AccountSummaryEnd(sender As Object, e As AccountSummaryEndEventArgs)
    Event CommissionReport(sender As Object, e As CommissionReportEventArgs)
    Event ContractDetails(sender As Object, e As ContractDetailsEventArgs)
    Event ContractDetailsEnd(sender As Object, e As ContractDetailsEndEventArgs)
    Event CurrentTime(sender As Object, e As CurrentTimeEventArgs)
    Event AccountUpdateMulti(sender As Object, e As AccountUpdateMultiEventArgs)
    Event AccountUpdateMultiEnd(sender As Object, e As AccountUpdateMultiEndEventArgs)
    Event DeltaNeutralValidation(sender As Object, e As DeltaNeutralValidationEventArgs)
    Event DisplayGroupList(sender As Object, e As DisplayGroupListEventArgs)
    Event DisplayGroupUpdated(sender As Object, e As DisplayGroupUpdatedEventArgs)
    Event ExecDetailsEnd(sender As Object, e As ExecDetailsEndEventArgs)
    Event ExecDetails(sender As Object, e As ExecDetailsEventArgs)
    Event FundamentalData(sender As Object, e As FundamentalDataEventArgs)
    Event HistoricalData(sender As Object, e As HistoricalDataEventArgs)
    Event HistoricalDataEnd(sender As Object, e As HistoricalDataEndEventArgs)
    Event ManagedAccounts(sender As Object, e As ManagedAccountsEventArgs)
    Event MarketDataType(sender As Object, e As MarketDataTypeEventArgs)
    Event OpenOrderEnd(sender As Object, e As EventArgs)
    Event OpenOrder(sender As Object, e As OpenOrderEventArgs)
    Event OrderStatus(sender As Object, e As OrderStatusEventArgs)
    Event Position(sender As Object, e As PositionEventArgs)
    Event PositionEnd(sender As Object, e As EventArgs)
    Event PositionMulti(sender As Object, e As PositionMultiEventArgs)
    Event PositionMultiEnd(sender As Object, e As PositionMultiEndEventArgs)
    Event RealtimeBar(sender As Object, e As RealtimeBarEventArgs)
    Event ReceiveFA(sender As Object, e As ReceiveFAEventArgs)
    Event ScannerDataEnd(sender As Object, e As ScannerDataEndEventArgs)
    Event ScannerData(sender As Object, e As ScannerDataEventArgs)
    Event ScannerParameters(sender As Object, e As ScannerParametersEventArgs)
    Event SecurityDefinitionOptionParameter(sender As Object, e As SecurityDefinitionOptionParameterEventArgs)
    Event SecurityDefinitionOptionParameterEnd(sender As Object, e As SecurityDefinitionOptionParameterEndEventArgs)
    Event TickSnapshotEnd(sender As Object, e As TickSnapshotEndEventArgs)
    Event UpdateAccountTime(sender As Object, e As UpdateAccountTimeEventArgs)
    Event UpdateAccountValue(sender As Object, e As UpdateAccountValueEventArgs)
    Event UpdateMktDepthL2(sender As Object, e As UpdateMktDepthL2EventArgs)
    Event UpdateNewsBulletin(sender As Object, e As UpdateNewsBulletinEventArgs)
    Event UpdatePortfolio(sender As Object, e As UpdatePortfolioEventArgs)
    Event VerifyCompleted(sender As Object, e As VerifyCompletedEventArgs)
    Event VerifyMessageAPI(sender As Object, e As VerifyMessageAPIEventArgs)
    Event VerifyAndAuthCompleted(sender As Object, e As VerifyAndAuthCompletedEventArgs)
    Event VerifyAndAuthMessageAPI(sender As Object, e As VerifyAndAuthMessageAPIEventArgs)
    Event FamilyCodes(sender As Object, e As FamilyCodesEventArgs)
    Event SymbolSamples(sender As Object, e As SymbolSamplesEventArgs)
    Event BondContractDetails(sender As Object, e As BondContractDetailsEventArgs)
    Event MktDepthExchanges(sender As Object, e As MktDepthExchangesEventArgs)

#End Region

End Class

