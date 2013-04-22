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

Imports System.Net
Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Threading
Imports System.Environment

Public Class Scrotter
    Public Shared OpenPath(7), SavePath As String
    Public OpenStream As Stream = Nothing
    Public SaveStream As Stream = Nothing
    Public PhoneStream As Stream = Nothing
    Public SaveImg As Image
    Public CanvImg(7) As Image
    Public Image2 As New Bitmap(720, 1280)
    Public Shared IsMono As Boolean
    Public ReadOnly Version As String = "0.8"
    Public ReadOnly ReleaseDate As String = "2013-4-22"
    Private Image(7) As String
    Public AppData As String

    Private Sub LoadBtn_Click(sender As Object, e As EventArgs) Handles LoadBtn.Click
        Dim lastfolderopen As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.Title = "Please select your screenshot..."
        openFileDialog1.InitialDirectory = lastfolderopen
        openFileDialog1.Filter = "BMP Files(*.BMP)|*.BMP|PNG Files(*.PNG)|*.PNG|JPG Files(*.JPG)|*.JPG|GIF Files(*.GIF)|*.GIF|All Files(*.*)|*.*"
        openFileDialog1.FilterIndex = 5
        openFileDialog1.RestoreDirectory = True
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            LoadImage.Image = My.Resources._301
            Try
                OpenStream = openFileDialog1.OpenFile()
                If (OpenStream IsNot Nothing) Then
                    OpenPath(ScreenPicker.Value) = openFileDialog1.FileName
                    ScreenshotBox.Text = OpenPath(ScreenPicker.Value)
                    RefreshLists()
                End If
            Catch Ex As Exception
            Finally
                If (OpenStream IsNot Nothing) Then
                    OpenStream.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub Save(sender As Object, e As EventArgs) Handles SaveBtn.Click
        If ScreenAmountPicker.Value > 1 Then
            Dim number As Integer = 1
            Do While number <= ScreenAmountPicker.Value
                If CanvImg(number) Is Nothing Then CanvImg(number) = New Bitmap(CanvImg(1).Width, CanvImg(1).Height)
                number = number + 1
            Loop
            ArrayPreview.ShowDialog()
            Exit Sub
        End If
        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.FileName = "Scrotter_" & DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss") & ".png"
        saveFileDialog1.Filter = "BMP Files(*.BMP)|*.BMP|PNG Files(*.PNG)|*.PNG|JPG Files(*.JPG)|*.JPG|All Files(*.*)|*.*" '|GIF Files(*.GIF)|*.GIF"
        saveFileDialog1.FilterIndex = 2
        saveFileDialog1.RestoreDirectory = True
        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            SaveImg = CanvImg(1)
            SaveStream = saveFileDialog1.OpenFile()
            If (SaveStream IsNot Nothing) Then
                SavePath = saveFileDialog1.FileName
                SaveStream.Close()
                RefreshLists()
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

    Private Sub RefreshLists() Handles ModelBox.SelectedValueChanged
        StretchCheckbox.Enabled = True
        UnderShadowCheckbox.Enabled = True
        GlossCheckbox.Enabled = True
        ShadowCheckbox.Enabled = True
        VariantBox.Enabled = False
        VariantBox.Items.Clear()
        VariantBox.Text = "Variant"
        Select Case ModelBox.Text
            Case "Samsung Galaxy SIII"
                VariantBox.Enabled = True
                VariantBox.Items.AddRange({"White", "Blue", "Red", "Brown", "Black"})
                VariantBox.SelectedIndex = 0
            Case "Google Nexus 7", "Google Nexus 10", "Motorola Xoom"
                VariantBox.Enabled = True
                VariantBox.Items.AddRange({"Portrait", "Landscape"})
                VariantBox.SelectedIndex = 0
            Case "HTC One X, HTC One X+"
                VariantBox.Enabled = True
                VariantBox.Items.AddRange({"White", "Black"})
                VariantBox.SelectedIndex = 0
                UnderShadowCheckbox.Enabled = False
                UnderShadowCheckbox.Checked = False
            Case "Apple iPhone 4", "Apple iPhone 4S", "Apple iPhone 5", "Apple iPad Mini"
                VariantBox.Enabled = True
                VariantBox.Items.AddRange({"Black", "White"})
                VariantBox.SelectedIndex = 0
            Case "Samsung Galaxy SII, Epic 4G Touch"
                VariantBox.Enabled = True
                VariantBox.Items.AddRange({"Model 1", "Model 2"})
                VariantBox.SelectedIndex = 0
            Case "HTC Desire HD, HTC Inspire 4G", "Samsung Galaxy SIII Mini", "Motorola Droid RAZR", "Motorola Droid RAZR M"
                GlossCheckbox.Enabled = False
                GlossCheckbox.Checked = False
                UnderShadowCheckbox.Enabled = False
                UnderShadowCheckbox.Checked = False
            Case "HTC One S", "HTC One V", "Google Nexus 4"
                UnderShadowCheckbox.Enabled = False
                UnderShadowCheckbox.Checked = False
            Case "Apple iPhone 3G, 3GS"
                GlossCheckbox.Enabled = False
                GlossCheckbox.Checked = False
            Case "BlackBerry Z10"
                VariantBox.Enabled = True
                VariantBox.Items.AddRange({"Black", "White"})
                VariantBox.SelectedIndex = 0
                GlossCheckbox.Enabled = False
                GlossCheckbox.Checked = False
                UnderShadowCheckbox.Enabled = False
                UnderShadowCheckbox.Checked = False
            Case "Samsung Galaxy Note II"
                VariantBox.Enabled = True
                VariantBox.Items.AddRange({"White", "Gray"})
                VariantBox.SelectedIndex = 0
                GlossCheckbox.Enabled = False
                GlossCheckbox.Checked = False
                UnderShadowCheckbox.Enabled = False
                UnderShadowCheckbox.Checked = False
        End Select
        RefreshPreview()
    End Sub

    Private Sub RefreshPreview() Handles VariantBox.SelectedValueChanged, ShadowCheckbox.CheckedChanged, GlossCheckbox.CheckedChanged, UnderShadowCheckbox.CheckedChanged, StretchCheckbox.CheckedChanged, ScreenPicker.ValueChanged
        ScreenshotBox.Text = OpenPath(ScreenPicker.Value)
        If ModelBox.Text = "Samsung Galaxy SIII" Then
            Select Case VariantBox.Text
                Case "Black", "Red", "Brown"
                    GlossCheckbox.Enabled = False
                    GlossCheckbox.Checked = False
            End Select
        End If
        If BackgroundDownloader.IsBusy = False Then
            LoadImage.Image = My.Resources._301
            Dim args As ArgumentType = New ArgumentType()
            args.type = 1
            args.var = VariantBox.Text
            args.model = ModelBox.Text
            BackgroundDownloader.RunWorkerAsync(args)
        End If
    End Sub

    Private Sub BackgroundDownloader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundDownloader.DoWork
        Dim args As ArgumentType = e.Argument
        If args.type = 1 Then
            Dim ScreenCapBitmap As New Bitmap(720, 1280)
            Try
                If String.IsNullOrEmpty(OpenPath(ScreenPicker.Value)) = False Then
                    Image(ScreenPicker.Value) = (OpenPath(ScreenPicker.Value))
                    ScreenCapBitmap = New Bitmap(Image(ScreenPicker.Value))
                End If
            Catch ex As Exception
                MsgBox("Unable to load screenshot.")
                Exit Sub
            End Try
            Dim Image1 As New Bitmap(720, 1280)
            Dim Gloss As New Bitmap(720, 1280)
            Dim Undershadow As New Bitmap(720, 1280)
            Dim Shadow As New Bitmap(720, 1280)
            Dim IndexW As Integer = 0
            Dim IndexH As Integer = 0
            Dim Overlay As New Bitmap(720, 1280)
            Dim DeviceName As String = ""
            Dim ShadowRes As String = ""
            Dim GlossUsed As Boolean = False
            Dim UndershadowUsed As Boolean = False
            Dim databaseurl As String = "https://raw.github.com/Yttrium-tYcLief/Scrotter/database/"
            Select Case args.model
                Case "Samsung Galaxy SIII Mini"
                    DeviceName = "SamsungGSIIIMini"
                    ShadowRes = "480x800"
                    IndexW = 78
                    IndexH = 182
                Case "HTC Desire HD, HTC Inspire 4G"
                    DeviceName = "DesireHD"
                    ShadowRes = "480x800"
                    IndexW = 104
                    IndexH = 169
                Case "HTC One X, HTC One X+"
                    If args.var = "Black" Then
                        DeviceName = "OneXBlack"
                        IndexW = 113
                    ElseIf args.var = "White" Then
                        DeviceName = "OneXWhite"
                        IndexW = 115
                    End If
                    UndershadowUsed = True
                    ShadowRes = "720x1280"
                    IndexH = 213
                Case "Samsung Galaxy SIII"
                    IndexW = 88
                    If args.var = "Blue" Then
                        DeviceName = "GSIIIBlue"
                        GlossUsed = True
                    ElseIf args.var = "White" Then
                        DeviceName = "GSIIIWhite"
                        GlossUsed = True
                        IndexW = 84
                    ElseIf args.var = "Black" Then
                        DeviceName = "GSIIIBlack"
                    ElseIf args.var = "Red" Then
                        DeviceName = "GSIIIRed"
                    ElseIf args.var = "Brown" Then
                        DeviceName = "GSIIIBrown"
                    End If
                    UndershadowUsed = True
                    ShadowRes = "720x1280"
                    IndexH = 184
                Case "Google Nexus 10"
                    If args.var = "Portrait" Then
                        DeviceName = "Nexus10Port"
                        ShadowRes = "800x1280"
                        IndexW = 217
                        IndexH = 223
                        Dim imgtmp As New Bitmap(800, 1280)
                        Using graphicsHandle As Graphics = Graphics.FromImage(imgtmp)
                            graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
                            graphicsHandle.DrawImage(ScreenCapBitmap, 0, 0, 800, 1280)
                            ScreenCapBitmap = imgtmp
                        End Using
                    ElseIf args.var = "Landscape" Then
                        DeviceName = "Nexus10Land"
                        ShadowRes = "1280x800"
                        IndexW = 227
                        IndexH = 217
                        Dim imgtmp As New Bitmap(1280, 800)
                        Using graphicsHandle As Graphics = Graphics.FromImage(imgtmp)
                            graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
                            graphicsHandle.DrawImage(ScreenCapBitmap, 0, 0, 1280, 800)
                            ScreenCapBitmap = imgtmp
                        End Using
                    End If
                    GlossUsed = True
                    UndershadowUsed = True
                Case "Motorola Xoom"
                    If args.var = "Portrait" Then
                        DeviceName = "XoomPort"
                        ShadowRes = "800x1280"
                        IndexW = 199
                        IndexH = 200
                    ElseIf args.var = "Landscape" Then
                        DeviceName = "XoomLand"
                        ShadowRes = "1280x800"
                        IndexW = 218
                        IndexH = 191
                    End If
                    GlossUsed = True
                    UndershadowUsed = True
                Case "Samsung Galaxy SII, Epic 4G Touch"
                    If args.var = "Model 1" Then
                        DeviceName = "GSII"
                        IndexH = 191
                    ElseIf args.var = "Model 2" Then
                        DeviceName = "Epic4GTouch"
                        IndexH = 175
                    End If
                    ShadowRes = "480x800"
                    IndexW = 132
                    GlossUsed = True
                    UndershadowUsed = True
                Case "Apple iPhone"
                    DeviceName = "iPhone"
                    ShadowRes = "320x480"
                    GlossUsed = True
                    UndershadowUsed = True
                    IndexW = 89
                    IndexH = 176
                Case "Apple iPhone 3G, 3GS"
                    DeviceName = "iPhone3Gand3GS"
                    ShadowRes = "320x480"
                    UndershadowUsed = True
                    IndexW = 88
                    IndexH = 176
                Case "Apple iPhone 4"
                    If args.var = "Black" Then
                        DeviceName = "iPhone4Black"
                    ElseIf args.var = "White" Then
                        DeviceName = "iPhone4White"
                    End If
                    ShadowRes = "640x960"
                    IndexW = 62
                    IndexH = 264
                    GlossUsed = True
                    UndershadowUsed = True
                Case "Apple iPhone 4S"
                    If args.var = "Black" Then
                        DeviceName = "iPhone4SBlack"
                    ElseIf args.var = "White" Then
                        DeviceName = "iPhone4SWhite"
                    End If
                    ShadowRes = "640x960"
                    IndexW = 62
                    IndexH = 264
                    GlossUsed = True
                    UndershadowUsed = True
                Case "Apple iPhone 5"
                    If args.var = "Black" Then
                        DeviceName = "iPhone5Black"
                        'Overlay = FetchImage("http://ompldr.org/vaDZhNQ/iPhone5Black.png")
                    ElseIf args.var = "White" Then
                        DeviceName = "iPhone5White"
                        'Overlay = FetchImage("http://ompldr.org/vaDZhNg/iPhone5White.png")
                    End If
                    ShadowRes = "640x1136"
                    IndexW = 133
                    IndexH = 287
                    GlossUsed = True
                    UndershadowUsed = True
                Case "Samsung Google Galaxy Nexus"
                    DeviceName = "GalaxyNexus"
                    ShadowRes = "720x1280"
                    IndexW = 155
                    IndexH = 263
                    GlossUsed = True
                    UndershadowUsed = True
                Case "Samsung Galaxy Note II"
                    If args.var = "White" Then
                        DeviceName = "GalaxyNoteII"
                    ElseIf args.var = "Gray" Then
                        DeviceName = "GalaxyNoteIIGray"
                    End If
                    IndexW = 49
                    IndexH = 140
                    ShadowRes = "720x1280"
                Case "Motorola Droid RAZR"
                    DeviceName = "DroidRAZR"
                    ShadowRes = "r540960"
                    IndexW = 150
                    IndexH = 206
                Case "Google Nexus 7"
                    If args.var = "Portrait" Then
                        DeviceName = "Nexus7Port"
                        ShadowRes = "800x1280"
                        IndexW = 264
                        IndexH = 311
                    ElseIf args.var = "Landscape" Then
                        DeviceName = "Nexus7Land"
                        ShadowRes = "1280x800"
                        IndexW = 315
                        IndexH = 270
                    End If
                    GlossUsed = True
                    UndershadowUsed = True
                Case "HTC One S"
                    DeviceName = "OneS"
                    ShadowRes = "540x960"
                    IndexW = 106
                    IndexH = 228
                    GlossUsed = True
                Case "HTC One V"
                    DeviceName = "OneV"
                    ShadowRes = "480x800"
                    IndexW = 85
                    IndexH = 165
                    GlossUsed = True
                Case "Google Nexus S"
                    DeviceName = "NexusS"
                    ShadowRes = "480x800"
                    IndexW = 45
                    IndexH = 165
                    GlossUsed = True
                Case "Google Nexus 4"
                    DeviceName = "Nexus4"
                    ShadowRes = "768x1280"
                    IndexW = 45
                    IndexH = 193
                    GlossUsed = True
                Case "Motorola Droid RAZR M"
                    DeviceName = "DroidRazrM"
                    ShadowRes = "540x960"
                    IndexW = 49
                    IndexH = 129
                Case "BlackBerry Z10"
                    If args.var = "Black" Then
                        DeviceName = "Z10Black"
                    ElseIf args.var = "White" Then
                        DeviceName = "Z10White"
                    End If
                    ShadowRes = "768x1280"
                    IndexW = 111
                    IndexH = 300
            End Select
            Image1 = FetchImage(databaseurl & "Device/" & DeviceName & ".png")
            If UndershadowUsed = True Then Undershadow = FetchImage(databaseurl & "Undershadow/" & DeviceName & ".png")
            If GlossUsed = True Then Gloss = FetchImage(databaseurl & "Gloss/" & DeviceName & ".png")
            Shadow = FetchImage(databaseurl & "Shadow/" & ShadowRes & ".png")
            If StretchCheckbox.Checked = True Then
                Dim imgtmp2 As New Bitmap(Shadow.Width, Shadow.Height)
                Using graphicsHandle As Graphics = Graphics.FromImage(imgtmp2)
                    graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
                    graphicsHandle.DrawImage(ScreenCapBitmap, 0, 0, Shadow.Width, Shadow.Height)
                    ScreenCapBitmap = imgtmp2
                End Using
            End If
            Dim Background As New Bitmap(Image1.Width, Image1.Height)
            Dim Image3 As New Bitmap(Image1.Width, Image1.Height, PixelFormat.Format32bppArgb)
            Dim g As Graphics = Graphics.FromImage(Image3)
            g.Clear(Color.Transparent)
            g.DrawImage(Background, New Point(0, 0))
            If UnderShadowCheckbox.Checked = True Then g.DrawImage(Undershadow, New Point(0, 0))
            g.DrawImage(ScreenCapBitmap, New Point(IndexW, IndexH))
            If ShadowCheckbox.Checked = True Then g.DrawImage((Shadow), New Point(IndexW, IndexH))
            g.DrawImage(Image1, New Point(0, 0))
            If GlossCheckbox.Checked = True Then g.DrawImage(Gloss, New Point(0, 0))
            ' If (args.model = "Apple iPhone 5") Then g.DrawImage(Overlay, New Point(0, 0))
            g.Dispose()
            g = Nothing
            CanvImg(ScreenPicker.Value) = Image3
        End If
    End Sub

    Public Class ArgumentType
        Public type As Integer
        Public var As String
        Public model As String
    End Class

    Private Function FetchImage(ByVal url As String)
        Try
            Return New Bitmap(New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(url))))
        Catch ex As Exception
        End Try
        Return New Bitmap(720, 1280)
    End Function

    Private Sub BackgroundDownloader_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundDownloader.RunWorkerCompleted
        Preview.Image = CanvImg(ScreenPicker.Value)
        LoadImage.Image = Nothing
    End Sub

    Private Sub CaptureBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CaptureBtn.Click
        adb.ShowDialog()
    End Sub

    Public Shared Sub ADBCapture()
        If Scrotter.IsMono = False Then OpenPath(Scrotter.ScreenPicker.Value) = (Environment.GetEnvironmentVariable("temp") & Path.DirectorySeparatorChar & "capture.png") Else OpenPath(Scrotter.ScreenPicker.Value) = Path.DirectorySeparatorChar & "tmp" & Path.DirectorySeparatorChar & "capture.png"
        Scrotter.RefreshLists()
    End Sub

    Private Sub Scrotter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim t As Type = Type.[GetType]("Mono.Runtime")
        If t Is Nothing Then IsMono = False Else IsMono = True
        about.CheckForUpdates(False)
        If IsMono = False Then AppData = System.IO.Directory.Exists(SpecialFolder.ApplicationData & ".scrotter/") Else System.IO.Directory.Exists(SpecialFolder.Personal & ".scrotter/") 'Per-platform specifics are not usually good as code should be consistent, but this is okay for directory structures
        System.IO.Directory.CreateDirectory(AppData)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        about.ShowDialog()
    End Sub

    Private Sub ScreenAmountPicker_ValueChanged(sender As Object, e As EventArgs) Handles ScreenAmountPicker.ValueChanged
        If ScreenAmountPicker.Value > 1 Then
            ScreenPicker.Maximum = ScreenAmountPicker.Value
            SaveBtn.Text = "Save Multiple Screens As..."
        Else
            ScreenPicker.Value = 1
            ScreenPicker.Maximum = 1
            SaveBtn.Text = "Save As..."
        End If
    End Sub

    Private Sub EnableMultipleScreens(sender As Object, e As EventArgs) Handles ModelBox.TextChanged
        ScreenAmountPicker.Enabled = True
        ScreenPicker.Enabled = True
    End Sub

End Class
