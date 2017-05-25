' Copyright (C) 2017 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.


Option Explicit On

Imports System.Collections.Generic

Friend Class dlgHistoricalNews
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
    Public WithEvents cmdOk As System.Windows.Forms.Button
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    Public WithEvents txtHistoricalNewsConId As System.Windows.Forms.TextBox
    Public WithEvents txtHistoricalNewsProviderCodes As System.Windows.Forms.TextBox
    Public WithEvents txtHistoricalNewsRequstId As System.Windows.Forms.TextBox
    Public WithEvents labelHistoricalNewsProviderCodes As System.Windows.Forms.Label
    Public WithEvents labelHistoricalNewsConId As System.Windows.Forms.Label
    Public WithEvents labelHistoricalNewsStartDateTime As System.Windows.Forms.Label
    Public WithEvents labelHistoricalNewsEndDateTime As System.Windows.Forms.Label
    Public WithEvents labelHistoricalNewsTotalResults As System.Windows.Forms.Label
    Public WithEvents txtHistoricalNewsStartDateTime As System.Windows.Forms.TextBox
    Public WithEvents txtHistoricalNewsEndDateTime As System.Windows.Forms.TextBox
    Public WithEvents txtHistoricalNewsTotalResults As System.Windows.Forms.TextBox
    Public WithEvents cmdMiscOptions As System.Windows.Forms.Button
    Public WithEvents labelHistoricalNewsRequestId As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.txtHistoricalNewsConId = New System.Windows.Forms.TextBox()
        Me.txtHistoricalNewsProviderCodes = New System.Windows.Forms.TextBox()
        Me.txtHistoricalNewsRequstId = New System.Windows.Forms.TextBox()
        Me.labelHistoricalNewsProviderCodes = New System.Windows.Forms.Label()
        Me.labelHistoricalNewsConId = New System.Windows.Forms.Label()
        Me.labelHistoricalNewsRequestId = New System.Windows.Forms.Label()
        Me.labelHistoricalNewsStartDateTime = New System.Windows.Forms.Label()
        Me.labelHistoricalNewsEndDateTime = New System.Windows.Forms.Label()
        Me.labelHistoricalNewsTotalResults = New System.Windows.Forms.Label()
        Me.txtHistoricalNewsStartDateTime = New System.Windows.Forms.TextBox()
        Me.txtHistoricalNewsEndDateTime = New System.Windows.Forms.TextBox()
        Me.txtHistoricalNewsTotalResults = New System.Windows.Forms.TextBox()
        Me.cmdMiscOptions = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        Me.cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOk.Location = New System.Drawing.Point(60, 203)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOk.Size = New System.Drawing.Size(73, 25)
        Me.cmdOk.TabIndex = 12
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(148, 203)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancel.TabIndex = 13
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'txtHistoricalNewsConId
        '
        Me.txtHistoricalNewsConId.AcceptsReturn = True
        Me.txtHistoricalNewsConId.BackColor = System.Drawing.SystemColors.Window
        Me.txtHistoricalNewsConId.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtHistoricalNewsConId.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHistoricalNewsConId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHistoricalNewsConId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHistoricalNewsConId.Location = New System.Drawing.Point(117, 42)
        Me.txtHistoricalNewsConId.MaxLength = 0
        Me.txtHistoricalNewsConId.Name = "txtHistoricalNewsConId"
        Me.txtHistoricalNewsConId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHistoricalNewsConId.Size = New System.Drawing.Size(151, 13)
        Me.txtHistoricalNewsConId.TabIndex = 3
        Me.txtHistoricalNewsConId.Text = "8314"
        '
        'txtHistoricalNewsProviderCodes
        '
        Me.txtHistoricalNewsProviderCodes.AcceptsReturn = True
        Me.txtHistoricalNewsProviderCodes.BackColor = System.Drawing.SystemColors.Window
        Me.txtHistoricalNewsProviderCodes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtHistoricalNewsProviderCodes.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHistoricalNewsProviderCodes.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHistoricalNewsProviderCodes.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHistoricalNewsProviderCodes.Location = New System.Drawing.Point(117, 68)
        Me.txtHistoricalNewsProviderCodes.MaxLength = 0
        Me.txtHistoricalNewsProviderCodes.Name = "txtHistoricalNewsProviderCodes"
        Me.txtHistoricalNewsProviderCodes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHistoricalNewsProviderCodes.Size = New System.Drawing.Size(151, 13)
        Me.txtHistoricalNewsProviderCodes.TabIndex = 5
        Me.txtHistoricalNewsProviderCodes.Text = "BZ+FLY"
        '
        'txtHistoricalNewsRequstId
        '
        Me.txtHistoricalNewsRequstId.AcceptsReturn = True
        Me.txtHistoricalNewsRequstId.BackColor = System.Drawing.SystemColors.Window
        Me.txtHistoricalNewsRequstId.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtHistoricalNewsRequstId.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHistoricalNewsRequstId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHistoricalNewsRequstId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHistoricalNewsRequstId.Location = New System.Drawing.Point(117, 16)
        Me.txtHistoricalNewsRequstId.MaxLength = 0
        Me.txtHistoricalNewsRequstId.Name = "txtHistoricalNewsRequstId"
        Me.txtHistoricalNewsRequstId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHistoricalNewsRequstId.Size = New System.Drawing.Size(151, 13)
        Me.txtHistoricalNewsRequstId.TabIndex = 1
        Me.txtHistoricalNewsRequstId.Text = "0"
        '
        'labelHistoricalNewsProviderCodes
        '
        Me.labelHistoricalNewsProviderCodes.BackColor = System.Drawing.Color.Gainsboro
        Me.labelHistoricalNewsProviderCodes.Cursor = System.Windows.Forms.Cursors.Default
        Me.labelHistoricalNewsProviderCodes.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelHistoricalNewsProviderCodes.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labelHistoricalNewsProviderCodes.Location = New System.Drawing.Point(16, 70)
        Me.labelHistoricalNewsProviderCodes.Name = "labelHistoricalNewsProviderCodes"
        Me.labelHistoricalNewsProviderCodes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.labelHistoricalNewsProviderCodes.Size = New System.Drawing.Size(95, 17)
        Me.labelHistoricalNewsProviderCodes.TabIndex = 4
        Me.labelHistoricalNewsProviderCodes.Text = "Provider Codes"
        '
        'labelHistoricalNewsConId
        '
        Me.labelHistoricalNewsConId.BackColor = System.Drawing.Color.Gainsboro
        Me.labelHistoricalNewsConId.Cursor = System.Windows.Forms.Cursors.Default
        Me.labelHistoricalNewsConId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelHistoricalNewsConId.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labelHistoricalNewsConId.Location = New System.Drawing.Point(16, 43)
        Me.labelHistoricalNewsConId.Name = "labelHistoricalNewsConId"
        Me.labelHistoricalNewsConId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.labelHistoricalNewsConId.Size = New System.Drawing.Size(95, 17)
        Me.labelHistoricalNewsConId.TabIndex = 2
        Me.labelHistoricalNewsConId.Text = "Contract Id"
        '
        'labelHistoricalNewsRequestId
        '
        Me.labelHistoricalNewsRequestId.BackColor = System.Drawing.Color.Gainsboro
        Me.labelHistoricalNewsRequestId.Cursor = System.Windows.Forms.Cursors.Default
        Me.labelHistoricalNewsRequestId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelHistoricalNewsRequestId.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labelHistoricalNewsRequestId.Location = New System.Drawing.Point(16, 16)
        Me.labelHistoricalNewsRequestId.Name = "labelHistoricalNewsRequestId"
        Me.labelHistoricalNewsRequestId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.labelHistoricalNewsRequestId.Size = New System.Drawing.Size(95, 17)
        Me.labelHistoricalNewsRequestId.TabIndex = 0
        Me.labelHistoricalNewsRequestId.Text = "Request Id"
        '
        'labelHistoricalNewsStartDateTime
        '
        Me.labelHistoricalNewsStartDateTime.BackColor = System.Drawing.Color.Gainsboro
        Me.labelHistoricalNewsStartDateTime.Cursor = System.Windows.Forms.Cursors.Default
        Me.labelHistoricalNewsStartDateTime.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelHistoricalNewsStartDateTime.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labelHistoricalNewsStartDateTime.Location = New System.Drawing.Point(16, 97)
        Me.labelHistoricalNewsStartDateTime.Name = "labelHistoricalNewsStartDateTime"
        Me.labelHistoricalNewsStartDateTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.labelHistoricalNewsStartDateTime.Size = New System.Drawing.Size(95, 17)
        Me.labelHistoricalNewsStartDateTime.TabIndex = 6
        Me.labelHistoricalNewsStartDateTime.Text = "Start Date/Time"
        '
        'labelHistoricalNewsEndDateTime
        '
        Me.labelHistoricalNewsEndDateTime.BackColor = System.Drawing.Color.Gainsboro
        Me.labelHistoricalNewsEndDateTime.Cursor = System.Windows.Forms.Cursors.Default
        Me.labelHistoricalNewsEndDateTime.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelHistoricalNewsEndDateTime.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labelHistoricalNewsEndDateTime.Location = New System.Drawing.Point(16, 124)
        Me.labelHistoricalNewsEndDateTime.Name = "labelHistoricalNewsEndDateTime"
        Me.labelHistoricalNewsEndDateTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.labelHistoricalNewsEndDateTime.Size = New System.Drawing.Size(95, 17)
        Me.labelHistoricalNewsEndDateTime.TabIndex = 8
        Me.labelHistoricalNewsEndDateTime.Text = "End Date/Time"
        '
        'labelHistoricalNewsTotalResults
        '
        Me.labelHistoricalNewsTotalResults.BackColor = System.Drawing.Color.Gainsboro
        Me.labelHistoricalNewsTotalResults.Cursor = System.Windows.Forms.Cursors.Default
        Me.labelHistoricalNewsTotalResults.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelHistoricalNewsTotalResults.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labelHistoricalNewsTotalResults.Location = New System.Drawing.Point(16, 151)
        Me.labelHistoricalNewsTotalResults.Name = "labelHistoricalNewsTotalResults"
        Me.labelHistoricalNewsTotalResults.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.labelHistoricalNewsTotalResults.Size = New System.Drawing.Size(95, 17)
        Me.labelHistoricalNewsTotalResults.TabIndex = 10
        Me.labelHistoricalNewsTotalResults.Text = "Total Results"
        '
        'txtHistoricalNewsStartDateTime
        '
        Me.txtHistoricalNewsStartDateTime.AcceptsReturn = True
        Me.txtHistoricalNewsStartDateTime.BackColor = System.Drawing.SystemColors.Window
        Me.txtHistoricalNewsStartDateTime.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtHistoricalNewsStartDateTime.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHistoricalNewsStartDateTime.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHistoricalNewsStartDateTime.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHistoricalNewsStartDateTime.Location = New System.Drawing.Point(117, 97)
        Me.txtHistoricalNewsStartDateTime.MaxLength = 0
        Me.txtHistoricalNewsStartDateTime.Name = "txtHistoricalNewsStartDateTime"
        Me.txtHistoricalNewsStartDateTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHistoricalNewsStartDateTime.Size = New System.Drawing.Size(151, 13)
        Me.txtHistoricalNewsStartDateTime.TabIndex = 7
        '
        'txtHistoricalNewsEndDateTime
        '
        Me.txtHistoricalNewsEndDateTime.AcceptsReturn = True
        Me.txtHistoricalNewsEndDateTime.BackColor = System.Drawing.SystemColors.Window
        Me.txtHistoricalNewsEndDateTime.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtHistoricalNewsEndDateTime.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHistoricalNewsEndDateTime.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHistoricalNewsEndDateTime.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHistoricalNewsEndDateTime.Location = New System.Drawing.Point(117, 124)
        Me.txtHistoricalNewsEndDateTime.MaxLength = 0
        Me.txtHistoricalNewsEndDateTime.Name = "txtHistoricalNewsEndDateTime"
        Me.txtHistoricalNewsEndDateTime.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHistoricalNewsEndDateTime.Size = New System.Drawing.Size(151, 13)
        Me.txtHistoricalNewsEndDateTime.TabIndex = 9
        '
        'txtHistoricalNewsTotalResults
        '
        Me.txtHistoricalNewsTotalResults.AcceptsReturn = True
        Me.txtHistoricalNewsTotalResults.BackColor = System.Drawing.SystemColors.Window
        Me.txtHistoricalNewsTotalResults.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtHistoricalNewsTotalResults.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHistoricalNewsTotalResults.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHistoricalNewsTotalResults.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHistoricalNewsTotalResults.Location = New System.Drawing.Point(117, 151)
        Me.txtHistoricalNewsTotalResults.MaxLength = 0
        Me.txtHistoricalNewsTotalResults.Name = "txtHistoricalNewsTotalResults"
        Me.txtHistoricalNewsTotalResults.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHistoricalNewsTotalResults.Size = New System.Drawing.Size(151, 13)
        Me.txtHistoricalNewsTotalResults.TabIndex = 11
        Me.txtHistoricalNewsTotalResults.Text = "10"
        '
        'cmdMiscOptions
        '
        Me.cmdMiscOptions.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdMiscOptions.BackColor = System.Drawing.SystemColors.Control
        Me.cmdMiscOptions.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdMiscOptions.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMiscOptions.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdMiscOptions.Location = New System.Drawing.Point(19, 172)
        Me.cmdMiscOptions.Name = "cmdMiscOptions"
        Me.cmdMiscOptions.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdMiscOptions.Size = New System.Drawing.Size(249, 25)
        Me.cmdMiscOptions.TabIndex = 14
        Me.cmdMiscOptions.Text = "Misc Options"
        Me.cmdMiscOptions.UseVisualStyleBackColor = True
        '
        'dlgHistoricalNews
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(280, 236)
        Me.Controls.Add(Me.cmdMiscOptions)
        Me.Controls.Add(Me.txtHistoricalNewsTotalResults)
        Me.Controls.Add(Me.txtHistoricalNewsEndDateTime)
        Me.Controls.Add(Me.txtHistoricalNewsStartDateTime)
        Me.Controls.Add(Me.labelHistoricalNewsTotalResults)
        Me.Controls.Add(Me.labelHistoricalNewsEndDateTime)
        Me.Controls.Add(Me.labelHistoricalNewsStartDateTime)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.txtHistoricalNewsConId)
        Me.Controls.Add(Me.txtHistoricalNewsProviderCodes)
        Me.Controls.Add(Me.txtHistoricalNewsRequstId)
        Me.Controls.Add(Me.labelHistoricalNewsProviderCodes)
        Me.Controls.Add(Me.labelHistoricalNewsConId)
        Me.Controls.Add(Me.labelHistoricalNewsRequestId)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgHistoricalNews"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Request Historical News"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
