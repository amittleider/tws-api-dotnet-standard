' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.


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
	Protected Overloads Overrides Sub Dispose(Disposing As Boolean)
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
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdSubscribe = New System.Windows.Forms.Button()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.optAllMsgs = New System.Windows.Forms.RadioButton()
        Me.optNewMsgs = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdUnsubscribe = New System.Windows.Forms.Button()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdSubscribe
        '
        Me.cmdSubscribe.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSubscribe.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSubscribe.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSubscribe.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSubscribe.Location = New System.Drawing.Point(72, 112)
        Me.cmdSubscribe.Name = "cmdSubscribe"
        Me.cmdSubscribe.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSubscribe.Size = New System.Drawing.Size(81, 25)
        Me.cmdSubscribe.TabIndex = 4
        Me.cmdSubscribe.Text = "Subscribe"
        Me.cmdSubscribe.UseVisualStyleBackColor = True
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.Color.Gainsboro
        Me.Frame1.Controls.Add(Me.optAllMsgs)
        Me.Frame1.Controls.Add(Me.optNewMsgs)
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Frame1.Location = New System.Drawing.Point(8, 8)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(353, 89)
        Me.Frame1.TabIndex = 2
        Me.Frame1.TabStop = False
        '
        'optAllMsgs
        '
        Me.optAllMsgs.BackColor = System.Drawing.Color.Gainsboro
        Me.optAllMsgs.Cursor = System.Windows.Forms.Cursors.Default
        Me.optAllMsgs.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optAllMsgs.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optAllMsgs.Location = New System.Drawing.Point(32, 56)
        Me.optAllMsgs.Name = "optAllMsgs"
        Me.optAllMsgs.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optAllMsgs.Size = New System.Drawing.Size(305, 17)
        Me.optAllMsgs.TabIndex = 6
        Me.optAllMsgs.TabStop = True
        Me.optAllMsgs.Text = "receive all current day's messages and any new messages."
        Me.optAllMsgs.UseVisualStyleBackColor = False
        '
        'optNewMsgs
        '
        Me.optNewMsgs.BackColor = System.Drawing.Color.Gainsboro
        Me.optNewMsgs.Cursor = System.Windows.Forms.Cursors.Default
        Me.optNewMsgs.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optNewMsgs.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optNewMsgs.Location = New System.Drawing.Point(32, 32)
        Me.optNewMsgs.Name = "optNewMsgs"
        Me.optNewMsgs.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optNewMsgs.Size = New System.Drawing.Size(241, 17)
        Me.optNewMsgs.TabIndex = 5
        Me.optNewMsgs.TabStop = True
        Me.optNewMsgs.Text = "receive new messages only."
        Me.optNewMsgs.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(297, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "When subscribing to IB news bulletins you have 2 options:"
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(280, 112)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(81, 25)
        Me.cmdClose.TabIndex = 1
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdUnsubscribe
        '
        Me.cmdUnsubscribe.BackColor = System.Drawing.SystemColors.Control
        Me.cmdUnsubscribe.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdUnsubscribe.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUnsubscribe.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdUnsubscribe.Location = New System.Drawing.Point(160, 112)
        Me.cmdUnsubscribe.Name = "cmdUnsubscribe"
        Me.cmdUnsubscribe.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdUnsubscribe.Size = New System.Drawing.Size(81, 25)
        Me.cmdUnsubscribe.TabIndex = 0
        Me.cmdUnsubscribe.Text = "UnSubscribe"
        Me.cmdUnsubscribe.UseVisualStyleBackColor = True
        '
        'dlgNewsBulletins
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(371, 146)
        Me.Controls.Add(Me.cmdSubscribe)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdUnsubscribe)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(184, 250)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgNewsBulletins"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "IB News Bulletin Subscription"
        Me.Frame1.ResumeLayout(False)
        Me.ResumeLayout(False)

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
	Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
		m_ok = False
		Hide()
	End Sub
	
	'--------------------------------------------------------------------------------
	'   Subscribes to IB news bulletins. When subscribing users can get all the existing
	'   days messages and will be notified of new messages
	'--------------------------------------------------------------------------------
	Private Sub cmdSubscribe_Click(sender As Object, e As EventArgs) Handles cmdSubscribe.Click
		m_ok = True
		m_subscribe = True
		m_allMsgs = (optAllMsgs.Checked = True)
		Hide()
	End Sub
	
	'--------------------------------------------------------------------------------
	'   Unsubscribes to news bulletins so users will not receive IB new bulletin
	'   notifications.
	'--------------------------------------------------------------------------------
	Private Sub cmdUnsubscribe_Click(sender As Object, e As EventArgs) Handles cmdUnsubscribe.Click
		m_ok = True
		m_subscribe = False
		Hide()
	End Sub
	
	'--------------------------------------------------------------------------------
	'   Default to the 'new messages only' subscription option if not is specified.
	'--------------------------------------------------------------------------------
	Private Sub dlgNewsBulletins_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		optNewMsgs.Checked = True
	End Sub
End Class
