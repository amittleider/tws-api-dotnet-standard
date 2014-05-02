' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Option Strict Off
Option Explicit On
Friend Class dlgLogConfig
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
	Public WithEvents cmbServerLogLevel As System.Windows.Forms.ComboBox
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents CancelButton_Renamed As System.Windows.Forms.Button
	Public WithEvents OKButton As System.Windows.Forms.Button
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(dlgLogConfig))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ToolTip1.Active = True
		Me.Frame1 = New System.Windows.Forms.GroupBox
		Me.cmbServerLogLevel = New System.Windows.Forms.ComboBox
		Me.Label1 = New System.Windows.Forms.Label
		Me.CancelButton_Renamed = New System.Windows.Forms.Button
		Me.OKButton = New System.Windows.Forms.Button
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Log Configuration"
		Me.ClientSize = New System.Drawing.Size(224, 116)
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
		Me.Name = "dlgLogConfig"
		Me.Frame1.Text = "TWS Server"
		Me.Frame1.Size = New System.Drawing.Size(209, 57)
		Me.Frame1.Location = New System.Drawing.Point(8, 8)
		Me.Frame1.TabIndex = 2
		Me.Frame1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Frame1.BackColor = System.Drawing.SystemColors.Control
		Me.Frame1.Enabled = True
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Visible = True
		Me.Frame1.Name = "Frame1"
		Me.cmbServerLogLevel.Size = New System.Drawing.Size(121, 21)
		Me.cmbServerLogLevel.Location = New System.Drawing.Point(80, 24)
		Me.cmbServerLogLevel.TabIndex = 3
		Me.cmbServerLogLevel.Text = "Combo1"
		Me.cmbServerLogLevel.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmbServerLogLevel.BackColor = System.Drawing.SystemColors.Window
		Me.cmbServerLogLevel.CausesValidation = True
		Me.cmbServerLogLevel.Enabled = True
		Me.cmbServerLogLevel.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbServerLogLevel.IntegralHeight = True
		Me.cmbServerLogLevel.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbServerLogLevel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbServerLogLevel.Sorted = False
		Me.cmbServerLogLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
		Me.cmbServerLogLevel.TabStop = True
		Me.cmbServerLogLevel.Visible = True
		Me.cmbServerLogLevel.Name = "cmbServerLogLevel"
		Me.Label1.Text = "Log Level :"
		Me.Label1.Size = New System.Drawing.Size(65, 17)
		Me.Label1.Location = New System.Drawing.Point(16, 32)
		Me.Label1.TabIndex = 4
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
		Me.CancelButton_Renamed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CancelButton_Renamed.Text = "Cancel"
		Me.CancelButton_Renamed.Size = New System.Drawing.Size(65, 25)
		Me.CancelButton_Renamed.Location = New System.Drawing.Point(116, 80)
		Me.CancelButton_Renamed.TabIndex = 1
		Me.CancelButton_Renamed.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CancelButton_Renamed.BackColor = System.Drawing.SystemColors.Control
		Me.CancelButton_Renamed.CausesValidation = True
		Me.CancelButton_Renamed.Enabled = True
		Me.CancelButton_Renamed.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CancelButton_Renamed.Cursor = System.Windows.Forms.Cursors.Default
		Me.CancelButton_Renamed.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CancelButton_Renamed.TabStop = True
		Me.CancelButton_Renamed.Name = "CancelButton_Renamed"
		Me.OKButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.OKButton.Text = "OK"
		Me.OKButton.Size = New System.Drawing.Size(65, 25)
		Me.OKButton.Location = New System.Drawing.Point(44, 80)
		Me.OKButton.TabIndex = 0
		Me.OKButton.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.OKButton.BackColor = System.Drawing.SystemColors.Control
		Me.OKButton.CausesValidation = True
		Me.OKButton.Enabled = True
		Me.OKButton.ForeColor = System.Drawing.SystemColors.ControlText
		Me.OKButton.Cursor = System.Windows.Forms.Cursors.Default
		Me.OKButton.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.OKButton.TabStop = True
		Me.OKButton.Name = "OKButton"
		Me.Controls.Add(Frame1)
		Me.Controls.Add(CancelButton_Renamed)
		Me.Controls.Add(OKButton)
		Me.Frame1.Controls.Add(cmbServerLogLevel)
		Me.Frame1.Controls.Add(Label1)
	End Sub
#End Region 
#Region "Upgrade Support "
	Private Shared m_vb6FormDefInstance As dlgLogConfig
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As dlgLogConfig
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New dlgLogConfig()
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
	' Public Members
	' ===============================================================================
	Public Enum LOG_LEVEL
		Sys = 1
		Err
		Warn
		Info
		Detail
	End Enum
	
	' ===============================================================================
	' Private Members
	' ===============================================================================
	Private m_serverLogLevel As Short
	Private m_ok As Boolean
	
	' ===============================================================================
	' Get/Set Properties
	' ===============================================================================
	Public ReadOnly Property serverLogLevel() As Short
		Get
			serverLogLevel = m_serverLogLevel
		End Get
	End Property
	
	Public ReadOnly Property ok() As Boolean
		Get
			ok = m_ok
		End Get
	End Property
	
	' ========================================================
	' Private Methods
	' ========================================================
	Private Sub dlgLogConfig_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		cmbServerLogLevel.Items.Add(("System"))
		cmbServerLogLevel.Items.Add(("Error"))
		cmbServerLogLevel.Items.Add(("Warning"))
		cmbServerLogLevel.Items.Add(("Information"))
		cmbServerLogLevel.Items.Add(("Detail"))
		
		cmbServerLogLevel.SelectedIndex = LOG_LEVEL.Err - 1 ' Dfault TWS log level is ERROR
	End Sub
	
	' ========================================================
	' Button Events
	' ========================================================
	Private Sub OKButton_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles OKButton.Click
		m_serverLogLevel = cmbServerLogLevel.SelectedIndex + 1
		m_ok = True
		
		Hide()
	End Sub
	
	Private Sub CancelButton_Renamed_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CancelButton_Renamed.Click
		m_ok = False
		Hide()
	End Sub
End Class