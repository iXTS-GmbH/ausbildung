using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ixts.Ausbildung.Geometry
{
    public class PolygonPrinter
    {
        private Dictionary<string, Polygon> polygons = new Dictionary<string, Polygon>();
        private int triangleCounter;
        private int quadliteralCounter;
        //Hier soll die ganze Funktionalität hin
        public PolygonPrinter()
        {

        }

        public void MovePolygon(string polygon, double moveX, double movey)
        {
            //Bewegt das Polygon mit dem namen gleich dem string polygon
        }

        public void ZoomPolygon(string polygon, double factor)
        {
            //Zoomed das Polygon mit dem namen gleich dem string polygon
        }

        public void Clear()
        {
            //setzt den PolygonPrinter auf seinen Anfangszustand zurück
        }

        public String Create(Point point1, Point point2, Point point3)//Triangle
        {
            return null; //Erschafft ein Triangle
        }

        public String Create(Point point1, Point point2, Point point3, Point point4)//Quadliteral
        {
            return null;//Erschafft ein Quadliteral
        }

        public Bitmap Print()
        {
            return null;//Zeichnet alle Polygone in ein Bitmap
        }
    }
}
