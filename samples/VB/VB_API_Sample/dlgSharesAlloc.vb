' Copyright (C) 2016 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.


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
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtFaProfile = New System.Windows.Forms.TextBox()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.txtFaGroup = New System.Windows.Forms.TextBox()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.txtFaPercentage = New System.Windows.Forms.TextBox()
        Me.txtFaMethod = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Frame1.SuspendLayout()
        Me.Frame2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtFaProfile
        '
        Me.txtFaProfile.AcceptsReturn = True
        Me.txtFaProfile.BackColor = System.Drawing.SystemColors.Window
        Me.txtFaProfile.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFaProfile.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFaProfile.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFaProfile.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFaProfile.Location = New System.Drawing.Point(112, 160)
        Me.txtFaProfile.MaxLength = 0
        Me.txtFaProfile.Name = "txtFaProfile"
        Me.txtFaProfile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFaProfile.Size = New System.Drawing.Size(292, 13)
        Me.txtFaProfile.TabIndex = 3
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(104, 216)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOK.Size = New System.Drawing.Size(76, 26)
        Me.cmdOK.TabIndex = 4
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(240, 216)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(76, 26)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'txtFaGroup
        '
        Me.txtFaGroup.AcceptsReturn = True
        Me.txtFaGroup.BackColor = System.Drawing.SystemColors.Window
        Me.txtFaGroup.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFaGroup.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFaGroup.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFaGroup.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFaGroup.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtFaGroup.Location = New System.Drawing.Point(112, 24)
        Me.txtFaGroup.MaxLength = 0
        Me.txtFaGroup.Name = "txtFaGroup"
        Me.txtFaGroup.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFaGroup.Size = New System.Drawing.Size(292, 13)
        Me.txtFaGroup.TabIndex = 0
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.Color.Gainsboro
        Me.Frame1.Controls.Add(Me.txtFaPercentage)
        Me.Frame1.Controls.Add(Me.txtFaMethod)
        Me.Frame1.Controls.Add(Me.Label4)
        Me.Frame1.Controls.Add(Me.Label2)
        Me.Frame1.Controls.Add(Me.Label1)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Frame1.Location = New System.Drawing.Point(8, 8)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(401, 121)
        Me.Frame1.TabIndex = 6
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Group"
        '
        'txtFaPercentage
        '
        Me.txtFaPercentage.AcceptsReturn = True
        Me.txtFaPercentage.BackColor = System.Drawing.SystemColors.Window
        Me.txtFaPercentage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFaPercentage.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFaPercentage.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFaPercentage.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFaPercentage.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtFaPercentage.Location = New System.Drawing.Point(104, 88)
        Me.txtFaPercentage.MaxLength = 0
        Me.txtFaPercentage.Name = "txtFaPercentage"
        Me.txtFaPercentage.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFaPercentage.Size = New System.Drawing.Size(292, 13)
        Me.txtFaPercentage.TabIndex = 2
        '
        'txtFaMethod
        '
        Me.txtFaMethod.AcceptsReturn = True
        Me.txtFaMethod.BackColor = System.Drawing.SystemColors.Window
        Me.txtFaMethod.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtFaMethod.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFaMethod.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFaMethod.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFaMethod.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtFaMethod.Location = New System.Drawing.Point(104, 51)
        Me.txtFaMethod.MaxLength = 0
        Me.txtFaMethod.Name = "txtFaMethod"
        Me.txtFaMethod.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtFaMethod.Size = New System.Drawing.Size(292, 13)
        Me.txtFaMethod.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Gainsboro
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(24, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(89, 17)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Percentage"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(24, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(89, 17)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Method"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(24, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(89, 17)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Group"
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.Color.Gainsboro
        Me.Frame2.Controls.Add(Me.Label3)
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Frame2.Location = New System.Drawing.Point(8, 144)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(401, 49)
        Me.Frame2.TabIndex = 8
        Me.Frame2.TabStop = False
        Me.Frame2.Text = "Profile"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Gainsboro
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(24, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(73, 17)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Profile"
        '
        'dlgSharesAlloc
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(418, 251)
        Me.Controls.Add(Me.txtFaProfile)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.txtFaGroup)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.Frame2)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(189, 232)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgSharesAlloc"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FA Allocation Info"
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.Frame2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        m_faGroup = txtFaGroup.Text
        m_faMethod = txtFaMethod.Text
        m_faPercentage = txtFaPercentage.Text
        m_faProfile = txtFaProfile.Text
        m_ok = True
        Me.Hide()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        m_ok = False
        Me.Hide()
    End Sub
    ' ========================================================
    ' Public Methods
    ' ========================================================
    Public Sub init(acctsList As String)

    End Sub
End Class
