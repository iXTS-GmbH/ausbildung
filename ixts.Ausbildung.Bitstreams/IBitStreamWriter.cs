using System;

namespace ixts.Ausbildung.Bitstreams
{
    public interface IBitStreamWriter
    {
        void Write(Boolean bit);
        void Close();
    }
}
