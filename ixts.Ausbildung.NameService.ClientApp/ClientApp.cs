using System;

namespace ixts.Ausbildung.NameService.ClientApp
{
    class ClientApp
    {
        private static NameClient nc;

        static void Main(String[] args)
        {
            var host = args.Length > 0 ? args[0] : Constants.LOOPBACK;
            var port = args.Length > 1 ? Int32.Parse(args[1]) : Constants.STANDARD_PORT;

            try
            {
                nc = new NameClient(host, port);
                nc.Loop();
            }
            catch (FormatException e)
            {
                Console.WriteLine("Es wurde eine ungültige IP-Adresse angegeben");
                ErrorEnd();
            }
            catch (Exception e)
            {
                Console.WriteLine("Es ist ein Fehler aufgetreten");
                ErrorEnd();
            }
        }

        private static void ErrorEnd()
        {
            Console.WriteLine("Drücke beliebige Taste um das Programm zu beenden");
            Console.ReadKey();
        }
    }
}
