﻿using System;

namespace ixts.Ausbildung.Primzahlen.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Was wollen sie tun?");
            Console.WriteLine();
            Console.WriteLine("Alle Primzahlen bis zu einem Wert ermitteln (AP)");
            Console.WriteLine("Eine zufällige Primzahl generieren (RP)");
            Console.WriteLine("Prüfen ob eine Zahl eine Primzahl ist (CP)");
            Console.WriteLine("Einen Generator zu einer Primzahl ermitteln (GG)");
            Console.WriteLine("Prüfen ob eine Zahl ein Generator für eine Primzahl ist (CG)");
            Console.WriteLine("Eine zufällige Zahl generieren RN");
            var command = Console.ReadLine();

            if (string.IsNullOrEmpty(command))
            {
                command = command.ToUpper();
            }

            switch (command)
            {
                case "AP":
                    GetAllPrimesUpToValue();
                    break;
                case "RP":
                    GetRandomPrime();
                    break;
                case "CP":
                    CheckPrime();
                    break;
                case "GG":
                    GetGenerator();
                    break;
                case "CG":
                    CheckGenerator();
                    break;
                case "RN":
                    GetRandomNumber();
                    break;
                default:
                    throw new ArgumentException(string.Format("{0} ist kein gültiger Befehl",command));
            }
        }

        private static void GetAllPrimesUpToValue()
        {
            Console.WriteLine("Bitte geben sie den Grenzwert ein");
            var line = Console.ReadLine();
            if (!String.IsNullOrEmpty(line))
            {
                throw new ArgumentException("Kein Grenzwert angegeben");
            }
            var value = int.Parse(line);

            for (var i = 2; i < value; i++)
            {
                if (PrimeTest.IsPrime(i))
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

        private static void CheckPrime()
        {
            Console.WriteLine("Bitte geben sie die zu prüfende Zahl ein");
            var line = Console.ReadLine();
            if (String.IsNullOrEmpty(line))
            {
                throw new ArgumentException("Keine Zahl angegeben");
            }
            var value = int.Parse(line);


            Console.WriteLine(PrimeTest.IsPrime(value) ? "Ihre Zahl ist eine Primzahl" : "Ihre Zahl ist keine Primzahl");
        }

        private static void GetGenerator()
        {
            Console.WriteLine("Bitte geben sie eine Primzahl ein");
            var line = Console.ReadLine();
            if (String.IsNullOrEmpty(line) || !PrimeTest.IsPrime(int.Parse(line)))
            {
                throw new ArgumentException("Keine Primzahl angegeben");
            }

            var value = int.Parse(line);

            var generator = PrimeGenerator.GetGenerator(value);

            Console.WriteLine("Ein Generator von {0} ist {1}",value,generator);
        }

        private static void CheckGenerator()
        {
            Console.WriteLine("Bitte geben sie eine Primzahl ein");
            var primeLine = Console.ReadLine();

            if (String.IsNullOrEmpty(primeLine) || !PrimeTest.IsPrime(int.Parse(primeLine)))
            {
                throw new ArgumentException("Keine Primzahl angegeben");
            }
            var prime = int.Parse(primeLine);

            Console.WriteLine("Bitte geben sie den zu Prüfenden Generator ein");
            var generatorLine = Console.ReadLine();

            if (String.IsNullOrEmpty(generatorLine))
            {
                throw new ArgumentException("Keine Zahl angegeben");
            }
            var generator = int.Parse(generatorLine);

            Console.WriteLine(PrimeGenerator.IsGenerator(prime, generator) ? "Ihre Zahl ist ein Generator dieser Primzahl" : "Ihre Zahl ist kein Generator dieser Primzahl");
        }

        private static void GetRandomNumber()
        {
            var prime = Fermat.RandomPrime();
            var random = new Random();

            Console.WriteLine("Ihre zufällig generierte Zahl ist: ");
            Console.WriteLine(new RandomGenerator(prime, random.Next(prime - 1)).Current);
        }
    }
}
            