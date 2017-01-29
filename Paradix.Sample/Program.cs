using System;

namespace Paradix.Sample
{
	public static class Program
    {
        [STAThread]
        static void Main (string[] args)
		{
			using (var game = new Shooter ())
				game.Run ();
		}
	}
}

