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
        Me.CaptureBtn = New System.Windows.Forms.Button()
        Me.CancelBtn = New System.Windows.Forms.Button()
        Me.PathFolderBtn = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.toolstextbox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'CaptureBtn
        '
        Me.CaptureBtn.Enabled = False
        Me.CaptureBtn.Location = New System.Drawing.Point(115, 214)
        Me.CaptureBtn.Name = "CaptureBtn"
        Me.CaptureBtn.Size = New System.Drawing.Size(144, 23)
        Me.CaptureBtn.TabIndex = 0
        Me.CaptureBtn.Text = "Capture"
        Me.CaptureBtn.UseVisualStyleBackColor = True
        '
        'CancelBtn
        '
        Me.CancelBtn.Location = New System.Drawing.Point(15, 215)
        Me.CancelBtn.Name = "CancelBtn"
        Me.CancelBtn.Size = New System.Drawing.Size(75, 23)
        Me.CancelBtn.TabIndex = 2
        Me.CancelBtn.Text = "Cancel"
        Me.CancelBtn.UseVisualStyleBackColor = True
        '
        'PathFolderBtn
        '
        Me.PathFolderBtn.Location = New System.Drawing.Point(15, 186)
        Me.PathFolderBtn.Name = "PathFolderBtn"
        Me.PathFolderBtn.Size = New System.Drawing.Size(75, 23)
        Me.PathFolderBtn.TabIndex = 5
        Me.PathFolderBtn.Text = "Browse..."
        Me.PathFolderBtn.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(247, 30)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "1. First, install the Android SDK Tools below."
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(17, 40)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(229, 13)
        Me.LinkLabel1.TabIndex = 8
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Android SDK Tools (73MB download, one-time)"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(247, 82)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "2. Launch the SDK Manager at the end of setup. Check ""Android SDK platform-tools""" & _
    " and click ""Install 1 package"". Hit ""accept"", and once it finishes, close it." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'toolstextbox
        '
        Me.toolstextbox.Location = New System.Drawing.Point(116, 186)
        Me.toolstextbox.Name = "toolstextbox"
        Me.toolstextbox.ReadOnly = True
        Me.toolstextbox.Size = New System.Drawing.Size(143, 20)
        Me.toolstextbox.TabIndex = 10
        Me.toolstextbox.Text = "platform-tools"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 122)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(247, 28)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "3. Hit ""Browse..."" and find the platform-tools folder created in the SDK Tools di" & _
    "rectory."
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(12, 153)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(247, 32)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "4. Plug in your device, wait a minute, and hit ""Capture""."
        '
        'adb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(271, 250)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.toolstextbox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PathFolderBtn)
        Me.Controls.Add(Me.CancelBtn)
        Me.Controls.Add(Me.CaptureBtn)
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
End Class
