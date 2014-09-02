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
            if (sourceFile == "splitterTest")
            {
                return new[]
                {
                    "Das ist ein Testfile",
                    "split",
                    "Das ist ein zweites Testfile",
                    "split",
                    "Das ist ein mehrzeiliges",
                    "drittes split Testfile"
                };
            }
            var bigFile = new List<String>();
            for (var i = 0; i < 101; i++)
            {
                bigFile.Add("Das ist ein großes TestFile");
                bigFile.Add("break");
            }
            return bigFile.ToArray();
        }

        public void WriteLines(string fileName, string[] lines)
        {
            outputFiles.Add(lines);
        }
    }
}
