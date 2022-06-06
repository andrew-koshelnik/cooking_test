using System.Collections;

namespace Game.Utils
{
	public static class ListExtension
	{
		public static bool AreEqual(this IList first, IList second)
		{
			if (first.Count != second.Count)
			{
				return false;
			}

			for (var elementCounter = 0; elementCounter < first.Count; elementCounter++)
			{
				if (!first[elementCounter].Equals(second[elementCounter]))
				{
					return false;
				}
			}
			return true;
		}
	}
}