using cooking.Enum;
using Game.Services;
using Models;
using Signals;
using strange.extensions.mediation.impl;

namespace Views.StarPanel
{
	public class StarPanelMediator : EventMediator
	{
		[Inject] public StarPanelView View { get; set; }
		
		[Inject] public CurrencyChangeSignal CurrencyChangeSignal { get; set; }
		[Inject] public InventoryModel InventoryModel { get; set; }
		[Inject] public AssetService AssetService { get; set; }
		public override void OnRegister()
		{
			base.OnRegister();
			
			View.SetText(InventoryModel.Value(Currency.Stars).ToString());
			
			CurrencyChangeSignal.AddListener(OnCurrencyChange);
			
			
			AssetService.Link(AssetsConstants.STARPANEL, View.gameObject);
		}

		private void OnCurrencyChange(Currency currency, int value)
		{
			if(currency == Currency.Stars)
				View.SetText(value.ToString());
		}
	}
}