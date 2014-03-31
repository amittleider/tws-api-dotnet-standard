' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Option Strict Off
Option Explicit On
Friend Class dlgExecFilter
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
	Public WithEvents txtAction As System.Windows.Forms.TextBox
	Public WithEvents txtClientId As System.Windows.Forms.TextBox
	Public WithEvents txtAcctCode As System.Windows.Forms.TextBox
	Public WithEvents txtTime As System.Windows.Forms.TextBox
	Public WithEvents txtSymbol As System.Windows.Forms.TextBox
	Public WithEvents txtSecType As System.Windows.Forms.TextBox
	Public WithEvents txtExchange As System.Windows.Forms.TextBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents cmdOk As System.Windows.Forms.Button
    Public WithEvents lblClientId As System.Windows.Forms.Label
    Public WithEvents lblAcctCode As System.Windows.Forms.Label
    Public WithEvents lblTime As System.Windows.Forms.Label
    Public WithEvents lblSymbol As System.Windows.Forms.Label
    Public WithEvents lblSecType As System.Windows.Forms.Label
    Public WithEvents lblExchange As System.Windows.Forms.Label
    Public WithEvents txtReqId As System.Windows.Forms.TextBox
    Public WithEvents lblReqId As System.Windows.Forms.Label
    Public WithEvents lblAction As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtAction = New System.Windows.Forms.TextBox
        Me.txtClientId = New System.Windows.Forms.TextBox
        Me.txtAcctCode = New System.Windows.Forms.TextBox
        Me.txtTime = New System.Windows.Forms.TextBox
        Me.txtSymbol = New System.Windows.Forms.TextBox
        Me.txtSecType = New System.Windows.Forms.TextBox
        Me.txtExchange = New System.Windows.Forms.TextBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.lblClientId = New System.Windows.Forms.Label
        Me.lblAcctCode = New System.Windows.Forms.Label
        Me.lblTime = New System.Windows.Forms.Label
        Me.lblSymbol = New System.Windows.Forms.Label
        Me.lblSecType = New System.Windows.Forms.Label
        Me.lblExchange = New System.Windows.Forms.Label
        Me.lblAction = New System.Windows.Forms.Label
        Me.txtReqId = New System.Windows.Forms.TextBox
        Me.lblReqId = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtAction
        '
        Me.txtAction.AcceptsReturn = True
        Me.txtAction.BackColor = System.Drawing.SystemColors.Window
        Me.txtAction.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAction.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAction.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAction.Location = New System.Drawing.Point(119, 188)
        Me.txtAction.MaxLength = 0
        Me.txtAction.Name = "txtAction"
        Me.txtAction.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAction.Size = New System.Drawing.Size(97, 19)
        Me.txtAction.TabIndex = 8
        '
        'txtClientId
        '
        Me.txtClientId.AcceptsReturn = True
        Me.txtClientId.BackColor = System.Drawing.SystemColors.Window
        Me.txtClientId.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtClientId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClientId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtClientId.Location = New System.Drawing.Point(119, 38)
        Me.txtClientId.MaxLength = 0
        Me.txtClientId.Name = "txtClientId"
        Me.txtClientId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtClientId.Size = New System.Drawing.Size(97, 19)
        Me.txtClientId.TabIndex = 2
        '
        'txtAcctCode
        '
        Me.txtAcctCode.AcceptsReturn = True
        Me.txtAcctCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtAcctCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAcctCode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAcctCode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAcctCode.Location = New System.Drawing.Point(119, 63)
        Me.txtAcctCode.MaxLength = 0
        Me.txtAcctCode.Name = "txtAcctCode"
        Me.txtAcctCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAcctCode.Size = New System.Drawing.Size(97, 19)
        Me.txtAcctCode.TabIndex = 3
        '
        'txtTime
        '
        Me.txtTime.AcceptsReturn = True
        Me.txtTime.BackColor = System.Drawing.SystemColors.Window
        Me.txtTime.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTime.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTime.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTime.Location = New System.Drawing.Point(119, 88)
        Me.txtTime.MaxLength = 0
        Me.txtTime.Name = "txtTime"
        Me.txtTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTime.Size = New System.Drawing.Size(97, 19)
        Me.txtTime.TabIndex = 4
        '
        'txtSymbol
        '
        Me.txtSymbol.AcceptsReturn = True
        Me.txtSymbol.BackColor = System.Drawing.SystemColors.Window
        Me.txtSymbol.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSymbol.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSymbol.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSymbol.Location = New System.Drawing.Point(119, 113)
        Me.txtSymbol.MaxLength = 0
        Me.txtSymbol.Name = "txtSymbol"
        Me.txtSymbol.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSymbol.Size = New System.Drawing.Size(97, 19)
        Me.txtSymbol.TabIndex = 5
        '
        'txtSecType
        '
        Me.txtSecType.AcceptsReturn = True
        Me.txtSecType.BackColor = System.Drawing.SystemColors.Window
        Me.txtSecType.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSecType.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSecType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSecType.Location = New System.Drawing.Point(119, 138)
        Me.txtSecType.MaxLength = 0
        Me.txtSecType.Name = "txtSecType"
        Me.txtSecType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSecType.Size = New System.Drawing.Size(97, 19)
        Me.txtSecType.TabIndex = 6
        '
        'txtExchange
        '
        Me.txtExchange.AcceptsReturn = True
        Me.txtExchange.BackColor = System.Drawing.SystemColors.Window
        Me.txtExchange.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtExchange.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExchange.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtExchange.Location = New System.Drawing.Point(119, 163)
        Me.txtExchange.MaxLength = 0
        Me.txtExchange.Name = "txtExchange"
        Me.txtExchange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtExchange.Size = New System.Drawing.Size(97, 19)
        Me.txtExchange.TabIndex = 7
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(143, 213)
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
        Me.cmdOk.Location = New System.Drawing.Point(64, 213)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOk.Size = New System.Drawing.Size(73, 25)
        Me.cmdOk.TabIndex = 0
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'lblClientId
        '
        Me.lblClientId.BackColor = System.Drawing.SystemColors.Control
        Me.lblClientId.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblClientId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientId.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblClientId.Location = New System.Drawing.Point(15, 41)
        Me.lblClientId.Name = "lblClientId"
        Me.lblClientId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblClientId.Size = New System.Drawing.Size(65, 17)
        Me.lblClientId.TabIndex = 14
        Me.lblClientId.Text = "Client Id"
        '
        'lblAcctCode
        '
        Me.lblAcctCode.BackColor = System.Drawing.SystemColors.Control
        Me.lblAcctCode.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAcctCode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcctCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAcctCode.Location = New System.Drawing.Point(15, 66)
        Me.lblAcctCode.Name = "lblAcctCode"
        Me.lblAcctCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAcctCode.Size = New System.Drawing.Size(97, 17)
        Me.lblAcctCode.TabIndex = 13
        Me.lblAcctCode.Text = "Account Code"
        '
        'lblTime
        '
        Me.lblTime.BackColor = System.Drawing.SystemColors.Control
        Me.lblTime.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblTime.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTime.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTime.Location = New System.Drawing.Point(15, 91)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTime.Size = New System.Drawing.Size(65, 17)
        Me.lblTime.TabIndex = 12
        Me.lblTime.Text = "Time"
        '
        'lblSymbol
        '
        Me.lblSymbol.BackColor = System.Drawing.SystemColors.Control
        Me.lblSymbol.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblSymbol.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSymbol.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSymbol.Location = New System.Drawing.Point(15, 116)
        Me.lblSymbol.Name = "lblSymbol"
        Me.lblSymbol.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSymbol.Size = New System.Drawing.Size(65, 17)
        Me.lblSymbol.TabIndex = 11
        Me.lblSymbol.Text = "Symbol"
        '
        'lblSecType
        '
        Me.lblSecType.BackColor = System.Drawing.SystemColors.Control
        Me.lblSecType.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblSecType.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSecType.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSecType.Location = New System.Drawing.Point(15, 141)
        Me.lblSecType.Name = "lblSecType"
        Me.lblSecType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblSecType.Size = New System.Drawing.Size(65, 17)
        Me.lblSecType.TabIndex = 10
        Me.lblSecType.Text = "SecType"
        '
        'lblExchange
        '
        Me.lblExchange.BackColor = System.Drawing.SystemColors.Control
        Me.lblExchange.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblExchange.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExchange.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblExchange.Location = New System.Drawing.Point(15, 166)
        Me.lblExchange.Name = "lblExchange"
        Me.lblExchange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblExchange.Size = New System.Drawing.Size(73, 17)
        Me.lblExchange.TabIndex = 9
        Me.lblExchange.Text = "Exchange"
        '
        'lblAction
        '
        Me.lblAction.BackColor = System.Drawing.SystemColors.Control
        Me.lblAction.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAction.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAction.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAction.Location = New System.Drawing.Point(15, 191)
        Me.lblAction.Name = "lblAction"
        Me.lblAction.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAction.Size = New System.Drawing.Size(81, 17)
        Me.lblAction.TabIndex = 8
        Me.lblAction.Text = "Action"
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
        Me.lblReqId.Size = New System.Drawing.Size(65, 17)
        Me.lblReqId.TabIndex = 15
        Me.lblReqId.Text = "Request Id"
        '
        'dlgExecFilter
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(237, 253)
        Me.Controls.Add(Me.lblReqId)
        Me.Controls.Add(Me.txtReqId)
        Me.Controls.Add(Me.txtAction)
        Me.Controls.Add(Me.txtClientId)
        Me.Controls.Add(Me.txtAcctCode)
        Me.Controls.Add(Me.txtTime)
        Me.Controls.Add(Me.txtSymbol)
        Me.Controls.Add(Me.txtSecType)
        Me.Controls.Add(Me.txtExchange)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.lblClientId)
        Me.Controls.Add(Me.lblAcctCode)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.lblSymbol)
        Me.Controls.Add(Me.lblSecType)
        Me.Controls.Add(Me.lblExchange)
        Me.Controls.Add(Me.lblAction)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(184, 250)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgExecFilter"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Execution Report Filter"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
