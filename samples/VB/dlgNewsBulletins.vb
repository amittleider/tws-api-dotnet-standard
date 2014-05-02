' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Option Strict Off
Option Explicit On
Friend Class dlgNewsBulletins
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
	Public WithEvents cmdSubscribe As System.Windows.Forms.Button
	Public WithEvents optAllMsgs As System.Windows.Forms.RadioButton
	Public WithEvents optNewMsgs As System.Windows.Forms.RadioButton
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents cmdUnsubscribe As System.Windows.Forms.Button
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(dlgNewsBulletins))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ToolTip1.Active = True
		Me.cmdSubscribe = New System.Windows.Forms.Button
		Me.Frame1 = New System.Windows.Forms.GroupBox
		Me.optAllMsgs = New System.Windows.Forms.RadioButton
		Me.optNewMsgs = New System.Windows.Forms.RadioButton
		Me.Label1 = New System.Windows.Forms.Label
		Me.cmdClose = New System.Windows.Forms.Button
		Me.cmdUnsubscribe = New System.Windows.Forms.Button
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "IB News Bulletin Subscription"
		Me.ClientSize = New System.Drawing.Size(371, 146)
		Me.Location = New System.Drawing.Point(184, 250)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
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
		Me.Name = "dlgNewsBulletins"
		Me.cmdSubscribe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSubscribe.Text = "Subscribe"
		Me.cmdSubscribe.Size = New System.Drawing.Size(81, 25)
		Me.cmdSubscribe.Location = New System.Drawing.Point(72, 112)
		Me.cmdSubscribe.TabIndex = 4
		Me.cmdSubscribe.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdSubscribe.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSubscribe.CausesValidation = True
		Me.cmdSubscribe.Enabled = True
		Me.cmdSubscribe.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSubscribe.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSubscribe.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSubscribe.TabStop = True
		Me.cmdSubscribe.Name = "cmdSubscribe"
		Me.Frame1.Size = New System.Drawing.Size(353, 89)
		Me.Frame1.Location = New System.Drawing.Point(8, 8)
		Me.Frame1.TabIndex = 2
		Me.Frame1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Frame1.BackColor = System.Drawing.SystemColors.Control
		Me.Frame1.Enabled = True
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Visible = True
		Me.Frame1.Name = "Frame1"
		Me.optAllMsgs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optAllMsgs.Text = "receive all current day's messages and any new messages."
		Me.optAllMsgs.Size = New System.Drawing.Size(305, 17)
		Me.optAllMsgs.Location = New System.Drawing.Point(32, 56)
		Me.optAllMsgs.TabIndex = 6
		Me.optAllMsgs.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.optAllMsgs.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optAllMsgs.BackColor = System.Drawing.SystemColors.Control
		Me.optAllMsgs.CausesValidation = True
		Me.optAllMsgs.Enabled = True
		Me.optAllMsgs.ForeColor = System.Drawing.SystemColors.ControlText
		Me.optAllMsgs.Cursor = System.Windows.Forms.Cursors.Default
		Me.optAllMsgs.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.optAllMsgs.Appearance = System.Windows.Forms.Appearance.Normal
		Me.optAllMsgs.TabStop = True
		Me.optAllMsgs.Checked = False
		Me.optAllMsgs.Visible = True
		Me.optAllMsgs.Name = "optAllMsgs"
		Me.optNewMsgs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optNewMsgs.Text = "receive new messages only."
		Me.optNewMsgs.Size = New System.Drawing.Size(241, 17)
		Me.optNewMsgs.Location = New System.Drawing.Point(32, 32)
		Me.optNewMsgs.TabIndex = 5
		Me.optNewMsgs.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.optNewMsgs.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.optNewMsgs.BackColor = System.Drawing.SystemColors.Control
		Me.optNewMsgs.CausesValidation = True
		Me.optNewMsgs.Enabled = True
		Me.optNewMsgs.ForeColor = System.Drawing.SystemColors.ControlText
		Me.optNewMsgs.Cursor = System.Windows.Forms.Cursors.Default
		Me.optNewMsgs.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.optNewMsgs.Appearance = System.Windows.Forms.Appearance.Normal
		Me.optNewMsgs.TabStop = True
		Me.optNewMsgs.Checked = False
		Me.optNewMsgs.Visible = True
		Me.optNewMsgs.Name = "optNewMsgs"
		Me.Label1.Text = "When subscribing to IB news bulletins you have 2 options:"
		Me.Label1.Size = New System.Drawing.Size(297, 25)
		Me.Label1.Location = New System.Drawing.Point(8, 16)
		Me.Label1.TabIndex = 3
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
		Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdClose.Text = "Close"
		Me.cmdClose.Size = New System.Drawing.Size(81, 25)
		Me.cmdClose.Location = New System.Drawing.Point(280, 112)
		Me.cmdClose.TabIndex = 1
		Me.cmdClose.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
		Me.cmdClose.CausesValidation = True
		Me.cmdClose.Enabled = True
		Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdClose.TabStop = True
		Me.cmdClose.Name = "cmdClose"
		Me.cmdUnsubscribe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdUnsubscribe.Text = "UnSubscribe"
		Me.cmdUnsubscribe.Size = New System.Drawing.Size(81, 25)
		Me.cmdUnsubscribe.Location = New System.Drawing.Point(160, 112)
		Me.cmdUnsubscribe.TabIndex = 0
		Me.cmdUnsubscribe.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdUnsubscribe.BackColor = System.Drawing.SystemColors.Control
		Me.cmdUnsubscribe.CausesValidation = True
		Me.cmdUnsubscribe.Enabled = True
		Me.cmdUnsubscribe.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdUnsubscribe.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdUnsubscribe.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdUnsubscribe.TabStop = True
		Me.cmdUnsubscribe.Name = "cmdUnsubscribe"
		Me.Controls.Add(cmdSubscribe)
		Me.Controls.Add(Frame1)
		Me.Controls.Add(cmdClose)
		Me.Controls.Add(cmdUnsubscribe)
		Me.Frame1.Controls.Add(optAllMsgs)
		Me.Frame1.Controls.Add(optNewMsgs)
		Me.Frame1.Controls.Add(Label1)
	End Sub
