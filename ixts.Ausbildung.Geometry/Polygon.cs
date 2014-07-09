
using System;

namespace ixts.Ausbildung.Geometry
{
    public class Polygon
    {
        public Point[] Points;

        //public Polygon()
        //{

        //}

        public double Perimeter() //Eventuell muss ich das Array als Parameter einspeisen
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

        //public double Area() //wie muss ich Patrick fragen
        //{
        //double sA = B.Distance(C);
        //double sB = C.Distance(A);
        //double sC = A.Distance(B);
        //double s = (sA + sB + sC) / 2;
        //double flaeche = Math.Sqrt(s * (s - sA) * (s - sB) * (s - sC)); //Fläche Dreieck
        //    return 0;
        //}

        public Point LowerLeft() //Erst Lists mit x und y werten füllen dann [].Min und einen Point mit den ergebnissen als Parameter zurückgeben
        {
            return null;
        }

        public Point UpperRight() //Erst Lists mit x und y werten füllen dann [].Max und einen Point mit den ergebnissen als Parameter zurückgeben
        {
            return null;
        }

        public Boolean IsSame(Polygon p, double within) //
        {

            var isSamecheck = Points[0].X + within >= p.Points[0].X && Points[0].X - within <= p.Points[0].X;
            isSamecheck = Points[0].Y + within >= p.Points[0].Y && Points[0].Y - within <= p.Points[0].Y;
            for (var i = 0; i < Points.Length; i++)
            {
                if (isSamecheck)
                {
                    isSamecheck = Points[i].X + within >= p.Points[i].X && Points[i].X - within <= p.Points[i].X;
                }
                if (isSamecheck)
                {
                    isSamecheck = Points[i].Y + within >= p.Points[i].Y && Points[i].Y - within <= p.Points[i].Y;
                }

            }
            return isSamecheck;
        }

        public Polygon Moved(double dx, double dy) //Muss ich Patrick fragen bezüglich des erstellens des neuen objekts
        {
            return null;
        }

        public Polygon Zoomed(double f)//siehe Moved
        {
            return null;
        }

        public Polygon Zoomed(Point p, double f)//siehe Moved
        {
            return null;
        }

        public Polygon Rotate(double w)//siehe Moved
        {
            return null;
        }

        public Polygon Rotate(Point p, double w)//siehe Moved
        {
            return null;
        }

        public Point Middle()//Koordinaten von UpperRight mit LowerLeft subtrahieren und durch 2 teilen = Mittelpunktkoordinaten
        {
            return null;
        }

    }
}
