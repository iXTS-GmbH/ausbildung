using System;
using System.Collections.Generic;

namespace TextfileLines
{
    public class TestStream:IStream
    {
        private static List<String> testfile = new List<string>();
        private static List<String> writefile = new List<string>(); 

        public TestStream(String inputPath, String outputPath)
        {
            switch (inputPath)
            {
                case "Test":
                    testfile = new List<string>
                    {
                        "Das ist ein Test.",
                        "Wenn dieser Test erfolgreich ist,",
                        "kann man diese Zeilen",
                        "in einer List<String> lesen."  
                    };
                    break;

                case "NullTest":
                    testfile = new List<string>
                    {
                        "Das ist ein Test,",
                        "welcher abdeckt ob",
                        "",
                        "leere Zeilen",
                        "richtig interpretiert werden."
                    };
                    break;
                case "SameLineTest":
                    testfile = new List<string>
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
                    testfile = writefile;
                    writefile = new List<string>();
                    break;
            }

        }

        private int count = -1;

        public string ReadLine()
        {
            if (count < testfile.Count - 1)
            {
                count += 1;
                return testfile[count];
            }
            return null;
        }

        public void WriteLine(string line)
        {
            writefile.Add(line);
        }


        public void Close()
        {
        }
    }
}
