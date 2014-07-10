using System;

namespace ixts.Ausbildung.Geometry
{
    public class Triangle:Polygon
    {

    public Triangle(Point[] points):base(points)
        {

        }

        public Boolean Equilateral()//Gleichseitig
        {
            return false;
        }

        public Boolean Isosceles()//Gleichschenklig
        {
            return false;
        }
    }
}
