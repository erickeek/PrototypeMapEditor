﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Prototype.Core.Helper
{
    public static class RectangleHelper
    {
        public static void DrawRectangle(this SpriteBatch spriteBatch, Texture2D texture, Rectangle rectangle, Color color, int lineWidth = 1)
        {
            spriteBatch.Draw(texture, new Rectangle(rectangle.X, rectangle.Y, lineWidth, rectangle.Height + lineWidth), color);
            spriteBatch.Draw(texture, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width + lineWidth, lineWidth), color);
            spriteBatch.Draw(texture, new Rectangle(rectangle.X + rectangle.Width, rectangle.Y, lineWidth, rectangle.Height + lineWidth), color);
            spriteBatch.Draw(texture, new Rectangle(rectangle.X, rectangle.Y + rectangle.Height, rectangle.Width + lineWidth, lineWidth), color);
        }

        public static void DrawRectangle(this SpriteBatch spriteBatch, Texture2D texture, IEnumerable<Rectangle> rectangles, Color color, int lineWidth = 1)
        {
            foreach (var rectangle in rectangles)
            {
                spriteBatch.DrawRectangle(texture, rectangle, color, lineWidth);
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

        public static Rectangle Scaling(this ObjectMap objectMap, float scale)
        {
            var source = new Rectangle
            {
                Width = (int)(objectMap.Source.Width * scale),
                Height = (int)(objectMap.Source.Height * scale)
            };
            source.X = (int)objectMap.Position.X - source.Width / 2;
            source.Y = (int)objectMap.Position.Y - source.Height / 2;
            return source;
        }

        public static Rectangle ScalingPosition(this ObjectMap objectMap, float scale)
        {
            var source = new Rectangle
            {
                Width = (int)(objectMap.Source.Width * scale),
                Height = (int)(objectMap.Source.Height * scale)
            };
            source.X = (int)((objectMap.Position.X - source.Width / 2f) * scale);
            source.Y = (int)((objectMap.Position.Y - source.Height / 2f) * scale);

            return source;
        }
    }
}
