
using System;

namespace ixts.Ausbildung.Spielkarten
{
    public class Card
    {
        public int CardKind;
        public int CardSuit;

        public Card(int suit, int kind)
        {
            CardSuit = suit;
            CardKind = kind;
        }

        public Boolean Equals(Card otherCard)
        {
            return CardKind == otherCard.CardKind && CardSuit == otherCard.CardSuit;
        }

        public String CardString()
        {
            return string.Format("{0} {1}",Suit.ValueString[CardSuit],Kind.ValueString[CardKind]);
        }
    }
}