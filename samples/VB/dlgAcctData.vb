' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Option Strict Off
Option Explicit On
Friend Class dlgAcctData
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
	Public WithEvents txtLastUpdateTime As System.Windows.Forms.TextBox
	Public WithEvents lstPortfolioData As System.Windows.Forms.ListBox
	Public WithEvents Frame2 As System.Windows.Forms.GroupBox
	Public WithEvents lstKeyValueData As System.Windows.Forms.ListBox
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents cmdClose As System.Windows.Forms.Button
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtLastUpdateTime = New System.Windows.Forms.TextBox
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me.lstPortfolioData = New System.Windows.Forms.ListBox
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.lstKeyValueData = New System.Windows.Forms.ListBox
        Me.cmdClose = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Frame2.SuspendLayout()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtLastUpdateTime
        '
        Me.txtLastUpdateTime.AcceptsReturn = True
        Me.txtLastUpdateTime.BackColor = System.Drawing.SystemColors.Window
        Me.txtLastUpdateTime.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLastUpdateTime.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastUpdateTime.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtLastUpdateTime.Location = New System.Drawing.Point(104, 352)
        Me.txtLastUpdateTime.MaxLength = 0
        Me.txtLastUpdateTime.Name = "txtLastUpdateTime"
        Me.txtLastUpdateTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLastUpdateTime.Size = New System.Drawing.Size(89, 19)
        Me.txtLastUpdateTime.TabIndex = 6
        Me.txtLastUpdateTime.Text = "00:00"
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Controls.Add(Me.lstPortfolioData)
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(8, 192)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(649, 137)
        Me.Frame2.TabIndex = 3
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Portfolio Data"
        '
        'lstPortfolioData
        '
        Me.lstPortfolioData.BackColor = System.Drawing.SystemColors.Window
        Me.lstPortfolioData.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstPortfolioData.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstPortfolioData.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstPortfolioData.HorizontalScrollbar = True
        Me.lstPortfolioData.ItemHeight = 14
        Me.lstPortfolioData.Location = New System.Drawing.Point(8, 24)
        Me.lstPortfolioData.Name = "lstPortfolioData"
        Me.lstPortfolioData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstPortfolioData.Size = New System.Drawing.Size(633, 88)
        Me.lstPortfolioData.TabIndex = 4
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.lstKeyValueData)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(8, 16)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(649, 161)
        Me.Frame1.TabIndex = 1
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Key, Value, and Currency"
        '
        'lstKeyValueData
        '
        Me.lstKeyValueData.BackColor = System.Drawing.SystemColors.Window
        Me.lstKeyValueData.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstKeyValueData.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstKeyValueData.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstKeyValueData.ItemHeight = 14
        Me.lstKeyValueData.Location = New System.Drawing.Point(8, 24)
        Me.lstKeyValueData.Name = "lstKeyValueData"
        Me.lstKeyValueData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstKeyValueData.Size = New System.Drawing.Size(633, 116)
        Me.lstKeyValueData.TabIndex = 2
        '
        'cmdClose
        '
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Location = New System.Drawing.Point(293, 352)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.Size = New System.Drawing.Size(81, 25)
        Me.cmdClose.TabIndex = 0
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 352)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(89, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Last update time :"
        '
        'dlgAcctData
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(667, 392)
        Me.Controls.Add(Me.txtLastUpdateTime)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(315, 341)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgAcctData"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Account Update"
        Me.Frame2.ResumeLayout(False)
        Me.Frame1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Upgrade Support "
	Private Shared m_vb6FormDefInstance As dlgAcctData
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As dlgAcctData
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New dlgAcctData()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	
    Private m_utils As Utils

    Private m_accountName As String
    Private m_complete As Boolean
	
	
	' ========================================================
	' Button Events
	' ========================================================
	Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
		' clear any existing list details
		lstKeyValueData.Items.Clear()
		lstPortfolioData.Items.Clear()
		txtLastUpdateTime.Text = "00:00"
		
		Hide()
	End Sub
	
	' ========================================================
	' Public methods
	' ========================================================
	'--------------------------------------------------------------------------------
	' Class initializer. Make utilites available to this class
	'--------------------------------------------------------------------------------
	Public Sub init(ByVal utilities As Utils)
		m_utils = utilities
	End Sub
	
	'--------------------------------------------------------------------------------
	' Updates a user account property
	'--------------------------------------------------------------------------------
    Public Sub updateAccountValue(ByRef key As String, ByRef val_Renamed As String, ByRef curency As String, ByRef accountName As String)
        Dim msg As String

        msg = "key=" & key & " value=" & val_Renamed & " currency=" & curency & " account=" & accountName
        Call m_utils.addListItem(Utils.List_Types.ACCOUNT_DATA, msg)
    End Sub

    '--------------------------------------------------------------------------------
    ' Updates a portfolio position details
    '--------------------------------------------------------------------------------
    Public Sub updatePortfolio(ByVal contract As IBApi.Contract, ByRef position As Integer, ByRef marketPrice As Double, ByRef marketValue As Double, ByRef averageCost As Double, ByRef unrealizedPNL As Double, ByRef realizedPNL As Double, ByRef accountName As String)
        Dim msg As String

        With contract
            msg = "conId=" & .ConId & " symbol=" & .Symbol & " secType=" & .SecType & " expiry=" & .Expiry & " strike=" & .Strike _
            & " right=" & .Right & " multiplier=" & .Multiplier & " primaryExch=" & .PrimaryExch & " currency=" & .Currency _
            & " localSymbol=" & .LocalSymbol & " tradingClass=" & .TradingClass & " position=" & position & " mktPrice=" & marketPrice & " mktValue=" & marketValue _
            & " avgCost=" & averageCost & " unrealizedPNL=" & unrealizedPNL & " realizedPNL=" & realizedPNL & " account=" & accountName
        End With
        Call m_utils.addListItem(Utils.List_Types.PORTFOLIO_DATA, msg)
    End Sub

    '--------------------------------------------------------------------------------
    ' Updates the server clock time
    '--------------------------------------------------------------------------------
    Public Sub updateAccountTime(ByRef timeStamp As String)
        txtLastUpdateTime.Text = timeStamp
    End Sub

    Public Sub accountDownloadBegin(ByVal accountName As String)
        m_accountName = accountName
        m_complete = False
        Call updateTitle()
    End Sub

    Public Sub accountDownloadEnd(ByVal accountName As String)
        If Len(m_accountName) <> 0 And m_accountName <> accountName Then
            Return
        End If

        m_complete = True
        Call updateTitle()
    End Sub

    Private Sub updateTitle()

        Dim title As String
        title = ""

        If Len(m_accountName) <> 0 Then
            title = m_accountName
        End If
        If m_complete Then
            If Len(title) <> 0 Then
                title = title & " "
            End If
            title = title & "[complete]"
        End If

        Me.Text = title

    End Sub
End Class
