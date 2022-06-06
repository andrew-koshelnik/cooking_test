﻿using cooking.Enum;
using Game.Services;

namespace cooking.controller
{
	public class LoadLobbyHudCommand : BaseCommand
	{
		[Inject] public AssetService AssetService { get; set; }
		
		public override void Execute()
		{
			base.Execute();
			
			AssetService.Spawn(AssetsConstants.LOBBYHUD, Layers.HUD);
		}
	}
}