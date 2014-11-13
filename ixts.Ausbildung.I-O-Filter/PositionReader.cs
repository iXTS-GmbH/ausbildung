using System;
using System.IO;

namespace ixts.Ausbildung.I_O_Filter
{
    public class PositionReader:TextReader
    {
        private const int TAB = 8;
        private int line = 1;
        private int column = 0;
        private readonly Boolean unixSystem = Environment.NewLine == "\r\n";

        public override int Read()
        {
            return TrackPosition(base.Read());
        }

        public override int Read(char[] buffer, int index, int count)
        {
            int have = base.Read(buffer, index, count);
            for (int i = index; i < index + have; i++)
            {
                TrackPosition(buffer[i]);
            }
            return have;
        }

        private int TrackPosition(int chr)
        {
            if (chr < 0)
            {
                
            }else if (chr == '\n')
            {
                line++;
                if (unixSystem)
                {
                    column = 0;
                }
            }else if (chr == '\t')
            {
                column = (column/TAB + 1)*TAB;
            }else if (chr == '\r')
            {
                column = 0;
            }
            else
            {
                column++;
            }
            return chr;
        }

        public int Line()
        {
            return line;
        }

        public int Column()
        {
            return column;
        }
    }
}
