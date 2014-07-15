using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ixts.Ausbildung.Geometry
{
    public class ScriptInterpreter
    {
        private PolygonPrinter polygonPrinter;
        private List<string> listOfForms = new List<string>(); 

        public ScriptInterpreter()
        {

        }

        public void Eval(String script)
        {
            //Hier werden die Scripts der Konsolenapp in befehle umgewandelt und an den PolygonPrinter geschickt
        }
    }
}
