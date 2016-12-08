' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Class UpdateMktDepthL2EventArgs

    Property tickerId As Integer

    Property position As Integer

    Property marketMaker As String

    Property operation As Integer

    Property side As Integer

    Property price As Double

    Property size As Integer

End Class

