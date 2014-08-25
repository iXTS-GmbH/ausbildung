using System;

namespace TextFileLines.Test
{
    class NoOutputFileTest: TextFileMapper
    {
        protected override string Transform(String line)
        {
            return line;
        }
    }
}
