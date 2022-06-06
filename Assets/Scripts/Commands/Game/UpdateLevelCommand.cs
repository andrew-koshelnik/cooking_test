using System.Linq;
using cooking.controller;
using Models;

namespace Commands.Game
{
	public class UpdateLevelCommand : BaseCommand
	{
		[Inject] public bool Status { get; set; }
		[Inject] public LevelModel LevelModel { get; set; }
		[Inject] public GameModel GameModel { get; set; }

		public override void Execute()
		{
			base.Execute();

			if (Status)
			{
				LevelModel.CurrentLevelNumber++;
				
				var levelConfig = GameModel.LevelConfigs.FirstOrDefault(l=>l.ID == LevelModel.CurrentLevelNumber);
			
				if (levelConfig != null)
				{
					LevelModel.LevelConfigConfiguration = levelConfig;
				}
			}
		}
	}
}