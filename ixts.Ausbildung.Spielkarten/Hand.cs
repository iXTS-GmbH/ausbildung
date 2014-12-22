using System;

namespace ixts.Ausbildung.Spielkarten
{
    public class Hand
    {
        public readonly Card CardIchi; // Ichi == jap. Eins
        public readonly Card CardNi; // Ni == jap. Zwei
        public readonly Card CardSan; // San == jap. Drei
        public readonly Card CardYon; // Yon == jap. Vier
        public readonly Card CardGo; // Go == jap. Fünf
        private readonly Rank rank;

        public Hand(Card cardIchi,Card cardNi, Card cardSan, Card cardYon, Card cardGo)
        {
            CardIchi = cardIchi;
            CardNi = cardNi;
            CardSan = cardSan;
            CardYon = cardYon;
            CardGo = cardGo;
            rank = new Rank(this);
        }


        public String GetRank()
        {
            return rank.GetRank();
        }

        public String GetHand()
        {
            return string.Format("{0} {1} {2} {3} {4}",CardIchi.CardString(),CardNi.CardString(),CardSan.CardString(),CardYon.CardString(),CardGo.CardString());
        }
    }
}
