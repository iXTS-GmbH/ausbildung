using System.Collections.Generic;

namespace ixts.Ausbildung.Geometry
{
    public class StringToPointsParser
    {

        public static Point[] Parse(string pointstring)
        {
            var pointstrings = pointstring.Split(new[]{';',' '});//Trennzeichen der Punkte
            return Parse(pointstrings);
        }

        public static Point[] Parse(string[] pointstrings)
        {
            var points = new List<Point>();
            foreach (string point in pointstrings)
            {
                var coordinates = point.Split('/');
                points.Add(new Point(double.Parse(coordinates[0]), double.Parse(coordinates[1])));
            }
            return points.ToArray();
        }
    }
}
