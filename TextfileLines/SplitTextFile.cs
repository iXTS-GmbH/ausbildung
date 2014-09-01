using System;

namespace TextFileLines
{
    public class SplitTextFile:TextFileSplitter
    {
        private static String splitPoint = "break";
        protected override Boolean SplitAt(string line)
        {
            return line.StartsWith(splitPoint);
        }

        public void SetSplitPoint(String newSplitPoint)
        {
            if (!String.IsNullOrEmpty(newSplitPoint))
            {
                splitPoint = newSplitPoint;
            }
        }

        public String GetSplitPoint()
        {
            return splitPoint;
        }
    }


}
