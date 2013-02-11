Imports System.IO
Imports System.Net

Public Class adb

    Private adbpath As String = (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & Path.DirectorySeparatorChar & "Scrotter" & Path.DirectorySeparatorChar & "adb.exe")
    Private adbwinapipath As String = (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & Path.DirectorySeparatorChar & "Scrotter" & Path.DirectorySeparatorChar & "AdbWinApi.dll")
    Private adbwinusbapipath As String = (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & Path.DirectorySeparatorChar & "Scrotter" & Path.DirectorySeparatorChar & "AdbWinUsbApi.dll")
    Private Wireless As Boolean = False
    Private customgray As Color = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
    Private customteal As Color = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(152, Byte), Integer))

    Private Sub CancelBtn()
        Me.Close()
    End Sub

    Public Sub CaptureBtn()
        If Scrotter.IsMono = False Then
            If File.Exists(adbpath) = False Or File.Exists(adbwinapipath) = False Or File.Exists(adbwinusbapipath) = False Then
                MsgBox("Unable to locate ADB. Did you download it?")
                Exit Sub
            End If
            If Wireless = True Then
                Dim wirelessconnect As New Process With {.StartInfo = _
                New ProcessStartInfo With { _
                .FileName = adbpath, _
                .Arguments = "connect " & IPBox1.Text & "." & IPBox2.Text & "." & IPBox3.Text & "." & IPBox4.Text, _
                .WindowStyle = ProcessWindowStyle.Hidden}}
                Try
                    wirelessconnect.Start()
                Catch ex As Exception
                    MsgBox("Unable to connect to device. Is adbWireless enabled and are you on the same network?")
                    Exit Sub
                End Try
                wirelessconnect.WaitForExit()
            End If
            Dim tempPath As String = Environment.GetEnvironmentVariable("Temp")
            Dim imgcap As New Process With {.StartInfo = _
            New ProcessStartInfo With { _
            .FileName = adbpath, _
            .Arguments = "shell " & Path.DirectorySeparatorChar & "system" & Path.DirectorySeparatorChar & "bin" & Path.DirectorySeparatorChar & "screencap -p " & Path.DirectorySeparatorChar & "sdcard" & Path.DirectorySeparatorChar & "screenshot.png", _
            .WindowStyle = ProcessWindowStyle.Hidden}}
            Try
                imgcap.Start()
            Catch ex As Exception
                MsgBox("Unable to take screenshot. Are you running ICS or later?")
                Exit Sub
            End Try
            imgcap.WaitForExit()
            If File.Exists(Environment.GetEnvironmentVariable("temp") & Path.DirectorySeparatorChar & "capture.png") Then
                Scrotter.Image2.Dispose()
                My.Computer.FileSystem.DeleteFile(Environment.GetEnvironmentVariable("temp") & Path.DirectorySeparatorChar & "capture.png")
            End If
            Dim imgconv As New Process With {.StartInfo = _
            New ProcessStartInfo With { _
            .FileName = adbpath, _
            .Arguments = "pull " & Path.DirectorySeparatorChar & "sdcard" & Path.DirectorySeparatorChar & "screenshot.png " & tempPath & Path.DirectorySeparatorChar & "capture.png", _
            .WindowStyle = ProcessWindowStyle.Hidden}}
            Try
                imgconv.Start()
            Catch ex As Exception
                MsgBox("Unable to retrieve screenshot. Are the drivers for your device installed, and is your device properly connected?")
                Exit Sub
            End Try
            imgconv.WaitForExit()
        Else
            Dim tempPath As String = Path.DirectorySeparatorChar & "tmp" & Path.DirectorySeparatorChar
            Dim imgcap As New Process With {.StartInfo = _
            New ProcessStartInfo With { _
            .FileName = "adb", _
            .Arguments = "shell " & Path.DirectorySeparatorChar & "system" & Path.DirectorySeparatorChar & "bin" & Path.DirectorySeparatorChar & "screencap -p " & Path.DirectorySeparatorChar & "sdcard" & Path.DirectorySeparatorChar & "screenshot.png", _
            .WindowStyle = ProcessWindowStyle.Hidden}}
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
            .Arguments = "pull " & Path.DirectorySeparatorChar & "sdcard" & Path.DirectorySeparatorChar & "screenshot.png " & tempPath & "capture.png", _
            .WindowStyle = ProcessWindowStyle.Hidden}}
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

    Private Sub adb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Scrotter.IsMono = False Then
            LinkLabel1.Links.RemoveAt(0)
            LinkLabel1.Links.Add(0, 20, "")
            LinkLabel2.Links.RemoveAt(0)
            LinkLabel2.Links.Add(3, 35, "http://developer.android.com/tools/extras/oem-usb.html")
        Else
            ModeToggleBtnLabel.Visible = False
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
        End If
    End Sub

    Private Sub linkLabel1_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.LinkLabel1.Links(LinkLabel1.Links.IndexOf(e.Link)).Visited = True
        If Scrotter.IsMono = False Then
            If (System.IO.Directory.Exists((Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & Path.DirectorySeparatorChar & "Scrotter"))) = False Then System.IO.Directory.CreateDirectory((Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & Path.DirectorySeparatorChar & "Scrotter"))
        Using webClient = New WebClient()
            Dim bytes = webClient.DownloadData("https://dl.dropbox.com/s/x2jx44l3h3a4t5e/adb.exe")
            File.WriteAllBytes((adbpath), bytes)
            bytes = webClient.DownloadData("https://dl.dropbox.com/s/xuc6r4fjhl2ye60/AdbWinApi.dll")
            File.WriteAllBytes((adbwinapipath), bytes)
            bytes = webClient.DownloadData("https://dl.dropbox.com/s/db2f6ha8waca2fm/AdbWinUsbApi.dll")
            File.WriteAllBytes((adbwinusbapipath), bytes)
        End Using
        MsgBox("Download complete.")
        Else
        Dim target As String = CType(e.Link.LinkData, String)
        System.Diagnostics.Process.Start(target)
        End If
    End Sub

    Private Sub linkLabel2_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Me.LinkLabel2.Links(LinkLabel2.Links.IndexOf(e.Link)).Visited = True
        Dim target As String = CType(e.Link.LinkData, String)
        System.Diagnostics.Process.Start(target)
    End Sub

    Private Sub ModeToggleBtn()
        If Wireless = True Then
            Wireless = False
            ModeToggleBtnLabel.Text = "Wireless"
            Label6.Visible = False
            IPBox1.Visible = False
            IPBox2.Visible = False
            IPBox3.Visible = False
            IPBox4.Visible = False
            LinkLabel2.Text = "2. Install the drivers for your device. (Windows only)"
            LinkLabel2.Links.RemoveAt(0)
            LinkLabel2.Links.Add(3, 35, "http://developer.android.com/tools/extras/oem-usb.html")
            Label3.Text = "3. Launch the SDK Manager at the end of setup. Check ""Android SDK platform-tools"" and click ""Install 1 package"". Hit ""accept"", and once it finishes, close it."
            Label1.Text = "4. Hit ""Browse..."" and find the platform-tools folder created in the SDK Tools directory."
            Label4.Text = "5. Plug in your device, wait a minute, and hit ""Capture""."
        Else
            Wireless = True
            ModeToggleBtnLabel.Text = "Wired"
            Label6.Visible = True
            IPBox1.Visible = True
            IPBox2.Visible = True
            IPBox3.Visible = True
            IPBox4.Visible = True
            LinkLabel2.Text = "2. Install adbWireless from the Play Store."
            LinkLabel2.Links.RemoveAt(0)
            LinkLabel2.Links.Add(32, 10, "https://play.google.com/store/apps/details?id=com.teamboid.adbwireless")
            Label3.Text = "3. Launch adbWireless and, after connecting to the same network as your computer, enable it."
            Label1.Text = "4. Type in the IP shown on your device below, and then hit Capture."
            Label4.Text = ""
        End If
    End Sub

    Private Sub IPBox1_TextChanged(sender As Object, e As EventArgs) Handles IPBox1.LostFocus
        Select Case IPBox1.Text
            Case Is > 255
                IPBox1.Text = 255
            Case Is < 0
                IPBox1.Text = 0
        End Select
    End Sub

    Private Sub IPBox2_TextChanged(sender As Object, e As EventArgs) Handles IPBox2.LostFocus
        Select Case IPBox2.Text
            Case Is > 255
                IPBox2.Text = 255
            Case Is < 0
                IPBox2.Text = 0
        End Select
    End Sub

    Private Sub IPBox3_TextChanged(sender As Object, e As EventArgs) Handles IPBox3.LostFocus
        Select Case IPBox3.Text
            Case Is > 255
                IPBox3.Text = 255
            Case Is < 0
                IPBox3.Text = 0
        End Select
    End Sub

    Private Sub IPBox4_TextChanged(sender As Object, e As EventArgs) Handles IPBox4.LostFocus
        Select Case IPBox4.Text
            Case Is > 255
                IPBox4.Text = 255
            Case Is < 0
                IPBox4.Text = 0
        End Select
    End Sub

    Private Sub IPBox1_Refocus(sender As Object, e As EventArgs) Handles IPBox1.TextChanged
        If Len(IPBox1.Text) = 3 Then
            IPBox2.Focus()
            IPBox2.SelectAll()
            IPBox1_TextChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub IPBox2_Refocus(sender As Object, e As EventArgs) Handles IPBox2.TextChanged
        If Len(IPBox2.Text) = 3 Then
            IPBox3.Focus()
            IPBox3.SelectAll()
            IPBox2_TextChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub IPBox3_Refocus(sender As Object, e As EventArgs) Handles IPBox3.TextChanged
        If Len(IPBox3.Text) = 3 Then
            IPBox4.Focus()
            IPBox4.SelectAll()
            IPBox3_TextChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub CancelBtnLabel_MouseDown(sender As Object, e As EventArgs) Handles CancelBtnBox.MouseDown, CancelBtnLabel.MouseDown
        CancelBtnBox.BackColor = customteal
        CancelBtnLabel.BackColor = customteal
    End Sub

    Private Sub CancelBtnBox_MouseUp(sender As Object, e As EventArgs) Handles CancelBtnBox.MouseUp, CancelBtnLabel.MouseUp
        CancelBtnBox.BackColor = customgray
        CancelBtnLabel.BackColor = customgray
        CancelBtn()
    End Sub

    Private Sub ModeToggleBtnBox_MouseDown(sender As Object, e As EventArgs) Handles ModeToggleBtnBox.MouseDown, ModeToggleBtnLabel.MouseDown
        If Scrotter.IsMono = False Then
            ModeToggleBtnBox.BackColor = customteal
            ModeToggleBtnLabel.BackColor = customteal
        End If
    End Sub

    Private Sub ModeToggleBtnBox_MouseUp(sender As Object, e As EventArgs) Handles ModeToggleBtnBox.MouseUp, ModeToggleBtnLabel.MouseUp
        If Scrotter.IsMono = False Then
            ModeToggleBtnBox.BackColor = customgray
            ModeToggleBtnLabel.BackColor = customgray
            ModeToggleBtn()
        End If
    End Sub

    Private Sub CaptureBtnBox_MouseDown(sender As Object, e As EventArgs) Handles CaptureBtnBox.MouseDown, CaptureBtnLabel.MouseDown
        CaptureBtnBox.BackColor = customteal
        CaptureBtnLabel.BackColor = customteal
    End Sub

    Private Sub CaptureBtnBox_MouseUp(sender As Object, e As EventArgs) Handles CaptureBtnBox.MouseUp, CaptureBtnLabel.MouseUp
        CaptureBtnBox.BackColor = customgray
        CaptureBtnLabel.BackColor = customgray
        CaptureBtn()
    End Sub

End Class