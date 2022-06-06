using System;
using System.Threading;
using System.Threading.Tasks;
using cooking.controller;
using Game.Services;
using Models;
using Signals.Game;
using Random = UnityEngine.Random;

namespace Commands.Character
{
	public class StartWaitersMoveCommand : BaseCommand
	{
		[Inject] public GameModel GameModel { get; set; }
		[Inject] public LevelModel LevelModel { get; set; }
		[Inject] public MoveCharacterSignal MoveCharacterSignal { get; set; }
		[Inject] public CancellationTokenService CancellationTokenService { get; set; }
		
		public override void Execute()
		{
			base.Execute();

			StartWaitersMove();
			WaitForCustomer();
		}

		private async void WaitForCustomer()
		{
			while (LevelModel.EndTime > DateTime.UtcNow)
			{
				int cooldown = Random.Range(LevelModel.LevelConfigConfiguration.MinSpawnTime, LevelModel.LevelConfigConfiguration.MaxSpawnTime);
		
				if (LevelModel.LevelConfigConfiguration.MaxSpawnTime > 0)
				{
					await Task.Delay(new TimeSpan(0, 0, cooldown));
					
					if(CancellationTokenService.IsCanceled())
						return;
				}
				
				StartWaitersMove();
			}
			
			Release();
		}

		private void StartWaitersMove()
		{
			var freeCharacter = GameModel.WaitersModels.Find(c => c.IsWaitingNewOrder);

			if (freeCharacter != null)
			{
				freeCharacter.IsExpired = false;
				freeCharacter.IsWaitingNewOrder = false;

				MoveCharacterSignal.Dispatch(freeCharacter.ID, freeCharacter.CharacterPosition);
			}
		}
	}
}