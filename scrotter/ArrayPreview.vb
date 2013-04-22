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

Imports System.Drawing.Imaging
Imports System.IO
Imports System.Drawing.Drawing2D

Public Class ArrayPreview

    Public PhonesImg, SaveImg As Image
    Public SaveStream As Stream = Nothing
    Public OpenStream As Stream = Nothing
    Public SavePath, OpenPath As String
    Public ImgBackgroundColor As Color = Color.Transparent

    Private Sub RefreshOptions(sender As Object, e As EventArgs) Handles BackgroundType.TextChanged
        BackgroundLoadBtn.Enabled = False
        ColorPickBtn.Enabled = False
        Label2.Enabled = False
        ImagePatternPicker.Enabled = False
        Select Case BackgroundType.Text
            Case "Transparent"
            Case "Solid Color"
                ColorPickBtn.Enabled = True
            Case "Load Image"
                BackgroundLoadBtn.Enabled = True
                Label2.Enabled = True
                ImagePatternPicker.Enabled = True
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

    Private Sub RefreshPreview() Handles ImagePatternPicker.TextChanged
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
                Dim BackgroundImg As Bitmap
                BackgroundImg = New Bitmap(1, 1)
                If String.IsNullOrEmpty(OpenPath) = False Then BackgroundImg = New Bitmap(OpenPath)
                Dim Tmpimg As New Bitmap(New Bitmap(PhonesImg.Width, PhonesImg.Height))
                Dim g As Graphics = Graphics.FromImage(Tmpimg)
                g.Clear(Color.Transparent)
                Select Case ImagePatternPicker.Text
                    Case "Single"
                        g.DrawImage(BackgroundImg, New Point(0, 0))
                    Case "Stretch"
                        Dim tmpbackgroundimg As New Bitmap(PhonesImg.Width, PhonesImg.Height)
                        Dim resizedimg As New Bitmap(BackgroundImg.Width, BackgroundImg.Height)
                        Using graphicsHandle As Graphics = Graphics.FromImage(tmpbackgroundimg)
                            graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
                            graphicsHandle.DrawImage(BackgroundImg, 0, 0, PhonesImg.Width, PhonesImg.Height)
                            resizedimg = tmpbackgroundimg
                            g.DrawImage(resizedimg, New Point(0, 0))
                        End Using
                    Case "Tile"
                        Dim TileBrush As New TextureBrush(BackgroundImg)
                        TileBrush.WrapMode = Drawing2D.WrapMode.Tile
                        Dim tmpbackgroundimg As New Bitmap(PhonesImg.Width, PhonesImg.Height)
                        Dim tiledimg As New Bitmap(PhonesImg.Width, PhonesImg.Height)
                        Using formgraphics As Graphics = Graphics.FromImage(tmpbackgroundimg)
                            formgraphics.FillRectangle(TileBrush, New Rectangle(0, 0, PhonesImg.Width, PhonesImg.Height))
                            tiledimg = tmpbackgroundimg
                            g.DrawImage(tiledimg, New Point(0, 0))
                        End Using
                    Case "Zoom"
                        Dim conformtodim As Boolean = False 'False = height, true = width
                        'Dim toobig As Boolean = False
                        Dim resizedimg As New Bitmap(0, 0)
                        If ((BackgroundImg.Width / BackgroundImg.Height) < (PhonesImg.Width / PhonesImg.Height)) Then conformtodim = True
                        'If BackgroundImg.Width > PhonesImg.Width And BackgroundImg.Height > PhonesImg.Height Then toobig = True
                        'If toobig = False Then
                        Dim ratio As New Integer
                        If conformtodim = False Then
                            ratio = (PhonesImg.Width / BackgroundImg.Width)
                            Dim tmpbackgroundimg As New Bitmap(ratio * BackgroundImg.Width, ratio * BackgroundImg.Height)
                            Using graphicsHandle As Graphics = Graphics.FromImage(tmpbackgroundimg)
                                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
                                graphicsHandle.DrawImage(resizedimg, 0, 0, (ratio * BackgroundImg.Width), (ratio * BackgroundImg.Height))
                                resizedimg = tmpbackgroundimg
                            End Using
                            g.DrawImage(resizedimg, New Point((0 - ((PhonesImg.Width - resizedimg.Width) / 2)), 0))
                        Else
                            ratio = (PhonesImg.Height / BackgroundImg.Height)
                            Dim tmpbackgroundimg As New Bitmap(ratio * BackgroundImg.Width, ratio * BackgroundImg.Height)
                            Using graphicsHandle As Graphics = Graphics.FromImage(tmpbackgroundimg)
                                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
                                graphicsHandle.DrawImage(resizedimg, 0, 0, (ratio * BackgroundImg.Width), (ratio * BackgroundImg.Height))
                                resizedimg = tmpbackgroundimg
                            End Using
                            g.DrawImage(resizedimg, New Point(0, (0 - ((PhonesImg.Height - resizedimg.Height) / 2))))
                        End If
                        'Else
                        'insertpointw = 0 - ((BackgroundImg.Width - PhonesImg.Width) / 2)
                        'insertpointh = 0 - ((BackgroundImg.Height - PhonesImg.Height) / 2)
                        'End If
                End Select
                g.DrawImage(PhonesImg, New Point(0, 0))
                g.Dispose()
                g = Nothing
                SaveImg = Tmpimg
        End Select
        Preview.Image = SaveImg
    End Sub

    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.FileName = "Scrotter_" & DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss") & ".png"
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
                ElseIf Filetype = 2 Then
                    'Dim Image3 As New Bitmap(bm.Width, bm.Height)
                    'Dim g As Graphics = Graphics.FromImage(Image3)
                    'g.Clear(Color.White)
                    'g.DrawImage(bm, New Point(0, 0))
                    'g.Dispose()
                    'g = Nothing
                    'Image3.Save(SavePath, System.Drawing.Imaging.ImageFormat.Gif)
                    Me.Close()
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
            Dim invertcolor As Color = Color.FromArgb(255 - ImgBackgroundColor.R, 255 - ImgBackgroundColor.G, 255 - ImgBackgroundColor.B)
            Dim luma As Integer = CInt(invertcolor.R * 0.3 + invertcolor.G * 0.59 + invertcolor.B * 0.11)
            ColorPickBtn.BackColor = ImgBackgroundColor
            ColorPickBtn.ForeColor = Color.FromArgb(luma, luma, luma)
            RefreshPreview()
        End If
    End Sub

    Private Sub BackgroundLoadBtn_Click(sender As Object, e As EventArgs) Handles BackgroundLoadBtn.Click
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