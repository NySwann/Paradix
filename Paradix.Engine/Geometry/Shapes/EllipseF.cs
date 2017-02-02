using System;
using Microsoft.Xna.Framework;

namespace Paradix
{
    public class EllipseF : IShapeF
    {
		public float X { get; set; }
		public float Y { get; set; }
		public float HorizontalRadius { get; set; }
		public float VerticalRadius { get; set; }

        public float Left => X - HorizontalRadius;
        public float Top => Y - VerticalRadius;
        public float Right => X + HorizontalRadius;
        public float Bottom => Y + VerticalRadius;

		public Vector2 Position 
		{
			get 
			{
				return new Vector2 (X, Y);
			}

			set 
			{
				X = value.X;
				Y = value.Y;
			}
		}

		public Vector2 Center 
		{
			get 
			{
				return new Vector2 (X, Y);
			}

			set 
			{
				X = value.X;
				Y = value.Y;
			}
		}

        public RectangleF BoundingRectangle
        {
            get
            {
                var minX = Left;
                var minY = Top;
                var maxX = Right;
                var maxY = Bottom;
                return new RectangleF(minX, minY, maxX - minX, maxY - minY);
            }
        }

		public EllipseF (float x, float y, float horizontalRadius, float verticalRadius)
		{
			X = x;
			Y = y;
			HorizontalRadius = horizontalRadius;
			VerticalRadius = verticalRadius;
		}

		public EllipseF (Vector2 position, Vector2 radius)
			: this (position.X, position.Y, radius.X, radius.Y)
		{
		}

        public bool Contains(float x, float y)
        {
            float xCalc = (float) (Math.Pow(x - X, 2) / Math.Pow(HorizontalRadius, 2));
            float yCalc = (float) (Math.Pow(y - Y, 2) / Math.Pow(VerticalRadius, 2));

            return xCalc + yCalc <= 1;
        }

        public bool Contains(Vector2 point)
        {
            return Contains(point.X, point.Y);
        }
    }
}