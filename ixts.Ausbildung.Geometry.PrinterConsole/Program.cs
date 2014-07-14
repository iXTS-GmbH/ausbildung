using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ixts.Ausbildung.Geometry.PrinterConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            switch (args[0])
            {
                case "draw":
                    Draw(args);
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
            //Methode Draw
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
