' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Option Strict Off
Option Explicit On
Friend Class dlgPositions
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
    Public WithEvents cmdOk As System.Windows.Forms.Button
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    Public WithEvents txtAccount As System.Windows.Forms.TextBox
    Public WithEvents txtModelCode As System.Windows.Forms.TextBox
    Public WithEvents txtId As System.Windows.Forms.TextBox
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbLedgerAndNLV As System.Windows.Forms.CheckBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.txtAccount = New System.Windows.Forms.TextBox()
        Me.txtModelCode = New System.Windows.Forms.TextBox()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbLedgerAndNLV = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        Me.cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOk.Location = New System.Drawing.Point(60, 121)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOk.Size = New System.Drawing.Size(73, 25)
        Me.cmdOk.TabIndex = 7
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(148, 121)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancel.TabIndex = 8
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'txtAccount
        '
        Me.txtAccount.AcceptsReturn = True
        Me.txtAccount.BackColor = System.Drawing.SystemColors.Window
        Me.txtAccount.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAccount.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccount.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAccount.Location = New System.Drawing.Point(117, 42)
        Me.txtAccount.MaxLength = 0
        Me.txtAccount.Name = "txtAccount"
        Me.txtAccount.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAccount.Size = New System.Drawing.Size(151, 20)
        Me.txtAccount.TabIndex = 3
        '
        'txtModelCode
        '
        Me.txtModelCode.AcceptsReturn = True
        Me.txtModelCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtModelCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtModelCode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtModelCode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtModelCode.Location = New System.Drawing.Point(117, 68)
        Me.txtModelCode.MaxLength = 0
        Me.txtModelCode.Name = "txtModelCode"
        Me.txtModelCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtModelCode.Size = New System.Drawing.Size(151, 20)
        Me.txtModelCode.TabIndex = 5
        '
        'txtId
        '
        Me.txtId.AcceptsReturn = True
        Me.txtId.BackColor = System.Drawing.SystemColors.Window
        Me.txtId.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtId.Location = New System.Drawing.Point(117, 16)
        Me.txtId.MaxLength = 0
        Me.txtId.Name = "txtId"
        Me.txtId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtId.Size = New System.Drawing.Size(151, 20)
        Me.txtId.TabIndex = 1
        Me.txtId.Text = "0"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(16, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(89, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Model Code"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(16, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(68, 19)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Account"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(193, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Id"
        '
        'cbLedgerAndNLV
        '
        Me.cbLedgerAndNLV.AutoSize = True
        Me.cbLedgerAndNLV.Location = New System.Drawing.Point(19, 94)
        Me.cbLedgerAndNLV.Name = "cbLedgerAndNLV"
        Me.cbLedgerAndNLV.Size = New System.Drawing.Size(100, 18)
        Me.cbLedgerAndNLV.TabIndex = 6
        Me.cbLedgerAndNLV.Text = "LedgerAndNLV"
        Me.cbLedgerAndNLV.UseVisualStyleBackColor = True
        '
        'dlgPositions
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(280, 154)
        Me.Controls.Add(Me.cbLedgerAndNLV)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.txtAccount)
        Me.Controls.Add(Me.txtModelCode)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgPositions"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Request Positions/Account Updates"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
#Region "Upgrade Support "
    Private Shared m_vb6FormDefInstance As dlgPositions
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As dlgPositions
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New dlgPositions()
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(value As dlgPositions)
            m_vb6FormDefInstance = value
        End Set
    End Property
#End Region

    Public Enum Dlg_Type
        REQUEST_POSITIONS_MULTI = 1
        CANCEL_POSITIONS_MULTI
        REQUEST_ACCOUNT_UPDATES_MULTI
        CANCEL_ACCOUNT_UPDATES_MULTI
    End Enum

    ' ===============================================================================
    ' Private Members
    ' ===============================================================================
    Private m_arrDlgTitles As New Collection
    Private m_id As Integer
    Private m_account As String
    Private m_modelCode As String
    Private m_ledgerAndNLV As Boolean
    Private m_ok As Boolean = False

    ' ===============================================================================
    ' Get/Set Properties
    ' ===============================================================================
    Public ReadOnly Property id() As Integer
        Get
            id = m_id
        End Get
    End Property

    Public ReadOnly Property account() As String
        Get
            account = m_account
        End Get
    End Property

    Public ReadOnly Property modelCode() As String
        Get
            modelCode = m_modelCode
        End Get
    End Property

    Public ReadOnly Property ledgerAndNLV() As Boolean
        Get
            ledgerAndNLV = m_ledgerAndNLV
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
    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        m_id = Text2Int(txtId.Text)
        m_account = txtAccount.Text
        m_modelCode = txtModelCode.Text
        m_ledgerAndNLV = cbLedgerAndNLV.Checked
        m_ok = True

        Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        m_ok = False
        Close()
    End Sub

    Private Sub dlgPositions_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        m_id = 0
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

        txtId.Enabled = True
        txtAccount.Enabled = (dlgType = Dlg_Type.REQUEST_POSITIONS_MULTI Or dlgType = Dlg_Type.REQUEST_ACCOUNT_UPDATES_MULTI)
        txtModelCode.Enabled = (dlgType = Dlg_Type.REQUEST_POSITIONS_MULTI Or dlgType = Dlg_Type.REQUEST_ACCOUNT_UPDATES_MULTI)
        cbLedgerAndNLV.Enabled = (dlgType = Dlg_Type.REQUEST_ACCOUNT_UPDATES_MULTI)

    End Sub

    '--------------------------------------------------------------------------------
    ' Set the various dialog title string for each dialog type and the initial
    ' dialog data.
    '--------------------------------------------------------------------------------
    Private Sub Form_Initialize_Renamed()
        m_arrDlgTitles.Add("Request Positions Multi")
        m_arrDlgTitles.Add("Cancel Positions Multi")
        m_arrDlgTitles.Add("Request Account Updates Multi")
        m_arrDlgTitles.Add("Cancel Account Updates Multi")
    End Sub

End Class
