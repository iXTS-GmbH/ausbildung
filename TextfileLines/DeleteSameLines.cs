using System;

namespace TextFileLines
{
    public class DeleteSameLines : TextFileMapper
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
