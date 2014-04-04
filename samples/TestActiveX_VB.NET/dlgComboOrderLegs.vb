' Copyright (C) 2013 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
' and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable.

Option Strict Off
Option Explicit On

Imports System.Collections.Generic

Friend Class dlgComboOrderLegs
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
    Public WithEvents cmdOk As System.Windows.Forms.Button
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    Public WithEvents cmdRemoveLeg As System.Windows.Forms.Button
    Public WithEvents cmdAddLeg As System.Windows.Forms.Button
    Public WithEvents txtOpenClose As System.Windows.Forms.TextBox
    Public WithEvents txtExchange As System.Windows.Forms.TextBox
    Public WithEvents txtAction As System.Windows.Forms.TextBox
    Public WithEvents txtRatio As System.Windows.Forms.TextBox
    Public WithEvents txtConid As System.Windows.Forms.TextBox
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents frmLegDetails As System.Windows.Forms.GroupBox
    'Public WithEvents grdComboLegs As AxMSFlexGridLib.AxMSFlexGrid
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents txtDesignatedLocation As System.Windows.Forms.TextBox
    Public WithEvents txtShortSaleSlot As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtExemptCode As System.Windows.Forms.TextBox
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgComboOrderLegs))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdRemoveLeg = New System.Windows.Forms.Button
        Me.frmLegDetails = New System.Windows.Forms.GroupBox
        Me.txtPrice = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtExemptCode = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtDesignatedLocation = New System.Windows.Forms.TextBox
        Me.txtShortSaleSlot = New System.Windows.Forms.TextBox
        Me.cmdAddLeg = New System.Windows.Forms.Button
        Me.txtOpenClose = New System.Windows.Forms.TextBox
        Me.txtExchange = New System.Windows.Forms.TextBox
        Me.txtAction = New System.Windows.Forms.TextBox
        Me.txtRatio = New System.Windows.Forms.TextBox
        Me.txtConid = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Frame1 = New System.Windows.Forms.GroupBox
        'Me.grdComboLegs = New AxMSFlexGridLib.AxMSFlexGrid
        Me.frmLegDetails.SuspendLayout()
        Me.Frame1.SuspendLayout()
        'CType(Me.grdComboLegs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        Me.cmdOk.BackColor = System.Drawing.SystemColors.Control
        Me.cmdOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOk.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOk.Location = New System.Drawing.Point(558, 306)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdOk.Size = New System.Drawing.Size(73, 25)
        Me.cmdOk.TabIndex = 2
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCancel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(637, 307)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCancel.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdRemoveLeg
        '
        Me.cmdRemoveLeg.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRemoveLeg.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRemoveLeg.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRemoveLeg.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRemoveLeg.Location = New System.Drawing.Point(215, 259)
        Me.cmdRemoveLeg.Name = "cmdRemoveLeg"
        Me.cmdRemoveLeg.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRemoveLeg.Size = New System.Drawing.Size(65, 25)
        Me.cmdRemoveLeg.TabIndex = 1
        Me.cmdRemoveLeg.Text = "Remove"
        Me.cmdRemoveLeg.UseVisualStyleBackColor = False
        '
        'frmLegDetails
        '
        Me.frmLegDetails.BackColor = System.Drawing.SystemColors.Control
        Me.frmLegDetails.Controls.Add(Me.txtPrice)
        Me.frmLegDetails.Controls.Add(Me.Label9)
        Me.frmLegDetails.Controls.Add(Me.Label8)
        Me.frmLegDetails.Controls.Add(Me.txtExemptCode)
        Me.frmLegDetails.Controls.Add(Me.Label7)
        Me.frmLegDetails.Controls.Add(Me.Label6)
        Me.frmLegDetails.Controls.Add(Me.txtDesignatedLocation)
        Me.frmLegDetails.Controls.Add(Me.txtShortSaleSlot)
        Me.frmLegDetails.Controls.Add(Me.cmdAddLeg)
        Me.frmLegDetails.Controls.Add(Me.txtOpenClose)
        Me.frmLegDetails.Controls.Add(Me.txtExchange)
        Me.frmLegDetails.Controls.Add(Me.txtAction)
        Me.frmLegDetails.Controls.Add(Me.txtRatio)
        Me.frmLegDetails.Controls.Add(Me.txtConid)
        Me.frmLegDetails.Controls.Add(Me.Label5)
        Me.frmLegDetails.Controls.Add(Me.Label4)
        Me.frmLegDetails.Controls.Add(Me.Label3)
        Me.frmLegDetails.Controls.Add(Me.Label2)
        Me.frmLegDetails.Controls.Add(Me.Label1)
        Me.frmLegDetails.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frmLegDetails.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frmLegDetails.Location = New System.Drawing.Point(514, 8)
        Me.frmLegDetails.Name = "frmLegDetails"
        Me.frmLegDetails.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frmLegDetails.Size = New System.Drawing.Size(196, 290)
        Me.frmLegDetails.TabIndex = 1
        Me.frmLegDetails.TabStop = False
        Me.frmLegDetails.Text = "Leg Details"
        '
        'txtPrice
        '
        Me.txtPrice.AcceptsReturn = True
        Me.txtPrice.BackColor = System.Drawing.SystemColors.Window
        Me.txtPrice.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPrice.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtPrice.Location = New System.Drawing.Point(97, 229)
        Me.txtPrice.MaxLength = 0
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPrice.Size = New System.Drawing.Size(93, 20)
        Me.txtPrice.TabIndex = 17
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 233)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 14)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Price"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 205)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 14)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Exempt Code"
        '
        'txtExemptCode
        '
        Me.txtExemptCode.AcceptsReturn = True
        Me.txtExemptCode.BackColor = System.Drawing.SystemColors.Window
        Me.txtExemptCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtExemptCode.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExemptCode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtExemptCode.Location = New System.Drawing.Point(97, 202)
        Me.txtExemptCode.MaxLength = 0
        Me.txtExemptCode.Name = "txtExemptCode"
        Me.txtExemptCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtExemptCode.Size = New System.Drawing.Size(93, 20)
        Me.txtExemptCode.TabIndex = 15
        Me.txtExemptCode.Text = "-1"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(6, 178)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(85, 17)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Location"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(6, 152)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(85, 17)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Short Sale Slot"
        '
        'txtDesignatedLocation
        '
        Me.txtDesignatedLocation.AcceptsReturn = True
        Me.txtDesignatedLocation.BackColor = System.Drawing.SystemColors.Window
        Me.txtDesignatedLocation.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDesignatedLocation.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesignatedLocation.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDesignatedLocation.Location = New System.Drawing.Point(97, 175)
        Me.txtDesignatedLocation.MaxLength = 0
        Me.txtDesignatedLocation.Name = "txtDesignatedLocation"
        Me.txtDesignatedLocation.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDesignatedLocation.Size = New System.Drawing.Size(93, 20)
        Me.txtDesignatedLocation.TabIndex = 13
        '
        'txtShortSaleSlot
        '
        Me.txtShortSaleSlot.AcceptsReturn = True
        Me.txtShortSaleSlot.BackColor = System.Drawing.SystemColors.Window
        Me.txtShortSaleSlot.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtShortSaleSlot.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShortSaleSlot.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtShortSaleSlot.Location = New System.Drawing.Point(97, 149)
        Me.txtShortSaleSlot.MaxLength = 0
        Me.txtShortSaleSlot.Name = "txtShortSaleSlot"
        Me.txtShortSaleSlot.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtShortSaleSlot.Size = New System.Drawing.Size(93, 20)
        Me.txtShortSaleSlot.TabIndex = 11
        Me.txtShortSaleSlot.Text = "0"
        '
        'cmdAddLeg
        '
        Me.cmdAddLeg.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAddLeg.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAddLeg.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddLeg.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAddLeg.Location = New System.Drawing.Point(64, 259)
        Me.cmdAddLeg.Name = "cmdAddLeg"
        Me.cmdAddLeg.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAddLeg.Size = New System.Drawing.Size(65, 25)
        Me.cmdAddLeg.TabIndex = 18
        Me.cmdAddLeg.Text = "Add"
        Me.cmdAddLeg.UseVisualStyleBackColor = False
        '
        'txtOpenClose
        '
        Me.txtOpenClose.AcceptsReturn = True
        Me.txtOpenClose.BackColor = System.Drawing.SystemColors.Window
        Me.txtOpenClose.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOpenClose.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOpenClose.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOpenClose.Location = New System.Drawing.Point(97, 124)
        Me.txtOpenClose.MaxLength = 0
        Me.txtOpenClose.Name = "txtOpenClose"
        Me.txtOpenClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtOpenClose.Size = New System.Drawing.Size(93, 20)
        Me.txtOpenClose.TabIndex = 9
        Me.txtOpenClose.Text = "0"
        '
        'txtExchange
        '
        Me.txtExchange.AcceptsReturn = True
        Me.txtExchange.BackColor = System.Drawing.SystemColors.Window
        Me.txtExchange.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtExchange.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExchange.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtExchange.Location = New System.Drawing.Point(97, 99)
        Me.txtExchange.MaxLength = 0
        Me.txtExchange.Name = "txtExchange"
        Me.txtExchange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtExchange.Size = New System.Drawing.Size(93, 20)
        Me.txtExchange.TabIndex = 7
        Me.txtExchange.Text = "SMART"
        '
        'txtAction
        '
        Me.txtAction.AcceptsReturn = True
        Me.txtAction.BackColor = System.Drawing.SystemColors.Window
        Me.txtAction.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAction.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAction.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtAction.Location = New System.Drawing.Point(97, 74)
        Me.txtAction.MaxLength = 0
        Me.txtAction.Name = "txtAction"
        Me.txtAction.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtAction.Size = New System.Drawing.Size(93, 20)
        Me.txtAction.TabIndex = 5
        Me.txtAction.Text = "BUY"
        '
        'txtRatio
        '
        Me.txtRatio.AcceptsReturn = True
        Me.txtRatio.BackColor = System.Drawing.SystemColors.Window
        Me.txtRatio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRatio.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRatio.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtRatio.Location = New System.Drawing.Point(97, 49)
        Me.txtRatio.MaxLength = 0
        Me.txtRatio.Name = "txtRatio"
        Me.txtRatio.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRatio.Size = New System.Drawing.Size(93, 20)
        Me.txtRatio.TabIndex = 3
        Me.txtRatio.Text = "1"
        '
        'txtConid
        '
        Me.txtConid.AcceptsReturn = True
        Me.txtConid.BackColor = System.Drawing.SystemColors.Window
        Me.txtConid.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtConid.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConid.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtConid.Location = New System.Drawing.Point(97, 24)
        Me.txtConid.MaxLength = 0
        Me.txtConid.Name = "txtConid"
        Me.txtConid.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtConid.Size = New System.Drawing.Size(93, 20)
        Me.txtConid.TabIndex = 1
        Me.txtConid.Text = "0"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(6, 127)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(85, 17)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Open/Close"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(6, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(85, 17)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Exchange"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(6, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(85, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Side"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(6, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(85, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Ratio"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(6, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(85, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Conid"
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        ' Me.Frame1.Controls.Add(Me.grdComboLegs)
        Me.Frame1.Controls.Add(Me.cmdRemoveLeg)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(8, 8)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(500, 290)
        Me.Frame1.TabIndex = 0
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Combo Legs"
        '
        'grdComboLegs
        '
        'Me.grdComboLegs.Location = New System.Drawing.Point(8, 24)
        'Me.grdComboLegs.Name = "grdComboLegs"
        'Me.grdComboLegs.OcxState = CType(resources.GetObject("grdComboLegs.OcxState"), System.Windows.Forms.AxHost.State)
        'Me.grdComboLegs.Size = New System.Drawing.Size(486, 198)
        'Me.grdComboLegs.TabIndex = 0
        '
        'dlgComboOrderLegs
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(722, 344)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.frmLegDetails)
        Me.Controls.Add(Me.Frame1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(184, 250)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgComboOrderLegs"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Combination Order Legs"
        Me.frmLegDetails.ResumeLayout(False)
        Me.frmLegDetails.PerformLayout()
        Me.Frame1.ResumeLayout(False)
        'CType(Me.grdComboLegs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region
#Region "Upgrade Support "
    Private Shared m_vb6FormDefInstance As dlgComboOrderLegs
    Private Shared m_InitializingDefInstance As Boolean
    Public Shared Property DefInstance() As dlgComboOrderLegs
        Get
            If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
                m_InitializingDefInstance = True
                m_vb6FormDefInstance = New dlgComboOrderLegs()
                m_InitializingDefInstance = False
            End If
            DefInstance = m_vb6FormDefInstance
        End Get
        Set(value As dlgComboOrderLegs)
            m_vb6FormDefInstance = value
        End Set
    End Property
#End Region

    Private m_comboLegs As List(Of IBApi.ComboLeg)
    Private m_orderComboLegs As List(Of IBApi.OrderComboLeg)
    Private m_tws As Tws

    Private m_ok As Boolean

    ' ===============================================================================
    ' Get/Set Properties
    ' ===============================================================================
    Public ReadOnly Property ok() As Boolean
        Get
            ok = m_ok
        End Get
    End Property

    Public ReadOnly Property comboLegs() As List(Of IBApi.ComboLeg)
        Get
            comboLegs = m_comboLegs
        End Get
    End Property

    Public ReadOnly Property orderComboLegs() As List(Of IBApi.OrderComboLeg)
        Get
            orderComboLegs = m_orderComboLegs
        End Get
    End Property

    ' ===============================================================================
    ' Public Methods
    ' ===============================================================================
    Public Sub Init(ByVal comboLegs As List(Of IBApi.ComboLeg), ByVal orderComboLegs As List(Of IBApi.OrderComboLeg), ByVal tws As Tws)

        m_tws = tws

        If (Not comboLegs Is Nothing) And (Not orderComboLegs Is Nothing) Then

            Dim Count As Long
            Dim iLoop As Long
            Dim insertPos As Long

            Count = comboLegs.Count

            For iLoop = 0 To Count - 1 Step 1

                'insertPos = grdComboLegs.Rows

                Dim cmbLeg As IBApi.ComboLeg
                cmbLeg = comboLegs.Item(iLoop)
                Dim orderCmbLeg As IBApi.OrderComboLeg
                orderCmbLeg = orderComboLegs.Item(iLoop)

                Dim row As String

                With cmbLeg
                    row = .conId & vbTab & .ratio & vbTab & .action & vbTab _
                        & .exchange & vbTab & .openClose & vbTab _
                        & .shortSaleSlot & vbTab & .designatedLocation & vbTab & .exemptCode
                End With

                With orderCmbLeg
                    If .price = Double.MaxValue Then
                        row = row & vbTab
                    Else
                        row = row & vbTab & .price
                    End If
                End With

                'grdComboLegs.AddItem(row, insertPos)

            Next
        End If
    End Sub

    ' ===============================================================================
    ' Form Events
    ' ===============================================================================
    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click

        Dim iLoop As Long
        Dim Count As Long

        'Count = grdComboLegs.Rows

        'If (Count > 1) Then

        '    m_comboLegs = New List(Of IBApi.ComboLeg)
        '    m_orderComboLegs = New List(Of IBApi.OrderComboLeg)

        '    For iLoop = 1 To Count - 1 Step 1

        '        Dim cmbLeg As IBApi.ComboLeg = New IBApi.ComboLeg
        '        m_comboLegs.Add(cmbLeg)
        '        Dim orderCmbLeg As IBApi.OrderComboLeg = New IBApi.OrderComboLeg
        '        m_orderComboLegs.Add(orderCmbLeg)

        '        grdComboLegs.Row = iLoop

        '        grdComboLegs.Col = 0
        '        cmbLeg.conId = CInt(grdComboLegs.Text)

        '        grdComboLegs.Col = 1
        '        cmbLeg.ratio = CInt(grdComboLegs.Text)

        '        grdComboLegs.Col = 2
        '        cmbLeg.action = grdComboLegs.Text

        '        grdComboLegs.Col = 3
        '        cmbLeg.exchange = grdComboLegs.Text

        '        grdComboLegs.Col = 4
        '        cmbLeg.openClose = CShort(grdComboLegs.Text)

        '        grdComboLegs.Col = 5
        '        cmbLeg.shortSaleSlot = CInt(grdComboLegs.Text)

        '        grdComboLegs.Col = 6
        '        cmbLeg.designatedLocation = grdComboLegs.Text

        '        grdComboLegs.Col = 7
        '        If Not String.IsNullOrEmpty(grdComboLegs.Text) Then
        '            cmbLeg.exemptCode = CInt(grdComboLegs.Text)
        '        Else
        '            cmbLeg.exemptCode = CInt("-1")
        '        End If

        '        grdComboLegs.Col = 8
        '        If Len(grdComboLegs.Text) = 0 Then
        '            orderCmbLeg.price = Double.MaxValue
        '        Else
        '            orderCmbLeg.price = CDbl(grdComboLegs.Text)
        '        End If
        '    Next

        'End If

        m_ok = True
        Hide()

    End Sub

    '--------------------------------------------------------------------------------
    ' Cancel
    '--------------------------------------------------------------------------------
    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click

        m_ok = False
        Hide()
    End Sub

    '--------------------------------------------------------------------------------
    ' Adds a combo leg to the list
    '--------------------------------------------------------------------------------
    Private Sub cmdAddLeg_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAddLeg.Click
        Dim insertPos As Short
        Dim row As String
        'insertPos = grdComboLegs.Rows
        row = txtConid.Text & vbTab & txtRatio.Text & vbTab & txtAction.Text & vbTab & txtExchange.Text & vbTab & txtOpenClose.Text & vbTab & txtShortSaleSlot.Text & vbTab & txtDesignatedLocation.Text & vbTab & txtExemptCode.Text & vbTab & txtPrice.Text

        'grdComboLegs.AddItem(row, insertPos)
    End Sub

    '--------------------------------------------------------------------------------
    ' Removes a combo leg from the list
    '--------------------------------------------------------------------------------
    Private Sub cmdRemoveLeg_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRemoveLeg.Click
        Dim selRowEnd, selRowStart, temp As Object
        Dim iLoop As Short

        ' get the current rows selection if any
        'selRowStart = grdComboLegs.Row
        'selRowEnd = grdComboLegs.RowSel
        If selRowStart > selRowEnd Then
            temp = selRowStart
            selRowStart = selRowEnd
            selRowEnd = temp
        End If

        For iLoop = selRowEnd To selRowStart Step -1
            If Not iLoop = 0 Then
                'grdComboLegs.RemoveItem(iLoop)
            End If
        Next iLoop

    End Sub

    '--------------------------------------------------------------------------------
    ' Call when the form is first loaded and the combo leg header row is added
    '--------------------------------------------------------------------------------
    Private Sub dlgComboOrderLegs_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Dim title As String
        title = "Combination Order Legs"
        'Call grdComboLegs.AddItem("ConId" & vbTab & "Ratio" & vbTab & "Side" & vbTab & "Exchange" & vbTab & "Open/Close" & vbTab & "Short Sale Slot" & vbTab & "Location" & vbTab & "Exempt Code" & vbTab & "Price", 0)
    End Sub
End Class