using Microsoft.Xna.Framework;

namespace Paradix
{
	public sealed class Transform : Component
	{
		private bool IsPositionRelative = true;

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
				IsPositionRelative = true;
				CalculateTransform ();
			}
		}

		private Vector2 _AbsolutePosition = Vector2.Zero;
		public Vector2 AbsolutePosition
		{
			get 
			{
				return _AbsolutePosition;
			}

			set 
			{
				_AbsolutePosition = value;
				IsPositionRelative = false;
				CalculateTransform ();
			}
		}

		private bool IsScaleRelative = true;

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
				IsScaleRelative = true;
				CalculateTransform ();
			}
		}

		private Vector2 _AbsoluteScale = Vector2.One;
		public Vector2 AbsoluteScale 
		{
			get 
			{
				return _AbsoluteScale;
			}

			set 
			{
				_AbsoluteScale = value;
				IsScaleRelative = false;
				CalculateTransform ();
			}
		}

		private bool IsRotationRelative = true;

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
				IsRotationRelative = true;
				CalculateTransform ();
			}
		}

		private float _AbsoluteRotation = 0f;
		public float AbsoluteRotation
		{
			get 
			{
				return _AbsoluteRotation;
			}

			set 
			{
				_AbsoluteRotation = value;
				IsRotationRelative = false;
				CalculateTransform ();
			}
		}

		public Transform() : base("Transform")
		{
		}

		private void CalculateTransform()
		{
			if (IsAttached) 
			{
				if (AttachedEntity.IsAttached && AttachedEntity.AttachedEntity.HasComponent<Transform> ()) 
				{
					var parentTransform = AttachedEntity.AttachedEntity.GetComponent<Transform> ();

					if (IsPositionRelative)
						_AbsolutePosition = (_RelativePosition.Rotate (parentTransform.AbsoluteRotation)) * parentTransform.AbsoluteScale + parentTransform.AbsolutePosition;
					else
						_RelativePosition = (_AbsolutePosition.Rotate (-parentTransform.AbsoluteRotation)) / parentTransform.AbsoluteScale - parentTransform.AbsolutePosition;

					if (IsScaleRelative)
						_AbsoluteScale = _RelativeScale * parentTransform.AbsoluteScale;
					else
						_RelativeScale = _AbsoluteScale / parentTransform.AbsoluteScale;

					if (IsRotationRelative)
						_AbsoluteRotation = _RelativeRotation + parentTransform.AbsoluteRotation;
					else
						_RelativeRotation = _AbsoluteRotation - parentTransform.AbsoluteRotation;
				} 
				else 
				{
					if (IsPositionRelative)
						_AbsolutePosition = _RelativePosition;
					else
						_RelativePosition = _AbsolutePosition;

					if (IsScaleRelative)
						_AbsoluteScale = _RelativeScale;
					else
						_RelativeScale = _AbsoluteScale;

					if (IsRotationRelative)
						_AbsoluteRotation = _RelativeRotation;
					else
						_RelativeRotation = _AbsoluteRotation;
				}

				foreach (var entity in AttachedEntity.GetComponents ((Component obj) => obj is Entity && ((Entity) obj).HasComponent<Transform> ()))
					((Entity)entity).GetComponent<Transform>().CalculateTransform ();
			}
		}
	}
}

