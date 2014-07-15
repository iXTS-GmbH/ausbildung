using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ixts.Ausbildung.Geometry
{
    public class StringToPointsParser
    {
        public StringToPointsParser()
        {

        }

        public static Point[] Parse(string pointstring)
        {
                var points = new List<Point>();
                var pointsstrings = pointstring.Split(' ');
                foreach (string point in pointsstrings)
                {
                    var coordinates = point.Split('/');
                    points.Add(new Point(double.Parse(coordinates[0]), double.Parse(coordinates[1])));
                }
                return points.ToArray();//Hier sollen aus dem String die Points gemacht werden (Format: x/y x/y)
        }
    }
}
