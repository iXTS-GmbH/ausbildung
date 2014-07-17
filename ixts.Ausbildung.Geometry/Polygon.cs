
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

        public double Area()
        {
            double sum1 = 0;
            double sum2 = 0;
            for (int i = 0; i < Points.Length; i++) //Formel: A = (n.X*n+1.Y (n.X*0.Y(Ende)) - n.Y*n+1.X (n.Y*0.X(Ende)))/2
            {
                if (i == Points.Length - 1)
                {
                    sum1 = sum1 + Points[i].X*Points[0].Y;
                    sum2 = sum2 + Points[i].Y*Points[0].X;
                }
                else
                {
                    sum1 = sum1 + Points[i].X*Points[i + 1].Y;
                    sum2 = sum2 + Points[i].Y*Points[i + 1].X;
                }
            }
            double flaeche = (sum1 - sum2)/2;
            return flaeche;
        }

        public Point LowerLeft()
        {
            var xValues = new List<double>();
            var yValues = new List<double>();
            foreach (var point in Points)
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
            return new Polygon(mpoints.ToArray());
        }

        public Polygon Zoomed(double factor)
        {
            var mpoints = new List<Point>();
            for (int i = 0; i < Points.Length; i++)
            {
                mpoints.Add(new Point(Points[i].X*factor, Points[i].Y*factor));
            }
            return new Polygon(mpoints.ToArray());
        }

        public Polygon Zoomed(Point point, double factor)
        {

            var mPoints = new List<Point>();
            for (int i = 0; i < Points.Length; i++)
            {
                mPoints.Add(new Point((Points[i].X - point.X) * factor + point.X, (Points[i].Y - point.Y) * factor + point.Y));
            }
            return new Polygon(mPoints.ToArray());
        }

        public Polygon Rotate(double angle)
        {
            var rPoints = new List<Point>();
            foreach (Point point in Points)
            {
                var rX = point.X * Math.Cos(angle*Math.PI/180) + point.Y * Math.Sin(angle*Math.PI/180);            //x' = x·cosφ + y·sinφ
                var rY = point.X * (0 - Math.Sin(angle*Math.PI/180)) + point.Y * Math.Cos(angle*Math.PI/180);      //y' = x·(-sinφ) + y·cosφ
                rX = Math.Round(rX, 3);
                rY = Math.Round(rY, 3);
                rPoints.Add(new Point(rX,rY));
            }
            return new Polygon(rPoints.ToArray());
        }

        public Polygon Rotate(Point point, double angle)
        {
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

        public override bool Equals(object other)
        {
            var otherPolygon = other as Polygon;
            if(otherPolygon != null && Points.Length == otherPolygon.Points.Length)
            {
                foreach (var point in otherPolygon.Points)
                {
                    if (!Points.Contains(point))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}