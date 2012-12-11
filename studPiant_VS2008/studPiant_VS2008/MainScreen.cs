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

        public MainScreen()
        {
            InitializeComponent();
        }

        private void MainScreen_MouseDown(object sender, MouseEventArgs e)
        {
            Shape = new Cross(e.Location);
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
    }
}