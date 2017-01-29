using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Paradix
{
	public class SpriteSheet
	{
		public Texture2D Sheet {get; private set; } = null;
		public List<Sprite> Frames { get; private set; } = null;

		public int LineNumber { get; private set; } = 0;
		public int ColumnNumber { get; private set; } = 0;
		public int TotalFrameNumber { get; private set; } = 0;

		public int FrameWidth 
		{
			get
			{
				return Sheet.Width / ColumnNumber;
			}
		}

		public int FrameHeight 
		{
			get
			{
				return Sheet.Height / LineNumber;
			}
		}

		public Sprite this[int frameIndex]
		{
			get 
			{
				Contract.RequiresPositiveOrNull (frameIndex, "frameIndex");
				Contract.Requires (frameIndex < TotalFrameNumber, "The frameIndex must be < TotalFrameNumber");
				Contract.Requires (frameIndex < Frames.Count, "The frameIndex must be < Frames.Count");

				return Frames [frameIndex];
			}
		}

		public SpriteSheet (Texture2D sheet, int columnNumber, int lineNumber, int totalFrameNumber)
		{
			Contract.RequiresNotNull (sheet, "sheet");
			Contract.RequiresPositive (columnNumber, "columnNumber");
			Contract.RequiresPositive (lineNumber, "lineNumber");
			Contract.RequiresPositive (totalFrameNumber, "totalFrameNumber");

			Sheet = sheet;
			ColumnNumber = columnNumber;
			LineNumber = lineNumber;
			TotalFrameNumber = totalFrameNumber;

			GenerateFrames ();
		}

		private void GenerateFrames()
		{
			Frames = new List<Sprite> ();

			for (int frameIndex = 0; frameIndex < TotalFrameNumber; frameIndex++) 
			{
				var sprite = new Sprite (Sheet);

				sprite.SourceRectangle =  new Rectangle ((frameIndex % ColumnNumber) * FrameWidth, 
					(frameIndex / ColumnNumber) * FrameHeight, FrameWidth, FrameHeight);

				Frames.Add (sprite);
			}
		}
	}
}

