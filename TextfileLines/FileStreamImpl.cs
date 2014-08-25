using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextFileLines
{
    public class FileStreamImpl:IFileStream
    {
        public FileStreamImpl(string inputFile)
        {

        }

        public string[][] GetOutput()
        {
            return null;
        }


        public string[] ReadLines()
        {
            throw new NotImplementedException();
        }

        public void WriteLines(string[] lines)
        {
            throw new NotImplementedException();
        }
    }
}
