using System;
using Microsoft.Xna.Framework;

namespace Paradix
{
	public static class Vector2Extensions
	{
		public static Vector2 Rotate(this Vector2 point, float angle)
		{
			var s = (float)Math.Sin (angle);
			var c = (float)Math.Cos (angle);

			point = new Vector2 (point.X * c - point.Y * s, point.X * s + point.Y * c);

			return (point);
		}
	}
}
