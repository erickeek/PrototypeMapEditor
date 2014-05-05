using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PrototypeMapEditor.Helper
{
    public static class RectangleHelper
    {
        public static void DrawRectangle(this SpriteBatch spriteBatch, Texture2D texture, Rectangle rectangle, Color color, int lineWidth)
        {
            spriteBatch.Draw(texture, new Rectangle(rectangle.X, rectangle.Y, lineWidth, rectangle.Height + lineWidth), color);
            spriteBatch.Draw(texture, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width + lineWidth, lineWidth), color);
            spriteBatch.Draw(texture, new Rectangle(rectangle.X + rectangle.Width, rectangle.Y, lineWidth, rectangle.Height + lineWidth), color);
            spriteBatch.Draw(texture, new Rectangle(rectangle.X, rectangle.Y + rectangle.Height, rectangle.Width + lineWidth, lineWidth), color);
        }

        public static void DrawRectangle(this SpriteBatch spriteBatch, Texture2D texture, IEnumerable<Rectangle> rectangles, Color color, int lineWidth)
        {
            foreach (var rectangle in rectangles)
            {
                spriteBatch.Draw(texture, new Rectangle(rectangle.X, rectangle.Y, lineWidth, rectangle.Height + lineWidth), color);
                spriteBatch.Draw(texture, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width + lineWidth, lineWidth), color);
                spriteBatch.Draw(texture, new Rectangle(rectangle.X + rectangle.Width, rectangle.Y, lineWidth, rectangle.Height + lineWidth), color);
                spriteBatch.Draw(texture, new Rectangle(rectangle.X, rectangle.Y + rectangle.Height, rectangle.Width + lineWidth, lineWidth), color);
            }
        }

        public static Rectangle Add(this Rectangle fonte, Vector2 position)
        {
            return new Rectangle(
                (int)(fonte.X + position.X),
                (int)(fonte.Y + position.Y),
                fonte.Width,
                fonte.Height);
        }
    }
}
