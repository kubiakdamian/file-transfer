using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serialization
{
    public class Serialize
    {
        private static BinaryFormatter formatter = new BinaryFormatter();
        public static File readFromStream(Stream stream)
        {
            return (File) formatter.Deserialize(stream);
        }

        public static void writeToStream(Stream stream, File file)
        {
            formatter.Serialize(stream, file);
        }
    }
}