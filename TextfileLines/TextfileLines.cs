using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace TextfileLines
{
    public class TextfileLines:IEnumerable<String>
    {

        private readonly List<String> lineList = new List<String>();

        public TextfileLines(String filename)
        {
            var file = new StreamReader(filename);
            for (var line = file.ReadLine(); line != null; line = file.ReadLine())
            {
                lineList.Add(line);
            }
            file.Close();
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
