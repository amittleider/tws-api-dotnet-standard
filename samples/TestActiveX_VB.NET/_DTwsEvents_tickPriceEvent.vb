' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

﻿
Namespace AxTWSLib
    Friend Class _DTwsEvents_tickPriceEvent

        Property id As Integer

        Property tickType As Utils.TickType

        Property price As Double

        Property canAutoExecute As Integer

    End Class
End Namespace
