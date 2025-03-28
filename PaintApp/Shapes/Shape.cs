using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PaintApp.Shapes
{
    public abstract class Shape
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public Color ShapeColor { get; set; }
        public bool IsSelected { get; set; }

        public abstract void Draw(Graphics g);
        public abstract bool Contains(int x, int y);
    }
}
