'Scrotter, a program designed by yttrium to frame mobile screenshots.
'Copyright (C) 2013 Alex West
'Version 0.8 Beta
'
'This program is free software; you can redistribute it and/or
'modify it under the terms of the GNU General Public License
'as published by the Free Software Foundation; either version 2
'of the License, or (at your option) any later version.
'
'This program is distributed in the hope that it will be useful,
'but WITHOUT ANY WARRANTY; without even the implied warranty of
'MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'GNU General Public License for more details.
'
'The GNU General Public License may be read at http://www.gnu.org/licenses/gpl-2.0.html.

Imports System.Runtime.InteropServices
Imports System.Net
Imports System.Security.Cryptography.X509Certificates
Imports System.Net.Security

Public Class about

    Dim l As String

    Private Sub frm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Dim i As String = "UpUpDownDownLeftRightLeftRightBA"
        If (e.KeyCode.ToString = "Up") And (l <> "Up") Then l = ""
        l = l & e.KeyCode.ToString
        If l = i Then UpdateButton.Text = "install gentoo"
        If e.KeyCode.ToString = "Return" Then l = ""
        If l.Length > 60 Then l = ""
    End Sub

    <Runtime.InteropServices.StructLayout(Runtime.InteropServices.LayoutKind.Sequential)> Public Structure Side
        Public Left As Integer
        Public Right As Integer
        Public Top As Integer
        Public Bottom As Integer
    End Structure
    <Runtime.InteropServices.DllImport("dwmapi.dll")> Public Shared Function DwmExtendFrameIntoClientArea(ByVal hWnd As IntPtr, ByRef pMarinset As Side) As Integer
    End Function

    Private Sub about_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Scrotter v" & Scrotter.Version & "  (" & Scrotter.ReleaseDate & ")"
        Try
            Me.BackColor = Color.Black 'It must be set to black...
            Dim Side As Side = New Side
            Side.Left = -1
            Side.Right = -1
            Side.Top = -1
            Side.Bottom = -1
            Dim result As Integer = DwmExtendFrameIntoClientArea(Me.Handle, Side)
        Catch ex As Exception
        End Try
        WebsiteBox.TabIndex = 1
    End Sub

    Private Const WM_NCLBUTTONDOWN = &HA1
    Private Const HTCAPTION = 2

    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
                 (ByVal hwnd As Integer, ByVal wMsg As Integer, _
                  ByVal wParam As Integer, ByVal lParam As String) As Integer
    Private Declare Sub ReleaseCapture Lib "user32" ()

    Private Sub Panel1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        Dim lHwnd As Int32
        lHwnd = Me.Handle
        If lHwnd = 0 Then Exit Sub
        ReleaseCapture()
        SendMessage(lHwnd, WM_NCLBUTTONDOWN, HTCAPTION, 0&)
    End Sub

    Private Sub GithubBox_Click(sender As Object, e As EventArgs) Handles GithubBox.Click
        System.Diagnostics.Process.Start("https://github.com/Yttrium-tYcLief/Scrotter")
    End Sub

    Private Sub ReportBugBox_Click(sender As Object, e As EventArgs) Handles ReportBugBox.Click
        System.Diagnostics.Process.Start("https://github.com/Yttrium-tYcLief/Scrotter/issues")
    End Sub

    Private Sub LicenseBox_Click(sender As Object, e As EventArgs) Handles LicenseBox.Click
        System.Diagnostics.Process.Start("https://github.com/Yttrium-tYcLief/Scrotter/blob/master/LICENSE.creole")
    End Sub

    Private Sub WebsiteBox_Click(sender As Object, e As EventArgs) Handles WebsiteBox.Click
        System.Diagnostics.Process.Start("http://yttrium-tyclief.github.com/Scrotter/")
    End Sub

    Private Sub UpdateButton_Click(sender As Object, e As EventArgs) Handles UpdateButton.Click
        If UpdateButton.Text = "install gentoo" Then System.Diagnostics.Process.Start("http://www.gentoo.org/doc/en/handbook/handbook-x86.xml?part=1") Else CheckForUpdates(True)
    End Sub

    Public Shared Sub CheckForUpdates(prompt As Boolean)
        ServicePointManager.ServerCertificateValidationCallback = AddressOf Validator
        Dim wc As New WebClient
        Dim Version As String
        Dim Updater As Integer
        Version = wc.DownloadString("https://raw.github.com/Yttrium-tYcLief/Scrotter/master/latest/latest")
        If Version > Scrotter.Version Then
            Updater = MessageBox.Show("You are currently on v" & Scrotter.Version & ", but the newest version is v" & Version & "." & vbNewLine & "Would you like to download the latest update?" & vbNewLine & "If you do not update, some images may no longer work.", "Updater", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If Updater = vbYes Then
                System.Diagnostics.Process.Start("https://github.com/Yttrium-tYcLief/Scrotter/raw/master/latest/scrotter.exe")
                If prompt = False Then
                    Scrotter.Close()
                End If
            Else
                GoTo final
            End If
        Else
            If prompt = True Then
                MessageBox.Show("You are on the latest official version.", "Updater", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
final:
    End Sub

    Public Shared Function Validator(sender As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) As Boolean
        Return True
    End Function

    Private Sub about_closing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        UpdateButton.Text = "Check for updates..."
    End Sub

End Class