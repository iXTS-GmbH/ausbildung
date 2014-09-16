using System.ServiceProcess;
using System.Threading;

namespace ixts.Ausbildung.NameService.ServerService
{
    public partial class ServerService : ServiceBase
    {
        private PersistentNameServer server;

        public ServerService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //Parallel.Invoke(() =>
            //    {
            //        server = new PersistentNameServer(2000);
            //        server.Loop(); //Bereitet ihm Probleme
            //    });

            var loopThread = new Thread(ServerStart);
            loopThread.Start();
        }

        protected override void OnStop()
        {
            server.Stop();
        }

        private void ServerStart()
        {
            server = new PersistentNameServer(2000);
            server.Loop(); 
        }
    }
}
