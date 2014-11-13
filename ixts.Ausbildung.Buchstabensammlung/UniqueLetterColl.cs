using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.Buchstabensammlung
{
    public class UniqueLetterColl:LetterColl
    {

        public UniqueLetterColl(params char[] letters)
        {
            ConstruktHelper(letters);
        }

        public UniqueLetterColl(String s)
        {
            var letters = s.ToCharArray();
            ConstruktHelper(letters);

        }

        private void ConstruktHelper(IEnumerable<char> letters)
        {
            var newList = new List<Char>();

            foreach (var letter in letters)
            {
                if (!newList.Contains(letter))
                {
                    newList.Add(letter);
                }
            }

            Letters = newList.ToArray();
        }
    }
}
