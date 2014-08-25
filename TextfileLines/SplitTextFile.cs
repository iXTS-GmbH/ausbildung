using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextFileLines
{
    public class SplitTextFile:TextFileSplitter
    {


        protected override Boolean SplitAt(string line)
        {
            //Hier kommt Testimplementierung rein
            return false;
        }
    }
}
