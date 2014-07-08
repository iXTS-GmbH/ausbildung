using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public double LowestValue(double a, double b, double c)
        {
            double lValue;

            if (a < c)
            {
                if (a < b)
                {
                    lValue = a;
                }
                else
                {
                    lValue = b;
                }
            }
            else
            {
                if (a > b)
                {
                    if (c > b)
                    {
                        lValue = b;
                    }
                    else
                    {
                        lValue = c;
                    }
                }
                else
                {
                    lValue = c;
                }
            }

            return lValue;
        }
    }
}
