Imports IBApi
Imports System.Text

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

        Private _bboExchange As String

        Public Property BboExchange As String
            Get
                Return _bboExchange
            End Get
            Private Set(value As String)
                _bboExchange = value
            End Set
        End Property

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
            Console.WriteLine("BondContractDetails begin. ReqId: " & reqId)
            printBondContractDetailsMsg(contract)
            Console.WriteLine("BondContractDetails end. ReqId: " & reqId)
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
            Console.WriteLine("ContractDetails begin. ReqId: " & reqId)
            printContractMsg(contractDetails.Summary)
            printContractDetailsMsg(contractDetails)
            Console.WriteLine("ContractDetails end. ReqId: " & reqId)
        End Sub
        '! [contractdetails]

        Public Sub printContractMsg(contract As IBApi.Contract)
            Console.WriteLine(vbTab & "ConId: " & contract.ConId)
            Console.WriteLine(vbTab & "Symbol: " & contract.Symbol)
            Console.WriteLine(vbTab & "SecType: " & contract.SecType)
            Console.WriteLine(vbTab & "LastTradeDateOrContractMonth: " & contract.LastTradeDateOrContractMonth)
            Console.WriteLine(vbTab & "Strike: " & contract.Strike)
            Console.WriteLine(vbTab & "Right: " & contract.Right)
            Console.WriteLine(vbTab & "Multiplier: " & contract.Multiplier)
            Console.WriteLine(vbTab & "Exchange: " & contract.Exchange)
            Console.WriteLine(vbTab & "PrimaryExchange: " & contract.PrimaryExch)
            Console.WriteLine(vbTab & "Currency: " & contract.Currency)
            Console.WriteLine(vbTab & "LocalSymbol: " & contract.LocalSymbol)
            Console.WriteLine(vbTab & "TradingClass: " & contract.TradingClass)
        End Sub

        Public Sub printContractDetailsMsg(contractDetails As IBApi.ContractDetails)
            Console.WriteLine(vbTab & "MarketName: " & contractDetails.MarketName)
            Console.WriteLine(vbTab & "MinTick: " & contractDetails.MinTick)
            Console.WriteLine(vbTab & "PriceMagnifier: " & contractDetails.PriceMagnifier)
            Console.WriteLine(vbTab & "OrderTypes: " & contractDetails.OrderTypes)
            Console.WriteLine(vbTab & "ValidExchanges: " & contractDetails.ValidExchanges)
            Console.WriteLine(vbTab & "UnderConId: " & contractDetails.UnderConId)
            Console.WriteLine(vbTab & "LongName: " & contractDetails.LongName)
            Console.WriteLine(vbTab & "ContractMonth: " & contractDetails.ContractMonth)
            Console.WriteLine(vbTab & "Indystry: " & contractDetails.Industry)
            Console.WriteLine(vbTab & "Category: " & contractDetails.Category)
            Console.WriteLine(vbTab & "SubCategory: " & contractDetails.Subcategory)
            Console.WriteLine(vbTab & "TimeZoneId: " & contractDetails.TimeZoneId)
            Console.WriteLine(vbTab & "TradingHours: " & contractDetails.TradingHours)
            Console.WriteLine(vbTab & "LiquidHours: " & contractDetails.LiquidHours)
            Console.WriteLine(vbTab & "EvRule: " & contractDetails.EvRule)
            Console.WriteLine(vbTab & "EvMultiplier: " & contractDetails.EvMultiplier)
            Console.WriteLine(vbTab & "MdSizeMultiplier: " & contractDetails.MdSizeMultiplier)
            Console.WriteLine(vbTab & "AggGroup: " & contractDetails.AggGroup)
            Console.WriteLine(vbTab & "UnderSymbol: " & contractDetails.UnderSymbol)
            Console.WriteLine(vbTab & "UnderSecType: " & contractDetails.UnderSecType)
            Console.WriteLine(vbTab & "MarketRuleIds: " & contractDetails.MarketRuleIds)
            Console.WriteLine(vbTab & "RealExpirationDate: " & contractDetails.RealExpirationDate)
            printContractDetailsSecIdList(contractDetails.SecIdList)
        End Sub

        Public Sub printContractDetailsSecIdList(secIdList As List(Of IBApi.TagValue))
            If Not secIdList Is Nothing Then
                Console.Write(vbTab & "SecIdList: {")
                For Each tagValue In secIdList
                    Console.Write(tagValue.Tag & "=" & tagValue.Value & ";")
                Next
                Console.WriteLine("}")
            End If
        End Sub

        Public Sub printBondContractDetailsMsg(contractDetails As IBApi.ContractDetails)
            Console.WriteLine(vbTab & "Symbol: " & contractDetails.Summary.Symbol)
            Console.WriteLine(vbTab & "SecType: " & contractDetails.Summary.SecType)
            Console.WriteLine(vbTab & "Cusip: " & contractDetails.Cusip)
            Console.WriteLine(vbTab & "Coupon: " & contractDetails.Coupon)
            Console.WriteLine(vbTab & "Maturity: " & contractDetails.Maturity)
            Console.WriteLine(vbTab & "IssueDate: " & contractDetails.IssueDate)
            Console.WriteLine(vbTab & "Ratings: " & contractDetails.Ratings)
            Console.WriteLine(vbTab & "BondType: " & contractDetails.BondType)
            Console.WriteLine(vbTab & "CouponType: " & contractDetails.CouponType)
            Console.WriteLine(vbTab & "Convertible: " & contractDetails.Convertible)
            Console.WriteLine(vbTab & "Callable: " & contractDetails.Callable)
            Console.WriteLine(vbTab & "Putable: " & contractDetails.Putable)
            Console.WriteLine(vbTab & "DescAppend: " & contractDetails.DescAppend)
            Console.WriteLine(vbTab & "Exchange: " & contractDetails.Summary.Exchange)
            Console.WriteLine(vbTab & "Currency: " & contractDetails.Summary.Currency)
            Console.WriteLine(vbTab & "MarketName: " & contractDetails.MarketName)
            Console.WriteLine(vbTab & "TradingClass: " & contractDetails.Summary.TradingClass)
            Console.WriteLine(vbTab & "ConId: " & contractDetails.Summary.ConId)
            Console.WriteLine(vbTab & "MinTick: " & contractDetails.MinTick)
            Console.WriteLine(vbTab & "MdSizeMultiplier: " & contractDetails.MdSizeMultiplier)
            Console.WriteLine(vbTab & "OrderTypes: " & contractDetails.OrderTypes)
            Console.WriteLine(vbTab & "ValidExchanges: " & contractDetails.ValidExchanges)
            Console.WriteLine(vbTab & "NextOptionDate: " & contractDetails.NextOptionDate)
            Console.WriteLine(vbTab & "NextOptionType: " & contractDetails.NextOptionType)
            Console.WriteLine(vbTab & "NextOptionPartial: " & contractDetails.NextOptionPartial)
            Console.WriteLine(vbTab & "Notes: " & contractDetails.Notes)
            Console.WriteLine(vbTab & "Long Name: " & contractDetails.LongName)
            Console.WriteLine(vbTab & "EvRule: " & contractDetails.EvRule)
            Console.WriteLine(vbTab & "EvMultiplier: " & contractDetails.EvMultiplier)
            Console.WriteLine(vbTab & "AggGroup: " & contractDetails.AggGroup)
            Console.WriteLine(vbTab & "MarketRuleIds: " & contractDetails.MarketRuleIds)
            printContractDetailsSecIdList(contractDetails.SecIdList)
        End Sub


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

        '! [errors]
        Public Sub [error](id As Integer, errorCode As Integer, errorMsg As String) Implements IBApi.EWrapper.error
            Console.WriteLine("Error - Id [" & id & "] ErrorCode [" & errorCode & "] ErrorMsg [" & errorMsg & "]")
        End Sub
        '! [errors]

        Public Sub [error](str As String) Implements IBApi.EWrapper.error
            Console.WriteLine("Error - Str [" & str & "]")
        End Sub

        Public Sub [error](e As System.Exception) Implements IBApi.EWrapper.error
            Console.WriteLine("Error - Exception [" & e.Message & "]")
        End Sub

        '! [execdetails]
        Public Sub execDetails(reqId As Integer, contract As IBApi.Contract, execution As IBApi.Execution) Implements IBApi.EWrapper.execDetails
            Console.WriteLine("ExecDetails - ReqId [" & reqId & "] Contract [" & contract.Symbol & ", " & contract.SecType &
                          "] Execution [Price: " & execution.Price & ", Exchange: " & execution.Exchange & ", Last Liquidity: " & execution.LastLiquidity.ToString() & "]")
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
        Public Sub historicalData(reqId As Integer, bar As Bar) Implements IBApi.EWrapper.historicalData, IBApi.EWrapper.historicalDataUpdate
            Console.WriteLine("HistoricalData - ReqId [" & reqId & "] Date [" & bar.Time & "] Open [" & bar.Open & "] High [" &
                          bar.High & "] Low [" & bar.Low & "] Volume [" & bar.Volume & "] Count [" & bar.Count & "]")
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
        Public Sub orderStatus(orderId As Integer, status As String, filled As Double, remaining As Double, avgFillPrice As Double, permId As Integer, parentId As Integer, lastFillPrice As Double, clientId As Integer, whyHeld As String, mktCapPrice As Double) Implements IBApi.EWrapper.orderStatus
            Console.WriteLine("OrderStatus. Id: " & orderId & ", Status: " & status & ", Filled" & filled & ", Remaining: " & remaining &
                ", AvgFillPrice: " & avgFillPrice & ", PermId: " & permId & ", ParentId: " & parentId & ", LastFillPrice: " & lastFillPrice &
                ", ClientId: " & clientId & ", WhyHeld: " & whyHeld & ", mktCapPrice: " & mktCapPrice)
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

        '! [scannerparameters]
        Public Sub scannerParameters(xml As String) Implements IBApi.EWrapper.scannerParameters
            Console.WriteLine("ScannerParameters. " & xml & "\n")
        End Sub
        '! [scannerparameters]

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
        Public Sub tickPrice(tickerId As Integer, field As Integer, price As Double, attribs As TickAttrib) Implements IBApi.EWrapper.tickPrice
            Console.WriteLine("TickPrice - TickerId [" & CStr(tickerId) & "] Field [" & TickType.getField(field) & "] Price [" & CStr(price) & "] PreOpen [" & attribs.PreOpen & "]")
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
        Public Sub updatePortfolio(contract As IBApi.Contract, position As Double, marketPrice As Double, marketValue As Double, averageCost As Double, unrealizedPNL As Double, realizedPNL As Double, accountName As String) Implements IBApi.EWrapper.updatePortfolio
            Console.WriteLine("UpdatePortfolio. " & contract.Symbol & ", " & contract.SecType & " @ " & contract.Exchange &
                ": Position: " & position & ", MarketPrice: " & marketPrice & ", MarketValue: " & marketValue & ", AverageCost: " & averageCost &
                ", UnrealizedPNL: " & unrealizedPNL & ", RealizedPNL: " & realizedPNL & ", AccountName: " & accountName)
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

        '! [softDollarTiers]
        Public Sub softDollarTiers(reqid As Integer, tiers As SoftDollarTier()) Implements EWrapper.softDollarTiers
            Console.WriteLine("Soft Dollar Tiers:")

            For Each tier In tiers
                Console.WriteLine(tier.DisplayName)
            Next
        End Sub
        '! [softDollarTiers]

        '! [familyCodes]
        Public Sub familyCodes(familyCodes As FamilyCode()) Implements EWrapper.familyCodes
            Console.WriteLine("Family Codes:")

            For Each familyCode In familyCodes
                Console.WriteLine("Account ID: " & familyCode.AccountID & " Family Code Str: " & familyCode.FamilyCodeStr)
            Next
        End Sub
        '! [familyCodes]

        '! [symbolSamples]
        Public Sub symbolSamples(reqId As Integer, contractDescriptions As ContractDescription()) Implements EWrapper.symbolSamples
            Dim derivSecTypes As String

            Console.WriteLine("Symbol Samples. Request Id: " & reqId)

            For Each contractDescription In contractDescriptions
                derivSecTypes = ""
                For Each derivSecType In contractDescription.DerivativeSecTypes
                    derivSecTypes += derivSecType
                    derivSecTypes += " "
                Next
                Console.WriteLine("Contract: conId - " & contractDescription.Contract.ConId & ", symbol - " & contractDescription.Contract.Symbol &
                                  ", secType -" & contractDescription.Contract.SecType & ", primExchange - " & contractDescription.Contract.PrimaryExch &
                                  ", currency - " & contractDescription.Contract.Currency & ", derivativeSecTypes - " & derivSecTypes)
            Next
        End Sub
        '! [symbolSamples]

        '! [mktDepthExchanges]
        Public Sub mktDepthExchanges(depthMktDataDescriptions As DepthMktDataDescription()) Implements EWrapper.mktDepthExchanges
            Console.WriteLine("Market Depth Exchanges:")

            Dim aggGroup As String

            For Each depthMktDataDescription In depthMktDataDescriptions
                If depthMktDataDescription.AggGroup <> Integer.MaxValue Then
                    aggGroup = depthMktDataDescription.AggGroup
                Else
                    aggGroup = ""
                End If

                Console.WriteLine("Depth Market Data Descriprion. Exchange: " & depthMktDataDescription.Exchange &
                                  " Security Type: " & depthMktDataDescription.SecType &
                                  " Listing Exch: " & depthMktDataDescription.ListingExch &
                                  " Service Data Type: " & depthMktDataDescription.ServiceDataType &
                                  "  Agg Group: " & aggGroup)
            Next
        End Sub
        '! [mktDepthExchanges]

        '! [tickNews]
        Public Sub tickNews(tickerId As Integer, timeStamp As Long, providerCode As String, articleId As String, headline As String, extraData As String) Implements IBApi.EWrapper.tickNews
            Console.WriteLine("Tick News. Ticker Id: " & tickerId & ", Time Stamp: " & timeStamp & ", Provider Code: " & providerCode & ", Article Id: " & articleId & ", Headline: " & headline & ", Extra Data: " & extraData)
        End Sub
        '! [tickNews]

        '! [smartcomponents]
        Public Sub smartComponents(reqId As Integer, theMap As Dictionary(Of Integer, KeyValuePair(Of String, Char))) Implements EWrapper.smartComponents
            Dim sb As New StringBuilder

            sb.AppendFormat("==== Smart Components Begin (total={0}) reqId = {1} ===={2}", theMap.Count, reqId, Environment.NewLine)

            For Each item In theMap
                sb.AppendFormat("bit number: {0}, exchange: {1}, exchange letter: {2}{3}", item.Key, item.Value.Key, item.Value.Value, Environment.NewLine)
            Next

            sb.AppendFormat("==== Smart Components Begin (total={0}) reqId = {1} ===={2}", theMap.Count, reqId, Environment.NewLine)

            Console.WriteLine(sb)
        End Sub
        '! [smartcomponents]

        '! [tickReqParams]
        Public Sub tickReqParams(tickerId As Integer, minTick As Double, bboExchange As String, snapshotPermissions As Integer) Implements EWrapper.tickReqParams
            Console.WriteLine("id={0} minTick = {1} bboExchange = {2} snapshotPermissions = {3}", tickerId, minTick, bboExchange, snapshotPermissions)

            Me.BboExchange = bboExchange
        End Sub
        '! [tickReqParams]

        '! [newsProviders]
        Public Sub newsProviders(newsProviders As NewsProvider()) Implements EWrapper.newsProviders
            Console.WriteLine("News Providers")

            For Each newsProvider In newsProviders
                Console.WriteLine("News Provider: providerCode - " & newsProvider.ProviderCode & ", providerName - " & newsProvider.ProviderName)
            Next
        End Sub
        '! [newsProviders]

        '! [newsArticle]
        Public Sub newsArticle(requestId As Integer, articleType As Integer, articleText As String) Implements EWrapper.newsArticle
            Console.WriteLine("News Article. Request Id: " & requestId & ", Article Type: " & articleType)

            If articleType = 0 Then
                Console.WriteLine("News Article Text: " & articleText)
            ElseIf articleType = 1 Then
                Console.WriteLine("News Article Text: article text is binary/pdf and cannot be displayed")
            End If
        End Sub
        '! [newsArticle]

        '! [historicalNews]
        Public Sub historicalNews(requestId As Integer, time As String, providerCode As String, articleId As String, headline As String) Implements IBApi.EWrapper.historicalNews
            Console.WriteLine("Historical News. Request Id: " & requestId & ", Time: " & time & ", Provider Code: " & providerCode & ", Article Id: " & articleId & ", Headline: " & headline)
        End Sub
        '! [historicalNews]

        '! [historicalNewsEnd]
        Public Sub historicalNewsEnd(requestId As Integer, hasMore As Boolean) Implements IBApi.EWrapper.historicalNewsEnd
            Console.WriteLine("Historical News End. Request Id: " & requestId & ", Has More: " & hasMore)
        End Sub
        '! [historicalNewsEnd]

        '! [headTimestamp]
        Public Sub headTimestamp(requestId As Integer, timeStamp As String) Implements IBApi.EWrapper.headTimestamp
            Console.WriteLine("Head time stamp. Request Id: {0}, Head time stamp: {1}", requestId, timeStamp)
        End Sub
        '! [headTimestamp]

        '! [histogramData]
        Public Sub histogramData(reqId As Integer, data As HistogramEntry()) Implements EWrapper.histogramData
            Console.WriteLine("Histogram data. Request Id: {0}, data size: {1}", reqId, data.Length)
            data.ToList().ForEach(Sub(i) Console.WriteLine(vbTab & "Price: {0}, Size: {1}", i.Price, i.Size))
        End Sub
        '! [histogramData]

        '! [rerouteMktDataReq]
        Public Sub rerouteMktDataReq(reqId As Integer, conId As Integer, exchange As String) Implements IBApi.EWrapper.rerouteMktDataReq
            Console.WriteLine("Re-route market data request. Req Id: {0}, Con Id: {1}, Exchange: {2}", reqId, conId, exchange)
        End Sub
        '! [rerouteMktDataReq]

        '! [rerouteMktDepthReq]
        Public Sub rerouteMktDepthReq(reqId As Integer, conId As Integer, exchange As String) Implements IBApi.EWrapper.rerouteMktDepthReq
            Console.WriteLine("Re-route market depth request. Req Id: {0}, Con Id: {1}, Exchange: {2}", reqId, conId, exchange)
        End Sub
        '! [rerouteMktDepthReq]

        '! [marketRule]
        Public Sub marketRule(marketRuleId As Integer, priceIncrements As PriceIncrement()) Implements EWrapper.marketRule
            Console.WriteLine("Market Rule Id:" & marketRuleId)

            For Each priceIncrement In priceIncrements
                Console.WriteLine("LowEdge: " & CDec(priceIncrement.LowEdge) & " Increment: " & CDec(priceIncrement.Increment))
            Next
        End Sub
        '! [marketRule]

		'! [pnl]
        Public Sub pnl(reqId As Integer, dailyPnL As Double, unrealizedPnL As Double, realizedPnL As Double) Implements EWrapper.pnl
            Console.WriteLine("PnL. Request Id: {0}, daily PnL: {1}, unrealized PnL: {2}, realized PnL: {3}", reqId, dailyPnL, unrealizedPnL, realizedPnL)
        End Sub
		'! [pnl]
		
		'! [pnlsingle]
        Public Sub pnlSingle(reqId As Integer, pos As Integer, dailyPnL As Double, unrealizedPnL As Double, realizedPnL As Double, value As Double) Implements EWrapper.pnlSingle
            Console.WriteLine("PnL Single. Request Id: {0}, pos: {1}, daily PnL: {2}, unrealized PnL: {3}, realized PnL: {4}, value: {5}", reqId, pos, dailyPnL, unrealizedPnL, realizedPnL, value)
        End Sub
		'! [pnlsingle]
		
		'! [historicalticks]
        Public Sub historicalTick(reqId As Integer, ticks As HistoricalTick(), done As Boolean) Implements EWrapper.historicalTicks
            For Each tick In ticks
                Console.WriteLine("Historical Tick. Request Id: {0}, Time: {1}, Price: {2}, Size: {3}", reqId, tick.Time, tick.Price, tick.Size)
            Next
        End Sub
		'! [historicalticks]

		'! [historicalticksbidask]
        Public Sub historicalTickBidAsk(reqId As Integer, ticks As HistoricalTickBidAsk(), done As Boolean) Implements EWrapper.historicalTicksBidAsk
            For Each tick In ticks
                Console.WriteLine("Historical Tick Bid/Ask. Request Id: {0}, Time: {1}, Mask: {2} Price Bid: {3}, Price Ask {4}, Size Bid: {5}, Size Ask {6}",
                    reqId, tick.Time, tick.Mask, tick.PriceBid, tick.PriceAsk, tick.SizeBid, tick.SizeAsk)
            Next
        End Sub
		'! [historicalticksbidask]

		'! [historicaltickslast]
        Public Sub historicalTickLast(reqId As Integer, ticks As HistoricalTickLast(), done As Boolean) Implements EWrapper.historicalTicksLast
            For Each tick In ticks
                Console.WriteLine("Historical Tick Last. Request Id: {0}, Time: {1}, Mask: {2}, Price: {3}, Size: {4}, Exchange: {5}, Special Conditions: {6}",
                    reqId, tick.Time, tick.Mask, tick.Price, tick.Size, tick.Exchange, tick.SpecialConditions)
            Next
        End Sub
        '! [historicaltickslast]

        '! [tickbytickalllast]
        Public Sub tickByTickAllLast(reqId As Integer, tickType As Integer, time As Long, price As Double, size As Integer, attribs As TickAttrib, exchange As String, specialConditions As String) Implements EWrapper.tickByTickAllLast
            Dim tickTypeStr As String
            Dim timeStr As String = New DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(time).ToString("yyyyMMdd-HH:mm:ss zzz")
            If tickType = 1 Then
                tickTypeStr = "Last"
            Else
                tickTypeStr = "AllLast"
            End If
            Console.WriteLine("Tick-By-Tick. Request Id: {0}, TickType: {1}, Time: {2}, Price: {3}, Size: {4}, Exchange: {5}, Special Conditions: {6}, PastLimit: {7}, Unreported: {8}",
                reqId, tickTypeStr, timeStr, price, size, exchange, specialConditions, attribs.PastLimit, attribs.Unreported)
        End Sub
        '! [tickbytickalllast]

        '! [tickbytickbidask]
        Public Sub tickByTickBidAsk(reqId As Integer, time As Long, bidPrice As Double, askPrice As Double, bidSize As Integer, askSize As Integer, attribs As TickAttrib) Implements EWrapper.tickByTickBidAsk
            Dim timeStr As String = New DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(time).ToString("yyyyMMdd-HH:mm:ss zzz")
            Console.WriteLine("Tick-By-Tick. Request Id: {0}, TickType: BidAsk, Time: {1}, BidPrice: {2}, AskPrice: {3}, BidSize: {4}, AskSize: {5}, BidPastLow: {6}, AskPastHigh: {7}",
                reqId, timeStr, bidPrice, askPrice, bidSize, askSize, attribs.BidPastLow, attribs.AskPastHigh)
        End Sub
        '! [tickbytickbidask]

    End Class

End Namespace
