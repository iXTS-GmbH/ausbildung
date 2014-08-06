using System;
using System.Collections.Generic;

namespace TextFileLines
{
    public class TestStream:IStream
    {
        private static List<String> readFile = new List<String>();
        private static List<String> writeFile = new List<String>();
        private readonly String fileName;

        public TestStream(String inputFileName, String outputFileName = null)
        {
            fileName = outputFileName;

            switch (inputFileName)
            {
                case "Test":
                    readFile = new List<String>
                    {
                        "Das ist ein Test.",
                        "Wenn dieser Test erfolgreich ist,",
                        "kann man diese Zeilen",
                        "in einer List<String> lesen."  
                    };

                    break;

                case "ToUpperTest":
                    readFile = new List<string>
                    {
                        "Das ist ein Test.",
                        "Wenn dieser Test erfolgreich ist,",
                        "kann man diese Zeilen",
                        "in Caps lesen."
                    };

                    break;

                case "EmptyLineTest":
                    readFile = new List<String>
                    {
                        "Das ist ein Test,",
                        "welcher abdeckt ob",
                        "",
                        "leere Zeilen",
                        "richtig interpretiert werden."
                    };

                    break;

                case "SameLineTest":
                    readFile = new List<String>
                    {
                        "Diese Zeile kommt mehrfach hintereinander",
                        "Diese Zeile kommt mehrfach hintereinander",
                        "Diese Zeile kommt mehrfach hintereinander",
                        "Diese auch",
                        "Diese auch",
                        "Diese auch"
                    };

                    break;

                case "WriteTest":
                    readFile = writeFile;
                    writeFile = new List<String>();
                    break;
            }

        }

        private int counter = -1;

        public String ReadLine()
        {
            if (counter < readFile.Count - 1)
            {
                counter += 1;
                return readFile[counter];
            }
            return null;
        }

        public void WriteLine(String line)
        {
            if (fileName != null)
            {
                writeFile.Add(line);
            }
            else
            {
                throw new ArgumentException("Kein OutputFile angegeben");
            }
        }


        public void Close()
        {
            //Ist in der Prod dazu da die Streams wieder zu schließen hat im Test aber keine Verwendung
        }
    }
}
