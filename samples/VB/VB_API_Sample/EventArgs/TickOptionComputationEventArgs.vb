' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Class TickOptionComputationEventArgs

    Property tickType As Integer

    Property tickerId As Integer

    Property impliedVolatility As Double

    Property delta As Double

    Property optPrice As Double

    Property pvDividend As Double

    Property gamma As Double

    Property vega As Double

    Property theta As Double

    Property undPrice As Double

End Class

