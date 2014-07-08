using System;

namespace ixts.Ausbildung.Geometry
{
    public class Triangle
    {
        protected Point a;
        protected Point b;
        protected Point c;

        public Triangle(Point a,Point b, Point c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public Point A
        {
            get { return a; }
            set { a = value; }
        }

        public Point B
        {
            get { return b; }
            set { b = value; }
        }

        public Point C
        {
            get { return c; }
            set { c = value; }
        }

        public double Perimeter()
        {
            double sA = b.Distance(c);
            double sB = c.Distance(a);
            double sC = a.Distance(b);
            double perimeter = sA + sB + sC;
            return perimeter;
        }

        public double Area()
        {
            double sA = b.Distance(c);
            double sB = c.Distance(a);
            double sC = a.Distance(b);
            double s = (sA + sB + sC)/2; 
            double flaeche = Math.Sqrt(s*(s - sA)*(s - sB)*(s - sC)); 
            return flaeche;
        }

        public Point LowerLeft()
        {
            double lX = LowestValue(a.X,b.X,c.X); 
            double lY = LowestValue(a.Y,b.Y,c.Y);

            var lowerLeft = new Point(lX,lY);
            return lowerLeft;
        }

        public double LowestValue(double lA, double lB, double lC)
        {
            double lValue;

            if (lA < lC)
            {
                if (lA < lB)
                {
                    lValue = lA;
                }
                else
                {
                    lValue = lB;
                }
            }
            else
            {
                if (lA > lB)
                {
                    if (lC > lB)
                    {
                        lValue = lB;
                    }
                    else
                    {
                        lValue = lC;
                    }
                }
                else
                {
                    lValue = lC;
                }
            }

            return lValue;
        }

        public Point UpperRight()
        {
            var hX = HighestValue(a.X, b.X, c.X);
            var hY = HighestValue(a.Y, b.Y, c.Y);

            var upperRight = new Point(hX, hY);
            return upperRight;
        }

        public double HighestValue(double hA, double hB, double hC)
        {
            double hValue;

            if (hA > hC)
            {
                if (hA > hB)
                {
                    hValue = hA;
                }
                else
                {
                    hValue = hB;
                }
            }
            else
            {
                if (hB < hC)
                {
                    hValue = hC;
                }
                else
                {
                    hValue = hB;
                }
            }
            return hValue;
        }

        public Boolean IsSame(Triangle t, double within)
        {
            Boolean isSamecheck= a.X + within >= t.A.X && a.X - within <= t.A.X;//t.A.X liegt im rahmen

            if (isSamecheck){
                isSamecheck = a.Y + within >= t.A.Y && a.Y - within <= t.A.Y;//t.A.Y liegt im rahmen
            }

            if (isSamecheck){
                isSamecheck = b.X + within >= t.B.X && b.X - within <= t.B.X;//t.B.X liegt im rahmen
            }
            if (isSamecheck)
            {
                isSamecheck = b.Y + within >= t.B.Y && b.Y - within <= t.B.Y;//t.B.Y liegt im rahmen
            }

            if (isSamecheck)
            {
                isSamecheck = c.X + within >= t.C.X && c.X - within <= t.C.X;//t.C.X liegt im rahmen
            }
            if (isSamecheck)
            {
                isSamecheck = c.Y + within >= t.C.Y && c.Y - within <= t.C.Y;//t.C.X liegt im rahmen
            }
            return isSamecheck;
        }

        public Triangle Moved(double dx, double dy)
        {
            var mA = new Point(a.X + dx, a.Y + dy);
            var mB = new Point(b.X + dx, b.Y + dy);
            var mC = new Point(c.X + dx, c.Y + dy);
            var mTriangle = new Triangle(mA, mB, mC);
            return mTriangle;
        }

        public Triangle Zoomed(double f)
        {
            var zA = new Point(a.X*f, a.Y*f);
            var zB = new Point(b.X*f, b.Y*f);
            var zC = new Point(c.X*f, c.Y*f);
            var zTriangle = new Triangle(zA, zB, zC);
            return zTriangle;
        }

        public Triangle Zoomed(Point p, double f)
        {

            var zA = new Point((a.X - p.X)*f + p.X, (a.Y - p.Y)*f + p.Y);
            var zB = new Point((b.X - p.X)*f + p.X, (b.Y - p.Y)*f + p.Y);
            var zC = new Point((c.X - p.X)*f + p.X, (c.Y - p.Y)*f + p.Y);
            var zTriangle = new Triangle(zA, zB, zC);
            return zTriangle;
        }
    }
}
