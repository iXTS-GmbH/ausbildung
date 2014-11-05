
namespace ixts.Ausbildung.Potenzieren
{
    public class Potenz
    {
        public static int Pow(int powBase, int powExponent, int moduloValue)
        {
            long bigPowBase = powBase;
            long z = 1;

            while (powExponent > 0)
            {
                if (powExponent % 2 == 0)
                {
                    powExponent /= 2;
                    bigPowBase = bigPowBase * bigPowBase % moduloValue;
                }
                else
                {
                    powExponent--;
                    z = z * bigPowBase % moduloValue;
                }
            }
            return (int)z;
        }
    }
}
