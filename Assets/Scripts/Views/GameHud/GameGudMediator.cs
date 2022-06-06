using Events;
using Signals.Game;
using strange.extensions.mediation.impl;
using Views.Game;

namespace Views.GameHud
{
	public class GameGudMediator: EventMediator
	{
		[Inject] public GameHudView View { get; set; }
		[Inject] public ShowGameHudSignal ShowGameHudSignal { get; set; }
		[Inject] public HideGameHudSignal HideGameHudSignal { get; set; }

		public override void OnRegister()
		{
			base.OnRegister();
            
			View.Init();
			
			ShowGameHudSignal.AddListener(Show);
			HideGameHudSignal.AddListener(Hide);
		}

		private void Hide()
		{
			View.Hide();
		}

		private void Show()
		{
			View.Show();
		}

		public override void OnRemove()
		{
			base.OnRemove();
			
			ShowGameHudSignal.RemoveListener(Show);
			HideGameHudSignal.RemoveListener(Hide);
		}
	}
}