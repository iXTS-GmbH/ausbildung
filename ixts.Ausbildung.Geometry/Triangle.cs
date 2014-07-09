using System;
using System.Linq;

namespace ixts.Ausbildung.Geometry
{
    public class Triangle:Polygon
    {
        private Point A;
        private Point B;
        private Point C;
        public new Point[] Points;

    public Triangle(Point a, Point b, Point c)
        {
            A = a;
            B = b;
            C = c;
            Points = new []{a,b,c};
        }

        //public Point LowerLeft()
        //{
        //    var lX = new [] {A.X, B.X, C.X}.Min();
        //    var lY = new [] {A.Y, B.Y, C.Y}.Min();
        //    var lowerLeft = new Point(lX,lY);
        //    return lowerLeft;
        //}

        //public Point UpperRight()
        //{
        //    double hX = new [] { A.X, B.X, C.X }.Max();
        //    double hY = new [] { A.Y, B.Y, C.Y }.Max();

        //    var upperRight = new Point(hX, hY);
        //    return upperRight;
        //}

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
