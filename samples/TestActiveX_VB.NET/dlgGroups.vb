' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Friend Class dlgGroups

    Private m_utils As Utils
    Private m_mainWnd As dlgMainWnd

    '--------------------------------------------------------------------------------
    ' init Groups dialog and disable some items
    '--------------------------------------------------------------------------------
    Public Sub init(ByVal utilities As Utils, ByRef mainWin As System.Windows.Forms.Form)

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
    Private Sub cmdQueryDisplayGroups_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQueryDisplayGroups.Click

        enableFields(False)
        comboDisplayGroups.Items.Clear()

        Dim reqId As Integer
        reqId = CInt(textId.Text)

        Call m_utils.addListItem(Utils.List_Types.DISPLAY_GROUPS_DATA, "Querying display groups (reqId=" & reqId & ") ...")

        ' enable this after removing of temp code
        m_mainWnd.Tws1.queryDisplayGroups(reqId)

    End Sub

    '--------------------------------------------------------------------------------
    ' clear Group Messages listbox
    '--------------------------------------------------------------------------------
    Private Sub cmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReset.Click
        lstGroupMessages.Items.Clear()
        enableFields(False)
        comboDisplayGroups.Items.Clear()
        textContractInfo.Clear()

    End Sub

    '--------------------------------------------------------------------------------
    ' close Groups dialog
    '--------------------------------------------------------------------------------
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Hide()
    End Sub

    '--------------------------------------------------------------------------------
    ' subscribe to group events
    '--------------------------------------------------------------------------------
    Private Sub cmdSubscribeToGroupEvents_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSubscribeToGroupEvents.Click

        Dim groupId As Integer
        groupId = CInt(comboDisplayGroups.Text)

        Dim reqId As Integer
        reqId = CInt(textId.Text)

        Call m_utils.addListItem(Utils.List_Types.DISPLAY_GROUPS_DATA, "Subscribing to group events (reqId=" & reqId & " groupId=" & groupId & ") ...")

        ' enable this after removing of temp code
        m_mainWnd.Tws1.subscribeToGroupEvents(reqId, groupId)

    End Sub

    '--------------------------------------------------------------------------------
    ' unsubscribe from group events
    '--------------------------------------------------------------------------------
    Private Sub cmdUnsubscribeFromGroupEvents_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUnsubscribeFromGroupEvents.Click

        Dim reqId As Integer
        reqId = CInt(textId.Text)

        Call m_utils.addListItem(Utils.List_Types.DISPLAY_GROUPS_DATA, "Unsubscribing from group events (reqId=" & reqId & ") ...")

        m_mainWnd.Tws1.unsubscribeFromGroupEvents(reqId)

    End Sub

    '--------------------------------------------------------------------------------
    ' update display group
    '--------------------------------------------------------------------------------
    Private Sub cmdUpdateDisplayGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateDisplayGroup.Click

        Dim contractInfo As String
        contractInfo = textContractInfo.Text

        Dim reqId As Integer
        reqId = CInt(textId.Text)

        If (contractInfo.Length > 0) Then

            Call m_utils.addListItem(Utils.List_Types.DISPLAY_GROUPS_DATA, "Updating display group (reqId=" & reqId & " contractInfo=" & contractInfo & ") ...")

            m_mainWnd.Tws1.updateDisplayGroup(reqId, contractInfo)

        End If

    End Sub

    '================================================================================
    ' Events
    '================================================================================
    Public Sub displayGroupList(ByVal reqId As Integer, ByVal groups As String)

        If groups.Length > 0 Then

            comboDisplayGroups.Items.Clear()
            enableFields(True)

            ' parse groups
            Dim result() As String = Split(groups, "|")
            comboDisplayGroups.Items.AddRange(result)
            comboDisplayGroups.SelectedIndex() = 0

            Call m_utils.addListItem(Utils.List_Types.DISPLAY_GROUPS_DATA, "Display groups: reqId=" & reqId & " groups=" & groups)
        Else
            Call m_utils.addListItem(Utils.List_Types.DISPLAY_GROUPS_DATA, "Display groups: reqId=" & reqId & " groups=<empty>")
        End If

    End Sub

    Public Sub displayGroupUpdated(ByVal reqId As Integer, ByVal contractInfo As String)

        Call m_utils.addListItem(Utils.List_Types.DISPLAY_GROUPS_DATA, "Display group updated: reqId=" & reqId & " contractInfo=" & contractInfo)

    End Sub

    Private Sub enableFields(ByVal enable As Boolean)
        comboDisplayGroups.Enabled = enable
        cmdSubscribeToGroupEvents.Enabled = enable
        cmdUnsubscribeFromGroupEvents.Enabled = enable
        cmdUpdateDisplayGroup.Enabled = enable
        textContractInfo.Enabled = enable
    End Sub

End Class