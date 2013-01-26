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
        Me.CaptureBtn = New System.Windows.Forms.Button()
        Me.CancelBtn = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.ModeToggleBtn = New System.Windows.Forms.Button()
        Me.IPBox1 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.IPBox2 = New System.Windows.Forms.TextBox()
        Me.IPBox3 = New System.Windows.Forms.TextBox()
        Me.IPBox4 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'CaptureBtn
        '
        Me.CaptureBtn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CaptureBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CaptureBtn.Location = New System.Drawing.Point(154, 240)
        Me.CaptureBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CaptureBtn.Name = "CaptureBtn"
        Me.CaptureBtn.Size = New System.Drawing.Size(139, 28)
        Me.CaptureBtn.TabIndex = 0
        Me.CaptureBtn.Text = "Capture"
        Me.CaptureBtn.UseVisualStyleBackColor = True
        '
        'CancelBtn
        '
        Me.CancelBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CancelBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CancelBtn.Location = New System.Drawing.Point(12, 240)
        Me.CancelBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CancelBtn.Name = "CancelBtn"
        Me.CancelBtn.Size = New System.Drawing.Size(65, 28)
        Me.CancelBtn.TabIndex = 2
        Me.CancelBtn.Text = "Cancel"
        Me.CancelBtn.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.Location = New System.Drawing.Point(12, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(316, 31)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "1. First, click below to download adb."
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(17, 49)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(268, 16)
        Me.LinkLabel1.TabIndex = 8
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Android Debug Bridge (~718KB download, one-time)"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.Location = New System.Drawing.Point(12, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(281, 53)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "3. Launch the SDK Manager at the end of setup. Check ""Android SDK platform-tools""" & _
    " and click ""Install 1 package"". Hit ""accept"", and once it finishes, close it." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.Location = New System.Drawing.Point(12, 171)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(281, 34)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "4. Hit ""Browse..."" and find the platform-tools folder created in the SDK Tools di" & _
    "rectory."
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.Location = New System.Drawing.Point(12, 206)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(287, 22)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "5. Plug in your device, wait a minute, and hit ""Capture""."
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.Font = New System.Drawing.Font("Ubuntu", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(17, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(276, 16)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "YOUR DEVICE MUST RUN ICS OR LATER"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LinkLabel2
        '
        Me.LinkLabel2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LinkLabel2.Location = New System.Drawing.Point(12, 75)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(281, 43)
        Me.LinkLabel2.TabIndex = 14
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "2. Install the drivers for your device. (Windows only)"
        '
        'ModeToggleBtn
        '
        Me.ModeToggleBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ModeToggleBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ModeToggleBtn.Location = New System.Drawing.Point(83, 240)
        Me.ModeToggleBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ModeToggleBtn.Name = "ModeToggleBtn"
        Me.ModeToggleBtn.Size = New System.Drawing.Size(65, 28)
        Me.ModeToggleBtn.TabIndex = 15
        Me.ModeToggleBtn.Text = "Wireless"
        Me.ModeToggleBtn.UseVisualStyleBackColor = True
        '
        'IPBox1
        '
        Me.IPBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.IPBox1.Location = New System.Drawing.Point(82, 210)
        Me.IPBox1.MaxLength = 3
        Me.IPBox1.Name = "IPBox1"
        Me.IPBox1.Size = New System.Drawing.Size(36, 20)
        Me.IPBox1.TabIndex = 16
        Me.IPBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.IPBox1.Visible = False
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(55, 210)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(21, 16)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "IP:"
        Me.Label6.Visible = False
        '
        'IPBox2
        '
        Me.IPBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.IPBox2.Location = New System.Drawing.Point(124, 210)
        Me.IPBox2.MaxLength = 3
        Me.IPBox2.Name = "IPBox2"
        Me.IPBox2.Size = New System.Drawing.Size(36, 20)
        Me.IPBox2.TabIndex = 18
        Me.IPBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.IPBox2.Visible = False
        '
        'IPBox3
        '
        Me.IPBox3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.IPBox3.Location = New System.Drawing.Point(166, 210)
        Me.IPBox3.MaxLength = 3
        Me.IPBox3.Name = "IPBox3"
        Me.IPBox3.Size = New System.Drawing.Size(36, 20)
        Me.IPBox3.TabIndex = 19
        Me.IPBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.IPBox3.Visible = False
        '
        'IPBox4
        '
        Me.IPBox4.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.IPBox4.Location = New System.Drawing.Point(208, 210)
        Me.IPBox4.MaxLength = 3
        Me.IPBox4.Name = "IPBox4"
        Me.IPBox4.Size = New System.Drawing.Size(36, 20)
        Me.IPBox4.TabIndex = 20
        Me.IPBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.IPBox4.Visible = False
        '
        'adb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(311, 287)
        Me.Controls.Add(Me.IPBox4)
        Me.Controls.Add(Me.IPBox3)
        Me.Controls.Add(Me.IPBox2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.IPBox1)
        Me.Controls.Add(Me.ModeToggleBtn)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CancelBtn)
        Me.Controls.Add(Me.CaptureBtn)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MinimumSize = New System.Drawing.Size(321, 320)
        Me.Name = "adb"
        Me.Text = "Android Capture Utility"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CaptureBtn As System.Windows.Forms.Button
    Friend WithEvents CancelBtn As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents ModeToggleBtn As System.Windows.Forms.Button
    Friend WithEvents IPBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents IPBox2 As System.Windows.Forms.TextBox
    Friend WithEvents IPBox3 As System.Windows.Forms.TextBox
    Friend WithEvents IPBox4 As System.Windows.Forms.TextBox
End Class
