using System;
using System.IO;

namespace TextfileLines
{
    public class StreamImpl:IStream
    {
        private StreamReader reader;
        private StreamWriter writer;

        public StreamImpl(String inputPath, String outputPath = null)
        {
            reader = new StreamReader(inputPath);
            writer = new StreamWriter(outputPath);
        }

        public string ReadLine()
        {
            return reader.ReadLine();
        }

        public void WriteLine(String line)
        {
            writer.WriteLine(line);
        }


        public void Close()
        {
            reader.Close();
            writer.Close();
        }
    }
}
