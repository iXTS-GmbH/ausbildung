using System;

namespace TextFileLines
{
    public class TextSplitter:TextFileSplitter
    {
        private static String splitPoint = "BREAK";

        protected override Boolean SplitAt(string line)
        {
            var upperCaseLine = line.ToUpper();

            return upperCaseLine.StartsWith(splitPoint);
        }

        public void SetSplitPoint(String newSplitPoint)
        {
            if (!String.IsNullOrEmpty(newSplitPoint))
            {
                splitPoint = newSplitPoint.ToUpper();
            }
        }
    }


}
