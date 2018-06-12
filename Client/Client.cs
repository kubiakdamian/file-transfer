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
            try
            {
                Serialize.writeToStream(client.GetStream(), file);
            }
            catch(Exception)
            {
                Console.WriteLine("Failed in sending data");
                Console.ReadKey();
            }
            
        }

        public void Dispose()
        {
            this.client.Close();
        }
    }
}