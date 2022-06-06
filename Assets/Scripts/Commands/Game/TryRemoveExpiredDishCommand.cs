using cooking.controller;
using cooking.Enum;
using cooking.so;
using Models;
using Signals.Game;
using VO;

namespace cooking.controller
{
	public class TryRemoveExpiredDishCommand : BaseCommand
	{
		[Inject] public string Source { get; set; }
		[Inject] public Ingredients Ingredient { get; set; }
		
		[Inject] public GameModel GameModel { get; set; }
		[Inject] public RemoveIngredientFromSourceSignal RemoveIngredientFromSourceSignal { get; set; }
		
		public override void Execute()
		{
			base.Execute();

			var ingredientConfig = GameModel.GetIngredientConfig(Ingredient);
			var sourceModel = GameModel.GetSourceModel(Source);
			
			if (ingredientConfig != null && sourceModel != null)
			{
				if ( ingredientConfig.IsExpired)
				{
					sourceModel.IsFree = true;
					RemoveIngredientFromSourceSignal.Dispatch(sourceModel.ID);
				}
			}
		}
	}
}