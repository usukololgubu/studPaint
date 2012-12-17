using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace studPiant_VS2008
{
    public partial class MainScreen : Form
    {
        List<Shape> Shapes = new List<Shape>(); //Хранит все фигуры
        Shape Shape; //Поле для хранения текущей фигуры
        Pen pMain = new Pen(Color.Black);
        enum rdB_Positions {cross, line};
        rdB_Positions Figures = new rdB_Positions();
        Boolean flagStart = false; //Флаг второй точки для линии
        Point LS; //Поле для записи координат первой точки для линии

        public MainScreen()
        {
            InitializeComponent();
        }

        private void MainScreen_MouseDown(object sender, MouseEventArgs e)
        {
            switch (Figures)
            {
                case rdB_Positions.cross:
                    flagStart = false;
                    Shape = new Cross(e.Location);
                    Refresh();
                    break;
                case rdB_Positions.line:
                    if (!flagStart)
                    {
                        LS = e.Location;
                        flagStart = true;
                    }
                    else
                    {
                        Shape = new Line(LS, e.Location);
                        flagStart = false;
                        Refresh();
                    }
                    break;
            }
            
            Shapes.Add(Shape);
            this.Refresh();
        }

        private void MainScreen_Paint(object sender, PaintEventArgs e)
        {
            foreach (Shape p in this.Shapes)
            { //Отрисовка готовых объектов
                p.DrawWith(e.Graphics, pMain);
            }
        }

        private void rdButt_Cross_CheckedChanged(object sender, EventArgs e)
        {
            Figures = rdB_Positions.cross;
        }

        private void rdButt_Lines_CheckedChanged(object sender, EventArgs e)
        {
            Figures = rdB_Positions.line;
        }
    }
}