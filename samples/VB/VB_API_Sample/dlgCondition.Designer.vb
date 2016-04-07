<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgCondition
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tabControl1 = New System.Windows.Forms.TabControl()
        Me.conditionTypePage = New System.Windows.Forms.TabPage()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.percentRb = New System.Windows.Forms.RadioButton()
        Me.volumeRb = New System.Windows.Forms.RadioButton()
        Me.timeRb = New System.Windows.Forms.RadioButton()
        Me.tradeRb = New System.Windows.Forms.RadioButton()
        Me.marginRb = New System.Windows.Forms.RadioButton()
        Me.priceRb = New System.Windows.Forms.RadioButton()
        Me.conditionPage = New System.Windows.Forms.TabPage()
        Me.conditionPanel = New System.Windows.Forms.Panel()
        Me.back = New System.Windows.Forms.Button()
        Me.apply = New System.Windows.Forms.Button()
        Me.tabPage1 = New System.Windows.Forms.TabPage()
        Me.pricePanel = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.priceConExch = New System.Windows.Forms.TextBox()
        Me.priceConId = New System.Windows.Forms.TextBox()
        Me.priceMethod = New System.Windows.Forms.ComboBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.priceOperator = New System.Windows.Forms.ComboBox()
        Me.price = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.tabPage2 = New System.Windows.Forms.TabPage()
        Me.marginPanel = New System.Windows.Forms.Panel()
        Me.marginOperator = New System.Windows.Forms.ComboBox()
        Me.marginCushion = New System.Windows.Forms.TextBox()
        Me.label5 = New System.Windows.Forms.Label()
        Me.label6 = New System.Windows.Forms.Label()
        Me.tabPage3 = New System.Windows.Forms.TabPage()
        Me.tradePanel = New System.Windows.Forms.Panel()
        Me.label9 = New System.Windows.Forms.Label()
        Me.label8 = New System.Windows.Forms.Label()
        Me.label7 = New System.Windows.Forms.Label()
        Me.tradeType = New System.Windows.Forms.TextBox()
        Me.tradeExchange = New System.Windows.Forms.TextBox()
        Me.tradeUnderlying = New System.Windows.Forms.TextBox()
        Me.tabPage4 = New System.Windows.Forms.TabPage()
        Me.timePanel = New System.Windows.Forms.Panel()
        Me.label11 = New System.Windows.Forms.Label()
        Me.label10 = New System.Windows.Forms.Label()
        Me.time = New System.Windows.Forms.TextBox()
        Me.timeOperator = New System.Windows.Forms.ComboBox()
        Me.tabPage5 = New System.Windows.Forms.TabPage()
        Me.volumePanel = New System.Windows.Forms.Panel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.volumeConExch = New System.Windows.Forms.TextBox()
        Me.volumeConId = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.volume = New System.Windows.Forms.TextBox()
        Me.volumeOperator = New System.Windows.Forms.ComboBox()
        Me.label17 = New System.Windows.Forms.Label()
        Me.label16 = New System.Windows.Forms.Label()
        Me.tabPage6 = New System.Windows.Forms.TabPage()
        Me.percentPanel = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.percentConExch = New System.Windows.Forms.TextBox()
        Me.percentConId = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.percent = New System.Windows.Forms.TextBox()
        Me.percentOperator = New System.Windows.Forms.ComboBox()
        Me.label13 = New System.Windows.Forms.Label()
        Me.label12 = New System.Windows.Forms.Label()
        Me.tabControl1.SuspendLayout()
        Me.conditionTypePage.SuspendLayout()
        Me.conditionPage.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        Me.pricePanel.SuspendLayout()
        Me.tabPage2.SuspendLayout()
        Me.marginPanel.SuspendLayout()
        Me.tabPage3.SuspendLayout()
        Me.tradePanel.SuspendLayout()
        Me.tabPage4.SuspendLayout()
        Me.timePanel.SuspendLayout()
        Me.tabPage5.SuspendLayout()
        Me.volumePanel.SuspendLayout()
        Me.tabPage6.SuspendLayout()
        Me.percentPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabControl1
        '
        Me.tabControl1.Controls.Add(Me.conditionTypePage)
        Me.tabControl1.Controls.Add(Me.conditionPage)
        Me.tabControl1.Controls.Add(Me.tabPage1)
        Me.tabControl1.Controls.Add(Me.tabPage2)
        Me.tabControl1.Controls.Add(Me.tabPage3)
        Me.tabControl1.Controls.Add(Me.tabPage4)
        Me.tabControl1.Controls.Add(Me.tabPage5)
        Me.tabControl1.Controls.Add(Me.tabPage6)
        Me.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabControl1.Location = New System.Drawing.Point(0, 0)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(309, 216)
        Me.tabControl1.TabIndex = 1
        '
        'conditionTypePage
        '
        Me.conditionTypePage.Controls.Add(Me.btnNext)
        Me.conditionTypePage.Controls.Add(Me.percentRb)
        Me.conditionTypePage.Controls.Add(Me.volumeRb)
        Me.conditionTypePage.Controls.Add(Me.timeRb)
        Me.conditionTypePage.Controls.Add(Me.tradeRb)
        Me.conditionTypePage.Controls.Add(Me.marginRb)
        Me.conditionTypePage.Controls.Add(Me.priceRb)
        Me.conditionTypePage.Location = New System.Drawing.Point(4, 22)
        Me.conditionTypePage.Name = "conditionTypePage"
        Me.conditionTypePage.Padding = New System.Windows.Forms.Padding(3)
        Me.conditionTypePage.Size = New System.Drawing.Size(301, 190)
        Me.conditionTypePage.TabIndex = 0
        Me.conditionTypePage.Text = "Condition type"
        Me.conditionTypePage.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(218, 159)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(75, 23)
        Me.btnNext.TabIndex = 2
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'percentRb
        '
        Me.percentRb.AutoSize = True
        Me.percentRb.Location = New System.Drawing.Point(183, 52)
        Me.percentRb.Name = "percentRb"
        Me.percentRb.Size = New System.Drawing.Size(102, 17)
        Me.percentRb.TabIndex = 6
        Me.percentRb.Text = "Percent Change"
        Me.percentRb.UseVisualStyleBackColor = True
        '
        'volumeRb
        '
        Me.volumeRb.AutoSize = True
        Me.volumeRb.Location = New System.Drawing.Point(183, 29)
        Me.volumeRb.Name = "volumeRb"
        Me.volumeRb.Size = New System.Drawing.Size(60, 17)
        Me.volumeRb.TabIndex = 5
        Me.volumeRb.Text = "Volume"
        Me.volumeRb.UseVisualStyleBackColor = True
        '
        'timeRb
        '
        Me.timeRb.AutoSize = True
        Me.timeRb.Location = New System.Drawing.Point(183, 6)
        Me.timeRb.Name = "timeRb"
        Me.timeRb.Size = New System.Drawing.Size(48, 17)
        Me.timeRb.TabIndex = 4
        Me.timeRb.Text = "Time"
        Me.timeRb.UseVisualStyleBackColor = True
        '
        'tradeRb
        '
        Me.tradeRb.AutoSize = True
        Me.tradeRb.Location = New System.Drawing.Point(8, 52)
        Me.tradeRb.Name = "tradeRb"
        Me.tradeRb.Size = New System.Drawing.Size(53, 17)
        Me.tradeRb.TabIndex = 3
        Me.tradeRb.Text = "Trade"
        Me.tradeRb.UseVisualStyleBackColor = True
        '
        'marginRb
        '
        Me.marginRb.AutoSize = True
        Me.marginRb.Location = New System.Drawing.Point(8, 29)
        Me.marginRb.Name = "marginRb"
        Me.marginRb.Size = New System.Drawing.Size(98, 17)
        Me.marginRb.TabIndex = 2
        Me.marginRb.Text = "Margin Cushion"
        Me.marginRb.UseVisualStyleBackColor = True
        '
        'priceRb
        '
        Me.priceRb.AutoSize = True
        Me.priceRb.Checked = True
        Me.priceRb.Location = New System.Drawing.Point(8, 6)
        Me.priceRb.Name = "priceRb"
        Me.priceRb.Size = New System.Drawing.Size(49, 17)
        Me.priceRb.TabIndex = 1
        Me.priceRb.TabStop = True
        Me.priceRb.Text = "Price"
        Me.priceRb.UseVisualStyleBackColor = True
        '
        'conditionPage
        '
        Me.conditionPage.Controls.Add(Me.conditionPanel)
        Me.conditionPage.Controls.Add(Me.back)
        Me.conditionPage.Controls.Add(Me.apply)
        Me.conditionPage.Location = New System.Drawing.Point(4, 22)
        Me.conditionPage.Name = "conditionPage"
        Me.conditionPage.Padding = New System.Windows.Forms.Padding(3)
        Me.conditionPage.Size = New System.Drawing.Size(301, 190)
        Me.conditionPage.TabIndex = 1
        Me.conditionPage.Text = "Condition"
        Me.conditionPage.UseVisualStyleBackColor = True
        '
        'conditionPanel
        '
        Me.conditionPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.conditionPanel.Location = New System.Drawing.Point(3, 3)
        Me.conditionPanel.Name = "conditionPanel"
        Me.conditionPanel.Size = New System.Drawing.Size(295, 150)
        Me.conditionPanel.TabIndex = 3
        '
        'back
        '
        Me.back.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.back.Location = New System.Drawing.Point(137, 159)
        Me.back.Name = "back"
        Me.back.Size = New System.Drawing.Size(75, 23)
        Me.back.TabIndex = 1
        Me.back.Text = "Back"
        Me.back.UseVisualStyleBackColor = True
        '
        'apply
        '
        Me.apply.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.apply.Location = New System.Drawing.Point(218, 159)
        Me.apply.Name = "apply"
        Me.apply.Size = New System.Drawing.Size(75, 23)
        Me.apply.TabIndex = 2
        Me.apply.Text = "Apply"
        Me.apply.UseVisualStyleBackColor = True
        '
        'tabPage1
        '
        Me.tabPage1.Controls.Add(Me.pricePanel)
        Me.tabPage1.Location = New System.Drawing.Point(4, 22)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Size = New System.Drawing.Size(301, 190)
        Me.tabPage1.TabIndex = 2
        Me.tabPage1.Text = "Price"
        Me.tabPage1.UseVisualStyleBackColor = True
        '
        'pricePanel
        '
        Me.pricePanel.Controls.Add(Me.Label15)
        Me.pricePanel.Controls.Add(Me.priceConExch)
        Me.pricePanel.Controls.Add(Me.priceConId)
        Me.pricePanel.Controls.Add(Me.priceMethod)
        Me.pricePanel.Controls.Add(Me.label4)
        Me.pricePanel.Controls.Add(Me.label3)
        Me.pricePanel.Controls.Add(Me.label2)
        Me.pricePanel.Controls.Add(Me.priceOperator)
        Me.pricePanel.Controls.Add(Me.price)
        Me.pricePanel.Controls.Add(Me.label1)
        Me.pricePanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.pricePanel.Location = New System.Drawing.Point(0, 0)
        Me.pricePanel.Name = "pricePanel"
        Me.pricePanel.Size = New System.Drawing.Size(301, 140)
        Me.pricePanel.TabIndex = 0
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(8, 35)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(107, 13)
        Me.Label15.TabIndex = 21
        Me.Label15.Text = "Underlying exchange"
        '
        'priceConExch
        '
        Me.priceConExch.Location = New System.Drawing.Point(124, 32)
        Me.priceConExch.Name = "priceConExch"
        Me.priceConExch.Size = New System.Drawing.Size(156, 20)
        Me.priceConExch.TabIndex = 20
        '
        'priceConId
        '
        Me.priceConId.Location = New System.Drawing.Point(124, 6)
        Me.priceConId.Name = "priceConId"
        Me.priceConId.Size = New System.Drawing.Size(156, 20)
        Me.priceConId.TabIndex = 19
        '
        'priceMethod
        '
        Me.priceMethod.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.priceMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.priceMethod.FormattingEnabled = True
        Me.priceMethod.Location = New System.Drawing.Point(124, 60)
        Me.priceMethod.Name = "priceMethod"
        Me.priceMethod.Size = New System.Drawing.Size(156, 21)
        Me.priceMethod.TabIndex = 18
        '
        'label4
        '
        Me.label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(8, 116)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(31, 13)
        Me.label4.TabIndex = 16
        Me.label4.Text = "Price"
        '
        'label3
        '
        Me.label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(8, 89)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(48, 13)
        Me.label3.TabIndex = 15
        Me.label3.Text = "Operator"
        '
        'label2
        '
        Me.label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(8, 63)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(43, 13)
        Me.label2.TabIndex = 1
        Me.label2.Text = "Method"
        '
        'priceOperator
        '
        Me.priceOperator.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.priceOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.priceOperator.FormattingEnabled = True
        Me.priceOperator.Items.AddRange(New Object() {"<=", ">="})
        Me.priceOperator.Location = New System.Drawing.Point(124, 86)
        Me.priceOperator.Name = "priceOperator"
        Me.priceOperator.Size = New System.Drawing.Size(156, 21)
        Me.priceOperator.TabIndex = 4
        '
        'price
        '
        Me.price.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.price.Location = New System.Drawing.Point(124, 113)
        Me.price.Name = "price"
        Me.price.Size = New System.Drawing.Size(156, 20)
        Me.price.TabIndex = 5
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(8, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(110, 13)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Underlying contract id"
        '
        'tabPage2
        '
        Me.tabPage2.Controls.Add(Me.marginPanel)
        Me.tabPage2.Location = New System.Drawing.Point(4, 22)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Size = New System.Drawing.Size(301, 190)
        Me.tabPage2.TabIndex = 3
        Me.tabPage2.Text = "Margin"
        Me.tabPage2.UseVisualStyleBackColor = True
        '
        'marginPanel
        '
        Me.marginPanel.Controls.Add(Me.marginOperator)
        Me.marginPanel.Controls.Add(Me.marginCushion)
        Me.marginPanel.Controls.Add(Me.label5)
        Me.marginPanel.Controls.Add(Me.label6)
        Me.marginPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.marginPanel.Location = New System.Drawing.Point(0, 0)
        Me.marginPanel.Name = "marginPanel"
        Me.marginPanel.Size = New System.Drawing.Size(301, 190)
        Me.marginPanel.TabIndex = 4
        '
        'marginOperator
        '
        Me.marginOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.marginOperator.FormattingEnabled = True
        Me.marginOperator.Items.AddRange(New Object() {"<=", ">="})
        Me.marginOperator.Location = New System.Drawing.Point(76, 26)
        Me.marginOperator.Name = "marginOperator"
        Me.marginOperator.Size = New System.Drawing.Size(208, 21)
        Me.marginOperator.TabIndex = 5
        '
        'marginCushion
        '
        Me.marginCushion.Location = New System.Drawing.Point(76, 53)
        Me.marginCushion.Name = "marginCushion"
        Me.marginCushion.Size = New System.Drawing.Size(209, 20)
        Me.marginCushion.TabIndex = 1
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(8, 30)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(48, 13)
        Me.label5.TabIndex = 2
        Me.label5.Text = "Operator"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(8, 56)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(62, 13)
        Me.label6.TabIndex = 3
        Me.label6.Text = "Cushion (%)"
        '
        'tabPage3
        '
        Me.tabPage3.Controls.Add(Me.tradePanel)
        Me.tabPage3.Location = New System.Drawing.Point(4, 22)
        Me.tabPage3.Name = "tabPage3"
        Me.tabPage3.Size = New System.Drawing.Size(301, 190)
        Me.tabPage3.TabIndex = 4
        Me.tabPage3.Text = "Trade"
        Me.tabPage3.UseVisualStyleBackColor = True
        '
        'tradePanel
        '
        Me.tradePanel.Controls.Add(Me.label9)
        Me.tradePanel.Controls.Add(Me.label8)
        Me.tradePanel.Controls.Add(Me.label7)
        Me.tradePanel.Controls.Add(Me.tradeType)
        Me.tradePanel.Controls.Add(Me.tradeExchange)
        Me.tradePanel.Controls.Add(Me.tradeUnderlying)
        Me.tradePanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.tradePanel.Location = New System.Drawing.Point(0, 0)
        Me.tradePanel.Name = "tradePanel"
        Me.tradePanel.Size = New System.Drawing.Size(301, 106)
        Me.tradePanel.TabIndex = 0
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(8, 70)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(31, 13)
        Me.label9.TabIndex = 5
        Me.label9.Text = "Type"
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(8, 44)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(55, 13)
        Me.label8.TabIndex = 4
        Me.label8.Text = "Exchange"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(8, 18)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(57, 13)
        Me.label7.TabIndex = 3
        Me.label7.Text = "Underlying"
        '
        'tradeType
        '
        Me.tradeType.Location = New System.Drawing.Point(71, 67)
        Me.tradeType.Name = "tradeType"
        Me.tradeType.Size = New System.Drawing.Size(214, 20)
        Me.tradeType.TabIndex = 2
        '
        'tradeExchange
        '
        Me.tradeExchange.Location = New System.Drawing.Point(71, 41)
        Me.tradeExchange.Name = "tradeExchange"
        Me.tradeExchange.Size = New System.Drawing.Size(214, 20)
        Me.tradeExchange.TabIndex = 1
        '
        'tradeUnderlying
        '
        Me.tradeUnderlying.Location = New System.Drawing.Point(71, 15)
        Me.tradeUnderlying.Name = "tradeUnderlying"
        Me.tradeUnderlying.Size = New System.Drawing.Size(214, 20)
        Me.tradeUnderlying.TabIndex = 0
        '
        'tabPage4
        '
        Me.tabPage4.Controls.Add(Me.timePanel)
        Me.tabPage4.Location = New System.Drawing.Point(4, 22)
        Me.tabPage4.Name = "tabPage4"
        Me.tabPage4.Size = New System.Drawing.Size(301, 190)
        Me.tabPage4.TabIndex = 5
        Me.tabPage4.Text = "Time"
        Me.tabPage4.UseVisualStyleBackColor = True
        '
        'timePanel
        '
        Me.timePanel.Controls.Add(Me.label11)
        Me.timePanel.Controls.Add(Me.label10)
        Me.timePanel.Controls.Add(Me.time)
        Me.timePanel.Controls.Add(Me.timeOperator)
        Me.timePanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.timePanel.Location = New System.Drawing.Point(0, 0)
        Me.timePanel.Name = "timePanel"
        Me.timePanel.Size = New System.Drawing.Size(301, 100)
        Me.timePanel.TabIndex = 10
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Location = New System.Drawing.Point(9, 55)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(30, 13)
        Me.label11.TabIndex = 8
        Me.label11.Text = "Time"
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Location = New System.Drawing.Point(9, 29)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(48, 13)
        Me.label10.TabIndex = 7
        Me.label10.Text = "Operator"
        '
        'time
        '
        Me.time.Location = New System.Drawing.Point(77, 52)
        Me.time.Name = "time"
        Me.time.Size = New System.Drawing.Size(209, 20)
        Me.time.TabIndex = 6
        '
        'timeOperator
        '
        Me.timeOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.timeOperator.FormattingEnabled = True
        Me.timeOperator.Items.AddRange(New Object() {"<=", ">="})
        Me.timeOperator.Location = New System.Drawing.Point(77, 25)
        Me.timeOperator.Name = "timeOperator"
        Me.timeOperator.Size = New System.Drawing.Size(208, 21)
        Me.timeOperator.TabIndex = 9
        '
        'tabPage5
        '
        Me.tabPage5.Controls.Add(Me.volumePanel)
        Me.tabPage5.Location = New System.Drawing.Point(4, 22)
        Me.tabPage5.Name = "tabPage5"
        Me.tabPage5.Size = New System.Drawing.Size(301, 190)
        Me.tabPage5.TabIndex = 6
        Me.tabPage5.Text = "Volume"
        Me.tabPage5.UseVisualStyleBackColor = True
        '
        'volumePanel
        '
        Me.volumePanel.Controls.Add(Me.Label18)
        Me.volumePanel.Controls.Add(Me.volumeConExch)
        Me.volumePanel.Controls.Add(Me.volumeConId)
        Me.volumePanel.Controls.Add(Me.Label19)
        Me.volumePanel.Controls.Add(Me.volume)
        Me.volumePanel.Controls.Add(Me.volumeOperator)
        Me.volumePanel.Controls.Add(Me.label17)
        Me.volumePanel.Controls.Add(Me.label16)
        Me.volumePanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.volumePanel.Location = New System.Drawing.Point(0, 0)
        Me.volumePanel.Name = "volumePanel"
        Me.volumePanel.Size = New System.Drawing.Size(301, 125)
        Me.volumePanel.TabIndex = 26
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(8, 32)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(107, 13)
        Me.Label18.TabIndex = 28
        Me.Label18.Text = "Underlying exchange"
        '
        'volumeConExch
        '
        Me.volumeConExch.Location = New System.Drawing.Point(126, 29)
        Me.volumeConExch.Name = "volumeConExch"
        Me.volumeConExch.Size = New System.Drawing.Size(156, 20)
        Me.volumeConExch.TabIndex = 27
        '
        'volumeConId
        '
        Me.volumeConId.Location = New System.Drawing.Point(126, 3)
        Me.volumeConId.Name = "volumeConId"
        Me.volumeConId.Size = New System.Drawing.Size(156, 20)
        Me.volumeConId.TabIndex = 26
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(8, 6)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(110, 13)
        Me.Label19.TabIndex = 25
        Me.Label19.Text = "Underlying contract id"
        '
        'volume
        '
        Me.volume.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.volume.Location = New System.Drawing.Point(126, 82)
        Me.volume.Name = "volume"
        Me.volume.Size = New System.Drawing.Size(156, 20)
        Me.volume.TabIndex = 22
        '
        'volumeOperator
        '
        Me.volumeOperator.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.volumeOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.volumeOperator.FormattingEnabled = True
        Me.volumeOperator.Items.AddRange(New Object() {"<=", ">="})
        Me.volumeOperator.Location = New System.Drawing.Point(126, 55)
        Me.volumeOperator.Name = "volumeOperator"
        Me.volumeOperator.Size = New System.Drawing.Size(156, 21)
        Me.volumeOperator.TabIndex = 21
        '
        'label17
        '
        Me.label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label17.AutoSize = True
        Me.label17.Location = New System.Drawing.Point(8, 58)
        Me.label17.Name = "label17"
        Me.label17.Size = New System.Drawing.Size(48, 13)
        Me.label17.TabIndex = 23
        Me.label17.Text = "Operator"
        '
        'label16
        '
        Me.label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label16.AutoSize = True
        Me.label16.Location = New System.Drawing.Point(8, 85)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(42, 13)
        Me.label16.TabIndex = 24
        Me.label16.Text = "Volume"
        '
        'tabPage6
        '
        Me.tabPage6.Controls.Add(Me.percentPanel)
        Me.tabPage6.Location = New System.Drawing.Point(4, 22)
        Me.tabPage6.Name = "tabPage6"
        Me.tabPage6.Size = New System.Drawing.Size(301, 190)
        Me.tabPage6.TabIndex = 7
        Me.tabPage6.Text = "Percent"
        Me.tabPage6.UseVisualStyleBackColor = True
        '
        'percentPanel
        '
        Me.percentPanel.Controls.Add(Me.Label14)
        Me.percentPanel.Controls.Add(Me.percentConExch)
        Me.percentPanel.Controls.Add(Me.percentConId)
        Me.percentPanel.Controls.Add(Me.Label20)
        Me.percentPanel.Controls.Add(Me.percent)
        Me.percentPanel.Controls.Add(Me.percentOperator)
        Me.percentPanel.Controls.Add(Me.label13)
        Me.percentPanel.Controls.Add(Me.label12)
        Me.percentPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.percentPanel.Location = New System.Drawing.Point(0, 0)
        Me.percentPanel.Name = "percentPanel"
        Me.percentPanel.Size = New System.Drawing.Size(301, 128)
        Me.percentPanel.TabIndex = 32
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(10, 32)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(107, 13)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "Underlying exchange"
        '
        'percentConExch
        '
        Me.percentConExch.Location = New System.Drawing.Point(126, 29)
        Me.percentConExch.Name = "percentConExch"
        Me.percentConExch.Size = New System.Drawing.Size(156, 20)
        Me.percentConExch.TabIndex = 33
        '
        'percentConId
        '
        Me.percentConId.Location = New System.Drawing.Point(126, 3)
        Me.percentConId.Name = "percentConId"
        Me.percentConId.Size = New System.Drawing.Size(156, 20)
        Me.percentConId.TabIndex = 32
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(10, 6)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(110, 13)
        Me.Label20.TabIndex = 31
        Me.Label20.Text = "Underlying contract id"
        '
        'percent
        '
        Me.percent.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.percent.Location = New System.Drawing.Point(126, 86)
        Me.percent.Name = "percent"
        Me.percent.Size = New System.Drawing.Size(156, 20)
        Me.percent.TabIndex = 28
        '
        'percentOperator
        '
        Me.percentOperator.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.percentOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.percentOperator.FormattingEnabled = True
        Me.percentOperator.Items.AddRange(New Object() {"<=", ">="})
        Me.percentOperator.Location = New System.Drawing.Point(126, 59)
        Me.percentOperator.Name = "percentOperator"
        Me.percentOperator.Size = New System.Drawing.Size(156, 21)
        Me.percentOperator.TabIndex = 27
        '
        'label13
        '
        Me.label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label13.AutoSize = True
        Me.label13.Location = New System.Drawing.Point(8, 62)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(48, 13)
        Me.label13.TabIndex = 29
        Me.label13.Text = "Operator"
        '
        'label12
        '
        Me.label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label12.AutoSize = True
        Me.label12.Location = New System.Drawing.Point(8, 89)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(101, 13)
        Me.label12.TabIndex = 30
        Me.label12.Text = "Percentage change"
        '
        'dlgCondition
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(309, 216)
        Me.Controls.Add(Me.tabControl1)
        Me.Name = "dlgCondition"
        Me.Text = "dlgCondition"
        Me.tabControl1.ResumeLayout(False)
        Me.conditionTypePage.ResumeLayout(False)
        Me.conditionTypePage.PerformLayout()
        Me.conditionPage.ResumeLayout(False)
        Me.tabPage1.ResumeLayout(False)
        Me.pricePanel.ResumeLayout(False)
        Me.pricePanel.PerformLayout()
        Me.tabPage2.ResumeLayout(False)
        Me.marginPanel.ResumeLayout(False)
        Me.marginPanel.PerformLayout()
        Me.tabPage3.ResumeLayout(False)
        Me.tradePanel.ResumeLayout(False)
        Me.tradePanel.PerformLayout()
        Me.tabPage4.ResumeLayout(False)
        Me.timePanel.ResumeLayout(False)
        Me.timePanel.PerformLayout()
        Me.tabPage5.ResumeLayout(False)
        Me.volumePanel.ResumeLayout(False)
        Me.volumePanel.PerformLayout()
        Me.tabPage6.ResumeLayout(False)
        Me.percentPanel.ResumeLayout(False)
        Me.percentPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents tabControl1 As System.Windows.Forms.TabControl
    Private WithEvents conditionTypePage As System.Windows.Forms.TabPage
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Private WithEvents percentRb As System.Windows.Forms.RadioButton
    Private WithEvents volumeRb As System.Windows.Forms.RadioButton
    Private WithEvents timeRb As System.Windows.Forms.RadioButton
    Private WithEvents tradeRb As System.Windows.Forms.RadioButton
    Private WithEvents marginRb As System.Windows.Forms.RadioButton
    Private WithEvents priceRb As System.Windows.Forms.RadioButton
    Private WithEvents conditionPage As System.Windows.Forms.TabPage
    Private WithEvents conditionPanel As System.Windows.Forms.Panel
    Private WithEvents back As System.Windows.Forms.Button
    Private WithEvents apply As System.Windows.Forms.Button
    Private WithEvents tabPage1 As System.Windows.Forms.TabPage
    Private WithEvents pricePanel As System.Windows.Forms.Panel
    Private WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents priceConExch As System.Windows.Forms.TextBox
    Friend WithEvents priceConId As System.Windows.Forms.TextBox
    Private WithEvents priceMethod As System.Windows.Forms.ComboBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents priceOperator As System.Windows.Forms.ComboBox
    Private WithEvents price As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents tabPage2 As System.Windows.Forms.TabPage
    Private WithEvents marginPanel As System.Windows.Forms.Panel
    Private WithEvents marginOperator As System.Windows.Forms.ComboBox
    Private WithEvents marginCushion As System.Windows.Forms.TextBox
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents tabPage3 As System.Windows.Forms.TabPage
    Private WithEvents tradePanel As System.Windows.Forms.Panel
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents tradeType As System.Windows.Forms.TextBox
    Private WithEvents tradeExchange As System.Windows.Forms.TextBox
    Private WithEvents tradeUnderlying As System.Windows.Forms.TextBox
    Private WithEvents tabPage4 As System.Windows.Forms.TabPage
    Private WithEvents timePanel As System.Windows.Forms.Panel
    Private WithEvents label11 As System.Windows.Forms.Label
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents time As System.Windows.Forms.TextBox
    Private WithEvents timeOperator As System.Windows.Forms.ComboBox
    Private WithEvents tabPage5 As System.Windows.Forms.TabPage
    Private WithEvents volumePanel As System.Windows.Forms.Panel
    Private WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents volumeConExch As System.Windows.Forms.TextBox
    Friend WithEvents volumeConId As System.Windows.Forms.TextBox
    Private WithEvents Label19 As System.Windows.Forms.Label
    Private WithEvents volume As System.Windows.Forms.TextBox
    Private WithEvents volumeOperator As System.Windows.Forms.ComboBox
    Private WithEvents label17 As System.Windows.Forms.Label
    Private WithEvents label16 As System.Windows.Forms.Label
    Private WithEvents tabPage6 As System.Windows.Forms.TabPage
    Private WithEvents percentPanel As System.Windows.Forms.Panel
    Private WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents percentConExch As System.Windows.Forms.TextBox
    Friend WithEvents percentConId As System.Windows.Forms.TextBox
    Private WithEvents Label20 As System.Windows.Forms.Label
    Private WithEvents percent As System.Windows.Forms.TextBox
    Private WithEvents percentOperator As System.Windows.Forms.ComboBox
    Private WithEvents label13 As System.Windows.Forms.Label
    Private WithEvents label12 As System.Windows.Forms.Label
End Class
