using System;

namespace ixts.Ausbildung.NameService.ServerApp
{
    public class ServerApp
    {
        static void Main(string[] args)
        {
            var port = args.Length == 0 ? Constants.STANDARD_PORT : Int32.Parse(args[0]);
            new PersistentNameServer(port).Loop();
        }
    }
}
