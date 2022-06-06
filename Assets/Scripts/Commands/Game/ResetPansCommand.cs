using cooking.controller;
using Models;
using Signals.Game;

namespace Commands.Game
{
	public class ResetPansCommand : BaseCommand
	{
		[Inject] public GameModel GameModel { get; set; }
		[Inject] public RemoveDishFromSourceSignal RemoveDishFromSourceSignal { get; set; }
		[Inject] public RemoveIngredientFromSourceSignal RemoveIngredientFromSourceSignal { get; set; }
		public override void Execute()
		{
			base.Execute();

			foreach (var model in GameModel.PanModels)
			{
				model.IsFree = true;
				model.CurrentDish = null;
				
				RemoveIngredientFromSourceSignal.Dispatch(model.ID);
			}
		}
	}
}