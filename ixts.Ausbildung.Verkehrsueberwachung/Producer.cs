using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ixts.Ausbildung.Verkehrsueberwachung
{
    public class Producer
    {
        private readonly String serverIp;
        private readonly String serverPort;

        public Producer(String ip)
        {
            var parameters = ip.Split(':');

            serverIp = parameters[0];
            serverPort = parameters[1];
        }

        public void Control()
        {

            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.Connect(IPAddress.Parse(serverIp),int.Parse(serverPort));

            while (serverIp != null)
            {
                //Hier bedingung einfügen zu der eine nachricht gesendet werden soll
                //als Platzhalter ein Sleep für 5 Sekunden
                Thread.Sleep(5000);
                //
                socket.Send(new byte[]{});
            }
        }
    }
}
