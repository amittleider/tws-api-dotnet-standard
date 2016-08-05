Imports IBApi

Namespace Samples

    ' Contracts can be defined in multiple ways. The TWS/IB Gateway will always perform a query on the available contracts
    ' And find which one Is the best candidate
    '  - More than a single candidate will yield an ambiguity error message.
    '  - No suitable candidates will produce a "contract not found" message.
    '  How do I find my contract though?
    '  - Often the quickest way Is by looking for it in the TWS And looking at its description there (double click).
    '  - The TWS' symbol corresponds to the API's localSymbol. Keep this in mind when defining Futures or Options.
    '  - The TWS' underlying's symbol can usually be mapped to the API's symbol.
    '  
    ' Any stock Or option symbols displayed are for illustrative purposes only And are Not intended to portray a recommendation.

    Public Class ContractSamples

        ' Usually, the easiest way to define a Stock/CASH contract is through these four attributes.

        Public Shared Function EurGbpFx() As Contract
            '! [cashcontract]
            Dim contract As Contract = New Contract
            contract.Symbol = "EUR"
            contract.SecType = "CASH"
            contract.Currency = "GBP"
            contract.Exchange = "IDEALPRO"
            '! [cashcontract]
            Return contract
        End Function

        Public Shared Function Index() As Contract
            '! [indcontract]
            Dim contract As Contract = New Contract
            contract.Symbol = "DAX"
            contract.SecType = "IND"
            contract.Currency = "EUR"
            contract.Exchange = "DTB"
            '! [indcontract]
            Return contract
        End Function

        Public Shared Function CFD() As Contract
            '! [cfdcontract]
            Dim contract As Contract = New Contract
            contract.Symbol = "IBDE30"
            contract.SecType = "CFD"
            contract.Currency = "EUR"
            contract.Exchange = "SMART"
            '! [cfdcontract]
            Return contract
        End Function

        Public Shared Function EuropeanStock() As Contract
            Dim contract As Contract = New Contract
            contract.Symbol = "SIE"
            contract.SecType = "STK"
            contract.Currency = "EUR"
            contract.Exchange = "SMART"
            Return contract
        End Function

        Public Shared Function OptionAtIse() As Contract
            Dim contract As Contract = New Contract
            contract.Symbol = "BPX"
            contract.SecType = "OPT"
            contract.Currency = "USD"
            contract.Exchange = "ISE"
            contract.LastTradeDateOrContractMonth = "20160916"
            contract.Right = "C"
            contract.Strike = 65
            contract.Multiplier = "100"
            Return contract
        End Function

        Public Shared Function USStock() As Contract
            '! [stkcontract]
            Dim contract As Contract = New Contract
            contract.Symbol = "IBKR"
            contract.SecType = "STK"
            contract.Currency = "USD"
            '! In the API side, NASDAQ Is always defined as ISLAND for routing purposes
            contract.Exchange = "ISLAND"
            '! [stkcontract]
            Return contract
        End Function

        Public Shared Function USStockAtSmart() As Contract

            Dim Contract As Contract = New Contract
            Contract.Symbol = "IBKR"
            Contract.SecType = "STK"
            Contract.Currency = "USD"
            Contract.Exchange = "SMART"
            Return Contract
        End Function

        Public Shared Function USStockWithPrimaryExch() As Contract
            '! [stkcontractwithprimary]
            Dim Contract As Contract = New Contract
            Contract.symbol = "MSFT"
            Contract.secType = "STK"
            Contract.currency = "USD"
            Contract.exchange = "SMART"
            'Specify the Primary Exchange attribute to avoid contract ambiguity
            Contract.PrimaryExch = "ISLAND"
            '! [stkcontractwithprimary]
            Return Contract
        End Function
		
		Public Shared Function BondWithCusip() As Contract
			'! [bondwithcusip]
			Dim Contract As Contract = New Contract
			' enter CUSIP as symbol
			contract.symbol= "912828C57"
			contract.secType = "BOND"
			contract.exchange = "SMART"
			contract.currency = "USD"
			'! [bondwithcusip]
			Return Contract
		End Function
	
        Public Shared Function Bond() As Contract
            '! [bond]
            Dim Contract As Contract = New Contract
            Contract.conid = 147554578
            Contract.exchange = "SMART"
            '! [bond]
            Return Contract
        End Function
	
        Public Shared Function MutualFund() As Contract
            '! [fundcontract]
            Dim Contract As Contract = New Contract
            Contract.symbol = "VINIX"
            Contract.secType = "FUND"
            Contract.exchange = "FUNDSERV"
            Contract.currency = "USD"
            '! [fundcontract]
            Return Contract
        End Function
	
        Public Shared Function Commodity() As Contract
            '! [commoditycontract]
            Dim Contract As Contract = New Contract
            Contract.symbol = "XAUUSD"
            Contract.secType = "CMDTY"
            Contract.exchange = "SMART"
            Contract.currency = "USD"
            '! [commoditycontract]
            Return Contract
        End Function
		
        Public Shared Function USOptionContract() As Contract

            Dim Contract As Contract = New Contract
            Contract.Symbol = "GOOG"
            Contract.SecType = "OPT"
            Contract.Exchange = "SMART"
            Contract.Currency = "USD"
            Contract.LastTradeDateOrContractMonth = "20170120"
            Contract.Strike = 615
            Contract.Right = "C"
            Contract.Multiplier = "100"

            Return Contract
        End Function

        Public Shared Function OptionAtBOX() As Contract
            '! [optcontract]
            Dim contract As Contract = New Contract
            contract.Symbol = "GOOG"
            contract.SecType = "OPT"
            contract.Exchange = "BOX"
            contract.Currency = "USD"
            contract.LastTradeDateOrContractMonth = "20170120"
            contract.Strike = 615
            contract.Right = "C"
            contract.Multiplier = "100"
            '! [optcontract]
            Return contract
        End Function

        '
        ' Option contracts require far more information since there are many contracts having the exact same
        ' attributes such as symbol, currency, strike, etc. 
        '
        Public Shared Function NormalOption() As Contract

            Dim contract As Contract = New Contract
            contract.Symbol = "BAYN"
            contract.SecType = "OPT"
            contract.Exchange = "DTB"
            contract.Currency = "EUR"
            contract.LastTradeDateOrContractMonth = "20161216"
            contract.Strike = 100
            contract.Right = "C"
            contract.Multiplier = "100"
            '! Often, contracts will also require a trading class to rule out ambiguities
            contract.TradingClass = "BAY"
            Return contract

        End Function
        '
        '  This contract for example requires the trading class too in order to prevent any ambiguity.
        '
        Public Shared Function OptionWithTradingClass() As Contract
            '! [optcontract_tradingclass]
            Dim contract As Contract = New Contract
            contract.Symbol = "SANT"
            contract.SecType = "OPT"
            contract.Exchange = "MEFFRV"
            contract.Currency = "EUR"
            contract.LastTradeDateOrContractMonth = "20190621"
            contract.Strike = 7.5
            contract.Right = "C"
            contract.Multiplier = "100"
            contract.TradingClass = "SANEU"
            '! [optcontract_tradingclass]
            Return contract
        End Function

        ' Using the contract's own symbol (localSymbol) can greatly simplify a contract description

        Public Shared Function OptionWithLocalSymbol() As Contract
            '! [optcontract_localsymbol]
            Dim contract As Contract = New Contract()
            'Watch out for the spaces within the local symbol!
            contract.LocalSymbol = "C DBK  DEC 20  1600"
            contract.SecType = "OPT"
            contract.Exchange = "DTB"
            contract.Currency = "EUR"
            '! [optcontract_localsymbol]
            Return contract
        End Function

        '
        ' Future contracts also require an expiration date but are less complicated than options.
        '
        Public Shared Function SimpleFuture() As Contract
            '! [futcontract]
            Dim contract As Contract = New Contract
            contract.Symbol = "ES"
            contract.SecType = "FUT"
            contract.Exchange = "GLOBEX"
            contract.Currency = "USD"
            contract.LastTradeDateOrContractMonth = "201612"
            '! [futcontract]
            Return contract
        End Function

        '
        '  Rather than giving expiration dates we can also provide the local symbol
        '  attributes such as symbol, currency, strike, etc. 
        '
        Public Shared Function FutureWithLocalSymbol() As Contract
            '! [futcontract_local_symbol]
            Dim contract As Contract = New Contract
            contract.SecType = "FUT"
            contract.Exchange = "GLOBEX"
            contract.Currency = "USD"
            contract.LocalSymbol = "ESU6"
            '! [futcontract_local_symbol]
            Return contract
        End Function

        Public Shared Function FutureWithMultiplier() As Contract
            '! [futcontract_multiplier]
            Dim contract As Contract = New Contract()
            contract.Symbol = "DAX"
            contract.SecType = "FUT"
            contract.Exchange = "DTB"
            contract.Currency = "EUR"
            contract.LastTradeDateOrContractMonth = "201609"
            contract.Multiplier = "5"
            '! [futcontract_multiplier]
            Return contract
        End Function

        ' 
        '  Note the space in the symbol!
        '
        Public Shared Function WrongContract() As Contract

            Dim contract As Contract = New Contract
            contract.Symbol = " IJR "
            contract.ConId = 9579976
            contract.SecType = "STK"
            contract.Exchange = "SMART"
            contract.Currency = "USD"
            Return contract
        End Function

        Public Shared Function FuturesOnOptions() As Contract

            '! [fopcontract]
            Dim contract As Contract = New Contract
            contract.Symbol = "ES"
            contract.SecType = "FOP"
            contract.Exchange = "GLOBEX"
            contract.Currency = "USD"
            contract.LastTradeDateOrContractMonth = "20160617"
            contract.Strike = 1810
            contract.Right = "C"
            contract.Multiplier = "50"
            '! [fopcontract]
            Return contract

        End Function

        '
        ' It Is also possible to define contracts based on their ISIN (IBKR STK sample).
        '
        '
        Public Shared Function ByISIN() As Contract

            Dim contract As Contract = New Contract
            contract.SecIdType = "ISIN"
            contract.SecId = "US45841N1072"
            contract.Exchange = "SMART"
            contract.Currency = "USD"
            contract.SecType = "STK"
            Return contract

        End Function


        '  
        '  Or their conId (EUR.USD sample).
        '  Note: passing a contract containing the conId can cause problems If one Of the other provided
        '  attributes does Not match 100% with what Is in IB's database. This is particularly important
        '  for contracts such as Bonds which may change their description from one day to another.
        '  If the conId Is provided, it Is best Not to give too much information as in the example below.
        ' 

        Public Shared Function ByConId() As Contract

            Dim contract As Contract = New Contract
            contract.SecType = "CASH"
            contract.ConId = 12087792
            contract.Exchange = "IDEALPRO"
            Return contract

        End Function


        '
        ' Ambiguous contracts are great to use with reqContractDetails. This way you can
        ' query the whole option chain for an underlying. Bear in mind that there are
        ' pacing mechanisms in place which will delay any further responses from the TWS
        ' to prevent abuse.
        '

        Public Shared Function OptionForQuery() As Contract

            '! [optionforquery]
            Dim contract As Contract = New Contract
            contract.Symbol = "FISV"
            contract.SecType = "OPT"
            contract.Exchange = "SMART"
            contract.Currency = "USD"
            '! [optionforquery]
            Return contract
        End Function

        Public Shared Function OptionComboContract() As Contract
            '! [bagoptcontract]
            Dim contract As Contract = New Contract
            contract.Symbol = "DBK"
            contract.SecType = "BAG"
            contract.Currency = "EUR"
            contract.Exchange = "DTB"

            Dim leg1 As ComboLeg = New ComboLeg
            leg1.ConId = 197397509 'DBK JUN 15 '18 C
            leg1.Ratio = 1
            leg1.Action = "BUY"
            leg1.Exchange = "DTB"

            Dim leg2 As ComboLeg = New ComboLeg
            leg2.ConId = 197397584 'DBK JUN 15 '18 P
            leg2.Ratio = 1
            leg2.Action = "SELL"
            leg2.Exchange = "DTB"

            contract.ComboLegs = New List(Of ComboLeg)
            contract.ComboLegs.Add(leg1)
            contract.ComboLegs.Add(leg2)
            '! [bagoptcontract]
            Return contract
        End Function


        ' 
        ' STK Combo contract
        ' Leg 1: 43645865 - IBKR's STK
        ' Leg 2: 9408 - McDonald's STK
        '

        Public Shared Function StockComboContract() As Contract

            '! [bagstkcontract]
            Dim contract As Contract = New Contract
            contract.Symbol = "MCD"
            contract.SecType = "BAG"
            contract.Currency = "USD"
            contract.Exchange = "SMART"

            Dim leg1 As ComboLeg = New ComboLeg
            leg1.ConId = 43645865
            leg1.Ratio = 1
            leg1.Action = "BUY"
            leg1.Exchange = "SMART"

            Dim leg2 As ComboLeg = New ComboLeg
            leg2.ConId = 9408
            leg2.Ratio = 1
            leg2.Action = "SELL"
            leg2.Exchange = "SMART"

            contract.ComboLegs = New List(Of ComboLeg)
            contract.ComboLegs.Add(leg1)
            contract.ComboLegs.Add(leg2)
            '! [bagstkcontract]
            Return contract

        End Function

        '
        ' CBOE Volatility Index Future combo contract
        ' Leg 1: 195538625 - FUT expiring 2016/02/17
        ' Leg 2: 197436571 - FUT expiring 2016/03/16
        '

        Public Shared Function FutureComboContract() As Contract

            '! [bagfutcontract]
            Dim contract As Contract = New Contract
            contract.Symbol = "VIX"
            contract.SecType = "BAG"
            contract.Currency = "USD"
            contract.Exchange = "CFE"

            Dim leg1 As ComboLeg = New ComboLeg
            leg1.ConId = 195538625
            leg1.Ratio = 1
            leg1.Action = "BUY"
            leg1.Exchange = "CFE"

            Dim leg2 As ComboLeg = New ComboLeg
            leg2.ConId = 197436571
            leg2.Ratio = 1
            leg2.Action = "SELL"
            leg2.Exchange = "CFE"

            contract.ComboLegs = New List(Of ComboLeg)
            contract.ComboLegs.Add(leg1)
            contract.ComboLegs.Add(leg2)
            '! [bagfutcontract]
            Return contract

        End Function

        Public Shared Function InterCmdtyFuturesContract() As Contract

            '! [intcmdfutcontract]
            Dim contract As Contract = New Contract
            contract.Symbol = "CL.BZ"
            contract.SecType = "BAG"
            contract.Currency = "USD"
            contract.Exchange = "NYMEX"

            Dim leg1 As ComboLeg = New ComboLeg
            leg1.ConId = 47207310 ' CL Dec'16 @NYMEX
            leg1.Ratio = 1
            leg1.Action = "BUY"
            leg1.Exchange = "NYMEX"

            Dim leg2 As ComboLeg = New ComboLeg
            leg2.ConId = 47195961 ' BZ Dec'16 @NYMEX
            leg2.Ratio = 1
            leg2.Action = "SELL"
            leg2.Exchange = "NYMEX"

            contract.ComboLegs = New List(Of ComboLeg)
            contract.ComboLegs.Add(leg1)
            contract.ComboLegs.Add(leg2)
            '! [intcmdfutcontract]
            Return contract

        End Function

        Public Shared Function NewsFeedForQuery() As Contract

            '! [newsfeedforquery]
            Dim contract As Contract = New Contract()
            contract.SecType = "NEWS"
            contract.Exchange = "BT" 'Briefing Trader
            '! [newsfeedforquery]
            Return contract

        End Function

        Public Shared Function BTbroadtapeNewsFeed() As Contract
            '! [newscontractbt]
            Dim contract As Contract = New Contract()
            contract.Symbol = "BT:BT_ALL" 'BroadTape All News
            contract.SecType = "NEWS"
            contract.Exchange = "BT" 'Briefing Trader
            '! [newscontractbt]
            Return contract
        End Function

        Public Shared Function BZbroadtapeNewsFeed() As Contract
            '! [newscontractbz]
            Dim contract As Contract = New Contract()
            contract.Symbol = "BZ:BZ_ALL" 'BroadTape All News
            contract.SecType = "NEWS"
            contract.Exchange = "BZ" 'Benzinga Pro
            '! [newscontractbz]
            Return contract
        End Function

        Public Shared Function FLYbroadtapeNewsFeed() As Contract
            '! [newscontractfly]
            Dim contract As Contract = New Contract()
            contract.Symbol = "FLY:FLY_ALL" 'BroadTape All News
            contract.SecType = "NEWS"
            contract.Exchange = "FLY" 'Fly On the Wall
            '! [newscontractfly]
            Return contract
        End Function

        Public Shared Function MTbroadtapeNewsFeed() As Contract
            '! [newscontractmt]
            Dim contract As Contract = New Contract()
            contract.Symbol = "MT:MT_ALL" 'BroadTape All News
            contract.SecType = "NEWS"
            contract.Exchange = "MT" 'Midnight Trader
            '! [newscontractmt]
            Return contract
        End Function

    End Class

End Namespace
