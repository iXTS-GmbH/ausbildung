using System.Collections.Generic;

namespace ixts.Ausbildung.Josephusring
{
    public class Ring
    {
        private readonly List<Prisoner> ring = new List<Prisoner>(); 

        public Ring(int prisioners)
        {
            for (var i = 0; i < prisioners; i++)
            {
                ring.Add(new Prisoner(i));
            }

            for (var i = 0; i < ring.Count - 1; i++)
            {
                ring[i].InsertNext(ring[i + 1]);
            }
        }

        public int GetJosephusPosition(int fatalNumber)
        {
            var remove = fatalNumber%ring.Count - 1;

            while (ring.Count > 1)
            {
                if (remove == -1)
                {
                    remove = ring.Count - 1;
                }

                ring.RemoveAt(remove);
                remove = ((fatalNumber + remove)%ring.Count) - 1;
            }

            return ring[0].GetPosition();
        }
    }
}
