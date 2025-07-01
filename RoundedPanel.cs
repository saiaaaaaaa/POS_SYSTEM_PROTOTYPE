using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace POS_System_w_Price_and_Payment_PROTOTYPE
{
    class RoundedPanel : Panel
    {
        public int Radius
        {
            get;
            set;
        }

        public RoundedPanel()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
            Radius = 24;
        }

        GraphicsPath RoundPath(RectangleF RectangleF, int Radius)
        {
            float r2 = Radius / 2f;
            GraphicsPath Path = new GraphicsPath();
            Path.AddArc(RectangleF.X, RectangleF.Y, Radius, Radius, 180, 90);
            Path.AddLine(RectangleF.X + r2, RectangleF.Y, RectangleF.Width - r2, RectangleF.Y);
            Path.AddArc(RectangleF.X + RectangleF.Width - Radius, RectangleF.Y, Radius, Radius, 270, 90);
            Path.AddLine(RectangleF.Width, RectangleF.Y + r2, RectangleF.Width, RectangleF.Height - r2);
            Path.AddArc(RectangleF.X + RectangleF.Width - Radius, RectangleF.Y + RectangleF.Height - Radius, Radius, Radius, 0, 90);
            Path.AddLine(RectangleF.Width - r2, RectangleF.Height, RectangleF.X + r2, RectangleF.Height);
            Path.AddArc(RectangleF.X, RectangleF.Y + RectangleF.Height - Radius, Radius, Radius, 90, 90);
            Path.AddLine(RectangleF.X, RectangleF.Height - r2, RectangleF.X, RectangleF.Y + r2);
            Path.CloseFigure();
            return Path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            RectangleF RectangleF = new RectangleF(0, 0, Width, Height);
            GraphicsPath Path = RoundPath(RectangleF, Radius);
            Region = new Region(Path);
            e.Graphics.FillPath(new SolidBrush(BackColor), Path);
        }
    }
}
