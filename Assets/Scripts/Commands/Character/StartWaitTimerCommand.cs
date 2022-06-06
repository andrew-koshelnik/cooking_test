using System;
using System.Linq;
using System.Threading.Tasks;
using cooking.controller;
using Game.Services;
using Models;
using UnityEngine;

namespace Signals.Game
{
	public class StartWaitTimerCommand : BaseCommand
	{
		[Inject] public GameModel GameModel { get; set; }
		[Inject] public WaiterModel WaiterModel { get; set; }
		[Inject] public CharacterWaitTimerChangeSignal CharacterWaitTimerChangeSignal { get; set; }
		[Inject] public CancellationTokenService CancellationTokenService { get; set; }

		public override void Execute()
		{
			base.Execute();

			if (!WaiterModel.IsExpired && WaiterModel?.WaiterConfig.WaitTime > 0)
			{
				Retain();
				Wait();
			}
		}

		private async void Wait()
		{
			var waitTime = (float)WaiterModel.WaiterConfig.WaitTime;
			
			CharacterWaitTimerChangeSignal.Dispatch(WaiterModel.ID, 1);
			
			while (waitTime > 0)
			{
				await Task.Delay(new TimeSpan(0, 0, 0, 0,100));
				
				if(CancellationTokenService.IsCanceled())
					return;
				
				waitTime -= 0.1f;
				if (WaiterModel.IsExpired)
				{
					Release();
					return;
				}
				else
				{
					CharacterWaitTimerChangeSignal.Dispatch(WaiterModel.ID, waitTime / WaiterModel.WaiterConfig.WaitTime);
				}
			}

			WaiterModel.IsExpired = true;
			Release();
		}
	}
}