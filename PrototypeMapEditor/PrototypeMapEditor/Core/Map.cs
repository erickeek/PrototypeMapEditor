using System;
using System.Collections.Generic;

namespace PrototypeMapEditor.Core
{
    [Serializable]
    public class Map
    {
        public string Name { get; set; }
        public string FileName { get; set; }
        public List<Layer> Layers { get; private set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Map()
        {
            Layers = new List<Layer>();
        }

        public void AddLayer(Layer layer)
        {
            Layers.Add(layer);
        }
    }
}