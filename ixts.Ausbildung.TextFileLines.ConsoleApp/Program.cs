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
                throw new Exception("Bitte geben sie einen Befehl ein, eine Liste gültiger Befehle und deren Parameter können mit help oder ? eingesehen werden");
            }

            args[0] = args[0].ToUpper();

            switch (args[0])
            {
                case "TOUPPERCASE":

                    ToUpperCase(args[1], args[2]);

                    break;

                case "TOLOWERCASE":

                    ToLowerCase(args[1], args[2]);

                    break;

                case "REMOVEEMPTYLINES":

                    RemoveEmptyLines(args[1],args[2]);

                    break;

                case "REMOVEDUPLICATELINES":

                    RemoveDuplicateLines(args[1], args[2]);

                    break;

                case "SPLIT":
                    if (args.Length == 3)
                    {
                        Split(args[1], args[2]);
                    }
                    else
                    {
                        Split(args[1]);
                    }

                    break;

                case "HELP":

                    Help();

                    break;
                case "?":

                    Help();

                    break;
                default:
                    throw new Exception("Kein Gültiger Befehl! Eine Liste aller gültigen Befehle kann mit help oder ? aufgerufen werden");
            }
        }

        private static void ToUpperCase(String sourcePath, String targetPath)
        {
            var fileMapper = new ToUpperLineMapper();
            fileMapper.Map(sourcePath,targetPath);
        }

        private static void ToLowerCase(String sourcePath, String targetPath)
        {
            var fileMapper = new ToLowerLineMapper();
            fileMapper.Map(sourcePath,targetPath);
        }

        private static void RemoveEmptyLines(String sourcePath, String targetPath)
        {
            var fileMapper = new RemoveEmptyLinesMapper();
            fileMapper.Map(sourcePath,targetPath);
        }

        private static void RemoveDuplicateLines(String sourcePath, String targetPath)
        {
            var fileMapper = new RemoveDuplicateLinesMapper();
            fileMapper.Map(sourcePath,targetPath);
        }

        private static void Split(String sourcePath, String splitPoint = null)
        {
            var fileSplitter = new TextSplitter();
            if (splitPoint != null)
            {
                fileSplitter.SetSplitPoint(splitPoint);
            }
            fileSplitter.Split(sourcePath);
        }

        private static void Help()
        {
            var descriptionPart = " und speichert das Ergebnis in targetPath";

            Console.WriteLine("");
            Console.WriteLine("-TOUPPERCASE sourcePath targetPath");
            Console.WriteLine("Ändert Text in UPPERCASE{0}",descriptionPart);
            ShowPathDescription();

            Console.WriteLine("-TOLOWERCASE sourcePath targetpath");
            Console.WriteLine("Ändert Text in lowercase{0}",descriptionPart);
            ShowPathDescription();

            Console.WriteLine("-REMOVEEMPTYLINES sourcePath targetPath");
            Console.WriteLine("Entfernt leere Zeilen aus Text{0}",descriptionPart);
            ShowPathDescription();

            Console.WriteLine("-REMOVEDUPLICATELINES sourcePath targetPath");
            Console.WriteLine("Entfernt sich hintereinander wiederholende Zeilen{0}",descriptionPart);
            ShowPathDescription();

            Console.WriteLine("-SPLIT sourcePath splitPoint(optional)");
            Console.WriteLine("Spaltet Text an mit splitPoint definierten Punkten und Speichert Ergebnis nummeriert im selben Verzeichnis");
            ShowPathDescription(false);
            Console.WriteLine("splitPoint(optional): Ein Zeichen oder eine Zeichenkette an der die Datei gesplalten wird, wenn sie am Zeilenanfang steht");
            Console.WriteLine("Standart: break");

            Console.WriteLine("-HELP,?:");
            Console.WriteLine("Ruft die Hilfe auf");
        }

        private static void ShowPathDescription(Boolean bothPaths = true)
        { 
            Console.WriteLine("sourcePath: Der Pfad zu der Datei die bearbeitet werden soll");

            if (bothPaths)
            {
                Console.WriteLine("targetPath:Der Pfad zu dem Platz an den die bearbeitete Datei gespeichert werden soll");
            }
            
        }
    }
}
