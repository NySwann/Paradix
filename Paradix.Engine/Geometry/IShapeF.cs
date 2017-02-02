using Microsoft.Xna.Framework;

namespace Paradix
{
	public interface IShapeF
	{
		RectangleF BoundingRectangle { get; }
		bool Contains (Vector2 point);
		// bool Intersects (Shape other);
		// bool Overlap (Shape other);
	}
}