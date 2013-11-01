Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Imaging

Namespace YLScsDrawing.Imaging
	''' <summary>
	''' Using InteropServices.Marshal mathods to get image channels (R,G,B,A) byte
	''' </summary>
	Public Class ImageData
		Implements IDisposable
		Private _red As Byte(,), _green As Byte(,), _blue As Byte(,), _alpha As Byte(,)
		Private _disposed As Boolean = False

		Public Property A() As Byte(,)
			Get
				Return _alpha
			End Get
			Set
				_alpha = value
			End Set
		End Property
		Public Property B() As Byte(,)
			Get
				Return _blue
			End Get
			Set
				_blue = value
			End Set
		End Property
		Public Property G() As Byte(,)
			Get
				Return _green
			End Get
			Set
				_green = value
			End Set
		End Property
		Public Property R() As Byte(,)
			Get
				Return _red
			End Get
			Set
				_red = value
			End Set
		End Property

		Public Function Clone() As ImageData
			Dim cb As New ImageData()
			cb.A = DirectCast(_alpha.Clone(), Byte(,))
			cb.B = DirectCast(_blue.Clone(), Byte(,))
			cb.G = DirectCast(_green.Clone(), Byte(,))
			cb.R = DirectCast(_red.Clone(), Byte(,))
			Return cb
		End Function

		#Region "InteropServices.Marshal mathods"
		Public Sub FromBitmap(srcBmp As Bitmap)
			Dim w As Integer = srcBmp.Width
			Dim h As Integer = srcBmp.Height

			_alpha = New Byte(w - 1, h - 1) {}
			_blue = New Byte(w - 1, h - 1) {}
			_green = New Byte(w - 1, h - 1) {}
			_red = New Byte(w - 1, h - 1) {}

			' Lock the bitmap's bits.  
			Dim bmpData As System.Drawing.Imaging.BitmapData = srcBmp.LockBits(New Rectangle(0, 0, w, h), System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)
			' Get the address of the first line.
			Dim ptr As IntPtr = bmpData.Scan0

			' Declare an array to hold the bytes of the bitmap.
			Dim bytes As Integer = bmpData.Stride * srcBmp.Height
			Dim rgbValues As Byte() = New Byte(bytes - 1) {}

			' Copy the RGB values
			System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes)

			Dim offset As Integer = bmpData.Stride - w * 4

			Dim index As Integer = 0
			For y As Integer = 0 To h - 1
				For x As Integer = 0 To w - 1
					_blue(x, y) = rgbValues(index)
					_green(x, y) = rgbValues(index + 1)
					_red(x, y) = rgbValues(index + 2)
					_alpha(x, y) = rgbValues(index + 3)
					index += 4
				Next
				index += offset
			Next

			' Unlock the bits.
			srcBmp.UnlockBits(bmpData)
		End Sub

		Public Function ToBitmap() As Bitmap
			Dim width As Integer = 0, height As Integer = 0
			If _alpha IsNot Nothing Then
				width = Math.Max(width, _alpha.GetLength(0))
				height = Math.Max(height, _alpha.GetLength(1))
			End If
			If _blue IsNot Nothing Then
				width = Math.Max(width, _blue.GetLength(0))
				height = Math.Max(height, _blue.GetLength(1))
			End If
			If _green IsNot Nothing Then
				width = Math.Max(width, _green.GetLength(0))
				height = Math.Max(height, _green.GetLength(1))
			End If
			If _red IsNot Nothing Then
				width = Math.Max(width, _red.GetLength(0))
				height = Math.Max(height, _red.GetLength(1))
			End If
			Dim bmp As New Bitmap(width, height, PixelFormat.Format32bppArgb)
			Dim bmpData As System.Drawing.Imaging.BitmapData = bmp.LockBits(New Rectangle(0, 0, width, height), System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb)

			' Get the address of the first line.
			Dim ptr As IntPtr = bmpData.Scan0

			' Declare an array to hold the bytes of the bitmap.
			Dim bytes As Integer = bmpData.Stride * bmp.Height
			Dim rgbValues As Byte() = New Byte(bytes - 1) {}

			' set rgbValues
			Dim offset As Integer = bmpData.Stride - width * 4
			Dim i As Integer = 0
			For y As Integer = 0 To height - 1
				For x As Integer = 0 To width - 1
					rgbValues(i) = If(checkArray(_blue, x, y), _blue(x, y), CByte(0))
					rgbValues(i + 1) = If(checkArray(_green, x, y), _green(x, y), CByte(0))
					rgbValues(i + 2) = If(checkArray(_red, x, y), _red(x, y), CByte(0))
					rgbValues(i + 3) = If(checkArray(_alpha, x, y), _alpha(x, y), CByte(255))
					i += 4
				Next
				i += offset
			Next

			' Copy the RGB values back to the bitmap
			System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes)

			' Unlock the bits.
			bmp.UnlockBits(bmpData)
			Return bmp
		End Function
		#End Region

		Private Shared Function checkArray(array As Byte(,), x As Integer, y As Integer) As Boolean
			If array Is Nothing Then
				Return False
			End If
			If x < array.GetLength(0) AndAlso y < array.GetLength(1) Then
				Return True
			Else
				Return False
			End If
		End Function

		Public Sub Dispose() Implements IDisposable.Dispose
			Dispose(True)

			' Use SupressFinalize in case a subclass
			' of this type implements a finalizer.
			GC.SuppressFinalize(Me)
		End Sub

		Protected Overridable Sub Dispose(disposing As Boolean)
			' If you need thread safety, use a lock around these 
			' operations, as well as in your methods that use the resource.
			If Not _disposed Then
				If disposing Then
					_alpha = Nothing
					_blue = Nothing
					_green = Nothing
					_red = Nothing
				End If

				' Indicate that the instance has been disposed.
				_disposed = True
			End If
		End Sub
	End Class
End Namespace
