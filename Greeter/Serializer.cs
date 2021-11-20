using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace RenCapGrpc.Shared
{
    public static class Serializer<T>
    {
        public static byte[] ToBytes(T obj)
        {
            var bs = new BinaryFormatter();
            var ms = new MemoryStream();
            bs.Serialize(ms, obj);
            return ms.ToArray();
        }

        public static T FromBytes(byte[] bytes)
        {
            var bs = new BinaryFormatter();
            var ms = new MemoryStream(bytes);
            var data = bs.Deserialize(ms);
            return (T)data;
        }
    }
}