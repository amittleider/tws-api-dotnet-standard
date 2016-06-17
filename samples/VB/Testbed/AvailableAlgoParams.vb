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
            forceCompletion As Boolean, allowPastTime As Boolean)

            baseOrder.AlgoStrategy = "ArrivalPx"
            baseOrder.AlgoParams = New List(Of TagValue)
            baseOrder.AlgoParams.Add(New TagValue("maxPctVol", maxPctVol.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("riskAversion", riskAversion))
            baseOrder.AlgoParams.Add(New TagValue("startTime", startTime))
            baseOrder.AlgoParams.Add(New TagValue("endTime", endTime))
            baseOrder.AlgoParams.Add(New TagValue("forceCompletion", BooleantoString(forceCompletion)))
            baseOrder.AlgoParams.Add(New TagValue("allowPastEndTime", BooleantoString(allowPastTime)))
        End Sub
        '! [arrivalpx_params]

        '! [darkice_params]
        Public Shared Sub FillDarkIceParams(baseOrder As Order, displaySize As Integer, startTime As String, endTime As String, allowPastEndTime As Boolean)

            baseOrder.AlgoStrategy = "DarkIce"
            baseOrder.AlgoParams = New List(Of TagValue)
            baseOrder.AlgoParams.Add(New TagValue("displaySize", displaySize.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("startTime", startTime))
            baseOrder.AlgoParams.Add(New TagValue("endTime", endTime))
            baseOrder.AlgoParams.Add(New TagValue("allowPastEndTime", BooleantoString(allowPastEndTime)))
        End Sub
        '! [darkice_params]

        '! [pctvol_params]
        Public Shared Sub FillPctVolParams(baseOrder As Order, pctVol As Double, startTime As String, endTime As String, noTakeLiq As Boolean)

            baseOrder.AlgoStrategy = "PctVol"
            baseOrder.AlgoParams = New List(Of TagValue)
            baseOrder.AlgoParams.Add(New TagValue("pctVol", pctVol.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("startTime", startTime))
            baseOrder.AlgoParams.Add(New TagValue("endTime", endTime))
            baseOrder.AlgoParams.Add(New TagValue("noTakeLiq", BooleantoString(noTakeLiq)))

        End Sub
        '! [pctvol_params]

        '! [twap_params]
        Public Shared Sub FillTwapParams(baseOrder As Order, strategyType As String, startTime As String, endTime As String, allowPastEndTime As Boolean)

            baseOrder.AlgoStrategy = "Twap"
            baseOrder.AlgoParams = New List(Of TagValue)
            baseOrder.AlgoParams.Add(New TagValue("strategyType", strategyType))
            baseOrder.AlgoParams.Add(New TagValue("startTime", startTime))
            baseOrder.AlgoParams.Add(New TagValue("endTime", endTime))
            baseOrder.AlgoParams.Add(New TagValue("allowPastEndTime", BooleantoString(allowPastEndTime)))

        End Sub
        '! [twap_params]

        '! [vwap_params]
        Public Shared Sub FillVwapParams(baseOrder As Order, maxPctVol As Double, startTime As String, endTime As String, allowPastEndTime As Boolean, noTakeLiq As Boolean)

            baseOrder.AlgoStrategy = "Vwap"
            baseOrder.AlgoParams = New List(Of TagValue)
            baseOrder.AlgoParams.Add(New TagValue("maxPctVol", maxPctVol.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("startTime", startTime))
            baseOrder.AlgoParams.Add(New TagValue("endTime", endTime))
            baseOrder.AlgoParams.Add(New TagValue("allowPastEndTime", BooleantoString(allowPastEndTime)))
            baseOrder.AlgoParams.Add(New TagValue("noTakeLiq", BooleantoString(noTakeLiq)))

        End Sub
        '! [vwap_params]

        '! [ad_params]
        Public Shared Sub FillAccumulateDistributeParams(baseOrder As Order, componentSize As Integer, timeBetweenOrders As Integer, randomizeTime20 As Boolean, randomizeSize55 As Boolean,
            giveUp As Integer, catchUp As Boolean, waitOrFill As Boolean, startTime As String, endTime As String)

            baseOrder.AlgoStrategy = "AD"
            baseOrder.AlgoParams = New List(Of TagValue)
            baseOrder.AlgoParams.Add(New TagValue("componentSize", componentSize.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("timeBetweenOrders", timeBetweenOrders.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("randomizeTime20", BooleantoString(randomizeTime20)))
            baseOrder.AlgoParams.Add(New TagValue("randomizeSize55", BooleantoString(randomizeSize55)))
            baseOrder.AlgoParams.Add(New TagValue("giveUp", giveUp.ToString()))
            baseOrder.AlgoParams.Add(New TagValue("catchUp", BooleantoString(catchUp)))
            baseOrder.AlgoParams.Add(New TagValue("waitOrFill", BooleantoString(waitOrFill)))
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

    End Class
End Namespace
