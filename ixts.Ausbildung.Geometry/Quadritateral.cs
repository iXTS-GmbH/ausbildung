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
    }
}
