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
        Shape tmpShape; //Поле для хранения мнимой фигуры

        Pen pMain = new Pen(Color.Black);
        Pen pTemp = new Pen(Color.Gray);

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
                    addShape(tmpShape);
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
                        addShape(tmpShape);
                        flagStart = false;
                        Refresh();
                    }
                    break;
            }
            //Shapes.Add(tmpShape);
            this.Refresh();
        }

        private void MainScreen_Paint(object sender, PaintEventArgs e)
        {
            if (tmpShape != null) //Отрисовка мнимого объекта
            {
                tmpShape.DrawWith(e.Graphics, pTemp);
            }

            foreach (Shape p in this.Shapes)
            { //Отрисовка готовых объектов
                p.DrawWith(e.Graphics, pMain);
            }
        }

        private void addShape(Shape shape)
        {
            Shapes.Add(shape);
        }

        private void rdButt_Cross_CheckedChanged(object sender, EventArgs e)
        {
            Figures = rdB_Positions.cross;
            tmpShape = null;
            Refresh();
        }

        private void rdButt_Lines_CheckedChanged(object sender, EventArgs e)
        {
            Figures = rdB_Positions.line;
            tmpShape = null;
            Refresh();
        }

        private void сохранитькакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string curFile = "allFigures"; //Имя файла для записи
            StreamWriter sw = new StreamWriter(curFile);

            flagStart = false;
            foreach (Shape p in this.Shapes)
            {
                p.SaveTo(sw);
            }
            sw.Close();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string curFile = "allFigures"; //Имя файла для записи
            if (openFileDialog1.ShowDialog() == DialogResult.OK) //Выбрать файл вручную
            {
                curFile = openFileDialog1.FileName;
            }
            StreamReader sr = new StreamReader(curFile);

            while (!sr.EndOfStream)
            {
                string type = sr.ReadLine();
                flagStart = false;
                switch (type)
                {
                    case "Cross":
                        Shapes.Add(new Cross(sr));
                        break;
                    case "Line":
                        Shapes.Add(new Line(sr));
                        break;
                }
            }
            sr.Close();
            Refresh();
        }

        private void MainScreen_MouseMove(object sender, MouseEventArgs e)
        {
            switch (Figures)
            {
                case rdB_Positions.cross:
                    tmpShape = new Cross(e.Location);
                    Refresh();
                    break;
                case rdB_Positions.line:
                    if (!flagStart)
                    {
                        LS = e.Location;
                        Refresh();
                    }
                    else
                    {
                        tmpShape = new Line(LS, e.Location);
                        Refresh();
                    }
                    break;
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }
    }
}