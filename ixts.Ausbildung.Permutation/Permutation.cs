using System;

namespace ixts.Ausbildung.Permutation
{
    public class Permutation
    {
        public static readonly int Joker = 0; 

        public static Boolean IsPermutation(int[] a)
        {
            var n = a.Length;
            var found = new Boolean[n + 1];

            for (var i = 0; i < n; i++)
            {
                var element = a[i];
                if (element == Joker)
                continue;
                if (element < 1 || element > n)
                {
                    return false;
                }
                if (found[element])
                {
                    return false;
                }
                found[element] = true;
            }
            return true;
        }

        private static Boolean IsPermutationRow(int[][] a,int row)
        {
            return IsPermutation(a[row]);
        }

        private static Boolean IsPermutationCol(int[][] a, int col)
        {
            var n = a.Length;
            var temp = new int[n];
            for (var i = 0; i < n; i++)
            {
                temp[i] = a[i][col];
            }
            return IsPermutation(temp);
        }

        public static Boolean IsPermutationBlock(int[][] a, int bottom, int top, int left, int right)
        {
            var n = (top - bottom)*(right - left);
            var i = 0;
            var temp = new int[n];
            for (var r = bottom; r < top; r++)
            {
                for (var c = left; c < right; c++)
                {
                    temp[i++] = a[r][c];
                }
            }
            return IsPermutation(temp);
        }

        public static Boolean IsPermutation(int[][] a)
        {
            var n = a.Length;
            for (var i = 0; i < n; i++)
            {
                if (!IsPermutationRow(a,i) || !IsPermutationCol(a,i))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
