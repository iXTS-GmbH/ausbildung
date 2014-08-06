using System;
using System.Collections;
using System.Collections.Generic;

namespace TextfileLines
{
    public class TextfileLines:IEnumerable<String>
    {
        private readonly List<String> lineList = new List<String>();


        public TextfileLines(String filename, IStreamFactory str = null)
        {
            str = str ?? new StreamFactory();

            var file = str.Make(filename);

            for (var line = file.ReadLine(); line != null; line = file.ReadLine())
            {
                lineList.Add(line);
            }
        }

        public IEnumerator<String> GetEnumerator()
        {
            return lineList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
