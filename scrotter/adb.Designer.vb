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
        Me.PathFolderBtn = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.toolstextbox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'CaptureBtn
        '
        Me.CaptureBtn.Enabled = False
        Me.CaptureBtn.Location = New System.Drawing.Point(93, 267)
        Me.CaptureBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CaptureBtn.Name = "CaptureBtn"
        Me.CaptureBtn.Size = New System.Drawing.Size(200, 28)
        Me.CaptureBtn.TabIndex = 0
        Me.CaptureBtn.Text = "Capture"
        Me.CaptureBtn.UseVisualStyleBackColor = True
        '
        'CancelBtn
        '
        Me.CancelBtn.Location = New System.Drawing.Point(12, 267)
        Me.CancelBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CancelBtn.Name = "CancelBtn"
        Me.CancelBtn.Size = New System.Drawing.Size(75, 28)
        Me.CancelBtn.TabIndex = 2
        Me.CancelBtn.Text = "Cancel"
        Me.CancelBtn.UseVisualStyleBackColor = True
        '
        'PathFolderBtn
        '
        Me.PathFolderBtn.Location = New System.Drawing.Point(12, 231)
        Me.PathFolderBtn.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PathFolderBtn.Name = "PathFolderBtn"
        Me.PathFolderBtn.Size = New System.Drawing.Size(75, 28)
        Me.PathFolderBtn.TabIndex = 5
        Me.PathFolderBtn.Text = "Browse..."
        Me.PathFolderBtn.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(281, 37)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "1. First, install the Android SDK Tools below."
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(17, 65)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(239, 16)
        Me.LinkLabel1.TabIndex = 8
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Android SDK Tools (73MB download, one-time)"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(281, 101)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "2. Launch the SDK Manager at the end of setup. Check ""Android SDK platform-tools""" & _
    " and click ""Install 1 package"". Hit ""accept"", and once it finishes, close it." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'toolstextbox
        '
        Me.toolstextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.toolstextbox.Location = New System.Drawing.Point(93, 234)
        Me.toolstextbox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.toolstextbox.Name = "toolstextbox"
        Me.toolstextbox.ReadOnly = True
        Me.toolstextbox.Size = New System.Drawing.Size(200, 20)
        Me.toolstextbox.TabIndex = 10
        Me.toolstextbox.Text = "platform-tools"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 143)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(281, 34)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "3. Hit ""Browse..."" and find the platform-tools folder created in the SDK Tools di" & _
    "rectory."
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(12, 186)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(281, 39)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "4. Plug in your device, wait a minute, and hit ""Capture""."
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Ubuntu", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(17, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(276, 16)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "YOUR DEVICE MUST RUN ICS OR LATER"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'adb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(305, 308)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.toolstextbox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PathFolderBtn)
        Me.Controls.Add(Me.CancelBtn)
        Me.Controls.Add(Me.CaptureBtn)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "adb"
        Me.Text = "Android Capture Utility"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
	Friend WithEvents CaptureBtn As System.Windows.Forms.Button
	Friend WithEvents CancelBtn As System.Windows.Forms.Button
	Friend WithEvents PathFolderBtn As System.Windows.Forms.Button
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents toolstextbox As System.Windows.Forms.TextBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
