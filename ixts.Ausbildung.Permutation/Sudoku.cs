using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ixts.Ausbildung.Permutation
{
    public class Sudoku
    {
        private const int JOKER = 0;
        private const int CELL = 3;
        public const int SIZE = CELL*CELL;

        public static int[][] Matrix;

        public Boolean Solve()
        {
            for (var r = 0; r < SIZE; r++)
            {
                for (var c = 0; c < SIZE; c++)
                {
                    if (Matrix[r][c] == JOKER)
                    {
                        for (var num = 0; num <= SIZE; num++)
                        {
                            Matrix[r][c] = num;
                            if (IsValid())
                            {
                                if (Solve())
                                {
                                    return true;
                                }
                            }
                        }
                        Matrix[r][c] = JOKER;
                        return false;
                    }
                }
            }
            return true;
        }

        private static Boolean IsValid()
        {
            for (var r = 0; r < SIZE; r += CELL)
            {
                for (var c = 0; c < SIZE; c += CELL)
                {
                    if (!Permutation.IsPermutationBlock(Matrix,r,r + CELL,c,c + CELL))
                    {
                        return false;
                    }
                }
            }
            return Permutation.IsPermutation(Matrix);
        }
    }
}
