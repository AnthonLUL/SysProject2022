//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Net;
//using System.Net.Sockets;
//using System.Text;
//using AbsenseApi;
//using AbsenseApi.Managers;
//using StudentLibrary;
//using System.Text.Json;

//namespace AbsenseApi.Receiver
//{
//    public class UdpReceiver
//    {
//        private static readonly AbsenseApiManager _manager = new AbsenseApiManager();

//        // https://msdn.microsoft.com/en-us/library/tst0kwb1(v=vs.110).aspx
//        // IMPORTANT Windows firewall must be open on UDP port 7000
//        // https://www.windowscentral.com/how-open-port-windows-firewall
//        // Use the network MGV-xxx to capture from local IoT devices (fake or real)
//        private const int Port = 7000;
//        //private static readonly IPAddress IpAddress = IPAddress.Parse("192.168.5.137"); 
//        // Listen for activity on all network interfaces
//        // https://msdn.microsoft.com/en-us/library/system.net.ipaddress.ipv6any.aspx
//        public static void ReceiveAction()
//        {
//            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, Port);
//            using (UdpClient socket = new UdpClient(ipEndPoint))
//            {
//                IPEndPoint remoteEndPoint = new IPEndPoint(0, 0);

//                //Console.WriteLine("Waiting for broadcast {0}", socket.Client.LocalEndPoint);
//                byte[] datagramReceived = socket.Receive(ref remoteEndPoint);

//                string message = Encoding.ASCII.GetString(datagramReceived, 0, datagramReceived.Length);
//                //Console.WriteLine("Receives {0} bytes from {1} port {2} message {3}", datagramReceived.Length,
//                //    remoteEndPoint.Address, remoteEndPoint.Port, message);

//                Parse(message);
//            }
//        }

//        //To parse data from the IoT devices(depends on the protocol)
//        public static void Parse(string response)
//        {
//            string[] parts = response.Split(' ');

//            Student student = JsonSerializer.Deserialize<Student>(response);

//            student = _manager.GetByNFCId(Convert.ToInt32(parts));
//            Console.WriteLine("After " + student.CheckedIn);
//            student.CheckedIn = !student.CheckedIn;
//            student = _manager.Update(student.StudentId, student);
//            Console.WriteLine("Before " + student.CheckedIn);

            

//            //foreach (string part in parts)
//            //{
//            //    Console.WriteLine(part);
//            //}
//            //string temperatureLine = parts[6];
//            //string temperatureStr = temperatureLine.Substring(temperatureLine.IndexOf(": ") + 2);
//            //Console.WriteLine(temperatureStr);
//        }
//    }
//}
