Imports IBApi

Public Class dlgAdjustStop

    Private m_order As IBApi.Order

    Sub New(order As Order)
        InitializeComponent()

        Me.m_order = order
        cbAdjustedOrderType.Text = order.AdjustedOrderType
        tbTriggerPrice.Text = Util.DoubleMaxString(order.TriggerPrice)
        tbAdjustedStopPrice.Text = Util.DoubleMaxString(order.AdjustedStopPrice)
        tbAdjustedStopLimitPrice.Text = Util.DoubleMaxString(order.AdjustedStopLimitPrice)
        tbAdjustedTrailingAmnt.Text = Util.DoubleMaxString(order.AdjustedTrailingAmount)
        cbAdjustedTrailingAmntUnit.SelectedIndex = order.AdjustableTrailingUnit
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        m_order.AdjustedOrderType = cbAdjustedOrderType.Text
        m_order.TriggerPrice = Utils.StringToDouble(tbTriggerPrice.Text)
        m_order.AdjustedStopPrice = Utils.StringToDouble(tbAdjustedStopPrice.Text)
        m_order.AdjustedStopLimitPrice = Utils.StringToDouble(tbAdjustedStopLimitPrice.Text)
        m_order.AdjustedTrailingAmount = Utils.StringToDouble(tbAdjustedTrailingAmnt.Text)
        m_order.AdjustableTrailingUnit = cbAdjustedTrailingAmntUnit.SelectedIndex

        Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub
End Class