﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace PrototypeMapEditor.Core
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

        public void AddObjectMap(ObjectMap objeto)
        {
            objeto.Position += new Vector2(objeto.Source.Width, objeto.Source.Height) / 2f;
            ObjectsInMap.Add(objeto);
        }
    }
}