using System;

namespace ixts.Ausbildung.NameService.ServerApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            int port = args.Length == 0 ? 2000 : Int32.Parse(args[0]);
            new PersistenterNameServer(port).Loop();
        }
    }
}
