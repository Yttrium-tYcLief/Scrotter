Public Class adb

    Private platformpath As String

	Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
		platformpath = Nothing
		CaptureBtn.Enabled = False
		Me.Close()
	End Sub

    Public Sub CaptureBtn_Click(sender As Object, e As EventArgs) Handles CaptureBtn.Click
        Dim tempPath As String = Environment.GetEnvironmentVariable("Temp")
        Dim imgcap As New Process With {.StartInfo = _
        New ProcessStartInfo With { _
        .FileName = platformpath & "\adb.exe", _
        .Arguments = "shell /system/bin/screencap -p /sdcard/screenshot.png", _
        .WindowStyle = ProcessWindowStyle.Normal}}
        imgcap.Start()
        imgcap.WaitForExit()
        Dim imgconv As New Process With {.StartInfo = _
        New ProcessStartInfo With { _
        .FileName = platformpath & "\adb.exe", _
        .Arguments = "pull /sdcard/screenshot.png " & tempPath & "\capture.png", _
        .WindowStyle = ProcessWindowStyle.Normal}}
        imgconv.Start()
        imgconv.WaitForExit()
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