using cooking.controller;
using Models;
using Signals.Game;

namespace Commands.Game
{
	public class CheckReadyOrdersCommand : BaseCommand
	{
		[Inject] public GameModel GameModel { get; set; }
		[Inject] public OrderCompletedSignal OrderCompletedSignal { get; set; }

		public override void Execute()
		{
			base.Execute();

			foreach (var waiterModel in GameModel.WaitersModels)
			{
				if (waiterModel.OrderModel != null && waiterModel.OrderModel.Dishes.TrueForAll(model => model.IsReady))
				{
					waiterModel.IsExpired = true;
					OrderCompletedSignal.Dispatch(waiterModel);
				}
			}
		}
	}
}