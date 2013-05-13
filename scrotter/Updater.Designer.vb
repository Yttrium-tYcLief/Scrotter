<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Updater
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
        Me.VersionLabel = New System.Windows.Forms.Label()
        Me.HistoryBoxLabel = New System.Windows.Forms.Label()
        Me.ChangelogBtn = New System.Windows.Forms.Button()
        Me.LicenseBtn = New System.Windows.Forms.Button()
        Me.NoBtn = New System.Windows.Forms.Button()
        Me.YesBtn = New System.Windows.Forms.Button()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.HistoryBox = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'VersionLabel
        '
        Me.VersionLabel.AutoSize = True
        Me.VersionLabel.Font = New System.Drawing.Font("Ubuntu", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VersionLabel.Location = New System.Drawing.Point(13, 13)
        Me.VersionLabel.Name = "VersionLabel"
        Me.VersionLabel.Size = New System.Drawing.Size(378, 32)
        Me.VersionLabel.TabIndex = 0
        Me.VersionLabel.Text = "You are currently on v#, but the newest version is v#. If you do not update," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "som" & _
    "e images may no longer work. Would you like to update?" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'HistoryBoxLabel
        '
        Me.HistoryBoxLabel.AutoSize = True
        Me.HistoryBoxLabel.Location = New System.Drawing.Point(13, 57)
        Me.HistoryBoxLabel.Name = "HistoryBoxLabel"
        Me.HistoryBoxLabel.Size = New System.Drawing.Size(63, 16)
        Me.HistoryBoxLabel.TabIndex = 2
        Me.HistoryBoxLabel.Text = "Changelog:"
        '
        'ChangelogBtn
        '
        Me.ChangelogBtn.Location = New System.Drawing.Point(12, 201)
        Me.ChangelogBtn.Name = "ChangelogBtn"
        Me.ChangelogBtn.Size = New System.Drawing.Size(136, 28)
        Me.ChangelogBtn.TabIndex = 1
        Me.ChangelogBtn.Text = "View Full Changelog"
        Me.ChangelogBtn.UseVisualStyleBackColor = True
        '
        'LicenseBtn
        '
        Me.LicenseBtn.Location = New System.Drawing.Point(154, 201)
        Me.LicenseBtn.Name = "LicenseBtn"
        Me.LicenseBtn.Size = New System.Drawing.Size(94, 28)
        Me.LicenseBtn.TabIndex = 2
        Me.LicenseBtn.Text = "License"
        Me.LicenseBtn.UseVisualStyleBackColor = True
        '
        'NoBtn
        '
        Me.NoBtn.Location = New System.Drawing.Point(298, 201)
        Me.NoBtn.Name = "NoBtn"
        Me.NoBtn.Size = New System.Drawing.Size(114, 28)
        Me.NoBtn.TabIndex = 3
        Me.NoBtn.Text = "Update Later"
        Me.NoBtn.UseVisualStyleBackColor = True
        '
        'YesBtn
        '
        Me.YesBtn.Location = New System.Drawing.Point(418, 201)
        Me.YesBtn.Name = "YesBtn"
        Me.YesBtn.Size = New System.Drawing.Size(114, 28)
        Me.YesBtn.TabIndex = 4
        Me.YesBtn.Text = "Update Now"
        Me.YesBtn.UseVisualStyleBackColor = True
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(298, 201)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(234, 28)
        Me.ProgressBar.TabIndex = 6
        Me.ProgressBar.Visible = False
        '
        'HistoryBox
        '
        Me.HistoryBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HistoryBox.Font = New System.Drawing.Font("Ubuntu Mono", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HistoryBox.Location = New System.Drawing.Point(12, 76)
        Me.HistoryBox.Name = "HistoryBox"
        Me.HistoryBox.ReadOnly = True
        Me.HistoryBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.HistoryBox.Size = New System.Drawing.Size(520, 119)
        Me.HistoryBox.TabIndex = 7
        Me.HistoryBox.Text = ""
        '
        'Updater
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 241)
        Me.ControlBox = False
        Me.Controls.Add(Me.HistoryBox)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.YesBtn)
        Me.Controls.Add(Me.NoBtn)
        Me.Controls.Add(Me.LicenseBtn)
        Me.Controls.Add(Me.ChangelogBtn)
        Me.Controls.Add(Me.HistoryBoxLabel)
        Me.Controls.Add(Me.VersionLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Updater"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "  New Update Available"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents VersionLabel As System.Windows.Forms.Label
    Friend WithEvents HistoryBoxLabel As System.Windows.Forms.Label
    Friend WithEvents ChangelogBtn As System.Windows.Forms.Button
    Friend WithEvents LicenseBtn As System.Windows.Forms.Button
    Friend WithEvents NoBtn As System.Windows.Forms.Button
    Friend WithEvents YesBtn As System.Windows.Forms.Button
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents HistoryBox As System.Windows.Forms.RichTextBox
End Class
