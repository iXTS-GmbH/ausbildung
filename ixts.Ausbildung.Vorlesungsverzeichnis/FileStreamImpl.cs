using System;
using System.IO;

namespace ixts.Ausbildung.Vorlesungsverzeichnis
{
    public class FileStreamImpl:IFileStream
    {
        public string[] ReadAllLines(String path)
        {
            return File.ReadAllLines(path);
        }
    }
}
