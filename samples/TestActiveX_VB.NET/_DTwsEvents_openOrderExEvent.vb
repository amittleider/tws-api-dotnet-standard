' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

﻿
Namespace AxTWSLib
    Class _DTwsEvents_openOrderExEvent

        Property orderId As Integer

        Property contract As IBApi.Contract

        Property order As IBApi.Order

        Property orderState As IBApi.OrderState

    End Class
End Namespace
