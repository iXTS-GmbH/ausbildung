using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.PhysikalischeGroessen
{
    public class Time:IUnit
    {
        public static Dictionary<String,double> Units = new Dictionary<String, double>
            {
                {"s",1},
                {"d",24*3600},
                {"yr",365*24*3600},
                {"ns",1E-9}
            }; 


        public double BaseUnits()
        {
            return Units.Count;
        }
    }
}
