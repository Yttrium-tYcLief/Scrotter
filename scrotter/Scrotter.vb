'Scrotter, a program designed by yttrium to frame mobile screenshots.
'Copyright (C) 2013 Alex West
'Version 0.1 Public Beta
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

Public Class Scrotter

    Public Shared OpenPath, SavePath As String
    Public OpenStream As Stream = Nothing
    Public SaveStream As Stream = Nothing
    Public PhoneStream As Stream = Nothing
    Public SaveImg As Image = Nothing

    Private Sub LoadBtn_Click(sender As Object, e As EventArgs) Handles LoadBtn.Click
        Dim lastfolderopen As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.Title = "Please select your screenshot..."
        openFileDialog1.InitialDirectory = lastfolderopen
        openFileDialog1.Filter = "BMP Files(*.BMP)|*.BMP|PNG Files(*.PNG)|*.PNG|JPG Files(*.JPG)|*.JPG|GIF Files(*.GIF)|*.GIF"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            LoadImage.Image = My.Resources._301
            Try
                OpenStream = openFileDialog1.OpenFile()
                If (OpenStream IsNot Nothing) Then
                    OpenPath = openFileDialog1.FileName
                    ScreenshotBox.Text = OpenPath
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
        Dim saveFileDialog1 As New SaveFileDialog()

        saveFileDialog1.Filter = "BMP Files(*.BMP)|*.BMP|PNG Files(*.PNG)|*.PNG|JPG Files(*.JPG)|*.JPG" '|GIF Files(*.GIF)|*.GIF"
        saveFileDialog1.FilterIndex = 3
        saveFileDialog1.RestoreDirectory = True

        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
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
        UnderShadowCheckbox.Enabled = True
        GlossCheckbox.Enabled = True
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
            Case "Apple iPhone 4", "Apple iPhone 4S", "Apple iPhone 5"
                VariantBox.Enabled = True
                VariantBox.Items.AddRange({"Black", "White"})
                VariantBox.SelectedIndex = 0
            Case "Samsung Galaxy SII, Epic 4G Touch"
                VariantBox.Enabled = True
                VariantBox.Items.AddRange({"Model 1", "Model 2"})
                VariantBox.SelectedIndex = 0
            Case "HTC Desire HD, HTC Inspire 4G", "Samsung Galaxy SIII Mini", "Motorola Droid RAZR", "Motorola Droid RAZR M", "HP TouchPad", "HP Veer", "HTC Evo 3D", "HTC Vivid", "HTC Desire", "Samsung Galaxy Ace, Galaxy Cooper", "Sony Ericsson Xperia J", "LG Nitro HD, Spectrum, Optimus LTE/LTE L-01D/True HD LTE/LTE II", "Samsung Galaxy SII Skyrocket", "HTC Evo 4G LTE"
                GlossCheckbox.Enabled = False
                GlossCheckbox.Checked = False
                UnderShadowCheckbox.Enabled = False
                UnderShadowCheckbox.Checked = False
            Case "HTC One S", "HTC One V", "Samsung Galaxy Note II", "Google Nexus 4", "HTC Google Nexus One", "HTC Legend", "HTC Droid DNA", "Nokia N9"
                UnderShadowCheckbox.Enabled = False
                UnderShadowCheckbox.Checked = False
            Case "Apple iPhone 3G, 3GS"
                GlossCheckbox.Enabled = False
                GlossCheckbox.Checked = False
            Case "Sony Ericsson Xperia X10"
                VariantBox.Enabled = True
                VariantBox.Items.AddRange({"Black", "White"})
                VariantBox.SelectedIndex = 0
                GlossCheckbox.Enabled = False
                GlossCheckbox.Checked = False
                UnderShadowCheckbox.Enabled = False
                UnderShadowCheckbox.Checked = False
            Case "HTC Desire Z, T-Mobile G2", "Samsung Galaxy Tab 10.1"
                VariantBox.Enabled = True
                VariantBox.Items.AddRange({"Portrait", "Landscape"})
                VariantBox.SelectedIndex = 1
                GlossCheckbox.Enabled = False
                GlossCheckbox.Checked = False
                UnderShadowCheckbox.Enabled = False
                UnderShadowCheckbox.Checked = False
            Case "Samsung Droid Charge, Galaxy S Aviator, Galaxy S Lightray 4G"""
                VariantBox.Enabled = True
                VariantBox.Items.AddRange({"Model 1", "Model 2"})
                VariantBox.SelectedIndex = 0
                GlossCheckbox.Enabled = False
                GlossCheckbox.Checked = False
                UnderShadowCheckbox.Enabled = False
                UnderShadowCheckbox.Checked = False
            Case "Nokia Lumia 920"
                VariantBox.Enabled = True
                VariantBox.Items.AddRange({"Red", "Cyan", "Yellow", "Black", "White", "Grey"})
                VariantBox.SelectedIndex = 0
        End Select

        RefreshPreview()
    End Sub

    Private Sub RefreshPreview() Handles VariantBox.SelectedValueChanged, ShadowCheckbox.CheckedChanged, GlossCheckbox.CheckedChanged, UnderShadowCheckbox.CheckedChanged
        If BackgroundDownloader.IsBusy = False Then
            LoadImage.Image = My.Resources._301
            Dim args As ArgumentType = New ArgumentType()
            args.type = 1
            args.var = VariantBox.Text
            args.model = ModelBox.Text
            BackgroundDownloader.RunWorkerAsync(args)
            ShadowCheckbox.Enabled = True
        End If
    End Sub

    Private Sub BackgroundDownloader_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundDownloader.DoWork
        Dim args As ArgumentType = e.Argument
        If args.type = 1 Then
			Dim Image2 As New Bitmap(720, 1280)
			Try
				If String.IsNullOrEmpty(OpenPath) = False Then Image2 = New Bitmap(OpenPath)
			Catch ex As Exception
				MsgBox("Unable to retrieve screenshot. Are the drivers for your device installed, and is your device properly connected?")
				Exit Sub
			End Try
            Dim Image1 As New Bitmap(Image2)
            Dim Shadow As New Bitmap(New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData("http://ompldr.org/vaDJmbw/1280x720.png"))))
            Dim Gloss As New Bitmap(720, 1280)
            Dim Undershadow As New Bitmap(720, 1280)
            Dim IndexW As Integer = 0
            Dim IndexH As Integer = 0
            Dim Overlay As New Bitmap(720, 1280)
            Dim r320480 As String = "http://103.imagebam.com/download/fMTlGS2hf2yruDFhmTf4Ng/23245/232441277/320x480.png"
            Dim r480800 As String = "http://106.imagebam.com/download/F9adygThCFRUS6W77QbOpA/23245/232441280/480x800.png"
            Dim r480854 As String = "http://ompldr.org/vaDQzag/854x480.png"
            Dim r540960 As String = "http://107.imagebam.com/download/YhiAJ97ttnBH6Cry3vunsg/23245/232441281/540x960.png"
            Dim r640960 As String = "http://104.imagebam.com/download/ULwqOUIcom-pbM6ODaij_A/23245/232441284/640x960.png"
            Dim r6401136 As String = "http://107.imagebam.com/download/RndCBtk9guLnIAXusAaaWQ/23245/232441290/640x1136.png"
            Dim r7201280 As String = "http://102.imagebam.com/download/xeX7cVyvK1Xm0azSM9Oc6g/23245/232441293/720x1280.png"
            Dim r7681280 As String = "http://104.imagebam.com/download/kladtG0tmUNkYB_IyP7NIw/23245/232441298/768x1280.png"
            Dim r800480 As String = "http://ompldr.org/vaDY4Mg/800x480.png"
            Dim r8001280 As String = "http://104.imagebam.com/download/AMmyrqvT4tRMwJuO186JVA/23245/232443308/800x1280.png"
            Dim r1024768 As String = "http://ompldr.org/vaDQ1eg/1024x768.png"
            Dim r1280800 As String = "http://106.imagebam.com/download/gtT3LsbDEEYKFSzYfEKIoA/23245/232443312/1280x800.png"
            Dim r10801920 As String = "http://ompldr.org/vaDVxdA/1080x1920.png"
            Select Case args.model
                Case "Samsung Galaxy SIII Mini"
                    Image1 = FetchImage("http://103.imagebam.com/download/n6WF-5Igpqn605HhKYbmzQ/23245/232444262/GSIIIMini.png")
                    Shadow = FetchImage(r480800)
                    IndexW = 78
                    IndexH = 182
                Case "HTC Desire HD, HTC Inspire 4G"
                    Image1 = FetchImage("http://103.imagebam.com/download/Y3UBuWo3KwUIk12J9nWzhw/23245/232444224/DesireHD.png")
                    Shadow = FetchImage(r480800)
                    IndexW = 104
                    IndexH = 169
                Case "HTC One X, HTC One X+"
                    If args.var = "Black" Then
                        Image1 = FetchImage("http://ompldr.org/vaDU3cQ/OneXBlack.png")
                        Gloss = FetchImage("http://101.imagebam.com/download/--FEg5N-X5Y6nV-4phRoTg/23245/232446246/OneXBlack.png")
                        IndexW = 113
                    ElseIf args.var = "White" Then
                        Image1 = FetchImage("http://ompldr.org/vaDU3cg/OneXWhite.png")
                        Gloss = FetchImage("http://102.imagebam.com/download/wKBWy425OEAiViV-1_L2JQ/23245/232446251/OneXWhite.png")
                        IndexW = 115
                    End If
                    Shadow = FetchImage(r7201280)
                    IndexH = 213
                Case "Samsung Galaxy SIII"
                    If args.var = "Blue" Then
                        Image1 = FetchImage("http://103.imagebam.com/download/eC8ggZEPojCVayfCF43vpQ/23245/232444255/GSIIIBlue.png")
                        Gloss = FetchImage("http://101.imagebam.com/download/XKOkcp-J1pA74-6QrUcinA/23245/232446207/GSIIIBlue.png")
                        IndexW = 88
                    ElseIf args.var = "White" Then
                        Image1 = FetchImage("http://104.imagebam.com/download/BKXFsSBq3X47fU9nlBVAGA/23245/232444265/GSIIIWhite.png")
                        Gloss = FetchImage("http://101.imagebam.com/download/g_k_BEsUGrFjPRF_VSoTug/23245/232446208/GSIIIWhite.png")
                        IndexW = 84
                    ElseIf args.var = "Black" Then
                        Image1 = FetchImage("http://ompldr.org/vaDZnMg/GSIIIBlack.png")
                        IndexW = 88
                        GlossCheckbox.Enabled = False
                        GlossCheckbox.Checked = False
                    ElseIf args.var = "Red" Then
                        Image1 = FetchImage("http://ompldr.org/vaDZnMA/GSIIIRed.png")
                        IndexW = 88
                        GlossCheckbox.Enabled = False
                        GlossCheckbox.Checked = False
                    ElseIf args.var = "Brown" Then
                        Image1 = FetchImage("http://ompldr.org/vaDZnMQ/GSIIIBrown.png")
                        IndexW = 88
                        GlossCheckbox.Enabled = False
                        GlossCheckbox.Checked = False
                    End If
                    Undershadow = FetchImage("http://104.imagebam.com/download/M8YSsamRuFX-UdmMMGVaRQ/23245/232449429/GSIII.png")
                    Shadow = FetchImage(r7201280)
                    IndexH = 184
                Case "Google Nexus 10"
                    If args.var = "Portrait" Then
                        Image1 = FetchImage("http://106.imagebam.com/download/S-JHCUa600fE5YYnbQmOsw/23245/232444321/Nexus10Port.png")
                        Shadow = FetchImage(r8001280)
                        Gloss = FetchImage("http://101.imagebam.com/download/xKa57gweGuSjSQVpSaIN8w/23245/232446233/Nexus10Port.png")
                        Undershadow = FetchImage("http://102.imagebam.com/download/JnQpNQuQSEpDg50zBafe2Q/23245/232449473/Nexus10Port.png")
                        IndexW = 217
                        IndexH = 223
                        Dim imgtmp As New Bitmap(800, 1280)
                        Using graphicsHandle As Graphics = Graphics.FromImage(imgtmp)
                            graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
                            graphicsHandle.DrawImage(Image2, 0, 0, 800, 1280)
                            Image2 = imgtmp
                        End Using
                    ElseIf args.var = "Landscape" Then
                        Image1 = FetchImage("http://106.imagebam.com/download/uLF_WIWlWDjLkGyn_FpiVw/23245/232444313/Nexus10Land.png")
                        Shadow = FetchImage(r1280800)
                        Gloss = FetchImage("http://106.imagebam.com/download/fs8uO6QSqDqGIWrWW6hP5w/23245/232446230/Nexus10Land.png")
                        Undershadow = FetchImage("http://101.imagebam.com/download/5DV_KRipd4et4lCWCxFB7A/23245/232449463/Nexus10Land.png")
                        IndexW = 227
                        IndexH = 217
                        Dim imgtmp As New Bitmap(1280, 800)
                        Using graphicsHandle As Graphics = Graphics.FromImage(imgtmp)
                            graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
                            graphicsHandle.DrawImage(Image2, 0, 0, 1280, 800)
                            Image2 = imgtmp
                        End Using
                    End If
                Case "Motorola Xoom"
                    If args.var = "Portrait" Then
                        Image1 = FetchImage("http://106.imagebam.com/download/2MtWzZ_LKUPEuIKjKZKUhg/23245/232444345/XoomPort.png")
                        Shadow = FetchImage(r8001280)
                        Gloss = FetchImage("http://104.imagebam.com/download/_LfYrvNxlAik8ZxSywJ9FA/23245/232446259/XoomPort.png")
                        Undershadow = FetchImage("http://107.imagebam.com/download/K_IySnbIXPQaOeyJzsjB-Q/23245/232449486/XoomPort.png")
                        IndexW = 199
                        IndexH = 200
                    ElseIf args.var = "Landscape" Then
                        Image1 = FetchImage("http://108.imagebam.com/download/q6odFolKw9l7-PJUBmyEgg/23245/232444343/XoomLand.png")
                        Shadow = FetchImage(r1280800)
                        Gloss = FetchImage("http://103.imagebam.com/download/n7_eccl5kkDFCmd8Zl2ZjA/23245/232446256/XoomLand.png")
                        Undershadow = FetchImage("http://106.imagebam.com/download/fl8SMlSz5n7qEu9E9hEzVQ/23245/232449480/XoomLand.png")
                        IndexW = 218
                        IndexH = 191
                    End If
                Case "Samsung Galaxy SII, Epic 4G Touch"
                    If args.var = "Model 1" Then
                        Image1 = FetchImage("http://101.imagebam.com/download/Qb0UUK2N4n44-CeJh8dXGQ/23245/232444250/GSII.png")
                        Gloss = FetchImage("http://102.imagebam.com/download/LyNIHOeIjKmoosD8NSq3WA/23245/232446206/GSII.png")
                        Undershadow = FetchImage("http://108.imagebam.com/download/mNxjRHrYPTVlyly0qPOzUw/23245/232449422/GSII.png")
                        IndexH = 191
                    ElseIf args.var = "Model 2" Then
                        Image1 = FetchImage("http://101.imagebam.com/download/M3OGwFhyakGp-N6np53tKg/23245/232444234/Epic4GTouch.png")
                        Gloss = FetchImage("http://101.imagebam.com/download/VWrOhagASv4QAaYZM0wtOw/23245/232446199/Epic4GTouch.png")
                        Undershadow = FetchImage("http://108.imagebam.com/download/lfePLnspNi_nHn1Lz1o-zw/23245/232449410/Epic4GTouch.png")
                        IndexH = 175
                    End If
                    Shadow = FetchImage(r480800)
                    IndexW = 132
                Case "Apple iPhone"
                    Image1 = FetchImage("http://102.imagebam.com/download/kwG7EMQO2efuj0oOAGgvAw/23245/232444269/iPhone.png")
                    Shadow = FetchImage(r320480)
                    Gloss = FetchImage("http://104.imagebam.com/download/JYugbZN93ol0aWsjJBZszQ/23245/232446210/iPhone.png")
                    Undershadow = FetchImage("http://101.imagebam.com/download/DQ_mnzd6n6Gm4IT8vRaHPg/23245/232449433/iPhone.png")
                    IndexW = 89
                    IndexH = 176
                Case "Apple iPhone 3G, 3GS"
                    Image1 = FetchImage("http://108.imagebam.com/download/2fflwcusLtOdHGbKF5bRmA/23245/232444270/iPhone3Gand3GS.png")
                    Shadow = FetchImage(r320480)
                    Undershadow = FetchImage("http://108.imagebam.com/download/rQ-gQf_fK7kTg7i_kaN5Qw/23245/232449438/iPhone3Gand3GS.png")
                    IndexW = 88
                    IndexH = 176
                Case "Apple iPhone 4"
                    If args.var = "Black" Then
                        Image1 = FetchImage("http://108.imagebam.com/download/krN2_a9Gu7dPs984g8nkQw/23245/232444278/iPhone4Black.png")
                        Gloss = FetchImage("http://108.imagebam.com/download/DB7l2D7aU6lhMs8jKn9u5A/23245/232446214/iPhone4and4SBlack.png")
                    ElseIf args.var = "White" Then
                        Image1 = FetchImage("http://102.imagebam.com/download/3LTyb6jzu6Dzeni3KoSeNw/23245/232444290/iPhone4White.png")
                        Gloss = FetchImage("http://102.imagebam.com/download/UUZjqzmPlp2jIqu39heYbQ/23245/232446217/iPhone4and4SWhite.png")
                    End If
                    Undershadow = FetchImage("http://104.imagebam.com/download/0H18gXUZG0y653qVMK_zlA/23245/232449444/iPhone4and4S.png")
                    Shadow = FetchImage(r640960)
                    IndexW = 62
                    IndexH = 264
                Case "Apple iPhone 4S"
                    If args.var = "Black" Then
                        Image1 = FetchImage("http://103.imagebam.com/download/qfbTiEkvju67luFuIII9bA/23245/232444281/iPhone4SBlack.png")
                        Gloss = FetchImage("http://108.imagebam.com/download/DB7l2D7aU6lhMs8jKn9u5A/23245/232446214/iPhone4and4SBlack.png")
                    ElseIf args.var = "White" Then
                        Image1 = FetchImage("http://103.imagebam.com/download/EM7E87xOKp1u0hCxORtZlQ/23245/232444285/iPhone4SWhite.png")
                        Gloss = FetchImage("http://102.imagebam.com/download/UUZjqzmPlp2jIqu39heYbQ/23245/232446217/iPhone4and4SWhite.png")
                    End If
                    Undershadow = FetchImage("http://104.imagebam.com/download/0H18gXUZG0y653qVMK_zlA/23245/232449444/iPhone4and4S.png")
                    Shadow = FetchImage(r640960)
                    IndexW = 62
                    IndexH = 264
                Case "Apple iPhone 5"
                    If args.var = "Black" Then
                        Image1 = FetchImage("http://103.imagebam.com/download/Jqa13Vt7YJC7U6h05fmumg/23245/232444294/iPhone5Black.png")
                        Gloss = FetchImage("http://107.imagebam.com/download/-UigK0b5kRfPa4CP74WVTQ/23245/232446218/iPhone5Black-G.png")
                        Undershadow = FetchImage("http://106.imagebam.com/download/cNWALzDFezrQ1B1iGf4GGg/23245/232449448/iPhone5Black-DS.png")
                        Overlay = FetchImage("http://ompldr.org/vaDZhNQ/iPhone5Black.png")
                    ElseIf args.var = "White" Then
                        Image1 = FetchImage("http://101.imagebam.com/download/ISQSv4cFMh7LrkX8c7EW7A/23245/232444295/iPhone5White.png")
                        Gloss = FetchImage("http://102.imagebam.com/download/6uEehtOHOtHqI8BsnbhU0g/23245/232446221/iPhone5White-G.png")
                        Undershadow = FetchImage("http://108.imagebam.com/download/vDD3AxG4EWHdYi7Hhxz9Cg/23245/232449452/iPhone5White-DS.png")
                        Overlay = FetchImage("http://ompldr.org/vaDZhNg/iPhone5White.png")
                    End If
                    Shadow = FetchImage(r6401136)
                    IndexW = 133
                    IndexH = 287
                Case "Samsung Google Galaxy Nexus"
                    Image1 = FetchImage("http://107.imagebam.com/download/w1YzISbSAQWkcBcD8d0h9g/23245/232444239/GalaxyNexus.png")
                    Shadow = FetchImage(r7201280)
                    Gloss = FetchImage("http://103.imagebam.com/download/UfQ1I6eQVD4xdv0Pnpgwew/23245/232446201/GalaxyNexus.png")
                    Undershadow = FetchImage("http://103.imagebam.com/download/YIsKjp6AF1sqVkRJkg8Lhw/23245/232449415/GalaxyNexus.png")
                    IndexW = 155
                    IndexH = 263
                Case "Samsung Galaxy Note II"
                    Image1 = FetchImage("http://103.imagebam.com/download/AHVkOBxWhRpEJXxwP1KiLw/23245/232444244/GalaxyNoteII.png")
                    Shadow = FetchImage(r7201280)
                    Gloss = FetchImage("http://104.imagebam.com/download/m_P6Sfcc3mCGd7IQZwVOTw/23245/232446202/GalaxyNoteII.png")
                    IndexW = 49
                    IndexH = 140
                Case "Motorola Droid RAZR"
                    Image1 = FetchImage("http://106.imagebam.com/download/hM310SZGxmzR2wxM1IlEOQ/23245/232444231/DroidRAZR.png")
                    Shadow = FetchImage(r540960)
                    IndexW = 150
                    IndexH = 206
                Case "Google Nexus 7"
                    If args.var = "Portrait" Then
                        Image1 = FetchImage("http://104.imagebam.com/download/26ocJdNoE8NTLRhoTR0CDA/23245/232444310/Nexus7Port.png")
                        Shadow = FetchImage(r8001280)
                        Gloss = FetchImage("http://108.imagebam.com/download/Tw_6Jpul1bwHLSfM5ITS6Q/23245/232446227/Nexus7Port.png")
                        Undershadow = FetchImage("http://102.imagebam.com/download/7QKAHQadSzaWxFMpNP8-Jw/23245/232449457/Nexus7Port.png")
                        IndexW = 264
                        IndexH = 311
                    ElseIf args.var = "Landscape" Then
                        Image1 = FetchImage("http://101.imagebam.com/download/Rfj3cR78Rg4So0atGtxjyQ/23245/232444306/Nexus7Land.png")
                        Shadow = FetchImage(r1280800)
                        Gloss = FetchImage("http://101.imagebam.com/download/GPPHiyA4O005EU19Iz4hew/23245/232446226/Nexus7Land.png")
                        Undershadow = FetchImage("http://108.imagebam.com/download/UtdmeHp6BGR_WW4vvM8JUg/23245/232449453/Nexus7Land.png")
                        IndexW = 315
                        IndexH = 270
                    End If
                Case "HTC One S"
                    Image1 = FetchImage("http://103.imagebam.com/download/pES86Mk-oX3FwKg72ullsg/23245/232444328/OneS.png")
                    Shadow = FetchImage(r540960)
                    Gloss = FetchImage("http://102.imagebam.com/download/2YpfhldGjShokr_7vTVvrA/23245/232446240/OneS.png")
                    IndexW = 106
                    IndexH = 228
                Case "HTC One V"
                    Image1 = FetchImage("http://103.imagebam.com/download/d78I9T94gLuErZL59eWi6Q/23245/232444333/OneV.png")
                    Shadow = FetchImage(r480800)
                    Gloss = FetchImage("http://101.imagebam.com/download/XztYn-E4j2XfLl8co66zCQ/23245/232446244/OneV.png")
                    IndexW = 85
                    IndexH = 165
                Case "Google Nexus S"
                    Image1 = FetchImage("http://106.imagebam.com/download/qnwpbb1HFBzATLlQr7yD7g/23245/232444325/NexusS.png")
                    Shadow = FetchImage(r480800)
                    Gloss = FetchImage("http://108.imagebam.com/download/tu5BzK46n3ka_WydBl0pPQ/23245/232446237/NexusS.png")
                    IndexW = 45
                    IndexH = 165
                Case "Google Nexus 4"
                    Image1 = FetchImage("http://101.imagebam.com/download/fiW5-5yoR6LRtY20rwQmnw/23245/232444302/Nexus4.png")
                    Shadow = FetchImage(r7681280)
                    Gloss = FetchImage("http://104.imagebam.com/download/M_vkC9maazTeEad9DTvD9g/23245/232446224/Nexus4-G.png")
                    IndexW = 45
                    IndexH = 193
                Case "Motorola Droid RAZR M"
                    Image1 = FetchImage("http://106.imagebam.com/download/E58kNQKNie0lfbXBr8mM-A/23255/232546227/DroidRazrM.png")
                    Shadow = FetchImage(r540960)
                    IndexW = 49
                    IndexH = 129
                Case "Sony Ericsson Xperia X10"
                    If args.var = "Black" Then
                        Image1 = FetchImage("http://ompldr.org/vaDQzaA/SonyEricssonXperia10Black.png")
                        IndexW = 235
                        IndexH = 191
                    ElseIf args.var = "White" Then
                        Image1 = FetchImage("http://ompldr.org/vaDQzaQ/SonyEricssonXperia10White.png")
                        IndexW = 255
                        IndexH = 205
                    End If
                    Shadow = FetchImage(r480854)
                Case "HTC Google Nexus One"
                    Image1 = FetchImage("http://ompldr.org/vaDQzZQ/HTCGoogleNexusOne.png")
                    Shadow = FetchImage(r480800)
                    Gloss = FetchImage("http://ompldr.org/vaDQzOQ/HTCGoogleNexusOne.png")
                    IndexW = 165
                    IndexH = 168
                Case "HTC Hero"
                    Image1 = FetchImage("http://ompldr.org/vaDQzZg/HTCHero.png")
                    Shadow = FetchImage(r320480)
                    Gloss = FetchImage("http://ompldr.org/vaDQzYQ/HTCHero.png")
                    Undershadow = FetchImage("http://ompldr.org/vaDQzYw/HTCHero.png")
                    IndexW = 67
                    IndexH = 131
                Case "HTC Legend"
                    Image1 = FetchImage("http://ompldr.org/vaDQzZw/HTCLegend.png")
                    Shadow = FetchImage(r320480)
                    Gloss = FetchImage("http://ompldr.org/vaDQzYg/HTCLegend.png")
                    IndexW = 67
                    IndexH = 131
                    Dim imgtmp As New Bitmap(212, 316)
                    Using graphicsHandle As Graphics = Graphics.FromImage(imgtmp)
                        graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
                        graphicsHandle.DrawImage(Image2, 0, 0, 212, 316)
                        Image2 = imgtmp
                    End Using
                    Dim shdtmp As New Bitmap(212, 316)
                    Using graphicsHandle As Graphics = Graphics.FromImage(shdtmp)
                        graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
                        graphicsHandle.DrawImage(Shadow, 0, 0, 212, 316)
                        Shadow = shdtmp
                    End Using
                Case "HP TouchPad"
                    Image1 = FetchImage("http://ompldr.org/vaDQ1eQ/HPTouchPad.png")
                    Shadow = FetchImage(r1024768)
                    IndexW = 188
                    IndexH = 170
                Case "HP Veer"
                    Image1 = FetchImage("http://ompldr.org/vaDQ2NQ/HPVeer.png")
                    Shadow = FetchImage("http://ompldr.org/vaDQ2Ng/320x400.png")
                    IndexW = 54
                    IndexH = 77
                    Dim imgtmp As New Bitmap(219, 271)
                    Using graphicsHandle As Graphics = Graphics.FromImage(imgtmp)
                        graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
                        graphicsHandle.DrawImage(Image2, 0, 0, 219, 271)
                        Image2 = imgtmp
                    End Using
                    Dim shdtmp As New Bitmap(219, 271)
                    Using graphicsHandle As Graphics = Graphics.FromImage(shdtmp)
                        graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
                        graphicsHandle.DrawImage(Shadow, 0, 0, 219, 271)
                        Shadow = shdtmp
                    End Using
                Case "HTC Droid DNA"
                    Image1 = FetchImage("http://ompldr.org/vaDVxcQ/DroidDNA.png")
                    Shadow = FetchImage(r10801920)
                    Gloss = FetchImage("http://ompldr.org/vaDY3cw/DroidDNA.png")
                    IndexW = 106
                    IndexH = 300
                Case "HTC Vivid"
                    Image1 = FetchImage("http://ompldr.org/vaDVxcA/Vivid.png")
                    Shadow = FetchImage(r540960)
                    IndexW = 66
                    IndexH = 125
                Case "HTC Evo 3D"
                    Image1 = FetchImage("http://ompldr.org/vaDY3dA/Evo3D.png")
                    Shadow = FetchImage(r540960)
                    IndexW = 78
                    IndexH = 153
                Case "HTC Desire Z, T-Mobile G2"
                    If args.var = "Portrait" Then
                        Image1 = FetchImage("http://ompldr.org/vaDY4MQ/DesireZPort.png")
                        Shadow = FetchImage(r480800)
                        IndexW = 94
                        IndexH = 162
                    ElseIf args.var = "Landscape" Then
                        Image1 = FetchImage("http://ompldr.org/vaDY4MA/DesireZLand.png")
                        Shadow = FetchImage(r800480)
                        IndexW = 189
                        IndexH = 79
                    End If
                Case "HTC Desire"
                    Image1 = FetchImage("http://ompldr.org/vaDY4Yw/Desire.png")
                    Shadow = FetchImage(r480800)
                    IndexW = 136
                    IndexH = 180
                Case "Samsung Droid Charge, Galaxy S Aviator, Galaxy S Lightray 4G"
                    If args.var = "Model 1" Then
                        Image1 = FetchImage("http://ompldr.org/vaDY4ZQ/DroidCharge.png")
                        IndexH = 191
                    ElseIf args.var = "Model 2" Then
                        Image1 = FetchImage("http://ompldr.org/vaDY4bA/GalaxySAviator.png")
                        IndexH = 175
                    End If
                    Shadow = FetchImage(r480800)
                    IndexW = 60
                    IndexH = 115
                Case "Samsung Galaxy Ace, Galaxy Cooper"
                    Image1 = FetchImage("http://ompldr.org/vaDY4cA/GalaxyAce.png")
                    Shadow = FetchImage(r320480)
                    IndexW = 87
                    IndexH = 179
                Case "Nokia Lumia 920"
                    Select Case args.var
                        Case "Red"
                            Image1 = FetchImage("http://ompldr.org/vaDY5OQ/Lumia920Red.png")
                        Case "Cyan"
                            Image1 = FetchImage("http://ompldr.org/vaDY5Nw/Lumia920Cyan.png")
                        Case "Yellow"
                            Image1 = FetchImage("http://ompldr.org/vaDY5Yg/Lumia920Yellow.png")
                        Case "Black"
                            Image1 = FetchImage("http://ompldr.org/vaDY5Ng/Lumia920Black.png")
                        Case "White"
                            Image1 = FetchImage("http://ompldr.org/vaDY5YQ/Lumia920White.png")
                        Case "Grey"
                            Image1 = FetchImage("http://ompldr.org/vaDY5OA/Lumia920Grey.png")
                    End Select
                    Gloss = FetchImage("http://ompldr.org/vaDY5NA/Lumia920.png")
                    Undershadow = FetchImage("http://ompldr.org/vaDY5NQ/Lumia920.png")
                    Shadow = FetchImage(r7681280)
                    IndexW = 160
                    IndexH = 170
                Case "Sony Ericsson Xperia J"
                    Image1 = FetchImage("http://ompldr.org/vaDY5aQ/XperiaJ.png")
                    Shadow = FetchImage(r480854)
                    IndexW = 75
                    IndexH = 172
                Case "Nokia N9"
                    Select Case GlossCheckbox.Checked
                        Case True
                            Image1 = FetchImage("http://ompldr.org/vaDY5cw/N9Gloss.png")
                        Case False
                            Image1 = FetchImage("http://ompldr.org/vaDY5cQ/N9.png")
                    End Select
                    Shadow = FetchImage(r480854)
                    IndexW = 83
                    IndexH = 172
                Case "LG Nitro HD, Spectrum, Optimus LTE/LTE L-01D/True HD LTE/LTE II"
                    Image1 = FetchImage("http://ompldr.org/vaDY5eA/Nitro.png")
                    Shadow = FetchImage(r7201280)
                    IndexW = 83
                    IndexH = 172
                Case "Samsung Galaxy Tab 10.1"
                    If args.var = "Portrait" Then
                        Image1 = FetchImage("http://ompldr.org/vaDZhMw/GalaxyTab10.1Port.png")
                        Shadow = FetchImage(r8001280)
                        IndexW = 129
                    ElseIf args.var = "Landscape" Then
                        Image1 = FetchImage("http://ompldr.org/vaDZhMg/GalaxyTab10.1Land.png")
                        Shadow = FetchImage(r1280800)
                        IndexW = 135
                    End If
                    IndexH = 135
                Case "Samsung Galaxy SII Skyrocket"
                    Image1 = FetchImage("http://ompldr.org/vaDZhYw/GSII%20Skyrocket.png")
                    Shadow = FetchImage(r480800)
                    IndexW = 86
                    IndexH = 148
                Case "HTC Evo 4G LTE"
                    Image1 = FetchImage("http://ompldr.org/vaDZoYw/EVO4GLTE.png")
                    Shadow = FetchImage(r7201280)
                    IndexW = 88
                    IndexH = 199
            End Select
            Dim Background As New Bitmap(Image1.Width, Image1.Height)
            Dim Image3 As New Bitmap(Image1.Width, Image1.Height, PixelFormat.Format32bppArgb)
            Dim g As Graphics = Graphics.FromImage(Image3)
            g.Clear(Color.Transparent)
            g.DrawImage(Background, New Point(0, 0))
            If UnderShadowCheckbox.Checked = True Then g.DrawImage(Undershadow, New Point(0, 0))
            g.DrawImage(Image2, New Point(IndexW, IndexH))
            If ShadowCheckbox.Checked = True Then g.DrawImage(Shadow, New Point(IndexW, IndexH))
            g.DrawImage(Image1, New Point(0, 0))
            If GlossCheckbox.Checked = True Then g.DrawImage(Gloss, New Point(0, 0))
            If args.model = "iPhone 5" Then g.DrawImage(Overlay, New Point(0, 0))
            g.Dispose()
            g = Nothing
            SaveImg = Image3
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
        Preview.Image = SaveImg
        LoadImage.Image = Nothing
    End Sub

    Private Sub CaptureBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CaptureBtn.Click
        adb.ShowDialog()
    End Sub

    Public Shared Sub ADBCapture()
        OpenPath = (Environment.GetEnvironmentVariable("Temp") & "\capture.png")
		Scrotter.RefreshLists()
		Try
			My.Computer.FileSystem.DeleteFile(Environment.GetEnvironmentVariable("Temp") & "\capture.png")
		Catch ex As Exception
			Exit Sub
		End Try
	End Sub

End Class