
namespace ixts.Ausbildung.Spielkarten
{
    public class Card
    {
        public int Kind;
        public int Suit;

        public Card(int suit, int kind)
        {
            Suit = suit;
            Kind = kind;
        }
    }
}

//Suit:
// Spade = 4
// Heart = 3
// Diamond = 2
// Leaf = 1

//Kind:
// Ace = 14
// King = 13
// Queen = 12
// Jack = 11
// N10 = 10
// N9 = 9
// N8 = 8
// N7 = 7
// N6 = 6
// N5 = 5
// N4 = 4
// N3 = 3
// N2 = 2