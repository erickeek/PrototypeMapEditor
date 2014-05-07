using System.Drawing;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace PrototypeMapEditor.Helper
{
    public static class Texture2DHelper
    {
        public static Image ToImage(this Texture2D texture)
        {
            Image img;
            using (var ms = new MemoryStream())
            {
                texture.SaveAsPng(ms, texture.Width, texture.Height);
                ms.Seek(0, SeekOrigin.Begin);
                img = Image.FromStream(ms);
            }
            return img;
        }
    }
}