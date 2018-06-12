using System;
using System.IO;

namespace Client
{
    class Program
    {
        static String path = "../../test.txt";
        private static Serialization.File file;
        static void Main(string[] args)
        {
            try
            {
                FileStream fileStream = File.OpenRead(path);
                file = new Serialization.File(path, File.ReadAllBytes(path));
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine("Could find file with name:" + path);
                System.Threading.Thread.Sleep(3000);
                Environment.Exit(0);
            }

           
            try
            {
                Client client = new Client("127.0.0.1", 3000);
                Console.WriteLine("Sending data");
                client.SendData(file);
                Console.WriteLine("Close client");
                client.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}