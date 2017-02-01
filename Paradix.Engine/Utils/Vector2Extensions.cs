using System;
using Microsoft.Xna.Framework;

namespace Paradix
{
	public static class Vector2Extensions
	{
		public static Vector2 Rotate (this Vector2 point, float angle)
		{
			return point.RotateAround (angle, Vector2.Zero);
		}

		public static Vector2 RotateAround(this Vector2 point, float angle, Vector2 origin)
		{
			var s = (float)Math.Sin (angle);
			var c = (float)Math.Cos (angle);

			point -= origin;
			point = new Vector2 (point.X * c - point.Y * s, point.X * s + point.Y * c);
			point += origin;

			return (point);
		}

		public static bool IsNaN (this Vector2 value)
		{
			return float.IsNaN (value.X) || float.IsNaN (value.Y);
		}

		public static float ToAngle (this Vector2 value)
		{
			return (float)Math.Atan2 (value.X, -value.Y);
		}

		public static bool EqualsWithTolerance (this Vector2 value, Vector2 otherValue, float tolerance = 0.00001f)
		{
			return (Math.Abs (value.X - otherValue.X) <= tolerance) && (Math.Abs (value.Y - otherValue.Y) <= tolerance);
		}

		public static Vector2 Transform(this Vector2 point, Matrix matrix)
		{
			return Vector2.Transform (point, matrix);
		}

		public static Vector2 Transform (this Vector2 point, Quaternion quaternion)
		{
			return Vector2.Transform (point, quaternion);
		}

		public static Vector2 TransformNormal(this Vector2 point, Matrix matrix)
		{
			return Vector2.TransformNormal(point, matrix);
		}
	}
}
