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

        public MetadadoMapa MetadadoMapa { get; set; }

        protected override void Initialize()
        {
            _content = new ContentManager(Services, "Content");
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _nullTexture = _content.Load<Texture2D>("1x1");
        }

        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if (Texture == null)
                return;

            _spriteBatch.Begin();

            var viewportMiddle = GraphicsDevice.Viewport.Width / 2f;

            var maxWidth = MetadadoMapa.ObjetoDoMapas.Max(c => c.Fonte.Width);
            var scale = GraphicsDevice.Viewport.Width / (float)maxWidth;

            float positionY = 0;

            foreach (var objeto in MetadadoMapa.ObjetoDoMapas)
            {
                var origin = new Vector2(objeto.Fonte.Width, objeto.Fonte.Height) / 2;
                var position = new Vector2(viewportMiddle, positionY + objeto.Fonte.Height / 2f * scale);

                _spriteBatch.Draw(Texture, position, objeto.Fonte, Color.White, 0f, origin, scale, SpriteEffects.None, 1f);
                _spriteBatch.Draw(_nullTexture, position, objeto.Fonte, new Color(255, 0, 0, 30), 0f, origin, scale, SpriteEffects.None, 1f);

                positionY += objeto.Fonte.Y;
            }

            _spriteBatch.End();
        }

        public void LoadContent(string fileName)
        {
            Texture = _content.Load<Texture2D>(fileName);
        }
    }
}