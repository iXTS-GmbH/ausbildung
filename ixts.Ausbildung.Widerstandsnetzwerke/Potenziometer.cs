
namespace ixts.Ausbildung.Widerstandsnetzwerke
{
    public class Potenziometer:ICircuit
    {
        private double maxOhm;
        private double ohm;

        public Potenziometer(double maxOhm)
        {
            this.maxOhm = maxOhm;
            ohm = 0;
        }

        public double SetOhm(double newOhm)
        {
            if (newOhm > maxOhm)
            {
                ohm = maxOhm;
            }else if (newOhm < 0)
            {
                ohm = 0;
            }
            else
            {
                ohm = newOhm;
            }
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
