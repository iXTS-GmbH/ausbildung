using System;

namespace ixts.Ausbildung.Geometry
{
    public class Triangle : Polygon
    {

        public Triangle(Point[] points):base(points)//Constructor
        {

        }
        public Boolean Equilateral()//Gleichseitig
        {//TODO |x-y| < 0,001 Ueberarbeiten
            return  Math.Round(Points[0].Distance(Points[1]),3).Equals(Math.Round(Points[1].Distance(Points[2]),3))  &&
                    Math.Round(Points[2].Distance(Points[0]),3).Equals(Math.Round(Points[0].Distance(Points[1]),3));
        }

        public Boolean Isosceles()//Gleichschenklig
        {
            return  Math.Round(Points[0].Distance(Points[1]),3).Equals(Math.Round(Points[1].Distance(Points[2]),3)) ||
                    Math.Round(Points[1].Distance(Points[2]),3).Equals(Math.Round(Points[2].Distance(Points[0]),3)) ||
                    Math.Round(Points[2].Distance(Points[0]),3).Equals(Math.Round(Points[0].Distance(Points[1]),3));
            
        }
    }
}
