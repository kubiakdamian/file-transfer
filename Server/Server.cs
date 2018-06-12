using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    class Server : IDisposable
    {
        private String address = "127.0.0.1";
        private int port = 3000;
        private TcpListener listener;
        private Serialization.File file;

        public Server()
        {
            this.listener = new TcpListener(IPAddress.Parse(address), port);
            this.listener.Start();
        }

        public void listen()
        {
            while (true)
            {
                Console.WriteLine("Waiting for a client...");
                TcpClient client = listener.AcceptTcpClient();
                new Thread(() => clientThread(client)).Start();
                Console.WriteLine("Client connected");
            }
        }

        private void clientThread(TcpClient client)
        {
            file = Serialization.Serialize.readFromStream(client.GetStream());
            System.IO.File.WriteAllBytes(file.Name, file.Data);
            Console.WriteLine("File Received");
            client.Close();
        }

        public void Dispose()
        {
            listener.Stop();
        }
    }
}