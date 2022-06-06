using Game.Services;
using Models;
using strange.extensions.mediation.impl;

namespace Views.GameTimerPanel
{
	public class GameTimerPanelMediator: EventMediator
	{
		[Inject] public GameTimerPanelView View { get; set; }
		[Inject] public Timer Timer { get; set; }
		[Inject] public LevelModel LevelModel { get; set; }
		
		public override void OnRegister()
		{
			base.OnRegister();
			
			Timer.OnSecond += OnTimerChange;
			OnTimerChange();
		}

		private void OnEnable()
		{
			OnTimerChange();
		}

		private void OnTimerChange()
		{
			if(View != null && LevelModel != null)
				View.SetText(LevelModel.TimeLeft.ToString(@"mm\:ss"));
		}

		public override void OnRemove()
		{
			base.OnRemove();
			
			Timer.OnSecond -= OnTimerChange;
		}
	}
}