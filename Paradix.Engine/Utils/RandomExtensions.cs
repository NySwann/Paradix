using System;
using Microsoft.Xna.Framework;

namespace Paradix
{
    public static class RandomExtensions
    {
        public static float NextSingle(this Random random, float min, float max)
        {
            return (max - min) * NextSingle(random) + min;
        }

        public static float NextSingle(this Random random, float max)
        {
            return max * NextSingle(random);
        }

        public static float NextSingle(this Random random)
        {
            return (float) random.NextDouble();
        }

        public static float NextAngle(this Random random)
        {
            return NextSingle(random, -MathHelper.Pi, MathHelper.Pi);
        }

        public static void NextUnitVector(this Random random, out Vector2 vector)
        {
            var angle = NextAngle(random);
            vector = new Vector2((float) Math.Cos(angle), (float) Math.Sin(angle));
        }
    }
}