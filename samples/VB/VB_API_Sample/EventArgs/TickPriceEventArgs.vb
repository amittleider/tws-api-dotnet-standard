' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.
Imports IBApi

Class TickPriceEventArgs

    Property id As Integer

    Property tickType As Utils.TickType

    Property price As Double

    Property attribs As TickAttrib

End Class

