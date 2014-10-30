using System;

namespace ixts.Ausbildung.Primzahlen.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var max = int.Parse(args[0]);
            for (int i = 2; i < max; i++)
            {
                if (PrimTest.IsPrime(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
