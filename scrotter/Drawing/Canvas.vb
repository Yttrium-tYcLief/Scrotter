Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Namespace YLScsDrawing.Controls
	Public Partial Class Canvas
		Inherits UserControl
		Public Sub New()
			InitializeComponent()

			' Set the value of the double-buffering style bits to true.
			Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)
		End Sub

		Private filter As New YLScsDrawing.Imaging.Filters.FreeTransform()
		Private recthandle As RectangleF() = New RectangleF(3) {}
		Private vertex As PointF() = New PointF(3) {}

		Private originalCanvas As New Rectangle(0, 0, 400, 600)
		Public Property CanvasSize() As Size
			Get
				Return originalCanvas.Size
			End Get
			Set
				originalCanvas.Size = value
				setup()
			End Set
		End Property

		Private m_canvasBackColor As Color = Color.Transparent
		Public Property CanvasBackColor() As Color
			Get
				Return m_canvasBackColor
			End Get
			Set
				m_canvasBackColor = value
				Invalidate()
			End Set
		End Property

		Private m_zoomFactor As Single = 1F
		Public Property ZoomFactor() As Single
			Get
				Return m_zoomFactor
			End Get
			Set
				m_zoomFactor = Math.Max(0.001F, value)
				' if =0, tranform matrix will be thrown exception
				setup()
			End Set
		End Property

		Public Property IsBilinearInterpolation() As Boolean
			Get
				Return filter.IsBilinearInterpolation
			End Get
			Set
				filter.IsBilinearInterpolation = value
			End Set
		End Property

		Private pictureItem As Bitmap
		Public Property CanvasImage() As Bitmap

			Get
				Return pictureItem
			End Get
			Set
				pictureItem = value
				startFT()
				pictureItem = filter.Bitmap
				Invalidate()
			End Set
		End Property

		Private m_imageLocation As New Point()
		Public Property ImageLocation() As Point
			Get
				Return m_imageLocation
			End Get
			Set
				m_imageLocation = value
			End Set
		End Property

		Private Sub startFT()
			If pictureItem IsNot Nothing Then
				filter.Bitmap = pictureItem
				vertex(0) = New PointF(m_imageLocation.X, m_imageLocation.Y)
				vertex(1) = New PointF(m_imageLocation.X + pictureItem.Width, m_imageLocation.Y)
				vertex(2) = New PointF(m_imageLocation.X + pictureItem.Width, m_imageLocation.Y + pictureItem.Height)
				vertex(3) = New PointF(m_imageLocation.X, m_imageLocation.Y + pictureItem.Height)

				For i As Integer = 0 To 3
					recthandle(i) = New RectangleF(vertex(i).X - 2, vertex(i).Y - 2, 4, 4)
				Next
				filter.FourCorners = vertex
			End If
		End Sub

		Private zoomedCanvas As New Rectangle()
		Private visibleCanvas As New Rectangle()
		Private mxCanvasToControl As Matrix, mxControlToCanvas As Matrix
		' transform matrix
		Private Sub setup()
			' setup zoomed canvas Rectangle
			zoomedCanvas.Width = CInt(Math.Truncate(CSng(originalCanvas.Width) * m_zoomFactor))
			zoomedCanvas.Height = CInt(Math.Truncate(CSng(originalCanvas.Height) * m_zoomFactor))
			Me.AutoScrollMinSize = zoomedCanvas.Size
			Dim canvasLoc As New Point()
			If zoomedCanvas.Width < Me.ClientRectangle.Width Then
				canvasLoc.X = (Me.ClientRectangle.Width - zoomedCanvas.Width) \ 2
			Else
				canvasLoc.X = AutoScrollPosition.X
			End If
			If zoomedCanvas.Height < Me.ClientRectangle.Height Then
				canvasLoc.Y = (Me.ClientRectangle.Height - zoomedCanvas.Height) \ 2
			Else
				canvasLoc.Y = AutoScrollPosition.Y
			End If
			zoomedCanvas.Location = canvasLoc

			' setup transform matrix
			mxCanvasToControl = New Matrix()
			mxCanvasToControl.Scale(m_zoomFactor, m_zoomFactor)
			mxCanvasToControl.Translate(canvasLoc.X, canvasLoc.Y, MatrixOrder.Append)

			mxControlToCanvas = mxCanvasToControl.Clone()
			mxControlToCanvas.Invert()

			visibleCanvas = Me.ClientRectangle
			visibleCanvas.Intersect(zoomedCanvas)

			Invalidate()
		End Sub

		Private Function toCanvas(pt As Point) As Point
			Dim pts As Point() = New Point() {pt}
			If mxControlToCanvas IsNot Nothing Then
				mxControlToCanvas.TransformPoints(pts)
			End If
			Return pts(0)
		End Function

		Private ptOnCanvas As New Point()

		Private isDrag As Boolean = False
		Private moveFlag As Integer

		Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
			MyBase.OnMouseDown(e)
			ptOnCanvas = toCanvas(e.Location)
			For i As Integer = 0 To 3
				If recthandle(i).Contains(ptOnCanvas) Then
					isDrag = True
					moveFlag = i
				End If
			Next
		End Sub
		Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
			MyBase.OnMouseMove(e)
			ptOnCanvas = toCanvas(e.Location)

			If recthandle(0).Contains(ptOnCanvas) OrElse recthandle(1).Contains(ptOnCanvas) OrElse recthandle(2).Contains(ptOnCanvas) OrElse recthandle(3).Contains(ptOnCanvas) Then
				Me.Cursor = Cursors.Hand
			Else
				Me.Cursor = Cursors.[Default]
			End If

			If isDrag AndAlso originalCanvas.Contains(ptOnCanvas) Then
				recthandle(moveFlag) = New RectangleF(ptOnCanvas.X - 2, ptOnCanvas.Y - 2, 4, 4)
				vertex(moveFlag) = ptOnCanvas
			End If
			Invalidate()
		End Sub

		Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
			MyBase.OnMouseUp(e)
			If isDrag Then
				isDrag = False

				filter.FourCorners = vertex
				pictureItem = filter.Bitmap
				m_imageLocation = filter.ImageLocation
				Invalidate()
			End If
		End Sub

		Protected Overrides Sub OnMouseWheel(e As MouseEventArgs)
			MyBase.OnMouseWheel(e)
			If e.Delta > 0 Then
				Me.ZoomFactor += 0.1F
			End If
			If e.Delta < 0 Then
				Me.ZoomFactor -= 0.1F
			End If
		End Sub

		Protected Overrides Sub OnScroll(se As ScrollEventArgs)
			setup()
		End Sub

		Protected Overrides Sub OnResize(e As EventArgs)
			MyBase.OnResize(e)
			setup()
		End Sub

		Protected Overrides Sub OnPaint(e As PaintEventArgs)
			Dim g As Graphics = e.Graphics
			g.FillRectangle(New SolidBrush(m_canvasBackColor), visibleCanvas)
			g.Transform = mxCanvasToControl

			If pictureItem IsNot Nothing Then
				g.DrawImage(pictureItem, m_imageLocation)

				g.DrawPolygon(New Pen(Color.Yellow), vertex)
				For i As Integer = 0 To 3
					g.FillRectangle(New SolidBrush(Color.Red), recthandle(i))
				Next
			End If
		End Sub
	End Class
End Namespace
