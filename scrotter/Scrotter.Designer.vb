<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Scrotter
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Scrotter))
        Me.ModelBox = New System.Windows.Forms.ComboBox()
        Me.VariantBox = New System.Windows.Forms.ComboBox()
        Me.BackgroundDownloader = New System.ComponentModel.BackgroundWorker()
        Me.CaptureBtn = New System.Windows.Forms.Button()
        Me.ScreenPicker = New System.Windows.Forms.NumericUpDown()
        Me.ScreenAmountPicker = New System.Windows.Forms.NumericUpDown()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveMultipleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PreferencesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StyleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GlossToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EdgeShadowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnderShadowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ScreensToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NumberOfScreensToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CurrentScreenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem11 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem12 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem13 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem14 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem15 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem16 = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WebsiteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContributeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpBtn = New System.Windows.Forms.ToolStripMenuItem()
        Me.MemoryLabel = New System.Windows.Forms.ToolStripTextBox()
        Me.ReflectBox = New System.Windows.Forms.CheckBox()
        Me.MemoryTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.Preview = New System.Windows.Forms.PictureBox()
        CType(Me.ScreenPicker, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ScreenAmountPicker, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.Preview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ModelBox
        '
        Me.ModelBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ModelBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ModelBox.FormattingEnabled = True
        Me.ModelBox.Items.AddRange(New Object() {"Apple iPhone", "Apple iPhone 3G, 3GS", "Apple iPhone 4", "Apple iPhone 4S", "Apple iPhone 5", "Apple iPhone 5C", "Apple iPhone 5S", "BlackBerry Z10", "Google Nexus 4", "Google Nexus 5", "Google Nexus 7", "Google Nexus 10", "Google Nexus S", "HTC Desire HD, HTC Inspire 4G", "HTC One", "HTC One S", "HTC One V", "HTC One X, HTC One X+", "Kyocera RiSE", "LG G2", "LG Optimus 4X HD", "Motorola Droid RAZR", "Motorola Droid RAZR M", "Motorola Moto X", "Motorola Xoom", "Samsung Galaxy Player 5.0", "Samsung Galaxy Note II", "Samsung Galaxy SII, Epic 4G Touch", "Samsung Galaxy SIII", "Samsung Galaxy SIII Mini", "Samsung Galaxy SIV", "Samsung Google Galaxy Nexus", "Sony Xperia S", "Sony Xperia Sola", "Sony Xperia Z"})
        Me.ModelBox.Location = New System.Drawing.Point(12, 28)
        Me.ModelBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ModelBox.MaxDropDownItems = 16
        Me.ModelBox.Name = "ModelBox"
        Me.ModelBox.Size = New System.Drawing.Size(299, 21)
        Me.ModelBox.TabIndex = 5
        '
        'VariantBox
        '
        Me.VariantBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VariantBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.VariantBox.Enabled = False
        Me.VariantBox.FormattingEnabled = True
        Me.VariantBox.Location = New System.Drawing.Point(317, 28)
        Me.VariantBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.VariantBox.Name = "VariantBox"
        Me.VariantBox.Size = New System.Drawing.Size(230, 21)
        Me.VariantBox.TabIndex = 6
        '
        'BackgroundDownloader
        '
        '
        'CaptureBtn
        '
        Me.CaptureBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CaptureBtn.Location = New System.Drawing.Point(317, 446)
        Me.CaptureBtn.Name = "CaptureBtn"
        Me.CaptureBtn.Size = New System.Drawing.Size(224, 23)
        Me.CaptureBtn.TabIndex = 2
        Me.CaptureBtn.Text = "Capture from Android Device"
        Me.CaptureBtn.UseVisualStyleBackColor = True
        Me.CaptureBtn.Visible = False
        '
        'ScreenPicker
        '
        Me.ScreenPicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ScreenPicker.Enabled = False
        Me.ScreenPicker.Location = New System.Drawing.Point(505, 114)
        Me.ScreenPicker.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ScreenPicker.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ScreenPicker.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ScreenPicker.Name = "ScreenPicker"
        Me.ScreenPicker.Size = New System.Drawing.Size(36, 20)
        Me.ScreenPicker.TabIndex = 4
        Me.ScreenPicker.Value = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ScreenPicker.Visible = False
        '
        'ScreenAmountPicker
        '
        Me.ScreenAmountPicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ScreenAmountPicker.Enabled = False
        Me.ScreenAmountPicker.Location = New System.Drawing.Point(505, 94)
        Me.ScreenAmountPicker.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ScreenAmountPicker.Maximum = New Decimal(New Integer() {7, 0, 0, 0})
        Me.ScreenAmountPicker.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ScreenAmountPicker.Name = "ScreenAmountPicker"
        Me.ScreenAmountPicker.Size = New System.Drawing.Size(36, 20)
        Me.ScreenAmountPicker.TabIndex = 3
        Me.ScreenAmountPicker.Value = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ScreenAmountPicker.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.StyleToolStripMenuItem, Me.ScreensToolStripMenuItem, Me.HelpToolStripMenuItem, Me.MemoryLabel})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.Size = New System.Drawing.Size(559, 27)
        Me.MenuStrip1.TabIndex = 18
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.SaveMultipleToolStripMenuItem, Me.PreferencesToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(37, 23)
        Me.ToolStripMenuItem1.Text = "File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.OpenToolStripMenuItem.Text = "Open..."
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.SaveAsToolStripMenuItem.Text = "Save As..."
        '
        'SaveMultipleToolStripMenuItem
        '
        Me.SaveMultipleToolStripMenuItem.Enabled = False
        Me.SaveMultipleToolStripMenuItem.Name = "SaveMultipleToolStripMenuItem"
        Me.SaveMultipleToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.SaveMultipleToolStripMenuItem.Text = "Save Array As..."
        '
        'PreferencesToolStripMenuItem
        '
        Me.PreferencesToolStripMenuItem.Name = "PreferencesToolStripMenuItem"
        Me.PreferencesToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.PreferencesToolStripMenuItem.Text = "Preferences"
        Me.PreferencesToolStripMenuItem.Visible = False
        '
        'StyleToolStripMenuItem
        '
        Me.StyleToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GlossToolStripMenuItem, Me.EdgeShadowToolStripMenuItem, Me.UnderShadowToolStripMenuItem})
        Me.StyleToolStripMenuItem.Name = "StyleToolStripMenuItem"
        Me.StyleToolStripMenuItem.Size = New System.Drawing.Size(44, 23)
        Me.StyleToolStripMenuItem.Text = "Style"
        '
        'GlossToolStripMenuItem
        '
        Me.GlossToolStripMenuItem.CheckOnClick = True
        Me.GlossToolStripMenuItem.Name = "GlossToolStripMenuItem"
        Me.GlossToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.GlossToolStripMenuItem.Text = "Gloss"
        '
        'EdgeShadowToolStripMenuItem
        '
        Me.EdgeShadowToolStripMenuItem.CheckOnClick = True
        Me.EdgeShadowToolStripMenuItem.Name = "EdgeShadowToolStripMenuItem"
        Me.EdgeShadowToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.EdgeShadowToolStripMenuItem.Text = "Edge Shadow"
        '
        'UnderShadowToolStripMenuItem
        '
        Me.UnderShadowToolStripMenuItem.CheckOnClick = True
        Me.UnderShadowToolStripMenuItem.Name = "UnderShadowToolStripMenuItem"
        Me.UnderShadowToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.UnderShadowToolStripMenuItem.Text = "Drop Shadow"
        '
        'ScreensToolStripMenuItem
        '
        Me.ScreensToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NumberOfScreensToolStripMenuItem, Me.CurrentScreenToolStripMenuItem})
        Me.ScreensToolStripMenuItem.Name = "ScreensToolStripMenuItem"
        Me.ScreensToolStripMenuItem.Size = New System.Drawing.Size(59, 23)
        Me.ScreensToolStripMenuItem.Text = "Screens"
        '
        'NumberOfScreensToolStripMenuItem
        '
        Me.NumberOfScreensToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem3, Me.ToolStripMenuItem4, Me.ToolStripMenuItem5, Me.ToolStripMenuItem6, Me.ToolStripMenuItem7, Me.ToolStripMenuItem8, Me.ToolStripMenuItem9})
        Me.NumberOfScreensToolStripMenuItem.Name = "NumberOfScreensToolStripMenuItem"
        Me.NumberOfScreensToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.NumberOfScreensToolStripMenuItem.Text = "Number of Screens"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(80, 22)
        Me.ToolStripMenuItem3.Text = "1"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(80, 22)
        Me.ToolStripMenuItem4.Text = "2"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(80, 22)
        Me.ToolStripMenuItem5.Text = "3"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(80, 22)
        Me.ToolStripMenuItem6.Text = "4"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(80, 22)
        Me.ToolStripMenuItem7.Text = "5"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(80, 22)
        Me.ToolStripMenuItem8.Text = "6"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(80, 22)
        Me.ToolStripMenuItem9.Text = "7"
        '
        'CurrentScreenToolStripMenuItem
        '
        Me.CurrentScreenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem10, Me.ToolStripMenuItem11, Me.ToolStripMenuItem12, Me.ToolStripMenuItem13, Me.ToolStripMenuItem14, Me.ToolStripMenuItem15, Me.ToolStripMenuItem16})
        Me.CurrentScreenToolStripMenuItem.Name = "CurrentScreenToolStripMenuItem"
        Me.CurrentScreenToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.CurrentScreenToolStripMenuItem.Text = "Current Screen"
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(80, 22)
        Me.ToolStripMenuItem10.Text = "1"
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        Me.ToolStripMenuItem11.Size = New System.Drawing.Size(80, 22)
        Me.ToolStripMenuItem11.Text = "2"
        Me.ToolStripMenuItem11.Visible = False
        '
        'ToolStripMenuItem12
        '
        Me.ToolStripMenuItem12.Name = "ToolStripMenuItem12"
        Me.ToolStripMenuItem12.Size = New System.Drawing.Size(80, 22)
        Me.ToolStripMenuItem12.Text = "3"
        Me.ToolStripMenuItem12.Visible = False
        '
        'ToolStripMenuItem13
        '
        Me.ToolStripMenuItem13.Name = "ToolStripMenuItem13"
        Me.ToolStripMenuItem13.Size = New System.Drawing.Size(80, 22)
        Me.ToolStripMenuItem13.Text = "4"
        Me.ToolStripMenuItem13.Visible = False
        '
        'ToolStripMenuItem14
        '
        Me.ToolStripMenuItem14.Name = "ToolStripMenuItem14"
        Me.ToolStripMenuItem14.Size = New System.Drawing.Size(80, 22)
        Me.ToolStripMenuItem14.Text = "5"
        Me.ToolStripMenuItem14.Visible = False
        '
        'ToolStripMenuItem15
        '
        Me.ToolStripMenuItem15.Name = "ToolStripMenuItem15"
        Me.ToolStripMenuItem15.Size = New System.Drawing.Size(80, 22)
        Me.ToolStripMenuItem15.Text = "6"
        Me.ToolStripMenuItem15.Visible = False
        '
        'ToolStripMenuItem16
        '
        Me.ToolStripMenuItem16.Name = "ToolStripMenuItem16"
        Me.ToolStripMenuItem16.Size = New System.Drawing.Size(80, 22)
        Me.ToolStripMenuItem16.Text = "7"
        Me.ToolStripMenuItem16.Visible = False
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WebsiteToolStripMenuItem, Me.ContributeToolStripMenuItem, Me.HelpBtn})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 23)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'WebsiteToolStripMenuItem
        '
        Me.WebsiteToolStripMenuItem.Name = "WebsiteToolStripMenuItem"
        Me.WebsiteToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.WebsiteToolStripMenuItem.Text = "Website"
        '
        'ContributeToolStripMenuItem
        '
        Me.ContributeToolStripMenuItem.Name = "ContributeToolStripMenuItem"
        Me.ContributeToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.ContributeToolStripMenuItem.Text = "Contribute"
        '
        'HelpBtn
        '
        Me.HelpBtn.Name = "HelpBtn"
        Me.HelpBtn.Size = New System.Drawing.Size(151, 22)
        Me.HelpBtn.Text = "About Scrotter"
        '
        'MemoryLabel
        '
        Me.MemoryLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.MemoryLabel.AutoSize = False
        Me.MemoryLabel.BackColor = System.Drawing.SystemColors.Control
        Me.MemoryLabel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MemoryLabel.Name = "MemoryLabel"
        Me.MemoryLabel.ReadOnly = True
        Me.MemoryLabel.Size = New System.Drawing.Size(140, 23)
        Me.MemoryLabel.Text = "Memory Usage: "
        '
        'ReflectBox
        '
        Me.ReflectBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReflectBox.AutoSize = True
        Me.ReflectBox.Location = New System.Drawing.Point(16, 452)
        Me.ReflectBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ReflectBox.Name = "ReflectBox"
        Me.ReflectBox.Size = New System.Drawing.Size(74, 17)
        Me.ReflectBox.TabIndex = 16
        Me.ReflectBox.Text = "Reflection"
        Me.ReflectBox.UseVisualStyleBackColor = True
        Me.ReflectBox.Visible = False
        '
        'MemoryTimer
        '
        Me.MemoryTimer.Enabled = True
        Me.MemoryTimer.Interval = 500
        '
        'ProgressBar
        '
        Me.ProgressBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar.Location = New System.Drawing.Point(12, 474)
        Me.ProgressBar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ProgressBar.MarqueeAnimationSpeed = 10
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(535, 19)
        Me.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar.TabIndex = 19
        '
        'Preview
        '
        Me.Preview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Preview.InitialImage = Nothing
        Me.Preview.Location = New System.Drawing.Point(12, 54)
        Me.Preview.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Preview.Name = "Preview"
        Me.Preview.Size = New System.Drawing.Size(535, 439)
        Me.Preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Preview.TabIndex = 6
        Me.Preview.TabStop = False
        '
        'Scrotter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(559, 503)
        Me.Controls.Add(Me.ModelBox)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.ReflectBox)
        Me.Controls.Add(Me.CaptureBtn)
        Me.Controls.Add(Me.ScreenPicker)
        Me.Controls.Add(Me.ScreenAmountPicker)
        Me.Controls.Add(Me.VariantBox)
        Me.Controls.Add(Me.Preview)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MinimumSize = New System.Drawing.Size(500, 335)
        Me.Name = "Scrotter"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Scrotter"
        CType(Me.ScreenPicker, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ScreenAmountPicker, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.Preview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ModelBox As System.Windows.Forms.ComboBox
    Friend WithEvents Preview As System.Windows.Forms.PictureBox
    Friend WithEvents VariantBox As System.Windows.Forms.ComboBox
    Friend WithEvents BackgroundDownloader As System.ComponentModel.BackgroundWorker
    Friend WithEvents CaptureBtn As System.Windows.Forms.Button
    Friend WithEvents ScreenPicker As System.Windows.Forms.NumericUpDown
    Friend WithEvents ScreenAmountPicker As System.Windows.Forms.NumericUpDown
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveMultipleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WebsiteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContributeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpBtn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StyleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ScreensToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GlossToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EdgeShadowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnderShadowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReflectBox As System.Windows.Forms.CheckBox
    Friend WithEvents MemoryTimer As System.Windows.Forms.Timer
    Friend WithEvents PreferencesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MemoryLabel As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents NumberOfScreensToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CurrentScreenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem11 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem12 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem13 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem14 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem15 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem16 As System.Windows.Forms.ToolStripMenuItem

End Class
