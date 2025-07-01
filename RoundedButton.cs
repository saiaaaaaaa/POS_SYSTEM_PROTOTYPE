using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace POS_System_w_Price_and_Payment_PROTOTYPE
{
    class RoundedButton : Button
    {
        public Color BorderColor
        {
            get;
            set;
        }

        public float BorderWidth
        {
            get;
            set;
        }

        public int Radius
        {
            get;
            set;
        }

        public RoundedButton()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
            BorderColor = Color.Black;
            BorderWidth = 2;
            Radius = 24;
        }

        GraphicsPath RoundPath(RectangleF RectangleF, int Radius)
        {
            float m = 4f;
            float r2 = Radius / 2f;
            GraphicsPath Path = new GraphicsPath();

            Path.AddArc(RectangleF.X + m, RectangleF.Y + m, Radius, Radius, 180, 90);
            Path.AddLine(RectangleF.X + r2 + m, RectangleF.Y + m, RectangleF.Width - r2 - m, RectangleF.Y + m);
            Path.AddArc(RectangleF.X + RectangleF.Width - Radius - m, RectangleF.Y + m, Radius, Radius, 270, 90);
            Path.AddLine(RectangleF.Width - m, RectangleF.Y + r2, RectangleF.Width - m, RectangleF.Height - r2 - m);
            Path.AddArc(RectangleF.X + RectangleF.Width - Radius - m, RectangleF.Y + RectangleF.Height - Radius - m, Radius, Radius, 0, 90);
            Path.AddLine(RectangleF.Width - r2 - m, RectangleF.Height - m, RectangleF.X + r2 - m, RectangleF.Height - m);
            Path.AddArc(RectangleF.X + m, RectangleF.Y + RectangleF.Height - Radius - m, Radius, Radius, 90, 90);
            Path.AddLine(RectangleF.X + m, RectangleF.Height - r2 - m, RectangleF.X + m, RectangleF.Y + r2 + m);

            Path.CloseFigure();
            return Path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            RectangleF RectangleF = new RectangleF(0, 0, Width, Height);
            GraphicsPath Path = RoundPath(RectangleF, Radius);
            Region = new Region(Path);
            using (Pen Pen = new Pen(BorderColor, BorderWidth))
            {
                Pen.Alignment = PenAlignment.Inset;
                e.Graphics.DrawPath(Pen, Path);
            }
        }
    }
}
