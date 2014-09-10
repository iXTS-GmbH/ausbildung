using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.TextfileLines.Test
{
    public class TestStream:IStream
    {
        private static List<String> readFile = new List<String>();
        private static List<String> writeFile = new List<String>();
        private static List<String[]> outputFiles = new List<String[]>();
        private String lastFile = "";
        private static List<String> currentFile = new List<String>(); 
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

                case "ToLowerLineMapperTest":
                    readFile = new List<string>
                        {
                            "Das ist ein Test.",
                            "Wenn dieser Test erfolgreich ist,",
                            "kann man diese Zeilen",
                            "in Kleinschreibung lesen"
                        };
                    
                    break;

                case "RemoveLinesStartsWithMapperTest":
                    readFile = new List<string>
                        {
                        "Dies ist ein Test,",
                        "delete",
                        "bei welchem einige",
                        "delete",
                        "Zeilen gelöscht werden"
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

                case "splitterTest":
                    readFile = new List<string>
                    {
                        "Das ist ein Testfile",
                        "split",
                        "Das ist ein zweites Testfile",
                        "split",
                        "Das ist ein mehrzeiliges",
                        "drittes split Testfile"
                    };
                    break;

                case "BigFile":
                    readFile = new List<string>();

                    for (int i = 0; i < 101; i++)
                    {
                        readFile.Add("Das ist ein großes TestFile");
                        readFile.Add("break");
                    }

                    break;

                case "ToNumberLinesMapperTest":
                    readFile = new List<string>
                        {
                            "Das ist die erste Zeile.",
                            "Das ist die zweite Zeile.",
                            "Das ist die dritte Zeile."
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

        public string[][] GetOutput()
        {
            outputFiles.Add(currentFile.ToArray());
            var output = outputFiles;
            outputFiles = new List<String[]>();
            return output.ToArray();
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

        public void WriteLine(string targetPath, string line)
        {
            if (lastFile == "" || lastFile == targetPath)
            {
                currentFile.Add(line);
                lastFile = targetPath;
            }
            else
            {
                outputFiles.Add(currentFile.ToArray());
                currentFile = new List<string>{line};
                lastFile = targetPath;
            }   
            
        }


        public void Close()
        {
            //Ist im Produktivzweig dazu da die Streams wieder zu schließen hat im Teststream aber keine Verwendung
        }
    }
}
