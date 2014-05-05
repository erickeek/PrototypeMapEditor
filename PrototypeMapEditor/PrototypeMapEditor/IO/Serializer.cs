using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PrototypeMapEditor.IO
{
    public class Serializer<T> where T : class
    {
        public void SerializeObject(string filename, T objectToSerialize)
        {
            var stream = File.Open(filename, FileMode.Create);
            var bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, objectToSerialize);
            stream.Close();
        }

        public T DeSerializeObject(string filename)
        {
            var stream = File.Open(filename, FileMode.Open);
            var bFormatter = new BinaryFormatter();
            var objectToSerialize = (T)bFormatter.Deserialize(stream);
            stream.Close();
            return objectToSerialize;
        }
    }
}