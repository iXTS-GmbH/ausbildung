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
        private int lineCounter = 0;
        private List<String> input = new List<String>(); 

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
            return this;
        }

        public String Receive()
        {
            lineCounter += 1;
        }

        public void Send(byte[] msg)
        {

            Output.Add(Encoding.ASCII.GetString(msg));
        }


        public void Close()
        {
            lineCounter = 0;
            Status = false;
            Output = new List<string>();
        }

        public void SetTestProtokoll(String protokollKey)
        {
            switch (protokollKey)
            {
                case "PutTest":

                    input = new List<String>
                        {
                            ""
                        };

                    break;
                case "GetTest":

                    input = new List<String>
                        {
                            ""
                        };

                    break;
                case "DelTest":

                    input = new List<String>
                        {
                            ""
                        };

                    break;
            }
        }
    }
}
