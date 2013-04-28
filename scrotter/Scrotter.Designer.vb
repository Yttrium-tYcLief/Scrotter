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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Scrotter))
        Me.LoadBtn = New System.Windows.Forms.Button()
        Me.ScreenshotBox = New System.Windows.Forms.TextBox()
        Me.ModelBox = New System.Windows.Forms.ComboBox()
        Me.SaveBtn = New System.Windows.Forms.Button()
        Me.Preview = New System.Windows.Forms.PictureBox()
        Me.VariantBox = New System.Windows.Forms.ComboBox()
        Me.ShadowCheckbox = New System.Windows.Forms.CheckBox()
        Me.GlossCheckbox = New System.Windows.Forms.CheckBox()
        Me.UnderShadowCheckbox = New System.Windows.Forms.CheckBox()
        Me.BackgroundDownloader = New System.ComponentModel.BackgroundWorker()
        Me.LoadImage = New System.Windows.Forms.PictureBox()
        Me.StretchCheckbox = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CaptureBtn = New System.Windows.Forms.Button()
        Me.ScreenPicker = New System.Windows.Forms.NumericUpDown()
        Me.ScreenAmountPicker = New System.Windows.Forms.NumericUpDown()
        CType(Me.Preview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LoadImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ScreenPicker, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ScreenAmountPicker, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LoadBtn
        '
        Me.LoadBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LoadBtn.BackColor = System.Drawing.Color.Transparent
        Me.LoadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LoadBtn.Location = New System.Drawing.Point(466, 17)
        Me.LoadBtn.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.LoadBtn.Name = "LoadBtn"
        Me.LoadBtn.Size = New System.Drawing.Size(75, 30)
        Me.LoadBtn.TabIndex = 1
        Me.LoadBtn.Text = "Browse..."
        Me.LoadBtn.UseVisualStyleBackColor = False
        '
        'ScreenshotBox
        '
        Me.ScreenshotBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ScreenshotBox.Location = New System.Drawing.Point(317, 22)
        Me.ScreenshotBox.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.ScreenshotBox.Name = "ScreenshotBox"
        Me.ScreenshotBox.ReadOnly = True
        Me.ScreenshotBox.Size = New System.Drawing.Size(143, 20)
        Me.ScreenshotBox.TabIndex = 0
        Me.ScreenshotBox.Text = "Screenshot"
        '
        'ModelBox
        '
        Me.ModelBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ModelBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ModelBox.FormattingEnabled = True
        Me.ModelBox.Items.AddRange(New Object() {"Apple iPhone", "Apple iPhone 3G, 3GS", "Apple iPhone 4", "Apple iPhone 4S", "Apple iPhone 5", "BlackBerry Z10", "Google Nexus 4", "Google Nexus 7", "Google Nexus 10", "Google Nexus S", "HTC Desire HD, HTC Inspire 4G", "HTC One", "HTC One S", "HTC One V", "HTC One X, HTC One X+", "Motorola Droid RAZR", "Motorola Droid RAZR M", "Motorola Xoom", "Samsung Galaxy Player 5.0", "Samsung Galaxy Note II", "Samsung Galaxy SII, Epic 4G Touch", "Samsung Galaxy SIII", "Samsung Galaxy SIII Mini", "Samsung Google Galaxy Nexus"})
        Me.ModelBox.Location = New System.Drawing.Point(317, 130)
        Me.ModelBox.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.ModelBox.MaxDropDownItems = 16
        Me.ModelBox.Name = "ModelBox"
        Me.ModelBox.Size = New System.Drawing.Size(224, 24)
        Me.ModelBox.TabIndex = 5
        Me.ModelBox.Text = "Device Model"
        '
        'SaveBtn
        '
        Me.SaveBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SaveBtn.Location = New System.Drawing.Point(361, 574)
        Me.SaveBtn.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.SaveBtn.Name = "SaveBtn"
        Me.SaveBtn.Size = New System.Drawing.Size(186, 33)
        Me.SaveBtn.TabIndex = 12
        Me.SaveBtn.Text = "Save As..."
        Me.SaveBtn.UseVisualStyleBackColor = True
        '
        'Preview
        '
        Me.Preview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Preview.InitialImage = Nothing
        Me.Preview.Location = New System.Drawing.Point(0, 0)
        Me.Preview.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Preview.Name = "Preview"
        Me.Preview.Size = New System.Drawing.Size(302, 619)
        Me.Preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Preview.TabIndex = 6
        Me.Preview.TabStop = False
        '
        'VariantBox
        '
        Me.VariantBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VariantBox.Enabled = False
        Me.VariantBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.VariantBox.FormattingEnabled = True
        Me.VariantBox.Location = New System.Drawing.Point(317, 156)
        Me.VariantBox.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.VariantBox.Name = "VariantBox"
        Me.VariantBox.Size = New System.Drawing.Size(224, 24)
        Me.VariantBox.TabIndex = 6
        Me.VariantBox.Text = "Variant"
        '
        'ShadowCheckbox
        '
        Me.ShadowCheckbox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ShadowCheckbox.AutoSize = True
        Me.ShadowCheckbox.Enabled = False
        Me.ShadowCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ShadowCheckbox.Location = New System.Drawing.Point(317, 545)
        Me.ShadowCheckbox.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.ShadowCheckbox.Name = "ShadowCheckbox"
        Me.ShadowCheckbox.Size = New System.Drawing.Size(90, 20)
        Me.ShadowCheckbox.TabIndex = 9
        Me.ShadowCheckbox.Text = "Edge Shadow"
        Me.ShadowCheckbox.UseVisualStyleBackColor = True
        '
        'GlossCheckbox
        '
        Me.GlossCheckbox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GlossCheckbox.AutoSize = True
        Me.GlossCheckbox.Enabled = False
        Me.GlossCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GlossCheckbox.Location = New System.Drawing.Point(411, 524)
        Me.GlossCheckbox.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GlossCheckbox.Name = "GlossCheckbox"
        Me.GlossCheckbox.Size = New System.Drawing.Size(51, 20)
        Me.GlossCheckbox.TabIndex = 8
        Me.GlossCheckbox.Text = "Gloss"
        Me.GlossCheckbox.UseVisualStyleBackColor = True
        '
        'UnderShadowCheckbox
        '
        Me.UnderShadowCheckbox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UnderShadowCheckbox.AutoSize = True
        Me.UnderShadowCheckbox.Enabled = False
        Me.UnderShadowCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.UnderShadowCheckbox.Location = New System.Drawing.Point(411, 545)
        Me.UnderShadowCheckbox.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.UnderShadowCheckbox.Name = "UnderShadowCheckbox"
        Me.UnderShadowCheckbox.Size = New System.Drawing.Size(96, 20)
        Me.UnderShadowCheckbox.TabIndex = 10
        Me.UnderShadowCheckbox.Text = "Under Shadow"
        Me.UnderShadowCheckbox.UseVisualStyleBackColor = True
        '
        'BackgroundDownloader
        '
        '
        'LoadImage
        '
        Me.LoadImage.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.LoadImage.InitialImage = Nothing
        Me.LoadImage.Location = New System.Drawing.Point(396, 320)
        Me.LoadImage.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.LoadImage.Name = "LoadImage"
        Me.LoadImage.Size = New System.Drawing.Size(64, 64)
        Me.LoadImage.TabIndex = 11
        Me.LoadImage.TabStop = False
        '
        'StretchCheckbox
        '
        Me.StretchCheckbox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StretchCheckbox.AutoSize = True
        Me.StretchCheckbox.Enabled = False
        Me.StretchCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.StretchCheckbox.Location = New System.Drawing.Point(317, 524)
        Me.StretchCheckbox.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.StretchCheckbox.Name = "StretchCheckbox"
        Me.StretchCheckbox.Size = New System.Drawing.Size(94, 20)
        Me.StretchCheckbox.TabIndex = 7
        Me.StretchCheckbox.Text = "Stretch Image"
        Me.StretchCheckbox.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(317, 574)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(38, 33)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "?"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(398, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 16)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Number of Screens"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(417, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 16)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Current Screen"
        '
        'CaptureBtn
        '
        Me.CaptureBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CaptureBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CaptureBtn.Location = New System.Drawing.Point(317, 50)
        Me.CaptureBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CaptureBtn.Name = "CaptureBtn"
        Me.CaptureBtn.Size = New System.Drawing.Size(224, 28)
        Me.CaptureBtn.TabIndex = 2
        Me.CaptureBtn.Text = "Capture from Android Device"
        Me.CaptureBtn.UseVisualStyleBackColor = True
        '
        'ScreenPicker
        '
        Me.ScreenPicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ScreenPicker.Enabled = False
        Me.ScreenPicker.Location = New System.Drawing.Point(505, 106)
        Me.ScreenPicker.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ScreenPicker.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ScreenPicker.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ScreenPicker.Name = "ScreenPicker"
        Me.ScreenPicker.Size = New System.Drawing.Size(36, 20)
        Me.ScreenPicker.TabIndex = 4
        Me.ScreenPicker.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'ScreenAmountPicker
        '
        Me.ScreenAmountPicker.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ScreenAmountPicker.Enabled = False
        Me.ScreenAmountPicker.Location = New System.Drawing.Point(505, 82)
        Me.ScreenAmountPicker.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ScreenAmountPicker.Maximum = New Decimal(New Integer() {7, 0, 0, 0})
        Me.ScreenAmountPicker.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ScreenAmountPicker.Name = "ScreenAmountPicker"
        Me.ScreenAmountPicker.Size = New System.Drawing.Size(36, 20)
        Me.ScreenAmountPicker.TabIndex = 3
        Me.ScreenAmountPicker.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Scrotter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(559, 619)
        Me.Controls.Add(Me.CaptureBtn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ScreenPicker)
        Me.Controls.Add(Me.ScreenAmountPicker)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.StretchCheckbox)
        Me.Controls.Add(Me.LoadImage)
        Me.Controls.Add(Me.UnderShadowCheckbox)
        Me.Controls.Add(Me.GlossCheckbox)
        Me.Controls.Add(Me.ShadowCheckbox)
        Me.Controls.Add(Me.VariantBox)
        Me.Controls.Add(Me.Preview)
        Me.Controls.Add(Me.SaveBtn)
        Me.Controls.Add(Me.ModelBox)
        Me.Controls.Add(Me.ScreenshotBox)
        Me.Controls.Add(Me.LoadBtn)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.MinimumSize = New System.Drawing.Size(500, 401)
        Me.Name = "Scrotter"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Scrotter"
        CType(Me.Preview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LoadImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ScreenPicker, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ScreenAmountPicker, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LoadBtn As System.Windows.Forms.Button
    Friend WithEvents ScreenshotBox As System.Windows.Forms.TextBox
    Friend WithEvents ModelBox As System.Windows.Forms.ComboBox
    Friend WithEvents SaveBtn As System.Windows.Forms.Button
    Friend WithEvents Preview As System.Windows.Forms.PictureBox
    Friend WithEvents VariantBox As System.Windows.Forms.ComboBox
    Friend WithEvents ShadowCheckbox As System.Windows.Forms.CheckBox
    Friend WithEvents GlossCheckbox As System.Windows.Forms.CheckBox
    Friend WithEvents UnderShadowCheckbox As System.Windows.Forms.CheckBox
    Friend WithEvents BackgroundDownloader As System.ComponentModel.BackgroundWorker
    Friend WithEvents LoadImage As System.Windows.Forms.PictureBox
    Friend WithEvents StretchCheckbox As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CaptureBtn As System.Windows.Forms.Button
    Friend WithEvents ScreenPicker As System.Windows.Forms.NumericUpDown
    Friend WithEvents ScreenAmountPicker As System.Windows.Forms.NumericUpDown

End Class
