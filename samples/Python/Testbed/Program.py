"""
Copyright (C) 2016 Interactive Brokers LLC. All rights reserved.  This code is
subject to the terms and conditions of the IB API Non-Commercial License or the
 IB API Commercial License, as applicable. 
"""

import sys
import argparse
import datetime
import collections
import inspect

import logging
import time
import os.path

from ibapi import wrapper
from ibapi.client import EClient
from ibapi.utils import iswrapper

#types
from ibapi.common import *
from ibapi.order_condition import *
from ibapi.contract import *
from ibapi.order import *
from ibapi.order_state import *
from ibapi.execution import Execution
from ibapi.execution import ExecutionFilter
from ibapi.commission_report import CommissionReport
from ibapi.scanner import ScannerSubscription
from ibapi.ticktype import *

from ibapi.account_summary_tags import *

from ContractSamples import ContractSamples 
from OrderSamples import OrderSamples 
from AvailableAlgoParams import AvailableAlgoParams
from ScannerSubscriptionSamples import ScannerSubscriptionSamples
from FaAllocationSamples import FaAllocationSamples


def SetupLogger():
    if not os.path.exists("log"):
        os.makedirs("log")

    time.strftime("pyibapi.%Y%m%d_%H%M%S.log")

    recfmt = '(%(threadName)s) %(asctime)s.%(msecs)03d %(levelname)s %(filename)s:%(lineno)d %(message)s'

    timefmt = '%y%m%d_%H:%M:%S'

    #logging.basicConfig( level=logging.DEBUG, 
    #                    format=recfmt, datefmt=timefmt)
    logging.basicConfig(filename=time.strftime("log/pyibapi.%y%m%d_%H%M%S.log") , 
                        filemode="w",
                        level=logging.INFO, 
                        format=recfmt, datefmt=timefmt)
    logger = logging.getLogger()
    console = logging.StreamHandler()
    console.setLevel(logging.ERROR)
    logger.addHandler(console)

 

def printWhenExecuting(fn):
    def fn2(self):
        print("   doing", fn.__name__)
        fn(self)
        print("   done w/", fn.__name__)
    return fn2
    

class Activity(Object):
    def __init__(self, reqMsgId, ansMsgId, ansEndMsgId, reqId):
        self.reqMsdId = reqMsgId
        self.ansMsgId = ansMsgId
        self.ansEndMsgId = ansEndMsgId
        self.reqId = reqId


class RequestMgr(Object):
    def __init__(self):
        #I will keep this simple even if slower for now: only one list of
        # requests finding will be done by linear search
        self.requests = []


    def addReq(self, req):
        self.requests.append(req)


    def receivedMsg(self, msg):
        pass



#! [socket_declare]
class TestClient(EClient):
    def __init__(self, wrapper):
        EClient.__init__(self, wrapper)
#! [socket_declare]

        #how many times a method is called to see test coverage
        self.clntMeth2callCount = collections.defaultdict(int)
        self.clntMeth2reqIdIdx = collections.defaultdict(lambda: -1)
        self.reqId2nReq = collections.defaultdict(int)
        self.setupDetectReqId()


    def countReqId(self, methName, fn):
        def countReqId_(*args, **kwargs):
            self.clntMeth2callCount[methName] += 1
            idx = self.clntMeth2reqIdIdx[methName]
            if idx >= 0:
                sign = -1 if 'cancel' in methName else 1
                self.reqId2nReq[sign * args[idx]] +=1 
            return fn(*args, **kwargs)

        return countReqId_
            

    def setupDetectReqId(self):
        
        methods = inspect.getmembers(EClient, inspect.isfunction)
        for (methName, meth) in methods:
            if methName != "send_msg":
            #don't screw up the nice automated logging in the send_msg()
                self.clntMeth2callCount[methName] = 0
                #logging.debug("meth %s", name)
                sig = inspect.signature(meth)
                for (idx, pnameNparam) in enumerate(sig.parameters.items()):
                    (paramName, param) = pnameNparam
                    if paramName == "reqId":
                        self.clntMeth2reqIdIdx[methName] = idx

                setattr(TestClient, methName, self.countReqId(methName, meth))
         
        #print("TestClient.clntMeth2reqIdIdx", self.clntMeth2reqIdIdx)


#! [ewrapperimpl]
class TestWrapper(wrapper.EWrapper):
#! [ewrapperimpl]
    def __init__(self):
        wrapper.EWrapper.__init__(self)

        self.wrapMeth2callCount = collections.defaultdict(int)
        self.wrapMeth2reqIdIdx = collections.defaultdict(lambda: -1)
        self.reqId2nAns = collections.defaultdict(int)
        self.setupDetectWrapperReqId()
 

    #TODO: see how to factor this out !!
    
    def countWrapReqId(self, methName, fn):
        def countWrapReqId_(*args, **kwargs):
            self.wrapMeth2callCount[methName] += 1
            idx = self.wrapMeth2reqIdIdx[methName]
            if idx >= 0:
                self.reqId2nAns[args[idx]] +=1 
            return fn(*args, **kwargs)

        return countWrapReqId_
            

    def setupDetectWrapperReqId(self):
        
        methods = inspect.getmembers(wrapper.EWrapper, inspect.isfunction)
        for (methName, meth) in methods:
            self.wrapMeth2callCount[methName] = 0
            #logging.debug("meth %s", name)
            sig = inspect.signature(meth)
            for (idx, pnameNparam) in enumerate(sig.parameters.items()):
                (paramName, param) = pnameNparam
                # we want to count the errors as 'error' not 'answer'
                if 'error' not in methName and paramName == "reqId":
                    self.wrapMeth2reqIdIdx[methName] = idx

            setattr(TestWrapper, methName, self.countWrapReqId(methName, meth))
     
        #print("TestClient.wrapMeth2reqIdIdx", self.wrapMeth2reqIdIdx)

#this is here for documentation generation
""" 
#! [ereader]
        #this code is in Client::connect() so it's automatically done, no need
        # for user to do it
        self.reader = reader.EReader(self.conn, self.msg_queue)
        self.reader.start()   # start thread

#! [ereader]
"""

#! [socket_init]
class TestApp(TestWrapper, TestClient):
    def __init__(self):
        TestWrapper.__init__(self)
        TestClient.__init__(self, wrapper=self)
