using System;


namespace ixts.Ausbildung.Rectangles.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bitte geben sie 8 Werte, 4 Für jedes Rechteck, ein");
            var response = Console.ReadLine();
            
            if (string.IsNullOrEmpty(response))
            {
                throw new Exception("Keine Angabe gemacht");
            }

            var parameters = response.Split(' ');

            if (parameters.Length < 8)
            {
                throw new Exception("Ungenügende Angabe");
            }

            var rComparer = new RectangleComparer(int.Parse(parameters[0]), int.Parse(parameters[1]), int.Parse(parameters[2]), int.Parse(parameters[3]), int.Parse(parameters[4]),
                                                  int.Parse(parameters[5]), int.Parse(parameters[6]), int.Parse(parameters[7]));
            Console.WriteLine("Ihre Rechtecke werden verglichen ...");
            Console.WriteLine("Ergebnis: {0}",rComparer.Compare());
        }
    }
}
