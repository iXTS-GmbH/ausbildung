
namespace ixts.Ausbildung.Widerstandsnetzwerke
{
    public class Serial:ICircuit
    {
        private ICircuit[] parts;

        public Serial(ICircuit[] parts)
        {
            this.parts = parts;
        }

        public double GetOhm()
        {
            var result = 0.0;

            foreach (var part in parts)
            {
                result += part.GetOhm();
            }

            return result;
        }

        public int NumberOfResistors()
        {
            var result = 0;

            foreach (var part in parts)
            {
                result += part.NumberOfResistors();
            }

            return result;
        }
    }
}
