using System;

namespace TextFileLines.Test
{
    class NoOutputFileTest: TextFileMapper
    {
        public override string Transform(String line)
        {
            return line;
        }
    }
}
