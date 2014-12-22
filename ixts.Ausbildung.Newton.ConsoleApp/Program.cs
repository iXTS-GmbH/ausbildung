using System;

namespace ixts.Ausbildung.Newton.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wollen sie die Quadratwurzel(q) oder die Kubikwurzel(k) berechnen");
            var response = Console.ReadLine();

            switch (response)
            {
                case "q":
                    Console.WriteLine("Geben sie eine Zahl ein");
                    var qNumber = Console.ReadLine();
                    if (string.IsNullOrEmpty(qNumber))
                    {
                        throw new Exception("Keine Zahl angegeben");
                    }
                    Console.WriteLine(Approximation.Calculate(double.Parse(qNumber)));
                    break;
                case "k":
                    Console.WriteLine("Geben sie eine Zahl ein");
                    var kNumber = Console.ReadLine();
                    if (string.IsNullOrEmpty(kNumber))
                    {
                        throw new Exception("Keine Zahl angegeben");
                    }
                    Console.WriteLine(Kubik.Calculate(double.Parse(kNumber)));
                    break;
                default:
                    throw new Exception("Unbekannter Befehl");
            }
        }
    }
}
