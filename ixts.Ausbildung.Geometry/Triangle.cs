using System;

namespace ixts.Ausbildung.Geometry
{
    public class Triangle : Polygon
    {

        public Triangle(Point[] points):base(points)//Constructor
        {

        }
        public Boolean Equilateral()//Gleichseitig
        {

            return Math.Abs(Points[0].Distance(Points[1]) - Points[1].Distance(Points[2])) < 0.001 &&
                   Math.Abs(Points[2].Distance(Points[0]) - Points[0].Distance(Points[1])) < 0.001;
        }

        public Boolean Isosceles()//Gleichschenklig
        {

            return  Math.Abs(Points[0].Distance(Points[1]) - Points[1].Distance(Points[2])) < 0.001 ||
                    Math.Abs(Points[1].Distance(Points[2]) - Points[2].Distance(Points[0])) < 0.001 ||
                    Math.Abs(Points[2].Distance(Points[0]) - Points[0].Distance(Points[1])) < 0.001;
            
        }
    }
}
