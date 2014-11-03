using System;

namespace ixts.Ausbildung.Maexchen.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bitte geben sie ihren Würfelwurf ein");
            var response = Console.ReadLine();

            if (string.IsNullOrEmpty(response) || string.IsNullOrWhiteSpace(response))
            {
                throw new Exception("Keine Angabe");
            }

            var parameters = response.Split(' ');

            if (parameters.Length < 2)
            {
                throw new Exception("Ungenuegende Angabe");
            }

            Console.WriteLine("Sie haben");
            Console.WriteLine("{0} Punkte", PointCalculator.GetPoints(int.Parse(parameters[0]), int.Parse(parameters[1])));
        }
    }
}
