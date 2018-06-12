using System;

namespace Serialization
{
    [Serializable]
    public class File
    {
        private String name;
        private byte[] data;

        public File(String name, byte[] data)
        {
            this.Name = name;
            this.Data = data;
        }

        public byte[] Data { get => data; set => data = value; }
        public string Name { get => name; set => name = value; }
    }
}