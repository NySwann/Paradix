using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Paradix
{
	public class Entity : Component, IUpdateable, IDrawable, IContent
	{
		public bool IsActive { get; set; } = true;
		public List<Component> Components { get; private set; } = null;

		public Entity (string name) : base (name)
		{
			Components = new List<Component> ();
		}

		public void Enable ()
		{
			IsActive = true;
		}

		public void Disable ()
		{
			IsActive = false;
		}

		public void AddComponent (Component component)
		{
			Contract.RequiresNotNull (component, "component must not be null");
			Contract.Requires (component.AttachedEntity == null, "componement must not have multiple parents");

			component.AttachedEntity = this;
			Components.Add (component);
		}

		public void AddComponents (IEnumerable<Component> components)
		{
			Contract.RequiresNotEmpty (components, "component must not be null");

			foreach (var component in Components) 
			{
				Contract.Requires (component.AttachedEntity == null, "componements must not have multiple parents");

				component.AttachedEntity = this;
			}

			Components.AddRange (components);
		}

		public bool HasComponent<T> () where T : Component
		{
			return (Components.Find (component => component is T) != null);
		}

		public bool HasComponentWithName<T> (string name) where T : Component
		{
			return (Components.Find (component => component.Name == name && component is T) != null);
		}

		public bool HasComponentWithTag<T> (string tag) where T : Component
		{
			return (Components.Find (component => component.Tag == tag && component is T) != null);
		}

		public bool HasRequiredComponent(Predicate<Component> match)
		{
			return (Components.Find (match) != null);
		}

		public T GetComponent<T> () where T : Component
		{
			return ((T)Components.Find (component => component is T));
		}

		public List<Component> GetComponents (Predicate<Component> match)
		{
			return (Components.FindAll (match));
		}

		public T GetComponentByName<T> (string name) where T : Component
		{
			return ((T)Components.Find (component => component.Name == name && component is T));
		}

		public List<Component> GetComponentsByName (string name)
		{
			return (Components.FindAll (component => component.Name == name));
		}

		public T GetComponentByTag<T> (string tag) where T : Component
		{
			return ((T)Components.Find (component => component.Tag == tag && component is T));
		}

		public List<Component> GetComponentsByTag (string tag)
		{
			return (Components.FindAll (component => component.Tag == tag));
		}

		public void RemoveComponent<T> () where T : Component
		{
			var toRemove = (Components.Find (component => component is T));

			if (toRemove != null)
				Components.Remove (toRemove);
		}

		public void RemoveComponents (Predicate<Component> match)
		{
			Components.RemoveAll (match);
		}

		public void RemoveComponentByName<T> (string name) where T : Component
		{
			var toRemove = (Components.Find (component => component.Name == name && component is T));

			if (toRemove != null)
				Components.Remove (toRemove);
		}

		public void RemoveComponentByTag<T> (string tag) where T : Component
		{
			var toRemove = (Components.Find (component => component.Tag == tag && component is T));

			if (toRemove != null)
				Components.Remove (toRemove);
		}

		public void ClearComponents ()
		{
			Components.Clear ();
		}

		public override void Initialize ()
		{
			base.Initialize ();

			foreach (var component in Components)
				component.Initialize ();
		}

		public virtual void Load (ContentManager content)
		{
			foreach (var component in Components) 
			{
				if (component is IContent)
					((IContent)component).Load (content);
			}
		}

		public virtual void Update (GameTime gameTime, InputManager input)
		{
			if (IsActive) 
			{
				foreach (var component in Components) 
				{
					if (component is IUpdateable)
						((IUpdateable)component).Update (gameTime, input);
				}
			}
		}

		public virtual void Draw (GameTime gameTime, GraphicsManager graphics)
		{
			if (IsActive) 
			{
				foreach (var component in Components) 
				{
					if (component is IDrawable)
						((IDrawable)component).Draw (gameTime, graphics);
				}
			}
		}

		public virtual void Destroy ()
		{
			foreach (var component in Components) 
			{
				if (component is IContent)
					((IContent)component).Destroy ();
			}
		}

		protected override void Dispose (bool disposing)
		{
			if (!IsDisposed && disposing) 
			{
				IsActive = false;
				Components.Clear ();
				Components = null;
			}

			base.Dispose (disposing);
		}

	}
}

