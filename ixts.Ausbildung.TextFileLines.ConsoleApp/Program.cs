using System;
using TextFileLines;

namespace ixts.Ausbildung.TextFileLines.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                throw new ArgumentException("Bitte geben sie einen Befehl ein, eine Liste der möglichen Befehle und deren Parameter können mit help oder ? eingesehen werden");
            }

            switch (args[0])
            {
                case "toUppercase":
                    ToUppercase(args[1], args[2]);

                    break;

                case "split":
                    if (args.Length == 3)
                    {
                        Split(args[1], args[2]);
                    }
                    else
                    {
                        Split(args[1]);
                    }

                    break;

                case "help":
                    Help();

                    break;

                case "?":
                    Help();

                    break;
            }
        }

        private static void ToUppercase(String sourcePath, String outputFile)
        {
            var fileMapper = new ToUpperLine();
            fileMapper.Map(sourcePath,outputFile);
        }

        private static void Split(String sourcePath, String splitPoint = null)
        {
            var fileSplitter = new SplitTextFile();
            if (splitPoint != null)
            {
                fileSplitter.SetSplitPoint(splitPoint);
            }
            fileSplitter.Split(sourcePath);
        }

        private static void Help()
        {
            Console.WriteLine("");
            Console.WriteLine("-ToUppercase sourcePath outputFile");
            Console.WriteLine("");
            Console.WriteLine("sourcePath:");
            Console.WriteLine("Der Pfad zu der Datei die bearbeitet werden soll");
            Console.WriteLine("");
            Console.WriteLine("outputFile:");
            Console.WriteLine("Der Pfad zu dem Platz an den die bearbeitete Datei gespeichert werden soll");
            Console.WriteLine("");
            Console.WriteLine("-Split sourcePath splitPoint(optional)");
            Console.WriteLine("");
            Console.WriteLine("sourcePath:");
            Console.WriteLine("Der Pfad zu der Datei die bearbeitet werden soll");
            Console.WriteLine("");
            Console.WriteLine("splitPoint(optional):");
            Console.WriteLine("Ein Zeichen oder eine Zeichenkette an der, wenn sie am Zeilenanfang steht, die Datei gesplalten wird");
            Console.WriteLine("Standart: break");
            Console.WriteLine("");
            Console.WriteLine("help / ?:");
            Console.WriteLine("Ruft die Hilfe auf");
            Console.WriteLine("");
        }
    }
}
