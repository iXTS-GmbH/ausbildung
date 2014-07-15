﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ixts.Ausbildung.Geometry.PrinterApp
{
    public partial class PrinterApp : Form
    {
        private PolygonPrinter polygonPrinter;
        private readonly List<Polygon> listOfForms = new List<Polygon>();
        private int trianglecounter;
        private int quadliteralcounter;
        public PrinterApp()
        {
            InitializeComponent();
        }
        
        private void btn_Draw_Click(object sender, EventArgs e)
        {

            var isTriangle = dd_Polygons.SelectedIndex == 0;
            var form = CreateForm(isTriangle, tb_coordinates.Text);
            listOfForms.Add(form);
            PaintPolygon(form,pnl_drawField.Height);
            AddPolygonToListbox(isTriangle);
        }

        private void AddPolygonToListbox(Boolean isTriangle)
        {
            if (isTriangle)
            {
                trianglecounter = trianglecounter + 1;
                lb_ListofForms.Items.Add("Triangle" + trianglecounter);
            }
            else
            {
                quadliteralcounter = quadliteralcounter + 1;
                lb_ListofForms.Items.Add("Quadliteral" + quadliteralcounter);
            }
        }

        private void PaintPolygon(Polygon form, int height)
        {
            var drawpoints = new List<System.Drawing.Point>();
            foreach (var point in form.Points)
            {
                drawpoints.Add(new System.Drawing.Point(Convert.ToInt32(point.X), Convert.ToInt32(height-point.Y)));
            }
            Graphics g = pnl_drawField.CreateGraphics();
            Pen p = new Pen(Color.Blue);
            SolidBrush sb = new SolidBrush(Color.Blue);
            g.DrawPolygon(p,drawpoints.ToArray());
            g.FillPolygon(sb,drawpoints.ToArray());
        }

        private Polygon CreateForm(Boolean isTriangle, string coordinatesText)
        {
            var points = StringToPoints(coordinatesText);
            if (isTriangle)
            {
                return new Triangle(points);
            }
            return new Quadrilateral(points);
        }

        private Point[] StringToPoints(string coordinatesText)
        {
            if (tb_coordinates.Text.Length != 0)
            {
                var points = new List<Point>();
                var pointstrings = coordinatesText.Split(';');
                foreach (string pointstring in pointstrings)
                {
                   var coordinates = pointstring.Split('/');
                   points.Add(new Point(double.Parse(coordinates[0]), double.Parse(coordinates[1])));
                }
                return points.ToArray();
            }
            return null;
        }

        private void btn_Erase_Click(object sender, EventArgs e)
        {
            ClearField();
            ClearLists();
        }

        private void ClearLists()
        {
            
            listOfForms.Clear();
            lb_ListofForms.Items.Clear();
            trianglecounter = 0;
            quadliteralcounter = 0;
        }

        private void ClearField()
        {
            Graphics g = pnl_drawField.CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.White);
            g.FillRectangle(sb,0,0,pnl_drawField.Width,pnl_drawField.Height);
        }

        private void btn_moveUp_Click(object sender, EventArgs e)
        {
            listOfForms[lb_ListofForms.SelectedIndex] = listOfForms[lb_ListofForms.SelectedIndex].Moved(0, 1);
            ReDraw();
        }

        private void ReDraw()
        {
            ClearField();
            foreach (var form in listOfForms)
            {
                PaintPolygon(form, pnl_drawField.Height);
            }
        }

        private void btn_moveDown_Click(object sender, EventArgs e)
        {
            listOfForms[lb_ListofForms.SelectedIndex] = listOfForms[lb_ListofForms.SelectedIndex].Moved(0,-1);
            ReDraw();
        }

        private void btn_moveLeft_Click(object sender, EventArgs e)
        {
            listOfForms[lb_ListofForms.SelectedIndex] = listOfForms[lb_ListofForms.SelectedIndex].Moved(-1,0);
            ReDraw();
        }

        private void btn_moveRight_Click(object sender, EventArgs e)
        {
            listOfForms[lb_ListofForms.SelectedIndex] = listOfForms[lb_ListofForms.SelectedIndex].Moved(1,0);
            ReDraw();
        }

        private void btn_zoomPlus_Click(object sender, EventArgs e)
        {
            ZoomPolygon(2);
        }

        private void btn_zoomMinus_Click(object sender, EventArgs e)
        {
            ZoomPolygon(0.5);
        }

        private void ZoomPolygon(double factor)
        {
            var middlepoint = listOfForms[lb_ListofForms.SelectedIndex].Middle();
            listOfForms[lb_ListofForms.SelectedIndex] = listOfForms[lb_ListofForms.SelectedIndex].Zoomed(middlepoint,factor);
            ReDraw();
        }



    }
}
