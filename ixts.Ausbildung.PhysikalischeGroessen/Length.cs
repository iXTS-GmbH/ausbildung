using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.PhysikalischeGroessen
{
    public class Length:IUnit
    {
        public static Dictionary<String,double> Units = new Dictionary<String, double>
            {
                {"m",1},
                {"ft",0.3048},
                {"km",1000},
                {"mi",1632.9},
                {"LY",9.461E15},
                {"A",10E-10}
            };

        public double BaseUnits()
        {
            return Units.Count;
        }
    }
}
