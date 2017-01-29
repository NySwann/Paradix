﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Paradix
{
	public sealed class MouseController : IUpdateable
	{
		// TODO : Add sensivity

		public MouseState CurrentState { get; private set; }
		public MouseState PreviousState { get; private set; }

		public Point Position 
		{
			get 
			{
				return CurrentState.Position;
			}
		}

		public Point PositionDelta 
		{
			get 
			{
				return CurrentState.Position - PreviousState.Position;
			}
		}

		public bool IsMoving 
		{
			get 
			{
				return CurrentState.Position != PreviousState.Position;
			}
		}

		public int Wheel 
		{
			get 
			{
				return CurrentState.ScrollWheelValue;
			}
		}

		public int WheelDelta 
		{
			get 
			{
				return CurrentState.ScrollWheelValue - PreviousState.ScrollWheelValue;
			}
		}

		public bool IsScrolling 
		{
			get 
			{
				return CurrentState.ScrollWheelValue != PreviousState.ScrollWheelValue;
			}
		}

		public bool IsScrollingUp 
		{
			get 
			{
				return CurrentState.ScrollWheelValue < PreviousState.ScrollWheelValue;
			}
		}

		public bool IsScrollingDown 
		{
			get 
			{
				return CurrentState.ScrollWheelValue > PreviousState.ScrollWheelValue;
			}
		}

		public MouseController ()
		{
			CurrentState = Mouse.GetState ();
			PreviousState = CurrentState;
		}

		public bool IsButtonDown (MouseButton button)
		{
			switch (button) 
			{
			case MouseButton.Left:
				return CurrentState.LeftButton == ButtonState.Pressed;
			case MouseButton.Middle:
				return CurrentState.MiddleButton == ButtonState.Pressed;
			case MouseButton.Right:
				return CurrentState.RightButton == ButtonState.Pressed;
			case MouseButton.Forward:
				return CurrentState.XButton1 == ButtonState.Pressed;
			case MouseButton.Back:
				return CurrentState.XButton2 == ButtonState.Pressed;
			default:
				throw Contract.Unreachable;
			}
		}

		public bool IsButtonUp (MouseButton button)
		{
			switch (button) 
			{
			case MouseButton.Left:
				return CurrentState.LeftButton == ButtonState.Released;
			case MouseButton.Middle:
				return CurrentState.MiddleButton == ButtonState.Released;
			case MouseButton.Right:
				return CurrentState.RightButton == ButtonState.Released;
			case MouseButton.Forward:
				return CurrentState.XButton1 == ButtonState.Released;
			case MouseButton.Back:
				return CurrentState.XButton2 == ButtonState.Released;
			default:
				throw Contract.Unreachable;
			}
		}

		public bool IsButtonPressed (MouseButton button)
		{
			switch (button) 
			{
			case MouseButton.Left:
				return CurrentState.LeftButton == ButtonState.Pressed && PreviousState.LeftButton == ButtonState.Released;
			case MouseButton.Middle:
				return CurrentState.MiddleButton == ButtonState.Pressed && PreviousState.RightButton == ButtonState.Released;
			case MouseButton.Right:
				return CurrentState.RightButton == ButtonState.Pressed && PreviousState.MiddleButton == ButtonState.Released;
			case MouseButton.Forward:
				return CurrentState.XButton1 == ButtonState.Pressed && PreviousState.XButton1 == ButtonState.Released;
			case MouseButton.Back:
				return CurrentState.XButton2 == ButtonState.Pressed && PreviousState.XButton2 == ButtonState.Released;
			default:
				throw Contract.Unreachable;
			}
		}

		public bool IsButtonReleased (MouseButton button)
		{
			switch (button) 
			{
			case MouseButton.Left:
				return PreviousState.LeftButton == ButtonState.Pressed && CurrentState.LeftButton == ButtonState.Released;
			case MouseButton.Middle:
				return PreviousState.MiddleButton == ButtonState.Pressed && CurrentState.RightButton == ButtonState.Released;
			case MouseButton.Right:
				return PreviousState.RightButton == ButtonState.Pressed && CurrentState.MiddleButton == ButtonState.Released;
			case MouseButton.Forward:
				return PreviousState.XButton1 == ButtonState.Pressed && CurrentState.XButton1 == ButtonState.Released;
			case MouseButton.Back:
				return PreviousState.XButton2 == ButtonState.Pressed && CurrentState.XButton2 == ButtonState.Released;
			default:
				throw Contract.Unreachable;
			}
		}

		public void Update (GameTime gameTime)
		{
			PreviousState = CurrentState;
			CurrentState = Mouse.GetState ();
		}
	}
}