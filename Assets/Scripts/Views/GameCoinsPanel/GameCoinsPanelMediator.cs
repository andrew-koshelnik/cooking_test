using cooking.Enum;
using Models;
using Signals;
using strange.extensions.mediation.impl;
using Views.SoftCurrencyPanel;

namespace Views.GameCoinsPanel
{
	public class GameCoinsPanelMediator: EventMediator
	{
		[Inject] public GameCoinsPanelView View { get; set; }
		
		[Inject] public CurrencyChangeSignal CurrencyChangeSignal { get; set; }
		[Inject] public InventoryModel InventoryModel { get; set; }
		public override void OnRegister()
		{
			base.OnRegister();
			
			View.SetText(InventoryModel.Value(Currency.Coins).ToString());
			
			CurrencyChangeSignal.AddListener(OnCurrencyChange);
		}

		private void OnCurrencyChange(Currency currency, int value)
		{
			if(currency == Currency.PendingCoins)
				View.SetText(value.ToString());
		}
	}
}