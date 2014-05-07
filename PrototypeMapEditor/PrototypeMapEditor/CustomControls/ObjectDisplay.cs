using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PrototypeMapEditor.Core;
using WinFormsGraphicsDevice;

namespace PrototypeMapEditor.CustomControls
{
    public class ObjectDisplay : GraphicsDeviceControl
    {
        private const int MarginBetweenObjects = 5;

        private ContentManager _content;
        private SpriteBatch _spriteBatch;
        private Texture2D _nullTexture;

        public Texture2D Texture { get; set; }
        public Vector2 Position;
        private float _viewportMiddle;
        private float _viewportWidth;

        public MetadataMap MetadataMap { get; set; }

        protected override void Initialize()
        {
            _content = new ContentManager(Services, "Content");
            _spriteBatch = new SpriteBatch(GraphicsDevice);


            _nullTexture = _content.Load<Texture2D>("1x1");

            _viewportWidth = GraphicsDevice.Viewport.Width;
            _viewportMiddle = _viewportWidth / 2f;
        }

        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.Black);

            if (Texture == null)
                return;

            _spriteBatch.Begin();

            DrawAvaliableObjects();

            _spriteBatch.End();
        }

        private void DrawAvaliableObjects()
        {
            var scale = Scale();
            var positionY = Position.Y;

            foreach (var objeto in MetadataMap.ObjectsInMap)
            {
                var origin = new Vector2(objeto.Source.Width / 2f, 0);
                var position = new Vector2(_viewportMiddle, positionY);

                //_spriteBatch.Draw(_nullTexture, position, objeto.Source, Color.White, 0f, origin, scale, SpriteEffects.None, 1f);
                _spriteBatch.Draw(Texture, position, objeto.Source, Color.White, 0f, origin, scale, SpriteEffects.None, 1f);

                positionY = position.Y + objeto.Source.Height * scale + MarginBetweenObjects;
            }
        }

        public void LoadContent(string fileName)
        {
            Texture = _content.Load<Texture2D>(fileName);
        }

        public ObjectMap SelectObject(int x, int y)
        {
            if (MetadataMap == null)
                return null;

            var maxWidth = MaxWidth();
            var scale = Scale();

            var positionY = Position.Y;

            foreach (var objeto in MetadataMap.ObjectsInMap)
            {
                var position = new Vector2(0, positionY);

                var sourceRectangle = new Rectangle(0, (int)positionY, (int)(maxWidth * scale), (int)(objeto.Source.Height * scale));
                //_spriteBatch.Draw(_nullTexture, position, sourceRectangle, new Color(255, 0, 0, 20));

                if (sourceRectangle.Contains(x, y))
                {
                    return objeto;
                }

                positionY = position.Y + objeto.Source.Height * scale + MarginBetweenObjects;
            }
            return null;
        }

        public float TotalHeight
        {
            get
            {
                var scale = Scale();
                return MetadataMap.ObjectsInMap.Sum(c => c.Source.Height * scale + MarginBetweenObjects);
            }
        }

        private float Scale()
        {
            var maxWidth = MaxWidth();
            var scale = _viewportWidth / maxWidth;
            return scale;
        }

        private int MaxWidth()
        {
            var maxWidth = MetadataMap.ObjectsInMap.Max(c => c.Source.Width);
            return maxWidth;
        }
    }
}