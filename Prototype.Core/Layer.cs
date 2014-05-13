using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Prototype.Core
{
    [Serializable]
    public class Layer
    {
        public string Name { get; set; }
        public int Index { get; set; }
        public Color Color { get; set; }
        public float Scale { get; set; }
        public List<ObjectMap> ObjectsInMap { get; private set; }

        public Layer()
        {
            ObjectsInMap = new List<ObjectMap>();
        }

        public void AddObjectMap(ObjectMap objectMap, Vector2 position)
        {
            objectMap.Position = new Vector2(objectMap.Source.Width, objectMap.Source.Height) / 2 - position;

            objectMap.DrawOrder = (ObjectsInMap.Max(c => (int?)c.DrawOrder) ?? 0) + 1;
            ObjectsInMap.Add(objectMap);
        }
    }
}