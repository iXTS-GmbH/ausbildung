using System;

namespace ixts.Ausbildung.NumberBase.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bitte geben sie die Ausgangsbasis,die Zielbasis und die umzuwandelnde Zahl ein");
            var response = Console.ReadLine();
            if (string.IsNullOrEmpty(response))
            {
                throw new Exception("Keine Angabe gemacht");
            }

            var parameters = response.Split(' ');

            Console.WriteLine(NumberParser.Parse(parameters[0],parameters[1],int.Parse(parameters[2])));
        }
    }
}
