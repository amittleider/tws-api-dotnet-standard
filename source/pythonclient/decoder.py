#!/usr/bin/env python3

"""
Copyright (C) 2016 Interactive Brokers LLC. All rights reserved.  This code is
subject to the terms and conditions of the IB API Non-Commercial License or the
 IB API Commercial License, as applicable. 
"""

"""
The Decoder knows how to transform a message's payload into higher level 
IB message (eg: order info, mkt data, etc).
It will call the corresponding method from the Wrapper so that customer's code
(eg: class derived from Wrapper) can make further use of the data.
"""


import inspect

from object_implem import Object
from message import IN, OUT
from wrapper import *
from order import Order
from order import OrderComboLeg
from contract import Contract
from contract import UnderComp
from contract import ComboLeg
from execution import Execution
import order_condition
from order_state import OrderState 
from logger import LOGGER
from server_versions import *
from utils import *
from softdollartier import SoftDollarTier
from ticktype import *
from tag_value import TagValue
from scanner import ScanData
from commission_report import CommissionReport

        

class HandleInfo(Object):
    def __init__(self, wrap=None, proc=None):
        self.wrapperMeth = wrap
        self.wrapperParams = None
        self.processMeth = proc
        if wrap is None and proc is None:
            raise ValueError("both wrap and proc can't be None")

    def __str__(self):
        s = "wrap:%s meth:%s prms:%s" % (self.wrapperParams,
                self.processMsth, self.wrapperParams)
        return s


