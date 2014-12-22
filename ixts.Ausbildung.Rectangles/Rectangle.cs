using System;

namespace ixts.Ausbildung.Rectangles
{
    public class Rectangle
    {
        public Point LowerLeft;
        public Point UpperLeft;
        public Point LowerRight;
        public Point UpperRight;

        public Rectangle(int lowerLeftX,int lowerLeftY,int upperRightX,int upperRightY)
        {
            LowerLeft = new Point(lowerLeftX,lowerLeftY);
            UpperLeft = new Point(lowerLeftX,upperRightY);
            LowerRight = new Point(upperRightX,lowerLeftY);
            UpperRight = new Point(upperRightX,upperRightY);
        }


        public Boolean Equals(Rectangle otherRectangle)
        {
            return LowerLeft.Equals(otherRectangle.LowerLeft) && UpperRight.Equals(otherRectangle.UpperRight);
        }
    }
}
