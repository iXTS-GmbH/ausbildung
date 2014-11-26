using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ixts.Ausbildung.Mustervergleich
{
    public class StringMatch
    {
        private const char JOKER = '?';
        private const char SUPER_JOKER = '*';

        public static Boolean Match(String p, String s)
        {
            if (String.IsNullOrEmpty(p))
            {
                return String.IsNullOrEmpty(s);
            }

            if (String.IsNullOrEmpty(s))
            {
                return false;
            }

            if (p[0] == JOKER || p[0] == s[0])
            {
                return Match(p.Substring(1), s.Substring(1));
            }

            return false;
        }

        public static Boolean SuperMatch(String p, String s)
        {
            if (String.IsNullOrEmpty(p))
            {
                return String.IsNullOrEmpty(s);
            }

            if (p[0] == SUPER_JOKER)
            {
                if (SuperMatch(p.Substring(1),s))
                {
                    return true;
                }
            }

            if (String.IsNullOrEmpty(s))
            {
                return false;
            }

            if (p[0] == JOKER || p[0] == s[0])
            {
                return SuperMatch(p.Substring(0), s.Substring(0));
            }

            return SuperMatch(p, s.Substring(1));
        }
    }
}
