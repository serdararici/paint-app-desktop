using System;
using System.Drawing;

namespace PaintApp.Shapes
{
    public class EllipseShape : Shape
    {
        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(ShapeColor, IsSelected ? 3 : 1))
            {
                int x = Math.Min(X1, X2);
                int y = Math.Min(Y1, Y2);
                int width = Math.Abs(X2 - X1);
                int height = Math.Abs(Y2 - Y1);
                g.DrawEllipse(pen, x, y, width, height);

                if (IsSelected)
                {
                    using (Pen highlightPen = new Pen(Color.Gray, 5))
                    {
                        g.DrawEllipse(highlightPen, x - 2, y - 2, width + 4, height + 4);
                    }
                }
            }
        }

        public override bool Contains(int x, int y)
        {
            int left = Math.Min(X1, X2);
            int top = Math.Min(Y1, Y2);
            int right = Math.Max(X1, X2);
            int bottom = Math.Max(Y1, Y2);

            return x >= left && x <= right && y >= top && y <= bottom;
        }
    }
}
