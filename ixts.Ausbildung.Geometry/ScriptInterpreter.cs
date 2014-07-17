using System;
using System.Drawing;
using System.Linq;

namespace ixts.Ausbildung.Geometry
{
    public class ScriptInterpreter
    {
        internal PolygonPrinter PolygonPrinter = new PolygonPrinter();
        internal string LastPolygonName;

        public void Eval(String script)
        {
            var commands = script.Split(new []{Environment.NewLine},StringSplitOptions.None);
            foreach (var command in commands)
            {
                EvalCommand(command);
            }
        }

        private void EvalCommand(string command)
        {
            var parameter = command.Split(' ');//um Befehlstyp bestimmen zu können
            switch (parameter[0])
            {
                case "draw":
                    Draw(parameter[1] == "Triangle",parameter.Skip(2).ToArray());
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

        private void Draw(Boolean isTriangle,String[] parameter)
        {
            var points = StringToPointsParser.Parse(parameter);
            if (isTriangle)
            {
                LastPolygonName = PolygonPrinter.Create(points[0], points[1], points[2]);
            }
            else
            {
                LastPolygonName = PolygonPrinter.Create(points[0], points[1], points[2], points[3]);
            }
        }

        private void Move(string direction, int offset)
        {
            var moveX = 0;
            var moveY = 0;
            switch (direction)
            {
                case "north"://vektor ist 0/1
                    moveY = offset;
                    break;
                case "east"://vektor ist 1/0
                    moveX = offset;
                    break;
                case "south"://vektor ist 0/-1
                    moveY = -offset;//Negativ
                    break;
                case "west"://vektor ist -1/0
                    moveX = -offset;//Negativ
                    break;
            }
            PolygonPrinter.MovePolygon(LastPolygonName,moveX,moveY);
        }

        private void Zoom(double factor)
        {
            PolygonPrinter.ZoomPolygon(LastPolygonName,factor);
        }

        private void Print(string path)
        {
            Bitmap bitmap = PolygonPrinter.Print();
            bitmap.Save(path); //Wichtig das path den Dateinamen enthält(Fehlerquelle)
        }
    }
}


