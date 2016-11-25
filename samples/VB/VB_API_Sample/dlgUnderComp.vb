' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Imports System.Windows.Forms

Public Class dlgUnderComp

    ' ========================================================
    ' Member variables
    ' ========================================================
    Private m_underComp As IBApi.UnderComp

    ' ===============================================================================
    ' Public Methods
    ' ===============================================================================
    Public Sub init(underComp As IBApi.UnderComp)

        m_underComp = underComp

        With underComp
            txtConId.text = .conId
            txtDelta.text = .delta
            txtPrice.text = .price
        End With

    End Sub
    
    ' ========================================================
    ' Button Events
    ' ========================================================
    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOk.Click

        With m_underComp
            .conId = txtConId.Text
            .delta = txtDelta.Text
            .price = txtPrice.Text
        End With

        m_underComp = Nothing

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub cmdReset_Click(sender As System.Object, e As System.EventArgs) Handles cmdReset.Click

        With m_underComp
            .conId = 0
            .delta = 0
            .price = 0
        End With

        m_underComp = Nothing

        Me.DialogResult = System.Windows.Forms.DialogResult.Abort
        Me.Close()

    End Sub

    Private Sub cmdCancel_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancel.Click

        m_underComp = Nothing

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

End Class
