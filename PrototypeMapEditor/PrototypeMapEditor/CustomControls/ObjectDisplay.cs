using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using WinFormsGraphicsDevice;

namespace PrototypeMapEditor.CustomControls
{
    public class ObjectDisplay : GraphicsDeviceControl
    {
        private ContentManager _contentManager;
        private SpriteBatch _spriteBatch;

        protected override void Initialize()
        {
            _contentManager = new ContentManager(Services, "Content");
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
        }
    }
}