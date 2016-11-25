' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Imports IBApi

Friend Class Tws

    Private m_eReaderSignal As EReaderSignal = New EReaderMonitorSignal
    Private m_EventSource As ApiEventSource
    Private m_client As IBApi.EClient
    Private m_form As Form

    Sub New(form As Form)
        Me.m_form = form
        m_EventSource = New ApiEventSource(m_form)
        m_client = New IBApi.EClientSocket(m_EventSource, m_eReaderSignal)
        m_EventSource.ApiClient = m_client
    End Sub

    Friend ReadOnly Property ApiClient As EClient
        Get
            Return m_client
        End Get
    End Property

    Friend ReadOnly Property ApiEvents As ApiEventSource
        Get
            Return m_EventSource
        End Get
    End Property

    Friend Sub Connect(host As String, port As Integer, clientId As Integer, extraAuth As Boolean, optcapts As String)
        m_client.optionalCapabilities = optcapts

        DirectCast(m_client, EClientSocket).eConnect(host, port, clientId, extraAuth)

        Dim msgThread = New Threading.Thread(AddressOf msgProcessing)
        msgThread.IsBackground = True

        If m_client.ServerVersion() > 0 Then msgThread.Start()
    End Sub

    Private Sub msgProcessing()
        Dim reader = New EReader(m_client, m_eReaderSignal)

        reader.Start()

        While m_client.IsConnected
            m_eReaderSignal.waitForSignal()
            reader.processMsgs()
        End While
    End Sub

End Class
