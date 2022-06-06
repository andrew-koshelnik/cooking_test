using cooking.Events;
using strange.extensions.mediation.impl;
using UnityEngine.UIElements;

namespace Views.PlayPanel
{
	public class PlayPanelMediator: EventMediator
	{
		[Inject] public PlayPanelView View { get; set; }
		[Inject] public StartGameSignal StartGameSignal { get; set; }
		
		public override void OnRegister()
		{
			base.OnRegister();

			View.OnClick += OnClick;
		}

		private void OnClick()
		{
			StartGameSignal.Dispatch();
		}

		public override void OnRemove()
		{
			base.OnRemove();
			
			View.OnClick -= OnClick;
		}
	}
}