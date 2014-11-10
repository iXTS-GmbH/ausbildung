namespace ixts.Ausbildung.Mobiles
{
    public class Mobile:IMobile
    {
        private readonly Wire mobile;

        public Mobile(Wire mobile)
        {
            this.mobile = mobile;
        }

        public double Weight()
        {
            return mobile.Weight();
        }

        public void Balance()
        {
        }

        public override string ToString()
        {
           return mobile.ToString();
        }
    }
}
