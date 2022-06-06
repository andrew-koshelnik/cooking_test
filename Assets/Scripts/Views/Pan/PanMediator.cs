using System.Linq;
using cooking.controller;
using cooking.so;
using Game.Services;
using Models;
using Signals.Game;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UIElements;
using VO;

namespace Views.Pan
{
	public class PanMediator : EventMediator
	{
		[Inject] public PanView PanView { get; set; }
		[Inject] public SpawnIngredientOnPanSignal SpawnIngredientOnPanSignal { get; set; }
		[Inject] public IngredientClickSignal IngredientClickSignal { get; set; }
		[Inject] public RemoveIngredientFromSourceSignal RemoveIngredientFromSourceSignal { get; set; }
		
		[Inject] public GameModel GameModel { get; set; }
		[Inject] public AssetService AssetService { get; set; }
		
		public PanModel PanModel { get; set; }
		public IngredientConfig IngredientConfig { get; set; }
		
		public override void OnRegister()
		{
			base.OnRegister();

			SpawnIngredientOnPanSignal.AddListener(OnSpawnIngredient);
			RemoveIngredientFromSourceSignal.AddListener(RemoveIngredientFromSource);
			PanView.OnClick += OnClick;
		}

		private void RemoveIngredientFromSource(string panID)
		{
			if (PanModel?.ID == panID)
			{
				CleanUpHolder();
				IngredientConfig = null;
				PanView.SetActiveCookTimer(false);
				PanView.SetActiveExpireTimer(false);
			}
		}

		private void OnClick()
		{
			if (PanModel != null && IngredientConfig != null)
			{
				IngredientClickSignal.Dispatch(PanModel.ID, IngredientConfig.Type);
			}
		}

		private void OnSpawnIngredient(string panId, IngredientConfig ingredientConfig)
		{
			if (PanModel?.ID == panId && ingredientConfig != null)
			{
				IngredientConfig = ingredientConfig;
				
				CleanUpHolder();
					
				AssetService.SpawnAt(ingredientConfig.Prefab, PanView.BurgerHolder);

				PanView.SetActiveCookTimer(ingredientConfig.CookingTime > 0);
				PanView.SetActiveExpireTimer(ingredientConfig.ExpirationTime > 0);
			}
		}

		public void CleanUpHolder()
		{
			foreach (Transform child in PanView.BurgerHolder.transform) 
			{
				Destroy(child.gameObject);
			}
		}

		public override void OnRemove()
		{
			base.OnRemove();
			
			SpawnIngredientOnPanSignal.RemoveListener(OnSpawnIngredient);
			RemoveIngredientFromSourceSignal.RemoveListener(RemoveIngredientFromSource);
			
			PanView.OnClick -= OnClick;
		}
	}
}