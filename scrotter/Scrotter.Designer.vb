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
        Me.CaptureBtn = New System.Windows.Forms.Button()
        Me.StretchCheckbox = New System.Windows.Forms.CheckBox()
        CType(Me.Preview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LoadImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LoadBtn
        '
        Me.LoadBtn.Location = New System.Drawing.Point(464, 14)
        Me.LoadBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LoadBtn.Name = "LoadBtn"
        Me.LoadBtn.Size = New System.Drawing.Size(75, 24)
        Me.LoadBtn.TabIndex = 0
        Me.LoadBtn.Text = "Browse..."
        Me.LoadBtn.UseVisualStyleBackColor = True
        '
        'ScreenshotBox
        '
        Me.ScreenshotBox.Location = New System.Drawing.Point(315, 14)
        Me.ScreenshotBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ScreenshotBox.Name = "ScreenshotBox"
        Me.ScreenshotBox.ReadOnly = True
        Me.ScreenshotBox.Size = New System.Drawing.Size(143, 20)
        Me.ScreenshotBox.TabIndex = 1
        Me.ScreenshotBox.Text = "Screenshot"
        '
        'ModelBox
        '
        Me.ModelBox.FormattingEnabled = True
        Me.ModelBox.Items.AddRange(New Object() {"Apple iPad Mini", "Apple iPhone", "Apple iPhone 3G, 3GS", "Apple iPhone 4", "Apple iPhone 4S", "Apple iPhone 5", "ASUS Eee Pad Transformer", "Google Nexus 4", "Google Nexus 7", "Google Nexus 10", "Google Nexus S", "HP TouchPad", "HP Veer", "HTC 8S", "HTC 8X", "HTC Desire", "HTC Desire C", "HTC Desire HD, HTC Inspire 4G", "HTC Desire Z, T-Mobile G2", "HTC Droid DNA", "HTC Evo 3D", "HTC Evo 4G LTE", "HTC Google Nexus One", "HTC Hero", "HTC Legend", "HTC One S", "HTC One V", "HTC One X, HTC One X+", "HTC Vivid", "LG Nitro HD, Spectrum, Optimus LTE/LTE L-01D/True HD LTE/LTE II", "Motorola Droid RAZR", "Motorola Droid RAZR M", "Motorola Xoom", "Nokia Lumia 920", "Nokia N9", "Samsung Droid Charge, Galaxy S Aviator, Galaxy S Lightray 4G", "Samsung Galaxy Ace, Galaxy Cooper", "Samsung Galaxy Note II", "Samsung Galaxy SII, Epic 4G Touch", "Samsung Galaxy SII Skyrocket", "Samsung Galaxy SIII", "Samsung Galaxy SIII Mini", "Samsung Galaxy Tab 10.1", "Samsung Google Galaxy Nexus", "Sony Ericsson Xperia J", "Sony Ericsson Xperia X10"})
        Me.ModelBox.Location = New System.Drawing.Point(315, 93)
        Me.ModelBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ModelBox.Name = "ModelBox"
        Me.ModelBox.Size = New System.Drawing.Size(224, 21)
        Me.ModelBox.TabIndex = 2
        Me.ModelBox.Text = "Device Model"
        '
        'SaveBtn
        '
        Me.SaveBtn.Location = New System.Drawing.Point(464, 465)
        Me.SaveBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SaveBtn.Name = "SaveBtn"
        Me.SaveBtn.Size = New System.Drawing.Size(75, 27)
        Me.SaveBtn.TabIndex = 5
        Me.SaveBtn.Text = "Save As..."
        Me.SaveBtn.UseVisualStyleBackColor = True
        '
        'Preview
        '
        Me.Preview.InitialImage = Nothing
        Me.Preview.Location = New System.Drawing.Point(9, 14)
        Me.Preview.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Preview.Name = "Preview"
        Me.Preview.Size = New System.Drawing.Size(300, 478)
        Me.Preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Preview.TabIndex = 6
        Me.Preview.TabStop = False
        '
        'VariantBox
        '
        Me.VariantBox.Enabled = False
        Me.VariantBox.FormattingEnabled = True
        Me.VariantBox.Location = New System.Drawing.Point(315, 122)
        Me.VariantBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.VariantBox.Name = "VariantBox"
        Me.VariantBox.Size = New System.Drawing.Size(224, 21)
        Me.VariantBox.TabIndex = 7
        Me.VariantBox.Text = "Variant"
        '
        'ShadowCheckbox
        '
        Me.ShadowCheckbox.AutoSize = True
        Me.ShadowCheckbox.Enabled = False
        Me.ShadowCheckbox.Location = New System.Drawing.Point(315, 446)
        Me.ShadowCheckbox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ShadowCheckbox.Name = "ShadowCheckbox"
        Me.ShadowCheckbox.Size = New System.Drawing.Size(93, 17)
        Me.ShadowCheckbox.TabIndex = 8
        Me.ShadowCheckbox.Text = "Edge Shadow"
        Me.ShadowCheckbox.UseVisualStyleBackColor = True
        '
        'GlossCheckbox
        '
        Me.GlossCheckbox.AutoSize = True
        Me.GlossCheckbox.Enabled = False
        Me.GlossCheckbox.Location = New System.Drawing.Point(315, 422)
        Me.GlossCheckbox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GlossCheckbox.Name = "GlossCheckbox"
        Me.GlossCheckbox.Size = New System.Drawing.Size(52, 17)
        Me.GlossCheckbox.TabIndex = 9
        Me.GlossCheckbox.Text = "Gloss"
        Me.GlossCheckbox.UseVisualStyleBackColor = True
        '
        'UnderShadowCheckbox
        '
        Me.UnderShadowCheckbox.AutoSize = True
        Me.UnderShadowCheckbox.Enabled = False
        Me.UnderShadowCheckbox.Location = New System.Drawing.Point(315, 470)
        Me.UnderShadowCheckbox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.UnderShadowCheckbox.Name = "UnderShadowCheckbox"
        Me.UnderShadowCheckbox.Size = New System.Drawing.Size(97, 17)
        Me.UnderShadowCheckbox.TabIndex = 10
        Me.UnderShadowCheckbox.Text = "Under Shadow"
        Me.UnderShadowCheckbox.UseVisualStyleBackColor = True
        '
        'BackgroundDownloader
        '
        '
        'LoadImage
        '
        Me.LoadImage.InitialImage = Nothing
        Me.LoadImage.Location = New System.Drawing.Point(394, 249)
        Me.LoadImage.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LoadImage.Name = "LoadImage"
        Me.LoadImage.Size = New System.Drawing.Size(64, 76)
        Me.LoadImage.TabIndex = 11
        Me.LoadImage.TabStop = False
        '
        'CaptureBtn
        '
        Me.CaptureBtn.Location = New System.Drawing.Point(315, 41)
        Me.CaptureBtn.Name = "CaptureBtn"
        Me.CaptureBtn.Size = New System.Drawing.Size(224, 23)
        Me.CaptureBtn.TabIndex = 12
        Me.CaptureBtn.Text = "Capture from Android Device"
        Me.CaptureBtn.UseVisualStyleBackColor = True
        '
        'StretchCheckbox
        '
        Me.StretchCheckbox.AutoSize = True
        Me.StretchCheckbox.Enabled = False
        Me.StretchCheckbox.Location = New System.Drawing.Point(315, 397)
        Me.StretchCheckbox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.StretchCheckbox.Name = "StretchCheckbox"
        Me.StretchCheckbox.Size = New System.Drawing.Size(92, 17)
        Me.StretchCheckbox.TabIndex = 13
        Me.StretchCheckbox.Text = "Stretch Image"
        Me.StretchCheckbox.UseVisualStyleBackColor = True
        '
        'Scrotter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(551, 503)
        Me.Controls.Add(Me.StretchCheckbox)
        Me.Controls.Add(Me.CaptureBtn)
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
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Scrotter"
        Me.Text = "Scrotter"
        CType(Me.Preview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LoadImage, System.ComponentModel.ISupportInitialize).EndInit()
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
	Friend WithEvents CaptureBtn As System.Windows.Forms.Button
	Friend WithEvents StretchCheckbox As System.Windows.Forms.CheckBox

End Class
