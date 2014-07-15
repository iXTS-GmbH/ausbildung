using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace ixts.Ausbildung.Geometry
{
    public class PolygonPrinter
    {
        private Dictionary<string, Polygon> polygons = new Dictionary<string, Polygon>();
        private int triangleCounter;
        private int quadliteralCounter;

        public void MovePolygon(string polygon, double moveX, double moveY)
        {
            polygons[polygon] = polygons[polygon].Moved(moveX, moveY);
        }

        public void ZoomPolygon(string polygon, double factor)
        {
            var middlepoint = polygons[polygon].Middle();
            polygons[polygon] = polygons[polygon].Zoomed(middlepoint, factor);
        }

        public void Clear()
        {
            triangleCounter = 0;
            quadliteralCounter = 0;
            polygons.Clear();
        }

        public String Create(Point point1, Point point2, Point point3)//Triangle
        {
            var newTriangle = new Triangle(new [] {point1, point2, point3});
            triangleCounter = triangleCounter + 1;
            polygons.Add("Triangle" + triangleCounter,newTriangle);
            return "Triangle" + triangleCounter;
        }

        public String Create(Point point1, Point point2, Point point3, Point point4)//Quadliteral
        {
            var newQuadliteral = new Triangle(new[] { point1, point2, point3, point4 });
            quadliteralCounter = quadliteralCounter + 1;
            polygons.Add("Quadliteral" + quadliteralCounter, newQuadliteral);
            return "Quadliteral" + quadliteralCounter; 
        }

        public Bitmap Print(int height, int width)
        {
            Bitmap bitmap = new Bitmap(width,height);
            Graphics g = Graphics.FromImage(bitmap);
            Pen p = new Pen(Color.Black);
            SolidBrush sb = new SolidBrush(Color.Black);
            foreach (var polygon in polygons)
            {
                var drawpoints = new List<System.Drawing.Point>();
                foreach (var point in polygon.Value.Points)
                {
                    drawpoints.Add(new System.Drawing.Point(Convert.ToInt32(point.X),height -  Convert.ToInt32(point.Y)));
                }
                g.DrawPolygon(p,drawpoints.ToArray());
                g.FillPolygon(sb,drawpoints.ToArray());
            }
            return bitmap;
        }

        public Bitmap Print()
        {
            Bitmap bitmap = new Bitmap(BitmapWidth(), BitmapHeight());
            Graphics g = Graphics.FromImage(bitmap);
            Pen p = new Pen(Color.Black);
            SolidBrush sb = new SolidBrush(Color.Black);
            foreach (var polygon in polygons)
            {
                var drawpoints = new List<System.Drawing.Point>();
                foreach (var point in polygon.Value.Points)
                {
                    drawpoints.Add(new System.Drawing.Point(Convert.ToInt32(point.X), BitmapHeight() - Convert.ToInt32(point.Y)));
                }
                g.DrawPolygon(p, drawpoints.ToArray());
                g.FillPolygon(sb, drawpoints.ToArray());
            }
            return bitmap;
        }

        private int BitmapHeight()
        {
            var values = new List<double>();
            foreach (var polygon in polygons.Values)
            {
                foreach (var point in polygon.Points)
                {
                    values.Add(point.Y);
                }
            }
            return Convert.ToInt32(values.ToArray().Max() + 5);
        }

        private int BitmapWidth()
        {
            var values = new List<double>();
            foreach (var polygon in polygons.Values)
            {
                foreach (var point in polygon.Points)
                {
                    values.Add(point.X);
                }
            }
            return Convert.ToInt32(values.ToArray().Max() + 5);
        }
    }
}
