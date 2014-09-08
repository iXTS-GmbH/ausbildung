using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ixts.Ausbildung.NameService
{
    public class TestSocket:ISocket
    {
        public static Boolean Status = true;
        public static List<String> Output = new List<String>();
        private int lineCounter;
        private static List<String> input = new List<String>();
        public static IPAddress ServerIP;


        public void Bind(int port, IPAddress ip)
        {
            ServerIP = ip;
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
                            "PUT firstKey firstValue",
                            "PUT firstKey newfirstValue",
                            "STOP"
                        };

                    break;

                case "GetTest":

                    input = new List<String>
                        {
                            "PUT firstKey firstValue",
                            "GET firstKey",
                            "STOP"
                        };

                    break;

                case "DelTest":

                    input = new List<String>
                        {
                            "PUT firstKey firstValue",
                            "DEL firstKey",
                            "GET firstKey",
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

                case "LoadTest":

                    input = new List<String>
                        {
                            "GET firstKey",
                            "GET secondKey",
                            "GET thirdKey",
                            "GET fourdKey",
                            "STOP"
                        };

                    break;

                case "SaveTest":

                    input = new List<String>
                        {
                            "DEL secondKey",
                            "PUT fourdKey newfourdValue",
                            "PUT fiftKey fiftValue",
                            "STOP"
                        };

                    break;

                case "ClientPutTest":

                    input = new List<String>
                        {
                            "1 "
                        };

                    break;

                case "ClientGetTest":

                    input = new List<String>
                        {
                            "1 GetValue"
                        };

                    break;

                case "ClientDelTest":

                    input = new List<String>
                        {
                            "1 DelValue"
                        };

                    break;

                case "NoFileTest":

                    input = new List<String>
                        {
                            "STOP"
                        };

                    break;
            }
        }
    }
}
