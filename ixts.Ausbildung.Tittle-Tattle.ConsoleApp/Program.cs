using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ixts.Ausbildung.Tittle_Tattle.ConsoleApp
{
    class Program
    {
        private static int port = 2000;
        private static String[] hosts;

        static void Main(String[] args)
        {
            port = int.Parse(args[0]);
            var tmp = new List<String>();

            for (var i = 1; i < args.Length; i++)
            {
                tmp.Add(args[i]);
            }

            hosts = tmp.ToArray();
            new Thread(FirstRun).Start();
            new Thread(SecondRun).Start();
        }

        private static void FirstRun()
        {
            var ticker = new RandomTicker();
            while (hosts.Length != 0)
            {
                var number = ticker.Tick();
                Console.WriteLine("I got {0}",number);
                foreach (var host in hosts)
                {
                    var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    var tmp = host.Split(':');
                    var endPoint = new IPEndPoint(IPAddress.Parse(tmp[0]), int.Parse(tmp[1]));
                    socket.Bind(endPoint);
                    var numberstring = number.ToString();
                    var bytes = Encoding.ASCII.GetBytes(numberstring);
                    socket.SendTo(bytes, endPoint);
                    socket.Close();
                }
            }
        }

        private static void SecondRun()
        {
            var serversocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            var localpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            serversocket.Bind(localpoint);
            while (true)
            {
                var bytes = new byte[1024];
                serversocket.Receive(bytes);
                var number = Encoding.ASCII.GetString(bytes);
                Console.WriteLine("Aother got {0}",number);
                serversocket.Close();
            }
        }
    }
}
