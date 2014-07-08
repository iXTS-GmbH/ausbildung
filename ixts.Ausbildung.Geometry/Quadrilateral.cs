using System;

namespace ixts.Ausbildung.Geometry
{
    public class Quadrilateral
    {
        public Point A;
        public Point B;
        public Point C;
        public Point D;

        public Quadrilateral(Point a, Point b, Point c, Point d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }



        public double Perimeter()
        {
            var disA = A.Distance(B);
            var disB = B.Distance(C);
            var disC = C.Distance(D);
            var disD = D.Distance(A);
            var perimeter = disA + disB + disC + disD;
            return perimeter;
        }

        public double Area()
        {
            
            var d1 = new Triangle(A, B, C);//Dreieck 1 (A,B,C)
            var d2 = new Triangle(C, D, A);//Dreieck 2 (C,D,A)
            var dArea1 = d1.Area();//Fläche Dreieck 1
            var dArea2 = d2.Area();//Fläche Dreieck 2
            var area = dArea1 + dArea2;
            return area;
        }

        public Point LowerLeft()
        {
            var lX = LowestValue(new[] { A.X, B.X, C.X, D.X });
            var lY = LowestValue(new[] { A.Y, B.Y, C.Y, D.Y });
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
            var hX = HighestValue(new[] {A.X, B.X, C.X, D.X});
            var hY = HighestValue(new[] {A.Y, B.Y, C.Y, D.Y});
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

        public Boolean IsSame(Quadrilateral quad, double within)
        {
            var quadvalues = new[] { quad.A.X, quad.A.Y, quad.B.X, quad.B.Y, quad.C.X, quad.C.Y, quad.D.X, quad.D.Y };
            var selfvalues = new[] {A.X, A.Y, B.X, B.Y, C.X, C.Y, D.X, D.Y};
            var isSamecheck = selfvalues[0] + within >= quadvalues[0] && selfvalues[0] - within <= quadvalues[0];
            for (var i = 0; i < selfvalues.Length;i++)
            {
                if (isSamecheck)
                {
                    isSamecheck = selfvalues[i] + within >= quadvalues[i] && selfvalues[i] - within <= quadvalues[i];
                }
            }
            return isSamecheck;
        }
        public Quadrilateral Moved(double dx, double dy)
        {
            var mA = new Point(A.X + dx,A.Y + dy);
            var mB = new Point(B.X + dx,B.Y + dy);
            var mC = new Point(C.X + dx,C.Y + dy);
            var mD = new Point(D.X + dx,D.Y + dy);
            var mQuad = new Quadrilateral(mA, mB, mC, mD);
            return mQuad;
        }

        public Quadrilateral Zoomed(double f)
        {
            var zA = new Point(A.X*f,A.Y*f);
            var zB = new Point(B.X*f,B.Y*f);
            var zC = new Point(C.X*f,C.Y*f);
            var zD = new Point(D.X*f,D.Y*f);
            var zQuad = new Quadrilateral(zA, zB, zC, zD);
            return zQuad;
        }
    }
}
