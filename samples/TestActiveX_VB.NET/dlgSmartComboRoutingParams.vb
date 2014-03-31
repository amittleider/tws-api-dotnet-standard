' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Imports System.Windows.Forms
Imports System.Collections.Generic

Friend Class dlgSmartComboRoutingParams

    Private m_smartComboRoutingStrategy As String
    Private m_smartComboRoutingParams As List(Of IBApi.TagValue)
    Private m_tws As Tws

    ' ===============================================================================
    ' Get/Set Properties
    ' ===============================================================================
    Public ReadOnly Property smartComboRoutingStrategy() As String
        Get
            smartComboRoutingStrategy = m_smartComboRoutingStrategy
        End Get
    End Property

    Public ReadOnly Property smartComboRoutingParams() As List(Of IBApi.TagValue)
        Get
            smartComboRoutingParams = m_smartComboRoutingParams
        End Get
    End Property

    ' ===============================================================================
    ' Public Methods
    ' ===============================================================================
    Public Sub init(ByVal smartComboRoutingParams As List(Of IBApi.TagValue), ByRef tws As Tws, ByVal dlgTitle As String)

        Me.Text = dlgTitle
        If (grdParams.Rows = 0) Then
            Call grdParams.AddItem("Param" & vbTab & "Value")
            ' better way to convert pixels -> twips?
            Dim grdWidth As Integer
            grdWidth = grdParams.Width * 15
            Call grdParams.set_ColWidth(0, grdWidth * 0.4)
            Call grdParams.set_ColWidth(1, grdWidth - grdParams.get_ColWidth(0) - 100)
        End If

        m_tws = tws

        If Not smartComboRoutingParams Is Nothing Then

            Dim Count As Long
            Dim iLoop As Long
            Dim insertPos As Long

            Count = smartComboRoutingParams.Count
            For iLoop = 0 To Count - 1 Step 1

                insertPos = grdParams.Rows

                Dim param As IBApi.TagValue
                param = smartComboRoutingParams.Item(iLoop)

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

        Dim iLoop As Long
        Dim Count As Long

        Count = grdParams.Rows

        If (Count > 1) Then

            m_smartComboRoutingParams = New List(Of IBApi.TagValue)

            For iLoop = 1 To Count - 1 Step 1

                grdParams.Row = iLoop

                Dim tag As String
                Dim value As String

                grdParams.Col = 0
                tag = grdParams.Text

                grdParams.Col = 1
                value = grdParams.Text

                Dim param As IBApi.TagValue
                m_smartComboRoutingParams.Add(param)

            Next iLoop

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
