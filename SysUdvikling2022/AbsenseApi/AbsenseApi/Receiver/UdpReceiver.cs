using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using AbsenseApi;
using AbsenseApi.Managers;
using StudentLibrary;

namespace AbsenseApi.Receiver
{
    public class UdpReceiver
    {
        private readonly AbsenseApiManager _manager = new AbsenseApiManager();

        // https://msdn.microsoft.com/en-us/library/tst0kwb1(v=vs.110).aspx
        // IMPORTANT Windows firewall must be open on UDP port 7000
        // https://www.windowscentral.com/how-open-port-windows-firewall
        // Use the network MGV-xxx to capture from local IoT devices (fake or real)
        private const int Port = 7000;
        //private static readonly IPAddress IpAddress = IPAddress.Parse("192.168.5.137"); 
        // Listen for activity on all network interfaces
        // https://msdn.microsoft.com/en-us/library/system.net.ipaddress.ipv6any.aspx
        public void ReceiveAction()
        {
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, Port);
            using (UdpClient socket = new UdpClient(ipEndPoint))
            {
                IPEndPoint remoteEndPoint = new IPEndPoint(0, 0);
                while (true)
                {
                    //Console.WriteLine("Waiting for broadcast {0}", socket.Client.LocalEndPoint);
                    byte[] datagramReceived = socket.Receive(ref remoteEndPoint);

                    string message = Encoding.ASCII.GetString(datagramReceived, 0, datagramReceived.Length);
                    //Console.WriteLine("Receives {0} bytes from {1} port {2} message {3}", datagramReceived.Length,
                    //    remoteEndPoint.Address, remoteEndPoint.Port, message);

                    //Parse(message);
                    Student dude = _manager.GetByNFCId(Convert.ToInt32(message));
                    Console.WriteLine("After " + dude.CheckedIn);
                    dude.CheckedIn = !dude.CheckedIn;
                    dude = _manager.Update(dude.StudentId, dude);
                    Console.WriteLine("Before " + dude.CheckedIn);
                }
            }
        }

        // To parse data from the IoT devices (depends on the protocol)
        //private static void Parse(string response)
        //{
        //    string[] parts = response.Split(' ');
        //    foreach (string part in parts)
        //    {
        //        Console.WriteLine(part);
        //    }
        //    string temperatureLine = parts[6];
        //    string temperatureStr = temperatureLine.Substring(temperatureLine.IndexOf(": ") + 2);
        //    Console.WriteLine(temperatureStr);
        //}
    }
}