#End Region 
#Region "Upgrade Support "
	Private Shared m_vb6FormDefInstance As dlgNewsBulletins
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As dlgNewsBulletins
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New dlgNewsBulletins()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	
	'================================================================================
	' Private Members
	'================================================================================
	Private m_subscribe As Boolean
	Private m_allMsgs As Boolean
	Private m_ok As Boolean
	
	' ========================================================
	' Get/Set Methods
	' ========================================================
	Public ReadOnly Property subscribe() As Boolean
		Get
			subscribe = m_subscribe
		End Get
	End Property
	
	Public ReadOnly Property allMsgs() As Boolean
		Get
			allMsgs = m_allMsgs
		End Get
	End Property
	
	Public ReadOnly Property ok() As Boolean
		Get
			ok = m_ok
		End Get
	End Property
	
	'================================================================================
	' Button Events
	'================================================================================
	
	'--------------------------------------------------------------------------------
	'   Aborts the news bulletin request and hides this dialog
	'--------------------------------------------------------------------------------
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		m_ok = False
		Hide()
	End Sub
	
	'--------------------------------------------------------------------------------
	'   Subscribes to IB news bulletins. When subscribing users can get all the existing
	'   days messages and will be notified of new messages
	'--------------------------------------------------------------------------------
	Private Sub cmdSubscribe_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSubscribe.Click
		m_ok = True
		m_subscribe = True
		m_allMsgs = (optAllMsgs.Checked = True)
		Hide()
	End Sub
	
	'--------------------------------------------------------------------------------
	'   Unsubscribes to news bulletins so users will not receive IB new bulletin
	'   notifications.
	'--------------------------------------------------------------------------------
	Private Sub cmdUnsubscribe_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUnsubscribe.Click
		m_ok = True
		m_subscribe = False
		Hide()
	End Sub
	
	'--------------------------------------------------------------------------------
	'   Default to the 'new messages only' subscription option if not is specified.
	'--------------------------------------------------------------------------------
	Private Sub dlgNewsBulletins_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		optNewMsgs.Checked = True
	End Sub
End Class