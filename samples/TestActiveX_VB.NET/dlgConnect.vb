' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Option Strict Off
Option Explicit On
Friend Class dlgConnect
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
	Public WithEvents cmdOk As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents txtPort As System.Windows.Forms.TextBox
	Public WithEvents txtClientId As System.Windows.Forms.TextBox
	Public WithEvents txtHostIP As System.Windows.Forms.TextBox
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(dlgConnect))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ToolTip1.Active = True
		Me.cmdOk = New System.Windows.Forms.Button
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.txtPort = New System.Windows.Forms.TextBox
		Me.txtClientId = New System.Windows.Forms.TextBox
		Me.txtHostIP = New System.Windows.Forms.TextBox
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Connection Parameters"
		Me.ClientSize = New System.Drawing.Size(280, 225)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "dlgConnect"
		Me.cmdOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOk.Text = "Ok"
		Me.cmdOk.Size = New System.Drawing.Size(73, 25)
		Me.cmdOk.Location = New System.Drawing.Point(60, 192)
		Me.cmdOk.TabIndex = 3
		Me.cmdOk.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOk.CausesValidation = True
		Me.cmdOk.Enabled = True
		Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOk.TabStop = True
		Me.cmdOk.Name = "cmdOk"
		Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCancel.Text = "Cancel"
		Me.cmdCancel.Size = New System.Drawing.Size(73, 25)
		Me.cmdCancel.Location = New System.Drawing.Point(148, 192)
		Me.cmdCancel.TabIndex = 4
		Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCancel.CausesValidation = True
		Me.cmdCancel.Enabled = True
		Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCancel.TabStop = True
		Me.cmdCancel.Name = "cmdCancel"
		Me.txtPort.AutoSize = False
		Me.txtPort.Size = New System.Drawing.Size(241, 19)
		Me.txtPort.Location = New System.Drawing.Point(16, 96)
		Me.txtPort.TabIndex = 1
		Me.txtPort.Text = "7496"
		Me.txtPort.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtPort.AcceptsReturn = True
		Me.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtPort.BackColor = System.Drawing.SystemColors.Window
		Me.txtPort.CausesValidation = True
		Me.txtPort.Enabled = True
		Me.txtPort.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtPort.HideSelection = True
		Me.txtPort.ReadOnly = False
		Me.txtPort.Maxlength = 0
		Me.txtPort.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtPort.MultiLine = False
		Me.txtPort.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtPort.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtPort.TabStop = True
		Me.txtPort.Visible = True
		Me.txtPort.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtPort.Name = "txtPort"
		Me.txtClientId.AutoSize = False
		Me.txtClientId.Size = New System.Drawing.Size(241, 19)
		Me.txtClientId.Location = New System.Drawing.Point(16, 152)
		Me.txtClientId.TabIndex = 2
		Me.txtClientId.Text = "0"
		Me.txtClientId.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtClientId.AcceptsReturn = True
		Me.txtClientId.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtClientId.BackColor = System.Drawing.SystemColors.Window
		Me.txtClientId.CausesValidation = True
		Me.txtClientId.Enabled = True
		Me.txtClientId.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtClientId.HideSelection = True
		Me.txtClientId.ReadOnly = False
		Me.txtClientId.Maxlength = 0
		Me.txtClientId.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtClientId.MultiLine = False
		Me.txtClientId.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtClientId.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtClientId.TabStop = True
		Me.txtClientId.Visible = True
		Me.txtClientId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtClientId.Name = "txtClientId"
		Me.txtHostIP.AutoSize = False
		Me.txtHostIP.Size = New System.Drawing.Size(241, 19)
		Me.txtHostIP.Location = New System.Drawing.Point(16, 40)
		Me.txtHostIP.TabIndex = 0
		Me.txtHostIP.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtHostIP.AcceptsReturn = True
		Me.txtHostIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtHostIP.BackColor = System.Drawing.SystemColors.Window
		Me.txtHostIP.CausesValidation = True
		Me.txtHostIP.Enabled = True
		Me.txtHostIP.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtHostIP.HideSelection = True
		Me.txtHostIP.ReadOnly = False
		Me.txtHostIP.Maxlength = 0
		Me.txtHostIP.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtHostIP.MultiLine = False
		Me.txtHostIP.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtHostIP.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtHostIP.TabStop = True
		Me.txtHostIP.Visible = True
		Me.txtHostIP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtHostIP.Name = "txtHostIP"
		Me.Label3.Text = "Client ID"
		Me.Label3.Size = New System.Drawing.Size(89, 17)
		Me.Label3.Location = New System.Drawing.Point(16, 136)
		Me.Label3.TabIndex = 7
		Me.Label3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.SystemColors.Control
		Me.Label3.Enabled = True
		Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Label2.Text = "Port"
		Me.Label2.Size = New System.Drawing.Size(41, 17)
		Me.Label2.Location = New System.Drawing.Point(16, 80)
		Me.Label2.TabIndex = 6
		Me.Label2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.SystemColors.Control
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label1.Text = "IP Address (leave blank for local host)"
		Me.Label1.Size = New System.Drawing.Size(193, 17)
		Me.Label1.Location = New System.Drawing.Point(16, 16)
		Me.Label1.TabIndex = 5
		Me.Label1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(cmdOk)
		Me.Controls.Add(cmdCancel)
		Me.Controls.Add(txtPort)
		Me.Controls.Add(txtClientId)
		Me.Controls.Add(txtHostIP)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
	End Sub
#End Region 
#Region "Upgrade Support "
	Private Shared m_vb6FormDefInstance As dlgConnect
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As dlgConnect
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New dlgConnect()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	
	' ===============================================================================
	' Private Members
	' ===============================================================================
	Private m_hostIP As String
	Private m_port As Integer
	Private m_clientId As Integer
	Private m_ok As Boolean
	
	' ===============================================================================
	' Get/Set Properties
	' ===============================================================================
	Public ReadOnly Property hostIP() As String
		Get
			hostIP = m_hostIP
		End Get
	End Property
	
	Public ReadOnly Property port() As Integer
		Get
			port = m_port
		End Get
	End Property
	
	Public ReadOnly Property clientId() As Integer
		Get
			clientId = m_clientId
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
		m_hostIP = txtHostIP.Text
		m_port = CInt(txtPort.Text)
		m_clientId = CInt(txtClientId.Text)
		m_ok = True
		
		Hide()
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		m_ok = False
		Hide()
	End Sub
End Class