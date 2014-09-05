using System;
using System.Collections.Generic;
using System.Text;

namespace ixts.Ausbildung.NameService
{
    public class TestSocket:ISocket
    {
        public static Boolean Status = true;
        public static List<String> Output = new List<String>();
        private int lineCounter;
        private static List<String> input = new List<String>(); 

        public void Bind(int port)
        {
        }

        public void Listen(int backlog)
        {
        }

        public ISocket Accept()
        {
            return this;
        }

        public String Receive()
        {
            lineCounter += 1;
            return input[lineCounter - 1];
        }

        public void Send(byte[] msg)
        {
            Output.Add(Encoding.ASCII.GetString(msg));
        }


        public void Close()
        {
            lineCounter = 0;
            Status = false;
        }

        public void SetTestProtokoll(String protokollKey)
        {
            switch (protokollKey)
            {
                case "PutTest":

                    input = new List<String>
                        {
                            "PUT testKey testValue",
                            "PUT testKey anOtherTestValue",
                            "STOP"
                        };

                    break;
                case "GetTest":

                    input = new List<String>
                        {
                            "PUT testKey testValue",
                            "GET testKey",
                            "STOP"
                        };

                    break;
                case "DelTest":

                    input = new List<String>
                        {
                            "PUT testKey testValue",
                            "DEL testKey",
                            "GET testKey",
                            "STOP"
                        };

                    break;
                case "StopTest":

                    input = new List<string>
                        {
                            "STOP"
                        };
                    break;
                case "IllegalCommandTest":
                    input = new List<string>
                        {
                            "NotACommand",
                            "STOP"
                        };
                    break;
            }
        }
    }
}
