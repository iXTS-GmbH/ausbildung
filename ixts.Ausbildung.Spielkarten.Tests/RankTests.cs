using System;
using NUnit.Framework;

namespace ixts.Ausbildung.Spielkarten.Tests
{
    [TestFixture]
    public class RankTests
    {
        [TestCaseSource("GetRankTestSource")]
        public void GetRankTest(Hand hand, String expected)
        {
            var rank = new Rank(hand);
            var actual = rank.GetRank();
            var a = new Card(Suit.Diamond, Kind.A);

            Assert.AreEqual(expected, actual);
        }
        //
        public static readonly object[] GetRankTestSource =
            {
                new object[]{new Hand(new Card(Suit.Diamond, Kind.A), new Card(Suit.Diamond, Kind.K), new Card(Suit.Diamond, Kind.Q), new Card(Suit.Diamond, Kind.J), new Card(Suit.Diamond, Kind.N10)), "Royal Flush"},

            };
    }
}
