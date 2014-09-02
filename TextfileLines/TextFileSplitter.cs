using System;
using System.Collections.Generic;

namespace TextFileLines
{
    public abstract class TextFileSplitter
    {
        private const int FIRSTTHREECHARACTERNUMBER = 100;
        private const int FIRSTTWOCHARACTERNUMBER = 10;

        public void Split(String sourceFile, IFileStreamFactory str = null)
        {
            //Erklärung siehe TextFileLines
            str = str ?? new FileStreamFactory();

            var file = str.Make(sourceFile);

            var nextFileName = string.Format("{0}.000", sourceFile);
            var nextFile = new List<String>();
            var counter = 0;
            var allLines = file.ReadLines();

            foreach (var line in allLines)
            {
                nextFile.Add(line);

                if (SplitAt(line))
                {
                    file.WriteLines(nextFileName, nextFile.ToArray());
                    counter += 1;
                    var fileEnd = GetFileEnd(counter);

                    nextFileName = string.Format("{0}.{1}", sourceFile, fileEnd);
                    nextFile = new List<string>();
                }
            }
            if (nextFile.Count > 0)
            {
                file.WriteLines(nextFileName,nextFile.ToArray());
            }
            
        }

        private String GetFileEnd(int counter)
        {
            if (counter >= FIRSTTHREECHARACTERNUMBER)
            {
                return counter.ToString();
            }
            if (counter < FIRSTTHREECHARACTERNUMBER && counter >= FIRSTTWOCHARACTERNUMBER)
            {
                return string.Format("0{0}", counter);
            }
            return string.Format("00{0}", counter);
        }

        protected abstract Boolean SplitAt(String line);

    }
}
