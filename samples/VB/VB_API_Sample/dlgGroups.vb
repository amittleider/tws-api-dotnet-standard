' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Friend Class dlgGroups

    Private m_utils As Utils
    Private m_mainWnd As MainForm

    '--------------------------------------------------------------------------------
    ' init Groups dialog and disable some items
    '--------------------------------------------------------------------------------
    Public Sub init(utilities As Utils, mainWin As System.Windows.Forms.Form)

        m_utils = utilities
        m_mainWnd = mainWin

        enableFields(False)

    End Sub

    '================================================================================
    ' Requests
    '================================================================================
    '--------------------------------------------------------------------------------
    ' query display groups
    '--------------------------------------------------------------------------------
    Private Sub cmdQueryDisplayGroups_Click(sender As System.Object, e As System.EventArgs) Handles cmdQueryDisplayGroups.Click

        enableFields(False)
        comboDisplayGroups.Items.Clear()

        Dim reqId = CInt(textId.Text)

        m_utils.addListItem(Utils.ListType.DisplayGroupsData, "Querying display groups (reqId=" & reqId & ") ...")

        ' enable this after removing of temp code
        m_mainWnd.Api.queryDisplayGroups(reqId)

    End Sub

    '--------------------------------------------------------------------------------
    ' clear Group Messages listbox
    '--------------------------------------------------------------------------------
    Private Sub cmdReset_Click(sender As System.Object, e As System.EventArgs) Handles cmdReset.Click
        lstGroupMessages.Items.Clear()
        enableFields(False)
        comboDisplayGroups.Items.Clear()
        textContractInfo.Clear()

    End Sub

    '--------------------------------------------------------------------------------
    ' close Groups dialog
    '--------------------------------------------------------------------------------
    Private Sub cmdClose_Click(sender As System.Object, e As System.EventArgs) Handles cmdClose.Click
        Hide()
    End Sub

    '--------------------------------------------------------------------------------
    ' subscribe to group events
    '--------------------------------------------------------------------------------
    Private Sub cmdSubscribeToGroupEvents_Click(sender As System.Object, e As System.EventArgs) Handles cmdSubscribeToGroupEvents.Click

        Dim groupId = CInt(comboDisplayGroups.Text)

        Dim reqId = CInt(textId.Text)

        m_utils.addListItem(Utils.ListType.DisplayGroupsData, "Subscribing to group events (reqId=" & reqId & " groupId=" & groupId & ") ...")

        ' enable this after removing of temp code
        m_mainWnd.Api.subscribeToGroupEvents(reqId, groupId)

    End Sub

    '--------------------------------------------------------------------------------
    ' unsubscribe from group events
    '--------------------------------------------------------------------------------
    Private Sub cmdUnsubscribeFromGroupEvents_Click(sender As System.Object, e As System.EventArgs) Handles cmdUnsubscribeFromGroupEvents.Click

        Dim reqId = CInt(textId.Text)

        m_utils.addListItem(Utils.ListType.DisplayGroupsData, "Unsubscribing from group events (reqId=" & reqId & ") ...")

        m_mainWnd.Api.unsubscribeFromGroupEvents(reqId)

    End Sub

    '--------------------------------------------------------------------------------
    ' update display group
    '--------------------------------------------------------------------------------
    Private Sub cmdUpdateDisplayGroup_Click(sender As System.Object, e As System.EventArgs) Handles cmdUpdateDisplayGroup.Click
        Dim contractInfo = textContractInfo.Text
        Dim reqId = CInt(textId.Text)

        If (contractInfo.Length > 0) Then

            m_utils.addListItem(Utils.ListType.DisplayGroupsData, "Updating display group (reqId=" & reqId & " contractInfo=" & contractInfo & ") ...")

            m_mainWnd.Api.updateDisplayGroup(reqId, contractInfo)

        End If

    End Sub

    '================================================================================
    ' Events
    '================================================================================
    Public Sub displayGroupList(reqId As Integer, groups As String)

        If groups.Length > 0 Then

            comboDisplayGroups.Items.Clear()
            enableFields(True)

            ' parse groups
            Dim result() = Split(groups, "|")
            comboDisplayGroups.Items.AddRange(result)
            comboDisplayGroups.SelectedIndex() = 0

            m_utils.addListItem(Utils.ListType.DisplayGroupsData, "Display groups: reqId=" & reqId & " groups=" & groups)
        Else
            m_utils.addListItem(Utils.ListType.DisplayGroupsData, "Display groups: reqId=" & reqId & " groups=<empty>")
        End If

    End Sub

    Public Sub displayGroupUpdated(reqId As Integer, contractInfo As String)

        m_utils.addListItem(Utils.ListType.DisplayGroupsData, "Display group updated: reqId=" & reqId & " contractInfo=" & contractInfo)

    End Sub

    Private Sub enableFields(enable As Boolean)
        comboDisplayGroups.Enabled = enable
        cmdSubscribeToGroupEvents.Enabled = enable
        cmdUnsubscribeFromGroupEvents.Enabled = enable
        cmdUpdateDisplayGroup.Enabled = enable
        textContractInfo.Enabled = enable
    End Sub

End Class
