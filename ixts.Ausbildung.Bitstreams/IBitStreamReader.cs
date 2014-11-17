using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ixts.Ausbildung.Bitstreams
{
    public interface IBitStreamReader
    {
        int Read();
        Boolean EndOfStream();
        void Close();
    }
}
