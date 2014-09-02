using System;
using System.Collections.Generic;

namespace TextFileLines
{
    public class TestStream:IStream
    {
        private static List<String> readFile = new List<String>();
        private static List<String> writeFile = new List<String>();
        private readonly String outputFile;
        private int readFileLineCounter = -1;

        public TestStream(String sourcePath, String targetPath = null)
        {
            outputFile = targetPath;

            switch (sourcePath)
            {
                case "LinesTest":
                    readFile = new List<String>
                    {
                        "Das ist ein Test.",
                        "Wenn dieser Test erfolgreich ist,",
                        "kann man diese Zeilen",
                        "in einer List<String> lesen."  
                    };

                    break;

                case "ToUpperLineMapperTest":
                    readFile = new List<string>
                    {
                        "Das ist ein Test.",
                        "Wenn dieser Test erfolgreich ist,",
                        "kann man diese Zeilen",
                        "in Caps lesen."
                    };
                    break;
                case "RemoveEmptyLinesMapperTest":
                    readFile = new List<string>
                    {
                         "Dies ist ein Test",
                         "um zu schauen ob Leerzeilen",
                         "",
                         "korrekt entfernt werden"
                    };
                    break;
                case "RemoveDuplicateLinesMapperTest":
                    readFile = new List<string>
                    {
                        "Diese Zeile kommt doppelt",
                        "Diese Zeile kommt doppelt",
                        "Diese auch",
                        "Diese auch",
                        "Diese nicht"
                    };
                    break;
                case "WriteTest":
                    readFile = writeFile;
                    writeFile = new List<String>();
                    break;
            }

        }

        public String ReadLine()
        {
            if (readFileLineCounter < readFile.Count - 1)
            {
                readFileLineCounter += 1;
                return readFile[readFileLineCounter];
            }
            return null;
        }

        public void WriteLine(String line)
        {
            if (outputFile != null)
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
            //Ist in der Prod dazu da die Streams wieder zu schließen hat im Teststream aber keine Verwendung
        }
    }
}
