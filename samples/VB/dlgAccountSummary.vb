' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Option Strict Off
Option Explicit On
Friend Class dlgAccountSummary
    Inherits System.Windows.Forms.Form
#Region "Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()
        If m_vb6FormDefInstance Is Nothing Then
            If m_InitializingDefInstance Then
                m_vb6FormDefInstance = Me
            Else
                Try
                    'For the start-up form, the first instance created is the default instance.
                    If System.Reflection.Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is Me.GetType Then
                        m_vb6FormDefInstance = Me
                    End If
                Catch
                End Try
            End If
        End If
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        Form_Initialize_Renamed()
    End Sub
    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents txtGroupName As System.Windows.Forms.TextBox
    Public WithEvents txtTags As System.Windows.Forms.TextBox
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    Public WithEvents cmdOk As System.Windows.Forms.Button
    Public WithEvents lblGroupName As System.Windows.Forms.Label
    Public WithEvents lblTags As System.Windows.Forms.Label
    Public WithEvents txtReqId As System.Windows.Forms.TextBox
    Public WithEvents lblReqId As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtGroupName = New System.Windows.Forms.TextBox
        Me.txtTags = New System.Windows.Forms.TextBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.lblGroupName = New System.Windows.Forms.Label
        Me.lblTags = New System.Windows.Forms.Label
        Me.txtReqId = New System.Windows.Forms.TextBox
        Me.lblReqId = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtGroupName
        '
        Me.txtGroupName.AcceptsReturn = True
        Me.txtGroupName.BackColor = System.Drawing.SystemColors.Window
        Me.txtGroupName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGroupName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGroupName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtGroupName.Location = New System.Drawing.Point(119, 38)
        Me.txtGroupName.MaxLength = 0
        Me.txtGroupName.Name = "txtGroupName"
        Me.txtGroupName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtGroupName.Size = New System.Drawing.Size(97, 20)
        Me.txtGroupName.TabIndex = 2
        Me.txtGroupName.Text = "All"
        '
        'txtTags
        '
        Me.txtTags.AcceptsReturn = True
        Me.txtTags.BackColor = System.Drawing.SystemColors.Window
        Me.txtTags.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTags.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTags.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTags.Location = New System.Drawing.Point(119, 63)
        Me.txtTags.MaxLength = 0
        Me.txtTags.Name = "txtTags"
        Me.txtTags.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTags.Size = New System.Drawing.Size(97, 20)
        Me.txtTags.TabIndex = 3
        Me.txtTags.Text = "AccruedCash,BuyingPower,NetLiquidation"
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(143, 89)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdOk
        '
        Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOk.Location = New System.Drawing.Point(64, 89)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOk.Size = New System.Drawing.Size(73, 25)
        Me.cmdOk.TabIndex = 0
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'lblGroupName
        '
        Me.lblGroupName.BackColor = System.Drawing.SystemColors.Control
        Me.lblGroupName.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblGroupName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroupName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblGroupName.Location = New System.Drawing.Point(15, 41)
        Me.lblGroupName.Name = "lblGroupName"
        Me.lblGroupName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblGroupName.Size = New System.Drawing.Size(97, 17)
        Me.lblGroupName.TabIndex = 14
        Me.lblGroupName.Text = "Group Name"
        '
        'lblTags
        '
        Me.lblTags.BackColor = System.Drawing.SystemColors.Control
        Me.lblTags.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTags.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTags.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTags.Location = New System.Drawing.Point(15, 66)
        Me.lblTags.Name = "lblTags"
        Me.lblTags.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTags.Size = New System.Drawing.Size(97, 17)
        Me.lblTags.TabIndex = 13
        Me.lblTags.Text = "Tags"
        '
        'txtReqId
        '
        Me.txtReqId.AcceptsReturn = True
        Me.txtReqId.BackColor = System.Drawing.SystemColors.Window
        Me.txtReqId.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtReqId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReqId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtReqId.Location = New System.Drawing.Point(119, 12)
        Me.txtReqId.MaxLength = 0
        Me.txtReqId.Name = "txtReqId"
        Me.txtReqId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtReqId.Size = New System.Drawing.Size(97, 20)
        Me.txtReqId.TabIndex = 1
        Me.txtReqId.Text = "0"
        '
        'lblReqId
        '
        Me.lblReqId.BackColor = System.Drawing.SystemColors.Control
        Me.lblReqId.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblReqId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReqId.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblReqId.Location = New System.Drawing.Point(15, 15)
        Me.lblReqId.Name = "lblReqId"
        Me.lblReqId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblReqId.Size = New System.Drawing.Size(97, 17)
        Me.lblReqId.TabIndex = 15
        Me.lblReqId.Text = "Request Id"
        '
        'dlgAccountSummary
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(237, 118)
        Me.Controls.Add(Me.lblReqId)
        Me.Controls.Add(Me.txtReqId)
        Me.Controls.Add(Me.txtGroupName)
        Me.Controls.Add(Me.txtTags)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.lblGroupName)
        Me.Controls.Add(Me.lblTags)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(184, 250)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgAccountSummary"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Account Summary"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
