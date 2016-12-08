' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Class ScannerDataEventArgs

    Property reqId As Integer

    Property rank As Integer

    Property contractDetails As IBApi.ContractDetails

    Property distance As String

    Property benchmark As String

    Property projection As String

    Property legsStr As String

End Class

