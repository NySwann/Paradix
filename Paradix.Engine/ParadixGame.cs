﻿using Microsoft.Xna.Framework;

namespace Paradix
{
	public class ParadixGame : Game
	{
		public GraphicsManager Graphics { get; set; }
		public InputManager Inputs { get; set; }

		public ParadixGame ()
		{
			Graphics = new GraphicsManager (this);
			Inputs = new InputManager ();
		}

		protected override void Initialize ()
		{
			base.Initialize ();

			Graphics.CreateBatch ();
		}

		protected override void Update (GameTime gameTime)
		{
			base.Update (gameTime);

			Inputs.Flush (gameTime);
		}

		protected override void Dispose (bool disposing)
		{
			if (disposing) 
			{
				Graphics.Dispose ();
				Graphics = null;
				Inputs = null;
			}

			base.Dispose (disposing);
		}
	}
}