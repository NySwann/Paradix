using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Paradix.Sample
{
	public sealed class Asteroid : Entity
	{
		private static readonly string ShipTextureFile = "Asteroid";

		public Asteroid () : base("Asteroid")
		{
			AddComponent (new Transform());
			AddComponent (new Renderer ());

			GetComponent<Transform> ().RelativeScale = new Vector2 (0.3f, 0.3f);
			GetComponent<Transform> ().RelativePosition = new Vector2 (300f, 300f);
		}

		public override void Load(ContentManager content)
		{
			GetComponent<Renderer> ().Sprite = new Sprite(content.Load<Texture2D> (ShipTextureFile));
			GetComponent<Renderer> ().PixelsPerUnit = 1f;
			GetComponent<Renderer> ().LayerDepth = 0.1f;
		}
	}
}