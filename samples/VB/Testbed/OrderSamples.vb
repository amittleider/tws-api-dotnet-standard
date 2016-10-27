Imports IBApi

Namespace Samples

    ''' <summary>
    ''' Make sure to test using only your paper trading account when applicable. A good way of finding out if an order type/exchange combination
    ''' Is possible Is by trying to place such order manually using the TWS.
    ''' Before contacting our API support team please refer to the available documentation.
    ''' </summary>
    Public Class OrderSamples

        ''' <summary>
        ''' An auction order Is entered into the electronic trading system during the pre-market opening period for execution at the 
        ''' Calculated Opening Price (COP). If your order Is Not filled on the open, the order Is re-submitted as a limit order with 
        ''' the limit price set to the COP Or the best bid/ask after the market opens.
        ''' Products: FUT, STK
        ''' Supported Exchanges: https://individuals.interactivebrokers.com/en/?f=%2Fen%2Ftrading%2ForderTypeExchanges.php%3Fot%3Dauc
        ''' Reference: http://individuals.interactivebrokers.com/en/trading/orders/auction.php?ib_entity=llc
        ''' </summary>
        Public Shared Function AtAuction(action As String, quantity As Double, price As Double) As Order
            '! [auction]
            Dim order As Order = New Order
            order.Action = action
            order.Tif = "AUC"
            order.OrderType = "MTL"
            order.TotalQuantity = quantity
            order.LmtPrice = price
            '! [auction]
            Return order

        End Function

        ''' <summary>
        ''' A Discretionary order Is a limit order submitted with a hidden, specified 'discretionary' amount off the limit price which
        ''' may be used to increase the price range over which the limit order Is eligible to execute. The market sees only the limit price.
        ''' Products: STK
        ''' Supported Exchanges: https://individuals.interactivebrokers.com/en/?f=%2Fen%2Ftrading%2ForderTypeExchanges.php%3Fot%3Ddis
        ''' Reference: http://individuals.interactivebrokers.com/en/trading/orders/discretionary.php?ib_entity=llc
        ''' </summary>
        Public Shared Function Discretionary(action As String, quantity As Double, price As Double, discretionaryAmount As Double) As Order
            '! [discretionary]
            Dim order As Order = New Order
            order.Action = action
            order.OrderType = "LMT"
            order.TotalQuantity = quantity
            order.LmtPrice = price
            order.DiscretionaryAmt = discretionaryAmount
            '! [discretionary]
            Return order

        End Function

        ''' <summary>
        ''' A Market order Is an order to buy Or sell at the market bid Or offer price. A market order may increase the likelihood of a fill 
        ''' And the speed of execution, but unlike the Limit order a Market order provides no price protection And may fill at a price far 
        ''' lower/higher than the current displayed bid/ask.
        ''' Products: BOND, CFD, EFP, CASH, FUND, FUT, FOP, OPT, STK, WAR
        ''' Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=mkt
        ''' Reference: http://individuals.interactivebrokers.com/en/trading/orders/market.php?ib_entity=llc
        ''' </summary>
        Public Shared Function MarketOrder(action As String, quantity As Double) As Order
            '! [market]
            Dim order As Order = New Order
            order.Action = action
            order.OrderType = "MKT"
            order.TotalQuantity = quantity
            '! [market]
            Return order
        End Function

        ''' <summary>
        ''' A Market if Touched (MIT) Is an order to buy (Or sell) a contract below (Or above) the market. Its purpose Is to take advantage 
        ''' of sudden Or unexpected changes in share Or other prices And provides investors with a trigger price to set an order in motion. 
        ''' Investors may be waiting for excessive strength (Or weakness) to cease, which might be represented by a specific price point. 
        ''' MIT orders can be used to determine whether Or Not to enter the market once a specific price level has been achieved. This order 
        ''' Is held in the system until the trigger price Is touched, And Is then submitted as a market order. An MIT order Is similar to a 
        ''' stop order, except that an MIT sell order Is placed above the current market price, And a stop sell order Is placed below
        ''' Products: BOND, CFD, CASH, FUT, FOP, OPT, STK, WAR
        ''' Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=mit
        ''' Reference: http://individuals.interactivebrokers.com/en/trading/orders/mit.php?ib_entity=llc
        ''' </summary>
        Public Shared Function MarketIfTouched(action As String, quantity As Double, price As Double) As Order
            '! [market_if_touched]
            Dim order As Order = New Order
            order.Action = action
            order.OrderType = "MIT"
            order.TotalQuantity = quantity
            order.AuxPrice = price
            '! [market_if_touched]
            Return order

        End Function

        ''' <summary>
        ''' A Market-on-Close (MOC) order Is a market order that Is submitted to execute as close to the closing price as possible.
        ''' Products: CFD, FUT, STK, WAR
        ''' Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=moc
        ''' Reference: http://individuals.interactivebrokers.com/en/trading/orders/moc.php?ib_entity=llc
        ''' </summary>
        Public Shared Function MarketOnClose(action As String, quantity As Double) As Order
            '! [market_on_close]
            Dim order As Order = New Order
            order.Action = action
            order.OrderType = "MOC"
            order.TotalQuantity = quantity
            '! [market_on_close]
            Return order
        End Function

        ''' <summary>
        ''' A Market-on-Open (MOO) order combines a market order with the OPG time in force to create an order that Is automatically
        ''' submitted at the market's open and fills at the market price.
        ''' Products: CFD, STK, OPT, WAR
        ''' Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=moo
        ''' Reference: http://individuals.interactivebrokers.com/en/trading/orders/moo.php?ib_entity=llc
        ''' </summary>
        Public Shared Function MarketOnOpen(action As String, quantity As Double) As Order
            '! [market_on_open]
            Dim order As Order = New Order
            order.Action = action
            order.OrderType = "MKT"
            order.TotalQuantity = quantity
            order.Tif = "OPG"
            '! [market_on_open]
            Return order
        End Function

        ''' <summary>
        ''' ISE Midpoint Match (MPM) orders always execute at the midpoint of the NBBO. You can submit market And limit orders direct-routed 
        ''' to ISE for MPM execution. Market orders execute at the midpoint whenever an eligible contra-order Is available. Limit orders 
        ''' execute only when the midpoint price Is better than the limit price. Standard MPM orders are completely anonymous.
        ''' Products: STK
        ''' Supported Exchanges: ISE
        ''' Reference: http://individuals.interactivebrokers.com/en/trading/orders/mpm.php?ib_entity=llc
        ''' </summary>
        Public Shared Function MidpointMatch(action As String, quantity As Double) As Order
            '! [midpoint_match]
            Dim order As Order = New Order
            order.Action = action
            order.OrderType = "MKT"
            order.TotalQuantity = quantity
            '! [midpoint_match]
            Return order
        End Function

        ''' <summary>
        ''' A pegged-to-market order Is designed to maintain a purchase price relative to the national best offer (NBO) Or a sale price 
        ''' relative to the national best bid (NBB). Depending on the width of the quote, this order may be passive Or aggressive. 
        ''' The trader creates the order by entering a limit price which defines the worst limit price that they are willing to accept. 
        ''' Next, the trader enters an offset amount which computes the active limit price as follows:
        '''     Sell order price = Bid price + offset amount
        '''     Buy order price = Ask price - offset amount
        ''' Products: STK
        ''' Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=pegmkt
        ''' Reference: http://individuals.interactivebrokers.com/en/trading/orders/peggedMarket.php?ib_entity=llc
        ''' </summary>
        Public Shared Function PeggedToMarket(action As String, quantity As Double, marketOffset As Double) As Order
            '! [pegged_market]
            Dim order As Order = New Order
            order.Action = action
            order.OrderType = "PEG MKT"
            order.TotalQuantity = 100
            order.AuxPrice = marketOffset ' Offset price
            '! [pegged_market]
            Return order
        End Function

        ''' <summary>
        ''' A Pegged to Stock order continually adjusts the option order price by the product of a signed user-define delta And the change of 
        ''' the option's underlying stock price. The delta is entered as an absolute and assumed to be positive for calls and negative for puts. 
        ''' A buy Or sell call order price Is determined by adding the delta times a change in an underlying stock price to a specified starting 
        ''' price for the call. To determine the change in price, the stock reference price Is subtracted from the current NBBO midpoint. 
        ''' The Stock Reference Price can be defined by the user, Or defaults to the NBBO midpoint at the time of the order if no reference price 
        ''' Is entered. You may also enter a high/low stock price range which cancels the order when reached. The delta times the change in stock 
        ''' price will be rounded to the nearest penny in favor of the order.
        ''' Products: OPT
        ''' Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=relstk
        ''' Reference: http://individuals.interactivebrokers.com/en/trading/orders/peggedStock.php?ib_entity=llc
        ''' </summary>
        Public Shared Function PeggedToStock(action As String, quantity As Double, delta As Double, stockReferencePrice As Double, startingPrice As Double) As Order
            '! [pegged_stock]
            Dim order As Order = New Order
            order.Action = action
            order.OrderType = "PEG STK"
            order.TotalQuantity = quantity
            order.Delta = delta
            order.LmtPrice = stockReferencePrice
            order.StartingPrice = startingPrice
            '! [pegged_stock]
            Return order
        End Function

        ''' <summary>
        ''' Relative (a.k.a. Pegged-to-Primary) orders provide a means for traders to seek a more aggressive price than the National Best Bid 
        ''' And Offer (NBBO). By acting as liquidity providers, And placing more aggressive bids And offers than the current best bids And offers, 
        ''' traders increase their odds of filling their order. Quotes are automatically adjusted as the markets move, to remain aggressive. 
        ''' For a buy order, your bid Is pegged to the NBB by a more aggressive offset, And if the NBB moves up, your bid will also move up. 
        ''' If the NBB moves down, there will be no adjustment because your bid will become even more aggressive And execute. For sales, your 
        ''' offer Is pegged to the NBO by a more aggressive offset, And if the NBO moves down, your offer will also move down. If the NBO moves up, 
        ''' there will be no adjustment because your offer will become more aggressive And execute. In addition to the offset, you can define an 
        ''' absolute cap, which works Like a limit price, And will prevent your order from being executed above Or below a specified level.
        ''' Stocks, Options And Futures - Not available on paper trading
        ''' Products: CFD, STK, OPT, FUT
        ''' Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=rel
        ''' Reference: http://individuals.interactivebrokers.com/en/trading/orders/relative.php?ib_entity=llc
        ''' </summary>
        Public Shared Function RelativePeggedToPrimary(action As String, quantity As Double, priceCap As Double, offsetAmount As Double) As Order
            '! ! [relative_pegged_primary]
            Dim order As Order = New Order
            order.Action = action
            order.OrderType = "REL"
            order.TotalQuantity = quantity
            order.LmtPrice = priceCap
            order.AuxPrice = offsetAmount
            '! ! [relative_pegged_primary]
            Return order
        End Function

        ''' <summary>
        ''' Sweep-to-fill orders are useful when a trader values speed of execution over price. A sweep-to-fill order identifies the best price 
        ''' And the exact quantity offered/available at that price, And transmits the corresponding portion of your order for immediate execution. 
        ''' Simultaneously it identifies the next best price And quantity offered/available, And submits the matching quantity of your order for 
        ''' immediate execution.
        ''' Products: CFD, STK, WAR
        ''' Supported Exchanges: SMART
        ''' Reference: http://individuals.interactivebrokers.com/en/trading/orders/sweep.php?ib_entity=llc
        ''' </summary>
        Public Shared Function SweepToFill(action As String, quantity As Double, price As Double) As Order
            '! [sweep_to_fill]
            Dim order As Order = New Order
            order.Action = action
            order.OrderType = "LMT"
            order.TotalQuantity = quantity
            order.LmtPrice = price
            order.SweepToFill = True
            '! [sweep_to_fill]
            Return order
        End Function

        ''' <summary>
        ''' For option orders routed to the Boston Options Exchange (BOX) you may elect to participate in the BOX's price improvement auction in 
        ''' pennies. All BOX-directed price improvement orders are immediately sent from Interactive Brokers to the BOX order book, And when the 
        ''' terms allow, IB will evaluate it for inclusion in a price improvement auction based on price And volume priority. In the auction, your 
        ''' order will have priority over broker-dealer price improvement orders at the same price.
        ''' An Auction Limit order at a specified price. Use of a limit order ensures that you will Not receive an execution at a price less favorable 
        ''' than the limit price. Enter limit orders in penny increments with your auction improvement amount computed as the difference between your 
        ''' limit order price And the nearest listed increment.
        ''' Products: OPT
        ''' Supported Exchanges: BOX
        ''' Reference: http://individuals.interactivebrokers.com/en/trading/orders/priceImprovement.php?ib_entity=llc
        ''' </summary>
        Public Shared Function AuctionLimit(action As String, quantity As Double, price As Double, auctionStrategy As Integer) As Order
            '! [auction_limit]
            Dim order As Order = New Order
            order.Action = action
            order.OrderType = "LMT"
            order.TotalQuantity = quantity
            order.LmtPrice = price
            order.AuctionStrategy = auctionStrategy
            '! [auction_limit]
            Return order
        End Function

        ''' <summary>
        ''' For option orders routed to the Boston Options Exchange (BOX) you may elect to participate in the BOX's price improvement auction in pennies. 
        ''' All BOX-directed price improvement orders are immediately sent from Interactive Brokers to the BOX order book, And when the terms allow, 
        ''' IB will evaluate it for inclusion in a price improvement auction based on price And volume priority. In the auction, your order will have 
        ''' priority over broker-dealer price improvement orders at the same price.
        ''' An Auction Pegged to Stock order adjusts the order price by the product of a signed delta (which Is entered as an absolute And assumed to be 
        ''' positive for calls, negative for puts) And the change of the option's underlying stock price. A buy or sell call order price is determined 
        ''' by adding the delta times a change in an underlying stock price change to a specified starting price for the call. To determine the change 
        ''' in price, a stock reference price (NBBO midpoint at the time of the order Is assumed if no reference price Is entered) Is subtracted from 
        ''' the current NBBO midpoint. A stock range may also be entered that cancels an order when reached. The delta times the change in stock price 
        ''' will be rounded to the nearest penny in favor of the order And will be used as your auction improvement amount.
        ''' Products: OPT
        ''' Supported Exchanges: BOX
        ''' Reference: http://individuals.interactivebrokers.com/en/trading/orders/priceImprovement.php?ib_entity=llc
        ''' </summary>
        Public Shared Function AuctionPeggedToStock(action As String, quantity As Double, startingPrice As Double, delta As Double) As Order
            '! [auction_pegged_stock]
            Dim order As Order = New Order
            order.Action = action
            order.OrderType = "PEG STK"
            order.TotalQuantity = quantity
            order.Delta = delta
            order.StartingPrice = startingPrice
            '! [auction_pegged_stock]
            Return order
        End Function

        ''' <summary>
        ''' For option orders routed to the Boston Options Exchange (BOX) you may elect to participate in the BOX's price improvement auction in pennies. 
        ''' All BOX-directed price improvement orders are immediately sent from Interactive Brokers to the BOX order book, And when the terms allow, 
        ''' IB will evaluate it for inclusion in a price improvement auction based on price And volume priority. In the auction, your order will have 
        ''' priority over broker-dealer price improvement orders at the same price.
        ''' An Auction Relative order that adjusts the order price by the product of a signed delta (which Is entered as an absolute And assumed to be 
        ''' positive for calls, negative for puts) And the change of the option's underlying stock price. A buy or sell call order price is determined 
        ''' by adding the delta times a change in an underlying stock price change to a specified starting price for the call. To determine the change 
        ''' in price, a stock reference price (NBBO midpoint at the time of the order Is assumed if no reference price Is entered) Is subtracted from 
        ''' the current NBBO midpoint. A stock range may also be entered that cancels an order when reached. The delta times the change in stock price 
        ''' will be rounded to the nearest penny in favor of the order And will be used as your auction improvement amount.
        ''' Products: OPT
        ''' Supported Exchanges: BOX
        ''' Reference: http://individuals.interactivebrokers.com/en/trading/orders/priceImprovement.php?ib_entity=llc
        ''' </summary>
        Public Shared Function AuctionRelative(action As String, quantity As Double, offset As Double) As Order
            '! [auction_relative]
            Dim order As Order = New Order
            order.Action = action
            order.OrderType = "REL"
            order.TotalQuantity = quantity
            order.AuxPrice = offset
            '! [auction_relative]
            Return order
        End Function

        ''' <summary>
        ''' The Block attribute Is used for large volume option orders on ISE that consist of at least 50 contracts. To execute large-volume 
        ''' orders over time without moving the market, use the Accumulate/Distribute algorithm.
        ''' Products: OPT
        ''' Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=block
        ''' Reference: http://individuals.interactivebrokers.com/en/trading/orders/block.php?ib_entity=llc
        ''' </summary>
        Public Shared Function Block(action As String, quantity As Double, price As Double) As Order
            '! [block]
            Dim order As Order = New Order
            order.Action = action
            order.OrderType = "LMT"
            order.TotalQuantity = quantity ' Large volumes!
            order.LmtPrice = price
            order.BlockOrder = True
            '! [block]
            Return order
        End Function

        ''' <summary>
        ''' A Box Top order executes as a market order at the current best price. If the order Is only partially filled, the remainder Is submitted as 
        ''' a limit order with the limit price equal to the price at which the filled portion of the order executed.
        ''' Products: OPT
        ''' Supported Exchanges: BOX
        ''' Reference: https://individuals.interactivebrokers.com/en/?f=%2Fen%2Ftrading%2Forders%2Fboxtop.php%3Fib_entity%3Dllc
        ''' </summary>
        Public Shared Function BoxTop(action As String, quantity As Double) As Order
            '! [boxtop]
            Dim order As Order = New Order
            order.Action = action
            order.OrderType = "BOX TOP"
            order.TotalQuantity = quantity
            '! [boxtop]
            Return order
        End Function

        ''' <summary>
        ''' A Limit order Is an order to buy Or sell at a specified price Or better. The Limit order ensures that if the order fills, 
        ''' it will Not fill at a price less favorable than your limit price, but it does Not guarantee a fill.
        ''' Products: BOND, CFD, CASH, FUT, FOP, OPT, STK, WAR
        ''' Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=lmt
        ''' Reference: http://individuals.interactivebrokers.com/en/trading/orders/limit.php?ib_entity=llc
        ''' </summary>
        Public Shared Function LimitOrder(action As String, quantity As Double, limitPrice As Double) As Order
            '! [limitorder]
            Dim order As Order = New Order
            order.Action = action
            order.OrderType = "LMT"
            order.TotalQuantity = quantity
            order.LmtPrice = limitPrice
            '! [limitorder]
            Return order
        End Function

        ''' <summary>
        ''' A Limit if Touched Is an order to buy (Or sell) a contract at a specified price Or better, below (Or above) the market. This order Is 
        ''' held in the system until the trigger price Is touched. An LIT order Is similar to a stop limit order, except that an LIT sell order Is 
        ''' placed above the current market price, And a stop limit sell order Is placed below.
        ''' Products: BOND, CFD, CASH, FUT, FOP, OPT, STK, WAR
        ''' Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=lit
        ''' Reference: http://individuals.interactivebrokers.com/en/trading/orders/lit.php?ib_entity=llc
        ''' </summary>
        Public Shared Function LimitIfTouched(action As String, quantity As Double, limitPrice As Double, triggerPrice As Double) As Order
            '! [limitiftouched]
            Dim order As Order = New Order
            order.Action = action
            order.OrderType = "LIT"
            order.TotalQuantity = quantity
            order.LmtPrice = limitPrice
            order.AuxPrice = triggerPrice
            '! [limitiftouched]
            Return order
        End Function

        ' <summary>
        ' A Limit-on-close (LOC) order will be submitted at the close And will execute if the closing price Is at Or better than the submitted 
        ' limit price.
        ' Products: CFD, FUT, STK, WAR
        ' Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=loc
        ' Reference: http://individuals.interactivebrokers.com/en/trading/orders/loc.php?ib_entity=llc
        ' </summary>
        Public Shared Function LimitOnClose(action As String, quantity As Double, limitPrice As Double) As Order
            '! [limitonclose]
            Dim order As Order = New Order
            order.Action = action
            order.OrderType = "LOC"
            order.TotalQuantity = quantity
            order.LmtPrice = limitPrice
            '! [limitonclose]
            Return order
        End Function

        ''' <summary>
        ''' A Limit-on-Open (LOO) order combines a limit order with the OPG time in force to create an order that Is submitted at the market's open, 
        ''' And that will only execute at the specified limit price Or better. Orders are filled in accordance with specific exchange rules.
        ''' Products: CFD, STK, OPT, WAR
        ''' Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=moo
        ''' Reference: http://individuals.interactivebrokers.com/en/trading/orders/loo.php?ib_entity=llc
        ''' </summary>
        Public Shared Function LimitOnOpen(action As String, quantity As Double, limitPrice As Double) As Order
            '! [limitonopen]
            Dim order As Order = New Order
            order.Action = action
            order.Tif = "OPG"
            order.OrderType = "LMT"
            order.TotalQuantity = quantity
            order.LmtPrice = limitPrice
            '! [limitonopen]
            Return order
        End Function

        ''' <summary>
        ''' Passive Relative orders provide a means for traders to seek a less aggressive price than the National Best Bid And Offer (NBBO) while 
        ''' keeping the order pegged to the best bid (for a buy) Or ask (for a sell). The order price Is automatically adjusted as the markets move 
        ''' to keep the order less aggressive. For a buy order, your order price Is pegged to the NBB by a less aggressive offset, And if the NBB 
        ''' moves up, your bid will also move up. If the NBB moves down, there will be no adjustment because your bid will become aggressive And execute. 
        ''' For a sell order, your price Is pegged to the NBO by a less aggressive offset, And if the NBO moves down, your offer will also move down. 
        ''' If the NBO moves up, there will be no adjustment because your offer will become aggressive And execute. In addition to the offset, you can 
        ''' define an absolute cap, which works Like a limit price, And will prevent your order from being executed above Or below a specified level. 
        ''' The Passive Relative order Is similar to the Relative/Pegged-to-Primary order, except that the Passive relative subtracts the offset from 
        ''' the bid And the Relative adds the offset to the bid.
        ''' Products: STK, WAR
        ''' Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=passvrel
        ''' Reference: http://individuals.interactivebrokers.com/en/trading/orders/passiveRel.php?ib_entity=llc
        ''' </summary>
        Public Shared Function PassiveRelative(action As String, quantity As Double, offset As Double) As Order
            '! [passive_relative]
            Dim order As Order = New Order
            order.Action = action
            order.OrderType = "PASSV REL"
            order.TotalQuantity = quantity
            order.AuxPrice = offset
            '! [passive_relative]
            Return order
        End Function

        ''' <summary>
        ''' A pegged-to-midpoint order provides a means for traders to seek a price at the midpoint of the National Best Bid And Offer (NBBO). 
        ''' The price automatically adjusts to peg the midpoint as the markets move, to remain aggressive. For a buy order, your bid Is pegged to 
        ''' the NBBO midpoint And the order price adjusts automatically to continue to peg the midpoint if the market moves. The price only adjusts 
        ''' to be more aggressive. If the market moves in the opposite direction, the order will execute.
        ''' Products: STK
        ''' Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=pegmid
        ''' Reference: http://individuals.interactivebrokers.com/en/trading/orders/pegmid.php?ib_entity=llc
        ''' </summary>
        Public Shared Function PeggedToMidpoint(action As String, quantity As Double, offset As Double) As Order
            '! [pegged_midpoint]
            Dim order As Order = New Order
            order.Action = action
            order.OrderType = "PEG MID"
            order.TotalQuantity = quantity
            order.AuxPrice = offset
            '! [pegged_midpoint]
            Return order
        End Function

        ''' <summary>
        ''' Bracket orders are designed to help limit your loss And lock in a profit by "bracketing" an order with two opposite-side orders. 
        ''' A BUY order Is bracketed by a high-side sell limit order And a low-side sell stop order. A SELL order Is bracketed by a high-side buy 
        ''' stop order And a low side buy limit order.
        ''' Products: CFD, BAG, FOP, CASH, FUT, OPT, STK, WAR
        ''' Reference: https://individuals.interactivebrokers.com/en/index.php?f=583
        ''' </summary>
        Public Shared Function BracketOrder(parentOrderId As Integer, action As String, quantity As Double, limitPrice As Double,
             takeProfitLimitPrice As Double, stopLossPrice As Double) As List(Of Order)
            '! [bracket]
            'This will be our main Or "parent" order
            Dim parent As Order = New Order
            parent.OrderId = parentOrderId
            parent.Action = action
            parent.OrderType = "LMT"
            parent.TotalQuantity = quantity
            parent.LmtPrice = limitPrice
            'The parent And children orders will need this attribute set to false to prevent accidental executions.
            'The LAST CHILD will have it set to true, 
            parent.Transmit = False

            Dim takeProfit As Order = New Order
            '
            takeProfit.OrderId = parent.OrderId + 1

            If action.Equals("BUY") Then takeProfit.Action = "SELL" Else takeProfit.Action = "BUY"
            takeProfit.OrderType = "LMT"
            takeProfit.TotalQuantity = quantity
            takeProfit.LmtPrice = takeProfitLimitPrice
            takeProfit.ParentId = parentOrderId
            takeProfit.Transmit = False

            Dim stopLoss As Order = New Order
            stopLoss.OrderId = parent.OrderId + 2
            If action.Equals("BUY") Then stopLoss.Action = "SELL" Else stopLoss.Action = "BUY"
            stopLoss.OrderType = "STP"
            'Stop trigger price
            stopLoss.AuxPrice = stopLossPrice
            stopLoss.TotalQuantity = quantity
            stopLoss.ParentId = parentOrderId
            'In this case, the low side order will be the last child being sent. Therefore, it needs to set this attribute to true 
            'to activate all its predecessors
            stopLoss.Transmit = True

            Dim orders As List(Of Order) = New List(Of Order)
            orders.Add(parent)
            orders.Add(takeProfit)
            orders.Add(stopLoss)
            '! [bracket]
            Return orders

        End Function

        ''' <summary>
        ''' Products:CFD, FUT, FOP, OPT, STK, WAR
        ''' A Market-to-Limit (MTL) order Is submitted as a market order to execute at the current best market price. If the order Is only 
        ''' partially filled, the remainder of the order Is canceled And re-submitted as a limit order with the limit price equal to the price 
        ''' at which the filled portion of the order executed.
        ''' Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=mtl
        ''' Reference: http://individuals.interactivebrokers.com/en/trading/orders/mtl.php?ib_entity=llc
        ''' </summary>
        Public Shared Function MarketToLimit(action As String, quantity As Double) As Order
            '! [markettolimit]
            Dim order As Order = New Order
            order.Action = action
            order.OrderType = "MTL"
            order.TotalQuantity = quantity
            '! [markettolimit]
            Return order
        End Function

        ''' <summary>
        ''' This order type Is useful for futures traders using Globex. A Market with Protection order Is a market order that will be cancelled And 
        ''' resubmitted as a limit order if the entire order does Not immediately execute at the market price. The limit price Is set by Globex to be 
        ''' close to the current market price, slightly higher for a sell order And lower for a buy order.
        ''' Products: FUT, FOP
        ''' Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=mktprot
        ''' Reference: http://individuals.interactivebrokers.com/en/trading/orders/marketProtect.php?ib_entity=llc
        ''' </summary>
        Public Shared Function MarketWithProtection(action As String, quantity As Double) As Order
            '! [marketwithprotection]
            Dim order As Order = New Order
            order.Action = action
            order.OrderType = "MKT PRT"
            order.TotalQuantity = quantity
            '! [marketwithprotection]
            Return order
        End Function

        ''' <summary>
        ''' A Stop order Is an instruction to submit a buy Or sell market order if And when the user-specified stop trigger price Is attained Or 
        ''' penetrated. A Stop order Is Not guaranteed a specific execution price And may execute significantly away from its stop price. A Sell 
        ''' Stop order Is always placed below the current market price And Is typically used to limit a loss Or protect a profit on a long stock 
        ''' position. A Buy Stop order Is always placed above the current market price. It Is typically used to limit a loss Or help protect a 
        ''' profit on a short sale.
        ''' Products: CFD, BAG, CASH, FUT, FOP, OPT, STK, WAR
        ''' Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=stp
        ''' Reference: http://individuals.interactivebrokers.com/en/trading/orders/stop.php?ib_entity=llc
        ''' </summary>
        Public Shared Function StopOrder(action As String, quantity As Double, stopPrice As Double) As Order
            '! [stop]
            Dim order As Order = New Order
            order.Action = action
            order.OrderType = "STP"
            order.AuxPrice = stopPrice
            order.TotalQuantity = quantity
            '! [stop]
            Return order
        End Function

        ''' <summary>
        ''' A Stop-Limit order Is an instruction to submit a buy Or sell limit order when the user-specified stop trigger price Is attained Or 
        ''' penetrated. The order has two basic components: the stop price And the limit price. When a trade has occurred at Or through the stop 
        ''' price, the order becomes executable And enters the market as a limit order, which Is an order to buy Or sell at a specified price Or better.
        ''' Products: CFD, CASH, FUT, FOP, OPT, STK, WAR
        ''' Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=stplmt
        ''' Reference: http://individuals.interactivebrokers.com/en/trading/orders/stopLimit.php?ib_entity=llc
        ''' </summary>
        Public Shared Function StopLimit(action As String, quantity As Double, limitPrice As Double, stopPrice As Double) As Order
            '! [stoplimit]
            Dim order As Order = New Order
            order.Action = action
            order.OrderType = "STP LMT"
            order.TotalQuantity = quantity
            order.LmtPrice = limitPrice
            order.AuxPrice = stopPrice
            '! [stoplimit]
            Return order
        End Function

        ''' <summary>
        ''' A Stop with Protection order combines the functionality of a stop limit order with a market with protection order. The order Is set 
        ''' to trigger at a specified stop price. When the stop price Is penetrated, the order Is triggered as a market with protection order, 
        ''' which means that it will fill within a specified protected price range equal to the trigger price +/- the exchange-defined protection 
        ''' point range. Any portion of the order that does Not fill within this protected range Is submitted as a limit order at the exchange-defined 
        ''' trigger price +/- the protection points.
        ''' Products: FUT
        ''' Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=stpprot
        ''' Reference: http://individuals.interactivebrokers.com/en/trading/orders/stopProtect.php?ib_entity=llc
        ''' </summary>
        Public Shared Function StopWithProtection(action As String, quantity As Double, stopPrice As Double) As Order
            '! [stopwithprotection]
            Dim order As Order = New Order
            order.TotalQuantity = quantity
            order.Action = action
            order.OrderType = "STP PRT"
            order.AuxPrice = stopPrice
            '! [stopwithprotection]
            Return order
        End Function

        ''' <summary>
        ''' A sell trailing stop order sets the stop price at a fixed amount below the market price with an attached "trailing" amount. As the 
        ''' market price rises, the stop price rises by the trail amount, but if the stock price falls, the stop loss price doesn'''t change, 
        ''' And a market order Is submitted when the stop price Is hit. This technique Is designed to allow an investor to specify a limit on the 
        ''' maximum possible loss, without setting a limit on the maximum possible gain. "Buy" trailing stop orders are the mirror image of sell 
        ''' trailing stop orders, And are most appropriate for use in falling markets.
        ''' Products: CFD, CASH, FOP, FUT, OPT, STK, WAR
        ''' Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=trail
        ''' Reference: http://individuals.interactivebrokers.com/en/trading/orders/trailingStops.php?ib_entity=llc
        ''' </summary>
        Public Shared Function TrailingStop(action As String, quantity As Double, trailingPercent As Double, trailStopPrice As Double) As Order
            '! [trailingstop]
            Dim order As Order = New Order
            order.Action = action
            order.OrderType = "TRAIL"
            order.TotalQuantity = quantity
            order.TrailingPercent = trailingPercent
            order.TrailStopPrice = trailStopPrice
            '! [trailingstop]
            Return order
        End Function

        ''' <summary>
        ''' A trailing stop limit order is designed to allow an investor to specify a limit on the maximum possible loss, without setting a limit 
        ''' on the maximum possible gain. A SELL trailing stop limit moves with the market price, and continually recalculates the stop trigger 
        ''' price at a fixed amount below the market price, based on the user-defined "trailing" amount. The limit order price is also continually 
        ''' recalculated based on the limit offset. As the market price rises, both the stop price and the limit price rise by the trail amount and 
        ''' limit offset respectively, but if the stock price falls, the stop price remains unchanged, and when the stop price is hit a limit order 
        ''' is submitted at the last calculated limit price. A "Buy" trailing stop limit order is the mirror image of a sell trailing stop limit, 
        ''' and is generally used in falling markets.
        ''' Products: BOND, CFD, CASH, FUT, FOP, OPT, STK, WAR
        ''' Reference: http://individuals.interactivebrokers.com/en/trading/orders/trailingStopLimit.php?ib_entity=llc
        ''' </summary>
        Public Shared Function TrailingStopLimit(action As String, quantity As Double, limitPrice As Double, trailingAmount As Double, trailStopPrice As Double) As Order
            '! [trailingstoplimit]
            Dim order As Order = New Order
            order.Action = action
            order.OrderType = "TRAIL LIMIT"
            order.TotalQuantity = quantity
            order.TrailStopPrice = trailStopPrice
            order.LmtPrice = limitPrice
            order.AuxPrice = trailingAmount
            '![trailingstoplimit]
            Return order
        End Function

        ''' <summary>
        ''' Create combination orders that include options, stock and futures legs (stock legs can be included if the order is routed 
        ''' through SmartRouting). Although a combination/spread order is constructed of separate legs, it is executed as a single transaction 
        ''' if it is routed directly to an exchange. For combination orders that are SmartRouted, each leg may be executed separately to ensure 
        ''' best execution.
        ''' Products: OPT, STK, FUT
        ''' </summary>
        Public Shared Function ComboLimitOrder(action As String, quantity As Double, limitPrice As Double, nonGuaranteed As Boolean) As Order
            '! [combolimit]
            Dim order As Order = New Order
            order.Action = action
            order.OrderType = "LMT"
            order.TotalQuantity = quantity
            order.LmtPrice = limitPrice
            If (nonGuaranteed) Then
                order.SmartComboRoutingParams = New List(Of TagValue)
                order.SmartComboRoutingParams.Add(New TagValue("NonGuaranteed", "1"))
            End If
            '! [combolimit]
            Return order
        End Function

        ''' <summary>
        ''' Create combination orders that include options, stock and futures legs (stock legs can be included if the order is routed 
        ''' through SmartRouting). Although a combination/spread order is constructed of separate legs, it is executed as a single transaction 
        ''' if it is routed directly to an exchange. For combination orders that are SmartRouted, each leg may be executed separately to ensure 
        ''' best execution.
        ''' Products: OPT, STK, FUT
        ''' </summary>
        Public Shared Function ComboMarketOrder(action As String, quantity As Double, nonGuaranteed As Boolean) As Order
            '! [combomarket]
            Dim order As Order = New Order
            order.Action = action
            order.OrderType = "MKT"
            order.TotalQuantity = quantity
            If (nonGuaranteed) Then

                order.SmartComboRoutingParams = New List(Of TagValue)
                order.SmartComboRoutingParams.Add(New TagValue("NonGuaranteed", "1"))
            End If
            '! [combomarket]
            Return order
        End Function

        ''' <summary>
        ''' Create combination orders that include options, stock and futures legs (stock legs can be included if the order is routed 
        ''' through SmartRouting). Although a combination/spread order is constructed of separate legs, it is executed as a single transaction 
        ''' if it is routed directly to an exchange. For combination orders that are SmartRouted, each leg may be executed separately to ensure 
        ''' best execution.
        ''' Products: OPT, STK, FUT
        ''' </summary>
        Public Shared Function LimitOrderForComboWithLegPrices(action As String, quantity As Double, legPrices As Double(), nonGuaranteed As Boolean) As Order
            '! [limitordercombolegprices]
            Dim order As Order = New Order
            order.Action = action
            order.OrderType = "LMT"
            order.TotalQuantity = quantity
            order.OrderComboLegs = New List(Of OrderComboLeg)
            For Each price As Double In legPrices
                Dim ComboLeg As OrderComboLeg = New OrderComboLeg
                ComboLeg.Price = 5.0
                order.OrderComboLegs.Add(ComboLeg)
            Next price

            If (nonGuaranteed) Then
                order.SmartComboRoutingParams = New List(Of TagValue)
                order.SmartComboRoutingParams.Add(New TagValue("NonGuaranteed", "1"))
            End If
            '! [limitordercombolegprices]
            Return order
        End Function

        ''' <summary>
        ''' Create combination orders that include options, stock and futures legs (stock legs can be included if the order is routed 
        ''' through SmartRouting). Although a combination/spread order is constructed of separate legs, it is executed as a single transaction 
        ''' if it is routed directly to an exchange. For combination orders that are SmartRouted, each leg may be executed separately to ensure 
        ''' best execution.
        ''' Products: OPT, STK, FUT
        ''' </summary>
        Public Shared Function RelativeLimitCombo(action As String, quantity As Double, limitPrice As Double, nonGuaranteed As Boolean) As Order
            '! [relativelimitcombo]
            Dim order As Order = New Order
            order.Action = action
            order.TotalQuantity = quantity
            order.OrderType = "REL + LMT"
            order.LmtPrice = limitPrice
            If (nonGuaranteed) Then
                order.SmartComboRoutingParams = New List(Of TagValue)
                order.SmartComboRoutingParams.Add(New TagValue("NonGuaranteed", "1"))
            End If
            '! [relativelimitcombo]
            Return order
        End Function

        ''' <summary>
        ''' Create combination orders that include options, stock and futures legs (stock legs can be included if the order is routed 
        ''' through SmartRouting). Although a combination/spread order is constructed of separate legs, it is executed as a single transaction 
        ''' if it is routed directly to an exchange. For combination orders that are SmartRouted, each leg may be executed separately to ensure 
        ''' best execution.
        ''' Products: OPT, STK, FUT
        ''' </summary>
        Public Shared Function RelativeMarketCombo(action As String, quantity As Double, nonGuaranteed As Boolean) As Order
            '! [relativemarketcombo]
            Dim order As Order = New Order
            order.Action = action
            order.TotalQuantity = quantity
            order.OrderType = "REL + MKT"
            If (nonGuaranteed) Then

                order.SmartComboRoutingParams = New List(Of TagValue)
                order.SmartComboRoutingParams.Add(New TagValue("NonGuaranteed", "1"))
            End If
            '! [relativemarketcombo]
            Return order
        End Function

        ''' <summary>
        ''' One-Cancels All (OCA) order type allows an investor to place multiple and possibly unrelated orders assigned to a group. The aim is 
        ''' to complete just one of the orders, which in turn will cause TWS to cancel the remaining orders. The investor may submit several 
        ''' orders aimed at taking advantage of the most desirable price within the group. Completion of one piece of the group order causes 
        ''' cancellation of the remaining group orders while partial completion causes the group to rebalance. An investor might desire to sell 
        ''' 1000 shares of only ONE of three positions held above prevailing market prices. The OCA order group allows the investor to enter prices 
        ''' at specified target levels and if one is completed, the other two will automatically cancel. Alternatively, an investor may wish to take 
        ''' a LONG position in eMini S&P stock index futures in a falling market or else SELL US treasury futures at a more favorable price. 
        ''' Grouping the two orders using an OCA order type offers the investor two chance to enter a similar position, while only running the risk 
        ''' of taking on a single position.
        ''' Products: BOND, CASH, FUT, FOP, STK, OPT, WAR
        ''' Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=oca
        ''' Reference: http://individuals.interactivebrokers.com/en/trading/orders/oca.php?ib_entity=llc
        ''' </summary>
        Public Shared Function OneCancelsAll(ocaGroup As String, ocaOrders As List(Of Order), ocaType As Integer) As List(Of Order)
            '! [one_cancels_all]
            For Each o As Order In ocaOrders

                o.OcaGroup = ocaGroup
                o.OcaType = ocaType
                'Same as with Bracket orders. To prevent accidental executions, set all orders' transmit flag to false.
                'This will tell the TWS Not to send the orders, allowing your program to send them all first.
                o.Transmit = False
            Next o

            'Telling the TWS to transmit the last order in the OCA will also cause the transmission of its predecessors.
            ocaOrders.Item(ocaOrders.Count - 1).Transmit = True
            '! [one_cancels_all]
            Return ocaOrders

        End Function

        ''' <summary>
        ''' Specific to US options, investors are able to create and enter Volatility-type orders for options and combinations rather than price orders. 
        ''' Option traders may wish to trade and position for movements in the price of the option determined by its implied volatility. Because 
        ''' implied volatility is a key determinant of the premium on an option, traders position in specific contract months in an effort to take 
        ''' advantage of perceived changes in implied volatility arising before, during or after earnings or when company specific or broad market 
        ''' volatility is predicted to change. In order to create a Volatility order, clients must first create a Volatility Trader page from the 
        ''' Trading Tools menu and as they enter option contracts, premiums will display in percentage terms rather than premium. The buy/sell process 
        ''' is the same as for regular orders priced in premium terms except that the client can limit the volatility level they are willing to pay or 
        ''' receive.
        ''' Products: FOP, OPT
        ''' Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=volat
        ''' Reference: http://individuals.interactivebrokers.com/en/trading/orders/vol.php?ib_entity=llc
        ''' </summary>
        Public Shared Function Volatility(action As String, quantity As Double, volatilityPercent As Double, volatilityType As Integer) As Order
            '! [volatility]
            Dim order As Order = New Order
            order.Action = action
            order.OrderType = "VOL"
            order.TotalQuantity = quantity
            order.Volatility = volatilityPercent  'Expressed in percentage (40%)
            order.VolatilityType = volatilityType  ' 1=daily, 2=annual
            '! [volatility]
            Return order

        End Function

        '! [fhedge]
        Public Shared Function MarketFHedge(parentOrderId As Integer, action As String) As Order

            'FX Hedge orders can only have a quantity of 0
            Dim Order As Order = MarketOrder(action, 0)
            Order.ParentId = parentOrderId
            Order.HedgeType = "F"
            Return Order
        End Function
        '! [fhedge]

        Public Shared Function PeggedToBenchmark(action As String, quantity As Double, startingPrice As Double, peggedChangeAmountDecrease As Boolean, peggedChangeAmount As Double,
              referenceChangeAmount As Double, referenceConId As Integer, referenceExchange As String, stockReferencePrice As Double,
             referenceContractLowerRange As Double, referenceContractUpperRange As Double) As Order

            '! [pegged_benchmark]
            Dim order As Order = New Order
            order.OrderType = "PEG BENCH"
            'BUY Or SELL
            order.Action = action
            order.TotalQuantity = quantity
            'Beginning with price...
            order.StartingPrice = startingPrice
            'increase/decrease price..
            order.IsPeggedChangeAmountDecrease = peggedChangeAmountDecrease
            'by... (And likewise for price moving in opposite direction)
            order.PeggedChangeAmount = peggedChangeAmount
            'whenever there Is a price change of...
            order.ReferenceChangeAmount = referenceChangeAmount
            'in the reference contract...
            order.ReferenceContractId = referenceConId
            'being traded at...
            order.ReferenceExchange = referenceExchange
            'starting reference price Is...
            order.StockRefPrice = stockReferencePrice
            'Keep order active as long as reference contract trades between...
            order.StockRangeLower = referenceContractLowerRange
            'And...
            order.StockRangeUpper = referenceContractUpperRange
            '! [pegged_benchmark]
            Return order
        End Function


        Public Shared Function AttachAdjustableToStop(parent As Order, attachedOrderStopPrice As Double, triggerPrice As Double, adjustStopPrice As Double) As Order

            '! [adjustable_stop]
            'Attached order Is a conventional STP order in opposite direction
            Dim action As String = "BUY"
            If (parent.Action.Equals("BUY")) Then
                action = "SELL"
            End If
            Dim order As Order = StopOrder(action, parent.TotalQuantity, attachedOrderStopPrice)
            order.ParentId = parent.OrderId
            'When trigger price Is penetrated
            order.TriggerPrice = triggerPrice
            'The parent order will be turned into a STP order
            order.AdjustedOrderType = "STP"
            'With the given STP price
            order.AdjustedStopPrice = adjustStopPrice
            '! [adjustable_stop]
            Return order
        End Function

        Public Shared Function AttachAdjustableToStopLimit(parent As Order, attachedOrderStopPrice As Double, triggerPrice As Double,
             adjustedStopPrice As Double, adjustedStopLimitPrice As Double) As Order

            '! [adjustable_stop_limit]
            'Attached order Is a conventional STP order
            Dim action As String = "BUY"
            If (parent.Action.Equals("BUY")) Then
                action = "SELL"
            End If
            Dim order As Order = StopOrder(action, parent.TotalQuantity, attachedOrderStopPrice)
            order.ParentId = parent.OrderId
            'When trigger price Is penetrated
            order.TriggerPrice = triggerPrice
            'The parent order will be turned into a STP LMT order
            order.AdjustedOrderType = "STP LMT"
            'With the given stop price
            order.AdjustedStopPrice = adjustedStopPrice
            'And the given limit price
            order.AdjustedStopLimitPrice = adjustedStopLimitPrice
            '! [adjustable_stop_limit]
            Return order
        End Function

        Public Shared Function PriceCondition(conId As Integer, exchange As String, price As Double, isMore As Boolean, isConjunction As Boolean) As PriceCondition

            '! [price_condition]
            'Conditions have to be created via the OrderCondition.Create 
            Dim _priceCondition As PriceCondition = OrderCondition.Create(OrderConditionType.Price) 'cast to priceCondition
            'When this contract...
            _priceCondition.ConId = conId
            'traded on this exchange
            _priceCondition.Exchange = exchange
            'has a price above/below
            _priceCondition.IsMore = isMore
            'this quantity
            _priceCondition.Price = price
            'And | Or next condition (will be ignored if no more conditions are added)
            _priceCondition.IsConjunctionConnection = isConjunction
            '! [price_condition]
            Return _priceCondition
        End Function

        Public Shared Function ExecutionCondition(symbol As String, secType As String, exchange As String, isConjunction As Boolean) As ExecutionCondition

            '! [execution_condition]
            Dim execCondition As ExecutionCondition = OrderCondition.Create(OrderConditionType.Execution) ' cast to (ExecutionCondition)
            'When an execution on symbol
            execCondition.Symbol = symbol
            'at exchange
            execCondition.Exchange = exchange
            'for this secType
            execCondition.SecType = secType
            'And | Or next condition (will be ignored if no more conditions are added)
            execCondition.IsConjunctionConnection = isConjunction
            '! [execution_condition]
            Return execCondition
        End Function

        Public Shared Function MarginCondition(percent As Integer, isMore As Boolean, isConjunction As Boolean) As MarginCondition

            '! [margin_condition]
            Dim _MarginCondition As MarginCondition = OrderCondition.Create(OrderConditionType.Margin) ' cast to (MarginCondition)
            'If margin Is above/below
            _MarginCondition.IsMore = isMore
            'given percent
            _MarginCondition.Percent = percent
            'And | Or next condition (will be ignored if no more conditions are added)
            _MarginCondition.IsConjunctionConnection = isConjunction
            '! [margin_condition]
            Return _MarginCondition
        End Function

        Public Shared Function PercentageChangeCondition(pctChange As Double, conId As Integer, exchange As String, isMore As Boolean, isConjunction As Boolean) As PercentChangeCondition

            '! [percentage_condition]
            Dim pctChangeCondition As PercentChangeCondition = OrderCondition.Create(OrderConditionType.PercentCange) 'cast (PercentChangeCondition)
            'If there Is a price percent change measured against last close price above Or below...
            pctChangeCondition.IsMore = isMore
            'this amount...
            pctChangeCondition.ChangePercent = pctChange
            'on this contract
            pctChangeCondition.ConId = conId
            'when traded on this exchange...
            pctChangeCondition.Exchange = exchange
            'And | Or next condition (will be ignored if no more conditions are added)
            pctChangeCondition.IsConjunctionConnection = isConjunction
            '! [percentage_condition]
            Return pctChangeCondition
        End Function

        Public Shared Function TimeCondition(time As String, isMore As Boolean, isConjunction As Boolean) As TimeCondition

            '! [time_condition]
            Dim _TimeCondition As TimeCondition = OrderCondition.Create(OrderConditionType.Time) 'cast (timeCondition)
            'Before Or after...
            _TimeCondition.IsMore = isMore
            'this time..
            _TimeCondition.Time = time
            'And | Or next condition (will be ignored if no more conditions are added)     
            _TimeCondition.IsConjunctionConnection = isConjunction
            '! [time_condition]
            Return _TimeCondition
        End Function

        Public Shared Function VolumeCondition(conId As Integer, exchange As String, isMore As Boolean, volume As Integer, isConjunction As Boolean) As VolumeCondition

            '! [volume_condition]
            Dim volCond As VolumeCondition = OrderCondition.Create(OrderConditionType.Volume) 'cast (VolumeCondition)
            'Whenever contract...
            volCond.ConId = conId
            'When traded at
            volCond.Exchange = exchange
            'reaches a volume higher/lower
            volCond.IsMore = isMore
            'than this...
            volCond.Volume = volume
            'And | Or next condition (will be ignored if no more conditions are added)
            volCond.IsConjunctionConnection = isConjunction
            '! [volume_condition]
            Return volCond

        End Function

    End Class

End Namespace
