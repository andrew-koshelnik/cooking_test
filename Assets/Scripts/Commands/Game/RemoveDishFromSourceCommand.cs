using cooking.controller;
using Models;

namespace Commands.Game
{
	public class RemoveDishFromSourceCommand : BaseCommand
	{
		[Inject] public DishSourceModel DishSourceModel { get; set; }

		public override void Execute()
		{
			base.Execute();
			
			DishSourceModel.IsFree = true;
			DishSourceModel.CurrentIngredients.Clear();
		}
	}
}