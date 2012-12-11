using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace studPiant_VS2008
{
    abstract class Shape
    {
        public abstract void DrawWith(Graphics g, Pen p);
    }

    class Cross : Shape
    {
        private Point C = new Point();

        public Cross(Point _C)
        {
            C = _C;
        }

        public override void DrawWith(Graphics g, Pen p)
        {
            g.DrawLine(p, C.X - 5, C.Y - 5, C.X + 5, C.Y + 5);
            g.DrawLine(p, C.X + 5, C.Y - 5, C.X - 5, C.Y + 5);
        }
    }
}