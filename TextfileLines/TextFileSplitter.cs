using System;
using System.Collections.Generic;

namespace TextFileLines
{
    public abstract class TextFileSplitter
    {
        public void Split(String sourceFile, IStreamFactory str = null)
        {
            str = str ?? new StreamFactory();

            var file = str.Make(sourceFile);

            var nextFileName = string.Format("{0}.000", sourceFile);

            var counter = 0;

            var allLines = new TextFileLines(sourceFile, str);

            foreach (var line in allLines)
            {
                
            file.WriteLine(nextFileName, line);

                if (SplitAt(line))
                {
                    counter += 1;
                    nextFileName = string.Format("{0}.{1:000}", sourceFile, counter);
                }
            }
        }

        protected abstract Boolean SplitAt(String line);

    }
}
