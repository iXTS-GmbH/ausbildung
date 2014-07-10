
using System;

namespace ixts.Ausbildung.Geometry
{
    public class Polygon
    {
        protected Point[] Points;

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

        public Point LowerLeft() //Erst Lists mit x und y werten füllen dann [].Min und einen Point mit den ergebnissen als Parameter zurückgeben
        {
            


            return null;
        }

        public Point UpperRight() //Erst Lists mit x und y werten füllen dann [].Max und einen Point mit den ergebnissen als Parameter zurückgeben
        {
            return null;
        }

        public Boolean IsSame(Polygon polygon, double within) //
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
            return null;
        }

        public Polygon Zoomed(double factor)
        {
            //
            return null;
        }

        public Polygon Zoomed(Point point, double factor)
        {
            //
            return null;
        }

        public Polygon Rotate(double angle)
        {
            //
            return null;
        }

        public Polygon Rotate(Point point, double angle)
        {
            //
            return null;
        }

        public Point Middle()
        {
            return new Point((UpperRight().X - LowerLeft().X)/2, (UpperRight().Y - LowerLeft().Y)/2 );
        }

    }
}

        //public Triangle Moved(double dx, double dy)
        //{
        //    var mA = new Point(A.X + dx, A.Y + dy);
        //    var mB = new Point(B.X + dx, B.Y + dy);
        //    var mC = new Point(C.X + dx, C.Y + dy);
        //    var mTriangle = new Triangle(mA, mB, mC);
        //    return mTriangle;
        //}

        //public Triangle Zoomed(double f)
        //{
        //    var zA = new Point(A.X*f, A.Y*f);
        //    var zB = new Point(B.X*f, B.Y*f);
        //    var zC = new Point(C.X*f, C.Y*f);
        //    var zTriangle = new Triangle(zA, zB, zC);
        //    return zTriangle;
        //}

        //public Triangle Zoomed(Point p, double f)
        //{

        //    var zA = new Point((A.X - p.X)*f + p.X, (A.Y - p.Y)*f + p.Y);
        //    var zB = new Point((B.X - p.X)*f + p.X, (B.Y - p.Y)*f + p.Y);
        //    var zC = new Point((C.X - p.X)*f + p.X, (C.Y - p.Y)*f + p.Y);
        //    var zTriangle = new Triangle(zA, zB, zC);
        //    return zTriangle;
        //}