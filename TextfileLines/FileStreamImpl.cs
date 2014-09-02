using System;
using System.IO;

namespace TextFileLines
{
    public class FileStreamImpl:IFileStream
    {
        private readonly String sourcePath;
        public FileStreamImpl(string sourceFile)
        {
            sourcePath = sourceFile;
        }

        public string[][] GetOutput()
        {
            return null;
        }


        public string[] ReadLines()
        {
           return File.ReadAllLines(sourcePath);
        }

        public void WriteLines(String fileName,String[] lines)
        {
            File.WriteAllLines(fileName,lines);
        }
    }
}
