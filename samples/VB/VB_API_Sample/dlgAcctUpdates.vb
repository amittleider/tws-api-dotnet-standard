' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.


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
    Public WithEvents cmdUnSubscribe As Button
    Public WithEvents cmdSubscribe As Button
    Public WithEvents txtAcctCode As TextBox
    Public WithEvents Label2 As Label
    Public WithEvents Label1 As Label
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdUnSubscribe = New System.Windows.Forms.Button()
        Me.cmdSubscribe = New System.Windows.Forms.Button()
        Me.txtAcctCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(88, 152)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(81, 25)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdUnSubscribe
        '
        Me.cmdUnSubscribe.BackColor = System.Drawing.SystemColors.Control
        Me.cmdUnSubscribe.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdUnSubscribe.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUnSubscribe.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdUnSubscribe.Location = New System.Drawing.Point(148, 100)
        Me.cmdUnSubscribe.Name = "cmdUnSubscribe"
        Me.cmdUnSubscribe.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdUnSubscribe.Size = New System.Drawing.Size(89, 25)
        Me.cmdUnSubscribe.TabIndex = 11
        Me.cmdUnSubscribe.Text = "UnSubscribe"
        Me.cmdUnSubscribe.UseVisualStyleBackColor = False
        '
        'cmdSubscribe
        '
        Me.cmdSubscribe.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSubscribe.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdSubscribe.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSubscribe.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdSubscribe.Location = New System.Drawing.Point(28, 100)
        Me.cmdSubscribe.Name = "cmdSubscribe"
        Me.cmdSubscribe.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSubscribe.Size = New System.Drawing.Size(89, 25)
        Me.cmdSubscribe.TabIndex = 10
        Me.cmdSubscribe.Text = "Subscribe"
        Me.cmdSubscribe.UseVisualStyleBackColor = False
        '
        'txtAcctCode
        '
        Me.txtAcctCode.AcceptsReturn = True
        Me.txtAcctCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtAcctCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtAcctCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAcctCode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAcctCode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAcctCode.Location = New System.Drawing.Point(124, 68)
        Me.txtAcctCode.MaxLength = 0
        Me.txtAcctCode.Name = "txtAcctCode"
        Me.txtAcctCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAcctCode.Size = New System.Drawing.Size(121, 13)
        Me.txtAcctCode.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(28, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(81, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Account Code :"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(20, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(225, 33)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = " Enter the account code for the FA managed account you wish to receive updates fo" &
    "r : "
        '
        'dlgAcctUpdates
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(257, 185)
        Me.Controls.Add(Me.cmdUnSubscribe)
        Me.Controls.Add(Me.cmdSubscribe)
        Me.Controls.Add(Me.txtAcctCode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(184, 250)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgAcctUpdates"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Account Updates (FA customers only)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Private Sub cmdSubscribe_Click(sender As Object, e As EventArgs)
        m_acctCode = txtAcctCode.Text
        m_subscribe = True
        m_ok = True
        Me.Hide()
    End Sub

    Private Sub cmdUnSubscribe_Click(sender As Object, e As EventArgs)
        m_acctCode = txtAcctCode.Text
        m_subscribe = False
        m_ok = True
        Me.Hide()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        m_acctCode = ""
        m_ok = False
        Me.Hide()
    End Sub

End Class
