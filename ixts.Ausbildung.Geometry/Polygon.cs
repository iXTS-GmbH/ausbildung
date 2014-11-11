
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ixts.Ausbildung.Geometry
{
    public class Polygon
    {
        public Point[] Points;
        public Color Color;

        public Polygon(Point[] points,Color color)
        {
            Points = points;
            Color = color;
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
            var values = GetCoordinateValues();
            return new Point(values[0].ToArray().Min(), values[1].ToArray().Min());
        }

        public Point UpperRight()
        {

            var values = GetCoordinateValues();
            return new Point(values[0].ToArray().Max(), values[1].ToArray().Max());
        }

        private List<double>[] GetCoordinateValues()
        {
            var values = new List<double>[2];
            values[0] = new List<double>();
            values[1] = new List<double>();
            foreach (Point point in Points)
            {
                values[0].Add(point.X);
                values[1].Add(point.Y);
            }
            return values;
        }

        public Boolean IsSame(Polygon polygon, double within)
        {
            for (var i = 0; i < Points.Length; i++)
            {
                if (!(Points[i].X + within >= polygon.Points[i].X && Points[i].X - within <= polygon.Points[i].X) || !(Points[i].Y + within >= polygon.Points[i].Y && Points[i].Y - within <= polygon.Points[i].Y))
                {
                    return false;
                }
            }
            return true;
        }

        public Polygon Moved(double moveX, double moveY)
        {
            var mpoints = new List<Point>();
            for (int i = 0; i < Points.Length; i++)
            {
                mpoints.Add(new Point(Points[i].X + moveX, Points[i].Y + moveY));
            }
            return new Polygon(mpoints.ToArray(),Color);
        }

        public Polygon Zoomed(double factor)
        {
            var zoomedpoints = new List<Point>();
            for (int i = 0; i < Points.Length; i++)
            {
                zoomedpoints.Add(new Point(Points[i].X*factor, Points[i].Y*factor));
            }
            return new Polygon(zoomedpoints.ToArray(),Color);
        }

        public Polygon Zoomed(Point point, double factor)
        {

            var zoomedPoints = new List<Point>();
            for (int i = 0; i < Points.Length; i++)
            {
                zoomedPoints.Add(new Point((Points[i].X - point.X) * factor + point.X, (Points[i].Y - point.Y) * factor + point.Y));
            }
            return new Polygon(zoomedPoints.ToArray(),Color);
        }

        public Polygon Rotate(double angle)
        {
            var rPoints = new List<Point>();
            foreach (Point point in Points)
            {
                var rX = Math.Round(point.X * Math.Cos(angle*Math.PI/180) + point.Y * Math.Sin(angle*Math.PI/180),3);            //x' = x·cosφ + y·sinφ
                var rY = Math.Round(point.X * (0 - Math.Sin(angle*Math.PI/180)) + point.Y * Math.Cos(angle*Math.PI/180),3);      //y' = x·(-sinφ) + y·cosφ
                rPoints.Add(new Point(rX,rY));
            }
            return new Polygon(rPoints.ToArray(),Color);
        }

        public Polygon Rotate(Point point, double angle)
        {
            var rotatedPoints = new List<Point>();
            for (int i = 0; i < Points.Length; i++)
            {
               rotatedPoints.Add(Points[i].Moved(-point.X, -point.Y));
            }
            var movedPolygon = new Polygon(rotatedPoints.ToArray(),Color).Rotate(angle);
            var rotatedPolygon = movedPolygon.Moved(point.X, point.Y);
            return rotatedPolygon;
        }

        public Point Middle()
        {
            return new Point((UpperRight().X - LowerLeft().X)/2 + LowerLeft().X, (UpperRight().Y - LowerLeft().Y)/2 + LowerLeft().X);
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