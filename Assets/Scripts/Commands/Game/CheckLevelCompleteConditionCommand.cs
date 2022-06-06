using cooking.controller;
using Models;
using Signals.Game;

namespace Commands.Game
{
	public class CheckLevelCompleteConditionCommand : BaseCommand
	{
		[Inject] public WaiterModel WaiterModel { get; set; }
		[Inject] public LevelModel LevelModel { get; set; }
		[Inject] public LevelCompleteSignal LevelCompleteSignal { get; set; }

		public override void Execute()
		{
			base.Execute();

			if (LevelModel.TimeLeft.TotalSeconds > 0 && LevelModel.LevelConfigConfiguration.TargetDishServed > 0)
			{
				if (LevelModel.SurvedDishes >= LevelModel.LevelConfigConfiguration.TargetDishServed)
				{
					LevelCompleteSignal.Dispatch(true);
				}
			}
		}
	}
}