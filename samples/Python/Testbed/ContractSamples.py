"""
Copyright (C) 2016 Interactive Brokers LLC. All rights reserved.  This code is
subject to the terms and conditions of the IB API Non-Commercial License or the
 IB API Commercial License, as applicable. 
"""

import sys

from ibapi.contract import *


class ContractSamples:

    """ Usually, the easiest way to define a Stock/CASH contract is through 
    these four attributes.  """

    @staticmethod
    def EurGbpFx():
        #! [cashcontract]
        contract = Contract()
        contract.symbol = "EUR"
        contract.secType = "CASH"
        contract.currency = "GBP"
        contract.exchange = "IDEALPRO"
        #! [cashcontract]
        return contract


    @staticmethod
    def Index():
        #! [indcontract]
        contract = Contract()
        contract.symbol = "DAX"
        contract.secType = "IND"
        contract.currency = "EUR"
        contract.exchange = "DTB"
        #! [indcontract]
        return contract


    @staticmethod
    def CFD():
        #! [cfdcontract]
        contract = Contract()
        contract.symbol = "IBDE30"
        contract.secType = "CFD"
        contract.currency = "EUR"
        contract.exchange = "SMART"
        #! [cfdcontract]
        return contract


    @staticmethod
    def EuropeanStock():
        contract = Contract()
        contract.symbol = "SIE"
        contract.secType = "STK"
        contract.currency = "EUR"
        contract.exchange = "SMART"
        return contract


    @staticmethod
    def OptionAtIse():
        contract = Contract()
        contract.symbol = "BPX"
        contract.secType = "OPT"
        contract.currency = "USD"
        contract.exchange = "ISE"
        contract.lastTradeDateOrContractMonth = "20160916"
        contract.right = "C"
        contract.strike = 65
        contract.multiplier = "100"
        return contract


    @staticmethod
    def BondWithCusip():
            #! [bondwithcusip]
            contract = Contract()
            # enter CUSIP as symbol
            contract.symbol= "912828C57"
            contract.secType = "BOND"
            contract.exchange = "SMART"
            contract.currency = "USD"
            #! [bondwithcusip]
            return contract


    @staticmethod
    def Bond():
            #! [bond]
            contract = Contract()
            contract.conId = 29105549
            contract.exchange = "SMART"
            #! [bond]
            return contract


    @staticmethod
    def MutualFund():
            #! [fundcontract]
            contract = Contract()
            contract.symbol = "VINIX"
            contract.secType = "FUND"
            contract.exchange = "FUNDSERV"
            contract.currency = "USD"
            #! [fundcontract]
            return contract


    @staticmethod
    def Commodity():
            #! [commoditycontract]
            contract = Contract()
            contract.symbol = "XAUUSD"
            contract.secType = "CMDTY"
            contract.exchange = "SMART"
            contract.currency = "USD"
            #! [commoditycontract]
            return contract
    

    @staticmethod
    def USStock():
        #! [stkcontract]
        contract = Contract()
        contract.symbol = "IBKR"
        contract.secType = "STK"
        contract.currency = "USD"
        #In the API side, NASDAQ is always defined as ISLAND in the exchange field
        contract.exchange = "ISLAND"
        #! [stkcontract]
        return contract


    @staticmethod
    def USStockWithPrimaryExch():
        #! [stkcontractwithprimary]
        contract = Contract()
        contract.symbol = "MSFT"
        contract.secType = "STK"
        contract.currency = "USD"
        contract.exchange = "SMART"
        #Specify the Primary Exchange attribute to avoid contract ambiguity 
        contract.primaryExch = "ISLAND"
        #! [stkcontractwithprimary]
        return contract

            
    @staticmethod
    def USStockAtSmart():
        contract = Contract()
        contract.symbol = "IBKR"
        contract.secType = "STK"
        contract.currency = "USD"
        contract.exchange = "SMART"
        return contract


    @staticmethod
    def USOptionContract():
        #! [optcontract_us]
        contract = Contract()
        contract.symbol = "GOOG"
        contract.secType = "OPT"
        contract.exchange = "SMART"
        contract.currency = "USD"
        contract.lastTradeDateOrContractMonth = "20170120"
        contract.strike = 615
        contract.right = "C"
        contract.multiplier = "100"
        #! [optcontract_us]
        return contract


    @staticmethod
    def OptionAtBOX():
        #! [optcontract]
        contract = Contract()
        contract.symbol = "GOOG"
        contract.secType = "OPT"
        contract.exchange = "BOX"
        contract.currency = "USD"
        contract.lastTradeDateOrContractMonth = "20170120"
        contract.strike = 615
        contract.right = "C"
        contract.multiplier = "100"
        #! [optcontract]
        return contract


    """ Option contracts require far more information since there are many 
    contracts having the exact same attributes such as symbol, currency, 
    strike, etc. This can be overcome by adding more details such as the 
    trading class"""

    @staticmethod
    def OptionWithTradingClass():
        #! [optcontract_tradingclass]
        contract = Contract()
        contract.symbol = "SANT"
        contract.secType = "OPT"
        contract.exchange = "MEFFRV"
        contract.currency = "EUR"
        contract.lastTradeDateOrContractMonth = "20190621"
        contract.strike = 7.5
        contract.right = "C"
        contract.multiplier = "100"
        contract.tradingClass = "SANEU"
        #! [optcontract_tradingclass]
        return contract


    """ Using the contract's own symbol (localSymbol) can greatly simplify a
    contract description """

    @staticmethod
    def OptionWithLocalSymbol():
        #! [optcontract_localsymbol]
        contract = Contract()
        #Watch out for the spaces within the local symbol!
        contract.localSymbol = "C DBK  DEC 20  1600"
        contract.secType = "OPT"
        contract.exchange = "DTB"
        contract.currency = "EUR"
        #! [optcontract_localsymbol]
        return contract


    """ Future contracts also require an expiration date but are less
    complicated than options."""

    @staticmethod
    def SimpleFuture():
        #! [futcontract]
        contract = Contract()
        contract.symbol = "ES"
        contract.secType = "FUT"
        contract.exchange = "GLOBEX"
        contract.currency = "USD"
        contract.lastTradeDateOrContractMonth = "201612"
        #! [futcontract]
        return contract


    """Rather than giving expiration dates we can also provide the local symbol
    attributes such as symbol, currency, strike, etc. """

    @staticmethod
    def FutureWithLocalSymbol():
        #! [futcontract_local_symbol]
        contract = Contract()
        contract.secType = "FUT"
        contract.exchange = "GLOBEX"
        contract.currency = "USD"
        contract.localSymbol = "ESU6"
        #! [futcontract_local_symbol]
        return contract


    @staticmethod
    def FutureWithMultiplier():
        #! [futcontract_multiplier]
        contract = Contract()
        contract.symbol = "DAX"
        contract.secType = "FUT"
        contract.exchange = "DTB"
        contract.currency = "EUR"
        contract.lastTradeDateOrContractMonth = "201609"
        contract.multiplier = "5"
        #! [futcontract_multiplier]
        return contract


    """ Note the space in the symbol! """

    @staticmethod
    def WrongContract():
        contract = Contract()
        contract.symbol = " IJR "
        contract.conId = 9579976
        contract.secType = "STK"
        contract.exchange = "SMART"
        contract.currency = "USD"
        return contract

    @staticmethod
    def FuturesOnOptions():
        #! [fopcontract]
        contract = Contract()
        contract.symbol = "ES"
        contract.secType = "FOP"
        contract.exchange = "GLOBEX"
        contract.currency = "USD"
        contract.lastTradeDateOrContractMonth = "20160617"
        contract.strike = 1810
        contract.right = "C"
        contract.multiplier = "50"
        #! [fopcontract]
        return contract


    """ It is also possible to define contracts based on their ISIN (IBKR STK
    sample). """

    @staticmethod
    def ByISIN():
        contract = Contract()
        contract.secIdType = "ISIN"
        contract.secId = "US45841N1072"
        contract.exchange = "SMART"
        contract.currency = "USD"
        contract.secType = "STK"
        return contract


    """ Or their conId (EUR.uSD sample).
    Note: passing a contract containing the conId can cause problems if one of 
    the other provided attributes does not match 100% with what is in IB's 
    database. This is particularly important for contracts such as Bonds which 
    may change their description from one day to another.
    If the conId is provided, it is best not to give too much information as
    in the example below. """

    @staticmethod
    def ByConId():
        contract = Contract()
        contract.secType = "CASH"
        contract.conId = 12087792
        contract.exchange = "IDEALPRO"
        return contract


    """ Ambiguous contracts are great to use with reqContractDetails. This way
    you can query the whole option chain for an underlying. Bear in mind that
    there are pacing mechanisms in place which will delay any further responses
    from the TWS to prevent abuse. """

    @staticmethod
    def OptionForQuery():
        #! [optionforquery]
        contract = Contract()
        contract.symbol = "FISV"
        contract.secType = "OPT"
        contract.exchange = "SMART"
        contract.currency = "USD"
        #! [optionforquery]
        return contract


    @staticmethod
    def OptionComboContract():
        #! [bagoptcontract]
        contract = Contract()
        contract.symbol = "DBK"
        contract.secType = "BAG"
        contract.currency = "EUR"
        contract.exchange = "DTB"

        leg1 = ComboLeg()
        leg1.conId = 197397509 #DBK JUN 15 2018 C
        leg1.ratio = 1
        leg1.action = "BUY"
        leg1.exchange = "DTB"

        leg2 = ComboLeg()
        leg2.conId = 197397584  #DBK JUN 15 2018 P
        leg2.ratio = 1
        leg2.action = "SELL"
        leg2.exchange = "DTB"

        contract.comboLegs = []
        contract.comboLegs.append(leg1)
        contract.comboLegs.append(leg2)
        #! [bagoptcontract]
        return contract


    """ STK Combo contract
    Leg 1: 43645865 - IBKR's STK
    Leg 2: 9408 - McDonald's STK """

    @staticmethod
    def StockComboContract():
        #! [bagstkcontract]
        contract = Contract()
        contract.symbol = "IBKR,MCD"
        contract.secType = "BAG"
        contract.currency = "USD"
        contract.exchange = "SMART"

        leg1 = ComboLeg()
        leg1.conId = 43645865#IBKR STK
        leg1.ratio = 1
        leg1.action = "BUY"
        leg1.exchange = "SMART"

        leg2 = ComboLeg()
        leg2.conId = 9408#MCD STK
        leg2.ratio = 1
        leg2.action = "SELL"
        leg2.exchange = "SMART"

        contract.comboLegs = []
        contract.comboLegs.append(leg1)
        contract.comboLegs.append(leg2)
        #! [bagstkcontract]
        return contract


    """ CBOE Volatility Index Future combo contract """

    @staticmethod
    def FutureComboContract():
        #! [bagfutcontract]
        contract = Contract()
        contract.symbol = "VIX"
        contract.secType = "BAG"
        contract.currency = "USD"
        contract.exchange = "CFE"

        leg1 = ComboLeg()
        leg1.conId = 256038899 # VIX FUT 201708
        leg1.ratio = 1
        leg1.action = "BUY"
        leg1.exchange = "CFE"

        leg2 = ComboLeg()
        leg2.conId = 260564703 # VIX FUT 201709
        leg2.ratio = 1
        leg2.action = "SELL"
        leg2.exchange = "CFE"

        contract.comboLegs = []
        contract.comboLegs.append(leg1)
        contract.comboLegs.append(leg2)
        #! [bagfutcontract]
        return contract


    @staticmethod
    def InterCmdtyFuturesContract():
        #! [intcmdfutcontract]
        contract = Contract()
        contract.symbol = "CL.bZ"
        contract.secType = "BAG"
        contract.currency = "USD"
        contract.exchange = "NYMEX"

        leg1 = ComboLeg()
        leg1.conId = 47207310 #CL Dec'16 @NYMEX
        leg1.ratio = 1
        leg1.action = "BUY"
        leg1.exchange = "NYMEX"

        leg2 = ComboLeg()
        leg2.conId = 47195961 #BZ Dec'16 @NYMEX
        leg2.ratio = 1
        leg2.action = "SELL"
        leg2.exchange = "NYMEX"

        contract.comboLegs = []
        contract.comboLegs.append(leg1)
        contract.comboLegs.append(leg2)
        #! [intcmdfutcontract]
        return contract


    @staticmethod
    def NewsFeedForQuery():
        #! [newsfeedforquery]
        contract = Contract()
        contract.secType = "NEWS"
        contract.exchange = "BT" #Briefing Trader
        #! [newsfeedforquery]
        return contract


    @staticmethod
    def BTbroadtapeNewsFeed():
        #! [newscontractbt]
        contract = Contract()
        contract.symbol  = "BT:BT_ALL" #BroadTape All News
        contract.secType = "NEWS"
        contract.exchange = "BT" #Briefing Trader
        #! [newscontractbt]
        return contract


    @staticmethod
    def BZbroadtapeNewsFeed():
        #! [newscontractbz]
        contract = Contract()
        contract.symbol = "BZ:BZ_ALL" #BroadTape All News
        contract.secType = "NEWS"
        contract.exchange = "BZ" #Benzinga Pro
        #! [newscontractbz]
        return contract


    @staticmethod
    def FLYbroadtapeNewsFeed():
        #! [newscontractfly]
        contract = Contract()
        contract.symbol  = "FLY:FLY_ALL" #BroadTape All News
        contract.secType = "NEWS"
        contract.exchange = "FLY" #Fly on the Wall
       #! [newscontractfly]
        return contract


    @staticmethod
    def MTbroadtapeNewsFeed():
        #! [newscontractmt]
        contract = Contract()
        contract.symbol = "MT:MT_ALL" #BroadTape All News
        contract.secType = "NEWS"
        contract.exchange = "MT" #Midnight Trader
        #! [newscontractmt]
        return contract


def Test():
    from utils import ExerciseStaticMethods
    ExerciseStaticMethods(ContractSamples)


if "__main__" == __name__:
   Test()

