using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Paradix
{
	public sealed class KeyboardController : IUpdateable
	{
		// TODO : List of keys UP / DOWN / PRESSED / RELEASED

		public PlayerIndex Player { get; set; } = PlayerIndex.One;
		public KeyboardState CurrentState { get; private set; }
		public KeyboardState PreviousState { get; private set; }

		public KeyboardController (PlayerIndex player = PlayerIndex.One)
		{
			Player = player;
			CurrentState = Keyboard.GetState (Player);
			PreviousState = CurrentState;
		}

		public bool IsKeyDown (Keys key)
		{
			return CurrentState.IsKeyDown (key);
		}

		public bool IsKeyUp (Keys key)
		{
			return CurrentState.IsKeyUp (key);
		}

		public bool IsKeyPressed (Keys key)
		{
			return CurrentState.IsKeyDown (key) && PreviousState.IsKeyUp (key);
		}

		public bool IsKeyReleased (Keys key)
		{
			return PreviousState.IsKeyDown (key) && CurrentState.IsKeyUp (key);
		}

		public void Update (GameTime gameTime)
		{
			PreviousState = CurrentState;
			CurrentState = Keyboard.GetState (Player);
		}
	}
}