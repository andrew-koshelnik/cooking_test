using cooking.controller;
using Signals;
using strange.extensions.mediation.impl;

namespace Views.Loading
{
	public class LoadingMediator : EventMediator
	{
		[Inject] public LoadingView View { get; set; }
		
		[Inject] public HideLoadingSignal HideLoadingSignal { get; set; }
		
		public override void OnRegister()
		{
			base.OnRegister();
			
			HideLoadingSignal.AddListener(OnHideLoading);
		}

		private void OnHideLoading()
		{
			View.Hide();
		}
	}
}