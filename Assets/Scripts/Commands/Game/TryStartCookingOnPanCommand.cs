using System;
using System.Linq;
using System.Threading.Tasks;
using cooking.Enum;
using cooking.so;
using Game.Services;
using Models;
using Signals.Game;
using UnityEngine;

namespace cooking.controller
{
	public class TryStartCookingOnPanCommand : BaseCommand
	{
		[Inject] public Ingredients Ingredient { get; set; }
		[Inject] public string Source { get; set; }
		
		[Inject] public GameModel GameModel { get; set; }
		[Inject] public SpawnIngredientOnPanSignal SpawnIngredientOnPanSignal { get; set; }
		[Inject] public RemoveIngredientFromSourceSignal RemoveIngredientFromSourceSignal { get; set; }
		[Inject] public CancellationTokenService CancellationTokenService { get; set; }
		
		private IngredientConfig _ingredientConfig;
		private PanModel _panModel;
		private bool _terminated;
		
		public override void Execute()
		{
			base.Execute();
			
			_ingredientConfig = GameModel.IngredientsConfigs.FirstOrDefault(c=>c.Type == Ingredient);

			if (_ingredientConfig != null && _ingredientConfig.Cooker == Cooker.Pan)
			{
				_panModel = GameModel.PanModels.FirstOrDefault(p => p.IsFree);

				if (_panModel != null && _ingredientConfig != null && _ingredientConfig.CookingTime > 0)
				{
					_panModel.IsFree = false;
					
					RemoveIngredientFromSourceSignal.AddListener(OnIngredientRemove);
					
					StartCooking(_panModel);
				}
			}
		}

		private void OnIngredientRemove(string id)
		{
			if (_panModel != null && id == _panModel.ID)
			{
				_terminated = true;
				_panModel.IsFree = true;
			}
		}

		private void StartCooking(PanModel panModel)
		{
			SpawnIngredientOnPanSignal.Dispatch(panModel.ID, _ingredientConfig);
				
			if (_ingredientConfig.CookingTime > 0)
			{
				Retain();
					
				WaitCooking();
			}
		}

		private async void WaitCooking()
		{
			await Task.Delay(new TimeSpan(0, 0, _ingredientConfig.CookingTime));
			
			if(CancellationTokenService.IsCanceled())
				return;
			
			var readyIngredient = GameModel.IngredientsConfigs.FirstOrDefault(c=>c.Type == _ingredientConfig.CookedIngredient);
			SpawnIngredientOnPanSignal.Dispatch(_panModel.ID, readyIngredient);

			await StartExpire(readyIngredient.ExpirationTime);
			
			if(CancellationTokenService.IsCanceled())
				return;
			
			RemoveIngredientFromSourceSignal.RemoveListener(OnIngredientRemove);
			Release();
		}

		private async Task StartExpire(int readyIngredientExpirationTime)
		{
			if (readyIngredientExpirationTime > 0)
			{
				await Task.Delay(new TimeSpan(0, 0, readyIngredientExpirationTime));

				if(CancellationTokenService.IsCanceled())
					return;
				
				if (!_terminated)
				{
					var expiredIngredient = GameModel.IngredientsConfigs.FirstOrDefault(c=>c.Type == _ingredientConfig.ExpiredIngredient);
					SpawnIngredientOnPanSignal.Dispatch(_panModel.ID, expiredIngredient);
				}
			}
		}
	}
}