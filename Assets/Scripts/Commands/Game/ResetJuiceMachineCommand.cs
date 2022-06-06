using cooking.controller;
using Models;
using Signals.Game;

namespace Commands.Game
{
	public class ResetJuiceMachineCommand : BaseCommand
	{
		[Inject] public GameModel GameModel { get; set; }
		[Inject] public RemoveIngredientFromSourceSignal RemoveIngredientFromSourceSignal { get; set; }
		public override void Execute()
		{
			base.Execute();

			GameModel.JuiceMachineModel.IsFree = true;
			GameModel.JuiceMachineModel.IsCooking = false;
				
			RemoveIngredientFromSourceSignal.Dispatch(GameModel.JuiceMachineModel.ID);
		}
	}
}