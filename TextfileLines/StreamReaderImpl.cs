using System.IO;

namespace TextfileLines
{
    public class StreamReaderImpl : IStreamReader
    {
        private StreamReader reader;

        public StreamReaderImpl(string path)
        {
            reader = new StreamReader(path);
        }

        public string ReadLine()
        {
            return reader.ReadLine();
        }
    }
}
