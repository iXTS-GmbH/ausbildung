﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;

namespace ixts.Ausbildung.Geometry.PrinterConsole
{
    class Program
    {
        private ScriptInterpreter scriptInterpreter;
        private static List<Polygon> listOfForms = new List<Polygon>(); 
        static void Main(string[] args)
        {
            var test = Console.ReadLine();
            Console.Out.Write(test);
        }

        private static void CommandInterpretation(String[] command)//Die Ganze Main ist nicht mehr als Befehlsinterpretation
        {
            switch (command[0])
            {
                case "draw":
                    Draw(command); //draw Triangle 20/20 40/20 30/40
                    break;
                case "move":
                    Move(command);//move north 2
                    break;
                case "zoom":
                    Zoom(command);//zoom 2
                    break;
                case "print":
                    Print(command);//print C:\Users\mkaestl.IXTS\Projekte\Ausbildung\ausbildung\test.png
                    break;
            }
        }

        private static void Draw(string[] args)//Draw Methode
        {
            var points = new List<Point>();
            for (int i = 2; i < args.Length; i++)
            {
                var coordinates = args[i].Split('/');
                points.Add(new Point(double.Parse(coordinates[0]), double.Parse(coordinates[1])));
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

        private static void Move(string[] args)//Move Methode
        {
            var moveX = 0;
            var moveY = 0;
            switch (args[1])
            {
                case "north"://faktor ist 1/0
                    moveX = Convert.ToInt32(args[2]);
                    break;
                case "east"://faktor ist 0/1
                    moveY = Convert.ToInt32(args[2]);
                    break;
                case "south"://faktor ist -1/0
                    moveX = -Convert.ToInt32(args[2]);//Faktor Negativ
                    break;
                case "west"://faktor ist 0/-1
                    moveY = -Convert.ToInt32(args[2]);//Faktor Negativ
                    break;
            }
            listOfForms[listOfForms.Count - 1] = listOfForms[listOfForms.Count - 1].Moved(moveX,moveY);
        }

        private static void Zoom(string[] args)//Zoom Methode 
        {
            var middle = listOfForms[listOfForms.Count - 1].Middle();
            listOfForms[listOfForms.Count - 1] = listOfForms[listOfForms.Count - 1].Zoomed(middle, double.Parse(args[1]));
        }

        private static void Print(string[] args)//Print Methode 
        {
            Bitmap pic = new Bitmap(PicWidth(),PicHeight());
            Graphics g = Graphics.FromImage(pic);
            Pen p = new Pen(Color.Black);
            SolidBrush sb = new SolidBrush(Color.Black);
            for (int i = 0; i < listOfForms.Count; i++)
            {
                var drawpoints = new List<System.Drawing.Point>();
                foreach (var point in listOfForms[i].Points)
                {
                    drawpoints.Add(new System.Drawing.Point(Convert.ToInt32(point.X), Convert.ToInt32(point.Y)));
                }
                g.DrawPolygon(p, drawpoints.ToArray());
                g.FillPolygon(sb, drawpoints.ToArray());
            }
            pic.Save(args[1]);
        }

        private static int PicHeight()
        {
            var values = new List<double>();

            foreach (var form in listOfForms)
            {
                foreach (var point in form.Points)
                {
                    values.Add(point.Y);
                }
            }
            return Range(values);
        }

        private static int PicWidth()
        {
            var values = new List<double>();

            foreach (var form in listOfForms)
            {
                foreach (var point in form.Points)
                {
                    values.Add(point.X);
                }
            }
            return Range(values);
        }

        private static int Range(List<double> values)
        {
            var maxvalue = values.ToArray().Max();
            var minvalue = values.ToArray().Min();
            var height = maxvalue - minvalue;
            return Convert.ToInt32(height);
        }
    }
}
