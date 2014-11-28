using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ixts.Ausbildung.Verkehrsueberwachung
{
    public class TrafficControl
    {
        private readonly Dictionary<String,Producer> producers = new Dictionary<String, Producer>();


        public TrafficControl(IEnumerable<String> detectors,String serverIp)
        {
            foreach (var detector in detectors)
            {
                producers.Add(detector,new Producer(serverIp));
            }
        }

        public void Start()
        {
            foreach (var producer in producers)
            {
                new Thread(Control).Start(producer.Key);
                new Thread(producer.Value.Control).Start();
                Control(producer.Key);
            }
        }

        private static void Control(object o)
        {
            var producerip = (String) o;

            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.Bind(new IPEndPoint(IPAddress.Parse(producerip.Split(':')[0]),int.Parse(producerip.Split(':')[1])));
            var buffer = new byte[10];
            var counter = 0;
            while (true)
            {
                socket.Receive(buffer);
                counter++;
                if (counter >= 10)
                {
                    Console.WriteLine("{0} sah 10 Autos",producerip);
                    counter = 0;
                }
            }
            
        }
    }
}
