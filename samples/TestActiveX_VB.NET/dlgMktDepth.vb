' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Option Strict Off
Option Explicit On
Friend Class dlgMktDepth
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
    'Public WithEvents grdBidBookEntries As AxMSFlexGridLib.AxMSFlexGrid
	Public WithEvents btnClose As System.Windows.Forms.Button
    'Public WithEvents grdAskBookEntries As AxMSFlexGridLib.AxMSFlexGrid
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(dlgMktDepth))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        ' Me.grdBidBookEntries = New AxMSFlexGridLib.AxMSFlexGrid
        Me.btnClose = New System.Windows.Forms.Button
        ' Me.grdAskBookEntries = New AxMSFlexGridLib.AxMSFlexGrid
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        'CType(Me.grdBidBookEntries, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(Me.grdAskBookEntries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdBidBookEntries
        '
        'Me.grdBidBookEntries.CausesValidation = False
        'Me.grdBidBookEntries.Location = New System.Drawing.Point(8, 24)
        'Me.grdBidBookEntries.Name = "grdBidBookEntries"
        'Me.grdBidBookEntries.OcxState = CType(resources.GetObject("grdBidBookEntries.OcxState"), System.Windows.Forms.AxHost.State)
        'Me.grdBidBookEntries.Size = New System.Drawing.Size(364, 375)
        'Me.grdBidBookEntries.TabIndex = 1
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.Control
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClose.Location = New System.Drawing.Point(336, 408)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClose.Size = New System.Drawing.Size(81, 25)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "Close"
        '
        'grdAskBookEntries
        '
        'Me.grdAskBookEntries.CausesValidation = False
        'Me.grdAskBookEntries.Location = New System.Drawing.Point(380, 24)
        'Me.grdAskBookEntries.Name = "grdAskBookEntries"
        'Me.grdAskBookEntries.OcxState = CType(resources.GetObject("grdAskBookEntries.OcxState"), System.Windows.Forms.AxHost.State)
        'Me.grdAskBookEntries.Size = New System.Drawing.Size(364, 375)
        'Me.grdAskBookEntries.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(496, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(33, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Ask"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(168, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(33, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Bid"
        '
        'dlgMktDepth
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(754, 439)
        'Me.Controls.Add(Me.grdBidBookEntries)
        'Me.Controls.Add(Me.btnClose)
        'Me.Controls.Add(Me.grdAskBookEntries)
        'Me.Controls.Add(Me.Label2)
        'Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(399, 416)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgMktDepth"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Market Depth for: "
        'CType(Me.grdBidBookEntries, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(Me.grdAskBookEntries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region 
