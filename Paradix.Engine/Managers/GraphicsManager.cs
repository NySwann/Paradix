using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Paradix
{
	public class GraphicsManager : IDisposable
	{
		public GraphicsDeviceManager DeviceManager { get; private set; } = null;
		public SpriteBatch Batch { get; private set; } = null;
		public bool IsDisposed = false;

		public GraphicsDevice Device 
		{ 
			get
			{
				return DeviceManager.GraphicsDevice;
			}
		}

		public bool SynchronizeWithVerticalRetrace
		{
			get
			{
				return DeviceManager.SynchronizeWithVerticalRetrace;
			}

			set
			{
				DeviceManager.SynchronizeWithVerticalRetrace = value;
				DeviceManager.ApplyChanges ();
			}
		}

		public bool IsFullScreen 
		{
			get 
			{
				return DeviceManager.IsFullScreen;
			}

			set 
			{
				DeviceManager.IsFullScreen = value;
				DeviceManager.ApplyChanges ();
			}
		}

		public bool MultiSampling 
		{
			get 
			{
				return DeviceManager.PreferMultiSampling;
			}

			set 
			{
				DeviceManager.PreferMultiSampling = value;
				DeviceManager.ApplyChanges ();
			}
		}

		public bool HardwareModeSwitch 
		{
			get 
			{
				return DeviceManager.HardwareModeSwitch;
			}

			set 
			{
				DeviceManager.HardwareModeSwitch = value;
				DeviceManager.ApplyChanges ();
			}
		}

		public DisplayOrientation SupportedOrientations
		{
			get
			{
				return DeviceManager.SupportedOrientations;
			}
		}

		public int BufferHeight 
		{
			get 
			{
				return DeviceManager.PreferredBackBufferHeight;
			}

			set 
			{
				DeviceManager.PreferredBackBufferHeight = value;
				DeviceManager.ApplyChanges ();
			}
		}

		public int BufferWidth 
		{
			get 
			{
				return DeviceManager.PreferredBackBufferWidth;
			}

			set 
			{
				DeviceManager.PreferredBackBufferWidth = value;
				DeviceManager.ApplyChanges ();
			}
		}

		public SurfaceFormat BufferFormat 
		{
			get 
			{
				return DeviceManager.PreferredBackBufferFormat;
			}

			set 
			{
				DeviceManager.PreferredBackBufferFormat = value;
				DeviceManager.ApplyChanges ();
			}
		}

		public DepthFormat StencilFormat 
		{
			get 
			{
				return DeviceManager.PreferredDepthStencilFormat;
			}

			set 
			{
				DeviceManager.PreferredDepthStencilFormat = value;
				DeviceManager.ApplyChanges ();
			}
		}

		public GraphicsManager (Game game)
		{
			DeviceManager = new GraphicsDeviceManager (game);
		}

		~GraphicsManager()
		{
			Dispose (false);
		}

		internal void CreateBatch()
		{
			Batch = new SpriteBatch (DeviceManager.GraphicsDevice);
		}

		public void ToggleFullScreen()
		{
			DeviceManager.ToggleFullScreen ();
		}

		public void Dispose ()
		{
			Dispose (true);
			GC.SuppressFinalize (this);
		}

		protected virtual void Dispose (bool disposing)
		{
			if (!IsDisposed && disposing) 
			{
				Batch.Dispose ();
				Batch = null;
				DeviceManager.Dispose ();
				DeviceManager = null;
			}

			IsDisposed = true;
		}
	}
}
