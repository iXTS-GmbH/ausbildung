using System.Collections.Generic;

namespace ixts.Ausbildung.Roman
{
    class LexicalComparator:IComparer<Roman>
    {


        public int Compare(Roman roman, Roman toCompareRoman)//Problem
        {
            return System.String.Compare(roman.ToString(), toCompareRoman.ToString(), System.StringComparison.Ordinal);
        }
    }
}
