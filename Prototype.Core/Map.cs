using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;

namespace Prototype.Core
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

        [JsonIgnore]
        public Texture2D Texture { get; set; }
        [JsonIgnore]
        public Vector2 Camera;
        [JsonIgnore]
        public float Zoom { get; set; }

        public Map()
        {
            Layers = new List<Layer>();
            Ledges = new List<Ledge>();
            Zoom = 1;
        }

        public void AddLayer(Layer layer)
        {
            Layers.Add(layer);
        }

        public void AddLedges(Ledge ledge)
        {
            Ledges.Add(ledge);
        }

        public void LoadContent(ContentManager content)
        {
            Texture = content.Load<Texture2D>(FileName);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var layer in Layers.OrderBy(l => l.Index))
            {
                var scale = layer.Scale * Zoom;
                foreach (var objectMap in layer.ObjectsInMap.OrderBy(o => o.DrawOrder))
                {
                    var origin = new Vector2(objectMap.Source.Width, objectMap.Source.Height) / 2f;
                    spriteBatch.Draw(Texture, (objectMap.Position + Camera) * scale, objectMap.Source, layer.Color, 0f, origin, scale, SpriteEffects.None, 1f);
                }
            }
            spriteBatch.End();
        }
    }

    public enum GridState
    {
        None = 0,
        Solid
    }
}