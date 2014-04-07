' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

﻿
Namespace AxTWSLib
    Class _DTwsEvents_updatePortfolioExEvent

        Property contract As IBApi.Contract

        Property position As Integer

        Property marketPrice As Double

        Property marketValue As Double

        Property averageCost As Double

        Property unrealisedPNL As Double

        Property realisedPNL As Double

        Property accountName As String

    End Class
End Namespace
