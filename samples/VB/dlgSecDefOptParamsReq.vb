' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Option Strict Off
Option Explicit On
Friend Class dlgSecDefOptParamsReq
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

        txtConId.Text = m_conId
        txtReqId.Text = m_reqId
        txtExchange.Text = m_exchange
        txtSecType.Text = m_secType
        txtSymbol.Text = m_symbol
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
    Public WithEvents txtConId As System.Windows.Forms.TextBox
    Public WithEvents txtSymbol As System.Windows.Forms.TextBox
    Public WithEvents txtSecType As System.Windows.Forms.TextBox
    Public WithEvents txtExchange As System.Windows.Forms.TextBox
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    Public WithEvents cmdOk As System.Windows.Forms.Button
    Public WithEvents lblSymbol As System.Windows.Forms.Label
    Public WithEvents lblSecType As System.Windows.Forms.Label
    Public WithEvents lblExchange As System.Windows.Forms.Label
    Public WithEvents txtReqId As System.Windows.Forms.TextBox
    Public WithEvents lblReqId As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtConId = New System.Windows.Forms.TextBox()
        Me.txtSymbol = New System.Windows.Forms.TextBox()
        Me.txtSecType = New System.Windows.Forms.TextBox()
        Me.txtExchange = New System.Windows.Forms.TextBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.lblSymbol = New System.Windows.Forms.Label()
        Me.lblSecType = New System.Windows.Forms.Label()
        Me.lblExchange = New System.Windows.Forms.Label()
        Me.txtReqId = New System.Windows.Forms.TextBox()
        Me.lblReqId = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtConId
        '
        Me.txtConId.AcceptsReturn = True
        Me.txtConId.BackColor = System.Drawing.SystemColors.Window
        Me.txtConId.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtConId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtConId.Location = New System.Drawing.Point(119, 114)
        Me.txtConId.MaxLength = 0
        Me.txtConId.Name = "txtConId"
        Me.txtConId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtConId.Size = New System.Drawing.Size(161, 20)
        Me.txtConId.TabIndex = 6
        '
        'txtSymbol
        '
        Me.txtSymbol.AcceptsReturn = True
        Me.txtSymbol.BackColor = System.Drawing.SystemColors.Window
        Me.txtSymbol.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSymbol.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSymbol.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSymbol.Location = New System.Drawing.Point(119, 38)
        Me.txtSymbol.MaxLength = 0
        Me.txtSymbol.Name = "txtSymbol"
        Me.txtSymbol.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSymbol.Size = New System.Drawing.Size(161, 20)
        Me.txtSymbol.TabIndex = 2
        '
        'txtSecType
        '
        Me.txtSecType.AcceptsReturn = True
        Me.txtSecType.BackColor = System.Drawing.SystemColors.Window
        Me.txtSecType.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSecType.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSecType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtSecType.Location = New System.Drawing.Point(119, 63)
        Me.txtSecType.MaxLength = 0
        Me.txtSecType.Name = "txtSecType"
        Me.txtSecType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtSecType.Size = New System.Drawing.Size(161, 20)
        Me.txtSecType.TabIndex = 3
        '
        'txtExchange
        '
        Me.txtExchange.AcceptsReturn = True
        Me.txtExchange.BackColor = System.Drawing.SystemColors.Window
        Me.txtExchange.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtExchange.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExchange.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtExchange.Location = New System.Drawing.Point(119, 88)
        Me.txtExchange.MaxLength = 0
        Me.txtExchange.Name = "txtExchange"
        Me.txtExchange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtExchange.Size = New System.Drawing.Size(161, 20)
        Me.txtExchange.TabIndex = 4
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(207, 148)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancel.TabIndex = 8
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdOk
        '
        Me.cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOk.Location = New System.Drawing.Point(128, 148)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOk.Size = New System.Drawing.Size(73, 25)
        Me.cmdOk.TabIndex = 7
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'lblSymbol
        '
        Me.lblSymbol.BackColor = System.Drawing.SystemColors.Control
        Me.lblSymbol.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblSymbol.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSymbol.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSymbol.Location = New System.Drawing.Point(15, 41)
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
        Me.lblSecType.Location = New System.Drawing.Point(15, 66)
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
        Me.lblExchange.Location = New System.Drawing.Point(15, 91)
        Me.lblExchange.Name = "lblExchange"
        Me.lblExchange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblExchange.Size = New System.Drawing.Size(73, 17)
        Me.lblExchange.TabIndex = 9
        Me.lblExchange.Text = "Exchange"
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
        Me.txtReqId.Size = New System.Drawing.Size(161, 20)
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
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(15, 117)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(81, 17)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "ConID"
        '
        'dlgSecDefOptParamsReq
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(292, 185)
        Me.Controls.Add(Me.txtConId)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblReqId)
        Me.Controls.Add(Me.txtReqId)
        Me.Controls.Add(Me.txtSymbol)
        Me.Controls.Add(Me.txtSecType)
        Me.Controls.Add(Me.txtExchange)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.lblSymbol)
        Me.Controls.Add(Me.lblSecType)
        Me.Controls.Add(Me.lblExchange)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(184, 250)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgSecDefOptParamsReq"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Security Definition Option Parameters Request"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
#Region "Upgrade Support "
    Private Shared m_vb6FormDefInstance As dlgSecDefOptParamsReq
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As dlgSecDefOptParamsReq
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New dlgSecDefOptParamsReq()
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(value As dlgSecDefOptParamsReq)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region
    ' ========================================================
    ' Member variables
    ' ========================================================
    Private m_symbol As String
    Private m_secType As String
    Private m_exchange As String
    Private m_conId As String
    Private m_reqId As Integer

    ' ========================================================
    ' Get/Set Methods
    ' ========================================================

    Public ReadOnly Property reqId As Integer
        Get
            Return m_reqId
        End Get
    End Property

    Public ReadOnly Property secType As String
        Get
            Return m_secType
        End Get
    End Property

    Public ReadOnly Property symbol As String
        Get
            Return m_symbol
        End Get
    End Property

    Public ReadOnly Property exchange As String
        Get
            Return m_exchange
        End Get
    End Property

    Public ReadOnly Property conId As Integer
        Get
            Return m_conId
        End Get
    End Property

    ' ========================================================
    ' Button Events
    ' ========================================================
    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click

        m_reqId = Text2Int(txtReqId.Text)
        m_conId = Text2IntMax(txtConId.Text)
        m_symbol = txtSymbol.Text
        m_secType = txtSecType.Text
        m_exchange = txtExchange.Text
        DialogResult = DialogResult.OK

        Me.Hide()

    End Sub

    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
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

    Private Function Text2IntMax(ByRef text As String) As Integer
        If Len(text) <= 0 Then
            Return Integer.MaxValue
        Else
            Return text
        End If
    End Function

End Class
