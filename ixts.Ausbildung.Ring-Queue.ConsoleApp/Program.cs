using System;

namespace ixts.Ausbildung.Ring_Queue.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var ring = new RingQueue<int>(1, 1, 1);

            for (var i = 0; i < 16; i++)
            {
                var a = ring.Get(2);
                var b = ring.Get(1);
                var c = ring.Get(0);

                ring.Push(a+b+c);
            }

            Console.WriteLine(ring.Get(0));
            Console.ReadLine();
        }
    }
}
