
using System;

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

        public Boolean Equals(Card otherCard)
        {
            return Kind == otherCard.Kind && Suit == otherCard.Suit;
        }
    }
}