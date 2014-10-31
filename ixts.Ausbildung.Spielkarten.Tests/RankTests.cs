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

            Assert.AreEqual(expected, actual);
        }
        
        public static readonly object[] GetRankTestSource =
            {
                //Royal Flush
                new object[]{new Hand(new Card(Suit.Diamond, Kind.A), new Card(Suit.Diamond, Kind.K), new Card(Suit.Diamond, Kind.Q), new Card(Suit.Diamond, Kind.J), new Card(Suit.Diamond, Kind.N10)), "Royal Flush"},
                //Straight Flush
                new object[]{new Hand(new Card(Suit.Diamond, Kind.K), new Card(Suit.Diamond, Kind.Q), new Card(Suit.Diamond, Kind.J), new Card(Suit.Diamond, Kind.N10), new Card(Suit.Diamond, Kind.N9)), "Straight Flush"},
                //Four of a Kind/Vierling
                new object[]{new Hand(new Card(Suit.Diamond, Kind.A), new Card(Suit.Heart,Kind.A), new Card(Suit.Leaf,Kind.A), new Card(Suit.Spade,Kind.A), new Card(Suit.Diamond,Kind.K)),"Four of a Kind"},
                //Full House
                new object[]{new Hand(new Card(Suit.Diamond, Kind.A), new Card(Suit.Heart,Kind.A), new Card(Suit.Leaf,Kind.A), new Card(Suit.Spade,Kind.K), new Card(Suit.Diamond,Kind.K)),"Full House"},
                //Straight
                new object[]{new Hand(new Card(Suit.Spade, Kind.K), new Card(Suit.Heart, Kind.Q), new Card(Suit.Leaf, Kind.J), new Card(Suit.Heart, Kind.N10), new Card(Suit.Diamond, Kind.N9)), "Straight"},
                //Straight with Ace == 1
                new object[]{new Hand(new Card(Suit.Leaf,Kind.A),new Card(Suit.Spade,Kind.N2),new Card(Suit.Heart,Kind.N3),new Card(Suit.Diamond,Kind.N4),new Card(Suit.Leaf,Kind.N5)), "Straight"},
                //Three of a Kind/Drilling
                new object[]{new Hand(new Card(Suit.Diamond, Kind.A), new Card(Suit.Heart,Kind.A), new Card(Suit.Leaf,Kind.A), new Card(Suit.Spade,Kind.Q), new Card(Suit.Diamond,Kind.K)),"Three of a Kind"},
                //Two Pairs
                new object[]{new Hand(new Card(Suit.Diamond, Kind.A), new Card(Suit.Heart,Kind.A), new Card(Suit.Leaf,Kind.Q), new Card(Suit.Spade,Kind.K), new Card(Suit.Diamond,Kind.K)),"Two Pairs"},
                //One Pair
                new object[]{new Hand(new Card(Suit.Diamond, Kind.A), new Card(Suit.Heart,Kind.A), new Card(Suit.Leaf,Kind.J), new Card(Suit.Spade,Kind.Q), new Card(Suit.Diamond,Kind.K)),"One Pair"},
                //High Card
                new object[]{new Hand(new Card(Suit.Diamond, Kind.A), new Card(Suit.Heart,Kind.N9), new Card(Suit.Leaf,Kind.J), new Card(Suit.Spade,Kind.Q), new Card(Suit.Diamond,Kind.K)),"High Card"}
            };

        [ExpectedException]
        [TestCase]
        public void InvalidHandTest()
        {
            var hand = new Hand(new Card(Suit.Heart, Kind.A), new Card(Suit.Heart, Kind.A), new Card(Suit.Leaf, Kind.J), new Card(Suit.Spade, Kind.Q), new Card(Suit.Diamond, Kind.K));
            var rank = new Rank(hand);
            rank.GetRank();
        }
    }
}
