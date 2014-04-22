<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Preferences
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
        Me.PersonalContainer = New System.Windows.Forms.GroupBox()
        Me.AdvancedContainer = New System.Windows.Forms.GroupBox()
        Me.SuspendLayout()
        '
        'PersonalContainer
        '
        Me.PersonalContainer.Location = New System.Drawing.Point(12, 13)
        Me.PersonalContainer.Name = "PersonalContainer"
        Me.PersonalContainer.Size = New System.Drawing.Size(240, 100)
        Me.PersonalContainer.TabIndex = 0
        Me.PersonalContainer.TabStop = False
        Me.PersonalContainer.Text = "Personal"
        '
        'AdvancedContainer
        '
        Me.AdvancedContainer.Location = New System.Drawing.Point(12, 119)
        Me.AdvancedContainer.Name = "AdvancedContainer"
        Me.AdvancedContainer.Size = New System.Drawing.Size(240, 211)
        Me.AdvancedContainer.TabIndex = 1
        Me.AdvancedContainer.TabStop = False
        Me.AdvancedContainer.Text = "Advanced"
        '
        'Preferences
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(264, 342)
        Me.Controls.Add(Me.AdvancedContainer)
        Me.Controls.Add(Me.PersonalContainer)
        Me.Name = "Preferences"
        Me.Text = "Preferences"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PersonalContainer As System.Windows.Forms.GroupBox
    Friend WithEvents AdvancedContainer As System.Windows.Forms.GroupBox
End Class
