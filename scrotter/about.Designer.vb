<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class about
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(about))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LicenseBox = New System.Windows.Forms.PictureBox()
        Me.ReportBugBox = New System.Windows.Forms.PictureBox()
        Me.GithubBox = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.LicenseBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportBugBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GithubBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.Controls.Add(Me.LicenseBox)
        Me.Panel1.Controls.Add(Me.ReportBugBox)
        Me.Panel1.Controls.Add(Me.GithubBox)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(640, 335)
        Me.Panel1.TabIndex = 1
        '
        'LicenseBox
        '
        Me.LicenseBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LicenseBox.Location = New System.Drawing.Point(555, 300)
        Me.LicenseBox.Name = "LicenseBox"
        Me.LicenseBox.Size = New System.Drawing.Size(64, 18)
        Me.LicenseBox.TabIndex = 2
        Me.LicenseBox.TabStop = False
        '
        'ReportBugBox
        '
        Me.ReportBugBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ReportBugBox.Location = New System.Drawing.Point(426, 300)
        Me.ReportBugBox.Name = "ReportBugBox"
        Me.ReportBugBox.Size = New System.Drawing.Size(108, 18)
        Me.ReportBugBox.TabIndex = 1
        Me.ReportBugBox.TabStop = False
        '
        'GithubBox
        '
        Me.GithubBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.GithubBox.Location = New System.Drawing.Point(346, 300)
        Me.GithubBox.Name = "GithubBox"
        Me.GithubBox.Size = New System.Drawing.Size(61, 18)
        Me.GithubBox.TabIndex = 0
        Me.GithubBox.TabStop = False
        '
        'about
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(640, 335)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "about"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Scrotter"
        Me.Panel1.ResumeLayout(False)
        CType(Me.LicenseBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportBugBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GithubBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LicenseBox As System.Windows.Forms.PictureBox
    Friend WithEvents ReportBugBox As System.Windows.Forms.PictureBox
    Friend WithEvents GithubBox As System.Windows.Forms.PictureBox
End Class
