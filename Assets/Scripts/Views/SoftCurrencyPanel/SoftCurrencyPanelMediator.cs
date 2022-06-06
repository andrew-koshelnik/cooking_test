using cooking.Enum;
using Game.Services;
using Models;
using Signals;
using strange.extensions.mediation.impl;

namespace Views.SoftCurrencyPanel
{
	public class SoftCurrencyPanelMediator : EventMediator
	{
		[Inject] public SoftCurrencyPanelView View { get; set; }
		
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
			if(currency == Currency.Coins)
				View.SetText(value.ToString());
		}
	}
}