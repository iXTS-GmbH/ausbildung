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
            Graphics g = pnl_drawField.CreateGraphics();
            Pen p = new Pen(Color.Black);
            SolidBrush sb = new SolidBrush(Color.Blue);
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
            paint(g,p,sb);
            lbl_control.Text = "Painted";

        }

        private void paint(Graphics g, Pen p, SolidBrush sb)
        {
            for (int i = 0; i < listOfDrawForms.Count; i++)
            {
                g.DrawPolygon(p, listOfDrawForms[i]);
                g.FillPolygon(sb, listOfDrawForms[i]);
            }
        }

        private void btn_Erase_Click(object sender, EventArgs e) //250:200 = Panel.size
        {
            clear_Field();
            listOfDrawForms.Clear();
            listOfForms.Clear();
            lb_ListofForms.Items.Clear();
            lbl_control.Text = "Erased";
        }

        private void clear_Field()
        {
            Graphics g = pnl_drawField.CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.White);
            g.FillRectangle(sb, 0, 0, 250, 200);
        }

        private void btn_moveDown_Click(object sender, EventArgs e)
        {
            listOfForms[lb_ListofForms.SelectedIndex] = listOfForms[lb_ListofForms.SelectedIndex].Moved(0, 1);
            for (int i = 0; i < listOfForms[lb_ListofForms.SelectedIndex].Points.Length; i++)
            {
                listOfDrawForms[lb_ListofForms.SelectedIndex][i].X = Convert.ToInt32(listOfForms[lb_ListofForms.SelectedIndex].Points[i].X);
                listOfDrawForms[lb_ListofForms.SelectedIndex][i].Y = Convert.ToInt32(listOfForms[lb_ListofForms.SelectedIndex].Points[i].Y);
            }
            Graphics g = pnl_drawField.CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.Blue);
            Pen p = new Pen(Color.Blue);
            clear_Field();
            paint(g,p,sb);
        }

        private void btn_moveUp_Click(object sender, EventArgs e)
        {
            listOfForms[lb_ListofForms.SelectedIndex] = listOfForms[lb_ListofForms.SelectedIndex].Moved(0, -1);
            for (int i = 0; i < listOfForms[lb_ListofForms.SelectedIndex].Points.Length; i++)
            {
                listOfDrawForms[lb_ListofForms.SelectedIndex][i].X = Convert.ToInt32(listOfForms[lb_ListofForms.SelectedIndex].Points[i].X);
                listOfDrawForms[lb_ListofForms.SelectedIndex][i].Y = Convert.ToInt32(listOfForms[lb_ListofForms.SelectedIndex].Points[i].Y);
            }
            Graphics g = pnl_drawField.CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.Blue);
            Pen p = new Pen(Color.Blue);
            clear_Field();
            paint(g, p, sb);
        }
    }
}
