using System;
using System.Collections;
using System.Collections.Generic;

namespace TextFileLines
{
    public class TextFileLines:IEnumerable<String>
    {
        private readonly List<String> lineList = new List<String>();

        public TextFileLines(String filename, IStreamFactory str = null)
        {   //?? heißt NullSammeloperator wenn der Wert nicht null ist wird der linke Wert zurückgegeben wenn er null ist der rechte Wert
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