#Region "Upgrade Support "
	Private Shared m_vb6FormDefInstance As dlgExecFilter
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As dlgExecFilter
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New dlgExecFilter()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	' ========================================================
	' Member variables
	' ========================================================
    Private m_execFilter As IBApi.ExecutionFilter

    Private m_reqId As Integer
	Private m_ok As Boolean
	
	' ========================================================
	' Get/Set Methods
	' ========================================================

    Public ReadOnly Property reqId() As Integer
        Get
            reqId = m_reqId
        End Get
    End Property
    Public ReadOnly Property execFilter() As IBApi.ExecutionFilter
        Get
            execFilter = m_execFilter
        End Get
    End Property

    Public ReadOnly Property ok() As Boolean
        Get
            ok = m_ok
        End Get
    End Property
    ' ===============================================================================
    ' Public Methods
    ' ===============================================================================
    Public Sub init(ByVal execFilter As IBApi.ExecutionFilter)

        m_execFilter = execFilter

        With execFilter

            txtClientId.Text = .clientId
            txtAcctCode.Text = .acctCode
            txtTime.Text = .time
            txtSymbol.Text = .symbol
            txtSecType.Text = .secType
            txtExchange.Text = .exchange
            txtAction.Text = .side

        End With
    End Sub

    ' ========================================================
    ' Button Events
    ' ========================================================
    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click

        m_reqId = Text2Int(txtReqId.Text)

        With m_execFilter

            .clientId = Text2Int(txtClientId.Text)
            .acctCode = txtAcctCode.Text
            .time = txtTime.Text
            .symbol = txtSymbol.Text
            .secType = txtSecType.Text
            .exchange = txtExchange.Text
            .side = txtAction.Text

        End With

        m_ok = True
        Me.Hide()

    End Sub

    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        m_ok = False
        Me.Hide()
    End Sub

    Private Sub dlgExecFilter_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        m_reqId = 0
    End Sub

    Private Function Text2Int(ByRef text As String) As Integer
        If Len(text) <= 0 Then
            Text2Int = 0
        Else
            Text2Int = text
        End If
    End Function

End Class