using System.Collections.Generic;
using UnityEngine;

namespace VO
{
	public class CharacterSpawnVO
	{
		public Transform CharacterHolder { get; set; }
		public Transform LeftSpawnPoint;
		public List<Transform> LeftCharactersPositions;
		public Transform RightSpawnPoint;
		public List<Transform> RightCharactersPositions;
		
		public CharacterSpawnVO(Transform charactersHolder, Transform leftSpawnPoint, List<Transform> leftCharactersPositions, Transform rightSpawnPoint, List<Transform> rightCharactersPositions)
		{
			CharacterHolder = charactersHolder;
			LeftSpawnPoint = leftSpawnPoint;
			LeftCharactersPositions = leftCharactersPositions;
			RightSpawnPoint = rightSpawnPoint;
			RightCharactersPositions = rightCharactersPositions;
		}

	}
}