' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Linq

Class dlgAlgoParams

    Private m_algoStrategy As String
    Private m_algoParams As List(Of IBApi.TagValue)

    ' ===============================================================================
    ' Get/Set Properties
    ' ===============================================================================
    Public ReadOnly Property algoStrategy() As String
        Get
            algoStrategy = m_algoStrategy
        End Get
    End Property

    Public ReadOnly Property algoParams() As List(Of IBApi.TagValue)
        Get
            algoParams = m_algoParams
        End Get
    End Property

    ' ===============================================================================
    ' Public Methods
    ' ===============================================================================
    Public Sub init(algoStrategy As String, algoParams As List(Of IBApi.TagValue))
        If (grdParams.Items.Count = 0) Then
            grdParams.Columns.AddRange(New ColumnHeader() {New ColumnHeader() With {.Text = "Param"}, New ColumnHeader() With {.Text = "Value"}})
            ' better way to convert pixels -> twips?
            'Dim grdWidth As Integer
            'grdWidth = grdParams.Width * 15
            'grdParams.Columns(0).Width = grdWidth * 0.4
            'grdParams.Columns(1).Width = grdWidth - grdParams.Columns(0).Width - 100
        End If

        txtStrategy.Text = algoStrategy

        If algoParams IsNot Nothing Then
            For Each param In algoParams
                grdParams.Items.Add(New ListViewItem(New String() {param.Tag, param.Value}))
            Next
        End If
    End Sub

    ' ===============================================================================
    ' Form Events
    ' ===============================================================================

    Private Sub OK_Button_Click(sender As System.Object, e As System.EventArgs) Handles OK_Button.Click
        m_algoStrategy = txtStrategy.Text

        If (m_algoStrategy <> "") Then
            If grdParams.Items.Count > 0 Then
                m_algoParams = New List(Of IBApi.TagValue)
                For Each row In grdParams.Items
                    Dim tag = row.SubItems(0).Text
                    Dim value = row.SubItems(1).Text
                    m_algoParams.Add(New IBApi.TagValue(tag, value))
                Next
            End If
        End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(sender As System.Object, e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    '--------------------------------------------------------------------------------
    ' Adds a param to the list
    '--------------------------------------------------------------------------------
    Private Sub cmdAddParam_Click(sender As Object, e As System.EventArgs) Handles cmdAddParam.Click
        Dim row = New String() {txtParam.Text, txtValue.Text}
        grdParams.Items.Add(New ListViewItem(row))
    End Sub

    '--------------------------------------------------------------------------------
    ' Removes a param from the list
    '--------------------------------------------------------------------------------
    Private Sub cmdRemoveParam_Click(sender As Object, e As System.EventArgs) Handles cmdRemoveParam.Click
        grdParams.SelectedItems.OfType(Of ListViewItem).ToList().ForEach(Sub(x) grdParams.Items.Remove(x))
    End Sub

End Class
