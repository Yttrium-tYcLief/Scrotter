Imports System.Runtime.InteropServices


Public Class about

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
End Class