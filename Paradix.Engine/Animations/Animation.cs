using System.Collections.Generic;

namespace Paradix
{
	public enum PlayMode
	{
		Once,
		Loop
	}

	public class Animation
	{
		public List<Sprite> Frames { get; private set; } = null;
		public double Interval { get; set; } = 0;
		public PlayMode Mode { get; set; } = PlayMode.Once;

		public Animation (List<Sprite> frames)
		{
			Contract.RequiresNotEmpty (frames, "frames");

			Frames = frames;
		}
	}
}

