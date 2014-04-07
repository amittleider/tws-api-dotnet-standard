' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

﻿
Namespace AxTWSLib
    Class _DTwsEvents_realtimeBarEvent

        Property reqId As Integer

        Property time As Long

        Property open As Double

        Property high As Double

        Property low As Double

        Property close As Double

        Property volume As Long

        Property WAP As Double

        Property count As Integer

    End Class
End Namespace
