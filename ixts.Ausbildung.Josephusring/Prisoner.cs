
namespace ixts.Ausbildung.Josephusring
{
    public class Prisoner
    {
        public Prisoner Next;
        private readonly int position;

        public Prisoner(int position)
        {
            this.position = position;
            Next = this;
        }

        public void InsertNext(Prisoner p)
        {
            p.Next = Next;
            Next = p;
        }

        public void RemoveNext()
        {
            Next = Next.Next;
        }

        public int GetPosition()
        {
            return position;
        }
    }
}
