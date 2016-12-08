' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Class UpdatePortfolioEventArgs

    Property contract As IBApi.Contract

    Property position As Integer

    Property marketPrice As Double

    Property marketValue As Double

    Property averageCost As Double

    Property unrealisedPNL As Double

    Property realisedPNL As Double

    Property accountName As String

End Class

