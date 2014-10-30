using System;

namespace ixts.Ausbildung.Primzahlen.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wollen sie alle Primzahlen bis zu einem Wert anzeigen(p) oder eine zufällige Primzahl generieren(g)?");
            var command = Console.ReadLine();

            switch (command)
            {
                case "p":
                    GetAllPrimesUpToValue();
                    break;
                case "g":
                    GetRandomPrime();
                    break;
                default:
                    throw new ArgumentException(string.Format("{0} ist kein gültiger Befehl",command));
            }
        }

        private static void GetAllPrimesUpToValue()
        {
            Console.WriteLine("Bitte geben sie den Grenzwert ein");
            var line = Console.ReadLine();
            var value = 0;
            if (!String.IsNullOrEmpty(line))
            {
                value = int.Parse(line);
            }
            else
            {
                throw new ArgumentException("Kein Grenzwert angegeben");
            }
            for (var i = 2; i < value; i++)
            {
                if (PrimTest.IsPrime(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static void GetRandomPrime()
        {
          Console.WriteLine("Ihre zufällig generierte Primzahl ist:");
          Console.WriteLine(Fermat.RandomPrime());
        }

    }
}
            