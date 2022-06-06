using cooking.so;
using Game;
using Game.Services;
using Models;

namespace cooking.controller
{
	public class LoadGameConfigCommand: BaseCommand
	{
		[Inject] public GameModel GameModel { get; set; }
		[Inject] public AssetService AssetService { get; set; }

		public override void Execute()
		{
			base.Execute();
			
			var gameConfig = AssetService.Get<GameConfig>(AssetsConstants.GAMECONFIG);

			if (gameConfig != null)
			{
				GameModel.GameConfig = gameConfig;
			}
		}
	}
}