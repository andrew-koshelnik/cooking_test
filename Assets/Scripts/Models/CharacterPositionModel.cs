using UnityEngine;

namespace Models
{
	public class CharacterPositionModel
	{
		public Transform Position { get; set; }
		public bool IsFree { get; set; }

		public CharacterPositionModel(Transform position, bool isFree)
		{
			Position = position;
			IsFree = isFree;
		}
	}
}