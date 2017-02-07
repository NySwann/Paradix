using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Paradix.Engine
{
	public abstract class Scene : IUpdateable, IDrawable, IContent
	{
		public string Name { get; private set; } = null;
		public List<Entity> Entities { get; private set; } = null;
		public bool IsActive { get; set; } = true;
		public bool IsPlaying { get; internal set; } = false;

		protected Scene(string name)
		{
			Contract.RequiresNotEmpty (name, "name");

			Name = name;
			Entities = new List<Entity> ();
		}

		public void Load (ContentManager content)
		{
			throw new NotImplementedException ();
		}

		public void Update (GameTime gameTime, InputManager input)
		{
			throw new NotImplementedException ();
		}

		public void Draw (GameTime gameTime, GraphicsManager graphics)
		{
			throw new NotImplementedException ();
		}

		public void Destroy ()
		{
			throw new NotImplementedException ();
		}
	}
}
