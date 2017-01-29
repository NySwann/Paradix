using System;
using System.Collections.Generic;
using System.Linq;

namespace Paradix
{
	public static class Contract
	{
		public static void Requires (bool precondition, string message)
		{
			RequiresNotEmpty (message, "message");

			if (!precondition)
				throw new ArgumentException (message);
		}

		public static void RequiresNotNull (object value, string paramName)
		{
			RequiresNotEmpty (paramName, "paramName");

			if (value == null)
				throw new ArgumentNullException (paramName + " must not be null");
		}

		public static void RequiresNotEmpty (string str, string paramName)
		{
			if (String.IsNullOrEmpty (paramName))
				throw new ArgumentException ("paramName string must not be empty");

			if (String.IsNullOrEmpty (str))
				throw new ArgumentException (paramName + " string must not be empty");
		}

		public static void RequiresNotEmpty<T> (IEnumerable<T> collection, string paramName)
		{
			RequiresNotEmpty (paramName, "paramName");
			RequiresNotNull (collection, "collection");

			if (collection.Count () == 0)
				throw new ArgumentException (paramName + " collection must not be empty");
		}

		public static void RequiresPositive (int value, string paramName)
		{
			RequiresNotEmpty (paramName, "paramName");

			if (value <= 0)
				throw new ArgumentNullException (paramName + " must be positive");
		}

		public static void RequiresPositiveOrNull (int value, string paramName)
		{
			RequiresNotEmpty (paramName, "paramName");

			if (value < 0)
				throw new ArgumentNullException (paramName + " must be positive or null");
		}

		public static Exception Unreachable 
		{
			get 
			{
				return new InvalidOperationException ("Code supposed to be unreachable");
			}
		}
	}
}
