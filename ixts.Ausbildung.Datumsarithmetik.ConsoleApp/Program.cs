using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ixts.Ausbildung.Datumsarithmetik.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wollen sie einen Wochentag bestimmen(WD) oder das Datum des Ostersonntags (ED)");
            var response = Console.ReadLine();
            if (!String.IsNullOrEmpty(response))
            {
                response = response.ToUpper();
            }
            else
            {
                throw new Exception("Keine Angabe");
            }
            
            switch (response)
            {
                case "WD":
                    GetWeekday();
                    break;
                case "ED":
                    GetEasterDate();
                    break;
                default:
                    throw new Exception("Unbekannte Eingabe");
            }
        }

        private static void GetWeekday()
        {
            Console.WriteLine("Bitte geben sie Tag, Monat und Jahr ein (Als Zahl)");
            var response = Console.ReadLine();
            var parameters = response.Split(' ');
            if (parameters.Length < 3)
            {
                throw new Exception("Ungenügende Anzahl Angaben");
            }

            var century = int.Parse(parameters[2])/100;
            var year = int.Parse(parameters[2]) - century*100;


            Console.WriteLine(Zeller.Wochentag(int.Parse(parameters[0]),int.Parse(parameters[1]),year,century));
        }

        private static void GetEasterDate()
        {
            Console.WriteLine("Bitte geben sie ein Jahr ein (yyyy)");
            var response = Console.ReadLine();
            if (!string.IsNullOrEmpty(response))
            {
                Console.WriteLine(EasterDate.GetEasterDate(int.Parse(response)));  
            }
            else
            {
                throw new Exception("Keine Angabe");
            }
            
        }
    }
}
