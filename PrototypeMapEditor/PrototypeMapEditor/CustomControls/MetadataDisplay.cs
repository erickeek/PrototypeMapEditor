using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PrototypeMapEditor.Core;
using PrototypeMapEditor.Helper;
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

        public List<ObjetoDoMapa> ObjetosDoMapa { get; set; }
        public ObjetoDoMapa ObjetosDoMapaAtual { get; set; }

        public Vector2 Position;

        protected override void Initialize()
        {
            _content = new ContentManager(Services, "Content");
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _nullTexture = _content.Load<Texture2D>("1x1");

            Position = Vector2.Zero;
            ObjetosDoMapa = new List<ObjetoDoMapa>();
        }

        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if (_texture == null)
                return;

            _spriteBatch.Begin();
            _spriteBatch.Draw(_texture, Position, Color.White);

            if (ObjetosDoMapa.Count > 0)
            {
                foreach (var objetoDoMapa in ObjetosDoMapa)
                {
                    _spriteBatch.DrawRectangle(_nullTexture, objetoDoMapa.Fonte.Add(Position), objetoDoMapa.Selecionado ? Color.Yellow : Color.Black, 1);
                }
            }

            if (ObjetosDoMapaAtual != null)
            {
                _spriteBatch.DrawRectangle(_nullTexture, ObjetosDoMapaAtual.Fonte.Add(Position), Color.Red, 1);
            }

            _spriteBatch.End();
        }

        public void LoadContent(string fileName)
        {
            _texture = _content.Load<Texture2D>(fileName);
        }
    }
}