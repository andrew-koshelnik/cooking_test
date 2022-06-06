using cooking.Enum;
using Models;
using Signals;
using Signals.Game;
using strange.extensions.mediation.impl;

namespace Views
{
	public class LevelCompletePopupMediator : EventMediator
	{
		[Inject] public LevelCompletePopupView View { get; set; }
		[Inject] public LevelModel LevelModel { get; set; }
		[Inject] public InventoryModel InventoryModel { get; set; }
		[Inject] public SwitchToLobbySignal SwitchToLobbySignal { get; set; }
		[Inject] public RestartGameSignal RestartGameSignal { get; set; }
		
		public override void OnRegister()
		{
			base.OnRegister();

			View.OnLobbyClick += OnLobbyClick;
			View.OnRetryClick += OnRetryClick;
			
			View.SetLevelText($"Level {LevelModel.CurrentLevelNumber}");
			View.SetCoinsText($"{InventoryModel.Value(Currency.PendingCoins)}");
			View.SetContent(LevelModel.IsWin);
		}

		private void OnRetryClick()
		{
			RestartGameSignal.Dispatch();
			
			Destroy(gameObject);
		}

		private void OnLobbyClick()
		{
			SwitchToLobbySignal.Dispatch();
			
			Destroy(gameObject);
		}

		public override void OnRemove()
		{
			base.OnRemove();
			
			View.OnRetryClick -= OnRetryClick;
			View.OnLobbyClick -= OnLobbyClick;
		}
	}
}