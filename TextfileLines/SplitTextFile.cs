using System;

namespace TextFileLines
{
    public class SplitTextFile:TextFileSplitter
    {
        protected override Boolean SplitAt(string line)
        {
            return line.StartsWith("break");
        }
    }
}
