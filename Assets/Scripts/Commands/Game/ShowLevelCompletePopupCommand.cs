using cooking.controller;
using cooking.Enum;
using Game.Services;
using Models;
using Views;

namespace Commands.Game
{
	public class ShowLevelCompletePopupCommand : BaseCommand
	{
		[Inject] public bool Status { get; set; }
		[Inject] public AssetService AssetService { get; set; }
		[Inject] public LevelModel LevelModel { get; set; }
		public override void Execute()
		{
			base.Execute();

			LevelModel.IsWin = Status;
			AssetService.Spawn(AssetsConstants.LEVECOMPLETEPOPUP, Layers.WINDOWS);
		}
	}
}