class Decoder(Object):
    def __init__(self, wrapper, serverVersion):
        self.wrapper = wrapper
        self.serverVersion = serverVersion
        self.discover_params()
        self.print_params()


    def processTickPriceMsg(self, fields):
        sMsgId = next(fields)
        version = decode(int, fields)

        reqId = decode(int, fields)
        tickType = decode(int, fields)
        price = decode(float, fields)
        size = decode(int, fields) # ver 2 field
        attrMask = decode(int, fields) # ver 3 field

        attrib = TickAttrib() 

        attrib.canAutoExecute = attrMask == 1

        if self.serverVersion >= MIN_SERVER_VER_PAST_LIMIT:
            attrib.canAutoExecute = attrMask & 1 != 0
            attrib.pastLimit = attrMask & 2 != 0

        self.wrapper.tickPrice(reqId, tickType, price, attrib)

        # process ver 2 fields
        sizeTickType = TickTypeEnum.NOT_SET
        if TickTypeEnum.BID == tickType:
            sizeTickType = TickTypeEnum.BID_SIZE
        elif TickTypeEnum.ASK == tickType:
            sizeTickType = TickTypeEnum.ASK_SIZE
        elif TickTypeEnum.LAST == tickType:
            sizeTickType = TickTypeEnum.LAST_SIZE

        if sizeTickType != TickTypeEnum.NOT_SET:
            self.wrapper.tickSize(reqId, sizeTickType, size)


    def processOrderStatusMsg(self, fields):

        sMsgId = next(fields)
        version = decode(int, fields)
        orderId = decode(int, fields)
        status = decode(str, fields)

        if self.serverVersion >= MIN_SERVER_VER_FRACTIONAL_POSITIONS:
            filled = decode(float, fields)
        else:
            filled = decode(int, fields)

        if self.serverVersion >= MIN_SERVER_VER_FRACTIONAL_POSITIONS:
            remaining = decode(float, fields)
        else:
            remaining = decode(int, fields)

        avgFillPrice = decode(float, fields)

        permId = decode(int, fields) # ver 2 field
        parentId = decode(int, fields) # ver 3 field
        lastFillPrice = decode(float, fields) # ver 4 field
        clientId = decode(int, fields) # ver 5 field
        whyHeld = decode(str, fields) # ver 6 field

        self.wrapper.orderStatus(orderId, status, filled, remaining,
            avgFillPrice, permId, parentId, lastFillPrice, clientId, whyHeld)


    def processOpenOrder(self, fields):

        sMsgId = next(fields)
        version = decode(int, fields)

        order = Order()
        order.orderId = decode(int, fields)

        contract = Contract()

        contract.conId = decode(int, fields) # ver 17 field
        contract.symbol = decode(str, fields) 
        contract.secType = decode(str, fields) 
        contract.lastTradeDateOrContractMonth = decode(str, fields) 
        contract.strike = decode(float, fields)
        contract.right = decode(str, fields) 
        if version >= 32:
            contract.multiplier = decode(str, fields) 
        contract.exchange = decode(str, fields) 
        contract.currency = decode(str, fields) 
        contract.localSymbol = decode(str, fields)  # ver 2 field
        if version >= 32:
            contract.tradingClass = decode(str, fields) 

        # read order fields
        order.action = decode(str, fields)  

        if self.serverVersion >= MIN_SERVER_VER_FRACTIONAL_POSITIONS:
            order.totalQuantity = decode(float, fields)  
        else:
            order.totalQuantity = decode(int, fields)

        order.orderType = decode(str, fields) 
        if version < 29:
            order.lmtPrice = decode(float, fields)
        else:
            order.lmtPrice = decode(float, fields, SHOW_UNSET)
        if version < 30:
            order.auxPrice = decode(float, fields)
        else:
            order.auxPrice = decode(float, fields, SHOW_UNSET)
        order.tif = decode(str, fields)
        order.ocaGroup = decode(str, fields)
        order.account = decode(str, fields)
        order.openClose = decode(str, fields)

        order.origin = decode(int, fields)

        order.orderRef = decode(str, fields)
        order.clientId = decode(int, fields) # ver 3 field
        order.permId = decode(int, fields)   # ver 4 field

        order.outsideRth = decode(bool, fields) # ver 18 field
        order.hidden = decode(bool, fields) # ver 4 field
        order.discretionaryAmt = decode(float, fields) # ver 4 field
        order.goodAfterTime = decode(str, fields) # ver 5 field

        order.sharesAllocation = decode(str, fields) # deprecated ver 6 field

        order.faGroup = decode(str, fields) # ver 7 field
        order.faMethod = decode(str, fields) # ver 7 field
        order.faPercentage = decode(str, fields) # ver 7 field
        order.faProfile = decode(str, fields) # ver 7 field

        if self.serverVersion >= MIN_SERVER_VER_MODELS_SUPPORT:
            order.modelCode = decode(str, fields)

        order.goodTillDate = decode(str, fields) # ver 8 field

        order.rule80A = decode(str, fields) # ver 9 field
        order.percentOffset = decode(float, fields, SHOW_UNSET) # ver 9 field
        order.settlingFirm = decode(str, fields) # ver 9 field
        order.shortSaleSlot = decode(int, fields) # ver 9 field
        order.designatedLocation = decode(str, fields) # ver 9 field
        if self.serverVersion == MIN_SERVER_VER_SSHORTX_OLD:
            exemptCode = decode(int, fields)
        elif version >= 23:
            order.exemptCode = decode(int, fields)
        order.auctionStrategy = decode(int, fields) # ver 9 field
        order.startingPrice = decode(float, fields, SHOW_UNSET) # ver 9 field
        order.stockRefPrice = decode(float, fields, SHOW_UNSET) # ver 9 field
        order.delta = decode(float, fields, SHOW_UNSET) # ver 9 field
        order.stockRangeLower = decode(float, fields, SHOW_UNSET) # ver 9 field
        order.stockRangeUpper = decode(float, fields, SHOW_UNSET) # ver 9 field
        order.displaySize = decode(int, fields) # ver 9 field

        #if( version < 18) {
        #		# will never happen
        #		/* order.rthOnly = */ readBoolFromInt()
        #}

        order.blockOrder = decode(bool, fields) # ver 9 field
        order.sweepToFill = decode(bool, fields) # ver 9 field
        order.allOrNone = decode(bool, fields) # ver 9 field
        order.minQty = decode(int, fields, SHOW_UNSET) # ver 9 field
        order.ocaType = decode(int, fields) # ver 9 field
        order.eTradeOnly = decode(bool, fields) # ver 9 field
        order.firmQuoteOnly = decode(bool, fields) # ver 9 field
        order.nbboPriceCap = decode(float, fields, SHOW_UNSET) # ver 9 field

        order.parentId = decode(int, fields) # ver 10 field
        order.triggerMethod = decode(int, fields) # ver 10 field

        order.volatility = decode(float, fields, SHOW_UNSET) # ver 11 field
        order.volatilityType = decode(int, fields) # ver 11 field
        order.deltaNeutralOrderType = decode(str, fields) # ver 11 field (had a hack for ver 11)
        order.deltaNeutralAuxPrice = decode(float, fields, SHOW_UNSET) # ver 12 field

        if version >= 27 and order.deltaNeutralOrderType:
            order.deltaNeutralConId = decode(int, fields)
            order.deltaNeutralSettlingFirm = decode(str, fields)
            order.deltaNeutralClearingAccount = decode(str, fields)
            order.deltaNeutralClearingIntent = decode(str, fields)

        if version >= 31 and order.deltaNeutralOrderType:
            order.deltaNeutralOpenClose = decode(str, fields)
            order.deltaNeutralShortSale = decode(bool, fields)
            order.deltaNeutralShortSaleSlot = decode(int, fields)
            order.deltaNeutralDesignatedLocation = decode(str, fields)

        order.continuousUpdate = decode(bool, fields) # ver 11 field

        # will never happen
        #if( self.serverVersion == 26) {
        #	order.stockRangeLower = readDouble()
        #	order.stockRangeUpper = readDouble()
        #}

        order.referencePriceType = decode(int, fields) # ver 11 field

        order.trailStopPrice = decode(float, fields, SHOW_UNSET) # ver 13 field

        if version >= 30:
            order.trailingPercent = decode(float, fields, SHOW_UNSET)

        order.basisPoints = decode(float, fields, SHOW_UNSET) # ver 14 field
        order.basisPointsType = decode(int, fields, SHOW_UNSET) # ver 14 field
        contract.comboLegsDescrip = decode(str, fields) # ver 14 field

        if version >= 29:
            contract.comboLegsCount = decode(int, fields)

            if contract.comboLegsCount > 0:
                contract.comboLegs = []
                for idxLeg in range(contract.comboLegsCount):
                    comboLeg = ComboLeg()
                    comboLeg.conId = decode(int, fields)
                    comboLeg.ratio = decode(int, fields)
                    comboLeg.action = decode(str, fields)
                    comboLeg.exchange = decode(str, fields)
                    comboLeg.openClose = decode(int, fields)
                    comboLeg.shortSaleSlot = decode(int, fields)
                    comboLeg.designatedLocation = decode(str, fields)
                    comboLeg.exemptCode = decode(int, fields)
                    contract.comboLegs.append(comboLeg)

            order.orderComboLegsCount = decode(int, fields)
            if order.orderComboLegsCount > 0:
                order.orderComboLegs = []
                for idxOrdLeg in range(order.orderComboLegsCount):
                    orderComboLeg = OrderComboLeg()
                    orderComboLeg.price = decode(float, fields, SHOW_UNSET)
                    order.orderComboLegs.append(orderComboLeg)

        if version >= 26:
            order.smartComboRoutingParamsCount = decode(int, fields)
            if order.smartComboRoutingParamsCount > 0:
                order.smartComboRoutingParams = []
                for idxPrm in range(order.smartComboRoutingParamsCount):
                    tagValue = TagValue()
                    tagValue.tag = decode(str, fields)
                    tagValue.value = decode(str, fields)
                    order.smartComboRoutingParams.append(tagValue)

        if version >= 20:
            order.scaleInitLevelSize = decode(int, fields, SHOW_UNSET)
            order.scaleSubsLevelSize = decode(int, fields, SHOW_UNSET)
        else:
            # ver 15 fields
            order.notSuppScaleNumComponents = decode(int, fields, SHOW_UNSET)
            order.scaleInitLevelSize = decode(int, fields, SHOW_UNSET) # scaleComponectSize

        order.scalePriceIncrement = decode(float, fields, SHOW_UNSET) # ver 15 field

        if version >= 28 and order.scalePriceIncrement != UNSET_DOUBLE \
                and order.scalePriceIncrement > 0.0:
            order.scalePriceAdjustValue = decode(float, fields, SHOW_UNSET)
            order.scalePriceAdjustInterval = decode(int, fields, SHOW_UNSET)
            order.scaleProfitOffset = decode(float, fields, SHOW_UNSET)
            order.scaleAutoReset = decode(bool, fields)
            order.scaleInitPosition = decode(int, fields, SHOW_UNSET)
            order.scaleInitFillQty = decode(int, fields, SHOW_UNSET)
            order.scaleRandomPercent = decode(bool, fields)

        if version >= 24:
            order.hedgeType = decode(str, fields)
            if order.hedgeType:
                order.hedgeParam = decode(str, fields)

        if version >= 25:
            order.optOutSmartRouting = decode(bool, fields)

        order.clearingAccount = decode(str, fields) # ver 19 field
        order.clearingIntent = decode(str, fields) # ver 19 field

        if version >= 22:
            order.notHeld = decode(bool, fields)

        if version >= 20:
            contract.underCompPresent = decode(bool, fields)
            if contract.underCompPresent:
                contract.underComp = UnderComp()
                contract.underComp.conId = decode(int, fields)
                contract.underComp.delta = decode(float, fields)
                contract.underComp.price = decode(float, fields)

        if version >= 21:
            order.algoStrategy = decode(str, fields)
            if order.algoStrategy:
                order.algoParamsCount = decode(int, fields)
                if order.algoParamsCount > 0:
                    order.algoParams = []
                    for idxAlgoPrm in range(order.algoParamsCount):
                        tagValue = TagValue()
                        tagValue.tag = decode(str, fields)
                        tagValue.value = decode(str, fields)
                        order.algoParams.append(tagValue)

        if version >= 33:
            order.solicited = decode(bool, fields)

        orderState = OrderState()

        order.whatIf = decode(bool, fields) # ver 16 field

        orderState.status = decode(str, fields) # ver 16 field
        orderState.initMargin = decode(str, fields) # ver 16 field
        orderState.maintMargin = decode(str, fields) # ver 16 field
        orderState.equityWithLoan = decode(str, fields) # ver 16 field
        orderState.commission = decode(float, fields, SHOW_UNSET) # ver 16 field
        orderState.minCommission = decode(float, fields, SHOW_UNSET) # ver 16 field
        orderState.maxCommission = decode(float, fields, SHOW_UNSET) # ver 16 field
        orderState.commissionCurrency = decode(str, fields) # ver 16 field
        orderState.warningText = decode(str, fields) # ver 16 field

        if version >= 34:
            order.randomizeSize = decode(bool, fields)
            order.randomizePrice = decode(bool, fields)

        if self.serverVersion >= MIN_SERVER_VER_PEGGED_TO_BENCHMARK:
            if order.orderType == "PEG BENCH":
                order.referenceContractId = decode(int, fields)
                order.isPeggedChangeAmountDecrease = decode(bool, fields)
                order.peggedChangeAmount = decode(float, fields)
                order.referenceChangeAmount = decode(float, fields)
                order.referenceExchangeId = decode(str, fields)

            order.conditionsSize = decode(int, fields)
            if order.conditionsSize > 0:
                order.conditions = []
                for idxCond in range(order.conditionsSize):
                    order.conditionType = decode(int, fields)
                    condition = order_condition.Create(order.conditionType)
                    condition.decode(fields)
                    order.conditions.append(condition)

                order.conditionsIgnoreRth = decode(bool, fields)
                order.conditionsCancelOrder = decode(bool, fields)

            order.adjustedOrderType = decode(str, fields)
            order.triggerPrice = decode(float, fields)
            order.trailStopPrice = decode(float, fields)
            order.lmtPriceOffset = decode(float, fields)
            order.adjustedStopPrice = decode(float, fields)
            order.adjustedStopLimitPrice = decode(float, fields)
            order.adjustedTrailingAmount = decode(float, fields)
            order.adjustableTrailingUnit = decode(int, fields)

        if self.serverVersion >= MIN_SERVER_VER_SOFT_DOLLAR_TIER:
            name = decode(str, fields)
            value = decode(str, fields)
            displayName = decode(str, fields)
            order.softDollarTier = SoftDollarTier(name, value, displayName)

        self.wrapper.openOrder(order.orderId, contract, order, orderState)


    def processPortfolioValueMsg(self, fields):

        sMsgId = next(fields)
        version = decode(int, fields)

        # read contract fields
        contract = Contract()
        contract.conId = decode(int, fields) # ver 6 field
        contract.symbol = decode(str, fields)
        contract.secType = decode(str, fields)
        contract.lastTradeDateOrContractMonth = decode(str, fields)
        contract.strike = decode(float, fields)
        contract.right = decode(str, fields)

        if version >= 7:
            contract.multiplier = decode(str, fields)
            contract.primaryExchange = decode(str, fields)

        contract.currency = decode(str, fields)
        contract.localSymbol = decode(str, fields) # ver 2 field
        if version >= 8:
            contract.tradingClass = decode(str, fields)

        if self.serverVersion >= MIN_SERVER_VER_FRACTIONAL_POSITIONS:
            position = decode(float, fields)
        else:
            position = decode(int, fields)

        marketPrice = decode(float, fields)
        marketValue = decode(float, fields)
        averageCost = decode(float, fields) # ver 3 field
        unrealizedPNL = decode(float, fields) # ver 3 field
        realizedPNL = decode(float, fields) # ver 3 field

        accountName = decode(str, fields) # ver 4 field

        if version == 6 and self.serverVersion == 39:
            contract.primaryExchange = decode(str, fields)

        self.wrapper.updatePortfolio( contract,
            position, marketPrice, marketValue, averageCost,
            unrealizedPNL, realizedPNL, accountName)


    def processContractDataMsg(self, fields):

        sMsgId = next(fields)
        version = decode(int, fields)

        reqId = -1
        if version >= 3:
            reqId = decode(int, fields)

        contract = ContractDetails()
        contract.summary.symbol = decode(str, fields)
        contract.summary.secType = decode(str, fields)
        contract.summary.lastTradeDateOrContractMonth = decode(str, fields)
        contract.summary.strike = decode(float, fields)
        contract.summary.right = decode(str, fields)
        contract.summary.exchange = decode(str, fields)
        contract.summary.currency = decode(str, fields)
        contract.summary.localSymbol = decode(str, fields)
        contract.marketName = decode(str, fields)
        contract.summary.tradingClass = decode(str, fields)
        contract.summary.conId = decode(int, fields)
        contract.minTick = decode(float, fields)
        contract.summary.multiplier = decode(str, fields)
        contract.orderTypes = decode(str, fields)
        contract.validExchanges = decode(str, fields)
        contract.priceMagnifier = decode(int, fields) # ver 2 field
        if version >= 4:
            contract.underConId = decode(int, fields)
        if version >= 5:
            contract.longName = decode(str, fields)
            contract.summary.primaryExchange = decode(str, fields)
        if version >= 6:
            contract.contractMonth = decode(str, fields)
            contract.industry = decode(str, fields)
            contract.category = decode(str, fields)
            contract.subcategory = decode(str, fields)
            contract.timeZoneId = decode(str, fields)
            contract.tradingHours = decode(str, fields)
            contract.liquidHours = decode(str, fields)
        if version >= 8:
            contract.evRule = decode(str, fields)
            contract.evMultiplier = decode(int, fields)
        if version >= 7:
            contract.secIdListCount = decode(int, fields)
            if contract.secIdListCount > 0:
                contract.secIdList = []
                for idxSecIdList in range(secIdListCount):
                    tagValue = TagValue()
                    tagValue.tag = decode(str, fields)
                    tagValue.value = decode(str, fields)
                    contract.secIdList.append(tagValue)

        self.wrapper.contractDetails(reqId, contract)


    def processBondContractDataMsg(self, fields):

        sMsgId = next(fields)
        version = decode(int, fields)

        reqId = -1
        if version >= 3:
            reqId = decode(int, fields)

        contract = ContractDetails()
        contract.summary.symbol = decode(str, fields)
        contract.summary.secType = decode(str, fields)
        contract.cusip = decode(str, fields)
        contract.coupon = decode(int, fields)
        contract.maturity = decode(str, fields)
        contract.issueDate = decode(str, fields)
        contract.ratings = decode(str, fields)
        contract.bondType = decode(str, fields)
        contract.couponType = decode(str, fields)
        contract.convertible = decode(bool, fields)
        contract.callable = decode(bool, fields)
        contract.putable = decode(bool, fields)
        contract.descAppend = decode(str, fields)
        contract.summary.exchange = decode(str, fields)
        contract.summary.currency = decode(str, fields)
        contract.marketName = decode(str, fields)
        contract.summary.tradingClass = decode(str, fields)
        contract.summary.conId = decode(int, fields)
        contract.minTick = decode(float, fields)
        contract.orderTypes = decode(str, fields)
        contract.validExchanges = decode(str, fields)
        contract.nextOptionDate = decode(str, fields) # ver 2 field
        contract.nextOptionType = decode(str, fields) # ver 2 field
        contract.nextOptionPartial = decode(bool, fields) # ver 2 field
        contract.notes = decode(str, fields) # ver 2 field
        if version >= 4:
            contract.longName = decode(str, fields)
        if version >= 6:
            contract.evRule = decode(str, fields)
            contract.evMultiplier = decode(int, fields)
        if version >= 5:
            contract.secIdListCount = decode(int, fields)
            if contract.secIdListCount > 0:
                contract.secIdList = []
                for idxSecIdList in range(secIdListCount):
                    tagValue = TagValue()
                    tagValue.tag = decode(str, fields)
                    tagValue.value = decode(str, fields)
                    contract.secIdList.append(tagValue)

        self.wrapper.bondContractDetails(reqId, contract)

    def processScannerDataMsg(self, fields):
        sMsgId = next(fields)
        version = decode(int, fields)
        reqId = decode(int, fields)

        numberOfElements = decode(int, fields)

        for idxEl in range(numberOfElements):
            data = ScanData()
            data.contract = ContractDetails()

            data.rank = decode(int, fields)
            data.contract.summary.conId = decode(int, fields) # ver 3 field
            data.contract.summary.symbol = decode(str, fields)
            data.contract.summary.secType = decode(str, fields)
            data.contract.summary.lastTradeDateOrContractMonth = decode(str, fields)
            data.contract.summary.strike = decode(float, fields)
            data.contract.summary.right = decode(str, fields)
            data.contract.summary.exchange = decode(str, fields)
            data.contract.summary.currency = decode(str, fields)
            data.contract.summary.localSymbol = decode(str, fields)
            data.contract.marketName = decode(str, fields)
            data.contract.summary.tradingClass = decode(str, fields)
            data.distance = decode(str, fields)
            data.benchmark = decode(str, fields)
            data.projection = decode(str, fields)
            data.legsStr = decode(str, fields)
            self.wrapper.scannerData(reqId, data.rank, data.contract,
                data.distance, data.benchmark, data.projection, data.legsStr)

        self.wrapper.scannerDataEnd(reqId)
     

    def processExecutionDataMsg(self, fields):
        sMsgId = next(fields)
        version = decode(int, fields)

        reqId = -1
        if version >= 7:
            reqId = decode(int, fields)

        orderId = decode(int, fields)

        # decode contract fields
        contract = Contract()
        contract.conId = decode(int, fields) # ver 5 field
        contract.symbol = decode(str, fields)
        contract.secType = decode(str, fields)
        contract.lastTradeDateOrContractMonth = decode(str, fields)
        contract.strike = decode(float, fields)
        contract.right = decode(str, fields)
        if version >= 9:
            contract.multiplier = decode(str, fields)
        contract.exchange = decode(str, fields)
        contract.currency = decode(str, fields)
        contract.localSymbol = decode(str, fields)
        if version >= 10:
            contract.tradingClass = decode(str, fields)

        # decode execution fields
        exec = Execution()
        exec.orderId = orderId
        exec.execId = decode(str, fields)
        exec.time = decode(str, fields)
        exec.acctNumber = decode(str, fields)
        exec.exchange = decode(str, fields)
        exec.side = decode(str, fields)

        if self.serverVersion >= MIN_SERVER_VER_FRACTIONAL_POSITIONS:
                exec.shares = decode(float, fields)
        else:
                exec.shares = decode(int, fields)

        exec.price = decode(float, fields)
        exec.permId = decode(int, fields) # ver 2 field
        exec.clientId = decode(int, fields)  # ver 3 field
        exec.liquidation = decode(int, fields) # ver 4 field

        if version >= 6:
            exec.cumQty = decode(float, fields)
            exec.avgPrice = decode(float, fields)

        if version >= 8:
            exec.orderRef = decode(str, fields)

        if version >= 9:
            exec.evRule = decode(str, fields)
            exec.evMultiplier = decode(float, fields)
        if self.serverVersion >= MIN_SERVER_VER_MODELS_SUPPORT:
            exec.modelCode = decode(str, fields)

        self.wrapper.execDetails(reqId, contract, exec)


    def processHistoricalDataMsg(self, fields):
        sMsgId = next(fields)
        version = decode(int, fields)
        reqId = decode(int, fields)
        startDateStr = decode(str, fields) # ver 2 field
        endDateStr = decode(str, fields) # ver 2 field

        itemCount = decode(int, fields)

        bars = []
        for idxBar in range(itemCount):
            bar = BarData()
            bar.date = decode(str, fields)
            bar.open = decode(float, fields)
            bar.high = decode(float, fields)
            bar.low = decode(float, fields)
            bar.close = decode(float, fields)
            bar.volume = decode(int, fields)
            bar.average = decode(float, fields)
            bar.hasGaps = decode(str, fields)
            bar.barCount = decode(int, fields) # ver 3 field

            bars.append(bar)

            self.wrapper.historicalData(reqId, bar.date, bar.open, bar.high, 
                bar.low, bar.close, bar.volume, bar.barCount, bar.average,
                bar.hasGaps == "true")

        #assert len(bars() == itemCount

        # send end of dataset marker
        self.wrapper.historicalDataEnd(reqId, startDateStr, endDateStr)


 
    def processTickOptionComputationMsg(self, fields):
        optPrice = None
        pvDividend = None
        gamma = None
        vega = None
        theta = None
        undPrice = None

        sMsgId = next(fields)
        version = decode(int, fields)
        reqId = decode(int, fields)
        tickTypeInt = decode(int, fields)

        impliedVol = decode(float, fields)
        delta = decode(float, fields)

        if impliedVol < 0:    # -1 is the "not computed" indicator
            impliedVol = None
        if delta > 1. or delta < -1.: # -2 is the "not computed" indicator
            delta = None

        if version >= 6 or \
             tickTypeInt == TickTypeEnum.MODEL_OPTION: # introduced in ver 5

            optPrice = decode(float, fields)
            pvDividend = decode(float, fields)

            if optPrice < 0:    # -1 is the "not computed" indicator
                optPrice = None
            if pvDividend < 0:  # -1 is the "not computed" indicator
                pvDividend = None

        if version >= 6:
            gamma = decode(float, fields)
            vega = decode(float, fields)
            theta = decode(float, fields)
            undPrice = decode(float, fields)

            if gamma > 1 or gamma < -1:  # -2 is the "not yet computed" indicator
                gamma = None
            if vega > 1 or vega < -1:    # -2 is the "not yet computed" indicator
                vega = None
            if theta > 1 or theta < -1:  # -2 is the "not yet computed" indicator
                theta = None
            if undPrice < 0:             # -1 is the "not computed" indicator
                undPrice = None

        self.wrapper.tickOptionComputation(reqId, tickTypeInt, impliedVol, 
            delta, optPrice, pvDividend, gamma, vega, theta, undPrice)



    def processDeltaNeutralValidationMsg(self, fields):
        sMsgId = next(fields)
        version = decode(int, fields)
        reqId = decode(int, fields)

        underComp = UnderComp()

        underComp.conId = decode(int, fields)
        underComp.delta = decode(float, fields)
        underComp.price = decode(float, fields)

        self.wrapper.deltaNeutralValidation(reqId, underComp)


    def processCommissionReportMsg(self, fields):
        sMsgId = next(fields)
        version = decode(int, fields)

        commissionReport = CommissionReport()
        commissionReport.execId = decode(str, fields)
        commissionReport.commission = decode(float, fields)
        commissionReport.currency = decode(str, fields)
        commissionReport.realizedPNL = decode(float, fields)
        commissionReport.yield_ = decode(float, fields);
        commissionReport.yieldRedemptionDate = decode(int, fields)

        self.wrapper.commissionReport(commissionReport)
     
 
    def processPositionDataMsg(self, fields):
        sMsgId = next(fields)
        version = decode(int, fields)

        account = decode(str, fields)

        # decode contract fields
        contract = Contract()
        contract.conId = decode(int, fields)
        contract.symbol = decode(str, fields)
        contract.secType = decode(str, fields)
        contract.lastTradeDateOrContractMonth = decode(str, fields)
        contract.strike = decode(float, fields)
        contract.right = decode(str, fields)
        contract.multiplier = decode(str, fields)
        contract.exchange = decode(str, fields)
        contract.currency = decode(str, fields)
        contract.localSymbol = decode(str, fields)
        if version >= 2:
            contract.tradingClass = decode(str, fields)

        if self.serverVersion >= MIN_SERVER_VER_FRACTIONAL_POSITIONS:
            position = decode(float, fields)
        else:
            position = decode(int, fields)

        avgCost = 0.
        if version >= 3:
            avgCost = decode(float, fields)

        self.wrapper.position(account, contract, position, avgCost)


    def processPositionMultiMsg(self, fields):
        sMsgId = next(fields)

        version = decode(int, fields)
        reqId = decode(int, fields)
        account = decode(str, fields)

        # decode contract fields
        contract = Contract()
        contract.conId = decode(int, fields)
        contract.symbol = decode(str, fields)
        contract.secType = decode(str, fields)
        contract.lastTradeDateOrContractMonth = decode(str, fields)
        contract.strike = decode(float, fields)
        contract.right = decode(str, fields)
        contract.multiplier = decode(str, fields)
        contract.exchange = decode(str, fields)
        contract.currency = decode(str, fields)
        contract.localSymbol = decode(str, fields)
        contract.tradingClass = decode(str, fields)
        position = decode(float, fields)
        avgCost = decode(float, fields)
        modelCode = decode(str, fields)
 
        self.wrapper.positionMulti(reqId, account, modelCode, contract, position, avgCost)
               

    def processSecurityDefinitionOptionParameterMsg(self, fields):
        sMsgId = next(fields)

        reqId = decode(int, fields)
        exchange = decode(str, fields)
        underlyingConId = decode(int, fields)
        tradingClass = decode(str, fields)
        multiplier = decode(str, fields)

        expCount = decode(int, fields)
        expirations = set()
        for idxExp in range(expCount):
            expiration = decode(str, fields)
            expirations.add(expiration)

        strikeCount = decode(int, fields)
        strikes = set()
        for idxStrike in range(strikeCount):
            strike = decode(float, fields)
            strikes.add(strike)

        self.wrapper.securityDefinitionOptionParameter(reqId, exchange, 
            underlyingConId, tradingClass, multiplier, expirations, strikes)


    def processSecurityDefinitionOptionParameterEndMsg(self, fields):
        sMsgId = next(fields)

        reqId = decode(int, fields)
        self.wrapper.securityDefinitionOptionParameterEnd(reqId)


    def processSoftDollarTiersMsg(self, fields):
        sMsgId = next(fields)

        reqId = decode(int, fields)
        nTiers = decode(int, fields)

        tiers = []
        for idxTier in range(nTiers):
                tier = SoftDollarTier()
                tier.name = decode(str, fields)
                tier.value = decode(str, fields)
                tier.dislplayName = decode(str, fields)
                tiers.append(tier)
                
        self.wrapper.softDollarTiers(reqId, tiers)


    def processFamilyCodesMsg(self, fields):
        sMsgId = next(fields)

        nFamilyCodes = decode(int, fields)
        familyCodes = []
        for idxFamCode in range(nFamilyCodes):
            famCode = FamilyCode()
            famCode.accountID = decode(str, fields)
            famCode.familyCodeStr = decode(str, fields)
            familyCodes.append(famCode)

        self.wrapper.familyCodes(familyCodes)


    def processSymbolSamplesMsg(self, fields):
        sMsgId = next(fields)

        reqId = decode(int, fields)
        nContractDescriptions = decode(int, fields)
        contractDescriptions = []
        for idxConDescr in range(nContractDescriptions):
            conDesc = ContractDescription()
            conDesc.contract.conId = decode(int, fields)
            conDesc.contract.symbol = decode(str, fields)
            conDesc.contract.secType = decode(str, fields)
            conDesc.contract.primaryExchange = decode(str, fields)
            conDesc.contract.currency = decode(str, fields)

            nDerivativeSecTypes = decode(int, fields)
            conDesc.derivativeSecTypes = []
            for idxDerivSecType in range(nDerivativeSecTypes):
                derivSecType = decode(str, fields)
                conDesc.derivativeSecTypes.append(derivSecType)

        self.wrapper.symbolSamples(reqId, contractDescriptions)

  
    ######################################################################

    def discover_params(self):
        meth2handleInfo = {}
        for handleInfo in self.msgId2handleInfo.values():
            meth2handleInfo[handleInfo.wrapperMeth] = handleInfo
        
        methods = inspect.getmembers(Wrapper, inspect.isfunction)
        for (name, meth) in methods:
            #LOGGER.debug("meth %s", name)
            sig = inspect.signature(meth)
            handleInfo = meth2handleInfo.get(meth, None)
            if handleInfo is not None:
                handleInfo.wrapperParams = sig.parameters
        
            #for (pname, param) in sig.parameters.items():
            #     LOGGER.debug("\tparam %s %s %s", pname, param.name, param.annotation)
  

    def print_params(self):
        for (msgId, handleInfo) in self.msgId2handleInfo.items():
            if handleInfo.wrapperMeth is not None:
                LOGGER.debug("meth %s", handleInfo.wrapperMeth.__name__)
                if handleInfo.wrapperParams is not None:
                    for (pname, param) in handleInfo.wrapperParams.items():
                         LOGGER.debug("\tparam %s %s %s", pname, param.name, param.annotation)
                    

    def interpret_with_signature(self, fields, handleInfo):
        if handleInfo.wrapperParams is None:
            LOGGER.debug("%s: no param info in ", fields, handleInfo)
            return
       
        nIgnoreFields = 2 #bypass msgId and versionId faster this way
        if len(fields) - nIgnoreFields != len(handleInfo.wrapperParams) - 1:
            LOGGER.error("diff len fields and params %d %d for fields: %s and handleInfo: %s", 
                         len(fields), len(handleInfo.wrapperParams), fields,
                         handleInfo)
            return 

        fieldIdx = nIgnoreFields
        args = []
        for (pname, param) in handleInfo.wrapperParams.items():
            if pname != "self":
                LOGGER.debug("field %s ", fields[fieldIdx])
                arg = fields[fieldIdx].decode()
                LOGGER.debug("arg %s type %s", arg, param.annotation)
                if param.annotation is int:
                    arg = int(arg)
                elif param.annotation is float:
                    arg = float(arg)

                args.append(arg)
                fieldIdx += 1

        #handleInfo.wrapperMeth(self.wrapper, *args)
        method = getattr(self.wrapper.__class__, handleInfo.wrapperMeth.__name__)
        LOGGER.debug("calling %s with %s %s", method, self.wrapper, args)
        method(self.wrapper, *args)
       
    
    def interpret(self, fields):
        if len(fields) == 0:
            LOGGER.debug("no fields")
            return

        sMsgId = fields[0]
        nMsgId = int(sMsgId)

        handleInfo = self.msgId2handleInfo.get(nMsgId, None)

        if handleInfo is None:
            LOGGER.debug("%s: no handleInfo", fields)
            return
       
        try:
            if handleInfo.wrapperMeth is not None:
                self.interpret_with_signature(fields, handleInfo)
            elif handleInfo.processMeth is not None:
                handleInfo.processMeth(self, iter(fields))
        except BadMessage as badMsg:
                theBadMsg = ",".join(fields)
                self.wrapper.error(NO_VALID_ID, BAD_MESSAGE.code(), 
                                   BAD_MESSAGE.msg() + theBadMsg)
                self.conn.disconnect()

 
    msgId2handleInfo = { 
        IN.TICK_PRICE: HandleInfo(proc=processTickPriceMsg), 
        IN.TICK_SIZE: HandleInfo(wrap=Wrapper.tickSize), 
        IN.ORDER_STATUS: HandleInfo(proc=processOrderStatusMsg), 
        IN.ERR_MSG: HandleInfo(wrap=Wrapper.error), 
        IN.OPEN_ORDER: HandleInfo(proc=processOpenOrder), 
        IN.ACCT_VALUE: HandleInfo(wrap=Wrapper.updateAccountValue), 
        IN.PORTFOLIO_VALUE: HandleInfo(proc=processPortfolioValueMsg), 
        IN.ACCT_UPDATE_TIME: HandleInfo(wrap=Wrapper.updateAccountTime), 
        IN.NEXT_VALID_ID: HandleInfo(wrap=Wrapper.nextValidId, ), 
        IN.CONTRACT_DATA: HandleInfo(proc=processContractDataMsg), 
        IN.EXECUTION_DATA: HandleInfo(proc=processExecutionDataMsg), 
        IN.MARKET_DEPTH: HandleInfo(wrap=Wrapper.updateMktDepth), 
        IN.MARKET_DEPTH_L2: HandleInfo(wrap=Wrapper.updateMktDepthL2), 
        IN.NEWS_BULLETINS: HandleInfo(wrap=Wrapper.updateNewsBulletin), 
        IN.MANAGED_ACCTS: HandleInfo(wrap=Wrapper.managedAccounts, ),
        IN.RECEIVE_FA: HandleInfo(wrap=Wrapper.receiveFA), 
        IN.HISTORICAL_DATA: HandleInfo(proc=processHistoricalDataMsg), 
        IN.BOND_CONTRACT_DATA: HandleInfo(proc=processBondContractDataMsg), 
        IN.SCANNER_PARAMETERS: HandleInfo(wrap=Wrapper.scannerParameters), 
        IN.SCANNER_DATA: HandleInfo(proc=processScannerDataMsg), 
        IN.TICK_OPTION_COMPUTATION: HandleInfo(proc=processTickOptionComputationMsg), 
        IN.TICK_GENERIC: HandleInfo(wrap=Wrapper.tickGeneric), 
        IN.TICK_STRING: HandleInfo(wrap=Wrapper.tickString), 
        IN.TICK_EFP: HandleInfo(wrap=Wrapper.tickEFP), 
        IN.CURRENT_TIME: HandleInfo(wrap=Wrapper.currentTime), 
        IN.REAL_TIME_BARS: HandleInfo(wrap=Wrapper.realtimeBar), 
        IN.FUNDAMENTAL_DATA: HandleInfo(wrap=Wrapper.fundamentalData), 
        IN.CONTRACT_DATA_END: HandleInfo(wrap=Wrapper.contractDetailsEnd), 
        IN.OPEN_ORDER_END: HandleInfo(wrap=Wrapper.openOrderEnd), 
        IN.ACCT_DOWNLOAD_END: HandleInfo(wrap=Wrapper.accountDownloadEnd), 
        IN.EXECUTION_DATA_END: HandleInfo(wrap=Wrapper.execDetailsEnd), 
        IN.DELTA_NEUTRAL_VALIDATION: HandleInfo(proc=processDeltaNeutralValidationMsg), 
        IN.TICK_SNAPSHOT_END: HandleInfo(wrap=Wrapper.tickSnapshotEnd), 
        IN.MARKET_DATA_TYPE: HandleInfo(wrap=Wrapper.marketDataType), 
        IN.COMMISSION_REPORT: HandleInfo(proc=processCommissionReportMsg), 
        IN.POSITION_DATA: HandleInfo(proc=processPositionDataMsg), 
        IN.POSITION_END: HandleInfo(wrap=Wrapper.positionEnd), 
        IN.ACCOUNT_SUMMARY: HandleInfo(wrap=Wrapper.accountSummary), 
        IN.ACCOUNT_SUMMARY_END: HandleInfo(wrap=Wrapper.accountSummaryEnd), 
        IN.VERIFY_MESSAGE_API: HandleInfo(wrap=Wrapper.verifyMessageAPI), 
        IN.VERIFY_COMPLETED: HandleInfo(wrap=Wrapper.verifyCompleted), 
        IN.DISPLAY_GROUP_LIST: HandleInfo(wrap=Wrapper.displayGroupList), 
        IN.DISPLAY_GROUP_UPDATED: HandleInfo(wrap=Wrapper.displayGroupUpdated), 
        IN.VERIFY_AND_AUTH_MESSAGE_API: HandleInfo(wrap=Wrapper.verifyAndAuthMessageAPI), 
        IN.VERIFY_AND_AUTH_COMPLETED: HandleInfo(wrap=Wrapper.verifyAndAuthCompleted), 
        IN.POSITION_MULTI: HandleInfo(proc=processPositionMultiMsg), 
        IN.POSITION_MULTI_END: HandleInfo(wrap=Wrapper.positionMultiEnd), 
        IN.ACCOUNT_UPDATE_MULTI: HandleInfo(wrap=Wrapper.accountUpdateMulti), 
        IN.ACCOUNT_UPDATE_MULTI_END: HandleInfo(wrap=Wrapper.accountUpdateMultiEnd), 
        IN.SECURITY_DEFINITION_OPTION_PARAMETER: HandleInfo(proc=processSecurityDefinitionOptionParameterMsg), 
        IN.SECURITY_DEFINITION_OPTION_PARAMETER_END: HandleInfo(proc=processSecurityDefinitionOptionParameterEndMsg), 
        IN.SOFT_DOLLAR_TIERS: HandleInfo(proc=processSoftDollarTiersMsg), 
        IN.FAMILY_CODES: HandleInfo(proc=processFamilyCodesMsg), 
        IN.SYMBOL_SAMPLES: HandleInfo(proc=processSymbolSamplesMsg), 
   }



