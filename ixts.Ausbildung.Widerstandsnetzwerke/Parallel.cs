
namespace ixts.Ausbildung.Widerstandsnetzwerke
{
    public class Parallel:ICircuit
    {
        private ICircuit[] parts;

        public Parallel(ICircuit[] parts)
        {
            this.parts = parts;
        }

        public double GetOhm()
        {
            var result = 0.0;
            foreach (var part in parts)
            {
                result = result + 1/part.GetOhm();
            }

            return 1/result;
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
