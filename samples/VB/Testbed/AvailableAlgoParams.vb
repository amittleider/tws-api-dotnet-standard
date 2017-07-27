Imports IBApi
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace Samples

    Public Class AvailableAlgoParams

        Public Shared Function BooleantoString(bool As Boolean) As String
            If (bool) Then
                Return "1"
            Else
                Return "0"
            End If
        End Function

        '! [arrivalpx_params]
        Public Shared Sub FillArrivalPriceParams(baseOrder As Order, maxPctVol As Double, riskAversion As String, startTime As String, endTime As String,
            forceCompletion As Boolean, allowPastTime As Boolean, monetaryValue As Double)

            baseOrder.AlgoStrategy = "ArrivalPx"
            baseOrder.AlgoParams = New List(Of TagValue)
            baseOrder.AlgoParams.Add(New TagValue("maxPctVol", maxPctVol.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("riskAversion", riskAversion))
            baseOrder.AlgoParams.Add(New TagValue("startTime", startTime))
            baseOrder.AlgoParams.Add(New TagValue("endTime", endTime))
            baseOrder.AlgoParams.Add(New TagValue("forceCompletion", BooleantoString(forceCompletion)))
            baseOrder.AlgoParams.Add(New TagValue("allowPastEndTime", BooleantoString(allowPastTime)))
            baseOrder.AlgoParams.Add(New TagValue("monetaryValue", monetaryValue.ToString()))
        End Sub
        '! [arrivalpx_params]

        '! [darkice_params]
        Public Shared Sub FillDarkIceParams(baseOrder As Order, displaySize As Integer, startTime As String, endTime As String,
            allowPastEndTime As Boolean, monetaryValue As Double)

            baseOrder.AlgoStrategy = "DarkIce"
            baseOrder.AlgoParams = New List(Of TagValue)
            baseOrder.AlgoParams.Add(New TagValue("displaySize", displaySize.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("startTime", startTime))
            baseOrder.AlgoParams.Add(New TagValue("endTime", endTime))
            baseOrder.AlgoParams.Add(New TagValue("allowPastEndTime", BooleantoString(allowPastEndTime)))
            baseOrder.AlgoParams.Add(New TagValue("monetaryValue", monetaryValue.ToString()))
        End Sub
        '! [darkice_params]

        '! [pctvol_params]
        Public Shared Sub FillPctVolParams(baseOrder As Order, pctVol As Double, startTime As String, endTime As String, noTakeLiq As Boolean, monetaryValue As Double)

            baseOrder.AlgoStrategy = "PctVol"
            baseOrder.AlgoParams = New List(Of TagValue)
            baseOrder.AlgoParams.Add(New TagValue("pctVol", pctVol.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("startTime", startTime))
            baseOrder.AlgoParams.Add(New TagValue("endTime", endTime))
            baseOrder.AlgoParams.Add(New TagValue("noTakeLiq", BooleantoString(noTakeLiq)))
            baseOrder.AlgoParams.Add(New TagValue("monetaryValue", monetaryValue.ToString()))

        End Sub
        '! [pctvol_params]

        '! [twap_params]
        Public Shared Sub FillTwapParams(baseOrder As Order, strategyType As String, startTime As String, endTime As String,
            allowPastEndTime As Boolean, monetaryValue As Double)

            baseOrder.AlgoStrategy = "Twap"
            baseOrder.AlgoParams = New List(Of TagValue)
            baseOrder.AlgoParams.Add(New TagValue("strategyType", strategyType))
            baseOrder.AlgoParams.Add(New TagValue("startTime", startTime))
            baseOrder.AlgoParams.Add(New TagValue("endTime", endTime))
            baseOrder.AlgoParams.Add(New TagValue("allowPastEndTime", BooleantoString(allowPastEndTime)))
            baseOrder.AlgoParams.Add(New TagValue("monetaryValue", monetaryValue.ToString()))

        End Sub
        '! [twap_params]

        '! [vwap_params]
        Public Shared Sub FillVwapParams(baseOrder As Order, maxPctVol As Double, startTime As String, endTime As String,
            allowPastEndTime As Boolean, noTakeLiq As Boolean, speedUp As Boolean, monetaryValue As Double)

            baseOrder.AlgoStrategy = "Vwap"
            baseOrder.AlgoParams = New List(Of TagValue)
            baseOrder.AlgoParams.Add(New TagValue("maxPctVol", maxPctVol.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("startTime", startTime))
            baseOrder.AlgoParams.Add(New TagValue("endTime", endTime))
            baseOrder.AlgoParams.Add(New TagValue("allowPastEndTime", BooleantoString(allowPastEndTime)))
            baseOrder.AlgoParams.Add(New TagValue("noTakeLiq", BooleantoString(noTakeLiq)))
            baseOrder.AlgoParams.Add(New TagValue("speedUp", BooleantoString(speedUp)))
            baseOrder.AlgoParams.Add(New TagValue("monetaryValue", monetaryValue.ToString()))

        End Sub
        '! [vwap_params]

        '! [ad_params]
        Public Shared Sub FillAccumulateDistributeParams(baseOrder As Order, componentSize As Integer, timeBetweenOrders As Integer, randomizeTime20 As Boolean, randomizeSize55 As Boolean,
            giveUp As Integer, catchUp As Boolean, waitForFill As Boolean, startTime As String, endTime As String)

            baseOrder.AlgoStrategy = "AD"
            baseOrder.AlgoParams = New List(Of TagValue)
            baseOrder.AlgoParams.Add(New TagValue("componentSize", componentSize.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("timeBetweenOrders", timeBetweenOrders.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("randomizeTime20", BooleantoString(randomizeTime20)))
            baseOrder.AlgoParams.Add(New TagValue("randomizeSize55", BooleantoString(randomizeSize55)))
            baseOrder.AlgoParams.Add(New TagValue("giveUp", giveUp.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("catchUp", BooleantoString(catchUp)))
            baseOrder.AlgoParams.Add(New TagValue("waitForFill", BooleantoString(waitForFill)))
            baseOrder.AlgoParams.Add(New TagValue("startTime", startTime))
            baseOrder.AlgoParams.Add(New TagValue("endTime", endTime))
        End Sub
        '! [ad_params]

        '! [balanceimpactrisk_params]
        Public Shared Sub FillBalanceImpactRiskParams(baseOrder As Order, maxPctVol As Double, riskAversion As String, forceCompletion As Boolean)
            baseOrder.AlgoStrategy = "BalanceImpactRisk"
            baseOrder.AlgoParams = New List(Of TagValue)
            baseOrder.AlgoParams.Add(New TagValue("maxPctVol", maxPctVol.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("riskAversion", riskAversion))
            baseOrder.AlgoParams.Add(New TagValue("forceCompletion", BooleantoString(forceCompletion)))
        End Sub
        '! [balanceimpactrisk_params]

        '! [minimpact_params]
        Public Shared Sub FillMinImpactParams(baseOrder As Order, maxPctVol As Double)

            baseOrder.AlgoStrategy = "MinImpact"
            baseOrder.AlgoParams = New List(Of TagValue)
            baseOrder.AlgoParams.Add(New TagValue("maxPctVol", maxPctVol.ToString()))
        End Sub
        '! [minimpact_params]

        '! [adaptive_params]
        Public Shared Sub FillAdaptiveParams(baseOrder As Order, priority As String)

            baseOrder.AlgoStrategy = "Adaptive"
            baseOrder.AlgoParams = New List(Of TagValue)
            baseOrder.AlgoParams.Add(New TagValue("adaptivePriority", priority))
        End Sub
        '! [adaptive_params]

        '! [closepx_params]
        Public Shared Sub FillClosePriceParams(baseOrder As Order, maxPctVol As Double, riskAversion As String, startTime As String, forceCompletion As Boolean, monetaryValue As Double)

            baseOrder.AlgoStrategy = "ClosePx"
            baseOrder.AlgoParams = New List(Of TagValue)
            baseOrder.AlgoParams.Add(New TagValue("maxPctVol", maxPctVol.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("riskAversion", riskAversion))
            baseOrder.AlgoParams.Add(New TagValue("startTime", startTime))
            baseOrder.AlgoParams.Add(New TagValue("forceCompletion", BooleantoString(forceCompletion)))
            baseOrder.AlgoParams.Add(New TagValue("monetaryValue", monetaryValue.ToString()))

        End Sub
        '! [closepx_params]

        '! [pctvolpx_params]
        Public Shared Sub FillPriceVariantPctVolParams(baseOrder As Order, pctVol As Double, deltaPctVol As Double, minPctVol4Px As Double,
            maxPctVol4Px As Double, startTime As String, endTime As String, noTakeLiq As Boolean, monetaryValue As Double)

            baseOrder.AlgoStrategy = "PctVolPx"
            baseOrder.AlgoParams = New List(Of TagValue)
            baseOrder.AlgoParams.Add(New TagValue("pctVol", pctVol.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("deltaPctVol", deltaPctVol.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("minPctVol4Px", minPctVol4Px.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("maxPctVol4Px", maxPctVol4Px.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("startTime", startTime))
            baseOrder.AlgoParams.Add(New TagValue("endTime", endTime))
            baseOrder.AlgoParams.Add(New TagValue("noTakeLiq", BooleantoString(noTakeLiq)))
            baseOrder.AlgoParams.Add(New TagValue("monetaryValue", monetaryValue.ToString()))

        End Sub
        '! [pctvolpx_params]

        '! [pctvolsz_params]
        Public Shared Sub FillSizeVariantPctVolParams(baseOrder As Order, startPctVol As Double, endPctVol As Double,
            startTime As String, endTime As String, noTakeLiq As Boolean, monetaryValue As Double)

            baseOrder.AlgoStrategy = "PctVolSz"
            baseOrder.AlgoParams = New List(Of TagValue)
            baseOrder.AlgoParams.Add(New TagValue("startPctVol", startPctVol.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("endPctVol", endPctVol.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("startTime", startTime))
            baseOrder.AlgoParams.Add(New TagValue("endTime", endTime))
            baseOrder.AlgoParams.Add(New TagValue("noTakeLiq", BooleantoString(noTakeLiq)))
            baseOrder.AlgoParams.Add(New TagValue("monetaryValue", monetaryValue.ToString()))

        End Sub
        '! [pctvolsz_params]

        '! [pctvoltm_params]
        Public Shared Sub FillTimeVariantPctVolParams(baseOrder As Order, startPctVol As Double, endPctVol As Double,
            startTime As String, endTime As String, noTakeLiq As Boolean, monetaryValue As Double)

            baseOrder.AlgoStrategy = "PctVolTm"
            baseOrder.AlgoParams = New List(Of TagValue)
            baseOrder.AlgoParams.Add(New TagValue("startPctVol", startPctVol.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("endPctVol", endPctVol.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("startTime", startTime))
            baseOrder.AlgoParams.Add(New TagValue("endTime", endTime))
            baseOrder.AlgoParams.Add(New TagValue("noTakeLiq", BooleantoString(noTakeLiq)))
            baseOrder.AlgoParams.Add(New TagValue("monetaryValue", monetaryValue.ToString()))

        End Sub
        '! [pctvoltm_params]

        '! [jefferies_vwap_params]
        Public Shared Sub FillJefferiesVWAPParams(baseOrder As Order, startTime As String, endTime As String, relativeLimit As Double, maxVolumeRate As Double, excludeAuctions As String,
            triggerPrice As Double, wowPrice As Double, minFillSize As Integer, wowOrderPct As Double, wowMode As String, isBuyBack As Boolean, wowReference As String)

            'Must be direct-routed to "JEFFALGO"

            baseOrder.AlgoStrategy = "VWAP"
            baseOrder.AlgoParams = New List(Of TagValue)
            baseOrder.AlgoParams.Add(New TagValue("startTime", startTime))
            baseOrder.AlgoParams.Add(New TagValue("endTime", endTime))
            baseOrder.AlgoParams.Add(New TagValue("relativeLimit", relativeLimit.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("maxVolumeRate", maxVolumeRate.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("excludeAuctions", excludeAuctions))
            baseOrder.AlgoParams.Add(New TagValue("triggerPrice", triggerPrice.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("wowPrice", wowPrice.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("minFillSize", minFillSize.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("wowOrderPct", wowOrderPct.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("wowMode", wowMode))
            baseOrder.AlgoParams.Add(New TagValue("isBuyBack", BooleantoString(isBuyBack)))
            baseOrder.AlgoParams.Add(New TagValue("wowReference", wowReference))
        End Sub
        '! [jefferies_vwap_params]

        '! [csfb_inline_params]
        Public Shared Sub FillCSFBInlineParams(baseOrder As Order, startTime As String, endTime As String, execStyle As String, minPercent As Integer, maxPercent As Integer, displaySize As Integer, auction As String,
            blockFinder As Boolean, blockPrice As Double, minBlockSize As Integer, maxBlockSize As Integer, iWouldPrice As Double)

            'Must be direct-routed to "CSFBALGO"

            baseOrder.AlgoStrategy = "INLINE"
            baseOrder.AlgoParams = New List(Of TagValue)
            baseOrder.AlgoParams.Add(New TagValue("startTime", startTime))
            baseOrder.AlgoParams.Add(New TagValue("endTime", endTime))
            baseOrder.AlgoParams.Add(New TagValue("execStyle", execStyle))
            baseOrder.AlgoParams.Add(New TagValue("minPercent", minPercent.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("maxPercent", maxPercent.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("displaySize", displaySize.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("auction", auction))
            baseOrder.AlgoParams.Add(New TagValue("blockFinder", BooleantoString(blockFinder)))
            baseOrder.AlgoParams.Add(New TagValue("blockPrice", blockPrice.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("minBlockSize", minBlockSize.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("maxBlockSize", maxBlockSize.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("iWouldPrice", iWouldPrice.ToString()))
        End Sub
        '! [csfb_inline_params]

    End Class
End Namespace
