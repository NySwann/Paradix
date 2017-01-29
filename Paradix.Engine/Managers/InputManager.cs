using Microsoft.Xna.Framework;

namespace Paradix
{
	public sealed class InputManager : IController
	{
		public GamePadController [] GamePads { get; private set; } = null;
		public KeyboardController [] Keyboards { get; private set; } = null;
		public MouseController Mouse { get; private set; } = null;

		public InputManager ()
		{
			GamePads = new GamePadController [4];
			GamePads [0] = new GamePadController (PlayerIndex.One);
			GamePads [1] = new GamePadController (PlayerIndex.Two);
			GamePads [2] = new GamePadController (PlayerIndex.Three);
			GamePads [3] = new GamePadController (PlayerIndex.Four);

			Keyboards = new KeyboardController [4];
			Keyboards [0] = new KeyboardController (PlayerIndex.One);
			Keyboards [1] = new KeyboardController (PlayerIndex.Two);
			Keyboards [2] = new KeyboardController (PlayerIndex.Three);
			Keyboards [3] = new KeyboardController (PlayerIndex.Four);

			Mouse = new MouseController ();
		}

		public void Flush (GameTime gameTime)
		{
			foreach (var gamePad in GamePads)
				gamePad.Flush (gameTime);
			
			foreach (var keyboard in Keyboards)
				keyboard.Flush (gameTime);

			Mouse.Flush (gameTime);
		}
	}

}
