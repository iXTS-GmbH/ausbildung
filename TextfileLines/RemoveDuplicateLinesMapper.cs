using System;

namespace TextFileLines
{
    public class RemoveDuplicateLinesMapper:TextFileMapper
    {
        private String lastLine = "";

        protected override String Transform(String line)
        {
            if (lastLine == line)
            {
                return null;
            }
            lastLine = line;
            return line;
        }
    }
}
