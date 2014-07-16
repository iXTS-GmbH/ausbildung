using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace ixts.Ausbildung.Geometry
{
    public class PolygonPrinter
    {
        internal Dictionary<string, Polygon> polygons = new Dictionary<string, Polygon>();
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

        public String Create(Point point1, Point point2, Point point3)//Triangle //Todo Redundanz entfernen
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

        public Bitmap Print(int width, int height)
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
                    drawpoints.Add(new System.Drawing.Point(Convert.ToInt32(point.X),height -  Convert.ToInt32(point.Y)));//TODO height - in methode auslagern und sinnvoll genennen
                }
                g.DrawPolygon(p,drawpoints.ToArray());
                g.FillPolygon(sb,drawpoints.ToArray());
            }
            return bitmap;
        }

        public Bitmap Print()
        {
            return Print(Bitmapsize()[0], Bitmapsize()[1]);
        }

        private int[] Bitmapsize()
        {
            var heightvalues = new List<double>();
            var widthvalues = new List<double>();
            foreach (var polygon in polygons.Values)
            {
                foreach (var point in polygon.Points)
                {
                    widthvalues.Add(point.X);
                    heightvalues.Add(point.Y);
                }
            }
            var size = new double[2];
            size[0] = Convert.ToInt32(widthvalues.ToArray().Max() + 5);
            size[1] = Convert.ToInt32(heightvalues.ToArray().Max() + 5);
            return size;
        }

    }
}
