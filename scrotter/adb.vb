Public Class adb

    Private platformpath As String
    Public Shared capimage As String

	Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
		platformpath = Nothing
		CaptureBtn.Enabled = False
		Me.Close()
	End Sub

	Public Sub CaptureBtn_Click(sender As Object, e As EventArgs) Handles CaptureBtn.Click
		Dim tempPath As String = System.IO.Path.GetTempPath
		Dim imgcap As New Process With {.StartInfo = _
		New ProcessStartInfo With { _
		.FileName = platformpath & "ADB.EXE ", _
		.Arguments = "pull /dev/graphics/fb0", _
		.WindowStyle = ProcessWindowStyle.Normal}}
		imgcap.Start()
		Dim imgconv As New Process With {.StartInfo = _
		New ProcessStartInfo With { _
		.FileName = platformpath & "ADB.EXE ", _
		.Arguments = "ffmpeg -vframes 1 -f rawvideo -pix_fmt rgb32 -s " & 720 & "x" & 1280 & "-i fb0 " & tempPath & "capture.png", _
		.WindowStyle = ProcessWindowStyle.Normal}}
		imgconv.Start()
		capimage = (tempPath & "capture.png")
		Scrotter.ADBCapture()
		Me.Close()
	End Sub

    Private Sub PathFolderBtn_Click(sender As Object, e As EventArgs) Handles PathFolderBtn.Click
        Dim platformpathdialog As New System.Windows.Forms.FolderBrowserDialog
        platformpathdialog.Description = "Select the Folder"
		platformpathdialog.RootFolder = Environment.SpecialFolder.MyComputer
        Dim dlgResult As DialogResult = platformpathdialog.ShowDialog()
        If dlgResult = Windows.Forms.DialogResult.OK Then
            platformpath = platformpathdialog.SelectedPath
            toolstextbox.Text = platformpath
            CaptureBtn.Enabled = True
        End If
    End Sub

    Private Sub adb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.LinkLabel1.Links.RemoveAt(0)
        Me.LinkLabel1.Links.Add(0, 17, "https://dl.google.com/android/installer_r21.0.1-windows.exe")
    End Sub

    Private Sub linkLabel1_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.LinkLabel1.Links(LinkLabel1.Links.IndexOf(e.Link)).Visited = True
        Dim target As String = CType(e.Link.LinkData, String)
        System.Diagnostics.Process.Start(target)
    End Sub

End Class