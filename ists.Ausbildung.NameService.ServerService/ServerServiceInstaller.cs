using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace ixts.Ausbildung.NameService.ServerService
{
    [RunInstaller(true)]
    public class ServerServiceInstaller : Installer
    {
        private ServiceInstaller mInstaller;
        private ServiceProcessInstaller mInstallerProcess;

        public ServerServiceInstaller()
        {
            mInstaller = new ServiceInstaller();
            mInstallerProcess = new ServiceProcessInstaller();

            mInstallerProcess.Account = ServiceAccount.LocalSystem;
            mInstaller.ServiceName = "NameServerService";
            mInstaller.StartType = ServiceStartMode.Manual;

            Installers.Add(mInstaller);
            Installers.Add(mInstallerProcess);
        }
    }
}
