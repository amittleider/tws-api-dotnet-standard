' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Option Strict Off
Option Explicit On
Friend Class dlgAcctUpdates
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
	Public WithEvents cmdUnSubscribe As System.Windows.Forms.Button
	Public WithEvents cmdSubscribe As System.Windows.Forms.Button
	Public WithEvents txtAcctCode As System.Windows.Forms.TextBox
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(dlgAcctUpdates))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ToolTip1.Active = True
		Me.Frame1 = New System.Windows.Forms.GroupBox
		Me.cmdUnSubscribe = New System.Windows.Forms.Button
		Me.cmdSubscribe = New System.Windows.Forms.Button
		Me.txtAcctCode = New System.Windows.Forms.TextBox
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Account Updates (FA customers only)"
		Me.ClientSize = New System.Drawing.Size(257, 185)
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
		Me.Name = "dlgAcctUpdates"
		Me.Frame1.Size = New System.Drawing.Size(241, 129)
		Me.Frame1.Location = New System.Drawing.Point(8, 8)
		Me.Frame1.TabIndex = 5
		Me.Frame1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Frame1.BackColor = System.Drawing.SystemColors.Control
		Me.Frame1.Enabled = True
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Visible = True
		Me.Frame1.Name = "Frame1"
		Me.cmdUnSubscribe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdUnSubscribe.Text = "UnSubscribe"
		Me.cmdUnSubscribe.Size = New System.Drawing.Size(89, 25)
		Me.cmdUnSubscribe.Location = New System.Drawing.Point(136, 96)
		Me.cmdUnSubscribe.TabIndex = 4
		Me.cmdUnSubscribe.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdUnSubscribe.BackColor = System.Drawing.SystemColors.Control
		Me.cmdUnSubscribe.CausesValidation = True
		Me.cmdUnSubscribe.Enabled = True
		Me.cmdUnSubscribe.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdUnSubscribe.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdUnSubscribe.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdUnSubscribe.TabStop = True
		Me.cmdUnSubscribe.Name = "cmdUnSubscribe"
		Me.cmdSubscribe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdSubscribe.Text = "Subscribe"
		Me.cmdSubscribe.Size = New System.Drawing.Size(89, 25)
		Me.cmdSubscribe.Location = New System.Drawing.Point(16, 96)
		Me.cmdSubscribe.TabIndex = 3
		Me.cmdSubscribe.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdSubscribe.BackColor = System.Drawing.SystemColors.Control
		Me.cmdSubscribe.CausesValidation = True
		Me.cmdSubscribe.Enabled = True
		Me.cmdSubscribe.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdSubscribe.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdSubscribe.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdSubscribe.TabStop = True
		Me.cmdSubscribe.Name = "cmdSubscribe"
		Me.txtAcctCode.AutoSize = False
		Me.txtAcctCode.Size = New System.Drawing.Size(121, 19)
		Me.txtAcctCode.Location = New System.Drawing.Point(112, 64)
		Me.txtAcctCode.TabIndex = 2
		Me.txtAcctCode.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtAcctCode.AcceptsReturn = True
		Me.txtAcctCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtAcctCode.BackColor = System.Drawing.SystemColors.Window
		Me.txtAcctCode.CausesValidation = True
		Me.txtAcctCode.Enabled = True
		Me.txtAcctCode.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtAcctCode.HideSelection = True
		Me.txtAcctCode.ReadOnly = False
		Me.txtAcctCode.Maxlength = 0
		Me.txtAcctCode.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtAcctCode.MultiLine = False
		Me.txtAcctCode.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtAcctCode.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtAcctCode.TabStop = True
		Me.txtAcctCode.Visible = True
		Me.txtAcctCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtAcctCode.Name = "txtAcctCode"
		Me.Label2.Text = "Account Code :"
		Me.Label2.Size = New System.Drawing.Size(81, 17)
		Me.Label2.Location = New System.Drawing.Point(16, 64)
		Me.Label2.TabIndex = 1
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
		Me.Label1.Text = " Enter the account code for the FA managed account you wish to receive updates for : "
		Me.Label1.Size = New System.Drawing.Size(225, 33)
		Me.Label1.Location = New System.Drawing.Point(8, 16)
		Me.Label1.TabIndex = 0
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
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Label1.Name = "Label1"
		Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCancel.Text = "Cancel"
		Me.cmdCancel.Size = New System.Drawing.Size(81, 25)
		Me.cmdCancel.Location = New System.Drawing.Point(88, 152)
		Me.cmdCancel.TabIndex = 6
		Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCancel.CausesValidation = True
		Me.cmdCancel.Enabled = True
		Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCancel.TabStop = True
		Me.cmdCancel.Name = "cmdCancel"
		Me.Controls.Add(Frame1)
		Me.Controls.Add(cmdCancel)
		Me.Frame1.Controls.Add(cmdUnSubscribe)
		Me.Frame1.Controls.Add(cmdSubscribe)
		Me.Frame1.Controls.Add(txtAcctCode)
		Me.Frame1.Controls.Add(Label2)
		Me.Frame1.Controls.Add(Label1)
	End Sub
#End Region 
#Region "Upgrade Support "
	Private Shared m_vb6FormDefInstance As dlgAcctUpdates
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As dlgAcctUpdates
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New dlgAcctUpdates()
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
	Private m_acctCode As String
	Private m_subscribe As Boolean
	Private m_ok As Boolean
	
	' ===============================================================================
	' Get/Set Properties
	' ===============================================================================
	Public ReadOnly Property acctCode() As String
		Get
			acctCode = m_acctCode
		End Get
	End Property
	
    Public ReadOnly Property subscribe() As Boolean
        Get
            subscribe = m_subscribe
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
	Private Sub cmdSubscribe_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdSubscribe.Click
		m_acctCode = txtAcctCode.Text
		m_subscribe = True
		m_ok = True
		Me.Hide()
	End Sub
	
	Private Sub cmdUnSubscribe_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdUnSubscribe.Click
		m_acctCode = txtAcctCode.Text
		m_subscribe = False
		m_ok = True
		Me.Hide()
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		m_acctCode = ""
		m_ok = False
		Me.Hide()
	End Sub
End Class