using System;

namespace ixts.Ausbildung.Geometry
{
    public class Point
    {
        protected double x;
        protected double y;
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
            double disX = (nPoint.x - this.x)*(nPoint.x - this.x);
            double disY = (nPoint.y - this.y)*(nPoint.y - this.y);
            double distance = Math.Sqrt(disX + disY);
            return distance;
        }

        public Boolean IsSame(Point nPoint, double within)
        {
            double distance = this.Distance(nPoint);
            return distance <= within;

        }

        public Point Moved(double moveX, double moveY)
        {
            var movedPoint = new Point(this.x + moveX, this.y + moveY);
            return movedPoint;
        }
    }
}
