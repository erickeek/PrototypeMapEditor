﻿using System;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using Prototype.Core.IO;

namespace Prototype.Core
{
    [Serializable]
    public class ObjectMap
    {
        public string Name { get; set; }

        [JsonConverter(typeof(RectangleConverter))]
        public Rectangle Source;

        [JsonIgnore]
        public bool Selected { get; set; }

        public Vector2 Position { get; set; }

        public int DrawOrder { get; set; }
    }
}