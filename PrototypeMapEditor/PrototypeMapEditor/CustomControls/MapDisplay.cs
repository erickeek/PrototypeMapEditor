﻿using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PrototypeMapEditor.Core;
using WinFormsGraphicsDevice;

namespace PrototypeMapEditor.CustomControls
{
    public class MapDisplay : GraphicsDeviceControl
    {
        private ContentManager _content;
        private SpriteBatch _spriteBatch;
        private Texture2D _nullTexture;

        public Texture2D Texture { get; set; }
        public Vector2 Position;

        public Map Map { get; set; }
        public MetadataMap MetadataMap { get; set; }

        public ObjectMap ActualObjectMap { get; set; }

        protected override void Initialize()
        {
            _content = new ContentManager(Services, "Content");
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _nullTexture = _content.Load<Texture2D>("1x1");

            Map = new Map();
        }

        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.Black);

            if (Texture == null)
                return;

            _spriteBatch.Begin();

            foreach (var layer in Map.Layers.OrderBy(l => l.Index))
            {
                var scale = layer.Scale;
                foreach (var objectMap in layer.ObjectsInMap.OrderBy(o => o.DrawOrder))
                {
                    var origin = new Vector2(objectMap.Source.Width, objectMap.Source.Height) / 2f;
                    _spriteBatch.Draw(Texture, objectMap.Position + Position, objectMap.Source, layer.Color, 0f, origin, scale, SpriteEffects.None, 1f);

                    //_spriteBatch.Draw(_nullTexture, objectMap.Scaling(scale), new Color(255, 0, 0, 5));
                }
            }

            _spriteBatch.End();
        }

        public void LoadContent(string fileName)
        {
            Texture = _content.Load<Texture2D>(fileName);
        }
    }
}