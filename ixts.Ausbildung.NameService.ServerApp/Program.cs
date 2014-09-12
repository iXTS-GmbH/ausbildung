using System;

namespace ixts.Ausbildung.NameService.ServerApp
{
    public class Program
    {
        private const int STANDARDPORT = 2000;
        static void Main(string[] args)
        {
            var port = args.Length == 0 ? STANDARDPORT : Int32.Parse(args[0]);
            new PersistentNameServer(port).Loop();
        }
    }
}
