using System.Collections.Generic;

using Microsoft.Xna.Framework;

namespace Paradix
{
	public enum AnimatorState
	{
		Playing,
		Paused,
		Stopped
	}

	public class Animator : Component, IUpdateable
	{
		public AnimatorState State { get; private set; } = AnimatorState.Stopped;
		public double TotalElapsedMilliseconds = 0d;
		public int FrameCounter { get; set; } = 0;
		public int AnimationCounter { get; set; } = 0;
		public List<Animation> Animations { get; set; } = null;

		public Animation CurrentAnimation
		{
			get
			{
				return Animations [AnimationCounter];
			}
		}

		public Animator () : base("Animator")
		{
		}

		public void Update(GameTime gameTime, InputManager input)
		{
			Contract.Requires (IsAttached, "This Animator component must be attached to an Entity");
			Contract.Requires (AttachedEntity.HasComponent<Renderer> (), "The Transform component is required for the Animator component");

			if (State == AnimatorState.Playing) 
			{
				TotalElapsedMilliseconds += gameTime.ElapsedGameTime.TotalMilliseconds;

				if (TotalElapsedMilliseconds > CurrentAnimation.Interval) 
				{
					FrameCounter++;

					if (FrameCounter >= CurrentAnimation.Frames.Count) 
					{
						if (CurrentAnimation.Mode == PlayMode.Loop) 
						{
							FrameCounter = 0;
						}
						else
						{
							AnimationCounter++;

							if (AnimationCounter >= Animations.Count) 
							{
								State = AnimatorState.Stopped;
								return;
							}
						}
					}

					TotalElapsedMilliseconds = 0d;
				}
			}

			AttachedEntity.GetComponent<Renderer> ().Sprite = CurrentAnimation.Frames [FrameCounter];
		}

		public void Reset()
		{
			FrameCounter = 0;
			AnimationCounter = 0;
			TotalElapsedMilliseconds = 0f;
			State = AnimatorState.Stopped;
		}

		public void Play()
		{
			Contract.Requires(State == AnimatorState.Stopped || State == AnimatorState.Paused, 
				"State must be set on AnimationState.Stopped or AnimationState.Paused");

			if (State == AnimatorState.Stopped)
				Reset ();

			State = AnimatorState.Playing;
		}

		public void Pause()
		{
			Contract.Requires(State == AnimatorState.Playing, "State must be on AnimationState.Playing");

			State = AnimatorState.Paused;	
		}

		public void Stop()
		{
			Contract.Requires(State == AnimatorState.Playing || State == AnimatorState.Paused, 
				"State must be on AnimationState.Playing or AnimationState.Paused");

			State = AnimatorState.Stopped;	
		}
	}
}