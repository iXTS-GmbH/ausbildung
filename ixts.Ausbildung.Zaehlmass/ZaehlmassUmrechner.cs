using System;

namespace ixts.Ausbildung.Zaehlmass
{
    public class ZaehlmassUmrechner
    {
        private const int GROS = 144;
        private const int SCHOCK = 60;
        private const int DUTZEND = 12;

        public static String GetOldZaehlmass(int number)
        {
            var grosZaehler = 0;
            var schokZaehler = 0;
            var dutzendZaehler = 0;
            var einzelZaehler = 0;

            while (number > 0)
            {
                if (number/GROS >= 1)
                {
                    grosZaehler += number/GROS;
                    number -= number/GROS*GROS;
                }else if(number/SCHOCK >= 1)
                {
                    schokZaehler += number/SCHOCK;
                    number -= number/SCHOCK*SCHOCK;
                }else if (number/DUTZEND >= 1)
                {
                    dutzendZaehler += number/DUTZEND;
                    number -= number/DUTZEND*DUTZEND;
                }else if (number < DUTZEND)
                {
                    einzelZaehler += number;
                    number = 0;
                }
            }

            return string.Format("{0}:Gros {1}:Schok {2}:Dutzend {3}:Stueck",grosZaehler,schokZaehler,dutzendZaehler,einzelZaehler);
        }
    }
}
