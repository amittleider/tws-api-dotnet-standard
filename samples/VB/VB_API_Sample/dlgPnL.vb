Public Class dlgPnL

    Public Property ReqId As Integer

    Public Property Account As String

    Public Property ModelCode As String

    Public Property ConId As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        ReqId = If(String.IsNullOrWhiteSpace(txtReqId.Text), 0, Integer.Parse(txtReqId.Text))
        Account = txtAccount.Text
        ModelCode = txtModelCode.Text
        ConId() = If(String.IsNullOrWhiteSpace(txtConId.Text), 0, Integer.Parse(txtConId.Text))

        DialogResult = Windows.Forms.DialogResult.OK

        Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel

        Close()
    End Sub
End Class