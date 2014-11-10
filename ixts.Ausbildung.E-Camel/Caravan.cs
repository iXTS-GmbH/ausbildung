using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.E_Camel
{
    public class Caravan
    {
        private readonly List<Camel> caravan; 

        public Caravan()
        {
            caravan = new List<Camel>();
        }

        public int Pace()
        {
            if (caravan.Count == 0)
            {
                throw new Exception("Empty Caravan");
            }

            var pace = caravan[0].Pace();

            foreach (var camel in caravan)
            {
                if (camel.Pace() < pace)
                {
                    pace = camel.Pace();
                }
            }
            return pace;
        }

        public void AddCamel(Camel c)
        {
            if (c == null)
            {
                throw new Exception("Invalid Argument");
            }

            foreach (var camel in caravan)
            {
                if (c == camel)
                {
                    throw new Exception("Camel already in Caravan");
                }
            }

            if (caravan.Count > 0)
            {
                caravan[caravan.Count - 1].SetNext(c);
            }

            caravan.Add(c);
        }

        public void RemoveCamel(Camel c)
        {
            if (caravan.Count > 0)
            {
                caravan.Remove(c);
            }
            else
            {
                throw new Exception("Empty Caravan");
            }
            
        }

        public void Unload()
        {
            if (caravan.Count == 0)
            {
                throw new Exception("Empty Caravan");
            }

            foreach (var camel in caravan)
            {
                camel.SetLoad(0);
            }
        }

        public void AddLoad(int l)
        {
            if (l < 0)
            {
                throw new Exception("Invalid Argument");
            }

            if (caravan.Count == 0)
            {
                throw new Exception("Empty Caravan");
            }

            while (l != 0)
            {
                var maxSpeed = 0;
                foreach (var camel in caravan)
                {
                    if (camel.Pace() > maxSpeed)
                    {
                        maxSpeed = camel.Pace();
                    }
                }

                foreach (var camel in caravan)
                {
                    if (camel.Pace() == maxSpeed && l != 0)
                    {
                        camel.SetLoad(camel.GetLoad() + 1);
                        l = l - 1;
                    }
                }
            }
        }
    }
}
