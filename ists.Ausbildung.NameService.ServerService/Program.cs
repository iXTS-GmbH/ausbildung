using System.ServiceProcess;

namespace ixts.Ausbildung.NameService.ServerService
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new ServerService() 
			};
            ServiceBase.Run(ServicesToRun);
        }
    }
}
