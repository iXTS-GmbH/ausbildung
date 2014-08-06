using System.Collections.Generic;
using System;

namespace TextfileLines
{
    public class TestStreamReader : IStreamReader
    {
        private static readonly List<String> Testfile = new List<string>
            {
                "Das ist ein Test.",
                "Wenn dieser Test erfolgreich ist,",
                "kann man diese Zeilen",
                "in einer List<String> lesen."
            };

            private int count = -1;

            public string ReadLine()
            {
                if (count < Testfile.Count - 1)
                {
                    count += 1;
                    return Testfile[count];
                }
                return null;
            }
    }
}