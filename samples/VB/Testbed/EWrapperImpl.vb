Imports IBApi

Namespace Samples

    '! [ewrapperimpl]
    Public Class EWrapperImpl
        Implements EWrapper
        '! [ewrapperimpl]
        '! [socket_declare]
        Public eReaderSignal As EReaderSignal
        Public socketClient As EClientSocket
        '! [socket_declare]
        Public nextOrderId As Integer

        '! [socket_init]
        Sub New()
            eReaderSignal = New EReaderMonitorSignal
            socketClient = New EClientSocket(Me, eReaderSignal)
        End Sub
        '! [socket_init]

        Function serverVersion() As Integer
            serverVersion = socketClient.ServerVersion
        End Function

        '! [accountdownloadend]
        Public Sub accountDownloadEnd(account As String) Implements IBApi.EWrapper.accountDownloadEnd
            Console.WriteLine("accountDownloadEnd - Account[" & account & "]")
        End Sub
        '! [accountdownloadend]

        '! [accountsummary]
        Public Sub accountSummary(reqId As Integer, account As String, tag As String, value As String, currency As String) Implements IBApi.EWrapper.accountSummary
            Console.WriteLine("AccountSummary - ReqId [" & reqId & "] Account [" & account & "] Tag [" & tag & "] Value [" & value &
                          "] Currency [" & currency & "]")
        End Sub
        '! [accountsummary]

        '! [accountsummaryend]
        Public Sub accountSummaryEnd(reqId As Integer) Implements IBApi.EWrapper.accountSummaryEnd
            Console.WriteLine("AccountSummaryEnd - ReqId [" & reqId & "]")
        End Sub
        '! [accountsummaryend]

        '! [accountupdatemulti]
        Public Sub accountUpdateMulti(requestId As Integer, account As String, modelCode As String, key As String, value As String, currency As String) Implements IBApi.EWrapper.accountUpdateMulti
            Console.WriteLine("accountUpdateMulti. Id: " & requestId & ", Account: " & account & ", modelCode: " & modelCode & ", key: " & key & ", value: " & value & ", currency: " & currency)
        End Sub
        '! [accountupdatemulti]

        '! [accountupdatemultiend]
        Public Sub accountUpdateMultiEnd(requestId As Integer) Implements IBApi.EWrapper.accountUpdateMultiEnd
            Console.WriteLine("accountUpdateMultiEnd. id: " & requestId)
        End Sub
        '! [accountupdatemultiend]

        '! [bondcontractdetails]
        Public Sub bondContractDetails(reqId As Integer, contract As IBApi.ContractDetails) Implements IBApi.EWrapper.bondContractDetails
            Console.WriteLine("BondContractDetails - ReqId [" & reqId & "] Contract [" & contract.Summary.Symbol & ", " & contract.Summary.Currency & "]")
        End Sub
        '! [bondcontractdetails]

        '! [commissionreport]
        Public Sub commissionReport(commissionReport As IBApi.CommissionReport) Implements IBApi.EWrapper.commissionReport
            Console.WriteLine("CommissionReport - CommissionReport [" & commissionReport.Commission & " " & commissionReport.Currency & "]")
        End Sub
        '! [commissionreport]

        '! [connectack]
        Public Sub connectAck() Implements IBApi.EWrapper.connectAck
            Console.WriteLine("ConnectAck")
            If socketClient.AsyncEConnect Then
                socketClient.startApi()
            End If
        End Sub
        '! [connectack]
        Public Sub connectionClosed() Implements IBApi.EWrapper.connectionClosed
            Console.WriteLine("ConnectionClosed")
        End Sub

        '! [contractdetails]
        Public Sub contractDetails(reqId As Integer, contractDetails As IBApi.ContractDetails) Implements IBApi.EWrapper.contractDetails
            Console.WriteLine("ContractDetails - ReqId [" & reqId & "] ContractDetails [" & contractDetails.Summary.Symbol & "]")
        End Sub
        '! [contractdetails]

        '! [contractdetailsend]
        Public Sub contractDetailsEnd(reqId As Integer) Implements IBApi.EWrapper.contractDetailsEnd
            Console.WriteLine("ContractDetailsEnd - ReqId [" & reqId & "]")
        End Sub
        '! [contractdetailsend]

        '! [currenttime]
        Public Sub currentTime(time As Long) Implements IBApi.EWrapper.currentTime
            Console.WriteLine("CurrentTime - Time [" & time & "]")
        End Sub
        '! [currenttime]

        Public Sub deltaNeutralValidation(reqId As Integer, underComp As IBApi.UnderComp) Implements IBApi.EWrapper.deltaNeutralValidation
            Console.WriteLine("DeltaNeutralValidation - ReqId [" & reqId & "] UnderComp [ConId:" & underComp.ConId & ", Price:" &
                          underComp.Price & ", Delta:" & underComp.Delta & "]")
        End Sub

        '! [displaygrouplist]
        Public Sub displayGroupList(reqId As Integer, groups As String) Implements IBApi.EWrapper.displayGroupList
            Console.WriteLine("DisplayGroupList - ReqId [" & reqId & "] Groups [" & groups & "]")
        End Sub
        '! [displaygrouplist]

        '! [displaygroupupdated]
        Public Sub displayGroupUpdated(reqId As Integer, contractInfo As String) Implements IBApi.EWrapper.displayGroupUpdated
            Console.WriteLine("DisplayGroupUpdated - ReqId [" & reqId & "] ContractInfo [" & contractInfo & "]")
        End Sub
        '! [displaygroupupdated]


        Public Sub [error](id As Integer, errorCode As Integer, errorMsg As String) Implements IBApi.EWrapper.error
            Console.WriteLine("Error - Id [" & id & "] ErrorCode [" & errorCode & "] ErrorMsg [" & errorMsg & "]")
        End Sub


        Public Sub [error](str As String) Implements IBApi.EWrapper.error
            Console.WriteLine("Error - Str [" & str & "]")
        End Sub

        Public Sub [error](e As System.Exception) Implements IBApi.EWrapper.error
            Console.WriteLine("Error - Exception [" & e.Message & "]")
        End Sub

        '! [execdetails]
        Public Sub execDetails(reqId As Integer, contract As IBApi.Contract, execution As IBApi.Execution) Implements IBApi.EWrapper.execDetails
            Console.WriteLine("ExecDetails - ReqId [" & reqId & "] Contract [" & contract.Symbol & ", " & contract.SecType &
                          "] Execution [Price: " & execution.Price & ", Exchange: " & execution.Exchange & "]")
        End Sub
        '! [execdetails]
        '! [execdetailsend]
        Public Sub execDetailsEnd(reqId As Integer) Implements IBApi.EWrapper.execDetailsEnd
            Console.WriteLine("ExecDetailsEnd - ReqId [" & reqId & "]")
        End Sub
        '! [execdetailsend]
        '! [fundamentaldata]
        Public Sub fundamentalData(reqId As Integer, data As String) Implements IBApi.EWrapper.fundamentalData
            Console.WriteLine("FundamentalData - ReqId [" & reqId & "] Data [" & data & "]")
        End Sub
        '! [fundamentaldata]

        '! [historicaldata]
        Public Sub historicalData(reqId As Integer, [date] As String, open As Double, high As Double, low As Double, close As Double, volume As Integer, count As Integer, WAP As Double, hasGaps As Boolean) Implements IBApi.EWrapper.historicalData
            Console.WriteLine("HistoricalData - ReqId [" & reqId & "] Date [" & [date] & "] Open [" & open & "] High [" &
                          high & "] Low [" & low & "] Volume [" & volume & "] Count [" & count & "]")
        End Sub
        '! [historicaldata]

        '! [historicaldataend]
        Public Sub historicalDataEnd(reqId As Integer, start As String, [end] As String) Implements IBApi.EWrapper.historicalDataEnd
            Console.WriteLine("HistoricalDataEnd - ReqId [" & reqId & "] Start [" & start & "] End [" & [end] & "]")
        End Sub
        '! [historicaldataend]

        '! [managedaccounts]
        Public Sub managedAccounts(accountsList As String) Implements IBApi.EWrapper.managedAccounts
            Console.WriteLine("ManagedAccounts - AccountsList [" & accountsList & "]")
        End Sub
        '! [managedaccounts]

        '! [marketdatatype]
        Public Sub marketDataType(reqId As Integer, marketDataType As Integer) Implements IBApi.EWrapper.marketDataType
            Console.WriteLine("MarketDataType - ReqId [" & reqId & "] MarketDataType [" & marketDataType & "]")
        End Sub
        '! [marketdatatype]

        '! [nextvalidid]
        Public Sub nextValidId(orderId As Integer) Implements IBApi.EWrapper.nextValidId
            Console.WriteLine("NextValidId - OrderId [" & orderId & "]")
            nextOrderId = orderId
        End Sub
        '! [nextvalidid]

        '! [openorder]
        Public Sub openOrder(orderId As Integer, contract As IBApi.Contract, order As IBApi.Order, orderState As IBApi.OrderState) Implements IBApi.EWrapper.openOrder
            Console.WriteLine("OpenOrder. ID: " & orderId & ", " & contract.Symbol & ", " & contract.SecType & " @ " & contract.Exchange &
                          ": " & order.Action & ", " & order.OrderType & " " & order.TotalQuantity & ", " & orderState.Status)
        End Sub
        '! [openorder]

        '! [openorderend]
        Public Sub openOrderEnd() Implements IBApi.EWrapper.openOrderEnd
            Console.WriteLine("OpenOrderEnd")
        End Sub
        '! [openorderend]

        '! [orderstatus]
        Public Sub orderStatus(orderId As Integer, status As String, filled As Double, remaining As Double, avgFillPrice As Double, permId As Integer, parentId As Integer, lastFillPrice As Double, clientId As Integer, whyHeld As String) Implements IBApi.EWrapper.orderStatus
            Console.WriteLine("OrderStatus. Id: " & orderId & ", Status: " & status & ", Filled" & filled & ", Remaining: " & remaining &
                ", AvgFillPrice: " & avgFillPrice & ", PermId: " & permId & ", ParentId: " & parentId & ", LastFillPrice: " & lastFillPrice &
                ", ClientId: " & clientId & ", WhyHeld: " & whyHeld)
        End Sub
        '! [orderstatus]

        '! [position]
        Public Sub position(account As String, contract As IBApi.Contract, pos As Double, avgCost As Double) Implements IBApi.EWrapper.position
            Console.WriteLine("Position. " & account & " - Symbol: " & contract.Symbol & ", SecType: " & contract.SecType & ", Currency: " &
                          contract.Currency & ", Position: " & pos & ", Avg cost: " & avgCost)
        End Sub
        '! [position]

        '! [positionend]
        Public Sub positionEnd() Implements IBApi.EWrapper.positionEnd
            Console.WriteLine("PositionEnd \n")
        End Sub
        '! [positionend]

        '! [positionmulti]
        Public Sub positionMulti(requestId As Integer, account As String, modelCode As String, contract As Contract, pos As Double, avgCost As Double) Implements IBApi.EWrapper.positionMulti
            Console.WriteLine("positionMulti. Id: " & requestId & ", Account: " & account & ", ModelCode: " & modelCode & ", Contract: " & contract.Symbol & ", pos: " & pos & ", avgCost: " & avgCost)
        End Sub
        '! [positionmulti]

        '! [positionmultiend]
        Public Sub positionMultiEnd(requestId As Integer) Implements IBApi.EWrapper.positionMultiEnd
            Console.WriteLine("positionMultiEnd \n")
        End Sub
        '! [positionmultiend]

        '! [realtimebar]
        Public Sub realtimeBar(reqId As Integer, time As Long, open As Double, high As Double, low As Double, close As Double, volume As Long, WAP As Double, count As Integer) Implements IBApi.EWrapper.realtimeBar
            Console.WriteLine("RealTimeBars. " & reqId & " - Time: " & time & ", Open: " & open & ", High: " & high & ", Low: " & low & ", Close: " &
        close & ", Volume: " & volume & ", Count: " & count & ", WAP: " & WAP)
        End Sub
        '! [realtimebar]

        '! [receivefa]
        Public Sub receiveFA(faDataType As Integer, faXmlData As String) Implements IBApi.EWrapper.receiveFA
            Console.WriteLine("Receing FA: " & faDataType & " - " & faXmlData)
        End Sub
        '! [receivefa]

        '! [scannerdata]
        Public Sub scannerData(reqId As Integer, rank As Integer, contractDetails As IBApi.ContractDetails, distance As String, benchmark As String, projection As String, legsStr As String) Implements IBApi.EWrapper.scannerData
            Console.WriteLine("ScannerData. " & reqId & " - Rank: " & rank & ", Symbol: " & contractDetails.Summary.Symbol & ", SecType: " &
                          contractDetails.Summary.SecType & ", Currency: " & contractDetails.Summary.Currency & ", Distance: " & distance &
                          ", Benchmark: " & benchmark & ", Projection: " & projection & ", Legs String: " & legsStr)
        End Sub
        '! [scannerdata]

        '! [scannerdataend]
        Public Sub scannerDataEnd(reqId As Integer) Implements IBApi.EWrapper.scannerDataEnd
            Console.WriteLine("ScannerDataEnd. " & reqId & "\n")
        End Sub
        '! [scannerdataend]

        '! [scannerParameters]
        Public Sub scannerParameters(xml As String) Implements IBApi.EWrapper.scannerParameters
            Console.WriteLine("ScannerParameters. " & xml & "\n")
        End Sub
        '! [scannerParameters]

        '! [tickEFP]
        Public Sub tickEFP(tickerId As Integer, tickType As Integer, basisPoints As Double, formattedBasisPoints As String, impliedFuture As Double, holdDays As Integer, futureLastTradeDate As String, dividendImpact As Double, dividendsToLastTradeDate As Double) Implements IBApi.EWrapper.tickEFP
            Console.WriteLine("TickEFP. " & tickerId & ", Type: " & tickType & ", BasisPoints: " & basisPoints & ", FormattedBasisPoints: " &
                          formattedBasisPoints & ", ImpliedFuture: " & impliedFuture & ", HoldDays: " & holdDays & ", FutureLastTradeDate: " &
                          futureLastTradeDate & ", DividendImpact: " & dividendImpact & ", DividendsToLastTradeDate: " & dividendsToLastTradeDate)
        End Sub
        '! [tickefp]

        '! [tickgeneric]
        Public Sub tickGeneric(tickerId As Integer, field As Integer, value As Double) Implements IBApi.EWrapper.tickGeneric
            Console.WriteLine("Tick Generic. Ticker Id:" & tickerId & ", Field: " & field & ", Value: " & value)
        End Sub
        '! [tickgeneric]

        '! [tickoptioncomputation]
        Public Sub tickOptionComputation(tickerId As Integer, field As Integer, impliedVolatility As Double, delta As Double, optPrice As Double, pvDividend As Double, gamma As Double, vega As Double, theta As Double, undPrice As Double) Implements IBApi.EWrapper.tickOptionComputation
            Console.WriteLine("TickOptionComputation. TickerId: " & tickerId & ", field: " & field & ", ImpliedVolatility: " & impliedVolatility &
                        ", Delta: " & delta & ", OptionPrice: " & optPrice & ", pvDividend: " & pvDividend & ", Gamma: " & gamma &
                      ", Vega: " & vega & ", Theta: " & theta & ", UnderlyingPrice: " & undPrice)
        End Sub
        '! [tickoptioncomputation]

        '! [tickprice]
        Public Sub tickPrice(tickerId As Integer, field As Integer, price As Double, canAutoExecute As Integer) Implements IBApi.EWrapper.tickPrice
            Console.WriteLine("TickPrice - TickerId [" & CStr(tickerId) & "] Field [" & TickType.getField(field) & "] Price [" & CStr(price) & "]")
        End Sub
        '! [tickprice]

        '! [ticksize]
        Public Sub tickSize(tickerId As Integer, field As Integer, size As Integer) Implements IBApi.EWrapper.tickSize
            Console.WriteLine("Tick Size. Ticker Id:" & CStr(tickerId) & ", Field: " & TickType.getField(field) & ", Size: " & CStr(size))
        End Sub
        '! [ticksize]

        '! [ticksnapshotend]
        Public Sub tickSnapshotEnd(tickerId As Integer) Implements IBApi.EWrapper.tickSnapshotEnd
            Console.WriteLine("TickSnapshotEnd: " & CStr(tickerId))
        End Sub
        '! [ticksnapshotend]

        '! [tickstring]
        Public Sub tickString(tickerId As Integer, field As Integer, value As String) Implements IBApi.EWrapper.tickString
            Console.WriteLine("Tick string. Ticker Id:" & CStr(tickerId) & ", Type: " & TickType.getField(field) & ", Value: " & value)
        End Sub
        '! [tickstring]

        '! [updateaccounttime]
        Public Sub updateAccountTime(timestamp As String) Implements IBApi.EWrapper.updateAccountTime
            Console.WriteLine("UpdateAccountTime. Time: " & timestamp)
        End Sub
        '! [updateaccounttime]

        '! [updateaccountvalue]
        Public Sub updateAccountValue(key As String, value As String, currency As String, accountName As String) Implements IBApi.EWrapper.updateAccountValue
            Console.WriteLine("UpdateAccountValue. Key: " & key & ", Value: " & value & ", Currency: " & currency & ", AccountName: " & accountName)
        End Sub
        '! [updateaccountvalue]

        '! [updatemktdepth]
        Public Sub updateMktDepth(tickerId As Integer, position As Integer, operation As Integer, side As Integer, price As Double, size As Integer) Implements IBApi.EWrapper.updateMktDepth
            Console.WriteLine("UpdateMarketDepth. " & CStr(tickerId) & " - Position: " & CStr(position) & ", Operation: " & CStr(operation) & ", Side: " & CStr(side) &
                          ", Price: " & CStr(price) & ", Size" & CStr(size))
        End Sub
        '! [updatemktdepth]

        '! [updatemktdepthl2]
        Public Sub updateMktDepthL2(tickerId As Integer, position As Integer, marketMaker As String, operation As Integer, side As Integer, price As Double, size As Integer) Implements IBApi.EWrapper.updateMktDepthL2
            Console.WriteLine("UpdateMarketDepthL2. " & tickerId & " - Position: " & position & ", Operation: " & operation & ", Side: " & side &
                          ", Price: " & price & ", Size" & size)
        End Sub
        '! [updatemktdepthl2]

        '! [updatenewsbulletin]
        Public Sub updateNewsBulletin(msgId As Integer, msgType As Integer, message As String, origExchange As String) Implements IBApi.EWrapper.updateNewsBulletin
            Console.WriteLine("News Bulletins. " & msgId & " - Type: " & msgType & ", Message: " & message & ", Exchange of Origin: " & origExchange)
        End Sub
        '! [updatenewsbulletin]

        '! [updateportfolio]
        Public Sub updatePortfolio(contract As IBApi.Contract, position As Double, marketPrice As Double, marketValue As Double, averageCost As Double, unrealisedPNL As Double, realisedPNL As Double, accountName As String) Implements IBApi.EWrapper.updatePortfolio
            Console.WriteLine("UpdatePortfolio. " & contract.Symbol & ", " & contract.SecType & " @ " & contract.Exchange &
                ": Position: " & position & ", MarketPrice: " & marketPrice & ", MarketValue: " & marketValue & ", AverageCost: " & averageCost &
                ", UnrealisedPNL: " & unrealisedPNL & ", RealisedPNL: " & realisedPNL & ", AccountName: " & accountName)
        End Sub
        '! [updateportfolio]

        Public Sub verifyAndAuthCompleted(isSuccessful As Boolean, errorText As String) Implements IBApi.EWrapper.verifyAndAuthCompleted
            Console.WriteLine("verifyAndAuthCompleted. IsSuccessful: " & isSuccessful & " - Error: " & errorText)
        End Sub

        Public Sub verifyAndAuthMessageAPI(apiData As String, xyzChallenge As String) Implements IBApi.EWrapper.verifyAndAuthMessageAPI
            Console.WriteLine("verifyAndAuthMessageAPI: " & apiData & " " & xyzChallenge)
        End Sub

        Public Sub verifyCompleted(isSuccessful As Boolean, errorText As String) Implements IBApi.EWrapper.verifyCompleted
            Console.WriteLine("verifyCompleted. IsSuccessfule: " & isSuccessful & " - Error: " & errorText)
        End Sub

        Public Sub verifyMessageAPI(apiData As String) Implements IBApi.EWrapper.verifyMessageAPI
            Console.WriteLine("verifyMessageAPI: " & apiData)
        End Sub

        '! [securityDefinitionOptionParameter]
        Public Sub securityDefinitionOptionParameter(reqId As Integer, exchange As String, underlyingConId As Integer, tradingClass As String, multiplier As String, expirations As HashSet(Of String), strikes As HashSet(Of Double)) Implements EWrapper.securityDefinitionOptionParameter
            Console.WriteLine("securityDefinitionOptionParameter: " & reqId & " tradingClass: " & tradingClass & " multiplier: ")
        End Sub
        '! [securityDefinitionOptionParameter]

        '! [securityDefinitionOptionParameterEnd]
        Public Sub securityDefinitionOptionParameterEnd(reqId As Integer) Implements EWrapper.securityDefinitionOptionParameterEnd
            Console.WriteLine("Called securityDefinitionParameterEnd")
        End Sub
        '! [securityDefinitionOptionParameterEnd]

        Public Sub softDollarTiers(reqid As Integer, tiers As SoftDollarTier()) Implements EWrapper.softDollarTiers
            Console.WriteLine("Soft Dollar Tiers:")

            For Each tier In tiers
                Console.WriteLine(tier.DisplayName)
            Next
        End Sub

    End Class

End Namespace