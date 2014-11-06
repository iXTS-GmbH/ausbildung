using System;
using NUnit.Framework;

namespace ixts.Ausbildung.Permutation.Test
{
    [TestFixture]
    public class PermutationTests
    {
        [TestCase(new []{1,2,3,4,5,6},true)]//Eine Permutation
        [TestCase(new []{1,2,3,7,5,6},false)]//Zu große Zahl
        [TestCase(new []{1,2,3,3,5,6},false)]//Eine Zahl doppelt
        public void IsPermutationTest(int[] a, Boolean expected)
        {
            var actual = Permutation.IsPermutation(a);

            Assert.AreEqual(expected,actual);
        }

        [TestCaseSource("IsPermutationMatrixTestSource")]
        public void IsPermutationMatrixTest(int[][] a, Boolean expected)
        {
            var actual = Permutation.IsPermutation(a);

            Assert.AreEqual(expected,actual);
        }

        private static readonly object[] IsPermutationMatrixTestSource =
            {
                //Eine Permutation
                new object[]{new []{new []{1,2,3,4,5,6},
                                    new []{2,3,4,5,6,1},
                                    new []{3,4,5,6,1,2},
                                    new []{4,5,6,1,2,3},
                                    new []{5,6,1,2,3,4},
                                    new []{6,1,2,3,4,5}}, true}, 
                //Gleiche Zeilen
                new object[]{new []{new []{1,1,1,1,1,1},
                                    new []{2,2,2,2,2,2},
                                    new []{3,3,3,3,3,3},
                                    new []{4,4,4,4,4,4},
                                    new []{5,5,5,5,5,5},
                                    new []{6,6,6,6,6,6}}, false},
                //Gleiche Spalten
                new object[]{new []{new []{1,2,3,4,5,6},
                                    new []{1,2,3,4,5,6},
                                    new []{1,2,3,4,5,6},
                                    new []{1,2,3,4,5,6},
                                    new []{1,2,3,4,5,6},
                                    new []{1,2,3,4,5,6}}, false} 
            };

    }
}
