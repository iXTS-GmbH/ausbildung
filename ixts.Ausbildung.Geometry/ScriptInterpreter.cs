using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ixts.Ausbildung.Geometry
{
    public class ScriptInterpreter
    {
        private PolygonPrinter polygonPrinter = new PolygonPrinter();
        private List<string> listOfForms = new List<string>(); 

        public ScriptInterpreter()
        {

        }

        public void Eval(String script)
        {
            var commands = script.Split(new string[]{"\r\n"},StringSplitOptions.None);
            foreach (var command in commands)
            {
                EvalCommand(command);
            }
        }

        private void EvalCommand(string command)
        {
            var parameter = command.Split(' ');
            switch (parameter[0])
            {
                case "draw":
                    Draw(parameter);
                    break;
                case "move":
                    Move(parameter[1],int.Parse(parameter[2]));
                    break;
                case "zoom":
                    Zoom(double.Parse(parameter[1]));
                    break;
                case "print":
                    Print(parameter[1]);
                    break;
            }            
        }

        private void Draw(string[] parameter)
        {
            if (parameter[1] == "Triangle")
            {
                var pointstring = parameter[2] + " " + parameter[3] + " " + parameter[4];
                var points = StringToPointsParser.Parse(pointstring);
                listOfForms.Add(polygonPrinter.Create(points[0],points[1],points[2]));
            }
            else
            {
                var pointstring = parameter[2] + " " + parameter[3] + " " + parameter[4] + " " + parameter[5];
                var points = StringToPointsParser.Parse(pointstring);
                listOfForms.Add(polygonPrinter.Create(points[0], points[1], points[2],points[3]));
            }
        }

        private void Move(string direction, int offset)
        {
            var moveX = 0;
            var moveY = 0;
            switch (direction)
            {
                case "north"://faktor ist 1/0
                    moveX = offset;
                    break;
                case "east"://faktor ist 0/1
                    moveY = offset;
                    break;
                case "south"://faktor ist -1/0
                    moveX = -offset;//Faktor Negativ
                    break;
                case "west"://faktor ist 0/-1
                    moveY = -offset;//Faktor Negativ
                    break;
            }
            polygonPrinter.MovePolygon(listOfForms[listOfForms.Count - 1],moveX,moveY);
        }

        private void Zoom(double factor)
        {
            polygonPrinter.ZoomPolygon(listOfForms[listOfForms.Count - 1],factor);
        }

        private void Print(string path)
        {
            Bitmap bitmap = polygonPrinter.Print();
            bitmap.Save(path);
        }
    }
}


