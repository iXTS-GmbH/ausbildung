using System;

namespace ixts.Ausbildung.NameService.ServerApp
{
    public class Program
    {
        private const int STANDARD_PORT = 2000;
        static void Main(string[] args)
        {
            var port = args.Length == 0 ? STANDARD_PORT : Int32.Parse(args[0]);
            new PersistentNameServer(port).Loop();
        }
    }
}
