using System.IO;
using Newtonsoft.Json;

namespace Prototype.Core.IO
{
    public class ActionSaveMetadataMap
    {
        private readonly MetadataMap _metadataMap;
        private readonly string _path;

        public ActionSaveMetadataMap(MetadataMap metadataMap, string path)
        {
            _metadataMap = metadataMap;
            _path = path;
        }

        public void Executar()
        {
            var jsonText = JsonConvert.SerializeObject(_metadataMap);
            // verificar se é do tipo bmm
            File.WriteAllText(_path, jsonText);
        }
    }
}