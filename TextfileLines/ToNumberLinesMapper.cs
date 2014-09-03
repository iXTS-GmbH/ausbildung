using System;

namespace TextFileLines
{
    public class ToNumberLinesMapper : TextFileMapper
    {
        private int lineCounter = 1;
        protected override String Transform(String line)
        {
            var numberedLine = string.Format("{0} {1}",lineCounter,line);
            lineCounter += 1;
            return numberedLine;
        }
    }
}
