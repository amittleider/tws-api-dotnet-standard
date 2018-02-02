Imports IBApi
Imports System.Threading
Imports Testbed.Samples

' VB .NET users previously using our ActiveX control are actively encouraged to use the C# client library (CSharpAPI) instead just as demonstrated in 
' this sample. You can either add the entire CSharpAPI project or reference its resulting DLL.
' Using the C# client instead of the ActiveX COM interface allows for a more transparent and manageable integration.
Module MainModule

    Dim wrapperImpl As EWrapperImpl = New EWrapperImpl

    Private Function increment(ByRef arg As Integer) As Integer
        arg += 1
        Return (arg - 1)
    End Function

    Sub Main()
        Dim socketClient As EClientSocket = wrapperImpl.socketClient

        ' [connect]
        socketClient.eConnect("127.0.0.1", 7497, 0)
        ' [connect]
        ' [ereader]
        'Once the messages are in the queue, an additional thread need to fetch them
        Dim msgThread As Thread = New Thread(AddressOf messageProcessing)
        msgThread.IsBackground = True
        If (wrapperImpl.serverVersion() > 0) Then Call msgThread.Start()
        ' [ereader]
        '*************************************************************************************************************************************************/
        '* One (although primitive) way of knowing if we can proceed Is by monitoring the order's nextValidId reception which comes down automatically after connecting. */
        '*************************************************************************************************************************************************/

        While wrapperImpl.nextOrderId = 0
            'Wait until we receive an orderId from the TWS. This will tell us the connection has been properly established
        End While

        testIBMethods(socketClient, wrapperImpl.nextOrderId)

        Thread.Sleep(1000)
        Console.WriteLine("Disconnecting")
        socketClient.eDisconnect()
    End Sub

    ''Once the messages are in the queue, an additional thread need to fetch them
    ' [ereader_thread]
    Private Sub messageProcessing()
        Dim reader As EReader = New EReader(wrapperImpl.socketClient, wrapperImpl.eReaderSignal)
        reader.Start()
        While (wrapperImpl.socketClient.IsConnected)
            wrapperImpl.eReaderSignal.waitForSignal()
            reader.processMsgs()
        End While
    End Sub
    ' [ereader_thread]

    '****************************************************************
    ' Below are few quick-to-test examples on the IB API functions grouped by functionality. Uncomment the relevant methods. *
    '****************************************************************
    Private Sub testIBMethods(client As EClientSocket, nextValidId As Integer)

        '**************************************************
        '** Real time market data operations  - Tickers ***
        '**************************************************
        'tickDataOperations(client)

        '***************************************************
        '** Tick option computation operations - Tickers ***
        '***************************************************
        tickOptionComputationOperations(client)

        '*******************************************************
        '** Real time market data operations  - Market Depth ***
        '*******************************************************
        'marketDepthOperations(client)

        '*********************************************************
        '** Real time market data operations  - Real Time Bars ***
        '*********************************************************
        'realTimeBars(client)

        '*************************************************************
        '** Real time market data operations  - Streamed Or Frozen ***
        '*************************************************************
        'marketDataType(client)

        '*********************************
        '** Historical Data operations ***
        '*********************************
        'historicalDataRequests(client)

        '************************
        '** Options Specifics ***
        '************************
        'optionsOperations(client)

        '***************************
        '** Contract information ***
        '***************************
        'contractOperations(client)

        '**********************
        '** Market Scanners ***
        '**********************
        'marketScanners(client)

        '****************************
        '** Reuter's Fundamentals ***
        '****************************
        'reutersFundamentals(client)

        '**********************
        '** IB's Bulletins ***
        '**********************
        'bulletins(client)

        '*************************
        '** Account Management ***
        '*************************
        'accountOperations(client)

        '*********************
        '** Order handling ***
        '*********************
        'orderOperations(client, nextValidId)

        '***********************************
        '** Financial Advisor Exclusive Operations ***
        '***********************************
        ' financialAdvisorOperations(client)

        '*******************
        '** Miscellaneous ***
        '*******************
        'miscellaneous(client)

        '*******************
        '** Linking ***
        '*******************
        'linkingOperations(client)

        '*******************
        '** News operations ***
        '*******************
        'newsOperations(client)
        '***********************
        '*** Smart components ***
        '***********************
        'smartComponents(client)
        '***********************
        '*** Head time stamp ***
        '***********************
        'headTimestamp(client)
        '***********************
        '*** Histogram data  ***
        '***********************
        'histogramData(client)

        '***********************
        '*** CFD re-route    ***
        '***********************
        'rerouteCFDOperations(client)

        '***********************
        '*** MarketRule      ***
        '***********************
        'marketRuleOperations(client)

        'pnl(client)
        'pnlSingle(client)

        '**************************
        '*** Algo Orders ***
        '**************************
        'TestAlgoSamples(client, nextValidId)

        '**************************
        '*** Continuous futures ***
        '**************************
        'continuousFuturesOperations(client)

        'historicalTicks(client)

        '***********************
        '*** Tick-By-Tick    ***
        '***********************
        'tickByTickOperations(client)

        Thread.Sleep(15000)
        Console.WriteLine("Done")
        Thread.Sleep(500000)
    End Sub

    Private Sub historicalTicks(client As EClientSocket)
		' [reqhistoricalticks]
        client.reqHistoricalTicks(18001, ContractSamples.USStockAtSmart(), "20170712 21:39:33", Nothing, 10, "TRADES", 1, True, Nothing)
        client.reqHistoricalTicks(18002, ContractSamples.USStockAtSmart(), "20170712 21:39:33", Nothing, 10, "BID_ASK", 1, True, Nothing)
        client.reqHistoricalTicks(18003, ContractSamples.USStockAtSmart(), "20170712 21:39:33", Nothing, 10, "MIDPOINT", 1, True, Nothing)
		' [reqhistoricalticks]
    End Sub

    Private Sub pnl(client As EClientSocket)
		' [reqpnl]
        client.reqPnL(17001, "DUD00029", "")
		' [reqpnl]
        Thread.Sleep(1000)
		' [cancelpnl]
        client.cancelPnL(17001)
		' [cancelpnl]
    End Sub

    Private Sub pnlSingle(client As EClientSocket)
		' [reqpnlsingle]
        client.reqPnLSingle(17001, "DUD00029", "", 268084)
		' [reqpnlsingle]
        Thread.Sleep(1000)
		' [cancelpnlsingle]
        client.cancelPnLSingle(17001)
		' [cancelpnlsingle]
    End Sub

    Private Sub smartComponents(client As EClientSocket)

        client.reqMktData(13001, ContractSamples.USStockAtSmart(), "", False, False, Nothing)

        While String.IsNullOrWhiteSpace(wrapperImpl.BboExchange)
            Thread.Sleep(1000)
        End While

        client.cancelMktData(13001)
        ' [reqsmartcomponents]
        client.reqSmartComponents(13002, wrapperImpl.BboExchange)
        ' [reqsmartcomponents]
    End Sub

    Private Sub tickDataOperations(client As EClientSocket)

        ' Requesting real time market data 
        ' Thread.Sleep(1000) 
        ' [reqmktdata]
        client.reqMktData(1001, ContractSamples.StockComboContract(), String.Empty, False, False, Nothing)
        client.reqMktData(1002, ContractSamples.FuturesOnOptions(), String.Empty, False, False, Nothing)
        ' [reqmktdata]
        ' [reqmktdata_snapshot]
        client.reqMktData(1003, ContractSamples.FutureComboContract(), String.Empty, True, False, Nothing)
        ' [reqmktdata_snapshot]

        ' [regulatorysnapshot]
        ' Each regulatory snapshot request will incur a fee of 0.01 USD 
        ' client.reqMktData(1004, ContractSamples.USStock(), "", False, True, Nothing)
        ' [regulatorysnapshot]

        '! [reqmktdata_genticks]
        'Requesting RTVolume (Time & Sales), shortable And Fundamental Ratios generic ticks
        client.reqMktData(1004, ContractSamples.USStock(), "233,236,258", False, False, Nothing)
        '! [reqmktdata_genticks]

        '! [reqmktdata_contractnews]
        ' Without the API news subscription this will generate an "invalid tick type" error
        client.reqMktData(1005, ContractSamples.USStock(), "mdoff,292:BZ", False, False, Nothing)
        client.reqMktData(1006, ContractSamples.USStock(), "mdoff,292:BT", False, False, Nothing)
        client.reqMktData(1007, ContractSamples.USStock(), "mdoff,292:FLY", False, False, Nothing)
        client.reqMktData(1008, ContractSamples.USStock(), "mdoff,292:MT", False, False, Nothing)
        '! [reqmktdata_contractnews]
        '! [reqmktdata_broadtapenews]
        client.reqMktData(1009, ContractSamples.BTbroadtapeNewsFeed(), "mdoff,292", False, False, Nothing)
        client.reqMktData(1010, ContractSamples.BZbroadtapeNewsFeed(), "mdoff,292", False, False, Nothing)
        client.reqMktData(1011, ContractSamples.FLYbroadtapeNewsFeed(), "mdoff,292", False, False, Nothing)
        client.reqMktData(1012, ContractSamples.MTbroadtapeNewsFeed(), "mdoff,292", False, False, Nothing)
        '! [reqmktdata_broadtapenews]

        '! [reqoptiondatagenticks]
        'Requesting data for an option contract will return the greek values
        client.reqMktData(1005, ContractSamples.USOptionContract(), String.Empty, False, False, Nothing)
        '! [reqoptiondatagenticks]

        '! [reqfuturesopeninterest]
        'Requesting data for a futures contract will return the futures open interest
        client.reqMktData(1014, ContractSamples.SimpleFuture(), "mdoff,588", False, False, Nothing)
        '! [reqfuturesopeninterest]

        '! [reqmktdatapreopenbidask]
        'Requesting data for a futures contract will return the pre-open bid/ask flag
        client.reqMktData(1015, ContractSamples.SimpleFuture(), "", False, False, Nothing)
        '! [reqmktData_preopenbidask]

        '! [reqavgoptvolume]
        'Requesting data for a stock will return the average option volume
        client.reqMktData(1016, ContractSamples.USStockAtSmart(), "mdoff,105", False, False, Nothing)
        '! [reqavgoptvolume]

        Thread.Sleep(10000)
        ' Canceling the market data subscription 
        ' [cancelmktdata]
        client.cancelMktData(1001)
        client.cancelMktData(1002)
        client.cancelMktData(1003)
        client.cancelMktData(1004)
        client.cancelMktData(1005)
        client.cancelMktData(1014)
        client.cancelMktData(1015)
        client.cancelMktData(1016)
        ' [cancelmktdata]
    End Sub

    Private Sub tickOptionComputationOperations(client As EClientSocket)

        ' Requesting real time market data 
        ' [reqmktdata]
        client.reqMktData(2001, ContractSamples.FuturesOnOptions(), String.Empty, False, False, Nothing)
        ' [reqmktdata]

        Thread.Sleep(10000)

        ' Canceling the market data subscription 
        ' [cancelmktdata]
        client.cancelMktData(2001)
        ' [cancelmktdata]
    End Sub

    Private Sub marketDepthOperations(client As EClientSocket)

        '** Requesting the Deep Book ***
        '! [reqmarketdepth]
        client.reqMarketDepth(2001, ContractSamples.EurGbpFx(), 5, Nothing)
        '! [reqmarketdepth]
        Thread.Sleep(2000)

        '** Canceling the Deep Book request ***
        '! [cancelmktdepth]
        client.cancelMktDepth(2001)
        '! [cancelmktdepth]

        '** Requesting Market Depth Exchanges ***
        Thread.Sleep(2000)
        '! [reqMktDepthExchanges]
        client.reqMktDepthExchanges()
        '! [reqMktDepthExchanges]
    End Sub

    Private Sub realTimeBars(client As EClientSocket)

        '** Requesting real time bars ***
        '! [reqrealtimebars]
        client.reqRealTimeBars(3001, ContractSamples.EurGbpFx(), 5, "MIDPOINT", True, Nothing)
        '! [reqrealtimebars]
        Thread.Sleep(4000)
        '** Canceling real time bars ***
        '! [cancelrealtimebars]
        client.cancelRealTimeBars(3001)
        '! [cancelrealtimebars]
    End Sub

    Private Sub marketDataType(client As EClientSocket)
        '! [reqmarketdatatype]
        '*** Switch to live (1) frozen (2) delayed (3) or delayed frozen (4)***/
        client.reqMarketDataType(1)
        '! [reqmarketdatatype]
    End Sub

    Private Sub historicalDataRequests(client As EClientSocket)

        '** Requesting historical data ***
        '! [reqhistoricaldata]
        Dim queryTime As String = DateTime.Now.AddMonths(-6).ToString("yyyyMMdd HH:mm:ss")
        client.reqHistoricalData(4001, ContractSamples.EurGbpFx(), queryTime, "1 M", "1 day", "MIDPOINT", 1, 1, False, Nothing)
        client.reqHistoricalData(4002, ContractSamples.EuropeanStock(), queryTime, "10 D", "1 min", "TRADES", 1, 1, False, Nothing)
        '! [reqhistoricaldata]
        Thread.Sleep(2000)
        '** Canceling historical data requests ***
        '! [cancelhistoricaldata]
        client.cancelHistoricalData(4001)
        client.cancelHistoricalData(4002)
        '! [cancelhistoricaldata]
    End Sub

    Private Sub optionsOperations(client As EClientSocket)

        'Starting in version 9.72 of the API, the function reqSecDefOptParams can be used to retrieve an option chain for an underlying contract
        '! [reqsecdefoptparams]
        client.reqSecDefOptParams(0, "IBM", "", "STK", 8314)
        '! [reqsecdefoptparams]

        '! [calculateimpliedvolatility]
        '** Calculating implied volatility ***
        client.calculateImpliedVolatility(5001, ContractSamples.NormalOption(), 5, 85, Nothing)
        '** Canceling implied volatility ***
        client.cancelCalculateImpliedVolatility(5001)
        '! [calculateimpliedvolatility]

        '! [calculateoptionprice]
        '** Calculating option's price ***
        client.calculateOptionPrice(5002, ContractSamples.NormalOption(), 0.22, 85, Nothing)
        '** Canceling option's price calculation ***
        client.cancelCalculateOptionPrice(5002)
        '! [calculateoptionprice]

        '! [exercise_options]
        '** Exercising options ***
        client.exerciseOptions(5003, ContractSamples.OptionWithTradingClass(), 1, 1, Nothing, 1)
        '! [exercise_options]
    End Sub

    Private Sub contractOperations(client As EClientSocket)

        '! [reqcontractdetails]
        client.reqContractDetails(209, ContractSamples.EurGbpFx())
        client.reqContractDetails(210, ContractSamples.OptionForQuery())
        client.reqContractDetails(211, ContractSamples.Bond())
        client.reqContractDetails(212, ContractSamples.FuturesOnOptions())
        client.reqContractDetails(213, ContractSamples.SimpleFuture())
        '! [reqcontractdetails]

        '! [reqcontractdetailsnews]
        client.reqContractDetails(211, ContractSamples.NewsFeedForQuery())
        '! [reqcontractdetailsnews]

        Thread.Sleep(2000)
        ''! [reqmatchingsymbols]
        client.reqMatchingSymbols(202, "IB")
        ''! [reqmatchingsymbols]
    End Sub

    Private Sub marketScanners(client As EClientSocket)

        '*** Requesting all available parameters which can be used to build a scanner request ***/
        '! [reqscannerparameters]
        client.reqScannerParameters()
        '! [reqscannerparameters]
        Thread.Sleep(2000)

        '*** Triggering a scanner subscription ***/
        '! [reqscannersubscription]
        client.reqScannerSubscription(7001, ScannerSubscriptionSamples.HighOptVolumePCRatioUSIndexes(), Nothing)
        '! [reqscannersubscription]

        Thread.Sleep(2000)
        '*** Canceling the scanner subscription ***/
        '! [cancelscannersubscription]
        client.cancelScannerSubscription(7001)
        '! [cancelscannersubscription]

    End Sub

    Private Sub reutersFundamentals(client As EClientSocket)

        '** Requesting Fundamentals ***
        '! [reqfundamentaldata]
        client.reqFundamentalData(8001, ContractSamples.USStock(), "ReportsFinSummary", Nothing)
        '! [reqfundamentaldata]

        Thread.Sleep(2000)

        '! [cancelfundamentaldata]
        '** Canceling fundamentals request ***
        client.cancelFundamentalData(8001)
        '! [cancelfundamentaldata]
    End Sub

    Private Sub bulletins(client As EClientSocket)

        '** Requesting Interactive Broker's news bulletins *
        '! [reqnewsbulletins]
        client.reqNewsBulletins(True)
        '! [reqnewsbulletins]
        Thread.Sleep(2000)
        '** Canceling IB's news bulletins ***
        '! [cancelnewsbulletins]
        client.cancelNewsBulletin()
        '! [cancelnewsbulletins]
    End Sub

    Private Sub accountOperations(client As EClientSocket)

        '! [reqaccountupdatesmulti]
        'client.reqAccountUpdatesMulti(9002, null, "EUstocks", true)
        '! [reqaccountupdatesmulti]

        '! [reqpositionsmulti]
        client.reqPositionsMulti(9003, "DU74649", "EUstocks")
        '! [reqpositionsmulti]

        Thread.Sleep(10000)

        '** Requesting managed accounts***
        '! [reqmanagedaccts]
        client.reqManagedAccts()
        '! [reqmanagedaccts]

        '** Requesting accounts' summary ***
        Thread.Sleep(2000)
        '! [reqaaccountsummary]
        client.reqAccountSummary(9001, "All", AccountSummaryTags.GetAllTags())
        '! [reqaaccountsummary]

        '! [reqaaccountsummaryledger]
        client.reqAccountSummary(9002, "All", "$LEDGER")
        '! [reqaaccountsummaryledger]
        Thread.Sleep(2000)
        '! [reqaaccountsummaryledgercurrency]
        client.reqAccountSummary(9003, "All", "$LEDGER:EUR")
        '! [reqaaccountsummaryledgercurrency]
        Thread.Sleep(2000)
        '! [reqaaccountsummaryledgerall]
        client.reqAccountSummary(9004, "All", "$LEDGER:ALL")
        '! [reqaaccountsummaryledgerall]

        Thread.Sleep(2000)
        '! [cancelaaccountsummary]
        client.cancelAccountSummary(9001)
        client.cancelAccountSummary(9002)
        client.cancelAccountSummary(9003)
        client.cancelAccountSummary(9004)
        '! [cancelaaccountsummary]

        '** Subscribing to an account's information. Only one at a time! ***
        Thread.Sleep(2000)
        '! [reqaaccountupdates]
        client.reqAccountUpdates(True, "U150462")
        '! [reqaaccountupdates]
        Thread.Sleep(2000)
        '! [cancelaaccountupdates]
        client.reqAccountUpdates(False, "U150462")
        '! [cancelaaccountupdates]

        '! [reqaaccountupdatesmulti]
        client.reqAccountUpdatesMulti(9002, "U150462", "EUstocks", True)
        '! [reqaaccountupdatesmulti]

        Thread.Sleep(2000)
        '** Requesting all accounts' positions. ***
        '! [reqpositions]
        client.reqPositions()
        '! [reqpositions]
        Thread.Sleep(2000)
        '! [cancelpositions]
        client.cancelPositions()
        '! [cancelpositions]

        Thread.Sleep(2000)
        ''! [reqfamilycodes]
        client.reqFamilyCodes()
        ''! [reqfamilycodes]

    End Sub

    Private Sub orderOperations(client As EClientSocket, nextOrderId As Integer)

        '** Requesting the next valid id ***
        '! [reqids]
        'The parameter Is always ignored.
        client.reqIds(-1)
        '! [reqids]
        'Thread.Sleep(1000)
        '** Requesting all open orders ***
        '! [reqallopenorders]
        client.reqAllOpenOrders()
        '! [reqallopenorders]
        'Thread.Sleep(1000)
        '** Taking over orders to be submitted via TWS ***
        '! [reqautoopenorders]
        client.reqAutoOpenOrders(True)
        '! [reqautoopenorders]
        ' Thread.Sleep(1000)
        '** Requesting this API client's orders ***
        '! [reqopenorders]
        client.reqOpenOrders()
        '! [reqopenorders]
        'Thread.Sleep(1000)
        '** Placing/modifying an order - remember to ALWAYS increment the nextValidId after placing an order so it can be used for the next one! ***

        '! [order_submission]
        client.placeOrder(increment(nextOrderId), ContractSamples.USStock(), OrderSamples.LimitOrder("SELL", 1, 50))
        '! [order_submission]

        '! [faorderoneaccount]
        Dim faOrderOneAccount As Order = OrderSamples.MarketOrder("BUY", 100)
        ' Specify the Account Number directly
        faOrderOneAccount.Account = "DU119915"
        client.placeOrder(increment(nextOrderId), ContractSamples.USStock(), faOrderOneAccount)
        '! [faorderoneaccount]

        '! [faordergroupequalquantity]
        Dim faOrderGroupEQ As Order = OrderSamples.LimitOrder("SELL", 200, 2000)
        faOrderGroupEQ.FaGroup = "Group_Equal_Quantity"
        faOrderGroupEQ.FaMethod = "EqualQuantity"
        client.placeOrder(increment(nextOrderId), ContractSamples.SimpleFuture(), faOrderGroupEQ)
        '! [faordergroupequalquantity]

        '! [faordergrouppctchange]
        Dim faOrderGroupPC As Order = OrderSamples.MarketOrder("BUY", 0)
        ' You should not specify any order quantity for PctChange allocation method
        faOrderGroupPC.FaGroup = "Pct_Change"
        faOrderGroupPC.FaMethod = "PctChange"
        faOrderGroupPC.FaPercentage = "100"
        client.placeOrder(increment(nextOrderId), ContractSamples.EurGbpFx(), faOrderGroupPC)
        '! [faordergrouppctchange]

        '! [faorderprofile]
        Dim faOrderProfile As Order = OrderSamples.LimitOrder("BUY", 200, 100)
        faOrderProfile.FaProfile = "Percent_60_40"
        client.placeOrder(increment(nextOrderId), ContractSamples.EuropeanStock(), faOrderProfile)
        '! [faorderprofile]

        '! [modelorder]
        Dim modelOrder As Order = OrderSamples.LimitOrder("BUY", 200, 100)
        modelOrder.Account = "DF12345" 'master FA account number
        modelOrder.ModelCode = "Technology" 'model for tech stocks first created in TWS
        client.placeOrder(increment(nextOrderId), ContractSamples.USStock(), modelOrder)
        '! [modelorder]

        'client.placeOrder(increment(nextOrderId), ContractSamples.OptionAtBOX(), OrderSamples.Block("BUY", 50, 20))
        'client.placeOrder(increment(nextOrderId), ContractSamples.OptionAtBOX(), OrderSamples.BoxTop("SELL", 10))
        'client.placeOrder(increment(nextOrderId), ContractSamples.FutureComboContract(), OrderSamples.ComboLimitOrder("SELL", 1, 1, False))
        'client.placeOrder(increment(nextOrderId), ContractSamples.StockComboContract(), OrderSamples.ComboMarketOrder("BUY", 1, True))
        'client.placeOrder(increment(nextOrderId), ContractSamples.StockComboContract(), OrderSamples.LimitOrderForComboWithLegPrices("BUY", 1, New Double() 10, 5}, True))
        'client.placeOrder(increment(nextOrderId), ContractSamples.USStock(), OrderSamples.Discretionary("SELL", 1, 45, 0.5))
        'client.placeOrder(increment(nextOrderId), ContractSamples.OptionAtBOX(), OrderSamples.LimitIfTouched("BUY", 1, 30, 34))
        'client.placeOrder(increment(nextOrderId), ContractSamples.USStock(), OrderSamples.LimitOnClose("SELL", 1, 34))
        'client.placeOrder(increment(nextOrderId), ContractSamples.USStock(), OrderSamples.LimitOnOpen("BUY", 1, 35))
        'client.placeOrder(increment(nextOrderId), ContractSamples.USStock(), OrderSamples.LimitOrder("SELL", 1, 50))
        'client.placeOrder(increment(nextOrderId), ContractSamples.USStock(), OrderSamples.MarketIfTouched("BUY", 1, 30))
        'client.placeOrder(increment(nextOrderId), ContractSamples.USStock(), OrderSamples.MarketOnClose("SELL", 1))
        'client.placeOrder(increment(nextOrderId), ContractSamples.USStock(), OrderSamples.MarketOnOpen("BUY", 1))
        'client.placeOrder(increment(nextOrderId), ContractSamples.USStock(), OrderSamples.MarketOrder("SELL", 1))
        'client.placeOrder(increment(nextOrderId), ContractSamples.USStock(), OrderSamples.MarketToLimit("BUY", 1))
        'client.placeOrder(increment(nextOrderId), ContractSamples.OptionAtIse(), OrderSamples.MidpointMatch("BUY", 1))
        'client.placeOrder(increment(nextOrderId), ContractSamples.USStock(), OrderSamples.MarketToLimit("BUY", 1))
        'client.placeOrder(increment(nextOrderId), ContractSamples.USStock(), OrderSamples.StopOrder("SELL", 1, 34))
        'client.placeOrder(increment(nextOrderId), ContractSamples.USStock(), OrderSamples.StopLimit("BUY", 1, 35, 33))
        'client.placeOrder(increment(nextOrderId), ContractSamples.USStock(), OrderSamples.StopWithProtection("SELL", 1, 45))
        'client.placeOrder(increment(nextOrderId), ContractSamples.USStock(), OrderSamples.SweepToFill("BUY", 1, 35))
        'client.placeOrder(increment(nextOrderId), ContractSamples.USStock(), OrderSamples.TrailingStop("SELL", 1, 0.5, 30))
        'client.placeOrder(increment(nextOrderId), ContractSamples.USStock(), OrderSamples.TrailingStopLimit("BUY", 1, 2, 5, 50))
        'client.placeOrder(increment(nextOrderId), ContractSamples.NormalOption(), OrderSamples.Volatility("SELL", 1, 5, 2))



        'NOTE the following orders are Not supported For Paper Trading
        'client.placeOrder(increment(nextOrderId), ContractSamples.USStock(), OrderSamples.AtAuction("BUY", 100, 30.0))
        'client.placeOrder(increment(nextOrderId), ContractSamples.OptionAtBOX(), OrderSamples.AuctionLimit("SELL", 10, 30.0, 2))
        'client.placeOrder(increment(nextOrderId), ContractSamples.OptionAtBOX(), OrderSamples.AuctionPeggedToStock("BUY", 10, 30, 0.5))
        'client.placeOrder(increment(nextOrderId), ContractSamples.OptionAtBOX(), OrderSamples.AuctionRelative("SELL", 10, 0.6))
        'client.placeOrder(increment(nextOrderId), ContractSamples.SimpleFuture(), OrderSamples.MarketWithProtection("BUY", 1))
        'client.placeOrder(increment(nextOrderId), ContractSamples.USStock(), OrderSamples.PassiveRelative("BUY", 1, 0.5))


        '208813720 (GOOG)
        'client.placeOrder(nextOrderId, ContractSamples.USStock(),
        'OrderSamples.PeggedToBenchmark("SELL", 100, 33, True, 0.1, 1, 208813720, "ISLAND", 750, 650, 800))


        'Stop ADJUSTABLE ORDERS
        'Dim stpParent As Order = OrderSamples.StopOrder("SELL", 100, 30)
        'stpParent.OrderId = nextOrderId

        'client.placeOrder(stpParent.OrderId, ContractSamples.EuropeanStock(), stpParent)
        'client.placeOrder(increment(nextOrderId), ContractSamples.EuropeanStock(), OrderSamples.AttachAdjustableToStop(stpParent, 35, 32, 33))
        'client.placeOrder(increment(nextOrderId), ContractSamples.EuropeanStock(), OrderSamples.AttachAdjustableToStopLimit(stpParent, 35, 33, 32, 33))
        'client.placeOrder(increment(nextOrderId), ContractSamples.EuropeanStock(), OrderSamples.AttachAdjustableToTrail(stpParent, 35, 32, 32, 1, 0))

        'Dim lmtParent As Order = OrderSamples.LimitOrder("BUY", 100, 30)
        'lmtParent.OrderId = increment(nextOrderId)

        'client.placeOrder(lmtParent.OrderId, ContractSamples.EuropeanStock(), lmtParent)
        'Attached TRAIL adjusted can only be attached to LMT parent orders.
        'client.placeOrder(increment(nextOrderId), ContractSamples.EuropeanStock(), OrderSamples.AttachAdjustableToTrail(lmtParent, 34, 32, 33, 0.008, 0))

        'Thread.Sleep(3000)
        '! [cancelorder]
        client.cancelOrder(nextOrderId - 1)
        '! [cancelorder]
        '** Cancel all orders for all accounts ***
        '! [reqglobalcancel]
        client.reqGlobalCancel()
        '! [reqglobalcancel]
        '** Request the day's executions ***
        '! [reqexecutions]
        client.reqExecutions(10001, New ExecutionFilter())
        '! [reqexecutions]
    End Sub

    Private Sub newsOperations(client As EClientSocket)

        ' Requesting news ticks
        ' [reqNewsTicks]
        client.reqMktData(10001, ContractSamples.USStockAtSmart(), "mdoff,292", False, False, Nothing)
        ' [reqNewsTicks]

        Thread.Sleep(5000)

        ' Canceling news ticks
        ' [cancelNewsTicks]
        client.cancelMktData(10001)
        ' [cancelNewsTicks]

        ' Requesting news providers
        Thread.Sleep(2000)
        ' [reqNewsProviders]
        client.reqNewsProviders()
        ' [reqNewsProviders]

        ' Requesting news article
        Thread.Sleep(2000)
        ' [reqNewsArticle]
        client.reqNewsArticle(10002, "BZ", "BZ$04507322", Nothing)
        ' [reqNewsArticle]

        ' Requesting historical news
        Thread.Sleep(2000)
        ' [reqHistoricalNews]
        client.reqHistoricalNews(10003, 8314, "BZ+FLY", "", "", 10, Nothing)
        ' [reqHistoricalNews]

    End Sub

    Private Sub OcaSample(client As EClientSocket, nextOrderId As Integer)

        'OCA ORDER
        '! [ocasubmit]
        Dim ocaOrders As List(Of Order) = New List(Of Order)
        ocaOrders.Add(OrderSamples.LimitOrder("BUY", 1, 10))
        ocaOrders.Add(OrderSamples.LimitOrder("BUY", 1, 11))
        ocaOrders.Add(OrderSamples.LimitOrder("BUY", 1, 12))
        OrderSamples.OneCancelsAll("TestOCA_" + nextOrderId, ocaOrders, 2)
        For Each o As Order In ocaOrders
            client.placeOrder(increment(nextOrderId), ContractSamples.USStock(), o)
        Next
        '! [ocasubmit]
    End Sub

    Private Sub ConditionSamples(client As EClientSocket, nextOrderId As Integer)

        '! [order_conditioning_activate]
        Dim mkt As Order = OrderSamples.MarketOrder("BUY", 100)
        'Order will become active if conditioning criteria Is met
        mkt.ConditionsCancelOrder = True
        mkt.Conditions.Add(OrderSamples.PriceCondition(208813720, "SMART", 600, False, False))
        mkt.Conditions.Add(OrderSamples.ExecutionCondition("EUR.USD", "CASH", "IDEALPRO", True))
        mkt.Conditions.Add(OrderSamples.MarginCondition(30, True, False))
        mkt.Conditions.Add(OrderSamples.PercentageChangeCondition(15.0, 208813720, "SMART", True, True))
        mkt.Conditions.Add(OrderSamples.TimeCondition("20160118 23:59:59", True, False))
        mkt.Conditions.Add(OrderSamples.VolumeCondition(208813720, "SMART", False, 100, True))
        client.placeOrder(increment(nextOrderId), ContractSamples.EuropeanStock(), mkt)
        '! [order_conditioning_activate]

        'Conditions can make the order active Or cancel it. Only LMT orders can be conditionally canceled.
        '! [order_conditioning_cancel]
        Dim lmt As Order = OrderSamples.LimitOrder("BUY", 100, 20)
        'The active order will be cancelled if conditioning criteria Is met
        lmt.ConditionsCancelOrder = True
        lmt.Conditions.Add(OrderSamples.PriceCondition(208813720, "SMART", 600, False, False))
        client.placeOrder(increment(nextOrderId), ContractSamples.EuropeanStock(), lmt)
        '! [order_conditioning_cancel]
    End Sub

    Private Sub BracketSample(client As EClientSocket, nextOrderId As Integer)

        'BRACKET ORDER
        '! [bracketsubmit]
        Dim bracket As List(Of Order) = OrderSamples.BracketOrder(increment(nextOrderId), "BUY", 100, 30, 40, 20)
        For Each o As Order In bracket
            client.placeOrder(o.OrderId, ContractSamples.EuropeanStock(), o)
        Next
        '! [bracketsubmit]
    End Sub

    Private Sub HedgeSample(client As EClientSocket, nextOrderId As Integer)

        'F Hedge order
        '! [hedgesubmit]
        'Parent order on a contract which currency differs from your base currency
        Dim parent As Order = OrderSamples.LimitOrder("BUY", 100, 10)
        parent.OrderId = increment(nextOrderId)
        'Hedge on the currency conversion
        Dim hedge As Order = OrderSamples.MarketFHedge(parent.OrderId, "BUY")
        'Place the parent first...
        client.placeOrder(parent.OrderId, ContractSamples.EuropeanStock(), parent)
        'Then the hedge order
        client.placeOrder(increment(increment(nextOrderId)), ContractSamples.EurGbpFx(), hedge)
        '! [hedgesubmit]
    End Sub

    Private Sub TestAlgoSamples(client As EClientSocket, nextOrderId As Integer)

        '! [algo_base_order]
        Dim baseOrder As Order = OrderSamples.LimitOrder("BUY", 1000, 1)
        '! [algo_base_order]

        '! [arrivalpx]
        AvailableAlgoParams.FillArrivalPriceParams(baseOrder, 0.10000000000000001, "Aggressive", "09:00:00 CET", "16:00:00 CET", True, True, 100000)
        client.placeOrder(increment(nextOrderId), ContractSamples.USStockAtSmart(), baseOrder)
        '! [arrivalpx]

        Thread.Sleep(500)

        '! [darkice]
        AvailableAlgoParams.FillDarkIceParams(baseOrder, 10, "09:00:00 CET", "16:00:00 CET", True, 100000)
        client.placeOrder(increment(nextOrderId), ContractSamples.USStockAtSmart(), baseOrder)
        '! [darkice]

        Thread.Sleep(500)

        '! [ad]
        ' The Time Zone in "startTime" and "endTime" attributes is ignored and always defaulted to GMT
        AvailableAlgoParams.FillAccumulateDistributeParams(baseOrder, 10, 60, True, True, 1, True, True, "20161010-12:00:00 GMT", "20161010-16:00:00 GMT")
        client.placeOrder(increment(nextOrderId), ContractSamples.USStockAtSmart(), baseOrder)
        '! [ad]

        Thread.Sleep(500)

        '! [twap]
        AvailableAlgoParams.FillTwapParams(baseOrder, "Marketable", "09:00:00 CET", "16:00:00 CET", True, 100000)
        client.placeOrder(increment(nextOrderId), ContractSamples.USStockAtSmart(), baseOrder)
        '! [twap]

        Thread.Sleep(500)

        '! [vwap]
        AvailableAlgoParams.FillVwapParams(baseOrder, 0.20000000000000001, "09:00:00 CET", "16:00:00 CET", True, True, True, 100000)
        client.placeOrder(increment(nextOrderId), ContractSamples.USStockAtSmart(), baseOrder)
        '! [vwap]

        Thread.Sleep(500)

        '! [balanceimpactrisk]
        AvailableAlgoParams.FillBalanceImpactRiskParams(baseOrder, 0.10000000000000001, "Aggressive", True)
        client.placeOrder(increment(nextOrderId), ContractSamples.USOptionContract(), baseOrder)
        '! [balanceimpactrisk]

        Thread.Sleep(500)

        '! [minimpact]
        AvailableAlgoParams.FillMinImpactParams(baseOrder, 0.29999999999999999)
        client.placeOrder(increment(nextOrderId), ContractSamples.USOptionContract(), baseOrder)
        '! [minimpact]

        '! [adaptive]
        AvailableAlgoParams.FillAdaptiveParams(baseOrder, "Normal")
        client.placeOrder(increment(nextOrderId), ContractSamples.USStockAtSmart(), baseOrder)
        '! [adaptive]

        '! [closepx]
        AvailableAlgoParams.FillClosePriceParams(baseOrder, 0.5, "Neutral", "12:00:00 EST", True, 100000)
        client.placeOrder(increment(nextOrderId), ContractSamples.USStockAtSmart(), baseOrder)
        '! [closepx]

        '! [pctvol]
        AvailableAlgoParams.FillPctVolParams(baseOrder, 0.5, "12:00:00 EST", "14:00:00 EST", True, 100000)
        client.placeOrder(increment(nextOrderId), ContractSamples.USStockAtSmart(), baseOrder)
        '! [pctvol]               

        '! [pctvolpx]
        AvailableAlgoParams.FillPriceVariantPctVolParams(baseOrder, 0.10000000000000001, 0.050000000000000003, 0.01, 0.20000000000000001, "12:00:00 EST", "14:00:00 EST", True, 100000)
        client.placeOrder(increment(nextOrderId), ContractSamples.USStockAtSmart(), baseOrder)
        '! [pctvolpx]

        '! [pctvolsz]
        AvailableAlgoParams.FillSizeVariantPctVolParams(baseOrder, 0.20000000000000001, 0.40000000000000002, "12:00:00 EST", "14:00:00 EST", True, 100000)
        client.placeOrder(increment(nextOrderId), ContractSamples.USStockAtSmart(), baseOrder)
        '! [pctvolsz]

        '! [pctvoltm]
        AvailableAlgoParams.FillTimeVariantPctVolParams(baseOrder, 0.20000000000000001, 0.40000000000000002, "12:00:00 EST", "14:00:00 EST", True, 100000)
        client.placeOrder(increment(nextOrderId), ContractSamples.USStockAtSmart(), baseOrder)
        '! [pctvoltm]

        '! [jeff_vwap_algo]
        AvailableAlgoParams.FillJefferiesVWAPParams(baseOrder, "10:00:00 EST", "16:00:00 EST", 10, 10, "Exclude_Both", 130, 135, 1, 10, "Patience", False, "Midpoint")
        client.placeOrder(increment(nextOrderId), ContractSamples.JefferiesContract(), baseOrder)
        '! [jeff_vwap_algo]

        '! [csfb_inline_algo]
        AvailableAlgoParams.FillCSFBInlineParams(baseOrder, "10:00:00 EST", "16:00:00 EST", "Patient", 10, 20, 100, "Default", False, 40, 100, 100, 35)
        client.placeOrder(increment(nextOrderId), ContractSamples.CSFBContract(), baseOrder)
        '! [csfb_inline_algo]
    End Sub



    Private Sub financialAdvisorOperations(client As EClientSocket)

        ''*** Requesting FA information ***/
        ''! [requestfaaliases]
        client.requestFA(Constants.FaAliases)
        ''! [requestfaaliases]

        ''! [requestfagroups]
        client.requestFA(Constants.FaGroups)
        ''! [requestfagroups]

        ''! [requestfaprofiles]
        client.requestFA(Constants.FaProfiles)
        ''! [requestfaprofiles]

        ''*** Replacing FA information - Fill in with the appropriate XML string. ***/
        ''! [replacefaonegroup]
        client.replaceFA(Constants.FaGroups, FaAllocationSamples.FaOneGroup)
        ''! [replacefaonegroup]

        ''! [replacefatwogroups]
        client.replaceFA(Constants.FaGroups, FaAllocationSamples.FaTwoGroups)
        ''! [replacefatwogroups]

        ''! [replacefaoneprofile]
        client.replaceFA(Constants.FaProfiles, FaAllocationSamples.FaOneProfile)
        ''! [replacefaoneprofile]

        ''! [replacefatwoprofiles]
        client.replaceFA(Constants.FaProfiles, FaAllocationSamples.FaTwoProfiles)
        ''! [replacefatwoprofiles]

        ''! [reqSoftDollarTiers]
        client.reqSoftDollarTiers(4001)
        ''! [reqSoftDollarTiers]
    End Sub

    Private Sub miscellaneous(client As EClientSocket)

        '** Request TWS' current time ***
        client.reqCurrentTime()
        '** Setting TWS logging level  ***
        client.setServerLogLevel(1)
    End Sub

    Private Sub linkingOperations(client As EClientSocket)

        '! [querydisplaygroups]
        client.queryDisplayGroups(9001)
        '! [querydisplaygroups]

        Thread.Sleep(500)

        '! [subscribetogroupevents]
        client.subscribeToGroupEvents(9002, 1)
        '! [subscribetogroupevents]

        Thread.Sleep(500)

        '! [updatedisplaygroup]
        client.updateDisplayGroup(9002, "8314@SMART")
        '! [updatedisplaygroup]

        Thread.Sleep(500)

        '! [subscribefromgroupevents]
        client.unsubscribeFromGroupEvents(9002)
        '! [subscribefromgroupevents]

        client.verifyRequest("a name", "9.71")
        client.verifyMessage("apiData")

    End Sub

    Private Sub headTimestamp(client As EClientSocket)
        '! [reqHeadTimeStamp]
        client.reqHeadTimestamp(14001, ContractSamples.USStock(), "TRADES", 1, 1)
        '! [reqHeadTimeStamp]
        Thread.Sleep(500)
        '! [cancelHeadTimestamp]
        client.cancelHeadTimestamp(14001)
        '! [cancelHeadTimestamp]		
    End Sub

    Private Sub histogramData(client As EClientSocket)
        '! [reqHistogramData]
        client.reqHistogramData(15001, ContractSamples.USStockWithPrimaryExch, False, "1 week")
        '! [reqHistogramData]
        Thread.Sleep(2000)
        '! [cancelHistogramData]
        client.cancelHistogramData(15001)
        '! [cancelHistogramData]
    End Sub

    Private Sub rerouteCFDOperations(client As EClientSocket)
        ' [reqmktdatacfd]
        client.reqMktData(16001, ContractSamples.USStockCFD(), String.Empty, False, False, Nothing)
        Thread.Sleep(1000)
        client.reqMktData(16002, ContractSamples.EuropeanStockCFD(), String.Empty, False, False, Nothing)
        Thread.Sleep(1000)
        client.reqMktData(16003, ContractSamples.CashCFD(), String.Empty, False, False, Nothing)
        Thread.Sleep(1000)
        ' [reqmktdatacfd]

        ' [reqmktdepthcfd]
        client.reqMarketDepth(16004, ContractSamples.USStockCFD(), 10, Nothing)
        Thread.Sleep(1000)
        client.reqMarketDepth(16005, ContractSamples.EuropeanStockCFD(), 10, Nothing)
        Thread.Sleep(1000)
        client.reqMarketDepth(16006, ContractSamples.CashCFD(), 10, Nothing)
        Thread.Sleep(1000)
        ' [reqmktdepthcfd]

    End Sub

    Private Sub marketRuleOperations(client As EClientSocket)

        client.reqContractDetails(17001, ContractSamples.USStock())
        client.reqContractDetails(17002, ContractSamples.Bond())

        Thread.Sleep(2000)

        '! [reqmarketrule]
        client.reqMarketRule(26)
        client.reqMarketRule(240)
        '! [reqmarketrule]

    End Sub

    Private Sub continuousFuturesOperations(client As EClientSocket)

        client.reqContractDetails(18001, ContractSamples.ContFut())

        '! [reqhistoricaldatacontfut]
        Dim queryTime As String = DateTime.Now.ToString("yyyyMMdd HH:mm:ss")
        client.reqHistoricalData(18002, ContractSamples.ContFut(), queryTime, "1 Y", "1 month", "TRADES", 0, 1, False, Nothing)
        Thread.Sleep(10000)
        client.cancelHistoricalData(18002)
        '! [reqhistoricaldatacontfut]

    End Sub

    Private Sub tickByTickOperations(client As EClientSocket)

        ' Requesting tick-by-tick data (only refresh)
        '! [reqtickbytick]
        client.reqTickByTickData(19001, ContractSamples.EuropeanStock(), "Last", 0, False)
        client.reqTickByTickData(19002, ContractSamples.EuropeanStock(), "AllLast", 0, False)
        client.reqTickByTickData(19003, ContractSamples.EuropeanStock(), "BidAsk", 0, True)
        client.reqTickByTickData(19004, ContractSamples.EurGbpFx(), "MidPoint", 0, False)
        '! [reqtickbytick]

        Thread.Sleep(10000)

        '! [canceltickbytick]
        client.cancelTickByTickData(19001)
        client.cancelTickByTickData(19002)
        client.cancelTickByTickData(19003)
        client.cancelTickByTickData(19004)
        '! [canceltickbytick]

        Thread.Sleep(5000)

        ' Requesting tick-by-tick data (historical + refresh)
        '! [reqtickbytick]
        client.reqTickByTickData(19005, ContractSamples.EuropeanStock(), "Last", 10, False)
        client.reqTickByTickData(19006, ContractSamples.EuropeanStock(), "AllLast", 10, False)
        client.reqTickByTickData(19007, ContractSamples.EuropeanStock(), "BidAsk", 10, False)
        client.reqTickByTickData(19008, ContractSamples.EurGbpFx(), "MidPoint", 10, True)
        '! [reqtickbytick]

        Thread.Sleep(10000)

        '! [canceltickbytick]
        client.cancelTickByTickData(19005)
        client.cancelTickByTickData(19006)
        client.cancelTickByTickData(19007)
        client.cancelTickByTickData(19008)
        '! [canceltickbytick]

    End Sub


End Module
