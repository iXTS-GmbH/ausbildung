using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ixts.Ausbildung.Watchdog.ConsoleApp
{
    public class Program
    {
        private static readonly Dictionary<String,IPAddress> Hosts = new Dictionary<string, IPAddress>(); 

        static void Main(string[] args)
        {

            foreach (var s in args)
            {
                var ip = Dns.GetHostAddresses(s.Split(':')[0])[0];
                Hosts.Add(s,ip);
            }

            new Thread(Send).Start();
            new Thread(Receive).Start();
        }

        private static void Send()
        {
            while (Hosts.Count != 0)
            {
                foreach (var host in Hosts)
                {
                    var connection = true;
                    var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    var endPoint = new IPEndPoint(host.Value, int.Parse(host.Key.Split(':')[1]));
                    var bytes = Encoding.ASCII.GetBytes("32");
                    try
                    {
                        socket.Connect(endPoint);
                    }
                    catch (Exception)
                    {
                        connection = false;
                    }
                    if (connection)
                    {
                        socket.Listen(10);
                        var consocket = socket.Accept();
                        consocket.Send(bytes);
                        consocket.Receive(bytes);
                        var response = Encoding.ASCII.GetString(bytes);
                        Console.WriteLine(response == "64" ? "{0} up" : "{0} down", host.Key);
                    }
                    else
                    {
                        Console.WriteLine("No Connection to Host: {0}",host.Key);
                    }
                    socket.Close();
                }
                Thread.Sleep(10000);
            }
        }

        private static void Receive()
        {
            while (Hosts.Count != 0)
            {
                foreach (var host in Hosts)
                {
                    var connection = true;
                    var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    var endPoint = new IPEndPoint(host.Value, int.Parse(host.Key.Split(':')[1]));
                    var bytes = new byte[1024];

                    try
                    {
                        socket.Connect(endPoint);
                    }
                    catch (Exception)
                    {
                        connection = false;
                    }
                    if (connection)
                    {
                        socket.Listen(10);
                        var consocket = socket.Accept();
                        consocket.Receive(bytes);
                        var request = Encoding.ASCII.GetString(bytes);

                        if (request == "32")
                        {
                            bytes = Encoding.ASCII.GetBytes("64");
                            consocket.Send(bytes);
                        }

                        socket.Close();
                    }
                    else
                    {
                        Console.WriteLine("No Connection to Host: {0}", host.Key);
                    }
                }

                Thread.Sleep(10000);
            }
        }
    }
}
