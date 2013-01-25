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

    Dim newPoint As New System.Drawing.Point()
    Dim a As Integer
    Dim b As Integer
    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        a = Me.MousePosition.X - Me.Location.X
        b = Me.MousePosition.Y - Me.Location.Y
    End Sub
    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        If e.Button = MouseButtons.Left Then
            newPoint = Me.MousePosition
            newPoint.X = newPoint.X - (a)
            newPoint.Y = newPoint.Y - (b)
            Me.Location = newPoint
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub
End Class