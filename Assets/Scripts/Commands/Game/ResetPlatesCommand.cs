using cooking.controller;
using Models;
using Signals.Game;

namespace Commands.Game
{
	public class ResetPlatesCommand : BaseCommand
	{
		[Inject] public GameModel GameModel { get; set; }
		[Inject] public RemoveDishFromSourceSignal RemoveDishFromSourceSignal { get; set; }
		
		public override void Execute()
		{
			base.Execute();

			foreach (var model in GameModel.PlateModels)
			{
				model.IsFree = true;
				model.CurrentIngredients.Clear();
				RemoveDishFromSourceSignal.Dispatch(model);
			}
		}
	}
}