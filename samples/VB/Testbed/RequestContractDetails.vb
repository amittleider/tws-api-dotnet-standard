' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved.  This code Is subject to the terms
' And conditions of the IB API Non-Commercial License Or the IB API Commercial License, as applicable. 

Imports IBApi
Imports System.Threading

Namespace Samples

    Public Class RequestContractDetails
        Inherits EWrapperImpl

        Private _isFinished As Boolean = False

        Public Property IsFinished() As Boolean
            Get
                Return _isFinished
            End Get
            Set(ByVal value As Boolean)
                _isFinished = value
            End Set
        End Property

        Public Function Main(ByVal args As String())

            Dim testImpl As RequestContractDetails = New RequestContractDetails()
            testImpl.socketClient.eConnect("127.0.0.1", 7496, 0)
            While (testImpl.nextOrderId <= 0)
            End While
            'We can request the whole option's chain by giving a brief description of the contract
            'i.e. we only specify symbol, currency, secType And exchange (SMART)

            Dim optionContract As Contract = ContractSamples.OptionForQuery()

            testImpl.socketClient.reqContractDetails(1, optionContract)

            While (testImpl.IsFinished = False)
            End While
            Thread.Sleep(10000)
            Console.WriteLine("Disconnecting...")
            testImpl.socketClient.eDisconnect()
            Return 0

        End Function

        Public Overloads Sub contractDetailsEnd(reqId As Integer)

            Console.WriteLine("Finished receiving all matching contracts.")
            IsFinished = True

        End Sub


        Public Overloads Sub contractDetails(reqId As Integer, contractDetails As ContractDetails)

            Console.WriteLine("/*******Incoming Contract Details - RequestId " & reqId & "************/")
            Console.WriteLine(contractDetails.Summary.Symbol & " " & contractDetails.Summary.SecType & " @ " & contractDetails.Summary.Exchange)
            Console.WriteLine("lastTradeDate: " & contractDetails.Summary.LastTradeDateOrContractMonth & ", Right: " & contractDetails.Summary.Right)
            Console.WriteLine("Strike: " & contractDetails.Summary.Strike & ", Multiplier: " & contractDetails.Summary.Multiplier)
            Console.WriteLine("/*******     End     *************/\n")
        End Sub

    End Class
End Namespace