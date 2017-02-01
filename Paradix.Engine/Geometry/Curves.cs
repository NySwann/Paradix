using Microsoft.Xna.Framework;

namespace Paradix
{
	public static class Curves
	{
		public struct BezierNode
		{
			public Vector2 Point { get; set; }
			public Vector2 Direction { get; set; }

			public BezierNode(Vector2 point, Vector2 direction)
			{
				Point = point;
				Direction = direction;
			}
		}

		public static Vector2 Bezier(float time, Vector2 start0, Vector2 start1, Vector2 end0, Vector2 end1)
		{
			float u = 1 - time;
			float tt = time * time;
			float uu = u * u;
			float uuu = uu * u;
			float ttt = tt * time;

			var point = uuu * start0;

			point += 3 * uu * time * start1;
			point += 3 * u * tt * end0;
			point += ttt * end1;

			return point;
		}

		public static Vector2 Bezier(float time, BezierNode start, BezierNode end)
		{
			return Bezier(time, start.Point, start.Direction, end.Point, end.Direction);
		}
	}
}