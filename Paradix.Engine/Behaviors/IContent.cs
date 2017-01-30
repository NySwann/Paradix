using Microsoft.Xna.Framework.Content;

namespace Paradix
{
	public interface IContent
	{
		void Load (ContentManager content);
		void Destroy ();
	}
}
