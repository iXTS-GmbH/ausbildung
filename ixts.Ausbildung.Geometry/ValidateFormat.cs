using System;
using System.Linq;

namespace ixts.Ausbildung.Geometry
{
    public class ValidateFormat
    {
        private const string TRIANGLE = "Triangle";
        private const string QUADLITERAL = "Quadliteral";
        private const int TRIANGLEPOINTCOUNT = 3;
        private const int QUADLITERALPOINTCOUNT = 4;

        public static void CheckPointStringFormat(string pointstring)//gewolltes Format 00#/00#;00#/00#;00#/00#;
        {
            //Hier muss ich noch auf Buchstaben prüfen
            if (!pointstring.Contains('/'))
            {
                throw new FalseArgumentExeption(string.Format("Kein güliges Koordinatentrennzeichen enthalten (Gültiges Trennzeichen: '/')"));
            }
            LetterCheck(pointstring);
        }

        public static void CheckPointStringFormat(string[] pointstrings)
        {
            foreach (var pointstring in pointstrings)
            {
                CheckPointStringFormat(pointstring);
            }
        }

        public static Boolean LetterCheck(string teststring)
        {
            var letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            foreach (var letter in letters)
            {
                if (teststring.Contains(letter))
                {
                    return false;
                }
            }
            return true;
        }

        public static void CheckPointCount(Point[] points, string type)
        {

            if ((type == TRIANGLE && points.Length == TRIANGLEPOINTCOUNT) || (type == QUADLITERAL && points.Length == QUADLITERALPOINTCOUNT))
            {

                throw new NoValidPointCountExeption(string.Format("{0} ist keine gültige anzahl an Punkten für {1}",points.Length,type));
            }
        }

    }
}
