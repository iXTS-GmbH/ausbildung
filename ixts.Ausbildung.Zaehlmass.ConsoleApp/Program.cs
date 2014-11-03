using System;

namespace ixts.Ausbildung.Zaehlmass.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Bitte geben sie die umzuwandelnde Zahl ein");
            var response = Console.ReadLine();
            if (string.IsNullOrEmpty(response) || string.IsNullOrWhiteSpace(response))
            {
                throw new Exception("Keine Zahl angegeben");
            }
            Console.WriteLine("Umgewandelt");
            Console.WriteLine(ZaehlmassUmrechner.GetOldZaehlmass(int.Parse(response)));
        }
    }
}
