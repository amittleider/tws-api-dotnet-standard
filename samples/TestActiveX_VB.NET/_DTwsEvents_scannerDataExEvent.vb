' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

﻿
Namespace AxTWSLib
    Class _DTwsEvents_scannerDataExEvent

        Property reqId As Integer

        Property rank As Integer

        Property contractDetails As IBApi.ContractDetails

        Property distance As String

        Property benchmark As String

        Property projection As String

        Property legsStr As String

    End Class
End Namespace
