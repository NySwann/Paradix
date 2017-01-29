namespace Paradix
{
	public abstract class Component
	{
		public string Name { get; private set; } = null;
		public string Tag { get; private set; } = null;
		public Entity AttachedGameObject { get; set; } = null;

 		protected Component (string name, string tag = null)
		{
			Contract.RequiresNotEmpty (name, "The name must not be null or empty !");

			Name = name;
			Tag = tag;
		}

		public virtual void Initialize ()
		{
		}
	}
}