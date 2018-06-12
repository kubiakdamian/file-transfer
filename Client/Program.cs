using System;
using System.IO;

namespace Client
{
    class Program
    {
        private static String path;
        private static Serialization.File file;
        static void Main(string[] args)
        {
            openFileStream();
        
            try
            {
                Client client = new Client("127.0.0.1", 3000);
                client.SendData(file);
                Console.WriteLine("File sent, closing client..");
                client.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static String getFileName()
        {
            String fileName;
            Console.WriteLine("Enter file name: ");
            fileName = Console.ReadLine();

            return fileName;
        }

        private static void openFileStream()
        {
            bool tryingToConnect = true;
            while (tryingToConnect)
            {
                path = "../../" + getFileName() + ".txt";
                try
                {
                    FileStream fileStream = File.OpenRead(path);
                    file = new Serialization.File(path, File.ReadAllBytes(path));
                    tryingToConnect = false;
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Couldn't find file with path:" + path);
                }
            }
        
        }
    }
}