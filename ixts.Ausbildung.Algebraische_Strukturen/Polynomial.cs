using System;

namespace ixts.Ausbildung.Algebraische_Strukturen
{
    public class Polynomial<F>:IRing<Polynomial<F>> where F:IField<F>
    {
        private readonly F[] a;

        public Polynomial(params F[] c)
        {
            a = new F[c.Length];
            Array.Copy(c,a,Length(c));
        }

        private static int Length(F[] x)
        {
            var d = x.Length - 1;

            while (d >= 0 && x[d].IsZero())
            {
                d--;
            }
            return d + 1;
        }

        public Polynomial<F> Div(Polynomial<F> x)
        {
            return Mult(x);
        }

        public Polynomial<F> Mult(Polynomial<F> x)
        {
            if (IsZero() || x.IsZero())
            {
                return new Polynomial<F>();
            }
            if (IsOne())
            {
                return x;
            }
            if (x.IsOne())
            {
                return this;
            }

            var d = Degree() + x.Degree();

            var b = new F[d+1];

            for (var i = 0; i <= Degree(); i++)
            {
                for (var j = 0; j <= x.Degree(); j++)
                {
                    if (b[i + j] == null)
                    {
                        b[i + j] = a[i].Mult(x.a[j]);

                    }
                    else
                    {
                        b[i + j] = b[i + j].Add(a[i].Mult(x.a[j]));
                    }
                }
            }
            return new Polynomial<F>(b);
        }

        public bool IsOne()
        {
            return a.Length == 1 && a[0].IsOne();
        }

        public Polynomial<F> Add(Polynomial<F> x)
        {
            if (IsZero())
            {
                return x;
            }
            if (x.IsZero())
            {
                return this;
            }

            var degree = Math.Max(Degree(), x.Degree());
            var b = new F[degree + 1];
            for (var i = 0; i <= degree; i++)
            {
                if (i > Degree())
                {
                    b[i] = x.a[i];
                }else if (i > x.Degree())
                {
                    b[i] = a[i];
                }
                else
                {
                    b[i] = a[i].Add(x.a[i]);
                }
            }
            return new Polynomial<F>(b);
        }

        public Polynomial<F> Sub(Polynomial<F> x)
        {
            return Add(x);
        }

        public bool IsZero()
        {
            return a.Length == 0;
        }

        public int Degree()
        {
            return Math.Max(0, a.Length - 1);
        }
    }
}
