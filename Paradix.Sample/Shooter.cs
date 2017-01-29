using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Paradix.Sample
{
	public sealed class Shooter : ParadixGame
	{
		private Ship PlayerShip = null;

		public Shooter ()
		{
			Graphics.BufferHeight = 800;
			Graphics.BufferWidth = 1400;
			Content.RootDirectory = "Content";

			CreateEntities ();
		}

		protected override void Initialize ()
		{           
			base.Initialize ();

			PlayerShip.Initialize ();
		}

		private void CreateEntities()
		{
			PlayerShip = new Ship (this);
		}
			
		protected override void LoadContent ()
		{
			base.LoadContent ();

			PlayerShip.Load(Content);
		}
			
		protected override void Update (GameTime gameTime)
		{
			base.Update (gameTime);

			PlayerShip.Update (gameTime);
		}

		protected override void Draw (GameTime gameTime)
		{
			base.Draw (gameTime);

			GraphicsDevice.Clear (Color.Black);

			Graphics.Batch.Begin (SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

			PlayerShip.Draw (Graphics.Batch, gameTime);

			Graphics.Batch.End();
		}
	}
}

