using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ixts.Ausbildung.Geometry.PrinterApp
{
    public partial class Form1 : Form
    {
        private List<System.Drawing.Point[]> listOfDrawForms = new List<System.Drawing.Point[]>();
        private List<Polygon> listOfForms = new List<Polygon>(); 
        private int triangleCounter;
        private int quadliteralCounter;
        private SolidBrush sb = new SolidBrush(Color.Blue);
        private Pen pen = new Pen(Color.Blue);
        public Form1()
        {
            InitializeComponent();
        }
        
        private void btn_Draw_Click(object sender, EventArgs e)
        {
            if (tb_coordinates.Text.Length != 0)
            {
            var drawpoints = new List<System.Drawing.Point>();
            var formpoints = new List<Point>();
            var pointstrings = tb_coordinates.Text.Split(';');
            for (int i = 0; i < pointstrings.Length; i++)
            {
                var coordinats = pointstrings[i].Split('/');
                drawpoints.Add(new System.Drawing.Point(int.Parse(coordinats[0]), int.Parse(coordinats[1])));
                formpoints.Add(new Point(double.Parse(coordinats[0]), double.Parse(coordinats[1])));
               
            }
            pnl_drawField_Paint(drawpoints.ToArray(), formpoints.ToArray());  
            }

        }

        private void pnl_drawField_Paint(System.Drawing.Point[] drawpoints, Point[] formpoints)
        {
            if (dd_Polygons.SelectedIndex == 0)
            {
                listOfDrawForms.Add(drawpoints);
                listOfForms.Add(new Triangle(formpoints));
                triangleCounter = triangleCounter + 1;
                lb_ListofForms.Items.Add("Triangle" + triangleCounter);
            }
            if(dd_Polygons.SelectedIndex == 1)
            {
                listOfDrawForms.Add(drawpoints);
                listOfForms.Add(new Quadrilateral(formpoints));
                quadliteralCounter = quadliteralCounter + 1;
                lb_ListofForms.Items.Add("Quadliteral" + quadliteralCounter);
            }
            Field_Paint();

        }

        private void Field_Paint()
        {
            Graphics g = pnl_drawField.CreateGraphics();
            for (int i = 0; i < listOfDrawForms.Count; i++)
            {
                g.DrawPolygon(pen, listOfDrawForms[i]);
                g.FillPolygon(sb, listOfDrawForms[i]);
            }
        }

        private void btn_Erase_Click(object sender, EventArgs e) //250:200 = Panel.size
        {
            clear_Field();
            listOfDrawForms.Clear();
            listOfForms.Clear();
            lb_ListofForms.Items.Clear();
            tb_coordinates.Text = "";
        }

        private void clear_Field()
        {
            SolidBrush clearBrush = new SolidBrush(Color.White);
            Graphics g = pnl_drawField.CreateGraphics();
            g.FillRectangle(clearBrush, 0, 0, 250, 200);
        }

        private void btn_moveDown_Click(object sender, EventArgs e)
        {
            if (lb_ListofForms.SelectedIndex >= 0)
            {
            listOfForms[lb_ListofForms.SelectedIndex] = listOfForms[lb_ListofForms.SelectedIndex].Moved(0, 1);
            Polygon_Change();
            }

        }

        private void btn_moveUp_Click(object sender, EventArgs e)
        {
            if (lb_ListofForms.SelectedIndex >= 0)
            {
                listOfForms[lb_ListofForms.SelectedIndex] = listOfForms[lb_ListofForms.SelectedIndex].Moved(0, -1);
                Polygon_Change();
            }
        }

        private void btn_moveRight_Click(object sender, EventArgs e)
        {
            if (lb_ListofForms.SelectedIndex >= 0)
            {
                listOfForms[lb_ListofForms.SelectedIndex] = listOfForms[lb_ListofForms.SelectedIndex].Moved(1, 0);
                Polygon_Change();
            }
        }

        private void btn_moveLeft_Click(object sender, EventArgs e)
        {
            if (lb_ListofForms.SelectedIndex >= 0)
            {
                listOfForms[lb_ListofForms.SelectedIndex] = listOfForms[lb_ListofForms.SelectedIndex].Moved(-1, 0);
                Polygon_Change();
            }
        }

        private void Polygon_Change()
        {
            for (int i = 0; i < listOfForms[lb_ListofForms.SelectedIndex].Points.Length; i++)
            {
                listOfDrawForms[lb_ListofForms.SelectedIndex][i].X =
                    Convert.ToInt32(listOfForms[lb_ListofForms.SelectedIndex].Points[i].X);
                listOfDrawForms[lb_ListofForms.SelectedIndex][i].Y =
                    Convert.ToInt32(listOfForms[lb_ListofForms.SelectedIndex].Points[i].Y);
            }
            clear_Field();
            Field_Paint();
        }

        private void btn_zoomPlus_Click(object sender, EventArgs e)
        {
            if (lb_ListofForms.SelectedIndex >= 0)
            {
                var middlepoint = listOfForms[lb_ListofForms.SelectedIndex].Middle();
                listOfForms[lb_ListofForms.SelectedIndex] = listOfForms[lb_ListofForms.SelectedIndex].Zoomed(middlepoint, 2);
                Polygon_Change();
            }
        }

        private void btn_zoomMinus_Click(object sender, EventArgs e)
        {
            if (lb_ListofForms.SelectedIndex >= 0)
            {
                var middlepoint = listOfForms[lb_ListofForms.SelectedIndex].Middle();
                listOfForms[lb_ListofForms.SelectedIndex] = listOfForms[lb_ListofForms.SelectedIndex].Zoomed(middlepoint, 0.5);
                Polygon_Change();
            }
        }
    }
}
