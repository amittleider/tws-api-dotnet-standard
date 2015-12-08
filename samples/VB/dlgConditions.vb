Imports IBApi

Public Class dlgConditions

    Dim order As IBApi.Order
    Dim bindingSource As New BindingSource

    Public Sub New(order As Order)
        ' This call is required by the designer.
        InitializeComponent()

        Me.order = order
        cancelOrder.SelectedIndex = If(order.ConditionsCancelOrder, 1, 0)
        ignoreRth.Checked = order.ConditionsIgnoreRth        
        bindingSource.DataSource = order.Conditions
        conditionList.AutoGenerateColumns = False
        conditionList.DataSource = bindingSource
    End Sub

    Private Property selectedCondition As OrderCondition
        Get
            If conditionList.SelectedCells.Count = 0 OrElse conditionList.SelectedCells(0).RowIndex = -1 Then
                Return Nothing
            End If

            Return bindingSource(conditionList.SelectedCells(0).RowIndex)
        End Get
        Set(value As OrderCondition)
            If conditionList.SelectedCells.Count > 0 AndAlso conditionList.SelectedCells(0).RowIndex <> -1 Then
                bindingSource(conditionList.SelectedCells(0).RowIndex) = value
            End If
        End Set
    End Property

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        order.ConditionsCancelOrder = cancelOrder.SelectedIndex
        order.ConditionsIgnoreRth = ignoreRth.Checked
        order.Conditions = bindingSource.DataSource

        Close()
    End Sub

    Private Sub lbAddCondition_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbAddCondition.LinkClicked
        Dim dlg As New dlgCondition(Nothing)

        If dlg.ShowDialog() = DialogResult.OK Then
            bindingSource.Add(dlg.Condition)
        End If
    End Sub

    Private Sub lbRemoveCondition_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lbRemoveCondition.LinkClicked
        bindingSource.Remove(selectedCondition)
    End Sub

    Private Sub conditionList_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles conditionList.CellFormatting
        If bindingSource.Count <= e.RowIndex Then
            Return
        End If

        Dim obj As OrderCondition = bindingSource(e.RowIndex)

        e.FormattingApplied = True


        Select e.ColumnIndex
            Case 0
                e.Value = obj.ToString()

            Case 1
                e.Value = If(obj.IsConjunctionConnection, "and", "or")

            Case Else
                e.FormattingApplied = False
        End Select
    End Sub

    Private Sub conditionList_CellParsing(sender As Object, e As DataGridViewCellParsingEventArgs) Handles conditionList.CellParsing
        If e.ColumnIndex = 0 Then
            e.ParsingApplied = False

            Return
        End If

        bindingSource(e.RowIndex).IsConjunctionConnection = e.Value.ToString().Equals("and", StringComparison.InvariantCultureIgnoreCase)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub conditionList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles conditionList.CellDoubleClick
        If e.ColumnIndex = 0 Then
            Dim dlg As New dlgCondition(selectedCondition)

            If dlg.ShowDialog() = DialogResult.OK Then
                selectedCondition = dlg.Condition
            End If
        End If
    End Sub
End Class