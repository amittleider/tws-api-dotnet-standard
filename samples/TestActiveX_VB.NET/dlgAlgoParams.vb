' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class dlgAlgoParams

    Private m_algoStrategy As String
    Private m_algoParams As List(Of IBApi.TagValue)
    ' Private m_tws As AxTWSLib.AxTws

    ' ===============================================================================
    ' Get/Set Properties
    ' ===============================================================================
    Public ReadOnly Property algoStrategy() As String
        Get
            algoStrategy = m_algoStrategy
        End Get
    End Property

    Public ReadOnly Property algoParams() As TWSLib.ITagValueList
        Get
            algoParams = m_algoParams
        End Get
    End Property

    ' ===============================================================================
    ' Public Methods
    ' ===============================================================================
    Public Sub init(ByVal algoStrategy As String, ByVal algoParams As TWSLib.ITagValueList, ByRef tws As AxTWSLib.AxTws)

        If (grdParams.Rows = 0) Then
            Call grdParams.AddItem("Param" & vbTab & "Value")
            ' better way to convert pixels -> twips?
            Dim grdWidth As Integer
            grdWidth = grdParams.Width * 15
            Call grdParams.set_ColWidth(0, grdWidth * 0.4)
            Call grdParams.set_ColWidth(1, grdWidth - grdParams.get_ColWidth(0) - 100)
        End If

        m_tws = tws

        txtStrategy.Text = algoStrategy

        If Not algoParams Is Nothing Then

            Dim Count As Long
            Dim iLoop As Long
            Dim insertPos As Long

            Count = algoParams.Count
            For iLoop = 0 To Count - 1 Step 1

                insertPos = grdParams.Rows

                Dim param As TWSLib.ITagValue
                param = algoParams.Item(iLoop)

                Dim row As String

                With param
                    row = .tag & vbTab & .value
                End With

                grdParams.AddItem(row, insertPos)

            Next iLoop
        End If
    End Sub

    ' ===============================================================================
    ' Form Events
    ' ===============================================================================
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        m_algoStrategy = txtStrategy.Text

        If (m_algoStrategy <> "") Then

            Dim iLoop As Long
            Dim Count As Long

            Count = grdParams.Rows

            If (Count > 1) Then

                m_algoParams = m_tws.createTagValueList()

                For iLoop = 1 To Count - 1 Step 1

                    grdParams.Row = iLoop

                    Dim tag As String
                    Dim value As String

                    grdParams.Col = 0
                    tag = grdParams.Text

                    grdParams.Col = 1
                    value = grdParams.Text

                    Dim param As TWSLib.ITagValue
                    param = m_algoParams.Add(tag, value)

                Next iLoop

            End If
        End If

        m_tws = Nothing

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click

        m_tws = Nothing

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    '--------------------------------------------------------------------------------
    ' Adds a param to the list
    '--------------------------------------------------------------------------------
    Private Sub cmdAddParam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAddParam.Click

        Dim insertPos As Long
        Dim row As String

        insertPos = grdParams.Rows
        row = txtParam.Text & vbTab & txtValue.Text

        grdParams.AddItem(row, insertPos)

    End Sub

    '--------------------------------------------------------------------------------
    ' Removes a param from the list
    '--------------------------------------------------------------------------------
    Private Sub cmdRemoveParam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRemoveParam.Click

        Dim selRowStart, selRowEnd As Long

        ' get the current rows selection if any
        selRowStart = grdParams.Row
        selRowEnd = grdParams.RowSel

        If selRowStart > selRowEnd Then
            Dim temp As Long
            temp = selRowStart
            selRowStart = selRowEnd
            selRowEnd = temp
        End If

        Dim iLoop As Long

        For iLoop = selRowEnd To selRowStart Step -1
            If Not iLoop = 0 Then
                grdParams.RemoveItem(iLoop)
            End If
        Next iLoop

    End Sub

End Class
