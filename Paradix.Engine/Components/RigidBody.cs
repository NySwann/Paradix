using Microsoft.Xna.Framework;

namespace Paradix
{
	public class RigidBody : Component, IUpdateable
	{
		public Vector2 Velocity { get; private set; } = Vector2.Zero;
		public Vector2 Acceleration { get; set; } = Vector2.One;
		public Vector2 Friction { get; set; } = Vector2.Zero;
		public Vector2 MaxVelocity { get; set; } = Vector2.One;

		public bool IsMoving 
		{
			get 
			{
				return Velocity != Vector2.Zero;
			}
		}

		public RigidBody () : base ("RigidBody")
		{
		}

		public void Update (GameTime gameTime, InputManager input)
		{
			if (Velocity.X > MaxVelocity.X)
				Velocity = new Vector2(MaxVelocity.X, Velocity.Y);

			if (Velocity.X < -MaxVelocity.X)
				Velocity = new Vector2(-MaxVelocity.X, Velocity.Y);

			if (Velocity.Y > MaxVelocity.Y)
				Velocity = new Vector2(Velocity.X, MaxVelocity.Y);

			if (Velocity.Y < -MaxVelocity.Y)
				Velocity = new Vector2(Velocity.X, -MaxVelocity.Y);

			Move (Velocity.X * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 10, 
				Velocity.Y * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 10);

			Velocity *= Friction;
		}

		public void AddVelocity (float x, float y)
		{
			AddVelocity (new Vector2 (x, y));
		}

		public void AddVelocity (Vector2 velocity)
		{
			Velocity += velocity;
		}

		public void Move (float x, float y)
		{
			Move (new Vector2 (x, y));
		}

		public void Move (Vector2 relative)
		{
			Contract.Requires (AttachedGameObject.HasComponent<Transform> (), "The Transform component is required for the Rigidbody component");

			AttachedGameObject.GetComponent<Transform> ().RelativePosition += relative;
		}
	}
}