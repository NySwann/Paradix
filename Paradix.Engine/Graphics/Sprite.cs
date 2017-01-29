using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Paradix
{
	public enum OriginMode
	{
		TopLeft,
		TopRight,
		BottomLeft,
		BottomRight,
		TopCenter,
		BottomCenter,
		RightCenter,
		LeftCenter,
		Center
	}

	public class Sprite
	{
		public Texture2D Texture { get; private set; } = null;
		public virtual Rectangle? SourceRectangle { get; set; } = null;
		public OriginMode OriginMode { get; set; } = OriginMode.Center;
		public Color Color { get; set; } = Color.White;
		public SpriteEffects Effects { get; set; } = SpriteEffects.None;
		public float PixelsPerUnit { get; set; } = 1f;

		public Vector2 Origin 
		{
			get 
			{
				return CalculateOrigin ();
			}
		}

		public Sprite (Texture2D texture)
		{
			Contract.RequiresNotNull (texture, "The texture must not be null");

			Texture = texture;
		}

		private Vector2 CalculateOrigin ()
		{
			if (SourceRectangle != null && SourceRectangle.HasValue) 
			{
				var srcRect = SourceRectangle.Value;

				switch (OriginMode) 
				{
				case OriginMode.TopLeft:
					return new Vector2 (0, 0);
				case OriginMode.TopRight:
					return new Vector2 (srcRect.Width, 0);
				case OriginMode.BottomLeft:
					return new Vector2 (0, srcRect.Height);
				case OriginMode.BottomRight:
					return new Vector2 (srcRect.Width, 0);
				case OriginMode.TopCenter:
					return new Vector2 (srcRect.Width / 2, 0);
				case OriginMode.BottomCenter:
					return new Vector2 (srcRect.Width / 2, srcRect.Height);
				case OriginMode.RightCenter:
					return new Vector2 (srcRect.Width, srcRect.Height / 2);
				case OriginMode.LeftCenter:
					return new Vector2 (0, srcRect.Height / 2);
				case OriginMode.Center:
					return new Vector2 (srcRect.Width / 2, srcRect.Height / 2);
				default:
					throw Contract.Unreachable;
				}
			}
			else 
			{
				switch (OriginMode) 
				{
				case OriginMode.TopLeft:
					return new Vector2 (0, 0);
				case OriginMode.TopRight:
					return new Vector2 (Texture.Width, 0);
				case OriginMode.BottomLeft:
					return new Vector2 (0, Texture.Height);
				case OriginMode.BottomRight:
					return new Vector2 (Texture.Width, 0);
				case OriginMode.TopCenter:
					return new Vector2 (Texture.Width / 2, 0);
				case OriginMode.BottomCenter:
					return new Vector2 (Texture.Width / 2, Texture.Height);
				case OriginMode.RightCenter:
					return new Vector2 (Texture.Width, Texture.Height / 2);
				case OriginMode.LeftCenter:
					return new Vector2 (0, Texture.Height / 2);
				case OriginMode.Center:
					return new Vector2 (Texture.Width / 2, Texture.Height / 2);
				default:
					throw Contract.Unreachable;
				}
			}
		}
	}
}

