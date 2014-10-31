using System;

namespace ixts.Ausbildung.Spielkarten
{
    public class Rank
    {
        private readonly Hand hand;

        public Rank(Hand hand)
        {
            this.hand = hand;
        }

        public String GetRank()
        {
            return CheckRank();
        }

        private String CheckRank()
        {
            //wie prüfe ich auf die Typen

        }
    }
}
