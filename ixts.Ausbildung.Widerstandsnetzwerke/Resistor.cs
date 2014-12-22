
namespace ixts.Ausbildung.Widerstandsnetzwerke
{
    public class Resistor:ICircuit
    {
        private readonly double ohm;

        public Resistor(double ohm)
        {
            this.ohm = ohm;
        }

        public double GetOhm()
        {
            return ohm;
        }

        public int NumberOfResistors()
        {
            return 1;
        }
    }
}
