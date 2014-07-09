
namespace ixts.Ausbildung.Geometry
{
    public class Polygon
    {
        public Point[] Points;

        //public Polygon()
        //{

        //}

        public double Perimeter()
        {
            var perimeter = 0.0;
            for (var i = 0; i < Points.Length; i++)
            {
                if (i == Points.Length - 1)
                {
                    perimeter = perimeter + Points[i].Distance(Points[0]);
                }
                else
                {
                    perimeter = perimeter + Points[i].Distance(Points[i + 1]);
                }
            }
            return perimeter;
        }
    }
}
