using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Paradix
{
	public interface IDrawable
	{
		void Draw (GameTime gameTime, GraphicsManager graphics);
	}
}

