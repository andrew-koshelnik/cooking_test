using System.Collections.Generic;
using System.Linq;
using cooking.controller;
using cooking.Enum;
using cooking.so;
using Game.Utils;
using Models;
using Signals.Game;
using UnityEngine;

namespace Commands.Game
{
	public class TryAddIngredientOnPlateCommand : BaseCommand
	{
		[Inject] public string Source { get; set; }
		[Inject] public Ingredients Ingredient { get; set; }
		
		[Inject] public GameModel GameModel { get; set; }

		[Inject] public SpawnIngredientOnPlateSignal SpawnIngredientOnPlateSignal { get; set; }
		[Inject] public RemoveIngredientFromSourceSignal RemoveIngredientFromSourceSignal { get; set; }
		
		public override void Execute()
		{
			base.Execute();

			var plateModel = FindSuitablePlate();
			var ingredientConfig = GameModel.IngredientsConfigs.FirstOrDefault(i => i.Type == Ingredient);

			if (ingredientConfig != null && ingredientConfig.Cooker == Cooker.Plate)
			{
				if (plateModel != null)
				{
					SpawnIngredient(plateModel, ingredientConfig);
				}
			}
		}

		private void SpawnIngredient(DishSourceModel DishSourceModel, IngredientConfig ingredientConfig)
		{
			if (DishSourceModel != null)
			{
				DishSourceModel.IsFree = false;
				DishSourceModel.CurrentIngredients.Add(Ingredient);

				SpawnIngredientOnPlateSignal.Dispatch(DishSourceModel.ID, ingredientConfig);
				
				RemoveIngredientFromSourceSignal.Dispatch(Source);
			}
		}

		private DishSourceModel FindSuitablePlate()
		{
			var recipes = GameModel.DishConfigs.FindAll(r => r.Ingredients.Contains(Ingredient));
			
			DishSourceModel DishSourceModel = null;
			
			if (recipes.Count > 0)
			{

				foreach (var recipe in recipes)
				{
					var ingredientOrder = recipe.Ingredients.IndexOf(Ingredient);
					var requiredIngredient = recipe.Ingredients.GetRange(0, ingredientOrder);
					
					if (requiredIngredient.Count == 0)
					{
						DishSourceModel = GameModel.PlateModels.FirstOrDefault(p => p.IsFree);
					}
					else
					{
						foreach (var plate in GameModel.PlateModels)
						{
							if (plate.CurrentIngredients.AreEqual(requiredIngredient))
							{
								return plate;
							}
						}
					}
				}
			}
			
			return DishSourceModel;
		}
	}
}