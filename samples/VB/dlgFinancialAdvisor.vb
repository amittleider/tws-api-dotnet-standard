' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Option Strict Off
Option Explicit On 
Friend Class dlgFinancialAdvisor
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
    Public WithEvents lstProfiles As System.Windows.Forms.TextBox
    Public WithEvents lstAliases As System.Windows.Forms.TextBox
    Public WithEvents lstGroups As System.Windows.Forms.TextBox
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents cmdClose As System.Windows.Forms.Button
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Public WithEvents Frame3 As System.Windows.Forms.GroupBox
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(dlgFinancialAdvisor))
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
        Me.ToolTip1.Active = True
        Me.lstProfiles = New System.Windows.Forms.TextBox
        Me.lstAliases = New System.Windows.Forms.TextBox
        Me.Frame1 = New System.Windows.Forms.GroupBox
        Me.lstGroups = New System.Windows.Forms.TextBox
        Me.cmdClose = New System.Windows.Forms.Button
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me.Frame3 = New System.Windows.Forms.GroupBox
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Text = "Financial Advisor"
        Me.ClientSize = New System.Drawing.Size(667, 595)
        Me.Location = New System.Drawing.Point(315, 341)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ControlBox = True
        Me.Enabled = True
        Me.KeyPreview = False
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.HelpButton = False
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        Me.Name = "dlgFinancialAdvisor"
        Me.lstProfiles.AutoSize = False
        Me.lstProfiles.Size = New System.Drawing.Size(633, 121)
        Me.lstProfiles.Location = New System.Drawing.Point(16, 216)
        Me.lstProfiles.MultiLine = True
        Me.lstProfiles.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.lstProfiles.WordWrap = False
        Me.lstProfiles.TabIndex = 4
        Me.lstProfiles.Text = "Start" & Chr(13) & Chr(10)
        Me.lstProfiles.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstProfiles.AcceptsReturn = True
        Me.lstProfiles.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.lstProfiles.BackColor = System.Drawing.SystemColors.Window
        Me.lstProfiles.CausesValidation = True
        Me.lstProfiles.Enabled = True
        Me.lstProfiles.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstProfiles.HideSelection = True
        Me.lstProfiles.ReadOnly = False
        Me.lstProfiles.Maxlength = 0
        Me.lstProfiles.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.lstProfiles.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstProfiles.TabStop = True
        Me.lstProfiles.Visible = True
        Me.lstProfiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lstProfiles.Name = "lstProfiles"
        Me.lstAliases.AutoSize = False
        Me.lstAliases.Size = New System.Drawing.Size(633, 121)
        Me.lstAliases.Location = New System.Drawing.Point(16, 392)
        Me.lstAliases.MultiLine = True
        Me.lstAliases.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.lstAliases.WordWrap = False
        Me.lstAliases.TabIndex = 3
        Me.lstAliases.Text = "Start" & Chr(13) & Chr(10)
        Me.lstAliases.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstAliases.AcceptsReturn = True
        Me.lstAliases.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.lstAliases.BackColor = System.Drawing.SystemColors.Window
        Me.lstAliases.CausesValidation = True
        Me.lstAliases.Enabled = True
        Me.lstAliases.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstAliases.HideSelection = True
        Me.lstAliases.ReadOnly = False
        Me.lstAliases.Maxlength = 0
        Me.lstAliases.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.lstAliases.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstAliases.TabStop = True
        Me.lstAliases.Visible = True
        Me.lstAliases.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lstAliases.Name = "lstAliases"
        Me.Frame1.Text = "Groups:"
        Me.Frame1.Size = New System.Drawing.Size(649, 161)
        Me.Frame1.Location = New System.Drawing.Point(8, 16)
        Me.Frame1.TabIndex = 1
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Enabled = True
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Visible = True
        Me.Frame1.Name = "Frame1"
        Me.lstGroups.AutoSize = False
        Me.lstGroups.Size = New System.Drawing.Size(633, 121)
        Me.lstGroups.Location = New System.Drawing.Point(8, 24)
        Me.lstGroups.MultiLine = True
        Me.lstGroups.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.lstGroups.WordWrap = False
        Me.lstGroups.TabIndex = 2
        Me.lstGroups.Text = "Start" & Chr(13) & Chr(10)
        Me.lstGroups.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstGroups.AcceptsReturn = True
        Me.lstGroups.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.lstGroups.BackColor = System.Drawing.SystemColors.Window
        Me.lstGroups.CausesValidation = True
        Me.lstGroups.Enabled = True
        Me.lstGroups.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstGroups.HideSelection = True
        Me.lstGroups.ReadOnly = False
        Me.lstGroups.Maxlength = 0
        Me.lstGroups.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.lstGroups.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstGroups.TabStop = True
        Me.lstGroups.Visible = True
        Me.lstGroups.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lstGroups.Name = "lstGroups"
        Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.cmdClose.Text = "Accept Edits"
        Me.cmdClose.Size = New System.Drawing.Size(81, 25)
        Me.cmdClose.Location = New System.Drawing.Point(293, 560)
        Me.cmdClose.TabIndex = 0
        Me.cmdClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClose.CausesValidation = True
        Me.cmdClose.Enabled = True
        Me.cmdClose.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdClose.TabStop = True
        Me.cmdClose.Name = "cmdClose"
        Me.Frame2.Text = "Profiles:"
        Me.Frame2.Size = New System.Drawing.Size(649, 161)
        Me.Frame2.Location = New System.Drawing.Point(8, 192)
        Me.Frame2.TabIndex = 5
        Me.Frame2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame2.BackColor = System.Drawing.SystemColors.Control
        Me.Frame2.Enabled = True
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Visible = True
        Me.Frame2.Name = "Frame2"
        Me.Frame3.Text = "Aliases"
        Me.Frame3.Size = New System.Drawing.Size(649, 161)
        Me.Frame3.Location = New System.Drawing.Point(8, 368)
        Me.Frame3.TabIndex = 6
        Me.Frame3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame3.BackColor = System.Drawing.SystemColors.Control
        Me.Frame3.Enabled = True
        Me.Frame3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame3.Visible = True
        Me.Frame3.Name = "Frame3"
        Me.Controls.Add(lstProfiles)
        Me.Controls.Add(lstAliases)
        Me.Controls.Add(Frame1)
        Me.Controls.Add(cmdClose)
        Me.Controls.Add(Frame2)
        Me.Controls.Add(Frame3)
        Me.Frame1.Controls.Add(lstGroups)
    End Sub
