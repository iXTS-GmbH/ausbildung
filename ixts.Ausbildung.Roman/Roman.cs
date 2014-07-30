using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ixts.Ausbildung.Roman
{
    public class Roman
    {
        public readonly String rNumber;

        public Roman(String romaNumber)
        {
            rNumber = romaNumber;
        }

        public override String ToString()
        {
            return rNumber;
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