' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

﻿
Namespace AxTWSLib
    Class _DTwsEvents_updateMktDepthL2Event

        Property tickerId As Integer

        Property position As Integer

        Property marketMaker As String

        Property operation As Integer

        Property side As Integer

        Property price As Double

        Property size As Integer

    End Class
End Namespace
