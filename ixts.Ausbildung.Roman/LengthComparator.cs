using System.Collections.Generic;

namespace ixts.Ausbildung.Roman
{
    class LengthComparator:IComparer<Roman>
    {


        public int Compare(Roman roman, Roman toCompareRoman)
        {
            return roman.ToString().Length.CompareTo(toCompareRoman.ToString().Length);
        }
    }
}