#End Region
#Region "Upgrade Support "
    Private Shared m_vb6FormDefInstance As dlgFinancialAdvisor
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As dlgFinancialAdvisor
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New dlgFinancialAdvisor
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(ByVal Value As dlgFinancialAdvisor)
            m_vb6FormDefInstance = Value
        End Set
    End Property
#End Region

    Private m_utils As Utils
    Private m_ok As Boolean
    Public aliasesXML, groupsXML, profilesXML, CRSTR As Object
    Public CRLFSTR As String
    ' ========================================================
    ' Button Events
    ' ========================================================
    Private Sub cmdClose_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdClose.Click
        ' clear any existing list details
        m_ok = True
        Hide()
    End Sub

    ' ========================================================
    ' Public methods
    ' ========================================================

    Public Sub init(ByVal utilities As Utils, ByVal faGroupXML As String, ByVal faProfilesXML As String, ByVal faAliasesXML As String)
        m_utils = utilities
        CRSTR = Chr(10)
        CRLFSTR = Chr(13) & Chr(10)
        lstGroups.Text = Replace(faGroupXML, CRSTR, CRLFSTR)
        lstProfiles.Text = Replace(faProfilesXML, CRSTR, CRLFSTR)
        lstAliases.Text = Replace(faAliasesXML, CRSTR, CRLFSTR)
        m_ok = False
    End Sub
    Public Function ok() As Object
        groupsXML = Replace(lstGroups.Text, CRLFSTR, CRSTR)
        profilesXML = Replace(lstProfiles.Text, CRLFSTR, CRSTR)
        aliasesXML = Replace(lstAliases.Text, CRLFSTR, CRSTR)
        ok = m_ok
    End Function
End Class