using System.Collections.Generic;

namespace ixts.Ausbildung.Geometry
{
    public class StringToPointsParser
    {

        public static Point[] Parse(string pointstring)
        {
                var points = new List<Point>();
                var pointsstrings = pointstring.Split(new char[]{';',' '});//Trennzeichen der Punkte
                foreach (string point in pointsstrings)
                {
                    var coordinates = point.Split('/');
                    points.Add(new Point(double.Parse(coordinates[0]), double.Parse(coordinates[1])));
                }
                return points.ToArray();
        }
    }
}
