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
        Shape tmpShape; //Хранит мнимые фигуры

        Pen pMain = new Pen(Color.Black);
        Pen pTemp = new Pen(Color.Gray);

        enum rdB_Positions { cross, line, circle };
        rdB_Positions Figures = new rdB_Positions();

        Boolean flagStart = false; //Флаг второй точки для линии
        Point lineStart; //Поле для записи координат первой точки для линии
        Point CircleCenter; //Поле для записи координат точки центра окружности

        public MainScreen()
        {
            InitializeComponent();
        }

        private void MainScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
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
                            lineStart = e.Location;
                            flagStart = true;
                        }
                        else
                        {
                            addShape(tmpShape);
                            flagStart = false;
                            Refresh();
                        }
                        break;
                    case rdB_Positions.circle:
                        if (!flagStart)
                        {
                            CircleCenter = e.Location;
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
            else if (e.Button == MouseButtons.Right)
            {
                foreach (Shape p in this.Shapes)
                {
                    if (p.IsNearTo(e.Location))
                    {
                        shapesList.SetSelected(Shapes.IndexOf(p), true);
                    }
                }
            }
        }

        private void MainScreen_Paint(object sender, PaintEventArgs e)
        {
            if (tmpShape != null) //Отрисовка мнимого объекта
            {
                tmpShape.DrawWith(e.Graphics, pTemp);
            }

            foreach (Shape p in this.Shapes) //Отрисовка готового объекта
            { 
                p.DrawWith(e.Graphics, pMain);
            }
        }

        private void addShape(Shape shape)
        {
            Shapes.Add(shape);
            shapesList.Items.Add(shape.DescriptionString);
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

        private void rdButt_Circle_CheckedChanged(object sender, EventArgs e)
        {
            Figures = rdB_Positions.circle;
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
                    case "Circle":
                        Shapes.Add(new Circle(sr));
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
                        lineStart = e.Location;
                        Refresh();
                    }
                    else
                    {
                        tmpShape = new Line(lineStart, e.Location);
                        Refresh();
                    }
                    break;
                case rdB_Positions.circle:
                    if (!flagStart)
                    {
                        CircleCenter = e.Location;
                        Refresh();
                    }
                    else
                    {
                        tmpShape = new Circle(CircleCenter, e.Location);
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

        private void shapesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void butt_ClearSelected_Click(object sender, EventArgs e)
        {
            while (shapesList.SelectedIndices.Count > 0)
            {
                Shapes.RemoveAt(shapesList.SelectedIndices[0]);
                shapesList.Items.RemoveAt(shapesList.SelectedIndices[0]);
            }
        }

        private void butt_ClearAll_Click(object sender, EventArgs e)
        {
            Shapes.Clear();
            shapesList.ClearSelected();
            shapesList.Items.Clear();
            flagStart = false;
            tmpShape = null;
            Refresh();
        }

        private void butt_CancelSelected_Click(object sender, EventArgs e)
        {
            shapesList.ClearSelected();
            Refresh();
        }
    }
}