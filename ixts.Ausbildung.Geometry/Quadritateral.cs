using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ixts.Ausbildung.Geometry
{
    public class Quadritateral
    {
        protected Point a;
        protected Point b;
        protected Point c;
        protected Point d;

        public Quadritateral(Point a, Point b, Point c, Point d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
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

        public Point D
        {
            get { return d; }
            set { d = value; }
        }

        public double Perimeter()
        {
            var disA = a.Distance(b);
            var disB = b.Distance(c);
            var disC = c.Distance(d);
            var disD = d.Distance(a);
            var perimeter = disA + disB + disC + disD;
            return perimeter;
        }

        public double Area()
        {
            
            var d1 = new Triangle(a, b, c);//Dreieck 1 (A,B,C)
            var d2 = new Triangle(c, d, a);//Dreieck 2 (C,D,A)
            var dArea1 = d1.Area();//Fläche Dreieck 1
            var dArea2 = d2.Area();//Fläche Dreieck 2
            var area = dArea1 + dArea2;
            return area;
        }

        public Point LowerLeft()
        {
            var lX = LowestValue(new[] { a.Y, b.Y, c.Y, d.X });
            var lY = LowestValue(new[] { a.Y, b.Y, c.Y, d.Y });
            var lowerLeft = new Point(lX, lY);
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
    }
}
