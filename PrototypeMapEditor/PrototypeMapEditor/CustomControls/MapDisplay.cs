﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Prototype.Core;
using Prototype.Core.Enum;
using Prototype.Core.Helper;
using WinFormsGraphicsDevice;

namespace PrototypeMapEditor.CustomControls
{
    public class MapDisplay : GraphicsDeviceControl
    {
        private ContentManager _content;
        private SpriteBatch _spriteBatch;
        private Texture2D _nullTexture;

        public Map Map { get; set; }
        public MetadataMap MetadataMap { get; set; }

        public ObjectMap ActualObjectMap { get; set; }
        public ObjectMap StampObjectMap { get; set; }
        public Layer ActualLayer { get; set; }

        public DrawingMode DrawingMode { get; set; }

        private const int SquareSize = 64;
        private static readonly Color RedColor = new Color(255, 0, 0, 1);
        private static readonly Color TransparentColorStamp = new Color(255, 255, 255, 25);

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

            if (Map.Texture == null)
                return;

            Map.Draw(_spriteBatch);

            _spriteBatch.Begin();
            var zoom = Map.Zoom;

            /*foreach (var layer in Map.Layers.OrderBy(l => l.Index))
            {
                var scale = layer.Scale * zoom;
                foreach (var objectMap in layer.ObjectsInMap.OrderBy(o => o.DrawOrder))
                {
                    var scalingSource = objectMap.ScalingPosition(scale);
                    _spriteBatch.Draw(_nullTexture, scalingSource, RedColor);
                }
            }*/

            if (StampObjectMap != null && DrawingMode == DrawingMode.SegmentSelection)
            {
                var scale = ActualLayer.Scale * zoom;
                var origin = new Vector2(StampObjectMap.Source.Width, StampObjectMap.Source.Height) / 2f;
                _spriteBatch.Draw(Map.Texture, (StampObjectMap.Position + Map.Camera) * scale, StampObjectMap.Source, TransparentColorStamp, 0f, origin, scale, SpriteEffects.None, 1f);
            }

            if (DrawingMode == DrawingMode.CollisionMap)
            {
                var squareSize = SquareSize * zoom;

                Map.Grid = Map.Grid ?? new GridState[(int)(GraphicsDevice.Viewport.Width / squareSize), (int)(GraphicsDevice.Viewport.Height / squareSize)];

                for (var x = 0; x < Map.Grid.GetLength(0); x++)
                {
                    for (var y = 0; y < Map.Grid.GetLength(1); y++)
                    {
                        var source = new Rectangle((int)(Map.Camera.X + x * squareSize), (int)(Map.Camera.Y + y * squareSize), (int)squareSize, (int)squareSize);

                        if (Map.Grid[x, y] == GridState.Solid)
                            _spriteBatch.Draw(_nullTexture, source, RedColor);
                        else
                            _spriteBatch.DrawRectangle(_nullTexture, source, RedColor);
                    }
                }
            }

            _spriteBatch.End();
        }

        public void LoadContent(string fileName)
        {
            Map.Texture = _content.Load<Texture2D>(fileName);
            Map.FileName = fileName;
        }

        public void SetGridState(int x, int y)
        {
            var squareSize = (int)(SquareSize * Map.Zoom);

            x /= squareSize;
            y /= squareSize;

            if (x >= Map.Grid.GetLength(0) || y >= Map.Grid.GetLength(1))
                return;

            Map.Grid[x, y] = Map.Grid[x, y] == GridState.None ? GridState.Solid : GridState.None;
        }
    }
}