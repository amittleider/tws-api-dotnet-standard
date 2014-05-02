' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Option Strict Off
Option Explicit On
Friend Class dlgSharesAlloc
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
	Public WithEvents txtFaProfile As System.Windows.Forms.TextBox
	Public WithEvents cmdOK As System.Windows.Forms.Button
	Public WithEvents cmdCancel As System.Windows.Forms.Button
	Public WithEvents txtFaGroup As System.Windows.Forms.TextBox
	Public WithEvents txtFaPercentage As System.Windows.Forms.TextBox
	Public WithEvents txtFaMethod As System.Windows.Forms.TextBox
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(dlgSharesAlloc))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ToolTip1.Active = True
		Me.txtFaProfile = New System.Windows.Forms.TextBox
		Me.cmdOK = New System.Windows.Forms.Button
		Me.cmdCancel = New System.Windows.Forms.Button
		Me.txtFaGroup = New System.Windows.Forms.TextBox
		Me.Frame1 = New System.Windows.Forms.GroupBox
		Me.txtFaPercentage = New System.Windows.Forms.TextBox
		Me.txtFaMethod = New System.Windows.Forms.TextBox
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.Frame2 = New System.Windows.Forms.GroupBox
		Me.Label3 = New System.Windows.Forms.Label
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "FA Allocation Info"
		Me.ClientSize = New System.Drawing.Size(418, 251)
		Me.Location = New System.Drawing.Point(189, 232)
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
		Me.Name = "dlgSharesAlloc"
		Me.txtFaProfile.AutoSize = False
		Me.txtFaProfile.Size = New System.Drawing.Size(292, 23)
		Me.txtFaProfile.Location = New System.Drawing.Point(112, 160)
		Me.txtFaProfile.TabIndex = 3
		Me.txtFaProfile.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtFaProfile.AcceptsReturn = True
		Me.txtFaProfile.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtFaProfile.BackColor = System.Drawing.SystemColors.Window
		Me.txtFaProfile.CausesValidation = True
		Me.txtFaProfile.Enabled = True
		Me.txtFaProfile.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtFaProfile.HideSelection = True
		Me.txtFaProfile.ReadOnly = False
		Me.txtFaProfile.Maxlength = 0
		Me.txtFaProfile.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtFaProfile.MultiLine = False
		Me.txtFaProfile.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtFaProfile.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtFaProfile.TabStop = True
		Me.txtFaProfile.Visible = True
		Me.txtFaProfile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtFaProfile.Name = "txtFaProfile"
		Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdOK.Text = "OK"
		Me.AcceptButton = Me.cmdOK
		Me.cmdOK.Size = New System.Drawing.Size(76, 26)
		Me.cmdOK.Location = New System.Drawing.Point(104, 216)
		Me.cmdOK.TabIndex = 4
		Me.cmdOK.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
		Me.cmdOK.CausesValidation = True
		Me.cmdOK.Enabled = True
		Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdOK.TabStop = True
		Me.cmdOK.Name = "cmdOK"
		Me.cmdCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdCancel.Text = "Cancel"
		Me.cmdCancel.Size = New System.Drawing.Size(76, 26)
		Me.cmdCancel.Location = New System.Drawing.Point(240, 216)
		Me.cmdCancel.TabIndex = 5
		Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
		Me.cmdCancel.CausesValidation = True
		Me.cmdCancel.Enabled = True
		Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdCancel.TabStop = True
		Me.cmdCancel.Name = "cmdCancel"
		Me.txtFaGroup.AutoSize = False
		Me.txtFaGroup.Size = New System.Drawing.Size(292, 21)
		Me.txtFaGroup.IMEMode = System.Windows.Forms.ImeMode.Disable
		Me.txtFaGroup.Location = New System.Drawing.Point(112, 24)
		Me.txtFaGroup.TabIndex = 0
		Me.txtFaGroup.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtFaGroup.AcceptsReturn = True
		Me.txtFaGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtFaGroup.BackColor = System.Drawing.SystemColors.Window
		Me.txtFaGroup.CausesValidation = True
		Me.txtFaGroup.Enabled = True
		Me.txtFaGroup.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtFaGroup.HideSelection = True
		Me.txtFaGroup.ReadOnly = False
		Me.txtFaGroup.Maxlength = 0
		Me.txtFaGroup.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtFaGroup.MultiLine = False
		Me.txtFaGroup.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtFaGroup.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtFaGroup.TabStop = True
		Me.txtFaGroup.Visible = True
		Me.txtFaGroup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtFaGroup.Name = "txtFaGroup"
		Me.Frame1.Text = "Group"
		Me.Frame1.Size = New System.Drawing.Size(401, 121)
		Me.Frame1.Location = New System.Drawing.Point(8, 8)
		Me.Frame1.TabIndex = 6
		Me.Frame1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Frame1.BackColor = System.Drawing.SystemColors.Control
		Me.Frame1.Enabled = True
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Visible = True
		Me.Frame1.Name = "Frame1"
		Me.txtFaPercentage.AutoSize = False
		Me.txtFaPercentage.Size = New System.Drawing.Size(292, 21)
		Me.txtFaPercentage.IMEMode = System.Windows.Forms.ImeMode.Disable
		Me.txtFaPercentage.Location = New System.Drawing.Point(104, 88)
		Me.txtFaPercentage.TabIndex = 2
		Me.txtFaPercentage.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtFaPercentage.AcceptsReturn = True
		Me.txtFaPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtFaPercentage.BackColor = System.Drawing.SystemColors.Window
		Me.txtFaPercentage.CausesValidation = True
		Me.txtFaPercentage.Enabled = True
		Me.txtFaPercentage.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtFaPercentage.HideSelection = True
		Me.txtFaPercentage.ReadOnly = False
		Me.txtFaPercentage.Maxlength = 0
		Me.txtFaPercentage.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtFaPercentage.MultiLine = False
		Me.txtFaPercentage.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtFaPercentage.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtFaPercentage.TabStop = True
		Me.txtFaPercentage.Visible = True
		Me.txtFaPercentage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtFaPercentage.Name = "txtFaPercentage"
		Me.txtFaMethod.AutoSize = False
		Me.txtFaMethod.Size = New System.Drawing.Size(292, 21)
		Me.txtFaMethod.IMEMode = System.Windows.Forms.ImeMode.Disable
		Me.txtFaMethod.Location = New System.Drawing.Point(104, 51)
		Me.txtFaMethod.TabIndex = 1
		Me.txtFaMethod.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtFaMethod.AcceptsReturn = True
		Me.txtFaMethod.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtFaMethod.BackColor = System.Drawing.SystemColors.Window
		Me.txtFaMethod.CausesValidation = True
		Me.txtFaMethod.Enabled = True
		Me.txtFaMethod.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtFaMethod.HideSelection = True
		Me.txtFaMethod.ReadOnly = False
		Me.txtFaMethod.Maxlength = 0
		Me.txtFaMethod.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtFaMethod.MultiLine = False
		Me.txtFaMethod.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtFaMethod.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtFaMethod.TabStop = True
		Me.txtFaMethod.Visible = True
		Me.txtFaMethod.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtFaMethod.Name = "txtFaMethod"
		Me.Label4.Text = "Percentage"
		Me.Label4.Size = New System.Drawing.Size(89, 17)
		Me.Label4.Location = New System.Drawing.Point(24, 88)
		Me.Label4.TabIndex = 11
		Me.Label4.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label4.BackColor = System.Drawing.SystemColors.Control
		Me.Label4.Enabled = True
		Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = False
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.Label2.Text = "Method"
		Me.Label2.Size = New System.Drawing.Size(89, 17)
		Me.Label2.Location = New System.Drawing.Point(24, 55)
		Me.Label2.TabIndex = 10
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
		Me.Label1.Text = "Group"
		Me.Label1.Size = New System.Drawing.Size(89, 17)
		Me.Label1.Location = New System.Drawing.Point(24, 18)
		Me.Label1.TabIndex = 7
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
		Me.Frame2.Text = "Profile"
		Me.Frame2.Size = New System.Drawing.Size(401, 49)
		Me.Frame2.Location = New System.Drawing.Point(8, 144)
		Me.Frame2.TabIndex = 8
		Me.Frame2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Frame2.BackColor = System.Drawing.SystemColors.Control
		Me.Frame2.Enabled = True
		Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame2.Visible = True
		Me.Frame2.Name = "Frame2"
		Me.Label3.Text = "Profile"
		Me.Label3.Size = New System.Drawing.Size(73, 17)
		Me.Label3.Location = New System.Drawing.Point(24, 18)
		Me.Label3.TabIndex = 9
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
		Me.Controls.Add(txtFaProfile)
		Me.Controls.Add(cmdOK)
		Me.Controls.Add(cmdCancel)
		Me.Controls.Add(txtFaGroup)
		Me.Controls.Add(Frame1)
		Me.Controls.Add(Frame2)
		Me.Frame1.Controls.Add(txtFaPercentage)
		Me.Frame1.Controls.Add(txtFaMethod)
		Me.Frame1.Controls.Add(Label4)
		Me.Frame1.Controls.Add(Label2)
		Me.Frame1.Controls.Add(Label1)
		Me.Frame2.Controls.Add(Label3)
	End Sub
#End Region 
#Region "Upgrade Support "
	Private Shared m_vb6FormDefInstance As dlgSharesAlloc
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As dlgSharesAlloc
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New dlgSharesAlloc()
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
	Private m_ok As Boolean
	Private m_faGroup As String
	Private m_faMethod As String
	Private m_faPercentage As String
	Private m_faProfile As String
	Public ReadOnly Property faGroup() As String
		Get
			faGroup = m_faGroup
		End Get
	End Property
	Public ReadOnly Property faMethod() As String
		Get
			faMethod = m_faMethod
		End Get
	End Property
	Public ReadOnly Property faPercentage() As String
		Get
			faPercentage = m_faPercentage
		End Get
	End Property
	Public ReadOnly Property faProfile() As String
		Get
			faProfile = m_faProfile
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
		m_faGroup = txtFaGroup.Text
		m_faMethod = txtFaMethod.Text
		m_faPercentage = txtFaPercentage.Text
		m_faProfile = txtFaProfile.Text
		m_ok = True
		Me.Hide()
	End Sub
	
	Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
		m_ok = False
		Me.Hide()
	End Sub
	' ========================================================
	' Public Methods
	' ========================================================
	Public Sub init(ByRef acctsList As String)
		
	End Sub
End Class