"""
Copyright (C) 2016 Interactive Brokers LLC. All rights reserved.  This code is
subject to the terms and conditions of the IB API Non-Commercial License or the
 IB API Commercial License, as applicable. 
"""


import sys

from ibapi.object_implem import Object
from ibapi.tag_value import TagValue
from ibapi.order import Order


class AvailableAlgoParams(Object):
    #! [arrivalpx_params]
    @staticmethod
    def FillArrivalPriceParams(baseOrder:Order, maxPctVol:float, 
                    riskAversion:str, startTime:str, endTime:str, 
                    forceCompletion:bool, allowPastTime:bool,
                    monetaryValue:float):
        baseOrder.algoStrategy = "ArrivalPx"
        baseOrder.algoParams = []
        baseOrder.algoParams.append(TagValue("maxPctVol", maxPctVol))
        baseOrder.algoParams.append(TagValue("riskAversion", riskAversion))
        baseOrder.algoParams.append(TagValue("startTime", startTime))
        baseOrder.algoParams.append(TagValue("endTime", endTime))
        baseOrder.algoParams.append(TagValue("forceCompletion",
                                             int(forceCompletion)))
        baseOrder.algoParams.append(TagValue("allowPastEndTime",
                                             int(allowPastTime)))
        baseOrder.algoParams.append(TagValue("monetaryValue", monetaryValue))
    #! [arrivalpx_params]


    #! [darkice_params]
    @staticmethod
    def FillDarkIceParams(baseOrder:Order, displaySize:int, startTime:str,
                          endTime:str, allowPastEndTime:bool,
                          monetaryValue:float):
        baseOrder.algoStrategy = "DarkIce"
        baseOrder.algoParams = []
        baseOrder.algoParams.append(TagValue("displaySize", displaySize))
        baseOrder.algoParams.append(TagValue("startTime", startTime))
        baseOrder.algoParams.append(TagValue("endTime", endTime))
        baseOrder.algoParams.append(TagValue("allowPastEndTime",
                                             int(allowPastEndTime)))
        baseOrder.algoParams.append(TagValue("monetaryValue", monetaryValue))
    #! [darkice_params]


    #! [pctvol_params]
    @staticmethod
    def FillPctVolParams(baseOrder:Order, pctVol:float, startTime:str,
                         endTime:str, noTakeLiq:bool,
                         monetaryValue:float):
        baseOrder.algoStrategy = "PctVol"
        baseOrder.algoParams = []
        baseOrder.algoParams.append(TagValue("pctVol", pctVol))
        baseOrder.algoParams.append(TagValue("startTime", startTime))
        baseOrder.algoParams.append(TagValue("endTime", endTime))
        baseOrder.algoParams.append(TagValue("noTakeLiq", int(noTakeLiq)))
        baseOrder.algoParams.append(TagValue("monetaryValue", monetaryValue))
    #! [pctvol_params]


    #! [twap_params]
    @staticmethod
    def FillTwapParams(baseOrder:Order, strategyType:str, startTime:str,
                        endTime:str, allowPastEndTime:bool,
                        monetaryValue:float):
        baseOrder.algoStrategy = "Twap"
        baseOrder.algoParams = []
        baseOrder.algoParams.append(TagValue("strategyType", strategyType))
        baseOrder.algoParams.append(TagValue("startTime", startTime))
        baseOrder.algoParams.append(TagValue("endTime", endTime))
        baseOrder.algoParams.append(TagValue("allowPastEndTime",
                                             int(allowPastEndTime)))
        baseOrder.algoParams.append(TagValue("monetaryValue", monetaryValue))
    #! [twap_params]


    #! [vwap_params]
    @staticmethod
    def FillVwapParams(baseOrder:Order, maxPctVol:float, startTime:str,
                        endTime:str, allowPastEndTime:bool, noTakeLiq:bool,
                        monetaryValue:float):
        baseOrder.algoStrategy = "Vwap"
        baseOrder.algoParams = []
        baseOrder.algoParams.append(TagValue("maxPctVol", maxPctVol))
        baseOrder.algoParams.append(TagValue("startTime", startTime))
        baseOrder.algoParams.append(TagValue("endTime", endTime))
        baseOrder.algoParams.append(TagValue("allowPastEndTime",
                                             int(allowPastEndTime)))
        baseOrder.algoParams.append(TagValue("noTakeLiq", int(noTakeLiq)))
        baseOrder.algoParams.append(TagValue("monetaryValue", monetaryValue))
    #! [vwap_params]


    #! [ad_params]
    @staticmethod
    def FillAccumulateDistributeParams(baseOrder:Order, componentSize:int, 
            timeBetweenOrders:int, randomizeTime20:bool, randomizeSize55:bool,
            giveUp:int, catchUp:bool, waitForFill:bool, startTime:str, 
            endTime:str):
        baseOrder.algoStrategy = "AD"
        baseOrder.algoParams = []
        baseOrder.algoParams.append(TagValue("componentSize", componentSize))
        baseOrder.algoParams.append(TagValue("timeBetweenOrders", timeBetweenOrders))
        baseOrder.algoParams.append(TagValue("randomizeTime20",
                                             int(randomizeTime20)))
        baseOrder.algoParams.append(TagValue("randomizeSize55",
                                             int(randomizeSize55)))
        baseOrder.algoParams.append(TagValue("giveUp", giveUp))
        baseOrder.algoParams.append(TagValue("catchUp", int(catchUp)))
        baseOrder.algoParams.append(TagValue("waitForFill", int(waitForFill)))
        baseOrder.algoParams.append(TagValue("startTime", startTime))
        baseOrder.algoParams.append(TagValue("endTime", endTime))
    #! [ad_params]


    #! [balanceimpactrisk_params]
    @staticmethod
    def FillBalanceImpactRiskParams(baseOrder:Order, maxPctVol:float, 
                                    riskAversion:str, forceCompletion:bool):
        baseOrder.algoStrategy = "BalanceImpactRisk"
        baseOrder.algoParams = []
        baseOrder.algoParams.append(TagValue("maxPctVol", maxPctVol))
        baseOrder.algoParams.append(TagValue("riskAversion", riskAversion))
        baseOrder.algoParams.append(TagValue("forceCompletion",
                                                int(forceCompletion)))
    #! [balanceimpactrisk_params]


    #! [minimpact_params]
    @staticmethod
    def FillMinImpactParams(baseOrder:Order, maxPctVol:float):
        baseOrder.algoStrategy = "MinImpact"
        baseOrder.algoParams = []
        baseOrder.algoParams.append(TagValue("maxPctVol", maxPctVol))
    #! [minimpact_params]


    #! [adaptive_params]
    @staticmethod
    def FillAdaptiveParams(baseOrder:Order, priority:str):
        baseOrder.algoStrategy = "Adaptive"
        baseOrder.algoParams = []
        baseOrder.algoParams.append(TagValue("adaptivePriority", priority))
    #! [adaptive_params]


    #! [closepx_params]
    def FillClosePriceParams(baseOrder:Order, maxPctVol:float, riskAversion:str, 
                             startTime:str, forceCompletion:bool, 
                             monetaryValue:float):
        baseOrder.AlgoStrategy = "ClosePx"
        baseOrder.AlgoParams = []
        baseOrder.AlgoParams.append(TagValue("maxPctVol", maxPctVol))
        baseOrder.AlgoParams.append(TagValue("riskAversion", riskAversion))
        baseOrder.AlgoParams.append(TagValue("startTime", startTime))
        baseOrder.AlgoParams.append(TagValue("forceCompletion", int(forceCompletion)))
        baseOrder.AlgoParams.append(TagValue("monetaryValue", monetaryValue))
    #! [closepx_params]


    #! [pctvolpx_params]
    def FillPriceVariantPctVolParams(baseOrder:Order, pctVol:float, 
                                     deltaPctVol:float, minPctVol4Px:float, 
                                     maxPctVol4Px:float, startTime:str,
                                     endTime:str, noTakeLiq:bool, 
                                     monetaryValue:float):
        baseOrder.AlgoStrategy = "PctVolPx"
        baseOrder.AlgoParams = []
        baseOrder.AlgoParams.append(TagValue("pctVol", pctVol))
        baseOrder.AlgoParams.append(TagValue("deltaPctVol", deltaPctVol))
        baseOrder.AlgoParams.append(TagValue("minPctVol4Px", minPctVol4Px))
        baseOrder.AlgoParams.append(TagValue("maxPctVol4Px", maxPctVol4Px))
        baseOrder.AlgoParams.append(TagValue("startTime", startTime))
        baseOrder.AlgoParams.append(TagValue("endTime", endTime))
        baseOrder.AlgoParams.append(TagValue("noTakeLiq", int(noTakeLiq)))
        baseOrder.AlgoParams.append(TagValue("monetaryValue", monetaryValue))
    #! [pctvolpx_params]


    #! [pctvolsz_params]
    def FillSizeVariantPctVolParams(baseOrder:Order, startPctVol:float, 
                                    endPctVol:float, startTime:str, 
                                    endTime:str, noTakeLiq:bool, 
                                    monetaryValue:float):
        baseOrder.AlgoStrategy = "PctVolSz"
        baseOrder.AlgoParams = []
        baseOrder.AlgoParams.append(TagValue("startPctVol", startPctVol))
        baseOrder.AlgoParams.append(TagValue("endPctVol", endPctVol))
        baseOrder.AlgoParams.append(TagValue("startTime", startTime))
        baseOrder.AlgoParams.append(TagValue("endTime", endTime))
        baseOrder.AlgoParams.append(TagValue("noTakeLiq", int(noTakeLiq)))
        baseOrder.AlgoParams.append(TagValue("monetaryValue", monetaryValue))
    #! [pctvolsz_params]


    #! [pctvoltm_params]
    def FillTimeVariantPctVolParams(baseOrder:Order, startPctVol:float, 
                                    endPctVol:float, startTime:str, 
                                    endTime:str, noTakeLiq:bool, 
                                    monetaryValue:float):
        baseOrder.AlgoStrategy = "PctVolTm"
        baseOrder.AlgoParams = []
        baseOrder.AlgoParams.append(TagValue("startPctVol", startPctVol))
        baseOrder.AlgoParams.append(TagValue("endPctVol", endPctVol))
        baseOrder.AlgoParams.append(TagValue("startTime", startTime))
        baseOrder.AlgoParams.append(TagValue("endTime", endTime))
        baseOrder.AlgoParams.append(TagValue("noTakeLiq", int(noTakeLiq)))
        baseOrder.AlgoParams.append(TagValue("monetaryValue", monetaryValue))
    #! [pctvoltm_params]


def Test():
    av = AvailableAlgoParams()
 
if "__main__" == __name__:
    Test()
        
