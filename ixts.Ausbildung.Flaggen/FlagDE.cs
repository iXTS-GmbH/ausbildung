using System;

namespace ixts.Ausbildung.Flaggen
{
    public class FlagDE:IFlag
    {
        private readonly int height;
        private readonly int width;
        
        public FlagDE(int width, int height)
        {
            this.height = height;
            this.width = width;
        }


        public String Flagcolor(int pointX, int pointY)
        {
            if (pointX > width || pointY > height)
            {
                throw new Exception("Punkt nicht auf Flagge");
            }

            if (pointY <= height/3)
            {
                return "gold";
            }

            return pointY <= (height/3)*2 ? "red" : "black";
        }
    }
}
