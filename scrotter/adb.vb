Imports System.IO

Public Class adb

    Private platformpath As String

    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        Me.Close()
    End Sub

    Public Sub CaptureBtn_Click(sender As Object, e As EventArgs) Handles CaptureBtn.Click
        If Scrotter.IsMono = False Then
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
            If File.Exists(Environment.GetEnvironmentVariable("temp") & "\capture.png") Then
                Scrotter.Image2.Dispose()
                My.Computer.FileSystem.DeleteFile(Environment.GetEnvironmentVariable("temp") & "\capture.png")
            End If
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
        Else
            Dim tempPath As String = "/tmp/"
            Dim imgcap As New Process With {.StartInfo = _
            New ProcessStartInfo With { _
            .FileName = "adb", _
            .Arguments = "shell /system/bin/screencap -p /sdcard/screenshot.png", _
            .WindowStyle = ProcessWindowStyle.Normal}}
            Try
                imgcap.Start()
            Catch ex As Exception
                MsgBox("Unable to find ADB. Did you correctly set the PATH?")
                Exit Sub
            End Try
            imgcap.WaitForExit()
            If File.Exists(tempPath & "capture.png") Then
                Scrotter.Image2.Dispose()
                My.Computer.FileSystem.DeleteFile(tempPath & "capture.png")
            End If
            Dim imgconv As New Process With {.StartInfo = _
            New ProcessStartInfo With { _
            .FileName = "adb", _
            .Arguments = "pull /sdcard/screenshot.png " & tempPath & "capture.png", _
            .WindowStyle = ProcessWindowStyle.Normal}}
            Try
                imgconv.Start()
            Catch ex As Exception
                MsgBox("Unable to retrieve screenshot. Is your machine configured correctly, and is your device properly connected?")
                Exit Sub
            End Try
            imgconv.WaitForExit()
        End If
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
        If Scrotter.IsMono = False Then
            LinkLabel1.Links.RemoveAt(0)
            LinkLabel1.Links.Add(0, 17, "https://dl.google.com/android/installer_r21.0.1-windows.exe")
            LinkLabel2.Links.RemoveAt(0)
            LinkLabel2.Links.Add(3, 35, "http://developer.android.com/tools/extras/oem-usb.html")
        Else
            Label2.Text = "1. First, download and extract the Android platform-tools."
            LinkLabel1.Links.RemoveAt(0)
            LinkLabel1.Links.Add(0, 22, "http://esausilva.com/wp-content/plugins/cimy-counter/cc_redirect.php?cc=platform-tools-linux&fn=http://esausilva.com/misc/android/platform-tools-linux.tar.gz")
            LinkLabel1.Text = "Android platform-tools (2.5MB download, one-time)"
            LinkLabel2.Text = "2. Follow this guide, skipping step 1 and using the above link."
            LinkLabel2.Links.RemoveAt(0)
            LinkLabel2.Links.Add(15, 5, "http://ubuntuforums.org/showthread.php?t=1918512")
            Label3.Text = "3. Plug in your device, wait a minute, and hit ""Capture""."
            Label1.Text = ""
            Label4.Text = ""
            PathFolderBtn.Enabled = False
            toolstextbox.Enabled = False
            CaptureBtn.Enabled = True
        End If
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