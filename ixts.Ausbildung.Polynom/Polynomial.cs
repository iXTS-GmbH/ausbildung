using System;

namespace ixts.Ausbildung.Polynom
{
    public class Polynomial
    {
        public readonly double[] A;
        private const double EPSILON = 1E-12;
        public readonly Polynomial Zero = new Polynomial();
        public readonly Polynomial One = new Polynomial(1);

        public Polynomial()
        {
            A = new double[0];
        }

        public Polynomial(int degree)
        {
            A = new double[degree];
        }

        public Polynomial(double[] c)
        {
            Array.Copy(c,A,Length(c));
        }

        private static int Length(double[] c)
        {
            var d = c.Length - 1;
            while (d >= 0 && Math.Abs(c[d]) < EPSILON)
            {
                d--;
            }
            return d + 1;
        }

        public int Degree()
        {
            return Math.Max(0, A.Length - 1);
        }

        public Boolean Equals(Polynomial p)
        {
            if (p == null)
            {
                return false;
            }

            return A.Equals(p.A);
        }

        public Boolean IsZero()
        {
            return Equals(Zero);
        }

        public Boolean IsOne()
        {
            return Equals(One);
        }

        public override int GetHashCode()
        {
            return A.GetHashCode();
        }

        public Polynomial Add(Polynomial p)
        {
            if (IsZero())
            {
                return p;
            }
            if (p.IsZero())
            {
                return this;
            }
            var c = new double[Math.Max(Degree(),p.Degree()) + 1];
            for (var i = 0; i < c.Length; i++)
            {
                c[i] = Get(i) + p.Get(i);
            }
            return new Polynomial(c);
        }

        public double Get(int i)
        {
            if (i < 0)
            {
                throw new Exception();
            }
            return IsZero() || i > Degree() ? 0 : A[i];
        }

        public Polynomial Sub(Polynomial p)
        {
            return Add(p.Mult(-1));
        }

        public Polynomial Mult(Polynomial p)
        {
            if (IsZero() || p.IsZero())
            {
                return Zero;
            }
            if (IsOne())
            {
                return p;
            }
            if (p.IsOne())
            {
                return this;
            }
            var c = new double[Degree() + p.Degree() + 1];
            for (var i = 0; i <= Degree(); i++)
            {
                for (var j = 0; j <= p.Degree(); j++)
                {
                    c[i + j] += A[i]*p.A[j];
                }
            }
            return new Polynomial(c);
        }

        public Polynomial Mult(double r)
        {
            if (IsZero() || r < EPSILON)
            {
                return Zero;
            }
            var b = new double[Degree() + 1];
            for (var i = 0; i <= Degree(); i++)
            {
                b[i] = A[i]*r;
            }
            return new Polynomial(b);
        }

        public Polynomial[] Div(Polynomial p)
        {
            if (p.IsZero())
            {
                throw new Exception("Division durch 0");
            }
            var dq = Degree() - p.Degree() + 1;
            if (dq <= 0)
            {
                return new []{Zero, this};
            }
            var rest = new double[0];
            Array.Copy(A, rest, Length(A));
            var quotient = new double[dq];

            var dr = p.Degree();
            var c = p.A[dr];
            for (var i = dq - 1; i >= 0; i--)
            {
                var q = rest[dr + i]/c;
                quotient[i] = q;
                for (var j = 0; j <= dr; j++)
                {
                    rest[i + j] -= q*p.A[j];
                }
            }
            return new []{new Polynomial(quotient),new Polynomial(rest)};
        }

        public static Polynomial Gcd(Polynomial g, Polynomial q)
        {
            var r = new Polynomial();
            while (!q.IsZero())
            {
                r = g.Div(q)[1];
                g = q;
                q = r;  
            }
            return g;
        }
        

        public override String ToString()
        {
            if (IsZero())
            {
                return "0";
            }
            var s = String.Format("{0}", A[0]);
            for (var i = 1; i < A.Length; i++)
            {
                s = String.Format("{0}^{1} {2}", A[i], i, s);
            }
            return s;
        }

        public double Value(double x)
        {
            var y = 0.0;
            for (var i = Degree(); i >= 0; i--)
            {
                y = A[i] + x*y;
            }
            return y;
        }
    }
}
