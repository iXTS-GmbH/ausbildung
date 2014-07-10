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
            var check = Math.Round(Points[0].Distance(Points[1]),3) == Math.Round(Points[1].Distance(Points[2]),3) &&
                        Math.Round(Points[2].Distance(Points[0]),3) == Math.Round(Points[0].Distance(Points[1]),3);
            return check;
        }

        public Boolean Isosceles()//Gleichschenklig
        {
            var check = Math.Round(Points[0].Distance(Points[1]),3) == Math.Round(Points[1].Distance(Points[2]),3) ||
                        Math.Round(Points[1].Distance(Points[2]),3) == Math.Round(Points[2].Distance(Points[0]),3) ||
                        Math.Round(Points[2].Distance(Points[0]),3) == Math.Round(Points[0].Distance(Points[1]),3);
            return check;
        }
    }
}
