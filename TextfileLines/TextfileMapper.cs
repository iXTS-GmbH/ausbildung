using System;

namespace TextFileLines
{
    public abstract class TextFileMapper:ITextFileMapper
    {

        public void Map(String inputFileName, String outputFileName, IStreamFactory str = null)
        {   //Erklärung siehe TextFileLines
            str = str ?? new StreamFactory();

            var file = str.Make(inputFileName, outputFileName);
            var tfL = new TextFileLines(inputFileName, str);

            foreach (var line in tfL)
            {
                var transLine = Transform(line);

                if (transLine != null)
                {
                    file.WriteLine(transLine);
                }
            }

            file.Close();
        }

        public abstract String Transform(String line);
    }
}
