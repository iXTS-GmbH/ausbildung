using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ixts.Ausbildung.ByteBurgTarif.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bitte geben sie ihre Start und Ziel-Station ein");
            var response = Console.ReadLine();

            if (string.IsNullOrEmpty(response))
            {
                throw new Exception("Keine Angabe gemacht");
            }

            var parameters = response.Split(' ');

            if (parameters.Length < 2)
            {
                throw new Exception("Ungenügende Angabe");
            }

            Console.WriteLine("Fahrtpreis wird berechnet...");
            var cost = TarifCalculator.Calculate(int.Parse(parameters[0]), int.Parse(parameters[1]));
            Console.WriteLine("Ihre Fahrt kostet {0} Taler",cost);

        }
    }
}
