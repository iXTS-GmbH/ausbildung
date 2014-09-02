using System;

namespace TextFileLines
{
    public class RemoveEmptyLinesMapper:TextFileMapper
    {
        protected override String Transform(String line)
        {
            if (String.IsNullOrEmpty(line))
            {
                return null;
            }
            return line;
        }
    }
}
