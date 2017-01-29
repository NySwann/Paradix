using System;

namespace Paradix
{
	public abstract class Component : IDisposable
	{
		public string Name { get; private set; } = null;
		public string Tag { get; private set; } = null;
		public Entity AttachedGameObject { get; set; } = null;
		public bool IsDisposed {get; private set;} = false;

		public bool IsAttached
		{
			get
			{
				return AttachedGameObject != null;
			}
		}

		protected Component (string name, string tag = null)
		{
			Contract.RequiresNotEmpty (name, "The name must not be null or empty !");

			Name = name;
			Tag = tag;
		}

		~Component ()
		{
			Dispose (false);
		}

		public virtual void Initialize ()
		{
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
				Name = null;
				Tag = null;
				AttachedGameObject = null;
			}

			IsDisposed = true;
		}
	}
}