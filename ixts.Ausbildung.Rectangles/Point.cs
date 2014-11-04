using System;

namespace ixts.Ausbildung.Rectangles
{
    public class Point
    {
        private readonly int x;
        private readonly int y;

        public Point(int x,int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X {
            get { return x; }
        }

        public int Y {
            get { return y; }
        }


        public Boolean Equals(Point otherPoint)
        {
            return x == otherPoint.X && y == otherPoint.Y;
        }
    }
}
