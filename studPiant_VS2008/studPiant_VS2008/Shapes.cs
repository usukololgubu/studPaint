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
        public abstract void SaveTo(StreamWriter sw);
    }

    class Cross : Shape
    {
        private Point C;

        public Cross(Point _C)
        {
            C = _C;
        }

        public override void DrawWith(Graphics g, Pen p)
        {
            g.DrawLine(p, C.X - 5, C.Y - 5, C.X + 5, C.Y + 5);
            g.DrawLine(p, C.X + 5, C.Y - 5, C.X - 5, C.Y + 5);
        }

        public override void SaveTo(StreamWriter sw) //Сохранение
        {
            sw.WriteLine("Cross");
            sw.WriteLine(Convert.ToString(C.X) + " " + Convert.ToString(C.Y));
        }
    }

    class Line : Shape
    {
        private Point S, F;

        public Line(Point _S, Point _F)
        {
            this.S = _S;
            this.F = _F;
        }

        public override void DrawWith(Graphics g, Pen p)
        {
            g.DrawLine(p, S.X, S.Y, F.X, F.Y);
        }

        public override void SaveTo(StreamWriter sw) //Сохранение
        {
            sw.WriteLine("Line");
            sw.WriteLine(Convert.ToString(S.X) + " " + Convert.ToString(S.Y));
            sw.WriteLine(Convert.ToString(F.X) + " " + Convert.ToString(F.Y));
        }
    }
}