#! [socket_init]
        self.nKeybInt = 0
        self.started = False
        self.nextValidOrderId = None
        self.permId2ord = {}
        self.reqId2nErr = collections.defaultdict(int)
        self.globalCancelOnly = False


    def dumpTestCoverageSituation(self):
        for clntMeth in sorted(self.clntMeth2callCount.keys()):
            logging.debug("ClntMeth: %-30s %6d" % (clntMeth,
                                            self.clntMeth2callCount[clntMeth]))

        for wrapMeth in sorted(self.wrapMeth2callCount.keys()):
            logging.debug("WrapMeth: %-30s %6d" % (wrapMeth,
                                            self.wrapMeth2callCount[wrapMeth]))


    def dumpReqAnsErrSituation(self):
        logging.debug("%s\t%s\t%s\t%s" % ("ReqId", "#Req", "#Ans", "#Err"))
        for reqId in sorted(self.reqId2nReq.keys()):
            nReq = self.reqId2nReq.get(reqId, 0)
            nAns = self.reqId2nAns.get(reqId, 0)
            nErr = self.reqId2nErr.get(reqId, 0)
            logging.debug("%d\t%d\t%s\t%d" % (reqId, nReq, nAns, nErr))

    @iswrapper
    #! [connectack]
    def connectAck(self):
        if self.async:
            self.startApi() 
    #! [connectack]

    @iswrapper
    #! [nextvalidid]
    def nextValidId(self, orderId:int):
        super().nextValidId(orderId)

        logging.debug("setting nextValidOrderId: %d", orderId)
        self.nextValidOrderId = orderId
    #! [nextvalidid]

        #we can start now
        self.start()


    def start(self):
        if self.started:
            return

        self.started = True

        if self.globalCancelOnly:
            print("Executing GlobalCancel only")
            self.reqGlobalCancel()
        else:
            print("Executing requests")
            self.reqGlobalCancel()
            self.marketDataType_req()
            self.accountOperations_req()
            self.tickDataOperations_req()
            self.marketDepthOperations_req()
            self.realTimeBars_req()
            self.historicalDataRequests_req()
            self.optionsOperations_req()
            self.marketScanners_req()
            self.reutersFundamentals_req()
            self.bulletins_req()
            self.contractOperations_req()
            self.contractNewsFeed_req()
            self.miscelaneous_req()
            self.linkingOperations()
            self.financialAdvisorOperations()
            self.orderOperations_req()
            print("Executing requests ... finished")


    def keyboardInterrupt(self):
        self.nKeybInt += 1
        if self.nKeybInt == 1:
            self.stop()
        else:
            print("Finishing test")
            self.done = True


    def stop(self):
        print("Executing cancels")
        self.orderOperations_cancel()
        self.accountOperations_cancel()
        self.tickDataOperations_cancel()
        self.marketDepthOperations_cancel() 
        self.realTimeBars_cancel()
        self.historicalDataRequests_cancel()
        self.optionsOperations_cancel()
        self.marketScanners_cancel()
        self.reutersFundamentals_cancel()
        self.bulletins_cancel()
        print("Executing cancels ... finished")


    def nextOrderId(self):
        oid = self.nextValidOrderId
        self.nextValidOrderId += 1
        return oid


    @iswrapper
    #! [error]
    def error(self, reqId:TickerId, errorCode:int, errorString:str):
        super().error(reqId, errorCode, errorString)
        print("Error. Id: " , reqId, " Code: " , errorCode , " Msg: " , errorString)
    #! [error] self.reqId2nErr[reqId] += 1


    @iswrapper
    def winError(self, text:str, lastError:int):
        super().winError(text, lastError)
 

    @iswrapper
    #! [openorder]
    def openOrder(self, orderId:OrderId, contract:Contract, order:Order, 
                  orderState:OrderState):
        super().openOrder(orderId, contract, order, orderState)
        print("OpenOrder. ID:", orderId, contract.symbol, contract.secType,
            "@", contract.exchange, ":", order.action, order.orderType,
            order.totalQuantity, orderState.status)
    #! [openorder]

        order.contract = contract
        self.permId2ord[order.permId] = order


    @iswrapper
    #! [openorderend]
    def openOrderEnd(self):
        super().openOrderEnd()
        print("OpenOrderEnd")
    #! [openorderend]

        logging.debug("Received %d openOrders", len(self.permId2ord))


    @iswrapper
    #! [orderstatus]
    def orderStatus(self, orderId:OrderId , status:str, filled:float,
                    remaining:float, avgFillPrice:float, permId:int, 
                    parentId:int, lastFillPrice:float, clientId:int, 
                    whyHeld:str):
        super().orderStatus(orderId, status, filled, remaining,
            avgFillPrice, permId, parentId, lastFillPrice, clientId, whyHeld)
        print("OrderStatus. Id:", orderId, "Status:", status, "Filled:", filled,
            "Remaining:", remaining ,"AvgFillPrice:", avgFillPrice,
            "PermId:", permId, "ParentId:", parentId, "LastFillPrice:",
            lastFillPrice, "ClientId:", clientId, "WhyHeld:",whyHeld)
    #! [orderstatus]


    @printWhenExecuting
    def accountOperations_req(self):
        # Requesting managed accounts***/
        #! [reqmanagedaccts]
        self.reqManagedAccts()
        #! [reqmanagedaccts]
        # Requesting accounts' summary ***/

        #! [reqaaccountsummary]
        self.reqAccountSummary(9001, "All", AccountSummaryTags.AllTags)
        #! [reqaaccountsummary]

        #! [reqaaccountsummaryledger]
        self.reqAccountSummary(9002, "All", "$LEDGER")
        #! [reqaaccountsummaryledger]

        #! [reqaaccountsummaryledgercurrency]
        self.reqAccountSummary(9003, "All", "$LEDGER:EUR")
        #! [reqaaccountsummaryledgercurrency]

        #! [reqaaccountsummaryledgerall]
        self.reqAccountSummary(9004, "All", "$LEDGER:ALL")
        #! [reqaaccountsummaryledgerall]

        # Subscribing to an account's information. Only one at a time! 
        #! [reqaaccountupdates]
        self.reqAccountUpdates(True, self.account)
        #! [reqaaccountupdates]

        #! [reqaaccountupdatesmulti]
        self.reqAccountUpdatesMulti(9005, self.account, "", True)
        #! [reqaaccountupdatesmulti]

        # Requesting all accounts' positions.
        #! [reqpositions]
        self.reqPositions()
        #! [reqpositions]

        #! [reqpositionsmulti]
        self.reqPositionsMulti(9006, self.account, "")
        #! [reqpositionsmulti]

        #! [reqFamilyCodes]
        self.reqFamilyCodes()
        #! [reqFamilyCodes]


    @printWhenExecuting
    def accountOperations_cancel(self):
        #! [cancelaaccountsummary]
        self.cancelAccountSummary(9001)
        self.cancelAccountSummary(9002)
        self.cancelAccountSummary(9003)
        self.cancelAccountSummary(9004)
        #! [cancelaaccountsummary]

        #! [cancelaaccountupdates]
        self.reqAccountUpdates(False, self.account)
        #! [cancelaaccountupdates]

        #! [cancelaaccountupdatesmulti]
        self.cancelAccountUpdatesMulti(9005)
        #! [cancelaaccountupdatesmulti]
 
        #! [cancelpositions]
        self.cancelPositions()
        #! [cancelpositions]

        #! [cancelpositionsmulti]
        self.cancelPositionsMulti(9006)
        #! [cancelpositionsmulti]


    @iswrapper
    #! [managedaccounts]
    def managedAccounts(self, accountsList:str):
        super().managedAccounts(accountsList)
        print("Account list: ",accountsList)
    #! [managedaccounts]

        self.account = accountsList.split(",")[0]


    @iswrapper
    #! [accountsummary]
    def accountSummary(self, reqId:int, account:str, tag:str, value:str, 
                       currency:str):
        super().accountSummary(reqId, account, tag, value, currency)
        print("Acct Summary. ReqId:" , reqId , "Acct:", account, 
            "Tag: ", tag, "Value:", value, "Currency:", currency)
    #! [accountsummary]


    @iswrapper
    #! [accountsummaryend]
    def accountSummaryEnd(self, reqId:int):
        super().accountSummaryEnd(reqId)
        print("AccountSummaryEnd. Req Id: ", reqId)

    #! [accountsummaryend]


    @iswrapper
    #! [updateaccountvalue]
    def updateAccountValue(self, key:str, val:str, currency:str, 
                            accountName:str):
        super().updateAccountValue(key, val, currency, accountName)
        print("UpdateAccountValue. Key:" ,key, "Value:", val, 
            "Currency:", currency, "AccountName:", accountName)
    #! [updateaccountvalue]


    @iswrapper
    #! [updateportfolio]
    def updatePortfolio(self, contract:Contract, position:float,
                        marketPrice:float, marketValue:float, 
                        averageCost:float, unrealizedPNL:float, 
                        realizedPNL:float, accountName:str):
        super().updatePortfolio(contract, position, marketPrice, marketValue,
                        averageCost, unrealizedPNL, realizedPNL, accountName)
        print("UpdatePortfolio.", contract.symbol, "", contract.secType, "@",
            contract.exchange, "Position:", position, "MarketPrice:", marketPrice,
            "MarketValue:", marketValue, "AverageCost:", averageCost,
            "UnrealizedPNL:", unrealizedPNL, "RealizedPNL:", realizedPNL,
            "AccountName:", accountName)
    #! [updateportfolio]


    @iswrapper
    #! [updateaccounttime]
    def updateAccountTime(self, timeStamp:str):
        super().updateAccountTime(timeStamp)
        print("UpdateAccountTime. Time:", timeStamp)
    #! [updateaccounttime]


    @iswrapper
    #! [accountdownloadend]
    def accountDownloadEnd(self, accountName:str):
        super().accountDownloadEnd(accountName)
        print("Account download finished:", accountName)
    #! [accountdownloadend]


    @iswrapper
    #! [position]
    def position(self, account:str, contract:Contract, position:float, 
                 avgCost:float):
        super().position(account, contract, position, avgCost)
        print("Position.", account, "Symbol:", contract.symbol, "SecType:",
            contract.secType, "Currency:", contract.currency,
            "Position:", position, "Avg cost:", avgCost)
    #! [position]


    @iswrapper
    #! [positionend]
    def positionEnd(self):
        super().positionEnd()
        print("PositionEnd")
    #! [positionend]

 
    @iswrapper    
    #! [positionmulti]
    def positionMulti(self, reqId:int, account:str, modelCode:str,
                      contract:Contract, pos:float, avgCost:float):
        super().positionMulti(reqId, account, modelCode, contract, pos, avgCost)
        print("Position Multi. Request:", reqId, "Account:", account,
            "ModelCode:", modelCode, "Symbol:", contract.symbol, "SecType:",
            contract.secType, "Currency:", contract.currency, ",Position:", 
            pos, "AvgCost:", avgCost)
    #! [positionmulti]


    @iswrapper    
    #! [positionmultiend]
    def positionMultiEnd(self, reqId:int):
        super().positionMultiEnd(reqId)
        print("Position Multi End. Request:" , reqId)
    #! [positionmultiend]


    @iswrapper    
    #! [accountupdatemulti]
    def accountUpdateMulti(self, reqId:int, account:str, modelCode:str,
                            key:str, value:str, currency:str):
        super().accountUpdateMulti(reqId, account, modelCode, key, value,
                                   currency)
        print("Account Update Multi. Request:", reqId, "Account:", account, 
            "ModelCode:", modelCode, "Key:", key , "Value:", value, 
            "Currency:", currency)
    #! [accountupdatemulti]


    @iswrapper    
    #! [accountupdatemultiend]
    def accountUpdateMultiEnd(self, reqId:int):
        super().accountUpdateMultiEnd(reqId)
        print("Account Update Multi End. Request:", reqId)
    #! [accountupdatemultiend]

    
    @iswrapper    
    #! [familyCodes]
    def familyCodes(self, familyCodes:ListOfFamilyCode):
        super().familyCodes(familyCodes)
        print("Family Codes:")
        for familyCode in familyCodes:
            print("Account ID: %s, Family Code Str: %s" % (
                            familyCode.accountID, familyCode.familyCodeStr))
    #! [familyCodes]

 
    def marketDataType_req(self):
        #! [reqmarketdatatype]
        # Switch to live (1) frozen (2) delayed (3) or delayed frozen (4)
        self.reqMarketDataType(MarketDataTypeEnum.DELAYED)
        #! [reqmarketdatatype]

    @iswrapper
    #! [marketdatatype]
    def marketDataType(self, reqId:TickerId, marketDataType:int):
        super().marketDataType(reqId, marketDataType)
        print("MarketDataType. ", reqId, "Type:", marketDataType)
    #! [marketdatatype]
 

    @printWhenExecuting
    def tickDataOperations_req(self):
        # Requesting real time market data 

        #! [reqmktdata]
        self.reqMktData(1101, ContractSamples.USStockAtSmart(), "", False, None)
        self.reqMktData(1001, ContractSamples.StockComboContract(), "", True, None)
        #! [reqmktdata]

        #! [reqmktdata_snapshot]
        self.reqMktData(1003, ContractSamples.FutureComboContract(), "", False, None)
        #! [reqmktdata_snapshot]

        #! [reqmktdata_genticks]
        # Requesting RTVolume (Time & Sales), shortable and Fundamental Ratios generic ticks
        self.reqMktData(1004, ContractSamples.USStock(), "233,236,258", False, None)
        #! [reqmktdata_genticks]

        #! [reqmktdata_contractnews]
        self.reqMktData(1005, ContractSamples.USStock(), "mdoff,292:BZ", False, None)
        self.reqMktData(1006, ContractSamples.USStock(), "mdoff,292:BT", False, None)
        self.reqMktData(1007, ContractSamples.USStock(), "mdoff,292:FLY", False, None)
        self.reqMktData(1008, ContractSamples.USStock(), "mdoff,292:MT", False, None)
        #! [reqmktdata_contractnews]


        #! [reqmktdata_broadtapenews]
        self.reqMktData(1009, ContractSamples.BTbroadtapeNewsFeed(), "mdoff,292", False, None)
        self.reqMktData(1010, ContractSamples.BZbroadtapeNewsFeed(), "mdoff,292", False, None)
        self.reqMktData(1011, ContractSamples.FLYbroadtapeNewsFeed(), "mdoff,292", False, None)
        self.reqMktData(1012, ContractSamples.MTbroadtapeNewsFeed(), "mdoff,292", False, None)
        #! [reqmktdata_broadtapenews]

        #! [reqoptiondatagenticks]
        # Requesting data for an option contract will return the greek values
        self.reqMktData(1002, ContractSamples.OptionWithLocalSymbol(), "", False, None)
        #! [reqoptiondatagenticks]


    @printWhenExecuting
    def tickDataOperations_cancel(self):
        # Canceling the market data subscription 
        #! [cancelmktdata]
        self.cancelMktData(1101)
        self.cancelMktData(1001)
        self.cancelMktData(1002)
        self.cancelMktData(1003)
        #! [cancelmktdata]
 

    @iswrapper
    #! [tickprice]
    def tickPrice(self, reqId: TickerId , tickType: TickType, price: float,
                  attrib:TickAttrib):
        super().tickPrice(reqId, tickType, price, attrib)
        print("Tick Price. Ticker Id:", reqId, "tickType:", tickType, "Price:", 
            price, "CanAutoExecute:", attrib.canAutoExecute, 
            "PastLimit", attrib.pastLimit)
    #! [tickprice]


    @iswrapper
    #! [ticksize]
    def tickSize(self, reqId: TickerId, tickType: TickType, size: int):
        super().tickSize(reqId, tickType, size)
        print("Tick Size. Ticker Id:", reqId, "tickType:", tickType, "Size:", size)
    #! [ticksize]


    @iswrapper
    #! [tickgeneric]
    def tickGeneric(self, reqId:TickerId, tickType:TickType, value:float):
        super().tickGeneric(reqId, tickType, value)
        print("Tick Generic. Ticker Id:" , reqId, "tickType:", tickType, "Value:", value)
    #! [tickgeneric]


    @iswrapper
    #! [tickstring]
    def tickString(self, reqId:TickerId, tickType:TickType, value:str):
        super().tickString(reqId, tickType, value)
        print("Tick string. Ticker Id:", reqId, "Type:", tickType, "Value:", value)
    #! [tickstring]
  

    @iswrapper
    #! [ticksnapshotend]
    def tickSnapshotEnd(self, reqId:int):
        super().tickSnapshotEnd(reqId)
        print("TickSnapshotEnd:", reqId)
    #! [ticksnapshotend]


    @printWhenExecuting
    def marketDepthOperations_req(self):
        # Requesting the Deep Book 
        #! [reqmarketdepth]
        self.reqMktDepth(2101, ContractSamples.USStock(), 5, None)
        self.reqMktDepth(2001, ContractSamples.EurGbpFx(), 5, None)
        #! [reqmarketdepth]


    @iswrapper
    #! [updatemktdepth]
    def updateMktDepth(self, reqId:TickerId , position:int, operation:int,
                        side:int, price:float, size:int): 
        super().updateMktDepth(reqId, position, operation, side, price, size)
        print("UpdateMarketDepth. ", reqId, "Position:", position, "Operation:", 
            operation, "Side:", side, "Price:", price, "Size", size)
    #! [updatemktdepth]

 
    @iswrapper
    #! [updatemktdepthl2]
    def updateMktDepthL2(self, reqId:TickerId , position:int, marketMaker:str,
                          operation:int, side:int, price:float, size:int):
        super().updateMktDepthL2(reqId, position, marketMaker, operation, side,
                                 price, size)
        print("UpdateMarketDepthL2. ", reqId, "Position:", position, "Operation:", 
            operation, "Side:", side, "Price:", price, "Size", size)
    #! [updatemktdepthl2]
 


    @printWhenExecuting
    def marketDepthOperations_cancel(self):
        # Canceling the Deep Book request
        #! [cancelmktdepth]
        self.cancelMktDepth(2101)
        self.cancelMktDepth(2001)
        #! [cancelmktdepth]


    @printWhenExecuting
    def realTimeBars_req(self):
        # Requesting real time bars 
        #! [reqrealtimebars]
        self.reqRealTimeBars(3101, ContractSamples.USStockAtSmart(), 5, "MIDPOINT", True, None)
        self.reqRealTimeBars(3001, ContractSamples.EurGbpFx(), 5, "MIDPOINT", True, None)
        #! [reqrealtimebars]


    @iswrapper
    #! [realtimebar]
    def realtimeBar(self, reqId:TickerId , time:int, open:float, high:float, 
                    low:float, close:float, volume:int, wap:float, 
                    count: int):
        super().realtimeBar(reqId, time, open, high, low, close, volume, wap, count)
        print("RealTimeBars. ", reqId, "Time:", time, "Open:", open, 
            "High:", high, "Low:", low, "Close:", close, "Volume:", volume, 
            "Count:", count, "WAP:", wap)
    #! [realtimebar]

 
    @printWhenExecuting
    def realTimeBars_cancel(self):
        # Canceling real time bars 
        #! [cancelrealtimebars]
        self.cancelRealTimeBars(3101)
        self.cancelRealTimeBars(3001)
        #! [cancelrealtimebars]


    @printWhenExecuting
    def historicalDataRequests_req(self):
        # Requesting historical data 
        #! [reqhistoricaldata]
        queryTime = (datetime.datetime.today() -
                    datetime.timedelta(days=180)).strftime("%Y%m%d %H:%M:%S")
        #String queryTime = DateTime.Now.AddMonths(-6).ToString("yyyyMMdd HH:mm:ss")
        self.reqHistoricalData(4101, ContractSamples.USStockAtSmart(), queryTime, 
                               "1 M", "1 day", "MIDPOINT", 1, 1, None)
        self.reqHistoricalData(4001, ContractSamples.EurGbpFx(), queryTime, 
                               "1 M", "1 day", "MIDPOINT", 1, 1, None)
        self.reqHistoricalData(4002, ContractSamples.EuropeanStock(), queryTime,
                                "10 D", "1 min", "TRADES", 1, 1, None)
        #! [reqhistoricaldata]


    @printWhenExecuting
    def historicalDataRequests_cancel(self):
        # Canceling historical data requests 
        self.cancelHistoricalData(4101)
        self.cancelHistoricalData(4001)
        self.cancelHistoricalData(4002)


    @iswrapper
    #! [historicaldata]
    def historicalData(self, reqId:TickerId , date:str, open:float, high:float, 
                       low:float, close:float, volume:int, barCount:int, 
                        WAP:float, hasGaps:int):
        super().historicalData(reqId, date, open, high, low, close, volume,
                               barCount, WAP, hasGaps)
        print("HistoricalData. ", reqId, " Date:", date, "Open:", open, 
            "High:", high, "Low:", low, "Close:", close, "Volume:", volume, 
            "Count:", barCount, "WAP:", WAP, "HasGaps:", hasGaps)
    #! [historicaldata]

    @iswrapper
    #! [historicaldataend]
    def historicalDataEnd(self, reqId:int, start:str, end:str):
        super().historicalDataEnd(reqId, start, end)
        print("HistoricalDataEnd ", reqId, "from", start, "to", end)
    #! [historicaldataend]


    @printWhenExecuting
    def optionsOperations_req(self):
        #! [reqsecdefoptparams]
        self.reqSecDefOptParams(0, "IBM", "", "STK", 8314)
        #! [reqsecdefoptparams]

        # Calculating implied volatility 
        #! [calculateimpliedvolatility]
        self.calculateImpliedVolatility(5001, ContractSamples.OptionAtBOX(), 5, 85, None)
        #! [calculateimpliedvolatility]

        # Calculating option's price 
        #! [calculateoptionprice]
        self.calculateOptionPrice(5002, ContractSamples.OptionAtBOX(), 0.22, 85, None)
        #! [calculateoptionprice]

        # Exercising options 
        #! [exercise_options]
        self.exerciseOptions(5003, ContractSamples.OptionWithTradingClass(), 1,
                             1, self.account, 1)
        #! [exercise_options]



    @printWhenExecuting
    def optionsOperations_cancel(self):
        # Canceling implied volatility 
        self.cancelCalculateImpliedVolatility(5001)
        # Canceling option's price calculation 
        self.cancelCalculateOptionPrice(5002)


    @iswrapper
    #! [securityDefinitionOptionParameter]
    def securityDefinitionOptionParameter(self, reqId:int, exchange:str,
                        underlyingConId:int, tradingClass:str, multiplier:str, 
                        expirations:SetOfString, strikes:SetOfFloat):
        super().securityDefinitionOptionParameter(reqId, exchange,
            underlyingConId, tradingClass, multiplier, expirations, strikes)
        print("Security Definition Option Parameter. ReqId:%d Exchange:%s "
            "Underlying conId: %d TradingClass:%s Multiplier:%s Exp:%s Strikes:%s", 
            reqId, exchange, underlyingConId, tradingClass, multiplier, 
            ",".join(expirations), ",".join(str(strikes)))
    #! [securityDefinitionOptionParameter]


    @iswrapper
    #! [securityDefinitionOptionParameterEnd]
    def securityDefinitionOptionParameterEnd(self, reqId:int):
        super().securityDefinitionOptionParameterEnd(reqId)
        print("Security Definition Option Parameter End. Request: ", reqId)
    #! [securityDefinitionOptionParameterEnd]


    @iswrapper
    #! [tickoptioncomputation]
    def tickOptionComputation(self, reqId:TickerId, tickType:TickType ,
            impliedVol:float, delta:float, optPrice:float, pvDividend:float, 
            gamma:float, vega:float, theta:float, undPrice:float):  
        super().tickOptionComputation(reqId, tickType, impliedVol, delta,
                            optPrice, pvDividend, gamma, vega, theta, undPrice)
        print("TickOptionComputation. TickerId:", reqId, "tickType:", tickType, 
            "ImpliedVolatility:", impliedVol, "Delta:", delta, "OptionPrice:", 
            optPrice, "pvDividend:", pvDividend, "Gamma: ", gamma, "Vega:", vega, 
            "Theta:", theta, "UnderlyingPrice:", undPrice)
    #! [tickoptioncomputation]


    @printWhenExecuting
    def contractOperations_req(self):
        #! [reqcontractdetails]
        self.reqContractDetails(209, ContractSamples.EurGbpFx())
        self.reqContractDetails(210, ContractSamples.OptionForQuery())
        self.reqContractDetails(211, ContractSamples.Bond())
        #! [reqcontractdetails]

        #! [reqMatchingSymbols]
        self.reqMatchingSymbols(212, "IB")
        #! [reqMatchingSymbols]


    @printWhenExecuting
    def contractNewsFeed_req(self):
        #! [reqcontractdetailsnews]
        self.reqContractDetails(213, ContractSamples.NewsFeedForQuery())
        #! [reqcontractdetailsnews]


    @iswrapper
    #! [contractdetails]
    def contractDetails(self, reqId:int, contractDetails:ContractDetails):
        super().contractDetails(reqId, contractDetails)
        print("ContractDetails. ReqId:", reqId, contractDetails.summary.symbol, 
            contractDetails.summary.secType, "ConId:", contractDetails.summary.conId, 
            "@", contractDetails.summary.exchange)
    #! [contractdetails]


    @iswrapper
    def bondContractDetails(self, reqId:int, contractDetails:ContractDetails):
        super().bondContractDetails(reqId, contractDetails)


    @iswrapper
    #! [contractdetailsend]
    def contractDetailsEnd(self, reqId:int):
        super().contractDetailsEnd(reqId)
        print("ContractDetailsEnd. ",reqId,"\n")
    #! [contractdetailsend]


    @iswrapper
    #! [symbolSamples]
    def symbolSamples(self, reqId:int, 
                      contractDescriptions:ListOfContractDescription):
        super().symbolSamples(reqId, contractDescriptions)
        print("Symbol Samples. Request Id: ", reqId)

        for contractDescription in contractDescriptions:
            derivSecTypes = ""
            for derivSecType in contractDescription.DerivativeSecTypes:
                derivSecTypes += derivSecType
                derivSecTypes += " "
            print("Contract: conId:%s, symbol:%s, secType:%s primExchange:%s, currency:%s, derivativeSecTypes:%s" % (
                contractDescription.contract.conId, 
                contractDescription.contract.symbol, 
                contractDescription.contract.secType, 
                contractDescription.contract.primaryExch,
                contractDescription.contract.currency, derivSecTypes))
    #! [symbolSamples]

 
    @printWhenExecuting
    def marketScanners_req(self):
        # Requesting all available parameters which can be used to build a scanner request
        #! [reqscannerparameters]
        self.reqScannerParameters()
        #! [reqscannerparameters]

        # Triggering a scanner subscription 
        #! [reqscannersubscription]
        self.reqScannerSubscription(7001,
            ScannerSubscriptionSamples.HighOptVolumePCRatioUSIndexes(), None)
        #! [reqscannersubscription]



    @printWhenExecuting
    def marketScanners_cancel(self):
        # Canceling the scanner subscription 
        #! [cancelscannersubscription]
        self.cancelScannerSubscription(7001)
        #! [cancelscannersubscription]


    @iswrapper
    #! [scannerparameters]
    def scannerParameters(self, xml:str):
        super().scannerParameters(xml)
        open('log/scanner.xml', 'w').write(xml)
    #! [scannerparameters]
        

    @iswrapper
    #! [scannerdata]
    def scannerData(self, reqId:int, rank:int, contractDetails:ContractDetails,
                     distance:str, benchmark:str, projection:str, legsStr:str):
        super().scannerData(reqId, rank, contractDetails, distance, benchmark,
                            projection, legsStr)
        print("ScannerData. ", reqId, "Rank:", rank, "Symbol:", contractDetails.summary.symbol, 
            "SecType:", contractDetails.summary.secType, "Currency:", contractDetails.summary.currency , 
            "Distance:", distance, "Benchmark:", benchmark, 
            "Projection:", projection, "Legs String:", legsStr)
    #! [scannerdata]


    @iswrapper
    #! [scannerdataend]
    def scannerDataEnd(self, reqId:int):
        super().scannerDataEnd(reqId)
        print("ScannerDataEnd. ",reqId)
    #! [scannerdataend]

 
    @printWhenExecuting
    def reutersFundamentals_req(self):
        # Requesting Fundamentals 
        #! [reqfundamentaldata]
        self.reqFundamentalData(8001, ContractSamples.USStock(),
                                  "ReportsFinSummary", None)
        #! [reqfundamentaldata]


    @printWhenExecuting
    def reutersFundamentals_cancel(self):
        # Canceling fundamentals request ***/
        #! [cancelfundamentaldata]
        self.cancelFundamentalData(8001)
        #! [cancelfundamentaldata]


    @iswrapper
    #! [fundamentaldata]
    def fundamentalData(self, reqId:TickerId , data:str):
        super().fundamentalData(reqId, data)
        print("FundamentalData. ", reqId, data)
    #! [fundamentaldata]


    @printWhenExecuting
    def bulletins_req(self):
        # Requesting Interactive Broker's news bulletins 
        #! [reqnewsbulletins]
        self.reqNewsBulletins(True)
        #! [reqnewsbulletins]


    @printWhenExecuting
    def bulletins_cancel(self):
        # Canceling IB's news bulletins 
        #! [cancelnewsbulletins]
        self.cancelNewsBulletins()
        #! [cancelnewsbulletins]


    @iswrapper
    #! [updatenewsbulletin]
    def updateNewsBulletin(self, msgId:int, msgType:int, newsMessage:str, 
                           originExch:str):
        super().updateNewsBulletin(msgId, msgType, newsMessage, originExch)
        print("News Bulletins. ", msgId, " Type: ", msgType, "Message:", newsMessage, 
            "Exchange of Origin: ",originExch)
    #! [updatenewsbulletin]

        self.bulletins_cancel()
        

    def ocaSample(self):
        #OCA ORDER
        #! [ocasubmit]
        ocaOrders = []
        ocaOrders.append(OrderSamples.LimitOrder("BUY", 1, 10))
        ocaOrders.append(OrderSamples.LimitOrder("BUY", 1, 11))
        ocaOrders.append(OrderSamples.LimitOrder("BUY", 1, 12))
        OrderSamples.OneCancelsAll("TestOCA_" + self.nextValidOrderId, ocaOrders, 2)
        for o in ocaOrders:
            self.placeOrder(self.nextOrderId(), ContractSamples.USStock(), o)
        #! [ocasubmit]


    def conditionSamples(self):
        #! [order_conditioning_activate]
        mkt = OrderSamples.MarketOrder("BUY", 100)
        #Order will become active if conditioning criteria is met
        mkt.conditionsCancelOrder = True
        mkt.conditions.append(
            OrderSamples.PriceCondition(PriceCondition.TriggerMethodEnum.Default, 
                                        208813720, "SMART", 600, False, False))
        mkt.conditions.append(OrderSamples.ExecutionCondition("EUR.USD", "CASH", "IDEALPRO", True))
        mkt.conditions.append(OrderSamples.MarginCondition(30, True, False))
        mkt.conditions.append(OrderSamples.PercentageChangeCondition(15.0, 208813720, "SMART", True, True))
        mkt.conditions.append(OrderSamples.TimeCondition("20160118 23:59:59", True, False))
        mkt.conditions.append(OrderSamples.VolumeCondition(208813720, "SMART", False, 100, True))
        self.placeOrder(self.nextOrderId(), ContractSamples.EuropeanStock(), mkt)
        #! [order_conditioning_activate]

        #Conditions can make the order active or cancel it. Only LMT orders can be conditionally canceled.
        #! [order_conditioning_cancel]
        lmt = OrderSamples.LimitOrder("BUY", 100, 20)
        #The active order will be cancelled if conditioning criteria is met
        lmt.conditionsCancelOrder = True
        lmt.conditions.append(
            OrderSamples.PriceCondition(PriceCondition.TriggerMethodEnum.Last, 
                                        208813720, "SMART", 600, False, False))
        self.placeOrder(self.nextOrderId(), ContractSamples.EuropeanStock(), lmt)
        #! [order_conditioning_cancel]


    def bracketSample(self):
        #BRACKET ORDER
        #! [bracketsubmit]
        bracket = OrderSamples.BracketOrder(self.nextOrderId(), "BUY", 100, 30, 40, 20)
        for o in bracket:
            self.placeOrder(o.orderId, ContractSamples.EuropeanStock(), o)
            self.nextOrderId()  # need to advance this we'll skip one extra oid, it's fine
        #! [bracketsubmit]


    def hedgeSample(self):
        #F Hedge order
        #! [hedgesubmit]
        #Parent order on a contract which currency differs from your base currency
        parent = OrderSamples.LimitOrder("BUY", 100, 10)
        parent.orderId = self.nextOrderId()
        #Hedge on the currency conversion
        hedge = OrderSamples.MarketFHedge(parent.orderId, "BUY")
        #Place the parent first...
        self.placeOrder(parent.orderId, ContractSamples.EuropeanStock(), parent)
        #Then the hedge order
        self.placeOrder(self.nextOrderId(), ContractSamples.EurGbpFx(), hedge)
        #! [hedgesubmit]


    def testAlgoSamples(self):
        #! [algo_base_order]
        baseOrder = OrderSamples.LimitOrder("BUY", 1000, 1)
        #! [algo_base_order]

        #! [arrivalpx]
        AvailableAlgoParams.FillArrivalPriceParams(baseOrder, 0.1, 
             "Aggressive", "09:00:00 CET", "16:00:00 CET", True, True, 100000)
        self.placeOrder(self.nextOrderId(), ContractSamples.USStockAtSmart(), baseOrder)
        #! [arrivalpx]


        #! [darkice]
        AvailableAlgoParams.FillDarkIceParams(baseOrder, 10, 
                                  "09:00:00 CET", "16:00:00 CET", True, 100000)
        self.placeOrder(self.nextOrderId(), ContractSamples.USStockAtSmart(), baseOrder)
        #! [darkice]


        #! [ad]
        # The Time Zone in "startTime" and "endTime" attributes is ignored and always defaulted to GMT
        AvailableAlgoParams.FillAccumulateDistributeParams(baseOrder, 10, 60, 
                            True, True, 1, True, True, 
                            "20161010-12:00:00 GMT", "20161010-16:00:00 GMT")
        self.placeOrder(self.nextOrderId(), ContractSamples.USStockAtSmart(), baseOrder)
        #! [ad]


        #! [twap]
        AvailableAlgoParams.FillTwapParams(baseOrder, "Marketable", 
                                 "09:00:00 CET", "16:00:00 CET", True, 100000)
        self.placeOrder(self.nextOrderId(), ContractSamples.USStockAtSmart(), baseOrder)
        #! [twap]


        #! [vwap]
        AvailableAlgoParams.FillVwapParams(baseOrder, 0.2, 
                           "09:00:00 CET", "16:00:00 CET", True, True, 100000)
        self.placeOrder(self.nextOrderId(), ContractSamples.USStockAtSmart(), baseOrder)
        #! [vwap]


        #! [balanceimpactrisk]
        AvailableAlgoParams.FillBalanceImpactRiskParams(baseOrder, 0.1, 
                                                        "Aggressive", True)
        self.placeOrder(self.nextOrderId(), ContractSamples.USOptionContract(), baseOrder)
        #! [balanceimpactrisk]


        #! [minimpact]
        AvailableAlgoParams.FillMinImpactParams(baseOrder, 0.3)
        self.placeOrder(self.nextOrderId(), ContractSamples.USOptionContract(), baseOrder)
        #! [minimpact]

        #! [adaptive]
        AvailableAlgoParams.FillAdaptiveParams(baseOrder, "Normal")
        self.placeOrder(self.nextOrderId(), ContractSamples.USStockAtSmart(), baseOrder)
        #! [adaptive]

        #! [closepx]
        AvailableAlgoParams.FillClosePriceParams(baseOrder, 0.5, "Neutral", 
                                                "12:00:00 EST", True, 100000)
        self.placeOrder(self.nextOrderId(), ContractSamples.USStockAtSmart(), baseOrder)
        #! [closepx]

        #! [pctvol]
        AvailableAlgoParams.FillPctVolParams(baseOrder, 0.5, 
                                "12:00:00 EST", "14:00:00 EST", True, 100000)
        self.placeOrder(self.nextOrderId(), ContractSamples.USStockAtSmart(), baseOrder)
        #! [pctvol]               

        #! [pctvolpx]
        AvailableAlgoParams.FillPriceVariantPctVolParams(baseOrder, 
            0.1, 0.05, 0.01, 0.2, "12:00:00 EST", "14:00:00 EST", True, 100000)
        self.placeOrder(self.nextOrderId(), ContractSamples.USStockAtSmart(), baseOrder)
        #! [pctvolpx]

        #! [pctvolsz]
        AvailableAlgoParams.FillSizeVariantPctVolParams(baseOrder, 
                        0.2, 0.4, "12:00:00 EST", "14:00:00 EST", True, 100000)
        self.placeOrder(self.nextOrderId(), ContractSamples.USStockAtSmart(), baseOrder)
        #! [pctvolsz]

        #! [pctvoltm]
        AvailableAlgoParams.FillTimeVariantPctVolParams(baseOrder, 
                        0.2, 0.4, "12:00:00 EST", "14:00:00 EST", True, 100000)
        self.placeOrder(self.nextOrderId(), ContractSamples.USStockAtSmart(), baseOrder)
        #! [pctvoltm] 


    @printWhenExecuting
    def financialAdvisorOperations(self):
        # Requesting FA information ***/
        #! [requestfaaliases]
        self.requestFA(FaDataTypeEnum.ALIASES)
        #! [requestfaaliases]

        #! [requestfagroups]
        self.requestFA(FaDataTypeEnum.GROUPS)
        #! [requestfagroups]

        #! [requestfaprofiles]
        self.requestFA(FaDataTypeEnum.PROFILES)
        #! [requestfaprofiles]

        # Replacing FA information - Fill in with the appropriate XML string. ***/
        #! [replacefaonegroup]
        self.replaceFA(FaDataTypeEnum.GROUPS, FaAllocationSamples.FaOneGroup)
        #! [replacefaonegroup]

        #! [replacefatwogroups]
        self.replaceFA(FaDataTypeEnum.GROUPS, FaAllocationSamples.FaTwoGroups)
        #! [replacefatwogroups]

        #! [replacefaoneprofile]
        self.replaceFA(FaDataTypeEnum.PROFILES, FaAllocationSamples.FaOneProfile)
        #! [replacefaoneprofile]

        #! [replacefatwoprofiles]
        self.replaceFA(FaDataTypeEnum.PROFILES, FaAllocationSamples.FaTwoProfiles)
        #! [replacefatwoprofiles]

        #! [reqSoftDollarTiers]
        self.reqSoftDollarTiers(14001)
        #! [reqSoftDollarTiers]


    @iswrapper    
    #! [receivefa]
    def receiveFA(self, faData:FaDataType , cxml:str):
        super().receiveFA(faData, cxml)
        print("Receiving FA: ",faDataType)
        open('log/fa.xml', 'w').write(xml)
    #! [receivefa]


    @iswrapper    
    #! [softDollarTiers]
    def softDollarTiers(self, reqId:int, tiers:list):
        super().softDollarTiers(reqId, tiers)
        print("Soft Dollar Tiers:", tiers)
    #! [softDollarTiers]


    @printWhenExecuting
    def miscelaneous_req(self):
        # Request TWS' current time ***/
        self.reqCurrentTime()
        # Setting TWS logging level  ***/
        self.setServerLogLevel(1)


    @printWhenExecuting
    def linkingOperations(self):
        self.verifyRequest("a name", "9.71")
        self.verifyMessage("apiData")
        self.verifyAndAuthMessage("apiData", "xyz")
        self.verifyAndAuthRequest("a name", "9.71", "key")

        #! [querydisplaygroups]
        self.queryDisplayGroups(19001)
        #! [querydisplaygroups]

        #! [subscribetogroupevents]
        self.subscribeToGroupEvents(19002, 1)
        #! [subscribetogroupevents]

        #! [updatedisplaygroup]
        self.updateDisplayGroup(19002, "8314@SMART")
        #! [updatedisplaygroup]

        #! [subscribefromgroupevents]
        self.unsubscribeFromGroupEvents(19002)
        #! [subscribefromgroupevents]


    @iswrapper
    #! [displaygrouplist]
    def displayGroupList(self, reqId:int, groups:str):
        super().displayGroupList(reqId, groups)
        print("DisplayGroupList. Request: ", reqId, "Groups", groups)
    #! [displaygrouplist]


    @iswrapper
    #! [displaygroupupdated]
    def displayGroupUpdated(self, reqId:int, contractInfo:str):
        super().displayGroupUpdated(reqId, contractInfo)
        print("displayGroupUpdated. Request:", reqId, "ContractInfo:" , contractInfo)
    #! [displaygroupupdated]


    @printWhenExecuting
    def orderOperations_req(self):
        # Requesting the next valid id ***/
        #! [reqids]
        #The parameter is always ignored.
        self.reqIds(-1)
        #! [reqids]

        # Requesting all open orders ***/
        #! [reqallopenorders]
        self.reqAllOpenOrders()
        #! [reqallopenorders]

        # Taking over orders to be submitted via TWS ***/
        #! [reqautoopenorders]
        self.reqAutoOpenOrders(True)
        #! [reqautoopenorders]

        # Requesting this API client's orders ***/
        #! [reqopenorders]
        self.reqOpenOrders()
        #! [reqopenorders]


        # Placing/modifying an order - remember to ALWAYS increment the 
        # nextValidId after placing an order so it can be used for the next one! 
        # Note if there are multiple clients connected to an account, the 
        # order ID must also be greater than all order IDs returned for orders 
        # to orderStatus and openOrder to this client.

        #! [order_submission]
        self.simplePlaceOid = self.nextOrderId()
        self.placeOrder(self.simplePlaceOid, ContractSamples.USStock(), 
                        OrderSamples.LimitOrder("SELL", 1, 50))
        #! [order_submission]

        #! [faorderoneaccount]
        faOrderOneAccount = OrderSamples.MarketOrder("BUY", 100)
        # Specify the Account Number directly
        faOrderOneAccount.account = "DU119915"
        self.placeOrder(self.nextOrderId(), ContractSamples.USStock(), faOrderOneAccount)
        #! [faorderoneaccount]

        #! [faordergroupequalquantity]
        faOrderGroupEQ = OrderSamples.LimitOrder("SELL", 200, 2000)
        faOrderGroupEQ.faGroup = "Group_Equal_Quantity"
        faOrderGroupEQ.faMethod = "EqualQuantity"
        self.placeOrder(self.nextOrderId(), ContractSamples.SimpleFuture(), faOrderGroupEQ)
        #! [faordergroupequalquantity]

        #! [faordergrouppctchange]
        faOrderGroupPC = OrderSamples.MarketOrder("BUY", 0) 
        # You should not specify any order quantity for PctChange allocation method
        faOrderGroupPC.faGroup = "Pct_Change"
        faOrderGroupPC.faMethod = "PctChange"
        faOrderGroupPC.faPercentage = "100"
        self.placeOrder(self.nextOrderId(), ContractSamples.EurGbpFx(), faOrderGroupPC)
        #! [faordergrouppctchange]

        #! [faorderprofile]
        faOrderProfile = OrderSamples.LimitOrder("BUY", 200, 100)
        faOrderProfile.faProfile = "Percent_60_40"
        self.placeOrder(self.nextOrderId(), ContractSamples.EuropeanStock(), faOrderProfile)
        #! [faorderprofile]

        self.placeOrder(self.nextOrderId(), ContractSamples.OptionAtBOX(), 
            OrderSamples.Block("BUY", 50, 20))
        self.placeOrder(self.nextOrderId(), ContractSamples.OptionAtBOX(), 
            OrderSamples.BoxTop("SELL", 10))
        self.placeOrder(self.nextOrderId(), ContractSamples.FutureComboContract(), 
            OrderSamples.ComboLimitOrder("SELL", 1, 1, False))
        self.placeOrder(self.nextOrderId(), ContractSamples.StockComboContract(), 
            OrderSamples.ComboMarketOrder("BUY", 1, True))
        self.placeOrder(self.nextOrderId(), ContractSamples.OptionComboContract(), 
            OrderSamples.ComboMarketOrder("BUY", 1, False))
        self.placeOrder(self.nextOrderId(), ContractSamples.StockComboContract(), 
            OrderSamples.LimitOrderForComboWithLegPrices("BUY", 1, [10, 5], True))
        self.placeOrder(self.nextOrderId(), ContractSamples.USStock(), 
            OrderSamples.Discretionary("SELL", 1, 45, 0.5))
        self.placeOrder(self.nextOrderId(), ContractSamples.OptionAtBOX(), 
            OrderSamples.LimitIfTouched("BUY", 1, 30, 34))
        self.placeOrder(self.nextOrderId(), ContractSamples.USStock(), 
            OrderSamples.LimitOnClose("SELL", 1, 34))
        self.placeOrder(self.nextOrderId(), ContractSamples.USStock(), 
            OrderSamples.LimitOnOpen("BUY", 1, 35))
        self.placeOrder(self.nextOrderId(), ContractSamples.USStock(), 
            OrderSamples.MarketIfTouched("BUY", 1, 30))
        self.placeOrder(self.nextOrderId(), ContractSamples.USStock(), 
            OrderSamples.MarketOnClose("SELL", 1))
        self.placeOrder(self.nextOrderId(), ContractSamples.USStock(), 
            OrderSamples.MarketOnOpen("BUY", 1))
        self.placeOrder(self.nextOrderId(), ContractSamples.USStock(), 
            OrderSamples.MarketOrder("SELL", 1))
        self.placeOrder(self.nextOrderId(), ContractSamples.USStock(), 
            OrderSamples.MarketToLimit("BUY", 1))
        self.placeOrder(self.nextOrderId(), ContractSamples.OptionAtIse(), 
            OrderSamples.MidpointMatch("BUY", 1))
        self.placeOrder(self.nextOrderId(), ContractSamples.USStock(), 
            OrderSamples.MarketToLimit("BUY", 1))
        self.placeOrder(self.nextOrderId(), ContractSamples.USStock(), 
            OrderSamples.Stop("SELL", 1, 34.4))
        self.placeOrder(self.nextOrderId(), ContractSamples.USStock(), 
            OrderSamples.StopLimit("BUY", 1, 35, 33))
        self.placeOrder(self.nextOrderId(), ContractSamples.USStock(), 
            OrderSamples.StopWithProtection("SELL", 1, 45))
        self.placeOrder(self.nextOrderId(), ContractSamples.USStock(), 
            OrderSamples.SweepToFill("BUY", 1, 35))
        self.placeOrder(self.nextOrderId(), ContractSamples.USStock(), 
            OrderSamples.TrailingStop("SELL", 1, 0.5, 30))
        self.placeOrder(self.nextOrderId(), ContractSamples.USStock(), 
            OrderSamples.TrailingStopLimit("BUY", 1, 50, 5, 30))
        self.placeOrder(self.nextOrderId(), ContractSamples.OptionAtIse(), 
            OrderSamples.Volatility("SELL", 1, 5, 2))

        self.bracketSample()

        self.conditionSamples()

        self.hedgeSample()
        
        #NOTE: the following orders are not supported for Paper Trading
        #self.placeOrder(self.nextOrderId(), ContractSamples.USStock(), OrderSamples.AtAuction("BUY", 100, 30.0))
        #self.placeOrder(self.nextOrderId(), ContractSamples.OptionAtBOX(), OrderSamples.AuctionLimit("SELL", 10, 30.0, 2))
        #self.placeOrder(self.nextOrderId(), ContractSamples.OptionAtBOX(), OrderSamples.AuctionPeggedToStock("BUY", 10, 30, 0.5))
        #self.placeOrder(self.nextOrderId(), ContractSamples.OptionAtBOX(), OrderSamples.AuctionRelative("SELL", 10, 0.6))
        #self.placeOrder(self.nextOrderId(), ContractSamples.SimpleFuture(), OrderSamples.MarketWithProtection("BUY", 1))
        #self.placeOrder(self.nextOrderId(), ContractSamples.USStock(), OrderSamples.PassiveRelative("BUY", 1, 0.5))

        #208813720 (GOOG)
        #self.placeOrder(self.nextOrderId(), ContractSamples.USStock(),
        #    OrderSamples.PeggedToBenchmark("SELL", 100, 33, True, 0.1, 1, 208813720, "ISLAND", 750, 650, 800))

        #STOP ADJUSTABLE ORDERS
        #Order stpParent = OrderSamples.Stop("SELL", 100, 30)
        #stpParent.OrderId = self.nextOrderId()
        #self.placeOrder(stpParent.OrderId, ContractSamples.EuropeanStock(), stpParent)
        #self.placeOrder(self.nextOrderId(), ContractSamples.EuropeanStock(), OrderSamples.AttachAdjustableToStop(stpParent, 35, 32, 33))
        #self.placeOrder(self.nextOrderId(), ContractSamples.EuropeanStock(), OrderSamples.AttachAdjustableToStopLimit(stpParent, 35, 33, 32, 33))
        #self.placeOrder(self.nextOrderId(), ContractSamples.EuropeanStock(), OrderSamples.AttachAdjustableToTrail(stpParent, 35, 32, 32, 1, 0))

        #Order lmtParent = OrderSamples.LimitOrder("BUY", 100, 30)
        #lmtParent.OrderId = self.nextOrderId()
        #self.placeOrder(lmtParent.OrderId, ContractSamples.EuropeanStock(), lmtParent)
        #Attached TRAIL adjusted can only be attached to LMT parent orders.
        #self.placeOrder(self.nextOrderId(), ContractSamples.EuropeanStock(), OrderSamples.AttachAdjustableToTrailAmount(lmtParent, 34, 32, 33, 0.008))
        self.testAlgoSamples()

        # Cancel all orders for all accounts ***/
        #self.reqGlobalCancel()

        # Request the day's executions ***/
        #! [reqexecutions]
        self.reqExecutions(10001, ExecutionFilter())
        #! [reqexecutions]

        
    #! [order_cancellation]
    def orderOperations_cancel(self):
        self.cancelOrder(self.simplePlaceOid)
    #! [order_cancellation]

    @iswrapper    
    #! [execdetails]
    def execDetails(self, reqId:int, contract:Contract, execution:Execution):
        super().execDetails(reqId, contract, execution)
        print("ExecDetails. ", reqId, contract.symbol, contract.secType, contract.currency, 
            execution.execId, execution.orderId, execution.shares)
    #! [execdetails]


    @iswrapper    
    #! [execdetailsend]
    def execDetailsEnd(self, reqId:int):
        super().execDetailsEnd(reqId)
        print("ExecDetailsEnd. ",reqId)
    #! [execdetailsend]


    @iswrapper    
    #! [commissionreport]
    def commissionReport(self, commissionReport:CommissionReport):
        super().commissionReport(commissionReport)
        print("CommissionReport. ", commissionReport.execId, commissionReport.commission,
            commissionReport.currency, commissionReport.realizedPNL)
    #! [commissionreport]
     

