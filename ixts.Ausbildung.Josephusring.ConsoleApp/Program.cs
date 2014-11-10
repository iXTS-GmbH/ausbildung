using System;

namespace ixts.Ausbildung.Josephusring.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bitte geben sie die Anzahl Gefangener und die 'fatale' Nummer ein");
            var response = Console.ReadLine();

            if (string.IsNullOrEmpty(response))
            {
                throw new Exception("Keine Angabe gemacht");
            }

            var parameters = response.Split(' ');

            var prisioners = int.Parse(parameters[0]);
            var fatalNumber = int.Parse(parameters[1]);

            var ring = new Ring(prisioners);

            Console.WriteLine("Der Überlebende steht an Position {0}",ring.GetJosephusPosition(fatalNumber));
            Console.ReadLine();
        }
    }
}
