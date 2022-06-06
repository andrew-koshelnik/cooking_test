using System;
using System.Threading.Tasks;
using cooking.Enum;
using Game;
using Game.Services;
using Signals;
using UnityEngine;

namespace cooking.controller
{
	public class LoadLobbyCommand : BaseCommand
	{
		[Inject] public AssetService AssetService { get; set; }
		[Inject] public GameManager GameManager { get; set; }
		[Inject] public AssetBundleService AssetBundleService { get; set; }
		
		public override void Execute()
		{
			base.Execute();
			Retain();
			LoadBundle();
			GameManager.RootMono.StartCoroutine(AssetBundleService.GetLobbyAssetBundle());
		}

		private async void LoadBundle()
		{
			while (AssetBundleService.LobbyAssetBundle == null)
			{
				await Task.Yield();
			}
			
			var customAssetRequest = AssetBundleService.LobbyAssetBundle.LoadAssetAsync("Lobby");

			while (!customAssetRequest.isDone)
			{
				await Task.Yield();
			}
			
			AssetService.SpawnAt((GameObject)customAssetRequest.asset, Layers.LOBBY);
			
			Release();
		}
	}
}