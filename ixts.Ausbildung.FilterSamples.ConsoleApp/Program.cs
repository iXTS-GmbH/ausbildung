using System;

namespace ixts.Ausbildung.FilterSamples.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bitte geben sie zu bearbeitende Daten ein. Das Ende wird mit 3 -1 gekennzeichnet");

            var dataEnd = false;
            var data = "";

            while (!dataEnd)
            {
                data += Console.ReadLine();

                var isEndControl = data.Split(' ');

                if (isEndControl[isEndControl.Length - 3] == "-1" && isEndControl[isEndControl.Length - 2] == "-1" && isEndControl[isEndControl.Length -1] == "-1" )
                {
                    dataEnd = true;
                }
                data += " ";
            }

            Console.WriteLine(DataHandler.Handle(data));
        }
    }
}
