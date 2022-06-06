using cooking.so;
using Game.Services;
using Models;
using Signals;
using Signals.Game;
using strange.extensions.mediation.impl;
using UnityEngine;
using Views.Order;
using Views.Pan;

namespace Views.Juice
{
	public class JuiceMachineMediator : EventMediator
	{
		[Inject] public JuiceMachineView JuiceMachineView { get; set; }
		[Inject] public GameModel GameModel { get; set; }
		
		[Inject] public StartMakingJuiceSignal StartMakingJuiceSignal { get; set; }
		[Inject] public FinishMakingJuiceSignal FinishMakingJuiceSignal { get; set; }
		[Inject] public SpawnIngredientOnJuiceMachineSignal SpawnIngredientOnJuiceMachineSignal { get; set; }
		[Inject] public RemoveIngredientFromSourceSignal RemoveIngredientFromSourceSignal { get; set; }
		[Inject] public RemoveDishFromSourceSignal RemoveDishFromSourceSignal { get; set; }
		[Inject] public AssetService AssetService { get; set; }

		public override void OnRegister()
		{
			base.OnRegister();
			
			SpawnIngredientOnJuiceMachineSignal.AddListener(OnSpawnIngredient);
			StartMakingJuiceSignal.AddListener(OnStartCooking);
			FinishMakingJuiceSignal.AddListener(OnFinishCooking);
			RemoveIngredientFromSourceSignal.AddListener(OnRemoveIngredient);
			RemoveDishFromSourceSignal.AddListener(OnRemoveDishFromSource);
		}

		private void OnRemoveDishFromSource(DishSourceModel source)
		{
			if (GameModel.JuiceMachineModel.ID == source.ID)
			{
				CleanUpHolder();
			}
		}

		private void OnRemoveIngredient(string id)
		{
			if (GameModel.JuiceMachineModel.ID == id)
			{
				CleanUpHolder();
			}
		}

		private void OnFinishCooking()
		{
			JuiceMachineView.SetActiveCookTimer(false);
		}

		private void OnStartCooking()
		{
			JuiceMachineView.SetActiveCookTimer(true);
		}

		private void OnSpawnIngredient(IngredientConfig ingredientConfig)
		{
			if (ingredientConfig != null)
			{
				AssetService.SpawnAt(ingredientConfig.Prefab, JuiceMachineView.Holder);
			}
		}

		public override void OnRemove()
		{
			base.OnRemove();
			
			SpawnIngredientOnJuiceMachineSignal.RemoveListener(OnSpawnIngredient);
			StartMakingJuiceSignal.RemoveListener(OnStartCooking);
			FinishMakingJuiceSignal.RemoveListener(OnFinishCooking);
			RemoveIngredientFromSourceSignal.RemoveListener(OnRemoveIngredient);
			RemoveDishFromSourceSignal.RemoveListener(OnRemoveDishFromSource);
		}
		
		public void CleanUpHolder()
		{
			foreach (Transform child in JuiceMachineView.Holder) 
			{
				Destroy(child.gameObject);
			}
		}
	}
}