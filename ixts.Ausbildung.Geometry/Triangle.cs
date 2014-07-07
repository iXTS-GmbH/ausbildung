using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ixts.Ausbildung.Geometry
{
    public class Triangle
    {
        protected double a;
        protected double b;
        protected double c;

        public Triangle(double a,double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public double A
        {
            get { return a; }
            set { a = value; }
        }

        public double B
        {
            get { return b; }
            set { b = value; }
        }

        public double C
        {
            get { return c; }
            set { c = value; }
        }
    }
}
