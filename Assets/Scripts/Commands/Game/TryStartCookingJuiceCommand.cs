using System;
using System.Linq;
using System.Threading.Tasks;
using cooking.controller;
using cooking.Enum;
using cooking.so;
using Game.Services;
using Models;
using Signals;
using Signals.Game;
using UnityEngine;

namespace Commands.Game
{
	public class TryStartCookingJuiceCommand : BaseCommand
	{
		[Inject] public Ingredients Ingredient { get; set; }
		
		[Inject] public GameModel GameModel { get; set; }
		[Inject] public RemoveIngredientFromSourceSignal RemoveIngredientFromSourceSignal { get; set; }
		[Inject] public StartMakingJuiceSignal StartMakingJuiceSignal { get; set; }
		[Inject] public FinishMakingJuiceSignal FinishMakingJuiceSignal { get; set; }
		[Inject] public SpawnIngredientOnJuiceMachineSignal SpawnIngredientOnJuiceMachineSignal { get; set; }
		[Inject] public CancellationTokenService CancellationTokenService { get; set; }

		private IngredientConfig _ingredientConfig;
		
		public override void Execute()
		{
			base.Execute();

			var ingredientConfig = GameModel.IngredientsConfigs.FirstOrDefault(i => i.Type == Ingredient);

			if (ingredientConfig != null && ingredientConfig.Cooker == Cooker.JuiceMachine && GameModel.JuiceMachineModel.IsFree)
			{
				if (!GameModel.JuiceMachineModel.IsCooking)
				{
					GameModel.JuiceMachineModel.IsCooking = true;

					_ingredientConfig = GameModel.IngredientsConfigs.FirstOrDefault(c=>c.Type == Ingredient);

					StartMakingJuiceSignal.Dispatch();
					WaitCooking();
				}
			}
			else
			{
				
			}
		}
		
		private async void WaitCooking()
		{
			await Task.Delay(new TimeSpan(0, 0, _ingredientConfig.CookingTime));
			
			if(CancellationTokenService.IsCanceled())
				return;
			
			var readyIngredient = GameModel.IngredientsConfigs.FirstOrDefault(c=>c.Type == _ingredientConfig.CookedIngredient);
			SpawnIngredientOnJuiceMachineSignal.Dispatch(readyIngredient);
			FinishMakingJuiceSignal.Dispatch();
			
			GameModel.JuiceMachineModel.CurrentIngredients.Add(_ingredientConfig.Type);
			GameModel.JuiceMachineModel.IsCooking = false;
			GameModel.JuiceMachineModel.IsFree = false;
			Release();
		}
	}
}