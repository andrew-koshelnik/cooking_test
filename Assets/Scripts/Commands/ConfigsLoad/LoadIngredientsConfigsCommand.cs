using System.Linq;
using cooking.so;
using Game;
using Game.Services;
using Models;
using UnityEngine;

namespace cooking.controller
{
	public class LoadIngredientsConfigsCommand : BaseCommand
	{
		[Inject] public GameModel GameModel { get; set; }

		public override void Execute()
		{
			base.Execute();
			
			var configs = Resources.LoadAll<IngredientConfig>("SO/Ingredients");
			
			if (configs != null)
			{
				GameModel.IngredientsConfigs = configs.ToList();
			}
		}
	}
}