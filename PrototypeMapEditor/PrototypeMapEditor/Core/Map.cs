using System;
using System.Collections.Generic;

namespace PrototypeMapEditor.Core
{
    [Serializable]
    public class Map
    {
        public string Name { get; set; }
        public string FileName { get; set; }
        public string MetadataFileName { get; set; }
        public List<Layer> Layers { get; private set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public GridState[,] Grid { get; set; }
        public List<Ledge> Ledges { get; private set; }

        public Map()
        {
            Layers = new List<Layer>();
            Ledges = new List<Ledge>();
        }

        public void AddLayer(Layer layer)
        {
            Layers.Add(layer);
        }

        public void AddLedges(Ledge ledge)
        {
            Ledges.Add(ledge);
        }
    }

    public enum GridState
    {
        None = 0,
        Solid
    }
}