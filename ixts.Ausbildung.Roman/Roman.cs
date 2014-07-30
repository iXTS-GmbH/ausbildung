using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ixts.Ausbildung.Roman
{
    public class Roman
    {
        //Konstruktor der Römische Zahl als String annimmt
        //toString                                                     //toString liefert aus numerischen zahlen römische
        //Getter numeral liefert numerischen wert einer Römischen Zahl //numeral liefert aus römischen zahlen numerische
        //Nur Positive Zahlen
        private string rNumber;

        public Roman(String romaNumber)
        {
            rNumber = romaNumber;
        }

        public int numeral()
        {
            //Gibt numerischen wert von rNumber zurück
            return 0;
        }

        public override String ToString()
        {

            return "";
        }

    }
}

//Römische Zahlen(Werte):
//I = 1
//V = 5
//X = 10
//L = 50
//C = 100
//D = 500
//M = 1000

//Umrechnungsregeln:

//1. Steht ein niedrigerer Wert vor einem Höheren wird Subtrahiert zb. IV = 1 5, 1<5, 5-1 = 4, IV = 4
//2. Andersherum wird Addiert zb. VI = 5 1, 5>1, 5+1 = 6, VI = 6