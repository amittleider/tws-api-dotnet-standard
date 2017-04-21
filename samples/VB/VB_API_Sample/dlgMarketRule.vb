' Copyright (C) 2017 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.


Option Explicit On
Friend Class dlgMarketRule
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
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    Public WithEvents cmdOk As System.Windows.Forms.Button
    Public WithEvents txtMarketRuleId As System.Windows.Forms.TextBox
    Public WithEvents lblMarketRuleId As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.txtMarketRuleId = New System.Windows.Forms.TextBox()
        Me.lblMarketRuleId = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(143, 42)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOk.Location = New System.Drawing.Point(64, 42)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOk.Size = New System.Drawing.Size(73, 25)
        Me.cmdOk.TabIndex = 0
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'txtMarketRuleId
        '
        Me.txtMarketRuleId.AcceptsReturn = True
        Me.txtMarketRuleId.BackColor = System.Drawing.SystemColors.Window
        Me.txtMarketRuleId.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMarketRuleId.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMarketRuleId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMarketRuleId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMarketRuleId.Location = New System.Drawing.Point(119, 12)
        Me.txtMarketRuleId.MaxLength = 0
        Me.txtMarketRuleId.Name = "txtMarketRuleId"
        Me.txtMarketRuleId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMarketRuleId.Size = New System.Drawing.Size(97, 13)
        Me.txtMarketRuleId.TabIndex = 1
        Me.txtMarketRuleId.Text = "0"
        '
        'lblMarketRuleId
        '
        Me.lblMarketRuleId.BackColor = System.Drawing.Color.Gainsboro
        Me.lblMarketRuleId.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblMarketRuleId.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMarketRuleId.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMarketRuleId.Location = New System.Drawing.Point(15, 15)
        Me.lblMarketRuleId.Name = "lblMarketRuleId"
        Me.lblMarketRuleId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblMarketRuleId.Size = New System.Drawing.Size(97, 17)
        Me.lblMarketRuleId.TabIndex = 15
        Me.lblMarketRuleId.Text = "Market Rule Id"
        '
        'dlgMarketRule
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(237, 70)
        Me.Controls.Add(Me.lblMarketRuleId)
        Me.Controls.Add(Me.txtMarketRuleId)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(184, 250)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgMarketRule"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Market Rule"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
#Region "Upgrade Support "
    Private Shared m_vb6FormDefInstance As dlgMarketRule
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As dlgMarketRule
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New dlgMarketRule()
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(value As dlgMarketRule)
            m_vb6FormDefInstance = value
        End Set
    End Property
#End Region

    ' ========================================================
    ' Member variables
    ' ========================================================
    Private m_marketRuleId As Integer
    Private m_ok As Boolean

    ' ========================================================
    ' Get/Set Methods
    ' ========================================================

    Public ReadOnly Property marketRuleId() As Integer
        Get
            marketRuleId = m_marketRuleId
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
    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOk.Click

        m_marketRuleId = Text2Int(txtMarketRuleId.Text)

        m_ok = True
        Me.Hide()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        m_ok = False
        Me.Hide()
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
    Public Sub init()
        m_ok = False
    End Sub
End Class


