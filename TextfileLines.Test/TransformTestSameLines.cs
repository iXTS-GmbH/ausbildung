using System;

namespace TextFileLines.Test
{
    public class TransformTestSameLines : TextFileMapper
    {
        private String lastLine;

        protected override String Transform(String line)
        {
            if (line.Equals(lastLine))
            {
                return null;
            }

            lastLine = line;
            return line;
        }
    }
}
