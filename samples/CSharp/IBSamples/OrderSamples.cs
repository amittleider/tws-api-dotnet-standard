/* Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBApi;

namespace Samples
{
    /// <summary>
    /// Make sure to test using only your paper trading account when applicable. A good way of finding out if an order type/exchange combination
    /// is possible is by trying to place such order manually using the TWS.
    /// Before contacting our API support team please refer to the available documentation.
    /// </summary>
    public class OrderSamples
    {
        /// <summary>
        /// An auction order is entered into the electronic trading system during the pre-market opening period for execution at the 
        /// Calculated Opening Price (COP). If your order is not filled on the open, the order is re-submitted as a limit order with 
        /// the limit price set to the COP or the best bid/ask after the market opens.
        /// Products: FUT, STK
        /// Supported Exchanges: https://individuals.interactivebrokers.com/en/?f=%2Fen%2Ftrading%2ForderTypeExchanges.php%3Fot%3Dauc
        /// Reference: http://individuals.interactivebrokers.com/en/trading/orders/auction.php?ib_entity=llc
        /// </summary>
        public static Order AtAuction(string action, double quantity, double price)
        {
            Order order = new Order();
            order.Action = action;
            order.Tif = "AUC";
            order.OrderType = "MTL";
            order.TotalQuantity = quantity;
            order.LmtPrice = price;
            return order;
        }

        /// <summary>
        /// A Discretionary order is a limit order submitted with a hidden, specified 'discretionary' amount off the limit price which
        /// may be used to increase the price range over which the limit order is eligible to execute. The market sees only the limit price.
        /// Products: STK
        /// Supported Exchanges: https://individuals.interactivebrokers.com/en/?f=%2Fen%2Ftrading%2ForderTypeExchanges.php%3Fot%3Ddis
        /// Reference: http://individuals.interactivebrokers.com/en/trading/orders/discretionary.php?ib_entity=llc
        /// </summary>
        public static Order Discretionary(string action, double quantity, double price, double discretionaryAmount)
        {
            Order order = new Order();
            order.Action = action;
            order.OrderType = "LMT";
            order.TotalQuantity = quantity;
            order.LmtPrice = price;
            order.DiscretionaryAmt = discretionaryAmount;
            return order;
        }

        /// <summary>
        /// A Market order is an order to buy or sell at the market bid or offer price. A market order may increase the likelihood of a fill 
        /// and the speed of execution, but unlike the Limit order a Market order provides no price protection and may fill at a price far 
        /// lower/higher than the current displayed bid/ask.
        /// Products: BOND, CFD, EFP, CASH, FUND, FUT, FOP, OPT, STK, WAR
        /// Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=mkt
        /// Reference: http://individuals.interactivebrokers.com/en/trading/orders/market.php?ib_entity=llc
        /// </summary>
        public static Order MarketOrder(string action, double quantity)
        {
            Order order = new Order();
            order.Action = action;
            order.OrderType = "MKT";
            order.TotalQuantity = quantity;
            return order;
        }

        /// <summary>
        /// A Market if Touched (MIT) is an order to buy (or sell) a contract below (or above) the market. Its purpose is to take advantage 
        /// of sudden or unexpected changes in share or other prices and provides investors with a trigger price to set an order in motion. 
        /// Investors may be waiting for excessive strength (or weakness) to cease, which might be represented by a specific price point. 
        /// MIT orders can be used to determine whether or not to enter the market once a specific price level has been achieved. This order 
        /// is held in the system until the trigger price is touched, and is then submitted as a market order. An MIT order is similar to a 
        /// stop order, except that an MIT sell order is placed above the current market price, and a stop sell order is placed below
        /// Products: BOND, CFD, CASH, FUT, FOP, OPT, STK, WAR
        /// Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=mit
        /// Reference: http://individuals.interactivebrokers.com/en/trading/orders/mit.php?ib_entity=llc
        /// </summary>
        public static Order MarketIfTouched(string action, double quantity, double price)
        {
            Order order = new Order();
            order.Action = action;
            order.OrderType = "MIT";
            order.TotalQuantity = quantity;
            order.AuxPrice = price;
            return order;
        }

        /// <summary>
        /// A Market-on-Close (MOC) order is a market order that is submitted to execute as close to the closing price as possible.
        /// Products: CFD, FUT, STK, WAR
        /// Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=moc
        /// Reference: http://individuals.interactivebrokers.com/en/trading/orders/moc.php?ib_entity=llc
        /// </summary>
        public static Order MarketOnClose(string action, double quantity)
        {
            Order order = new Order();
            order.Action = action;
            order.OrderType = "MOC";
            order.TotalQuantity = quantity;
            return order;
        }

        /// <summary>
        /// A Market-on-Open (MOO) order combines a market order with the OPG time in force to create an order that is automatically
        /// submitted at the market's open and fills at the market price.
        /// Products: CFD, STK, OPT, WAR
        /// Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=moo
        /// Reference: http://individuals.interactivebrokers.com/en/trading/orders/moo.php?ib_entity=llc
        /// </summary>
        public static Order MarketOnOpen(string action, double quantity)
        {
            Order order = new Order();
            order.Action = action;
            order.OrderType = "MKT";
            order.TotalQuantity = quantity;
            order.Tif = "OPG";
            return order;
        }

        /// <summary>
        /// ISE Midpoint Match (MPM) orders always execute at the midpoint of the NBBO. You can submit market and limit orders direct-routed 
        /// to ISE for MPM execution. Market orders execute at the midpoint whenever an eligible contra-order is available. Limit orders 
        /// execute only when the midpoint price is better than the limit price. Standard MPM orders are completely anonymous.
        /// Products: STK
        /// Supported Exchanges: ISE
        /// Reference: http://individuals.interactivebrokers.com/en/trading/orders/mpm.php?ib_entity=llc
        /// </summary>
        public static Order MidpointMatch(string action, double quantity)
        {
            Order order = new Order();
            order.Action = action;
            order.OrderType = "MKT";
            order.TotalQuantity = quantity;
            return order;
        }

        /// <summary>
        /// A pegged-to-market order is designed to maintain a purchase price relative to the national best offer (NBO) or a sale price 
        /// relative to the national best bid (NBB). Depending on the width of the quote, this order may be passive or aggressive. 
        /// The trader creates the order by entering a limit price which defines the worst limit price that they are willing to accept. 
        /// Next, the trader enters an offset amount which computes the active limit price as follows:
        ///     Sell order price = Bid price + offset amount
        ///     Buy order price = Ask price - offset amount
        /// Products: STK
        /// Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=pegmkt
        /// Reference: http://individuals.interactivebrokers.com/en/trading/orders/peggedMarket.php?ib_entity=llc
        /// </summary>
        public static Order PeggedToMarket(string action, double quantity, double marketOffset)
        {
            Order order = new Order();
            order.Action = action;
            order.OrderType = "PEG MKT";
            order.TotalQuantity = 100;
            order.AuxPrice = marketOffset;//Offset price
            return order;
        }

        /// <summary>
        /// A Pegged to Stock order continually adjusts the option order price by the product of a signed user-define delta and the change of 
        /// the option's underlying stock price. The delta is entered as an absolute and assumed to be positive for calls and negative for puts. 
        /// A buy or sell call order price is determined by adding the delta times a change in an underlying stock price to a specified starting 
        /// price for the call. To determine the change in price, the stock reference price is subtracted from the current NBBO midpoint. 
        /// The Stock Reference Price can be defined by the user, or defaults to the NBBO midpoint at the time of the order if no reference price 
        /// is entered. You may also enter a high/low stock price range which cancels the order when reached. The delta times the change in stock 
        /// price will be rounded to the nearest penny in favor of the order.
        /// Products: OPT
        /// Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=relstk
        /// Reference: http://individuals.interactivebrokers.com/en/trading/orders/peggedStock.php?ib_entity=llc
        /// </summary>
        public static Order PeggedToStock(string action, double quantity, double delta, double stockReferencePrice, double startingPrice)
        {
            Order order = new Order();
            order.Action = action;
            order.OrderType = "PEG STK";
            order.TotalQuantity = quantity;
            order.Delta = delta;
            order.LmtPrice = stockReferencePrice;
            order.StartingPrice = startingPrice;
            return order;
        }

        /// <summary>
        /// Relative (a.k.a. Pegged-to-Primary) orders provide a means for traders to seek a more aggressive price than the National Best Bid 
        /// and Offer (NBBO). By acting as liquidity providers, and placing more aggressive bids and offers than the current best bids and offers, 
        /// traders increase their odds of filling their order. Quotes are automatically adjusted as the markets move, to remain aggressive. 
        /// For a buy order, your bid is pegged to the NBB by a more aggressive offset, and if the NBB moves up, your bid will also move up. 
        /// If the NBB moves down, there will be no adjustment because your bid will become even more aggressive and execute. For sales, your 
        /// offer is pegged to the NBO by a more aggressive offset, and if the NBO moves down, your offer will also move down. If the NBO moves up, 
        /// there will be no adjustment because your offer will become more aggressive and execute. In addition to the offset, you can define an 
        /// absolute cap, which works like a limit price, and will prevent your order from being executed above or below a specified level.
        /// Stocks, Options and Futures - not available on paper trading
        /// Products: CFD, STK, OPT, FUT
        /// Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=rel
        /// Reference: http://individuals.interactivebrokers.com/en/trading/orders/relative.php?ib_entity=llc
        /// </summary>
        public static Order RelativePeggedToPrimary(string action, double quantity, double priceCap, double offsetAmount)
        {
            Order order = new Order();
            order.Action = action;
            order.OrderType = "REL";
            order.TotalQuantity = quantity;
            order.LmtPrice = priceCap;
            order.AuxPrice = offsetAmount;
            return order;
        }

        /// <summary>
        /// Sweep-to-fill orders are useful when a trader values speed of execution over price. A sweep-to-fill order identifies the best price 
        /// and the exact quantity offered/available at that price, and transmits the corresponding portion of your order for immediate execution. 
        /// Simultaneously it identifies the next best price and quantity offered/available, and submits the matching quantity of your order for 
        /// immediate execution.
        /// Products: CFD, STK, WAR
        /// Supported Exchanges: SMART
        /// Reference: http://individuals.interactivebrokers.com/en/trading/orders/sweep.php?ib_entity=llc
        /// </summary>
        public static Order SweepToFill(string action, double quantity, double price)
        {
            Order order = new Order();
            order.Action = action;
            order.OrderType = "LMT";
            order.TotalQuantity = quantity;
            order.LmtPrice = price;
            order.SweepToFill = true;
            return order;
        }

        /// <summary>
        /// For option orders routed to the Boston Options Exchange (BOX) you may elect to participate in the BOX's price improvement auction in 
        /// pennies. All BOX-directed price improvement orders are immediately sent from Interactive Brokers to the BOX order book, and when the 
        /// terms allow, IB will evaluate it for inclusion in a price improvement auction based on price and volume priority. In the auction, your 
        /// order will have priority over broker-dealer price improvement orders at the same price.
        /// An Auction Limit order at a specified price. Use of a limit order ensures that you will not receive an execution at a price less favorable 
        /// than the limit price. Enter limit orders in penny increments with your auction improvement amount computed as the difference between your 
        /// limit order price and the nearest listed increment.
        /// Products: OPT
        /// Supported Exchanges: BOX
        /// Reference: http://individuals.interactivebrokers.com/en/trading/orders/priceImprovement.php?ib_entity=llc
        /// </summary>
        public static Order AuctionLimit(string action, double quantity, double price, int auctionStrategy)
        {
            Order order = new Order();
            order.Action = action;
            order.OrderType = "LMT";
            order.TotalQuantity = quantity;
            order.LmtPrice = price;
            order.AuctionStrategy = auctionStrategy;
            return order;
        }

        /// <summary>
        /// For option orders routed to the Boston Options Exchange (BOX) you may elect to participate in the BOX's price improvement auction in pennies. 
        /// All BOX-directed price improvement orders are immediately sent from Interactive Brokers to the BOX order book, and when the terms allow, 
        /// IB will evaluate it for inclusion in a price improvement auction based on price and volume priority. In the auction, your order will have 
        /// priority over broker-dealer price improvement orders at the same price.
        /// An Auction Pegged to Stock order adjusts the order price by the product of a signed delta (which is entered as an absolute and assumed to be 
        /// positive for calls, negative for puts) and the change of the option's underlying stock price. A buy or sell call order price is determined 
        /// by adding the delta times a change in an underlying stock price change to a specified starting price for the call. To determine the change 
        /// in price, a stock reference price (NBBO midpoint at the time of the order is assumed if no reference price is entered) is subtracted from 
        /// the current NBBO midpoint. A stock range may also be entered that cancels an order when reached. The delta times the change in stock price 
        /// will be rounded to the nearest penny in favor of the order and will be used as your auction improvement amount.
        /// Products: OPT
        /// Supported Exchanges: BOX
        /// Reference: http://individuals.interactivebrokers.com/en/trading/orders/priceImprovement.php?ib_entity=llc
        /// </summary>
        public static Order AuctionPeggedToStock(string action, double quantity, double startingPrice, double delta)
        {
            Order order = new Order();
            order.Action = action;
            order.OrderType = "PEG STK";
            order.TotalQuantity = quantity;
            order.Delta = delta;
            order.StartingPrice = startingPrice;
            return order;
        }

        /// <summary>
        /// For option orders routed to the Boston Options Exchange (BOX) you may elect to participate in the BOX's price improvement auction in pennies. 
        /// All BOX-directed price improvement orders are immediately sent from Interactive Brokers to the BOX order book, and when the terms allow, 
        /// IB will evaluate it for inclusion in a price improvement auction based on price and volume priority. In the auction, your order will have 
        /// priority over broker-dealer price improvement orders at the same price.
        /// An Auction Relative order that adjusts the order price by the product of a signed delta (which is entered as an absolute and assumed to be 
        /// positive for calls, negative for puts) and the change of the option's underlying stock price. A buy or sell call order price is determined 
        /// by adding the delta times a change in an underlying stock price change to a specified starting price for the call. To determine the change 
        /// in price, a stock reference price (NBBO midpoint at the time of the order is assumed if no reference price is entered) is subtracted from 
        /// the current NBBO midpoint. A stock range may also be entered that cancels an order when reached. The delta times the change in stock price 
        /// will be rounded to the nearest penny in favor of the order and will be used as your auction improvement amount.
        /// Products: OPT
        /// Supported Exchanges: BOX
        /// Reference: http://individuals.interactivebrokers.com/en/trading/orders/priceImprovement.php?ib_entity=llc
        /// </summary>
        public static Order AuctionRelative(string action, double quantity, double offset)
        {
            Order order = new Order();
            order.Action = action;
            order.OrderType = "REL";
            order.TotalQuantity = quantity;
            order.AuxPrice = offset;
            return order;
        }

        /// <summary>
        /// The Block attribute is used for large volume option orders on ISE that consist of at least 50 contracts. To execute large-volume 
        /// orders over time without moving the market, use the Accumulate/Distribute algorithm.
        /// Products: OPT
        /// Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=block
        /// Reference: http://individuals.interactivebrokers.com/en/trading/orders/block.php?ib_entity=llc
        /// </summary>
        public static Order Block(string action, double quantity, double price)
        {
            Order order = new Order();
            order.Action = action;
            order.OrderType = "LMT";
            order.TotalQuantity = quantity;//Large volumes!
            order.LmtPrice = price;
            order.BlockOrder = true;
            return order;
        }

        /// <summary>
        /// A Box Top order executes as a market order at the current best price. If the order is only partially filled, the remainder is submitted as 
        /// a limit order with the limit price equal to the price at which the filled portion of the order executed.
        /// Products: OPT
        /// Supported Exchanges: BOX
        /// Reference: https://individuals.interactivebrokers.com/en/?f=%2Fen%2Ftrading%2Forders%2Fboxtop.php%3Fib_entity%3Dllc
        /// </summary>
        public static Order BoxTop(string action, double quantity)
        {
            Order order = new Order();
            order.Action = action;
            order.OrderType = "BOX TOP";
            order.TotalQuantity = quantity;
            return order;
        }

        /// <summary>
        /// A Limit order is an order to buy or sell at a specified price or better. The Limit order ensures that if the order fills, 
        /// it will not fill at a price less favorable than your limit price, but it does not guarantee a fill.
        /// Products: BOND, CFD, CASH, FUT, FOP, OPT, STK, WAR
        /// Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=lmt
        /// Reference: http://individuals.interactivebrokers.com/en/trading/orders/limit.php?ib_entity=llc
        /// </summary>
        public static Order LimitOrder(string action, double quantity, double limitPrice)
        {
            Order order = new Order();
            order.Action = action;
            order.OrderType = "LMT";
            order.TotalQuantity = quantity;
            order.LmtPrice = limitPrice;
            return order;
        }

        /// <summary>
        /// A Limit if Touched is an order to buy (or sell) a contract at a specified price or better, below (or above) the market. This order is 
        /// held in the system until the trigger price is touched. An LIT order is similar to a stop limit order, except that an LIT sell order is 
        /// placed above the current market price, and a stop limit sell order is placed below.
        /// Products: BOND, CFD, CASH, FUT, FOP, OPT, STK, WAR
        /// Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=lit
        /// Reference: http://individuals.interactivebrokers.com/en/trading/orders/lit.php?ib_entity=llc
        /// </summary>
        public static Order LimitIfTouched(string action, double quantity, double limitPrice, double triggerPrice)
        {
            Order order = new Order();
            order.Action = action;
            order.OrderType = "LIT";
            order.TotalQuantity = quantity;
            order.LmtPrice = limitPrice;
            order.AuxPrice = triggerPrice;
            return order;
        }

        /// <summary>
        /// A Limit-on-close (LOC) order will be submitted at the close and will execute if the closing price is at or better than the submitted 
        /// limit price.
        /// Products: CFD, FUT, STK, WAR
        /// Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=loc
        /// Reference: http://individuals.interactivebrokers.com/en/trading/orders/loc.php?ib_entity=llc
        /// </summary>
        public static Order LimitOnClose(string action, double quantity, double limitPrice)
        {
            Order order = new Order();
            order.Action = action;
            order.OrderType = "LOC";
            order.TotalQuantity = quantity;
            order.LmtPrice = limitPrice;
            return order;
        }

        /// <summary>
        /// A Limit-on-Open (LOO) order combines a limit order with the OPG time in force to create an order that is submitted at the market's open, 
        /// and that will only execute at the specified limit price or better. Orders are filled in accordance with specific exchange rules.
        /// Products: CFD, STK, OPT, WAR
        /// Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=moo
        /// Reference: http://individuals.interactivebrokers.com/en/trading/orders/loo.php?ib_entity=llc
        /// </summary>
        public static Order LimitOnOpen(string action, double quantity, double limitPrice)
        {
            Order order = new Order();
            order.Action = action;
            order.Tif = "OPG";
            order.OrderType = "LMT";
            order.TotalQuantity = quantity;
            order.LmtPrice = limitPrice;
            return order;
        }

        /// <summary>
        /// Passive Relative orders provide a means for traders to seek a less aggressive price than the National Best Bid and Offer (NBBO) while 
        /// keeping the order pegged to the best bid (for a buy) or ask (for a sell). The order price is automatically adjusted as the markets move 
        /// to keep the order less aggressive. For a buy order, your order price is pegged to the NBB by a less aggressive offset, and if the NBB 
        /// moves up, your bid will also move up. If the NBB moves down, there will be no adjustment because your bid will become aggressive and execute. 
        /// For a sell order, your price is pegged to the NBO by a less aggressive offset, and if the NBO moves down, your offer will also move down. 
        /// If the NBO moves up, there will be no adjustment because your offer will become aggressive and execute. In addition to the offset, you can 
        /// define an absolute cap, which works like a limit price, and will prevent your order from being executed above or below a specified level. 
        /// The Passive Relative order is similar to the Relative/Pegged-to-Primary order, except that the Passive relative subtracts the offset from 
        /// the bid and the Relative adds the offset to the bid.
        /// Products: STK, WAR
        /// Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=passvrel
        /// Reference: http://individuals.interactivebrokers.com/en/trading/orders/passiveRel.php?ib_entity=llc
        /// </summary>
        public static Order PassiveRelative(string action, double quantity, double offset)
        {
            Order order = new Order();
            order.Action = action;
            order.OrderType = "PASSV REL";
            order.TotalQuantity = quantity;
            order.AuxPrice = offset;
            return order;
        }

        /// <summary>
        /// A pegged-to-midpoint order provides a means for traders to seek a price at the midpoint of the National Best Bid and Offer (NBBO). 
        /// The price automatically adjusts to peg the midpoint as the markets move, to remain aggressive. For a buy order, your bid is pegged to 
        /// the NBBO midpoint and the order price adjusts automatically to continue to peg the midpoint if the market moves. The price only adjusts 
        /// to be more aggressive. If the market moves in the opposite direction, the order will execute.
        /// Products: STK
        /// Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=pegmid
        /// Reference: http://individuals.interactivebrokers.com/en/trading/orders/pegmid.php?ib_entity=llc
        /// </summary>
        public static Order PeggedToMidpoint(string action, double quantity, double offset)
        {
            Order order = new Order();
            order.Action = action;
            order.OrderType = "PEG MID";
            order.TotalQuantity = quantity;
            order.AuxPrice = offset;
            return order;
        }

        /// <summary>
        /// Bracket orders are designed to help limit your loss and lock in a profit by "bracketing" an order with two opposite-side orders. 
        /// A BUY order is bracketed by a high-side sell limit order and a low-side sell stop order. A SELL order is bracketed by a high-side buy 
        /// stop order and a low side buy limit order.
        /// Products: CFD, BAG, FOP, CASH, FUT, OPT, STK, WAR
        /// Reference: https://individuals.interactivebrokers.com/en/index.php?f=583
        /// </summary>
        public static List<Order> BracketOrder(int parentOrderId, string action, double quantity, double limitPrice, 
            double takeProfitLimitPrice, double stopLossPrice)
        {
            //This will be our main or "parent" order
            Order parent = new Order();
            parent.OrderId = parentOrderId;
            parent.Action = action;
            parent.OrderType = "LMT";
            parent.TotalQuantity = quantity;
            parent.LmtPrice = limitPrice;
            //The parent and children orders will need this attribute set to false to prevent accidental executions.
            //The LAST CHILD will have it set to true, 
            parent.Transmit = false;

            Order takeProfit = new Order();
            //
            takeProfit.OrderId = parent.OrderId + 1;
            takeProfit.Action = action.Equals("BUY") ? "SELL" : "BUY";
            takeProfit.OrderType = "LMT";
            takeProfit.TotalQuantity = quantity;
            takeProfit.LmtPrice = takeProfitLimitPrice;
            takeProfit.ParentId = parentOrderId;
            takeProfit.Transmit = false;

            Order stopLoss = new Order();
            stopLoss.OrderId = parent.OrderId + 2;
            stopLoss.Action = action.Equals("BUY") ? "SELL" : "BUY";
            stopLoss.OrderType = "STP";
            //Stop trigger price
            stopLoss.AuxPrice = stopLossPrice;
            stopLoss.TotalQuantity = quantity;
            stopLoss.ParentId = parentOrderId;
            //In this case, the low side order will be the last child being sent. Therefore, it needs to set this attribute to true 
            //to activate all its predecessors
            stopLoss.Transmit = true;

            List<Order> bracketOrder = new List<Order>();
            bracketOrder.Add(parent);
            bracketOrder.Add(takeProfit);
            bracketOrder.Add(stopLoss);

            return bracketOrder;
        }

        /// <summary>
        /// Products:CFD, FUT, FOP, OPT, STK, WAR
        /// A Market-to-Limit (MTL) order is submitted as a market order to execute at the current best market price. If the order is only 
        /// partially filled, the remainder of the order is canceled and re-submitted as a limit order with the limit price equal to the price 
        /// at which the filled portion of the order executed.
        /// Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=mtl
        /// Reference: http://individuals.interactivebrokers.com/en/trading/orders/mtl.php?ib_entity=llc
        /// </summary>
        public static Order MarketToLimit(string action, double quantity)
        {
            Order order = new Order();
            order.Action = action;
            order.OrderType = "MTL";
            order.TotalQuantity = quantity;
            return order;
        }

        /// <summary>
        /// This order type is useful for futures traders using Globex. A Market with Protection order is a market order that will be cancelled and 
        /// resubmitted as a limit order if the entire order does not immediately execute at the market price. The limit price is set by Globex to be 
        /// close to the current market price, slightly higher for a sell order and lower for a buy order.
        /// Products: FUT, FOP
        /// Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=mktprot
        /// Reference: http://individuals.interactivebrokers.com/en/trading/orders/marketProtect.php?ib_entity=llc
        /// </summary>
        public static Order MarketWithProtection(string action, double quantity)
        {
            Order order = new Order();
            order.Action = action;
            order.OrderType = "MKT PRT";
            order.TotalQuantity = quantity;
            return order;
        }

        /// <summary>
        /// A Stop order is an instruction to submit a buy or sell market order if and when the user-specified stop trigger price is attained or 
        /// penetrated. A Stop order is not guaranteed a specific execution price and may execute significantly away from its stop price. A Sell 
        /// Stop order is always placed below the current market price and is typically used to limit a loss or protect a profit on a long stock 
        /// position. A Buy Stop order is always placed above the current market price. It is typically used to limit a loss or help protect a 
        /// profit on a short sale.
        /// Products: CFD, BAG, CASH, FUT, FOP, OPT, STK, WAR
        /// Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=stp
        /// Reference: http://individuals.interactivebrokers.com/en/trading/orders/stop.php?ib_entity=llc
        /// </summary>
        public static Order Stop(string action, double quantity, double stopPrice)
        {
            Order order = new Order();
            order.Action = action;
            order.OrderType = "STP";
            order.AuxPrice = stopPrice;
            order.TotalQuantity = quantity;
            return order;
        }

        /// <summary>
        /// A Stop-Limit order is an instruction to submit a buy or sell limit order when the user-specified stop trigger price is attained or 
        /// penetrated. The order has two basic components: the stop price and the limit price. When a trade has occurred at or through the stop 
        /// price, the order becomes executable and enters the market as a limit order, which is an order to buy or sell at a specified price or better.
        /// Products: CFD, CASH, FUT, FOP, OPT, STK, WAR
        /// Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=stplmt
        /// Reference: http://individuals.interactivebrokers.com/en/trading/orders/stopLimit.php?ib_entity=llc
        /// </summary>
        public static Order StopLimit(string action, double quantity, double limitPrice, double stopPrice)
        {
            Order order = new Order();
            order.Action = action;
            order.OrderType = "STP LMT";
            order.TotalQuantity = quantity;
            order.LmtPrice = limitPrice;
            order.AuxPrice = stopPrice;
            return order;
        }

        /// <summary>
        /// A Stop with Protection order combines the functionality of a stop limit order with a market with protection order. The order is set 
        /// to trigger at a specified stop price. When the stop price is penetrated, the order is triggered as a market with protection order, 
        /// which means that it will fill within a specified protected price range equal to the trigger price +/- the exchange-defined protection 
        /// point range. Any portion of the order that does not fill within this protected range is submitted as a limit order at the exchange-defined 
        /// trigger price +/- the protection points.
        /// Products: FUT
        /// Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=stpprot
        /// Reference: http://individuals.interactivebrokers.com/en/trading/orders/stopProtect.php?ib_entity=llc
        /// </summary>
        public static Order StopWithProtection(string action, double quantity, double stopPrice)
        {
            Order order = new Order();
            order.TotalQuantity = quantity;
            order.Action = action;
            order.OrderType = "STP PRT";
            order.AuxPrice = stopPrice;
            return order;
        }

        /// <summary>
        /// A sell trailing stop order sets the stop price at a fixed amount below the market price with an attached "trailing" amount. As the 
        /// market price rises, the stop price rises by the trail amount, but if the stock price falls, the stop loss price doesn't change, 
        /// and a market order is submitted when the stop price is hit. This technique is designed to allow an investor to specify a limit on the 
        /// maximum possible loss, without setting a limit on the maximum possible gain. "Buy" trailing stop orders are the mirror image of sell 
        /// trailing stop orders, and are most appropriate for use in falling markets.
        /// Products: CFD, CASH, FOP, FUT, OPT, STK, WAR
        /// Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=trail
        /// Reference: http://individuals.interactivebrokers.com/en/trading/orders/trailingStops.php?ib_entity=llc
        /// </summary>
        public static Order TrailingStop(string action, double quantity, double trailingPercent, double trailStopPrice)
        {
            Order order = new Order();
            order.Action = action;
            order.OrderType = "TRAIL";
            order.TotalQuantity = quantity;
            order.TrailingPercent = trailingPercent;
            order.TrailStopPrice = trailStopPrice;
            return order;
        }

        /// <summary>
        /// A trailing stop limit order is designed to allow an investor to specify a limit on the maximum possible loss, without setting a limit 
        /// on the maximum possible gain. A SELL trailing stop limit moves with the market price, and continually recalculates the stop trigger 
        /// price at a fixed amount below the market price, based on the user-defined "trailing" amount. The limit order price is also continually 
        /// recalculated based on the limit offset. As the market price rises, both the stop price and the limit price rise by the trail amount and 
        /// limit offset respectively, but if the stock price falls, the stop price remains unchanged, and when the stop price is hit a limit order 
        /// is submitted at the last calculated limit price. A "Buy" trailing stop limit order is the mirror image of a sell trailing stop limit, 
        /// and is generally used in falling markets.
        /// Products: BOND, CFD, CASH, FUT, FOP, OPT, STK, WAR
        /// Reference: http://individuals.interactivebrokers.com/en/trading/orders/trailingStopLimit.php?ib_entity=llc
        /// </summary>
        public static Order TrailingStopLimit(string action, double quantity, double limitPrice, double trailingAmount, double trailStopPrice)
        {
            Order order = new Order();
            order.Action = action;
            order.OrderType = "TRAIL LIMIT";
            order.TotalQuantity = quantity;
            order.TrailStopPrice = trailStopPrice;
            order.LmtPrice = limitPrice;
            order.AuxPrice = trailingAmount;
            return order;
        }

        /// <summary>
        /// Create combination orders that include options, stock and futures legs (stock legs can be included if the order is routed 
        /// through SmartRouting). Although a combination/spread order is constructed of separate legs, it is executed as a single transaction 
        /// if it is routed directly to an exchange. For combination orders that are SmartRouted, each leg may be executed separately to ensure 
        /// best execution.
        /// Products: OPT, STK, FUT
        /// </summary>
        public static Order ComboLimitOrder(string action, double quantity, double limitPrice, bool nonGuaranteed)
        {
            Order order = new Order();
            order.Action = action;
            order.OrderType = "LMT";
            order.TotalQuantity = quantity;
            order.LmtPrice = limitPrice;
            if (nonGuaranteed)
            {
                order.SmartComboRoutingParams = new List<TagValue>();
                order.SmartComboRoutingParams.Add(new TagValue("NonGuaranteed", "1"));
            }
            return order;
        }

        /// <summary>
        /// Create combination orders that include options, stock and futures legs (stock legs can be included if the order is routed 
        /// through SmartRouting). Although a combination/spread order is constructed of separate legs, it is executed as a single transaction 
        /// if it is routed directly to an exchange. For combination orders that are SmartRouted, each leg may be executed separately to ensure 
        /// best execution.
        /// Products: OPT, STK, FUT
        /// </summary>
        public static Order ComboMarketOrder(string action, double quantity, bool nonGuaranteed)
        {
            Order order = new Order();
            order.Action = action;
            order.OrderType = "MKT";
            order.TotalQuantity = quantity;
            if (nonGuaranteed)
            {
                order.SmartComboRoutingParams = new List<TagValue>();
                order.SmartComboRoutingParams.Add(new TagValue("NonGuaranteed", "1"));
            }
            return order;
        }

        /// <summary>
        /// Create combination orders that include options, stock and futures legs (stock legs can be included if the order is routed 
        /// through SmartRouting). Although a combination/spread order is constructed of separate legs, it is executed as a single transaction 
        /// if it is routed directly to an exchange. For combination orders that are SmartRouted, each leg may be executed separately to ensure 
        /// best execution.
        /// Products: OPT, STK, FUT
        /// </summary>
        public static Order LimitOrderForComboWithLegPrices(string action, double quantity, double[] legPrices, bool nonGuaranteed)
        {
            Order order = new Order();
            order.Action = action;
            order.OrderType = "LMT";
            order.TotalQuantity = quantity;
            order.OrderComboLegs = new List<OrderComboLeg>();
            foreach(double price in legPrices)
            {
                OrderComboLeg comboLeg = new OrderComboLeg();
                comboLeg.Price = 5.0;
                order.OrderComboLegs.Add(comboLeg);
            }           
            if (nonGuaranteed)
            {
                order.SmartComboRoutingParams = new List<TagValue>();
                order.SmartComboRoutingParams.Add(new TagValue("NonGuaranteed", "1"));
            }
            return order;
        }

        /// <summary>
        /// Create combination orders that include options, stock and futures legs (stock legs can be included if the order is routed 
        /// through SmartRouting). Although a combination/spread order is constructed of separate legs, it is executed as a single transaction 
        /// if it is routed directly to an exchange. For combination orders that are SmartRouted, each leg may be executed separately to ensure 
        /// best execution.
        /// Products: OPT, STK, FUT
        /// </summary>
        public static Order RelativeLimitCombo(string action, double quantity, double limitPrice, bool nonGuaranteed)
        {
            Order order = new Order();
            order.Action = action;
            order.TotalQuantity = quantity;
            order.OrderType = "REL + LMT";
            order.LmtPrice = limitPrice;
            if (nonGuaranteed)
            {
                order.SmartComboRoutingParams = new List<TagValue>();
                order.SmartComboRoutingParams.Add(new TagValue("NonGuaranteed", "1"));
            }
            return order;
        }

        /// <summary>
        /// Create combination orders that include options, stock and futures legs (stock legs can be included if the order is routed 
        /// through SmartRouting). Although a combination/spread order is constructed of separate legs, it is executed as a single transaction 
        /// if it is routed directly to an exchange. For combination orders that are SmartRouted, each leg may be executed separately to ensure 
        /// best execution.
        /// Products: OPT, STK, FUT
        /// </summary>
        public static Order RelativeMarketCombo(string action, double quantity, bool nonGuaranteed)
        {
            Order order = new Order();
            order.Action = action;
            order.TotalQuantity = quantity;
            order.OrderType = "REL + MKT";
            if (nonGuaranteed)
            {
                order.SmartComboRoutingParams = new List<TagValue>();
                order.SmartComboRoutingParams.Add(new TagValue("NonGuaranteed", "1"));
            }
            return order;
        }

        /// <summary>
        /// One-Cancels All (OCA) order type allows an investor to place multiple and possibly unrelated orders assigned to a group. The aim is 
        /// to complete just one of the orders, which in turn will cause TWS to cancel the remaining orders. The investor may submit several 
        /// orders aimed at taking advantage of the most desirable price within the group. Completion of one piece of the group order causes 
        /// cancellation of the remaining group orders while partial completion causes the group to rebalance. An investor might desire to sell 
        /// 1000 shares of only ONE of three positions held above prevailing market prices. The OCA order group allows the investor to enter prices 
        /// at specified target levels and if one is completed, the other two will automatically cancel. Alternatively, an investor may wish to take 
        /// a LONG position in eMini S&P stock index futures in a falling market or else SELL US treasury futures at a more favorable price. 
        /// Grouping the two orders using an OCA order type offers the investor two chance to enter a similar position, while only running the risk 
        /// of taking on a single position.
        /// Products: BOND, CASH, FUT, FOP, STK, OPT, WAR
        /// Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=oca
        /// Reference: http://individuals.interactivebrokers.com/en/trading/orders/oca.php?ib_entity=llc
        /// </summary>
        public static List<Order> OneCancelsAll(string ocaGroup, List<Order> ocaOrders, int ocaType)
        {
            foreach (Order o in ocaOrders)
            {
                o.OcaGroup = ocaGroup;
                o.OcaType = ocaType;
                //Same as with Bracket orders. To prevent accidental executions, set all orders' transmit flag to false.
                //This will tell the TWS not to send the orders, allowing your program to send them all first.
                o.Transmit = false;
            }

            //Telling the TWS to transmit the last order in the OCA will also cause the transmission of its predecessors.
            ocaOrders[ocaOrders.Count - 1].Transmit = true;
            return ocaOrders;
        }

        /// <summary>
        /// Specific to US options, investors are able to create and enter Volatility-type orders for options and combinations rather than price orders. 
        /// Option traders may wish to trade and position for movements in the price of the option determined by its implied volatility. Because 
        /// implied volatility is a key determinant of the premium on an option, traders position in specific contract months in an effort to take 
        /// advantage of perceived changes in implied volatility arising before, during or after earnings or when company specific or broad market 
        /// volatility is predicted to change. In order to create a Volatility order, clients must first create a Volatility Trader page from the 
        /// Trading Tools menu and as they enter option contracts, premiums will display in percentage terms rather than premium. The buy/sell process 
        /// is the same as for regular orders priced in premium terms except that the client can limit the volatility level they are willing to pay or 
        /// receive.
        /// Products: FOP, OPT
        /// Supported Exchanges: https://individuals.interactivebrokers.com/en/trading/orderTypeExchanges.php?ot=volat
        /// Reference: http://individuals.interactivebrokers.com/en/trading/orders/vol.php?ib_entity=llc
        /// </summary>
        public static Order Volatility(string action, double quantity, double volatilityPercent, int volatilityType)
        {
            Order order = new Order();
            order.Action = action;
            order.OrderType = "VOL";
            order.TotalQuantity = quantity;
            order.Volatility = volatilityPercent;//Expressed in percentage (40%)
            order.VolatilityType = volatilityType;// 1=daily, 2=annual
            return order;
        }
    }
}
