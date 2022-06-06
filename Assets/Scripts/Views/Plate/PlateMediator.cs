using cooking.so;
using Game.Services;
using Models;
using Signals.Game;
using strange.extensions.mediation.impl;
using UnityEngine;
using Views.Pan;

namespace Views.Plate
{
	public class PlateMediator : EventMediator
	{
		[Inject] public PlateView View { get; set; }
		[Inject] public SpawnIngredientOnPlateSignal SpawnIngredientOnPlateSignal { get; set; }
		[Inject] public AssetService AssetService { get; set; }
		[Inject] public TryConsumeDishSignal TryConsumeDishSignal { get; set; }
		[Inject] public RemoveDishFromSourceSignal RemoveDishFromSourceSignal { get; set; }
		public DishSourceModel DishSourceModel { get; set; }
		
		public override void OnRegister()
		{
			base.OnRegister();

			SpawnIngredientOnPlateSignal.AddListener(OnSpawnIngredient);
			RemoveDishFromSourceSignal.AddListener(CleanUpPlate);
			View.OnClick += OnClick;
			View.OnDoubleClick += OnDoubleClick;
		}

		private void CleanUpPlate(DishSourceModel DishSourceModel)
		{
			if (DishSourceModel.ID == this.DishSourceModel.ID)
			{
				CleanUpHolder();	
			}
		}

		private void OnClick()
		{
			TryConsumeDishSignal.Dispatch(DishSourceModel);
		}

		private void OnDoubleClick()
		{
			RemoveDishFromSourceSignal.Dispatch(DishSourceModel);
		}
		
		private void OnSpawnIngredient(string plateId, IngredientConfig ingredientConfig)
		{
			if (DishSourceModel?.ID == plateId && ingredientConfig != null)
			{
				AssetService.SpawnAt(ingredientConfig.Prefab, View.Holder);
			}
		}

		public void CleanUpHolder()
		{
			foreach (Transform child in View.Holder.transform) 
			{
				Destroy(child.gameObject);
			}
		}
		
		public override void OnRemove()
		{
			base.OnRemove();
			
			SpawnIngredientOnPlateSignal.RemoveListener(OnSpawnIngredient);
			RemoveDishFromSourceSignal.RemoveListener(CleanUpPlate);
			
			View.OnClick -= OnClick;
			View.OnDoubleClick -= OnDoubleClick;
		}
	}
}