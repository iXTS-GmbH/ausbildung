using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextFileLines
{
    public abstract class TextFileSplitter
    {
        public void Split(String inputFile, IFileStreamFactory str = null)
        {

        }

        protected abstract Boolean SplitAt(String line);

    }
}
