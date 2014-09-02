using System;

namespace TextFileLines
{
    public class ToUpperLineMapper : TextFileMapper
    {
        protected override String Transform(String line)
        {
            return line.ToUpper();
        }
    }
}
