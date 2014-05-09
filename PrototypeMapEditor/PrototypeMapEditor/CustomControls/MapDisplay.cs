using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PrototypeMapEditor.Core;
using PrototypeMapEditor.Core.Enum;
using PrototypeMapEditor.Helper;
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
        public ObjectMap StampObjectMap { get; set; }
        public Layer ActualLayer { get; set; }

        public DrawingMode DrawingMode { get; set; }

        public float Zoom { get; set; }

        private const int SquareSize = 32;
        private static readonly Color RedColor = new Color(255, 0, 0, 100);
        private static readonly Color TransparentColorStamp = new Color(255, 255, 255, 25);

        protected override void Initialize()
        {
            _content = new ContentManager(Services, "Content");
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _nullTexture = _content.Load<Texture2D>("1x1");

            Map = new Map();
            Zoom = 1;
        }

        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.Black);

            if (Texture == null)
                return;

            _spriteBatch.Begin();

            var zoom = Zoom;

            foreach (var layer in Map.Layers.OrderBy(l => l.Index))
            {
                var scale = layer.Scale * zoom;
                foreach (var objectMap in layer.ObjectsInMap.OrderBy(o => o.DrawOrder))
                {
                    var origin = new Vector2(objectMap.Source.Width, objectMap.Source.Height) / 2f;
                    _spriteBatch.Draw(Texture, (objectMap.Position + Position) * scale, objectMap.Source, layer.Color, 0f, origin, scale, SpriteEffects.None, 1f);

                    //_spriteBatch.Draw(_nullTexture, objectMap.Scaling(scale), RedColor);
                }
            }

            if (StampObjectMap != null && DrawingMode == DrawingMode.SegmentSelection)
            {
                var scale = ActualLayer.Scale * zoom;
                var origin = new Vector2(StampObjectMap.Source.Width, StampObjectMap.Source.Height) / 2f;
                _spriteBatch.Draw(Texture, (StampObjectMap.Position + Position) * scale, StampObjectMap.Source, TransparentColorStamp, 0f, origin, scale, SpriteEffects.None, 1f);
            }

            if (DrawingMode == DrawingMode.CollisionMap)
            {
                var squareSize = SquareSize * zoom;

                Map.Grid = Map.Grid ?? new GridState[(int)(GraphicsDevice.Viewport.Width / squareSize), (int)(GraphicsDevice.Viewport.Height / squareSize)];

                for (var x = 0; x < Map.Grid.GetLength(0); x++)
                {
                    for (var y = 0; y < Map.Grid.GetLength(1); y++)
                    {
                        var source = new Rectangle((int)(Position.X + x * squareSize), (int)(Position.Y + y * squareSize), (int)squareSize, (int)squareSize);

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
            Texture = _content.Load<Texture2D>(fileName);
            Map.FileName = fileName;
        }

        public void SetGridState(int x, int y)
        {
            x /= (int)(SquareSize * Zoom);
            y /= (int)(SquareSize * Zoom);

            if (x >= Map.Grid.GetLength(0) || y >= Map.Grid.GetLength(1))
                return;

            Map.Grid[x, y] = Map.Grid[x, y] == GridState.None ? GridState.Solid : GridState.None;
        }
    }
}