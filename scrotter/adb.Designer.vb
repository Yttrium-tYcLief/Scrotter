<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class adb
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(adb))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.IPBox1 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.IPBox2 = New System.Windows.Forms.TextBox()
        Me.IPBox3 = New System.Windows.Forms.TextBox()
        Me.IPBox4 = New System.Windows.Forms.TextBox()
        Me.BtnBorder = New System.Windows.Forms.PictureBox()
        Me.CancelBtnBox = New System.Windows.Forms.PictureBox()
        Me.CaptureBtnBox = New System.Windows.Forms.PictureBox()
        Me.ModeToggleBtnBox = New System.Windows.Forms.PictureBox()
        Me.CaptureBtnLabel = New System.Windows.Forms.Label()
        Me.ModeToggleBtnLabel = New System.Windows.Forms.Label()
        Me.CancelBtnLabel = New System.Windows.Forms.Label()
        CType(Me.BtnBorder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CancelBtnBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CaptureBtnBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ModeToggleBtnBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(7, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(316, 31)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "1. First, click below to download adb."
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.ForeColor = System.Drawing.Color.White
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(12, 49)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(268, 16)
        Me.LinkLabel1.TabIndex = 0
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Android Debug Bridge (~718KB download, one-time)"
        Me.LinkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(133, Byte), Integer), CType(CType(229, Byte), Integer))
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(7, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(281, 53)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "3. Launch the SDK Manager at the end of setup. Check ""Android SDK platform-tools""" & _
    " and click ""Install 1 package"". Hit ""accept"", and once it finishes, close it." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(7, 171)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(281, 34)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "4. Hit ""Browse..."" and find the platform-tools folder created in the SDK Tools di" & _
    "rectory."
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(7, 206)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(287, 22)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "5. Plug in your device, wait a minute, and hit ""Capture""."
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.Font = New System.Drawing.Font("Ubuntu", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(12, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(276, 16)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "YOUR DEVICE MUST RUN ICS OR LATER"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LinkLabel2
        '
        Me.LinkLabel2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LinkLabel2.ForeColor = System.Drawing.Color.White
        Me.LinkLabel2.LinkColor = System.Drawing.Color.FromArgb(CType(CType(99, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.LinkLabel2.Location = New System.Drawing.Point(7, 75)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(281, 43)
        Me.LinkLabel2.TabIndex = 1
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "2. Install the drivers for your device. (Windows only)"
        Me.LinkLabel2.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(133, Byte), Integer), CType(CType(229, Byte), Integer))
        '
        'IPBox1
        '
        Me.IPBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.IPBox1.Location = New System.Drawing.Point(77, 244)
        Me.IPBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.IPBox1.MaxLength = 3
        Me.IPBox1.Name = "IPBox1"
        Me.IPBox1.Size = New System.Drawing.Size(36, 20)
        Me.IPBox1.TabIndex = 2
        Me.IPBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.IPBox1.Visible = False
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(50, 244)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(21, 16)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "IP:"
        Me.Label6.Visible = False
        '
        'IPBox2
        '
        Me.IPBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.IPBox2.Location = New System.Drawing.Point(119, 244)
        Me.IPBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.IPBox2.MaxLength = 3
        Me.IPBox2.Name = "IPBox2"
        Me.IPBox2.Size = New System.Drawing.Size(36, 20)
        Me.IPBox2.TabIndex = 3
        Me.IPBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.IPBox2.Visible = False
        '
        'IPBox3
        '
        Me.IPBox3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.IPBox3.Location = New System.Drawing.Point(161, 244)
        Me.IPBox3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.IPBox3.MaxLength = 3
        Me.IPBox3.Name = "IPBox3"
        Me.IPBox3.Size = New System.Drawing.Size(36, 20)
        Me.IPBox3.TabIndex = 4
        Me.IPBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.IPBox3.Visible = False
        '
        'IPBox4
        '
        Me.IPBox4.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.IPBox4.Location = New System.Drawing.Point(203, 244)
        Me.IPBox4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.IPBox4.MaxLength = 3
        Me.IPBox4.Name = "IPBox4"
        Me.IPBox4.Size = New System.Drawing.Size(36, 20)
        Me.IPBox4.TabIndex = 5
        Me.IPBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.IPBox4.Visible = False
        '
        'BtnBorder
        '
        Me.BtnBorder.BackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(72, Byte), Integer))
        Me.BtnBorder.Location = New System.Drawing.Point(0, 270)
        Me.BtnBorder.Name = "BtnBorder"
        Me.BtnBorder.Size = New System.Drawing.Size(300, 50)
        Me.BtnBorder.TabIndex = 18
        Me.BtnBorder.TabStop = False
        '
        'CancelBtnBox
        '
        Me.CancelBtnBox.Location = New System.Drawing.Point(0, 272)
        Me.CancelBtnBox.Name = "CancelBtnBox"
        Me.CancelBtnBox.Size = New System.Drawing.Size(80, 48)
        Me.CancelBtnBox.TabIndex = 19
        Me.CancelBtnBox.TabStop = False
        '
        'CaptureBtnBox
        '
        Me.CaptureBtnBox.Location = New System.Drawing.Point(164, 272)
        Me.CaptureBtnBox.Name = "CaptureBtnBox"
        Me.CaptureBtnBox.Size = New System.Drawing.Size(136, 48)
        Me.CaptureBtnBox.TabIndex = 20
        Me.CaptureBtnBox.TabStop = False
        '
        'ModeToggleBtnBox
        '
        Me.ModeToggleBtnBox.Location = New System.Drawing.Point(82, 272)
        Me.ModeToggleBtnBox.Name = "ModeToggleBtnBox"
        Me.ModeToggleBtnBox.Size = New System.Drawing.Size(80, 48)
        Me.ModeToggleBtnBox.TabIndex = 21
        Me.ModeToggleBtnBox.TabStop = False
        '
        'CaptureBtnLabel
        '
        Me.CaptureBtnLabel.AutoSize = True
        Me.CaptureBtnLabel.Font = New System.Drawing.Font("Ubuntu", 12.0!)
        Me.CaptureBtnLabel.ForeColor = System.Drawing.Color.White
        Me.CaptureBtnLabel.Location = New System.Drawing.Point(199, 284)
        Me.CaptureBtnLabel.Name = "CaptureBtnLabel"
        Me.CaptureBtnLabel.Size = New System.Drawing.Size(67, 20)
        Me.CaptureBtnLabel.TabIndex = 22
        Me.CaptureBtnLabel.Text = "Capture"
        '
        'ModeToggleBtnLabel
        '
        Me.ModeToggleBtnLabel.AutoSize = True
        Me.ModeToggleBtnLabel.Font = New System.Drawing.Font("Ubuntu", 12.0!)
        Me.ModeToggleBtnLabel.ForeColor = System.Drawing.Color.White
        Me.ModeToggleBtnLabel.Location = New System.Drawing.Point(89, 284)
        Me.ModeToggleBtnLabel.Name = "ModeToggleBtnLabel"
        Me.ModeToggleBtnLabel.Size = New System.Drawing.Size(67, 20)
        Me.ModeToggleBtnLabel.TabIndex = 23
        Me.ModeToggleBtnLabel.Text = "Wireless"
        '
        'CancelBtnLabel
        '
        Me.CancelBtnLabel.AutoSize = True
        Me.CancelBtnLabel.Font = New System.Drawing.Font("Ubuntu", 12.0!)
        Me.CancelBtnLabel.ForeColor = System.Drawing.Color.White
        Me.CancelBtnLabel.Location = New System.Drawing.Point(12, 284)
        Me.CancelBtnLabel.Name = "CancelBtnLabel"
        Me.CancelBtnLabel.Size = New System.Drawing.Size(58, 20)
        Me.CancelBtnLabel.TabIndex = 24
        Me.CancelBtnLabel.Text = "Cancel"
        '
        'adb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(300, 320)
        Me.Controls.Add(Me.CancelBtnLabel)
        Me.Controls.Add(Me.ModeToggleBtnLabel)
        Me.Controls.Add(Me.CaptureBtnLabel)
        Me.Controls.Add(Me.ModeToggleBtnBox)
        Me.Controls.Add(Me.CaptureBtnBox)
        Me.Controls.Add(Me.CancelBtnBox)
        Me.Controls.Add(Me.BtnBorder)
        Me.Controls.Add(Me.IPBox4)
        Me.Controls.Add(Me.IPBox3)
        Me.Controls.Add(Me.IPBox2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.IPBox1)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "adb"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Android Capture Utility"
        CType(Me.BtnBorder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CancelBtnBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CaptureBtnBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ModeToggleBtnBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents IPBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents IPBox2 As System.Windows.Forms.TextBox
    Friend WithEvents IPBox3 As System.Windows.Forms.TextBox
    Friend WithEvents IPBox4 As System.Windows.Forms.TextBox
    Friend WithEvents BtnBorder As System.Windows.Forms.PictureBox
    Friend WithEvents CancelBtnBox As System.Windows.Forms.PictureBox
    Friend WithEvents CaptureBtnBox As System.Windows.Forms.PictureBox
    Friend WithEvents ModeToggleBtnBox As System.Windows.Forms.PictureBox
    Friend WithEvents CaptureBtnLabel As System.Windows.Forms.Label
    Friend WithEvents ModeToggleBtnLabel As System.Windows.Forms.Label
    Friend WithEvents CancelBtnLabel As System.Windows.Forms.Label
End Class
