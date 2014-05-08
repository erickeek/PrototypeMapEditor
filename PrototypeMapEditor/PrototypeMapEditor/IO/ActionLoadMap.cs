﻿using System.IO;
using Newtonsoft.Json;
using PrototypeMapEditor.Core;

namespace PrototypeMapEditor.IO
{
    public class ActionLoadMap
    {
        public Map Map { get; private set; }
        private readonly string _path;

        public ActionLoadMap(string path)
        {
            _path = path;
        }

        public void Executar()
        {
            var jsonText = File.ReadAllText(_path);
            Map = JsonConvert.DeserializeObject<Map>(jsonText);
        }
    }
}
