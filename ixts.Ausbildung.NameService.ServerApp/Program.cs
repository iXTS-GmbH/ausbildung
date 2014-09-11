using System;

namespace ixts.Ausbildung.NameService.ServerApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var port = args.Length == 0 ? 2000 : Int32.Parse(args[0]);
            new PersistentNameServer(port).Loop();
        }
    }
}
