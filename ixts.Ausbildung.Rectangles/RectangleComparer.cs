using System;

namespace ixts.Ausbildung.Rectangles
{
    public class RectangleComparer
    {
        private Rectangle rectanglePQ;
        private Rectangle rectangleST;


        public RectangleComparer(int pX, int pY, int qX, int qY, int sX, int sY, int tX, int tY)
        {
            rectanglePQ = new Rectangle(pX,pY,qX,qY);
            rectangleST = new Rectangle(sX,sY,tX,tY);
        }


        public String Compare()
        {
            if (rectanglePQ.Equals(rectangleST))
            {
                return "same";
            }

            if (Contained())
            {
                return "contained";
            }

            if (Touching())
            {
                return "touching";
            }

            if (Aligned())
            {
                return "aligned";
            }

            return Intersecting() ? "intersecting" : "disjoint";
        }

        private Boolean Contained()
        {
            if (rectanglePQ.LowerLeft.X <= rectangleST.LowerLeft.X && rectanglePQ.LowerLeft.Y <= rectangleST.LowerLeft.Y &&
                rectanglePQ.UpperRight.X >= rectangleST.UpperRight.X && rectanglePQ.UpperRight.Y >= rectangleST.LowerLeft.Y)
            {
                return true;
            }

            return rectanglePQ.LowerLeft.X >= rectangleST.LowerLeft.X && rectanglePQ.LowerLeft.Y >= rectangleST.LowerLeft.Y &&
                   rectanglePQ.UpperRight.X <= rectangleST.UpperRight.X && rectanglePQ.UpperRight.Y <= rectangleST.LowerLeft.Y;
        }

        private Boolean Aligned()
        {
            if (rectanglePQ.LowerLeft.Y == rectangleST.UpperLeft.Y || rectanglePQ.UpperLeft.Y == rectangleST.LowerLeft.Y)
            {
                return InXRow();
            }

            if (rectanglePQ.LowerLeft.X == rectangleST.LowerRight.X || rectanglePQ.LowerRight.X == rectangleST.LowerLeft.X)
            {
                return InYRow();
            }

            return false;
        }

        private Boolean Touching()
        {
            return rectanglePQ.UpperRight.Equals(rectangleST.LowerLeft) || rectanglePQ.LowerRight.Equals(rectangleST.UpperLeft) ||
                   rectanglePQ.UpperLeft.Equals(rectangleST.LowerRight) || rectanglePQ.LowerLeft.Equals(rectangleST.UpperRight);
        }

        private Boolean Intersecting()
        {
            if (rectangleST.LowerLeft.Y > rectanglePQ.LowerLeft.Y && rectangleST.LowerLeft.Y < rectanglePQ.UpperLeft.Y)
            {//oben
                return InXRow();
            }
            if (rectangleST.LowerLeft.Y < rectanglePQ.LowerLeft.Y && rectangleST.LowerLeft.Y > rectanglePQ.UpperLeft.Y)
            {//unten
                return InXRow();
            }
            if (rectangleST.LowerRight.X > rectanglePQ.LowerLeft.X && rectangleST.LowerRight.X < rectanglePQ.LowerRight.X)
            {//links
                return InYRow();
            }
            if (rectangleST.LowerRight.X < rectanglePQ.LowerLeft.X && rectangleST.LowerRight.X > rectanglePQ.LowerRight.X)
            {//rechts
                return InYRow();
            }
            return false;
        }

        private Boolean InXRow()
        {
            if (rectanglePQ.LowerLeft.X <= rectangleST.UpperLeft.X && rectanglePQ.LowerRight.X >= rectangleST.UpperRight.X)
            {
                return true;
            }

            if (rectanglePQ.LowerLeft.X >= rectangleST.UpperLeft.X && rectanglePQ.LowerRight.X <= rectangleST.UpperRight.X)
            {
                return true;
            }

            if (rectanglePQ.LowerLeft.X <= rectangleST.UpperLeft.X && rectanglePQ.LowerRight.X <= rectangleST.UpperRight.X)
            {
                return true;
            }

            return rectanglePQ.LowerLeft.X >= rectangleST.UpperLeft.X && rectanglePQ.LowerRight.X >= rectangleST.UpperRight.X;
        }

        private Boolean InYRow()
        {
            if (rectanglePQ.LowerLeft.Y <= rectangleST.LowerRight.Y && rectanglePQ.UpperLeft.Y <= rectangleST.UpperRight.Y)
            {
                return true;
            }

            if (rectanglePQ.LowerLeft.Y >= rectangleST.LowerRight.Y && rectanglePQ.UpperLeft.Y >= rectangleST.UpperRight.Y)
            {
                return true;
            }

            if (rectanglePQ.LowerLeft.Y <= rectangleST.LowerRight.Y && rectanglePQ.UpperLeft.Y >= rectangleST.UpperRight.Y)
            {
                return true;
            }

            return rectanglePQ.LowerLeft.Y >= rectangleST.LowerRight.Y && rectanglePQ.UpperLeft.Y <= rectangleST.UpperRight.Y;
        }
    }
}
