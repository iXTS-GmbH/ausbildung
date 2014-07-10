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
            set 
            { 
                x = value; 
            }
        }

        public double Y
        {
            get 
            { 
                return y;
            }
            set
            {
                y = value;
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
    }
}
