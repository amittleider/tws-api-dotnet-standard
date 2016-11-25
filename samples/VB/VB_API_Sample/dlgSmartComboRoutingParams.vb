' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Imports System.Collections.Generic
Imports System.Linq

Class dlgSmartComboRoutingParams

    Private m_smartComboRoutingStrategy As String
    Private m_smartComboRoutingParams As List(Of IBApi.TagValue)

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
    Public Sub init(smartComboRoutingParams As List(Of IBApi.TagValue), dlgTitle As String)

        Me.Text = dlgTitle

        If (grdParams.Columns.Count = 0) Then
            grdParams.Columns.AddRange(New ColumnHeader() {New ColumnHeader() With {.Text = "Param"}, New ColumnHeader() With {.Text = "Value"}})
        End If

        m_smartComboRoutingParams = smartComboRoutingParams

        If Not smartComboRoutingParams Is Nothing Then
            For Each param In smartComboRoutingParams
                grdParams.Items.Add(New ListViewItem(New String() {param.Tag, param.Value}))
            Next
        End If
    End Sub

    ' ===============================================================================
    ' Form Events
    ' ===============================================================================

    Private Sub OK_Button_Click(sender As System.Object, e As System.EventArgs) Handles OK_Button.Click
        m_smartComboRoutingParams = New List(Of IBApi.TagValue)

        If (grdParams.Items.Count > 0) Then

            For Each item As ListViewItem In grdParams.Items
                Dim tag = item.SubItems(0).Text
                Dim value = item.SubItems(1).Text

                m_smartComboRoutingParams.Add(New IBApi.TagValue(tag, value))
            Next

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

        grdParams.Items.Add(New ListViewItem(New String() {txtParam.Text, txtValue.Text}))

    End Sub

    '--------------------------------------------------------------------------------
    ' Removes a param from the list
    '--------------------------------------------------------------------------------
    Private Sub cmdRemoveParam_Click(sender As Object, e As System.EventArgs) Handles cmdRemoveParam.Click

        grdParams.SelectedItems.OfType(Of ListViewItem).ToList().ForEach(Sub(x) grdParams.Items.Remove(x))

    End Sub

End Class
