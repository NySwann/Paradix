using Microsoft.Xna.Framework;

namespace Paradix
{
	public sealed class Renderer : Component, IDrawable
	{
		// TODO : Add IsVisible property

		public Sprite Sprite { get; set; } = null;
		public Color ColorMask { get; set; } = Color.White;
		public float PixelsPerUnit { get; set; } = 1f;
		public float LayerDepth { get; set; } = 0f;

		public Renderer () : base ("Renderer")
		{
		}

		public void Draw (GameTime gameTime, GraphicsManager graphics)
		{
			Contract.RequiresNotNull (Sprite, "The Sprite must not be null");
			Contract.Requires (IsAttached, "This Renderer component must be attached to an Entity");
			Contract.Requires (AttachedEntity.HasComponent<Transform> (), "The Transform component is required for the Renderer component");

			var transform = AttachedEntity.GetComponent<Transform> ();

			graphics.Batch.Draw (Sprite.Texture, transform.AbsolutePosition, Sprite.SourceRectangle, Color.Lerp (ColorMask, Sprite.Color, 0.5f),
							   transform.AbsoluteRotation, Sprite.Origin, transform.AbsoluteScale * PixelsPerUnit * Sprite.PixelsPerUnit, Sprite.Effects, LayerDepth);
		}
	}
}