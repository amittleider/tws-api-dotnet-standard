Imports IBApi

Public Class dlgAdjustStop

    Dim order As IBApi.Order

    Sub New(order As Order)
        InitializeComponent()

        Me.order = order
        cbAdjustedOrderType.Text = order.AdjustedOrderType
        tbTriggerPrice.Text = Util.DoubleMaxString(order.TriggerPrice)
        tbAdjustedStopPrice.Text = Util.DoubleMaxString(order.AdjustedStopPrice)
        tbAdjustedStopLimitPrice.Text = Util.DoubleMaxString(order.AdjustedStopLimitPrice)
        tbAdjustedTrailingAmnt.Text = Util.DoubleMaxString(order.AdjustedTrailingAmount)
        cbAdjustedTrailingAmntUnit.SelectedIndex = order.AdjustableTrailingUnit
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        order.AdjustedOrderType = cbAdjustedOrderType.Text
        order.TriggerPrice = Utils.StringToDouble(tbTriggerPrice.Text)
        order.AdjustedStopPrice = Utils.StringToDouble(tbAdjustedStopPrice.Text)
        order.AdjustedStopLimitPrice = Utils.StringToDouble(tbAdjustedStopLimitPrice.Text)
        order.AdjustedTrailingAmount = Utils.StringToDouble(tbAdjustedTrailingAmnt.Text)
        order.AdjustableTrailingUnit = cbAdjustedTrailingAmntUnit.SelectedIndex

        Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub
End Class