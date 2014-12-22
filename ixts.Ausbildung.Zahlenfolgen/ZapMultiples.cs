namespace ixts.Ausbildung.Zahlenfolgen
{
    public class ZapMultiples:Filter
    {
        private readonly int b;

        public ZapMultiples(Naturals source,int b) : base(source)
        {
            this.b = b;
        }

        public override bool Pass(int number)
        {
            return number%b != 0;
        }
    }
}
