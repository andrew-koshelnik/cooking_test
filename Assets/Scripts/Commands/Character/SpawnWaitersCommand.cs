using System;
using System.Linq;
using System.Threading.Tasks;
using cooking.Enum;
using cooking.so;
using Game;
using Game.Services;
using Models;
using Signals.Game;
using Views.Character;
using Random = UnityEngine.Random;

namespace cooking.controller
{
	public class SpawnWaitersCommand : BaseCommand
	{
		[Inject] public AssetService AssetService { get; set; }
		[Inject] public CharacterSpawnModel CharacterSpawnModel { get; set; }
		[Inject] public GameModel GameModel { get; set; }
		[Inject] public LevelModel LevelModel { get; set; }
		
		public override void Execute()
		{
			base.Execute();

			for (int i = 0; i < LevelModel.LevelConfigConfiguration.NumberOfWaiters; i++)
			{
				var config = GameModel.WaiterConfigs[i % GameModel.WaiterConfigs.Count];
				
				TrySpawnCharacter(config);
			}
		}

		private void TrySpawnCharacter(WaiterConfig waiterConfig)
		{
			//1 - left, 2 - right
			var side = (Side)Random.Range(1, 3);

			var position = GetPositionFromPreferredSide(side, out var spawnPosition);

			if (position != null)
			{
				SpawnCharacter(waiterConfig, position, spawnPosition);
			}
		}

		private CharacterPositionModel GetPositionFromPreferredSide(Side side, out CharacterPositionModel spawnPosition)
		{
			CharacterPositionModel positionModel;
			
			var leftFreePosition = CharacterSpawnModel.LeftCharactersPositions.FirstOrDefault(p => p.IsFree);
			var rightFreePosition = CharacterSpawnModel.RightCharactersPositions.FirstOrDefault(p => p.IsFree);
			
			if (side == Side.LEFT)
			{
				positionModel = leftFreePosition;
				spawnPosition = CharacterSpawnModel.LeftSpawnPoint;
			}
			else
			{
				positionModel = rightFreePosition;
				spawnPosition = CharacterSpawnModel.RightSpawnPoint;
			}

			return positionModel;
		}

		private void SpawnCharacter(WaiterConfig config, CharacterPositionModel position, CharacterPositionModel spawnPosition)
		{
			var model = new WaiterModel(Guid.NewGuid().ToString(), position, spawnPosition, config);
			GameModel.WaitersModels.Add(model);

			var character = AssetService.SpawnAt(
				config.Prefab,
				CharacterSpawnModel.CharacterHolder,
				spawnPosition.Position.localPosition);

			var characterMediator = character.GetComponent<CharacterMediator>();
			
			if (characterMediator != null)
			{
				position.IsFree = false;
				model.IsWaitingNewOrder = true;
				characterMediator.WaiterModel = model;
			}
		}
	}
}