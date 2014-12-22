using System;
using System.Drawing;

namespace ixts.Ausbildung.Geometry
{
    public class Quadliteral:Polygon
    {

        public Quadliteral(Point[] points,Color color):base(points,color)
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
