using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Paradix.Engine
{
	public class SceneManager : IUpdateable, IDrawable, IContent
	{
		public Scene CurrentScene { get; private set; }

		public SceneManager ()
		{
		}

		public void Play (string sceneName)
		{
			
		}

		public void AddScene (Scene scene)
		{
			
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
