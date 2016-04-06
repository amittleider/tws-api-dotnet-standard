' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Namespace AxTWSLib
    Class _DTwsEvents_positionMultiEvent

        Property reqId As Integer

        Property account As String

        Property modelCode As String

        Property contract As IBApi.Contract

        Property pos As Integer

        Property avgCost As Double

    End Class
End Namespace
