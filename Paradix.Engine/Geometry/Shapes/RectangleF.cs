using System;
using Microsoft.Xna.Framework;

namespace Paradix
{
    public struct RectangleF : IShape, IEquatable<RectangleF>
    {
		public float X { get; set; }
		public float Y { get; set; }
		public float Width { get; set; }
		public float Height { get; set; }

        public float Left => X;
        public float Right => X + Width;
        public float Top => Y;
		public float Bottom => Y + Height;

		public Vector2 Position => new Vector2 (X, Y);
		public Vector2 Size => new Vector2 (Width, Height);
        public Vector2 Center => new Vector2 (X + Width / 2f, Y + Height / 2f);

		public RectangleF BoundingRectangle => this;

        public RectangleF(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

		public RectangleF (Vector2 position, Vector2 size)
		{
			X = position.X;
			Y = position.Y;
			Width = size.X;
			Height = size.Y;
		}

		public RectangleF(Rectangle rectangle)
        {
            X = rectangle.X;
            Y = rectangle.Y;
            Width = rectangle.Width;
            Height = rectangle.Height;
        }

        public bool Contains(int x, int y)
        {
            return (X <= x) && (x < X + Width) && (Y <= y) && (y < Y + Height);
        }

        public bool Contains(float x, float y)
        {
            return (X <= x) && (x < X + Width) && (Y <= y) && (y < Y + Height);
        }

        public bool Contains(Point value)
        {
            return (X <= value.X) && (value.X < X + Width) && (Y <= value.Y) && (value.Y < Y + Height);
        }

        public bool Contains(Vector2 value)
        {
            return (X <= value.X) && (value.X < X + Width) && (Y <= value.Y) && (value.Y < Y + Height);
        }

        public bool Contains(RectangleF value)
        {
            return (X <= value.X) && (value.X + value.Width <= X + Width) && (Y <= value.Y) &&
                   (value.Y + value.Height <= Y + Height);
        }

		public static implicit operator RectangleF (Rectangle rectangle)
		{
			return new RectangleF (rectangle);
		}

		public static implicit operator RectangleF? (Rectangle? rect)
		{
			if (!rect.HasValue)
				return null;

			return new RectangleF (rect.Value);
		}

		public static implicit operator Rectangle (RectangleF rect)
		{
			return new Rectangle ((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height);
		}

		public static bool operator == (RectangleF a, RectangleF b)
		{
			return (Math.Abs (a.X - b.X) < float.Epsilon)
				&& (Math.Abs (a.Y - b.Y) < float.Epsilon)
				&& (Math.Abs (a.Width - b.Width) < float.Epsilon)
				&& (Math.Abs (a.Height - b.Height) < float.Epsilon);
		}

		public static bool operator != (RectangleF a, RectangleF b)
		{
			return !(a == b);
		}

        public override bool Equals(object obj)
        {
            return obj is RectangleF && (this == (RectangleF) obj);
        }

        public bool Equals(RectangleF other)
        {
            return this == other;
        }

        public void Inflate(int horizontalAmount, int verticalAmount)
        {
            X -= horizontalAmount;
            Y -= verticalAmount;
            Width += horizontalAmount * 2;
            Height += verticalAmount * 2;
        }

        public void Inflate(float horizontalAmount, float verticalAmount)
        {
            X -= horizontalAmount;
            Y -= verticalAmount;
			Width += horizontalAmount * 2f;
			Height += verticalAmount * 2f;
        }

		public void Inflate (Vector2 amount)
		{
			Inflate (amount.X, amount.Y);
		}

        public bool Intersects(RectangleF value)
        {
            return (value.Left < Right) && (Left < value.Right) &&
                   (value.Top < Bottom) && (Top < value.Bottom);
        }

		public static RectangleF Union (RectangleF value1, RectangleF value2)
		{
			var x = Math.Min (value1.X, value2.X);
			var y = Math.Min (value1.Y, value2.Y);
			return new RectangleF (x, y,
				Math.Max (value1.Right, value2.Right) - x,
				Math.Max (value1.Bottom, value2.Bottom) - y);
		}


		public Vector2 IntersectionDepth (RectangleF other)
		{
			// Calculate half sizes.
			var thisHalfWidth = Width / 2.0f;
			var thisHalfHeight = Height / 2.0f;
			var otherHalfWidth = other.Width / 2.0f;
			var otherHalfHeight = other.Height / 2.0f;

			// Calculate centers.
			var centerA = new Vector2 (Left + thisHalfWidth, Top + thisHalfHeight);
			var centerB = new Vector2 (other.Left + otherHalfWidth, other.Top + otherHalfHeight);

			// Calculate current and minimum-non-intersecting distances between centers.
			var distanceX = centerA.X - centerB.X;
			var distanceY = centerA.Y - centerB.Y;
			var minDistanceX = thisHalfWidth + otherHalfWidth;
			var minDistanceY = thisHalfHeight + otherHalfHeight;

			// If we are not intersecting at all, return (0, 0).
			if ((Math.Abs (distanceX) >= minDistanceX) || (Math.Abs (distanceY) >= minDistanceY))
				return Vector2.Zero;

			// Calculate and return intersection depths.
			var depthX = distanceX > 0 ? minDistanceX - distanceX : -minDistanceX - distanceX;
			var depthY = distanceY > 0 ? minDistanceY - distanceY : -minDistanceY - distanceY;
			return new Vector2 (depthX, depthY);
		}

        public override string ToString()
        {
            return "{X:" + X + " Y:" + Y + " Width:" + Width + " Height:" + Height + "}";
        }

		public override int GetHashCode ()
		{
			return X.GetHashCode () ^ Y.GetHashCode () ^ Width.GetHashCode () ^ Height.GetHashCode ();
		}
    }
}