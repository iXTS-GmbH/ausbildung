using System;
using System.Collections.Generic;
using System.Net;

namespace ixts.Ausbildung.NameService.Test
{
    public class TestSocket:ISocket
    {
        public static Boolean Status = true;
        public static List<String> Output = new List<String>();
        private int lineCounter;
        private static List<String> input = new List<String>();
        public static IPAddress ServerIP;
        private const String COMMAND_PUT = "PUT";
        private const String COMMAND_GET = "GET";
        private const String COMMAND_DEL = "DEL";
        private const String COMMAND_STOP = "STOP";
        private const String SUCCEESS = "1 ";
        private const String DELETED_CHAR_MARKER = "\b";


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

        public void Send(String msg)
        {
            Output.Add(msg);
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
                            string.Format("{1} firstKey firstValue{0}",Environment.NewLine,COMMAND_PUT),
                            string.Format("{1} firstKey newfirstValue{0}",Environment.NewLine,COMMAND_PUT),
                            string.Format("{1}{0}",Environment.NewLine,COMMAND_STOP)
                        };

                    break;

                case "GetTest":

                    input = new List<String>
                        {
                            string.Format("{1} firstKey firstValue{0}",Environment.NewLine,COMMAND_PUT),
                            string.Format("{1} firstKey{0}",Environment.NewLine,COMMAND_GET),
                            string.Format("{1}{0}",Environment.NewLine,COMMAND_STOP)
                        };

                    break;

                case "DelTest":

                    input = new List<String>
                        {
                            string.Format("{1} firstKey firstValue{0}",Environment.NewLine,COMMAND_DEL),
                            string.Format("{1} firstKey{0}",Environment.NewLine,COMMAND_DEL),
                            string.Format("{1} firstKey{0}",Environment.NewLine,COMMAND_GET),
                            string.Format("{1}{0}",Environment.NewLine,COMMAND_STOP)
                        };

                    break;

                case "StopTest":

                    input = new List<String>
                        {
                            string.Format("{1}{0}",Environment.NewLine,COMMAND_STOP)
                        };
                    break;

                case "IllegalCommandTest":
                    input = new List<String>
                        {
                            string.Format("NotACommand{0}",Environment.NewLine),
                            string.Format("{1}{0}",Environment.NewLine,COMMAND_STOP)
                        };
                    break;

                case "LoadTest":

                    input = new List<String>
                        {
                            string.Format("{1} firstKey{0}",Environment.NewLine,COMMAND_GET),
                            string.Format("{1} secondKey{0}",Environment.NewLine,COMMAND_GET),
                            string.Format("{1} thirdKey{0}",Environment.NewLine,COMMAND_GET),
                            string.Format("{1} fourdKey{0}",Environment.NewLine,COMMAND_GET),
                            string.Format("{1}{0}",Environment.NewLine,COMMAND_STOP)
                        };

                    break;

                case "SaveTest":

                    input = new List<String>
                        {
                            string.Format("{1} secondKey{0}",Environment.NewLine,COMMAND_DEL),
                            string.Format("{1} fourdKey newfourdValue{0}",Environment.NewLine,COMMAND_PUT),
                            string.Format("{1} fiftKey fiftValue{0}",Environment.NewLine,COMMAND_PUT),
                            string.Format("{1}{0}",Environment.NewLine,COMMAND_STOP)
                        };

                    break;

                case "ClientPutTest":

                    input = new List<String>
                        {
                            SUCCEESS
                        };

                    break;

                case "ClientGetTest":

                    input = new List<String>
                        {
                            string.Format("{0}GetValue",SUCCEESS)
                        };

                    break;

                case "ClientDelTest":

                    input = new List<String>
                        {
                            string.Format("{0}DelValue",SUCCEESS)
                        };

                    break;

                case "NormalizeDataTest":

                    input = new List<String>
                        {
                            string.Format("PP{1}UT Nor{1}rmalizew{1}dKey Normn{1}alizt{1}edValue{0}",Environment.NewLine,DELETED_CHAR_MARKER),
                            string.Format("{1}{0}",Environment.NewLine,COMMAND_STOP)
                        };

                    break;
            }
        }
    }
}
