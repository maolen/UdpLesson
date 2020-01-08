using System;
using System.Net.Sockets;
using System.Net;

namespace UdpLesson
{
    class Program
    {
        static async void Main(string[] args)
        {
            var port = 3231;
            using(var udpClient = new UdpClient(port))
            {
                var asyncResult = await udpClient.ReceiveAsync();
                IPEndPoint sender = null;
                var result = udpClient.Receive(ref sender);

                // Для мультикаст сообщений
                // udpClient.JoinMulticastGroup(IPAddress.Parse("127.0.0.1"));
               
                var senderUdp = new UdpClient(port);
                var text = "Hello";
                var bytes = System.Text.Encoding.UTF8.GetBytes(text);
                var sendedBytes = await senderUdp.SendAsync(bytes, bytes.Length);
            }
        }
    }
}
