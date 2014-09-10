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


        public void Bind(int port, Boolean client, IPAddress ip)
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
                            string.Format("PUT firstKey firstValue{0}",Environment.NewLine),
                            string.Format("PUT firstKey newfirstValue{0}",Environment.NewLine),
                            string.Format("STOP{0}",Environment.NewLine)
                        };

                    break;

                case "GetTest":

                    input = new List<String>
                        {
                            string.Format("PUT firstKey firstValue{0}",Environment.NewLine),
                            string.Format("GET firstKey{0}",Environment.NewLine),
                            string.Format("STOP{0}",Environment.NewLine)
                        };

                    break;

                case "DelTest":

                    input = new List<String>
                        {
                            string.Format("PUT firstKey firstValue{0}",Environment.NewLine),
                            string.Format("DEL firstKey{0}",Environment.NewLine),
                            string.Format("GET firstKey{0}",Environment.NewLine),
                            string.Format("STOP{0}",Environment.NewLine)
                        };

                    break;

                case "StopTest":

                    input = new List<string>
                        {
                            string.Format("STOP{0}",Environment.NewLine)
                        };
                    break;

                case "IllegalCommandTest":
                    input = new List<string>
                        {
                            string.Format("NotACommand{0}",Environment.NewLine),
                            string.Format("STOP{0}",Environment.NewLine)
                        };
                    break;

                case "LoadTest":

                    input = new List<String>
                        {
                            string.Format("GET firstKey{0}",Environment.NewLine),
                            string.Format("GET secondKey{0}",Environment.NewLine),
                            string.Format("GET thirdKey{0}",Environment.NewLine),
                            string.Format("GET fourdKey{0}",Environment.NewLine),
                            string.Format("STOP{0}",Environment.NewLine)
                        };

                    break;

                case "SaveTest":

                    input = new List<String>
                        {
                            string.Format("DEL secondKey{0}",Environment.NewLine),
                            string.Format("PUT fourdKey newfourdValue{0}",Environment.NewLine),
                            string.Format("PUT fiftKey fiftValue{0}",Environment.NewLine),
                            string.Format("STOP{0}",Environment.NewLine)
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
                            string.Format("STOP{0}",Environment.NewLine)
                        };

                    break;
                case "NormalizeDataTest":

                    input = new List<String>
                        {
                            string.Format("PP\bUT Nor\brmalizew\bdKey Normn\balizt\bedValue{0}",Environment.NewLine),
                            string.Format("STOP{0}",Environment.NewLine)
                        };

                    break;
            }
        }
    }
}
