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
            var check = Points[0].Distance(Points[1]) == Points[1].Distance(Points[2]) &&
                        Points[2].Distance(Points[0]) == Points[0].Distance(Points[1]);
            return check;
        }

        public Boolean Isosceles()//Gleichschenklig
        {
            var check = Points[0].Distance(Points[1]) == Points[1].Distance(Points[2]) ||
                        Points[1].Distance(Points[2]) == Points[2].Distance(Points[0]) ||
                        Points[2].Distance(Points[0]) == Points[0].Distance(Points[1]);
            return check;
        }
    }
}
