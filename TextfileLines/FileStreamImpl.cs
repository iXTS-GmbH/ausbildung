using System;
using System.IO;

namespace TextFileLines
{
    public class FileStreamImpl:IFileStream
    {
        private readonly String inputFileName;
        public FileStreamImpl(string inputFile)
        {
            inputFileName = inputFile;
        }

        public string[][] GetOutput()
        {
            return null;
        }


        public string[] ReadLines()
        {
           return File.ReadAllLines(inputFileName);
        }

        public void WriteLines(String fileName,String[] lines)
        {
            File.WriteAllLines(fileName,lines);
        }
    }
}
