Public Class adb

	Public platformpath As String

	Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
		platformpath = Nothing
		CaptureBtn.Enabled = False
		Me.Close()
	End Sub

	Private Sub CaptureBtn_Click(sender As Object, e As EventArgs) Handles CaptureBtn.Click

	End Sub

	Private Sub PathFolderBtn_Click(sender As Object, e As EventArgs) Handles PathFolderBtn.Click
		Dim platformpathdialog As New System.Windows.Forms.FolderBrowserDialog
		platformpathdialog.Description = "Select the Folder"
		platformpathdialog.RootFolder = Environment.SpecialFolder.ProgramFiles
		Dim dlgResult As DialogResult = platformpathdialog.ShowDialog()
		If dlgResult = Windows.Forms.DialogResult.OK Then
			platformpath = platformpathdialog.SelectedPath
			toolstextbox.Text = platformpath
			CaptureBtn.Enabled = True
		End If
	End Sub

	Private Sub adb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Me.LinkLabel1.Links.RemoveAt(0)
		Me.LinkLabel1.Links.Add(0, 11, "http://developer.android.com/sdk/index.html")
	End Sub

	Private Sub linkLabel1_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
		Me.LinkLabel1.Links(LinkLabel1.Links.IndexOf(e.Link)).Visited = True
		Dim target As String = CType(e.Link.LinkData, String)
		System.Diagnostics.Process.Start(target)
	End Sub

End Class