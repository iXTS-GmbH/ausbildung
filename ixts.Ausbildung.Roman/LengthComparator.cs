using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ixts.Ausbildung.Roman
{
    class LengthComparator:IComparer<Roman>
    {


        public int Compare(Roman roman, Roman toCompareRoman)//TODO überarbeiten
        {
            if (roman.ToString().Length.CompareTo(toCompareRoman.ToString().Length) != 0)
            {
                return roman.ToString().Length.CompareTo(toCompareRoman.ToString().Length);
            }
            return 0;
        }
    }
}
