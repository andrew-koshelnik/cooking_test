using UnityEngine;

namespace cooking.so
{
	[CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObjects/Game", order = 2)]
	public class GameConfig : ScriptableObject
	{
		public int CharacterSpeed;
	}
}