#Region "Upgrade Support "
    Private Shared m_vb6FormDefInstance As dlgHistoricalNews
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As dlgHistoricalNews
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New dlgHistoricalNews()
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(value As dlgHistoricalNews)
            m_vb6FormDefInstance = value
        End Set
    End Property
#End Region

    ' ===============================================================================
    ' Private Members
    ' ===============================================================================
    Private m_requestId As Integer
    Private m_conId As Integer
    Private m_providerCodes As String
    Private m_startDateTime As String
    Private m_endDateTime As String
    Private m_totalResults As Integer
    Private m_ok As Boolean = False
    Private m_options As List(Of IBApi.TagValue)

    ' ===============================================================================
    ' Get/Set Properties
    ' ===============================================================================
    Public ReadOnly Property requestId() As Integer
        Get
            requestId = m_requestId
        End Get
    End Property

    Public ReadOnly Property conId() As Integer
        Get
            conId = m_conId
        End Get
    End Property

    Public ReadOnly Property providerCodes() As String
        Get
            providerCodes = m_providerCodes
        End Get
    End Property

    Public ReadOnly Property startDateTime() As String
        Get
            startDateTime = m_startDateTime
        End Get
    End Property

    Public ReadOnly Property endDateTime() As String
        Get
            endDateTime = m_endDateTime
        End Get
    End Property

    Public ReadOnly Property totalResults() As Integer
        Get
            totalResults = m_totalResults
        End Get
    End Property

    Public ReadOnly Property ok() As Boolean
        Get
            ok = m_ok
        End Get
    End Property

    Public ReadOnly Property options() As List(Of IBApi.TagValue)
        Get
            options = m_options
        End Get
    End Property

    ' ========================================================
    ' Button Events
    ' ========================================================
    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        m_requestId = Text2Int(txtHistoricalNewsRequstId.Text)
        m_conId = Text2Int(txtHistoricalNewsConId.Text)
        m_providerCodes = txtHistoricalNewsProviderCodes.Text
        m_startDateTime = txtHistoricalNewsStartDateTime.Text
        m_endDateTime = txtHistoricalNewsEndDateTime.Text
        m_totalResults = Text2Int(txtHistoricalNewsTotalResults.Text)
        m_ok = True

        Close()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        m_ok = False
        Close()
    End Sub

    Private Sub dlgHistoricalNews_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        m_requestId = 0
        txtHistoricalNewsStartDateTime.Text = String.Format("{0:yyyy-MM-dd HH:mm:ss.0}", DateTime.Now.AddDays(-4))
        txtHistoricalNewsEndDateTime.Text = String.Format("{0:yyyy-MM-dd HH:mm:ss.0}", DateTime.Now.AddDays(-3))
    End Sub

    Private Function Text2Int(text As String) As Integer
        If Len(text) <= 0 Then
            Text2Int = 0
        Else
            Text2Int = text
        End If
    End Function

    ' ========================================================
    ' Public Methods
    ' ========================================================
    '--------------------------------------------------------------------------------
    ' Sets the dialog field and button states based on the dialog type
    '--------------------------------------------------------------------------------
    Public Sub init(options As List(Of IBApi.TagValue))
        m_ok = False
        m_options = options
    End Sub

    Private Sub cmdMiscOptions_Click(sender As Object, e As EventArgs) Handles cmdMiscOptions.Click
        Dim dlg As New dlgSmartComboRoutingParams
        dlg.init(m_options, "Misc Options")
        Dim res As DialogResult
        res = dlg.ShowDialog()
        If res = DialogResult.OK Then
            m_options = dlg.smartComboRoutingParams
        End If
    End Sub
End Class
