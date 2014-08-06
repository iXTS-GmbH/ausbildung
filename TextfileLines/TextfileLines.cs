using System;
using System.Collections;
using System.Collections.Generic;

namespace TextfileLines
{
    public class TextfileLines:IEnumerable<String>
    {
        private readonly List<String> LineList = new List<String>();


        public TextfileLines(String filename, IStreamReaderFactory str = null)
        {
            str = str ?? new StreamReaderFactory();

            var file = str.Make(filename);

            for (var line = file.ReadLine(); line != null; line = file.ReadLine())
            {
                LineList.Add(line);
            }
        }

        public IEnumerator<String> GetEnumerator()
        {
            return LineList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public interface IStreamReaderFactory
    {
        IStreamReader Make(string path);
    }

    public interface IStreamReader
    {
        string ReadLine();
    }  
}
