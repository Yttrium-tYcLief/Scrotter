Imports System.Drawing
Imports System.Drawing.Drawing2D

Namespace YLScsDrawing.Imaging.Filters
	Public Class FreeTransform
		Private vertex As PointF() = New PointF(3) {}
		Private AB As YLScsDrawing.Geometry.Vector, BC As YLScsDrawing.Geometry.Vector, CD As YLScsDrawing.Geometry.Vector, DA As YLScsDrawing.Geometry.Vector
		Private rect As New Rectangle()
		Private srcCB As YLScsDrawing.Imaging.ImageData = New ImageData()
		Private srcW As Integer = 0
		Private srcH As Integer = 0

		Public Property Bitmap() As Bitmap
			Get
				Return getTransformedBitmap()
			End Get
			Set
				Try
					srcCB.FromBitmap(value)
					srcH = value.Height
					srcW = value.Width
				Catch
					srcW = 0
					srcH = 0
				End Try
			End Set
		End Property

		Public Property ImageLocation() As Point
			Get
				Return rect.Location
			End Get
			Set
				rect.Location = value
			End Set
		End Property

		Private isBilinear As Boolean = False
		Public Property IsBilinearInterpolation() As Boolean
			Get
				Return isBilinear
			End Get
			Set
				isBilinear = value
			End Set
		End Property

		Public ReadOnly Property ImageWidth() As Integer
			Get
				Return rect.Width
			End Get
		End Property

		Public ReadOnly Property ImageHeight() As Integer
			Get
				Return rect.Height
			End Get
		End Property

		Public Property VertexLeftTop() As PointF
			Get
				Return vertex(0)
			End Get
			Set
				vertex(0) = value
				setVertex()
			End Set
		End Property

		Public Property VertexTopRight() As PointF
			Get
				Return vertex(1)
			End Get
			Set
				vertex(1) = value
				setVertex()
			End Set
		End Property

		Public Property VertexRightBottom() As PointF
			Get
				Return vertex(2)
			End Get
			Set
				vertex(2) = value
				setVertex()
			End Set
		End Property

		Public Property VertexBottomLeft() As PointF
			Get
				Return vertex(3)
			End Get
			Set
				vertex(3) = value
				setVertex()
			End Set
		End Property

		Public Property FourCorners() As PointF()
			Get
				Return vertex
			End Get
			Set
				vertex = value
				setVertex()
			End Set
		End Property

		Private Sub setVertex()
			Dim xmin As Single = Single.MaxValue
			Dim ymin As Single = Single.MaxValue
			Dim xmax As Single = Single.MinValue
			Dim ymax As Single = Single.MinValue

			For i As Integer = 0 To 3
				xmax = Math.Max(xmax, vertex(i).X)
				ymax = Math.Max(ymax, vertex(i).Y)
				xmin = Math.Min(xmin, vertex(i).X)
				ymin = Math.Min(ymin, vertex(i).Y)
			Next

			rect = New Rectangle(CInt(Math.Truncate(xmin)), CInt(Math.Truncate(ymin)), CInt(Math.Truncate(xmax - xmin)), CInt(Math.Truncate(ymax - ymin)))

			AB = New YLScsDrawing.Geometry.Vector(vertex(0), vertex(1))
			BC = New YLScsDrawing.Geometry.Vector(vertex(1), vertex(2))
			CD = New YLScsDrawing.Geometry.Vector(vertex(2), vertex(3))
			DA = New YLScsDrawing.Geometry.Vector(vertex(3), vertex(0))

			' get unit vector
			AB /= AB.Magnitude
			BC /= BC.Magnitude
			CD /= CD.Magnitude
			DA /= DA.Magnitude
		End Sub

		Private Function isOnPlaneABCD(pt As PointF) As Boolean
		'  including point on border
			If Not YLScsDrawing.Geometry.Vector.IsCCW(pt, vertex(0), vertex(1)) Then
				If Not YLScsDrawing.Geometry.Vector.IsCCW(pt, vertex(1), vertex(2)) Then
					If Not YLScsDrawing.Geometry.Vector.IsCCW(pt, vertex(2), vertex(3)) Then
						If Not YLScsDrawing.Geometry.Vector.IsCCW(pt, vertex(3), vertex(0)) Then
							Return True
						End If
					End If
				End If
			End If
			Return False
		End Function

		Private Function getTransformedBitmap() As Bitmap
			If srcH = 0 OrElse srcW = 0 Then
				Return Nothing
			End If

			Dim destCB As New ImageData()
			destCB.A = New Byte(rect.Width - 1, rect.Height - 1) {}
			destCB.B = New Byte(rect.Width - 1, rect.Height - 1) {}
			destCB.G = New Byte(rect.Width - 1, rect.Height - 1) {}
			destCB.R = New Byte(rect.Width - 1, rect.Height - 1) {}


			Dim ptInPlane As New PointF()
			Dim x1 As Integer, x2 As Integer, y1 As Integer, y2 As Integer
			Dim dab As Double, dbc As Double, dcd As Double, dda As Double
			Dim dx1 As Single, dx2 As Single, dy1 As Single, dy2 As Single, dx1y1 As Single, dx1y2 As Single, _
				dx2y1 As Single, dx2y2 As Single, nbyte As Single

			For y As Integer = 0 To rect.Height - 1
				For x As Integer = 0 To rect.Width - 1
					Dim srcPt As New Point(x, y)
					srcPt.Offset(Me.rect.Location)

					If isOnPlaneABCD(srcPt) Then
						dab = Math.Abs((New YLScsDrawing.Geometry.Vector(vertex(0), srcPt)).CrossProduct(AB))
						dbc = Math.Abs((New YLScsDrawing.Geometry.Vector(vertex(1), srcPt)).CrossProduct(BC))
						dcd = Math.Abs((New YLScsDrawing.Geometry.Vector(vertex(2), srcPt)).CrossProduct(CD))
						dda = Math.Abs((New YLScsDrawing.Geometry.Vector(vertex(3), srcPt)).CrossProduct(DA))
						ptInPlane.X = CSng(srcW * (dda / (dda + dbc)))
						ptInPlane.Y = CSng(srcH * (dab / (dab + dcd)))

						x1 = CInt(Math.Truncate(ptInPlane.X))
						y1 = CInt(Math.Truncate(ptInPlane.Y))

						If x1 >= 0 AndAlso x1 < srcW AndAlso y1 >= 0 AndAlso y1 < srcH Then
							If isBilinear Then
								x2 = If((x1 = srcW - 1), x1, x1 + 1)
								y2 = If((y1 = srcH - 1), y1, y1 + 1)

								dx1 = ptInPlane.X - CSng(x1)
								If dx1 < 0 Then
									dx1 = 0
								End If
								dx1 = 1F - dx1
								dx2 = 1F - dx1
								dy1 = ptInPlane.Y - CSng(y1)
								If dy1 < 0 Then
									dy1 = 0
								End If
								dy1 = 1F - dy1
								dy2 = 1F - dy1

								dx1y1 = dx1 * dy1
								dx1y2 = dx1 * dy2
								dx2y1 = dx2 * dy1
								dx2y2 = dx2 * dy2


								nbyte = srcCB.A(x1, y1) * dx1y1 + srcCB.A(x2, y1) * dx2y1 + srcCB.A(x1, y2) * dx1y2 + srcCB.A(x2, y2) * dx2y2
								destCB.A(x, y) = CByte(Math.Truncate(nbyte))
								nbyte = srcCB.B(x1, y1) * dx1y1 + srcCB.B(x2, y1) * dx2y1 + srcCB.B(x1, y2) * dx1y2 + srcCB.B(x2, y2) * dx2y2
								destCB.B(x, y) = CByte(Math.Truncate(nbyte))
								nbyte = srcCB.G(x1, y1) * dx1y1 + srcCB.G(x2, y1) * dx2y1 + srcCB.G(x1, y2) * dx1y2 + srcCB.G(x2, y2) * dx2y2
								destCB.G(x, y) = CByte(Math.Truncate(nbyte))
								nbyte = srcCB.R(x1, y1) * dx1y1 + srcCB.R(x2, y1) * dx2y1 + srcCB.R(x1, y2) * dx1y2 + srcCB.R(x2, y2) * dx2y2
								destCB.R(x, y) = CByte(Math.Truncate(nbyte))
							Else
								destCB.A(x, y) = srcCB.A(x1, y1)
								destCB.B(x, y) = srcCB.B(x1, y1)
								destCB.G(x, y) = srcCB.G(x1, y1)
								destCB.R(x, y) = srcCB.R(x1, y1)
							End If
						End If
					End If
				Next
			Next
			Return destCB.ToBitmap()
		End Function
	End Class
End Namespace
