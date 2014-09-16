using System;
using System.Collections.Generic;

namespace ixts.Ausbildung.NameService.Test
{
    public class TestConsole:IConsole
    {
        public static List<String> WriteList = new List<String>();
        public static List<String> ReadList = new List<String>();
        private int lineCounter;
        private const String VALUE = "VALUE";
        private const String COMMAND_UNKNOWN = "UnkownCommand";
        private const String KEY_UNKNOWN = "UnkownKey";

        public String Readline()
        {
            lineCounter += 1;
            return ReadList[lineCounter - 1];
        }

        public void WriteLine(String line)
        {
            WriteList.Add(line);
        }


        public static void SetTestProtokoll(String protokollKey)
        {
            switch (protokollKey)
            {
                case "ClientPutTest":

                    ReadList = new List<String>
                        {
                            string.Format("{0} {1} {2}",Constants.COMMAND_PUT,Constants.COMMAND_GET,VALUE),
                            "STOP"
                        };

                    break;

                case "ClientGetTest":
                    
                    ReadList = new List<String>
                        {
                            string.Format("{0} {0}",Constants.COMMAND_GET),
                            "STOP"
                        };

                    break;

                case "ClientDelTest":

                    ReadList = new List<String>
                        {
                            string.Format("{0} {0}",Constants.COMMAND_DEL),
                            "STOP"
                        };

                    break;

                case "UnkownCommandTest":

                    ReadList = new List<String>
                        {
                            string.Format("{0} {1}",COMMAND_UNKNOWN,KEY_UNKNOWN),
                            "STOP"
                        };

                    break;

                case "IPTest":

                    ReadList = new List<String>
                        {
                            string.Format("{0} {1} {2}",Constants.COMMAND_PUT,VALUE,Constants.LOOPBACK),
                            "STOP"
                        };

                    break;
            }


        }
    }
}
