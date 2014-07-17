using System;

namespace ixts.Ausbildung.Geometry
{
    public class Point
    {
        private double x;
        private double y;

        public Point(double x,double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X
        {
            get
            {
               return x;
            }
        }

        public double Y
        {
            get 
            { 
                return y;
            }
        }

        public double Distance(Point nPoint)
        {
            double disX = (nPoint.x - x)*(nPoint.x - x);
            double disY = (nPoint.y - y)*(nPoint.y - y);
            double distance = Math.Sqrt(disX + disY);
            return distance;
        }

        public Boolean IsSame(Point nPoint, double within)
        {
            double distance = Distance(nPoint);
            return distance <= within;

        }

        public Point Moved(double moveX, double moveY)
        {
            var movedPoint = new Point(x + moveX, y + moveY);
            return movedPoint;
        }

        override public bool Equals(object other)
        {
            var otherPoint = other as Point;

            return otherPoint != null && Math.Abs(X - otherPoint.X) < 0.001 && Math.Abs(Y - otherPoint.Y) < 0.001;
        }

        override public string ToString()
        {
            return string.Format("{0}/{1}",x,y);
        }
    }
}
