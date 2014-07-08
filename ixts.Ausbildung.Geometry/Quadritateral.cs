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
            var lX = LowestValue(new[] { a.X, b.X, c.X, d.X });
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

        public Point UpperRight()
        {
            var hX = HighestValue(new[] {a.X, b.X, c.X, d.X});
            var hY = HighestValue(new[] {a.Y, b.Y, c.Y, d.Y});
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

        public Boolean IsSame(Quadritateral quad, double within)
        {
            Boolean isSamecheck = a.X + within >= quad.A.X && a.X - within <= quad.A.X;//quad.A.X liegt im rahmen

            if (isSamecheck){
                isSamecheck = a.Y + within >= quad.A.Y && a.Y - within <= quad.A.Y;//quad.A.Y liegt im rahmen
            }

            if (isSamecheck){
                isSamecheck = b.X + within >= quad.B.X && b.X - within <= quad.B.X;//quad.B.X liegt im rahmen
            }
            if (isSamecheck)
            {
                isSamecheck = b.Y + within >= quad.B.Y && b.Y - within <= quad.B.Y;//quad.B.Y liegt im rahmen
            }

            if (isSamecheck)
            {
                isSamecheck = c.X + within >= quad.C.X && c.X - within <= quad.C.X;//quad.C.X liegt im rahmen
            }
            if (isSamecheck)
            {
                isSamecheck = c.Y + within >= quad.C.Y && c.Y - within <= quad.C.Y;//quad.C.Y liegt im rahmen
            }
            if (isSamecheck)
            {
                isSamecheck = d.X + within >= quad.D.X && d.X - within <= quad.D.X;//quad.D.X liegt im rahmen
            }
            if (isSamecheck)
            {
                isSamecheck = d.Y + within >= quad.D.Y && d.Y - within <= quad.D.Y;//quad.D.Y liegt im rahmen
            }
            return isSamecheck;
        }

        public Quadritateral Moved(double dx, double dy)
        {
            var mA = new Point(a.X + dx,a.Y + dy);
            var mB = new Point(b.X + dx,b.Y + dy);
            var mC = new Point(c.X + dx,c.Y + dy);
            var mD = new Point(d.X + dx,d.Y + dy);
            var mQuad = new Quadritateral(mA, mB, mC, mD);
            return mQuad;
        }
    }
}
