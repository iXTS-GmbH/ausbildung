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
            switch (parameter[0])
            {
                case "draw":
                    ValidateFormat.CheckPointStringFormat(parameter.Skip(2).ToArray());
                    Draw(parameter.Skip(2).ToArray(), parameter[1]);
                    break;
                case "move":
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
                case "zoom":
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
                case "print":
                    if (LastPolygonName == null)
                    {
                        throw new NoFormExeption("Keine zeichenbare Form vorhanden");
                    }
                    Print(parameter[1]);
                    break;
                default:
                    throw new NoCommandExeption(string.Format("Der Befehl {0} ist nicht definiert (Definierte Befehle: draw,move,zoom,print)", parameter[0]));          
            }
           
        }

        private void Draw(String[] parameter, string type)
        {
            var points = StringToPointsParser.Parse(parameter);
                if (parameter.Length == 3)
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
                default:
                    throw new NoCommandExeption(String.Format("{0} ist keine gültige Richtungsangabe (gültige Angaben: north,east,south,west)",direction));
            }
            PolygonPrinter.MovePolygon(LastPolygonName,moveX,moveY);
        }

        private void Zoom(double factor)
        {
            PolygonPrinter.ZoomPolygon(LastPolygonName,factor);
        }

        private void Print(string path)//TODO Abfangen wenn ungültiger Pfad als Parameter mitgegeben wird
        {
            if (!Directory.Exists(path))
            {
                throw new NotExistingDirectoryException(string.Format("Verzeichnis {0} existiert nicht",path ));
            }
            
            Bitmap bitmap = PolygonPrinter.Print();
            bitmap.Save(path); //Wichtig das path den Dateinamen enthält(Fehlerquelle)
        }
    }
}


