using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.Buchstabensammlung
{
    public class LetterColl
    {
        protected char[] Letters;

        public LetterColl(params char[] letters)
        {
            Letters = letters;
        }

        public LetterColl(String s)
        {
            Letters = s.ToCharArray();
        }

        public int Size()
        {
            return Letters.Length;
        }

        public int Count(char c)
        {
            var count = 0;

            foreach (var letter in Letters)
            {
                if (letter == c)
                {
                    count++;
                }
            }

            return count;
        }

        public int Different()
        {
            var newLetters = new List<Char>();

            foreach (var letter in Letters)
            {
                if (!newLetters.Contains(letter))
                {
                    newLetters.Add(letter);
                }
            }
            return newLetters.Count;
        }

        public char Top()
        {
            var maxcount = 0;
            var maxchar = ' ';

            for (var i = 0; i < Letters.Length; i++)
            {
                var count = 0;
                foreach (var letter in Letters)
                {
                    if (letter == Letters[i])
                    {
                        count++;
                    }
                }

                if (count > maxcount)
                {
                    maxcount = count;
                    maxchar = Letters[i];
                }
            }
            return maxchar;
        }

        public override String ToString()
        {
            var result = "(";

            for (int i = 0; i < Letters.Length; i++)
            {
                if (i == Letters.Length - 1)
                {
                    result = string.Format("{0}{1}, ",result,Letters[i]);
                }
                else
                {
                    result = string.Format("{0}{1})",result,Letters[i]);
                }   
            }
            return result;
        }

        public LetterColl MoreThan(int m)
        {
            var newList = new List<Char>();

            for (var i = 0; i < Letters.Length; i++)
            {
                var count = 0;
                foreach (var letter in Letters)
                {
                    if (letter == Letters[i])
                    {
                        count++;
                    }
                }

                if (count > m)
                {
                    newList.Add(Letters[i]);
                }
            }
            return new LetterColl(newList.ToArray());
        }

        public Boolean Equals(LetterColl lc)
        {
            return Letters == lc.Letters;
        }

        public override int GetHashCode()
        {
            var hashstring = "";

            foreach (var letter in Letters)
            {
                hashstring = string.Format("{0}{1}",hashstring, letter.GetHashCode());
            }

            return int.Parse(hashstring);
        }

        public LetterColl Except(LetterColl lc)
        {
            var newList = new List<Char>(Letters);

            foreach (var letter in lc.Letters)
            {
                for (var i = newList.Count; i >= 0; i--)
                {
                    if (newList[i] == letter)
                    {
                        newList.RemoveAt(i);
                    }
                }
            }
            return new LetterColl(newList.ToArray());
        }
    }
}
