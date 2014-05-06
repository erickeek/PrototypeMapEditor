using System;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using PrototypeMapEditor.IO;

namespace PrototypeMapEditor.Core
{
    [Serializable]
    public class ObjetoDoMapa
    {
        public string Nome { get; set; }

        [JsonConverter(typeof(RectangleConverter))]
        public Rectangle Fonte;

        [JsonIgnore]
        public bool Selecionado { get; set; }
    }
}