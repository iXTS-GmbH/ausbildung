using System;
using System.Collections.Generic;

namespace TextFileLines
{
    public abstract class TextFileSplitter
    {
        public void Split(String inputFile, IFileStreamFactory str = null, IStreamFactory stf = null)
        {
            stf = stf ?? new StreamFactory();
            str = str ?? new FileStreamFactory();
            var file = str.Make(inputFile);
            var nextFileName = string.Format("{0}.000", inputFile);
            var nextFile = new List<String>{};
            var counter = -1;

            for (int i = 0; i < file.ReadLines().Length; i++)
            {
                var line = file.ReadLines()[i];
                nextFile.Add(line);
                if (SplitAt(line) || i == file.ReadLines().Length - 1)
                {
                    file.WriteLines(nextFileName,nextFile.ToArray());
                    counter += 1;
                    var fileEnd = GetFileEnd(counter);
                    nextFileName = string.Format("{0}.{1}",inputFile,fileEnd);
                    nextFile = new List<string>{};
                }
            }

        }

        protected String GetFileEnd(int counter)
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
