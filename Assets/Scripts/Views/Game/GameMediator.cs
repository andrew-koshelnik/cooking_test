using cooking.controller;
using cooking.Enum;
using Game.Services;
using Models;
using Signals.Game;
using strange.extensions.mediation.impl;
using VO;

namespace Views.Game
{
	public class GameMediator: EventMediator
	{
		[Inject] public GameView View { get; set; }
		[Inject] public GameModel GameModel { get; set; }
		[Inject] public HideGameSignal HideGameSignal { get; set; }
		[Inject] public ShowGameSignal ShowGameSignal { get; set; }
		[Inject] public InitGameSpawnPointsSignal InitGameSpawnPointsSignal { get; set; }
		[Inject] public InitPanModelsSignal InitPanModelsSignal { get; set; }
		[Inject] public InitPlateModelsSignal InitPlateModelsSignal { get; set; }
		[Inject] public IngredientClickSignal IngredientClickSignal { get; set; }
		[Inject] public TryConsumeDishSignal TryConsumeDishSignal { get; set; }
		
		[Inject] public AssetBundleService AssetBundleService { get; set; }

		public override void OnRegister()
		{
			base.OnRegister();
            
			HideGameSignal.AddListener(HideGame);
			ShowGameSignal.AddListener(ShowGame);
			

			View.BunButtonClick += OnBunClick;
			View.BurgerButtonClick += OnBurgerClick;
			View.TomatoButtonClick += OnTomatoClick;
			View.SaladButtonClick += OnSaladClick;
			View.JuiceMachineButtonClick += OnJuiceMachineClick;
			
			InitGameSpawnPointsSignal.Dispatch(new CharacterSpawnVO(View.CharactersHolder, View.LeftSpawnPoint, View.LeftCharactersPositions, View.RightSpawnPoint, View.RightCharactersPositions ));
			InitPanModelsSignal.Dispatch(View.Pans);
			InitPlateModelsSignal.Dispatch(View.PlateViews);
		}

		private void OnJuiceMachineClick()
		{
			if (GameModel.JuiceMachineModel.IsFree)
			{
				IngredientClickSignal.Dispatch(string.Empty, Ingredients.JuiceIngredient);
			}
			else
			{
				TryConsumeDishSignal.Dispatch(GameModel.JuiceMachineModel);
			}
		}

		private void OnBunClick()
		{
			IngredientClickSignal.Dispatch(string.Empty, Ingredients.Bun);
		}

		private void OnBurgerClick()
		{
			IngredientClickSignal.Dispatch(string.Empty, Ingredients.RawBurger);
		}

		private void OnTomatoClick()
		{
			IngredientClickSignal.Dispatch(string.Empty, Ingredients.Tomato);
		}

		private void OnSaladClick()
		{
			IngredientClickSignal.Dispatch(string.Empty, Ingredients.Lettuce);
		}

		private void ShowGame()
		{
			View.Show();
		}

		private void HideGame()
		{
			View.Hide();
		}

		public override void OnRemove()
		{
			base.OnRemove();
            
			HideGameSignal.RemoveListener(HideGame);
			ShowGameSignal.RemoveListener(ShowGame);
			
			View.BunButtonClick -= OnBunClick;
			View.BurgerButtonClick -= OnBurgerClick;
			View.TomatoButtonClick -= OnTomatoClick;
			View.SaladButtonClick -= OnSaladClick;
		}
	}
}