using Serialization;
using System;
using System.Net.Sockets;

namespace Client
{
    class Client : IDisposable
    {
        private TcpClient client;

        public Client(String host, int port)
        {
            client = new TcpClient();
            client.Connect(host, port);
        }

        public void SendData(File file)
        {
            Serialize.writeToStream(client.GetStream(), file);
        }

        public void Dispose()
        {
            this.client.Close();
        }
    }
}