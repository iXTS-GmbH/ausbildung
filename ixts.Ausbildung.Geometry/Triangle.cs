using System;

namespace ixts.Ausbildung.Geometry
{
    public class Triangle:Polygon
    {

    public Triangle(Point[] points):base(points)
        {

        }

        public Boolean Equilateral()
        {
            return false;
        }

        public Boolean Isosceles()
        {
            return false;
        }
    }
}
