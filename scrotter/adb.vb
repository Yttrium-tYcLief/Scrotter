Public Class adb

    Private platformpath As String

	Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
		Me.Close()
	End Sub

    Public Sub CaptureBtn_Click(sender As Object, e As EventArgs) Handles CaptureBtn.Click
        Dim tempPath As String = Environment.GetEnvironmentVariable("Temp")
        Dim imgcap As New Process With {.StartInfo = _
        New ProcessStartInfo With { _
        .FileName = platformpath & "\adb.exe", _
        .Arguments = "shell /system/bin/screencap -p /sdcard/screenshot.png", _
        .WindowStyle = ProcessWindowStyle.Normal}}
		Try
			imgcap.Start()
		Catch ex As Exception
			MsgBox("Unable to find ADB. Did you select the platform-tools folder?")
			Exit Sub
		End Try
        imgcap.WaitForExit()
        Dim imgconv As New Process With {.StartInfo = _
        New ProcessStartInfo With { _
        .FileName = platformpath & "\adb.exe", _
        .Arguments = "pull /sdcard/screenshot.png " & tempPath & "\capture.png", _
        .WindowStyle = ProcessWindowStyle.Normal}}
		Try
			imgconv.Start()
		Catch ex As Exception
			MsgBox("Unable to retrieve screenshot. Are the drivers for your device installed, and is your device properly connected?")
			Exit Sub
		End Try
        imgconv.WaitForExit()
        Scrotter.ADBCapture()
        Me.Close()
    End Sub

    Private Sub PathFolderBtn_Click(sender As Object, e As EventArgs) Handles PathFolderBtn.Click
        Dim platformpathdialog As New System.Windows.Forms.FolderBrowserDialog
        platformpathdialog.Description = "Select the Folder"
		platformpathdialog.RootFolder = Environment.SpecialFolder.MyComputer
		platformpathdialog.SelectedPath = "C:\Users\" & SystemInformation.UserName & "AppData\Local\Android\android-sdk\platform-tools"
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
        Me.LinkLabel2.Links.RemoveAt(0)
        Me.LinkLabel2.Links.Add(3, 35, "http://developer.android.com/tools/extras/oem-usb.html")
    End Sub

    Private Sub linkLabel1_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.LinkLabel1.Links(LinkLabel1.Links.IndexOf(e.Link)).Visited = True
        Dim target As String = CType(e.Link.LinkData, String)
        System.Diagnostics.Process.Start(target)
    End Sub

    Private Sub linkLabel2_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Me.LinkLabel2.Links(LinkLabel2.Links.IndexOf(e.Link)).Visited = True
        Dim target As String = CType(e.Link.LinkData, String)
        System.Diagnostics.Process.Start(target)
    End Sub

End Class