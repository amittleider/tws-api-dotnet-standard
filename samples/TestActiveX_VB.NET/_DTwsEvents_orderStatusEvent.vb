' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

﻿
Namespace AxTWSLib
    Class _DTwsEvents_orderStatusEvent

        Property orderId As Integer

        Property status As String

        Property filled As Integer

        Property remaining As Integer

        Property avgFillPrice As Double

        Property permId As Integer

        Property parentId As Integer

        Property lastFillPrice As Double

        Property clientId As Integer

        Property whyHeld As String

    End Class
End Namespace
