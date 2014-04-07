' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

﻿
Namespace AxTWSLib
    Friend Class _DTwsEvents_tickEFPEvent

        Property tickerId As Integer

        Property field As Utils.TickType

        Property basisPoints As Double

        Property totalDividends As Object

        Property holdDays As Integer

        Property futureExpiry As String

        Property dividendImpact As Double

        Property dividendsToExpiry As Double

        Property formattedBasisPoints As String

        Property impliedFuture As Double

    End Class
End Namespace
