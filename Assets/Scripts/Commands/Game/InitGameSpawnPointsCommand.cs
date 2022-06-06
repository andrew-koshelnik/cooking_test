using System.Collections.Generic;
using Models;
using UnityEngine;
using VO;

namespace cooking.controller
{
	public class InitGameSpawnPointsCommand : BaseCommand
	{
		[Inject] public CharacterSpawnModel CharacterSpawnModel { get; set; }
		
		[Inject] public CharacterSpawnVO CharacterSpawnVO { get; set; }
		
		public override void Execute()
		{
			base.Execute();

			CharacterSpawnModel.CharacterHolder = CharacterSpawnVO.CharacterHolder;
			
			CharacterSpawnModel.LeftSpawnPoint = new CharacterPositionModel(CharacterSpawnVO.LeftSpawnPoint, true);
			CharacterSpawnModel.RightSpawnPoint = new CharacterPositionModel(CharacterSpawnVO.RightSpawnPoint, true);
			
			CharacterSpawnModel.LeftCharactersPositions = new List<CharacterPositionModel>();
			CharacterSpawnModel.RightCharactersPositions = new List<CharacterPositionModel>();
			
			foreach (var charactersPosition in CharacterSpawnVO.LeftCharactersPositions)
			{
				CharacterSpawnModel.LeftCharactersPositions.Add(new CharacterPositionModel(charactersPosition, true));
			}
			
			foreach (var charactersPosition in CharacterSpawnVO.RightCharactersPositions)
			{
				CharacterSpawnModel.RightCharactersPositions.Add(new CharacterPositionModel(charactersPosition, true));
			}
		}
	}
}