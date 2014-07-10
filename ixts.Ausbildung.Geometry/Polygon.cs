
using System;
using System.Collections.Generic;
using System.Linq;

namespace ixts.Ausbildung.Geometry
{
    public class Polygon
    {
        public Point[] Points;

        public Polygon(Point[] points)
        {
            Points = points;
        }

        public double Perimeter()
        {
            var perimeter = 0.0;
            for (var i = 0; i < Points.Length; i++)
            {
                if (i == Points.Length - 1)
                {
                    perimeter = perimeter + Points[i].Distance(Points[0]);
                }
                else
                {
                    perimeter = perimeter + Points[i].Distance(Points[i + 1]);
                }
            }
            return perimeter;
        }

        public double Area() //Muss ich Patrick nach allgemeiner Formel fragen (oder googlen)
        {
        //double sA = B.Distance(C);
        //double sB = C.Distance(A);
        //double sC = A.Distance(B);
        //double s = (sA + sB + sC) / 2;
        //double flaeche = Math.Sqrt(s * (s - sA) * (s - sB) * (s - sC)); //Fläche Dreieck
            return 0;
        }

        public Point LowerLeft()
        {
            var xValues = new List<double>();
            var yValues = new List<double>();
            foreach (Point point in Points)
            {
                xValues.Add(point.X);
                yValues.Add(point.Y);
            }
            return new Point(xValues.ToArray().Min(), yValues.ToArray().Min());
        }

        public Point UpperRight()
        {
            var xValues = new List<double>();
            var yValues = new List<double>();
            foreach (Point point in Points)
            {
                xValues.Add(point.X);
                yValues.Add(point.Y);
            }
            return new Point(xValues.ToArray().Max(), yValues.ToArray().Max());
        }

        public Boolean IsSame(Polygon polygon, double within)
        {

            Boolean isSamecheck = true;
            for (var i = 0; i < Points.Length; i++)
            {
                if (isSamecheck)
                {
                    isSamecheck = Points[i].X + within >= polygon.Points[i].X && Points[i].X - within <= polygon.Points[i].X;
                }
                if (isSamecheck)
                {
                    isSamecheck = Points[i].Y + within >= polygon.Points[i].Y && Points[i].Y - within <= polygon.Points[i].Y;
                }

            }
            return isSamecheck;
        }

        public Polygon Moved(double moveX, double moveY)
        {
            var mpoints = new List<Point>();
            for (int i = 0; i < Points.Length; i++)
            {
                mpoints.Add(new Point(Points[i].X + moveX, Points[i].Y + moveY));
            }
            return new Polygon(mpoints.ToArray());//Muss spezialform (Triangle,Quadliteral) zurückgeben
        }

        public Polygon Zoomed(double factor)
        {
            var mpoints = new List<Point>();
            for (int i = 0; i < Points.Length; i++)
            {
                mpoints.Add(new Point(Points[i].X*factor, Points[i].Y*factor));
            }
            return new Polygon(mpoints.ToArray());//Muss spezialform (Triangle,Quadliteral) zurückgeben
        }

        public Polygon Zoomed(Point point, double factor)
        {

            var mPoints = new List<Point>();
            for (int i = 0; i < Points.Length; i++)
            {
                mPoints.Add(new Point((Points[i].X - point.X) * factor + point.X, (Points[i].Y - point.Y) * factor + point.Y));
            }
            return new Polygon(mPoints.ToArray());//Muss spezialform (Triangle,Quadliteral) zurückgeben
        }

        public Polygon Rotate(double angle)
        {
            var rPoints = new List<Point>();
            for (int i = 0; i < Points.Length; i++)
            {
                var rX = Points[i].X * Math.Cos(angle*Math.PI/180) + Points[i].Y * Math.Sin(angle*Math.PI/180);            //x' = x·cosφ + y·sinφ
                var rY = Points[i].X * (0 - Math.Sin(angle*Math.PI/180)) + Points[i].Y * Math.Cos(angle*Math.PI/180);      //y' = x·(-sinφ) + y·cosφ
                rX = Math.Round(rX, 2);
                rY = Math.Round(rY, 2);
                rPoints.Add(new Point(rX,rY));
            }
            return new Polygon(rPoints.ToArray());
        }

        public Polygon Rotate(Point point, double angle)
        {
            //Vorgehen:
            //Punkte so verschieben das point(x,y) = Point(0,0)
            //Mit Rotate drehen
            //Punkte um vorher geändertes maß zurückverschieben
            var mpoints = new List<Point>();
            for (int i = 0; i < Points.Length; i++)
            {
               mpoints.Add(Points[i].Moved(-point.X, -point.Y));
            }
            var movedPolygon = new Polygon(mpoints.ToArray()).Rotate(angle);
            var rotatedPolygon = movedPolygon.Moved(point.X, point.Y);
            return rotatedPolygon;
        }

        public Point Middle()
        {
            return new Point((UpperRight().X - LowerLeft().X)/2 + LowerLeft().X, (UpperRight().Y - LowerLeft().Y)/2 + LowerLeft().X );
        }

    }
}

        //public Triangle Zoomed(Point p, double f)
        //{

        //    var zA = new Point((A.X - p.X)*f + p.X, (A.Y - p.Y)*f + p.Y);
        //    var zB = new Point((B.X - p.X)*f + p.X, (B.Y - p.Y)*f + p.Y);
        //    var zC = new Point((C.X - p.X)*f + p.X, (C.Y - p.Y)*f + p.Y);
        //    var zTriangle = new Triangle(zA, zB, zC);
        //    return zTriangle;
        //}