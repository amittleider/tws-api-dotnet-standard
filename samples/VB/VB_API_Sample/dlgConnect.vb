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
    Public WithEvents txtOptCapts As System.Windows.Forms.TextBox
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.txtClientId = New System.Windows.Forms.TextBox()
        Me.txtHostIP = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtOptCapts = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        Me.cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOk.Location = New System.Drawing.Point(60, 315)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOk.Size = New System.Drawing.Size(73, 25)
        Me.cmdOk.TabIndex = 3
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
        Me.cmdCancel.Location = New System.Drawing.Point(148, 315)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'txtPort
        '
        Me.txtPort.AcceptsReturn = True
        Me.txtPort.BackColor = System.Drawing.SystemColors.Window
        Me.txtPort.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPort.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPort.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPort.Location = New System.Drawing.Point(16, 96)
        Me.txtPort.MaxLength = 0
        Me.txtPort.Name = "txtPort"
        Me.txtPort.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPort.Size = New System.Drawing.Size(241, 20)
        Me.txtPort.TabIndex = 1
        Me.txtPort.Text = "7496"
        '
        'txtClientId
        '
        Me.txtClientId.AcceptsReturn = True
        Me.txtClientId.BackColor = System.Drawing.SystemColors.Window
        Me.txtClientId.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtClientId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClientId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtClientId.Location = New System.Drawing.Point(16, 152)
        Me.txtClientId.MaxLength = 0
        Me.txtClientId.Name = "txtClientId"
        Me.txtClientId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtClientId.Size = New System.Drawing.Size(241, 20)
        Me.txtClientId.TabIndex = 2
        Me.txtClientId.Text = "0"
        '
        'txtHostIP
        '
        Me.txtHostIP.AcceptsReturn = True
        Me.txtHostIP.BackColor = System.Drawing.SystemColors.Window
        Me.txtHostIP.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHostIP.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHostIP.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHostIP.Location = New System.Drawing.Point(16, 40)
        Me.txtHostIP.MaxLength = 0
        Me.txtHostIP.Name = "txtHostIP"
        Me.txtHostIP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHostIP.Size = New System.Drawing.Size(241, 20)
        Me.txtHostIP.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(16, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(89, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Client ID"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(16, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(41, 17)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Port"
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
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "IP Address (leave blank for local host)"
        '
        'txtOptCapts
        '
        Me.txtOptCapts.AcceptsReturn = True
        Me.txtOptCapts.BackColor = System.Drawing.SystemColors.Window
        Me.txtOptCapts.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOptCapts.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOptCapts.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOptCapts.Location = New System.Drawing.Point(16, 206)
        Me.txtOptCapts.MaxLength = 0
        Me.txtOptCapts.Name = "txtOptCapts"
        Me.txtOptCapts.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtOptCapts.Size = New System.Drawing.Size(241, 20)
        Me.txtOptCapts.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(16, 190)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(117, 17)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Optional capabilities"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(16, 239)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(252, 60)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Live Trading ports: TWS: 7496; IB Gateway: 4001. Simulated Trading ports for new " & _
    "installations of version 954.1 or newer:  TWS: 7497; IB Gateway: 4002"
        '
        'dlgConnect
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(280, 348)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtOptCapts)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.txtClientId)
        Me.Controls.Add(Me.txtHostIP)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgConnect"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Connection Parameters"
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Private m_ok As Boolean = False
    Private m_optcapts As String
	
	' ===============================================================================
	' Get/Set Properties
	' ===============================================================================
	Public ReadOnly Property hostIP() As String
		Get
			hostIP = m_hostIP
		End Get
    End Property

    Public ReadOnly Property optCaps As String
        Get
            optCaps = m_optcapts
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
        m_optcapts = txtOptCapts.Text
		
        Close()
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		m_ok = False
        Close()
	End Sub
End Class
