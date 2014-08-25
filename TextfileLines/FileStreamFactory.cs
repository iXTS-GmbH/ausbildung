using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextFileLines
{
    public class FileStreamFactory:IFileStreamFactory
    {
        public IFileStream Make(string inputFileName)
        {
            return new FileStreamImpl(inputFileName);
        }
    }
}
