using System;
using System.Collections.Generic;

namespace TextFileLines
{
    public class TestFileStream:IFileStream
    {
        private static List<String[]> outputFiles = new List<string[]>();
        private readonly String sourceFile;

        public TestFileStream(String input)
        {
            sourceFile = input;
        }

        public String[][] GetOutput()
        {
            var output = outputFiles;
            outputFiles = new List<String[]>();
            return output.ToArray();
        }


        public string[] ReadLines()
        {
            switch (sourceFile)
            {
                case "splitterTest":
                    return new[]
                    {
                        "Das ist ein Testfile",
                        "split",
                        "Das ist ein zweites Testfile",
                        "split",
                        "Das ist ein mehrzeiliges",
                        "drittes split Testfile"
                    };
                case "BigFile":
                    var bigFile = new List<String>();

                    for (var i = 0; i < 101; i++)
                    {
                        bigFile.Add("Das ist ein großes TestFile");
                        bigFile.Add("break");
                    }

                    return bigFile.ToArray();
            }
            var toBigFile = new List<String>();

            for (int i = 0; i < 1001; i++)
            {
                toBigFile.Add("Dieses TestFile ist zu groß");
                toBigFile.Add("break");
            }

            return toBigFile.ToArray();
        }

        public void WriteLines(string fileName, string[] lines)
        {
            outputFiles.Add(lines);
        }
    }
}
