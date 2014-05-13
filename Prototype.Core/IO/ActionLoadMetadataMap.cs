using System.IO;
using Newtonsoft.Json;

namespace Prototype.Core.IO
{
    public class ActionLoadMetadataMap
    {
        public MetadataMap MetadataMap { get; private set; }
        private readonly string _path;

        public ActionLoadMetadataMap(string path)
        {
            _path = path;
        }

        public void Executar()
        {
            var jsonText = File.ReadAllText(_path);
            MetadataMap = JsonConvert.DeserializeObject<MetadataMap>(jsonText);
        }
    }
}