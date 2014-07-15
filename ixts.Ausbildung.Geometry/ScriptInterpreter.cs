﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace ixts.Ausbildung.Geometry
{
    public class ScriptInterpreter
    {
        internal PolygonPrinter polygonPrinter = new PolygonPrinter();
        internal List<string> listOfForms = new List<string>(); 

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
                var pointstring = parameter[2] + " " + parameter[3] + " " + parameter[4]; //um einen String zu erhalten der alle Punkte in den Parametern hat
                var points = StringToPointsParser.Parse(pointstring);
                listOfForms.Add(polygonPrinter.Create(points[0],points[1],points[2]));
            }
            else
            {
                var pointstring = parameter[2] + " " + parameter[3] + " " + parameter[4] + " " + parameter[5];//siehe anderen Komentar
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
            polygonPrinter.MovePolygon(listOfForms[listOfForms.Count - 1],moveX,moveY);
        }

        private void Zoom(double factor)
        {
            polygonPrinter.ZoomPolygon(listOfForms[listOfForms.Count - 1],factor);
        }

        private void Print(string path)
        {
            Bitmap bitmap = polygonPrinter.Print();
            bitmap.Save(path); //Wichtig das path den Dateinamen enthält(Fehlerquelle)
        }
    }
}


