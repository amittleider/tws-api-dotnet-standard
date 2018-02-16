' Copyright (C) 2017 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.


Option Explicit On

Imports System.Collections.Generic
Imports System.IO

Friend Class dlgNewsArticle
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
    Public WithEvents txtReqNewsArticleProviderCode As System.Windows.Forms.TextBox
    Public WithEvents txtReqNewsArticleArticleId As System.Windows.Forms.TextBox
    Public WithEvents txtReqNewsArticleRequestId As System.Windows.Forms.TextBox
    Public WithEvents labelReqNewsArticleArticleId As System.Windows.Forms.Label
    Public WithEvents labelReqNewsArticleProviderCode As System.Windows.Forms.Label
    Public WithEvents cmdMiscOptions As System.Windows.Forms.Button
    Public WithEvents labelReqNewsArticlePath As System.Windows.Forms.Label
    Public WithEvents txtReqNewsArticlePath As System.Windows.Forms.TextBox
    Friend WithEvents cmdSelectFolderDialog As System.Windows.Forms.Button
    Public WithEvents labelReqNewsArticleRequestId As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.txtReqNewsArticleProviderCode = New System.Windows.Forms.TextBox()
        Me.txtReqNewsArticleArticleId = New System.Windows.Forms.TextBox()
        Me.txtReqNewsArticleRequestId = New System.Windows.Forms.TextBox()
        Me.labelReqNewsArticleArticleId = New System.Windows.Forms.Label()
        Me.labelReqNewsArticleProviderCode = New System.Windows.Forms.Label()
        Me.labelReqNewsArticleRequestId = New System.Windows.Forms.Label()
        Me.cmdMiscOptions = New System.Windows.Forms.Button()
        Me.labelReqNewsArticlePath = New System.Windows.Forms.Label()
        Me.txtReqNewsArticlePath = New System.Windows.Forms.TextBox()
        Me.cmdSelectFolderDialog = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        Me.cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOk.Location = New System.Drawing.Point(57, 171)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOk.Size = New System.Drawing.Size(73, 25)
        Me.cmdOk.TabIndex = 7
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
        Me.cmdCancel.Location = New System.Drawing.Point(136, 171)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancel.TabIndex = 8
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'txtReqNewsArticleProviderCode
        '
        Me.txtReqNewsArticleProviderCode.AcceptsReturn = True
        Me.txtReqNewsArticleProviderCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtReqNewsArticleProviderCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtReqNewsArticleProviderCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtReqNewsArticleProviderCode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReqNewsArticleProviderCode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtReqNewsArticleProviderCode.Location = New System.Drawing.Point(117, 42)
        Me.txtReqNewsArticleProviderCode.MaxLength = 0
        Me.txtReqNewsArticleProviderCode.Name = "txtReqNewsArticleProviderCode"
        Me.txtReqNewsArticleProviderCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtReqNewsArticleProviderCode.Size = New System.Drawing.Size(151, 13)
        Me.txtReqNewsArticleProviderCode.TabIndex = 3
        '
        'txtReqNewsArticleArticleId
        '
        Me.txtReqNewsArticleArticleId.AcceptsReturn = True
        Me.txtReqNewsArticleArticleId.BackColor = System.Drawing.SystemColors.Window
        Me.txtReqNewsArticleArticleId.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtReqNewsArticleArticleId.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtReqNewsArticleArticleId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReqNewsArticleArticleId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtReqNewsArticleArticleId.Location = New System.Drawing.Point(117, 71)
        Me.txtReqNewsArticleArticleId.MaxLength = 0
        Me.txtReqNewsArticleArticleId.Name = "txtReqNewsArticleArticleId"
        Me.txtReqNewsArticleArticleId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtReqNewsArticleArticleId.Size = New System.Drawing.Size(151, 13)
        Me.txtReqNewsArticleArticleId.TabIndex = 5
        '
        'txtReqNewsArticleRequestId
        '
        Me.txtReqNewsArticleRequestId.AcceptsReturn = True
        Me.txtReqNewsArticleRequestId.BackColor = System.Drawing.SystemColors.Window
        Me.txtReqNewsArticleRequestId.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtReqNewsArticleRequestId.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtReqNewsArticleRequestId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReqNewsArticleRequestId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtReqNewsArticleRequestId.Location = New System.Drawing.Point(117, 16)
        Me.txtReqNewsArticleRequestId.MaxLength = 0
        Me.txtReqNewsArticleRequestId.Name = "txtReqNewsArticleRequestId"
        Me.txtReqNewsArticleRequestId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtReqNewsArticleRequestId.Size = New System.Drawing.Size(151, 13)
        Me.txtReqNewsArticleRequestId.TabIndex = 1
        Me.txtReqNewsArticleRequestId.Text = "0"
        '
        'labelReqNewsArticleArticleId
        '
        Me.labelReqNewsArticleArticleId.BackColor = System.Drawing.Color.Gainsboro
        Me.labelReqNewsArticleArticleId.Cursor = System.Windows.Forms.Cursors.Default
        Me.labelReqNewsArticleArticleId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelReqNewsArticleArticleId.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labelReqNewsArticleArticleId.Location = New System.Drawing.Point(16, 71)
        Me.labelReqNewsArticleArticleId.Name = "labelReqNewsArticleArticleId"
        Me.labelReqNewsArticleArticleId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.labelReqNewsArticleArticleId.Size = New System.Drawing.Size(89, 17)
        Me.labelReqNewsArticleArticleId.TabIndex = 4
        Me.labelReqNewsArticleArticleId.Text = "Article Id"
        '
        'labelReqNewsArticleProviderCode
        '
        Me.labelReqNewsArticleProviderCode.BackColor = System.Drawing.Color.Gainsboro
        Me.labelReqNewsArticleProviderCode.Cursor = System.Windows.Forms.Cursors.Default
        Me.labelReqNewsArticleProviderCode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelReqNewsArticleProviderCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labelReqNewsArticleProviderCode.Location = New System.Drawing.Point(16, 42)
        Me.labelReqNewsArticleProviderCode.Name = "labelReqNewsArticleProviderCode"
        Me.labelReqNewsArticleProviderCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.labelReqNewsArticleProviderCode.Size = New System.Drawing.Size(89, 19)
        Me.labelReqNewsArticleProviderCode.TabIndex = 2
        Me.labelReqNewsArticleProviderCode.Text = "Provider Code"
        '
        'labelReqNewsArticleRequestId
        '
        Me.labelReqNewsArticleRequestId.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton
        Me.labelReqNewsArticleRequestId.BackColor = System.Drawing.Color.Gainsboro
        Me.labelReqNewsArticleRequestId.Cursor = System.Windows.Forms.Cursors.Default
        Me.labelReqNewsArticleRequestId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelReqNewsArticleRequestId.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labelReqNewsArticleRequestId.Location = New System.Drawing.Point(16, 16)
        Me.labelReqNewsArticleRequestId.Name = "labelReqNewsArticleRequestId"
        Me.labelReqNewsArticleRequestId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.labelReqNewsArticleRequestId.Size = New System.Drawing.Size(95, 17)
        Me.labelReqNewsArticleRequestId.TabIndex = 0
        Me.labelReqNewsArticleRequestId.Text = "Request Id"
        '
        'cmdMiscOptions
        '
        Me.cmdMiscOptions.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdMiscOptions.BackColor = System.Drawing.SystemColors.Control
        Me.cmdMiscOptions.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdMiscOptions.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMiscOptions.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdMiscOptions.Location = New System.Drawing.Point(19, 140)
        Me.cmdMiscOptions.Name = "cmdMiscOptions"
        Me.cmdMiscOptions.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdMiscOptions.Size = New System.Drawing.Size(249, 25)
        Me.cmdMiscOptions.TabIndex = 9
        Me.cmdMiscOptions.Text = "Misc Options"
        Me.cmdMiscOptions.UseVisualStyleBackColor = True
        '
        'labelReqNewsArticlePath
        '
        Me.labelReqNewsArticlePath.BackColor = System.Drawing.Color.Gainsboro
        Me.labelReqNewsArticlePath.Cursor = System.Windows.Forms.Cursors.Default
        Me.labelReqNewsArticlePath.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelReqNewsArticlePath.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labelReqNewsArticlePath.Location = New System.Drawing.Point(16, 101)
        Me.labelReqNewsArticlePath.Name = "labelReqNewsArticlePath"
        Me.labelReqNewsArticlePath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.labelReqNewsArticlePath.Size = New System.Drawing.Size(89, 36)
        Me.labelReqNewsArticlePath.TabIndex = 10
        Me.labelReqNewsArticlePath.Text = "Path to Save binary/pdf"
        '
        'txtReqNewsArticlePath
        '
        Me.txtReqNewsArticlePath.AcceptsReturn = True
        Me.txtReqNewsArticlePath.BackColor = System.Drawing.SystemColors.Window
        Me.txtReqNewsArticlePath.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtReqNewsArticlePath.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtReqNewsArticlePath.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReqNewsArticlePath.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtReqNewsArticlePath.Location = New System.Drawing.Point(117, 101)
        Me.txtReqNewsArticlePath.MaxLength = 0
        Me.txtReqNewsArticlePath.Name = "txtReqNewsArticlePath"
        Me.txtReqNewsArticlePath.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtReqNewsArticlePath.Size = New System.Drawing.Size(116, 13)
        Me.txtReqNewsArticlePath.TabIndex = 11
        '
        'cmdSelectFolderDialog
        '
        Me.cmdSelectFolderDialog.Location = New System.Drawing.Point(239, 98)
        Me.cmdSelectFolderDialog.Name = "cmdSelectFolderDialog"
        Me.cmdSelectFolderDialog.Size = New System.Drawing.Size(29, 20)
        Me.cmdSelectFolderDialog.TabIndex = 12
        Me.cmdSelectFolderDialog.Text = "..."
        Me.cmdSelectFolderDialog.UseVisualStyleBackColor = True
        '
        'dlgNewsArticle
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(280, 208)
        Me.Controls.Add(Me.cmdSelectFolderDialog)
        Me.Controls.Add(Me.txtReqNewsArticlePath)
        Me.Controls.Add(Me.labelReqNewsArticlePath)
        Me.Controls.Add(Me.cmdMiscOptions)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.txtReqNewsArticleProviderCode)
        Me.Controls.Add(Me.txtReqNewsArticleArticleId)
        Me.Controls.Add(Me.txtReqNewsArticleRequestId)
        Me.Controls.Add(Me.labelReqNewsArticleArticleId)
        Me.Controls.Add(Me.labelReqNewsArticleProviderCode)
        Me.Controls.Add(Me.labelReqNewsArticleRequestId)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgNewsArticle"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Request News Article"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
