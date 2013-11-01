Imports System.Drawing

Namespace YLScsDrawing.Geometry
	Public Structure Vector
		Private _x As Double, _y As Double

		Public Sub New(x As Double, y As Double)
			_x = x
			_y = y
		End Sub
		Public Sub New(pt As PointF)
			_x = pt.X
			_y = pt.Y
		End Sub
		Public Sub New(st As PointF, [end] As PointF)
			_x = [end].X - st.X
			_y = [end].Y - st.Y
		End Sub

		Public Property X() As Double
			Get
				Return _x
			End Get
			Set
				_x = value
			End Set
		End Property

		Public Property Y() As Double
			Get
				Return _y
			End Get
			Set
				_y = value
			End Set
		End Property

		Public ReadOnly Property Magnitude() As Double
			Get
				Return Math.Sqrt(X * X + Y * Y)
			End Get
		End Property

		Public Shared Operator +(v1 As Vector, v2 As Vector) As Vector
			Return New Vector(v1.X + v2.X, v1.Y + v2.Y)
		End Operator

		Public Shared Operator -(v1 As Vector, v2 As Vector) As Vector
			Return New Vector(v1.X - v2.X, v1.Y - v2.Y)
		End Operator

		Public Shared Operator -(v As Vector) As Vector
			Return New Vector(-v.X, -v.Y)
		End Operator

		Public Shared Operator *(c As Double, v As Vector) As Vector
			Return New Vector(c * v.X, c * v.Y)
		End Operator

		Public Shared Operator *(v As Vector, c As Double) As Vector
			Return New Vector(c * v.X, c * v.Y)
		End Operator

		Public Shared Operator /(v As Vector, c As Double) As Vector
			Return New Vector(v.X / c, v.Y / c)
		End Operator

		' A * B =|A|.|B|.sin(angle AOB)
		Public Function CrossProduct(v As Vector) As Double
			Return _x * v.Y - v.X * _y
		End Function

		' A. B=|A|.|B|.cos(angle AOB)
		Public Function DotProduct(v As Vector) As Double
			Return _x * v.X + _y * v.Y
		End Function

		Public Shared Function IsClockwise(pt1 As PointF, pt2 As PointF, pt3 As PointF) As Boolean
			Dim V21 As New Vector(pt2, pt1)
			Dim v23 As New Vector(pt2, pt3)
			Return V21.CrossProduct(v23) < 0
			' sin(angle pt1 pt2 pt3) > 0, 0<angle pt1 pt2 pt3 <180
		End Function

		Public Shared Function IsCCW(pt1 As PointF, pt2 As PointF, pt3 As PointF) As Boolean
			Dim V21 As New Vector(pt2, pt1)
			Dim v23 As New Vector(pt2, pt3)
			Return V21.CrossProduct(v23) > 0
			' sin(angle pt2 pt1 pt3) < 0, 180<angle pt2 pt1 pt3 <360
		End Function

		Public Shared Function DistancePointLine(pt As PointF, lnA As PointF, lnB As PointF) As Double
			Dim v1 As New Vector(lnA, lnB)
			Dim v2 As New Vector(lnA, pt)
			v1 /= v1.Magnitude
			Return Math.Abs(v2.CrossProduct(v1))
		End Function

		Public Sub Rotate(Degree As Integer)
			Dim radian As Double = Degree * Math.PI / 180.0
			Dim sin As Double = Math.Sin(radian)
			Dim cos As Double = Math.Cos(radian)
			Dim nx As Double = _x * cos - _y * sin
			Dim ny As Double = _x * sin + _y * cos
			_x = nx
			_y = ny
		End Sub

		Public Function ToPointF() As PointF
			Return New PointF(CSng(_x), CSng(_y))
		End Function
	End Structure
End Namespace
