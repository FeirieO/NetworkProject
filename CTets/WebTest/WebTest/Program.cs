using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.WebSockets;
using System.Threading;

namespace WebTest
{

    

    class Program
    {

        static ClientWebSocket client;

        static void Main(string[] args)
        {
            client = new ClientWebSocket();
            Uri serverUri = new Uri($"ws://127.0.0.1:{8000}/");
            Task.Run(async () =>
            {
                await client.ConnectAsync(serverUri, System.Threading.CancellationToken.None);
                byte[] data = Encoding.ASCII.GetBytes("Hello World!");
                ArraySegment<byte> bytesToSend = new ArraySegment<byte>(data);
                await client.SendAsync(bytesToSend, WebSocketMessageType.Text, true, CancellationToken.None);
            });
            Console.ReadLine();
        }
    }
}
