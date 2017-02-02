using System;
using Microsoft.Xna.Framework;

namespace Paradix
{
    public struct CircleF : IShapeF, IEquatable<CircleF>
    {
		public float X { get; set; }
		public float Y { get; set; }
        public float Radius { get; set; }

        public float Left => X - Radius;
        public float Right => X + Radius;
        public float Top => Y - Radius;
        public float Bottom => Y + Radius;

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

		public float Diameter 
		{
			get 
			{
				return Radius * 2f;
			}

			set 
			{
				Radius = value * 2f;
			}
		}

        public float Circumference => 2.0f * MathHelper.Pi * Radius;

		public RectangleF BoundingRectangle 
		{
			get 
			{
				var minX = Left;
				var minY = Top;
				var maxX = Right;
				var maxY = Bottom;
				return new RectangleF (minX, minY, maxX - minX, maxY - minY);
			}
		}

		public CircleF (float x, float y, float radius)
		{
			X = x;
			Y = y;
			Radius = radius;
		}

		public CircleF (Vector2 position, float radius)
			: this(position.X, position.Y, radius)
		{
		}

        public Vector2 GetPointAlongEdge(float angle)
        {
            return new Vector2(X + Radius * (float) Math.Cos(angle),
                Y + Radius * (float) Math.Sin(angle));
        }

        public bool Contains(float x, float y)
        {
            return (new Vector2(x, y) - Center).LengthSquared() <= Radius*Radius;
        }

        public bool Contains(Point value)
        {
            return (value.ToVector2() - Center).LengthSquared() <= Radius*Radius;
        }

        public bool Contains(Vector2 value)
        {
            return (value - Center).LengthSquared() <= Radius*Radius;
        }

        public bool Contains(CircleF value)
        {
            var distanceOfCenter = value.Center - Center;
            var radii = Radius - value.Radius;

            return distanceOfCenter.X*distanceOfCenter.X + distanceOfCenter.Y*distanceOfCenter.Y <=
                   Math.Abs(radii*radii);
        }

		public void Inflate (float radiusAmount)
		{
			Center -= new Vector2 (radiusAmount);
			Radius += radiusAmount * 2;
		}

		public bool Intersects (CircleF value)
		{
			var distanceOfCenter = value.Center - Center;
			var radii = Radius + value.Radius;

			return distanceOfCenter.X * distanceOfCenter.X + distanceOfCenter.Y * distanceOfCenter.Y < radii * radii;
		}

		public bool Intersects (Rectangle value)
		{
			var distance = new Vector2 (Math.Abs (X - value.Center.X), Math.Abs (Y - value.Center.Y));

			if (distance.X > value.Width / 2.0f + Radius)
				return false;

			if (distance.Y > value.Height / 2.0f + Radius)
				return false;

			if (distance.X <= value.Width / 2.0f)
				return true;

			if (distance.Y <= value.Height / 2.0f)
				return true;

			var distanceOfCorners =
				(distance.X - value.Width / 2.0f) *
				(distance.X - value.Width / 2.0f) +
				(distance.Y - value.Height / 2.0f) *
				(distance.Y - value.Height / 2.0f);

			return distanceOfCorners <= Radius * Radius;
		}

		public static bool operator == (CircleF a, CircleF b)
		{
			return (Math.Abs (a.X - b.X) < float.Epsilon)
				&& (Math.Abs (a.Y - b.Y) < float.Epsilon)
				&& (Math.Abs (a.Radius - b.Radius) < float.Epsilon);
		}

		public static bool operator != (CircleF a, CircleF b)
		{
			return !(a == b);
		}

        public override bool Equals(object obj)
        {
            return obj is CircleF && (this == (CircleF) obj);
        }

        public bool Equals(CircleF other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
			return Position.GetHashCode() ^ Radius.GetHashCode();
        }

        public override string ToString()
        {
            return "{Center:" + Center + " Radius:" + Radius + "}";
        }

        public Rectangle ToRectangle()
        {
            return new Rectangle((int)(X - Radius), (int)(Y - Radius), (int)Radius * 2, (int)Radius * 2);
        }
    }
}