using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Paradix
{
	public sealed class GamePadController : IController
	{
		// TODO : Add Threshold
		// TODO : Add HasChanged, HasMoved or WasTouched
		// TODO : Vibration Duration
		// TODO : Vector2D Informations

		public PlayerIndex Player { get; set; } = PlayerIndex.One;
		public GamePadDeadZone DeadZone { get; set; } = GamePadDeadZone.None;
		public GamePadState CurrentState { get; private set; }
		public GamePadState PreviousState { get; private set; }

		public GamePadController (PlayerIndex player = PlayerIndex.One, GamePadDeadZone deadZone = GamePadDeadZone.None)
		{
			Player = player;
			DeadZone = deadZone;
			CurrentState = GamePad.GetState (Player, DeadZone);
			PreviousState = CurrentState;
		}

		public bool IsConnected 
		{
			get 
			{
				return CurrentState.IsConnected;
			}
		}

		public GamePadCapabilities GetCapabilities ()
		{
			return GamePad.GetCapabilities (Player);
		}

		public bool SetVibration (Vector2 motors)
		{
			return GamePad.SetVibration (Player, motors.X, motors.Y);
		}

		public bool SetVibration (float leftMotor, float rightMotor)
		{
			return GamePad.SetVibration (Player, leftMotor, rightMotor);
		}

		public bool IsButtonDown (Buttons button)
		{
			return CurrentState.IsButtonDown (button);
		}

		public bool IsButtonUp (Buttons button)
		{
			return CurrentState.IsButtonUp (button);
		}

		public bool IsButtonPressed (Buttons button)
		{
			return CurrentState.IsButtonDown (button) && PreviousState.IsButtonUp (button);
		}

		public bool IsButtonReleased (Buttons button)
		{
			return PreviousState.IsButtonDown (button) && CurrentState.IsButtonUp (button);
		}

		public Vector2 LeftThumpstick 
		{
			get 
			{
				return CurrentState.ThumbSticks.Left;
			}
		}

		public Vector2 RightThumpstick 
		{
			get 
			{
				return CurrentState.ThumbSticks.Right;
			}
		}

		public Vector2 LeftThumpstickDelta 
		{
			get 
			{
				return CurrentState.ThumbSticks.Left - PreviousState.ThumbSticks.Left;
			}
		}

		public Vector2 RightThumpstickDelta 
		{
			get 
			{
				return CurrentState.ThumbSticks.Right - PreviousState.ThumbSticks.Right;
			}
		}

		public float LeftTriggerPressure 
		{
			get 
			{
				return CurrentState.Triggers.Left;
			}

		}

		public float LeftTriggerPressureDelta 
		{
			get 
			{
				return CurrentState.Triggers.Left - PreviousState.Triggers.Left;
			}
		}

		public float RightTriggerPressure 
		{
			get 
			{
				return CurrentState.Triggers.Right;
			}
		}

		public float RightTriggerPressureDelta 
		{
			get 
			{
				return CurrentState.Triggers.Right - PreviousState.Triggers.Right;
			}
		}

		public void Flush (GameTime gameTime)
		{
			PreviousState = CurrentState;
			CurrentState = GamePad.GetState (Player, DeadZone);
		}
	}
}