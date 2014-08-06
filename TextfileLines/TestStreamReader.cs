using System.Collections.Generic;
using System;

namespace TextfileLines
{
    public class TestStreamReader : IStreamReader
    {
        private List<String> testfile = new List<string>();

        public TestStreamReader(String path)
        {
            if (path == "NullTest")
            {
                testfile = new List<string>
                    {
                        "Das ist ein Test,",
                        "welcher abdeckt ob",
                        "",
                        "leere Zeilen",
                        "richtig interpretiert werden."
                    };
            }
            if (path == "Test")
            {
                testfile = new List<string>
                    {
                        "Das ist ein Test.",
                        "Wenn dieser Test erfolgreich ist,",
                        "kann man diese Zeilen",
                        "in einer List<String> lesen."  
                    };
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
    }
}