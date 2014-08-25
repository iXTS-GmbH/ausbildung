using System;
using System.Collections.Generic;

namespace TextFileLines
{
    public class TestFileStream:IFileStream
    {
        private static readonly List<String[]> outputFiles = new List<string[]>();
        private static String inputFile;
        public TestFileStream(string inputFileName)
        {
            if (inputFileName != null)
            {
                inputFile = inputFileName;
            }
            else
            {
                throw new ArgumentException("Null");
            }
            
        }

        public String[][] GetOutput()
        {
            return outputFiles.ToArray();
        }


        public string[] ReadLines()
        {
            return new []
                {
                    "Das ist ein Testfile",
                    "break",
                    "Das ist ein zweites Testfile",
                    "break",
                    "Das ist ein mehrzeiliges",
                    "drittes Testfile"
                };
        }

        public void WriteLines(string[] lines)
        {
            outputFiles.Add(lines);

        }
    }
}
