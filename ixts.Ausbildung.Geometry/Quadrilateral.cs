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

            return Math.Abs(Points[0].Distance(Points[1]) - Points[1].Distance(Points[2])) < 0.001 &&
                   Math.Abs(Points[1].Distance(Points[2]) - Points[2].Distance(Points[3])) < 0.001 &&
                   Math.Abs(Points[2].Distance(Points[3]) - Points[3].Distance(Points[0])) < 0.001;
        }

        public Boolean Parallelogram()
        {
            return Math.Abs(Points[0].Distance(Points[1]) - Points[2].Distance(Points[3])) < 0.001 &&
                   Math.Abs(Points[1].Distance(Points[2]) - Points[3].Distance(Points[0])) < 0.001;
        }
    }
}
