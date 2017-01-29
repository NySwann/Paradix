using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Paradix.Sample
{
	public sealed class Ship : Entity
	{
		private static readonly string ShipTextureFile = "Ship";
		private static readonly Vector2 ShipAcceleration = new Vector2 (1.2f);
		private static readonly Vector2 ShipFriction = new Vector2(0.9f, 0.9f);
		private static readonly Vector2 ShipMaxSpeed = new Vector2(10.0f, 10.0f);

		public Ship (Shooter shooter) : base("Ship")
		{
			AddComponent (new Transform());
			AddComponent (new Renderer ());
			AddComponent (new RigidBody());

			GetComponent<Transform> ().AbsolutePosition = 
				new Vector2 (shooter.Graphics.BufferWidth / 2, shooter.Graphics.BufferHeight / 2);
			GetComponent<Transform> ().AbsoluteScale = new Vector2 (0.3f, 0.3f);

			GetComponent<RigidBody> ().Acceleration = ShipAcceleration;
			GetComponent<RigidBody> ().Friction = ShipFriction;
			GetComponent<RigidBody> ().MaxVelocity = ShipMaxSpeed;
		}

		public void Load(ContentManager content)
		{
			GetComponent<Renderer> ().Sprite = new Sprite(content.Load<Texture2D> (ShipTextureFile));
			GetComponent<Renderer> ().PixelsPerUnit = 1f;
			GetComponent<Renderer> ().LayerDepth = 0.9f;
		}

		public override void Update (GameTime gameTime)
		{
			KeyboardState keyboard = Keyboard.GetState();
			JoystickState joystick = Joystick.GetState(0);

			var velocity = new Vector2();

			if (joystick.IsConnected) 
			{
				if (joystick.Axes [0] < -0.05f || joystick.Axes [0] > 0.05f)
					velocity.X = joystick.Axes [0];
				if (joystick.Axes [1] < -0.05f || joystick.Axes [1] > 0.05f)
					velocity.Y = joystick.Axes [1];
			}

			if (keyboard.IsKeyDown(Keys.Up))
				velocity.Y = -1f;
			if (keyboard.IsKeyDown (Keys.Down))
				velocity.Y = 1f;
			if (keyboard.IsKeyDown (Keys.Right))
				velocity.X = 1f;
			if (keyboard.IsKeyDown (Keys.Left))
				velocity.X = -1f;
			if (keyboard.IsKeyDown (Keys.A))
				GetComponent<Transform> ().RelativeRotation += 0.01f;
			if (keyboard.IsKeyDown (Keys.E))
				GetComponent<Transform> ().RelativeRotation -= 0.01f;

			GetComponent<RigidBody> ().AddVelocity (velocity);

			base.Update (gameTime);
		}
	}
}