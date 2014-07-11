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
            var check = Math.Round(Points[0].Distance(Points[1]), 3) == Math.Round(Points[1].Distance(Points[2]), 3) &&
                        Math.Round(Points[1].Distance(Points[2]), 3) == Math.Round(Points[2].Distance(Points[3]), 3) &&
                        Math.Round(Points[2].Distance(Points[3]), 3) == Math.Round(Points[3].Distance(Points[0]), 3);
                        
            return check;
        }

        public Boolean Parallelogram()
        {
            var check = Math.Round(Points[0].Distance(Points[1]),3) == Math.Round(Points[2].Distance(Points[3]),3) &&
                        Math.Round(Points[1].Distance(Points[2]),3) == Math.Round(Points[3].Distance(Points[0]),3);
            return check;
        }
    }
}
