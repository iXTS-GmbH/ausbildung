using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace ixts.Ausbildung.NameService
{
    public class TestSocket:ISocket
    {
        private int socketPort;
        private int socketBacklog;
        public Boolean Status = true;
        public List<String> Output;


        public void Bind(int port)
        {
            socketPort = port;
        }

        public void Listen(int backlog)
        {
            socketBacklog = backlog;
        }

        public ISocket Accept()
        {
            return null;
        }

        public int Receive(byte[] bytes)
        {
            return 2;//Hier weis ich nicht ganz was ich machen soll
        }

        public void Send(byte[] msg)
        {

            Output.Add(Encoding.ASCII.GetString(msg));
        }


        public void Close()
        {
            Status = false;
            Output = new List<string>();
        }
    }
}
