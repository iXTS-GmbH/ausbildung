using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace ixts.Ausbildung.Geometry
{
    public class PolygonPrinter
    {
        private const string TRIANGLE = "Triangle";
        private const string QUADLITERAL = "Quadliteral";
        public Color Color = new Color();
        internal Dictionary<string, Polygon> Polygons = new Dictionary<string, Polygon>();
        private int triangleCounter;
        private int quadliteralCounter;

        public PolygonPrinter()
        {
            Color = Color.Black;
        }

        public void MovePolygon(string polygon, double moveX, double moveY)
        {
            Polygons[polygon] = Polygons[polygon].Moved(moveX, moveY);
        }

        public void ZoomPolygon(string polygon, double factor)
        {
            var middlepoint = Polygons[polygon].Middle();
            Polygons[polygon] = Polygons[polygon].Zoomed(middlepoint, factor);

        }

        public void Clear()
        {
            triangleCounter = 0;
            quadliteralCounter = 0;
            Polygons.Clear();
        }

        public String Create(Point point1, Point point2, Point point3)//Triangle
        {
            var points = new[] {point1,point2,point3};
            var newTriangle = new Triangle(points,Color);
            triangleCounter = triangleCounter + 1;
            var formname = string.Format("{0}{1}", TRIANGLE, triangleCounter);
            Polygons.Add(formname,newTriangle);
            return formname;
        }

        public String Create(Point point1, Point point2, Point point3, Point point4)//Quadliteral
        {
            var points = new[] {point1,point2,point3,point4};
            var newQuadliteral = new Quadliteral(points, Color);
            quadliteralCounter = quadliteralCounter + 1;
            var formname = string.Format("{0}{1}", QUADLITERAL, quadliteralCounter);
            Polygons.Add(formname, newQuadliteral);
            return formname; 
        }

        public Bitmap Print(int width, int height)
        {
            var bitmap = new Bitmap(width,height);
            var g = Graphics.FromImage(bitmap);
            foreach (var polygon in Polygons)
            {
                var p = new Pen(polygon.Value.Color);
                var sb = new SolidBrush(polygon.Value.Color);

                var drawpoints = new List<System.Drawing.Point>();
                foreach (var point in polygon.Value.Points)
                {
                    drawpoints.Add(PointToDrawingPointParser(point,height));
                }
                g.DrawPolygon(p,drawpoints.ToArray());
                g.FillPolygon(sb,drawpoints.ToArray());
            }
            return bitmap;
        }

        private System.Drawing.Point PointToDrawingPointParser(Point point, int bitmapHeight)
        {
            var x = Convert.ToInt32(point.X);
            var y = bitmapHeight - Convert.ToInt32(point.Y); //Um den 0/0 Punkt nach Links unten zu verschieben
            return new System.Drawing.Point(x, y);
        }

        public Bitmap Print()
        {
            return Print(Bitmapsize()[0], Bitmapsize()[1]);
        }

        private int[] Bitmapsize()
        {
            var heightvalues = new List<double>();
            var widthvalues = new List<double>();
            foreach (var polygon in Polygons.Values)
            {
                foreach (var point in polygon.Points)
                {
                    widthvalues.Add(point.X);
                    heightvalues.Add(point.Y);
                }
            }
            var size = new int[2];
            size[0] = Convert.ToInt32(widthvalues.ToArray().Max() + 5);
            size[1] = Convert.ToInt32(heightvalues.ToArray().Max() + 5);
            return size;
        }
    }
}
