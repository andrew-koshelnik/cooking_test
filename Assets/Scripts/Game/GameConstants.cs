using System.Collections.Generic;

namespace Game
{
	public static class GameConstants
	{
		public const string LevelNameFormat = "Level_{0}";
		public static List<string> Characters = new List<string>()
		{
			AssetsConstants.CHARACTER_1,
			AssetsConstants.CHARACTER_2,
			AssetsConstants.CHARACTER_3,
			AssetsConstants.CHARACTER_4,
		};
	}
}