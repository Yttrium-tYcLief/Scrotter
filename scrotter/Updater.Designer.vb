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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Updater))
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
        Me.VersionLabel.Font = New System.Drawing.Font("Ubuntu", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VersionLabel.Location = New System.Drawing.Point(13, 11)
        Me.VersionLabel.Name = "VersionLabel"
        Me.VersionLabel.Size = New System.Drawing.Size(519, 53)
        Me.VersionLabel.TabIndex = 0
        Me.VersionLabel.Text = "You are currently on v, but the newest version is v. If you do not update," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "some " & _
    "images may no longer work. Would you like to update?" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'HistoryBoxLabel
        '
        Me.HistoryBoxLabel.AutoSize = True
        Me.HistoryBoxLabel.Location = New System.Drawing.Point(10, 51)
        Me.HistoryBoxLabel.Name = "HistoryBoxLabel"
        Me.HistoryBoxLabel.Size = New System.Drawing.Size(61, 13)
        Me.HistoryBoxLabel.TabIndex = 2
        Me.HistoryBoxLabel.Text = "Changelog:"
        '
        'ChangelogBtn
        '
        Me.ChangelogBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChangelogBtn.Location = New System.Drawing.Point(12, 244)
        Me.ChangelogBtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ChangelogBtn.Name = "ChangelogBtn"
        Me.ChangelogBtn.Size = New System.Drawing.Size(136, 23)
        Me.ChangelogBtn.TabIndex = 1
        Me.ChangelogBtn.Text = "View Full Changelog"
        Me.ChangelogBtn.UseVisualStyleBackColor = True
        '
        'LicenseBtn
        '
        Me.LicenseBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LicenseBtn.Location = New System.Drawing.Point(154, 244)
        Me.LicenseBtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.LicenseBtn.Name = "LicenseBtn"
        Me.LicenseBtn.Size = New System.Drawing.Size(94, 23)
        Me.LicenseBtn.TabIndex = 2
        Me.LicenseBtn.Text = "License"
        Me.LicenseBtn.UseVisualStyleBackColor = True
        '
        'NoBtn
        '
        Me.NoBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NoBtn.Location = New System.Drawing.Point(298, 244)
        Me.NoBtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.NoBtn.Name = "NoBtn"
        Me.NoBtn.Size = New System.Drawing.Size(114, 23)
        Me.NoBtn.TabIndex = 3
        Me.NoBtn.Text = "Update Later"
        Me.NoBtn.UseVisualStyleBackColor = True
        '
        'YesBtn
        '
        Me.YesBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.YesBtn.Location = New System.Drawing.Point(418, 244)
        Me.YesBtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.YesBtn.Name = "YesBtn"
        Me.YesBtn.Size = New System.Drawing.Size(114, 23)
        Me.YesBtn.TabIndex = 4
        Me.YesBtn.Text = "Update Now"
        Me.YesBtn.UseVisualStyleBackColor = True
        '
        'ProgressBar
        '
        Me.ProgressBar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar.Location = New System.Drawing.Point(298, 244)
        Me.ProgressBar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(234, 23)
        Me.ProgressBar.TabIndex = 6
        Me.ProgressBar.Visible = False
        '
        'HistoryBox
        '
        Me.HistoryBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HistoryBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HistoryBox.Font = New System.Drawing.Font("Ubuntu Mono", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HistoryBox.Location = New System.Drawing.Point(12, 66)
        Me.HistoryBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.HistoryBox.Name = "HistoryBox"
        Me.HistoryBox.ReadOnly = True
        Me.HistoryBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.HistoryBox.Size = New System.Drawing.Size(520, 174)
        Me.HistoryBox.TabIndex = 7
        Me.HistoryBox.Text = ""
        '
        'Updater
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 277)
        Me.ControlBox = False
        Me.Controls.Add(Me.HistoryBox)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.YesBtn)
        Me.Controls.Add(Me.NoBtn)
        Me.Controls.Add(Me.LicenseBtn)
        Me.Controls.Add(Me.ChangelogBtn)
        Me.Controls.Add(Me.HistoryBoxLabel)
        Me.Controls.Add(Me.VersionLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MinimumSize = New System.Drawing.Size(510, 201)
        Me.Name = "Updater"
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
