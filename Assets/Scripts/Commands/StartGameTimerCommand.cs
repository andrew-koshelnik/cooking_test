using System;
using System.Threading.Tasks;
using Game.Services;
using Models;
using Signals;
using Signals.Game;
using UnityEngine.Analytics;

namespace cooking.controller
{
	public class StartGameTimerCommand : BaseCommand
	{
		[Inject] public LevelModel LevelModel { get; set; }
		[Inject] public GameTimerEndedSignal GameTimerEndedSignal { get; set; }
		[Inject] public LevelCompleteSignal LevelCompleteSignal { get; set; }
		[Inject] public CancellationTokenService CancellationTokenService { get; set; }
		
		public override void Execute()
		{
			base.Execute();
			
			LevelModel.CalculateEndTime();
			CancellationTokenService.Reset();
			
			Retain();
			Wait();
		}

		private async void Wait()
		{
			while (LevelModel.EndTime > DateTime.UtcNow)
			{
				await Task.Delay(new TimeSpan(0, 0, 1));
				
				if(CancellationTokenService.IsCanceled())
					return;
			}
			
			GameTimerEndedSignal.Dispatch();
			LevelCompleteSignal.Dispatch(false);
			Release();
		}
	}
}