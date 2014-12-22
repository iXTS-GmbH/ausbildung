using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.Spielkarten.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Die Karten werden gegeben...");
            var hand = GenerateHand();


            Console.WriteLine("Ihre Karten:");
            Console.WriteLine(hand.GetHand());
            Console.WriteLine("Sie Haben:");
            Console.WriteLine(hand.GetRank());
        }

        private static Hand GenerateHand()
        {
            var random = new Random();
            var cardList = new List<Card>();

            while (cardList.Count < 5)
            {
                var nCard = new Card(random.Next(1, 4),random.Next(2,14));
                var equalCheck = false;

                foreach (var card in cardList)
                {
                    if (!equalCheck)
                    {
                        equalCheck = nCard.Equals(card);
                    }
                    else
                    {
                        break;
                    }
                }

                if (!equalCheck)
                {
                    cardList.Add(nCard);
                }

            }

            return new Hand(cardList[0],cardList[1],cardList[2],cardList[3],cardList[4]);
        }
    }
}
