using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ixts.Ausbildung.Geometry.PrinterConsole
{
    class Program
    {
        private static List<Polygon> listOfForms = new List<Polygon>(); 
        static void Main(string[] args)
        {
            switch (args[0])
            {
                case "draw":
                    Draw(args); //draw Triangle 20/20 40/20 30/40
                    break;
                case "move":
                    Move(args);
                    break;
                case "zoom":
                    Zoom(args);
                    break;
                case "print":
                    Print(args);
                    break;
            }
            
        }

        private static void Draw(string[] args)
        {
            var points = new List<Point>();
            for (int i = 2; i < args.Length; i++)
            {
                var coordinates = args[i].Split('/');
                points.Add(new Point( double.Parse(coordinates[0]), double.Parse(coordinates[1])));
            }
            if (args[1] == "Triangle")
            {
                listOfForms.Add(new Triangle(points.ToArray()));
            }
            else
            {
                listOfForms.Add(new Quadrilateral(points.ToArray()));
            }
        }

        private static void Move(string[] args)
        {
            //Methode Move
        }

        private static void Zoom(string[] args)
        {
            //Methode Zoom
        }

        private static void Print(string[] args)
        {
            //Methode Print
        }
    }
}
