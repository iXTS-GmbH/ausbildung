using System;

namespace ixts.Ausbildung.TextfileLines
{
    public abstract class TextFileMapper
    {

        public void Map(String sourcePath, String targetPath, IStreamFactory str = null)
        {   
            str = str ?? new StreamFactory();

            var file = str.Make(sourcePath, targetPath);
            var tfL = new TextFileLine(sourcePath, str);

            foreach (var line in tfL)
            {
                var transformedLine = Transform(line);

                if (transformedLine != null)
                {
                    file.WriteLine(transformedLine);
                }
            }

            file.Close();
        }

        protected abstract String Transform(String line);
    }
}
