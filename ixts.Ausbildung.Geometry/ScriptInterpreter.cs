using System;
using System.Drawing;
using System.IO;
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
            parameter[0] = parameter[0].ToUpper();
            switch (parameter[0])
            {
                case "DRAW":
                    ValidateFormat.CheckPointStringFormat(parameter.Skip(2).ToArray());
                    Draw(parameter.Skip(2).ToArray());
                    break;
                case "MOVE":
                    if (LastPolygonName == null)
                    {
                        throw new NoFormExeption("Keine verschiebbare Form vorhanden!");
                    }
                    if(ValidateFormat.LetterCheck(parameter[2]))
                    {
                        Move(parameter[1],int.Parse(parameter[2]));
                        break;
                    }
                    throw new FalseArgumentExeption(string.Format("{0} ist kein gültiger Verschiebungsparameter",parameter[2]));
                case "ZOOM":
                    if (LastPolygonName == null)
                    {
                        throw new NoFormExeption("Keine zoombare Form vorhanden!");
                    }
                    if (ValidateFormat.LetterCheck(parameter[1]))
                    {
                    Zoom(double.Parse(parameter[1]));
                    break;
                    }
                    throw new FalseArgumentExeption(string.Format("{0} ist kein gültiger Zoomparameter",parameter[1]));
                case "PRINT":
                    if (LastPolygonName == null)
                    {
                        throw new NoFormExeption("Keine zeichenbare Form vorhanden");
                    }
                    Print(parameter[1]);
                    break;
                case "CHANGECOLOR":
                    if (parameter.Length == 5)
                    {
                        ChangeColor(int.Parse(parameter[1]),int.Parse(parameter[2]),int.Parse(parameter[3]),int.Parse(parameter[4]));
                    }
                    if (parameter.Length == 2)
                    {
                        ChangeColor(parameter[1]);
                    }
                    break;
                default:
                    throw new NoCommandExeption(string.Format("Der Befehl {0} ist nicht definiert (Definierte Befehle: DRAW,MOVE,ZOOM,PRINT,CHANGECOLOR)", parameter[0]));          
            }
           
        }

        private void Draw(String[] parameter)
        {
            var points = StringToPointsParser.Parse(parameter);
            LastPolygonName = parameter.Length == 3 ? PolygonPrinter.Create(points[0], points[1], points[2]) : PolygonPrinter.Create(points[0], points[1], points[2], points[3]);
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
                default:
                    throw new NoCommandExeption(String.Format("{0} ist keine gültige Richtungsangabe (gültige Angaben: north,east,south,west)",direction));
            }
            PolygonPrinter.MovePolygon(LastPolygonName,moveX,moveY);
        }

        private void Zoom(double factor)
        {
            PolygonPrinter.ZoomPolygon(LastPolygonName,factor);
        }

        private void Print(string path)
        {   
            var bitmap = PolygonPrinter.Print();
            bitmap.Save(path); //Wichtig das path den Dateinamen enthält(Fehlerquelle)
        }

        private void ChangeColor(String colorname)
        {
            PolygonPrinter.Color = Color.FromName(colorname);
        }

        private void ChangeColor(int alpha,int red,int green,int blue)
        {
            PolygonPrinter.Color = Color.FromArgb(alpha, red, green, blue);
        }
    }
}


