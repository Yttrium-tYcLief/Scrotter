Imports System.Drawing.Imaging
Imports System.IO

Public Class ArrayPreview

    Public PhonesImg, SaveImg As Image
    Public BackgroundImg As Bitmap
    Public SaveStream As Stream = Nothing
    Public OpenStream As Stream = Nothing
    Public SavePath, OpenPath As String
    Public ImgBackgroundColor As Color = Color.Transparent

    Private Sub RefreshOptions(sender As Object, e As EventArgs) Handles BackgroundType.TextChanged
        BackgroundLoadBtn.Enabled = False
        ColorPickBtn.Enabled = False
        BackgroundImageBox.Enabled = False
        Select Case BackgroundType.Text
            Case "Transparent"
            Case "Solid Color"
                ColorPickBtn.Enabled = True
            Case "Load Image"
                BackgroundLoadBtn.Enabled = True
                BackgroundImageBox.Enabled = True
        End Select
        RefreshPreview()
    End Sub

    Private Sub ArrayPreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Tmpimg As New Bitmap(New Bitmap((Scrotter.CanvImg(1).Width * Scrotter.ScreenAmountPicker.Value), Scrotter.CanvImg(1).Height, PixelFormat.Format32bppArgb))
        Dim g As Graphics = Graphics.FromImage(Tmpimg)
        g.Clear(Color.Transparent)
        Dim number As Integer = 1
        Do While number <= Scrotter.ScreenAmountPicker.Value
            g.DrawImage(Scrotter.CanvImg(number), New Point((Scrotter.CanvImg(1).Width * number) - Scrotter.CanvImg(1).Width, 0))
            number = number + 1
        Loop
        g.Dispose()
        g = Nothing
        PhonesImg = Tmpimg
        RefreshPreview()
    End Sub

    Private Sub RefreshPreview()
        Select Case BackgroundType.Text
            Case "Transparent"
                SaveImg = PhonesImg
            Case "Solid Color"
                Dim Tmpimg As New Bitmap(New Bitmap(PhonesImg.Width, PhonesImg.Height, PixelFormat.Format32bppArgb))
                Dim g As Graphics = Graphics.FromImage(Tmpimg)
                g.Clear(ImgBackgroundColor)
                g.DrawImage(PhonesImg, New Point(0, 0))
                g.Dispose()
                g = Nothing
                SaveImg = Tmpimg
            Case "Load Image"
                BackgroundImg = New Bitmap(OpenPath)
                Dim Tmpimg As New Bitmap(New Bitmap(PhonesImg.Width, PhonesImg.Height, PixelFormat.Format32bppArgb))
                Dim g As Graphics = Graphics.FromImage(Tmpimg)
                g.Clear(Color.Transparent)
                g.DrawImage(BackgroundImg, New Point(0, 0))
                g.DrawImage(PhonesImg, New Point(0, 0))
                g.Dispose()
                g = Nothing
                SaveImg = Tmpimg
        End Select
        Preview.Image = SaveImg
    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.Filter = "BMP Files(*.BMP)|*.BMP|PNG Files(*.PNG)|*.PNG|JPG Files(*.JPG)|*.JPG|All Files(*.*)|*.*" '|GIF Files(*.GIF)|*.GIF"
        saveFileDialog1.FilterIndex = 2
        saveFileDialog1.RestoreDirectory = True
        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            SaveStream = saveFileDialog1.OpenFile()
            If (SaveStream IsNot Nothing) Then
                SavePath = saveFileDialog1.FileName
                SaveStream.Close()
                Dim Filetype As Integer = saveFileDialog1.FilterIndex
                Dim bm As Bitmap = SaveImg
                If Filetype = 1 Then
                    Dim Image3 As New Bitmap(bm.Width, bm.Height)
                    Dim g As Graphics = Graphics.FromImage(Image3)
                    g.Clear(Color.White)
                    g.DrawImage(bm, New Point(0, 0))
                    g.Dispose()
                    g = Nothing
                    Image3.Save(SavePath, System.Drawing.Imaging.ImageFormat.Bmp)
                ElseIf Filetype = 2 Then
                    bm.Save(SavePath, System.Drawing.Imaging.ImageFormat.Png)
                ElseIf Filetype = 3 Then
                    Dim jgpEncoder As ImageCodecInfo = GetEncoder(ImageFormat.Jpeg)
                    Dim myEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality
                    Dim myEncoderParameters As New EncoderParameters(1)
                    Dim myEncoderParameter As New EncoderParameter(myEncoder, 98&)
                    myEncoderParameters.Param(0) = myEncoderParameter
                    Dim Image3 As New Bitmap(bm.Width, bm.Height)
                    Dim g As Graphics = Graphics.FromImage(Image3)
                    g.Clear(Color.White)
                    g.DrawImage(bm, New Point(0, 0))
                    g.Dispose()
                    g = Nothing
                    Image3.Save(SavePath, jgpEncoder, myEncoderParameters)
                    'ElseIf Filetype = 2 Then
                    'Dim Image3 As New Bitmap(bm.Width, bm.Height)
                    'Dim g As Graphics = Graphics.FromImage(Image3)
                    'g.Clear(Color.White)
                    'g.DrawImage(bm, New Point(0, 0))
                    'g.Dispose()
                    'g = Nothing
                    'Image3.Save(SavePath, System.Drawing.Imaging.ImageFormat.Gif)
                End If
            End If
        End If
    End Sub

    Private Function GetEncoder(ByVal format As ImageFormat) As ImageCodecInfo
        Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageDecoders()

        Dim codec As ImageCodecInfo
        For Each codec In codecs
            If codec.FormatID = format.Guid Then
                Return codec
            End If
        Next codec
        Return Nothing
    End Function

    Private Sub ColorPickBtn_Click(sender As Object, e As EventArgs) Handles ColorPickBtn.Click
        Dim result As DialogResult = ColorDialog.ShowDialog()
        If result = DialogResult.OK Then
            ImgBackgroundColor = ColorDialog.Color
            ColorPreview.BackColor = ImgBackgroundColor
            RefreshPreview()
        End If
    End Sub

    Private Sub BackgroundLoadBtn_Click(sender As Object, e As EventArgs)
        Dim lastfolderopen As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.Title = "Please select your background..."
        openFileDialog1.InitialDirectory = lastfolderopen
        openFileDialog1.Filter = "BMP Files(*.BMP)|*.BMP|PNG Files(*.PNG)|*.PNG|JPG Files(*.JPG)|*.JPG|All Files(*.*)|*.*"
        openFileDialog1.FilterIndex = 4
        openFileDialog1.RestoreDirectory = True
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                OpenStream = openFileDialog1.OpenFile()
                If (OpenStream IsNot Nothing) Then
                    OpenPath = openFileDialog1.FileName
                    BackgroundImageBox.Text = OpenPath
                    RefreshPreview()
                End If
            Catch Ex As Exception
            Finally
                If (OpenStream IsNot Nothing) Then
                    OpenStream.Close()
                End If
            End Try
        End If
    End Sub
End Class