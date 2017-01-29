using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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

		public void Draw (SpriteBatch spriteDrawer, GameTime gameTime)
		{
			Contract.RequiresNotNull (Sprite, "The Sprite must not be null");
			Contract.Requires (IsAttached, "This Renderer component must be attached to an Entity");
			Contract.Requires (AttachedGameObject.HasComponent<Transform> (), "The Transform component is required for the Renderer component");

			var transform = AttachedGameObject.GetComponent<Transform> ();

			spriteDrawer.Draw (Sprite.Texture, transform.AbsolutePosition, Sprite.SourceRectangle, Color.Lerp (ColorMask, Sprite.Color, 0.5f),
							   transform.AbsoluteRotation, Sprite.Origin, transform.AbsoluteScale * PixelsPerUnit * Sprite.PixelsPerUnit, Sprite.Effects, LayerDepth);
		}
	}
}