using System;

namespace ixts.Ausbildung.Geometry
{
    public class Quadrilateral:Polygon
    {

        public Quadrilateral(Point[] points):base(points)
        {

        }

        public Boolean Quadrat()
        {
            return false;
        }

        public Boolean Parallelogram()
        {
            return false;
        }
    }
}
