using System.Linq;
using cooking.so;
using Game;
using Game.Services;
using Models;
using UnityEngine;

namespace cooking.controller
{
	public class LoadLevelConfigCommand: BaseCommand
	{
		[Inject] public LevelModel LevelModel { get; set; }
		[Inject] public GameModel GameModel { get; set; }
		[Inject] public AssetService AssetService { get; set; }

		public override void Execute()
		{
			base.Execute();
			
			var configs = Resources.LoadAll<LevelConfig>("SO/Levels");
			GameModel.LevelConfigs = configs.ToList();

			var levelConfig = GameModel.LevelConfigs.FirstOrDefault(l=>l.ID == LevelModel.CurrentLevelNumber);
			
			if (levelConfig != null)
			{
				LevelModel.LevelConfigConfiguration = levelConfig;
			}
		}
	}
}