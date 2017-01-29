using Microsoft.Xna.Framework;

namespace Paradix
{
	public sealed class Transform : Component
	{
		// TODO : Add Position/Rotation/Scale HasChanged to prevent useless calculations

		private Vector2 _RelativePosition = Vector2.Zero;

		public Vector2 RelativePosition 
		{
			get 
			{
				return _RelativePosition;
			}

			set 
			{
				_RelativePosition = value;
			}
		}

		public Vector2 AbsolutePosition
		{
			get 
			{
				if (IsAttached && AttachedGameObject.IsAttached && AttachedGameObject.AttachedGameObject.HasComponent<Transform> ())
					return _RelativePosition + AttachedGameObject.AttachedGameObject.GetComponent<Transform> ().AbsolutePosition;
				return _RelativePosition;
			}

			set 
			{
				if (IsAttached && AttachedGameObject.IsAttached && AttachedGameObject.AttachedGameObject.HasComponent<Transform> ())
					_RelativePosition  = value - AttachedGameObject.AttachedGameObject.GetComponent<Transform> ().AbsolutePosition;
				_RelativePosition = value;
			}
		}

		private Vector2 _RelativeScale = Vector2.One;

		public Vector2 RelativeScale 
		{
			get 
			{
				return _RelativeScale;
			}

			set 
			{
				_RelativeScale = value;
			}
		}

		public Vector2 AbsoluteScale 
		{
			get 
			{
				if (IsAttached && AttachedGameObject.IsAttached && AttachedGameObject.AttachedGameObject.HasComponent<Transform> ())
					return _RelativeScale + AttachedGameObject.AttachedGameObject.GetComponent<Transform> ().AbsoluteScale;
				return _RelativeScale;
			}

			set 
			{
				if (IsAttached && AttachedGameObject.IsAttached && AttachedGameObject.AttachedGameObject.HasComponent<Transform> ())
					_RelativeScale = value - AttachedGameObject.AttachedGameObject.GetComponent<Transform> ().AbsoluteScale;
				_RelativeScale = value;
			}
		}

		private float _RelativeRotation = 0f;

		public float RelativeRotation 
		{
			get 
			{
				return _RelativeRotation;
			}

			set 
			{
				_RelativeRotation = value;
			}
		}

		public float AbsoluteRotation
		{
			get 
			{
				if (IsAttached && AttachedGameObject.IsAttached && AttachedGameObject.AttachedGameObject.HasComponent<Transform> ())
					return _RelativeRotation + AttachedGameObject.AttachedGameObject.GetComponent<Transform> ().AbsoluteRotation;
				return _RelativeRotation;
			}

			set 
			{
				if (IsAttached && AttachedGameObject.IsAttached && AttachedGameObject.AttachedGameObject.HasComponent<Transform> ())
					_RelativeRotation = value - AttachedGameObject.AttachedGameObject.GetComponent<Transform> ().AbsoluteRotation;
				_RelativeRotation = value;
			}
		}

		public Transform() : base("Transform")
		{
		}
	}
}

