using System.Collections.Generic;
using UnityEngine;

namespace Models
{
	public class CharacterSpawnModel
	{
		public Transform CharacterHolder { get; set; }
		
		public CharacterPositionModel LeftSpawnPoint;
		public List<CharacterPositionModel> LeftCharactersPositions;
		public CharacterPositionModel RightSpawnPoint;
		public List<CharacterPositionModel> RightCharactersPositions;
	}
}