#Region "Upgrade Support "
    Private Shared m_vb6FormDefInstance As dlgNewsArticle
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As dlgNewsArticle
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New dlgNewsArticle()
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(value As dlgNewsArticle)
            m_vb6FormDefInstance = value
        End Set
    End Property
#End Region

    ' ===============================================================================
    ' Private Members
    ' ===============================================================================
    Private m_requestId As Integer
    Private m_providerCode As String
    Private m_articleId As String
    Private m_path As String
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

    Public ReadOnly Property providerCode() As String
        Get
            providerCode = m_providerCode
        End Get
    End Property

    Public ReadOnly Property articleId() As String
        Get
            articleId = m_articleId
        End Get
    End Property

    Public ReadOnly Property path() As String
        Get
            path = m_path
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
        m_requestId = Text2Int(txtReqNewsArticleRequestId.Text)
        m_providerCode = txtReqNewsArticleProviderCode.Text
        m_articleId = txtReqNewsArticleArticleId.Text
        m_path = txtReqNewsArticlePath.Text + "\" + articleId + ".pdf"
        m_ok = True

        Close()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        m_ok = False
        Close()
    End Sub

    Private Sub dlgNewsArticle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        m_requestId = 0
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

        txtReqNewsArticleRequestId.Enabled = True
        txtReqNewsArticleProviderCode.Enabled = True
        txtReqNewsArticleArticleId.Enabled = True
        txtReqNewsArticlePath.Enabled = True
        txtReqNewsArticlePath.Text = Directory.GetCurrentDirectory()

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

    Private Sub cmdSelectFolderDialog_Click(sender As Object, e As EventArgs) Handles cmdSelectFolderDialog.Click
        Dim dlg As New FolderBrowserDialog With {.SelectedPath = txtReqNewsArticlePath.Text}

        If dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then
            Return
        End If

        txtReqNewsArticlePath.Text = dlg.SelectedPath
    End Sub
End Class
