using System;

namespace ixts.Ausbildung.Reihen
{
    public class Series
    {
        private const double EPSILON = 1E-13;

        public static double Exp(double number)
        {
            var n = 0;
            var an = 1.0;
            var sn = 1.0;

            while (Math.Abs(an/sn) > EPSILON)
            {
                an *= number/(n + 1);
                sn += an;
                n++;
            }

            return sn;
        }

        public static double Sinh(double number)
        {
            var n = 1;
            var an = number;
            var sn = number;

            while (Math.Abs(an) > Math.Abs(sn)*EPSILON)
            {
                an *= number/(n*2)*number/(n*2 + 1);
                sn += an;
                n++;
            }
            return sn;
        }

        public static double Arsinh(double number)
        {
            if (number >= 1 || number <= -1)
            {
                throw new Exception(string.Format("arsinh undefinded for {0}",number));
            }

            var n = 1;
            var an = number;
            var sn = number;

            while (Math.Abs(an) > Math.Abs(sn)*EPSILON)
            {
                an *= -number*number*(n*2 - 1)*(n*2 - 1)/(n*2)/(n*2 + 1);
                sn += an;
                n++;
            }

            return sn;
        }
    }
}
