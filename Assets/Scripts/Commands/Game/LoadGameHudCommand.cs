using cooking.Enum;
using Game.Services;

namespace cooking.controller
{
	public class LoadGameHudCommand: BaseCommand
	{
		[Inject] public AssetService AssetService { get; set; }
		
		public override void Execute()
		{
			base.Execute();
			
			AssetService.Spawn(AssetsConstants.GAMEHUD, Layers.HUD);
		}
	}
}