def main():
    SetupLogger()                                                                                                                                           
    logging.debug("now is %s", datetime.datetime.now())
    logging.getLogger().setLevel(logging.DEBUG)

    cmdLineParser = argparse.ArgumentParser("api tests")
    #cmdLineParser.add_option("-c", action="store_True", dest="use_cache", default = False, help = "use the cache")
    #cmdLineParser.add_option("-f", action="store", type="string", dest="file", default="", help="the input file")
    cmdLineParser.add_argument("-p", "--port", action="store", type=int, 
        dest="port", default = 4005, help="The TCP port to use")
    cmdLineParser.add_argument("-C", "--global-cancel", action="store_true",
        dest="global_cancel", default = False, 
        help="whether to trigger a globalCancel req")
    args = cmdLineParser.parse_args()
    print("Using args", args)
    logging.debug("Using args %s", args)
    #print(args)


    #enable logging when member vars are assigned
    from ibapi import utils 
    from ibapi.order import Order
    Order.__setattr__ = utils.setattr_log
    from ibapi.contract import Contract,UnderComp
    Contract.__setattr__ = utils.setattr_log 
    UnderComp.__setattr__ = utils.setattr_log 
    from ibapi.tag_value import TagValue
    TagValue.__setattr__ = utils.setattr_log
    TimeCondition.__setattr__ = utils.setattr_log 
    ExecutionCondition.__setattr__ = utils.setattr_log  
    MarginCondition.__setattr__ = utils.setattr_log  
    PriceCondition.__setattr__ = utils.setattr_log 
    PercentChangeCondition.__setattr__ = utils.setattr_log 
    VolumeCondition.__setattr__ = utils.setattr_log 

    #from inspect import signature as sig
    #import code code.interact(local=dict(globals(), **locals()))
    #sys.exit(1)

    #tc = TestClient(None)
    #tc.reqMktData(1101, ContractSamples.USStockAtSmart(), "", False, None)
    #print(tc.reqId2nReq)
    #sys.exit(1)

    try:
        app = TestApp()
        if args.global_cancel:
            app.globalCancelOnly = True
        #! [connect]
        app.connect("127.0.0.1", args.port, clientId=0)
        print("serverVersion:%s connectionTime:%s" % (app.serverVersion(),
                                                    app.twsConnectionTime()))
        #! [connect]
        app.run()
    except:
        raise
    finally:
        app.dumpTestCoverageSituation()
        app.dumpReqAnsErrSituation()


if __name__ == "__main__":
    main()
   
