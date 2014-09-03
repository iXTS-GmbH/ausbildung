using System;

namespace TextFileLines
{
    public class RemoveLinesStartsWithMapper:TextFileMapper
    {
        private static String removePoint;
        protected override string Transform(string line)
        {
            if (!String.IsNullOrEmpty(removePoint))
            {
                //erklärung siehe RemoveEmptyLinesMapper
                return line.StartsWith(removePoint) ? null : line;
            }

            return line;
        }

        public void SetRemovePoint(String newRemovePoint)
        {
            removePoint = newRemovePoint;
        }
    }
}
