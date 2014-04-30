Imports System.IO
Imports System.Net
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates

Public Class Updater
    Private Version As String
    Dim tmppath As String = System.IO.Path.GetTempFileName
    Dim tmppath2 As String = Path.Combine(System.IO.Path.GetTempPath, System.IO.Path.GetRandomFileName)
    Private Sub Updater_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ServicePointManager.ServerCertificateValidationCallback = AddressOf Validator
        Dim wc As New WebClient
        Try
            Version = wc.DownloadString("https://raw.github.com/Yttrium-tYcLief/Scrotter/master/latest/latest")
            Dim VersionNumsCurrent(2), VersionNumsNew(2) As Integer
            VersionNumsCurrent = Array.ConvertAll(Scrotter.Version.Split("."), Function(str) Int32.Parse(str))
            VersionNumsNew = Array.ConvertAll(Version.Split("."), Function(str) Int32.Parse(str))

            If VersionNumsCurrent(0) < VersionNumsNew(0) Or (VersionNumsCurrent(0) = VersionNumsNew(0) And VersionNumsCurrent(1) < VersionNumsNew(1)) Or (VersionNumsCurrent(0) = VersionNumsNew(0) And VersionNumsCurrent(1) = VersionNumsNew(1) And VersionNumsCurrent(2) < VersionNumsNew(2)) Then
                VersionLabel.Text = "You are currently on v" & Scrotter.Version & ", but the newest version is v" & Version.Replace(vbCr, "").Replace(vbLf, "") & ". If you do not update, some images may no longer work. Would you like to update?"
                HistoryBox.Text = wc.DownloadString("https://raw.github.com/Yttrium-tYcLief/Scrotter/master/changelog")
                HistoryBox.Text = HistoryBox.Text.Substring(HistoryBox.Text.IndexOf(Version), HistoryBox.Text.IndexOf(Scrotter.Version) - HistoryBox.Text.IndexOf(Version) - 1)
            Else
                Me.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub YesBtn_Click(sender As Object, e As EventArgs) Handles YesBtn.Click
        ProgressBar.Visible = True
        Dim client As New WebClient()
        AddHandler client.DownloadProgressChanged, AddressOf client_ProgressChanged
        AddHandler client.DownloadFileCompleted, AddressOf client_DownloadFileCompleted
        client.DownloadFileAsync(New Uri("https://github.com/Yttrium-tYcLief/Scrotter/raw/master/latest/scrotter.exe"), tmppath)
    End Sub

    Public Sub client_ProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        Dim bytesIn As Double = Double.Parse(e.BytesReceived.ToString())
        Dim totalBytes As Double = Double.Parse(e.TotalBytesToReceive.ToString())
        Dim percentage As Double = bytesIn / totalBytes * 100
        ProgressBar.Value = Integer.Parse(Math.Truncate(percentage).ToString())
    End Sub

    Public Sub client_DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        File.Replace(tmppath, Application.ExecutablePath, tmppath2)
        Application.Restart()
    End Sub

    Private Sub NoBtn_Click(sender As Object, e As EventArgs) Handles NoBtn.Click
        Me.Close()
    End Sub
    Private Sub LicenseBtn_Click(sender As Object, e As EventArgs) Handles LicenseBtn.Click
        System.Diagnostics.Process.Start("https://raw.githubusercontent.com/Yttrium-tYcLief/Scrotter/master/LICENSE")
    End Sub
    Private Sub ChangelogBtn_Click(sender As Object, e As EventArgs) Handles ChangelogBtn.Click
        System.Diagnostics.Process.Start("https://raw.github.com/Yttrium-tYcLief/Scrotter/master/changelog")
    End Sub

    Public Shared Function Validator(sender As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) As Boolean
        Return True
    End Function
End Class