#Region "Upgrade Support "
    Private Shared m_vb6FormDefInstance As dlgAccountSummary
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As dlgAccountSummary
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New dlgAccountSummary()
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal value As dlgAccountSummary)
            m_vb6FormDefInstance = value
        End Set
    End Property
#End Region

    Public Enum Dlg_Type
        REQUEST_ACCOUNT_SUMMARY = 1
        CANCEL_ACCOUNT_SUMMARY
    End Enum

    ' ========================================================
    ' Member variables
    ' ========================================================
    Private m_arrDlgTitles As New Collection
    Private m_reqId As Integer
    Private m_groupName As String
    Private m_tags As String
    Private m_ok As Boolean

    ' ========================================================
    ' Get/Set Methods
    ' ========================================================

    Public ReadOnly Property reqId() As Integer
        Get
            reqId = m_reqId
        End Get
    End Property
    Public ReadOnly Property groupName() As String
        Get
            groupName = m_groupName
        End Get
    End Property
    Public ReadOnly Property tags() As String
        Get
            tags = m_tags
        End Get
    End Property
    Public ReadOnly Property ok() As Boolean
        Get
            ok = m_ok
        End Get
    End Property
    ' ========================================================
    ' Button Events
    ' ========================================================
    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click

        m_reqId = Text2Int(txtReqId.Text)
        m_groupName = txtGroupName.Text
        m_tags = txtTags.Text

        m_ok = True
        Me.Hide()
    End Sub

    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        m_ok = False
        Me.Hide()
    End Sub

    Private Sub dlgAccountSummary_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        m_reqId = 0
    End Sub

    Private Function Text2Int(ByRef text As String) As Integer
        If Len(text) <= 0 Then
            Text2Int = 0
        Else
            Text2Int = text
        End If
    End Function

    ' ========================================================
    ' Public Methods
    ' ========================================================
    '--------------------------------------------------------------------------------
    ' Sets the dialog field and button states based on the dialog type
    '--------------------------------------------------------------------------------
    Public Sub init(ByRef dlgType As Dlg_Type)
        m_ok = False

        Text = m_arrDlgTitles.Item(dlgType)

        txtReqId.Enabled = True
        txtGroupName.Enabled = (dlgType = Dlg_Type.REQUEST_ACCOUNT_SUMMARY)
        txtTags.Enabled = (dlgType = Dlg_Type.REQUEST_ACCOUNT_SUMMARY)

    End Sub

    '--------------------------------------------------------------------------------
    ' Set the various dialog title string for each dialog type and the initial
    ' dialog data.
    '--------------------------------------------------------------------------------
    Private Sub Form_Initialize_Renamed()
        m_arrDlgTitles.Add("Request Account Summary")
        m_arrDlgTitles.Add("Cancel Account Summary")
    End Sub
End Class


