using System;

namespace TextFileLines
{
    public abstract class TextFileMapper
    {

        public void Map(String sourcePath, String targetPath, IStreamFactory str = null)
        {   
            //Erklärung siehe TextFileLines
            str = str ?? new StreamFactory();

            var file = str.Make(sourcePath, targetPath);
            var tfL = new TextFileLines(sourcePath, str);

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

        protected abstract String Transform(String line);
    }
}
