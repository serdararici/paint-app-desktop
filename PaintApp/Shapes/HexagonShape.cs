using System;
using System.Drawing;

namespace PaintApp.Shapes
{
    public class HexagonShape : Shape
    {
        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(ShapeColor, IsSelected ? 3 : 1))
            {
                Point[] points = CalculateHexagonPoints();
                g.DrawPolygon(pen, points);

                if (IsSelected)
                {
                    using (Pen highlightPen = new Pen(Color.Blue, 2))
                    {
                        g.DrawPolygon(highlightPen, points);
                    }
                }
            }
        }

        private Point[] CalculateHexagonPoints()
        {
            Point[] points = new Point[6];
            int centerX = (X1 + X2) / 2;
            int centerY = (Y1 + Y2) / 2;
            int width = Math.Abs(X2 - X1);
            int height = Math.Abs(Y2 - Y1);
            double radius = Math.Min(width, height) / 2;

            for (int i = 0; i < 6; i++)
            {
                double angle = i * Math.PI / 3;
                points[i] = new Point(
                    (int)(centerX + radius * Math.Cos(angle)),
                    (int)(centerY + radius * Math.Sin(angle))
                );
            }

            return points;
        }

        public override bool Contains(int x, int y)
        {
            Point[] points = CalculateHexagonPoints();
            bool inside = false;
            for (int i = 0, j = points.Length - 1; i < points.Length; j = i++)
            {
                if (((points[i].Y > y) != (points[j].Y > y)) &&
                    (x < (points[j].X - points[i].X) * (y - points[i].Y) /
                    (points[j].Y - points[i].Y) + points[i].X))
                {
                    inside = !inside;
                }
            }
            return inside;
        }
    }
}
