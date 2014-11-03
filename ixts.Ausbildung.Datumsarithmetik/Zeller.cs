using System;

namespace ixts.Ausbildung.Datumsarithmetik
{
    public class Zeller
    {
        public static String Wochentag(int day, int month, int year,int century)
        {
            return Weekday.KeyValue[(day + (26*(month+1))/10 + (5*year)/4 + (century)/4 + 5*(century) - 1)%7];
        }

    }
}
