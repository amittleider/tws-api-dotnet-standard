Imports IBApi

Public Class dlgPegBench

    Dim order As IBApi.Order

    Sub New(order As Order)
        ' This call is required by the designer.
        InitializeComponent()

        Me.order = order
        tbPeggedChangeAmount.Text = Util.DoubleMaxString(order.PeggedChangeAmount)
        tbReferenceChangeAmount.Text = Util.DoubleMaxString(order.ReferenceChangeAmount)
        tbStartingPrice.Text = Util.DoubleMaxString(order.StartingPrice)
        tbStartingReferencePrice.Text = Util.DoubleMaxString(order.StockRefPrice)
        cbPeggedChangeType.SelectedIndex = If(order.IsPeggedChangeAmountDecrease, 1, 0)
        tbReferenceContractId.Text = order.ReferenceContractId
        tbReferenceContractExchange.Text = order.ReferenceExchange
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click        
        order.StartingPrice = Utils.StringToDouble(tbStartingPrice.Text)
        order.StockRefPrice = Utils.StringToDouble(tbStartingReferencePrice.Text)
        order.PeggedChangeAmount = Utils.StringToDouble(tbPeggedChangeAmount.Text)
        order.IsPeggedChangeAmountDecrease = cbPeggedChangeType.SelectedIndex
        order.ReferenceChangeAmount = Utils.StringToDouble(tbReferenceChangeAmount.Text)
        order.ReferenceContractId = CInt(tbReferenceContractId.Text)
        order.ReferenceExchange = tbReferenceContractExchange.Text

        Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub
End Class