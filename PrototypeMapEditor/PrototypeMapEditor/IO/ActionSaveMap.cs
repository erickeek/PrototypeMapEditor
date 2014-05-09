using System.IO;
using Newtonsoft.Json;
using PrototypeMapEditor.Core;

namespace PrototypeMapEditor.IO
{
    class ActionSaveMap
    {
        private readonly Map _map;
        private readonly string _path;

        public ActionSaveMap(Map map, string path)
        {
            _map = map;
            _path = path;
        }

        public void Executar()
        {
            var jsonText = JsonConvert.SerializeObject(_map);
            File.WriteAllText(_path, jsonText);
        }
    }
}
