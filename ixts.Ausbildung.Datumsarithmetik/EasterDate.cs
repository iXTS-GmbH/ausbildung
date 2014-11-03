using System;

namespace ixts.Ausbildung.Datumsarithmetik
{
    public class EasterDate
    {

        public static String GetEasterDate(int year)
        {
            var g = year%19;
            var c = year/100;
            var h = (c - c/4 - (8*c + 13)/25 + 19*g + 15)%30;
            var i = h - h/28*(1 - 29/(h + 1)*(21 - g)/11);
            var j = (year + year/4 + i + 2 - c + c/4)%7;
            var l = i - j;
            var m = 3 + (l + 40)/44;
            var d = l + 28 - 31*(m/4);

            return string.Format("{0} {1}",d,m);
        }

    }
}
