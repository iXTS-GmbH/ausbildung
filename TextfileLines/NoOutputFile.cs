using System;

namespace TextFileLines
{
    public class NoOutputFile : TextFileMapper
    {
        protected override string Transform(String line)
        {
            return line;
        }
    }
}
