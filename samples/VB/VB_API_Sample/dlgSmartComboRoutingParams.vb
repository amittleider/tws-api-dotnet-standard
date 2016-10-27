' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Linq

Class dlgSmartComboRoutingParams

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

        If (grdParams.Columns.Count = 0) Then
            Call grdParams.Columns.AddRange(New ColumnHeader() {New ColumnHeader() With {.Text = "Param"}, New ColumnHeader() With {.Text = "Value"}})
            ' better way to convert pixels -> twips?
            'Dim grdWidth As Integer
            'grdWidth = grdParams.Width * 15
            'grdParams.Columns(0).Width = grdWidth * 0.4
            'grdParams.Columns(1).Width = grdWidth - grdParams.Columns(0).Width - 100
        End If

        m_tws = tws
        m_smartComboRoutingParams = smartComboRoutingParams

        If Not smartComboRoutingParams Is Nothing Then

            Dim Count As Long
            Dim iLoop As Long

            Count = smartComboRoutingParams.Count

            For iLoop = 0 To Count - 1 Step 1

                Dim param As IBApi.TagValue

                param = smartComboRoutingParams.Item(iLoop)

                grdParams.Items.Add(New ListViewItem(New String() {param.Tag, param.Value}))

            Next iLoop
        End If
    End Sub

    ' ===============================================================================
    ' Form Events
    ' ===============================================================================
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        Dim iLoop As Int32
        Dim Count As Long

        Count = grdParams.Items.Count
        m_smartComboRoutingParams = New List(Of IBApi.TagValue)

        If (Count > 0) Then

            For iLoop = 0 To Count - 1 Step 1

                'grdParams.Row = iLoop

                Dim tag As String
                Dim value As String

                'grdParams.Col = 0
                tag = grdParams.Items(iLoop).SubItems(0).Text

                'grdParams.Col = 1
                value = grdParams.Items(iLoop).SubItems(1).Text

                m_smartComboRoutingParams.Add(New IBApi.TagValue(tag, value))

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

        grdParams.Items.Add(New ListViewItem(New String() {txtParam.Text, txtValue.Text}))

    End Sub

    '--------------------------------------------------------------------------------
    ' Removes a param from the list
    '--------------------------------------------------------------------------------
    Private Sub cmdRemoveParam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRemoveParam.Click

        grdParams.SelectedItems.OfType(Of ListViewItem).ToList().ForEach(Sub(x) grdParams.Items.Remove(x))

    End Sub

End Class
