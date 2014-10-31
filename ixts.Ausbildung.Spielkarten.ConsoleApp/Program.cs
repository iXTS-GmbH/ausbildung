using System;

namespace ixts.Ausbildung.Spielkarten.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Die Karten werden gegeben...");
            var random = new Random();
            var hand = new Hand(new Card(random.Next(1,4),random.Next(2,14)), new Card(random.Next(1,4),random.Next(2,14)), 
                                new Card(random.Next(1,4),random.Next(2,14)), new Card(random.Next(1,4),random.Next(2,14)), new Card(random.Next(1,4),random.Next(2,14)));
            Console.WriteLine("Ihre Karten:");
            Console.WriteLine(hand.GetHand());
            Console.WriteLine("Sie Haben:");
            Console.WriteLine(hand.GetRank());
        }
    }
}
