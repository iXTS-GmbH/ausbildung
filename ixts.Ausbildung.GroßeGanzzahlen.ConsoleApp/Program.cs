using System;

namespace ixts.Ausbildung.GroßeGanzzahlen.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Die wievielte Fibonaccizahl möchten sie wissen?");
            var response = Console.ReadLine();
            if (String.IsNullOrEmpty(response))
            {
                throw new Exception("Keine Angabe gemacht");
            }

            Console.WriteLine("Ihre Zahl wird berechnet...");
            var result = Fibonacci.Calculator(int.Parse(response));
            Console.WriteLine("Ihre Zahl ist:");
            Console.WriteLine(result);
        }
    }
}
