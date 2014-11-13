using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.PhysikalischeGroessen
{
    public class Mass:IUnit
    {
        public static Dictionary<String,double> Units = new Dictionary<String, double>
            {
                {"kg",1},
                {"g",10E-3},
                {"lb",0.4536},
                {"Kt",2*10E-4}
            }; 


        public double BaseUnits()
        {
            return Units.Count;
        }
    }
}
