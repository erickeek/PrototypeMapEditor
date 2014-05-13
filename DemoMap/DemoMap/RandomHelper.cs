using System;
using Microsoft.Xna.Framework;

namespace DemoMap
{
    public static class RandomHelper
    {
        public static Random Random { get; private set; }

        static RandomHelper()
        {
            Random = new Random();
        }

        public static float GetFloat(float min, float max)
        {
            return (float)Random.NextDouble() * (max - min) + min;
        }

        public static double GetDouble(double min, double max)
        {
            return Random.NextDouble() * (max - min) + min;
        }

        public static Vector2 GetVector2(float xMin, float xMax, float yMin, float yMax)
        {
            return new Vector2(GetFloat(xMin, xMax), GetFloat(yMin, yMax));
        }

        public static int GetInt(int min, int max)
        {
            return Random.Next(min, max);
        }
    }
}