#Region "Upgrade Support "
	Private Shared m_vb6FormDefInstance As dlgMktDepth
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As dlgMktDepth
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New dlgMktDepth()
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
	' enums
	Enum Operation_Type
		OPERATION_INSERT = 0
		OPERATION_UPDATE = 1
		OPERATION_DELETE = 2
	End Enum
	
	Enum side
		ASK = 0
		BID = 1
	End Enum
	
    ' member variables
	Private m_ok As Boolean
	
	'================================================================================
	' Button Events
	'================================================================================
	Private Sub btnClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnClose.Click
		m_ok = False
		Me.Close()
	End Sub
	
	'================================================================================
	' Public Methods
    ' ===============================================================================
    '--------------------------------------------------------------------------------
    ' Adds the market depth row to the book
    '--------------------------------------------------------------------------------
    Public Sub updateMktDepth(ByVal tickerId As Short, ByVal rowId As Integer, ByVal marketMaker As String, ByVal operation As Integer, ByVal iside As Integer, ByVal price As Double, ByVal size_Renamed As Integer)
        ' Dim lstBookEntries As AxMSFlexGridLib.AxMSFlexGrid
        Dim bookentry As String, oldVal As String
        Dim theRow As Integer
        'If iside = side.BID Then
        '    lstBookEntries = grdBidBookEntries
        'Else
        '    lstBookEntries = grdAskBookEntries
        'End If
        'theRow = rowId + 1
        'If operation = Operation_Type.OPERATION_INSERT Then
        '    bookentry = marketMaker & vbTab & price & vbTab & size_Renamed & vbTab & "0.0" & vbTab & "0"
        '    ' lstBookEntries.AddItem(bookentry, theRow)
        'ElseIf operation = Operation_Type.OPERATION_UPDATE Then
        '    oldVal = lstBookEntries.get_TextMatrix(theRow, 0)
        '    If marketMaker <> oldVal Then
        '        lstBookEntries.set_TextMatrix(theRow, 0, marketMaker)
        '    End If
        '    oldVal = lstBookEntries.get_TextMatrix(theRow, 1)
        '    If price <> oldVal Then
        '        lstBookEntries.set_TextMatrix(theRow, 1, price)
        '    End If
        '    oldVal = lstBookEntries.get_TextMatrix(theRow, 2)
        '    If size_Renamed <> oldVal Then
        '        lstBookEntries.set_TextMatrix(theRow, 2, size_Renamed)
        '    End If
        'ElseIf operation = Operation_Type.OPERATION_DELETE Then
        '    lstBookEntries.RemoveItem(theRow)
        'End If

        '' recalc only the average cost and cumulative sizes that could have changed
        'Call UpdateList(lstBookEntries, theRow)
        'lstBookEntries.Refresh()
    End Sub

    '--------------------------------------------------------------------------------
    ' Flush the deep book
    '--------------------------------------------------------------------------------
    Public Sub init()
        ' flush the book entries and add the column headers
        ' clear()
        'If grdAskBookEntries.Rows = 0 Or grdBidBookEntries.Rows = 0 Then
        '    Dim bookentry As String
        '    bookentry = "MM" & vbTab & "Price" & vbTab & "Size" & vbTab & "cumSize" & vbTab & "avgPrice"
        '    If grdAskBookEntries.Rows = 0 Then
        '        grdAskBookEntries.AddItem(bookentry)
        '    End If
        '    If grdBidBookEntries.Rows = 0 Then
        '        grdBidBookEntries.AddItem(bookentry)
        '    End If
        'End If
    End Sub
    'Private Sub subClear(ByVal lstBookEntries As AxMSFlexGridLib.AxMSFlexGrid)
    '    Dim iLoop As Long
    '    For iLoop = lstBookEntries.Rows - 1 To 1 Step -1
    '        lstBookEntries.RemoveItem(iLoop)
    '    Next
    'End Sub
    'Public Sub clear()
    '    Call subClear(grdAskBookEntries)
    '    Call subClear(grdBidBookEntries)
    'End Sub
    'Private Sub UpdateList(ByRef lstBookEntries As AxMSFlexGridLib.AxMSFlexGrid, ByVal baseRow As Integer)
    '    Dim size_Renamed, cumSize As Short
    '    Dim price, totalPrice As Double
    '    Dim iLoop As Short

    '    totalPrice = 0
    '    cumSize = 0
    '    If baseRow > 1 And baseRow <= lstBookEntries.Rows - 1 Then
    '        cumSize = lstBookEntries.get_TextMatrix(baseRow - 1, 3)
    '        totalPrice = lstBookEntries.get_TextMatrix(baseRow - 1, 1) * cumSize
    '    End If

    '    For iLoop = baseRow To lstBookEntries.Rows - 1
    '        price = lstBookEntries.get_TextMatrix(iLoop, 1)
    '        size_Renamed = lstBookEntries.get_TextMatrix(iLoop, 2)
    '        cumSize = cumSize + size_Renamed
    '        totalPrice = totalPrice + (price * size_Renamed)
    '        lstBookEntries.set_TextMatrix(iLoop, 3, cumSize)
    '        lstBookEntries.set_TextMatrix(iLoop, 4, System.Math.Round(totalPrice / cumSize, 6))
    '    Next iLoop
    'End Sub
End Class