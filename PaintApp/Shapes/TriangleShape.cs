using System;
using System.Drawing;

namespace PaintApp.Shapes
{
    public class TriangleShape : Shape
    {
        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(ShapeColor, IsSelected ? 3 : 1))
            {
                Point[] points = new Point[]
                {
                    new Point((X1 + X2) / 2, Y1), // Üst nokta
                    new Point(X1, Y2),             // Alt sol nokta
                    new Point(X2, Y2)              // Alt sağ nokta
                };

                g.DrawPolygon(pen, points);

                if (IsSelected)
                {
                    using (Pen highlightPen = new Pen(Color.Gray, 5))
                    {
                        g.DrawPolygon(highlightPen, points);
                    }
                }
            }
        }

        public override bool Contains(int x, int y)
        {
            Point[] points = new Point[]
            {
                new Point((X1 + X2) / 2, Y1),
                new Point(X1, Y2),
                new Point(X2, Y2)
            };

            int i, j = 2;
            bool inside = false;
            for (i = 0; i < 3; j = i++)
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
