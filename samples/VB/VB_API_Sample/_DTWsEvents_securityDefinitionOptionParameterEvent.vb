Imports System.Collections.Generic

Namespace AxTWSLib
    Class _DTWsEvents_securityDefinitionOptionParameterEvent

        Property reqId As Integer

        Property exchange As String

        Property underlyingConId As Integer

        Property tradingClass As String

        Property multiplier As String

        Property expirations As HashSet(Of String)

        Property strikes As HashSet(Of Double)

    End Class
End Namespace
