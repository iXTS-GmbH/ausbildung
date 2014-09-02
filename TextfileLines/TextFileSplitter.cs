using System;
using System.Collections.Generic;

namespace TextFileLines
{
    public abstract class TextFileSplitter
    {
        public void Split(String sourceFile, IFileStreamFactory str = null)
        {//TODO Splitter so umschreiben das er TextFileLines benutzt
            //Erklärung siehe TextFileLines
            str = str ?? new FileStreamFactory();

            var file = str.Make(sourceFile);

            var nextFileName = string.Format("{0}.000", sourceFile);
            var nextFile = new List<String>();
            var counter = 0;
            var allLines = file.ReadLines();

            for (var i = 0; i < allLines.Length; i++)
            {

                var line = allLines[i];
                nextFile.Add(line);

                if (SplitAt(line) || i == allLines.Length - 1)
                {
                    file.WriteLines(nextFileName,nextFile.ToArray());
                    counter += 1;
                    var fileEnd = GetFileEnd(counter);

                    nextFileName = string.Format("{0}.{1}",sourceFile,fileEnd);
                    nextFile = new List<string>(); 
                }
            }

        }

        private String GetFileEnd(int counter)
        {
            if (counter >= 100)
            {
                return counter.ToString();
            }
            if (counter < 100 && counter >= 10)
            {
                return string.Format("0{0}", counter);
            }
            return string.Format("00{0}", counter);
        }

        protected abstract Boolean SplitAt(String line);

    }
}
