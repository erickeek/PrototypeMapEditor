using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Prototype.Core;
using Prototype.Core.Helper;
using WinFormsGraphicsDevice;

namespace PrototypeMapEditor.CustomControls
{
    public class MetadataDisplay : GraphicsDeviceControl
    {
        private ContentManager _content;
        private SpriteBatch _spriteBatch;
        private Texture2D _texture;
        private Texture2D _nullTexture;

        public Texture2D Texture
        {
            get { return _texture; }
            set { _texture = value; }
        }

        public List<ObjectMap> ObjectsInMap { get; set; }
        public ObjectMap ActualObjectMap { get; set; }

        public Vector2 Position;

        protected override void Initialize()
        {
            _content = new ContentManager(Services, "Content");
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _nullTexture = _content.Load<Texture2D>("1x1");

            Position = Vector2.Zero;
            ObjectsInMap = new List<ObjectMap>();
        }

        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if (_texture == null)
                return;

            _spriteBatch.Begin();

            DrawBackground();
            DrawObjectsInMap();
            DrawActualObjectMap();

            _spriteBatch.End();
        }

        private void DrawBackground()
        {
            _spriteBatch.Draw(_texture, Position, Color.White);
        }

        private void DrawObjectsInMap()
        {
            if (!ObjectsInMap.Any())
                return;

            foreach (var objectMap in ObjectsInMap)
            {
                var color = objectMap.Selected ? Color.Yellow : Color.Black;
                _spriteBatch.DrawRectangle(_nullTexture, objectMap.Source.Add(Position), color, 1);
            }
        }

        private void DrawActualObjectMap()
        {
            if (ActualObjectMap == null)
                return;

            _spriteBatch.DrawRectangle(_nullTexture, ActualObjectMap.Source.Add(Position), Color.Red, 1);
        }

        public void LoadContent(string fileName)
        {
            _texture = _content.Load<Texture2D>(fileName);
        }
    }
}