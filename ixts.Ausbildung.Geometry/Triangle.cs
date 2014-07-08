using System;

namespace ixts.Ausbildung.Geometry
{
    public class Triangle
    {
        public Point A;
        public Point B;
        public Point C;

        public Triangle(Point a,Point b, Point c)
        {
            A = a;
            B = b;
            C = c;
        }

        public double Perimeter()
        {
            double sA = B.Distance(C);
            double sB = C.Distance(A);
            double sC = A.Distance(B);
            double perimeter = sA + sB + sC;
            return perimeter;
        }

        public double Area()
        {
            double sA = B.Distance(C);
            double sB = C.Distance(A);
            double sC = A.Distance(B);
            double s = (sA + sB + sC)/2; 
            double flaeche = Math.Sqrt(s*(s - sA)*(s - sB)*(s - sC)); 
            return flaeche;
        }

        public Point LowerLeft()
        {
            double lX = LowestValue(new []{A.X,B.X,C.X}); 
            double lY = LowestValue(new []{A.Y,B.Y,C.Y});

            var lowerLeft = new Point(lX,lY);
            return lowerLeft;
        }

        public double LowestValue(double[] values)
        {
            var lValue = values[0];
            for (var i = 0; i < values.Length; i++)
            {
                if (values[i] < lValue)
                {
                    lValue = values[i];
                }
            }
            return lValue;
        }

        public Point UpperRight()
        {
            var hX = HighestValue(new []{A.X, B.X, C.X});
            var hY = HighestValue(new []{A.Y, B.Y, C.Y});

            var upperRight = new Point(hX, hY);
            return upperRight;
        }

        public double HighestValue(double[] values)
        {
            var hValue = values[0];
            for (var i = 0; i < values.Length; i++)
            {
                if (values[i] > hValue)
                {
                    hValue = values[i];
                }
            }
            return hValue;
        }

        public Boolean IsSame(Triangle t, double within)
        {
            var tvalues = new[] { t.A.X, t.A.Y, t.B.X, t.B.Y, t.C.X, t.C.Y };
            var selfvalues = new[] { A.X, A.Y, B.X, B.Y, C.X, C.Y };
            var isSamecheck = selfvalues[0] + within >= tvalues[0] && selfvalues[0] - within <= tvalues[0];
            for (var i = 0; i < selfvalues.Length; i++)
            {
                if (isSamecheck)
                {
                    isSamecheck = selfvalues[i] + within >= tvalues[i] && selfvalues[i] - within <= tvalues[i];
                }
            }
            return isSamecheck;
        }


        public Triangle Moved(double dx, double dy)
        {
            var mA = new Point(A.X + dx, A.Y + dy);
            var mB = new Point(B.X + dx, B.Y + dy);
            var mC = new Point(C.X + dx, C.Y + dy);
            var mTriangle = new Triangle(mA, mB, mC);
            return mTriangle;
        }

        public Triangle Zoomed(double f)
        {
            var zA = new Point(A.X*f, A.Y*f);
            var zB = new Point(B.X*f, B.Y*f);
            var zC = new Point(C.X*f, C.Y*f);
            var zTriangle = new Triangle(zA, zB, zC);
            return zTriangle;
        }

        public Triangle Zoomed(Point p, double f)
        {

            var zA = new Point((A.X - p.X)*f + p.X, (A.Y - p.Y)*f + p.Y);
            var zB = new Point((B.X - p.X)*f + p.X, (B.Y - p.Y)*f + p.Y);
            var zC = new Point((C.X - p.X)*f + p.X, (C.Y - p.Y)*f + p.Y);
            var zTriangle = new Triangle(zA, zB, zC);
            return zTriangle;
        }
    }
}
