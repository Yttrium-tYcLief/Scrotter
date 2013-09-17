using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace YLScsDrawing.Controls
{
    public partial class Canvas : UserControl
    {
        public Canvas()
        {
            InitializeComponent();
            
            // Set the value of the double-buffering style bits to true.
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint | ControlStyles.ResizeRedraw |
              ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
        }

        YLScsDrawing.Imaging.Filters.FreeTransform filter = new YLScsDrawing.Imaging.Filters.FreeTransform();
        RectangleF[] recthandle = new RectangleF[4];
        PointF[] vertex = new PointF[4];

        Rectangle originalCanvas = new Rectangle(0, 0, 400, 600);
        public Size CanvasSize
        {
            set { originalCanvas.Size = value; setup(); }
            get { return originalCanvas.Size; }
        }

        Color canvasBackColor = Color.Transparent;
        public Color CanvasBackColor
        {
            set { canvasBackColor = value; Invalidate(); }
            get { return canvasBackColor; }
        }

        float zoomFactor = 1f;
        public float ZoomFactor
        {
            get { return zoomFactor; }
            set
            {
                zoomFactor = Math.Max(0.001f, value); // if =0, tranform matrix will be thrown exception
                setup();
            }
        }

        public bool IsBilinearInterpolation
        {
            set { filter.IsBilinearInterpolation = value; }
            get { return filter.IsBilinearInterpolation; }
        }

        Bitmap pictureItem;
        public Bitmap CanvasImage
        {
            set
            {
                pictureItem = value;

                startFT();
                pictureItem = filter.Bitmap;
                Invalidate();
            }
            get { return pictureItem; }
        }

        Point imageLocation = new Point();
        public Point ImageLocation
        {
            set { imageLocation = value; }
            get { return imageLocation; }
        }

        private void startFT()
        {
            if (pictureItem != null)
            {
                filter.Bitmap = pictureItem;
                vertex[0] = new PointF(imageLocation.X, imageLocation.Y);
                vertex[1] = new PointF(imageLocation.X + pictureItem.Width, imageLocation.Y);
                vertex[2] = new PointF(imageLocation.X + pictureItem.Width, imageLocation.Y + pictureItem.Height);
                vertex[3] = new PointF(imageLocation.X, imageLocation.Y + pictureItem.Height);

                for (int i = 0; i < 4; i++)
                {
                    recthandle[i] = new RectangleF(vertex[i].X - 2, vertex[i].Y - 2, 4, 4);
                }
                filter.FourCorners = vertex;
            }
        }

        Rectangle zoomedCanvas = new Rectangle();
        Rectangle visibleCanvas = new Rectangle();
        Matrix mxCanvasToControl, mxControlToCanvas; // transform matrix

        private void setup()
        {
            // setup zoomed canvas Rectangle
            zoomedCanvas.Width = (int)((float)originalCanvas.Width * zoomFactor);
            zoomedCanvas.Height = (int)((float)originalCanvas.Height * zoomFactor);
            this.AutoScrollMinSize = zoomedCanvas.Size;
            Point canvasLoc = new Point();
            if (zoomedCanvas.Width < this.ClientRectangle.Width)
                canvasLoc.X = (this.ClientRectangle.Width - zoomedCanvas.Width) / 2;
            else canvasLoc.X = AutoScrollPosition.X;
            if (zoomedCanvas.Height < this.ClientRectangle.Height)
                canvasLoc.Y = (this.ClientRectangle.Height - zoomedCanvas.Height) / 2;
            else canvasLoc.Y = AutoScrollPosition.Y;
            zoomedCanvas.Location = canvasLoc;

            // setup transform matrix
            mxCanvasToControl = new Matrix();
            mxCanvasToControl.Scale(zoomFactor, zoomFactor);
            mxCanvasToControl.Translate(canvasLoc.X, canvasLoc.Y, MatrixOrder.Append);

            mxControlToCanvas = mxCanvasToControl.Clone();
            mxControlToCanvas.Invert();

            visibleCanvas = this.ClientRectangle;
            visibleCanvas.Intersect(zoomedCanvas);

            Invalidate();
        }

        private Point toCanvas(Point pt)
        {
            Point[] pts = new Point[] { pt };
            if (mxControlToCanvas != null)
                mxControlToCanvas.TransformPoints(pts);
            return pts[0];
        }

        Point ptOnCanvas = new Point();

        bool isDrag = false;
        int moveFlag;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            ptOnCanvas = toCanvas(e.Location);
            for (int i = 0; i < 4; i++)
            {
                if (recthandle[i].Contains(ptOnCanvas))
                {
                    isDrag = true;
                    moveFlag = i;
                }
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            ptOnCanvas = toCanvas(e.Location);

            if (recthandle[0].Contains(ptOnCanvas) || recthandle[1].Contains(ptOnCanvas) ||
                    recthandle[2].Contains(ptOnCanvas) || recthandle[3].Contains(ptOnCanvas))
                this.Cursor = Cursors.Hand;
            else this.Cursor = Cursors.Default;

            if (isDrag && originalCanvas.Contains(ptOnCanvas))
            {
                recthandle[moveFlag] = new RectangleF(ptOnCanvas.X - 2, ptOnCanvas.Y - 2, 4, 4);
                vertex[moveFlag] = ptOnCanvas;
            }
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (isDrag)
            {
                isDrag = false;

                filter.FourCorners = vertex;
                pictureItem = filter.Bitmap;
                imageLocation = filter.ImageLocation;
                Invalidate();
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (e.Delta > 0) this.ZoomFactor += 0.1f;
            if (e.Delta < 0) this.ZoomFactor -= 0.1f;
        }

        protected override void OnScroll(ScrollEventArgs se)
        {
            setup();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            setup();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(new SolidBrush(canvasBackColor), visibleCanvas);
            g.Transform = mxCanvasToControl;

            if (pictureItem != null)
            {
                g.DrawImage(pictureItem, imageLocation);

                g.DrawPolygon(new Pen(Color.Yellow), vertex);
                for (int i = 0; i < 4; i++)
                    g.FillRectangle(new SolidBrush(Color.Red), recthandle[i]);
            }
        }
    }
}